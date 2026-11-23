Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO

Public Class frmConsultationCodesListing

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        On Error GoTo RaiseErr
        Dim strLine As String = Nothing
        Dim strBuffer() As String
        Dim strFields() As String
        Dim strSql As String = Nothing
        If File.Exists(Application.StartupPath & "\Data\Consultations.txt") Then
            'Open the file for input
            Dim objReader = New StreamReader(Application.StartupPath & "\Data\Consultations.txt")
            Dim strWholeFile As String = objReader.ReadToEnd
            strBuffer = Split(strWholeFile, vbCrLf)
            Dim intRecordCount As Integer = strBuffer.Length + 10
            pb1.Value = 0 : pb1.Maximum = intRecordCount
            'First delete any records that may exist
            Dim myCommand = New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemConsultations", cnn)
            myCommand.ExecuteNonQuery()
            'iterate through the buffer string and insert into the table
            For i As Integer = 0 To strBuffer.Length - 2
                strLine = strBuffer(i)
                strFields = Split(strLine, "|")
                strSql = "INSERT INTO OchmasSystemConsultations (Code, Description, ConversionFactor, Units, BaseFactor, Value, Flag) VALUES " _
                    & "('" & strFields(0) & "', '" & strFields(1) & "', '" & strFields(2) & "', '" & strFields(3) & "', '" & strFields(4) & "', '" & strFields(5) & "', '" & strFields(6) & "')"
                myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                myCommand.ExecuteNonQuery()
                pb1.Value = pb1.Value + 1
            Next
            objReader.Close()
        Else
            MsgBox("The consultations file could not be located. Consultation details will not be loaded", MsgBoxStyle.Exclamation, "Missing Consultations File")
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Consultation Data Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmConsultationCodesListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadConsultationsData()
    End Sub

    Private Sub LoadConsultationsData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "Select Code AS [Code], Description, ConversionFactor AS [Con. Factor], Units, " _
            & "BaseFactor AS [Base Factor], Value, Flag FROM OchmasSystemConsultations ORDER BY Code"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        With dGrid
            .Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .Columns(1).Width = 300
        End With
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Consultation Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
