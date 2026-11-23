
Module CommonVariableAndFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions
    Public strPaymentMethod As String

    Public dblAmountTenderedCash As Double
    Public dblAmountTenderedEcoCash As Double
    Public dblAmountTenderedSwipe As Double
    Public dblAmountTenderedTransfer As Double
    Public dblAmountTenderedOther As Double

    Public dblReceiptAmount As Double

    Public eServerName As String
    Public eDatabase As String
    Public ePassword As String
    Public eUserName As String

    'Public Function shortMonthDateFormat(ByVal inDate As Date) As String
    '    Dim strReturn As String = Nothing
    '    If IsDate(inDate) Then
    '        strReturn = CStr(Format(DatePart(DateInterval.Day, inDate), "00")) & "-" &
    '        Mid(MonthName(DatePart(DateInterval.Month, inDate), True), 1, 3) & "-" &
    '        CStr(Format(DatePart(DateInterval.Year, inDate), "0000"))
    '    Else
    '        Return inDate.ToString
    '    End If
    '    Return strReturn
    'End Function

End Module
