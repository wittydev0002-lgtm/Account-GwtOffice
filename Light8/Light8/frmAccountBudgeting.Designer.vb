<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountBudgeting
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountBudgeting))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotal = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnOK = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.lblFinyear = New DevComponents.DotNetBar.LabelItem()
        Me.btnLoad = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblBranches = New System.Windows.Forms.Label()
        Me.cboBranches = New MTGCComboBox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblCostCode = New System.Windows.Forms.Label()
        Me.cboCostCode = New MTGCComboBox()
        Me.lblDepartmentCode = New System.Windows.Forms.Label()
        Me.cboDepartment = New MTGCComboBox()
        Me.KryptonPanel67 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge61 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel26 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel65 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge59 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel24 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel67, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel67.SuspendLayout()
        CType(Me.KryptonPanel65, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel65.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 511)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(560, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(559, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 511)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 511)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(558, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.Bar2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Controls.Add(Me.btnLoad)
        Me.KryptonPanel1.Controls.Add(Me.lblBranches)
        Me.KryptonPanel1.Controls.Add(Me.cboBranches)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.lblCostCode)
        Me.KryptonPanel1.Controls.Add(Me.cboCostCode)
        Me.KryptonPanel1.Controls.Add(Me.lblDepartmentCode)
        Me.KryptonPanel1.Controls.Add(Me.cboDepartment)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel67)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel65)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(558, 510)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 166
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 134)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Padding = New System.Windows.Forms.Padding(12)
        Me.KryptonPanel3.Size = New System.Drawing.Size(558, 354)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 181
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.White
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dGrid)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(534, 330)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 165
        Me.KryptonGroupBox1.Text = "Periods"
        Me.KryptonGroupBox1.Values.Heading = "Periods"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.Size = New System.Drawing.Size(532, 307)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dGrid.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Period"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 69
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "Amount"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 77
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Comments"
        Me.Column3.MaxInputLength = 150
        Me.Column3.Name = "Column3"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.lblTotal})
        Me.Bar2.Location = New System.Drawing.Point(0, 488)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 3
        Me.Bar2.PaddingLeft = 12
        Me.Bar2.PaddingRight = 12
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(558, 22)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 180
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Financial year total"
        '
        'lblTotal
        '
        Me.lblTotal.BeginGroup = True
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.PaddingLeft = 6
        Me.lblTotal.PaddingRight = 6
        Me.lblTotal.Text = "0.00"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(558, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnOK, Me.btnDelete, Me.btnPrint, Me.lblFinyear})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(558, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 179
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnOK
        '
        Me.btnOK.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Text = "&Save and close"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "&Delete"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "&Print"
        '
        'lblFinyear
        '
        Me.lblFinyear.BeginGroup = True
        Me.lblFinyear.Name = "lblFinyear"
        Me.lblFinyear.PaddingRight = 20
        Me.lblFinyear.Stretch = True
        Me.lblFinyear.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnLoad
        '
        Me.btnLoad.AutoSize = True
        Me.btnLoad.BackColor = System.Drawing.Color.White
        Me.btnLoad.ForeColor = System.Drawing.Color.Black
        Me.btnLoad.Location = New System.Drawing.Point(141, 106)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(83, 25)
        Me.btnLoad.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnLoad.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnLoad.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnLoad.StateCommon.Border.Rounding = 0
        Me.btnLoad.TabIndex = 176
        Me.btnLoad.Values.Text = "&Load budgets"
        '
        'lblBranches
        '
        Me.lblBranches.BackColor = System.Drawing.Color.White
        Me.lblBranches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBranches.ForeColor = System.Drawing.Color.Black
        Me.lblBranches.Location = New System.Drawing.Point(454, 38)
        Me.lblBranches.Name = "lblBranches"
        Me.lblBranches.Size = New System.Drawing.Size(87, 21)
        Me.lblBranches.TabIndex = 174
        Me.lblBranches.Text = "0"
        Me.lblBranches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBranches
        '
        Me.cboBranches.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboBranches.ArrowColor = System.Drawing.Color.Black
        Me.cboBranches.BackColor = System.Drawing.Color.White
        Me.cboBranches.BindedControl = CType(resources.GetObject("cboBranches.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboBranches.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboBranches.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBranches.ColumnNum = 1
        Me.cboBranches.ColumnWidth = "121"
        Me.cboBranches.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboBranches.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboBranches.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboBranches.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboBranches.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboBranches.DisplayMember = "Text"
        Me.cboBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboBranches.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboBranches.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboBranches.DropDownForeColor = System.Drawing.Color.Black
        Me.cboBranches.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboBranches.DropDownWidth = 141
        Me.cboBranches.ForeColor = System.Drawing.Color.Black
        Me.cboBranches.GridLineColor = System.Drawing.Color.LightGray
        Me.cboBranches.GridLineHorizontal = False
        Me.cboBranches.GridLineVertical = False
        Me.cboBranches.HighlightBorderColor = System.Drawing.Color.Gray
        Me.cboBranches.HighlightBorderOnMouseEvents = True
        Me.cboBranches.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboBranches.Location = New System.Drawing.Point(141, 38)
        Me.cboBranches.ManagingFastMouseMoving = True
        Me.cboBranches.ManagingFastMouseMovingInterval = 30
        Me.cboBranches.Name = "cboBranches"
        Me.cboBranches.NormalBorderColor = System.Drawing.Color.Gray
        Me.cboBranches.SelectedItem = Nothing
        Me.cboBranches.SelectedValue = Nothing
        Me.cboBranches.Size = New System.Drawing.Size(311, 21)
        Me.cboBranches.TabIndex = 173
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(17, 39)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(123, 20)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 172
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(123, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(123, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Branch"
        '
        'lblCostCode
        '
        Me.lblCostCode.BackColor = System.Drawing.Color.White
        Me.lblCostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostCode.ForeColor = System.Drawing.Color.Black
        Me.lblCostCode.Location = New System.Drawing.Point(454, 60)
        Me.lblCostCode.Name = "lblCostCode"
        Me.lblCostCode.Size = New System.Drawing.Size(87, 21)
        Me.lblCostCode.TabIndex = 171
        Me.lblCostCode.Text = "0"
        Me.lblCostCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCostCode
        '
        Me.cboCostCode.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCostCode.ArrowColor = System.Drawing.Color.Black
        Me.cboCostCode.BackColor = System.Drawing.Color.White
        Me.cboCostCode.BindedControl = CType(resources.GetObject("cboCostCode.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboCostCode.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboCostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCostCode.ColumnNum = 1
        Me.cboCostCode.ColumnWidth = "121"
        Me.cboCostCode.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCostCode.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboCostCode.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboCostCode.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboCostCode.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboCostCode.DisplayMember = "Text"
        Me.cboCostCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboCostCode.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboCostCode.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCostCode.DropDownForeColor = System.Drawing.Color.Black
        Me.cboCostCode.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboCostCode.DropDownWidth = 141
        Me.cboCostCode.ForeColor = System.Drawing.Color.Black
        Me.cboCostCode.GridLineColor = System.Drawing.Color.LightGray
        Me.cboCostCode.GridLineHorizontal = False
        Me.cboCostCode.GridLineVertical = False
        Me.cboCostCode.HighlightBorderColor = System.Drawing.Color.Gray
        Me.cboCostCode.HighlightBorderOnMouseEvents = True
        Me.cboCostCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboCostCode.Location = New System.Drawing.Point(141, 60)
        Me.cboCostCode.ManagingFastMouseMoving = True
        Me.cboCostCode.ManagingFastMouseMovingInterval = 30
        Me.cboCostCode.Name = "cboCostCode"
        Me.cboCostCode.NormalBorderColor = System.Drawing.Color.Gray
        Me.cboCostCode.SelectedItem = Nothing
        Me.cboCostCode.SelectedValue = Nothing
        Me.cboCostCode.Size = New System.Drawing.Size(311, 21)
        Me.cboCostCode.TabIndex = 170
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.BackColor = System.Drawing.Color.White
        Me.lblDepartmentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDepartmentCode.ForeColor = System.Drawing.Color.Black
        Me.lblDepartmentCode.Location = New System.Drawing.Point(454, 82)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(87, 21)
        Me.lblDepartmentCode.TabIndex = 169
        Me.lblDepartmentCode.Text = "0"
        Me.lblDepartmentCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDepartment
        '
        Me.cboDepartment.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.ArrowColor = System.Drawing.Color.Black
        Me.cboDepartment.BackColor = System.Drawing.Color.White
        Me.cboDepartment.BindedControl = CType(resources.GetObject("cboDepartment.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboDepartment.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartment.ColumnNum = 1
        Me.cboDepartment.ColumnWidth = "121"
        Me.cboDepartment.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboDepartment.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboDepartment.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboDepartment.DisplayMember = "Text"
        Me.cboDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDepartment.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboDepartment.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboDepartment.DropDownForeColor = System.Drawing.Color.Black
        Me.cboDepartment.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboDepartment.DropDownWidth = 141
        Me.cboDepartment.ForeColor = System.Drawing.Color.Black
        Me.cboDepartment.GridLineColor = System.Drawing.Color.LightGray
        Me.cboDepartment.GridLineHorizontal = False
        Me.cboDepartment.GridLineVertical = False
        Me.cboDepartment.HighlightBorderColor = System.Drawing.Color.Gray
        Me.cboDepartment.HighlightBorderOnMouseEvents = True
        Me.cboDepartment.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboDepartment.Location = New System.Drawing.Point(141, 82)
        Me.cboDepartment.ManagingFastMouseMoving = True
        Me.cboDepartment.ManagingFastMouseMovingInterval = 30
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.NormalBorderColor = System.Drawing.Color.Gray
        Me.cboDepartment.SelectedItem = Nothing
        Me.cboDepartment.SelectedValue = Nothing
        Me.cboDepartment.Size = New System.Drawing.Size(311, 21)
        Me.cboDepartment.TabIndex = 168
        '
        'KryptonPanel67
        '
        Me.KryptonPanel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel67.Controls.Add(Me.KryptonBorderEdge61)
        Me.KryptonPanel67.Controls.Add(Me.KryptonLabel26)
        Me.KryptonPanel67.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel67.Location = New System.Drawing.Point(17, 61)
        Me.KryptonPanel67.Name = "KryptonPanel67"
        Me.KryptonPanel67.Size = New System.Drawing.Size(123, 20)
        Me.KryptonPanel67.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel67.TabIndex = 167
        '
        'KryptonBorderEdge61
        '
        Me.KryptonBorderEdge61.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge61.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge61.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge61.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge61.Name = "KryptonBorderEdge61"
        Me.KryptonBorderEdge61.Size = New System.Drawing.Size(123, 1)
        Me.KryptonBorderEdge61.Text = "KryptonBorderEdge61"
        '
        'KryptonLabel26
        '
        Me.KryptonLabel26.BackColor = System.Drawing.Color.White
        Me.KryptonLabel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel26.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel26.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel26.Name = "KryptonLabel26"
        Me.KryptonLabel26.Size = New System.Drawing.Size(123, 20)
        Me.KryptonLabel26.TabIndex = 0
        Me.KryptonLabel26.Values.Text = "Cost center"
        '
        'KryptonPanel65
        '
        Me.KryptonPanel65.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel65.Controls.Add(Me.KryptonBorderEdge59)
        Me.KryptonPanel65.Controls.Add(Me.KryptonLabel24)
        Me.KryptonPanel65.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel65.Location = New System.Drawing.Point(17, 83)
        Me.KryptonPanel65.Name = "KryptonPanel65"
        Me.KryptonPanel65.Size = New System.Drawing.Size(123, 20)
        Me.KryptonPanel65.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel65.TabIndex = 166
        '
        'KryptonBorderEdge59
        '
        Me.KryptonBorderEdge59.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge59.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge59.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge59.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge59.Name = "KryptonBorderEdge59"
        Me.KryptonBorderEdge59.Size = New System.Drawing.Size(123, 1)
        Me.KryptonBorderEdge59.Text = "KryptonBorderEdge59"
        '
        'KryptonLabel24
        '
        Me.KryptonLabel24.BackColor = System.Drawing.Color.White
        Me.KryptonLabel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel24.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel24.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel24.Name = "KryptonLabel24"
        Me.KryptonLabel24.Size = New System.Drawing.Size(123, 20)
        Me.KryptonLabel24.TabIndex = 0
        Me.KryptonLabel24.Values.Text = "Department"
        '
        'frmAccountBudgeting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 512)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAccountBudgeting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Budgeting"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel67, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel67.ResumeLayout(False)
        Me.KryptonPanel67.PerformLayout()
        CType(Me.KryptonPanel65, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel65.ResumeLayout(False)
        Me.KryptonPanel65.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblBranches As System.Windows.Forms.Label
    Friend WithEvents cboBranches As MTGCComboBox
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblCostCode As System.Windows.Forms.Label
    Friend WithEvents cboCostCode As MTGCComboBox
    Friend WithEvents lblDepartmentCode As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As MTGCComboBox
    Friend WithEvents KryptonPanel67 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge61 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel26 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel65 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge59 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel24 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnLoad As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblFinyear As DevComponents.DotNetBar.LabelItem
End Class
