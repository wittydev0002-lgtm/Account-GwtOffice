Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJobCardInvoiceDetails

    Private Sub frmJobCardInvoiceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFormData()
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
            & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
            & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
            & "DiscountAllowed + Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, " _
            & "SalesRep AS [Technician], CONVERT(NVARCHAR, TransDate, 105) AS [Date], TransactionId from JobInvoiceDetails WHERE " _
            & "ReferenceNumber = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString

            If Not IsDBNull(objReader(3).ToString) Then
                If strTaxComputationType = "INCLUSIVE" Then
                    If IsNumeric(objReader(5).ToString) Then
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = Format((CDbl(objReader(3).ToString) - CDbl(objReader(5).ToString)), "##0.00")
                    Else
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                    End If
                End If
            End If

            If Not IsDBNull(objReader(4).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = objReader(5).ToString

            If Not IsDBNull(objReader(6).ToString) Then
                If strTaxComputationType = "INCLUSIVE" Then
                    If IsNumeric(objReader(5).ToString) Then
                        If IsNumeric(objReader(6).ToString) Then
                            dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = Format((CDbl(objReader(6).ToString) - CDbl(objReader(5).ToString)), "##0.00")
                        End If
                    End If
                End If
            End If


            If Not IsDBNull(objReader(7).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(7).Value = objReader(7).ToString

            If Not IsDBNull(objReader("Technician").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(8).Value = objReader("Technician").ToString
            If Not IsDBNull(objReader("Date").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(9).Value = objReader("Date").ToString

            If Not IsDBNull(objReader(8).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(10).Value = objReader(8).ToString
        End While
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cash Sale Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

End Class
