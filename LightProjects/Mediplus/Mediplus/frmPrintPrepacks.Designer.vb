<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintPrepacks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintPrepacks))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnAdd = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGridBrands = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDrugName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.cboInstruction = New MTGCComboBox()
        Me.lblPresentation = New System.Windows.Forms.Label()
        Me.lblStrength = New System.Windows.Forms.Label()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtCopies = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblCipher = New System.Windows.Forms.Label()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dGridBrands, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnAdd)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(663, 431)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.Location = New System.Drawing.Point(614, 252)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(20, 20)
        Me.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnAdd.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Back.ColorAngle = 100.0!
        Me.btnAdd.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnAdd.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAdd.StateCommon.Border.Rounding = 0
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Values.Image = CType(resources.GetObject("btnAdd.Values.Image"), System.Drawing.Image)
        Me.btnAdd.Values.Text = ""
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtDrugName)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblCode)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboInstruction)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblPresentation)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblStrength)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtCopies)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblCipher)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel9)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(639, 378)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(18, 71)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dGridBrands)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(606, 159)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 1
        Me.KryptonGroupBox2.Text = "Search results ..."
        Me.KryptonGroupBox2.Values.Heading = "Search results ..."
        '
        'dGridBrands
        '
        Me.dGridBrands.AllowUserToAddRows = False
        Me.dGridBrands.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridBrands.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dGridBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridBrands.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5, Me.Column3})
        Me.dGridBrands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridBrands.Location = New System.Drawing.Point(0, 0)
        Me.dGridBrands.Name = "dGridBrands"
        Me.dGridBrands.ReadOnly = True
        Me.dGridBrands.RowHeadersWidth = 25
        Me.dGridBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridBrands.Size = New System.Drawing.Size(604, 136)
        Me.dGridBrands.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridBrands.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridBrands.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridBrands.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dGridBrands.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGridBrands.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridBrands.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridBrands.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridBrands.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dGridBrands.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.White
        Me.dGridBrands.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridBrands.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridBrands.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridBrands.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 66
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "Strength"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 85
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0.00"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column3.HeaderText = "Unit Price"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 90
        '
        'txtDrugName
        '
        Me.txtDrugName.Location = New System.Drawing.Point(102, 18)
        Me.txtDrugName.Name = "txtDrugName"
        Me.txtDrugName.Size = New System.Drawing.Size(522, 20)
        Me.txtDrugName.TabIndex = 0
        '
        'lblCode
        '
        Me.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCode.Location = New System.Drawing.Point(547, 41)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(77, 20)
        Me.lblCode.TabIndex = 166
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInstruction
        '
        Me.cboInstruction.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboInstruction.ArrowColor = System.Drawing.Color.Black
        Me.cboInstruction.BindedControl = Nothing
        Me.cboInstruction.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboInstruction.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboInstruction.ColumnNum = 1
        Me.cboInstruction.ColumnWidth = "121"
        Me.cboInstruction.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboInstruction.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboInstruction.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboInstruction.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboInstruction.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboInstruction.DisplayMember = "Text"
        Me.cboInstruction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboInstruction.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboInstruction.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboInstruction.DropDownForeColor = System.Drawing.Color.Black
        Me.cboInstruction.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboInstruction.DropDownWidth = 141
        Me.cboInstruction.GridLineColor = System.Drawing.Color.LightGray
        Me.cboInstruction.GridLineHorizontal = False
        Me.cboInstruction.GridLineVertical = False
        Me.cboInstruction.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboInstruction.HighlightBorderOnMouseEvents = True
        Me.cboInstruction.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboInstruction.Location = New System.Drawing.Point(185, 236)
        Me.cboInstruction.ManagingFastMouseMoving = True
        Me.cboInstruction.ManagingFastMouseMovingInterval = 30
        Me.cboInstruction.Name = "cboInstruction"
        Me.cboInstruction.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboInstruction.SelectedItem = Nothing
        Me.cboInstruction.SelectedValue = Nothing
        Me.cboInstruction.Size = New System.Drawing.Size(415, 21)
        Me.cboInstruction.Sorted = True
        Me.cboInstruction.TabIndex = 2
        '
        'lblPresentation
        '
        Me.lblPresentation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPresentation.Location = New System.Drawing.Point(102, 41)
        Me.lblPresentation.Name = "lblPresentation"
        Me.lblPresentation.Size = New System.Drawing.Size(80, 20)
        Me.lblPresentation.TabIndex = 163
        Me.lblPresentation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStrength
        '
        Me.lblStrength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStrength.Location = New System.Drawing.Point(185, 41)
        Me.lblStrength.Name = "lblStrength"
        Me.lblStrength.Size = New System.Drawing.Size(360, 20)
        Me.lblStrength.TabIndex = 162
        Me.lblStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Location = New System.Drawing.Point(18, 18)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(83, 20)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 161
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(83, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(83, 20)
        Me.KryptonLabel2.TabIndex = 0
        Me.KryptonLabel2.Values.Text = "Drug Name"
        '
        'txtCopies
        '
        Me.txtCopies.Location = New System.Drawing.Point(185, 335)
        Me.txtCopies.Name = "txtCopies"
        Me.txtCopies.Size = New System.Drawing.Size(59, 20)
        Me.txtCopies.TabIndex = 4
        Me.txtCopies.Text = "1"
        Me.txtCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Location = New System.Drawing.Point(101, 335)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(83, 20)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 159
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(83, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(83, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "No. of labels"
        '
        'lblCipher
        '
        Me.lblCipher.BackColor = System.Drawing.Color.White
        Me.lblCipher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCipher.Location = New System.Drawing.Point(185, 261)
        Me.lblCipher.Name = "lblCipher"
        Me.lblCipher.Size = New System.Drawing.Size(439, 70)
        Me.lblCipher.TabIndex = 3
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel9.Location = New System.Drawing.Point(101, 237)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(83, 20)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 157
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(83, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(83, 20)
        Me.KryptonLabel8.TabIndex = 0
        Me.KryptonLabel8.Values.Text = "Instruction"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(582, 395)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(507, 395)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 2
        Me.btnOK.Values.Text = "&Print"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(663, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'frmPrintPrepacks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintPrepacks"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Content.LongText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.LongText.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White
        Me.Text = "Print Prepack Instructions"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dGridBrands, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
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
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblPresentation As System.Windows.Forms.Label
    Friend WithEvents lblStrength As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCopies As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblCipher As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnAdd As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cboInstruction As MTGCComboBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtDrugName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGridBrands As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
