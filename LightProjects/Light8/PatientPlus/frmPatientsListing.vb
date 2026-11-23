Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPatientsListing
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub GetSelectedRecord()
        If dGrid.Rows.Count > 0 Then
            intSelectedPatient = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
            strSelectedPatientFullDetails = dGrid.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            SearchForItem(txtSearchString.Text)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0

        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind

        Cursor = Cursors.WaitCursor

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        Select Case UCase(cboSearchBy.Text)
            Case Is = UCase("First Name")
                strSql = "SELECT UPPER(PatientId) AS [PN],  " _
                    & "UPPER(ISNULL(LastName, '')) +' '+ UPPER(ISNULL(FirstName, '')) +' '+ UPPER(ISNULL (OtherNames, '')) AS [Given Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(IdNumber) AS [ID No.] FROM OchmasPatients WHERE FirstName LIKE '%" & strFind & "%' " _
                    & "ORDER BY FirstName"
            Case Is = UCase("Last Name")
                strSql = "SELECT UPPER(PatientId) AS [PN], " _
                    & "UPPER(ISNULL(LastName, '')) +' '+ UPPER(ISNULL(FirstName, '')) +' '+ UPPER(ISNULL (OtherNames, '')) AS [Given Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(IdNumber) AS [ID No.] FROM OchmasPatients WHERE LastName LIKE '%" & strFind & "%' " _
                    & "ORDER BY LastName"
            Case Is = UCase("Patient Number")
                strSql = "SELECT UPPER(PatientId) AS [PN],  " _
                    & "UPPER(ISNULL(LastName, '')) +' '+ UPPER(ISNULL(FirstName, '')) +' '+ UPPER(ISNULL (OtherNames, '')) AS [Given Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(IdNumber) AS [ID No.] FROM OchmasPatients WHERE PatientId LIKE '%" & strFind & "%' " _
                    & "ORDER BY PatientId"
            Case Else
                strSql = "SELECT UPPER(PatientId) AS [PN], " _
                    & "UPPER(ISNULL(LastName, '')) +' '+ UPPER(ISNULL(FirstName, '')) +' '+ UPPER(ISNULL (OtherNames, '')) AS [Given Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(IdNumber) AS [ID No.] FROM OchmasPatients WHERE LastName LIKE '%" & strFind & "%' " _
                    & "ORDER BY LastName"
        End Select

        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Patients+ Patients search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmPatientsListing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        strSql = "SELECT UPPER(PatientId) AS [PN], UPPER(ISNULL(LastName, '')) +' '+ UPPER(ISNULL(FirstName, '')) +' '+ UPPER(ISNULL (OtherNames, '')) AS [Given Names], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) as [Birth Date], " _
            & "UPPER(Gender) AS [Gender], UPPER(IdNumber) AS [ID No.] FROM OchmasPatients " _
            & "ORDER BY LastName, FirstName, OtherNames"


        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Patient+ Patients search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        GetSelectedRecord()
        If intSelectedPatient = 0 Then
            MessageBox.Show("You have not selected any valid patient", "Invalid Patient Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            boolAbort = False
            Me.Close()
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        GetSelectedRecord()
        If intSelectedPatient = 0 Then
            MessageBox.Show("You have not selected any valid patient", "Invalid Patient Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class