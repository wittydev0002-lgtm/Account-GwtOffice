<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategoriesListing
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategoriesListing))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.kryptonSplitContainerHorizontal = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.grd = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dgrdDetails = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnOptions = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelected = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAll = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.kryptonSplitContainerHorizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kryptonSplitContainerHorizontal.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonSplitContainerHorizontal.Panel1.SuspendLayout()
        CType(Me.kryptonSplitContainerHorizontal.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonSplitContainerHorizontal.Panel2.SuspendLayout()
        Me.kryptonSplitContainerHorizontal.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expandablePanel1.SuspendLayout()
        CType(Me.dgrdDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.kryptonSplitContainerHorizontal)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel2.Controls.Add(Me.Bar1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(698, 501)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel2.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel2.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel2.TabIndex = 5
        '
        'kryptonSplitContainerHorizontal
        '
        Me.kryptonSplitContainerHorizontal.Cursor = System.Windows.Forms.Cursors.Default
        Me.kryptonSplitContainerHorizontal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kryptonSplitContainerHorizontal.Location = New System.Drawing.Point(1, 89)
        Me.kryptonSplitContainerHorizontal.Name = "kryptonSplitContainerHorizontal"
        '
        'kryptonSplitContainerHorizontal.Panel1
        '
        Me.kryptonSplitContainerHorizontal.Panel1.Controls.Add(Me.grd)
        Me.kryptonSplitContainerHorizontal.Panel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.kryptonSplitContainerHorizontal.Panel1.Controls.Add(Me.KryptonBorderEdge8)
        Me.kryptonSplitContainerHorizontal.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'kryptonSplitContainerHorizontal.Panel2
        '
        Me.kryptonSplitContainerHorizontal.Panel2.Controls.Add(Me.expandablePanel1)
        Me.kryptonSplitContainerHorizontal.Panel2.Controls.Add(Me.KryptonBorderEdge1)
        Me.kryptonSplitContainerHorizontal.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.kryptonSplitContainerHorizontal.Size = New System.Drawing.Size(696, 411)
        Me.kryptonSplitContainerHorizontal.SplitterDistance = 509
        Me.kryptonSplitContainerHorizontal.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.kryptonSplitContainerHorizontal.TabIndex = 33
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3})
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 0)
        Me.grd.Name = "grd"
        Me.grd.ReadOnly = True
        Me.grd.RowHeadersWidth = 25
        Me.grd.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grd.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grd.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd.Size = New System.Drawing.Size(508, 410)
        Me.grd.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.grd.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.grd.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grd.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.TabIndex = 21
        '
        'Column1
        '
        Me.Column1.HeaderText = "Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Category"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 410)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(508, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(508, 0)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 411)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'expandablePanel1
        '
        Me.expandablePanel1.AutoScroll = True
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.dgrdDetails)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(1, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(181, 411)
        Me.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.expandablePanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile
        Me.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.expandablePanel1.Style.GradientAngle = 90
        Me.expandablePanel1.Style.WordWrap = True
        Me.expandablePanel1.TabIndex = 5
        Me.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.TitleStyle.GradientAngle = 90
        Me.expandablePanel1.TitleStyle.MarginLeft = 6
        Me.expandablePanel1.TitleText = "Sub Categories"
        '
        'dgrdDetails
        '
        Me.dgrdDetails.AllowUserToAddRows = False
        Me.dgrdDetails.AllowUserToDeleteRows = False
        Me.dgrdDetails.ColumnHeadersVisible = False
        Me.dgrdDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dgrdDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrdDetails.Location = New System.Drawing.Point(0, 26)
        Me.dgrdDetails.Name = "dgrdDetails"
        Me.dgrdDetails.ReadOnly = True
        Me.dgrdDetails.RowHeadersWidth = 25
        Me.dgrdDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgrdDetails.Size = New System.Drawing.Size(181, 385)
        Me.dgrdDetails.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dgrdDetails.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dgrdDetails.StateCommon.Background.ColorAngle = 100.0!
        Me.dgrdDetails.StateCommon.Background.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrdDetails.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrdDetails.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrdDetails.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dgrdDetails.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrdDetails.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrdDetails.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.TabIndex = 42
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1, 411)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 30)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(696, 59)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 32
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel3.Location = New System.Drawing.Point(11, 18)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(71, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 26
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(71, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Search for"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(71, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'txtSearchString
        '
        Me.txtSearchString.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnOptions})
        Me.txtSearchString.Location = New System.Drawing.Point(83, 20)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(208, 20)
        Me.txtSearchString.TabIndex = 24
        '
        'btnOptions
        '
        Me.btnOptions.UniqueName = "41E18DF68FB84A5F41E18DF68FB84A5F"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 58)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(696, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 29)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(696, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.ButtonItem1, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(1, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(696, 29)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 30
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
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
        Me.btnDelete.Text = "Delete"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelected, Me.btnPrintAll})
        Me.ButtonItem1.Text = "Print"
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BeginGroup = True
        Me.btnPrintSelected.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelected.Text = "Print Selection"
        '
        'btnPrintAll
        '
        Me.btnPrintAll.BeginGroup = True
        Me.btnPrintAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintAll.Name = "btnPrintAll"
        Me.btnPrintAll.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintAll.Text = "Print Grid"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Text = "Refresh"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(697, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 500)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 500)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 500)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(698, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'frmCategoriesListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 501)
        Me.Controls.Add(Me.KryptonPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCategoriesListing"
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
        Me.StateCommon.Border.Width = 1
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Categories Setup"
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.kryptonSplitContainerHorizontal.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonSplitContainerHorizontal.Panel1.ResumeLayout(False)
        Me.kryptonSplitContainerHorizontal.Panel1.PerformLayout()
        CType(Me.kryptonSplitContainerHorizontal.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonSplitContainerHorizontal.Panel2.ResumeLayout(False)
        Me.kryptonSplitContainerHorizontal.Panel2.PerformLayout()
        CType(Me.kryptonSplitContainerHorizontal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonSplitContainerHorizontal.ResumeLayout(False)
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expandablePanel1.ResumeLayout(False)
        CType(Me.dgrdDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelected As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAll As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnOptions As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents kryptonSplitContainerHorizontal As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents grd As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgrdDetails As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class

