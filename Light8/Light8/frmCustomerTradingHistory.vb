Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomerTradingHistory

    Private Sub frmCustomerTradingHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAccountNo.Text = strSelectedAccount
        If boolEditStatusTwo = True Then LoadTradeData()
    End Sub

    Private Sub frmCustomerTradingHistory_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 630 : Me.Height = 372
    End Sub

    Private Sub LoadTradeData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM TradeReferences WHERE AccountNumber = '" & strSelectedAccount & "' AND TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("TradeHouseName").ToString) Then txtRefName.Text = objReader("TradeHouseName").ToString
            If Not IsDBNull(objReader("TradeAccountNo").ToString) Then txtRefAccount.Text = objReader("TradeAccountNo").ToString
            If IsDate(objReader("DateOpened").ToString) Then dpRef.Value = CDate(objReader("DateOpened").ToString)
            If Not IsDBNull(objReader("Status").ToString) Then cboAccountStatus.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("Commendation").ToString) Then cboRecommendation.Text = objReader("Commendation").ToString
            If Not IsDBNull(objReader("Notes").ToString) Then txtRefNotes.Text = objReader("Notes").ToString
            If IsNumeric(objReader("AccountBalance").ToString) Then txtRefBalance.Text = Format(CDbl(objReader("AccountBalance").ToString), "##0.00")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On References Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveTradeData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If Not String.IsNullOrEmpty(txtRefAccount.Text) Then
            MessageBox.Show("Please enter the reference account name", "Invalid Reference Account Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRefAccount.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtRefName.Text) Then
            MessageBox.Show("Please enter the reference account name", "Invalid Reference Account Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRefAccount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtRefBalance.Text) Then txtRefBalance.Text = "0.00"
        If String.IsNullOrEmpty(cboAccountStatus.Text) Then
            MessageBox.Show("Please enter the reference account status", "Invalid Trade Reference Account Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountStatus.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboRecommendation.Text) Then
            MessageBox.Show("Please enter trade reference recommendation", "Invalid Trade Recommendation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboRecommendation.Focus()
            Exit Sub
        End If
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO TradeReferences ([AccountNumber],[TradeHouseName],[TradeAccountNo]," _
                & "[DateOpened],[Status],[Commendation],[Notes],[AccountBalance]) " _
                & "VALUES('" & txtAccountNo.Text & "', '" & txtRefName.Text & "', '" & txtRefAccount.Text & "', " _
                & "'" & shortMonthDateFormat(dpRef.Value) & "', '" & cboAccountStatus.Text & "', " _
                & "'" & cboRecommendation.Text & "', '" & txtRefNotes.Text & "', " & CDbl(txtRefBalance.Text) & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Else
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM TradeReferences WHERE AccountNumber = '" & txtAccountNo.Text & "' " _
                & "AND TransactionId = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            strSql = "UPDATE TradeReferences SET [TradeHouseName] = '" & txtRefName.Text & "', [TradeAccountNo] = '" & txtRefAccount.Text & "', " _
                & "[DateOpened] = '" & shortMonthDateFormat(dpRef.Value) & "', [Status] = '" & cboAccountStatus.Text & "', " _
                & "[Commendation] = '" & cboRecommendation.Text & "', [Notes] = '" & txtRefNotes.Text & "', " _
                & "[AccountBalance] = " & CDbl(txtRefBalance.Text) & " " _
                & "WHERE [AccountNumber] = '" & txtAccountNo.Text & "' AND TransactionId = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Trading Data Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
