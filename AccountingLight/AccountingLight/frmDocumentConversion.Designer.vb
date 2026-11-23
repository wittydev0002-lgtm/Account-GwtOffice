<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentConversion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentConversion))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.pnlDate = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpDateOn = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnFindAccount = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnAddNew = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtAddress = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboSupplierName = New MTGCComboBox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtAccountNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.pnlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDate.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(566, 245)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(475, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(394, 207)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(16, 13)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.pnlDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel9)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnFindAccount)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnAddNew)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAddress)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboSupplierName)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel14)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAccountNumber)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel13)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(534, 188)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'pnlDate
        '
        Me.pnlDate.Controls.Add(Me.dpDateOn)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge2)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge15)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge16)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge17)
        Me.pnlDate.Location = New System.Drawing.Point(119, 16)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(99, 22)
        Me.pnlDate.TabIndex = 169
        '
        'dpDateOn
        '
        Me.dpDateOn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpDateOn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDateOn.Location = New System.Drawing.Point(1, 1)
        Me.dpDateOn.Name = "dpDateOn"
        Me.dpDateOn.Size = New System.Drawing.Size(97, 20)
        Me.dpDateOn.TabIndex = 10
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(98, 1)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
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
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(99, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(99, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel9.Location = New System.Drawing.Point(16, 18)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(101, 20)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 168
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(101, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel3.TabIndex = 0
        Me.KryptonLabel3.Values.Text = "Invoice Date"
        '
        'btnFindAccount
        '
        Me.btnFindAccount.AutoSize = True
        Me.btnFindAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFindAccount.Location = New System.Drawing.Point(472, 41)
        Me.btnFindAccount.Name = "btnFindAccount"
        Me.btnFindAccount.Size = New System.Drawing.Size(20, 20)
        Me.btnFindAccount.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnFindAccount.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFindAccount.StateCommon.Back.ColorAngle = 100.0!
        Me.btnFindAccount.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnFindAccount.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFindAccount.StateCommon.Border.Rounding = 0
        Me.btnFindAccount.TabIndex = 167
        Me.btnFindAccount.Values.Image = CType(resources.GetObject("btnFindAccount.Values.Image"), System.Drawing.Image)
        Me.btnFindAccount.Values.Text = ""
        '
        'btnAddNew
        '
        Me.btnAddNew.AutoSize = True
        Me.btnAddNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddNew.Location = New System.Drawing.Point(496, 41)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(20, 20)
        Me.btnAddNew.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnAddNew.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAddNew.StateCommon.Back.ColorAngle = 100.0!
        Me.btnAddNew.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnAddNew.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAddNew.StateCommon.Border.Rounding = 0
        Me.btnAddNew.TabIndex = 166
        Me.btnAddNew.Values.Image = CType(resources.GetObject("btnAddNew.Values.Image"), System.Drawing.Image)
        Me.btnAddNew.Values.Text = ""
        '
        'txtAddress
        '
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.Location = New System.Drawing.Point(119, 86)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(398, 80)
        Me.txtAddress.TabIndex = 165
        '
        'cboSupplierName
        '
        Me.cboSupplierName.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSupplierName.ArrowColor = System.Drawing.Color.Black
        Me.cboSupplierName.BindedControl = Nothing
        Me.cboSupplierName.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSupplierName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSupplierName.ColumnNum = 1
        Me.cboSupplierName.ColumnWidth = "121"
        Me.cboSupplierName.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSupplierName.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSupplierName.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSupplierName.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSupplierName.DisplayMember = "Text"
        Me.cboSupplierName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSupplierName.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSupplierName.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSupplierName.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSupplierName.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSupplierName.DropDownWidth = 141
        Me.cboSupplierName.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.GridLineHorizontal = False
        Me.cboSupplierName.GridLineVertical = False
        Me.cboSupplierName.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.HighlightBorderOnMouseEvents = True
        Me.cboSupplierName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSupplierName.Location = New System.Drawing.Point(119, 41)
        Me.cboSupplierName.ManagingFastMouseMoving = True
        Me.cboSupplierName.ManagingFastMouseMovingInterval = 30
        Me.cboSupplierName.Name = "cboSupplierName"
        Me.cboSupplierName.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.SelectedItem = Nothing
        Me.cboSupplierName.SelectedValue = Nothing
        Me.cboSupplierName.Size = New System.Drawing.Size(348, 21)
        Me.cboSupplierName.TabIndex = 164
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel2.Location = New System.Drawing.Point(16, 41)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(101, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 163
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel1.TabIndex = 116
        Me.KryptonLabel1.Values.Text = "Name"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(101, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel14.Location = New System.Drawing.Point(16, 86)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(101, 21)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 162
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel6.TabIndex = 116
        Me.KryptonLabel6.Values.Text = "Address"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(101, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.Location = New System.Drawing.Point(119, 64)
        Me.txtAccountNumber.MaxLength = 75
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(398, 20)
        Me.txtAccountNumber.TabIndex = 161
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel13.Location = New System.Drawing.Point(16, 61)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(101, 23)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 160
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(101, 22)
        Me.KryptonLabel5.TabIndex = 116
        Me.KryptonLabel5.Values.Text = "Account No"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(101, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'frmDocumentConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 245)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDocumentConversion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Conversion"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.pnlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnFindAccount As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnAddNew As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtAddress As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboSupplierName As MTGCComboBox
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtAccountNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pnlDate As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpDateOn As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
