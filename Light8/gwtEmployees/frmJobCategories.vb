Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmJobCategories

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmJobCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then
            txtCategory.Text = strCodeDescription
            txtCategory.SelectAll()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        If boolEditStatus = True Then
            strSql = "UPDATE SystemJobCategories SET JobCategory = '" & txtCategory.Text & "' WHERE TransactionNo = " & intSelectedCode & ""
        Else
            strSql = "INSERT INTO SystemJobCategories (JobCategory) VALUES ('" & txtCategory.Text & "')"
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatus = False Then
            If MessageBox.Show("Job Category updated successfully", "Job Category Update Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtCategory.Clear()
                txtCategory.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("Job Category updated successfully", "Job Category Setup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        boolAbort = False : boolEditStatus = True
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Job Ctegories Save"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
