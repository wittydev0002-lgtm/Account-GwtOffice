<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierInvoicesListing
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplierInvoicesListing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar9 = New DevComponents.DotNetBar.Bar()
        Me.btnNewSupplierInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditSupplierInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteSupplierInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelectedSupplierRow = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSupplierInvoiceList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSupplierPayments = New DevComponents.DotNetBar.ButtonItem()
        Me.btnView = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUnpaidInvoices = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBalances = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshSupplier = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndSupplierInvoice = New System.Windows.Forms.DateTimePicker()
        Me.dpStartSupplierInvoice = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnRunInvoice = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Bar10 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem12 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotal = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dGridSupplierInvoices = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdWindows = New System.Drawing.Printing.PrintDocument()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridSupplierInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(573, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 453)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(573, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(572, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 452)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 452)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar9
        '
        Me.Bar9.AntiAlias = True
        Me.Bar9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar9.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar9.IsMaximized = False
        Me.Bar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewSupplierInvoice, Me.btnEditSupplierInvoice, Me.btnDeleteSupplierInvoice, Me.ButtonItem3, Me.btnSupplierPayments, Me.btnView, Me.btnRefreshSupplier})
        Me.Bar9.Location = New System.Drawing.Point(1, 1)
        Me.Bar9.Name = "Bar9"
        Me.Bar9.RoundCorners = False
        Me.Bar9.Size = New System.Drawing.Size(571, 25)
        Me.Bar9.Stretch = True
        Me.Bar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar9.TabIndex = 153
        Me.Bar9.TabStop = False
        Me.Bar9.Text = "Bar9"
        '
        'btnNewSupplierInvoice
        '
        Me.btnNewSupplierInvoice.Image = CType(resources.GetObject("btnNewSupplierInvoice.Image"), System.Drawing.Image)
        Me.btnNewSupplierInvoice.Name = "btnNewSupplierInvoice"
        Me.btnNewSupplierInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewSupplierInvoice.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewSupplierInvoice.Text = "New"
        '
        'btnEditSupplierInvoice
        '
        Me.btnEditSupplierInvoice.Image = CType(resources.GetObject("btnEditSupplierInvoice.Image"), System.Drawing.Image)
        Me.btnEditSupplierInvoice.Name = "btnEditSupplierInvoice"
        Me.btnEditSupplierInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditSupplierInvoice.Text = "Edit"
        '
        'btnDeleteSupplierInvoice
        '
        Me.btnDeleteSupplierInvoice.BeginGroup = True
        Me.btnDeleteSupplierInvoice.Image = CType(resources.GetObject("btnDeleteSupplierInvoice.Image"), System.Drawing.Image)
        Me.btnDeleteSupplierInvoice.Name = "btnDeleteSupplierInvoice"
        Me.btnDeleteSupplierInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'ButtonItem3
        '
        Me.ButtonItem3.BeginGroup = True
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelectedSupplierRow, Me.btnPrintSupplierInvoiceList})
        Me.ButtonItem3.Text = "Print"
        '
        'btnPrintSelectedSupplierRow
        '
        Me.btnPrintSelectedSupplierRow.BeginGroup = True
        Me.btnPrintSelectedSupplierRow.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelectedSupplierRow.Name = "btnPrintSelectedSupplierRow"
        Me.btnPrintSelectedSupplierRow.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelectedSupplierRow.SymbolSize = 16.0!
        Me.btnPrintSelectedSupplierRow.Text = "Print Selected Row"
        '
        'btnPrintSupplierInvoiceList
        '
        Me.btnPrintSupplierInvoiceList.BeginGroup = True
        Me.btnPrintSupplierInvoiceList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSupplierInvoiceList.Name = "btnPrintSupplierInvoiceList"
        Me.btnPrintSupplierInvoiceList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSupplierInvoiceList.SymbolSize = 16.0!
        Me.btnPrintSupplierInvoiceList.Text = "Print Entire Sheet"
        '
        'btnSupplierPayments
        '
        Me.btnSupplierPayments.BeginGroup = True
        Me.btnSupplierPayments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSupplierPayments.Image = CType(resources.GetObject("btnSupplierPayments.Image"), System.Drawing.Image)
        Me.btnSupplierPayments.Name = "btnSupplierPayments"
        Me.btnSupplierPayments.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSupplierPayments.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSupplierPayments.Text = "Payments"
        '
        'btnView
        '
        Me.btnView.BeginGroup = True
        Me.btnView.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.Name = "btnView"
        Me.btnView.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnView.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnUnpaidInvoices, Me.btnBalances})
        Me.btnView.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnView.Text = "View"
        '
        'btnUnpaidInvoices
        '
        Me.btnUnpaidInvoices.BeginGroup = True
        Me.btnUnpaidInvoices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUnpaidInvoices.Name = "btnUnpaidInvoices"
        Me.btnUnpaidInvoices.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnUnpaidInvoices.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnUnpaidInvoices.Text = "Unpaid Invoices"
        '
        'btnBalances
        '
        Me.btnBalances.BeginGroup = True
        Me.btnBalances.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBalances.Name = "btnBalances"
        Me.btnBalances.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBalances.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnBalances.Text = "Supplier Balances"
        '
        'btnRefreshSupplier
        '
        Me.btnRefreshSupplier.BeginGroup = True
        Me.btnRefreshSupplier.Image = CType(resources.GetObject("btnRefreshSupplier.Image"), System.Drawing.Image)
        Me.btnRefreshSupplier.Name = "btnRefreshSupplier"
        Me.btnRefreshSupplier.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshSupplier.Text = "Refresh"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(571, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.AutoScroll = True
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel11)
        Me.KryptonPanel3.Controls.Add(Me.dpEndSupplierInvoice)
        Me.KryptonPanel3.Controls.Add(Me.dpStartSupplierInvoice)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel12)
        Me.KryptonPanel3.Controls.Add(Me.btnRunInvoice)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(571, 59)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel3.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel3.TabIndex = 158
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 58)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(571, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(208, 22)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(57, 21)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 151
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(57, 20)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Date to"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'dpEndSupplierInvoice
        '
        Me.dpEndSupplierInvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndSupplierInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpEndSupplierInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndSupplierInvoice.Location = New System.Drawing.Point(267, 21)
        Me.dpEndSupplierInvoice.Name = "dpEndSupplierInvoice"
        Me.dpEndSupplierInvoice.Size = New System.Drawing.Size(95, 20)
        Me.dpEndSupplierInvoice.TabIndex = 5
        '
        'dpStartSupplierInvoice
        '
        Me.dpStartSupplierInvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartSupplierInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpStartSupplierInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartSupplierInvoice.Location = New System.Drawing.Point(99, 21)
        Me.dpStartSupplierInvoice.Name = "dpStartSupplierInvoice"
        Me.dpStartSupplierInvoice.Size = New System.Drawing.Size(103, 20)
        Me.dpStartSupplierInvoice.TabIndex = 10
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge19)
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(20, 22)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel12.TabIndex = 150
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Date from"
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'btnRunInvoice
        '
        Me.btnRunInvoice.AutoSize = True
        Me.btnRunInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRunInvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnRunInvoice.ForeColor = System.Drawing.Color.Black
        Me.btnRunInvoice.Location = New System.Drawing.Point(368, 20)
        Me.btnRunInvoice.Name = "btnRunInvoice"
        Me.btnRunInvoice.Size = New System.Drawing.Size(58, 22)
        Me.btnRunInvoice.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnRunInvoice.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnRunInvoice.StateCommon.Back.ColorAngle = 100.0!
        Me.btnRunInvoice.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnRunInvoice.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnRunInvoice.StateCommon.Border.Rounding = 0
        Me.btnRunInvoice.TabIndex = 139
        Me.btnRunInvoice.Values.Image = CType(resources.GetObject("btnRunInvoice.Values.Image"), System.Drawing.Image)
        Me.btnRunInvoice.Values.Text = "Run ..."
        '
        'Bar10
        '
        Me.Bar10.AntiAlias = True
        Me.Bar10.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar10.IsMaximized = False
        Me.Bar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem12, Me.lblTotal})
        Me.Bar10.Location = New System.Drawing.Point(1, 434)
        Me.Bar10.Name = "Bar10"
        Me.Bar10.RoundCorners = False
        Me.Bar10.Size = New System.Drawing.Size(571, 19)
        Me.Bar10.Stretch = True
        Me.Bar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar10.TabIndex = 159
        Me.Bar10.TabStop = False
        Me.Bar10.Text = "Bar10"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingLeft = 3
        Me.LabelItem1.PaddingRight = 3
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Totals"
        '
        'LabelItem12
        '
        Me.LabelItem12.Name = "LabelItem12"
        Me.LabelItem12.PaddingLeft = 3
        Me.LabelItem12.PaddingRight = 3
        Me.LabelItem12.Text = "Invoice Totals"
        '
        'lblTotal
        '
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.PaddingLeft = 3
        Me.lblTotal.PaddingRight = 3
        Me.lblTotal.Text = "0.00"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(1, 433)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(571, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'dGridSupplierInvoices
        '
        Me.dGridSupplierInvoices.AllowUserToAddRows = False
        Me.dGridSupplierInvoices.AllowUserToDeleteRows = False
        Me.dGridSupplierInvoices.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridSupplierInvoices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridSupplierInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSupplierInvoices.Location = New System.Drawing.Point(1, 93)
        Me.dGridSupplierInvoices.Name = "dGridSupplierInvoices"
        Me.dGridSupplierInvoices.ReadOnly = True
        Me.dGridSupplierInvoices.RowHeadersWidth = 25
        Me.dGridSupplierInvoices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridSupplierInvoices.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridSupplierInvoices.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridSupplierInvoices.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridSupplierInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridSupplierInvoices.Size = New System.Drawing.Size(571, 340)
        Me.dGridSupplierInvoices.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridSupplierInvoices.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridSupplierInvoices.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dGridSupplierInvoices.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridSupplierInvoices.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridSupplierInvoices.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridSupplierInvoices.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSupplierInvoices.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSupplierInvoices.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSupplierInvoices.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridSupplierInvoices.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridSupplierInvoices.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridSupplierInvoices.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSupplierInvoices.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSupplierInvoices.TabIndex = 161
        '
        'ppd
        '
        Me.ppd.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd.Enabled = True
        Me.ppd.Icon = CType(resources.GetObject("ppd.Icon"), System.Drawing.Icon)
        Me.ppd.Name = "ppd"
        Me.ppd.Visible = False
        '
        'pdWindows
        '
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column5, Me.Column1, Me.Column2, Me.Column4, Me.Column6})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.HideOuterBorders = True
        Me.dGrid.Location = New System.Drawing.Point(1, 86)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(571, 347)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 168
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Date"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 63
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Order #"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 82
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Account #"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 94
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Account Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 118
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Value"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 67
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Buyer"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 70
        '
        'frmSupplierInvoicesListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(573, 454)
        Me.Controls.Add(Me.dGrid)
        Me.Controls.Add(Me.KryptonBorderEdge6)
        Me.Controls.Add(Me.Bar10)
        Me.Controls.Add(Me.KryptonPanel3)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar9)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Name = "frmSupplierInvoicesListing"
        Me.Text = "Supplier Invoices"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridSupplierInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar9 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewSupplierInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditSupplierInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteSupplierInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelectedSupplierRow As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSupplierInvoiceList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSupplierPayments As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshSupplier As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndSupplierInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartSupplierInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnRunInvoice As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Bar10 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem12 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridSupplierInvoices As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents ppd As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdWindows As System.Drawing.Printing.PrintDocument
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnView As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUnpaidInvoices As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBalances As DevComponents.DotNetBar.ButtonItem
End Class
