Imports CommonLibrary.Commons

Public Class frmLegalTransactionEdit

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmLegalTransactionEdit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        lblId.Text = intSelectedTransaction
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Debit, Credit, ReferenceNumber, Description, Comments " _
            & "FROM DefendantTransactions WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then txtDebit.Text = Format(CDbl(objReader(0).ToString), "##0.00")
            If IsNumeric(objReader(1).ToString) Then txtCredit.Text = Format(CDbl(objReader(1).ToString), "##0.00")
            If Not IsDBNull(objReader(2).ToString) Then txtReference.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtDescription.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtComments.Text = objReader(4).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On transaction edit"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalTransactionEdit_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 520 : Me.Height = 300
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtDebit.Text) Then
            MessageBox.Show("Please enter a valid amount for debit", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDebit.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtCredit.Text) Then
            MessageBox.Show("Please enter a valid amount for credit", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCredit.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE DefendantTransactions SET Debit = " & CDbl(txtDebit.Text) & ", " _
            & "Credit = " & CDbl(txtCredit.Text) & ", ReferenceNumber = '" & txtReference.Text & "', " _
            & "Description = '" & txtDescription.Text & "', Comments = '" & txtComments.Text & "' " _
            & "WHERE TransactionId = " & lblId.Text & "", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Transaction has been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On transaction edit"
        ShowErrorMessage()
    End Sub

End Class