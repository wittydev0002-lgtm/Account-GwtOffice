Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmKeyData

    Dim boolIsNewEntry As Boolean = False

    Private Sub PopulateCaptions()
        On Error GoTo RaiseErr
        dgrid.Rows.Add(71)
        dgrid.Rows(0).Cells(0).Value = UCase("Additional Tax Code")
        dgrid.Rows(1).Cells(0).Value = UCase("Addition Tax Year-To-Date Code")
        dgrid.Rows(2).Cells(0).Value = UCase("Arrear Pensions Allowed Year-To-Date Code")
        dgrid.Rows(3).Cells(0).Value = UCase("Arrear Pension Code")
        dgrid.Rows(4).Cells(0).Value = UCase("Arrear Pension Year-To-Date Code")
        dgrid.Rows(5).Cells(0).Value = UCase("Arrear Retirement Annuity Allowed Year-To-Date Code")
        dgrid.Rows(6).Cells(0).Value = UCase("Arrear Retirement Annuity Code")
        dgrid.Rows(7).Cells(0).Value = UCase("Arrear Retirement Year-To-Date Code")
        dgrid.Rows(8).Cells(0).Value = UCase("Basic Salary Code")
        dgrid.Rows(9).Cells(0).Value = UCase("Bonus Tax Code")
        dgrid.Rows(10).Cells(0).Value = UCase("Bonus Tax Year-To-Date Code")
        dgrid.Rows(11).Cells(0).Value = UCase("Bonus Taxable Income Year-To-Date Code")
        dgrid.Rows(12).Cells(0).Value = UCase("Cummulative Tax Indicator")
        dgrid.Rows(13).Cells(0).Value = UCase("Default Tax Authority")
        dgrid.Rows(14).Cells(0).Value = UCase("Fiscal Year Start Date")
        dgrid.Rows(15).Cells(0).Value = UCase("Fiscal Year End Date")
        dgrid.Rows(16).Cells(0).Value = UCase("Gross Income Code")
        dgrid.Rows(17).Cells(0).Value = UCase("Gross Income Year-To-Date Code")
        dgrid.Rows(18).Cells(0).Value = UCase("Medical Aid Code")
        dgrid.Rows(19).Cells(0).Value = UCase("Medical Aid Year-To-Date Code")
        dgrid.Rows(20).Cells(0).Value = UCase("Net Salary Code")
        dgrid.Rows(21).Cells(0).Value = UCase("Non Cash Gross Income Code")
        dgrid.Rows(22).Cells(0).Value = UCase("Non Cash Gross Income Year-To-Date Code")
        dgrid.Rows(23).Cells(0).Value = UCase("No of Periods")
        dgrid.Rows(24).Cells(0).Value = UCase("No of Runs")
        dgrid.Rows(25).Cells(0).Value = UCase("PAYE Tax Year-To-Date Code")
        dgrid.Rows(26).Cells(0).Value = UCase("PAYE Taxable Income Year-To-Date Code")
        dgrid.Rows(27).Cells(0).Value = UCase("Pensions Allowed Year-To-Date Code")
        dgrid.Rows(28).Cells(0).Value = UCase("Pensions Income Code")
        dgrid.Rows(29).Cells(0).Value = UCase("Pensions Income Year-To-Date Code")
        dgrid.Rows(30).Cells(0).Value = UCase("Pension Deduction Code")
        dgrid.Rows(31).Cells(0).Value = UCase("Pension Deduction Year-To-Date Code")
        dgrid.Rows(32).Cells(0).Value = UCase("Retirement Annuity Allowed Year-To-Date Code")
        dgrid.Rows(33).Cells(0).Value = UCase("Retirement Annuity Code")
        dgrid.Rows(34).Cells(0).Value = UCase("Retirement Annuity Year-To-Date Code")
        dgrid.Rows(35).Cells(0).Value = UCase("Retirement Fund PAYE Code")
        dgrid.Rows(36).Cells(0).Value = UCase("Retirement Fund PAYE Year-To-Date Code")
        dgrid.Rows(37).Cells(0).Value = UCase("Revised Taxable Income Year-To-Date Code")
        dgrid.Rows(38).Cells(0).Value = UCase("RU Advance Code")
        dgrid.Rows(39).Cells(0).Value = UCase("RU Amount Code")
        dgrid.Rows(40).Cells(0).Value = UCase("RU Recovery Code")
        dgrid.Rows(41).Cells(0).Value = UCase("Standard Hours Code")
        dgrid.Rows(42).Cells(0).Value = UCase("Standard Taxable Income Code")
        dgrid.Rows(43).Cells(0).Value = UCase("Stop Pay Flag")
        dgrid.Rows(44).Cells(0).Value = UCase("Tax Adjustment Balance Code")
        dgrid.Rows(45).Cells(0).Value = UCase("Tax Adjustment Code")
        dgrid.Rows(46).Cells(0).Value = UCase("Tax Authority Indicator")
        dgrid.Rows(47).Cells(0).Value = UCase("Tax (PAYE) Code")
        dgrid.Rows(48).Cells(0).Value = UCase("Taxed-to Period Code")
        dgrid.Rows(49).Cells(0).Value = UCase("Tax Periods Code")
        dgrid.Rows(50).Cells(0).Value = UCase("Tax-To-Date Code")
        dgrid.Rows(51).Cells(0).Value = UCase("Tax Year-To-Date Code")
        dgrid.Rows(52).Cells(0).Value = UCase("Taxable Income Code")
        dgrid.Rows(53).Cells(0).Value = UCase("Taxable Income Year-To-Date Code")
        dgrid.Rows(54).Cells(0).Value = UCase("Total Deductions Code")
        dgrid.Rows(55).Cells(0).Value = UCase("Year Start Date")
        dgrid.Rows(56).Cells(0).Value = UCase("Year End Date")
        dgrid.Rows(57).Cells(0).Value = UCase("Year End Period")
        dgrid.Rows(58).Cells(0).Value = UCase("Zero Gross Tax Stop Indicator")

        dgrid.Rows(59).Cells(0).Value = UCase("Aids Levy")
        dgrid.Rows(60).Cells(0).Value = UCase("Aids Levy Year-to-date")
        dgrid.Rows(61).Cells(0).Value = UCase("Medaid Expenses Code")
        dgrid.Rows(62).Cells(0).Value = UCase("Medaid Expenses Year-to-date")
        dgrid.Rows(63).Cells(0).Value = UCase("Current Medaid Expenses")
        dgrid.Rows(64).Cells(0).Value = UCase("Current Allowed Pension")
        dgrid.Rows(65).Cells(0).Value = UCase("Allowed Pension Year-to-date")
        dgrid.Rows(66).Cells(0).Value = UCase("Current Irregular Income")
        dgrid.Rows(67).Cells(0).Value = UCase("Irregular Income Year-to-date")
        dgrid.Rows(68).Cells(0).Value = UCase("Elderly Credits Year-to-date")
        dgrid.Rows(69).Cells(0).Value = UCase("Blind Credits Year-to-date")
        dgrid.Rows(70).Cells(0).Value = UCase("Disability Credits Year-to-date")

        'Set the default values

        dgrid.Rows(0).Cells(1).Value = "0"
        dgrid.Rows(1).Cells(1).Value = "0"
        dgrid.Rows(2).Cells(1).Value = "0"
        dgrid.Rows(3).Cells(1).Value = "0"
        dgrid.Rows(4).Cells(1).Value = "0"
        dgrid.Rows(5).Cells(1).Value = "0"
        dgrid.Rows(6).Cells(1).Value = "0"
        dgrid.Rows(7).Cells(1).Value = "0"
        dgrid.Rows(8).Cells(1).Value = "0"
        dgrid.Rows(9).Cells(1).Value = "0"
        dgrid.Rows(10).Cells(1).Value = "0"
        dgrid.Rows(11).Cells(1).Value = "0"
        dgrid.Rows(12).Cells(1).Value = "Y"
        dgrid.Rows(13).Cells(1).Value = "Z"
        dgrid.Rows(14).Cells(1).Value = "01-JAN-2010"
        dgrid.Rows(15).Cells(1).Value = "31-DEC-2010"
        dgrid.Rows(16).Cells(1).Value = "0"
        dgrid.Rows(17).Cells(1).Value = "0"
        dgrid.Rows(18).Cells(1).Value = "0"
        dgrid.Rows(19).Cells(1).Value = "0"
        dgrid.Rows(20).Cells(1).Value = "0"
        dgrid.Rows(21).Cells(1).Value = "0"
        dgrid.Rows(22).Cells(1).Value = "0"
        dgrid.Rows(23).Cells(1).Value = "12"
        dgrid.Rows(24).Cells(1).Value = "12"
        dgrid.Rows(25).Cells(1).Value = "0"
        dgrid.Rows(26).Cells(1).Value = "0"
        dgrid.Rows(27).Cells(1).Value = "0"
        dgrid.Rows(28).Cells(1).Value = "0"
        dgrid.Rows(29).Cells(1).Value = "0"
        dgrid.Rows(30).Cells(1).Value = "0"
        dgrid.Rows(31).Cells(1).Value = "0"
        dgrid.Rows(32).Cells(1).Value = "0"
        dgrid.Rows(33).Cells(1).Value = "0"
        dgrid.Rows(34).Cells(1).Value = "0"
        dgrid.Rows(35).Cells(1).Value = "0"
        dgrid.Rows(36).Cells(1).Value = "0"
        dgrid.Rows(37).Cells(1).Value = "0"
        dgrid.Rows(38).Cells(1).Value = "0"
        dgrid.Rows(39).Cells(1).Value = "0"
        dgrid.Rows(40).Cells(1).Value = "0"
        dgrid.Rows(41).Cells(1).Value = "0"
        dgrid.Rows(42).Cells(1).Value = "0"
        dgrid.Rows(43).Cells(1).Value = "N"
        dgrid.Rows(44).Cells(1).Value = "0"
        dgrid.Rows(45).Cells(1).Value = "0"
        dgrid.Rows(46).Cells(1).Value = "0"
        dgrid.Rows(47).Cells(1).Value = "0"
        dgrid.Rows(48).Cells(1).Value = "0"
        dgrid.Rows(49).Cells(1).Value = "0"
        dgrid.Rows(50).Cells(1).Value = "0"
        dgrid.Rows(51).Cells(1).Value = "0"
        dgrid.Rows(52).Cells(1).Value = "0"
        dgrid.Rows(53).Cells(1).Value = "0"
        dgrid.Rows(54).Cells(1).Value = "0"
        dgrid.Rows(55).Cells(1).Value = "01-JAN-2010"
        dgrid.Rows(56).Cells(1).Value = "31-DEC-2010"
        dgrid.Rows(57).Cells(1).Value = "12"
        dgrid.Rows(58).Cells(1).Value = "Y"

        dgrid.Rows(59).Cells(1).Value = "0"
        dgrid.Rows(60).Cells(1).Value = "0"
        dgrid.Rows(61).Cells(1).Value = "0"
        dgrid.Rows(62).Cells(1).Value = "0"
        dgrid.Rows(63).Cells(1).Value = "0"
        dgrid.Rows(64).Cells(1).Value = "0"
        dgrid.Rows(65).Cells(1).Value = "0"
        dgrid.Rows(66).Cells(1).Value = "0"
        dgrid.Rows(67).Cells(1).Value = "0"
        dgrid.Rows(68).Cells(1).Value = "0"
        dgrid.Rows(69).Cells(1).Value = "0"
        dgrid.Rows(70).Cells(1).Value = "0"

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Global User key data form load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub FillupValues()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AddTaxCode,AddTaxYtdCode,ArrPensAllowedYtdCode,ArrPensionCode,ArrPensionYtdCode " _
          & ",ArrRaAllowedYtdCode,ArrRaCode,ArrRaYtdCode,BasicCode,BonusTaxCode,BonusTaxYtdCode " _
          & ",BonusTiYtdCode,CumTaxInd,DefaultTaxAuth,FiscalYearEndDate,FiscalYearStartDate " _
          & ",GiCode,GiYtdCode,MedAidCode,MedAidYtdCode,NetCode,NonCashGICode,NonCashGIYTDCode " _
          & ",NoOfPeriods,NoOfRuns,PayeTaxYtdCode,PayeTiYtdCode,PensAllowedYtdCode,PensIncCode " _
          & ",PensIncYtdCode,PensionCode,PensionYtdCode,RaAllowedYtdCode,RaCode,RaYtdCode,RetFundPAYECode " _
          & ",RetFundPAYEYTDCode,RevisedTIYtdCode,RuAdvanceCode,RuAmt,RuRecoveryCode,StandardHrsCode " _
          & ",StandardTiCode,StopPay,TaxAdjBalCode,TaxAdjCode,TaxAuthorityInd,TaxCode,TaxedToPeriodCode " _
          & ",TaxPeriodsCode,TaxToDateCode,TaxYtdCode,TiCode,TiYtdCode,TotalDedsCode,YearEndDate " _
          & ",YearEndPeriod,YearStartDate,ZeroGrossTaxStopInd, AidsLevyCode, AidsLevyYtdCode, MedaidExpensesCode, " _
            & "MedaidExpensesYtdCode, CurrMedaidExpensesCode, CurrAllowedPensionCode, " _
            & "PensionAllowedYtdCode, CurrIrregularIncomeCode, YtdIrregularIncomeCode, " _
            & "ElderlyCreditsYtd, BlindCreditsCodeYtd, DisabilityCreditsCodeYtd FROM SystemKeyData"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AddTaxCode").ToString) Then dgrid.Rows(0).Cells(1).Value = UCase(objReader("AddTaxCode").ToString)
            If Not IsDBNull(objReader("AddTaxYtdCode").ToString) Then dgrid.Rows(1).Cells(1).Value = UCase(objReader("AddTaxYtdCode").ToString)
            If Not IsDBNull(objReader("ArrPensAllowedYtdCode").ToString) Then dgrid.Rows(2).Cells(1).Value = UCase(objReader("ArrPensAllowedYtdCode").ToString)
            If Not IsDBNull(objReader("ArrPensionCode").ToString) Then dgrid.Rows(3).Cells(1).Value = UCase(objReader("ArrPensionCode").ToString)
            If Not IsDBNull(objReader("ArrPensionYtdCode").ToString) Then dgrid.Rows(4).Cells(1).Value = UCase(objReader("ArrPensionYtdCode").ToString)
            If Not IsDBNull(objReader("ArrRaAllowedYtdCode").ToString) Then dgrid.Rows(5).Cells(1).Value = UCase(objReader("ArrRaAllowedYtdCode").ToString)
            If Not IsDBNull(objReader("ArrRaCode").ToString) Then dgrid.Rows(6).Cells(1).Value = UCase(objReader("ArrRaCode").ToString)
            If Not IsDBNull(objReader("ArrRaYtdCode").ToString) Then dgrid.Rows(7).Cells(1).Value = UCase(objReader("ArrRaYtdCode").ToString)
            If Not IsDBNull(objReader("BasicCode").ToString) Then dgrid.Rows(8).Cells(1).Value = UCase(objReader("BasicCode").ToString)
            If Not IsDBNull(objReader("BonusTaxCode").ToString) Then dgrid.Rows(9).Cells(1).Value = UCase(objReader("BonusTaxCode").ToString)
            If Not IsDBNull(objReader("BonusTaxYtdCode").ToString) Then dgrid.Rows(10).Cells(1).Value = UCase(objReader("BonusTaxYtdCode").ToString)
            If Not IsDBNull(objReader("BonusTiYtdCode").ToString) Then dgrid.Rows(11).Cells(1).Value = UCase(objReader("BonusTiYtdCode").ToString)
            If Not IsDBNull(objReader("CumTaxInd").ToString) Then dgrid.Rows(12).Cells(1).Value = UCase(objReader("CumTaxInd").ToString)
            If Not IsDBNull(objReader("DefaultTaxAuth").ToString) Then dgrid.Rows(13).Cells(1).Value = UCase(objReader("DefaultTaxAuth").ToString)
            If IsDate(objReader("FiscalYearEndDate").ToString) Then dgrid.Rows(14).Cells(1).Value = UCase(gwt_comm.shortMonthDateFormat(CDate(objReader("FiscalYearEndDate").ToString)))
            If IsDate(objReader("FiscalYearStartDate").ToString) Then dgrid.Rows(15).Cells(1).Value = UCase(gwt_comm.shortMonthDateFormat(CDate(objReader("FiscalYearStartDate").ToString)))
            If Not IsDBNull(objReader("GiCode").ToString) Then dgrid.Rows(16).Cells(1).Value = UCase(objReader("GiCode").ToString)
            If Not IsDBNull(objReader("GiYtdCode").ToString) Then dgrid.Rows(17).Cells(1).Value = UCase(objReader("GiYtdCode").ToString)
            If Not IsDBNull(objReader("MedAidCode").ToString) Then dgrid.Rows(18).Cells(1).Value = UCase(objReader("MedAidCode").ToString)
            If Not IsDBNull(objReader("MedAidYtdCode").ToString) Then dgrid.Rows(19).Cells(1).Value = UCase(objReader("MedAidYtdCode").ToString)
            If Not IsDBNull(objReader("NetCode").ToString) Then dgrid.Rows(20).Cells(1).Value = UCase(objReader("NetCode").ToString)
            If Not IsDBNull(objReader("NonCashGICode").ToString) Then dgrid.Rows(21).Cells(1).Value = UCase(objReader("NonCashGICode").ToString)
            If Not IsDBNull(objReader("NonCashGIYTDCode").ToString) Then dgrid.Rows(22).Cells(1).Value = UCase(objReader("NonCashGIYTDCode").ToString)
            If Not IsDBNull(objReader("NoOfPeriods").ToString) Then dgrid.Rows(23).Cells(1).Value = UCase(objReader("NoOfPeriods").ToString)
            If Not IsDBNull(objReader("NoOfRuns").ToString) Then dgrid.Rows(24).Cells(1).Value = UCase(objReader("NoOfRuns").ToString)
            If Not IsDBNull(objReader("PayeTaxYtdCode").ToString) Then dgrid.Rows(25).Cells(1).Value = UCase(objReader("PayeTaxYtdCode").ToString)
            If Not IsDBNull(objReader("PayeTiYtdCode").ToString) Then dgrid.Rows(26).Cells(1).Value = UCase(objReader("PayeTiYtdCode").ToString)
            If Not IsDBNull(objReader("PensAllowedYtdCode").ToString) Then dgrid.Rows(27).Cells(1).Value = UCase(objReader("PensAllowedYtdCode").ToString)
            If Not IsDBNull(objReader("PensIncCode").ToString) Then dgrid.Rows(28).Cells(1).Value = UCase(objReader("PensIncCode").ToString)
            If Not IsDBNull(objReader("PensIncYtdCode").ToString) Then dgrid.Rows(29).Cells(1).Value = UCase(objReader("PensIncYtdCode").ToString)
            If Not IsDBNull(objReader("PensionCode").ToString) Then dgrid.Rows(30).Cells(1).Value = UCase(objReader("PensionCode").ToString)
            If Not IsDBNull(objReader("PensionYtdCode").ToString) Then dgrid.Rows(31).Cells(1).Value = UCase(objReader("PensionYtdCode").ToString)
            If Not IsDBNull(objReader("RaAllowedYtdCode").ToString) Then dgrid.Rows(32).Cells(1).Value = UCase(objReader("RaAllowedYtdCode").ToString)
            If Not IsDBNull(objReader("RaCode").ToString) Then dgrid.Rows(33).Cells(1).Value = UCase(objReader("RaCode").ToString)
            If Not IsDBNull(objReader("RaYtdCode").ToString) Then dgrid.Rows(34).Cells(1).Value = UCase(objReader("RaYtdCode").ToString)
            If Not IsDBNull(objReader("RetFundPAYECode").ToString) Then dgrid.Rows(35).Cells(1).Value = UCase(objReader("RetFundPAYECode").ToString)
            If Not IsDBNull(objReader("RetFundPAYEYTDCode").ToString) Then dgrid.Rows(36).Cells(1).Value = UCase(objReader("RetFundPAYEYTDCode").ToString)
            If Not IsDBNull(objReader("RevisedTIYtdCode").ToString) Then dgrid.Rows(37).Cells(1).Value = UCase(objReader("RevisedTIYtdCode").ToString)
            If Not IsDBNull(objReader("RuAdvanceCode").ToString) Then dgrid.Rows(38).Cells(1).Value = UCase(objReader("RuAdvanceCode").ToString)
            If Not IsDBNull(objReader("RuAmt").ToString) Then dgrid.Rows(39).Cells(1).Value = UCase(objReader("RuAmt").ToString)
            If Not IsDBNull(objReader("RuRecoveryCode").ToString) Then dgrid.Rows(40).Cells(1).Value = UCase(objReader("RuRecoveryCode").ToString)
            If Not IsDBNull(objReader("StandardHrsCode").ToString) Then dgrid.Rows(41).Cells(1).Value = UCase(objReader("StandardHrsCode").ToString)
            If Not IsDBNull(objReader("StandardTiCode").ToString) Then dgrid.Rows(42).Cells(1).Value = UCase(objReader("StandardTiCode").ToString)
            If Not IsDBNull(objReader("StopPay").ToString) Then dgrid.Rows(43).Cells(1).Value = UCase(objReader("StopPay").ToString)
            If Not IsDBNull(objReader("TaxAdjBalCode").ToString) Then dgrid.Rows(44).Cells(1).Value = UCase(objReader("TaxAdjBalCode").ToString)
            If Not IsDBNull(objReader("TaxAdjCode").ToString) Then dgrid.Rows(45).Cells(1).Value = UCase(objReader("TaxAdjCode").ToString)
            If Not IsDBNull(objReader("TaxAuthorityInd").ToString) Then dgrid.Rows(46).Cells(1).Value = UCase(objReader("TaxAuthorityInd").ToString)
            If Not IsDBNull(objReader("TaxCode").ToString) Then dgrid.Rows(47).Cells(1).Value = UCase(objReader("TaxCode").ToString)
            If Not IsDBNull(objReader("TaxedToPeriodCode").ToString) Then dgrid.Rows(48).Cells(1).Value = UCase(objReader("TaxedToPeriodCode").ToString)
            If Not IsDBNull(objReader("TaxPeriodsCode").ToString) Then dgrid.Rows(49).Cells(1).Value = UCase(objReader("TaxPeriodsCode").ToString)
            If Not IsDBNull(objReader("TaxToDateCode").ToString) Then dgrid.Rows(50).Cells(1).Value = UCase(objReader("TaxToDateCode").ToString)
            If Not IsDBNull(objReader("TaxYtdCode").ToString) Then dgrid.Rows(51).Cells(1).Value = UCase(objReader("TaxYtdCode").ToString)
            If Not IsDBNull(objReader("TiCode").ToString) Then dgrid.Rows(52).Cells(1).Value = UCase(objReader("TiCode").ToString)
            If Not IsDBNull(objReader("TiYtdCode").ToString) Then dgrid.Rows(53).Cells(1).Value = UCase(objReader("TiYtdCode").ToString)
            If Not IsDBNull(objReader("TotalDedsCode").ToString) Then dgrid.Rows(54).Cells(1).Value = UCase(objReader("TotalDedsCode").ToString)
            If IsDate(objReader("YearStartDate").ToString) Then dgrid.Rows(55).Cells(1).Value = UCase(gwt_comm.shortMonthDateFormat(CDate(objReader("YearEndDate").ToString)))
            If Not IsDBNull(objReader("YearEndPeriod").ToString) Then dgrid.Rows(57).Cells(1).Value = UCase(objReader("YearEndPeriod").ToString)
            If IsDate(objReader("YearEndDate").ToString) Then dgrid.Rows(56).Cells(1).Value = UCase(gwt_comm.shortMonthDateFormat(CDate(objReader("YearStartDate").ToString)))
            If Not IsDBNull(objReader("ZeroGrossTaxStopInd").ToString) Then dgrid.Rows(58).Cells(1).Value = UCase(objReader("ZeroGrossTaxStopInd").ToString)

            If Not IsDBNull(objReader("AidsLevyCode").ToString) Then dgrid.Rows(59).Cells(1).Value = UCase(objReader("AidsLevyCode").ToString)
            If Not IsDBNull(objReader("AidsLevyYtdCode").ToString) Then dgrid.Rows(60).Cells(1).Value = UCase(objReader("AidsLevyYtdCode").ToString)
            If Not IsDBNull(objReader("MedaidExpensesCode").ToString) Then dgrid.Rows(61).Cells(1).Value = UCase(objReader("MedaidExpensesCode").ToString)
            If Not IsDBNull(objReader("MedaidExpensesYtdCode").ToString) Then dgrid.Rows(62).Cells(1).Value = UCase(objReader("MedaidExpensesYtdCode").ToString)
            If Not IsDBNull(objReader("CurrMedaidExpensesCode").ToString) Then dgrid.Rows(63).Cells(1).Value = UCase(objReader("CurrMedaidExpensesCode").ToString)
            If Not IsDBNull(objReader("CurrAllowedPensionCode").ToString) Then dgrid.Rows(64).Cells(1).Value = UCase(objReader("CurrAllowedPensionCode").ToString)
            If Not IsDBNull(objReader("PensionAllowedYtdCode").ToString) Then dgrid.Rows(65).Cells(1).Value = UCase(objReader("PensionAllowedYtdCode").ToString)
            If Not IsDBNull(objReader("CurrIrregularIncomeCode").ToString) Then dgrid.Rows(66).Cells(1).Value = UCase(objReader("CurrIrregularIncomeCode").ToString)
            If Not IsDBNull(objReader("YtdIrregularIncomeCode").ToString) Then dgrid.Rows(67).Cells(1).Value = UCase(objReader("YtdIrregularIncomeCode").ToString)
            If Not IsDBNull(objReader("ElderlyCreditsYtd").ToString) Then dgrid.Rows(68).Cells(1).Value = UCase(objReader("ElderlyCreditsYtd").ToString)
            If Not IsDBNull(objReader("BlindCreditsCodeYtd").ToString) Then dgrid.Rows(69).Cells(1).Value = UCase(objReader("BlindCreditsCodeYtd").ToString)
            If Not IsDBNull(objReader("DisabilityCreditsCodeYtd").ToString) Then dgrid.Rows(70).Cells(1).Value = UCase(objReader("DisabilityCreditsCodeYtd").ToString)

        Else
            boolIsNewEntry = True
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on key payroll codes form load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim intAddTaxCode As Integer = 0
        Dim intAddTaxYtdCode As Integer = 0
        Dim intArrPensAllowedYtdCode As Integer = 0
        Dim intArrPensionCode As Integer = 0
        Dim intArrPensionYtdCode As Integer = 0
        Dim intArrRaAllowedYtdCode As Integer = 0
        Dim intArrRaCode As Integer = 0
        Dim intArrRaYtdCode As Integer = 0
        Dim intBasicCode As Integer = 0
        Dim intBonusTaxCode As Integer = 0
        Dim intBonusTaxYtdCode As Integer = 0
        Dim intBonusTiYtdCode As Integer = 0
        Dim strCumTaxInd As String = "P"
        Dim strDefaultTaxAuth As String = "Z"
        Dim dtFiscalYearEndDate As Date = CDate("31-DEC-2010")
        Dim dtFiscalYearStartDate As Date = CDate("01-JAN-2010")
        Dim intGiCode As Integer = 0
        Dim intGiYtdCode As Integer = 0
        Dim intMedAidCode As Integer = 0
        Dim intMedAidYtdCode As Integer = 0
        Dim intNetCode As Integer = 0
        Dim intNonCashGICode As Integer = 0
        Dim intNonCashGIYTDCode As Integer = 0
        Dim intNoOfPeriods As Integer = 0
        Dim intNoOfRuns As Integer = 0
        Dim intPayeTaxYtdCode As Integer = 0
        Dim intPayeTiYtdCode As Integer = 0
        Dim intPensAllowedYtdCode As Integer = 0
        Dim intPensIncCode As Integer = 0
        Dim intPensIncYtdCode As Integer = 0
        Dim intPensionCode As Integer = 0
        Dim intPensionYtdCode As Integer = 0
        Dim intRaAllowedYtdCode As Integer = 0
        Dim intRaCode As Integer = 0
        Dim intRaYtdCode As Integer = 0
        Dim intRetFundPAYECode As Integer = 0
        Dim intRetFundPAYEYTDCode As Integer = 0
        Dim intRevisedTIYtdCode As Integer = 0
        Dim intRuAdvanceCode As Integer = 0
        Dim intRuAmt As Integer = 0
        Dim intRuRecoveryCode As Integer = 0
        Dim intStandardHrsCode As Integer = 0
        Dim intStandardTiCode As Integer = 0
        Dim strStopPay As String = "N"
        Dim intTaxAdjBalCode As Integer = 0
        Dim intTaxAdjCode As Integer = 0
        Dim intTaxAuthorityInd As Integer = 0
        Dim intTaxCode As Integer = 0
        Dim intTaxedToPeriodCode As Integer = 0
        Dim intTaxPeriodsCode As Integer = 0
        Dim intTaxToDateCode As Integer = 0
        Dim intTaxYtdCode As Integer = 0
        Dim intTiCode As Integer = 0
        Dim intTiYtdCode As Integer = 0
        Dim intTotalDedsCode As Integer = 0
        Dim dtYearEndDate As Date = CDate("31-DEC-2010")
        Dim intYearEndPeriod As Integer = 0
        Dim dtYearStartDate As Date = CDate("01-JAN-2010")
        Dim strZeroGrossTaxStopInd As String = "Y"

        Dim intAidLvy As Integer = 0, intAidLvyYtd As Integer = 0
        Dim intMedExp As Integer = 0, intMedExpYtd As Integer = 0, intMedExpCurr As Integer = 0
        Dim intCurrPensAllow As Integer = 0, intYtdPensAllow As Integer = 0
        Dim intIrregCurr As Integer = 0, intIrregYtd As Integer = 0
        Dim intEldCrYtd As Integer = 0, intBlindCrYtd As Integer = 0, intDisCrYtd As Integer = 0

        If Not dgrid.Rows(0).Cells(1).Value = Nothing Then intAddTaxCode = CInt(dgrid.Rows(0).Cells(1).Value.ToString)
        If Not dgrid.Rows(1).Cells(1).Value = Nothing Then intAddTaxYtdCode = CInt(dgrid.Rows(1).Cells(1).Value.ToString)
        If Not dgrid.Rows(2).Cells(1).Value = Nothing Then intArrPensAllowedYtdCode = CInt(dgrid.Rows(2).Cells(1).Value.ToString)
        If Not dgrid.Rows(3).Cells(1).Value = Nothing Then intArrPensionCode = CInt(dgrid.Rows(3).Cells(1).Value.ToString)
        If Not dgrid.Rows(4).Cells(1).Value = Nothing Then intArrPensionYtdCode = CInt(dgrid.Rows(4).Cells(1).Value.ToString)
        If Not dgrid.Rows(5).Cells(1).Value = Nothing Then intArrRaAllowedYtdCode = CInt(dgrid.Rows(5).Cells(1).Value.ToString)
        If Not dgrid.Rows(6).Cells(1).Value = Nothing Then intArrRaCode = CInt(dgrid.Rows(6).Cells(1).Value.ToString)
        If Not dgrid.Rows(7).Cells(1).Value = Nothing Then intArrRaYtdCode = CInt(dgrid.Rows(7).Cells(1).Value.ToString)
        If Not dgrid.Rows(8).Cells(1).Value = Nothing Then intBasicCode = CInt(dgrid.Rows(8).Cells(1).Value.ToString)
        If Not dgrid.Rows(9).Cells(1).Value = Nothing Then intBonusTaxCode = CInt(dgrid.Rows(9).Cells(1).Value.ToString)
        If Not dgrid.Rows(10).Cells(1).Value = Nothing Then intBonusTaxYtdCode = CInt(dgrid.Rows(10).Cells(1).Value.ToString)
        If Not dgrid.Rows(11).Cells(1).Value = Nothing Then intBonusTiYtdCode = CInt(dgrid.Rows(11).Cells(1).Value.ToString)
        If Not dgrid.Rows(12).Cells(1).Value = Nothing Then strCumTaxInd = dgrid.Rows(12).Cells(1).Value.ToString
        If Not dgrid.Rows(13).Cells(1).Value = Nothing Then strDefaultTaxAuth = dgrid.Rows(13).Cells(1).Value.ToString
        If Not dgrid.Rows(14).Cells(1).Value = Nothing Then dtFiscalYearEndDate = CDate(dgrid.Rows(14).Cells(1).Value.ToString)
        If Not dgrid.Rows(15).Cells(1).Value = Nothing Then dtFiscalYearStartDate = CDate(dgrid.Rows(15).Cells(1).Value.ToString)
        If Not dgrid.Rows(16).Cells(1).Value = Nothing Then intGiCode = CInt(dgrid.Rows(16).Cells(1).Value.ToString)
        If Not dgrid.Rows(17).Cells(1).Value = Nothing Then intGiYtdCode = CInt(dgrid.Rows(17).Cells(1).Value.ToString)
        If Not dgrid.Rows(18).Cells(1).Value = Nothing Then intMedAidCode = CInt(dgrid.Rows(18).Cells(1).Value.ToString)
        If Not dgrid.Rows(19).Cells(1).Value = Nothing Then intMedAidYtdCode = CInt(dgrid.Rows(19).Cells(1).Value.ToString)
        If Not dgrid.Rows(20).Cells(1).Value = Nothing Then intNetCode = CInt(dgrid.Rows(20).Cells(1).Value.ToString)
        If Not dgrid.Rows(21).Cells(1).Value = Nothing Then intNonCashGICode = CInt(dgrid.Rows(21).Cells(1).Value.ToString)
        If Not dgrid.Rows(22).Cells(1).Value = Nothing Then intNonCashGIYTDCode = CInt(dgrid.Rows(22).Cells(1).Value.ToString)
        If Not dgrid.Rows(23).Cells(1).Value = Nothing Then intNoOfPeriods = CInt(dgrid.Rows(23).Cells(1).Value.ToString)
        If Not dgrid.Rows(24).Cells(1).Value = Nothing Then intNoOfRuns = CInt(dgrid.Rows(24).Cells(1).Value.ToString)
        If Not dgrid.Rows(25).Cells(1).Value = Nothing Then intPayeTaxYtdCode = CInt(dgrid.Rows(25).Cells(1).Value.ToString)
        If Not dgrid.Rows(26).Cells(1).Value = Nothing Then intPayeTiYtdCode = CInt(dgrid.Rows(26).Cells(1).Value.ToString)
        If Not dgrid.Rows(27).Cells(1).Value = Nothing Then intPensAllowedYtdCode = CInt(dgrid.Rows(27).Cells(1).Value.ToString)
        If Not dgrid.Rows(28).Cells(1).Value = Nothing Then intPensIncCode = CInt(dgrid.Rows(28).Cells(1).Value.ToString)
        If Not dgrid.Rows(29).Cells(1).Value = Nothing Then intPensIncYtdCode = CInt(dgrid.Rows(29).Cells(1).Value.ToString)
        If Not dgrid.Rows(30).Cells(1).Value = Nothing Then intPensionCode = CInt(dgrid.Rows(30).Cells(1).Value.ToString)
        If Not dgrid.Rows(31).Cells(1).Value = Nothing Then intPensionYtdCode = CInt(dgrid.Rows(31).Cells(1).Value.ToString)
        If Not dgrid.Rows(32).Cells(1).Value = Nothing Then intRaAllowedYtdCode = CInt(dgrid.Rows(32).Cells(1).Value.ToString)
        If Not dgrid.Rows(33).Cells(1).Value = Nothing Then intRaCode = CInt(dgrid.Rows(33).Cells(1).Value.ToString)
        If Not dgrid.Rows(34).Cells(1).Value = Nothing Then intRaYtdCode = CInt(dgrid.Rows(34).Cells(1).Value.ToString)
        If Not dgrid.Rows(35).Cells(1).Value = Nothing Then intRetFundPAYECode = CInt(dgrid.Rows(35).Cells(1).Value.ToString)
        If Not dgrid.Rows(36).Cells(1).Value = Nothing Then intRetFundPAYEYTDCode = CInt(dgrid.Rows(36).Cells(1).Value.ToString)
        If Not dgrid.Rows(37).Cells(1).Value = Nothing Then intRevisedTIYtdCode = CInt(dgrid.Rows(37).Cells(1).Value.ToString)
        If Not dgrid.Rows(38).Cells(1).Value = Nothing Then intRuAdvanceCode = CInt(dgrid.Rows(38).Cells(1).Value.ToString)
        If Not dgrid.Rows(39).Cells(1).Value = Nothing Then intRuAmt = CInt(dgrid.Rows(39).Cells(1).Value.ToString)
        If Not dgrid.Rows(40).Cells(1).Value = Nothing Then intRuRecoveryCode = CInt(dgrid.Rows(40).Cells(1).Value.ToString)
        If Not dgrid.Rows(41).Cells(1).Value = Nothing Then intStandardHrsCode = CInt(dgrid.Rows(41).Cells(1).Value.ToString)
        If Not dgrid.Rows(42).Cells(1).Value = Nothing Then intStandardTiCode = CInt(dgrid.Rows(42).Cells(1).Value.ToString)
        If Not dgrid.Rows(43).Cells(1).Value = Nothing Then strStopPay = dgrid.Rows(43).Cells(1).Value.ToString
        If Not dgrid.Rows(44).Cells(1).Value = Nothing Then intTaxAdjBalCode = CInt(dgrid.Rows(44).Cells(1).Value.ToString)
        If Not dgrid.Rows(45).Cells(1).Value = Nothing Then intTaxAdjCode = CInt(dgrid.Rows(45).Cells(1).Value.ToString)
        If Not dgrid.Rows(46).Cells(1).Value = Nothing Then intTaxAuthorityInd = CInt(dgrid.Rows(46).Cells(1).Value.ToString)
        If Not dgrid.Rows(47).Cells(1).Value = Nothing Then intTaxCode = CInt(dgrid.Rows(47).Cells(1).Value.ToString)
        If Not dgrid.Rows(48).Cells(1).Value = Nothing Then intTaxedToPeriodCode = CInt(dgrid.Rows(48).Cells(1).Value.ToString)
        If Not dgrid.Rows(49).Cells(1).Value = Nothing Then intTaxPeriodsCode = CInt(dgrid.Rows(49).Cells(1).Value.ToString)
        If Not dgrid.Rows(50).Cells(1).Value = Nothing Then intTaxToDateCode = CInt(dgrid.Rows(50).Cells(1).Value.ToString)
        If Not dgrid.Rows(51).Cells(1).Value = Nothing Then intTaxYtdCode = CInt(dgrid.Rows(51).Cells(1).Value.ToString)
        If Not dgrid.Rows(52).Cells(1).Value = Nothing Then intTiCode = CInt(dgrid.Rows(52).Cells(1).Value.ToString)
        If Not dgrid.Rows(53).Cells(1).Value = Nothing Then intTiYtdCode = CInt(dgrid.Rows(53).Cells(1).Value.ToString)
        If Not dgrid.Rows(54).Cells(1).Value = Nothing Then intTotalDedsCode = CInt(dgrid.Rows(54).Cells(1).Value.ToString)
        If Not dgrid.Rows(55).Cells(1).Value = Nothing Then dtYearStartDate = CDate(dgrid.Rows(55).Cells(1).Value.ToString)
        If Not dgrid.Rows(57).Cells(1).Value = Nothing Then intYearEndPeriod = CInt(dgrid.Rows(57).Cells(1).Value.ToString)
        If Not dgrid.Rows(56).Cells(1).Value = Nothing Then dtYearEndDate = CDate(dgrid.Rows(56).Cells(1).Value.ToString)
        If Not dgrid.Rows(58).Cells(1).Value = Nothing Then strZeroGrossTaxStopInd = dgrid.Rows(58).Cells(1).Value.ToString

        If Not dgrid.Rows(59).Cells(1).Value = Nothing Then intAidLvy = CInt(dgrid.Rows(59).Cells(1).Value.ToString)
        If Not dgrid.Rows(60).Cells(1).Value = Nothing Then intAidLvyYtd = CInt(dgrid.Rows(60).Cells(1).Value.ToString)
        If Not dgrid.Rows(61).Cells(1).Value = Nothing Then intMedExp = CInt(dgrid.Rows(61).Cells(1).Value.ToString)
        If Not dgrid.Rows(62).Cells(1).Value = Nothing Then intMedExpYtd = CInt(dgrid.Rows(62).Cells(1).Value.ToString)
        If Not dgrid.Rows(63).Cells(1).Value = Nothing Then intMedExpCurr = CInt(dgrid.Rows(63).Cells(1).Value.ToString)
        If Not dgrid.Rows(64).Cells(1).Value = Nothing Then intCurrPensAllow = CInt(dgrid.Rows(64).Cells(1).Value.ToString)
        If Not dgrid.Rows(65).Cells(1).Value = Nothing Then intYtdPensAllow = CInt(dgrid.Rows(65).Cells(1).Value.ToString)
        If Not dgrid.Rows(66).Cells(1).Value = Nothing Then intIrregCurr = CInt(dgrid.Rows(66).Cells(1).Value.ToString)
        If Not dgrid.Rows(67).Cells(1).Value = Nothing Then intIrregYtd = CInt(dgrid.Rows(67).Cells(1).Value.ToString)
        If Not dgrid.Rows(68).Cells(1).Value = Nothing Then intEldCrYtd = CInt(dgrid.Rows(68).Cells(1).Value.ToString)
        If Not dgrid.Rows(69).Cells(1).Value = Nothing Then intBlindCrYtd = CInt(dgrid.Rows(69).Cells(1).Value.ToString)
        If Not dgrid.Rows(70).Cells(1).Value = Nothing Then intDisCrYtd = CInt(dgrid.Rows(70).Cells(1).Value.ToString)

        Dim strSql As String = Nothing
        If boolIsNewEntry = True Then
            'Insert new entry 
            strSql = "INSERT INTO SystemKeyData ([AddTaxCode],[AddTaxYtdCode],[ArrPensAllowedYtdCode],[ArrPensionCode] " _
           & ",[ArrPensionYtdCode],[ArrRaAllowedYtdCode],[ArrRaCode],[ArrRaYtdCode],[BasicCode] " _
           & ",[BonusTaxCode],[BonusTaxYtdCode],[BonusTiYtdCode],[CumTaxInd],[DefaultTaxAuth] " _
           & ",[FiscalYearEndDate],[FiscalYearStartDate],[GiCode],[GiYtdCode],[MedAidCode],[MedAidYtdCode] " _
           & ",[NetCode],[NonCashGICode],[NonCashGIYTDCode],[NoOfPeriods],[NoOfRuns],[PayeTaxYtdCode] " _
           & ",[PayeTiYtdCode],[PensAllowedYtdCode],[PensIncCode],[PensIncYtdCode],[PensionCode] " _
           & ",[PensionYtdCode],[RaAllowedYtdCode],[RaCode],[RaYtdCode],[RetFundPAYECode],[RetFundPAYEYTDCode] " _
           & ",[RevisedTIYtdCode],[RuAdvanceCode],[RuAmt],[RuRecoveryCode],[StandardHrsCode],[StandardTiCode] " _
           & ",[StopPay],[TaxAdjBalCode],[TaxAdjCode],[TaxAuthorityInd],[TaxCode],[TaxedToPeriodCode] " _
           & ",[TaxPeriodsCode],[TaxToDateCode],[TaxYtdCode],[TiCode],[TiYtdCode],[TotalDedsCode],[YearEndDate] " _
           & ",[YearEndPeriod],[YearStartDate],[ZeroGrossTaxStopInd], AidsLevyCode, AidsLevyYtdCode, MedaidExpensesCode, " _
            & "MedaidExpensesYtdCode, CurrMedaidExpensesCode, CurrAllowedPensionCode, " _
            & "PensionAllowedYtdCode, CurrIrregularIncomeCode, YtdIrregularIncomeCode, " _
            & "ElderlyCreditsYtd, BlindCreditsCodeYtd, DisabilityCreditsCodeYtd) " _
           & "VALUES (" & intAddTaxCode & "," & intAddTaxYtdCode & "," & intArrPensAllowedYtdCode & " " _
           & "," & intArrPensionCode & "," & intArrPensionYtdCode & "," & intArrRaAllowedYtdCode & " " _
           & "," & intArrRaCode & "," & intArrRaYtdCode & "," & intBasicCode & "," & intBonusTaxCode & " " _
           & "," & intBonusTaxYtdCode & "," & intBonusTiYtdCode & ",'" & strCumTaxInd & "','" & strDefaultTaxAuth & "' " _
           & ",'" & dtFiscalYearEndDate & "','" & dtFiscalYearStartDate & "'," & intGiCode & "," & intGiYtdCode & " " _
           & "," & intMedAidCode & "," & intMedAidYtdCode & "," & intNetCode & "," & intNonCashGICode & " " _
           & "," & intNonCashGIYTDCode & "," & intNoOfPeriods & "," & intNoOfRuns & "," & intPayeTaxYtdCode & " " _
           & "," & intPayeTiYtdCode & "," & intPensAllowedYtdCode & "," & intPensIncCode & "," & intPensIncYtdCode & " " _
           & "," & intPensionCode & "," & intPensionYtdCode & "," & intRaAllowedYtdCode & "," & intRaCode & " " _
           & "," & intRaYtdCode & "," & intRetFundPAYECode & "," & intRetFundPAYEYTDCode & "," & intRevisedTIYtdCode & " " _
           & "," & intRuAdvanceCode & "," & intRuAmt & "," & intRuRecoveryCode & "," & intStandardHrsCode & " " _
           & "," & intStandardTiCode & ",'" & strStopPay & "'," & intTaxAdjBalCode & "," & intTaxAdjCode & " " _
           & "," & intTaxAuthorityInd & "," & intTaxCode & "," & intTaxedToPeriodCode & "," & intTaxPeriodsCode & " " _
           & "," & intTaxToDateCode & "," & intTaxYtdCode & "," & intTiCode & "," & intTiYtdCode & "," & intTotalDedsCode & " " _
           & ",'" & dtYearEndDate & "'," & intYearEndPeriod & ",'" & dtYearStartDate & "','" & strZeroGrossTaxStopInd & "' " _
            & "," & intAidLvy & ",'" & intAidLvyYtd & "'," & intMedExp & "," & intMedExpCurr & " " _
           & "," & intMedExpYtd & "," & intCurrPensAllow & "," & intYtdPensAllow & "," & intIrregCurr & " " _
           & "," & intIrregYtd & "," & intEldCrYtd & "," & intBlindCrYtd & "," & intDisCrYtd & ")"
        Else
            'Update the details
            strSql = "UPDATE SystemKeyData SET [AddTaxCode] = " & intAddTaxCode & ", [AddTaxYtdCode] = " & intAddTaxYtdCode & ", " _
                & "[ArrPensAllowedYtdCode] = " & intArrPensAllowedYtdCode & ", [ArrPensionCode] = " & intArrPensionCode & ", " _
                & "[ArrPensionYtdCode] = " & intArrPensionYtdCode & ", [ArrRaAllowedYtdCode] = " & intArrRaAllowedYtdCode & ", " _
                & "[ArrRaCode] = " & intArrRaCode & ", [ArrRaYtdCode] = " & intArrRaYtdCode & ", [BasicCode] = " & intBasicCode & ", " _
                & "[BonusTaxCode] = " & intBonusTaxCode & ", [BonusTaxYtdCode] = " & intBonusTaxYtdCode & ", " _
                & "[BonusTiYtdCode] = " & intBonusTiYtdCode & ", [CumTaxInd] = '" & strCumTaxInd & "', " _
                & "[DefaultTaxAuth] = '" & strDefaultTaxAuth & "', [FiscalYearEndDate] = '" & dtFiscalYearEndDate & "', " _
                & "[FiscalYearStartDate] = '" & dtFiscalYearStartDate & "', [GiCode] = " & intGiCode & ", " _
                & "[GiYtdCode] = " & intGiYtdCode & ", [MedAidCode] = " & intMedAidCode & ", " _
                & "[MedAidYtdCode] = " & intMedAidYtdCode & ", [NetCode] = " & intNetCode & ", [NonCashGICode] = " & intNonCashGICode & ", " _
                & "[NonCashGIYTDCode] = " & intNonCashGIYTDCode & ", [NoOfPeriods] = " & intNoOfPeriods & ", " _
                & "[NoOfRuns] = " & intNoOfRuns & ", [PayeTaxYtdCode] = " & intPayeTaxYtdCode & ", " _
                & "[PayeTiYtdCode] = " & intPayeTiYtdCode & ", [PensAllowedYtdCode] = " & intPensAllowedYtdCode & ", " _
                & "[PensIncCode] = " & intPensIncCode & ", [PensIncYtdCode] = " & intPensIncYtdCode & ", " _
                & "[PensionCode] = " & intPensionCode & ", [PensionYtdCode] = " & intPensionYtdCode & ", " _
                & "[RaAllowedYtdCode] = " & intRaAllowedYtdCode & ", [RaCode] = " & intRaCode & ", " _
                & "[RaYtdCode] = " & intRaYtdCode & ", [RetFundPAYECode] = " & intRetFundPAYECode & ", " _
                & "[RetFundPAYEYTDCode] = " & intRetFundPAYEYTDCode & ", [RevisedTIYtdCode] = " & intRevisedTIYtdCode & ", " _
                & "[RuAdvanceCode] = " & intRuAdvanceCode & ", [RuAmt] = " & intRuAmt & ", " _
                & "[RuRecoveryCode] = " & intRuRecoveryCode & ", [StandardHrsCode] = " & intStandardHrsCode & ", " _
                & "[StandardTiCode] = " & intStandardTiCode & ", [StopPay] = '" & strStopPay & "', " _
                & "[TaxAdjBalCode] = " & intTaxAdjBalCode & ", [TaxAdjCode] = " & intTaxAdjCode & ", " _
                & "[TaxAuthorityInd] = " & intTaxAuthorityInd & ", [TaxCode] = " & intTaxCode & ", " _
                & "[TaxedToPeriodCode] = " & intTaxedToPeriodCode & ", [TaxPeriodsCode] = " & intTaxPeriodsCode & ", " _
                & "[TaxToDateCode] = " & intTaxToDateCode & ", [TaxYtdCode] = " & intTaxYtdCode & ", " _
                & "[TiCode] = " & intTiCode & ", [TiYtdCode] = " & intTiYtdCode & ", " _
                & "[TotalDedsCode] = " & intTotalDedsCode & ", [YearEndDate] = '" & dtYearEndDate & "', " _
                & "[YearEndPeriod] = " & intYearEndPeriod & ", [YearStartDate] = '" & dtYearStartDate & "', " _
                & "[ZeroGrossTaxStopInd] = '" & strZeroGrossTaxStopInd & "', [AidsLevyCode] = " & intAidLvy & ", " _
                & "[AidsLevyYtdCode] = " & intAidLvyYtd & ", [MedaidExpensesCode] = " & intMedExp & ", " _
            & "[MedaidExpensesYtdCode] = " & intMedExpYtd & ", [CurrMedaidExpensesCode] = " & intMedExpCurr & ", " _
            & "[CurrAllowedPensionCode] = " & intCurrPensAllow & ", " _
            & "[PensionAllowedYtdCode] = " & intYtdPensAllow & ", [CurrIrregularIncomeCode] = " & intIrregCurr & ", " _
            & "[YtdIrregularIncomeCode] = " & intIrregYtd & ", [ElderlyCreditsYtd] = " & intEldCrYtd & ", " _
            & "[BlindCreditsCodeYtd] = " & intBlindCrYtd & ", [DisabilityCreditsCodeYtd] = " & intDisCrYtd & ""
        End If
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        gwt_comm.GetKeyDataFields()
        MessageBox.Show("Key Data Fields Updated Successfully", "Transactions Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on key payroll codes form load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmKeyData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateCaptions()
        FillupValues()
    End Sub

    Private Sub dgrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellContentClick
        'Display the quick pick form based on the row
        If e.ColumnIndex = 2 Then
            If dgrid.CurrentRow.Index = 14 Or _
                dgrid.CurrentRow.Index = 15 Or _
                dgrid.CurrentRow.Index = 55 Or _
                dgrid.CurrentRow.Index = 56 Then
                If IsDate(dgrid.CurrentRow.Cells(1).Value.ToString) Then
                    strSelectedDate = gwt_comm.shortMonthDateFormat(CDate(dgrid.CurrentRow.Cells(1).Value.ToString))
                Else
                    If dgrid.CurrentRow.Index = 14 Then strSelectedDate = "01-JAN-" & Format(CInt(DatePart(DateInterval.Year, Now)), "0000")
                    If dgrid.CurrentRow.Index = 15 Then strSelectedDate = "31-DEC-" & Format(CInt(DatePart(DateInterval.Year, Now)), "0000")
                    If dgrid.CurrentRow.Index = 55 Then strSelectedDate = "01-JAN-" & Format(CInt(DatePart(DateInterval.Year, Now)), "0000")
                    If dgrid.CurrentRow.Index = 56 Then strSelectedDate = "31-DEC-" & Format(CInt(DatePart(DateInterval.Year, Now)), "0000")
                End If
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                dgrid.CurrentRow.Cells(1).Value = gwt_comm.shortMonthDateFormat(dtSetDate)
                Exit Sub
            End If
            If dgrid.CurrentRow.Index = 12 Or _
                dgrid.CurrentRow.Index = 13 Or _
                dgrid.CurrentRow.Index = 43 Or _
                dgrid.CurrentRow.Index = 58 Then
                Exit Sub
            Else
                strSelectedCode = "0"
                boolAbort = False
                gwt_comm.PayrollCodesSearch()
                If boolAbort = True Then Exit Sub
                dgrid.CurrentRow.Cells(1).Value = strSelectedCode
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgrid.CellValidating
        ValidateDataInput(e.RowIndex, e.ColumnIndex)
    End Sub

    Private Sub ValidateDataInput(ByVal intRowIndex As Integer, ByVal intColumnIndex As Integer)
        If intRowIndex = 12 And intColumnIndex = 1 Then
            If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value = Nothing Or _
                dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString <> "Y" Then
                If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value <> "N" Then
                    MessageBox.Show("The required value can be either Y or N. Value will be set to default Y", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(12).Cells(1).Value = "Y"
                    Exit Sub
                End If
            End If
        End If
        If intRowIndex = 13 And intColumnIndex = 1 Then
            If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value = Nothing Or _
                IsNumeric(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString) Then
                MessageBox.Show("The required 1 alpha letter, e.g. Z for Zimbabwe or A for South Africa", _
                    "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dgrid.Rows(13).Cells(1).Value = "Z"
                Exit Sub
            End If
        End If
        If intRowIndex = 14 And intColumnIndex = 1 Then
            If Not IsDate(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                MessageBox.Show("The required value must be a date formatted to " _
                    & "dd-MMM-yyyy" & vbCrLf & "The default date will be applied", _
                    "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dgrid.Rows(14).Cells(1).Value = "01-JAN-2010"
                Exit Sub
            End If
        End If
        If intRowIndex = 15 And intColumnIndex = 1 Then
            If Not IsDate(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                MessageBox.Show("The required value must be a date formatted to " _
                    & "dd-MMM-yyyy" & vbCrLf & "The default date will be applied", _
                    "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dgrid.Rows(15).Cells(1).Value = "31-DEC-2010"
                Exit Sub
            End If
        End If
        If intRowIndex = 55 And intColumnIndex = 1 Then
            If Not IsDate(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                MessageBox.Show("The required value must be a date formatted to " _
                    & "dd-MMM-yyyy" & vbCrLf & "The default date will be applied", _
                    "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dgrid.Rows(55).Cells(1).Value = "01-JAN-2010"
                Exit Sub
            End If
        End If
        If intRowIndex = 56 And intColumnIndex = 1 Then
            If Not IsDate(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                MessageBox.Show("The required value must be a date formatted to " _
                    & "dd-MMM-yyyy" & vbCrLf & "The default date will be applied", _
                    "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dgrid.Rows(56).Cells(1).Value = "31-DEC-2010"
                Exit Sub
            End If
        End If
        If intRowIndex = 43 And intColumnIndex = 1 Then
            If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value = Nothing Or _
                dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString <> "Y" Then
                If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value <> "N" Then
                    MessageBox.Show("The required value can be either Y or N. Value will be set to default N", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(43).Cells(1).Value = "N"
                    Exit Sub
                End If
            End If
        End If
        If intRowIndex = 58 And intColumnIndex = 1 Then
            If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value = Nothing Or _
                dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString <> "Y" Then
                If dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value <> "N" Then
                    MessageBox.Show("The required value can be either Y or N. Value will be set to default Y", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(58).Cells(1).Value = "Y"
                    Exit Sub
                End If
            End If
        End If
        If intRowIndex >= 0 And intRowIndex <= 11 Then
            If intColumnIndex = 1 Then
                If Not IsNumeric(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                    MessageBox.Show("The required value must be numeric. Value will be set to default 0", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(intRowIndex).Cells(1).Value = "0"
                Else
                    If CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString) <> 0 Then
                        If intRowIndex = 23 Or intRowIndex = 24 Or intRowIndex = 57 Then Exit Sub
                        If gwt_comm.ValidCode(CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString)) = False Then
                            MessageBox.Show("The code you have entered is invalid. Code set back to 0", _
                                "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            End If
        End If
        If intRowIndex >= 16 And intRowIndex <= 42 Then
            If intColumnIndex = 1 Then
                If Not IsNumeric(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                    MessageBox.Show("The required value must be numeric. Value will be set to default 0", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(intRowIndex).Cells(1).Value = "0"
                Else
                    If CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString) <> 0 Then
                        If intRowIndex = 23 Or intRowIndex = 24 Or intRowIndex = 57 Then Exit Sub
                        If gwt_comm.ValidCode(CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString)) = False Then
                            MessageBox.Show("The code you have entered is invalid. Code set back to 0", _
                                "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            End If
        End If
        If intRowIndex >= 44 And intRowIndex <= 54 Then
            If intColumnIndex = 1 Then
                If Not IsNumeric(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                    MessageBox.Show("The required value must be numeric. Value will be set to default 0", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(intRowIndex).Cells(1).Value = "0"
                Else
                    If CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString) <> 0 Then
                        If intRowIndex = 23 Or intRowIndex = 24 Or intRowIndex = 57 Then Exit Sub
                        If gwt_comm.ValidCode(CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString)) = False Then
                            MessageBox.Show("The code you have entered is invalid. Code set back to 0", _
                                "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            End If
        End If
        If intRowIndex = 57 Then
            If intColumnIndex = 1 Then
                If Not IsNumeric(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value) Then
                    MessageBox.Show("The required value must be numeric. Value will be set to default 0", _
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgrid.Rows(intRowIndex).Cells(1).Value = "0"
                Else
                    If CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString) <> 0 Then
                        If intRowIndex = 23 Or intRowIndex = 24 Or intRowIndex = 57 Then Exit Sub
                        If gwt_comm.ValidCode(CInt(dgrid.Rows(intRowIndex).Cells(intColumnIndex).Value.ToString)) = False Then
                            MessageBox.Show("The code you have entered is invalid. Code set back to 0", _
                                "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellValueChanged
        ValidateDataInput(e.RowIndex, e.ColumnIndex)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dgrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(1).Value), "")) Then
                For p As Integer = 0 To dgrid.ColumnCount - 2
                    'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                    Dim strFontName As String = "Arial"
                    Dim intFontSize As Integer = 6
                    Dim strFontColor As String = "Black"
                    Dim strFontBold As String = "False"
                    Dim strFontItalic As String = "False"
                    Dim strFontUnderline As String = "False"
                    Dim strBackColor As String = "White"
                    Dim intRectangleHeight As Integer = 25
                    Dim strPrintData As String = Nothing
                    If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(p).Value), "")) Then
                        strPrintData = dgrid.Rows(i).Cells(p).Value.ToString
                        'Get the actual font and style used in the grid
                        Dim fnt As Font = dgrid.Rows(i).Cells(p).Style.Font
                        If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                        If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                        Dim strFontStyle As String = "False"
                        If Not fnt Is Nothing Then strFontStyle = fnt.Style
                        If strFontStyle = "1" Then strFontBold = "True"
                        If strFontStyle = "2" Then strFontItalic = "True"
                        If strFontStyle = "3" Then ' Bold and italic
                            strFontBold = "True"
                            strFontItalic = "True"
                        End If
                        If strFontStyle = "4" Then strFontUnderline = "True"
                        If strFontStyle = "5" Then ' Bold and underline
                            strFontBold = "True"
                            strFontUnderline = "True"
                        End If
                        If strFontStyle = "6" Then ' italic and underline
                            strFontItalic = "True"
                            strFontUnderline = "True"
                        End If
                        If strFontStyle = "7" Then ' italic and underline
                            strFontItalic = "True"
                            strFontUnderline = "True"
                            strFontBold = "True"
                        End If
                    End If

                    strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                        & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                        & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & "</d>"

                Next

                strLineData = Mid(strLineData, 1, strLineData.Length - 4)
                arrPrintDetails.Add(strLineData)

            End If
        Next

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim strColumnHeaders As String = Nothing
        For i As Integer = 0 To dgrid.ColumnCount - 2
            strColumnHeaders = strColumnHeaders & dgrid.Columns(i).HeaderText & "|"
        Next
        strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

        'Request for print properties
        Dim prnt As New PrintDialog
        prnt.ShowDialog()

        Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

        'Widths are based on the percentage point of the paper size and the grid
        Dim strColumnWidths As String = Nothing
        Dim strColumsVisible As String = Nothing

        Dim intTotalGridWidth As Integer = 0
        'calculate the total column widths
        For y As Integer = 0 To dgrid.ColumnCount - 2
            intTotalGridWidth = intTotalGridWidth + dgrid.Columns(y).Width
        Next

        Dim intValidateWidth As Integer = 0
        For i As Integer = 0 To dgrid.ColumnCount - 2
            Dim intCurrentWidth As Integer = 0

            'Calculate the width based on the percentage in the grid
            Dim intEqualWidth As Integer = intPrintPageAreaWidth / dgrid.Columns.Count
            Dim intPercentagePrintArea As Integer = (dgrid.Columns(i).Width / intTotalGridWidth) * 100
            intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

            strColumnWidths = strColumnWidths & intCurrentWidth & "|"

            If intCurrentWidth = 0 Then
                strColumsVisible = strColumsVisible & "NO" & "|"
            Else
                strColumsVisible = strColumsVisible & "YES" & "|"
            End If
            intValidateWidth = intValidateWidth + intCurrentWidth
        Next
        strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
        strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dgrid.ColumnCount - 1
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Payroll Key Codes"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PAYROLL KEY CODES"
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumsVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Cursor = Cursors.Default
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On key payroll codes Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
