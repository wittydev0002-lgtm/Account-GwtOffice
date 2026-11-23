Imports System.IO
Imports System.Text

Module BankFileXtractFunctions

    Public Sub PrintHeader(ByVal DetailLine As String, ByVal sFilename As String)
        On Error GoTo RaiseErr
        'open the file as new for writing details into
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(sFilename, False)
        objStreamWriter.WriteLine(DetailLine)
        objStreamWriter.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "File Header Details Write Error")
        boolErrorFlag = True
    End Sub

    Public Sub PrintDetails(ByVal DetailLine As String, ByVal FileName As String)
        On Error GoTo RaiseErr
        'use the open file for writing record line into
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(FileName, True)
        'Write out the details.
        objStreamWriter.WriteLine(DetailLine)
        objStreamWriter.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Record Details Write Error")
        boolErrorFlag = True
    End Sub

    Public Sub PrintTrailer(ByVal TrailerLine As String, ByVal sFileName As String)
        On Error GoTo RaiseErr
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(sFileName, True)
        objStreamWriter.WriteLine(TrailerLine)
        objStreamWriter.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Trailer Details Write Error")
        boolErrorFlag = True
    End Sub

    Public Sub InitializeValues()
        intDebits = 0 : intCredits = 0
        dblDebits = 0 : dblCredits = 0
        boolErrorFlag = False
    End Sub

End Module
