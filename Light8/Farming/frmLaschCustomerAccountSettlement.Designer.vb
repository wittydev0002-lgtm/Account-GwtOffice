<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaschCustomerAccountSettlement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaschCustomerAccountSettlement))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblAccountDescription = New System.Windows.Forms.Label()
        Me.cboAccount = New MTGCComboBox()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.pnlDate = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboName = New MTGCComboBox()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtAmountExchange = New System.Windows.Forms.TextBox()
        Me.cboCurrency = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkOverideDate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.txtAccountHolderNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.chkOrdinaryPrinter = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.pdWindows = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.pnlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDate.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.chkOrdinaryPrinter)
        Me.KryptonPanel1.Controls.Add(Me.lblAccountDescription)
        Me.KryptonPanel1.Controls.Add(Me.cboAccount)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel1.Controls.Add(Me.pnlDate)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.cboName)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.pb1)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.chkOverideDate)
        Me.KryptonPanel1.Controls.Add(Me.txtAccountHolderNumber)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(637, 358)
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 1
        '
        'lblAccountDescription
        '
        Me.lblAccountDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccountDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAccountDescription.ForeColor = System.Drawing.Color.Black
        Me.lblAccountDescription.Location = New System.Drawing.Point(121, 70)
        Me.lblAccountDescription.Name = "lblAccountDescription"
        Me.lblAccountDescription.Size = New System.Drawing.Size(502, 21)
        Me.lblAccountDescription.TabIndex = 153
        Me.lblAccountDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccount
        '
        Me.cboAccount.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccount.ArrowColor = System.Drawing.Color.Black
        Me.cboAccount.BindedControl = Nothing
        Me.cboAccount.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboAccount.ColumnNum = 1
        Me.cboAccount.ColumnWidth = "121"
        Me.cboAccount.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccount.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboAccount.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboAccount.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboAccount.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboAccount.DisplayMember = "Text"
        Me.cboAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboAccount.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboAccount.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboAccount.DropDownForeColor = System.Drawing.Color.Black
        Me.cboAccount.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboAccount.DropDownWidth = 141
        Me.cboAccount.GridLineColor = System.Drawing.Color.LightGray
        Me.cboAccount.GridLineHorizontal = False
        Me.cboAccount.GridLineVertical = False
        Me.cboAccount.HighlightBorderColor = System.Drawing.Color.DarkGray
        Me.cboAccount.HighlightBorderOnMouseEvents = True
        Me.cboAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboAccount.Location = New System.Drawing.Point(121, 46)
        Me.cboAccount.ManagingFastMouseMoving = True
        Me.cboAccount.ManagingFastMouseMovingInterval = 30
        Me.cboAccount.Name = "cboAccount"
        Me.cboAccount.NormalBorderColor = System.Drawing.Color.DarkGray
        Me.cboAccount.SelectedItem = Nothing
        Me.cboAccount.SelectedValue = Nothing
        Me.cboAccount.Size = New System.Drawing.Size(502, 21)
        Me.cboAccount.Sorted = True
        Me.cboAccount.TabIndex = 152
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel4.Location = New System.Drawing.Point(13, 46)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(107, 21)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 151
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(107, 20)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Cashbook"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(107, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'pnlDate
        '
        Me.pnlDate.Controls.Add(Me.dpTransDate)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge14)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge15)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge16)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge17)
        Me.pnlDate.Location = New System.Drawing.Point(122, 18)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(98, 22)
        Me.pnlDate.TabIndex = 150
        '
        'dpTransDate
        '
        Me.dpTransDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpTransDate.Location = New System.Drawing.Point(1, 1)
        Me.dpTransDate.Name = "dpTransDate"
        Me.dpTransDate.Size = New System.Drawing.Size(96, 20)
        Me.dpTransDate.TabIndex = 10
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(97, 1)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(98, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(98, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel2.Location = New System.Drawing.Point(13, 19)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(107, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 149
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(107, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Transaction Date "
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(107, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'cboName
        '
        Me.cboName.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboName.ArrowColor = System.Drawing.Color.Black
        Me.cboName.BindedControl = CType(resources.GetObject("cboName.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboName.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboName.ColumnNum = 1
        Me.cboName.ColumnWidth = "121"
        Me.cboName.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboName.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboName.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboName.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboName.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboName.DisplayMember = "Text"
        Me.cboName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboName.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboName.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboName.DropDownForeColor = System.Drawing.Color.Black
        Me.cboName.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboName.DropDownWidth = 141
        Me.cboName.GridLineColor = System.Drawing.Color.LightGray
        Me.cboName.GridLineHorizontal = False
        Me.cboName.GridLineVertical = False
        Me.cboName.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboName.HighlightBorderOnMouseEvents = True
        Me.cboName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboName.Location = New System.Drawing.Point(122, 96)
        Me.cboName.ManagingFastMouseMoving = True
        Me.cboName.ManagingFastMouseMovingInterval = 30
        Me.cboName.Name = "cboName"
        Me.cboName.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboName.SelectedItem = Nothing
        Me.cboName.SelectedValue = Nothing
        Me.cboName.Size = New System.Drawing.Size(501, 21)
        Me.cboName.TabIndex = 146
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel3.Location = New System.Drawing.Point(16, 96)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(104, 21)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 145
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(104, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Farmer"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(104, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(16, 316)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(445, 25)
        Me.pb1.TabIndex = 116
        Me.pb1.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(548, 316)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 94
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(467, 316)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 93
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(16, 152)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountExchange)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboCurrency)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtReference)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmount)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label5)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(607, 158)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 92
        Me.KryptonGroupBox1.Text = "Payment"
        Me.KryptonGroupBox1.Values.Heading = "Payment"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(13, 103)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(110, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(14, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "US Dollar Amount"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(12, 75)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(110, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'txtAmountExchange
        '
        Me.txtAmountExchange.Enabled = False
        Me.txtAmountExchange.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountExchange.Location = New System.Drawing.Point(122, 81)
        Me.txtAmountExchange.Name = "txtAmountExchange"
        Me.txtAmountExchange.Size = New System.Drawing.Size(167, 22)
        Me.txtAmountExchange.TabIndex = 7
        Me.txtAmountExchange.Text = "0.00"
        Me.txtAmountExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownHeight = 100
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.DropDownWidth = 328
        Me.cboCurrency.Location = New System.Drawing.Point(122, 26)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(457, 22)
        Me.cboCurrency.StateCommon.ComboBox.Content.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCurrency.TabIndex = 15
        '
        'txtReference
        '
        Me.txtReference.Enabled = False
        Me.txtReference.Location = New System.Drawing.Point(366, 66)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(97, 20)
        Me.txtReference.TabIndex = 115
        Me.txtReference.Visible = False
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.Location = New System.Drawing.Point(122, 53)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(167, 22)
        Me.txtAmount.TabIndex = 6
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(12, 46)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(110, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Payment Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(13, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Currency"
        '
        'chkOverideDate
        '
        Me.chkOverideDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkOverideDate.Location = New System.Drawing.Point(226, 21)
        Me.chkOverideDate.Name = "chkOverideDate"
        Me.chkOverideDate.Size = New System.Drawing.Size(92, 16)
        Me.chkOverideDate.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOverideDate.TabIndex = 39
        Me.chkOverideDate.Text = "Override date"
        Me.chkOverideDate.Values.Text = "Override date"
        '
        'txtAccountHolderNumber
        '
        Me.txtAccountHolderNumber.Enabled = False
        Me.txtAccountHolderNumber.Location = New System.Drawing.Point(122, 119)
        Me.txtAccountHolderNumber.Name = "txtAccountHolderNumber"
        Me.txtAccountHolderNumber.Size = New System.Drawing.Size(501, 20)
        Me.txtAccountHolderNumber.TabIndex = 38
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(637, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'chkOrdinaryPrinter
        '
        Me.chkOrdinaryPrinter.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkOrdinaryPrinter.Location = New System.Drawing.Point(350, 17)
        Me.chkOrdinaryPrinter.Name = "chkOrdinaryPrinter"
        Me.chkOrdinaryPrinter.Size = New System.Drawing.Size(193, 20)
        Me.chkOrdinaryPrinter.TabIndex = 155
        Me.chkOrdinaryPrinter.Text = "Print receipt to ordinary printer"
        Me.chkOrdinaryPrinter.Values.Text = "Print receipt to ordinary printer"
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
        'frmLaschCustomerAccountSettlement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 358)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLaschCustomerAccountSettlement"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Lasch Customer Account Settlement"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.pnlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Private WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtAmountExchange As System.Windows.Forms.TextBox
    Friend WithEvents cboCurrency As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkOverideDate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtAccountHolderNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboName As MTGCComboBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents pnlDate As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboAccount As MTGCComboBox
    Friend WithEvents lblAccountDescription As System.Windows.Forms.Label
    Friend WithEvents chkOrdinaryPrinter As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents pdWindows As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
