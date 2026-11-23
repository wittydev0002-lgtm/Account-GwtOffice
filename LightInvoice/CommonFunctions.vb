Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions
    Public intAgingDaysPerPeriod As Integer
    Public intAgingIntervals As Integer
    Public intNextInvoiceNumber As Integer
    Public invoiceDate As Date
    Public boolInvoiceOverwritten As Boolean

    Public dblAmountTenderedCash As Double
    Public dblAmountTenderedEcoCash As Double
    Public dblAmountTenderedSwipe As Double
    Public dblAmountTenderedTransfer As Double
    Public dblAmountTenderedOther As Double

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

End Module