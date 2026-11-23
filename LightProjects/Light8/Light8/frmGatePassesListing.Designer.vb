<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGatePassesListing
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGatePassesListing))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridPasses = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndTo = New System.Windows.Forms.DateTimePicker()
        Me.dpStartFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnGo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboUser = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnNewPass = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditPass = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeletePass = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelectedPass = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllPass = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshPasses = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.dGridPasses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.cboUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.dGridPasses)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel.Controls.Add(Me.Bar3)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(747, 315)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 0
        '
        'dGridPasses
        '
        Me.dGridPasses.AllowUserToAddRows = False
        Me.dGridPasses.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridPasses.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dGridPasses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewImageColumn1, Me.Column7})
        Me.dGridPasses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridPasses.Location = New System.Drawing.Point(0, 84)
        Me.dGridPasses.Name = "dGridPasses"
        Me.dGridPasses.ReadOnly = True
        Me.dGridPasses.RowHeadersWidth = 25
        Me.dGridPasses.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridPasses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridPasses.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridPasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPasses.Size = New System.Drawing.Size(747, 231)
        Me.dGridPasses.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridPasses.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridPasses.StateCommon.Background.ColorAngle = 100.0!
        Me.dGridPasses.StateCommon.Background.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPasses.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPasses.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPasses.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridPasses.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridPasses.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPasses.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPasses.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPasses.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPasses.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridPasses.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridPasses.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPasses.TabIndex = 163
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle8.NullValue = "0"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn1.HeaderText = "Doc No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 91
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 96
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn3.HeaderText = "Collecting Agent"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 129
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Pass Type"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Visible = False
        Me.DataGridViewImageColumn1.Width = 30
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.Image = CType(resources.GetObject("Column7.Image"), System.Drawing.Image)
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 25
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel7.Controls.Add(Me.dpEndTo)
        Me.KryptonPanel7.Controls.Add(Me.dpStartFrom)
        Me.KryptonPanel7.Controls.Add(Me.btnGo)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel7.Controls.Add(Me.cboUser)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(0, 29)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(747, 55)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.TabIndex = 162
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(747, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'dpEndTo
        '
        Me.dpEndTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndTo.ForeColor = System.Drawing.Color.Black
        Me.dpEndTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndTo.Location = New System.Drawing.Point(276, 18)
        Me.dpEndTo.Name = "dpEndTo"
        Me.dpEndTo.Size = New System.Drawing.Size(109, 20)
        Me.dpEndTo.TabIndex = 5
        '
        'dpStartFrom
        '
        Me.dpStartFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartFrom.ForeColor = System.Drawing.Color.Black
        Me.dpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFrom.Location = New System.Drawing.Point(85, 18)
        Me.dpStartFrom.Name = "dpStartFrom"
        Me.dpStartFrom.Size = New System.Drawing.Size(105, 20)
        Me.dpStartFrom.TabIndex = 10
        '
        'btnGo
        '
        Me.btnGo.AutoSize = True
        Me.btnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnGo.ForeColor = System.Drawing.Color.Black
        Me.btnGo.Location = New System.Drawing.Point(673, 16)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(47, 22)
        Me.btnGo.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnGo.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnGo.StateCommon.Back.ColorAngle = 100.0!
        Me.btnGo.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnGo.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnGo.StateCommon.Border.Rounding = 0
        Me.btnGo.TabIndex = 144
        Me.btnGo.Values.Image = CType(resources.GetObject("btnGo.Values.Image"), System.Drawing.Image)
        Me.btnGo.Values.Text = "&Run"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(395, 17)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(64, 21)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 154
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(64, 20)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "View for"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(64, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'cboUser
        '
        Me.cboUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.DropDownWidth = 138
        Me.cboUser.ForeColor = System.Drawing.Color.Black
        Me.cboUser.Location = New System.Drawing.Point(460, 17)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboUser.Size = New System.Drawing.Size(208, 21)
        Me.cboUser.TabIndex = 138
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 54)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(747, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(213, 17)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(62, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 152
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(62, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Date to"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(62, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(17, 17)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(67, 21)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 153
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(67, 20)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Date from"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(67, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.BackColor = System.Drawing.Color.Transparent
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewPass, Me.btnEditPass, Me.btnDeletePass, Me.ButtonItem5, Me.btnRefreshPasses})
        Me.Bar3.Location = New System.Drawing.Point(0, 0)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.PaddingBottom = 3
        Me.Bar3.PaddingLeft = 3
        Me.Bar3.PaddingRight = 3
        Me.Bar3.PaddingTop = 3
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(747, 29)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 160
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnNewPass
        '
        Me.btnNewPass.Image = CType(resources.GetObject("btnNewPass.Image"), System.Drawing.Image)
        Me.btnNewPass.Name = "btnNewPass"
        Me.btnNewPass.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewPass.Text = "New"
        '
        'btnEditPass
        '
        Me.btnEditPass.Image = CType(resources.GetObject("btnEditPass.Image"), System.Drawing.Image)
        Me.btnEditPass.Name = "btnEditPass"
        Me.btnEditPass.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditPass.Text = "Edit"
        '
        'btnDeletePass
        '
        Me.btnDeletePass.BeginGroup = True
        Me.btnDeletePass.Image = CType(resources.GetObject("btnDeletePass.Image"), System.Drawing.Image)
        Me.btnDeletePass.Name = "btnDeletePass"
        Me.btnDeletePass.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeletePass.Text = "Delete"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Image = CType(resources.GetObject("ButtonItem5.Image"), System.Drawing.Image)
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelectedPass, Me.btnPrintAllPass})
        Me.ButtonItem5.Text = "Print"
        '
        'btnPrintSelectedPass
        '
        Me.btnPrintSelectedPass.BeginGroup = True
        Me.btnPrintSelectedPass.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelectedPass.Name = "btnPrintSelectedPass"
        Me.btnPrintSelectedPass.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelectedPass.Text = "Print Selection"
        '
        'btnPrintAllPass
        '
        Me.btnPrintAllPass.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintAllPass.Name = "btnPrintAllPass"
        Me.btnPrintAllPass.Text = "Print Grid"
        '
        'btnRefreshPasses
        '
        Me.btnRefreshPasses.BeginGroup = True
        Me.btnRefreshPasses.Image = CType(resources.GetObject("btnRefreshPasses.Image"), System.Drawing.Image)
        Me.btnRefreshPasses.Name = "btnRefreshPasses"
        Me.btnRefreshPasses.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshPasses.Text = "Refresh"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'frmExitPasses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 315)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "frmExitPasses"
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.Text = "Exit Passes"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.dGridPasses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.cboUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewPass As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditPass As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeletePass As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelectedPass As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllPass As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshPasses As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGo As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboUser As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridPasses As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewImageColumn
End Class
