<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerTradingHistory
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtAccountNo = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboRecommendation = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboAccountStatus = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.dpRef = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.txtRefNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel29 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel20 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel28 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel19 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel27 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel26 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtRefBalance = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel25 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtRefAccount = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel24 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel15 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtRefName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel23 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.cboRecommendation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAccountStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel29, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel29.SuspendLayout()
        CType(Me.KryptonPanel28, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel28.SuspendLayout()
        CType(Me.KryptonPanel27, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel27.SuspendLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel26.SuspendLayout()
        CType(Me.KryptonPanel25, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel25.SuspendLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel24.SuspendLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel23.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(614, 334)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(527, 295)
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
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.AutoSize = True
        Me.btnOK.Location = New System.Drawing.Point(446, 295)
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
        Me.btnOK.TabIndex = 29
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAccountNo)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboRecommendation)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboAccountStatus)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dpRef)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRefNotes)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel29)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel28)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel27)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel26)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRefBalance)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel25)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRefAccount)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel24)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRefName)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel23)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(590, 277)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Enabled = False
        Me.txtAccountNo.Location = New System.Drawing.Point(131, 16)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(227, 20)
        Me.txtAccountNo.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.txtAccountNo.StateCommon.Border.Width = 1
        Me.txtAccountNo.TabIndex = 97
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Location = New System.Drawing.Point(28, 16)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 96
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Account No."
        '
        'cboRecommendation
        '
        Me.cboRecommendation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecommendation.DropDownWidth = 163
        Me.cboRecommendation.Items.AddRange(New Object() {"Accept", "Conditionally Accept", "Decline"})
        Me.cboRecommendation.Location = New System.Drawing.Point(131, 156)
        Me.cboRecommendation.Name = "cboRecommendation"
        Me.cboRecommendation.Size = New System.Drawing.Size(163, 21)
        Me.cboRecommendation.TabIndex = 95
        '
        'cboAccountStatus
        '
        Me.cboAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountStatus.DropDownWidth = 163
        Me.cboAccountStatus.Items.AddRange(New Object() {"Paid Up", "Up to date", "In Arrears", "Bad Debt"})
        Me.cboAccountStatus.Location = New System.Drawing.Point(131, 132)
        Me.cboAccountStatus.Name = "cboAccountStatus"
        Me.cboAccountStatus.Size = New System.Drawing.Size(163, 21)
        Me.cboAccountStatus.TabIndex = 94
        '
        'dpRef
        '
        Me.dpRef.CalendarTodayDate = New Date(2011, 10, 16, 0, 0, 0, 0)
        Me.dpRef.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpRef.Location = New System.Drawing.Point(131, 108)
        Me.dpRef.Name = "dpRef"
        Me.dpRef.Size = New System.Drawing.Size(120, 21)
        Me.dpRef.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dpRef.StateCommon.Border.Rounding = 1
        Me.dpRef.TabIndex = 93
        '
        'txtRefNotes
        '
        Me.txtRefNotes.Location = New System.Drawing.Point(131, 182)
        Me.txtRefNotes.MaxLength = 250
        Me.txtRefNotes.Multiline = True
        Me.txtRefNotes.Name = "txtRefNotes"
        Me.txtRefNotes.Size = New System.Drawing.Size(430, 75)
        Me.txtRefNotes.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.txtRefNotes.StateCommon.Border.Width = 1
        Me.txtRefNotes.TabIndex = 92
        '
        'KryptonPanel29
        '
        Me.KryptonPanel29.Controls.Add(Me.KryptonBorderEdge19)
        Me.KryptonPanel29.Controls.Add(Me.KryptonLabel20)
        Me.KryptonPanel29.Location = New System.Drawing.Point(28, 180)
        Me.KryptonPanel29.Name = "KryptonPanel29"
        Me.KryptonPanel29.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel29.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel29.TabIndex = 91
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'KryptonLabel20
        '
        Me.KryptonLabel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel20.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel20.Name = "KryptonLabel20"
        Me.KryptonLabel20.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel20.TabIndex = 0
        Me.KryptonLabel20.Values.Text = "Note"
        '
        'KryptonPanel28
        '
        Me.KryptonPanel28.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel28.Controls.Add(Me.KryptonLabel19)
        Me.KryptonPanel28.Location = New System.Drawing.Point(28, 156)
        Me.KryptonPanel28.Name = "KryptonPanel28"
        Me.KryptonPanel28.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel28.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel28.TabIndex = 90
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel19.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel19.TabIndex = 0
        Me.KryptonLabel19.Values.Text = "Commendation"
        '
        'KryptonPanel27
        '
        Me.KryptonPanel27.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel27.Controls.Add(Me.KryptonLabel18)
        Me.KryptonPanel27.Location = New System.Drawing.Point(28, 132)
        Me.KryptonPanel27.Name = "KryptonPanel27"
        Me.KryptonPanel27.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel27.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel27.TabIndex = 89
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel18.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel18.TabIndex = 0
        Me.KryptonLabel18.Values.Text = "Status"
        '
        'KryptonPanel26
        '
        Me.KryptonPanel26.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel26.Controls.Add(Me.KryptonLabel17)
        Me.KryptonPanel26.Location = New System.Drawing.Point(28, 108)
        Me.KryptonPanel26.Name = "KryptonPanel26"
        Me.KryptonPanel26.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel26.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel26.TabIndex = 88
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel17.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel17.TabIndex = 0
        Me.KryptonLabel17.Values.Text = "Date opened"
        '
        'txtRefBalance
        '
        Me.txtRefBalance.Location = New System.Drawing.Point(131, 85)
        Me.txtRefBalance.Name = "txtRefBalance"
        Me.txtRefBalance.Size = New System.Drawing.Size(120, 20)
        Me.txtRefBalance.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.txtRefBalance.StateCommon.Border.Width = 1
        Me.txtRefBalance.TabIndex = 87
        Me.txtRefBalance.Text = "0.00"
        Me.txtRefBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonPanel25
        '
        Me.KryptonPanel25.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel25.Controls.Add(Me.KryptonLabel16)
        Me.KryptonPanel25.Location = New System.Drawing.Point(28, 85)
        Me.KryptonPanel25.Name = "KryptonPanel25"
        Me.KryptonPanel25.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel25.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel25.TabIndex = 86
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel16.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel16.TabIndex = 0
        Me.KryptonLabel16.Values.Text = "Balance"
        '
        'txtRefAccount
        '
        Me.txtRefAccount.Location = New System.Drawing.Point(131, 62)
        Me.txtRefAccount.Name = "txtRefAccount"
        Me.txtRefAccount.Size = New System.Drawing.Size(430, 20)
        Me.txtRefAccount.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.txtRefAccount.StateCommon.Border.Width = 1
        Me.txtRefAccount.TabIndex = 85
        '
        'KryptonPanel24
        '
        Me.KryptonPanel24.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel24.Controls.Add(Me.KryptonLabel15)
        Me.KryptonPanel24.Location = New System.Drawing.Point(28, 62)
        Me.KryptonPanel24.Name = "KryptonPanel24"
        Me.KryptonPanel24.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel24.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel24.TabIndex = 84
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonLabel15
        '
        Me.KryptonLabel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel15.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel15.Name = "KryptonLabel15"
        Me.KryptonLabel15.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel15.TabIndex = 0
        Me.KryptonLabel15.Values.Text = "Account No."
        '
        'txtRefName
        '
        Me.txtRefName.Location = New System.Drawing.Point(131, 39)
        Me.txtRefName.Name = "txtRefName"
        Me.txtRefName.Size = New System.Drawing.Size(430, 20)
        Me.txtRefName.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.txtRefName.StateCommon.Border.Width = 1
        Me.txtRefName.TabIndex = 83
        '
        'KryptonPanel23
        '
        Me.KryptonPanel23.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel23.Controls.Add(Me.KryptonLabel14)
        Me.KryptonPanel23.Location = New System.Drawing.Point(28, 39)
        Me.KryptonPanel23.Name = "KryptonPanel23"
        Me.KryptonPanel23.Size = New System.Drawing.Size(102, 20)
        Me.KryptonPanel23.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel23.TabIndex = 82
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel14.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel14.TabIndex = 0
        Me.KryptonLabel14.Values.Text = "Name"
        '
        'frmCustomerTradingHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 334)
        Me.Controls.Add(Me.KryptonPanel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomerTradingHistory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Customer Trading History"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.cboRecommendation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAccountStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel29, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel29.ResumeLayout(False)
        Me.KryptonPanel29.PerformLayout()
        CType(Me.KryptonPanel28, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel28.ResumeLayout(False)
        Me.KryptonPanel28.PerformLayout()
        CType(Me.KryptonPanel27, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel27.ResumeLayout(False)
        Me.KryptonPanel27.PerformLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel26.ResumeLayout(False)
        Me.KryptonPanel26.PerformLayout()
        CType(Me.KryptonPanel25, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel25.ResumeLayout(False)
        Me.KryptonPanel25.PerformLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel24.ResumeLayout(False)
        Me.KryptonPanel24.PerformLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel23.ResumeLayout(False)
        Me.KryptonPanel23.PerformLayout()
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
    Friend WithEvents cboRecommendation As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboAccountStatus As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents dpRef As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents txtRefNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel29 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel20 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel28 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel19 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel27 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel26 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtRefBalance As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel25 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtRefAccount As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel24 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel15 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtRefName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel23 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Private WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtAccountNo As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
