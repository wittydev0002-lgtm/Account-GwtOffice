Imports CommonLibrary.Commons

''' <summary>
''' All projects / sites of one client on a single screen, with the site details of each project.
''' </summary>
Public Class frmGtiClientProjects
    Inherits Form

    Private ReadOnly customerNumber As String
    Private ReadOnly customerName As String

    Private WithEvents grid As New DataGridView()
    Private WithEvents btnNew As New Button()
    Private WithEvents btnOpen As New Button()
    Private WithEvents btnSaveSite As New Button()
    Private WithEvents btnClose As New Button()
    Private lblClient As New Label()
    Private lblTotals As New Label()
    Private grpSite As New GroupBox()
    Private txtSiteName As New TextBox()
    Private txtSiteAddress As New TextBox()
    Private txtSiteContact As New TextBox()
    Private txtSitePhone As New TextBox()
    Private cboStatus As New ComboBox()
    Private loading As Boolean = False

    Public Sub New(ByVal accountNumber As String, ByVal accountName As String)
        customerNumber = accountNumber & ""
        customerName = accountName & ""

        Me.Text = "Client Projects / Sites"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.ClientSize = New Size(900, 590)
        Me.BackColor = Color.White

        lblClient.SetBounds(12, 10, 876, 24)
        lblClient.Font = New Font(Me.Font.FontFamily, 11.0F, FontStyle.Bold)
        lblClient.UseMnemonic = False   ' client names can contain "&"
        lblClient.Text = customerName & "   (account " & customerNumber & ")"
        Me.Controls.Add(lblClient)

        btnNew.SetBounds(12, 40, 130, 28) : btnNew.Text = "New project / site"
        btnOpen.SetBounds(148, 40, 130, 28) : btnOpen.Text = "Open project"
        Me.Controls.Add(btnNew) : Me.Controls.Add(btnOpen)

        With grid
            .SetBounds(12, 76, 876, 280)
            .AllowUserToAddRows = False : .AllowUserToDeleteRows = False : .AllowUserToResizeRows = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            .AutoGenerateColumns = True
        End With
        Me.Controls.Add(grid)

        lblTotals.SetBounds(12, 360, 876, 20)
        lblTotals.ForeColor = Color.DimGray
        Me.Controls.Add(lblTotals)

        grpSite.SetBounds(12, 386, 876, 158)
        grpSite.Text = "Site details of the selected project"
        Me.Controls.Add(grpSite)

        ' Each label is added directly before its box, so the tab order and screen-reader names are right.
        AddLabel("Site name", 14, 28)
        txtSiteName.SetBounds(110, 25, 320, 23) : txtSiteName.MaxLength = 200
        grpSite.Controls.Add(txtSiteName)
        AddLabel("Site address", 14, 58)
        txtSiteAddress.SetBounds(110, 55, 320, 88) : txtSiteAddress.Multiline = True : txtSiteAddress.MaxLength = 500
        txtSiteAddress.ScrollBars = ScrollBars.Vertical
        grpSite.Controls.Add(txtSiteAddress)
        AddLabel("Site contact", 460, 28)
        txtSiteContact.SetBounds(556, 25, 300, 23) : txtSiteContact.MaxLength = 150
        grpSite.Controls.Add(txtSiteContact)
        AddLabel("Contact phone", 460, 58)
        txtSitePhone.SetBounds(556, 55, 300, 23) : txtSitePhone.MaxLength = 70
        grpSite.Controls.Add(txtSitePhone)
        AddLabel("Status", 460, 88)
        cboStatus.SetBounds(556, 85, 160, 23)
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.Items.AddRange(New Object() {"Active", "On hold", "Completed"})
        grpSite.Controls.Add(cboStatus)
        btnSaveSite.SetBounds(726, 118, 130, 28) : btnSaveSite.Text = "Save site details"
        grpSite.Controls.Add(btnSaveSite)
        Dim tab As Integer = 0
        For Each c As Control In grpSite.Controls
            c.TabIndex = tab : tab += 1
        Next

        btnClose.SetBounds(798, 552, 90, 28) : btnClose.Text = "Close"
        Me.Controls.Add(btnClose)
        Me.CancelButton = btnClose
    End Sub

    Private Sub AddLabel(ByVal text As String, ByVal x As Integer, ByVal y As Integer)
        Dim label As New Label() With {.Text = text, .AutoSize = True}
        label.Location = New Point(x, y)
        grpSite.Controls.Add(label)
    End Sub

    Private Sub frmGtiClientProjects_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadProjects(0)
    End Sub

    Private Sub LoadProjects(ByVal selectProjectNumber As Integer)
        loading = True
        Try
            Dim table As DataTable = GtiTable("SELECT ContractNumber AS [Proj.#], ContractName AS [Project], SiteName AS [Site], " _
                & "ProjectStatus AS [Status], UPPER(REPLACE(CONVERT(CHAR(11), TakeOnDate, 106), ' ', '-')) AS [Start Date], " _
                & "CAST(InitialValue AS DECIMAL(30,2)) AS [Contract Value], CAST(RevisedValue AS DECIMAL(30,2)) AS [Revised Value], " _
                & "SiteAddress, SiteContact, SitePhone " _
                & "FROM ProjectsMain WHERE CustomerNumber = ? ORDER BY ContractNumber DESC", customerNumber)
            grid.DataSource = table

            grid.Columns("SiteAddress").Visible = False
            grid.Columns("SiteContact").Visible = False
            grid.Columns("SitePhone").Visible = False
            grid.Columns("Proj.#").Width = 60
            grid.Columns("Project").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            grid.Columns("Site").Width = 170
            grid.Columns("Status").Width = 80
            grid.Columns("Start Date").Width = 90
            For Each name As String In New String() {"Contract Value", "Revised Value"}
                grid.Columns(name).Width = 110
                grid.Columns(name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grid.Columns(name).DefaultCellStyle.Format = "N2"
            Next

            Dim totalValue As Decimal = 0
            Dim active As Integer = 0
            For Each row As DataRow In table.Rows
                Dim revised As Decimal = CDec(row("Revised Value"))
                totalValue += If(revised <> 0, revised, CDec(row("Contract Value")))
                If String.Equals(Convert.ToString(row("Status")), "Active", StringComparison.OrdinalIgnoreCase) Then active += 1
            Next
            lblTotals.Text = table.Rows.Count & " project(s), " & active & " active.   Total contract value: " & totalValue.ToString("N2")

            If selectProjectNumber > 0 Then
                For Each row As DataGridViewRow In grid.Rows
                    If CInt(row.Cells("Proj.#").Value) = selectProjectNumber Then
                        grid.CurrentCell = row.Cells("Proj.#")
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("The projects of this client could not be loaded." & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loading = False
        End Try
        ShowSelectedSite()
    End Sub

    Private Function SelectedProjectNumber() As Integer
        If grid.CurrentRow Is Nothing Then Return 0
        Dim value As Object = grid.CurrentRow.Cells("Proj.#").Value
        If value Is Nothing OrElse IsDBNull(value) Then Return 0
        Return CInt(value)
    End Function

    Private Sub ShowSelectedSite()
        Dim hasProject As Boolean = SelectedProjectNumber() > 0
        grpSite.Enabled = hasProject
        btnOpen.Enabled = hasProject
        If Not hasProject Then
            txtSiteName.Clear() : txtSiteAddress.Clear() : txtSiteContact.Clear() : txtSitePhone.Clear()
            cboStatus.SelectedIndex = -1
            Exit Sub
        End If
        Dim row As DataGridViewRow = grid.CurrentRow
        txtSiteName.Text = Convert.ToString(row.Cells("Site").Value)
        txtSiteAddress.Text = Convert.ToString(row.Cells("SiteAddress").Value)
        txtSiteContact.Text = Convert.ToString(row.Cells("SiteContact").Value)
        txtSitePhone.Text = Convert.ToString(row.Cells("SitePhone").Value)
        Dim status As String = Convert.ToString(row.Cells("Status").Value)
        If cboStatus.Items.IndexOf(status) < 0 Then status = "Active"
        cboStatus.SelectedItem = status
    End Sub

    Private Sub grid_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grid.SelectionChanged
        If loading Then Exit Sub
        ShowSelectedSite()
    End Sub

    Private Sub btnSaveSite_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveSite.Click
        Dim projectNumber As Integer = SelectedProjectNumber()
        If projectNumber <= 0 Then Exit Sub
        Try
            GtiExecute("UPDATE ProjectsMain SET SiteName = ?, SiteAddress = ?, SiteContact = ?, SitePhone = ?, ProjectStatus = ? WHERE ContractNumber = ?",
                Trim(txtSiteName.Text), Trim(txtSiteAddress.Text), Trim(txtSiteContact.Text), Trim(txtSitePhone.Text),
                Convert.ToString(cboStatus.SelectedItem), projectNumber)
            GtiLogActivity("ProjectsMain", "Site details updated for project " & projectNumber)
            LoadProjects(projectNumber)
        Catch ex As Exception
            MessageBox.Show("The site details could not be saved." & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
        Dim before As Object = GtiScalar("SELECT MAX(ContractNumber) FROM ProjectsMain WHERE CustomerNumber = ?", customerNumber)
        boolEditStatus = False
        intSelectedProjectNumber = 0
        GtiPresetProjectCustomerNumber = customerNumber
        GtiPresetProjectCustomerName = customerName
        Try
            Using f As New frmProjectSetup
                f.ShowDialog(Me)
            End Using
        Finally
            GtiPresetProjectCustomerNumber = Nothing
            GtiPresetProjectCustomerName = Nothing
        End Try
        Dim after As Object = GtiScalar("SELECT MAX(ContractNumber) FROM ProjectsMain WHERE CustomerNumber = ?", customerNumber)
        Dim newNumber As Integer = 0
        If after IsNot Nothing AndAlso Not IsDBNull(after) Then
            If before Is Nothing OrElse IsDBNull(before) OrElse CInt(after) <> CInt(before) Then newNumber = CInt(after)
        End If
        LoadProjects(newNumber)
    End Sub

    Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpen.Click
        OpenProject()
    End Sub

    Private Sub grid_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles grid.CellDoubleClick
        If e.RowIndex >= 0 Then OpenProject()
    End Sub

    Private Sub OpenProject()
        Dim projectNumber As Integer = SelectedProjectNumber()
        If projectNumber <= 0 Then Exit Sub
        intSelectedProjectNumber = projectNumber
        boolEditStatus = True
        Using f As New frmProjectSetup
            f.ShowDialog(Me)
        End Using
        LoadProjects(projectNumber)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
