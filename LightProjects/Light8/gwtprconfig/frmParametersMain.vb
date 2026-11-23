Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmParametersMain

    
    Private Sub btnCalculations_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculations.Click
        boolAbort = False
        Dim f As New frmCalculationsView
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim frm As New frmCalculations
        frm.ShowDialog()
    End Sub

    Private Sub btnConstants_Click(sender As System.Object, e As System.EventArgs) Handles btnConstants.Click
        boolAbort = False
        Dim frm As New frmConstants
        frm.ShowDialog()
    End Sub

    Private Sub btnCalendar_Click(sender As System.Object, e As System.EventArgs) Handles btnCalendar.Click
        boolAbort = False
        Dim frm As New frmCalendarSetup
        frm.ShowDialog()
    End Sub

    Private Sub btnCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnCodes.Click
        boolAbort = False
        Dim frm As New frmCodes
        frm.ShowDialog()
    End Sub

    Private Sub btnDates_Click(sender As System.Object, e As System.EventArgs) Handles btnDates.Click
        boolAbort = False
        Dim frm As New frmSystemDates
        frm.ShowDialog()
    End Sub

    Private Sub btnFlags_Click(sender As System.Object, e As System.EventArgs) Handles btnFlags.Click
        boolAbort = False
        Dim frm As New frmFlagsListing
        frm.ShowDialog()
    End Sub

    Private Sub btnTaxTables_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxTables.Click
        boolAbort = False
        Dim frm As New frmTaxTables
        frm.ShowDialog()
    End Sub

    Private Sub btnReferenceNames_Click(sender As System.Object, e As System.EventArgs) Handles btnReferenceNames.Click
        boolAbort = False
        Dim frm As New frmSystemReferences
        frm.ShowDialog()
    End Sub

    Private Sub btnLeaveParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnLeaveParameters.Click
        boolAbort = False
        Dim frm As New frmLeaveListing
        frm.ShowDialog()
    End Sub

    Private Sub btnHolidays_Click(sender As System.Object, e As System.EventArgs) Handles btnHolidays.Click
        boolAbort = False
        Dim frm As New frmLeaveParameters
        frm.ShowDialog()
    End Sub

    Private Sub btnKeyFields_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyFields.Click
        boolAbort = False
        Dim frm As New frmKeyData
        frm.ShowDialog()
    End Sub

    Private Sub btnTrekkedCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnTrekkedCodes.Click
        boolAbort = False
        Dim frm As New frmTrekkedFields
        frm.ShowDialog()
    End Sub

    Private Sub btnColumnReports_Click(sender As System.Object, e As System.EventArgs) Handles btnColumnReports.Click
        boolAbort = False
        Dim frm As New frmPayrollUserReportsListing
        frm.ShowDialog()
    End Sub

    Private Sub btnBanks_Click(sender As Object, e As EventArgs) Handles btnBanks.Click
        Dim frm As New frmBankListing
        frm.ShowDialog()
    End Sub

End Class