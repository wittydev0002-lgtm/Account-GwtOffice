Module CommonStructures

    Public Structure SalesData
        Public GrossSales As Double
        Public Taxes As Double
        Public Discounts As Double
        Public CostOfSales As Double
    End Structure

    Public Structure LedgerFigures
        Public OpeningBalance As Double
        Public PeriodMovement As Double
        Public ClosingBalance As Double
        Public DebitEntries As Double
        Public CreditEntries As Double
    End Structure

    Public Structure CashbookFigures
        Public OpeningBalance As Double
        Public PeriodMovement As Double
        Public ClosingBalance As Double
        Public DebitEntries As Double
        Public CreditEntries As Double
    End Structure

    Public Structure TrustCashbookFigures
        Public OpeningBalance As Double
        Public PeriodMovement As Double
        Public ClosingBalance As Double
        Public DebitEntries As Double
        Public CreditEntries As Double
    End Structure

End Module
