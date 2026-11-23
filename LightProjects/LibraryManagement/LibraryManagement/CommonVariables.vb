Module CommonVariables

    Public boolAbort As Boolean
    Public boolEditStatus As Boolean
    Public cnn As Data.OleDb.OleDbConnection
    Public strErrorMessages As String
    Public strConnection As String
    Public boolConnectionStatus As Boolean
    Public intSelectedRecord As Integer
    Public boolApplicationRunning As Boolean
    Public strPublicActiveFullUserName As String
    Public strUserLevel As String
    Public strUserName As String
    Public strUserBranch As String
    Public strSelectedBookNumber As String

    'Declare and set the default fonts
    Public fntHeaderFont As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Public fntDetailsFont As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public fntFooterFontItalic As New System.Drawing.Font("Times New Roman", 6, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
    Public fntDetailsFontBold As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Public strCompanyName As String
    Public intBorrowingPeriod As Integer
    Public strSelectedUser As String
    Public strSessionPrinter As String
    Public strSelectedUserLevel As String

End Module
