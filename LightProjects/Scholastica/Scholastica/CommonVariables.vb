Imports System.Data
Imports System.Data.OleDb
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonVariables

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

    Public intHighestSchoolGrade As Integer
    Public intYearStudentLeft As Integer

    Public strActiveSearch As String
    Public intLearnershipPeriod As Integer
    Public intStartingAge As Integer
    Public strNewStudentClassName As String
    Public arrNewStudentPaymentDetails As ArrayList
    Public strNewStudentPaymentRemarks As String
    Public dblNewStudentPaymentsTotal As Double
    Public intSelectedReceipt As Integer
    Public boolIncreamentCounter As Boolean
    Public intOverideReceiptNumber As Integer
    Public boolModified As Boolean
    Public strSchoolOperationType As String = "CONVENTIONAL"

    Public strStudentNumberPrefix As String
    Public strStudentNumberSuffix As String
    Public strStudentNumberAllocationMethod As String
    Public strStudentNumberAllocationBase As String
    Public strStudentNumberSeperator As String
    Public strStudentNumberSuffixBase As String

    Public strSchoolNumber As String
    Public intBilliableSubjectsLimit As Integer

    Public strReceiptSpecialNotes As String

    Public dblExtraAmount As Double
    Public strExtraPaymentDescription As String

    Public dpDueDateSelected As Date
    Public strSelectedTerm As String
    Public intInvoiceYear As Integer

End Module
