Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectsListing

    Private Sub btnNewProject_Click(sender As System.Object, e As System.EventArgs) Handles btnNewProject.Click
        boolEditStatus = False
        intSelectedProjectNumber = 0
        Dim f As New frmProjectSetup ' frmProjectDetails
        f.ShowDialog()
        LoadData(Now, Now, "--- ALL ---")
    End Sub

    Private Sub LoadData(ByVal startDate As Date, ByVal EndDate As Date, ByVal ProjectOwner As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader 'UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken]
        If UCase(ProjectOwner) = "--- ALL ---" Then
            strSql = "SELECT ProjectsMain.ContractNumber AS [Proj.#], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken], " _
                & "ProjectsMain.ContractName AS [Contract Name], [Owner] AS [Owner], " _
                & "Customers.AccountName AS [Customer], CAST(ProjectsMain.InitialValue AS DECIMAL (30,2)) AS " _
                & "[Initial Value], CAST(ProjectsMain.RevisedValue AS DECIMAL (30,2)) AS [Revised Value] FROM " _
                & "ProjectsMain LEFT OUTER JOIN Customers ON Customers.AccountNumber = ProjectsMain.CustomerNumber"
        Else
            strSql = "SELECT ProjectsMain.ContractNumber AS [Proj.#], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken], " _
                & "ProjectsMain.ContractName AS [Contract Name], [Owner] AS [Owner], " _
                & "Customers.AccountName AS [Customer], CAST(ProjectsMain.InitialValue AS DECIMAL (30,2)) AS " _
                & "[Initial Value], CAST(ProjectsMain.RevisedValue AS DECIMAL (30,2)) AS [Revised Value] FROM " _
                & "ProjectsMain LEFT OUTER JOIN Customers ON Customers.AccountNumber = ProjectsMain.CustomerNumber " _
                & "WHERE ProjectsMain.TakeOnDate BETWEEN '" & startDate & "' AND '" & EndDate & "' AND ProjectsMain.Owner = '" & ProjectOwner & "'"
        End If

        dGridProjects.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridProjects.DataSource = dTable

        dGridProjects.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        For i As Integer = 0 To dGridProjects.Columns.Count - 1
            If i = 5 Or i = 6 Then
                dGridProjects.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridProjects.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On project details listing load"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub btnEditProject_Click(sender As System.Object, e As System.EventArgs) Handles btnEditProject.Click
        If dGridProjects.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProjects.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProjects.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedProjectNumber = CInt(dGridProjects.CurrentRow.Cells(0).Value.ToString)
                boolEditStatus = True
                Dim f As New frmProjectSetup
                f.ShowDialog()
                LoadData(Now, Now, "--- ALL ---")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On projects analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenses.Click
        Dim frm As New frmProjectExpenses
        frm.ShowDialog()
    End Sub

    Private Sub btnGoProjects_Click(sender As System.Object, e As System.EventArgs) Handles btnGoProjects.Click
        LoadData(dpStartFromProjects.Value, dpEndToProjects.Value, cboPersonnelProjects.Text)
    End Sub

    Private Sub dGridProjects_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridProjects.CellContentDoubleClick
        If dGridProjects.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProjects.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProjects.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedProjectNumber = CInt(dGridProjects.CurrentRow.Cells(0).Value.ToString)
                boolEditStatus = True

                If Not Object.Equals(dGridProjects.CurrentRow.Cells(4).Value, Nothing) Then
                    strCallingProjectCustomer = dGridProjects.CurrentRow.Cells(4).Value.ToString
                End If
                If Not Object.Equals(dGridProjects.CurrentRow.Cells(2).Value, Nothing) Then
                    strCallingProjectName = dGridProjects.CurrentRow.Cells(2).Value.ToString
                End If

                Dim f As New frmProjectSetup
                f.ShowDialog()

                strCallingProjectCustomer = Nothing
                strCallingProjectName = Nothing
                LoadData(Now, Now, "--- ALL ---")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On projects analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmProjectsListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadEmployees()
        LoadData(Now, Now, "--- ALL ---")
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData(Now, Now, "--- ALL ---")
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnelProjects.Items.Clear()
        cboPersonnelProjects.Items.Add("--- ALL ---")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnelProjects.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Personnel Details Load"
        ShowErrorMessage()
    End Sub

End Class