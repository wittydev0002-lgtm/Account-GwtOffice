Imports System.Drawing
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocBiddersListing

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmMocBidders
        frm.ShowDialog()
        LoadBidders(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub LoadBidders(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Bidders.CardNo as [Card #], Bidders.GivenNames AS [Given Names], " _
            & "Bidders.IdNumber AS [ID Number], UPPER(REPLACE(CONVERT(CHAR(11), Bidders.AuctionDate, 106), ' ', '-')) AS [Auction Date], " _
            & "CAST(SUM(MocAttachmentDetails.BidAmount) AS DECIMAL (10,2)) AS [Bids Amt], " _
            & "CAST(Bidders.DepositAmount AS DECIMAL (10,2)) AS [Deposit], CAST(Bidders.CardAmount AS DECIMAL (10,2)) AS [Card Fee] FROM Bidders " _
            & "LEFT OUTER JOIN MocAttachmentDetails ON Bidders.CardNo = MocAttachmentDetails.BidderId " _
            & "WHERE Bidders.AuctionDate BETWEEN '" & StartingDate & "' AND '" & EndingDate & "' " _
            & "GROUP BY Bidders.CardNo, Bidders.GivenNames, Bidders.IdNumber, Bidders.AuctionDate, " _
            & "MocAttachmentDetails.BidAmount, Bidders.DepositAmount, Bidders.CardAmount"

        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        'Add column for balance
        With dGrid
            .Columns.Add("BalCol", "Balance")
            For p As Integer = 0 To .RowCount - 1
                Dim dblbids As Double = 0
                Dim dblDeposit As Double = 0
                Dim dblCardFee As Double = 0
                Dim dblBalance As Double = 0
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblbids = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                            dblDeposit = CDbl(.Rows(p).Cells(5).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblCardFee = CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If
                dblBalance = dblbids - (dblDeposit + dblCardFee)
                .Rows(p).Cells(7).Value = Format(dblBalance, "##0.00")
            Next
        End With

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p > 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        AlternateColors()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bidders data update"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelected()
        Dim frm As New frmMocBidders
        frm.ShowDialog()
        LoadBidders(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub GetSelected()
        If dGrid.RowCount <= 0 Then Exit Sub
        strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
        strSelectedDate = dGrid.CurrentRow.Cells(3).Value.ToString
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        LoadBidders(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub btnRowDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnRowDetails.Click
        GetSelected()
        Dim frm As New frmMocBidderItemsDetails
        frm.ShowDialog()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.RowCount <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelected()
        Dim frm As New frmMocBidders
        frm.ShowDialog()
        LoadBidders(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub AlternateColors()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.White
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub btnPrintSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSummary.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        Dim m_print As New PrintControl.ControlPrint
        m_print.SetControl(dGrid)
        Dim ppd As New EnhancedPrintPreviewDialog
        ppd.Document = DirectCast(m_print, PrintDocument)
        ppd.ShowDialog()
    End Sub

    Private Sub btnPrintStatement_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintStatement.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        If IsNumeric(strSelectedAccount) Then
            intSelectedTransaction = CInt(strSelectedAccount)
        Else
            Exit Sub
        End If
        gwt_comm.PrintCustomerDocument(intSelectedTransaction, "AUCTION STATEMENT")
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        If IsNumeric(strSelectedAccount) Then
            intSelectedTransaction = CInt(strSelectedAccount)
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Bidders WHERE CardNo = " & strSelectedAccount & " " _
                & "AND AuctionDate = '" & strSelectedDate & "'", cnn)
            objCommand.ExecuteNonQuery()
            LoadBidders(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
        Else
            Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bidders data update"
        ShowErrorMessage()
    End Sub

End Class
