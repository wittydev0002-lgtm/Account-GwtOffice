<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOne
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cashbook Transactions", 5, 5)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bank Reconciliation Statement", 5, 5)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trial Balance", 5, 5)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ledger Transactions", 5, 5)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Profit and Loss Standard", 5, 5)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Balance Sheet", 5, 5)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cash Flow Statement", 5, 5)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction Detail by Account", 5, 5)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General Ledger Report", 5, 5)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Tax Liability", 5, 5)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction Detail by Tax Code", 5, 5)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("YTD Profit Compared to Last Year", 5, 5)
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Tax Collected Per Period", 5, 5)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Assets Depreciation Schedule", 5, 5)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ledger Account Balances", 5, 5)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Financial", 12, 12, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15})
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Balances", 5, 5)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A/R Aging Analysis", 5, 5)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Transaction History", 5, 5)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Open Invoiced By Due Date", 5, 5)
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Most Profitable Customers", 5, 5)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Statements", 5, 5)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Balances At Specified Date", 5, 5)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customers and Receivables", 9, 9, New System.Windows.Forms.TreeNode() {TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23})
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Creditors Transaction History", 5, 5)
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Today's Creditors Payments", 5, 5)
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Amounts Due to Creditors", 5, 5)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders", 5, 5)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendors/Creditors", 10, 10, New System.Windows.Forms.TreeNode() {TreeNode25, TreeNode26, TreeNode27, TreeNode28})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOne))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StyleManager2 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.splitMain = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.SuperTabControl3 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridLedgers = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Bar12 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem24 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem27 = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerCount = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem31 = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerDebits = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem34 = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerCredits = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem36 = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerMovement = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem38 = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerEndBalance = New DevComponents.DotNetBar.LabelItem()
        Me.Bar13 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem40 = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerPeriodStartBalance = New DevComponents.DotNetBar.LabelItem()
        Me.lblLedgerBFbalanceType = New DevComponents.DotNetBar.LabelItem()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.btnFindData = New DevComponents.DotNetBar.ButtonX()
        Me.dpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.tvAccounts = New System.Windows.Forms.TreeView()
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar11 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem21 = New DevComponents.DotNetBar.LabelItem()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem11 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem12 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem13 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem14 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpJvStartFrom = New System.Windows.Forms.DateTimePicker()
        Me.dpJvEndTo = New System.Windows.Forms.DateTimePicker()
        Me.btnFindJournals = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.btnNewJournal = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditJournal = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteJournal = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSeletedRowQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintQuoteList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshJournal = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel7 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Bar16 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel15 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel3 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.panelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.recentDocsItemPane = New DevComponents.DotNetBar.ItemPanel()
        Me.btnLedgerAccounts = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSpecialLedgers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOrganisation = New DevComponents.DotNetBar.ButtonItem()
        Me.labelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem3 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem4 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem8 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.KryptonDataGridView3 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel2.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        CType(Me.SuperTabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl3.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.dGridLedgers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        Me.expandablePanel1.SuspendLayout()
        CType(Me.Bar11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel7.SuspendLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel15.SuspendLayout()
        Me.SideNavPanel3.SuspendLayout()
        Me.panelEx1.SuspendLayout()
        CType(Me.KryptonDataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager2
        '
        Me.StyleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager2.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3})
        Me.Bar3.Location = New System.Drawing.Point(0, 678)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(1007, 20)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 8
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Stretch = True
        Me.LabelItem3.Text = "Great Wits Financial Light Edge 8.0"
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel7)
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Controls.Add(Me.SideNavPanel3)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem3, Me.SideNavItem2, Me.SideNavItem4, Me.SideNavItem8})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Margin = New System.Windows.Forms.Padding(0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1007, 678)
        Me.SideNav1.TabIndex = 9
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Controls.Add(Me.splitMain)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.SideNavPanel2.Controls.Add(Me.Bar11)
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(88, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Size = New System.Drawing.Size(918, 646)
        Me.SideNavPanel2.TabIndex = 6
        Me.SideNavPanel2.Visible = False
        '
        'splitMain
        '
        Me.splitMain.BackColor = System.Drawing.Color.White
        Me.splitMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Location = New System.Drawing.Point(0, 26)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.splitMain.Panel1.Controls.Add(Me.SuperTabControl3)
        Me.splitMain.Panel1.Controls.Add(Me.KryptonPanel4)
        Me.splitMain.Panel1.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.splitMain.Panel2.Controls.Add(Me.expandablePanel1)
        Me.splitMain.Panel2.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile
        Me.splitMain.Size = New System.Drawing.Size(918, 620)
        Me.splitMain.SplitterDistance = 694
        Me.splitMain.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.StateCommon.Separator.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.splitMain.StateCommon.Separator.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.splitMain.TabIndex = 8
        '
        'SuperTabControl3
        '
        Me.SuperTabControl3.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl3.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl3.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl3.ControlBox.Name = ""
        Me.SuperTabControl3.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl3.ControlBox.MenuBox, Me.SuperTabControl3.ControlBox.CloseBox})
        Me.SuperTabControl3.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl3.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl3.Location = New System.Drawing.Point(0, 57)
        Me.SuperTabControl3.Name = "SuperTabControl3"
        Me.SuperTabControl3.ReorderTabsEnabled = True
        Me.SuperTabControl3.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl3.SelectedTabIndex = 0
        Me.SuperTabControl3.Size = New System.Drawing.Size(694, 563)
        Me.SuperTabControl3.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl3.TabIndex = 12
        Me.SuperTabControl3.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2})
        Me.SuperTabControl3.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl3.Text = "SuperTabControl3"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.KryptonPanel5)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(694, 538)
        Me.SuperTabControlPanel2.TabIndex = 1
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.dGridLedgers)
        Me.KryptonPanel5.Controls.Add(Me.Bar12)
        Me.KryptonPanel5.Controls.Add(Me.Bar13)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.KryptonPanel5.Size = New System.Drawing.Size(694, 538)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel5.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel5.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel5.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel5.TabIndex = 1
        '
        'dGridLedgers
        '
        Me.dGridLedgers.AllowUserToAddRows = False
        Me.dGridLedgers.AllowUserToDeleteRows = False
        Me.dGridLedgers.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridLedgers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dGridLedgers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewImageColumn4})
        Me.dGridLedgers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridLedgers.Location = New System.Drawing.Point(1, 24)
        Me.dGridLedgers.Name = "dGridLedgers"
        Me.dGridLedgers.ReadOnly = True
        Me.dGridLedgers.RowHeadersWidth = 25
        Me.dGridLedgers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridLedgers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridLedgers.Size = New System.Drawing.Size(692, 486)
        Me.dGridLedgers.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridLedgers.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridLedgers.StateCommon.Background.ColorAngle = 100.0!
        Me.dGridLedgers.StateCommon.Background.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridLedgers.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridLedgers.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridLedgers.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridLedgers.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridLedgers.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridLedgers.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridLedgers.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridLedgers.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridLedgers.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridLedgers.TabIndex = 16
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn18.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 63
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn19.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn20.HeaderText = "Folio"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 62
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn21.HeaderText = "Contra Account"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 124
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn22.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn22.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 66
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn23.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn23.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 71
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn24.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewImageColumn4
        '
        Me.DataGridViewImageColumn4.HeaderText = ""
        Me.DataGridViewImageColumn4.Name = "DataGridViewImageColumn4"
        Me.DataGridViewImageColumn4.ReadOnly = True
        Me.DataGridViewImageColumn4.ToolTipText = "Reverse Transaction"
        Me.DataGridViewImageColumn4.Width = 25
        '
        'Bar12
        '
        Me.Bar12.AntiAlias = True
        Me.Bar12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar12.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar12.IsMaximized = False
        Me.Bar12.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem24, Me.LabelItem27, Me.lblLedgerCount, Me.LabelItem31, Me.lblLedgerDebits, Me.LabelItem34, Me.lblLedgerCredits, Me.LabelItem36, Me.lblLedgerMovement, Me.LabelItem38, Me.lblLedgerEndBalance})
        Me.Bar12.Location = New System.Drawing.Point(1, 510)
        Me.Bar12.Name = "Bar12"
        Me.Bar12.PaddingBottom = 3
        Me.Bar12.PaddingTop = 3
        Me.Bar12.Size = New System.Drawing.Size(692, 27)
        Me.Bar12.Stretch = True
        Me.Bar12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar12.TabIndex = 1
        Me.Bar12.TabStop = False
        Me.Bar12.Text = "Bar12"
        '
        'LabelItem24
        '
        Me.LabelItem24.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem24.Name = "LabelItem24"
        Me.LabelItem24.PaddingLeft = 3
        Me.LabelItem24.PaddingRight = 3
        Me.LabelItem24.Stretch = True
        '
        'LabelItem27
        '
        Me.LabelItem27.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem27.Name = "LabelItem27"
        Me.LabelItem27.PaddingLeft = 3
        Me.LabelItem27.PaddingRight = 3
        Me.LabelItem27.Text = "Count"
        '
        'lblLedgerCount
        '
        Me.lblLedgerCount.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblLedgerCount.Name = "lblLedgerCount"
        Me.lblLedgerCount.PaddingLeft = 3
        Me.lblLedgerCount.PaddingRight = 3
        Me.lblLedgerCount.Text = "0.00"
        Me.lblLedgerCount.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem31
        '
        Me.LabelItem31.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem31.Name = "LabelItem31"
        Me.LabelItem31.PaddingLeft = 3
        Me.LabelItem31.PaddingRight = 3
        Me.LabelItem31.Text = "Debits"
        Me.LabelItem31.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblLedgerDebits
        '
        Me.lblLedgerDebits.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblLedgerDebits.Name = "lblLedgerDebits"
        Me.lblLedgerDebits.PaddingLeft = 3
        Me.lblLedgerDebits.PaddingRight = 3
        Me.lblLedgerDebits.Text = "0.00"
        Me.lblLedgerDebits.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem34
        '
        Me.LabelItem34.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem34.Name = "LabelItem34"
        Me.LabelItem34.PaddingLeft = 3
        Me.LabelItem34.PaddingRight = 3
        Me.LabelItem34.Text = "Credits"
        Me.LabelItem34.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblLedgerCredits
        '
        Me.lblLedgerCredits.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblLedgerCredits.Name = "lblLedgerCredits"
        Me.lblLedgerCredits.PaddingLeft = 3
        Me.lblLedgerCredits.PaddingRight = 3
        Me.lblLedgerCredits.Text = "0.00"
        Me.lblLedgerCredits.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem36
        '
        Me.LabelItem36.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem36.Name = "LabelItem36"
        Me.LabelItem36.PaddingLeft = 3
        Me.LabelItem36.PaddingRight = 3
        Me.LabelItem36.Text = "Period Movement"
        Me.LabelItem36.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblLedgerMovement
        '
        Me.lblLedgerMovement.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblLedgerMovement.Name = "lblLedgerMovement"
        Me.lblLedgerMovement.PaddingLeft = 3
        Me.lblLedgerMovement.PaddingRight = 3
        Me.lblLedgerMovement.Text = "0.00"
        Me.lblLedgerMovement.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem38
        '
        Me.LabelItem38.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem38.Name = "LabelItem38"
        Me.LabelItem38.PaddingLeft = 3
        Me.LabelItem38.PaddingRight = 3
        Me.LabelItem38.Text = "Period End Balance"
        Me.LabelItem38.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblLedgerEndBalance
        '
        Me.lblLedgerEndBalance.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblLedgerEndBalance.Name = "lblLedgerEndBalance"
        Me.lblLedgerEndBalance.PaddingLeft = 3
        Me.lblLedgerEndBalance.PaddingRight = 3
        Me.lblLedgerEndBalance.Text = "0.00"
        Me.lblLedgerEndBalance.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Bar13
        '
        Me.Bar13.AntiAlias = True
        Me.Bar13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar13.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar13.IsMaximized = False
        Me.Bar13.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem40, Me.lblLedgerPeriodStartBalance, Me.lblLedgerBFbalanceType})
        Me.Bar13.Location = New System.Drawing.Point(1, 1)
        Me.Bar13.Name = "Bar13"
        Me.Bar13.Size = New System.Drawing.Size(692, 23)
        Me.Bar13.Stretch = True
        Me.Bar13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar13.TabIndex = 0
        Me.Bar13.TabStop = False
        Me.Bar13.Text = "Bar13"
        '
        'LabelItem40
        '
        Me.LabelItem40.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.LabelItem40.Name = "LabelItem40"
        Me.LabelItem40.PaddingLeft = 3
        Me.LabelItem40.PaddingRight = 3
        Me.LabelItem40.Stretch = True
        Me.LabelItem40.Text = "Balance brought forward"
        '
        'lblLedgerPeriodStartBalance
        '
        Me.lblLedgerPeriodStartBalance.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.lblLedgerPeriodStartBalance.Name = "lblLedgerPeriodStartBalance"
        Me.lblLedgerPeriodStartBalance.PaddingLeft = 3
        Me.lblLedgerPeriodStartBalance.PaddingRight = 3
        Me.lblLedgerPeriodStartBalance.Text = "0.00"
        Me.lblLedgerPeriodStartBalance.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblLedgerPeriodStartBalance.Width = 100
        '
        'lblLedgerBFbalanceType
        '
        Me.lblLedgerBFbalanceType.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.lblLedgerBFbalanceType.Name = "lblLedgerBFbalanceType"
        Me.lblLedgerBFbalanceType.PaddingLeft = 3
        Me.lblLedgerBFbalanceType.PaddingRight = 3
        Me.lblLedgerBFbalanceType.Text = "DR"
        Me.lblLedgerBFbalanceType.Width = 45
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        Me.SuperTabItem2.Text = "Transactions"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.lblAccountName)
        Me.KryptonPanel4.Controls.Add(Me.btnFindData)
        Me.KryptonPanel4.Controls.Add(Me.dpEndDate)
        Me.KryptonPanel4.Controls.Add(Me.dpStartDate)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(694, 57)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel4.StateCommon.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonPanel4.TabIndex = 11
        '
        'lblAccountName
        '
        Me.lblAccountName.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAccountName.ForeColor = System.Drawing.Color.Black
        Me.lblAccountName.Location = New System.Drawing.Point(437, 18)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(235, 22)
        Me.lblAccountName.TabIndex = 169
        Me.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFindData
        '
        Me.btnFindData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFindData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFindData.Image = CType(resources.GetObject("btnFindData.Image"), System.Drawing.Image)
        Me.btnFindData.Location = New System.Drawing.Point(356, 17)
        Me.btnFindData.Name = "btnFindData"
        Me.btnFindData.Size = New System.Drawing.Size(75, 23)
        Me.btnFindData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFindData.TabIndex = 168
        Me.btnFindData.Text = "Process ..."
        '
        'dpEndDate
        '
        Me.dpEndDate.BackColor = System.Drawing.Color.White
        Me.dpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndDate.Location = New System.Drawing.Point(248, 18)
        Me.dpEndDate.Name = "dpEndDate"
        Me.dpEndDate.Size = New System.Drawing.Size(96, 22)
        Me.dpEndDate.TabIndex = 162
        '
        'dpStartDate
        '
        Me.dpStartDate.BackColor = System.Drawing.Color.White
        Me.dpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartDate.Location = New System.Drawing.Point(81, 17)
        Me.dpStartDate.Name = "dpStartDate"
        Me.dpStartDate.Size = New System.Drawing.Size(99, 22)
        Me.dpStartDate.TabIndex = 163
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(193, 20)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(54, 20)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 165
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(54, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(54, 20)
        Me.KryptonLabel3.TabIndex = 0
        Me.KryptonLabel3.Values.Text = "Date to"
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel7.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(14, 19)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(66, 20)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel7.TabIndex = 164
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.White
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(66, 20)
        Me.KryptonLabel6.TabIndex = 0
        Me.KryptonLabel6.Values.Text = "Date from"
        '
        'expandablePanel1
        '
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.tvAccounts)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(219, 620)
        Me.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.expandablePanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.Style.GradientAngle = 90
        Me.expandablePanel1.TabIndex = 7
        Me.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.TitleStyle.GradientAngle = 90
        Me.expandablePanel1.TitleStyle.MarginLeft = 6
        Me.expandablePanel1.TitleText = "Chart of Accounts"
        '
        'tvAccounts
        '
        Me.tvAccounts.BackColor = System.Drawing.Color.White
        Me.tvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvAccounts.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvAccounts.ForeColor = System.Drawing.Color.Black
        Me.tvAccounts.FullRowSelect = True
        Me.tvAccounts.ImageIndex = 0
        Me.tvAccounts.ImageList = Me.imageList2
        Me.tvAccounts.Location = New System.Drawing.Point(0, 26)
        Me.tvAccounts.Name = "tvAccounts"
        Me.tvAccounts.SelectedImageIndex = 1
        Me.tvAccounts.Size = New System.Drawing.Size(219, 594)
        Me.tvAccounts.TabIndex = 4
        '
        'imageList2
        '
        Me.imageList2.ImageStream = CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList2.Images.SetKeyName(0, "Comments_Small.png")
        Me.imageList2.Images.SetKeyName(1, "AddNewSource_Small.png")
        Me.imageList2.Images.SetKeyName(2, "Folder.ico")
        Me.imageList2.Images.SetKeyName(3, "user2.png")
        Me.imageList2.Images.SetKeyName(4, "calendar.png")
        Me.imageList2.Images.SetKeyName(5, "dude1.png")
        Me.imageList2.Images.SetKeyName(6, "businessman2.png")
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(918, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'Bar11
        '
        Me.Bar11.AntiAlias = True
        Me.Bar11.BackColor = System.Drawing.Color.Transparent
        Me.Bar11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar11.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar11.IsMaximized = False
        Me.Bar11.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem17, Me.LabelItem21})
        Me.Bar11.Location = New System.Drawing.Point(0, 0)
        Me.Bar11.Name = "Bar11"
        Me.Bar11.RoundCorners = False
        Me.Bar11.Size = New System.Drawing.Size(918, 25)
        Me.Bar11.Stretch = True
        Me.Bar11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar11.TabIndex = 6
        Me.Bar11.TabStop = False
        Me.Bar11.Text = "Bar11"
        '
        'ButtonItem17
        '
        Me.ButtonItem17.BeginGroup = True
        Me.ButtonItem17.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem17.Image = CType(resources.GetObject("ButtonItem17.Image"), System.Drawing.Image)
        Me.ButtonItem17.Name = "ButtonItem17"
        Me.ButtonItem17.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem17.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem3})
        Me.ButtonItem17.Text = "Print"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.BeginGroup = True
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem2.Text = "Selected Account"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.BeginGroup = True
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem3.Text = "All Accounts"
        '
        'LabelItem21
        '
        Me.LabelItem21.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem21.Name = "LabelItem21"
        Me.LabelItem21.Stretch = True
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.dGrid)
        Me.SideNavPanel1.Controls.Add(Me.Bar1)
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel8)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.SideNavPanel1.Controls.Add(Me.Bar5)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(88, 31)
        Me.SideNavPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Size = New System.Drawing.Size(918, 646)
        Me.SideNavPanel1.TabIndex = 2
        Me.SideNavPanel1.Visible = False
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.DataGridViewTextBoxColumn5, Me.Column3, Me.Column4, Me.Column5})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 91)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(918, 528)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 157
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Date"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 63
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Journal No."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Amount"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Key"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Delete"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 54
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.LabelItem4, Me.LabelItem5, Me.LabelItem6, Me.LabelItem7, Me.LabelItem8, Me.LabelItem9, Me.LabelItem11, Me.LabelItem12, Me.LabelItem13, Me.LabelItem14})
        Me.Bar1.Location = New System.Drawing.Point(0, 619)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.Size = New System.Drawing.Size(918, 27)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 156
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem2
        '
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 3
        Me.LabelItem2.PaddingRight = 3
        Me.LabelItem2.Stretch = True
        '
        'LabelItem4
        '
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 3
        Me.LabelItem4.PaddingRight = 3
        Me.LabelItem4.Text = "Count"
        '
        'LabelItem5
        '
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingLeft = 3
        Me.LabelItem5.PaddingRight = 3
        Me.LabelItem5.Text = "0.00"
        Me.LabelItem5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem6
        '
        Me.LabelItem6.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingLeft = 3
        Me.LabelItem6.PaddingRight = 3
        Me.LabelItem6.Text = "Debits"
        Me.LabelItem6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem7
        '
        Me.LabelItem7.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.PaddingLeft = 3
        Me.LabelItem7.PaddingRight = 3
        Me.LabelItem7.Text = "0.00"
        Me.LabelItem7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem8
        '
        Me.LabelItem8.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingLeft = 3
        Me.LabelItem8.PaddingRight = 3
        Me.LabelItem8.Text = "Credits"
        Me.LabelItem8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem9
        '
        Me.LabelItem9.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem9.Name = "LabelItem9"
        Me.LabelItem9.PaddingLeft = 3
        Me.LabelItem9.PaddingRight = 3
        Me.LabelItem9.Text = "0.00"
        Me.LabelItem9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem11
        '
        Me.LabelItem11.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem11.Name = "LabelItem11"
        Me.LabelItem11.PaddingLeft = 3
        Me.LabelItem11.PaddingRight = 3
        Me.LabelItem11.Text = "Period Movement"
        Me.LabelItem11.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem12
        '
        Me.LabelItem12.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem12.Name = "LabelItem12"
        Me.LabelItem12.PaddingLeft = 3
        Me.LabelItem12.PaddingRight = 3
        Me.LabelItem12.Text = "0.00"
        Me.LabelItem12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem13
        '
        Me.LabelItem13.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem13.Name = "LabelItem13"
        Me.LabelItem13.PaddingLeft = 3
        Me.LabelItem13.PaddingRight = 3
        Me.LabelItem13.Text = "Period End Balance"
        Me.LabelItem13.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem14
        '
        Me.LabelItem14.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem14.Name = "LabelItem14"
        Me.LabelItem14.PaddingLeft = 3
        Me.LabelItem14.PaddingRight = 3
        Me.LabelItem14.Text = "0.00"
        Me.LabelItem14.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel8.Controls.Add(Me.dpJvStartFrom)
        Me.KryptonPanel8.Controls.Add(Me.dpJvEndTo)
        Me.KryptonPanel8.Controls.Add(Me.btnFindJournals)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel12)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(0, 31)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(918, 60)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel8.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel8.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel8.TabIndex = 155
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 59)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(918, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'dpJvStartFrom
        '
        Me.dpJvStartFrom.BackColor = System.Drawing.Color.White
        Me.dpJvStartFrom.ForeColor = System.Drawing.Color.Black
        Me.dpJvStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpJvStartFrom.Location = New System.Drawing.Point(92, 19)
        Me.dpJvStartFrom.Name = "dpJvStartFrom"
        Me.dpJvStartFrom.Size = New System.Drawing.Size(99, 22)
        Me.dpJvStartFrom.TabIndex = 10
        '
        'dpJvEndTo
        '
        Me.dpJvEndTo.BackColor = System.Drawing.Color.White
        Me.dpJvEndTo.ForeColor = System.Drawing.Color.Black
        Me.dpJvEndTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpJvEndTo.Location = New System.Drawing.Point(294, 19)
        Me.dpJvEndTo.Name = "dpJvEndTo"
        Me.dpJvEndTo.Size = New System.Drawing.Size(95, 22)
        Me.dpJvEndTo.TabIndex = 5
        '
        'btnFindJournals
        '
        Me.btnFindJournals.AutoSize = True
        Me.btnFindJournals.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFindJournals.BackColor = System.Drawing.Color.White
        Me.btnFindJournals.ForeColor = System.Drawing.Color.Black
        Me.btnFindJournals.Location = New System.Drawing.Point(395, 19)
        Me.btnFindJournals.Name = "btnFindJournals"
        Me.btnFindJournals.Size = New System.Drawing.Size(41, 22)
        Me.btnFindJournals.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnFindJournals.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFindJournals.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFindJournals.StateCommon.Border.Rounding = 0
        Me.btnFindJournals.TabIndex = 146
        Me.btnFindJournals.Values.Image = CType(resources.GetObject("btnFindJournals.Values.Image"), System.Drawing.Image)
        Me.btnFindJournals.Values.Text = "&Go"
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(218, 20)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(74, 21)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 145
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(74, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Date to"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(74, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(17, 20)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(74, 21)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel12.TabIndex = 144
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.White
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(74, 20)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Date from"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(74, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 30)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(918, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.BackColor = System.Drawing.Color.Transparent
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewJournal, Me.btnEditJournal, Me.btnDeleteJournal, Me.ButtonItem4, Me.btnRefreshJournal})
        Me.Bar5.Location = New System.Drawing.Point(0, 1)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(918, 29)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 153
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnNewJournal
        '
        Me.btnNewJournal.Image = CType(resources.GetObject("btnNewJournal.Image"), System.Drawing.Image)
        Me.btnNewJournal.Name = "btnNewJournal"
        Me.btnNewJournal.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewJournal.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewJournal.Text = "New"
        '
        'btnEditJournal
        '
        Me.btnEditJournal.Image = CType(resources.GetObject("btnEditJournal.Image"), System.Drawing.Image)
        Me.btnEditJournal.Name = "btnEditJournal"
        Me.btnEditJournal.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditJournal.Text = "Edit"
        '
        'btnDeleteJournal
        '
        Me.btnDeleteJournal.BeginGroup = True
        Me.btnDeleteJournal.Image = CType(resources.GetObject("btnDeleteJournal.Image"), System.Drawing.Image)
        Me.btnDeleteJournal.Name = "btnDeleteJournal"
        Me.btnDeleteJournal.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteJournal.Text = "Delete"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.BeginGroup = True
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSeletedRowQuote, Me.btnPrintQuoteList})
        Me.ButtonItem4.Text = "Print"
        '
        'btnPrintSeletedRowQuote
        '
        Me.btnPrintSeletedRowQuote.BeginGroup = True
        Me.btnPrintSeletedRowQuote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSeletedRowQuote.Name = "btnPrintSeletedRowQuote"
        Me.btnPrintSeletedRowQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSeletedRowQuote.SymbolSize = 16.0!
        Me.btnPrintSeletedRowQuote.Text = "Print Selected Journal"
        '
        'btnPrintQuoteList
        '
        Me.btnPrintQuoteList.BeginGroup = True
        Me.btnPrintQuoteList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintQuoteList.Name = "btnPrintQuoteList"
        Me.btnPrintQuoteList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintQuoteList.SymbolSize = 16.0!
        Me.btnPrintQuoteList.Text = "Print Journal Listing"
        '
        'btnRefreshJournal
        '
        Me.btnRefreshJournal.BeginGroup = True
        Me.btnRefreshJournal.Image = CType(resources.GetObject("btnRefreshJournal.Image"), System.Drawing.Image)
        Me.btnRefreshJournal.Name = "btnRefreshJournal"
        Me.btnRefreshJournal.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshJournal.Text = "Refresh"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(918, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'SideNavPanel7
        '
        Me.SideNavPanel7.Controls.Add(Me.KryptonPanel16)
        Me.SideNavPanel7.Controls.Add(Me.KryptonPanel15)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge25)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge24)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge23)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge14)
        Me.SideNavPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel7.Location = New System.Drawing.Point(88, 31)
        Me.SideNavPanel7.Name = "SideNavPanel7"
        Me.SideNavPanel7.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel7.Size = New System.Drawing.Size(918, 646)
        Me.SideNavPanel7.TabIndex = 32
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel16.Controls.Add(Me.Bar16)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge26)
        Me.KryptonPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel16.Location = New System.Drawing.Point(258, 13)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Size = New System.Drawing.Size(647, 620)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel16.TabIndex = 33
        '
        'Bar16
        '
        Me.Bar16.AccessibleDescription = "Bar16 (Bar16)"
        Me.Bar16.AccessibleName = "Bar16"
        Me.Bar16.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar16.AntiAlias = True
        Me.Bar16.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar16.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar16.IsMaximized = False
        Me.Bar16.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem10})
        Me.Bar16.Location = New System.Drawing.Point(1, 0)
        Me.Bar16.Name = "Bar16"
        Me.Bar16.PaddingBottom = 3
        Me.Bar16.PaddingLeft = 3
        Me.Bar16.PaddingRight = 3
        Me.Bar16.PaddingTop = 3
        Me.Bar16.RoundCorners = False
        Me.Bar16.Size = New System.Drawing.Size(646, 24)
        Me.Bar16.Stretch = True
        Me.Bar16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar16.TabIndex = 1
        Me.Bar16.TabStop = False
        Me.Bar16.Text = "Bar16"
        '
        'LabelItem10
        '
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.Text = "Report Sample"
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'KryptonPanel15
        '
        Me.KryptonPanel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel15.Controls.Add(Me.tvReports)
        Me.KryptonPanel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel15.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel15.Location = New System.Drawing.Point(13, 13)
        Me.KryptonPanel15.Name = "KryptonPanel15"
        Me.KryptonPanel15.Size = New System.Drawing.Size(245, 620)
        Me.KryptonPanel15.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel15.TabIndex = 32
        '
        'tvReports
        '
        Me.tvReports.BackColor = System.Drawing.Color.White
        Me.tvReports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReports.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvReports.ForeColor = System.Drawing.Color.Black
        Me.tvReports.HideSelection = False
        Me.tvReports.ImageIndex = 0
        Me.tvReports.ImageList = Me.imageList1
        Me.tvReports.Location = New System.Drawing.Point(0, 0)
        Me.tvReports.Name = "tvReports"
        TreeNode1.ImageIndex = 5
        TreeNode1.Name = "Node28"
        TreeNode1.SelectedImageIndex = 5
        TreeNode1.Text = "Cashbook Transactions"
        TreeNode2.ImageIndex = 5
        TreeNode2.Name = "Node26"
        TreeNode2.SelectedImageIndex = 5
        TreeNode2.Text = "Bank Reconciliation Statement"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "PHC"
        TreeNode3.SelectedImageIndex = 5
        TreeNode3.Text = "Trial Balance"
        TreeNode4.ImageIndex = 5
        TreeNode4.Name = "Node0"
        TreeNode4.SelectedImageIndex = 5
        TreeNode4.Text = "Ledger Transactions"
        TreeNode5.ImageIndex = 5
        TreeNode5.Name = "Node11"
        TreeNode5.SelectedImageIndex = 5
        TreeNode5.Text = "Profit and Loss Standard"
        TreeNode6.ImageIndex = 5
        TreeNode6.Name = "OHS"
        TreeNode6.SelectedImageIndex = 5
        TreeNode6.Text = "Balance Sheet"
        TreeNode7.ImageIndex = 5
        TreeNode7.Name = "IOD"
        TreeNode7.SelectedImageIndex = 5
        TreeNode7.Text = "Cash Flow Statement"
        TreeNode8.ImageIndex = 5
        TreeNode8.Name = "CDM"
        TreeNode8.SelectedImageIndex = 5
        TreeNode8.Text = "Transaction Detail by Account"
        TreeNode9.ImageIndex = 5
        TreeNode9.Name = "TBM"
        TreeNode9.SelectedImageIndex = 5
        TreeNode9.Text = "General Ledger Report"
        TreeNode10.ImageIndex = 5
        TreeNode10.Name = "HIVM"
        TreeNode10.SelectedImageIndex = 5
        TreeNode10.Text = "Sales Tax Liability"
        TreeNode11.ImageIndex = 5
        TreeNode11.Name = "MS"
        TreeNode11.SelectedImageIndex = 5
        TreeNode11.Text = "Transaction Detail by Tax Code"
        TreeNode12.ImageIndex = 5
        TreeNode12.Name = "DSM"
        TreeNode12.SelectedImageIndex = 5
        TreeNode12.Text = "YTD Profit Compared to Last Year"
        TreeNode13.ImageIndex = 5
        TreeNode13.Name = "ABSM"
        TreeNode13.SelectedImageIndex = 5
        TreeNode13.Text = "Sales Tax Collected Per Period"
        TreeNode14.ImageIndex = 5
        TreeNode14.Name = "Node27"
        TreeNode14.SelectedImageIndex = 5
        TreeNode14.Text = "Assets Depreciation Schedule"
        TreeNode15.ImageIndex = 5
        TreeNode15.Name = "Node0"
        TreeNode15.SelectedImageIndex = 5
        TreeNode15.Text = "Ledger Account Balances"
        TreeNode16.ImageIndex = 12
        TreeNode16.Name = "NodeEmployees"
        TreeNode16.SelectedImageIndex = 12
        TreeNode16.Text = "Financial"
        TreeNode17.ImageIndex = 5
        TreeNode17.Name = "Node0"
        TreeNode17.SelectedImageIndex = 5
        TreeNode17.Text = "Customer Balances"
        TreeNode18.ImageIndex = 5
        TreeNode18.Name = "Node12"
        TreeNode18.SelectedImageIndex = 5
        TreeNode18.Text = "A/R Aging Analysis"
        TreeNode19.ImageIndex = 5
        TreeNode19.Name = "Node13"
        TreeNode19.SelectedImageIndex = 5
        TreeNode19.Text = "Customer Transaction History"
        TreeNode20.ImageIndex = 5
        TreeNode20.Name = "Node14"
        TreeNode20.SelectedImageIndex = 5
        TreeNode20.Text = "Open Invoiced By Due Date"
        TreeNode21.ImageIndex = 5
        TreeNode21.Name = "Node15"
        TreeNode21.SelectedImageIndex = 5
        TreeNode21.Text = "Most Profitable Customers"
        TreeNode22.ImageIndex = 5
        TreeNode22.Name = "Node29"
        TreeNode22.SelectedImageIndex = 5
        TreeNode22.Text = "Customer Statements"
        TreeNode23.ImageIndex = 5
        TreeNode23.Name = "Node0"
        TreeNode23.SelectedImageIndex = 5
        TreeNode23.Text = "Customer Balances At Specified Date"
        TreeNode24.ImageIndex = 9
        TreeNode24.Name = "Node1"
        TreeNode24.SelectedImageIndex = 9
        TreeNode24.Text = "Customers and Receivables"
        TreeNode25.ImageIndex = 5
        TreeNode25.Name = "Node17"
        TreeNode25.SelectedImageIndex = 5
        TreeNode25.Text = "Creditors Transaction History"
        TreeNode26.ImageIndex = 5
        TreeNode26.Name = "Node18"
        TreeNode26.SelectedImageIndex = 5
        TreeNode26.Text = "Today's Creditors Payments"
        TreeNode27.ImageIndex = 5
        TreeNode27.Name = "Node19"
        TreeNode27.SelectedImageIndex = 5
        TreeNode27.Text = "Amounts Due to Creditors"
        TreeNode28.ImageIndex = 5
        TreeNode28.Name = "Node20"
        TreeNode28.SelectedImageIndex = 5
        TreeNode28.Text = "Orders"
        TreeNode29.ImageIndex = 10
        TreeNode29.Name = "Node2"
        TreeNode29.SelectedImageIndex = 10
        TreeNode29.Text = "Vendors/Creditors"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode16, TreeNode24, TreeNode29})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(245, 620)
        Me.tvReports.TabIndex = 33
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "Folder.ico")
        Me.imageList1.Images.SetKeyName(1, "calendar.png")
        Me.imageList1.Images.SetKeyName(2, "user2.png")
        Me.imageList1.Images.SetKeyName(3, "dude1.png")
        Me.imageList1.Images.SetKeyName(4, "businessman2.png")
        Me.imageList1.Images.SetKeyName(5, "TableSmall.png")
        Me.imageList1.Images.SetKeyName(6, "Delivery.png")
        Me.imageList1.Images.SetKeyName(7, "Money.png")
        Me.imageList1.Images.SetKeyName(8, "49.png")
        Me.imageList1.Images.SetKeyName(9, "07.png")
        Me.imageList1.Images.SetKeyName(10, "10.png")
        Me.imageList1.Images.SetKeyName(11, "25.png")
        Me.imageList1.Images.SetKeyName(12, "133.png")
        Me.imageList1.Images.SetKeyName(13, "Search.bmp")
        Me.imageList1.Images.SetKeyName(14, "420.png")
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(905, 13)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(12, 13)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(12, 633)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(894, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(12, 12)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(894, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'SideNavPanel3
        '
        Me.SideNavPanel3.Controls.Add(Me.panelEx1)
        Me.SideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel3.Location = New System.Drawing.Point(88, 31)
        Me.SideNavPanel3.Name = "SideNavPanel3"
        Me.SideNavPanel3.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel3.Size = New System.Drawing.Size(918, 646)
        Me.SideNavPanel3.TabIndex = 10
        Me.SideNavPanel3.Visible = False
        '
        'panelEx1
        '
        Me.panelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.panelEx1.Controls.Add(Me.recentDocsItemPane)
        Me.panelEx1.Controls.Add(Me.labelX1)
        Me.panelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.panelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelEx1.Location = New System.Drawing.Point(12, 12)
        Me.panelEx1.Name = "panelEx1"
        Me.panelEx1.Padding = New System.Windows.Forms.Padding(12)
        Me.panelEx1.Size = New System.Drawing.Size(458, 622)
        Me.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.panelEx1.Style.GradientAngle = 90
        Me.panelEx1.TabIndex = 12
        Me.panelEx1.Text = "panelEx1"
        '
        'recentDocsItemPane
        '
        Me.recentDocsItemPane.AutoScroll = True
        '
        '
        '
        Me.recentDocsItemPane.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.recentDocsItemPane.ContainerControlProcessDialogKey = True
        Me.recentDocsItemPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.recentDocsItemPane.DragDropSupport = True
        Me.recentDocsItemPane.ForeColor = System.Drawing.Color.Black
        Me.recentDocsItemPane.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnLedgerAccounts, Me.btnSpecialLedgers, Me.btnOrganisation})
        Me.recentDocsItemPane.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.recentDocsItemPane.Location = New System.Drawing.Point(12, 35)
        Me.recentDocsItemPane.Name = "recentDocsItemPane"
        Me.recentDocsItemPane.Size = New System.Drawing.Size(434, 575)
        Me.recentDocsItemPane.TabIndex = 1
        '
        'btnLedgerAccounts
        '
        Me.btnLedgerAccounts.BeginGroup = True
        Me.btnLedgerAccounts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnLedgerAccounts.ForeColor = System.Drawing.Color.Black
        Me.btnLedgerAccounts.Name = "btnLedgerAccounts"
        Me.btnLedgerAccounts.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnLedgerAccounts.Symbol = "58341"
        Me.btnLedgerAccounts.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnLedgerAccounts.Text = "Ledger Accounts<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">View, create and maintain ledger account" & _
    "s</font>"
        '
        'btnSpecialLedgers
        '
        Me.btnSpecialLedgers.BeginGroup = True
        Me.btnSpecialLedgers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSpecialLedgers.ForeColor = System.Drawing.Color.Black
        Me.btnSpecialLedgers.Name = "btnSpecialLedgers"
        Me.btnSpecialLedgers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSpecialLedgers.Symbol = "57519"
        Me.btnSpecialLedgers.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSpecialLedgers.Text = "Special Ledger Accounts<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Define ledger accounts used by t" & _
    "he system <br/>e.g. Sales Control Account, Debtors Control Account, etc</font>"
        '
        'btnOrganisation
        '
        Me.btnOrganisation.BeginGroup = True
        Me.btnOrganisation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOrganisation.CommandParameter = ""
        Me.btnOrganisation.ForeColor = System.Drawing.Color.Black
        Me.btnOrganisation.Name = "btnOrganisation"
        Me.btnOrganisation.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnOrganisation.Symbol = ""
        Me.btnOrganisation.Text = "Organization Settings<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">View and edit organisation paramet" & _
    "ers applicable to the environment</font>"
        '
        'labelX1
        '
        '
        '
        '
        Me.labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash
        Me.labelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gray
        Me.labelX1.BackgroundStyle.BorderBottomWidth = 1
        Me.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX1.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelX1.ForeColor = System.Drawing.Color.Black
        Me.labelX1.Location = New System.Drawing.Point(12, 12)
        Me.labelX1.Name = "labelX1"
        Me.labelX1.Size = New System.Drawing.Size(434, 23)
        Me.labelX1.TabIndex = 0
        Me.labelX1.Text = "General Settings"
        '
        'SideNavItem1
        '
        Me.SideNavItem1.IsSystemMenu = True
        Me.SideNavItem1.Name = "SideNavItem1"
        Me.SideNavItem1.Symbol = ""
        Me.SideNavItem1.Text = "Menu"
        '
        'Separator1
        '
        Me.Separator1.FixedSize = New System.Drawing.Size(3, 1)
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Padding.Bottom = 2
        Me.Separator1.Padding.Left = 6
        Me.Separator1.Padding.Right = 6
        Me.Separator1.Padding.Top = 2
        Me.Separator1.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical
        '
        'SideNavItem3
        '
        Me.SideNavItem3.Name = "SideNavItem3"
        Me.SideNavItem3.Panel = Me.SideNavPanel2
        Me.SideNavItem3.Symbol = "58397"
        Me.SideNavItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem3.Text = "Ledgers"
        '
        'SideNavItem2
        '
        Me.SideNavItem2.Name = "SideNavItem2"
        Me.SideNavItem2.Panel = Me.SideNavPanel1
        Me.SideNavItem2.Symbol = ""
        Me.SideNavItem2.Text = "Journals"
        '
        'SideNavItem4
        '
        Me.SideNavItem4.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.SideNavItem4.Name = "SideNavItem4"
        Me.SideNavItem4.Panel = Me.SideNavPanel3
        Me.SideNavItem4.Symbol = ""
        Me.SideNavItem4.Text = "Settings"
        '
        'SideNavItem8
        '
        Me.SideNavItem8.Checked = True
        Me.SideNavItem8.Name = "SideNavItem8"
        Me.SideNavItem8.Panel = Me.SideNavPanel7
        Me.SideNavItem8.Symbol = "57373"
        Me.SideNavItem8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem8.Text = "Reports"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Account Number"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Account Name"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Account Number"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Account Name"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Account Number"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Account Name"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'KryptonDataGridView3
        '
        Me.KryptonDataGridView3.AllowUserToAddRows = False
        Me.KryptonDataGridView3.AllowUserToDeleteRows = False
        Me.KryptonDataGridView3.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.KryptonDataGridView3.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.KryptonDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonDataGridView3.Location = New System.Drawing.Point(1, 24)
        Me.KryptonDataGridView3.Name = "KryptonDataGridView3"
        Me.KryptonDataGridView3.ReadOnly = True
        Me.KryptonDataGridView3.RowHeadersWidth = 25
        Me.KryptonDataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.KryptonDataGridView3.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.KryptonDataGridView3.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.KryptonDataGridView3.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.KryptonDataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.KryptonDataGridView3.Size = New System.Drawing.Size(686, 462)
        Me.KryptonDataGridView3.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.KryptonDataGridView3.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.KryptonDataGridView3.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.KryptonDataGridView3.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonDataGridView3.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonDataGridView3.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.KryptonDataGridView3.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonDataGridView3.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonDataGridView3.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonDataGridView3.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonDataGridView3.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonDataGridView3.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.KryptonDataGridView3.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonDataGridView3.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonDataGridView3.TabIndex = 155
        '
        'frmOne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOne"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Financial Light Edge 8.0"
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel2.ResumeLayout(False)
        Me.SideNavPanel2.PerformLayout()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        CType(Me.SuperTabControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl3.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        CType(Me.dGridLedgers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        Me.expandablePanel1.ResumeLayout(False)
        CType(Me.Bar11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel7.ResumeLayout(False)
        Me.SideNavPanel7.PerformLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        Me.KryptonPanel16.PerformLayout()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel15.ResumeLayout(False)
        Me.SideNavPanel3.ResumeLayout(False)
        Me.panelEx1.ResumeLayout(False)
        CType(Me.KryptonDataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavPanel7 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel3 As DevComponents.DotNetBar.Controls.SideNavPanel
    Private WithEvents panelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents recentDocsItemPane As DevComponents.DotNetBar.ItemPanel
    Private WithEvents btnLedgerAccounts As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnSpecialLedgers As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem3 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem4 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem8 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar11 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem21 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents splitMain As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnFindData As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents SuperTabControl3 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Bar12 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem24 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem27 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerCount As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem31 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerDebits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem34 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerCredits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem36 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerMovement As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem38 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerEndBalance As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Bar13 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem40 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerPeriodStartBalance As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblLedgerBFbalanceType As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents lblAccountName As System.Windows.Forms.Label
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents KryptonDataGridView3 As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents tvAccounts As System.Windows.Forms.TreeView
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dGridLedgers As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel15 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents tvReports As System.Windows.Forms.TreeView
    Friend WithEvents Bar16 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Private WithEvents btnOrganisation As DevComponents.DotNetBar.ButtonItem
    Protected WithEvents StyleManager2 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewJournal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditJournal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteJournal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSeletedRowQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintQuoteList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshJournal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpJvStartFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpJvEndTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFindJournals As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem11 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem12 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem13 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem14 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewImageColumn
End Class