<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiagnosisCodesListing
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagnosisCodesListing))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel21 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel32 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge48 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel21 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtFullDescription = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.lblCount = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.pb1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel21.SuspendLayout()
        CType(Me.KryptonPanel32, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel32.SuspendLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonSplitContainer1)
        Me.KryptonPanel.Controls.Add(Me.Bar1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.Bar5)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(872, 591)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(1, 26)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.dGrid)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonPanel1)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color2 = System.Drawing.Color.White
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.txtFullDescription)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(870, 544)
        Me.KryptonSplitContainer1.SplitterDistance = 669
        Me.KryptonSplitContainer1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color2 = System.Drawing.Color.WhiteSmoke
        Me.KryptonSplitContainer1.TabIndex = 157
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.Column1})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 63)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(668, 481)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 2
        '
        'Code
        '
        Me.Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        Me.Code.Width = 66
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Short Description"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel21)
        Me.KryptonPanel1.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel32)
        Me.KryptonPanel1.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(668, 63)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 1
        '
        'KryptonPanel21
        '
        Me.KryptonPanel21.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel21.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel21.Location = New System.Drawing.Point(226, 22)
        Me.KryptonPanel21.Name = "KryptonPanel21"
        Me.KryptonPanel21.Size = New System.Drawing.Size(79, 20)
        Me.KryptonPanel21.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel21.TabIndex = 205
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(79, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(79, 20)
        Me.KryptonLabel12.TabIndex = 0
        Me.KryptonLabel12.Values.Text = "Search for ..."
        '
        'txtSearchString
        '
        Me.txtSearchString.Location = New System.Drawing.Point(307, 22)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(160, 20)
        Me.txtSearchString.TabIndex = 202
        '
        'KryptonPanel32
        '
        Me.KryptonPanel32.Controls.Add(Me.KryptonBorderEdge48)
        Me.KryptonPanel32.Controls.Add(Me.KryptonLabel21)
        Me.KryptonPanel32.Location = New System.Drawing.Point(16, 22)
        Me.KryptonPanel32.Name = "KryptonPanel32"
        Me.KryptonPanel32.Size = New System.Drawing.Size(79, 20)
        Me.KryptonPanel32.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel32.TabIndex = 204
        '
        'KryptonBorderEdge48
        '
        Me.KryptonBorderEdge48.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge48.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge48.Name = "KryptonBorderEdge48"
        Me.KryptonBorderEdge48.Size = New System.Drawing.Size(79, 1)
        Me.KryptonBorderEdge48.Text = "KryptonBorderEdge48"
        '
        'KryptonLabel21
        '
        Me.KryptonLabel21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel21.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel21.Name = "KryptonLabel21"
        Me.KryptonLabel21.Size = New System.Drawing.Size(79, 20)
        Me.KryptonLabel21.TabIndex = 0
        Me.KryptonLabel21.Values.Text = "Search by ..."
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.Items.AddRange(New Object() {"Code", "Description"})
        Me.cboSearchBy.Location = New System.Drawing.Point(97, 21)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchBy.Size = New System.Drawing.Size(119, 21)
        Me.cboSearchBy.TabIndex = 203
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 62)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(668, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(668, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 544)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'txtFullDescription
        '
        Me.txtFullDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFullDescription.Location = New System.Drawing.Point(1, 0)
        Me.txtFullDescription.Multiline = True
        Me.txtFullDescription.Name = "txtFullDescription"
        Me.txtFullDescription.ReadOnly = True
        Me.txtFullDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFullDescription.Size = New System.Drawing.Size(195, 544)
        Me.txtFullDescription.StateCommon.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullDescription.TabIndex = 1
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 544)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.lblCount, Me.LabelItem1, Me.pb1})
        Me.Bar1.Location = New System.Drawing.Point(1, 570)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(870, 20)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 156
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 6
        Me.LabelItem2.PaddingRight = 6
        Me.LabelItem2.Text = "Count :"
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.PaddingLeft = 6
        Me.lblCount.PaddingRight = 6
        Me.lblCount.Text = "0"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
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
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1, 25)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(870, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.BackColor = System.Drawing.Color.Transparent
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnPrint, Me.btnImport, Me.btnRefresh})
        Me.Bar5.Location = New System.Drawing.Point(1, 0)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(870, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 154
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNew.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.Text = "Print"
        '
        'btnImport
        '
        Me.btnImport.BeginGroup = True
        Me.btnImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImport.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnImport.Text = "Import"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Text = "Refresh"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(871, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 590)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 590)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 590)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(872, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmDiagnosisCodesListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 591)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiagnosisCodesListing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Diagnosis Codes"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel1.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.PerformLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel21.ResumeLayout(False)
        Me.KryptonPanel21.PerformLayout()
        CType(Me.KryptonPanel32, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel32.ResumeLayout(False)
        Me.KryptonPanel32.PerformLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents pb1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel21 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel32 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge48 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel21 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCount As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtFullDescription As ComponentFactory.Krypton.Toolkit.KryptonTextBox
End Class
