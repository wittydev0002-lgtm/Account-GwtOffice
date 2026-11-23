Imports CommonLibrary.Commons

Public Class Form1

    '    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '        LoadData()
    '    End Sub

    '    Private Sub LoadData()
    '        On Error GoTo RaiseErr
    '        Dim strSql As String = Nothing
    '        strSql = "SELECT TOP 1000 Defendants.DefendantId as [Defendant #], Defendants.GivenNames as [Given Names], " _
    '                & "Defendants.FileId AS [File #], Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ " _
    '                & "Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
    '                & "CAST(SUM(DefendantTransactions.Debit) AS DECIMAL (10,2)) AS [Debit], " _
    '                & "CAST(SUM(DefendantTransactions.Credit) AS DECIMAL (10,2)) AS [Credit], " _
    '                & "CAST((SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS DECIMAL (10,2)) AS [Balance] " _
    '                & "FROM Defendants LEFT OUTER JOIN DefendantTransactions " _
    '                & "ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
    '                & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
    '                & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4"
    '        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
    '        cmd.CommandType = CommandType.Text

    '        Dim ds As DataSet = New DataSet
    '        Dim adapter As New OleDb.OleDbDataAdapter

    '        adapter.SelectCommand = New OleDb.OleDbCommand(strSql, cnn)
    '        adapter.Fill(ds)
    '        DataListView1.DataSource = ds.Tables(0)
    '        With DataListView1
    '            .Columns(.Columns.Count - 1).TextAlign = HorizontalAlignment.Right
    '            .Columns(.Columns.Count - 2).TextAlign = HorizontalAlignment.Right
    '            .Columns(.Columns.Count - 3).TextAlign = HorizontalAlignment.Right
    '            For p As Integer = 0 To .Columns.Count - 1
    '                .Columns(p).Width = -1
    '            Next
    '            .Columns(3).Width = 0
    '        End With
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Names Load"
    '        ShowErrorMessage()
    '    End Sub

    '    Private Sub DataListView1_DoubleClick(sender As Object, e As System.EventArgs)
    '        MsgBox("You have clicked " & DataListView1.SelectedItem.Text)
    '    End Sub

    '    Private Sub DataListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    '    End Sub
End Class