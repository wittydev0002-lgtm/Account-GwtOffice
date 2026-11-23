Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectExpenses

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmProjectExpenses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGridEntry.Rows.Add(1)
    End Sub

    Private Sub dGridEntry_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridEntry.CellEndEdit
        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable
        If dGridEntry.CurrentCell.ColumnIndex = 5 Or dGridEntry.CurrentCell.ColumnIndex = 6 Then
            If IsNumeric(dGridEntry.CurrentCell.Value) Then
                dGridEntry.CurrentCell.Value = Format(CDbl(dGridEntry.CurrentCell.Value.ToString), "##0.00")
            Else
                dGridEntry.CurrentCell.Value = "0.00"
            End If
        End If
        ComputeTotal()
    End Sub

    Private Sub ComputeTotal()
        On Error GoTo RaiseErr
        Dim dblAmount As Double = 0
        Dim dblTaxes As Double = 0
        If Not Object.Equals(dGridEntry.CurrentRow.Cells(5).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(5).Value.ToString) Then
                If IsNumeric(dGridEntry.CurrentRow.Cells(5).Value.ToString) Then
                    dblAmount = CDbl(dGridEntry.CurrentRow.Cells(5).Value.ToString)
                End If
            End If
        End If
        If Not Object.Equals(dGridEntry.CurrentRow.Cells(6).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(6).Value.ToString) Then
                If IsNumeric(dGridEntry.CurrentRow.Cells(6).Value.ToString) Then
                    dblTaxes = CDbl(dGridEntry.CurrentRow.Cells(6).Value.ToString)
                End If
            End If
        End If
        Dim dblTotal As Double = dblAmount + dblTaxes
        dGridEntry.CurrentRow.Cells(dGridEntry.ColumnCount - 1).Value = Format(dblTotal, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Total Computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridEntry_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridEntry.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dGridEntriy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridEntry.KeyDown
        If e.KeyValue = 9 Then
            'frmCashoutItemTypes
            If dGridEntry.CurrentCell.ColumnIndex = 1 Then
                strSelectedAccount = Nothing
                lblActiveLedgerAccount.Text = Nothing
                boolAbort = False
                gwt_comm.SearchForLedgerAccount()
                If boolAbort = True Then Exit Sub
                dGridEntry.CurrentRow.Cells(1).Value = strSelectedAccount
                lblActiveLedgerAccount.Text = strSelectedAccountName
            End If

            If dGridEntry.CurrentCell.ColumnIndex = 2 Then
                strSelectedAccount = Nothing
                lblActiveCustomerName.Text = Nothing
                boolAbort = False
                gwt_comm.CustomerSearch()
                If boolAbort = True Then Exit Sub
                dGridEntry.CurrentRow.Cells(2).Value = strSelectedAccount
                lblActiveCustomerName.Text = strSelectedAccountName
                strPublicCustomerId = strSelectedAccount
            End If

            If dGridEntry.CurrentCell.ColumnIndex = 3 Then
                strSelectedAccount = Nothing
                boolAbort = False
                gwt_comm.CustomerProjectSearch()
                If boolAbort = True Then Exit Sub
                dGridEntry.CurrentRow.Cells(3).Value = strSelectedAccount
            End If

            If dGridEntry.CurrentCell.ColumnIndex = dGridEntry.ColumnCount - 1 Then
                With dGridTransactions
                    .Rows.Add(dGridEntry.CurrentRow.Cells(0).Value, dGridEntry.CurrentRow.Cells(1).Value, _
                                dGridEntry.CurrentRow.Cells(2).Value, dGridEntry.CurrentRow.Cells(3).Value, _
                                dGridEntry.CurrentRow.Cells(4).Value, dGridEntry.CurrentRow.Cells(5).Value, _
                                dGridEntry.CurrentRow.Cells(6).Value, dGridEntry.CurrentRow.Cells(7).Value)
                End With
                For p As Integer = 0 To dGridEntry.ColumnCount - 1
                    dGridEntry.CurrentRow.Cells(p).Value = Nothing
                Next
                e.SuppressKeyPress = True
                dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(0)
                lblActiveCustomerName.Text = Nothing
                lblActiveLedgerAccount.Text = Nothing
                ComputeTransactionTotals()
            End If
        End If
    End Sub

    Private Sub ComputeTransactionTotals()
        On Error GoTo RaiseErr
        Dim dblTotalAmount As Double = 0
        Dim dblTotalTaxes As Double = 0
        For p As Integer = 0 To dGridTransactions.Rows.Count - 1
            Dim dblAmount As Double = 0
            Dim dblTaxes As Double = 0
            If Not Object.Equals(dGridTransactions.Rows(p).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(p).Cells(5).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(p).Cells(5).Value.ToString) Then
                        dblAmount = CDbl(dGridTransactions.Rows(p).Cells(5).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridTransactions.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(p).Cells(6).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(p).Cells(6).Value.ToString) Then
                        dblTaxes = CDbl(dGridTransactions.Rows(p).Cells(6).Value.ToString)
                    End If
                End If
            End If
            dblTotalTaxes = dblTotalTaxes + dblTaxes
            dblTotalAmount = dblTotalAmount + dblAmount
        Next

        lblAmtTotal.Text = Format(dblTotalAmount, "#,##0.00")
        lblTotalVat.Text = Format(dblTotalTaxes, "#,##0.00")
        lblTotalAll.Text = Format((dblTotalAmount + dblTotalTaxes), "#,##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Transactions Totals Computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGridTransactions.Rows.Count > 0 Then
            dGridTransactions.Rows.RemoveAt(dGridTransactions.CurrentRow.Index)
            ComputeTransactionTotals()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Transactions Row Delete"
        gwt_comm.ShowErrorMessage()
    End Sub
End Class
