<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashbookTransactions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashbookTransactions))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnTransactions = New DevComponents.DotNetBar.ButtonItem()
        Me.btnIncomes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExpenses = New DevComponents.DotNetBar.ButtonItem()
        Me.btnView = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSaveRenconciliation = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintTransactions = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintRecon = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCashbooks = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar10 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem23 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem25 = New DevComponents.DotNetBar.LabelItem()
        Me.lblCountAll = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem26 = New DevComponents.DotNetBar.LabelItem()
        Me.lblDebitsAll = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem28 = New DevComponents.DotNetBar.LabelItem()
        Me.lblCreditsAll = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem30 = New DevComponents.DotNetBar.LabelItem()
        Me.lblPeriodMovement = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem32 = New DevComponents.DotNetBar.LabelItem()
        Me.lblBalance = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboCashbook = New MTGCComboBox()
        Me.lblCashbook = New System.Windows.Forms.Label()
        Me.btnGo = New DevComponents.DotNetBar.ButtonX()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar9 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem20 = New DevComponents.DotNetBar.LabelItem()
        Me.lblBalanceAll = New DevComponents.DotNetBar.LabelItem()
        Me.lblCashbookBfBalanceType = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.lblReconBankBalanceAmt = New DevComponents.DotNetBar.LabelItem()
        Me.dGridAll = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(758, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(757, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 509)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 509)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnTransactions, Me.btnIncomes, Me.btnExpenses, Me.btnView, Me.btnEdit, Me.btnDeleteCustomer, Me.btnSaveRenconciliation, Me.btnPrint, Me.btnExportCustomers, Me.btnRefreshInvoice, Me.btnCashbooks})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(756, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 157
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnTransactions
        '
        Me.btnTransactions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTransactions.Image = CType(resources.GetObject("btnTransactions.Image"), System.Drawing.Image)
        Me.btnTransactions.Name = "btnTransactions"
        Me.btnTransactions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTransactions.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnTransactions.Text = "Entries"
        '
        'btnIncomes
        '
        Me.btnIncomes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnIncomes.Image = CType(resources.GetObject("btnIncomes.Image"), System.Drawing.Image)
        Me.btnIncomes.Name = "btnIncomes"
        Me.btnIncomes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnIncomes.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnIncomes.Text = "Incomes"
        Me.btnIncomes.Visible = False
        '
        'btnExpenses
        '
        Me.btnExpenses.BeginGroup = True
        Me.btnExpenses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExpenses.Image = CType(resources.GetObject("btnExpenses.Image"), System.Drawing.Image)
        Me.btnExpenses.Name = "btnExpenses"
        Me.btnExpenses.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExpenses.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnExpenses.Text = "Expenses"
        Me.btnExpenses.Visible = False
        '
        'btnView
        '
        Me.btnView.BeginGroup = True
        Me.btnView.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.Name = "btnView"
        Me.btnView.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnView.Text = "Un-posted Expenses"
        '
        'btnEdit
        '
        Me.btnEdit.BeginGroup = True
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "Edit"
        '
        'btnDeleteCustomer
        '
        Me.btnDeleteCustomer.BeginGroup = True
        Me.btnDeleteCustomer.Image = CType(resources.GetObject("btnDeleteCustomer.Image"), System.Drawing.Image)
        Me.btnDeleteCustomer.Name = "btnDeleteCustomer"
        Me.btnDeleteCustomer.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteCustomer.Text = "Delete"
        Me.btnDeleteCustomer.Visible = False
        '
        'btnSaveRenconciliation
        '
        Me.btnSaveRenconciliation.BeginGroup = True
        Me.btnSaveRenconciliation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSaveRenconciliation.Image = CType(resources.GetObject("btnSaveRenconciliation.Image"), System.Drawing.Image)
        Me.btnSaveRenconciliation.Name = "btnSaveRenconciliation"
        Me.btnSaveRenconciliation.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSaveRenconciliation.Text = "Save Recon"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintTransactions, Me.btnPrintRecon})
        Me.btnPrint.Text = "Print"
        '
        'btnPrintTransactions
        '
        Me.btnPrintTransactions.BeginGroup = True
        Me.btnPrintTransactions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintTransactions.Name = "btnPrintTransactions"
        Me.btnPrintTransactions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintTransactions.Text = "Cashbook Transactions"
        '
        'btnPrintRecon
        '
        Me.btnPrintRecon.BeginGroup = True
        Me.btnPrintRecon.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintRecon.Name = "btnPrintRecon"
        Me.btnPrintRecon.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintRecon.Text = "Reconcilliation Statement"
        '
        'btnExportCustomers
        '
        Me.btnExportCustomers.BeginGroup = True
        Me.btnExportCustomers.Image = CType(resources.GetObject("btnExportCustomers.Image"), System.Drawing.Image)
        Me.btnExportCustomers.Name = "btnExportCustomers"
        Me.btnExportCustomers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportCustomers.Text = "Export"
        Me.btnExportCustomers.Visible = False
        '
        'btnRefreshInvoice
        '
        Me.btnRefreshInvoice.BeginGroup = True
        Me.btnRefreshInvoice.Image = CType(resources.GetObject("btnRefreshInvoice.Image"), System.Drawing.Image)
        Me.btnRefreshInvoice.Name = "btnRefreshInvoice"
        Me.btnRefreshInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshInvoice.Text = "Refresh"
        '
        'btnCashbooks
        '
        Me.btnCashbooks.BeginGroup = True
        Me.btnCashbooks.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCashbooks.Image = CType(resources.GetObject("btnCashbooks.Image"), System.Drawing.Image)
        Me.btnCashbooks.Name = "btnCashbooks"
        Me.btnCashbooks.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCashbooks.Text = "Cashbooks"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(756, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar10
        '
        Me.Bar10.AntiAlias = True
        Me.Bar10.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar10.IsMaximized = False
        Me.Bar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem23, Me.LabelItem25, Me.lblCountAll, Me.LabelItem26, Me.lblDebitsAll, Me.LabelItem28, Me.lblCreditsAll, Me.LabelItem30, Me.lblPeriodMovement, Me.LabelItem32, Me.lblBalance})
        Me.Bar10.Location = New System.Drawing.Point(1, 483)
        Me.Bar10.Name = "Bar10"
        Me.Bar10.PaddingBottom = 3
        Me.Bar10.PaddingTop = 3
        Me.Bar10.Size = New System.Drawing.Size(756, 27)
        Me.Bar10.Stretch = True
        Me.Bar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar10.TabIndex = 162
        Me.Bar10.TabStop = False
        Me.Bar10.Text = "Bar10"
        '
        'LabelItem23
        '
        Me.LabelItem23.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem23.Name = "LabelItem23"
        Me.LabelItem23.PaddingLeft = 3
        Me.LabelItem23.PaddingRight = 3
        Me.LabelItem23.Stretch = True
        Me.LabelItem23.Text = "Balance brought forward"
        '
        'LabelItem25
        '
        Me.LabelItem25.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem25.Name = "LabelItem25"
        Me.LabelItem25.PaddingLeft = 3
        Me.LabelItem25.PaddingRight = 3
        Me.LabelItem25.Text = "Count"
        '
        'lblCountAll
        '
        Me.lblCountAll.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblCountAll.Name = "lblCountAll"
        Me.lblCountAll.PaddingLeft = 3
        Me.lblCountAll.PaddingRight = 3
        Me.lblCountAll.Text = "0.00"
        Me.lblCountAll.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem26
        '
        Me.LabelItem26.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem26.Name = "LabelItem26"
        Me.LabelItem26.PaddingLeft = 3
        Me.LabelItem26.PaddingRight = 3
        Me.LabelItem26.Text = "Debits"
        Me.LabelItem26.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDebitsAll
        '
        Me.lblDebitsAll.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblDebitsAll.Name = "lblDebitsAll"
        Me.lblDebitsAll.PaddingLeft = 3
        Me.lblDebitsAll.PaddingRight = 3
        Me.lblDebitsAll.Text = "0.00"
        Me.lblDebitsAll.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem28
        '
        Me.LabelItem28.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem28.Name = "LabelItem28"
        Me.LabelItem28.PaddingLeft = 3
        Me.LabelItem28.PaddingRight = 3
        Me.LabelItem28.Text = "Credits"
        Me.LabelItem28.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCreditsAll
        '
        Me.lblCreditsAll.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblCreditsAll.Name = "lblCreditsAll"
        Me.lblCreditsAll.PaddingLeft = 3
        Me.lblCreditsAll.PaddingRight = 3
        Me.lblCreditsAll.Text = "0.00"
        Me.lblCreditsAll.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem30
        '
        Me.LabelItem30.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem30.Name = "LabelItem30"
        Me.LabelItem30.PaddingLeft = 3
        Me.LabelItem30.PaddingRight = 3
        Me.LabelItem30.Text = "Period Movement"
        Me.LabelItem30.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblPeriodMovement
        '
        Me.lblPeriodMovement.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblPeriodMovement.Name = "lblPeriodMovement"
        Me.lblPeriodMovement.PaddingLeft = 3
        Me.lblPeriodMovement.PaddingRight = 3
        Me.lblPeriodMovement.Text = "0.00"
        Me.lblPeriodMovement.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem32
        '
        Me.LabelItem32.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.LabelItem32.Name = "LabelItem32"
        Me.LabelItem32.PaddingLeft = 3
        Me.LabelItem32.PaddingRight = 3
        Me.LabelItem32.Text = "Period End Balance"
        Me.LabelItem32.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblBalance
        '
        Me.lblBalance.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.PaddingLeft = 3
        Me.lblBalance.PaddingRight = 3
        Me.lblBalance.Text = "0.00"
        Me.lblBalance.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 482)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(756, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.cboCashbook)
        Me.KryptonPanel8.Controls.Add(Me.lblCashbook)
        Me.KryptonPanel8.Controls.Add(Me.btnGo)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel8.Controls.Add(Me.dpEndDate)
        Me.KryptonPanel8.Controls.Add(Me.dpStartDate)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel11)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(756, 51)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.TabIndex = 164
        '
        'cboCashbook
        '
        Me.cboCashbook.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCashbook.ArrowColor = System.Drawing.Color.Black
        Me.cboCashbook.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboCashbook.BindedControl = Nothing
        Me.cboCashbook.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboCashbook.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCashbook.ColumnNum = 1
        Me.cboCashbook.ColumnWidth = "121"
        Me.cboCashbook.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCashbook.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboCashbook.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboCashbook.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboCashbook.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboCashbook.DisplayMember = "Text"
        Me.cboCashbook.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboCashbook.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboCashbook.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCashbook.DropDownForeColor = System.Drawing.Color.Black
        Me.cboCashbook.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboCashbook.DropDownWidth = 141
        Me.cboCashbook.ForeColor = System.Drawing.Color.Black
        Me.cboCashbook.GridLineColor = System.Drawing.Color.LightGray
        Me.cboCashbook.GridLineHorizontal = False
        Me.cboCashbook.GridLineVertical = False
        Me.cboCashbook.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboCashbook.HighlightBorderOnMouseEvents = True
        Me.cboCashbook.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboCashbook.Location = New System.Drawing.Point(437, 14)
        Me.cboCashbook.ManagingFastMouseMoving = True
        Me.cboCashbook.ManagingFastMouseMovingInterval = 30
        Me.cboCashbook.Name = "cboCashbook"
        Me.cboCashbook.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboCashbook.SelectedItem = Nothing
        Me.cboCashbook.SelectedValue = Nothing
        Me.cboCashbook.Size = New System.Drawing.Size(180, 23)
        Me.cboCashbook.TabIndex = 177
        '
        'lblCashbook
        '
        Me.lblCashbook.AutoSize = True
        Me.lblCashbook.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCashbook.ForeColor = System.Drawing.Color.Black
        Me.lblCashbook.Location = New System.Drawing.Point(726, 24)
        Me.lblCashbook.Name = "lblCashbook"
        Me.lblCashbook.Size = New System.Drawing.Size(13, 13)
        Me.lblCashbook.TabIndex = 176
        Me.lblCashbook.Text = "0"
        Me.lblCashbook.Visible = False
        '
        'btnGo
        '
        Me.btnGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGo.Location = New System.Drawing.Point(621, 14)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGo.TabIndex = 175
        Me.btnGo.Text = "Process ..."
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(359, 17)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(77, 20)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 174
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Cashbook"
        '
        'dpEndDate
        '
        Me.dpEndDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndDate.Location = New System.Drawing.Point(249, 15)
        Me.dpEndDate.Name = "dpEndDate"
        Me.dpEndDate.Size = New System.Drawing.Size(96, 22)
        Me.dpEndDate.TabIndex = 170
        '
        'dpStartDate
        '
        Me.dpStartDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartDate.Location = New System.Drawing.Point(82, 15)
        Me.dpStartDate.Name = "dpStartDate"
        Me.dpStartDate.Size = New System.Drawing.Size(99, 22)
        Me.dpStartDate.TabIndex = 171
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(194, 17)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(54, 20)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 173
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(54, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(54, 20)
        Me.KryptonLabel4.TabIndex = 0
        Me.KryptonLabel4.Values.Text = "Date to"
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(15, 17)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(66, 20)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 172
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(66, 20)
        Me.KryptonLabel5.TabIndex = 0
        Me.KryptonLabel5.Values.Text = "Date from"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(756, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'Bar9
        '
        Me.Bar9.AntiAlias = True
        Me.Bar9.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar9.IsMaximized = False
        Me.Bar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem20, Me.lblBalanceAll, Me.lblCashbookBfBalanceType, Me.LabelItem1, Me.lblReconBankBalanceAmt})
        Me.Bar9.Location = New System.Drawing.Point(1, 78)
        Me.Bar9.Name = "Bar9"
        Me.Bar9.Size = New System.Drawing.Size(756, 23)
        Me.Bar9.Stretch = True
        Me.Bar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar9.TabIndex = 165
        Me.Bar9.TabStop = False
        Me.Bar9.Text = "Bar9"
        '
        'LabelItem20
        '
        Me.LabelItem20.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.LabelItem20.Name = "LabelItem20"
        Me.LabelItem20.PaddingLeft = 3
        Me.LabelItem20.PaddingRight = 3
        Me.LabelItem20.Stretch = True
        Me.LabelItem20.Text = "Balance brought forward"
        '
        'lblBalanceAll
        '
        Me.lblBalanceAll.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.lblBalanceAll.Name = "lblBalanceAll"
        Me.lblBalanceAll.PaddingLeft = 3
        Me.lblBalanceAll.PaddingRight = 3
        Me.lblBalanceAll.Text = "0.00"
        Me.lblBalanceAll.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblBalanceAll.Width = 100
        '
        'lblCashbookBfBalanceType
        '
        Me.lblCashbookBfBalanceType.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.lblCashbookBfBalanceType.Name = "lblCashbookBfBalanceType"
        Me.lblCashbookBfBalanceType.PaddingLeft = 3
        Me.lblCashbookBfBalanceType.PaddingRight = 3
        Me.lblCashbookBfBalanceType.Text = "DR"
        Me.lblCashbookBfBalanceType.Width = 45
        '
        'LabelItem1
        '
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Balance as per bank"
        '
        'lblReconBankBalanceAmt
        '
        Me.lblReconBankBalanceAmt.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.lblReconBankBalanceAmt.Name = "lblReconBankBalanceAmt"
        Me.lblReconBankBalanceAmt.PaddingLeft = 12
        Me.lblReconBankBalanceAmt.PaddingRight = 12
        Me.lblReconBankBalanceAmt.Text = "0.00"
        '
        'dGridAll
        '
        Me.dGridAll.AllowUserToAddRows = False
        Me.dGridAll.AllowUserToDeleteRows = False
        Me.dGridAll.AllowUserToResizeRows = False
        Me.dGridAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column11})
        Me.dGridAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridAll.Location = New System.Drawing.Point(1, 101)
        Me.dGridAll.Name = "dGridAll"
        Me.dGridAll.RowHeadersVisible = False
        Me.dGridAll.RowHeadersWidth = 25
        Me.dGridAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridAll.Size = New System.Drawing.Size(756, 381)
        Me.dGridAll.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridAll.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridAll.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAll.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridAll.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridAll.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridAll.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridAll.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridAll.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridAll.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridAll.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAll.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridAll.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridAll.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridAll.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAll.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAll.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridAll.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridAll.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAll.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAll.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAll.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridAll.TabIndex = 169
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 63
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
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
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Cost Code"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 96
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Reference"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 94
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.HeaderText = "Debit"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 66
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column6.HeaderText = "Credit"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 71
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Key"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Balance"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 81
        '
        'Column11
        '
        Me.Column11.HeaderText = "RS"
        Me.Column11.MinimumWidth = 30
        Me.Column11.Name = "Column11"
        Me.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column11.Width = 30
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
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Account #"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Account Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cost Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Reference"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn7.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn8.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.HeaderText = "Key"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'frmCashbookTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 510)
        Me.Controls.Add(Me.dGridAll)
        Me.Controls.Add(Me.Bar9)
        Me.Controls.Add(Me.KryptonPanel8)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar10)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCashbookTransactions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Cashbook Entries"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnIncomes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExpenses As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnView As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSaveRenconciliation As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintTransactions As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintRecon As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar10 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem23 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem25 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCountAll As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem26 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDebitsAll As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem28 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCreditsAll As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem30 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblPeriodMovement As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem32 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblBalance As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents cboCashbook As MTGCComboBox
    Friend WithEvents lblCashbook As System.Windows.Forms.Label
    Friend WithEvents btnGo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar9 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem20 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblBalanceAll As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCashbookBfBalanceType As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblReconBankBalanceAmt As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridAll As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnCashbooks As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTransactions As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
