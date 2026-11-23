Imports ComponentFactory.Krypton.Toolkit

Public Class frmErrorMessages
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmErrorMessages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtErrors.Text = strErrorMessages
    End Sub

    Private Sub btnReconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconnect.Click
        If String.IsNullOrEmpty(strConnection) Then
            MessageBox.Show("The application could not locate the connection file. " _
                & "May be this " & vbCrLf & "is your first time to run the application on your machine." &
                vbCrLf & "If you want the configure the database click YES else click NO to " _
                & "end the application", "Application connection Failure", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Exit Sub
        End If
        Try
            cnn = New OleDb.OleDbConnection(strConnection)
            cnn.Open()
            boolConnectionStatus = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolConnectionStatus = False
        End Try
    End Sub

End Class
