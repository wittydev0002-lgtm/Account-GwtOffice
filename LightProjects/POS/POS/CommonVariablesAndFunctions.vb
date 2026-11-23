Module CommonVariablesAndFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

    Public strNewInventoryItemCode As String
    Public strselectedShortCode As String

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

    Public dblAmountTenderedCash As Double
    Public dblAmountTenderedEcoCash As Double
    Public dblAmountTenderedSwipe As Double
    Public dblAmountTenderedTransfer As Double
    Public dblAmountTenderedOther As Double

End Module
