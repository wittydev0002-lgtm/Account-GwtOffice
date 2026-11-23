<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPaylightMain
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaylightMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A5 Payslips", 5, 5)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A5 Payslips Format 2", 5, 5)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Control", 5, 5)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Control Totals", 5, 5)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bank Transfer Schedule", 5, 5)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Summary", 5, 5)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Audit Trail", 5, 5)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Coinage Analysis", 5, 5)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tax Certificates", 5, 5)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll", 11, 11, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.cboSearchBy = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.txtSearchString = New DevComponents.DotNetBar.TextBoxItem()
        Me.lblTotalRecords = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel4 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridTransactions = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.btnNewBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnViewBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSaveBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.lblBatchNumber = New DevComponents.DotNetBar.LabelItem()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.lblBatchTotal = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel5 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridEmployeeToPay = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar6 = New DevComponents.DotNetBar.Bar()
        Me.btnPreparePayrun = New DevComponents.DotNetBar.ButtonItem()
        Me.btnProcessPay = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBankExtracts = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblActiveEmployees = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.KryptonSplitContainer2 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar7 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridReports = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNewReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshReports = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.Bar8 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.pnlPreview = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridPreview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.labelX5 = New DevComponents.DotNetBar.LabelX()
        Me.integerInput1 = New DevComponents.Editors.IntegerInput()
        Me.labelX4 = New DevComponents.DotNetBar.LabelX()
        Me.btnPrintPreview = New DevComponents.DotNetBar.ButtonX()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar16 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem4 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem5 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem6 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.ComboItem14 = New DevComponents.Editors.ComboItem()
        Me.ComboItem15 = New DevComponents.Editors.ComboItem()
        Me.ComboItem16 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ppdUserReports = New System.Windows.Forms.PrintPreviewDialog()
        Me.ComboItem17 = New DevComponents.Editors.ComboItem()
        Me.ComboItem18 = New DevComponents.Editors.ComboItem()
        Me.ComboItem19 = New DevComponents.Editors.ComboItem()
        Me.ComboItem20 = New DevComponents.Editors.ComboItem()
        Me.pdSchedules = New System.Drawing.Printing.PrintDocument()
        Me.pdTotals = New System.Drawing.Printing.PrintDocument()
        Me.pdSummary = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdSmallPayslips = New System.Drawing.Printing.PrintDocument()
        Me.pdFormatTwo = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel4.SuspendLayout()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel5.SuspendLayout()
        CType(Me.dGridEmployeeToPay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel2.SuspendLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        CType(Me.KryptonSplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer2.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer2.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer2.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer2.Panel2.SuspendLayout()
        Me.KryptonSplitContainer2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dGridReports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreview.SuspendLayout()
        CType(Me.dGridPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.integerInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ProgressBarItem1})
        Me.Bar1.Location = New System.Drawing.Point(0, 658)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(1007, 24)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Great Wits Pay Light 8.0"
        '
        'ProgressBarItem1
        '
        '
        '
        '
        Me.ProgressBarItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarItem1.ChunkGradientAngle = 0!
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel4)
        Me.SideNav1.Controls.Add(Me.SideNavPanel5)
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem2, Me.SideNavItem4, Me.SideNavItem5, Me.SideNavItem6})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1007, 658)
        Me.SideNav1.TabIndex = 1
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(144, 31)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel1.Size = New System.Drawing.Size(858, 626)
        Me.SideNavPanel1.TabIndex = 2
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.dGrid)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.Bar3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(6, 6)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(846, 614)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 2
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column1, Me.Column2, Me.Column5, Me.Column7, Me.Column8, Me.Column6})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(1, 30)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersVisible = False
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(844, 583)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGrid.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.TabIndex = 42
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Employee #"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 95
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Last Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 88
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "First Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 90
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Other Names"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 103
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "ID Number"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 91
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column7.HeaderText = "DOE"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 59
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column8.HeaderText = "DOB"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 60
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 68
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1, 29)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(844, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnEdit, Me.btnPrint, Me.btnRefresh, Me.LabelItem2, Me.cboSearchBy, Me.LabelItem4, Me.txtSearchString, Me.lblTotalRecords})
        Me.Bar3.Location = New System.Drawing.Point(1, 1)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(844, 28)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 21
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnEdit, New DevComponents.DotNetBar.SuperTooltipInfo("Edit", "", "Open selected item for edit", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.btnEdit.Text = "Edit"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnPrint, New DevComponents.DotNetBar.SuperTooltipInfo("Print", "", "Prints all the records in the active grid", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.btnPrint.Text = "Print"
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnRefresh, New DevComponents.DotNetBar.SuperTooltipInfo("Refresh Data", "", "Refreshes the active grid data", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.btnRefresh.Text = "ButtonItem7"
        '
        'LabelItem2
        '
        Me.LabelItem2.BeginGroup = True
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 5
        Me.LabelItem2.PaddingRight = 5
        Me.LabelItem2.Text = "Search by"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.ComboWidth = 140
        Me.cboSearchBy.DropDownHeight = 106
        Me.cboSearchBy.ItemHeight = 17
        Me.cboSearchBy.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4})
        Me.cboSearchBy.Name = "cboSearchBy"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Employee No"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Last Name"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "First Name"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Other Names"
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 6
        Me.LabelItem4.PaddingRight = 6
        Me.LabelItem4.Text = "Search for "
        '
        'txtSearchString
        '
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.TextBoxWidth = 120
        Me.txtSearchString.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'lblTotalRecords
        '
        Me.lblTotalRecords.BackColor = System.Drawing.Color.Orange
        Me.lblTotalRecords.BeginGroup = True
        Me.lblTotalRecords.Name = "lblTotalRecords"
        Me.lblTotalRecords.PaddingLeft = 3
        Me.lblTotalRecords.PaddingRight = 3
        Me.lblTotalRecords.Text = "0"
        Me.lblTotalRecords.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(845, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 612)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 612)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 613)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(846, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(846, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'SideNavPanel4
        '
        Me.SideNavPanel4.Controls.Add(Me.dGridTransactions)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge19)
        Me.SideNavPanel4.Controls.Add(Me.Bar5)
        Me.SideNavPanel4.Controls.Add(Me.Bar4)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge18)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge17)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge16)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge15)
        Me.SideNavPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel4.Location = New System.Drawing.Point(144, 31)
        Me.SideNavPanel4.Name = "SideNavPanel4"
        Me.SideNavPanel4.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel4.Size = New System.Drawing.Size(858, 626)
        Me.SideNavPanel4.TabIndex = 23
        Me.SideNavPanel4.Visible = False
        '
        'dGridTransactions
        '
        Me.dGridTransactions.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn7})
        Me.dGridTransactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridTransactions.Location = New System.Drawing.Point(7, 33)
        Me.dGridTransactions.Name = "dGridTransactions"
        Me.dGridTransactions.RowHeadersWidth = 25
        Me.dGridTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridTransactions.Size = New System.Drawing.Size(844, 566)
        Me.dGridTransactions.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridTransactions.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridTransactions.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridTransactions.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridTransactions.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.TabIndex = 24
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "EC No."
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn6.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 66
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Given Names"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 120
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(844, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewBatch, Me.btnViewBatch, Me.btnSaveBatch, Me.btnImportBatch, Me.ButtonItem6, Me.ButtonItem7, Me.LabelItem5, Me.lblBatchNumber})
        Me.Bar5.Location = New System.Drawing.Point(7, 7)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(844, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 22
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnNewBatch
        '
        Me.btnNewBatch.Image = CType(resources.GetObject("btnNewBatch.Image"), System.Drawing.Image)
        Me.btnNewBatch.Name = "btnNewBatch"
        Me.btnNewBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewBatch.Text = "New"
        '
        'btnViewBatch
        '
        Me.btnViewBatch.BeginGroup = True
        Me.btnViewBatch.Image = CType(resources.GetObject("btnViewBatch.Image"), System.Drawing.Image)
        Me.btnViewBatch.Name = "btnViewBatch"
        Me.btnViewBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnViewBatch.Text = "Open"
        '
        'btnSaveBatch
        '
        Me.btnSaveBatch.BeginGroup = True
        Me.btnSaveBatch.Image = CType(resources.GetObject("btnSaveBatch.Image"), System.Drawing.Image)
        Me.btnSaveBatch.Name = "btnSaveBatch"
        Me.btnSaveBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSaveBatch.Text = "Save"
        '
        'btnImportBatch
        '
        Me.btnImportBatch.BeginGroup = True
        Me.btnImportBatch.Image = CType(resources.GetObject("btnImportBatch.Image"), System.Drawing.Image)
        Me.btnImportBatch.Name = "btnImportBatch"
        Me.btnImportBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImportBatch.Text = "Import"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.BeginGroup = True
        Me.ButtonItem6.Image = CType(resources.GetObject("ButtonItem6.Image"), System.Drawing.Image)
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem6.Text = "ButtonItem6"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.Image = CType(resources.GetObject("ButtonItem7.Image"), System.Drawing.Image)
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem7.Text = "ButtonItem7"
        '
        'LabelItem5
        '
        Me.LabelItem5.BeginGroup = True
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingLeft = 3
        Me.LabelItem5.PaddingRight = 3
        Me.LabelItem5.Text = "Batch Number"
        '
        'lblBatchNumber
        '
        Me.lblBatchNumber.BackColor = System.Drawing.Color.Orange
        Me.lblBatchNumber.Name = "lblBatchNumber"
        Me.lblBatchNumber.PaddingLeft = 3
        Me.lblBatchNumber.PaddingRight = 3
        Me.lblBatchNumber.Text = "0"
        Me.lblBatchNumber.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.lblBatchTotal})
        Me.Bar4.Location = New System.Drawing.Point(7, 599)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.PaddingLeft = 3
        Me.Bar4.PaddingRight = 3
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(844, 20)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 4
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = "Amount totals"
        '
        'lblBatchTotal
        '
        Me.lblBatchTotal.Name = "lblBatchTotal"
        Me.lblBatchTotal.PaddingLeft = 3
        Me.lblBatchTotal.PaddingRight = 3
        Me.lblBatchTotal.Text = "0.00"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(7, 619)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(844, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(851, 7)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(1, 613)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(7, 6)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(845, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 614)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'SideNavPanel5
        '
        Me.SideNavPanel5.Controls.Add(Me.dGridEmployeeToPay)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge24)
        Me.SideNavPanel5.Controls.Add(Me.Bar6)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge23)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge22)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge21)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge20)
        Me.SideNavPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel5.Location = New System.Drawing.Point(144, 31)
        Me.SideNavPanel5.Name = "SideNavPanel5"
        Me.SideNavPanel5.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel5.Size = New System.Drawing.Size(858, 626)
        Me.SideNavPanel5.TabIndex = 36
        Me.SideNavPanel5.Visible = False
        '
        'dGridEmployeeToPay
        '
        Me.dGridEmployeeToPay.AllowUserToAddRows = False
        Me.dGridEmployeeToPay.AllowUserToDeleteRows = False
        Me.dGridEmployeeToPay.AllowUserToResizeRows = False
        Me.dGridEmployeeToPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridEmployeeToPay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridEmployeeToPay.Location = New System.Drawing.Point(7, 41)
        Me.dGridEmployeeToPay.Name = "dGridEmployeeToPay"
        Me.dGridEmployeeToPay.ReadOnly = True
        Me.dGridEmployeeToPay.RowHeadersVisible = False
        Me.dGridEmployeeToPay.RowHeadersWidth = 25
        Me.dGridEmployeeToPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridEmployeeToPay.Size = New System.Drawing.Size(844, 578)
        Me.dGridEmployeeToPay.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridEmployeeToPay.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridEmployeeToPay.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridEmployeeToPay.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridEmployeeToPay.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridEmployeeToPay.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridEmployeeToPay.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridEmployeeToPay.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridEmployeeToPay.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridEmployeeToPay.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridEmployeeToPay.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridEmployeeToPay.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridEmployeeToPay.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridEmployeeToPay.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridEmployeeToPay.TabIndex = 43
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(7, 40)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(844, 1)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'Bar6
        '
        Me.Bar6.AntiAlias = True
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar6.IsMaximized = False
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPreparePayrun, Me.btnProcessPay, Me.btnBankExtracts, Me.LabelItem8, Me.lblActiveEmployees})
        Me.Bar6.Location = New System.Drawing.Point(7, 7)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.RoundCorners = False
        Me.Bar6.Size = New System.Drawing.Size(844, 33)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar6.TabIndex = 22
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'btnPreparePayrun
        '
        Me.btnPreparePayrun.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPreparePayrun.Name = "btnPreparePayrun"
        Me.btnPreparePayrun.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPreparePayrun.Symbol = "58368"
        Me.btnPreparePayrun.SymbolColor = System.Drawing.Color.Red
        Me.btnPreparePayrun.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPreparePayrun.Text = "Prepare"
        '
        'btnProcessPay
        '
        Me.btnProcessPay.BeginGroup = True
        Me.btnProcessPay.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnProcessPay.Name = "btnProcessPay"
        Me.btnProcessPay.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnProcessPay.Symbol = "58369"
        Me.btnProcessPay.SymbolColor = System.Drawing.Color.Navy
        Me.btnProcessPay.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnProcessPay.Text = "Run"
        '
        'btnBankExtracts
        '
        Me.btnBankExtracts.BeginGroup = True
        Me.btnBankExtracts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBankExtracts.Name = "btnBankExtracts"
        Me.btnBankExtracts.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBankExtracts.Symbol = "58363"
        Me.btnBankExtracts.SymbolColor = System.Drawing.Color.Green
        Me.btnBankExtracts.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnBankExtracts.Text = "Transfer Nets"
        '
        'LabelItem8
        '
        Me.LabelItem8.BeginGroup = True
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingLeft = 6
        Me.LabelItem8.PaddingRight = 6
        Me.LabelItem8.Text = "Total number of employees to be paid"
        '
        'lblActiveEmployees
        '
        Me.lblActiveEmployees.BackColor = System.Drawing.Color.Orange
        Me.lblActiveEmployees.Name = "lblActiveEmployees"
        Me.lblActiveEmployees.PaddingLeft = 3
        Me.lblActiveEmployees.PaddingRight = 3
        Me.lblActiveEmployees.Text = "0"
        Me.lblActiveEmployees.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(851, 7)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(1, 612)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(1, 612)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(6, 619)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(846, 1)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(846, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Controls.Add(Me.KryptonSplitContainer1)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge9)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(144, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel2.Size = New System.Drawing.Size(858, 626)
        Me.SideNavPanel2.TabIndex = 40
        Me.SideNavPanel2.Visible = False
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(7, 7)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonSplitContainer2)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonBorderEdge26)
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color2 = System.Drawing.Color.White
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.pnlPreview)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonPanel18)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.Bar16)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge28)
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(844, 612)
        Me.KryptonSplitContainer1.SplitterDistance = 231
        Me.KryptonSplitContainer1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.TabIndex = 32
        '
        'KryptonSplitContainer2
        '
        Me.KryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonSplitContainer2.Name = "KryptonSplitContainer2"
        Me.KryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'KryptonSplitContainer2.Panel1
        '
        Me.KryptonSplitContainer2.Panel1.Controls.Add(Me.KryptonPanel1)
        Me.KryptonSplitContainer2.Panel1.Controls.Add(Me.KryptonBorderEdge25)
        Me.KryptonSplitContainer2.Panel1.Controls.Add(Me.Bar7)
        Me.KryptonSplitContainer2.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonSplitContainer2.Panel1.StateCommon.Color2 = System.Drawing.Color.White
        '
        'KryptonSplitContainer2.Panel2
        '
        Me.KryptonSplitContainer2.Panel2.Controls.Add(Me.KryptonPanel2)
        Me.KryptonSplitContainer2.Panel2.Controls.Add(Me.Bar8)
        Me.KryptonSplitContainer2.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonSplitContainer2.Panel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer2.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.KryptonSplitContainer2.Size = New System.Drawing.Size(230, 612)
        Me.KryptonSplitContainer2.SplitterDistance = 203
        Me.KryptonSplitContainer2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonSplitContainer2.StateCommon.Separator.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer2.StateCommon.Separator.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer2.TabIndex = 39
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.tvReports)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 24)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel1.Size = New System.Drawing.Size(230, 178)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 45
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
        Me.tvReports.Location = New System.Drawing.Point(6, 6)
        Me.tvReports.Name = "tvReports"
        TreeNode1.ImageIndex = 5
        TreeNode1.Name = "Node1"
        TreeNode1.SelectedImageIndex = 5
        TreeNode1.Text = "A5 Payslips"
        TreeNode2.ImageIndex = 5
        TreeNode2.Name = "Node2"
        TreeNode2.SelectedImageIndex = 5
        TreeNode2.Text = "A5 Payslips Format 2"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "Node3"
        TreeNode3.SelectedImageIndex = 5
        TreeNode3.Text = "Employee Control"
        TreeNode4.ImageIndex = 5
        TreeNode4.Name = "Node4"
        TreeNode4.SelectedImageIndex = 5
        TreeNode4.Text = "Payroll Control Totals"
        TreeNode5.ImageIndex = 5
        TreeNode5.Name = "Node5"
        TreeNode5.SelectedImageIndex = 5
        TreeNode5.Text = "Bank Transfer Schedule"
        TreeNode6.ImageIndex = 5
        TreeNode6.Name = "Node6"
        TreeNode6.SelectedImageIndex = 5
        TreeNode6.Text = "Payroll Summary"
        TreeNode7.ImageIndex = 5
        TreeNode7.Name = "Node7"
        TreeNode7.SelectedImageIndex = 5
        TreeNode7.Text = "Audit Trail"
        TreeNode8.ImageIndex = 5
        TreeNode8.Name = "Node8"
        TreeNode8.SelectedImageIndex = 5
        TreeNode8.Text = "Coinage Analysis"
        TreeNode9.ImageIndex = 5
        TreeNode9.Name = "Node9"
        TreeNode9.SelectedImageIndex = 5
        TreeNode9.Text = "Tax Certificates"
        TreeNode10.ImageIndex = 11
        TreeNode10.Name = "Node0"
        TreeNode10.SelectedImageIndex = 11
        TreeNode10.Text = "Payroll"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode10})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(218, 166)
        Me.tvReports.TabIndex = 46
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
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(0, 202)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(230, 1)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'Bar7
        '
        Me.Bar7.AccessibleDescription = "Bar16 (Bar16)"
        Me.Bar7.AccessibleName = "Bar16"
        Me.Bar7.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar7.AntiAlias = True
        Me.Bar7.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar7.IsMaximized = False
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem7})
        Me.Bar7.Location = New System.Drawing.Point(0, 0)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.PaddingBottom = 3
        Me.Bar7.PaddingLeft = 3
        Me.Bar7.PaddingRight = 3
        Me.Bar7.PaddingTop = 3
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(230, 24)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar7.TabIndex = 43
        Me.Bar7.TabStop = False
        Me.Bar7.Text = "Bar7"
        '
        'LabelItem7
        '
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.Text = "Standard Reports"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.dGridReports)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge27)
        Me.KryptonPanel2.Controls.Add(Me.Bar2)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 24)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(230, 380)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 46
        '
        'dGridReports
        '
        Me.dGridReports.AllowUserToAddRows = False
        Me.dGridReports.AllowUserToDeleteRows = False
        Me.dGridReports.AllowUserToResizeRows = False
        Me.dGridReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column9})
        Me.dGridReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridReports.Location = New System.Drawing.Point(0, 26)
        Me.dGridReports.Name = "dGridReports"
        Me.dGridReports.ReadOnly = True
        Me.dGridReports.RowHeadersVisible = False
        Me.dGridReports.RowHeadersWidth = 25
        Me.dGridReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridReports.Size = New System.Drawing.Size(230, 354)
        Me.dGridReports.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridReports.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridReports.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridReports.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridReports.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridReports.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridReports.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridReports.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridReports.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridReports.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridReports.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridReports.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridReports.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridReports.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReports.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReports.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridReports.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridReports.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReports.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReports.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReports.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReports.TabIndex = 53
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Report Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 103
        '
        'Column9
        '
        Me.Column9.HeaderText = "Type"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(230, 1)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewReport, Me.btnEditReport, Me.btnDeleteReport, Me.btnPrintReport, Me.btnExportReport, Me.btnRefreshReports, Me.LabelItem6})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(230, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 47
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnNewReport
        '
        Me.btnNewReport.Image = CType(resources.GetObject("btnNewReport.Image"), System.Drawing.Image)
        Me.btnNewReport.Name = "btnNewReport"
        Me.btnNewReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewReport.Text = "New"
        '
        'btnEditReport
        '
        Me.btnEditReport.Image = CType(resources.GetObject("btnEditReport.Image"), System.Drawing.Image)
        Me.btnEditReport.Name = "btnEditReport"
        Me.btnEditReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditReport.Text = "Edit"
        '
        'btnDeleteReport
        '
        Me.btnDeleteReport.BeginGroup = True
        Me.btnDeleteReport.Image = CType(resources.GetObject("btnDeleteReport.Image"), System.Drawing.Image)
        Me.btnDeleteReport.Name = "btnDeleteReport"
        Me.btnDeleteReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteReport.Text = "Delete"
        '
        'btnPrintReport
        '
        Me.btnPrintReport.BeginGroup = True
        Me.btnPrintReport.Image = CType(resources.GetObject("btnPrintReport.Image"), System.Drawing.Image)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintReport.Text = "Print"
        '
        'btnExportReport
        '
        Me.btnExportReport.BeginGroup = True
        Me.btnExportReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportReport.Image = CType(resources.GetObject("btnExportReport.Image"), System.Drawing.Image)
        Me.btnExportReport.Name = "btnExportReport"
        Me.btnExportReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportReport.Text = "To Excel"
        '
        'btnRefreshReports
        '
        Me.btnRefreshReports.BeginGroup = True
        Me.btnRefreshReports.Image = CType(resources.GetObject("btnRefreshReports.Image"), System.Drawing.Image)
        Me.btnRefreshReports.Name = "btnRefreshReports"
        Me.btnRefreshReports.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshReports.Text = "ButtonItem7"
        '
        'LabelItem6
        '
        Me.LabelItem6.BackColor = System.Drawing.Color.Orange
        Me.LabelItem6.BeginGroup = True
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingLeft = 3
        Me.LabelItem6.PaddingRight = 3
        Me.LabelItem6.Text = "0"
        Me.LabelItem6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Bar8
        '
        Me.Bar8.AccessibleDescription = "Bar16 (Bar16)"
        Me.Bar8.AccessibleName = "Bar16"
        Me.Bar8.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar8.AntiAlias = True
        Me.Bar8.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar8.IsMaximized = False
        Me.Bar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem9})
        Me.Bar8.Location = New System.Drawing.Point(0, 0)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.PaddingBottom = 3
        Me.Bar8.PaddingLeft = 3
        Me.Bar8.PaddingRight = 3
        Me.Bar8.PaddingTop = 3
        Me.Bar8.RoundCorners = False
        Me.Bar8.Size = New System.Drawing.Size(230, 24)
        Me.Bar8.Stretch = True
        Me.Bar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar8.TabIndex = 43
        Me.Bar8.TabStop = False
        Me.Bar8.Text = "Bar8"
        '
        'LabelItem9
        '
        Me.LabelItem9.Name = "LabelItem9"
        Me.LabelItem9.Text = "Custom Reports"
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(230, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 612)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'pnlPreview
        '
        Me.pnlPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.pnlPreview.Controls.Add(Me.dGridPreview)
        Me.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreview.ForeColor = System.Drawing.Color.Black
        Me.pnlPreview.Location = New System.Drawing.Point(1, 24)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(607, 461)
        Me.pnlPreview.StateCommon.Color1 = System.Drawing.Color.White
        Me.pnlPreview.StateCommon.Color2 = System.Drawing.Color.White
        Me.pnlPreview.TabIndex = 44
        '
        'dGridPreview
        '
        Me.dGridPreview.AllowUserToAddRows = False
        Me.dGridPreview.AllowUserToDeleteRows = False
        Me.dGridPreview.AllowUserToResizeRows = False
        Me.dGridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridPreview.Location = New System.Drawing.Point(0, 0)
        Me.dGridPreview.Name = "dGridPreview"
        Me.dGridPreview.ReadOnly = True
        Me.dGridPreview.RowHeadersVisible = False
        Me.dGridPreview.RowHeadersWidth = 25
        Me.dGridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPreview.Size = New System.Drawing.Size(607, 461)
        Me.dGridPreview.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridPreview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPreview.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPreview.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPreview.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPreview.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPreview.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridPreview.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridPreview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPreview.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPreview.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridPreview.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridPreview.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.TabIndex = 43
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.labelX5)
        Me.KryptonPanel18.Controls.Add(Me.integerInput1)
        Me.KryptonPanel18.Controls.Add(Me.labelX4)
        Me.KryptonPanel18.Controls.Add(Me.btnPrintPreview)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(1, 485)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(607, 127)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel18.TabIndex = 43
        '
        'labelX5
        '
        Me.labelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX5.ForeColor = System.Drawing.Color.Black
        Me.labelX5.Location = New System.Drawing.Point(133, 47)
        Me.labelX5.Name = "labelX5"
        Me.labelX5.Size = New System.Drawing.Size(48, 19)
        Me.labelX5.TabIndex = 8
        Me.labelX5.Text = "Copies:"
        '
        'integerInput1
        '
        Me.integerInput1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.integerInput1.ForeColor = System.Drawing.Color.Black
        Me.integerInput1.Location = New System.Drawing.Point(188, 46)
        Me.integerInput1.Name = "integerInput1"
        Me.integerInput1.ShowUpDown = True
        Me.integerInput1.Size = New System.Drawing.Size(66, 22)
        Me.integerInput1.TabIndex = 7
        Me.integerInput1.Value = 1
        '
        'labelX4
        '
        Me.labelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.labelX4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash
        Me.labelX4.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gray
        Me.labelX4.BackgroundStyle.BorderBottomWidth = 1
        Me.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelX4.ForeColor = System.Drawing.Color.Black
        Me.labelX4.Location = New System.Drawing.Point(134, 9)
        Me.labelX4.Name = "labelX4"
        Me.labelX4.Size = New System.Drawing.Size(120, 23)
        Me.labelX4.TabIndex = 6
        Me.labelX4.Text = "Print"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrintPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPrintPreview.Location = New System.Drawing.Point(11, 14)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(109, 101)
        Me.btnPrintPreview.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrintPreview.TabIndex = 5
        Me.btnPrintPreview.Text = "Print"
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(607, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'Bar16
        '
        Me.Bar16.AccessibleDescription = "Bar16 (Bar16)"
        Me.Bar16.AccessibleName = "Bar16"
        Me.Bar16.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar16.AntiAlias = True
        Me.Bar16.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar16.Dock = System.Windows.Forms.DockStyle.Top
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
        Me.Bar16.Size = New System.Drawing.Size(607, 24)
        Me.Bar16.Stretch = True
        Me.Bar16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar16.TabIndex = 42
        Me.Bar16.TabStop = False
        Me.Bar16.Text = "Bar16"
        '
        'LabelItem10
        '
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.Text = "Report Preview"
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(1, 612)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(7, 6)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(844, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 613)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(851, 6)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 613)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(6, 619)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(846, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
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
        'SideNavItem2
        '
        Me.SideNavItem2.Checked = True
        Me.SideNavItem2.Name = "SideNavItem2"
        Me.SideNavItem2.Panel = Me.SideNavPanel1
        Me.SideNavItem2.Symbol = ""
        Me.SideNavItem2.Text = "Home"
        '
        'SideNavItem4
        '
        Me.SideNavItem4.Name = "SideNavItem4"
        Me.SideNavItem4.Panel = Me.SideNavPanel4
        Me.SideNavItem4.Symbol = "57391"
        Me.SideNavItem4.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem4.Text = "Transactions Entries"
        '
        'SideNavItem5
        '
        Me.SideNavItem5.Name = "SideNavItem5"
        Me.SideNavItem5.Panel = Me.SideNavPanel5
        Me.SideNavItem5.Symbol = ""
        Me.SideNavItem5.Text = "Payroll Runs"
        '
        'SideNavItem6
        '
        Me.SideNavItem6.Name = "SideNavItem6"
        Me.SideNavItem6.Panel = Me.SideNavPanel2
        Me.SideNavItem6.Symbol = "57932"
        Me.SideNavItem6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem6.Text = "Reports"
        '
        'ComboItem13
        '
        Me.ComboItem13.Text = "Employee No"
        '
        'ComboItem14
        '
        Me.ComboItem14.Text = "Last Name"
        '
        'ComboItem15
        '
        Me.ComboItem15.Text = "First Name"
        '
        'ComboItem16
        '
        Me.ComboItem16.Text = "Other Names"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Employee No"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Last Name"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "First Name"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "Other Names"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "Employee No"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "Last Name"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "First Name"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "Other Names"
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
        'ComboItem17
        '
        Me.ComboItem17.Text = "Employee No"
        '
        'ComboItem18
        '
        Me.ComboItem18.Text = "Last Name"
        '
        'ComboItem19
        '
        Me.ComboItem19.Text = "First Name"
        '
        'ComboItem20
        '
        Me.ComboItem20.Text = "Other Names"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "ppdUserReports"
        Me.PrintPreviewDialog1.Visible = False
        '
        'pdSmallPayslips
        '
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
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'frmPaylightMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 682)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPaylightMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pay Light 8.0"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel1.ResumeLayout(False)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel4.ResumeLayout(False)
        Me.SideNavPanel4.PerformLayout()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel5.ResumeLayout(False)
        Me.SideNavPanel5.PerformLayout()
        CType(Me.dGridEmployeeToPay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel2.ResumeLayout(False)
        Me.SideNavPanel2.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel1.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.PerformLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        CType(Me.KryptonSplitContainer2.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer2.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer2.Panel1.PerformLayout()
        CType(Me.KryptonSplitContainer2.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.KryptonSplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer2.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.dGridReports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.dGridPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.integerInput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboSearchBy As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtSearchString As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents lblTotalRecords As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ppdUserReports As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents SideNavPanel4 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem4 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnViewBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSaveBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem14 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem15 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem16 As DevComponents.Editors.ComboItem
    Friend WithEvents lblBatchNumber As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridTransactions As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblBatchTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideNavPanel5 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnPreparePayrun As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnProcessPay As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBankExtracts As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblActiveEmployees As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavItem5 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents ComboItem17 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem18 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem19 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem20 As DevComponents.Editors.ComboItem
    Friend WithEvents dGridEmployeeToPay As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavItem6 As DevComponents.DotNetBar.Controls.SideNavItem
    Private WithEvents imageList1 As ImageList
    Friend WithEvents pdSchedules As Printing.PrintDocument
    Friend WithEvents pdTotals As Printing.PrintDocument
    Friend WithEvents pdSummary As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents pdSmallPayslips As Printing.PrintDocument
    Friend WithEvents pdFormatTwo As Printing.PrintDocument
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents ppd As PrintPreviewDialog
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents pnlPreview As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridPreview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents labelX5 As DevComponents.DotNetBar.LabelX
    Private WithEvents integerInput1 As DevComponents.Editors.IntegerInput
    Private WithEvents labelX4 As DevComponents.DotNetBar.LabelX
    Private WithEvents btnPrintPreview As DevComponents.DotNetBar.ButtonX
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar16 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonSplitContainer2 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Bar8 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents tvReports As TreeView
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshReports As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridReports As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
