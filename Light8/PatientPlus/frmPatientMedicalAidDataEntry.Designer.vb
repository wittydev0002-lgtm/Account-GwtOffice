<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientMedicalAidDataEntry
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientMedicalAidDataEntry))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cboPackage = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboMedicalAidScheme = New MTGCComboBox()
        Me.txtMedaidSuffix = New Numberbox.Numberbox()
        Me.KryptonPanel21 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge38 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge35 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel19 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge36 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel20 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge37 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtMedaidNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblSchemeCode = New System.Windows.Forms.Label()
        Me.dpMedaidExpireDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel24 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge45 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboPackage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel21.SuspendLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel20.SuspendLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel24.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOk)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(511, 246)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(424, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Location = New System.Drawing.Point(343, 209)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOk.StateCommon.Border.Rounding = 0
        Me.btnOk.TabIndex = 7
        Me.btnOk.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dpMedaidExpireDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel24)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblSchemeCode)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboPackage)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboMedicalAidScheme)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtMedaidSuffix)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel21)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel18)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel19)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel20)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtMedaidNumber)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(487, 189)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'cboPackage
        '
        Me.cboPackage.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPackage.DropDownWidth = 122
        Me.cboPackage.ForeColor = System.Drawing.Color.Black
        Me.cboPackage.Items.AddRange(New Object() {"Cash", "Medical Aid", "Company"})
        Me.cboPackage.Location = New System.Drawing.Point(148, 59)
        Me.cboPackage.Name = "cboPackage"
        Me.cboPackage.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboPackage.Size = New System.Drawing.Size(291, 21)
        Me.cboPackage.TabIndex = 38
        '
        'cboMedicalAidScheme
        '
        Me.cboMedicalAidScheme.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboMedicalAidScheme.ArrowColor = System.Drawing.Color.Black
        Me.cboMedicalAidScheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboMedicalAidScheme.BindedControl = CType(resources.GetObject("cboMedicalAidScheme.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboMedicalAidScheme.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboMedicalAidScheme.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMedicalAidScheme.ColumnNum = 1
        Me.cboMedicalAidScheme.ColumnWidth = "121"
        Me.cboMedicalAidScheme.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboMedicalAidScheme.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboMedicalAidScheme.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboMedicalAidScheme.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboMedicalAidScheme.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboMedicalAidScheme.DisplayMember = "Text"
        Me.cboMedicalAidScheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMedicalAidScheme.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboMedicalAidScheme.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboMedicalAidScheme.DropDownForeColor = System.Drawing.Color.Black
        Me.cboMedicalAidScheme.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboMedicalAidScheme.DropDownWidth = 141
        Me.cboMedicalAidScheme.ForeColor = System.Drawing.Color.Black
        Me.cboMedicalAidScheme.GridLineColor = System.Drawing.Color.LightGray
        Me.cboMedicalAidScheme.GridLineHorizontal = False
        Me.cboMedicalAidScheme.GridLineVertical = False
        Me.cboMedicalAidScheme.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboMedicalAidScheme.HighlightBorderOnMouseEvents = True
        Me.cboMedicalAidScheme.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboMedicalAidScheme.Location = New System.Drawing.Point(148, 32)
        Me.cboMedicalAidScheme.ManagingFastMouseMoving = True
        Me.cboMedicalAidScheme.ManagingFastMouseMovingInterval = 30
        Me.cboMedicalAidScheme.Name = "cboMedicalAidScheme"
        Me.cboMedicalAidScheme.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboMedicalAidScheme.SelectedItem = Nothing
        Me.cboMedicalAidScheme.SelectedValue = Nothing
        Me.cboMedicalAidScheme.Size = New System.Drawing.Size(291, 23)
        Me.cboMedicalAidScheme.TabIndex = 37
        '
        'txtMedaidSuffix
        '
        Me.txtMedaidSuffix.AllowDecimal = True
        Me.txtMedaidSuffix.BackColor = System.Drawing.Color.White
        Me.txtMedaidSuffix.ForeColor = System.Drawing.Color.Black
        Me.txtMedaidSuffix.Location = New System.Drawing.Point(148, 106)
        Me.txtMedaidSuffix.Name = "txtMedaidSuffix"
        Me.txtMedaidSuffix.Size = New System.Drawing.Size(57, 22)
        Me.txtMedaidSuffix.TabIndex = 36
        Me.txtMedaidSuffix.Text = "00"
        Me.txtMedaidSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMedaidSuffix.ThousandsSeperator = False
        Me.txtMedaidSuffix.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel21
        '
        Me.KryptonPanel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel21.Controls.Add(Me.KryptonLabel14)
        Me.KryptonPanel21.Controls.Add(Me.KryptonBorderEdge38)
        Me.KryptonPanel21.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel21.Location = New System.Drawing.Point(46, 106)
        Me.KryptonPanel21.Name = "KryptonPanel21"
        Me.KryptonPanel21.Size = New System.Drawing.Size(100, 22)
        Me.KryptonPanel21.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel21.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel21.TabIndex = 35
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel14.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(100, 21)
        Me.KryptonLabel14.TabIndex = 1
        Me.KryptonLabel14.Values.Text = "Suffix"
        '
        'KryptonBorderEdge38
        '
        Me.KryptonBorderEdge38.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge38.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge38.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge38.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge38.Name = "KryptonBorderEdge38"
        Me.KryptonBorderEdge38.Size = New System.Drawing.Size(100, 1)
        Me.KryptonBorderEdge38.Text = "KryptonBorderEdge38"
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge35)
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(46, 34)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(100, 22)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel18.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel18.TabIndex = 31
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel11.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(100, 21)
        Me.KryptonLabel11.TabIndex = 1
        Me.KryptonLabel11.Values.Text = "Medical Aid"
        '
        'KryptonBorderEdge35
        '
        Me.KryptonBorderEdge35.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge35.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge35.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge35.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge35.Name = "KryptonBorderEdge35"
        Me.KryptonBorderEdge35.Size = New System.Drawing.Size(100, 1)
        Me.KryptonBorderEdge35.Text = "KryptonBorderEdge35"
        '
        'KryptonPanel19
        '
        Me.KryptonPanel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel19.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge36)
        Me.KryptonPanel19.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel19.Location = New System.Drawing.Point(46, 58)
        Me.KryptonPanel19.Name = "KryptonPanel19"
        Me.KryptonPanel19.Size = New System.Drawing.Size(100, 22)
        Me.KryptonPanel19.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel19.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel19.TabIndex = 32
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(100, 21)
        Me.KryptonLabel12.TabIndex = 1
        Me.KryptonLabel12.Values.Text = "Package"
        '
        'KryptonBorderEdge36
        '
        Me.KryptonBorderEdge36.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge36.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge36.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge36.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge36.Name = "KryptonBorderEdge36"
        Me.KryptonBorderEdge36.Size = New System.Drawing.Size(100, 1)
        Me.KryptonBorderEdge36.Text = "KryptonBorderEdge36"
        '
        'KryptonPanel20
        '
        Me.KryptonPanel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel20.Controls.Add(Me.KryptonLabel13)
        Me.KryptonPanel20.Controls.Add(Me.KryptonBorderEdge37)
        Me.KryptonPanel20.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel20.Location = New System.Drawing.Point(46, 82)
        Me.KryptonPanel20.Name = "KryptonPanel20"
        Me.KryptonPanel20.Size = New System.Drawing.Size(100, 22)
        Me.KryptonPanel20.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel20.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel20.TabIndex = 33
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel13.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(100, 21)
        Me.KryptonLabel13.TabIndex = 1
        Me.KryptonLabel13.Values.Text = "Member No."
        '
        'KryptonBorderEdge37
        '
        Me.KryptonBorderEdge37.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge37.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge37.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge37.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge37.Name = "KryptonBorderEdge37"
        Me.KryptonBorderEdge37.Size = New System.Drawing.Size(100, 1)
        Me.KryptonBorderEdge37.Text = "KryptonBorderEdge37"
        '
        'txtMedaidNumber
        '
        Me.txtMedaidNumber.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtMedaidNumber.Border.Class = "TextBoxBorder"
        Me.txtMedaidNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMedaidNumber.DisabledBackColor = System.Drawing.Color.White
        Me.txtMedaidNumber.ForeColor = System.Drawing.Color.Black
        Me.txtMedaidNumber.Location = New System.Drawing.Point(148, 82)
        Me.txtMedaidNumber.Name = "txtMedaidNumber"
        Me.txtMedaidNumber.PreventEnterBeep = True
        Me.txtMedaidNumber.Size = New System.Drawing.Size(291, 22)
        Me.txtMedaidNumber.TabIndex = 34
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 244)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(510, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 244)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 245)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(511, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(511, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'lblSchemeCode
        '
        Me.lblSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSchemeCode.Location = New System.Drawing.Point(299, 110)
        Me.lblSchemeCode.Name = "lblSchemeCode"
        Me.lblSchemeCode.Size = New System.Drawing.Size(106, 18)
        Me.lblSchemeCode.TabIndex = 39
        Me.lblSchemeCode.Visible = False
        '
        'dpMedaidExpireDate
        '
        Me.dpMedaidExpireDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpMedaidExpireDate.ForeColor = System.Drawing.Color.Black
        Me.dpMedaidExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpMedaidExpireDate.Location = New System.Drawing.Point(148, 131)
        Me.dpMedaidExpireDate.Name = "dpMedaidExpireDate"
        Me.dpMedaidExpireDate.Size = New System.Drawing.Size(122, 22)
        Me.dpMedaidExpireDate.TabIndex = 44
        '
        'KryptonPanel24
        '
        Me.KryptonPanel24.Controls.Add(Me.KryptonLabel16)
        Me.KryptonPanel24.Controls.Add(Me.KryptonBorderEdge45)
        Me.KryptonPanel24.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel24.Location = New System.Drawing.Point(46, 131)
        Me.KryptonPanel24.Name = "KryptonPanel24"
        Me.KryptonPanel24.Size = New System.Drawing.Size(100, 22)
        Me.KryptonPanel24.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel24.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel24.TabIndex = 43
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel16.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(100, 21)
        Me.KryptonLabel16.TabIndex = 1
        Me.KryptonLabel16.Values.Text = "Expiry date"
        '
        'KryptonBorderEdge45
        '
        Me.KryptonBorderEdge45.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge45.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge45.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge45.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge45.Name = "KryptonBorderEdge45"
        Me.KryptonBorderEdge45.Size = New System.Drawing.Size(100, 1)
        Me.KryptonBorderEdge45.Text = "KryptonBorderEdge45"
        '
        'frmPatientMedicalAidDataEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 246)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientMedicalAidDataEntry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Medical Setup"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboPackage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel21.ResumeLayout(False)
        Me.KryptonPanel21.PerformLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        Me.KryptonPanel19.PerformLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel20.ResumeLayout(False)
        Me.KryptonPanel20.PerformLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel24.ResumeLayout(False)
        Me.KryptonPanel24.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboPackage As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboMedicalAidScheme As MTGCComboBox
    Friend WithEvents txtMedaidSuffix As Numberbox.Numberbox
    Friend WithEvents KryptonPanel21 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge38 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge35 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge36 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel20 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge37 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtMedaidNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblSchemeCode As Label
    Friend WithEvents dpMedaidExpireDate As DateTimePicker
    Friend WithEvents KryptonPanel24 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge45 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
