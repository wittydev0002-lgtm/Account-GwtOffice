<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssetsMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssetsMain))
        Me.btnPrintSeletedRowQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintQuoteList = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridAssets = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboFilter = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.btnNewAsset = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditAsset = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteAsset = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelected = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAssetList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDisposeAsset = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshAsset = New DevComponents.DotNetBar.ButtonItem()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.dGridDispensing = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.btnCategories = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.dGridAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.cboFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridDispensing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrintSeletedRowQuote
        '
        Me.btnPrintSeletedRowQuote.BeginGroup = True
        Me.btnPrintSeletedRowQuote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSeletedRowQuote.Name = "btnPrintSeletedRowQuote"
        Me.btnPrintSeletedRowQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSeletedRowQuote.SymbolSize = 16.0!
        Me.btnPrintSeletedRowQuote.Text = "Print Selected Row"
        '
        'btnPrintQuoteList
        '
        Me.btnPrintQuoteList.BeginGroup = True
        Me.btnPrintQuoteList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintQuoteList.Name = "btnPrintQuoteList"
        Me.btnPrintQuoteList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintQuoteList.SymbolSize = 16.0!
        Me.btnPrintQuoteList.Text = "Print Entire Sheet"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.ProgressBarItem1})
        Me.Bar3.Location = New System.Drawing.Point(0, 621)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(934, 20)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 10
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Stretch = True
        Me.LabelItem3.Text = "Great Wits Business Light Asset Management 8.0"
        '
        'ProgressBarItem1
        '
        '
        '
        '
        Me.ProgressBarItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarItem1.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem2})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(934, 621)
        Me.SideNav1.TabIndex = 11
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.dGridAssets)
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Controls.Add(Me.Bar5)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(78, 31)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Size = New System.Drawing.Size(855, 589)
        Me.SideNavPanel1.TabIndex = 2
        '
        'dGridAssets
        '
        Me.dGridAssets.AllowUserToAddRows = False
        Me.dGridAssets.AllowUserToDeleteRows = False
        Me.dGridAssets.AllowUserToResizeRows = False
        Me.dGridAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridAssets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dGridAssets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridAssets.Location = New System.Drawing.Point(0, 81)
        Me.dGridAssets.Name = "dGridAssets"
        Me.dGridAssets.ReadOnly = True
        Me.dGridAssets.RowHeadersWidth = 25
        Me.dGridAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridAssets.Size = New System.Drawing.Size(855, 508)
        Me.dGridAssets.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridAssets.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridAssets.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAssets.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridAssets.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridAssets.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridAssets.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridAssets.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridAssets.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridAssets.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridAssets.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAssets.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridAssets.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridAssets.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridAssets.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAssets.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAssets.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridAssets.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridAssets.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAssets.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAssets.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAssets.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAssets.TabIndex = 155
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Asset Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 101
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Manufacturer"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 111
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Model"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 69
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Allocated To"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 105
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Location"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 83
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Category"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 89
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel2.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel2.Controls.Add(Me.cboFilter)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 30)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(855, 51)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel2.TabIndex = 154
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(855, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(321, 16)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(262, 20)
        Me.txtSearchString.TabIndex = 3
        '
        'cboFilter
        '
        Me.cboFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.DropDownWidth = 140
        Me.cboFilter.ForeColor = System.Drawing.Color.Black
        Me.cboFilter.Items.AddRange(New Object() {"CODE", "NAME", "MANUFACTURER", "LOCATION", "CATEGORY", "OWNER"})
        Me.cboFilter.Location = New System.Drawing.Point(98, 15)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.cboFilter.Size = New System.Drawing.Size(140, 21)
        Me.cboFilter.TabIndex = 2
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(244, 14)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(76, 22)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 1
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(76, 21)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Search for"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(76, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(21, 14)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(76, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 0
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(76, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Search filter"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(76, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 29)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(855, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.BackColor = System.Drawing.Color.Transparent
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewAsset, Me.btnEditAsset, Me.btnDeleteAsset, Me.btnCategories, Me.btnPrint, Me.btnDisposeAsset, Me.btnRefreshAsset})
        Me.Bar5.Location = New System.Drawing.Point(0, 0)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(855, 29)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 153
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnNewAsset
        '
        Me.btnNewAsset.Image = CType(resources.GetObject("btnNewAsset.Image"), System.Drawing.Image)
        Me.btnNewAsset.Name = "btnNewAsset"
        Me.btnNewAsset.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewAsset.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewAsset.Text = "New"
        '
        'btnEditAsset
        '
        Me.btnEditAsset.Image = CType(resources.GetObject("btnEditAsset.Image"), System.Drawing.Image)
        Me.btnEditAsset.Name = "btnEditAsset"
        Me.btnEditAsset.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditAsset.Text = "Edit"
        '
        'btnDeleteAsset
        '
        Me.btnDeleteAsset.BeginGroup = True
        Me.btnDeleteAsset.Image = CType(resources.GetObject("btnDeleteAsset.Image"), System.Drawing.Image)
        Me.btnDeleteAsset.Name = "btnDeleteAsset"
        Me.btnDeleteAsset.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelected, Me.btnPrintAssetList})
        Me.btnPrint.Text = "Print"
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BeginGroup = True
        Me.btnPrintSelected.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelected.SymbolSize = 16.0!
        Me.btnPrintSelected.Text = "Print Selected Asset Details"
        '
        'btnPrintAssetList
        '
        Me.btnPrintAssetList.BeginGroup = True
        Me.btnPrintAssetList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintAssetList.Name = "btnPrintAssetList"
        Me.btnPrintAssetList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintAssetList.SymbolSize = 16.0!
        Me.btnPrintAssetList.Text = "Print Asset Listing"
        '
        'btnDisposeAsset
        '
        Me.btnDisposeAsset.BeginGroup = True
        Me.btnDisposeAsset.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDisposeAsset.Image = CType(resources.GetObject("btnDisposeAsset.Image"), System.Drawing.Image)
        Me.btnDisposeAsset.Name = "btnDisposeAsset"
        Me.btnDisposeAsset.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDisposeAsset.Text = "Dispose"
        '
        'btnRefreshAsset
        '
        Me.btnRefreshAsset.BeginGroup = True
        Me.btnRefreshAsset.Image = CType(resources.GetObject("btnRefreshAsset.Image"), System.Drawing.Image)
        Me.btnRefreshAsset.Name = "btnRefreshAsset"
        Me.btnRefreshAsset.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshAsset.Text = "Refresh"
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
        'dGridDispensing
        '
        Me.dGridDispensing.AllowUserToAddRows = False
        Me.dGridDispensing.AllowUserToDeleteRows = False
        Me.dGridDispensing.AllowUserToResizeRows = False
        Me.dGridDispensing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridDispensing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridDispensing.Location = New System.Drawing.Point(0, 81)
        Me.dGridDispensing.Name = "dGridDispensing"
        Me.dGridDispensing.ReadOnly = True
        Me.dGridDispensing.RowHeadersVisible = False
        Me.dGridDispensing.RowHeadersWidth = 25
        Me.dGridDispensing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridDispensing.Size = New System.Drawing.Size(955, 608)
        Me.dGridDispensing.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridDispensing.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridDispensing.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridDispensing.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridDispensing.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridDispensing.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridDispensing.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridDispensing.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridDispensing.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridDispensing.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridDispensing.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridDispensing.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridDispensing.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridDispensing.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridDispensing.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridDispensing.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridDispensing.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridDispensing.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridDispensing.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridDispensing.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridDispensing.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridDispensing.TabIndex = 155
        '
        'btnCategories
        '
        Me.btnCategories.BeginGroup = True
        Me.btnCategories.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCategories.Image = CType(resources.GetObject("btnCategories.Image"), System.Drawing.Image)
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCategories.Text = "&Categories"
        '
        'frmAssetsMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 641)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssetsMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Business Light Edge Asset Management"
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.dGridAssets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.cboFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridDispensing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrintSeletedRowQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintQuoteList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewAsset As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditAsset As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteAsset As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelected As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAssetList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshAsset As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboFilter As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridAssets As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dGridDispensing As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnDisposeAsset As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCategories As DevComponents.DotNetBar.ButtonItem
End Class
