Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleBatchFile

    Dim intNumberOfBalesInFile As Integer
    
    Private Sub frmBaleBatchFile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Clear()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DISTINCT(SendBatchNo) FROM BaleItems WHERE SentStatus = 'PNG'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridBatches
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(False, objReader(0).ToString)
            End While
            objReader.Close()
        End With

        strSql = "UPDATE BaleItems SET Tare = 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Open Batches Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridBatches_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridBatches.CellEndEdit
        If e.ColumnIndex = 0 Then
            'Clear and repopulate the grid
            dGrid.Rows.Clear()
            For p As Integer = 0 To dGridBatches.Rows.Count - 1
                If dGridBatches.Rows(p).Cells(0).Value = True Then
                    PopulateDetails(p)
                    lblTotal.Text = dGrid.Rows.Count
                End If
            Next
        End If
    End Sub

    Private Sub dGridBatches_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dGridBatches.MouseUp
        If dGridBatches.Rows.Count <= 0 Then Exit Sub
        If dGridBatches.CurrentCell.ColumnIndex = 0 Then
            dGridBatches.EndEdit()
        End If
    End Sub

    Private Sub PopulateDetails(ByVal Row As Integer)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim intBatch As Integer = 0
        If Not Object.Equals(dGridBatches.Rows(Row).Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridBatches.Rows(Row).Cells(1).Value.ToString) Then
                If IsNumeric(dGridBatches.Rows(Row).Cells(1).Value.ToString) Then
                    intBatch = CInt(dGridBatches.Rows(Row).Cells(1).Value.ToString)
                End If
            End If
        End If
        Dim strSql As String = "SELECT BarCode, ControlGrade, CustomerGrade, Tare, Weight, Price, Grower, Moisture, LotNumber FROM BaleItems WHERE SendBatchNo = " & intBatch & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6), objReader(7), objReader(8), intBatch)
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Open Batches Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnFile_Click(sender As System.Object, e As System.EventArgs) Handles btnFile.Click

        If dGrid.Rows.Count <= 0 Then Exit Sub

        On Error GoTo RaiseErr

        intNumberOfBalesInFile = 0
        arrMyPrintData = New ArrayList

        boolAbort = False
        Dim frm As New frmBaleHeader
        frm.ShowDialog()
        If boolAbort = True Then
            Exit Sub
        End If

        Dim sfd As New SaveFileDialog
        Dim strFileName As String = Nothing
        sfd.ShowDialog()
        strFileName = sfd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then

            Dim objFile As New System.IO.StreamWriter(strFileName & ".csv", False)
            objFile.WriteLine(strAgentCode & "," & strCountry & "," & strTobaccoType & "," & _
                              CStr(intCropYear) & "," & strShippingDate & "," & strLoadNumber & "," & _
                              strVehicleNumber & "," & strCarrierCode & "," & strShipToLocation)

            Dim intNextFileNo As Integer = 1

            Dim objBatchNumber As New Data.OleDb.OleDbCommand("SELECT DISTINCT(FileNumber) FROM BaleItems ORDER BY FileNumber DESC", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objBatchNumber.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then
                    intNextFileNo = CInt(objReader(0).ToString) + 1
                End If
            End If
            objReader.Close()

            'Update bale headers

            Dim objBaleHeader As New Data.OleDb.OleDbCommand("INSERT INTO [BaleHeaders] ([Agent],[CountryOfOrigin],[TobaccoType]," _
                & "[CropYear],[DateShipped],[LoadNumber],[BillOfLading],[CarrierCode],[ShipToLocation], [FileNumber]) VALUES " _
                & "('" & strAgentCode & "', '" & strCountry & "', '" & strTobaccoType & "', " & intCropYear & ", " _
                & "'" & strShippingDate & "', '" & strLoadNumber & "', '" & strVehicleNumber & "', '" & strCarrierCode & "', " _
                & "'" & strShipToLocation & "', " & intNextFileNo & ")", cnn)
            objBaleHeader.ExecuteNonQuery()

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

                    Dim strBatch As String = Nothing
                    If Not Object.Equals(.Rows(p).Cells(.Columns.Count - 1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(.Rows(p).Cells(.Columns.Count - 1).Value.ToString) Then
                            strBatch = .Rows(p).Cells(.Columns.Count - 1).Value.ToString
                        End If
                    End If

                    If Not String.IsNullOrEmpty(strControlGrade) Then
                        strCustomeGrade = strControlGrade
                    Else
                        If Not String.IsNullOrEmpty(strCustomeGrade) Then
                            strControlGrade = strCustomeGrade
                        End If
                    End If

                    Dim PrintPrice As String = "0.00"
                    If IsNumeric(strPrice) Then PrintPrice = Format(CDbl(strPrice), "#,##0.00")

                    Dim Tare As String = "0.00"
                    If IsNumeric(strTare) Then Tare = Format(CDbl(strTare), "#,##0.00")

                    Dim dWeight As String = "0.00"
                    If IsNumeric(strWeight) Then dWeight = Format(CDbl(strWeight), "#,##0.00")

                    Dim Moisture As String = "0.00"
                    If IsNumeric(strMoisture) Then Moisture = Format(CDbl(strMoisture), "#,##0.00")

                    arrMyPrintData.Add(CStr(p + 1) & ";" & strBatch & ";" & strBarcode & ";" & strControlGrade & ";" &
                        strCustomeGrade & ";" & Tare & ";" & dWeight & ";" & PrintPrice & ";" &
                        strGrower & ";" & Moisture & ";" & strLotNumber)

                    objFile.WriteLine(strBarcode & "," & strControlGrade & "," & strCustomeGrade & "," &
                        strTare & "," & strWeight & "," & strPrice & "," & strGrower & "," &
                        strMoisture & "," & strLotNumber)

                    'Update date as already trasmitted
                    Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE BaleItems SET SentStatus = 'YES', " _
                        & "TransmissionDate = '" & Now & "', DriverName = '" & strDriverName & "', " _
                        & "FileNumber = " & intNextFileNo & ", FileId = '" & strLoadNumber & "' " _
                        & "WHERE Barcode = '" & strBarcode & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    intNumberOfBalesInFile = intNumberOfBalesInFile + 1

                Next

            End With

            objFile.Close()

        End If

        dGrid.Rows.Clear()
        LoadData()

        PrintDeliveryNote(intNumberOfBalesInFile)

        MessageBox.Show("File generated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On File Generation"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        dGrid.Rows.Clear()
        LoadData()
    End Sub

    Private Sub dGrid_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        lblTotal.Text = dGrid.Rows.Count
    End Sub

End Class