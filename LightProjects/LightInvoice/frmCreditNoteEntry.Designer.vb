<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditNoteEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreditNoteEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdWindows = New System.Drawing.Printing.PrintDocument()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.picDocumentImage = New System.Windows.Forms.PictureBox()
        Me.cboSerials = New MTGCComboBox()
        Me.cboItems = New MTGCComboBox()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblInvoiceNumber = New System.Windows.Forms.Label()
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
        Me.txtNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtReference = New MTGCComboBox()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cboAccountDetails = New MTGCComboBox()
        Me.lblAccountNumber = New System.Windows.Forms.Label()
        Me.btnSearchAccountHolder = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblDocumentNumber = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
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
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.picDocumentImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
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
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(789, 528)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(1, 31)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(787, 496)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 8
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 1)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(3)
        Me.KryptonPanel2.Size = New System.Drawing.Size(787, 495)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 18
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(3, 101)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(781, 254)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel6.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel6.TabIndex = 17
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.White
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.picDocumentImage)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboSerials)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboItems)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dGrid)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(781, 254)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 13
        Me.KryptonGroupBox1.Text = "Items and Expenses"
        Me.KryptonGroupBox1.Values.Heading = "Items and Expenses"
        '
        'picDocumentImage
        '
        Me.picDocumentImage.BackColor = System.Drawing.Color.White
        Me.picDocumentImage.ForeColor = System.Drawing.Color.Black
        Me.picDocumentImage.Location = New System.Drawing.Point(599, 77)
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
        Me.cboSerials.BackColor = System.Drawing.Color.White
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
        Me.cboSerials.Location = New System.Drawing.Point(324, 134)
        Me.cboSerials.ManagingFastMouseMoving = True
        Me.cboSerials.ManagingFastMouseMovingInterval = 30
        Me.cboSerials.Name = "cboSerials"
        Me.cboSerials.NormalBorderColor = System.Drawing.Color.WhiteSmoke
        Me.cboSerials.SelectedItem = Nothing
        Me.cboSerials.SelectedValue = Nothing
        Me.cboSerials.Size = New System.Drawing.Size(147, 21)
        Me.cboSerials.Sorted = True
        Me.cboSerials.TabIndex = 14
        Me.cboSerials.Visible = False
        '
        'cboItems
        '
        Me.cboItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.ArrowColor = System.Drawing.Color.Black
        Me.cboItems.BackColor = System.Drawing.Color.White
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
        Me.cboItems.Location = New System.Drawing.Point(177, 94)
        Me.cboItems.ManagingFastMouseMoving = True
        Me.cboItems.ManagingFastMouseMovingInterval = 30
        Me.cboItems.Name = "cboItems"
        Me.cboItems.NormalBorderColor = System.Drawing.Color.WhiteSmoke
        Me.cboItems.SelectedItem = Nothing
        Me.cboItems.SelectedValue = Nothing
        Me.cboItems.Size = New System.Drawing.Size(294, 21)
        Me.cboItems.Sorted = True
        Me.cboItems.TabIndex = 13
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
        Me.dGrid.Size = New System.Drawing.Size(779, 231)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.TabIndex = 1
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.lblInvoiceNumber)
        Me.KryptonPanel5.Controls.Add(Me.lblTaxable)
        Me.KryptonPanel5.Controls.Add(Me.lblSubTotal)
        Me.KryptonPanel5.Controls.Add(Me.lblPayable)
        Me.KryptonPanel5.Controls.Add(Me.Label2)
        Me.KryptonPanel5.Controls.Add(Me.Label8)
        Me.KryptonPanel5.Controls.Add(Me.Label3)
        Me.KryptonPanel5.Controls.Add(Me.lblTaxes)
        Me.KryptonPanel5.Controls.Add(Me.Label4)
        Me.KryptonPanel5.Controls.Add(Me.lblDiscounts)
        Me.KryptonPanel5.Controls.Add(Me.Label5)
        Me.KryptonPanel5.Controls.Add(Me.txtNotes)
        Me.KryptonPanel5.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(3, 355)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(781, 137)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 16
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.BackColor = System.Drawing.Color.White
        Me.lblInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInvoiceNumber.ForeColor = System.Drawing.Color.Black
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(12, 57)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(63, 22)
        Me.lblInvoiceNumber.TabIndex = 75
        Me.lblInvoiceNumber.Visible = False
        '
        'lblTaxable
        '
        Me.lblTaxable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTaxable.BackColor = System.Drawing.Color.White
        Me.lblTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTaxable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTaxable.ForeColor = System.Drawing.Color.Black
        Me.lblTaxable.Location = New System.Drawing.Point(658, 58)
        Me.lblTaxable.Name = "lblTaxable"
        Me.lblTaxable.Size = New System.Drawing.Size(109, 22)
        Me.lblTaxable.TabIndex = 74
        Me.lblTaxable.Text = "0.00"
        Me.lblTaxable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.BackColor = System.Drawing.Color.White
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSubTotal.ForeColor = System.Drawing.Color.Black
        Me.lblSubTotal.Location = New System.Drawing.Point(658, 12)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(109, 22)
        Me.lblSubTotal.TabIndex = 66
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPayable
        '
        Me.lblPayable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPayable.BackColor = System.Drawing.Color.White
        Me.lblPayable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPayable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPayable.ForeColor = System.Drawing.Color.Black
        Me.lblPayable.Location = New System.Drawing.Point(658, 104)
        Me.lblPayable.Name = "lblPayable"
        Me.lblPayable.Size = New System.Drawing.Size(109, 22)
        Me.lblPayable.TabIndex = 72
        Me.lblPayable.Text = "0.00"
        Me.lblPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(559, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 22)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Sub Total"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(559, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 22)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Taxable Amt"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(559, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 22)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Discounts"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTaxes
        '
        Me.lblTaxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTaxes.BackColor = System.Drawing.Color.White
        Me.lblTaxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTaxes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTaxes.ForeColor = System.Drawing.Color.Black
        Me.lblTaxes.Location = New System.Drawing.Point(658, 81)
        Me.lblTaxes.Name = "lblTaxes"
        Me.lblTaxes.Size = New System.Drawing.Size(109, 22)
        Me.lblTaxes.TabIndex = 71
        Me.lblTaxes.Text = "0.00"
        Me.lblTaxes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(559, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 22)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Taxes"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiscounts
        '
        Me.lblDiscounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscounts.BackColor = System.Drawing.Color.White
        Me.lblDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiscounts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDiscounts.ForeColor = System.Drawing.Color.Black
        Me.lblDiscounts.Location = New System.Drawing.Point(658, 35)
        Me.lblDiscounts.Name = "lblDiscounts"
        Me.lblDiscounts.Size = New System.Drawing.Size(109, 22)
        Me.lblDiscounts.TabIndex = 70
        Me.lblDiscounts.Text = "0.00"
        Me.lblDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(559, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 22)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Total Payable"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.Location = New System.Drawing.Point(79, 12)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(466, 114)
        Me.txtNotes.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.txtNotes.StateCommon.Border.Rounding = 5
        Me.txtNotes.TabIndex = 11
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(6, 14)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(70, 22)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel7.TabIndex = 10
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(70, 21)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Notes"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(70, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.dpDate)
        Me.KryptonPanel4.Controls.Add(Me.txtReference)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel12)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel11)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel4.Controls.Add(Me.lblDocumentNumber)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(781, 98)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel4.StateCommon.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonPanel4.TabIndex = 15
        '
        'dpDate
        '
        Me.dpDate.BackColor = System.Drawing.Color.White
        Me.dpDate.ForeColor = System.Drawing.Color.Black
        Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDate.Location = New System.Drawing.Point(138, 17)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(112, 20)
        Me.dpDate.TabIndex = 4
        '
        'txtReference
        '
        Me.txtReference.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.txtReference.ArrowColor = System.Drawing.Color.Black
        Me.txtReference.BackColor = System.Drawing.Color.White
        Me.txtReference.BindedControl = Nothing
        Me.txtReference.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtReference.ColumnNum = 1
        Me.txtReference.ColumnWidth = "121"
        Me.txtReference.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.txtReference.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.txtReference.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.txtReference.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtReference.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.txtReference.DisplayMember = "Text"
        Me.txtReference.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtReference.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txtReference.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.txtReference.DropDownForeColor = System.Drawing.Color.Black
        Me.txtReference.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDownList
        Me.txtReference.DropDownWidth = 141
        Me.txtReference.ForeColor = System.Drawing.Color.Black
        Me.txtReference.GridLineColor = System.Drawing.Color.LightGray
        Me.txtReference.GridLineHorizontal = False
        Me.txtReference.GridLineVertical = False
        Me.txtReference.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.txtReference.HighlightBorderOnMouseEvents = True
        Me.txtReference.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.txtReference.Location = New System.Drawing.Point(138, 65)
        Me.txtReference.ManagingFastMouseMoving = True
        Me.txtReference.ManagingFastMouseMovingInterval = 30
        Me.txtReference.Name = "txtReference"
        Me.txtReference.NormalBorderColor = System.Drawing.Color.LightGray
        Me.txtReference.SelectedItem = Nothing
        Me.txtReference.SelectedValue = Nothing
        Me.txtReference.Size = New System.Drawing.Size(112, 21)
        Me.txtReference.TabIndex = 62
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(10, 64)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(126, 22)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel12.TabIndex = 61
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.White
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(126, 21)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Source Invoice #"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(126, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(10, 41)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(126, 22)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 59
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.White
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(126, 21)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Document #"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(126, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(10, 15)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(126, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 58
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.White
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(126, 21)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Transaction date"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(126, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.BackColor = System.Drawing.Color.White
        Me.KryptonGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(276, 4)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.cboAccountDetails)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.lblAccountNumber)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.btnSearchAccountHolder)
        Me.KryptonGroupBox2.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(495, 82)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 57
        Me.KryptonGroupBox2.Text = "Account holder details"
        Me.KryptonGroupBox2.Values.Heading = "Account holder details"
        '
        'cboAccountDetails
        '
        Me.cboAccountDetails.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccountDetails.ArrowColor = System.Drawing.Color.Black
        Me.cboAccountDetails.BackColor = System.Drawing.Color.White
        Me.cboAccountDetails.BindedControl = Nothing
        Me.cboAccountDetails.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboAccountDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboAccountDetails.ColumnNum = 1
        Me.cboAccountDetails.ColumnWidth = "121"
        Me.cboAccountDetails.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccountDetails.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboAccountDetails.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboAccountDetails.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboAccountDetails.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboAccountDetails.DisplayMember = "Text"
        Me.cboAccountDetails.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboAccountDetails.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboAccountDetails.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboAccountDetails.DropDownForeColor = System.Drawing.Color.Black
        Me.cboAccountDetails.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboAccountDetails.DropDownWidth = 141
        Me.cboAccountDetails.ForeColor = System.Drawing.Color.Black
        Me.cboAccountDetails.GridLineColor = System.Drawing.Color.LightGray
        Me.cboAccountDetails.GridLineHorizontal = False
        Me.cboAccountDetails.GridLineVertical = False
        Me.cboAccountDetails.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboAccountDetails.HighlightBorderOnMouseEvents = True
        Me.cboAccountDetails.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboAccountDetails.Location = New System.Drawing.Point(17, 6)
        Me.cboAccountDetails.ManagingFastMouseMoving = True
        Me.cboAccountDetails.ManagingFastMouseMovingInterval = 30
        Me.cboAccountDetails.Name = "cboAccountDetails"
        Me.cboAccountDetails.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboAccountDetails.SelectedItem = Nothing
        Me.cboAccountDetails.SelectedValue = Nothing
        Me.cboAccountDetails.Size = New System.Drawing.Size(435, 21)
        Me.cboAccountDetails.TabIndex = 17
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccountNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Location = New System.Drawing.Point(17, 30)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(458, 22)
        Me.lblAccountNumber.TabIndex = 56
        Me.lblAccountNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSearchAccountHolder
        '
        Me.btnSearchAccountHolder.BackColor = System.Drawing.Color.White
        Me.btnSearchAccountHolder.ForeColor = System.Drawing.Color.Black
        Me.btnSearchAccountHolder.Location = New System.Drawing.Point(455, 6)
        Me.btnSearchAccountHolder.Name = "btnSearchAccountHolder"
        Me.btnSearchAccountHolder.Size = New System.Drawing.Size(21, 21)
        Me.btnSearchAccountHolder.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnSearchAccountHolder.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSearchAccountHolder.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSearchAccountHolder.StateCommon.Border.Rounding = 0
        Me.btnSearchAccountHolder.TabIndex = 55
        Me.btnSearchAccountHolder.Values.Image = CType(resources.GetObject("btnSearchAccountHolder.Values.Image"), System.Drawing.Image)
        Me.btnSearchAccountHolder.Values.Text = ""
        '
        'lblDocumentNumber
        '
        Me.lblDocumentNumber.BackColor = System.Drawing.Color.White
        Me.lblDocumentNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDocumentNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNumber.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentNumber.Location = New System.Drawing.Point(138, 41)
        Me.lblDocumentNumber.Name = "lblDocumentNumber"
        Me.lblDocumentNumber.Size = New System.Drawing.Size(112, 22)
        Me.lblDocumentNumber.TabIndex = 20
        Me.lblDocumentNumber.Text = "1"
        Me.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(787, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 30)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(787, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.White
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(787, 29)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 6
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSave.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSave.Text = "Save"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(788, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 526)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 526)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 527)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(789, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(789, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Name (or code)"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 190
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Description"
        Me.Column2.MaxInputLength = 300
        Me.Column2.MinimumWidth = 250
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 250
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column8.HeaderText = "Serial No"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Visible = False
        Me.Column8.Width = 69
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "Unit Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 71
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
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
        Me.Column9.ReadOnly = True
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column9.Visible = False
        Me.Column9.Width = 70
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Discount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Visible = False
        Me.Column5.Width = 90
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "Tax"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 37
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle5
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
        Me.Column10.ReadOnly = True
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column10.Visible = False
        Me.Column10.Width = 44
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column11.HeaderText = "Serial Tid"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column11.Visible = False
        Me.Column11.Width = 71
        '
        'frmCreditNoteEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 528)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreditNoteEntry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Credit Note Entry"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.picDocumentImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdWindows As System.Drawing.Printing.PrintDocument
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents picDocumentImage As System.Windows.Forms.PictureBox
    Friend WithEvents cboSerials As MTGCComboBox
    Friend WithEvents cboItems As MTGCComboBox
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblInvoiceNumber As System.Windows.Forms.Label
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
    Friend WithEvents txtNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtReference As MTGCComboBox
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents cboAccountDetails As MTGCComboBox
    Friend WithEvents lblAccountNumber As System.Windows.Forms.Label
    Friend WithEvents btnSearchAccountHolder As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblDocumentNumber As System.Windows.Forms.Label
    Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
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
End Class