Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDiagnosticsCodeSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        boolAbort = False

        Dim strSql As String = Nothing
        If boolEditStatus = True Then
            strSql = "UPDATE OchmasSystemIcdten SET ShortDescription = '" & txtShortDescription.Text & "', " _
                & "LongDescription = '" & txtLongDescription.Text & "', Validation = '" & txtValidation.Text & "', " _
                & "Branch = '" & strUserBranch & "', UserName = '" & strPublicActiveFullUserName & "', " _
                & "ChangeDate = '" & Now & "' WHERE Code = '" & txtCode.Text & "'"
        Else
            strSql = "INSERT INTO OchmasSystemIcdten (Code, ShortDescription, LongDescription, Validation, " _
                & "Branch, UserName, ChangeDate) VALUES " _
                & "('" & txtCode.Text & "', '" & txtShortDescription.Text & "', '" & txtLongDescription.Text & "', " _
                & "'" & txtValidation.Text & "', '" & strUserBranch & "', '" & strPublicActiveFullUserName & "', '" & Now & "')"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Diagnosis codes have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Diagnosis Codes Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Code, ShortDescription, LongDescription, Validation " _
            & "FROM OchmasSystemIcdten WHERE Code = '" & strSelectedCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        txtCode.Enabled = False
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtShortDescription.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtLongDescription.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtValidation.Text = objReader(2).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Diagnosis Codes Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmDiagnosticsCodeSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
        End If
    End Sub

End Class
