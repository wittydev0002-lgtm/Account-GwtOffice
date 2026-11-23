<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventorySalesCostPriceAdjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventorySalesCostPriceAdjustment))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtUnitPrice = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtItemCode = New MTGCComboBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(550, 198)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(469, 162)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
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
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(394, 162)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 2
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dpDateFrom)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtDateTo)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel6)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtUnitPrice)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnSearch)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtItemCode)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(526, 144)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'dtDateTo
        '
        Me.dtDateTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dtDateTo.ForeColor = System.Drawing.Color.Black
        Me.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDateTo.Location = New System.Drawing.Point(269, 84)
        Me.dtDateTo.Name = "dtDateTo"
        Me.dtDateTo.Size = New System.Drawing.Size(103, 20)
        Me.dtDateTo.TabIndex = 4
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(221, 84)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(47, 20)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 151
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(47, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(47, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "And"
        '
        'dpDateFrom
        '
        Me.dpDateFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpDateFrom.ForeColor = System.Drawing.Color.Black
        Me.dpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDateFrom.Location = New System.Drawing.Point(109, 85)
        Me.dpDateFrom.Name = "dpDateFrom"
        Me.dpDateFrom.Size = New System.Drawing.Size(103, 20)
        Me.dpDateFrom.TabIndex = 4
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(19, 85)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(90, 20)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 149
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(90, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(90, 20)
        Me.KryptonLabel2.TabIndex = 0
        Me.KryptonLabel2.Values.Text = "Sales between"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(19, 59)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(90, 20)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 148
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(90, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(90, 20)
        Me.KryptonLabel5.TabIndex = 0
        Me.KryptonLabel5.Values.Text = "Unit Price"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtUnitPrice.ForeColor = System.Drawing.Color.Black
        Me.txtUnitPrice.Location = New System.Drawing.Point(109, 59)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(91, 20)
        Me.txtUnitPrice.TabIndex = 147
        Me.txtUnitPrice.Text = "0.00"
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSearch
        '
        Me.btnSearch.AutoSize = True
        Me.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(456, 34)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(49, 22)
        Me.btnSearch.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnSearch.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSearch.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSearch.StateCommon.Border.Rounding = 0
        Me.btnSearch.TabIndex = 146
        Me.btnSearch.Values.Image = CType(resources.GetObject("btnSearch.Values.Image"), System.Drawing.Image)
        Me.btnSearch.Values.Text = "Find"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(19, 36)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(90, 20)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 145
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(90, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(90, 20)
        Me.KryptonLabel3.TabIndex = 0
        Me.KryptonLabel3.Values.Text = "Item code"
        '
        'txtItemCode
        '
        Me.txtItemCode.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.txtItemCode.ArrowColor = System.Drawing.Color.Black
        Me.txtItemCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtItemCode.BindedControl = Nothing
        Me.txtItemCode.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtItemCode.ColumnNum = 1
        Me.txtItemCode.ColumnWidth = "121"
        Me.txtItemCode.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.txtItemCode.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.txtItemCode.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.txtItemCode.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtItemCode.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.txtItemCode.DisplayMember = "Text"
        Me.txtItemCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtItemCode.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txtItemCode.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.txtItemCode.DropDownForeColor = System.Drawing.Color.Black
        Me.txtItemCode.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.txtItemCode.DropDownWidth = 141
        Me.txtItemCode.ForeColor = System.Drawing.Color.Black
        Me.txtItemCode.GridLineColor = System.Drawing.Color.LightGray
        Me.txtItemCode.GridLineHorizontal = False
        Me.txtItemCode.GridLineVertical = False
        Me.txtItemCode.HighlightBorderColor = System.Drawing.Color.DarkGray
        Me.txtItemCode.HighlightBorderOnMouseEvents = True
        Me.txtItemCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.txtItemCode.Location = New System.Drawing.Point(109, 35)
        Me.txtItemCode.ManagingFastMouseMoving = True
        Me.txtItemCode.ManagingFastMouseMovingInterval = 30
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.NormalBorderColor = System.Drawing.Color.DarkGray
        Me.txtItemCode.SelectedItem = Nothing
        Me.txtItemCode.SelectedValue = Nothing
        Me.txtItemCode.Size = New System.Drawing.Size(344, 21)
        Me.txtItemCode.Sorted = True
        Me.txtItemCode.TabIndex = 144
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(550, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 197)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(550, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(549, 1)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 196)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(1, 196)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'frmInventorySalesCostPriceAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventorySalesCostPriceAdjustment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Cost Price Adjustment"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
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
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtItemCode As MTGCComboBox
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtUnitPrice As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dtDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
