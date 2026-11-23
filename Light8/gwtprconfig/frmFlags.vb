Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmFlags

    Private Sub frmFlags_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then LoadDetails()
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        txtDescription.Text = strSelectedDescription
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "FlagName, FlagValue FROM SystemFlagValues WHERE FlagNo " _
            & "= " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dgrid.Rows.Clear()
        If objReader.HasRows = True Then
            While objReader.Read
                dgrid.Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            End While
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on System Flags Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim i As Integer = 0
        'First update the main flag
        'Update the main flag values as well
        If boolEditStatus = True Then
            sqlCommand = New Data.OleDb.OleDbCommand("UPDATE SystemFlagNames SET " _
                & "FlagName = '" & txtDescription.Text & "' WHERE " _
                & "FlagNo = " & intSelectedTransaction & "", cnn)
            sqlCommand.ExecuteNonQuery()
        Else
            'Get the last record added for the flags
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT FlagNo FROM SystemFlagNames ORDER BY FlagNo DESC", cnn)
            Dim objReadCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objReadCount.HasRows Then
                objReadCount.Read()
                If IsNumeric(objReadCount(0).ToString) Then
                    intSelectedTransaction = CInt(objReadCount(0).ToString) + 1
                Else
                    intSelectedTransaction = 1
                End If
            Else
                intSelectedTransaction = 1
            End If
            objReadCount.Close()
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemFlagNames " _
                    & "(FlagName, FlagNo) VALUES ('" & txtDescription.Text & "', " _
                    & "" & intSelectedTransaction & ")", cnn)
            sqlCommand.ExecuteNonQuery()
        End If
        'Whether new or old, drop the current records in the table and fill with new values
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM " _
            & "SystemFlagValues WHERE FlagNo = " & intSelectedTransaction & "", cnn)
        sqlCommand.ExecuteNonQuery()
        For i = 0 To dgrid.Rows.Count - 1
            Dim strFlagName As String = Nothing
            Dim strFlagValue As String = Nothing
            Dim intFlagId As Integer = 0
            Dim strFlagId As String = "0"
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(1).Value), "")) Then
                strFlagName = Convert.ToString(dgrid.Rows(i).Cells(1).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(2).Value), "")) Then
                strFlagValue = Convert.ToString(dgrid.Rows(i).Cells(2).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(0).Value), "")) Then
                strFlagId = Convert.ToString(dgrid.Rows(i).Cells(0).Value)
            End If
            If IsNumeric(strFlagId) Then intFlagId = CInt(strFlagId) Else intFlagId = 0
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                & "SystemFlagValues (FlagNo, FlagValue, FlagName, " _
                & "OrdinalNo) VALUES (" & intSelectedTransaction & ", " _
                & "'" & strFlagValue & "', " _
                & "'" & strFlagName & "', " _
                & "" & intFlagId & ")", cnn)
            sqlCommand.ExecuteNonQuery()
        Next
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & "on System Flags Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOption.Click
        dgrid.Rows.Add(1)
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = dgrid.Rows.Count
    End Sub

    Private Sub btnDeleteOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOption.Click
        dgrid.Rows.RemoveAt(dgrid.CurrentRow.Index)
    End Sub

End Class
