<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoyalityCustmerTransactionEntries
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoyalityCustmerTransactionEntries))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.grpReceiptEntries = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridSales = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonGroup4 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnClear = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnRemove = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnFinish = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pnlTotals = New System.Windows.Forms.Panel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblTaxes = New System.Windows.Forms.Label()
        Me.lblDiscounts = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grpSalesDetails = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.lblLoyalityCategory = New System.Windows.Forms.Label()
        Me.cboServiceClass = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblLoyalityAccountHolder = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtLoyalityAccount = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnFind = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSalesTax = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.txtShortCode = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnNewItem = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.cboPersonnel = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAcceptSaleEntry = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.dpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.chkOverideDate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.lblCostPrice = New System.Windows.Forms.Label()
        Me.txtNotes = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCurrentPayable = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPriceOnSale = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblItemDescription = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSalesDiscount = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtSalesQty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtBarcode = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        CType(Me.grpReceiptEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpReceiptEntries.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpReceiptEntries.Panel.SuspendLayout()
        Me.grpReceiptEntries.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dGridSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup4.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup4.Panel.SuspendLayout()
        Me.KryptonGroup4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlTotals.SuspendLayout()
        CType(Me.grpSalesDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSalesDetails.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSalesDetails.Panel.SuspendLayout()
        Me.grpSalesDetails.SuspendLayout()
        CType(Me.cboServiceClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPersonnel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.TabControlPanel3)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(3)
        Me.KryptonPanel.Size = New System.Drawing.Size(888, 650)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 1
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.grpReceiptEntries)
        Me.TabControlPanel3.Controls.Add(Me.KryptonGroup4)
        Me.TabControlPanel3.Controls.Add(Me.grpSalesDetails)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(882, 644)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 5
        '
        'grpReceiptEntries
        '
        Me.grpReceiptEntries.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpReceiptEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpReceiptEntries.ForeColor = System.Drawing.Color.Black
        Me.grpReceiptEntries.Location = New System.Drawing.Point(1, 1)
        Me.grpReceiptEntries.Name = "grpReceiptEntries"
        '
        'grpReceiptEntries.Panel
        '
        Me.grpReceiptEntries.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.grpReceiptEntries.Panel.Controls.Add(Me.KryptonPanel2)
        Me.grpReceiptEntries.Panel.ForeColor = System.Drawing.Color.Black
        Me.grpReceiptEntries.Size = New System.Drawing.Size(578, 525)
        Me.grpReceiptEntries.StateCommon.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grpReceiptEntries.TabIndex = 4
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.dGridSales)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(577, 523)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 1
        '
        'dGridSales
        '
        Me.dGridSales.AllowUserToAddRows = False
        Me.dGridSales.AllowUserToDeleteRows = False
        Me.dGridSales.AllowUserToResizeRows = False
        Me.dGridSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column7, Me.DataGridViewTextBoxColumn2, Me.Column3, Me.Column14, Me.Column1, Me.Column2})
        Me.dGridSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSales.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet
        Me.dGridSales.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet
        Me.dGridSales.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.dGridSales.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.dGridSales.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.dGridSales.Location = New System.Drawing.Point(0, 0)
        Me.dGridSales.Name = "dGridSales"
        Me.dGridSales.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003
        Me.dGridSales.ReadOnly = True
        Me.dGridSales.RowHeadersWidth = 25
        Me.dGridSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridSales.Size = New System.Drawing.Size(577, 523)
        Me.dGridSales.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridSales.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet
        Me.dGridSales.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dGridSales.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSales.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSales.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridSales.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSales.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dGridSales.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSales.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSales.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dGridSales.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 59
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column7.HeaderText = "Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 61
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 89
        '
        'Column3
        '
        Me.Column3.HeaderText = "Sales Rep"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Category"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0.00"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Amount"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Account"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'KryptonGroup4
        '
        Me.KryptonGroup4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroup4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonGroup4.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup4.Location = New System.Drawing.Point(1, 526)
        Me.KryptonGroup4.Name = "KryptonGroup4"
        '
        'KryptonGroup4.Panel
        '
        Me.KryptonGroup4.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroup4.Panel.Controls.Add(Me.Panel2)
        Me.KryptonGroup4.Panel.Controls.Add(Me.pnlTotals)
        Me.KryptonGroup4.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup4.Size = New System.Drawing.Size(578, 117)
        Me.KryptonGroup4.StateCommon.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup4.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.btnClear)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.btnFinish)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(321, 116)
        Me.Panel2.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSize = True
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Location = New System.Drawing.Point(86, 21)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.btnRefresh.Size = New System.Drawing.Size(74, 74)
        Me.btnRefresh.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnRefresh.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnRefresh.StateCommon.Back.ColorAngle = 100.0!
        Me.btnRefresh.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma
        Me.btnRefresh.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRefresh.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRefresh.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRefresh.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnRefresh.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRefresh.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnRefresh.TabIndex = 12
        Me.btnRefresh.Values.ExtraText = "F5"
        Me.btnRefresh.Values.Image = CType(resources.GetObject("btnRefresh.Values.Image"), System.Drawing.Image)
        Me.btnRefresh.Values.Text = "Refresh"
        '
        'btnClear
        '
        Me.btnClear.AutoSize = True
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(238, 21)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.btnClear.Size = New System.Drawing.Size(74, 74)
        Me.btnClear.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnClear.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnClear.StateCommon.Back.ColorAngle = 100.0!
        Me.btnClear.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma
        Me.btnClear.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnClear.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnClear.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnClear.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnClear.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnClear.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnClear.TabIndex = 11
        Me.btnClear.Values.ExtraText = "F8"
        Me.btnClear.Values.Image = CType(resources.GetObject("btnClear.Values.Image"), System.Drawing.Image)
        Me.btnClear.Values.Text = "Cancel All"
        '
        'btnRemove
        '
        Me.btnRemove.AutoSize = True
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.Location = New System.Drawing.Point(162, 21)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.btnRemove.Size = New System.Drawing.Size(74, 74)
        Me.btnRemove.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnRemove.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnRemove.StateCommon.Back.ColorAngle = 100.0!
        Me.btnRemove.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma
        Me.btnRemove.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRemove.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRemove.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRemove.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnRemove.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnRemove.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnRemove.TabIndex = 10
        Me.btnRemove.Values.ExtraText = "F9"
        Me.btnRemove.Values.Image = CType(resources.GetObject("btnRemove.Values.Image"), System.Drawing.Image)
        Me.btnRemove.Values.Text = "Remove"
        '
        'btnFinish
        '
        Me.btnFinish.AutoSize = True
        Me.btnFinish.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnFinish.ForeColor = System.Drawing.Color.Black
        Me.btnFinish.Location = New System.Drawing.Point(10, 21)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.btnFinish.Size = New System.Drawing.Size(74, 74)
        Me.btnFinish.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnFinish.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFinish.StateCommon.Back.ColorAngle = 100.0!
        Me.btnFinish.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma
        Me.btnFinish.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnFinish.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnFinish.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnFinish.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnFinish.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnFinish.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnFinish.TabIndex = 9
        Me.btnFinish.Values.ExtraText = "F3"
        Me.btnFinish.Values.Image = CType(resources.GetObject("btnFinish.Values.Image"), System.Drawing.Image)
        Me.btnFinish.Values.Text = "Finish"
        '
        'pnlTotals
        '
        Me.pnlTotals.BackColor = System.Drawing.Color.Transparent
        Me.pnlTotals.Controls.Add(Me.KryptonBorderEdge9)
        Me.pnlTotals.Controls.Add(Me.lblTaxes)
        Me.pnlTotals.Controls.Add(Me.lblDiscounts)
        Me.pnlTotals.Controls.Add(Me.Label10)
        Me.pnlTotals.Controls.Add(Me.Label11)
        Me.pnlTotals.Controls.Add(Me.lblSubTotal)
        Me.pnlTotals.Controls.Add(Me.Label12)
        Me.pnlTotals.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTotals.ForeColor = System.Drawing.Color.Black
        Me.pnlTotals.Location = New System.Drawing.Point(321, 0)
        Me.pnlTotals.Name = "pnlTotals"
        Me.pnlTotals.Size = New System.Drawing.Size(256, 116)
        Me.pnlTotals.TabIndex = 0
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(1, 116)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'lblTaxes
        '
        Me.lblTaxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTaxes.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTaxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTaxes.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblTaxes.ForeColor = System.Drawing.Color.Black
        Me.lblTaxes.Location = New System.Drawing.Point(113, 72)
        Me.lblTaxes.Name = "lblTaxes"
        Me.lblTaxes.Size = New System.Drawing.Size(134, 25)
        Me.lblTaxes.TabIndex = 16
        Me.lblTaxes.Text = "0.00"
        Me.lblTaxes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDiscounts
        '
        Me.lblDiscounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscounts.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiscounts.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblDiscounts.ForeColor = System.Drawing.Color.Black
        Me.lblDiscounts.Location = New System.Drawing.Point(113, 46)
        Me.lblDiscounts.Name = "lblDiscounts"
        Me.lblDiscounts.Size = New System.Drawing.Size(134, 25)
        Me.lblDiscounts.TabIndex = 15
        Me.lblDiscounts.Text = "0.00"
        Me.lblDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 25)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Taxes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 25)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Discounts"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblSubTotal.ForeColor = System.Drawing.Color.Black
        Me.lblSubTotal.Location = New System.Drawing.Point(113, 20)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(134, 25)
        Me.lblSubTotal.TabIndex = 11
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 25)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Sub Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpSalesDetails
        '
        Me.grpSalesDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpSalesDetails.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpSalesDetails.ForeColor = System.Drawing.Color.Black
        Me.grpSalesDetails.Location = New System.Drawing.Point(579, 1)
        Me.grpSalesDetails.Name = "grpSalesDetails"
        '
        'grpSalesDetails.Panel
        '
        Me.grpSalesDetails.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.grpSalesDetails.Panel.Controls.Add(Me.lblLoyalityCategory)
        Me.grpSalesDetails.Panel.Controls.Add(Me.cboServiceClass)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label15)
        Me.grpSalesDetails.Panel.Controls.Add(Me.lblLoyalityAccountHolder)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label14)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtLoyalityAccount)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label13)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtSalesTax)
        Me.grpSalesDetails.Panel.Controls.Add(Me.lblItemCode)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtShortCode)
        Me.grpSalesDetails.Panel.Controls.Add(Me.lblUserName)
        Me.grpSalesDetails.Panel.Controls.Add(Me.pb1)
        Me.grpSalesDetails.Panel.Controls.Add(Me.cboPersonnel)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label9)
        Me.grpSalesDetails.Panel.Controls.Add(Me.btnAcceptSaleEntry)
        Me.grpSalesDetails.Panel.Controls.Add(Me.btnSearch)
        Me.grpSalesDetails.Panel.Controls.Add(Me.dpTransDate)
        Me.grpSalesDetails.Panel.Controls.Add(Me.chkOverideDate)
        Me.grpSalesDetails.Panel.Controls.Add(Me.lblCostPrice)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtNotes)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label7)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label6)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtCurrentPayable)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label5)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label4)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtPriceOnSale)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label3)
        Me.grpSalesDetails.Panel.Controls.Add(Me.lblItemDescription)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label2)
        Me.grpSalesDetails.Panel.Controls.Add(Me.Label1)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtSalesDiscount)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtSalesQty)
        Me.grpSalesDetails.Panel.Controls.Add(Me.txtBarcode)
        Me.grpSalesDetails.Panel.ForeColor = System.Drawing.Color.Black
        Me.grpSalesDetails.Size = New System.Drawing.Size(302, 642)
        Me.grpSalesDetails.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grpSalesDetails.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grpSalesDetails.TabIndex = 1
        '
        'lblLoyalityCategory
        '
        Me.lblLoyalityCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblLoyalityCategory.ForeColor = System.Drawing.Color.Black
        Me.lblLoyalityCategory.Location = New System.Drawing.Point(14, 526)
        Me.lblLoyalityCategory.Name = "lblLoyalityCategory"
        Me.lblLoyalityCategory.Size = New System.Drawing.Size(88, 19)
        Me.lblLoyalityCategory.TabIndex = 41
        Me.lblLoyalityCategory.Visible = False
        '
        'cboServiceClass
        '
        Me.cboServiceClass.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboServiceClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceClass.DropDownWidth = 246
        Me.cboServiceClass.ForeColor = System.Drawing.Color.Black
        Me.cboServiceClass.Location = New System.Drawing.Point(27, 492)
        Me.cboServiceClass.Name = "cboServiceClass"
        Me.cboServiceClass.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboServiceClass.Size = New System.Drawing.Size(246, 21)
        Me.cboServiceClass.TabIndex = 40
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(27, 471)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(246, 20)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Agent Category"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoyalityAccountHolder
        '
        Me.lblLoyalityAccountHolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblLoyalityAccountHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLoyalityAccountHolder.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoyalityAccountHolder.ForeColor = System.Drawing.Color.Black
        Me.lblLoyalityAccountHolder.Location = New System.Drawing.Point(27, 406)
        Me.lblLoyalityAccountHolder.Name = "lblLoyalityAccountHolder"
        Me.lblLoyalityAccountHolder.Size = New System.Drawing.Size(247, 20)
        Me.lblLoyalityAccountHolder.TabIndex = 38
        Me.lblLoyalityAccountHolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(27, 380)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(114, 24)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Loyality Account No."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoyalityAccount
        '
        Me.txtLoyalityAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtLoyalityAccount.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnFind})
        Me.txtLoyalityAccount.ForeColor = System.Drawing.Color.Black
        Me.txtLoyalityAccount.Location = New System.Drawing.Point(147, 380)
        Me.txtLoyalityAccount.Name = "txtLoyalityAccount"
        Me.txtLoyalityAccount.Size = New System.Drawing.Size(127, 24)
        Me.txtLoyalityAccount.TabIndex = 36
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl
        Me.btnFind.Text = "Find"
        Me.btnFind.UniqueName = "2E4D94D6B67D47595E8488280460D0B4"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(27, 338)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 20)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Tax"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSalesTax.Enabled = False
        Me.txtSalesTax.ForeColor = System.Drawing.Color.Black
        Me.txtSalesTax.Location = New System.Drawing.Point(180, 338)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(94, 23)
        Me.txtSalesTax.TabIndex = 34
        Me.txtSalesTax.Text = "0.00"
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblItemCode
        '
        Me.lblItemCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblItemCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.ForeColor = System.Drawing.Color.Black
        Me.lblItemCode.Location = New System.Drawing.Point(28, 233)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(246, 20)
        Me.lblItemCode.TabIndex = 33
        Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShortCode
        '
        Me.txtShortCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtShortCode.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnNewItem})
        Me.txtShortCode.ForeColor = System.Drawing.Color.Black
        Me.txtShortCode.Location = New System.Drawing.Point(28, 207)
        Me.txtShortCode.MaxLength = 8
        Me.txtShortCode.Name = "txtShortCode"
        Me.txtShortCode.Size = New System.Drawing.Size(246, 24)
        Me.txtShortCode.TabIndex = 31
        '
        'btnNewItem
        '
        Me.btnNewItem.Image = CType(resources.GetObject("btnNewItem.Image"), System.Drawing.Image)
        Me.btnNewItem.UniqueName = "BCC64327954B4A29A9A1FD3374D3C892"
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblUserName.ForeColor = System.Drawing.Color.Black
        Me.lblUserName.Location = New System.Drawing.Point(0, 615)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(300, 25)
        Me.lblUserName.TabIndex = 30
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pb1
        '
        Me.pb1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pb1.ForeColor = System.Drawing.Color.Black
        Me.pb1.Location = New System.Drawing.Point(61, 532)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(43, 26)
        Me.pb1.TabIndex = 29
        Me.pb1.Visible = False
        '
        'cboPersonnel
        '
        Me.cboPersonnel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboPersonnel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPersonnel.DropDownWidth = 246
        Me.cboPersonnel.ForeColor = System.Drawing.Color.Black
        Me.cboPersonnel.Location = New System.Drawing.Point(28, 161)
        Me.cboPersonnel.Name = "cboPersonnel"
        Me.cboPersonnel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboPersonnel.Size = New System.Drawing.Size(246, 21)
        Me.cboPersonnel.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(28, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(246, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Sales Personnel"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAcceptSaleEntry
        '
        Me.btnAcceptSaleEntry.AutoSize = True
        Me.btnAcceptSaleEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnAcceptSaleEntry.ForeColor = System.Drawing.Color.Black
        Me.btnAcceptSaleEntry.Location = New System.Drawing.Point(200, 520)
        Me.btnAcceptSaleEntry.Name = "btnAcceptSaleEntry"
        Me.btnAcceptSaleEntry.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.btnAcceptSaleEntry.Size = New System.Drawing.Size(74, 74)
        Me.btnAcceptSaleEntry.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnAcceptSaleEntry.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAcceptSaleEntry.StateCommon.Back.ColorAngle = 100.0!
        Me.btnAcceptSaleEntry.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma
        Me.btnAcceptSaleEntry.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnAcceptSaleEntry.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnAcceptSaleEntry.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnAcceptSaleEntry.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnAcceptSaleEntry.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnAcceptSaleEntry.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnAcceptSaleEntry.TabIndex = 26
        Me.btnAcceptSaleEntry.Values.ExtraText = "F4"
        Me.btnAcceptSaleEntry.Values.Image = CType(resources.GetObject("btnAcceptSaleEntry.Values.Image"), System.Drawing.Image)
        Me.btnAcceptSaleEntry.Values.Text = "Accept"
        '
        'btnSearch
        '
        Me.btnSearch.AutoSize = True
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(120, 520)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.btnSearch.Size = New System.Drawing.Size(74, 74)
        Me.btnSearch.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnSearch.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSearch.StateCommon.Back.ColorAngle = 100.0!
        Me.btnSearch.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma
        Me.btnSearch.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnSearch.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnSearch.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnSearch.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnSearch.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnSearch.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnSearch.TabIndex = 25
        Me.btnSearch.Values.ExtraText = "F2"
        Me.btnSearch.Values.Image = CType(resources.GetObject("btnSearch.Values.Image"), System.Drawing.Image)
        Me.btnSearch.Values.Text = "Search"
        '
        'dpTransDate
        '
        Me.dpTransDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpTransDate.Enabled = False
        Me.dpTransDate.ForeColor = System.Drawing.Color.Black
        Me.dpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpTransDate.Location = New System.Drawing.Point(139, 64)
        Me.dpTransDate.Name = "dpTransDate"
        Me.dpTransDate.Size = New System.Drawing.Size(96, 20)
        Me.dpTransDate.TabIndex = 22
        '
        'chkOverideDate
        '
        Me.chkOverideDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkOverideDate.ForeColor = System.Drawing.Color.Black
        Me.chkOverideDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkOverideDate.Location = New System.Drawing.Point(31, 65)
        Me.chkOverideDate.Name = "chkOverideDate"
        Me.chkOverideDate.Size = New System.Drawing.Size(94, 20)
        Me.chkOverideDate.TabIndex = 21
        Me.chkOverideDate.Text = "Overide date"
        Me.chkOverideDate.Values.Text = "Overide date"
        '
        'lblCostPrice
        '
        Me.lblCostPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCostPrice.ForeColor = System.Drawing.Color.Black
        Me.lblCostPrice.Location = New System.Drawing.Point(16, 558)
        Me.lblCostPrice.Name = "lblCostPrice"
        Me.lblCostPrice.Size = New System.Drawing.Size(88, 19)
        Me.lblCostPrice.TabIndex = 20
        Me.lblCostPrice.Text = "0.00"
        Me.lblCostPrice.Visible = False
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.Location = New System.Drawing.Point(27, 449)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(246, 23)
        Me.txtNotes.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(27, 427)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Notes/Serial no/Add info"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(27, 359)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 20)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Payable"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCurrentPayable
        '
        Me.txtCurrentPayable.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCurrentPayable.Enabled = False
        Me.txtCurrentPayable.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentPayable.Location = New System.Drawing.Point(180, 359)
        Me.txtCurrentPayable.Name = "txtCurrentPayable"
        Me.txtCurrentPayable.Size = New System.Drawing.Size(94, 23)
        Me.txtCurrentPayable.TabIndex = 15
        Me.txtCurrentPayable.Text = "0.00"
        Me.txtCurrentPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(246, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Barcode"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(246, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Item Short Code"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPriceOnSale
        '
        Me.txtPriceOnSale.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPriceOnSale.Enabled = False
        Me.txtPriceOnSale.ForeColor = System.Drawing.Color.Black
        Me.txtPriceOnSale.Location = New System.Drawing.Point(180, 275)
        Me.txtPriceOnSale.Name = "txtPriceOnSale"
        Me.txtPriceOnSale.Size = New System.Drawing.Size(94, 23)
        Me.txtPriceOnSale.TabIndex = 12
        Me.txtPriceOnSale.Text = "0.00"
        Me.txtPriceOnSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(27, 275)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Unit Price"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemDescription
        '
        Me.lblItemDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblItemDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemDescription.ForeColor = System.Drawing.Color.Black
        Me.lblItemDescription.Location = New System.Drawing.Point(28, 254)
        Me.lblItemDescription.Name = "lblItemDescription"
        Me.lblItemDescription.Size = New System.Drawing.Size(246, 20)
        Me.lblItemDescription.TabIndex = 10
        Me.lblItemDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(27, 296)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Quantity"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 317)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Discount"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesDiscount
        '
        Me.txtSalesDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSalesDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtSalesDiscount.Location = New System.Drawing.Point(180, 317)
        Me.txtSalesDiscount.Name = "txtSalesDiscount"
        Me.txtSalesDiscount.Size = New System.Drawing.Size(94, 23)
        Me.txtSalesDiscount.TabIndex = 7
        Me.txtSalesDiscount.Text = "0.00"
        Me.txtSalesDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesQty
        '
        Me.txtSalesQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSalesQty.ForeColor = System.Drawing.Color.Black
        Me.txtSalesQty.Location = New System.Drawing.Point(180, 296)
        Me.txtSalesQty.Name = "txtSalesQty"
        Me.txtSalesQty.Size = New System.Drawing.Size(94, 23)
        Me.txtSalesQty.TabIndex = 6
        Me.txtSalesQty.Text = "0"
        Me.txtSalesQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.Location = New System.Drawing.Point(28, 116)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(246, 23)
        Me.txtBarcode.TabIndex = 4
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(890, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 651)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(890, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(889, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 650)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 650)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(888, 650)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 6
        '
        'frmLoyalityCustmerTransactionEntries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 652)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoyalityCustmerTransactionEntries"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Loyality Customer Transaction Entries"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        CType(Me.grpReceiptEntries.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpReceiptEntries.Panel.ResumeLayout(False)
        CType(Me.grpReceiptEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpReceiptEntries.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.dGridSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroup4.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup4.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlTotals.ResumeLayout(False)
        Me.pnlTotals.PerformLayout()
        CType(Me.grpSalesDetails.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSalesDetails.Panel.ResumeLayout(False)
        Me.grpSalesDetails.Panel.PerformLayout()
        CType(Me.grpSalesDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSalesDetails.ResumeLayout(False)
        CType(Me.cboServiceClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPersonnel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents grpReceiptEntries As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridSales As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents KryptonGroup4 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents btnRefresh As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnClear As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnRemove As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnFinish As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pnlTotals As System.Windows.Forms.Panel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Private WithEvents lblTaxes As System.Windows.Forms.Label
    Private WithEvents lblDiscounts As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents lblSubTotal As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents grpSalesDetails As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents lblLoyalityCategory As System.Windows.Forms.Label
    Friend WithEvents cboServiceClass As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblLoyalityAccountHolder As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLoyalityAccount As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnFind As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTax As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtShortCode As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnNewItem As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cboPersonnel As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents btnAcceptSaleEntry As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkOverideDate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents lblCostPrice As System.Windows.Forms.Label
    Friend WithEvents txtNotes As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPayable As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPriceOnSale As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblItemDescription As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSalesDiscount As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtSalesQty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtBarcode As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
