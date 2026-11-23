Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing.Printing
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public gwt_comm As New CommonLibrary.Commons.CommonFunctions

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub OpenDatabase()
        On Error GoTo RaiseErr
        cnn = New Data.OleDb.OleDbConnection(strConnection)
        cnn.Open()
        boolConnectionStatus = True
        Exit Sub
RaiseErr:
        boolAbort = True
        boolConnectionStatus = False
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Database connection"
        ShowErrorMessage()
    End Sub

    Public Sub UpdateDatabase()

    End Sub

    Public Sub AssignDefaults()

    End Sub

    Public Sub AssignCompanyDetails()
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If IsNumeric(dbReader("ExpiryDays").ToString) Then intBorrowingPeriod = CInt(dbReader("ExpiryDays").ToString)
            If Not IsDBNull(dbReader("CompanyName").ToString) Then strCompanyName = dbReader("CompanyName").ToString
        End If
        dbReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        boolConnectionStatus = False
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Company Defaults Load"
        ShowErrorMessage()
    End Sub

    Public Sub GetKeyDataFields()

    End Sub

    Public Sub AssignSmsHttpSettings()

    End Sub

    Public Sub getBackupPath()

    End Sub

    Public Sub GetPrinterSettings()

    End Sub

    Public Function UnEncryption(ByVal PlanText As String) As String
        Dim HashedBytes As Byte()
        Dim MD5 As String = String.Empty
        Dim encoder As New System.Text.UTF8Encoding()
        Dim md5Hasher As New MD5CryptoServiceProvider()

        HashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(PlanText))

        For A As Int32 = 0 To HashedBytes.Length - 1
            MD5 += HashedBytes(A).ToString("x2")
        Next A
        Return MD5
    End Function

End Module
