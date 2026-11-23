Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugManufacturers

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim arrDataIn As New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strCode As String = Nothing
            Dim strInstruction As String = Nothing
            With dGrid
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strCode = .Rows(i).Cells(0).Value.ToString
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                    strInstruction = .Rows(i).Cells(1).Value.ToString
                End If
                If String.IsNullOrEmpty(strCode) Or String.IsNullOrEmpty(strInstruction) Then
                    MsgBox("Missing either the code or manufacturer name on line " & (i + 1) & ". Process will be aborted", MsgBoxStyle.Exclamation, "Missing Data")
                    Exit Sub
                Else
                    arrDataIn.Add(strCode & "|" & strInstruction)
                End If
            End With
        Next

        If arrDataIn.Count > 0 Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemDrugManufacturers", cnn)
            objCommand.ExecuteNonQuery()
            For i As Integer = 0 To arrDataIn.Count - 1
                Dim strBuffer() As String = Split(arrDataIn.Item(i), "|")
                Dim strSql As String = "INSERT INTO OchmasSystemDrugManufacturers([ManufacturerCode], [ManufacturerName]) VALUES " _
                    & "('" & strBuffer(0) & "', '" & strBuffer(1) & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            Next
        End If

        MsgBox("Dispensing Ciphers have been saved successfully", MsgBoxStyle.Information, "On drug manufacturers Save Success")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On drug manufacturers maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtCode.Text) Then
            MsgBox("Please enter the manufacturer code", MsgBoxStyle.Exclamation, "Missing Manufacturer Code")
            txtCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtName.Text) Then
            MsgBox("Please enter the manufacturer name", MsgBoxStyle.Exclamation, "Missing Name")
            txtName.Focus()
            Exit Sub
        End If

        'Check that the code does not already exist
        On Error GoTo RaiseErr

        'Add the item directly to the table
        Dim strSql As String = "INSERT INTO OchmasSystemDrugManufacturers([ManufacturerCode], [ManufacturerName]) VALUES " _
                    & "('" & txtCode.Text & "', '" & txtName.Text & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        With dGrid
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = txtCode.Text
            .Rows(.Rows.Count - 1).Cells(1).Value = txtName.Text
        End With

        txtCode.Clear() : txtName.Clear()
        txtCode.Text = CStr(AutoAllocateNextNumber())

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On drug manufacturers maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) = 13 Then txtName.Select()
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAdd.Focus()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ManufacturerCode, ManufacturerName FROM OchmasSystemDrugManufacturers ORDER BY ManufacturerName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On drug manufacturers maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmfrmDrugManufacturers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
        txtCode.Text = CStr(AutoAllocateNextNumber())
    End Sub

    Private Function AutoAllocateNextNumber() As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 1
        'Allocate the numbers as numerical for now. It can be anything though
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT count(ManufacturerCode) FROM OchmasSystemDrugManufacturers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReturn = CInt(objReader(0).ToString) + 1
        End If
        objReader.Close()
        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On drug manufacturers maintenance"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub frmDrugManufacturers_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 570 : Me.Height = 400
    End Sub

End Class
