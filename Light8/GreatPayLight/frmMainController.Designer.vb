<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainController
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
        Dim SuperTabColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainController))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Full Masterfile", 5, 5)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Listing", 5, 5)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salary Increaments", 5, 5)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("New Entrants", 5, 5)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Leavers", 5, 5)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Staff Turnover", 5, 5)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transfers", 5, 5)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personnel", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A5 Payslips", 5, 5)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A5 Payslips Format 2", 5, 5)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Control", 5, 5)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Control Totals", 5, 5)
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bank Transfer Schedule", 5, 5)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Summary", 5, 5)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Audit Trail", 5, 5)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Coinage Analysis", 5, 5)
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tax Certificates", 5, 5)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll", 11, 11, New System.Windows.Forms.TreeNode() {TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17})
        Dim SuperTabColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Dim SuperTabColorTable3 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable3 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.lblAccountsStatus = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.pb1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel4 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.tabParameters = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Home = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnParmsMain = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCodes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCalculations = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDates = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnConstants = New DevComponents.DotNetBar.ButtonItem()
        Me.btnKeyFields = New DevComponents.DotNetBar.ButtonItem()
        Me.btnColumnReports = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTrekkedFields = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSplitCodes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBanks = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCalendar = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCreate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImports = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPaywellDbImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOrganisation = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel5 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.ItemPanel2 = New DevComponents.DotNetBar.ItemPanel()
        Me.btnBankExtracts = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel3 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonSeparator1 = New ComponentFactory.Krypton.Toolkit.KryptonSeparator()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.pnlHome = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tabEmployees = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.home2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.tabBatches = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.navHome = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.navBatches = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.btnPayrollRun = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.navUtilities = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.navReports = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.navSettings = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.pdSummary = New System.Drawing.Printing.PrintDocument()
        Me.pdSchedules = New System.Drawing.Printing.PrintDocument()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdTotals = New System.Drawing.Printing.PrintDocument()
        Me.pdMasterFile = New System.Drawing.Printing.PrintDocument()
        Me.ppdUserReports = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdFormatTwo = New System.Drawing.Printing.PrintDocument()
        Me.pdSmallPayslips = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.printGrid = New System.Drawing.Printing.PrintDocument()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel4.SuspendLayout()
        CType(Me.tabParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabParameters.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel5.SuspendLayout()
        Me.SideNavPanel3.SuspendLayout()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.expandablePanel1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.pnlHome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHome.SuspendLayout()
        CType(Me.tabEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmployees.SuspendLayout()
        Me.SideNavPanel2.SuspendLayout()
        CType(Me.tabBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBatches.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1007, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 697)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1007, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 696)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1006, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 696)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblAccountsStatus, Me.LabelItem3, Me.pb1})
        Me.Bar1.Location = New System.Drawing.Point(1, 677)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(1005, 20)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 22
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'lblAccountsStatus
        '
        Me.lblAccountsStatus.ForeColor = System.Drawing.Color.Yellow
        Me.lblAccountsStatus.Name = "lblAccountsStatus"
        Me.lblAccountsStatus.PaddingLeft = 12
        Me.lblAccountsStatus.PaddingRight = 12
        Me.lblAccountsStatus.Stretch = True
        Me.lblAccountsStatus.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingRight = 36
        Me.LabelItem3.Text = "Great Wits Technologies ©  2016 - 2017"
        '
        'pb1
        '
        '
        '
        '
        Me.pb1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pb1.ChunkGradientAngle = 0.0!
        Me.pb1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pb1.Name = "pb1"
        Me.pb1.RecentlyUsed = False
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel4)
        Me.SideNav1.Controls.Add(Me.SideNavPanel5)
        Me.SideNav1.Controls.Add(Me.SideNavPanel3)
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.navHome, Me.navBatches, Me.btnPayrollRun, Me.navUtilities, Me.navReports, Me.navSettings})
        Me.SideNav1.Location = New System.Drawing.Point(1, 1)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1005, 676)
        Me.SideNav1.TabIndex = 23
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel4
        '
        Me.SideNavPanel4.Controls.Add(Me.tabParameters)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge25)
        Me.SideNavPanel4.Controls.Add(Me.Bar2)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge24)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge23)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge22)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge21)
        Me.SideNavPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel4.Location = New System.Drawing.Point(109, 31)
        Me.SideNavPanel4.Name = "SideNavPanel4"
        Me.SideNavPanel4.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel4.Size = New System.Drawing.Size(895, 644)
        Me.SideNavPanel4.TabIndex = 14
        '
        'tabParameters
        '
        Me.tabParameters.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.tabParameters.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabParameters.ControlBox.MenuBox.Name = ""
        Me.tabParameters.ControlBox.Name = ""
        Me.tabParameters.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabParameters.ControlBox.MenuBox, Me.tabParameters.ControlBox.CloseBox})
        Me.tabParameters.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabParameters.ForeColor = System.Drawing.Color.Black
        Me.tabParameters.Location = New System.Drawing.Point(7, 33)
        Me.tabParameters.Name = "tabParameters"
        Me.tabParameters.ReorderTabsEnabled = True
        Me.tabParameters.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabParameters.SelectedTabIndex = 0
        Me.tabParameters.Size = New System.Drawing.Size(881, 604)
        Me.tabParameters.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.tabParameters.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabParameters.TabIndex = 6
        Me.tabParameters.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Home})
        SuperTabLinearGradientColorTable1.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
        SuperTabColorTable1.Background = SuperTabLinearGradientColorTable1
        Me.tabParameters.TabStripColor = SuperTabColorTable1
        Me.tabParameters.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabParameters.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(881, 579)
        Me.SuperTabControlPanel2.TabIndex = 1
        Me.SuperTabControlPanel2.TabItem = Me.Home
        '
        'Home
        '
        Me.Home.AttachedControl = Me.SuperTabControlPanel2
        Me.Home.GlobalItem = False
        Me.Home.Name = "Home"
        Me.Home.Text = "Home"
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(881, 1)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnParmsMain, Me.btnCreate, Me.btnImports, Me.btnOrganisation})
        Me.Bar2.Location = New System.Drawing.Point(7, 7)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(881, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 4
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnParmsMain
        '
        Me.btnParmsMain.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnParmsMain.Image = CType(resources.GetObject("btnParmsMain.Image"), System.Drawing.Image)
        Me.btnParmsMain.Name = "btnParmsMain"
        Me.btnParmsMain.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnParmsMain.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnCodes, Me.btnCalculations, Me.btnDates, Me.ButtonItem5, Me.ButtonItem6, Me.btnConstants, Me.btnKeyFields, Me.btnColumnReports, Me.btnTrekkedFields, Me.btnSplitCodes, Me.btnBanks, Me.btnCalendar})
        Me.btnParmsMain.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnParmsMain.Text = "System Parameters"
        '
        'btnCodes
        '
        Me.btnCodes.Name = "btnCodes"
        Me.btnCodes.Text = "Codes"
        '
        'btnCalculations
        '
        Me.btnCalculations.BeginGroup = True
        Me.btnCalculations.Name = "btnCalculations"
        Me.btnCalculations.Text = "Calculations"
        '
        'btnDates
        '
        Me.btnDates.BeginGroup = True
        Me.btnDates.Name = "btnDates"
        Me.btnDates.Text = "Employee Dates"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.BeginGroup = True
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "Payroll Flags (Indicators)"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.BeginGroup = True
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "Reference Numbers"
        '
        'btnConstants
        '
        Me.btnConstants.BeginGroup = True
        Me.btnConstants.Name = "btnConstants"
        Me.btnConstants.Text = "Payroll Constants"
        '
        'btnKeyFields
        '
        Me.btnKeyFields.BeginGroup = True
        Me.btnKeyFields.Name = "btnKeyFields"
        Me.btnKeyFields.Text = "Key Payroll Codes"
        '
        'btnColumnReports
        '
        Me.btnColumnReports.BeginGroup = True
        Me.btnColumnReports.Name = "btnColumnReports"
        Me.btnColumnReports.Text = "6 Column Report Designer"
        '
        'btnTrekkedFields
        '
        Me.btnTrekkedFields.BeginGroup = True
        Me.btnTrekkedFields.Name = "btnTrekkedFields"
        Me.btnTrekkedFields.Text = "Trekked Codes"
        '
        'btnSplitCodes
        '
        Me.btnSplitCodes.BeginGroup = True
        Me.btnSplitCodes.Name = "btnSplitCodes"
        Me.btnSplitCodes.Text = "Split Payment Codes"
        '
        'btnBanks
        '
        Me.btnBanks.BeginGroup = True
        Me.btnBanks.Name = "btnBanks"
        Me.btnBanks.Text = "Banks Maintenance"
        '
        'btnCalendar
        '
        Me.btnCalendar.BeginGroup = True
        Me.btnCalendar.Name = "btnCalendar"
        Me.btnCalendar.Text = "Run Calendar"
        '
        'btnCreate
        '
        Me.btnCreate.BeginGroup = True
        Me.btnCreate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCreate.Image = CType(resources.GetObject("btnCreate.Image"), System.Drawing.Image)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCreate.Text = "New Payroll"
        '
        'btnImports
        '
        Me.btnImports.BeginGroup = True
        Me.btnImports.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImports.Image = CType(resources.GetObject("btnImports.Image"), System.Drawing.Image)
        Me.btnImports.Name = "btnImports"
        Me.btnImports.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPaywellDbImport})
        Me.btnImports.Text = "Imports"
        '
        'btnPaywellDbImport
        '
        Me.btnPaywellDbImport.Name = "btnPaywellDbImport"
        Me.btnPaywellDbImport.Text = "Import Paywell Database"
        '
        'btnOrganisation
        '
        Me.btnOrganisation.BeginGroup = True
        Me.btnOrganisation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOrganisation.Image = CType(resources.GetObject("btnOrganisation.Image"), System.Drawing.Image)
        Me.btnOrganisation.Name = "btnOrganisation"
        Me.btnOrganisation.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnOrganisation.Text = "Company"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(888, 7)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'SideNavPanel5
        '
        Me.SideNavPanel5.Controls.Add(Me.ItemPanel2)
        Me.SideNavPanel5.Controls.Add(Me.LabelX2)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge16)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge15)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge14)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge13)
        Me.SideNavPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel5.Location = New System.Drawing.Point(109, 31)
        Me.SideNavPanel5.Name = "SideNavPanel5"
        Me.SideNavPanel5.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel5.Size = New System.Drawing.Size(895, 644)
        Me.SideNavPanel5.TabIndex = 18
        Me.SideNavPanel5.Visible = False
        '
        'ItemPanel2
        '
        Me.ItemPanel2.AutoScroll = True
        Me.ItemPanel2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ItemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel2.ContainerControlProcessDialogKey = True
        Me.ItemPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemPanel2.DragDropSupport = True
        Me.ItemPanel2.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnBankExtracts})
        Me.ItemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel2.Location = New System.Drawing.Point(7, 44)
        Me.ItemPanel2.Name = "ItemPanel2"
        Me.ItemPanel2.Size = New System.Drawing.Size(881, 593)
        Me.ItemPanel2.TabIndex = 5
        '
        'btnBankExtracts
        '
        Me.btnBankExtracts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBankExtracts.ImagePaddingHorizontal = 12
        Me.btnBankExtracts.ImagePaddingVertical = 16
        Me.btnBankExtracts.Name = "btnBankExtracts"
        Me.btnBankExtracts.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBankExtracts.Symbol = "57772"
        Me.btnBankExtracts.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnBankExtracts.Text = "Bank Extract<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create a bank file of net salary and any ot" & _
    "her split payment codes</font>"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash
        Me.LabelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gray
        Me.LabelX2.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(7, 7)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.PaddingLeft = 12
        Me.LabelX2.Size = New System.Drawing.Size(881, 37)
        Me.LabelX2.SymbolColor = System.Drawing.Color.White
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Utility Tools"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(888, 7)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'SideNavPanel3
        '
        Me.SideNavPanel3.Controls.Add(Me.KryptonHeader1)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge26)
        Me.SideNavPanel3.Controls.Add(Me.KryptonSeparator1)
        Me.SideNavPanel3.Controls.Add(Me.KryptonPanel1)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge20)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge19)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge18)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge17)
        Me.SideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel3.Location = New System.Drawing.Point(109, 31)
        Me.SideNavPanel3.Name = "SideNavPanel3"
        Me.SideNavPanel3.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel3.Size = New System.Drawing.Size(895, 644)
        Me.SideNavPanel3.TabIndex = 10
        Me.SideNavPanel3.Visible = False
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.BackColor = System.Drawing.Color.White
        Me.KryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonHeader1.ForeColor = System.Drawing.Color.Black
        Me.KryptonHeader1.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Calendar
        Me.KryptonHeader1.Location = New System.Drawing.Point(228, 7)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(660, 27)
        Me.KryptonHeader1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader1.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.KryptonHeader1.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonHeader1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonHeader1.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonHeader1.TabIndex = 7
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = "Preview"
        Me.KryptonHeader1.Values.Image = Nothing
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(227, 7)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'KryptonSeparator1
        '
        Me.KryptonSeparator1.BackColor = System.Drawing.Color.White
        Me.KryptonSeparator1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonSeparator1.ForeColor = System.Drawing.Color.Black
        Me.KryptonSeparator1.Location = New System.Drawing.Point(222, 7)
        Me.KryptonSeparator1.Name = "KryptonSeparator1"
        Me.KryptonSeparator1.Size = New System.Drawing.Size(5, 630)
        Me.KryptonSeparator1.TabIndex = 5
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.expandablePanel1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(7, 7)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(215, 630)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 4
        '
        'expandablePanel1
        '
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.tvReports)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.ExpandButtonVisible = False
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(215, 630)
        Me.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.Style.GradientAngle = 90
        Me.expandablePanel1.TabIndex = 10
        Me.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.TitleStyle.GradientAngle = 90
        Me.expandablePanel1.TitleStyle.MarginLeft = 6
        Me.expandablePanel1.TitleText = "Standard Reports"
        '
        'tvReports
        '
        Me.tvReports.BackColor = System.Drawing.Color.White
        Me.tvReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReports.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvReports.ForeColor = System.Drawing.Color.Black
        Me.tvReports.HideSelection = False
        Me.tvReports.ImageIndex = 0
        Me.tvReports.ImageList = Me.imageList1
        Me.tvReports.Location = New System.Drawing.Point(0, 26)
        Me.tvReports.Name = "tvReports"
        TreeNode1.ImageIndex = 5
        TreeNode1.Name = "Node1"
        TreeNode1.SelectedImageIndex = 5
        TreeNode1.Text = "Employee Full Masterfile"
        TreeNode2.ImageIndex = 5
        TreeNode2.Name = "Node20"
        TreeNode2.SelectedImageIndex = 5
        TreeNode2.Text = "Employee Listing"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "Node21"
        TreeNode3.SelectedImageIndex = 5
        TreeNode3.Text = "Salary Increaments"
        TreeNode4.ImageIndex = 5
        TreeNode4.Name = "Node22"
        TreeNode4.SelectedImageIndex = 5
        TreeNode4.Text = "New Entrants"
        TreeNode5.ImageIndex = 5
        TreeNode5.Name = "Node23"
        TreeNode5.SelectedImageIndex = 5
        TreeNode5.Text = "Leavers"
        TreeNode6.ImageIndex = 5
        TreeNode6.Name = "Node24"
        TreeNode6.SelectedImageIndex = 5
        TreeNode6.Text = "Staff Turnover"
        TreeNode7.ImageIndex = 5
        TreeNode7.Name = "Node25"
        TreeNode7.SelectedImageIndex = 5
        TreeNode7.Text = "Transfers"
        TreeNode8.ImageIndex = 2
        TreeNode8.Name = "Node0"
        TreeNode8.SelectedImageIndex = 2
        TreeNode8.Text = "Personnel"
        TreeNode9.ImageIndex = 5
        TreeNode9.Name = "Node1"
        TreeNode9.SelectedImageIndex = 5
        TreeNode9.Text = "A5 Payslips"
        TreeNode10.ImageIndex = 5
        TreeNode10.Name = "Node2"
        TreeNode10.SelectedImageIndex = 5
        TreeNode10.Text = "A5 Payslips Format 2"
        TreeNode11.ImageIndex = 5
        TreeNode11.Name = "Node3"
        TreeNode11.SelectedImageIndex = 5
        TreeNode11.Text = "Employee Control"
        TreeNode12.ImageIndex = 5
        TreeNode12.Name = "Node4"
        TreeNode12.SelectedImageIndex = 5
        TreeNode12.Text = "Payroll Control Totals"
        TreeNode13.ImageIndex = 5
        TreeNode13.Name = "Node5"
        TreeNode13.SelectedImageIndex = 5
        TreeNode13.Text = "Bank Transfer Schedule"
        TreeNode14.ImageIndex = 5
        TreeNode14.Name = "Node6"
        TreeNode14.SelectedImageIndex = 5
        TreeNode14.Text = "Payroll Summary"
        TreeNode15.ImageIndex = 5
        TreeNode15.Name = "Node7"
        TreeNode15.SelectedImageIndex = 5
        TreeNode15.Text = "Audit Trail"
        TreeNode16.ImageIndex = 5
        TreeNode16.Name = "Node8"
        TreeNode16.SelectedImageIndex = 5
        TreeNode16.Text = "Coinage Analysis"
        TreeNode17.ImageIndex = 5
        TreeNode17.Name = "Node9"
        TreeNode17.SelectedImageIndex = 5
        TreeNode17.Text = "Tax Certificates"
        TreeNode18.ImageIndex = 11
        TreeNode18.Name = "Node0"
        TreeNode18.SelectedImageIndex = 11
        TreeNode18.Text = "Payroll"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode18})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(215, 604)
        Me.tvReports.TabIndex = 26
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
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(888, 7)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.pnlHome)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge8)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(109, 31)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel1.Size = New System.Drawing.Size(895, 644)
        Me.SideNavPanel1.TabIndex = 2
        Me.SideNavPanel1.Visible = False
        '
        'pnlHome
        '
        Me.pnlHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.pnlHome.Controls.Add(Me.tabEmployees)
        Me.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHome.ForeColor = System.Drawing.Color.Black
        Me.pnlHome.Location = New System.Drawing.Point(7, 7)
        Me.pnlHome.Name = "pnlHome"
        Me.pnlHome.Size = New System.Drawing.Size(881, 630)
        Me.pnlHome.StateCommon.Color1 = System.Drawing.Color.White
        Me.pnlHome.StateCommon.Color2 = System.Drawing.Color.White
        Me.pnlHome.TabIndex = 4
        '
        'tabEmployees
        '
        Me.tabEmployees.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.tabEmployees.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabEmployees.ControlBox.MenuBox.Name = ""
        Me.tabEmployees.ControlBox.Name = ""
        Me.tabEmployees.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmployees.ControlBox.MenuBox, Me.tabEmployees.ControlBox.CloseBox})
        Me.tabEmployees.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabEmployees.ForeColor = System.Drawing.Color.Black
        Me.tabEmployees.Location = New System.Drawing.Point(0, 0)
        Me.tabEmployees.Name = "tabEmployees"
        Me.tabEmployees.ReorderTabsEnabled = True
        Me.tabEmployees.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabEmployees.SelectedTabIndex = 0
        Me.tabEmployees.Size = New System.Drawing.Size(881, 630)
        Me.tabEmployees.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.tabEmployees.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEmployees.TabIndex = 0
        Me.tabEmployees.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.home2})
        SuperTabLinearGradientColorTable2.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
        SuperTabColorTable2.Background = SuperTabLinearGradientColorTable2
        Me.tabEmployees.TabStripColor = SuperTabColorTable2
        Me.tabEmployees.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabEmployees.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(881, 605)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.home2
        '
        'home2
        '
        Me.home2.AttachedControl = Me.SuperTabControlPanel1
        Me.home2.GlobalItem = False
        Me.home2.Name = "home2"
        Me.home2.Text = "SuperTabItem1"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(888, 7)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Controls.Add(Me.tabBatches)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge12)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge11)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge9)
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(109, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel2.Size = New System.Drawing.Size(895, 644)
        Me.SideNavPanel2.TabIndex = 6
        Me.SideNavPanel2.Visible = False
        '
        'tabBatches
        '
        Me.tabBatches.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.tabBatches.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabBatches.ControlBox.MenuBox.Name = ""
        Me.tabBatches.ControlBox.Name = ""
        Me.tabBatches.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabBatches.ControlBox.MenuBox, Me.tabBatches.ControlBox.CloseBox})
        Me.tabBatches.Controls.Add(Me.SuperTabControlPanel3)
        Me.tabBatches.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBatches.ForeColor = System.Drawing.Color.Black
        Me.tabBatches.Location = New System.Drawing.Point(7, 7)
        Me.tabBatches.Name = "tabBatches"
        Me.tabBatches.ReorderTabsEnabled = True
        Me.tabBatches.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBatches.SelectedTabIndex = 0
        Me.tabBatches.Size = New System.Drawing.Size(881, 630)
        Me.tabBatches.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.tabBatches.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBatches.TabIndex = 4
        Me.tabBatches.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2})
        SuperTabLinearGradientColorTable3.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
        SuperTabColorTable3.Background = SuperTabLinearGradientColorTable3
        Me.tabBatches.TabStripColor = SuperTabColorTable3
        Me.tabBatches.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabBatches.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(881, 605)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "SuperTabItem1"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(888, 7)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(883, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
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
        'navHome
        '
        Me.navHome.Name = "navHome"
        Me.navHome.Panel = Me.SideNavPanel1
        Me.navHome.Symbol = "58941"
        Me.navHome.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.navHome.Text = "Home"
        '
        'navBatches
        '
        Me.navBatches.Name = "navBatches"
        Me.navBatches.Panel = Me.SideNavPanel2
        Me.navBatches.Symbol = "57532"
        Me.navBatches.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.navBatches.Text = "Transactions"
        '
        'btnPayrollRun
        '
        Me.btnPayrollRun.Name = "btnPayrollRun"
        Me.btnPayrollRun.Symbol = ""
        Me.btnPayrollRun.Text = "Payroll Run"
        '
        'navUtilities
        '
        Me.navUtilities.Name = "navUtilities"
        Me.navUtilities.Panel = Me.SideNavPanel5
        Me.navUtilities.Symbol = ""
        Me.navUtilities.Text = "Utilities"
        '
        'navReports
        '
        Me.navReports.Name = "navReports"
        Me.navReports.Panel = Me.SideNavPanel3
        Me.navReports.Symbol = ""
        Me.navReports.Text = "Reports"
        '
        'navSettings
        '
        Me.navSettings.Checked = True
        Me.navSettings.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.navSettings.Name = "navSettings"
        Me.navSettings.Panel = Me.SideNavPanel4
        Me.navSettings.Symbol = ""
        Me.navSettings.Text = "Settings"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
        '
        'ppd
        '
        Me.ppd.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ppd.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd.Enabled = True
        Me.ppd.Icon = CType(resources.GetObject("ppd.Icon"), System.Drawing.Icon)
        Me.ppd.Name = "ppd"
        Me.ppd.Visible = False
        '
        'ppdUserReports
        '
        Me.ppdUserReports.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdUserReports.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdUserReports.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdUserReports.Enabled = True
        Me.ppdUserReports.Icon = CType(resources.GetObject("ppdUserReports.Icon"), System.Drawing.Icon)
        Me.ppdUserReports.Name = "ppdUserReports"
        Me.ppdUserReports.Visible = False
        '
        'pdSmallPayslips
        '
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
        'frmMainController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageUnderCaption = True
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMainController"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paylight 2017"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel4.ResumeLayout(False)
        Me.SideNavPanel4.PerformLayout()
        CType(Me.tabParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabParameters.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel5.ResumeLayout(False)
        Me.SideNavPanel5.PerformLayout()
        Me.SideNavPanel3.ResumeLayout(False)
        Me.SideNavPanel3.PerformLayout()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.expandablePanel1.ResumeLayout(False)
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.pnlHome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHome.ResumeLayout(False)
        CType(Me.tabEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmployees.ResumeLayout(False)
        Me.SideNavPanel2.ResumeLayout(False)
        Me.SideNavPanel2.PerformLayout()
        CType(Me.tabBatches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBatches.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavPanel5 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel3 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel4 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents navHome As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents navBatches As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents btnPayrollRun As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents navUtilities As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents navReports As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents navSettings As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents pnlHome As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tabEmployees As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents home2 As DevComponents.DotNetBar.SuperTabItem
    Protected WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents tabParameters As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Home As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnParmsMain As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCodes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCalculations As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDates As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnConstants As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnKeyFields As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnColumnReports As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblAccountsStatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pb1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents btnTrekkedFields As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCreate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImports As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPaywellDbImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tabBatches As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents btnSplitCodes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBanks As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ItemPanel2 As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents btnBankExtracts As DevComponents.DotNetBar.ButtonItem
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Private WithEvents tvReports As System.Windows.Forms.TreeView
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonSeparator1 As ComponentFactory.Krypton.Toolkit.KryptonSeparator
    Friend WithEvents pdSummary As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdSchedules As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppd As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdTotals As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdMasterFile As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdUserReports As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdFormatTwo As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdSmallPayslips As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents printGrid As System.Drawing.Printing.PrintDocument
    Friend WithEvents btnOrganisation As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCalendar As DevComponents.DotNetBar.ButtonItem
End Class
