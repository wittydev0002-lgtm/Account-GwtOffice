Imports CommonLibrary.Commons

Public Class frmSubjectsForBillingMaximum

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtMaximum.Text) Then
            MessageBox.Show("Please enter a valid numeric value", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMaximum.Select()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_RemedialSubjectsMaximum", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_RemedialSubjectsMaximum (SubjectsLimit) VALUES (" & txtMaximum.Text & ")", cnn)
        objCommand.ExecuteNonQuery()
        intBilliableSubjectsLimit = CInt(txtMaximum.Text)
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On maximum number of billiable subjects on remedial lessons setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [SubjectsLimit] FROM SC_RemedialSubjectsMaximum", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then txtMaximum.Text = objReader(0).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On maximum number of billiable subjects on remedial lessons setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmSubjectsForBillingMaximum_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub frmSubjectsForBillingMaximum_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 406
        Me.Height = 166
    End Sub
End Class