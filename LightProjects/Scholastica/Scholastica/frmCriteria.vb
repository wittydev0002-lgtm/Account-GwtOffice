Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Public Class frmCriteria
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolabort = True
        Me.Close()
    End Sub

    Private Sub frmCriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Select Case UCase(strReportType)
            Case = "SPONSORS"
                strSql = "SELECT DISTINCT(Sponsor) FROM SC_Sponsors ORDER BY Sponsor"
            Case = "STUDENT TYPES"
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCriteria.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCriteria.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On report criteria load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not String.IsNullOrEmpty(cboCriteria.Text) Then
            strSelectedDescription = cboCriteria.Text
            boolAbort = False
            Me.Close()
        Else
            MessageBox.Show("Please select the criteria", "Missing Criteria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCriteria.Select()
            Exit Sub
        End If
    End Sub
End Class