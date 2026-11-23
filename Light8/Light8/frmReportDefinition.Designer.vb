<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportDefinition
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
        Me.components = New System.ComponentModel.Container()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnClose = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtFooter = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblFooterFontStyle = New System.Windows.Forms.Label()
        Me.cboFooterSize = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtFooterFont = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnFooterFont = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblDetailFontStyle = New System.Windows.Forms.Label()
        Me.lblHeaderFontStyle = New System.Windows.Forms.Label()
        Me.chkPageBreak = New System.Windows.Forms.CheckBox()
        Me.chkBreakKey = New System.Windows.Forms.CheckBox()
        Me.cboDetailSize = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboHeaderSize = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtDetailFont = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnDetailFont = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtHeaderFont = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnHeaderFont = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chkZero = New System.Windows.Forms.CheckBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboSortOrder = New System.Windows.Forms.ComboBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboFooterSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDetailSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboHeaderSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.btnClose)
        Me.KryptonPanel.Controls.Add(Me.btnOk)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.cboSortOrder)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(669, 320)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(582, 283)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 25)
        Me.btnClose.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnClose.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnClose.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnClose.StateCommon.Border.Rounding = 0
        Me.btnClose.TabIndex = 33
        Me.btnClose.Values.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Location = New System.Drawing.Point(501, 283)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOk.StateCommon.Border.Rounding = 0
        Me.btnOk.TabIndex = 32
        Me.btnOk.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(10, 54)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtFooter)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel8)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblFooterFontStyle)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboFooterSize)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtFooterFont)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel7)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDetailFontStyle)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblHeaderFontStyle)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkPageBreak)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkBreakKey)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboDetailSize)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboHeaderSize)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtDetailFont)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtHeaderFont)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkZero)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(647, 223)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 31
        Me.KryptonGroupBox1.Text = "Other options"
        Me.KryptonGroupBox1.Values.Heading = "Other options"
        '
        'txtFooter
        '
        Me.txtFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtFooter.ForeColor = System.Drawing.Color.Black
        Me.txtFooter.Location = New System.Drawing.Point(108, 162)
        Me.txtFooter.MaxLength = 100
        Me.txtFooter.Name = "txtFooter"
        Me.txtFooter.Size = New System.Drawing.Size(523, 20)
        Me.txtFooter.TabIndex = 48
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(20, 164)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(76, 20)
        Me.KryptonLabel8.TabIndex = 47
        Me.KryptonLabel8.Values.Text = "Footer text :"
        '
        'lblFooterFontStyle
        '
        Me.lblFooterFontStyle.BackColor = System.Drawing.Color.Transparent
        Me.lblFooterFontStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFooterFontStyle.ForeColor = System.Drawing.Color.Black
        Me.lblFooterFontStyle.Location = New System.Drawing.Point(534, 83)
        Me.lblFooterFontStyle.Name = "lblFooterFontStyle"
        Me.lblFooterFontStyle.Size = New System.Drawing.Size(97, 20)
        Me.lblFooterFontStyle.TabIndex = 46
        '
        'cboFooterSize
        '
        Me.cboFooterSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboFooterSize.DropDownWidth = 71
        Me.cboFooterSize.ForeColor = System.Drawing.Color.Black
        Me.cboFooterSize.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "24", "30", "36", "48", "72"})
        Me.cboFooterSize.Location = New System.Drawing.Point(449, 82)
        Me.cboFooterSize.Name = "cboFooterSize"
        Me.cboFooterSize.Size = New System.Drawing.Size(71, 21)
        Me.cboFooterSize.TabIndex = 45
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(403, 84)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(38, 20)
        Me.KryptonLabel6.TabIndex = 44
        Me.KryptonLabel6.Values.Text = "Size :"
        '
        'txtFooterFont
        '
        Me.txtFooterFont.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtFooterFont.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnFooterFont})
        Me.txtFooterFont.ForeColor = System.Drawing.Color.Black
        Me.txtFooterFont.Location = New System.Drawing.Point(108, 78)
        Me.txtFooterFont.Name = "txtFooterFont"
        Me.txtFooterFont.Size = New System.Drawing.Size(275, 26)
        Me.txtFooterFont.TabIndex = 43
        '
        'btnFooterFont
        '
        Me.btnFooterFont.Text = "Browse ..."
        Me.btnFooterFont.UniqueName = "162EAE351A144818EFB2D43A90A43ABB"
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(16, 82)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(80, 20)
        Me.KryptonLabel7.TabIndex = 42
        Me.KryptonLabel7.Values.Text = "Footer Font :"
        '
        'lblDetailFontStyle
        '
        Me.lblDetailFontStyle.BackColor = System.Drawing.Color.Transparent
        Me.lblDetailFontStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDetailFontStyle.ForeColor = System.Drawing.Color.Black
        Me.lblDetailFontStyle.Location = New System.Drawing.Point(534, 51)
        Me.lblDetailFontStyle.Name = "lblDetailFontStyle"
        Me.lblDetailFontStyle.Size = New System.Drawing.Size(97, 20)
        Me.lblDetailFontStyle.TabIndex = 41
        '
        'lblHeaderFontStyle
        '
        Me.lblHeaderFontStyle.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderFontStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeaderFontStyle.ForeColor = System.Drawing.Color.Black
        Me.lblHeaderFontStyle.Location = New System.Drawing.Point(534, 20)
        Me.lblHeaderFontStyle.Name = "lblHeaderFontStyle"
        Me.lblHeaderFontStyle.Size = New System.Drawing.Size(97, 20)
        Me.lblHeaderFontStyle.TabIndex = 40
        '
        'chkPageBreak
        '
        Me.chkPageBreak.AutoSize = True
        Me.chkPageBreak.BackColor = System.Drawing.Color.Transparent
        Me.chkPageBreak.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPageBreak.ForeColor = System.Drawing.Color.Black
        Me.chkPageBreak.Location = New System.Drawing.Point(417, 126)
        Me.chkPageBreak.Name = "chkPageBreak"
        Me.chkPageBreak.Size = New System.Drawing.Size(214, 17)
        Me.chkPageBreak.TabIndex = 39
        Me.chkPageBreak.Text = "New page on group sort key change"
        Me.chkPageBreak.UseVisualStyleBackColor = False
        '
        'chkBreakKey
        '
        Me.chkBreakKey.AutoSize = True
        Me.chkBreakKey.BackColor = System.Drawing.Color.Transparent
        Me.chkBreakKey.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBreakKey.ForeColor = System.Drawing.Color.Black
        Me.chkBreakKey.Location = New System.Drawing.Point(234, 126)
        Me.chkBreakKey.Name = "chkBreakKey"
        Me.chkBreakKey.Size = New System.Drawing.Size(160, 17)
        Me.chkBreakKey.TabIndex = 38
        Me.chkBreakKey.Text = "Group on sort key change"
        Me.chkBreakKey.UseVisualStyleBackColor = False
        '
        'cboDetailSize
        '
        Me.cboDetailSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboDetailSize.DropDownWidth = 71
        Me.cboDetailSize.ForeColor = System.Drawing.Color.Black
        Me.cboDetailSize.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "24", "30", "36", "48", "72"})
        Me.cboDetailSize.Location = New System.Drawing.Point(449, 50)
        Me.cboDetailSize.Name = "cboDetailSize"
        Me.cboDetailSize.Size = New System.Drawing.Size(71, 21)
        Me.cboDetailSize.TabIndex = 37
        '
        'cboHeaderSize
        '
        Me.cboHeaderSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboHeaderSize.DropDownWidth = 71
        Me.cboHeaderSize.ForeColor = System.Drawing.Color.Black
        Me.cboHeaderSize.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "24", "30", "36", "48", "72"})
        Me.cboHeaderSize.Location = New System.Drawing.Point(449, 19)
        Me.cboHeaderSize.Name = "cboHeaderSize"
        Me.cboHeaderSize.Size = New System.Drawing.Size(71, 21)
        Me.cboHeaderSize.TabIndex = 36
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(403, 52)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(38, 20)
        Me.KryptonLabel5.TabIndex = 35
        Me.KryptonLabel5.Values.Text = "Size :"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(403, 20)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(38, 20)
        Me.KryptonLabel4.TabIndex = 34
        Me.KryptonLabel4.Values.Text = "Size :"
        '
        'txtDetailFont
        '
        Me.txtDetailFont.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDetailFont.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnDetailFont})
        Me.txtDetailFont.ForeColor = System.Drawing.Color.Black
        Me.txtDetailFont.Location = New System.Drawing.Point(108, 46)
        Me.txtDetailFont.Name = "txtDetailFont"
        Me.txtDetailFont.Size = New System.Drawing.Size(275, 26)
        Me.txtDetailFont.TabIndex = 33
        '
        'btnDetailFont
        '
        Me.btnDetailFont.Text = "Browse ..."
        Me.btnDetailFont.UniqueName = "162EAE351A144818EFB2D43A90A43ABB"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(20, 49)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(76, 20)
        Me.KryptonLabel2.TabIndex = 32
        Me.KryptonLabel2.Values.Text = "Detail Font :"
        '
        'txtHeaderFont
        '
        Me.txtHeaderFont.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtHeaderFont.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnHeaderFont})
        Me.txtHeaderFont.ForeColor = System.Drawing.Color.Black
        Me.txtHeaderFont.Location = New System.Drawing.Point(108, 14)
        Me.txtHeaderFont.Name = "txtHeaderFont"
        Me.txtHeaderFont.Size = New System.Drawing.Size(275, 26)
        Me.txtHeaderFont.TabIndex = 31
        '
        'btnHeaderFont
        '
        Me.btnHeaderFont.Text = "Browse ..."
        Me.btnHeaderFont.UniqueName = "162EAE351A144818EFB2D43A90A43ABB"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(86, 22)
        Me.KryptonLabel1.TabIndex = 30
        Me.KryptonLabel1.Values.Text = "Header Font"
        '
        'chkZero
        '
        Me.chkZero.AutoSize = True
        Me.chkZero.BackColor = System.Drawing.Color.Transparent
        Me.chkZero.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkZero.ForeColor = System.Drawing.Color.Black
        Me.chkZero.Location = New System.Drawing.Point(87, 126)
        Me.chkZero.Name = "chkZero"
        Me.chkZero.Size = New System.Drawing.Size(133, 17)
        Me.chkZero.TabIndex = 29
        Me.chkZero.Text = "Suppress zero values"
        Me.chkZero.UseVisualStyleBackColor = False
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(8, 25)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(279, 20)
        Me.KryptonLabel3.TabIndex = 29
        Me.KryptonLabel3.Values.Text = "Sort by (Default is Employee Number Sequence) :"
        '
        'cboSortOrder
        '
        Me.cboSortOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortOrder.ForeColor = System.Drawing.Color.Black
        Me.cboSortOrder.FormattingEnabled = True
        Me.cboSortOrder.Items.AddRange(New Object() {"Department/Employee Number Sequence", "Department/Surname/Employee Number", "Cost Code/Employee Number", "Cost Code/Surname/Employee Number", "Paypoint/Employee Number Sequence", "Paypoint/Surname Sequence", "Paypoint/Cost Code/Employee Number", "Employee Number Sequence"})
        Me.cboSortOrder.Location = New System.Drawing.Point(313, 24)
        Me.cboSortOrder.Name = "cboSortOrder"
        Me.cboSortOrder.Size = New System.Drawing.Size(344, 21)
        Me.cboSortOrder.TabIndex = 28
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 319)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(669, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(669, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(668, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 318)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 318)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Location = New System.Drawing.Point(29, 288)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(103, 22)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 38
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(103, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Location = New System.Drawing.Point(20, 18)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(86, 22)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 39
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'frmReportDefinition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportDefinition"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Definition"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboFooterSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDetailSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboHeaderSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
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
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboSortOrder As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkZero As System.Windows.Forms.CheckBox
    Friend WithEvents txtDetailFont As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnDetailFont As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtHeaderFont As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnHeaderFont As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboDetailSize As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboHeaderSize As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents chkPageBreak As System.Windows.Forms.CheckBox
    Friend WithEvents chkBreakKey As System.Windows.Forms.CheckBox
    Friend WithEvents lblDetailFontStyle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderFontStyle As System.Windows.Forms.Label
    Friend WithEvents lblFooterFontStyle As System.Windows.Forms.Label
    Friend WithEvents cboFooterSize As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtFooterFont As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnFooterFont As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtFooter As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
