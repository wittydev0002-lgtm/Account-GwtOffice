Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMatchInvoicesToPayments

    Private Sub frmMatchInvoicesToPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        For i As Integer = 0 To arrSelectedItems.Count - 1
            Dim strBuffer() As String = Split(arrSelectedItems.Item(i), "|")
            dGrid.Rows.Add(strBuffer(0), strBuffer(1), strBuffer(2), strBuffer(3))
        Next
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strRef As String = Nothing
            Dim dblAmount As Double = 0
            Dim dblPriorAmt As Double = 0
            Dim strDate As String = Format(Now, "dd-MMM-yyyy")

            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                strDate = dGrid.Rows(i).Cells(0).Value.ToString
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                strRef = dGrid.Rows(i).Cells(1).Value.ToString
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                dblPriorAmt = dGrid.Rows(i).Cells(2).Value.ToString
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                dblAmount = dGrid.Rows(i).Cells(3).Value.ToString
            End If
            Dim strComment As String = "MATCHING ACCOUNT INVOICES AND PAYMENTS"
            Dim dblSpecialKey As Integer = gwt_comm.SpecialKey()

            If dblAmount <> 0 Then
                'Dim myCommand As New Data.OleDb.OleDbCommand("UPDATE CustomerTransactions SET [ReferenceNumber] = '" & strRef & "', " _
                '    & "Amount = " & dblAmount & " WHERE AccountNumber = '" & strSelectedAccount & "' AND Amount = " & dblPriorAmt & " AND TransactionType = 'PAYMENT'", cnn)
                'myCommand.ExecuteNonQuery()

                Dim myCommand As New Data.OleDb.OleDbCommand("INSERT INTO CustomerTransactions ([AccountNumber],[TransactionDate]," _
                        & "[Amount],[TransactionType],[Description],[ReferenceNumber],[UserName],[BranchName], [SpecialKey], [Comments]) " _
                        & "VALUES('" & strSelectedAccount & "', '" & strDate & "', " _
                        & "" & dblAmount & ", 'PAYMENT', 'CASH PAYMENT', '" & strRef & "', " _
                        & "'" & strUserName & "', '" & strUserBranch & "', " & dblSpecialKey & ", '" & strComment & "')", cnn)
                myCommand.ExecuteNonQuery()

            End If
        Next
        MessageBox.Show("Transactions Matched Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On invoice payments matching"
        ShowErrorMessage()
    End Sub

End Class
