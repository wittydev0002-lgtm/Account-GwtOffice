Module commonVariables2

    Public printToFiscalPrinter As Boolean

    Public dblUS_Rate As Double = 1
    Public dblRand_Rate As Double = 0
    Public dblBond_Rate As Double = 0
    Public dblTransfer_Rate As Double = 0
    Public dblSwipe_Rate As Double = 0
    Public dblEcocash_Rate As Double = 0
    Public dblPula_Rate As Double = 0

    Public dblReceiptValue As Double = 0

    Public changeCurrency As String

    Public strPriceType As String
    Public strTillslipCustomerName As String
    Public strCustomerTin As String = Nothing
    Public strTillCustomerVat As String = Nothing

    Public intSelectedOrdinalNo As Integer
    Public strSelectedOptionValue As String
    Public intOriginalDocumentNumber As Integer

    Public intPublicTestFiscalCommPort As Integer
    Public intPublicFiscalCurrency As Integer

    Public dblActiveExchangeRate As Double

    Public intFiscalBonType As Integer
    Public strSaleCurrencyUsed As String

    Public dblActiveSalesCurrencyRate As Double

End Module
