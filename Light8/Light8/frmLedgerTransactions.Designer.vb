<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLedgerTransactions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLedgerTransactions))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Bar11 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOpenExpenses = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOpenJournals = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.splitMain = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.SuperTabControl3 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridLedgers = New AdvancedDataGridViewControl.AdvancedDatagridview()
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
        Me.btnRestartAccount = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar11, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(710, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(709, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 471)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 471)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
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
        'Bar11
        '
        Me.Bar11.AntiAlias = True
        Me.Bar11.BackColor = System.Drawing.Color.Transparent
        Me.Bar11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar11.IsMaximized = False
        Me.Bar11.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem17, Me.btnRefresh, Me.ButtonItem1, Me.btnRestartAccount})
        Me.Bar11.Location = New System.Drawing.Point(1, 1)
        Me.Bar11.Name = "Bar11"
        Me.Bar11.RoundCorners = False
        Me.Bar11.Size = New System.Drawing.Size(708, 25)
        Me.Bar11.Stretch = True
        Me.Bar11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar11.TabIndex = 7
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
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Text = "Refresh"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.BeginGroup = True
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnOpenExpenses, Me.btnOpenJournals})
        Me.ButtonItem1.Text = "View and Post ..."
        '
        'btnOpenExpenses
        '
        Me.btnOpenExpenses.BeginGroup = True
        Me.btnOpenExpenses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOpenExpenses.Name = "btnOpenExpenses"
        Me.btnOpenExpenses.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnOpenExpenses.Text = "Open Expenses"
        '
        'btnOpenJournals
        '
        Me.btnOpenJournals.BeginGroup = True
        Me.btnOpenJournals.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOpenJournals.Name = "btnOpenJournals"
        Me.btnOpenJournals.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnOpenJournals.Text = "Open Journals"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(708, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'splitMain
        '
        Me.splitMain.BackColor = System.Drawing.Color.White
        Me.splitMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Location = New System.Drawing.Point(1, 27)
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
        Me.splitMain.Size = New System.Drawing.Size(708, 445)
        Me.splitMain.SplitterDistance = 534
        Me.splitMain.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.StateCommon.Separator.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.splitMain.StateCommon.Separator.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.splitMain.TabIndex = 9
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
        Me.SuperTabControl3.Size = New System.Drawing.Size(534, 388)
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
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(534, 363)
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
        Me.KryptonPanel5.Size = New System.Drawing.Size(534, 363)
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
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridLedgers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dGridLedgers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewImageColumn4})
        Me.dGridLedgers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridLedgers.Location = New System.Drawing.Point(1, 24)
        Me.dGridLedgers.Name = "dGridLedgers"
        Me.dGridLedgers.ReadOnly = True
        Me.dGridLedgers.RowHeadersWidth = 25
        Me.dGridLedgers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridLedgers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridLedgers.Size = New System.Drawing.Size(532, 311)
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn22.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn22.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 66
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn23.DefaultCellStyle = DataGridViewCellStyle6
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
        Me.DataGridViewTextBoxColumn24.Width = 47
        '
        'DataGridViewImageColumn4
        '
        Me.DataGridViewImageColumn4.HeaderText = ""
        Me.DataGridViewImageColumn4.Image = CType(resources.GetObject("DataGridViewImageColumn4.Image"), System.Drawing.Image)
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
        Me.Bar12.Location = New System.Drawing.Point(1, 335)
        Me.Bar12.Name = "Bar12"
        Me.Bar12.PaddingBottom = 3
        Me.Bar12.PaddingTop = 3
        Me.Bar12.Size = New System.Drawing.Size(532, 27)
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
        Me.Bar13.Size = New System.Drawing.Size(532, 23)
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
        Me.KryptonPanel4.Size = New System.Drawing.Size(534, 57)
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
        Me.dpEndDate.Size = New System.Drawing.Size(96, 20)
        Me.dpEndDate.TabIndex = 162
        '
        'dpStartDate
        '
        Me.dpStartDate.BackColor = System.Drawing.Color.White
        Me.dpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartDate.Location = New System.Drawing.Point(81, 17)
        Me.dpStartDate.Name = "dpStartDate"
        Me.dpStartDate.Size = New System.Drawing.Size(99, 20)
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
        Me.expandablePanel1.Size = New System.Drawing.Size(169, 445)
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
        Me.tvAccounts.Size = New System.Drawing.Size(169, 419)
        Me.tvAccounts.TabIndex = 4
        '
        'btnRestartAccount
        '
        Me.btnRestartAccount.BeginGroup = True
        Me.btnRestartAccount.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRestartAccount.Name = "btnRestartAccount"
        Me.btnRestartAccount.Text = "Re-start Selected"
        '
        'frmLedgerTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 472)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar11)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLedgerTransactions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Ledger Entries"
        CType(Me.Bar11, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents LabelItem21 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Bar11 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnOpenExpenses As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnOpenJournals As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents splitMain As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents SuperTabControl3 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridLedgers As AdvancedDataGridViewControl.AdvancedDatagridview
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
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents btnFindData As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents tvAccounts As System.Windows.Forms.TreeView
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnRestartAccount As DevComponents.DotNetBar.ButtonItem
End Class
