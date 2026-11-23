Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeesWithValue

    Private Sub frmEmployeesWithValue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT EmployeeMaster.EmployeeNo AS [Employee No], " _
            & "EmployeeMaster.LastName +' '+ EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames " _
            & "AS [Given Names], EmployeeCodes.CodeNo AS [Code], " _
            & "CONVERT(NVARCHAR(EmployeeCodes.Amount AS DECIMAL(10,2)) AS [Amount] " _
            & "FROM EmployeeCodes WHERE EmployeeCodes.EmployeeNo = EmployeeMaster.EmployeeNo " _
            & "WHERE EmployeeCodes.CodeNo = " & intSelectedCode & " ORDER BY " _
            & "EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.OtherNames"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Employee Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmEmployeesWithValue_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 639 : Me.Height = 380
    End Sub
End Class