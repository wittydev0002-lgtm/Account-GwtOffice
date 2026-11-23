<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoice
    Inherits DevComponents.DotNetBar.Metro.MetroForm 'ComponentFactory.Krypton.Toolkit.KryptonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoice))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtAccountNumber = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboPersonnel = New MTGCComboBox()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtProjectNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtOrderNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtReference = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtPhone = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.Label()
        Me.chkOverrideNo = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtLastName = New System.Windows.Forms.Label()
        Me.txtAddress = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.chkOverideDate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.cboProjects = New MTGCComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chkProjectStatus = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnFindAccount = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnSaveClose = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSaveNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRemoveItem = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonGroupBox5 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtComments = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonGroupBox4 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.lblTaxable = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.lblPayable = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTaxes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDiscounts = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.picDocumentImage = New System.Windows.Forms.PictureBox()
        Me.cboSerials = New MTGCComboBox()
        Me.cboItems = New MTGCComboBox()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboSupplierName = New MTGCComboBox()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdWindows = New System.Drawing.Printing.PrintDocument()
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.miniToolStrip = New System.Windows.Forms.StatusStrip()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.KryptonTextBox2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.pdAirInvoice = New System.Drawing.Printing.PrintDocument()
        Me.txtFiscalDay = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtFiscalInvoiceNo = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox5.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox5.Panel.SuspendLayout()
        Me.KryptonGroupBox5.SuspendLayout()
        CType(Me.KryptonGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox4.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox4.Panel.SuspendLayout()
        Me.KryptonGroupBox4.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.picDocumentImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.txtFiscalInvoiceNo)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel1.Controls.Add(Me.txtFiscalDay)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel1.Controls.Add(Me.cboPersonnel)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel1.Controls.Add(Me.txtProjectNumber)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.dpTransDate)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel1.Controls.Add(Me.txtOrderNumber)
        Me.KryptonPanel1.Controls.Add(Me.txtReference)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel11)
        Me.KryptonPanel1.Controls.Add(Me.txtPhone)
        Me.KryptonPanel1.Controls.Add(Me.txtEmailAddress)
        Me.KryptonPanel1.Controls.Add(Me.chkOverrideNo)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.txtLastName)
        Me.KryptonPanel1.Controls.Add(Me.txtAddress)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel14)
        Me.KryptonPanel1.Controls.Add(Me.chkOverideDate)
        Me.KryptonPanel1.Controls.Add(Me.cboProjects)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Controls.Add(Me.chkProjectStatus)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.btnFindAccount)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel16)
        Me.KryptonPanel1.Controls.Add(Me.cboSupplierName)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge23)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(860, 589)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.txtAccountNumber)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(318, 37)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(115, 22)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 200
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtAccountNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.txtAccountNumber.Location = New System.Drawing.Point(1, 1)
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(113, 20)
        Me.txtAccountNumber.StateCommon.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.txtAccountNumber.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.txtAccountNumber.TabIndex = 4
        Me.txtAccountNumber.Values.Text = ""
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(114, 1)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(115, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(115, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.AutoSize = False
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(19, 211)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(821, 5)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(414, 127)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(75, 21)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 181
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(75, 20)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Project"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'cboPersonnel
        '
        Me.cboPersonnel.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboPersonnel.ArrowColor = System.Drawing.Color.Black
        Me.cboPersonnel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboPersonnel.BindedControl = Nothing
        Me.cboPersonnel.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboPersonnel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPersonnel.ColumnNum = 1
        Me.cboPersonnel.ColumnWidth = "121"
        Me.cboPersonnel.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboPersonnel.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboPersonnel.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboPersonnel.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboPersonnel.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboPersonnel.DisplayMember = "Text"
        Me.cboPersonnel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPersonnel.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboPersonnel.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboPersonnel.DropDownForeColor = System.Drawing.Color.Black
        Me.cboPersonnel.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboPersonnel.DropDownWidth = 141
        Me.cboPersonnel.ForeColor = System.Drawing.Color.Black
        Me.cboPersonnel.GridLineColor = System.Drawing.Color.LightGray
        Me.cboPersonnel.GridLineHorizontal = False
        Me.cboPersonnel.GridLineVertical = False
        Me.cboPersonnel.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboPersonnel.HighlightBorderOnMouseEvents = True
        Me.cboPersonnel.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboPersonnel.Location = New System.Drawing.Point(491, 154)
        Me.cboPersonnel.ManagingFastMouseMoving = True
        Me.cboPersonnel.ManagingFastMouseMovingInterval = 30
        Me.cboPersonnel.Name = "cboPersonnel"
        Me.cboPersonnel.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboPersonnel.SelectedItem = Nothing
        Me.cboPersonnel.SelectedValue = Nothing
        Me.cboPersonnel.Size = New System.Drawing.Size(353, 21)
        Me.cboPersonnel.Sorted = True
        Me.cboPersonnel.TabIndex = 155
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(414, 154)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(75, 21)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 146
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(75, 20)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Sales Agent"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'txtProjectNumber
        '
        Me.txtProjectNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtProjectNumber.Enabled = False
        Me.txtProjectNumber.ForeColor = System.Drawing.Color.Black
        Me.txtProjectNumber.Location = New System.Drawing.Point(762, 123)
        Me.txtProjectNumber.Name = "txtProjectNumber"
        Me.txtProjectNumber.Size = New System.Drawing.Size(82, 23)
        Me.txtProjectNumber.TabIndex = 159
        Me.txtProjectNumber.Text = "0"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(705, 127)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(51, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 158
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(51, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Prj No."
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(51, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(414, 81)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(76, 21)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 180
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(76, 20)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Doc. #"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(76, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'dpTransDate
        '
        Me.dpTransDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpTransDate.ForeColor = System.Drawing.Color.Black
        Me.dpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpTransDate.Location = New System.Drawing.Point(635, 39)
        Me.dpTransDate.Name = "dpTransDate"
        Me.dpTransDate.Size = New System.Drawing.Size(103, 20)
        Me.dpTransDate.TabIndex = 10
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(440, 54)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel3.TabIndex = 178
        Me.KryptonLabel3.Values.Text = "Invoice Details ..."
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtOrderNumber.ForeColor = System.Drawing.Color.Black
        Me.txtOrderNumber.Location = New System.Drawing.Point(491, 104)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(105, 23)
        Me.txtOrderNumber.TabIndex = 149
        '
        'txtReference
        '
        Me.txtReference.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtReference.Enabled = False
        Me.txtReference.ForeColor = System.Drawing.Color.Black
        Me.txtReference.Location = New System.Drawing.Point(491, 82)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(105, 23)
        Me.txtReference.TabIndex = 152
        Me.txtReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(414, 104)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(75, 21)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 145
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(75, 20)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Order no."
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'txtPhone
        '
        Me.txtPhone.BackColor = System.Drawing.Color.Transparent
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPhone.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtPhone.ForeColor = System.Drawing.Color.Black
        Me.txtPhone.Location = New System.Drawing.Point(206, 37)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(37, 21)
        Me.txtPhone.TabIndex = 157
        Me.txtPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtPhone.Visible = False
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.BackColor = System.Drawing.Color.Transparent
        Me.txtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtEmailAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtEmailAddress.ForeColor = System.Drawing.Color.Black
        Me.txtEmailAddress.Location = New System.Drawing.Point(249, 37)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(36, 21)
        Me.txtEmailAddress.TabIndex = 154
        Me.txtEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtEmailAddress.Visible = False
        '
        'chkOverrideNo
        '
        Me.chkOverrideNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkOverrideNo.ForeColor = System.Drawing.Color.Black
        Me.chkOverrideNo.Location = New System.Drawing.Point(601, 81)
        Me.chkOverrideNo.Name = "chkOverrideNo"
        Me.chkOverrideNo.Size = New System.Drawing.Size(81, 20)
        Me.chkOverrideNo.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkOverrideNo.TabIndex = 158
        Me.chkOverrideNo.Values.Text = "Override #"
        Me.chkOverrideNo.Visible = False
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.AutoSize = False
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(541, 66)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(300, 5)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.Color.Transparent
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtLastName.ForeColor = System.Drawing.Color.Black
        Me.txtLastName.Location = New System.Drawing.Point(155, 37)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(45, 21)
        Me.txtLastName.TabIndex = 156
        Me.txtLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtLastName.Visible = False
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.Location = New System.Drawing.Point(95, 106)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(300, 87)
        Me.txtAddress.TabIndex = 168
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge20)
        Me.KryptonPanel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel14.Location = New System.Drawing.Point(22, 106)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(71, 21)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 167
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(71, 20)
        Me.KryptonLabel10.TabIndex = 1
        Me.KryptonLabel10.Values.Text = "Address"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(71, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'chkOverideDate
        '
        Me.chkOverideDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkOverideDate.ForeColor = System.Drawing.Color.Black
        Me.chkOverideDate.Location = New System.Drawing.Point(743, 40)
        Me.chkOverideDate.Name = "chkOverideDate"
        Me.chkOverideDate.Size = New System.Drawing.Size(98, 20)
        Me.chkOverideDate.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkOverideDate.TabIndex = 153
        Me.chkOverideDate.Values.Text = "Override date"
        '
        'cboProjects
        '
        Me.cboProjects.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboProjects.ArrowColor = System.Drawing.Color.Black
        Me.cboProjects.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboProjects.BindedControl = Nothing
        Me.cboProjects.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboProjects.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboProjects.ColumnNum = 1
        Me.cboProjects.ColumnWidth = "121"
        Me.cboProjects.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboProjects.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboProjects.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboProjects.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboProjects.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboProjects.DisplayMember = "Text"
        Me.cboProjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboProjects.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboProjects.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboProjects.DropDownForeColor = System.Drawing.Color.Black
        Me.cboProjects.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDownList
        Me.cboProjects.DropDownWidth = 141
        Me.cboProjects.ForeColor = System.Drawing.Color.Black
        Me.cboProjects.GridLineColor = System.Drawing.Color.LightGray
        Me.cboProjects.GridLineHorizontal = False
        Me.cboProjects.GridLineVertical = False
        Me.cboProjects.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboProjects.HighlightBorderOnMouseEvents = True
        Me.cboProjects.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboProjects.Location = New System.Drawing.Point(491, 127)
        Me.cboProjects.ManagingFastMouseMoving = True
        Me.cboProjects.ManagingFastMouseMovingInterval = 30
        Me.cboProjects.Name = "cboProjects"
        Me.cboProjects.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboProjects.SelectedItem = Nothing
        Me.cboProjects.SelectedValue = Nothing
        Me.cboProjects.Size = New System.Drawing.Size(208, 21)
        Me.cboProjects.TabIndex = 155
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(16, 54)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(115, 20)
        Me.KryptonLabel2.TabIndex = 166
        Me.KryptonLabel2.Values.Text = "Customer Details ..."
        '
        'chkProjectStatus
        '
        Me.chkProjectStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkProjectStatus.ForeColor = System.Drawing.Color.Black
        Me.chkProjectStatus.Location = New System.Drawing.Point(601, 104)
        Me.chkProjectStatus.Name = "chkProjectStatus"
        Me.chkProjectStatus.Size = New System.Drawing.Size(115, 20)
        Me.chkProjectStatus.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkProjectStatus.TabIndex = 154
        Me.chkProjectStatus.Values.Text = "Is Project Invoice"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.AutoSize = False
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(133, 66)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(300, 5)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'btnFindAccount
        '
        Me.btnFindAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnFindAccount.ForeColor = System.Drawing.Color.Black
        Me.btnFindAccount.Location = New System.Drawing.Point(373, 81)
        Me.btnFindAccount.Name = "btnFindAccount"
        Me.btnFindAccount.Size = New System.Drawing.Size(21, 21)
        Me.btnFindAccount.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnFindAccount.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFindAccount.StateCommon.Back.ColorAngle = 100.0!
        Me.btnFindAccount.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnFindAccount.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFindAccount.StateCommon.Border.Rounding = 0
        Me.btnFindAccount.TabIndex = 149
        Me.btnFindAccount.Values.Image = CType(resources.GetObject("btnFindAccount.Values.Image"), System.Drawing.Image)
        Me.btnFindAccount.Values.Text = ""
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(858, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.White
        Me.Bar1.ColorScheme.BarCaptionInactiveBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar1.ColorScheme.ExplorerBarBackground = System.Drawing.Color.Transparent
        Me.Bar1.ColorScheme.ItemCheckedBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar1.ColorScheme.MenuBarBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSaveClose, Me.btnSaveNew, Me.btnSearch, Me.btnRemoveItem, Me.btnPrint, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(858, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 163
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnSaveClose
        '
        Me.btnSaveClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSaveClose.Image = CType(resources.GetObject("btnSaveClose.Image"), System.Drawing.Image)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSaveClose.Text = "&Save and Close"
        '
        'btnSaveNew
        '
        Me.btnSaveNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSaveNew.Image = CType(resources.GetObject("btnSaveNew.Image"), System.Drawing.Image)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSaveNew.Text = "Save and New"
        Me.btnSaveNew.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.BeginGroup = True
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Text = "Find"
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.BeginGroup = True
        Me.btnRemoveItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRemoveItem.Image = CType(resources.GetObject("btnRemoveItem.Image"), System.Drawing.Image)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnRemoveItem.Text = "Delete Entry"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "&Print"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnRefresh.Text = "Refresh"
        '
        'KryptonGroupBox5
        '
        Me.KryptonGroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox5.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox5.Location = New System.Drawing.Point(19, 415)
        Me.KryptonGroupBox5.Name = "KryptonGroupBox5"
        '
        'KryptonGroupBox5.Panel
        '
        Me.KryptonGroupBox5.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox5.Panel.Controls.Add(Me.txtComments)
        Me.KryptonGroupBox5.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox5.Panel.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.KryptonGroupBox5.Size = New System.Drawing.Size(555, 159)
        Me.KryptonGroupBox5.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox5.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox5.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox5.TabIndex = 146
        Me.KryptonGroupBox5.Values.Heading = "Notes"
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtComments.ForeColor = System.Drawing.Color.Black
        Me.txtComments.Location = New System.Drawing.Point(5, 0)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(543, 131)
        Me.txtComments.TabIndex = 148
        '
        'KryptonGroupBox4
        '
        Me.KryptonGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox4.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox4.Location = New System.Drawing.Point(593, 415)
        Me.KryptonGroupBox4.Name = "KryptonGroupBox4"
        '
        'KryptonGroupBox4.Panel
        '
        Me.KryptonGroupBox4.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.lblTaxable)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.lblSubTotal)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.lblPayable)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.Label2)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.Label8)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.Label3)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.lblTaxes)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.Label4)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.lblDiscounts)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.Label5)
        Me.KryptonGroupBox4.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox4.Size = New System.Drawing.Size(250, 159)
        Me.KryptonGroupBox4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox4.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox4.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox4.TabIndex = 145
        Me.KryptonGroupBox4.Values.Heading = "Totals"
        '
        'lblTaxable
        '
        Me.lblTaxable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTaxable.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTaxable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTaxable.ForeColor = System.Drawing.Color.Black
        Me.lblTaxable.Location = New System.Drawing.Point(119, 57)
        Me.lblTaxable.Name = "lblTaxable"
        Me.lblTaxable.Size = New System.Drawing.Size(109, 22)
        Me.lblTaxable.TabIndex = 64
        Me.lblTaxable.Text = "0.00"
        Me.lblTaxable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSubTotal.ForeColor = System.Drawing.Color.Black
        Me.lblSubTotal.Location = New System.Drawing.Point(119, 11)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(109, 22)
        Me.lblSubTotal.TabIndex = 56
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPayable
        '
        Me.lblPayable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPayable.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPayable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPayable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPayable.ForeColor = System.Drawing.Color.Black
        Me.lblPayable.Location = New System.Drawing.Point(119, 103)
        Me.lblPayable.Name = "lblPayable"
        Me.lblPayable.Size = New System.Drawing.Size(109, 22)
        Me.lblPayable.TabIndex = 62
        Me.lblPayable.Text = "0.00"
        Me.lblPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 22)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Sub Total"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 22)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Taxable Amt"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 22)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Discounts"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTaxes
        '
        Me.lblTaxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTaxes.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTaxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTaxes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTaxes.ForeColor = System.Drawing.Color.Black
        Me.lblTaxes.Location = New System.Drawing.Point(119, 80)
        Me.lblTaxes.Name = "lblTaxes"
        Me.lblTaxes.Size = New System.Drawing.Size(109, 22)
        Me.lblTaxes.TabIndex = 61
        Me.lblTaxes.Text = "0.00"
        Me.lblTaxes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 22)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Taxes"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiscounts
        '
        Me.lblDiscounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscounts.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiscounts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDiscounts.ForeColor = System.Drawing.Color.Black
        Me.lblDiscounts.Location = New System.Drawing.Point(119, 34)
        Me.lblDiscounts.Name = "lblDiscounts"
        Me.lblDiscounts.Size = New System.Drawing.Size(109, 22)
        Me.lblDiscounts.TabIndex = 60
        Me.lblDiscounts.Text = "0.00"
        Me.lblDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 22)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Total Payable"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(19, 219)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.picDocumentImage)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboSerials)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboItems)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dGrid)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(822, 190)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 144
        Me.KryptonGroupBox1.Values.Heading = "Invoice items"
        '
        'picDocumentImage
        '
        Me.picDocumentImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.picDocumentImage.ForeColor = System.Drawing.Color.Black
        Me.picDocumentImage.Location = New System.Drawing.Point(634, 41)
        Me.picDocumentImage.Name = "picDocumentImage"
        Me.picDocumentImage.Size = New System.Drawing.Size(171, 106)
        Me.picDocumentImage.TabIndex = 101
        Me.picDocumentImage.TabStop = False
        Me.picDocumentImage.Visible = False
        '
        'cboSerials
        '
        Me.cboSerials.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSerials.ArrowColor = System.Drawing.Color.Black
        Me.cboSerials.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboSerials.BindedControl = Nothing
        Me.cboSerials.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSerials.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSerials.ColumnNum = 1
        Me.cboSerials.ColumnWidth = "121"
        Me.cboSerials.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSerials.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSerials.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSerials.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSerials.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSerials.DisplayMember = "Text"
        Me.cboSerials.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSerials.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSerials.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSerials.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSerials.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSerials.DropDownWidth = 141
        Me.cboSerials.ForeColor = System.Drawing.Color.Black
        Me.cboSerials.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSerials.GridLineHorizontal = False
        Me.cboSerials.GridLineVertical = False
        Me.cboSerials.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboSerials.HighlightBorderOnMouseEvents = True
        Me.cboSerials.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSerials.Location = New System.Drawing.Point(477, 104)
        Me.cboSerials.ManagingFastMouseMoving = True
        Me.cboSerials.ManagingFastMouseMovingInterval = 30
        Me.cboSerials.Name = "cboSerials"
        Me.cboSerials.NormalBorderColor = System.Drawing.Color.WhiteSmoke
        Me.cboSerials.SelectedItem = Nothing
        Me.cboSerials.SelectedValue = Nothing
        Me.cboSerials.Size = New System.Drawing.Size(147, 21)
        Me.cboSerials.Sorted = True
        Me.cboSerials.TabIndex = 12
        Me.cboSerials.Visible = False
        '
        'cboItems
        '
        Me.cboItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.ArrowColor = System.Drawing.Color.Black
        Me.cboItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboItems.BindedControl = Nothing
        Me.cboItems.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboItems.ColumnNum = 1
        Me.cboItems.ColumnWidth = "121"
        Me.cboItems.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboItems.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboItems.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboItems.DisplayMember = "Text"
        Me.cboItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboItems.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboItems.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboItems.DropDownForeColor = System.Drawing.Color.Black
        Me.cboItems.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboItems.DropDownWidth = 141
        Me.cboItems.ForeColor = System.Drawing.Color.Black
        Me.cboItems.GridLineColor = System.Drawing.Color.LightGray
        Me.cboItems.GridLineHorizontal = False
        Me.cboItems.GridLineVertical = False
        Me.cboItems.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboItems.HighlightBorderOnMouseEvents = True
        Me.cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboItems.Location = New System.Drawing.Point(198, 58)
        Me.cboItems.ManagingFastMouseMoving = True
        Me.cboItems.ManagingFastMouseMovingInterval = 30
        Me.cboItems.Name = "cboItems"
        Me.cboItems.NormalBorderColor = System.Drawing.Color.WhiteSmoke
        Me.cboItems.SelectedItem = Nothing
        Me.cboItems.SelectedValue = Nothing
        Me.cboItems.Size = New System.Drawing.Size(294, 21)
        Me.cboItems.Sorted = True
        Me.cboItems.TabIndex = 11
        Me.cboItems.Visible = False
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column8, Me.Column4, Me.Column3, Me.Column9, Me.Column5, Me.Column6, Me.Column7, Me.Column10, Me.Column11})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.Size = New System.Drawing.Size(820, 167)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Name"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 190
        '
        'Column2
        '
        Me.Column2.HeaderText = "Description"
        Me.Column2.MaxInputLength = 300
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 200
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column8.HeaderText = "Serial No"
        Me.Column8.Name = "Column8"
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 69
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column4.HeaderText = "Unit Price"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 71
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 37
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column9.HeaderText = "Sub Total"
        Me.Column9.Name = "Column9"
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column9.Visible = False
        Me.Column9.Width = 65
        '
        'Column5
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column5.HeaderText = "Discount"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 90
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column6.HeaderText = "Tax"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 37
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column7.HeaderText = "Line Total"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 71
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column10.HeaderText = "Type"
        Me.Column10.Name = "Column10"
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column10.Visible = False
        Me.Column10.Width = 41
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column11.HeaderText = "Serial Tid"
        Me.Column11.Name = "Column11"
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column11.Visible = False
        Me.Column11.Width = 64
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel16.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel16.Location = New System.Drawing.Point(21, 81)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Size = New System.Drawing.Size(71, 21)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel16.TabIndex = 142
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(71, 20)
        Me.KryptonLabel12.TabIndex = 1
        Me.KryptonLabel12.Values.Text = "Name"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(71, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'cboSupplierName
        '
        Me.cboSupplierName.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSupplierName.ArrowColor = System.Drawing.Color.Black
        Me.cboSupplierName.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
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
        Me.cboSupplierName.ForeColor = System.Drawing.Color.Black
        Me.cboSupplierName.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.GridLineHorizontal = False
        Me.cboSupplierName.GridLineVertical = False
        Me.cboSupplierName.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.HighlightBorderOnMouseEvents = True
        Me.cboSupplierName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSupplierName.Location = New System.Drawing.Point(95, 81)
        Me.cboSupplierName.ManagingFastMouseMoving = True
        Me.cboSupplierName.ManagingFastMouseMovingInterval = 30
        Me.cboSupplierName.Name = "cboSupplierName"
        Me.cboSupplierName.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboSupplierName.SelectedItem = Nothing
        Me.cboSupplierName.SelectedValue = Nothing
        Me.cboSupplierName.Size = New System.Drawing.Size(275, 21)
        Me.cboSupplierName.TabIndex = 143
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(858, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(1, 588)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(858, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(859, 0)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(1, 589)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 589)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'PrintDocument1
        '
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
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.miniToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.miniToolStrip.Size = New System.Drawing.Size(871, 22)
        Me.miniToolStrip.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(10, 1)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'KryptonTextBox2
        '
        Me.KryptonTextBox2.Enabled = False
        Me.KryptonTextBox2.Location = New System.Drawing.Point(101, 32)
        Me.KryptonTextBox2.Name = "KryptonTextBox2"
        Me.KryptonTextBox2.Size = New System.Drawing.Size(322, 20)
        Me.KryptonTextBox2.TabIndex = 146
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Location = New System.Drawing.Point(107, 33)
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.Size = New System.Drawing.Size(115, 20)
        Me.KryptonTextBox1.TabIndex = 149
        '
        'pdAirInvoice
        '
        '
        'txtFiscalDay
        '
        Me.txtFiscalDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtFiscalDay.ForeColor = System.Drawing.Color.Black
        Me.txtFiscalDay.Location = New System.Drawing.Point(492, 176)
        Me.txtFiscalDay.Name = "txtFiscalDay"
        Me.txtFiscalDay.Size = New System.Drawing.Size(104, 23)
        Me.txtFiscalDay.TabIndex = 210
        Me.txtFiscalDay.Text = "0"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(415, 180)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(75, 21)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 209
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(75, 20)
        Me.KryptonLabel8.TabIndex = 1
        Me.KryptonLabel8.Values.Text = "Fiscal Day"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'txtFiscalInvoiceNo
        '
        Me.txtFiscalInvoiceNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtFiscalInvoiceNo.ForeColor = System.Drawing.Color.Black
        Me.txtFiscalInvoiceNo.Location = New System.Drawing.Point(762, 177)
        Me.txtFiscalInvoiceNo.Name = "txtFiscalInvoiceNo"
        Me.txtFiscalInvoiceNo.Size = New System.Drawing.Size(82, 23)
        Me.txtFiscalInvoiceNo.TabIndex = 212
        Me.txtFiscalInvoiceNo.Text = "0"
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(637, 180)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(119, 21)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel7.TabIndex = 211
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel9.TabIndex = 1
        Me.KryptonLabel9.Values.Text = "Fiscal Invoice No. "
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(119, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 589)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvoice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox5.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox5.Panel.ResumeLayout(False)
        Me.KryptonGroupBox5.Panel.PerformLayout()
        CType(Me.KryptonGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox5.ResumeLayout(False)
        CType(Me.KryptonGroupBox4.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox4.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox4.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.picDocumentImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        Me.KryptonPanel16.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdWindows As System.Drawing.Printing.PrintDocument
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents chkOverideDate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtReference As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtOrderNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents dpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboSupplierName As MTGCComboBox
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents miniToolStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents KryptonGroupBox5 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtComments As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonGroupBox4 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Private WithEvents lblTaxable As System.Windows.Forms.Label
    Private WithEvents lblSubTotal As System.Windows.Forms.Label
    Private WithEvents lblPayable As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents lblTaxes As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents lblDiscounts As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents cboSerials As MTGCComboBox
    Friend WithEvents cboItems As MTGCComboBox
    Friend WithEvents txtEmailAddress As System.Windows.Forms.Label
    Friend WithEvents picDocumentImage As System.Windows.Forms.PictureBox
    Friend WithEvents cboPersonnel As MTGCComboBox
    Friend WithEvents txtPhone As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonTextBox2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnFindAccount As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkOverrideNo As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtProjectNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboProjects As MTGCComboBox
    Friend WithEvents chkProjectStatus As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents pdAirInvoice As System.Drawing.Printing.PrintDocument
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSaveClose As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSaveNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRemoveItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtAddress As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtAccountNumber As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtFiscalInvoiceNo As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtFiscalDay As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
