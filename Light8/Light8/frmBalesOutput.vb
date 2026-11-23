Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBalesOutput

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Not String.IsNullOrEmpty(txtBarcode.Text) Then
            If Asc(e.KeyChar) = 13 Then
                e.Handled = True
                isBarCodeEntry = True
                AddBarCode(txtBarcode.Text)
                isBarCodeEntry = False
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtBarcode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBarcode.Validating
        If Not String.IsNullOrEmpty(txtBarcode.Text) Then
            AddBarCode(txtBarcode.Text)
        End If
    End Sub

    Private Sub AddBarCode(ByVal barcode As String)
        On Error GoTo RaiseErr

        If AlreadyScanned(barcode) = True Then
            MessageBox.Show("This bale has already been scanned through", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBarcode.Clear()
            txtBarcode.Select()
        Else
            If BaleSent(barcode) = True Then
                MessageBox.Show("This bale has already been scanned out", "Bale Scanned Out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtBarcode.Clear()
                txtBarcode.Select()
            Else
                If BalePendingWithBatchNumber(barcode) = True Then
                    MessageBox.Show("This bale has already been scanned but pending delivery", "Bale Scanned Out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtBarcode.Clear()
                    txtBarcode.Select()
                Else
                    Dim strSql As String = "SELECT BarCode, ControlGrade, ControlGrade, CONVERT(NVARCHAR, CONVERT(INT, Tare)), " _
                         & "CONVERT(NVARCHAR, Weight), CONVERT(NVARCHAR, CAST(Price AS DECIMAL (30,2))), Grower, " _
                         & "CONVERT(NVARCHAR, Moisture), LotNumber FROM BaleItems WHERE BarCode = '" & barcode & "'"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        With dGrid
                            .Rows.Add(UCase(objReader(0)), UCase(objReader(1)), UCase(objReader(2)), UCase(objReader(3)),
                                UCase(objReader(4)), UCase(objReader(5)), UCase(objReader(6)), UCase(objReader(7)),
                                UCase(objReader(8)))
                            ItemTotals()
                        End With
                    End If
                    objReader.Close()
                    txtBarcode.Clear()
                    txtBarcode.Select()
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Bale Transaction Load"
        ShowErrorMessage()
    End Sub

    Private Function BalePendingWithBatchNumber(ByVal Barcode As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT SendBatchNo FROM BaleItems WHERE Barcode = '" & Barcode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    If CInt(objReader(0).ToString) <> 0 Then
                        boolReturn = True
                    End If
                End If
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Bale status fetch"
        ShowErrorMessage()
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        If dGrid.Rows.Count <= 0 Then Exit Sub

        'boolAbort = False
        'Dim frm As New frmBaleHeader
        'frm.ShowDialog()
        'If boolAbort = True Then
        '    Exit Sub
        'End If

        On Error GoTo RaiseErr

        'Dim sfd As New SaveFileDialog
        'Dim strFileName As String = Nothing
        'sfd.ShowDialog()
        'strFileName = sfd.FileName

        Cursor = Cursors.WaitCursor

        'Get the next batch number

        Dim intNextBatchNo As Integer = 1

        Dim objBatchNumber As New Data.OleDb.OleDbCommand("SELECT DISTINCT(SendBatchNo) FROM BaleItems ORDER BY SendBatchNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objBatchNumber.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intNextBatchNo = CInt(objReader(0).ToString) + 1
            End If
        End If
        objReader.Close()

        'If Not String.IsNullOrEmpty(strFileName) Then
        '    Dim objFile As New System.IO.StreamWriter(strFileName & ".csv", False)
        '    objFile.WriteLine(strAgentCode & "," & strCountry & "," & strTobaccoType & "," & _
        '                      CStr(intCropYear) & "," & strShippingDate & "," & strLoadNumber & "," & _
        '                      strVehicleNumber & "," & strCarrierCode & "," & strShipToLocation)
        With dGrid
            For p As Integer = 0 To .Rows.Count - 1
                Dim strBarcode As String = Nothing
                Dim strControlGrade As String = Nothing
                Dim strCustomeGrade As String = Nothing
                Dim strTare As String = "0"
                Dim strWeight As String = Nothing
                Dim strPrice As String = Nothing
                Dim strGrower As String = Nothing
                Dim strMoisture As String = "0"
                Dim strLotNumber As String = Nothing

                'BarCode,Control Grade,Customer Grade,Tare,Weight,Price,Grower,Moisture,Lot Number

                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strBarcode = .Rows(p).Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strControlGrade = .Rows(p).Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        strCustomeGrade = .Rows(p).Cells(2).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        strWeight = .Rows(p).Cells(4).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        strPrice = .Rows(p).Cells(5).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        strGrower = .Rows(p).Cells(6).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString) Then
                        strLotNumber = .Rows(p).Cells(8).Value.ToString
                    End If
                End If

                'objFile.WriteLine(strBarcode & "," & strControlGrade & "," & strCustomeGrade & "," &
                '    strTare & "," & strWeight & "," & strPrice & "," & strGrower & "," &
                '    strMoisture & "," & strLotNumber)

                'Update date as already trasmitted
                Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE BaleItems SET SentStatus = 'PNG', " _
                    & "TransmissionDate = '" & Now & "', SendBatchNo = " & intNextBatchNo & " " _
                    & "WHERE Barcode = '" & strBarcode & "'", cnn)
                objCommand.ExecuteNonQuery()

            Next

            'objFile.Close()

        End With
        'End If

        Cursor = Cursors.Default

        dGrid.Rows.Clear()

        MessageBox.Show("Extraction file has been created successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On file transmission"
        ShowErrorMessage()
    End Sub

    Private Sub frmBalesOutput_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        If gwt_comm.CheckColumnExistence("BaleItems", "SentStatus") = False Then
            strSql = "ALTER TABLE BaleItems ADD [SentStatus][NVARCHAR](3) NOT NULL DEFAULT 'NO'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "SendBatchNo") = False Then
            strSql = "ALTER TABLE BaleItems ADD [SendBatchNo][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "TransmissionDate") = False Then
            strSql = "ALTER TABLE BaleItems ADD [TransmissionDate][SmallDateTime] NULL"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "UPDATE BaleItems SET Tare = 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        LoadGrades()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Database Table Update"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        On Error GoTo RaiseErr
        If e.ColumnIndex > 0 Then
            Dim strBarCode As String = Nothing
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    strBarCode = dGrid.CurrentRow.Cells(0).Value.ToString
                    Dim strValue As String = Nothing
                    If Not Object.Equals(dGrid.CurrentRow.Cells(e.ColumnIndex).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(e.ColumnIndex).Value.ToString) Then
                            strValue = dGrid.CurrentRow.Cells(e.ColumnIndex).Value.ToString
                        End If
                    End If
                    Dim strSql As String = Nothing
                    Select Case e.ColumnIndex
                        Case Is = 1
                            strSql = "UPDATE BaleItems SET ControlGrade = '" & strValue & "' WHERE Barcode = '" & strBarCode & "'"
                        Case Is = 2
                            strSql = "UPDATE BaleItems SET CustomerGrade = '" & strValue & "' WHERE Barcode = '" & strBarCode & "'"
                        Case Is = 3
                            If Not IsNumeric(strValue) Then strValue = "0.00"
                            strSql = "UPDATE BaleItems SET Tare = " & strValue & " WHERE Barcode = '" & strBarCode & "'"
                        Case Is = 4
                            If Not IsNumeric(strValue) Then strValue = "0.00"
                            strSql = "UPDATE BaleItems SET Weight = " & strValue & " WHERE Barcode = '" & strBarCode & "'"
                        Case Is = 5
                            If Not IsNumeric(strValue) Then strValue = "0.00"
                            strSql = "UPDATE BaleItems SET Price = " & strValue & " WHERE Barcode = '" & strBarCode & "'"
                        Case Is = 6
                            If Not IsNumeric(strValue) Then strValue = "0.00"
                            strSql = "UPDATE BaleItems SET Moisture = " & strValue & " WHERE Barcode = '" & strBarCode & "'"
                        Case Is = 7
                            strSql = "UPDATE BaleItems SET LotNumber = '" & strValue & "' WHERE Barcode = '" & strBarCode & "'"
                    End Select
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        End If
        If e.ColumnIndex = 1 Then
            Dim strCol1 As String = Nothing
            Dim strCol2 As String = Nothing
            If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    strCol1 = dGrid.CurrentRow.Cells(1).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                    strCol2 = dGrid.CurrentRow.Cells(2).Value.ToString
                End If
            End If
            If UCase(strCol1) <> UCase(strCol2) Then
                dGrid.CurrentRow.Cells(2).Value = UCase(strCol1)
            End If
        End If
        Exit Sub
RaiseErr:  '772517627
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Bale Information Edit"
        ShowErrorMessage()
    End Sub

    Private Function AlreadyScanned(ByVal BarCode As String) As Boolean
        Dim boolReturn As Boolean = False
        With dGrid
            If .Rows.Count <= 0 Then Exit Function
            For p As Integer = 0 To .Rows.Count - 1
                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        If UCase(Trim(BarCode)) = UCase(Trim(.Rows(p).Cells(0).Value.ToString)) Then
                            boolReturn = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End With
        Return boolReturn
    End Function

    Private Function BaleSent(ByVal Barcode As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT SentStatus FROM BaleItems WHERE Barcode = '" & Barcode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "YES" Then
                    boolReturn = True
                End If
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Bale status fetch"
        ShowErrorMessage()
    End Function

    Private Sub ItemTotals()
        lblTotal.Text = dGrid.Rows.Count
    End Sub

    Private Sub dGrid_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        ItemTotals()
    End Sub

    Private Sub LoadGrades()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Grade FROM BaleGrades ORDER BY Grade"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            CType(Me.dGrid.Columns(1), ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn).Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Bale Grades Load"
        ShowErrorMessage()
    End Sub

End Class