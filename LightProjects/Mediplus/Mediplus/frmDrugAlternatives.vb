Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugAlternatives

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim arrDataIn As New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strAlternateName As String = Nothing
            With dGrid
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                    strAlternateName = .Rows(i).Cells(1).Value.ToString
                    arrDataIn.Add(strDrugCode & "|" & strAlternateName)
                End If
            End With
        Next

        If arrDataIn.Count > 0 Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemAlternativeMedicines WHERE DrugCode = '" & strDrugCode & "'", cnn)
            objCommand.ExecuteNonQuery()
            For i As Integer = 0 To arrDataIn.Count - 1
                Dim strBuffer() As String = Split(arrDataIn.Item(i), "|")
                Dim strSql As String = "INSERT INTO OchmasSystemAlternativeMedicines([DrugCode], [AlternateName]) VALUES " _
                    & "('" & strDrugCode & "', '" & strBuffer(1) & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            Next
        End If

        MsgBox("Alternative drug names have been saved successfully", MsgBoxStyle.Information, "On alternative drugs update")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On alternative drugs update"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtAlternateName.Text) Then
            MsgBox("Please enter the alternative drug name", MsgBoxStyle.Exclamation, "Missing Name")
            txtAlternateName.Focus()
            Exit Sub
        End If

        'Check that the code does not already exist
        On Error GoTo RaiseErr

        'Add the item directly to the table
        Dim strSql As String = "INSERT INTO OchmasSystemAlternativeMedicines([DrugCode], [AlternateName]) VALUES " _
                    & "('" & strDrugCode & "', '" & txtAlternateName.Text & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        LoadData()
        txtAlternateName.Clear()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On alternative drug names update"
        ShowErrorMessage()
    End Sub

    Private Sub txtInstruction_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlternateName.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAdd.Focus()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [TransactionId], [AlternateName] FROM " _
            & "OchmasSystemAlternativeMedicines WHERE [DrugCode] = '" & strDrugCode & "' ORDER BY AlternateName", cnn)
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On alternate drug names update"
        ShowErrorMessage()
    End Sub

    Private Sub frmDrugAlternatives_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

End Class
