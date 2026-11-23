Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMainOne

    Public Sub AddTabbedForm(ByVal frm As System.Windows.Forms.Form, ByVal TabColor As DevComponents.DotNetBar.eTabItemColor)
        'Iterate through the item tabs and make sure that the item has not be loaded before
        'If item already loaded then activate it instead
        Cursor = Cursors.WaitCursor

        Dim boolTabLoaded As Boolean = False
        For i As Integer = 0 To tabFinancialMain.Tabs.Count - 1
            If UCase(tabFinancialMain.Tabs.Item(i).Text) = UCase(frm.Text) Then
                boolTabLoaded = True
                tabFinancialMain.SelectedTabIndex = i
                Cursor = Cursors.Default
                Exit Sub
            End If
        Next

        If boolTabLoaded = False Then
            frm.TopLevel = False
            frm.Visible = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill

            Dim myTabPanel As New DevComponents.DotNetBar.SuperTabControlPanel 'TabControlPanel()
            Dim myTabItem As New DevComponents.DotNetBar.SuperTabItem 'TabItem()

            myTabItem.Text = frm.Text
            Me.tabFinancialMain.Controls.Add(myTabPanel)
            myTabItem.AttachedControl = myTabPanel
            tabFinancialMain.Tabs.Add(myTabItem)

            myTabPanel.Location = New System.Drawing.Point(0, 26)
            myTabPanel.Name = "TabControlPanel" & tabFinancialMain.Tabs.Count
            myTabPanel.Padding = New System.Windows.Forms.Padding(0)
            myTabPanel.Size = New System.Drawing.Size(616, 385)
            myTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            myTabPanel.Dock = System.Windows.Forms.DockStyle.Fill
            myTabPanel.TabItem = myTabItem
            myTabItem.PredefinedColor = TabColor ' DevComponents.DotNetBar.eTabItemColor.Purple
            myTabPanel.Controls.Add(frm)
            tabFinancialMain.SelectedTabIndex = tabFinancialMain.Tabs.Count - 1
            tabFinancialMain.Refresh()
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub frmMainOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.UserAuthentication()
        If boolAbort = True Then
            End
        End If
        tabFinancialMain.Tabs.Clear()
        Dim frm = New frmMocCasesListings
        AddTabbedForm(frm, DevComponents.DotNetBar.eTabItemColor.Default)
    End Sub

    Private Sub btnCases_Click(sender As System.Object, e As System.EventArgs) Handles btnCases.Click
        Dim frm = New frmMocCasesListings
        AddTabbedForm(frm, DevComponents.DotNetBar.eTabItemColor.Default)
    End Sub

    Private Sub btnReturns_Click(sender As System.Object, e As System.EventArgs) Handles btnReturns.Click
        Dim frm As New frmMocReturnsListings
        AddTabbedForm(frm, DevComponents.DotNetBar.eTabItemColor.Default)
    End Sub

    Private Sub btnAttachments_Click(sender As System.Object, e As System.EventArgs) Handles btnAttachments.Click
        Dim frm As New frmMocAttachmentsAndRemovals
        AddTabbedForm(frm, DevComponents.DotNetBar.eTabItemColor.Default)
    End Sub

    Private Sub btnBidders_Click(sender As System.Object, e As System.EventArgs) Handles btnBidders.Click
        Dim frm As New frmMocBiddersListing
        AddTabbedForm(frm, DevComponents.DotNetBar.eTabItemColor.Default)
    End Sub

End Class