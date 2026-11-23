<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchasingMain
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
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchasingMain))
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Creditors Transaction History", 5, 5)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Today's Creditors Payments", 5, 5)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Amounts Due to Creditors", 5, 5)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders", 5, 5)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendors/Creditors", 10, 10, New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Me.StyleManager2 = New DevComponents.DotNetBar.StyleManager()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.SuperTabControl2 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridCreditNotes = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Bar8 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem13 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem14 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem15 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem16 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem17 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem18 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem19 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar7 = New DevComponents.DotNetBar.Bar()
        Me.btnNewCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnViewFilteredCreditNotes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCreditNotes = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridQuotes = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Bar6 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.lblQuoteTotal = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.lblQuoteTaxes = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem11 = New DevComponents.DotNetBar.LabelItem()
        Me.lblQuoteDiscounts = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.btnNewQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFilterQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSeletedRowQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintQuoteList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshQuotes = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridPurchaseOrders = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboSearchOptions = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel17 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpStartFrom = New System.Windows.Forms.DateTimePicker()
        Me.dpEndTo = New System.Windows.Forms.DateTimePicker()
        Me.btnProcess = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel19 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.Totals = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalOrders = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.lblDiscounts = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTaxes = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNewOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSummaryOrders = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectedOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeliveryNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshOrders = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridSupplierInvoices = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar10 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem12 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem20 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem21 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem22 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem23 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem24 = New DevComponents.DotNetBar.LabelItem()
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
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar9 = New DevComponents.DotNetBar.Bar()
        Me.btnNewSupplierInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditSupplierInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteSupplierInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelectedSupplierRow = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSupplierInvoiceList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSupplierPayments = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshSupplier = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel5 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridCreditors = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel81 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge82 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel67 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboCreditorSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtCreditorSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar14 = New DevComponents.DotNetBar.Bar()
        Me.btnNewSupplier = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditCreditor = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteSupplier = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnNotZero = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportSuppliers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAccountSettlement = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCreditors = New DevComponents.DotNetBar.ButtonItem()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGridOrderDetails = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip()
        Me.mnuAdjustPrice = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblBatchCostTotalOrders = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEntriesCountOrders = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGridOrdersList = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblGrandTotalOrders = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUnprocessedTotalOrders = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblProcessedTotalOrders = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpEndToOrders = New System.Windows.Forms.DateTimePicker()
        Me.dpStartFromOrders = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnGoOrders = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNewGoodsIn = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditGoodsIn = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteGoodsIn = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintReceivedOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPostReceivedOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem10 = New DevComponents.DotNetBar.ButtonItem()
        Me.SideNavPanel7 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Bar16 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel15 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel3 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.panelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.recentDocsItemPane = New DevComponents.DotNetBar.ItemPanel()
        Me.btnOrganisation = New DevComponents.DotNetBar.ButtonItem()
        Me.labelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem4 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem6 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem3 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem8 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.imageList2 = New System.Windows.Forms.ImageList()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdOrders = New System.Drawing.Printing.PrintDocument()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl2.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.dGridCreditNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.dGridQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.dGridPurchaseOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.cboSearchOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel17.SuspendLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dGridSupplierInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel5.SuspendLayout()
        CType(Me.dGridCreditors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel81.SuspendLayout()
        CType(Me.cboCreditorSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel2.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.dGridOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dGridOrdersList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel7.SuspendLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel15.SuspendLayout()
        Me.SideNavPanel3.SuspendLayout()
        Me.panelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager2
        '
        Me.StyleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager2.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3})
        Me.Bar3.Location = New System.Drawing.Point(0, 678)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(1007, 20)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 10
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Stretch = True
        Me.LabelItem3.Text = "Great Wits Light Purchasing 8.0"
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel5)
        Me.SideNav1.Controls.Add(Me.SideNavPanel7)
        Me.SideNav1.Controls.Add(Me.SideNavPanel3)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem4, Me.SideNavItem6, Me.SideNavItem2, Me.SideNavItem3, Me.SideNavItem8})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Margin = New System.Windows.Forms.Padding(0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1007, 678)
        Me.SideNav1.TabIndex = 11
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.SuperTabControl2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(119, 31)
        Me.SideNavPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Size = New System.Drawing.Size(887, 646)
        Me.SideNavPanel1.TabIndex = 2
        Me.SideNavPanel1.Visible = False
        '
        'SuperTabControl2
        '
        Me.SuperTabControl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl2.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl2.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl2.ControlBox.Name = ""
        Me.SuperTabControl2.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl2.ControlBox.MenuBox, Me.SuperTabControl2.ControlBox.CloseBox})
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl2.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl2.Location = New System.Drawing.Point(0, 1)
        Me.SuperTabControl2.Name = "SuperTabControl2"
        Me.SuperTabControl2.ReorderTabsEnabled = True
        Me.SuperTabControl2.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl2.SelectedTabIndex = 0
        Me.SuperTabControl2.Size = New System.Drawing.Size(887, 645)
        Me.SuperTabControl2.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl2.TabIndex = 151
        Me.SuperTabControl2.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem3, Me.SuperTabItem4, Me.SuperTabItem5})
        Me.SuperTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl2.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.dGridCreditNotes)
        Me.SuperTabControlPanel5.Controls.Add(Me.Bar8)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge7)
        Me.SuperTabControlPanel5.Controls.Add(Me.Bar7)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(887, 620)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem5
        '
        'dGridCreditNotes
        '
        Me.dGridCreditNotes.AllowUserToAddRows = False
        Me.dGridCreditNotes.AllowUserToDeleteRows = False
        Me.dGridCreditNotes.AllowUserToResizeRows = False
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridCreditNotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dGridCreditNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn15, Me.DataGridViewImageColumn2})
        Me.dGridCreditNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCreditNotes.Location = New System.Drawing.Point(0, 30)
        Me.dGridCreditNotes.Name = "dGridCreditNotes"
        Me.dGridCreditNotes.ReadOnly = True
        Me.dGridCreditNotes.RowHeadersWidth = 25
        Me.dGridCreditNotes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridCreditNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCreditNotes.Size = New System.Drawing.Size(887, 570)
        Me.dGridCreditNotes.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridCreditNotes.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridCreditNotes.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dGridCreditNotes.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridCreditNotes.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridCreditNotes.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridCreditNotes.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridCreditNotes.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCreditNotes.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCreditNotes.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridCreditNotes.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridCreditNotes.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridCreditNotes.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridCreditNotes.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCreditNotes.TabIndex = 156
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn12.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 63
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn11.HeaderText = "Doc. #"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 75
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn14.HeaderText = "Customer #"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 105
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn13.HeaderText = "Customer Name"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 129
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.Format = "N2"
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle27
        Me.DataGridViewTextBoxColumn15.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 80
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = CType(resources.GetObject("DataGridViewImageColumn2.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Width = 30
        '
        'Bar8
        '
        Me.Bar8.AntiAlias = True
        Me.Bar8.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar8.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar8.IsMaximized = False
        Me.Bar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem13, Me.LabelItem14, Me.LabelItem15, Me.LabelItem16, Me.LabelItem17, Me.LabelItem18, Me.LabelItem19})
        Me.Bar8.Location = New System.Drawing.Point(0, 600)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.RoundCorners = False
        Me.Bar8.Size = New System.Drawing.Size(887, 20)
        Me.Bar8.Stretch = True
        Me.Bar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar8.TabIndex = 155
        Me.Bar8.TabStop = False
        Me.Bar8.Text = "Bar8"
        '
        'LabelItem13
        '
        Me.LabelItem13.Name = "LabelItem13"
        Me.LabelItem13.PaddingLeft = 3
        Me.LabelItem13.PaddingRight = 3
        Me.LabelItem13.Stretch = True
        Me.LabelItem13.Text = "Totals"
        '
        'LabelItem14
        '
        Me.LabelItem14.Name = "LabelItem14"
        Me.LabelItem14.PaddingLeft = 3
        Me.LabelItem14.PaddingRight = 3
        Me.LabelItem14.Text = "Invoice Totals"
        '
        'LabelItem15
        '
        Me.LabelItem15.Name = "LabelItem15"
        Me.LabelItem15.PaddingLeft = 3
        Me.LabelItem15.PaddingRight = 3
        Me.LabelItem15.Text = "0.00"
        '
        'LabelItem16
        '
        Me.LabelItem16.Name = "LabelItem16"
        Me.LabelItem16.PaddingLeft = 3
        Me.LabelItem16.PaddingRight = 3
        Me.LabelItem16.Text = "Discounts"
        '
        'LabelItem17
        '
        Me.LabelItem17.Name = "LabelItem17"
        Me.LabelItem17.PaddingLeft = 3
        Me.LabelItem17.PaddingRight = 3
        Me.LabelItem17.Text = "0.00"
        '
        'LabelItem18
        '
        Me.LabelItem18.Name = "LabelItem18"
        Me.LabelItem18.PaddingLeft = 3
        Me.LabelItem18.PaddingRight = 3
        Me.LabelItem18.Text = "Taxes"
        '
        'LabelItem19
        '
        Me.LabelItem19.Name = "LabelItem19"
        Me.LabelItem19.PaddingLeft = 3
        Me.LabelItem19.PaddingRight = 3
        Me.LabelItem19.Text = "0.00"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 29)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'Bar7
        '
        Me.Bar7.AntiAlias = True
        Me.Bar7.BackColor = System.Drawing.Color.Transparent
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar7.IsMaximized = False
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewCreditNote, Me.btnEditCreditNote, Me.btnViewFilteredCreditNotes, Me.btnPrintCreditNote, Me.btnRefreshCreditNotes})
        Me.Bar7.Location = New System.Drawing.Point(0, 0)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.PaddingBottom = 3
        Me.Bar7.PaddingLeft = 3
        Me.Bar7.PaddingRight = 3
        Me.Bar7.PaddingTop = 3
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(887, 29)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar7.TabIndex = 153
        Me.Bar7.TabStop = False
        Me.Bar7.Text = "Bar7"
        '
        'btnNewCreditNote
        '
        Me.btnNewCreditNote.Image = CType(resources.GetObject("btnNewCreditNote.Image"), System.Drawing.Image)
        Me.btnNewCreditNote.Name = "btnNewCreditNote"
        Me.btnNewCreditNote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewCreditNote.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewCreditNote.Text = "New"
        '
        'btnEditCreditNote
        '
        Me.btnEditCreditNote.Image = CType(resources.GetObject("btnEditCreditNote.Image"), System.Drawing.Image)
        Me.btnEditCreditNote.Name = "btnEditCreditNote"
        Me.btnEditCreditNote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditCreditNote.Text = "Edit"
        '
        'btnViewFilteredCreditNotes
        '
        Me.btnViewFilteredCreditNotes.BeginGroup = True
        Me.btnViewFilteredCreditNotes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnViewFilteredCreditNotes.Image = CType(resources.GetObject("btnViewFilteredCreditNotes.Image"), System.Drawing.Image)
        Me.btnViewFilteredCreditNotes.Name = "btnViewFilteredCreditNotes"
        Me.btnViewFilteredCreditNotes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnViewFilteredCreditNotes.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnViewFilteredCreditNotes.Text = "View Filtered"
        '
        'btnPrintCreditNote
        '
        Me.btnPrintCreditNote.BeginGroup = True
        Me.btnPrintCreditNote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintCreditNote.Image = CType(resources.GetObject("btnPrintCreditNote.Image"), System.Drawing.Image)
        Me.btnPrintCreditNote.Name = "btnPrintCreditNote"
        Me.btnPrintCreditNote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintCreditNote.Text = "Print"
        '
        'btnRefreshCreditNotes
        '
        Me.btnRefreshCreditNotes.BeginGroup = True
        Me.btnRefreshCreditNotes.Image = CType(resources.GetObject("btnRefreshCreditNotes.Image"), System.Drawing.Image)
        Me.btnRefreshCreditNotes.Name = "btnRefreshCreditNotes"
        Me.btnRefreshCreditNotes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshCreditNotes.Text = "Refresh"
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "Debit Notes"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.dGridQuotes)
        Me.SuperTabControlPanel4.Controls.Add(Me.Bar6)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge6)
        Me.SuperTabControlPanel4.Controls.Add(Me.Bar5)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(887, 620)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'dGridQuotes
        '
        Me.dGridQuotes.AllowUserToAddRows = False
        Me.dGridQuotes.AllowUserToDeleteRows = False
        Me.dGridQuotes.AllowUserToResizeRows = False
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridQuotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle28
        Me.dGridQuotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewImageColumn1})
        Me.dGridQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridQuotes.Location = New System.Drawing.Point(0, 30)
        Me.dGridQuotes.Name = "dGridQuotes"
        Me.dGridQuotes.ReadOnly = True
        Me.dGridQuotes.RowHeadersWidth = 25
        Me.dGridQuotes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridQuotes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridQuotes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridQuotes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridQuotes.Size = New System.Drawing.Size(887, 570)
        Me.dGridQuotes.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridQuotes.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridQuotes.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dGridQuotes.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridQuotes.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridQuotes.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridQuotes.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridQuotes.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridQuotes.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridQuotes.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridQuotes.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridQuotes.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridQuotes.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridQuotes.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridQuotes.TabIndex = 155
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Doc. #"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 75
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 63
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Customer Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 129
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.Format = "N2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle29
        Me.DataGridViewTextBoxColumn8.HeaderText = "Quote Value"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 105
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.Format = "N2"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle30
        Me.DataGridViewTextBoxColumn9.HeaderText = "Discounts"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 91
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle31.Format = "N2"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle31
        Me.DataGridViewTextBoxColumn10.HeaderText = "Tax"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 56
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 30
        '
        'Bar6
        '
        Me.Bar6.AntiAlias = True
        Me.Bar6.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar6.IsMaximized = False
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.LabelItem5, Me.lblQuoteTotal, Me.LabelItem9, Me.lblQuoteTaxes, Me.LabelItem11, Me.lblQuoteDiscounts})
        Me.Bar6.Location = New System.Drawing.Point(0, 600)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.RoundCorners = False
        Me.Bar6.Size = New System.Drawing.Size(887, 20)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar6.TabIndex = 154
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 3
        Me.LabelItem2.PaddingRight = 3
        Me.LabelItem2.Stretch = True
        Me.LabelItem2.Text = "Totals"
        '
        'LabelItem5
        '
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingLeft = 3
        Me.LabelItem5.PaddingRight = 3
        Me.LabelItem5.Text = "Invoice Totals"
        '
        'lblQuoteTotal
        '
        Me.lblQuoteTotal.Name = "lblQuoteTotal"
        Me.lblQuoteTotal.PaddingLeft = 3
        Me.lblQuoteTotal.PaddingRight = 3
        Me.lblQuoteTotal.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem7})
        Me.lblQuoteTotal.Text = "0.00"
        '
        'LabelItem7
        '
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.PaddingLeft = 3
        Me.LabelItem7.PaddingRight = 3
        Me.LabelItem7.Text = "0.00"
        '
        'LabelItem9
        '
        Me.LabelItem9.Name = "LabelItem9"
        Me.LabelItem9.PaddingLeft = 3
        Me.LabelItem9.PaddingRight = 3
        Me.LabelItem9.Text = "Discounts"
        '
        'lblQuoteTaxes
        '
        Me.lblQuoteTaxes.Name = "lblQuoteTaxes"
        Me.lblQuoteTaxes.PaddingLeft = 3
        Me.lblQuoteTaxes.PaddingRight = 3
        Me.lblQuoteTaxes.Text = "0.00"
        '
        'LabelItem11
        '
        Me.LabelItem11.Name = "LabelItem11"
        Me.LabelItem11.PaddingLeft = 3
        Me.LabelItem11.PaddingRight = 3
        Me.LabelItem11.Text = "Taxes"
        '
        'lblQuoteDiscounts
        '
        Me.lblQuoteDiscounts.Name = "lblQuoteDiscounts"
        Me.lblQuoteDiscounts.PaddingLeft = 3
        Me.lblQuoteDiscounts.PaddingRight = 3
        Me.lblQuoteDiscounts.Text = "0.00"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 29)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.BackColor = System.Drawing.Color.Transparent
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewQuote, Me.btnEditQuote, Me.btnDeleteQuote, Me.btnFilterQuote, Me.ButtonItem4, Me.btnRefreshQuotes})
        Me.Bar5.Location = New System.Drawing.Point(0, 0)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(887, 29)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 152
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnNewQuote
        '
        Me.btnNewQuote.Image = CType(resources.GetObject("btnNewQuote.Image"), System.Drawing.Image)
        Me.btnNewQuote.Name = "btnNewQuote"
        Me.btnNewQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewQuote.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewQuote.Text = "New"
        '
        'btnEditQuote
        '
        Me.btnEditQuote.Image = CType(resources.GetObject("btnEditQuote.Image"), System.Drawing.Image)
        Me.btnEditQuote.Name = "btnEditQuote"
        Me.btnEditQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditQuote.Text = "Edit"
        '
        'btnDeleteQuote
        '
        Me.btnDeleteQuote.BeginGroup = True
        Me.btnDeleteQuote.Image = CType(resources.GetObject("btnDeleteQuote.Image"), System.Drawing.Image)
        Me.btnDeleteQuote.Name = "btnDeleteQuote"
        Me.btnDeleteQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnFilterQuote
        '
        Me.btnFilterQuote.BeginGroup = True
        Me.btnFilterQuote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFilterQuote.Image = CType(resources.GetObject("btnFilterQuote.Image"), System.Drawing.Image)
        Me.btnFilterQuote.Name = "btnFilterQuote"
        Me.btnFilterQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnFilterQuote.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnFilterQuote.Text = "View Filtered"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.BeginGroup = True
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSeletedRowQuote, Me.btnPrintQuoteList})
        Me.ButtonItem4.Text = "Print"
        '
        'btnPrintSeletedRowQuote
        '
        Me.btnPrintSeletedRowQuote.BeginGroup = True
        Me.btnPrintSeletedRowQuote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSeletedRowQuote.Name = "btnPrintSeletedRowQuote"
        Me.btnPrintSeletedRowQuote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSeletedRowQuote.SymbolSize = 16.0!
        Me.btnPrintSeletedRowQuote.Text = "Print Selected Row"
        '
        'btnPrintQuoteList
        '
        Me.btnPrintQuoteList.BeginGroup = True
        Me.btnPrintQuoteList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintQuoteList.Name = "btnPrintQuoteList"
        Me.btnPrintQuoteList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintQuoteList.SymbolSize = 16.0!
        Me.btnPrintQuoteList.Text = "Print Entire Sheet"
        '
        'btnRefreshQuotes
        '
        Me.btnRefreshQuotes.BeginGroup = True
        Me.btnRefreshQuotes.Image = CType(resources.GetObject("btnRefreshQuotes.Image"), System.Drawing.Image)
        Me.btnRefreshQuotes.Name = "btnRefreshQuotes"
        Me.btnRefreshQuotes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshQuotes.Text = "Refresh"
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Delivery Notes"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.dGridPurchaseOrders)
        Me.SuperTabControlPanel3.Controls.Add(Me.KryptonPanel13)
        Me.SuperTabControlPanel3.Controls.Add(Me.Bar4)
        Me.SuperTabControlPanel3.Controls.Add(Me.KryptonBorderEdge5)
        Me.SuperTabControlPanel3.Controls.Add(Me.Bar1)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(887, 620)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'dGridPurchaseOrders
        '
        Me.dGridPurchaseOrders.AllowUserToAddRows = False
        Me.dGridPurchaseOrders.AllowUserToDeleteRows = False
        Me.dGridPurchaseOrders.AllowUserToResizeRows = False
        Me.dGridPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridPurchaseOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column5, Me.Column1, Me.DataGridViewTextBoxColumn25, Me.Column4, Me.Column6})
        Me.dGridPurchaseOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridPurchaseOrders.HideOuterBorders = True
        Me.dGridPurchaseOrders.Location = New System.Drawing.Point(0, 92)
        Me.dGridPurchaseOrders.Name = "dGridPurchaseOrders"
        Me.dGridPurchaseOrders.ReadOnly = True
        Me.dGridPurchaseOrders.RowHeadersWidth = 25
        Me.dGridPurchaseOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPurchaseOrders.Size = New System.Drawing.Size(887, 508)
        Me.dGridPurchaseOrders.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridPurchaseOrders.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPurchaseOrders.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPurchaseOrders.TabIndex = 157
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
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn25.HeaderText = "Account Name"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 118
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle32.Format = "N2"
        DataGridViewCellStyle32.NullValue = "0.00"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle32
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
        'KryptonPanel13
        '
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel13.Controls.Add(Me.cboSearchOptions)
        Me.KryptonPanel13.Controls.Add(Me.KryptonPanel14)
        Me.KryptonPanel13.Controls.Add(Me.KryptonPanel17)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel13.Controls.Add(Me.dpStartFrom)
        Me.KryptonPanel13.Controls.Add(Me.dpEndTo)
        Me.KryptonPanel13.Controls.Add(Me.btnProcess)
        Me.KryptonPanel13.Controls.Add(Me.KryptonPanel18)
        Me.KryptonPanel13.Controls.Add(Me.KryptonPanel19)
        Me.KryptonPanel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(0, 30)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(887, 62)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel13.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel13.TabIndex = 156
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(679, 20)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(186, 20)
        Me.txtSearchString.TabIndex = 153
        '
        'cboSearchOptions
        '
        Me.cboSearchOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboSearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchOptions.DropDownWidth = 143
        Me.cboSearchOptions.ForeColor = System.Drawing.Color.Black
        Me.cboSearchOptions.Items.AddRange(New Object() {"Account number", "Account name"})
        Me.cboSearchOptions.Location = New System.Drawing.Point(487, 22)
        Me.cboSearchOptions.Name = "cboSearchOptions"
        Me.cboSearchOptions.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchOptions.Size = New System.Drawing.Size(115, 21)
        Me.cboSearchOptions.TabIndex = 152
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge20)
        Me.KryptonPanel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel14.Location = New System.Drawing.Point(609, 22)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(68, 21)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 151
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(68, 20)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Search for"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(68, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonPanel17
        '
        Me.KryptonPanel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel17.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel17.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel17.Location = New System.Drawing.Point(418, 22)
        Me.KryptonPanel17.Name = "KryptonPanel17"
        Me.KryptonPanel17.Size = New System.Drawing.Size(67, 21)
        Me.KryptonPanel17.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel17.TabIndex = 150
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(67, 20)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Search by"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(67, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 61)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'dpStartFrom
        '
        Me.dpStartFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartFrom.ForeColor = System.Drawing.Color.Black
        Me.dpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFrom.Location = New System.Drawing.Point(57, 21)
        Me.dpStartFrom.Name = "dpStartFrom"
        Me.dpStartFrom.Size = New System.Drawing.Size(113, 22)
        Me.dpStartFrom.TabIndex = 10
        '
        'dpEndTo
        '
        Me.dpEndTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndTo.ForeColor = System.Drawing.Color.Black
        Me.dpEndTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndTo.Location = New System.Drawing.Point(217, 21)
        Me.dpEndTo.Name = "dpEndTo"
        Me.dpEndTo.Size = New System.Drawing.Size(113, 22)
        Me.dpEndTo.TabIndex = 149
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnProcess.ForeColor = System.Drawing.Color.Black
        Me.btnProcess.Location = New System.Drawing.Point(334, 21)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(69, 22)
        Me.btnProcess.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnProcess.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnProcess.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnProcess.StateCommon.Border.Rounding = 0
        Me.btnProcess.TabIndex = 148
        Me.btnProcess.Values.Image = CType(resources.GetObject("btnProcess.Values.Image"), System.Drawing.Image)
        Me.btnProcess.Values.Text = "Process"
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge27)
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(175, 22)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(40, 21)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel18.TabIndex = 147
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(40, 20)
        Me.KryptonLabel8.TabIndex = 1
        Me.KryptonLabel8.Values.Text = "  to  "
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge27.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(40, 1)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'KryptonPanel19
        '
        Me.KryptonPanel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel19.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge28)
        Me.KryptonPanel19.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel19.Location = New System.Drawing.Point(14, 22)
        Me.KryptonPanel19.Name = "KryptonPanel19"
        Me.KryptonPanel19.Size = New System.Drawing.Size(41, 21)
        Me.KryptonPanel19.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel19.TabIndex = 146
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(41, 20)
        Me.KryptonLabel9.TabIndex = 1
        Me.KryptonLabel9.Values.Text = "From"
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge28.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(41, 1)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Totals, Me.LabelItem4, Me.lblTotalOrders, Me.LabelItem6, Me.lblDiscounts, Me.LabelItem8, Me.lblTaxes})
        Me.Bar4.Location = New System.Drawing.Point(0, 600)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(887, 20)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 153
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'Totals
        '
        Me.Totals.Name = "Totals"
        Me.Totals.PaddingLeft = 3
        Me.Totals.PaddingRight = 3
        Me.Totals.Stretch = True
        Me.Totals.Text = "Totals"
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 3
        Me.LabelItem4.PaddingRight = 3
        Me.LabelItem4.Text = "Orders Totals"
        '
        'lblTotalOrders
        '
        Me.lblTotalOrders.Name = "lblTotalOrders"
        Me.lblTotalOrders.PaddingLeft = 3
        Me.lblTotalOrders.PaddingRight = 3
        Me.lblTotalOrders.Text = "0.00"
        '
        'LabelItem6
        '
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingLeft = 3
        Me.LabelItem6.PaddingRight = 3
        Me.LabelItem6.Text = "Discounts"
        '
        'lblDiscounts
        '
        Me.lblDiscounts.Name = "lblDiscounts"
        Me.lblDiscounts.PaddingLeft = 3
        Me.lblDiscounts.PaddingRight = 3
        Me.lblDiscounts.Text = "0.00"
        '
        'LabelItem8
        '
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingLeft = 3
        Me.LabelItem8.PaddingRight = 3
        Me.LabelItem8.Text = "Taxes"
        '
        'lblTaxes
        '
        Me.lblTaxes.Name = "lblTaxes"
        Me.lblTaxes.PaddingLeft = 3
        Me.lblTaxes.PaddingRight = 3
        Me.lblTaxes.Text = "0.00"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 29)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewOrder, Me.btnEditOrder, Me.btnPrint, Me.btnDeliveryNote, Me.btnRefreshOrders})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(887, 29)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 151
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNewOrder
        '
        Me.btnNewOrder.Image = CType(resources.GetObject("btnNewOrder.Image"), System.Drawing.Image)
        Me.btnNewOrder.Name = "btnNewOrder"
        Me.btnNewOrder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewOrder.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewOrder.Text = "New"
        '
        'btnEditOrder
        '
        Me.btnEditOrder.Image = CType(resources.GetObject("btnEditOrder.Image"), System.Drawing.Image)
        Me.btnEditOrder.Name = "btnEditOrder"
        Me.btnEditOrder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditOrder.Text = "Edit"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSummaryOrders, Me.btnSelectedOrder})
        Me.btnPrint.Text = "Print"
        '
        'btnSummaryOrders
        '
        Me.btnSummaryOrders.BeginGroup = True
        Me.btnSummaryOrders.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSummaryOrders.Name = "btnSummaryOrders"
        Me.btnSummaryOrders.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSummaryOrders.Text = "Orders Summary"
        '
        'btnSelectedOrder
        '
        Me.btnSelectedOrder.BeginGroup = True
        Me.btnSelectedOrder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSelectedOrder.Name = "btnSelectedOrder"
        Me.btnSelectedOrder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSelectedOrder.Text = "Selected Order"
        '
        'btnDeliveryNote
        '
        Me.btnDeliveryNote.BeginGroup = True
        Me.btnDeliveryNote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDeliveryNote.Image = CType(resources.GetObject("btnDeliveryNote.Image"), System.Drawing.Image)
        Me.btnDeliveryNote.Name = "btnDeliveryNote"
        Me.btnDeliveryNote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeliveryNote.Text = "Delivery Note"
        '
        'btnRefreshOrders
        '
        Me.btnRefreshOrders.BeginGroup = True
        Me.btnRefreshOrders.Image = CType(resources.GetObject("btnRefreshOrders.Image"), System.Drawing.Image)
        Me.btnRefreshOrders.Name = "btnRefreshOrders"
        Me.btnRefreshOrders.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshOrders.Text = "Refresh"
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Orders"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dGridSupplierInvoices)
        Me.SuperTabControlPanel1.Controls.Add(Me.Bar10)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonPanel3)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge11)
        Me.SuperTabControlPanel1.Controls.Add(Me.Bar9)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(887, 620)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'dGridSupplierInvoices
        '
        Me.dGridSupplierInvoices.AllowUserToAddRows = False
        Me.dGridSupplierInvoices.AllowUserToDeleteRows = False
        Me.dGridSupplierInvoices.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridSupplierInvoices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridSupplierInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24})
        Me.dGridSupplierInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSupplierInvoices.Location = New System.Drawing.Point(0, 96)
        Me.dGridSupplierInvoices.Name = "dGridSupplierInvoices"
        Me.dGridSupplierInvoices.ReadOnly = True
        Me.dGridSupplierInvoices.RowHeadersWidth = 25
        Me.dGridSupplierInvoices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridSupplierInvoices.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridSupplierInvoices.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridSupplierInvoices.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridSupplierInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridSupplierInvoices.Size = New System.Drawing.Size(887, 504)
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
        Me.dGridSupplierInvoices.TabIndex = 159
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn19.HeaderText = "Doc. #"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 75
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn20.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 63
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn21.HeaderText = "Supplier Name"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 120
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "N2"
        Me.DataGridViewTextBoxColumn22.DefaultCellStyle = DataGridViewCellStyle23
        Me.DataGridViewTextBoxColumn22.HeaderText = "Invoice Value"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 113
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.Format = "N2"
        Me.DataGridViewTextBoxColumn23.DefaultCellStyle = DataGridViewCellStyle24
        Me.DataGridViewTextBoxColumn23.HeaderText = "Discounts"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 91
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N2"
        Me.DataGridViewTextBoxColumn24.DefaultCellStyle = DataGridViewCellStyle25
        Me.DataGridViewTextBoxColumn24.HeaderText = "Tax"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 56
        '
        'Bar10
        '
        Me.Bar10.AntiAlias = True
        Me.Bar10.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar10.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar10.IsMaximized = False
        Me.Bar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem12, Me.LabelItem20, Me.LabelItem21, Me.LabelItem22, Me.LabelItem23, Me.LabelItem24})
        Me.Bar10.Location = New System.Drawing.Point(0, 600)
        Me.Bar10.Name = "Bar10"
        Me.Bar10.RoundCorners = False
        Me.Bar10.Size = New System.Drawing.Size(887, 20)
        Me.Bar10.Stretch = True
        Me.Bar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar10.TabIndex = 158
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
        'LabelItem20
        '
        Me.LabelItem20.Name = "LabelItem20"
        Me.LabelItem20.PaddingLeft = 3
        Me.LabelItem20.PaddingRight = 3
        Me.LabelItem20.Text = "0.00"
        '
        'LabelItem21
        '
        Me.LabelItem21.Name = "LabelItem21"
        Me.LabelItem21.PaddingLeft = 3
        Me.LabelItem21.PaddingRight = 3
        Me.LabelItem21.Text = "Discounts"
        '
        'LabelItem22
        '
        Me.LabelItem22.Name = "LabelItem22"
        Me.LabelItem22.PaddingLeft = 3
        Me.LabelItem22.PaddingRight = 3
        Me.LabelItem22.Text = "0.00"
        '
        'LabelItem23
        '
        Me.LabelItem23.Name = "LabelItem23"
        Me.LabelItem23.PaddingLeft = 3
        Me.LabelItem23.PaddingRight = 3
        Me.LabelItem23.Text = "Taxes"
        '
        'LabelItem24
        '
        Me.LabelItem24.Name = "LabelItem24"
        Me.LabelItem24.PaddingLeft = 3
        Me.LabelItem24.PaddingRight = 3
        Me.LabelItem24.Text = "0.00"
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
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 30)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(887, 66)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel3.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel3.TabIndex = 157
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 65)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(887, 1)
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
        Me.dpEndSupplierInvoice.Size = New System.Drawing.Size(95, 22)
        Me.dpEndSupplierInvoice.TabIndex = 5
        '
        'dpStartSupplierInvoice
        '
        Me.dpStartSupplierInvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartSupplierInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpStartSupplierInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartSupplierInvoice.Location = New System.Drawing.Point(99, 21)
        Me.dpStartSupplierInvoice.Name = "dpStartSupplierInvoice"
        Me.dpStartSupplierInvoice.Size = New System.Drawing.Size(103, 22)
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
        Me.btnRunInvoice.Location = New System.Drawing.Point(368, 21)
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
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 29)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'Bar9
        '
        Me.Bar9.AntiAlias = True
        Me.Bar9.BackColor = System.Drawing.Color.Transparent
        Me.Bar9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar9.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar9.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar9.IsMaximized = False
        Me.Bar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewSupplierInvoice, Me.btnEditSupplierInvoice, Me.btnDeleteSupplierInvoice, Me.ButtonItem3, Me.btnSupplierPayments, Me.btnRefreshSupplier})
        Me.Bar9.Location = New System.Drawing.Point(0, 0)
        Me.Bar9.Name = "Bar9"
        Me.Bar9.PaddingBottom = 3
        Me.Bar9.PaddingLeft = 3
        Me.Bar9.PaddingRight = 3
        Me.Bar9.PaddingTop = 3
        Me.Bar9.RoundCorners = False
        Me.Bar9.Size = New System.Drawing.Size(887, 29)
        Me.Bar9.Stretch = True
        Me.Bar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar9.TabIndex = 152
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
        'btnRefreshSupplier
        '
        Me.btnRefreshSupplier.BeginGroup = True
        Me.btnRefreshSupplier.Image = CType(resources.GetObject("btnRefreshSupplier.Image"), System.Drawing.Image)
        Me.btnRefreshSupplier.Name = "btnRefreshSupplier"
        Me.btnRefreshSupplier.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshSupplier.Text = "Refresh"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Supplier Invoices"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'SideNavPanel5
        '
        Me.SideNavPanel5.Controls.Add(Me.dGridCreditors)
        Me.SideNavPanel5.Controls.Add(Me.KryptonPanel8)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge9)
        Me.SideNavPanel5.Controls.Add(Me.Bar14)
        Me.SideNavPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel5.Location = New System.Drawing.Point(119, 31)
        Me.SideNavPanel5.Name = "SideNavPanel5"
        Me.SideNavPanel5.Size = New System.Drawing.Size(887, 646)
        Me.SideNavPanel5.TabIndex = 24
        Me.SideNavPanel5.Visible = False
        '
        'dGridCreditors
        '
        Me.dGridCreditors.AllowUserToAddRows = False
        Me.dGridCreditors.AllowUserToDeleteRows = False
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridCreditors.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle33
        Me.dGridCreditors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridCreditors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39})
        Me.dGridCreditors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCreditors.Location = New System.Drawing.Point(0, 83)
        Me.dGridCreditors.Name = "dGridCreditors"
        Me.dGridCreditors.ReadOnly = True
        Me.dGridCreditors.RowHeadersWidth = 25
        Me.dGridCreditors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridCreditors.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridCreditors.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridCreditors.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridCreditors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCreditors.Size = New System.Drawing.Size(887, 563)
        Me.dGridCreditors.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridCreditors.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridCreditors.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridCreditors.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCreditors.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCreditors.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCreditors.TabIndex = 22
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn33.HeaderText = "Account No."
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Width = 104
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn34.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 69
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn35.HeaderText = "Telephone"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        Me.DataGridViewTextBoxColumn35.Width = 94
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn36.HeaderText = "Take On Date"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Width = 114
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn37.DefaultCellStyle = DataGridViewCellStyle34
        Me.DataGridViewTextBoxColumn37.HeaderText = "Email Address"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        Me.DataGridViewTextBoxColumn37.Width = 117
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn38.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        Me.DataGridViewTextBoxColumn38.Width = 82
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn39.HeaderText = "Cellphone"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        Me.DataGridViewTextBoxColumn39.Width = 93
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel81)
        Me.KryptonPanel8.Controls.Add(Me.cboCreditorSearchBy)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel8.Controls.Add(Me.txtCreditorSearchString)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(0, 32)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(887, 51)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.TabIndex = 19
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel10.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(264, 15)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(86, 20)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 146
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(86, 20)
        Me.KryptonLabel2.TabIndex = 0
        Me.KryptonLabel2.Values.Text = "Search string"
        '
        'KryptonPanel81
        '
        Me.KryptonPanel81.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel81.Controls.Add(Me.KryptonBorderEdge82)
        Me.KryptonPanel81.Controls.Add(Me.KryptonLabel67)
        Me.KryptonPanel81.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel81.Location = New System.Drawing.Point(8, 16)
        Me.KryptonPanel81.Name = "KryptonPanel81"
        Me.KryptonPanel81.Size = New System.Drawing.Size(86, 20)
        Me.KryptonPanel81.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel81.TabIndex = 145
        '
        'KryptonBorderEdge82
        '
        Me.KryptonBorderEdge82.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge82.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge82.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge82.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge82.Name = "KryptonBorderEdge82"
        Me.KryptonBorderEdge82.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge82.Text = "KryptonBorderEdge82"
        '
        'KryptonLabel67
        '
        Me.KryptonLabel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel67.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel67.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel67.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel67.Name = "KryptonLabel67"
        Me.KryptonLabel67.Size = New System.Drawing.Size(86, 20)
        Me.KryptonLabel67.TabIndex = 0
        Me.KryptonLabel67.Values.Text = "Search filter"
        '
        'cboCreditorSearchBy
        '
        Me.cboCreditorSearchBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboCreditorSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCreditorSearchBy.DropDownWidth = 152
        Me.cboCreditorSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboCreditorSearchBy.Items.AddRange(New Object() {"Account Number", "Account Name", "Account Type"})
        Me.cboCreditorSearchBy.Location = New System.Drawing.Point(96, 15)
        Me.cboCreditorSearchBy.Name = "cboCreditorSearchBy"
        Me.cboCreditorSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboCreditorSearchBy.Size = New System.Drawing.Size(152, 21)
        Me.cboCreditorSearchBy.TabIndex = 3
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(886, 0)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 50)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'txtCreditorSearchString
        '
        Me.txtCreditorSearchString.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCreditorSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtCreditorSearchString.Location = New System.Drawing.Point(352, 15)
        Me.txtCreditorSearchString.Name = "txtCreditorSearchString"
        Me.txtCreditorSearchString.Size = New System.Drawing.Size(211, 20)
        Me.txtCreditorSearchString.TabIndex = 1
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 31)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'Bar14
        '
        Me.Bar14.AntiAlias = True
        Me.Bar14.BackColor = System.Drawing.Color.Transparent
        Me.Bar14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar14.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar14.IsMaximized = False
        Me.Bar14.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewSupplier, Me.btnEditCreditor, Me.btnDeleteSupplier, Me.ButtonItem18, Me.btnExportSuppliers, Me.btnAccountSettlement, Me.btnRefreshCreditors})
        Me.Bar14.Location = New System.Drawing.Point(0, 0)
        Me.Bar14.Name = "Bar14"
        Me.Bar14.RoundCorners = False
        Me.Bar14.Size = New System.Drawing.Size(887, 31)
        Me.Bar14.Stretch = True
        Me.Bar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar14.TabIndex = 17
        Me.Bar14.TabStop = False
        Me.Bar14.Text = "Bar14"
        '
        'btnNewSupplier
        '
        Me.btnNewSupplier.Image = CType(resources.GetObject("btnNewSupplier.Image"), System.Drawing.Image)
        Me.btnNewSupplier.Name = "btnNewSupplier"
        Me.btnNewSupplier.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewSupplier.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewSupplier.Text = "New"
        '
        'btnEditCreditor
        '
        Me.btnEditCreditor.Image = CType(resources.GetObject("btnEditCreditor.Image"), System.Drawing.Image)
        Me.btnEditCreditor.Name = "btnEditCreditor"
        Me.btnEditCreditor.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditCreditor.Text = "Edit"
        '
        'btnDeleteSupplier
        '
        Me.btnDeleteSupplier.BeginGroup = True
        Me.btnDeleteSupplier.Image = CType(resources.GetObject("btnDeleteSupplier.Image"), System.Drawing.Image)
        Me.btnDeleteSupplier.Name = "btnDeleteSupplier"
        Me.btnDeleteSupplier.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteSupplier.Text = "Delete"
        '
        'ButtonItem18
        '
        Me.ButtonItem18.BeginGroup = True
        Me.ButtonItem18.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem18.Image = CType(resources.GetObject("ButtonItem18.Image"), System.Drawing.Image)
        Me.ButtonItem18.Name = "ButtonItem18"
        Me.ButtonItem18.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem18.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNotZero, Me.btnPrintAllCustomers})
        Me.ButtonItem18.Text = "Print"
        '
        'btnNotZero
        '
        Me.btnNotZero.Name = "btnNotZero"
        Me.btnNotZero.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNotZero.Text = "Print Not Zero"
        '
        'btnPrintAllCustomers
        '
        Me.btnPrintAllCustomers.BeginGroup = True
        Me.btnPrintAllCustomers.Name = "btnPrintAllCustomers"
        Me.btnPrintAllCustomers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintAllCustomers.Text = "Print All"
        '
        'btnExportSuppliers
        '
        Me.btnExportSuppliers.BeginGroup = True
        Me.btnExportSuppliers.Name = "btnExportSuppliers"
        Me.btnExportSuppliers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportSuppliers.Symbol = ""
        Me.btnExportSuppliers.Text = "Export"
        '
        'btnAccountSettlement
        '
        Me.btnAccountSettlement.BeginGroup = True
        Me.btnAccountSettlement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAccountSettlement.Image = CType(resources.GetObject("btnAccountSettlement.Image"), System.Drawing.Image)
        Me.btnAccountSettlement.Name = "btnAccountSettlement"
        Me.btnAccountSettlement.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAccountSettlement.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnAccountSettlement.Text = "Payments"
        '
        'btnRefreshCreditors
        '
        Me.btnRefreshCreditors.BeginGroup = True
        Me.btnRefreshCreditors.Image = CType(resources.GetObject("btnRefreshCreditors.Image"), System.Drawing.Image)
        Me.btnRefreshCreditors.Name = "btnRefreshCreditors"
        Me.btnRefreshCreditors.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshCreditors.Text = "&Refresh"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Controls.Add(Me.KryptonPanel7)
        Me.SideNavPanel2.Controls.Add(Me.KryptonPanel6)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.SideNavPanel2.Controls.Add(Me.KryptonPanel1)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.SideNavPanel2.Controls.Add(Me.Bar2)
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(119, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Size = New System.Drawing.Size(887, 646)
        Me.SideNavPanel2.TabIndex = 42
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(471, 77)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel7.Size = New System.Drawing.Size(416, 568)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel7.TabIndex = 139
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dGridOrderDetails)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel9)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(406, 558)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "Batch Details"
        Me.KryptonGroupBox1.Values.Heading = "Batch Details"
        '
        'dGridOrderDetails
        '
        Me.dGridOrderDetails.AllowUserToAddRows = False
        Me.dGridOrderDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridOrderDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dGridOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridOrderDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18})
        Me.dGridOrderDetails.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dGridOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridOrderDetails.Location = New System.Drawing.Point(0, 0)
        Me.dGridOrderDetails.Name = "dGridOrderDetails"
        Me.dGridOrderDetails.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003
        Me.dGridOrderDetails.ReadOnly = True
        Me.dGridOrderDetails.RowHeadersWidth = 25
        Me.dGridOrderDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridOrderDetails.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridOrderDetails.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridOrderDetails.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridOrderDetails.Size = New System.Drawing.Size(404, 453)
        Me.dGridOrderDetails.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridOrderDetails.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridOrderDetails.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOrderDetails.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrderDetails.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrderDetails.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridOrderDetails.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridOrderDetails.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridOrderDetails.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOrderDetails.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrderDetails.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrderDetails.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridOrderDetails.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridOrderDetails.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridOrderDetails.TabIndex = 133
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle21.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn4.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 97
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn16.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn17.HeaderText = "Serial #"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 82
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn18.HeaderText = "Unit Price"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 90
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAdjustPrice})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(147, 26)
        '
        'mnuAdjustPrice
        '
        Me.mnuAdjustPrice.Name = "mnuAdjustPrice"
        Me.mnuAdjustPrice.Size = New System.Drawing.Size(146, 22)
        Me.mnuAdjustPrice.Text = "Adjust Details"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.lblBatchCostTotalOrders)
        Me.KryptonPanel9.Controls.Add(Me.Label8)
        Me.KryptonPanel9.Controls.Add(Me.lblEntriesCountOrders)
        Me.KryptonPanel9.Controls.Add(Me.Label6)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(0, 453)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(404, 82)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 0
        '
        'lblBatchCostTotalOrders
        '
        Me.lblBatchCostTotalOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblBatchCostTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchCostTotalOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBatchCostTotalOrders.ForeColor = System.Drawing.Color.Black
        Me.lblBatchCostTotalOrders.Location = New System.Drawing.Point(135, 32)
        Me.lblBatchCostTotalOrders.Name = "lblBatchCostTotalOrders"
        Me.lblBatchCostTotalOrders.Size = New System.Drawing.Size(106, 19)
        Me.lblBatchCostTotalOrders.TabIndex = 25
        Me.lblBatchCostTotalOrders.Text = "0.00"
        Me.lblBatchCostTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(10, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 19)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Batch Cost Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEntriesCountOrders
        '
        Me.lblEntriesCountOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEntriesCountOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntriesCountOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntriesCountOrders.ForeColor = System.Drawing.Color.Black
        Me.lblEntriesCountOrders.Location = New System.Drawing.Point(135, 12)
        Me.lblEntriesCountOrders.Name = "lblEntriesCountOrders"
        Me.lblEntriesCountOrders.Size = New System.Drawing.Size(106, 19)
        Me.lblEntriesCountOrders.TabIndex = 23
        Me.lblEntriesCountOrders.Text = "0.00"
        Me.lblEntriesCountOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(10, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 19)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Entries Count"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(404, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(0, 77)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel6.Size = New System.Drawing.Size(471, 568)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 138
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(5, 5)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dGridOrdersList)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox2.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(461, 558)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 132
        Me.KryptonGroupBox2.Text = "Orders Listing"
        Me.KryptonGroupBox2.Values.Heading = "Orders Listing"
        '
        'dGridOrdersList
        '
        Me.dGridOrdersList.AllowUserToAddRows = False
        Me.dGridOrdersList.AllowUserToDeleteRows = False
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridOrdersList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle35
        Me.dGridOrdersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridOrdersList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column2})
        Me.dGridOrdersList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridOrdersList.Location = New System.Drawing.Point(0, 0)
        Me.dGridOrdersList.Name = "dGridOrdersList"
        Me.dGridOrdersList.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003
        Me.dGridOrdersList.ReadOnly = True
        Me.dGridOrdersList.RowHeadersWidth = 25
        Me.dGridOrdersList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridOrdersList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridOrdersList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridOrdersList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridOrdersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridOrdersList.Size = New System.Drawing.Size(459, 453)
        Me.dGridOrdersList.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridOrdersList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridOrdersList.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOrdersList.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrdersList.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrdersList.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridOrdersList.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridOrdersList.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridOrdersList.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOrdersList.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrdersList.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOrdersList.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridOrdersList.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridOrdersList.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridOrdersList.TabIndex = 132
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle36.NullValue = "0"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle36
        Me.DataGridViewTextBoxColumn1.HeaderText = "Batch No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 91
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 63
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N2"
        DataGridViewCellStyle37.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle37
        Me.DataGridViewTextBoxColumn3.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 67
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Status"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 72
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.lblGrandTotalOrders)
        Me.KryptonPanel2.Controls.Add(Me.Label4)
        Me.KryptonPanel2.Controls.Add(Me.lblUnprocessedTotalOrders)
        Me.KryptonPanel2.Controls.Add(Me.Label3)
        Me.KryptonPanel2.Controls.Add(Me.lblProcessedTotalOrders)
        Me.KryptonPanel2.Controls.Add(Me.Label2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 453)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(459, 82)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 0
        '
        'lblGrandTotalOrders
        '
        Me.lblGrandTotalOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrandTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrandTotalOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrandTotalOrders.ForeColor = System.Drawing.Color.Black
        Me.lblGrandTotalOrders.Location = New System.Drawing.Point(135, 52)
        Me.lblGrandTotalOrders.Name = "lblGrandTotalOrders"
        Me.lblGrandTotalOrders.Size = New System.Drawing.Size(106, 19)
        Me.lblGrandTotalOrders.TabIndex = 23
        Me.lblGrandTotalOrders.Text = "0.00"
        Me.lblGrandTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(10, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 19)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Grand Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnprocessedTotalOrders
        '
        Me.lblUnprocessedTotalOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblUnprocessedTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnprocessedTotalOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnprocessedTotalOrders.ForeColor = System.Drawing.Color.Black
        Me.lblUnprocessedTotalOrders.Location = New System.Drawing.Point(135, 32)
        Me.lblUnprocessedTotalOrders.Name = "lblUnprocessedTotalOrders"
        Me.lblUnprocessedTotalOrders.Size = New System.Drawing.Size(106, 19)
        Me.lblUnprocessedTotalOrders.TabIndex = 21
        Me.lblUnprocessedTotalOrders.Text = "0.00"
        Me.lblUnprocessedTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 19)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Unprocessed Total"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessedTotalOrders
        '
        Me.lblProcessedTotalOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblProcessedTotalOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcessedTotalOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblProcessedTotalOrders.ForeColor = System.Drawing.Color.Black
        Me.lblProcessedTotalOrders.Location = New System.Drawing.Point(135, 12)
        Me.lblProcessedTotalOrders.Name = "lblProcessedTotalOrders"
        Me.lblProcessedTotalOrders.Size = New System.Drawing.Size(106, 19)
        Me.lblProcessedTotalOrders.TabIndex = 19
        Me.lblProcessedTotalOrders.Text = "0.00"
        Me.lblProcessedTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 19)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Processed Total"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(459, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 645)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.dpEndToOrders)
        Me.KryptonPanel1.Controls.Add(Me.dpStartFromOrders)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge21)
        Me.KryptonPanel1.Controls.Add(Me.btnGoOrders)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 26)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(887, 51)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 131
        '
        'dpEndToOrders
        '
        Me.dpEndToOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndToOrders.ForeColor = System.Drawing.Color.Black
        Me.dpEndToOrders.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndToOrders.Location = New System.Drawing.Point(244, 14)
        Me.dpEndToOrders.Name = "dpEndToOrders"
        Me.dpEndToOrders.Size = New System.Drawing.Size(84, 22)
        Me.dpEndToOrders.TabIndex = 19
        '
        'dpStartFromOrders
        '
        Me.dpStartFromOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartFromOrders.ForeColor = System.Drawing.Color.Black
        Me.dpStartFromOrders.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFromOrders.Location = New System.Drawing.Point(77, 14)
        Me.dpStartFromOrders.Name = "dpStartFromOrders"
        Me.dpStartFromOrders.Size = New System.Drawing.Size(87, 22)
        Me.dpStartFromOrders.TabIndex = 18
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'btnGoOrders
        '
        Me.btnGoOrders.AutoSize = True
        Me.btnGoOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGoOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnGoOrders.ForeColor = System.Drawing.Color.Black
        Me.btnGoOrders.Location = New System.Drawing.Point(332, 14)
        Me.btnGoOrders.Name = "btnGoOrders"
        Me.btnGoOrders.Size = New System.Drawing.Size(59, 22)
        Me.btnGoOrders.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnGoOrders.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btnGoOrders.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnGoOrders.StateCommon.Border.Rounding = 0
        Me.btnGoOrders.TabIndex = 20
        Me.btnGoOrders.Values.Image = CType(resources.GetObject("btnGoOrders.Values.Image"), System.Drawing.Image)
        Me.btnGoOrders.Values.Text = "Query"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(8, 14)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(67, 22)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 3
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(67, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Date from"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(67, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(181, 14)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(61, 22)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 2
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(61, 21)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Date to"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(61, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewGoodsIn, Me.btnEditGoodsIn, Me.btnDeleteGoodsIn, Me.btnPrintReceivedOrder, Me.btnPostReceivedOrder, Me.ButtonItem10})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(887, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 18
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnNewGoodsIn
        '
        Me.btnNewGoodsIn.Image = CType(resources.GetObject("btnNewGoodsIn.Image"), System.Drawing.Image)
        Me.btnNewGoodsIn.Name = "btnNewGoodsIn"
        Me.btnNewGoodsIn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewGoodsIn.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewGoodsIn.Text = "New"
        '
        'btnEditGoodsIn
        '
        Me.btnEditGoodsIn.Image = CType(resources.GetObject("btnEditGoodsIn.Image"), System.Drawing.Image)
        Me.btnEditGoodsIn.Name = "btnEditGoodsIn"
        Me.btnEditGoodsIn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditGoodsIn.Text = "Edit"
        Me.btnEditGoodsIn.Visible = False
        '
        'btnDeleteGoodsIn
        '
        Me.btnDeleteGoodsIn.BeginGroup = True
        Me.btnDeleteGoodsIn.Image = CType(resources.GetObject("btnDeleteGoodsIn.Image"), System.Drawing.Image)
        Me.btnDeleteGoodsIn.Name = "btnDeleteGoodsIn"
        Me.btnDeleteGoodsIn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteGoodsIn.Text = "Delete"
        '
        'btnPrintReceivedOrder
        '
        Me.btnPrintReceivedOrder.BeginGroup = True
        Me.btnPrintReceivedOrder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintReceivedOrder.Image = CType(resources.GetObject("btnPrintReceivedOrder.Image"), System.Drawing.Image)
        Me.btnPrintReceivedOrder.Name = "btnPrintReceivedOrder"
        Me.btnPrintReceivedOrder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintReceivedOrder.Text = "Print"
        '
        'btnPostReceivedOrder
        '
        Me.btnPostReceivedOrder.BeginGroup = True
        Me.btnPostReceivedOrder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPostReceivedOrder.Image = CType(resources.GetObject("btnPostReceivedOrder.Image"), System.Drawing.Image)
        Me.btnPostReceivedOrder.Name = "btnPostReceivedOrder"
        Me.btnPostReceivedOrder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPostReceivedOrder.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPostReceivedOrder.Text = "Post"
        Me.btnPostReceivedOrder.Visible = False
        '
        'ButtonItem10
        '
        Me.ButtonItem10.BeginGroup = True
        Me.ButtonItem10.Image = CType(resources.GetObject("ButtonItem10.Image"), System.Drawing.Image)
        Me.ButtonItem10.Name = "ButtonItem10"
        Me.ButtonItem10.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem10.Text = "&Refresh"
        Me.ButtonItem10.Visible = False
        '
        'SideNavPanel7
        '
        Me.SideNavPanel7.Controls.Add(Me.KryptonPanel16)
        Me.SideNavPanel7.Controls.Add(Me.KryptonPanel15)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge25)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge24)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge23)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge14)
        Me.SideNavPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel7.Location = New System.Drawing.Point(120, 31)
        Me.SideNavPanel7.Name = "SideNavPanel7"
        Me.SideNavPanel7.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel7.Size = New System.Drawing.Size(886, 646)
        Me.SideNavPanel7.TabIndex = 32
        Me.SideNavPanel7.Visible = False
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel16.Controls.Add(Me.Bar16)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge26)
        Me.KryptonPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel16.Location = New System.Drawing.Point(258, 13)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Size = New System.Drawing.Size(615, 620)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel16.TabIndex = 33
        '
        'Bar16
        '
        Me.Bar16.AccessibleDescription = "Bar16 (Bar16)"
        Me.Bar16.AccessibleName = "Bar16"
        Me.Bar16.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar16.AntiAlias = True
        Me.Bar16.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar16.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar16.IsMaximized = False
        Me.Bar16.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem10})
        Me.Bar16.Location = New System.Drawing.Point(1, 0)
        Me.Bar16.Name = "Bar16"
        Me.Bar16.PaddingBottom = 3
        Me.Bar16.PaddingLeft = 3
        Me.Bar16.PaddingRight = 3
        Me.Bar16.PaddingTop = 3
        Me.Bar16.RoundCorners = False
        Me.Bar16.Size = New System.Drawing.Size(614, 24)
        Me.Bar16.Stretch = True
        Me.Bar16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar16.TabIndex = 1
        Me.Bar16.TabStop = False
        Me.Bar16.Text = "Bar16"
        '
        'LabelItem10
        '
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.Text = "Report Sample"
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'KryptonPanel15
        '
        Me.KryptonPanel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel15.Controls.Add(Me.tvReports)
        Me.KryptonPanel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel15.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel15.Location = New System.Drawing.Point(13, 13)
        Me.KryptonPanel15.Name = "KryptonPanel15"
        Me.KryptonPanel15.Size = New System.Drawing.Size(245, 620)
        Me.KryptonPanel15.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel15.TabIndex = 32
        '
        'tvReports
        '
        Me.tvReports.BackColor = System.Drawing.Color.White
        Me.tvReports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReports.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvReports.ForeColor = System.Drawing.Color.Black
        Me.tvReports.HideSelection = False
        Me.tvReports.ImageIndex = 0
        Me.tvReports.ImageList = Me.imageList1
        Me.tvReports.Location = New System.Drawing.Point(0, 0)
        Me.tvReports.Name = "tvReports"
        TreeNode6.ImageIndex = 5
        TreeNode6.Name = "Node17"
        TreeNode6.SelectedImageIndex = 5
        TreeNode6.Text = "Creditors Transaction History"
        TreeNode7.ImageIndex = 5
        TreeNode7.Name = "Node18"
        TreeNode7.SelectedImageIndex = 5
        TreeNode7.Text = "Today's Creditors Payments"
        TreeNode8.ImageIndex = 5
        TreeNode8.Name = "Node19"
        TreeNode8.SelectedImageIndex = 5
        TreeNode8.Text = "Amounts Due to Creditors"
        TreeNode9.ImageIndex = 5
        TreeNode9.Name = "Node20"
        TreeNode9.SelectedImageIndex = 5
        TreeNode9.Text = "Orders"
        TreeNode10.ImageIndex = 10
        TreeNode10.Name = "Node2"
        TreeNode10.SelectedImageIndex = 10
        TreeNode10.Text = "Vendors/Creditors"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode10})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(245, 620)
        Me.tvReports.TabIndex = 34
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "Folder.ico")
        Me.imageList1.Images.SetKeyName(1, "calendar.png")
        Me.imageList1.Images.SetKeyName(2, "user2.png")
        Me.imageList1.Images.SetKeyName(3, "dude1.png")
        Me.imageList1.Images.SetKeyName(4, "businessman2.png")
        Me.imageList1.Images.SetKeyName(5, "TableSmall.png")
        Me.imageList1.Images.SetKeyName(6, "Delivery.png")
        Me.imageList1.Images.SetKeyName(7, "Money.png")
        Me.imageList1.Images.SetKeyName(8, "49.png")
        Me.imageList1.Images.SetKeyName(9, "07.png")
        Me.imageList1.Images.SetKeyName(10, "10.png")
        Me.imageList1.Images.SetKeyName(11, "25.png")
        Me.imageList1.Images.SetKeyName(12, "133.png")
        Me.imageList1.Images.SetKeyName(13, "Search.bmp")
        Me.imageList1.Images.SetKeyName(14, "420.png")
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(873, 13)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(12, 13)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(12, 633)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(862, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(12, 12)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(862, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'SideNavPanel3
        '
        Me.SideNavPanel3.Controls.Add(Me.panelEx1)
        Me.SideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel3.Location = New System.Drawing.Point(109, 31)
        Me.SideNavPanel3.Name = "SideNavPanel3"
        Me.SideNavPanel3.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel3.Size = New System.Drawing.Size(897, 646)
        Me.SideNavPanel3.TabIndex = 10
        Me.SideNavPanel3.Visible = False
        '
        'panelEx1
        '
        Me.panelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.panelEx1.Controls.Add(Me.recentDocsItemPane)
        Me.panelEx1.Controls.Add(Me.labelX1)
        Me.panelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.panelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelEx1.Location = New System.Drawing.Point(12, 12)
        Me.panelEx1.Name = "panelEx1"
        Me.panelEx1.Padding = New System.Windows.Forms.Padding(12)
        Me.panelEx1.Size = New System.Drawing.Size(458, 622)
        Me.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.panelEx1.Style.GradientAngle = 90
        Me.panelEx1.TabIndex = 12
        Me.panelEx1.Text = "panelEx1"
        '
        'recentDocsItemPane
        '
        Me.recentDocsItemPane.AutoScroll = True
        '
        '
        '
        Me.recentDocsItemPane.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.recentDocsItemPane.ContainerControlProcessDialogKey = True
        Me.recentDocsItemPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.recentDocsItemPane.DragDropSupport = True
        Me.recentDocsItemPane.ForeColor = System.Drawing.Color.Black
        Me.recentDocsItemPane.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnOrganisation})
        Me.recentDocsItemPane.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.recentDocsItemPane.Location = New System.Drawing.Point(12, 35)
        Me.recentDocsItemPane.Name = "recentDocsItemPane"
        Me.recentDocsItemPane.Size = New System.Drawing.Size(434, 575)
        Me.recentDocsItemPane.TabIndex = 1
        '
        'btnOrganisation
        '
        Me.btnOrganisation.BeginGroup = True
        Me.btnOrganisation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOrganisation.CommandParameter = ""
        Me.btnOrganisation.ForeColor = System.Drawing.Color.Black
        Me.btnOrganisation.Image = CType(resources.GetObject("btnOrganisation.Image"), System.Drawing.Image)
        Me.btnOrganisation.Name = "btnOrganisation"
        Me.btnOrganisation.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnOrganisation.Symbol = ""
        Me.btnOrganisation.Text = "Organization Settings<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">View and edit organisation paramet" & _
    "ers applicable to the environment</font>"
        '
        'labelX1
        '
        '
        '
        '
        Me.labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash
        Me.labelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gray
        Me.labelX1.BackgroundStyle.BorderBottomWidth = 1
        Me.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX1.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelX1.ForeColor = System.Drawing.Color.Black
        Me.labelX1.Location = New System.Drawing.Point(12, 12)
        Me.labelX1.Name = "labelX1"
        Me.labelX1.Size = New System.Drawing.Size(434, 23)
        Me.labelX1.TabIndex = 0
        Me.labelX1.Text = "General Settings"
        '
        'SideNavItem1
        '
        Me.SideNavItem1.IsSystemMenu = True
        Me.SideNavItem1.Name = "SideNavItem1"
        Me.SideNavItem1.Symbol = ""
        Me.SideNavItem1.Text = "Menu"
        '
        'Separator1
        '
        Me.Separator1.FixedSize = New System.Drawing.Size(3, 1)
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Padding.Bottom = 2
        Me.Separator1.Padding.Left = 6
        Me.Separator1.Padding.Right = 6
        Me.Separator1.Padding.Top = 2
        Me.Separator1.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical
        '
        'SideNavItem4
        '
        Me.SideNavItem4.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.SideNavItem4.Name = "SideNavItem4"
        Me.SideNavItem4.Panel = Me.SideNavPanel3
        Me.SideNavItem4.Symbol = ""
        Me.SideNavItem4.Text = "Settings"
        '
        'SideNavItem6
        '
        Me.SideNavItem6.Name = "SideNavItem6"
        Me.SideNavItem6.Panel = Me.SideNavPanel5
        Me.SideNavItem6.Symbol = "59376"
        Me.SideNavItem6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem6.Text = "Suppliers"
        '
        'SideNavItem2
        '
        Me.SideNavItem2.Name = "SideNavItem2"
        Me.SideNavItem2.Panel = Me.SideNavPanel1
        Me.SideNavItem2.Symbol = ""
        Me.SideNavItem2.Text = "Transactions"
        '
        'SideNavItem3
        '
        Me.SideNavItem3.Checked = True
        Me.SideNavItem3.Name = "SideNavItem3"
        Me.SideNavItem3.Panel = Me.SideNavPanel2
        Me.SideNavItem3.Symbol = ""
        Me.SideNavItem3.Text = "Goods Receipt"
        '
        'SideNavItem8
        '
        Me.SideNavItem8.Name = "SideNavItem8"
        Me.SideNavItem8.Panel = Me.SideNavPanel7
        Me.SideNavItem8.Symbol = "57373"
        Me.SideNavItem8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem8.Text = "Reports"
        '
        'imageList2
        '
        Me.imageList2.ImageStream = CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList2.Images.SetKeyName(0, "Comments_Small.png")
        Me.imageList2.Images.SetKeyName(1, "AddNewSource_Small.png")
        Me.imageList2.Images.SetKeyName(2, "Folder.ico")
        Me.imageList2.Images.SetKeyName(3, "user2.png")
        Me.imageList2.Images.SetKeyName(4, "calendar.png")
        Me.imageList2.Images.SetKeyName(5, "dude1.png")
        Me.imageList2.Images.SetKeyName(6, "businessman2.png")
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
        'pdOrders
        '
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
        'frmPurchasingMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPurchasingMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Business Light Edge Purchasing"
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl2.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.SuperTabControlPanel5.PerformLayout()
        CType(Me.dGridCreditNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel4.PerformLayout()
        CType(Me.dGridQuotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.SuperTabControlPanel3.PerformLayout()
        CType(Me.dGridPurchaseOrders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        CType(Me.cboSearchOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel17.ResumeLayout(False)
        Me.KryptonPanel17.PerformLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        Me.KryptonPanel19.PerformLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.dGridSupplierInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel5.ResumeLayout(False)
        Me.SideNavPanel5.PerformLayout()
        CType(Me.dGridCreditors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel81.ResumeLayout(False)
        Me.KryptonPanel81.PerformLayout()
        CType(Me.cboCreditorSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel2.ResumeLayout(False)
        Me.SideNavPanel2.PerformLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.dGridOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dGridOrdersList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel7.ResumeLayout(False)
        Me.SideNavPanel7.PerformLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        Me.KryptonPanel16.PerformLayout()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel15.ResumeLayout(False)
        Me.SideNavPanel3.ResumeLayout(False)
        Me.panelEx1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents StyleManager2 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel5 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel81 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge82 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel67 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCreditorSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtCreditorSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar14 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewSupplier As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditCreditor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteSupplier As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNotZero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportSuppliers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAccountSettlement As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCreditors As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SuperTabControl2 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents Totals As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalOrders As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDiscounts As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTaxes As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeliveryNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshOrders As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dGridCreditNotes As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Bar8 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem13 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem14 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem15 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem16 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem17 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem18 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem19 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnViewFilteredCreditNotes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCreditNotes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dGridQuotes As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblQuoteTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblQuoteTaxes As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem11 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblQuoteDiscounts As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFilterQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSeletedRowQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintQuoteList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshQuotes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavPanel7 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Bar16 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel15 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavPanel3 As DevComponents.DotNetBar.Controls.SideNavPanel
    Private WithEvents panelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents recentDocsItemPane As DevComponents.DotNetBar.ItemPanel
    Private WithEvents btnOrganisation As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem4 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem6 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem8 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents dGridCreditors As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents tvReports As System.Windows.Forms.TreeView
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem3 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewGoodsIn As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditGoodsIn As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteGoodsIn As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintReceivedOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPostReceivedOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpEndToOrders As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartFromOrders As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnGoOrders As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGridOrdersList As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents lblGrandTotalOrders As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents lblUnprocessedTotalOrders As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents lblProcessedTotalOrders As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGridOrderDetails As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents lblBatchCostTotalOrders As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents lblEntriesCountOrders As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAdjustPrice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar9 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewSupplierInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditSupplierInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteSupplierInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelectedSupplierRow As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSupplierInvoiceList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSupplierPayments As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshSupplier As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndSupplierInvoice As DateTimePicker
    Friend WithEvents dpStartSupplierInvoice As DateTimePicker
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnRunInvoice As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Bar10 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem12 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem20 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem21 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem22 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem23 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem24 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridSupplierInvoices As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents dGridPurchaseOrders As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpStartFrom As DateTimePicker
    Friend WithEvents dpEndTo As DateTimePicker
    Friend WithEvents btnProcess As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnSummaryOrders As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSelectedOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pdOrders As Printing.PrintDocument
    Friend WithEvents ppd As PrintPreviewDialog
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboSearchOptions As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel17 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
End Class
