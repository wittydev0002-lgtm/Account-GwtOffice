Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookTransactionDateChange

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmCashbookTransactionDateChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM CashbookTransactions WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader("TransactionDate").ToString) Then dpTransDate.Value = CDate(objReader("TransactionDate").ToString)
            If Not IsDBNull(objReader("Description").ToString) Then txtDescription.Text = objReader("Description").ToString
            If Not IsDBNull(objReader("ContraAccount").ToString) Then txtContraAccount.Text = objReader("ContraAccount").ToString
            If IsNumeric(objReader("Amount").ToString) Then txtAmount.Text = Format(CDbl(objReader("Amount").ToString), "##0.00")
            If Not IsDBNull(objReader("Reference").ToString) Then txtReference.Text = objReader("Reference").ToString
            lblId.Text = intSelectedTransaction
        End If
        txtReference.Enabled = False : txtAmount.Enabled = False : txtContraAccount.Enabled = False
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook transaction load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please type in a valid description", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE CashbookTransactions SET Amount = " & CDbl(txtAmount.Text) & ", " _
            & "Description = '" & txtDescription.Text & "', ContraAccount = '" & txtContraAccount.Text & "', " _
            & "TransactionDate = '" & Format(CDate(dpTransDate.Value), "dd-MMM-yyyy") & "' WHERE TransactionId = " & CInt(lblId.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Transaction details have been modified successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook transaction edit"
        ShowErrorMessage()
    End Sub

    Private Sub frmCashbookTransactionDateChange_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 605 : Me.Height = 290
    End Sub

End Class
