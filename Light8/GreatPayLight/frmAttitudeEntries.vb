Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAttitudeEntries

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        Dim objReader As Data.OleDb.OleDbDataReader
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO JobDesiredAttitudes (Description, JobCode) VALUES ('" & txtDescription.Text & "', '" & strJobCode & "')"
        Else
            strSql = "UPDATE JobDesiredAttitudes SET Description = '" & txtDescription.Text & "' WHERE JobCode = '" & strJobCode & "' AND TransactionId = " & intSelectedTransaction & ""
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatusTwo = False Then
            If MessageBox.Show("Task saved successfully. Do you want to add another attribute?", _
                "Job Attribute Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtDescription.Clear()
                txtDescription.Focus()
                Exit Sub
            End If
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Job Attribute Update"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub LoadData()
        If boolEditStatusTwo = True Then txtDescription.Text = strSelectedValue
    End Sub

    Private Sub frmAttitudeEntries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub frmAttitudeEntries_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 520 : Me.Height = 203
    End Sub
End Class
