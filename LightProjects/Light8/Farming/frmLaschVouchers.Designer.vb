<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaschVouchers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaschVouchers))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblDistrict = New System.Windows.Forms.Label()
        Me.lblProvince = New System.Windows.Forms.Label()
        Me.lblFarmType = New System.Windows.Forms.Label()
        Me.lblIdNumber = New System.Windows.Forms.Label()
        Me.txtAccountHolderNumber = New System.Windows.Forms.Label()
        Me.lblAddress4 = New System.Windows.Forms.Label()
        Me.lblAddress3 = New System.Windows.Forms.Label()
        Me.lblAddress2 = New System.Windows.Forms.Label()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.cboName = New MTGCComboBox()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.pdSmallPayslips = New System.Drawing.Printing.PrintDocument()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.lblRef = New System.Windows.Forms.Label()
        Me.pnlDate = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.chkOverideDate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.pnlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDate.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.pnlDate)
        Me.KryptonPanel.Controls.Add(Me.chkOverideDate)
        Me.KryptonPanel.Controls.Add(Me.lblRef)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.dGrid)
        Me.KryptonPanel.Controls.Add(Me.lblDistrict)
        Me.KryptonPanel.Controls.Add(Me.lblProvince)
        Me.KryptonPanel.Controls.Add(Me.lblFarmType)
        Me.KryptonPanel.Controls.Add(Me.lblIdNumber)
        Me.KryptonPanel.Controls.Add(Me.txtAccountHolderNumber)
        Me.KryptonPanel.Controls.Add(Me.lblAddress4)
        Me.KryptonPanel.Controls.Add(Me.lblAddress3)
        Me.KryptonPanel.Controls.Add(Me.lblAddress2)
        Me.KryptonPanel.Controls.Add(Me.lblAddress1)
        Me.KryptonPanel.Controls.Add(Me.cboName)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(691, 476)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(592, 439)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 163
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(511, 439)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 162
        Me.btnOK.Values.Text = "&OK"
        '
        'lblDistrict
        '
        Me.lblDistrict.BackColor = System.Drawing.Color.Transparent
        Me.lblDistrict.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDistrict.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDistrict.ForeColor = System.Drawing.Color.Black
        Me.lblDistrict.Location = New System.Drawing.Point(409, 148)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(258, 21)
        Me.lblDistrict.TabIndex = 160
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProvince
        '
        Me.lblProvince.BackColor = System.Drawing.Color.Transparent
        Me.lblProvince.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProvince.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblProvince.ForeColor = System.Drawing.Color.Black
        Me.lblProvince.Location = New System.Drawing.Point(409, 125)
        Me.lblProvince.Name = "lblProvince"
        Me.lblProvince.Size = New System.Drawing.Size(258, 21)
        Me.lblProvince.TabIndex = 159
        Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFarmType
        '
        Me.lblFarmType.BackColor = System.Drawing.Color.Transparent
        Me.lblFarmType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFarmType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblFarmType.ForeColor = System.Drawing.Color.Black
        Me.lblFarmType.Location = New System.Drawing.Point(409, 102)
        Me.lblFarmType.Name = "lblFarmType"
        Me.lblFarmType.Size = New System.Drawing.Size(258, 21)
        Me.lblFarmType.TabIndex = 158
        Me.lblFarmType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdNumber
        '
        Me.lblIdNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIdNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblIdNumber.ForeColor = System.Drawing.Color.Black
        Me.lblIdNumber.Location = New System.Drawing.Point(409, 79)
        Me.lblIdNumber.Name = "lblIdNumber"
        Me.lblIdNumber.Size = New System.Drawing.Size(258, 21)
        Me.lblIdNumber.TabIndex = 157
        Me.lblIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountHolderNumber
        '
        Me.txtAccountHolderNumber.BackColor = System.Drawing.Color.Transparent
        Me.txtAccountHolderNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAccountHolderNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtAccountHolderNumber.ForeColor = System.Drawing.Color.Black
        Me.txtAccountHolderNumber.Location = New System.Drawing.Point(409, 55)
        Me.txtAccountHolderNumber.Name = "txtAccountHolderNumber"
        Me.txtAccountHolderNumber.Size = New System.Drawing.Size(258, 21)
        Me.txtAccountHolderNumber.TabIndex = 156
        Me.txtAccountHolderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress4
        '
        Me.lblAddress4.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddress4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAddress4.ForeColor = System.Drawing.Color.Black
        Me.lblAddress4.Location = New System.Drawing.Point(98, 148)
        Me.lblAddress4.Name = "lblAddress4"
        Me.lblAddress4.Size = New System.Drawing.Size(305, 21)
        Me.lblAddress4.TabIndex = 155
        Me.lblAddress4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress3
        '
        Me.lblAddress3.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddress3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAddress3.ForeColor = System.Drawing.Color.Black
        Me.lblAddress3.Location = New System.Drawing.Point(98, 125)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(305, 21)
        Me.lblAddress3.TabIndex = 154
        Me.lblAddress3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress2
        '
        Me.lblAddress2.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddress2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAddress2.ForeColor = System.Drawing.Color.Black
        Me.lblAddress2.Location = New System.Drawing.Point(98, 102)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(305, 21)
        Me.lblAddress2.TabIndex = 153
        Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress1
        '
        Me.lblAddress1.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddress1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblAddress1.ForeColor = System.Drawing.Color.Black
        Me.lblAddress1.Location = New System.Drawing.Point(98, 79)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(305, 21)
        Me.lblAddress1.TabIndex = 152
        Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboName.Location = New System.Drawing.Point(98, 55)
        Me.cboName.ManagingFastMouseMoving = True
        Me.cboName.ManagingFastMouseMovingInterval = 30
        Me.cboName.Name = "cboName"
        Me.cboName.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboName.SelectedItem = Nothing
        Me.cboName.SelectedValue = Nothing
        Me.cboName.Size = New System.Drawing.Size(305, 21)
        Me.cboName.TabIndex = 149
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel3.Location = New System.Drawing.Point(23, 55)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(75, 21)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 151
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(75, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Farmer"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(23, 428)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(644, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(689, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(690, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 475)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 475)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 475)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(691, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'pdSmallPayslips
        '
        '
        'ppd
        '
        Me.ppd.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ppd.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd.Enabled = True
        Me.ppd.Icon = CType(resources.GetObject("ppd.Icon"), System.Drawing.Icon)
        Me.ppd.Name = "ppd"
        Me.ppd.Visible = False
        '
        'lblRef
        '
        Me.lblRef.Location = New System.Drawing.Point(31, 438)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(114, 25)
        Me.lblRef.TabIndex = 169
        Me.lblRef.Text = "0"
        Me.lblRef.Visible = False
        '
        'pnlDate
        '
        Me.pnlDate.Controls.Add(Me.dpTransDate)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge11)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge10)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge9)
        Me.pnlDate.Controls.Add(Me.KryptonBorderEdge8)
        Me.pnlDate.Location = New System.Drawing.Point(98, 27)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(112, 22)
        Me.pnlDate.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.pnlDate.TabIndex = 171
        '
        'dpTransDate
        '
        Me.dpTransDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpTransDate.Enabled = False
        Me.dpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpTransDate.Location = New System.Drawing.Point(1, 1)
        Me.dpTransDate.Name = "dpTransDate"
        Me.dpTransDate.Size = New System.Drawing.Size(110, 20)
        Me.dpTransDate.TabIndex = 35
        Me.dpTransDate.Visible = False
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(111, 1)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(112, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(112, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'chkOverideDate
        '
        Me.chkOverideDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkOverideDate.Location = New System.Drawing.Point(220, 29)
        Me.chkOverideDate.Name = "chkOverideDate"
        Me.chkOverideDate.Size = New System.Drawing.Size(98, 20)
        Me.chkOverideDate.TabIndex = 170
        Me.chkOverideDate.Text = "Override date"
        Me.chkOverideDate.Values.Text = "Override date"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column3})
        Me.dGrid.Location = New System.Drawing.Point(23, 191)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.Size = New System.Drawing.Size(644, 231)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 161
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Code"
        Me.Column4.MinimumWidth = 80
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 80
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Description"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Pack"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Qty"
        Me.Column3.MinimumWidth = 100
        Me.Column3.Name = "Column3"
        '
        'frmLaschVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 476)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLaschVouchers"
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
        Me.Text = "Lasch Vouchers"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.pnlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboName As MTGCComboBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents lblFarmType As System.Windows.Forms.Label
    Friend WithEvents lblIdNumber As System.Windows.Forms.Label
    Friend WithEvents txtAccountHolderNumber As System.Windows.Forms.Label
    Friend WithEvents lblAddress4 As System.Windows.Forms.Label
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pdSmallPayslips As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppd As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents pnlDate As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents chkOverideDate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
