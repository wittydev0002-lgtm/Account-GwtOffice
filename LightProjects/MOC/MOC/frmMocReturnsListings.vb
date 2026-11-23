Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocReturnsListings

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmMocReturns
        frm.ShowDialog()

    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmMocReturns
        frm.ShowDialog()
    End Sub

    Private Sub GetSelected()
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmMocReturns
        frm.ShowDialog()
    End Sub

    Private Sub frmMocReturnsListings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT MocReturns.BookNumber, MocReturns.AdviceNumber, " _
            & "CONVERT(NVARCHAR, MocReturns.ActionDate, 105) AS [ActionDate], MocReturns.CaseNumber, MocCases.Plaintiff,  " _
            & "MocCases.Defendant, MocReturns.ProcedureName,  CAST((MocReturns.MileageCost + MocReturns.ServedOnRuleOneCosts + " _
            & "MocReturns.ServedOnRuleTwoCosts + MocReturns.ServedOnRuleThreeCosts + MocReturns.ServedOnCompanyOfficeCosts + " _
            & "MocReturns.ServedOnRegisteredMailCosts + MocReturns.ServedOnCourtOrderCosts + MocReturns.AttemptedServiceExecutionCosts + " _
            & "MocReturns.ExecutionCessionCosts + MocReturns.WarrantCosts + MocReturns.WarrantOfArrestCosts + " _
            & "MocReturns.WarrantOfAttachmentCosts + MocReturns.WarrantOfAttachmentPaidInFullCosts + " _
            & "MocReturns.WarrantOfAttachmentNullaBonaCosts + MocReturns.Cartage + MocReturns.Advertising + " _
            & "MocReturns.Locksmith + MocReturns.Notice + MocReturns.Inventories + MocReturns.WaitingTime + " _
            & "MocReturns.Security + MocReturns.Commission + MocReturns.Escort + MocReturns.Postage + " _
            & "MocReturns.OtherCostsAmount) AS DECIMAL (10,2)) AS TotalCosts, MocReturns.TransactionId " _
            & "FROM MocReturns LEFT OUTER JOIN MocCases ON MocReturns.CaseNumber = MocCases.CaseNo " _
            & "WHERE MocReturns.ActionDate BETWEEN '" & Format(dpStartFrom.Value, "dd-MMM-yyyy") & "' " _
            & "AND '" & Format(dpEndTo.Value, "dd-MMM-yyyy") & "' ORDER BY AdviceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), _
                objReader(4), objReader(5), objReader(6), objReader(7), objReader(8))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "MOC Returns Listing"
        ShowErrorMessage()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        LoadData()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub
End Class
