<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodes
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodes))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnCreate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEmployeesWith = New DevComponents.DotNetBar.ButtonItem()
        Me.btnReset = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgrdDetails = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonSeparator1 = New ComponentFactory.Krypton.Toolkit.KryptonSeparator()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnFindNext = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnFind = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchText = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnOptions = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dgrdDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnCreate, Me.btnEmployeesWith, Me.btnReset, Me.btnPrint, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(768, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 16
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnCreate
        '
        Me.btnCreate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCreate.Image = CType(resources.GetObject("btnCreate.Image"), System.Drawing.Image)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCreate.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnCreate.Text = "Configure"
        Me.btnCreate.Tooltip = "Configure payroll code"
        '
        'btnEmployeesWith
        '
        Me.btnEmployeesWith.BeginGroup = True
        Me.btnEmployeesWith.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEmployeesWith.Image = CType(resources.GetObject("btnEmployeesWith.Image"), System.Drawing.Image)
        Me.btnEmployeesWith.Name = "btnEmployeesWith"
        Me.btnEmployeesWith.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEmployeesWith.Text = "Show Usage"
        Me.btnEmployeesWith.Tooltip = "Configure payroll code"
        '
        'btnReset
        '
        Me.btnReset.BeginGroup = True
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReset.SymbolSize = 16.0!
        Me.btnReset.Text = "Reset"
        Me.btnReset.Tooltip = "Reset code to nothing"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SymbolSize = 16.0!
        Me.btnPrint.Text = "Print"
        Me.btnPrint.Tooltip = "Print codes"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.SymbolSize = 16.0!
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.Tooltip = "Refresh codes listing"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(768, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dgrdDetails)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.Label1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonPanel1.Location = New System.Drawing.Point(518, 26)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(250, 408)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 23
        '
        'dgrdDetails
        '
        Me.dgrdDetails.AllowUserToAddRows = False
        Me.dgrdDetails.AllowUserToDeleteRows = False
        Me.dgrdDetails.AllowUserToResizeRows = False
        Me.dgrdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgrdDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.Column8})
        Me.dgrdDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrdDetails.Location = New System.Drawing.Point(1, 25)
        Me.dgrdDetails.Name = "dgrdDetails"
        Me.dgrdDetails.ReadOnly = True
        Me.dgrdDetails.RowHeadersVisible = False
        Me.dgrdDetails.RowHeadersWidth = 25
        Me.dgrdDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrdDetails.Size = New System.Drawing.Size(249, 383)
        Me.dgrdDetails.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dgrdDetails.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dgrdDetails.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrdDetails.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrdDetails.StateCommon.HeaderColumn.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgrdDetails.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgrdDetails.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dgrdDetails.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dgrdDetails.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.TabIndex = 39
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(1, 24)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(249, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(249, 24)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Full Code Information"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(1, 408)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonSeparator1
        '
        Me.KryptonSeparator1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonSeparator1.Location = New System.Drawing.Point(513, 26)
        Me.KryptonSeparator1.Name = "KryptonSeparator1"
        Me.KryptonSeparator1.Size = New System.Drawing.Size(5, 408)
        Me.KryptonSeparator1.TabIndex = 24
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(512, 26)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 408)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.btnFindNext)
        Me.KryptonPanel3.Controls.Add(Me.btnFind)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel3.Controls.Add(Me.txtSearchText)
        Me.KryptonPanel3.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 26)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(512, 40)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.TabIndex = 27
        '
        'btnFindNext
        '
        Me.btnFindNext.AutoSize = True
        Me.btnFindNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFindNext.Location = New System.Drawing.Point(408, 9)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(62, 22)
        Me.btnFindNext.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnFindNext.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFindNext.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFindNext.StateCommon.Border.Rounding = 0
        Me.btnFindNext.TabIndex = 6
        Me.btnFindNext.Values.Image = CType(resources.GetObject("btnFindNext.Values.Image"), System.Drawing.Image)
        Me.btnFindNext.Values.Text = "Search"
        '
        'btnFind
        '
        Me.btnFind.AutoSize = True
        Me.btnFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFind.Location = New System.Drawing.Point(341, 9)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(62, 22)
        Me.btnFind.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnFind.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFind.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFind.StateCommon.Border.Rounding = 0
        Me.btnFind.TabIndex = 5
        Me.btnFind.Values.Image = CType(resources.GetObject("btnFind.Values.Image"), System.Drawing.Image)
        Me.btnFind.Values.Text = "Search"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 39)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(512, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'txtSearchText
        '
        Me.txtSearchText.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnOptions})
        Me.txtSearchText.Location = New System.Drawing.Point(150, 11)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(185, 20)
        Me.txtSearchText.TabIndex = 1
        '
        'btnOptions
        '
        Me.btnOptions.UniqueName = "41E18DF68FB84A5F41E18DF68FB84A5F"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.Items.AddRange(New Object() {"Employee Number", "Surname", "First Name", "Other Names", "Id Number"})
        Me.cboSearchBy.Location = New System.Drawing.Point(21, 10)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchBy.Size = New System.Drawing.Size(119, 21)
        Me.cboSearchBy.TabIndex = 4
        Me.cboSearchBy.Text = "Search by"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersVisible = False
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(512, 368)
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
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.TabIndex = 39
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "No."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 55
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Name"
        Me.Column2.MinimumWidth = 200
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Type"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 63
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Tax"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 56
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Display"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 78
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "YTD Code"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 93
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Mapped Ledger"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 123
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.dGrid)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 66)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(512, 368)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel2.TabIndex = 42
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column8.HeaderText = "Info"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'frmCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 434)
        Me.Controls.Add(Me.KryptonPanel2)
        Me.Controls.Add(Me.KryptonPanel3)
        Me.Controls.Add(Me.KryptonBorderEdge11)
        Me.Controls.Add(Me.KryptonSeparator1)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Name = "frmCodes"
        Me.Text = "Codes"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.dgrdDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnCreate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnReset As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonSeparator1 As ComponentFactory.Krypton.Toolkit.KryptonSeparator
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSearchText As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnOptions As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnEmployeesWith As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFindNext As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnFind As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgrdDetails As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
