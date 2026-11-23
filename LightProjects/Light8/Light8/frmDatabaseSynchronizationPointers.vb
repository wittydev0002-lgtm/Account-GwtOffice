Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDatabaseSynchronizationPointers

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmDatabaseSynchronizationPointersvb_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 651 : Me.Height = 358
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        Dim strCurrentRecord As String = Nothing

        If String.IsNullOrEmpty(txtLastInvoice.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last invoice number." & vbCrLf & "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastQuotation.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last quotation number." & vbCrLf & "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastReceipt.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last receipt number." & vbCrLf & _
                "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtFilename.Text) Then
            MessageBox.Show("Please enter the configuration file name", "Missing Configuration File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM RemoteDatabasePointers", cnn)
        objCommand.ExecuteNonQuery()

        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO RemoteDatabasePointers (LastReceipt, LastInvoice, " _
            & "LastQuotation, UpdateDate) VALUES (" & txtLastReceipt.Text & ", " & txtLastInvoice.Text & ", " _
            & "" & txtLastQuotation.Text & ", '" & dpDate.Value & "')", cnn)
        objCommand.ExecuteNonQuery()

        'Create the remote connection file

        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\Data\" & txtFilename.Text)
        Dim strConn As String = "data source=" & txtServerName.Text & ";initial catalog=" & txtDatabaseName.Text & ";user ID=" & txtLoginName.Text & ";password=" & txtLoginPassword.Text & ";provider=SQLOLEDB"
        objFileWriter.WriteLine(strConn)
        objFileWriter.Close()

        'Update the company external database filename
        objCommand = New Data.OleDb.OleDbCommand("UPDATE Company SET ExternalDatabaseFilename = '" & txtFilename.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        gwt_comm.AssignDefaults()
        gwt_comm.AssignCompanyDetails()

        MessageBox.Show("Remote connection pointers updated successfully", "Remote DB Connection Setup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On database synchronisation setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtLastReceipt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastReceipt.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtLastInvoice.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtLastInvoice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastInvoice.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtLastQuotation.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtLastQuotation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastQuotation.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            btnOK.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmDatabaseSynchronizationPointers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM RemoteDatabasePointers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader("UpdateDate").ToString) Then dpDate.Value = CDate(objReader("UpdateDate").ToString)
            If Not IsDBNull(objReader("LastReceipt").ToString) Then txtLastReceipt.Text = objReader("LastReceipt").ToString
            If Not IsDBNull(objReader("LastInvoice").ToString) Then txtLastInvoice.Text = objReader("LastInvoice").ToString
            If Not IsDBNull(objReader("LastQuotation").ToString) Then txtLastQuotation.Text = objReader("LastQuotation").ToString
        End If
        objReader.Close()

        'Read the connection file
        txtFilename.Text = strExternalDatabaseFilename
        If System.IO.File.Exists(Application.StartupPath & "\Data\" & strExternalDatabaseFilename) Then
            Dim objFileReader As New System.IO.StreamReader(Application.StartupPath & "\Data\" & strExternalDatabaseFilename)
            Dim strLine As String = objFileReader.ReadLine
            objFileReader.Close()
            If Not String.IsNullOrEmpty(strLine) Then
                Dim strValues() As String = Split(strLine, ";")
                Dim strActual() As String = Split(strValues(0), "=")
                txtServerName.Text = Trim(strActual(1))
                strActual = Split(strValues(1), "=")
                txtDatabaseName.Text = Trim(strActual(1))

                strActual = Split(strValues(2), "=")
                txtLoginName.Text = Trim(strActual(1))

                strActual = Split(strValues(3), "=")
                txtLoginPassword.Text = Trim(strActual(1))
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On database synchronisation setup"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
