Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSplitCodesSetup

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub InitialiazeDetails()
        On Error GoTo raise_err

        Dim rCodes As Data.OleDb.OleDbDataReader
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CodeNo, Description " _
                & "From SystemCodes ORDER BY CodeNo", cnn)
        rCodes = objCommand.ExecuteReader

        Dim arrPayrollCodes As New ArrayList

        'Initialize the array
        arrPayrollCodes.Add(UCase("000;No Code"))

        With cboSplitPayCode1
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With

        While rCodes.Read
            If Not IsDBNull(rCodes("Description").ToString) Or
                rCodes("Description").ToString <> "" Then
                arrPayrollCodes.Add(UCase(Format(CInt(rCodes("CodeNo").ToString), "000") & ";" & rCodes("Description").ToString))
            End If
        End While
        rCodes.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrPayrollCodes.Count
        If intItemsCount <= 0 Then
            MsgBox("No payroll codes were found for this payroll. Process will be aborted", MsgBoxStyle.Exclamation, "No Payroll Codes")
            Exit Sub
        End If

        Dim DropDownItems1(intItemsCount - 1) As MTGCComboBoxItem

        For p As Integer = 0 To arrPayrollCodes.Count - 1
            Dim strRecordText() As String = Split(arrPayrollCodes.Item(p).ToString, ";")
            DropDownItems1(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next

        With cboSplitPayCode1
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems1)
        End With

        Exit Sub
raise_err:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payroll codes details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboSplitPayCode1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode1.SelectedIndexChanged
        On Error Resume Next
        lblSplit1Description.Text = ""
        lblSplit1Description.Text = cboSplitPayCode1.SelectedItem.Col2
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SplitCodeParameters", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim intCode As Integer = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    intCode = CInt(dGrid.Rows(i).Cells(0).Value.ToString)
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SplitCodeParameters " _
                        & "(CodeNo) VALUES (" & intCode & ")", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On split codes setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If Not IsNumeric(cboSplitPayCode1.Text) Or String.IsNullOrEmpty(lblSplit1Description.Text) Then
            MessageBox.Show("Please enter a valid code number", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSplitPayCode1.Focus()
            Exit Sub
        Else
            dGrid.Rows.Add(cboSplitPayCode1.Text, lblSplit1Description.Text)
            cboSplitPayCode1.Text = "000"
            cboSplitPayCode1.Focus()
        End If
    End Sub

    Private Sub frmSplitCodesSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitialiazeDetails()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.Default
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SplitCodeParameters.CodeNo, " _
            & "SystemCodes.Description FROM SplitCodeParameters, SystemCodes " _
            & "WHERE SplitCodeParameters.CodeNo = SystemCodes.CodeNo ORDER BY SplitCodeParameters.CodeNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()  '3618 to 3627 kamupeni bobo
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On split codes load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmSplitCodesSetup_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 622 : Me.Height = 410
    End Sub

End Class