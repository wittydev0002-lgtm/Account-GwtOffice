<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceMain
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
        Dim SuperTabColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceMain))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Balances", 5, 5)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A/R Aging Analysis", 5, 5)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Transaction History", 5, 5)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Open Invoiced By Due Date", 5, 5)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Most Profitable Customers", 5, 5)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Statements", 5, 5)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Balances At Specified Date", 5, 5)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customers and Receivables", 9, 9, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7})
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonPanel19 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SuperTabControl2 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grd = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndInvoice = New System.Windows.Forms.DateTimePicker()
        Me.dpStartInvoice = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnRunInvoice = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.Totals = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotal = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.lblDiscounts = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTaxes = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNewInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelected = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSummary = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAccountSettlement = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeliveryNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridCreditNotes = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndCreditNote = New System.Windows.Forms.DateTimePicker()
        Me.dpStartCreditNote = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnRunCreditNote = New ComponentFactory.Krypton.Toolkit.KryptonButton()
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
        Me.btnPrintCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCreditNotes = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridProformas = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar9 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem12 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalProforma = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem21 = New DevComponents.DotNetBar.LabelItem()
        Me.lblDiscountsProforma = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem23 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTaxesProforma = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel17 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboUserProforma = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndToProforma = New System.Windows.Forms.DateTimePicker()
        Me.dpStartFromProforma = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnGoProforma = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNewProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelectedProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSummaryProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshProforma = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridQuotes = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndQuote = New System.Windows.Forms.DateTimePicker()
        Me.dpStartQuote = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnRunQuote = New ComponentFactory.Krypton.Toolkit.KryptonButton()
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
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSeletedRowQuote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintQuoteList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshQuotes = New DevComponents.DotNetBar.ButtonItem()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel5 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridCustomers = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNewCustomerQuote = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewInvoice = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewCashsale = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewCreditNote = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReceivePayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintCustomerStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEmailCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuActivateCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeactivateCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkActiveSearch = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnFind = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel81 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge82 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel67 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboCustomerSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar14 = New DevComponents.DotNetBar.Bar()
        Me.btnNewCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnNotZero = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.SideNavPanel3 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.panelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.recentDocsItemPane = New DevComponents.DotNetBar.ItemPanel()
        Me.btnOrganisation = New DevComponents.DotNetBar.ButtonItem()
        Me.labelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SideNavPanel7 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.pnlPreview = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridPreview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.labelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dGridTransactions = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.integerInput1 = New DevComponents.Editors.IntegerInput()
        Me.labelX4 = New DevComponents.DotNetBar.LabelX()
        Me.btnPrintPreview = New DevComponents.DotNetBar.ButtonX()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar16 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem4 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem6 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.btnPayments = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem8 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.StyleManager2 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl2.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.dGridCreditNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dGridProformas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel17.SuspendLayout()
        CType(Me.cboUserProforma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.dGridQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel5.SuspendLayout()
        CType(Me.dGridCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm1.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel81.SuspendLayout()
        CType(Me.cboCustomerSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel3.SuspendLayout()
        Me.panelEx1.SuspendLayout()
        Me.SideNavPanel7.SuspendLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        CType(Me.pnlPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreview.SuspendLayout()
        CType(Me.dGridPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.integerInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.SideNav1)
        Me.KryptonPanel.Controls.Add(Me.Bar3)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(1007, 698)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 0
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel5)
        Me.SideNav1.Controls.Add(Me.SideNavPanel3)
        Me.SideNav1.Controls.Add(Me.SideNavPanel7)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem4, Me.SideNavItem2, Me.SideNavItem6, Me.btnPayments, Me.SideNavItem8})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Margin = New System.Windows.Forms.Padding(0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1007, 678)
        Me.SideNav1.TabIndex = 10
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel19)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(102, 31)
        Me.SideNavPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Size = New System.Drawing.Size(904, 646)
        Me.SideNavPanel1.TabIndex = 2
        '
        'KryptonPanel19
        '
        Me.KryptonPanel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel19.Controls.Add(Me.SuperTabControl2)
        Me.KryptonPanel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel19.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel19.Location = New System.Drawing.Point(0, 1)
        Me.KryptonPanel19.Name = "KryptonPanel19"
        Me.KryptonPanel19.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.KryptonPanel19.Size = New System.Drawing.Size(904, 645)
        Me.KryptonPanel19.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel19.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel19.TabIndex = 154
        '
        'SuperTabControl2
        '
        Me.SuperTabControl2.BackColor = System.Drawing.Color.White
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
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl2.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl2.HorizontalText = False
        Me.SuperTabControl2.Location = New System.Drawing.Point(0, 12)
        Me.SuperTabControl2.Name = "SuperTabControl2"
        Me.SuperTabControl2.ReorderTabsEnabled = True
        Me.SuperTabControl2.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl2.SelectedTabIndex = 0
        Me.SuperTabControl2.Size = New System.Drawing.Size(904, 633)
        Me.SuperTabControl2.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl2.TabHorizontalSpacing = 6
        Me.SuperTabControl2.TabIndex = 151
        Me.SuperTabControl2.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem3, Me.SuperTabItem4, Me.SuperTabItem1, Me.SuperTabItem5})
        SuperTabLinearGradientColorTable1.Colors = New System.Drawing.Color() {System.Drawing.Color.Teal, System.Drawing.Color.Teal}
        SuperTabColorTable1.Background = SuperTabLinearGradientColorTable1
        Me.SuperTabControl2.TabStripColor = SuperTabColorTable1
        Me.SuperTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl2.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.grd)
        Me.SuperTabControlPanel3.Controls.Add(Me.KryptonPanel4)
        Me.SuperTabControlPanel3.Controls.Add(Me.Bar4)
        Me.SuperTabControlPanel3.Controls.Add(Me.KryptonBorderEdge5)
        Me.SuperTabControlPanel3.Controls.Add(Me.Bar1)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Padding = New System.Windows.Forms.Padding(3)
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(904, 608)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column6, Me.Column3, Me.Column4, Me.Column5, Me.Column7})
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(3, 99)
        Me.grd.Name = "grd"
        Me.grd.ReadOnly = True
        Me.grd.RowHeadersWidth = 25
        Me.grd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grd.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grd.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grd.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd.Size = New System.Drawing.Size(898, 486)
        Me.grd.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.grd.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.grd.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grd.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.TabIndex = 157
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Doc. #"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 75
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column6.HeaderText = "Date"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 63
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Customer Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 129
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column4.HeaderText = "Invoice Value"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 113
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column5.HeaderText = "Discounts"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 91
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column7.HeaderText = "Tax"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 56
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.AutoScroll = True
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel4.Controls.Add(Me.dpEndInvoice)
        Me.KryptonPanel4.Controls.Add(Me.dpStartInvoice)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel4.Controls.Add(Me.btnRunInvoice)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(3, 33)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(898, 66)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel4.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel4.TabIndex = 156
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 65)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(208, 22)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(57, 21)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 151
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(57, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Date to"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'dpEndInvoice
        '
        Me.dpEndInvoice.BackColor = System.Drawing.Color.White
        Me.dpEndInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpEndInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndInvoice.Location = New System.Drawing.Point(267, 23)
        Me.dpEndInvoice.Name = "dpEndInvoice"
        Me.dpEndInvoice.Size = New System.Drawing.Size(95, 20)
        Me.dpEndInvoice.TabIndex = 5
        '
        'dpStartInvoice
        '
        Me.dpStartInvoice.BackColor = System.Drawing.Color.White
        Me.dpStartInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpStartInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartInvoice.Location = New System.Drawing.Point(99, 23)
        Me.dpStartInvoice.Name = "dpStartInvoice"
        Me.dpStartInvoice.Size = New System.Drawing.Size(103, 20)
        Me.dpStartInvoice.TabIndex = 10
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(20, 22)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 150
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Date from"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'btnRunInvoice
        '
        Me.btnRunInvoice.AutoSize = True
        Me.btnRunInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRunInvoice.BackColor = System.Drawing.Color.White
        Me.btnRunInvoice.ForeColor = System.Drawing.Color.Black
        Me.btnRunInvoice.Location = New System.Drawing.Point(368, 22)
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
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Totals, Me.LabelItem4, Me.lblTotal, Me.LabelItem6, Me.lblDiscounts, Me.LabelItem8, Me.lblTaxes})
        Me.Bar4.Location = New System.Drawing.Point(3, 585)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(898, 20)
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
        Me.LabelItem4.Text = "Invoice Totals"
        '
        'lblTotal
        '
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.PaddingLeft = 3
        Me.lblTotal.PaddingRight = 3
        Me.lblTotal.Text = "0.00"
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
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(3, 32)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(898, 1)
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
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewInvoice, Me.btnEditInvoice, Me.btnDeleteInvoice, Me.btnPrint, Me.btnAccountSettlement, Me.btnDeliveryNote, Me.btnRefreshInvoice})
        Me.Bar1.Location = New System.Drawing.Point(3, 3)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(898, 29)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 151
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNewInvoice
        '
        Me.btnNewInvoice.Image = CType(resources.GetObject("btnNewInvoice.Image"), System.Drawing.Image)
        Me.btnNewInvoice.Name = "btnNewInvoice"
        Me.btnNewInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewInvoice.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewInvoice.Text = "New"
        '
        'btnEditInvoice
        '
        Me.btnEditInvoice.Image = CType(resources.GetObject("btnEditInvoice.Image"), System.Drawing.Image)
        Me.btnEditInvoice.Name = "btnEditInvoice"
        Me.btnEditInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditInvoice.Text = "Edit"
        '
        'btnDeleteInvoice
        '
        Me.btnDeleteInvoice.BeginGroup = True
        Me.btnDeleteInvoice.Image = CType(resources.GetObject("btnDeleteInvoice.Image"), System.Drawing.Image)
        Me.btnDeleteInvoice.Name = "btnDeleteInvoice"
        Me.btnDeleteInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelected, Me.btnPrintSummary})
        Me.btnPrint.Text = "Print"
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BeginGroup = True
        Me.btnPrintSelected.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelected.SymbolSize = 16.0!
        Me.btnPrintSelected.Text = "Print Selected Row"
        '
        'btnPrintSummary
        '
        Me.btnPrintSummary.BeginGroup = True
        Me.btnPrintSummary.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSummary.Name = "btnPrintSummary"
        Me.btnPrintSummary.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSummary.SymbolSize = 16.0!
        Me.btnPrintSummary.Text = "Print Entire Sheet"
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
        'btnDeliveryNote
        '
        Me.btnDeliveryNote.BeginGroup = True
        Me.btnDeliveryNote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDeliveryNote.Image = CType(resources.GetObject("btnDeliveryNote.Image"), System.Drawing.Image)
        Me.btnDeliveryNote.Name = "btnDeliveryNote"
        Me.btnDeliveryNote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeliveryNote.Text = "Delivery Note"
        '
        'btnRefreshInvoice
        '
        Me.btnRefreshInvoice.BeginGroup = True
        Me.btnRefreshInvoice.Image = CType(resources.GetObject("btnRefreshInvoice.Image"), System.Drawing.Image)
        Me.btnRefreshInvoice.Name = "btnRefreshInvoice"
        Me.btnRefreshInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshInvoice.Text = "Refresh"
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        Me.SuperTabItem3.Text = "Invoices"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.dGridCreditNotes)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonPanel7)
        Me.SuperTabControlPanel5.Controls.Add(Me.Bar8)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge7)
        Me.SuperTabControlPanel5.Controls.Add(Me.Bar7)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Padding = New System.Windows.Forms.Padding(3)
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(904, 608)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem5
        '
        'dGridCreditNotes
        '
        Me.dGridCreditNotes.AllowUserToAddRows = False
        Me.dGridCreditNotes.AllowUserToDeleteRows = False
        Me.dGridCreditNotes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridCreditNotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridCreditNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn15})
        Me.dGridCreditNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCreditNotes.Location = New System.Drawing.Point(3, 99)
        Me.dGridCreditNotes.Name = "dGridCreditNotes"
        Me.dGridCreditNotes.ReadOnly = True
        Me.dGridCreditNotes.RowHeadersWidth = 25
        Me.dGridCreditNotes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridCreditNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCreditNotes.Size = New System.Drawing.Size(898, 486)
        Me.dGridCreditNotes.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridCreditNotes.StateCommon.Background.Color2 = System.Drawing.Color.Transparent
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
        Me.dGridCreditNotes.TabIndex = 159
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn15.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 80
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.AutoScroll = True
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel7.Controls.Add(Me.dpEndCreditNote)
        Me.KryptonPanel7.Controls.Add(Me.dpStartCreditNote)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel11)
        Me.KryptonPanel7.Controls.Add(Me.btnRunCreditNote)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(3, 33)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(898, 66)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel7.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel7.TabIndex = 158
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 65)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(208, 22)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(57, 21)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 151
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.White
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(57, 20)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Date to"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'dpEndCreditNote
        '
        Me.dpEndCreditNote.BackColor = System.Drawing.Color.White
        Me.dpEndCreditNote.ForeColor = System.Drawing.Color.Black
        Me.dpEndCreditNote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndCreditNote.Location = New System.Drawing.Point(267, 23)
        Me.dpEndCreditNote.Name = "dpEndCreditNote"
        Me.dpEndCreditNote.Size = New System.Drawing.Size(95, 20)
        Me.dpEndCreditNote.TabIndex = 5
        '
        'dpStartCreditNote
        '
        Me.dpStartCreditNote.BackColor = System.Drawing.Color.White
        Me.dpStartCreditNote.ForeColor = System.Drawing.Color.Black
        Me.dpStartCreditNote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartCreditNote.Location = New System.Drawing.Point(99, 23)
        Me.dpStartCreditNote.Name = "dpStartCreditNote"
        Me.dpStartCreditNote.Size = New System.Drawing.Size(103, 20)
        Me.dpStartCreditNote.TabIndex = 10
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(20, 22)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 150
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.White
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Date from"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'btnRunCreditNote
        '
        Me.btnRunCreditNote.AutoSize = True
        Me.btnRunCreditNote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRunCreditNote.BackColor = System.Drawing.Color.White
        Me.btnRunCreditNote.ForeColor = System.Drawing.Color.Black
        Me.btnRunCreditNote.Location = New System.Drawing.Point(368, 22)
        Me.btnRunCreditNote.Name = "btnRunCreditNote"
        Me.btnRunCreditNote.Size = New System.Drawing.Size(58, 22)
        Me.btnRunCreditNote.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnRunCreditNote.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnRunCreditNote.StateCommon.Back.ColorAngle = 100.0!
        Me.btnRunCreditNote.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnRunCreditNote.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnRunCreditNote.StateCommon.Border.Rounding = 0
        Me.btnRunCreditNote.TabIndex = 139
        Me.btnRunCreditNote.Values.Image = CType(resources.GetObject("btnRunCreditNote.Values.Image"), System.Drawing.Image)
        Me.btnRunCreditNote.Values.Text = "Run ..."
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
        Me.Bar8.Location = New System.Drawing.Point(3, 585)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.RoundCorners = False
        Me.Bar8.Size = New System.Drawing.Size(898, 20)
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
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(3, 32)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(898, 1)
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
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewCreditNote, Me.btnEditCreditNote, Me.btnPrintCreditNote, Me.btnRefreshCreditNotes})
        Me.Bar7.Location = New System.Drawing.Point(3, 3)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.PaddingBottom = 3
        Me.Bar7.PaddingLeft = 3
        Me.Bar7.PaddingRight = 3
        Me.Bar7.PaddingTop = 3
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(898, 29)
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
        Me.btnEditCreditNote.Visible = False
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
        Me.SuperTabItem5.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Coral
        Me.SuperTabItem5.Text = "Credit Notes"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dGridProformas)
        Me.SuperTabControlPanel1.Controls.Add(Me.Bar9)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonPanel12)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge19)
        Me.SuperTabControlPanel1.Controls.Add(Me.Bar2)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(904, 608)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'dGridProformas
        '
        Me.dGridProformas.AllowUserToAddRows = False
        Me.dGridProformas.AllowUserToDeleteRows = False
        Me.dGridProformas.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridProformas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dGridProformas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22})
        Me.dGridProformas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridProformas.Location = New System.Drawing.Point(3, 99)
        Me.dGridProformas.Name = "dGridProformas"
        Me.dGridProformas.ReadOnly = True
        Me.dGridProformas.RowHeadersWidth = 25
        Me.dGridProformas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridProformas.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridProformas.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridProformas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridProformas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridProformas.Size = New System.Drawing.Size(898, 486)
        Me.dGridProformas.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridProformas.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridProformas.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dGridProformas.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridProformas.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridProformas.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridProformas.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridProformas.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridProformas.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridProformas.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridProformas.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridProformas.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridProformas.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridProformas.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridProformas.TabIndex = 160
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn17.HeaderText = "Doc. #"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 75
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn18.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 63
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn19.HeaderText = "Customer Name"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 129
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn20.HeaderText = "Invoice Value"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 113
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        Me.DataGridViewTextBoxColumn21.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn21.HeaderText = "Discounts"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 91
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        Me.DataGridViewTextBoxColumn22.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn22.HeaderText = "Tax"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 56
        '
        'Bar9
        '
        Me.Bar9.AntiAlias = True
        Me.Bar9.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar9.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar9.IsMaximized = False
        Me.Bar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem12, Me.lblTotalProforma, Me.LabelItem21, Me.lblDiscountsProforma, Me.LabelItem23, Me.lblTaxesProforma})
        Me.Bar9.Location = New System.Drawing.Point(3, 585)
        Me.Bar9.Name = "Bar9"
        Me.Bar9.RoundCorners = False
        Me.Bar9.Size = New System.Drawing.Size(898, 20)
        Me.Bar9.Stretch = True
        Me.Bar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar9.TabIndex = 159
        Me.Bar9.TabStop = False
        Me.Bar9.Text = "Bar9"
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
        Me.LabelItem12.Text = "Proforma Totals"
        '
        'lblTotalProforma
        '
        Me.lblTotalProforma.Name = "lblTotalProforma"
        Me.lblTotalProforma.PaddingLeft = 3
        Me.lblTotalProforma.PaddingRight = 3
        Me.lblTotalProforma.Text = "0.00"
        '
        'LabelItem21
        '
        Me.LabelItem21.Name = "LabelItem21"
        Me.LabelItem21.PaddingLeft = 3
        Me.LabelItem21.PaddingRight = 3
        Me.LabelItem21.Text = "Discounts"
        '
        'lblDiscountsProforma
        '
        Me.lblDiscountsProforma.Name = "lblDiscountsProforma"
        Me.lblDiscountsProforma.PaddingLeft = 3
        Me.lblDiscountsProforma.PaddingRight = 3
        Me.lblDiscountsProforma.Text = "0.00"
        '
        'LabelItem23
        '
        Me.LabelItem23.Name = "LabelItem23"
        Me.LabelItem23.PaddingLeft = 3
        Me.LabelItem23.PaddingRight = 3
        Me.LabelItem23.Text = "Taxes"
        '
        'lblTaxesProforma
        '
        Me.lblTaxesProforma.Name = "lblTaxesProforma"
        Me.lblTaxesProforma.PaddingLeft = 3
        Me.lblTaxesProforma.PaddingRight = 3
        Me.lblTaxesProforma.Text = "0.00"
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.AutoScroll = True
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonPanel17)
        Me.KryptonPanel12.Controls.Add(Me.cboUserProforma)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge20)
        Me.KryptonPanel12.Controls.Add(Me.KryptonPanel13)
        Me.KryptonPanel12.Controls.Add(Me.dpEndToProforma)
        Me.KryptonPanel12.Controls.Add(Me.dpStartFromProforma)
        Me.KryptonPanel12.Controls.Add(Me.KryptonPanel14)
        Me.KryptonPanel12.Controls.Add(Me.btnGoProforma)
        Me.KryptonPanel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(3, 33)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(898, 66)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel12.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel12.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel12.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel12.TabIndex = 158
        '
        'KryptonPanel17
        '
        Me.KryptonPanel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel17.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge27)
        Me.KryptonPanel17.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel17.Location = New System.Drawing.Point(368, 20)
        Me.KryptonPanel17.Name = "KryptonPanel17"
        Me.KryptonPanel17.Size = New System.Drawing.Size(67, 23)
        Me.KryptonPanel17.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel17.TabIndex = 153
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.BackColor = System.Drawing.Color.White
        Me.KryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(67, 22)
        Me.KryptonLabel10.TabIndex = 3
        Me.KryptonLabel10.Values.Text = "View for"
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge27.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(67, 1)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'cboUserProforma
        '
        Me.cboUserProforma.BackColor = System.Drawing.Color.White
        Me.cboUserProforma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserProforma.DropDownWidth = 138
        Me.cboUserProforma.ForeColor = System.Drawing.Color.Black
        Me.cboUserProforma.Location = New System.Drawing.Point(436, 22)
        Me.cboUserProforma.Name = "cboUserProforma"
        Me.cboUserProforma.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboUserProforma.Size = New System.Drawing.Size(190, 21)
        Me.cboUserProforma.TabIndex = 152
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(0, 65)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge21)
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(208, 22)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(57, 21)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 151
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.White
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(57, 20)
        Me.KryptonLabel8.TabIndex = 1
        Me.KryptonLabel8.Values.Text = "Date to"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'dpEndToProforma
        '
        Me.dpEndToProforma.BackColor = System.Drawing.Color.White
        Me.dpEndToProforma.ForeColor = System.Drawing.Color.Black
        Me.dpEndToProforma.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndToProforma.Location = New System.Drawing.Point(267, 23)
        Me.dpEndToProforma.Name = "dpEndToProforma"
        Me.dpEndToProforma.Size = New System.Drawing.Size(95, 20)
        Me.dpEndToProforma.TabIndex = 5
        '
        'dpStartFromProforma
        '
        Me.dpStartFromProforma.BackColor = System.Drawing.Color.White
        Me.dpStartFromProforma.ForeColor = System.Drawing.Color.Black
        Me.dpStartFromProforma.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFromProforma.Location = New System.Drawing.Point(99, 23)
        Me.dpStartFromProforma.Name = "dpStartFromProforma"
        Me.dpStartFromProforma.Size = New System.Drawing.Size(103, 20)
        Me.dpStartFromProforma.TabIndex = 10
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel14.Location = New System.Drawing.Point(20, 22)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 150
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.BackColor = System.Drawing.Color.White
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel9.TabIndex = 1
        Me.KryptonLabel9.Values.Text = "Date from"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'btnGoProforma
        '
        Me.btnGoProforma.AutoSize = True
        Me.btnGoProforma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGoProforma.BackColor = System.Drawing.Color.White
        Me.btnGoProforma.ForeColor = System.Drawing.Color.Black
        Me.btnGoProforma.Location = New System.Drawing.Point(632, 21)
        Me.btnGoProforma.Name = "btnGoProforma"
        Me.btnGoProforma.Size = New System.Drawing.Size(58, 22)
        Me.btnGoProforma.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnGoProforma.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnGoProforma.StateCommon.Back.ColorAngle = 100.0!
        Me.btnGoProforma.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnGoProforma.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnGoProforma.StateCommon.Border.Rounding = 0
        Me.btnGoProforma.TabIndex = 139
        Me.btnGoProforma.Values.Image = CType(resources.GetObject("btnGoProforma.Values.Image"), System.Drawing.Image)
        Me.btnGoProforma.Values.Text = "Run ..."
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(3, 32)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewProforma, Me.btnEditProforma, Me.btnDeleteProforma, Me.btnPrintProforma, Me.btnRefreshProforma})
        Me.Bar2.Location = New System.Drawing.Point(3, 3)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 3
        Me.Bar2.PaddingLeft = 3
        Me.Bar2.PaddingRight = 3
        Me.Bar2.PaddingTop = 3
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(898, 29)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 152
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnNewProforma
        '
        Me.btnNewProforma.Image = CType(resources.GetObject("btnNewProforma.Image"), System.Drawing.Image)
        Me.btnNewProforma.Name = "btnNewProforma"
        Me.btnNewProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewProforma.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewProforma.Text = "New"
        '
        'btnEditProforma
        '
        Me.btnEditProforma.Image = CType(resources.GetObject("btnEditProforma.Image"), System.Drawing.Image)
        Me.btnEditProforma.Name = "btnEditProforma"
        Me.btnEditProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditProforma.Text = "Edit"
        '
        'btnDeleteProforma
        '
        Me.btnDeleteProforma.BeginGroup = True
        Me.btnDeleteProforma.Image = CType(resources.GetObject("btnDeleteProforma.Image"), System.Drawing.Image)
        Me.btnDeleteProforma.Name = "btnDeleteProforma"
        Me.btnDeleteProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteProforma.Text = "Delete"
        '
        'btnPrintProforma
        '
        Me.btnPrintProforma.BeginGroup = True
        Me.btnPrintProforma.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintProforma.Image = CType(resources.GetObject("btnPrintProforma.Image"), System.Drawing.Image)
        Me.btnPrintProforma.Name = "btnPrintProforma"
        Me.btnPrintProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintProforma.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelectedProforma, Me.btnPrintSummaryProforma})
        Me.btnPrintProforma.Text = "Print"
        '
        'btnPrintSelectedProforma
        '
        Me.btnPrintSelectedProforma.BeginGroup = True
        Me.btnPrintSelectedProforma.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelectedProforma.Name = "btnPrintSelectedProforma"
        Me.btnPrintSelectedProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelectedProforma.SymbolSize = 16.0!
        Me.btnPrintSelectedProforma.Text = "Print Selected Row"
        '
        'btnPrintSummaryProforma
        '
        Me.btnPrintSummaryProforma.BeginGroup = True
        Me.btnPrintSummaryProforma.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSummaryProforma.Name = "btnPrintSummaryProforma"
        Me.btnPrintSummaryProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSummaryProforma.SymbolSize = 16.0!
        Me.btnPrintSummaryProforma.Text = "Print Entire Sheet"
        '
        'btnRefreshProforma
        '
        Me.btnRefreshProforma.BeginGroup = True
        Me.btnRefreshProforma.Image = CType(resources.GetObject("btnRefreshProforma.Image"), System.Drawing.Image)
        Me.btnRefreshProforma.Name = "btnRefreshProforma"
        Me.btnRefreshProforma.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshProforma.Text = "Refresh"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Pink
        Me.SuperTabItem1.Text = "Proforma Invoices"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.dGridQuotes)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonPanel1)
        Me.SuperTabControlPanel4.Controls.Add(Me.Bar6)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge6)
        Me.SuperTabControlPanel4.Controls.Add(Me.Bar5)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Padding = New System.Windows.Forms.Padding(3)
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(904, 608)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'dGridQuotes
        '
        Me.dGridQuotes.AllowUserToAddRows = False
        Me.dGridQuotes.AllowUserToDeleteRows = False
        Me.dGridQuotes.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridQuotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dGridQuotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.dGridQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridQuotes.Location = New System.Drawing.Point(3, 99)
        Me.dGridQuotes.Name = "dGridQuotes"
        Me.dGridQuotes.ReadOnly = True
        Me.dGridQuotes.RowHeadersWidth = 25
        Me.dGridQuotes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridQuotes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridQuotes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridQuotes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridQuotes.Size = New System.Drawing.Size(898, 486)
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
        Me.dGridQuotes.TabIndex = 158
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn8.HeaderText = "Quote Value"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 105
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "Discounts"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 91
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn10.HeaderText = "Tax"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 56
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.AutoScroll = True
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel1.Controls.Add(Me.dpEndQuote)
        Me.KryptonPanel1.Controls.Add(Me.dpStartQuote)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel1.Controls.Add(Me.btnRunQuote)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(3, 33)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(898, 66)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 157
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 65)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(208, 22)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(57, 21)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 151
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.White
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(57, 20)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Date to"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'dpEndQuote
        '
        Me.dpEndQuote.BackColor = System.Drawing.Color.White
        Me.dpEndQuote.ForeColor = System.Drawing.Color.Black
        Me.dpEndQuote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndQuote.Location = New System.Drawing.Point(267, 23)
        Me.dpEndQuote.Name = "dpEndQuote"
        Me.dpEndQuote.Size = New System.Drawing.Size(95, 20)
        Me.dpEndQuote.TabIndex = 5
        '
        'dpStartQuote
        '
        Me.dpStartQuote.BackColor = System.Drawing.Color.White
        Me.dpStartQuote.ForeColor = System.Drawing.Color.Black
        Me.dpStartQuote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartQuote.Location = New System.Drawing.Point(99, 23)
        Me.dpStartQuote.Name = "dpStartQuote"
        Me.dpStartQuote.Size = New System.Drawing.Size(103, 20)
        Me.dpStartQuote.TabIndex = 10
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(20, 22)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 150
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.White
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Date from"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'btnRunQuote
        '
        Me.btnRunQuote.AutoSize = True
        Me.btnRunQuote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRunQuote.BackColor = System.Drawing.Color.White
        Me.btnRunQuote.ForeColor = System.Drawing.Color.Black
        Me.btnRunQuote.Location = New System.Drawing.Point(368, 22)
        Me.btnRunQuote.Name = "btnRunQuote"
        Me.btnRunQuote.Size = New System.Drawing.Size(58, 22)
        Me.btnRunQuote.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnRunQuote.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnRunQuote.StateCommon.Back.ColorAngle = 100.0!
        Me.btnRunQuote.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnRunQuote.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnRunQuote.StateCommon.Border.Rounding = 0
        Me.btnRunQuote.TabIndex = 139
        Me.btnRunQuote.Values.Image = CType(resources.GetObject("btnRunQuote.Values.Image"), System.Drawing.Image)
        Me.btnRunQuote.Values.Text = "Run ..."
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
        Me.Bar6.Location = New System.Drawing.Point(3, 585)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.RoundCorners = False
        Me.Bar6.Size = New System.Drawing.Size(898, 20)
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
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(3, 32)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(898, 1)
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
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewQuote, Me.btnEditQuote, Me.btnDeleteQuote, Me.ButtonItem4, Me.btnRefreshQuotes})
        Me.Bar5.Location = New System.Drawing.Point(3, 3)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(898, 29)
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
        Me.SuperTabItem4.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        Me.SuperTabItem4.Text = "Quotations"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(904, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'SideNavPanel5
        '
        Me.SideNavPanel5.Controls.Add(Me.dGridCustomers)
        Me.SideNavPanel5.Controls.Add(Me.KryptonPanel8)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge9)
        Me.SideNavPanel5.Controls.Add(Me.Bar14)
        Me.SideNavPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel5.Location = New System.Drawing.Point(102, 31)
        Me.SideNavPanel5.Name = "SideNavPanel5"
        Me.SideNavPanel5.Size = New System.Drawing.Size(904, 646)
        Me.SideNavPanel5.TabIndex = 24
        Me.SideNavPanel5.Visible = False
        '
        'dGridCustomers
        '
        Me.dGridCustomers.AllowUserToAddRows = False
        Me.dGridCustomers.AllowUserToDeleteRows = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridCustomers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dGridCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.Column11})
        Me.dGridCustomers.ContextMenuStrip = Me.cm1
        Me.dGridCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCustomers.Location = New System.Drawing.Point(0, 83)
        Me.dGridCustomers.Name = "dGridCustomers"
        Me.dGridCustomers.ReadOnly = True
        Me.dGridCustomers.RowHeadersWidth = 25
        Me.dGridCustomers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridCustomers.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridCustomers.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridCustomers.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCustomers.Size = New System.Drawing.Size(904, 563)
        Me.dGridCustomers.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridCustomers.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridCustomers.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridCustomers.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCustomers.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCustomers.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridCustomers.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridCustomers.TabIndex = 20
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn27.HeaderText = "Account No."
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Width = 104
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn28.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Width = 69
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn29.HeaderText = "Telephone"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Width = 94
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn30.HeaderText = "Take On Date"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Width = 114
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn31.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn31.HeaderText = "Email Address"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Width = 117
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn32.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Width = 82
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column11.HeaderText = "Cellphone"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 93
        '
        'cm1
        '
        Me.cm1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cm1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.PrintToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.ToolStripMenuItem1, Me.mnuNewCustomerQuote, Me.mnuNewInvoice, Me.mnuNewCashsale, Me.mnuNewCreditNote, Me.mnuReceivePayment, Me.ToolStripMenuItem5, Me.mnuPrintCustomerStatement, Me.ToolStripMenuItem2, Me.mnuEmailCustomer, Me.ToolStripMenuItem3, Me.mnuActivateCustomer, Me.mnuDeactivateCustomer, Me.ToolStripMenuItem4, Me.mnuDeleteCustomer})
        Me.cm1.Name = "cm1"
        Me.cm1.Size = New System.Drawing.Size(251, 320)
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = CType(resources.GetObject("mnuOpen.Image"), System.Drawing.Image)
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(250, 22)
        Me.mnuOpen.Text = "Open Selected Customer"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(247, 6)
        '
        'mnuNewCustomerQuote
        '
        Me.mnuNewCustomerQuote.Name = "mnuNewCustomerQuote"
        Me.mnuNewCustomerQuote.Size = New System.Drawing.Size(250, 22)
        Me.mnuNewCustomerQuote.Text = "New &Quote for Customer"
        '
        'mnuNewInvoice
        '
        Me.mnuNewInvoice.Name = "mnuNewInvoice"
        Me.mnuNewInvoice.Size = New System.Drawing.Size(250, 22)
        Me.mnuNewInvoice.Text = "New &Invoice for Customer"
        '
        'mnuNewCashsale
        '
        Me.mnuNewCashsale.Name = "mnuNewCashsale"
        Me.mnuNewCashsale.Size = New System.Drawing.Size(250, 22)
        Me.mnuNewCashsale.Text = "New Cash &Sale for Customer"
        '
        'mnuNewCreditNote
        '
        Me.mnuNewCreditNote.Name = "mnuNewCreditNote"
        Me.mnuNewCreditNote.Size = New System.Drawing.Size(250, 22)
        Me.mnuNewCreditNote.Text = "New C&redit Note for Customer"
        '
        'mnuReceivePayment
        '
        Me.mnuReceivePayment.Name = "mnuReceivePayment"
        Me.mnuReceivePayment.Size = New System.Drawing.Size(250, 22)
        Me.mnuReceivePayment.Text = "Receive Payment From Customer"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(247, 6)
        '
        'mnuPrintCustomerStatement
        '
        Me.mnuPrintCustomerStatement.Image = CType(resources.GetObject("mnuPrintCustomerStatement.Image"), System.Drawing.Image)
        Me.mnuPrintCustomerStatement.Name = "mnuPrintCustomerStatement"
        Me.mnuPrintCustomerStatement.Size = New System.Drawing.Size(250, 22)
        Me.mnuPrintCustomerStatement.Text = "Print Customer Statement"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(247, 6)
        '
        'mnuEmailCustomer
        '
        Me.mnuEmailCustomer.Image = CType(resources.GetObject("mnuEmailCustomer.Image"), System.Drawing.Image)
        Me.mnuEmailCustomer.Name = "mnuEmailCustomer"
        Me.mnuEmailCustomer.Size = New System.Drawing.Size(250, 22)
        Me.mnuEmailCustomer.Text = "E-mail Customer"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(247, 6)
        '
        'mnuActivateCustomer
        '
        Me.mnuActivateCustomer.Name = "mnuActivateCustomer"
        Me.mnuActivateCustomer.Size = New System.Drawing.Size(250, 22)
        Me.mnuActivateCustomer.Text = "Make Active"
        '
        'mnuDeactivateCustomer
        '
        Me.mnuDeactivateCustomer.Name = "mnuDeactivateCustomer"
        Me.mnuDeactivateCustomer.Size = New System.Drawing.Size(250, 22)
        Me.mnuDeactivateCustomer.Text = "Make Inactive"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(247, 6)
        '
        'mnuDeleteCustomer
        '
        Me.mnuDeleteCustomer.Image = CType(resources.GetObject("mnuDeleteCustomer.Image"), System.Drawing.Image)
        Me.mnuDeleteCustomer.Name = "mnuDeleteCustomer"
        Me.mnuDeleteCustomer.Size = New System.Drawing.Size(250, 22)
        Me.mnuDeleteCustomer.Text = "&Delete"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.chkActiveSearch)
        Me.KryptonPanel8.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel81)
        Me.KryptonPanel8.Controls.Add(Me.cboCustomerSearchBy)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(0, 32)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(904, 51)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.TabIndex = 19
        '
        'chkActiveSearch
        '
        Me.chkActiveSearch.BackColor = System.Drawing.Color.White
        Me.chkActiveSearch.Checked = True
        Me.chkActiveSearch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActiveSearch.ForeColor = System.Drawing.Color.Black
        Me.chkActiveSearch.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkActiveSearch.Location = New System.Drawing.Point(568, 14)
        Me.chkActiveSearch.Name = "chkActiveSearch"
        Me.chkActiveSearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003
        Me.chkActiveSearch.Size = New System.Drawing.Size(95, 22)
        Me.chkActiveSearch.TabIndex = 165
        Me.chkActiveSearch.Text = "Active serach"
        Me.chkActiveSearch.Values.Text = "Active serach"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.White
        Me.txtSearchString.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnFind})
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(353, 12)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(205, 24)
        Me.txtSearchString.TabIndex = 164
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl
        Me.btnFind.Text = "Find"
        Me.btnFind.UniqueName = "3D638EA06E7B4A035DBF6E67BA01E8F6"
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
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
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
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
        Me.KryptonPanel81.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
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
        Me.KryptonBorderEdge82.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge82.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge82.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge82.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge82.Name = "KryptonBorderEdge82"
        Me.KryptonBorderEdge82.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge82.Text = "KryptonBorderEdge82"
        '
        'KryptonLabel67
        '
        Me.KryptonLabel67.BackColor = System.Drawing.Color.White
        Me.KryptonLabel67.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel67.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel67.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel67.Name = "KryptonLabel67"
        Me.KryptonLabel67.Size = New System.Drawing.Size(86, 20)
        Me.KryptonLabel67.TabIndex = 0
        Me.KryptonLabel67.Values.Text = "Search filter"
        '
        'cboCustomerSearchBy
        '
        Me.cboCustomerSearchBy.BackColor = System.Drawing.Color.White
        Me.cboCustomerSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerSearchBy.DropDownWidth = 152
        Me.cboCustomerSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboCustomerSearchBy.Items.AddRange(New Object() {"Account Number", "Account Name"})
        Me.cboCustomerSearchBy.Location = New System.Drawing.Point(96, 15)
        Me.cboCustomerSearchBy.Name = "cboCustomerSearchBy"
        Me.cboCustomerSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboCustomerSearchBy.Size = New System.Drawing.Size(152, 21)
        Me.cboCustomerSearchBy.TabIndex = 3
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(903, 0)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 50)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(904, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 31)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(904, 1)
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
        Me.Bar14.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewCustomer, Me.btnEditCustomer, Me.btnDeleteCustomer, Me.ButtonItem18, Me.btnExportCustomers, Me.btnRefreshCustomers})
        Me.Bar14.Location = New System.Drawing.Point(0, 0)
        Me.Bar14.Name = "Bar14"
        Me.Bar14.RoundCorners = False
        Me.Bar14.Size = New System.Drawing.Size(904, 31)
        Me.Bar14.Stretch = True
        Me.Bar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar14.TabIndex = 17
        Me.Bar14.TabStop = False
        Me.Bar14.Text = "Bar14"
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Image = CType(resources.GetObject("btnNewCustomer.Image"), System.Drawing.Image)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewCustomer.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewCustomer.Text = "New"
        '
        'btnEditCustomer
        '
        Me.btnEditCustomer.Image = CType(resources.GetObject("btnEditCustomer.Image"), System.Drawing.Image)
        Me.btnEditCustomer.Name = "btnEditCustomer"
        Me.btnEditCustomer.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditCustomer.Text = "Edit"
        '
        'btnDeleteCustomer
        '
        Me.btnDeleteCustomer.BeginGroup = True
        Me.btnDeleteCustomer.Image = CType(resources.GetObject("btnDeleteCustomer.Image"), System.Drawing.Image)
        Me.btnDeleteCustomer.Name = "btnDeleteCustomer"
        Me.btnDeleteCustomer.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteCustomer.Text = "Delete"
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
        'btnExportCustomers
        '
        Me.btnExportCustomers.BeginGroup = True
        Me.btnExportCustomers.Name = "btnExportCustomers"
        Me.btnExportCustomers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportCustomers.Symbol = ""
        Me.btnExportCustomers.Text = "Export"
        '
        'btnRefreshCustomers
        '
        Me.btnRefreshCustomers.BeginGroup = True
        Me.btnRefreshCustomers.Image = CType(resources.GetObject("btnRefreshCustomers.Image"), System.Drawing.Image)
        Me.btnRefreshCustomers.Name = "btnRefreshCustomers"
        Me.btnRefreshCustomers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshCustomers.Text = "&Refresh"
        '
        'SideNavPanel3
        '
        Me.SideNavPanel3.Controls.Add(Me.panelEx1)
        Me.SideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel3.Location = New System.Drawing.Point(102, 31)
        Me.SideNavPanel3.Name = "SideNavPanel3"
        Me.SideNavPanel3.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel3.Size = New System.Drawing.Size(904, 646)
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
        'SideNavPanel7
        '
        Me.SideNavPanel7.Controls.Add(Me.KryptonPanel16)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge25)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge24)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge23)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge14)
        Me.SideNavPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel7.Location = New System.Drawing.Point(102, 31)
        Me.SideNavPanel7.Name = "SideNavPanel7"
        Me.SideNavPanel7.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel7.Size = New System.Drawing.Size(904, 646)
        Me.SideNavPanel7.TabIndex = 32
        Me.SideNavPanel7.Visible = False
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel16.Controls.Add(Me.KryptonSplitContainer1)
        Me.KryptonPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel16.Location = New System.Drawing.Point(13, 13)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Size = New System.Drawing.Size(878, 620)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel16.TabIndex = 33
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.BackColor = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.ForeColor = System.Drawing.Color.Black
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.tvReports)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonBorderEdge26)
        Me.KryptonSplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color2 = System.Drawing.Color.White
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.pnlPreview)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonPanel18)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.Bar16)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge28)
        Me.KryptonSplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(878, 620)
        Me.KryptonSplitContainer1.SplitterDistance = 243
        Me.KryptonSplitContainer1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.TabIndex = 0
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
        TreeNode1.ImageIndex = 5
        TreeNode1.Name = "Node0"
        TreeNode1.SelectedImageIndex = 5
        TreeNode1.Text = "Customer Balances"
        TreeNode2.ImageIndex = 5
        TreeNode2.Name = "Node12"
        TreeNode2.SelectedImageIndex = 5
        TreeNode2.Text = "A/R Aging Analysis"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "Node13"
        TreeNode3.SelectedImageIndex = 5
        TreeNode3.Text = "Customer Transaction History"
        TreeNode4.ImageIndex = 5
        TreeNode4.Name = "Node14"
        TreeNode4.SelectedImageIndex = 5
        TreeNode4.Text = "Open Invoiced By Due Date"
        TreeNode5.ImageIndex = 5
        TreeNode5.Name = "Node15"
        TreeNode5.SelectedImageIndex = 5
        TreeNode5.Text = "Most Profitable Customers"
        TreeNode6.ImageIndex = 5
        TreeNode6.Name = "Node29"
        TreeNode6.SelectedImageIndex = 5
        TreeNode6.Text = "Customer Statements"
        TreeNode7.ImageIndex = 5
        TreeNode7.Name = "Node0"
        TreeNode7.SelectedImageIndex = 5
        TreeNode7.Text = "Customer Balances At Specified Date"
        TreeNode8.ImageIndex = 9
        TreeNode8.Name = "Node1"
        TreeNode8.SelectedImageIndex = 9
        TreeNode8.Text = "Customers and Receivables"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode8})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(242, 620)
        Me.tvReports.TabIndex = 35
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
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(242, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'pnlPreview
        '
        Me.pnlPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.pnlPreview.Controls.Add(Me.dGridPreview)
        Me.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreview.ForeColor = System.Drawing.Color.Black
        Me.pnlPreview.Location = New System.Drawing.Point(1, 24)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(629, 469)
        Me.pnlPreview.StateCommon.Color1 = System.Drawing.Color.White
        Me.pnlPreview.StateCommon.Color2 = System.Drawing.Color.White
        Me.pnlPreview.TabIndex = 44
        '
        'dGridPreview
        '
        Me.dGridPreview.AllowUserToAddRows = False
        Me.dGridPreview.AllowUserToDeleteRows = False
        Me.dGridPreview.AllowUserToResizeRows = False
        Me.dGridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridPreview.Location = New System.Drawing.Point(0, 0)
        Me.dGridPreview.Name = "dGridPreview"
        Me.dGridPreview.ReadOnly = True
        Me.dGridPreview.RowHeadersVisible = False
        Me.dGridPreview.RowHeadersWidth = 25
        Me.dGridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPreview.Size = New System.Drawing.Size(629, 469)
        Me.dGridPreview.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridPreview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPreview.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPreview.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPreview.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPreview.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPreview.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridPreview.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridPreview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPreview.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPreview.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridPreview.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridPreview.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPreview.TabIndex = 43
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.labelX5)
        Me.KryptonPanel18.Controls.Add(Me.dGridTransactions)
        Me.KryptonPanel18.Controls.Add(Me.integerInput1)
        Me.KryptonPanel18.Controls.Add(Me.labelX4)
        Me.KryptonPanel18.Controls.Add(Me.btnPrintPreview)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(1, 493)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(629, 127)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel18.TabIndex = 43
        '
        'labelX5
        '
        Me.labelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX5.ForeColor = System.Drawing.Color.Black
        Me.labelX5.Location = New System.Drawing.Point(133, 47)
        Me.labelX5.Name = "labelX5"
        Me.labelX5.Size = New System.Drawing.Size(48, 19)
        Me.labelX5.TabIndex = 8
        Me.labelX5.Text = "Copies:"
        '
        'dGridTransactions
        '
        Me.dGridTransactions.AllowUserToAddRows = False
        Me.dGridTransactions.AllowUserToDeleteRows = False
        Me.dGridTransactions.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.dGridTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column2, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn16, Me.Column13})
        Me.dGridTransactions.Location = New System.Drawing.Point(456, 14)
        Me.dGridTransactions.Name = "dGridTransactions"
        Me.dGridTransactions.ReadOnly = True
        Me.dGridTransactions.RowHeadersWidth = 25
        Me.dGridTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridTransactions.Size = New System.Drawing.Size(80, 56)
        Me.dGridTransactions.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridTransactions.StateCommon.Background.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.Background.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridTransactions.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.TabIndex = 35
        Me.dGridTransactions.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Ref #"
        Me.Column2.MinimumWidth = 100
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn3.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewTextBoxColumn4.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn16.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 80
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column13.HeaderText = "Type"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column13.Width = 44
        '
        'integerInput1
        '
        Me.integerInput1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.integerInput1.ForeColor = System.Drawing.Color.Black
        Me.integerInput1.Location = New System.Drawing.Point(188, 46)
        Me.integerInput1.Name = "integerInput1"
        Me.integerInput1.ShowUpDown = True
        Me.integerInput1.Size = New System.Drawing.Size(66, 20)
        Me.integerInput1.TabIndex = 7
        Me.integerInput1.Value = 1
        '
        'labelX4
        '
        Me.labelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.labelX4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash
        Me.labelX4.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gray
        Me.labelX4.BackgroundStyle.BorderBottomWidth = 1
        Me.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelX4.ForeColor = System.Drawing.Color.Black
        Me.labelX4.Location = New System.Drawing.Point(134, 9)
        Me.labelX4.Name = "labelX4"
        Me.labelX4.Size = New System.Drawing.Size(120, 23)
        Me.labelX4.TabIndex = 6
        Me.labelX4.Text = "Print"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrintPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPrintPreview.Location = New System.Drawing.Point(11, 14)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(109, 101)
        Me.btnPrintPreview.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrintPreview.TabIndex = 5
        Me.btnPrintPreview.Text = "Print"
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(629, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'Bar16
        '
        Me.Bar16.AccessibleDescription = "Bar16 (Bar16)"
        Me.Bar16.AccessibleName = "Bar16"
        Me.Bar16.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar16.AntiAlias = True
        Me.Bar16.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar16.Dock = System.Windows.Forms.DockStyle.Top
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
        Me.Bar16.Size = New System.Drawing.Size(629, 24)
        Me.Bar16.Stretch = True
        Me.Bar16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar16.TabIndex = 42
        Me.Bar16.TabStop = False
        Me.Bar16.Text = "Bar16"
        '
        'LabelItem10
        '
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.Text = "Report Sample"
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge28.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(891, 13)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(1, 620)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.White
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
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(12, 633)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(880, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(12, 12)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(880, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
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
        'SideNavItem2
        '
        Me.SideNavItem2.Checked = True
        Me.SideNavItem2.Name = "SideNavItem2"
        Me.SideNavItem2.Panel = Me.SideNavPanel1
        Me.SideNavItem2.Symbol = ""
        Me.SideNavItem2.Text = "Home"
        '
        'SideNavItem6
        '
        Me.SideNavItem6.Name = "SideNavItem6"
        Me.SideNavItem6.Panel = Me.SideNavPanel5
        Me.SideNavItem6.Symbol = "59376"
        Me.SideNavItem6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem6.Text = "Customers"
        '
        'btnPayments
        '
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Symbol = ""
        Me.btnPayments.Text = "Receipts"
        '
        'SideNavItem8
        '
        Me.SideNavItem8.Name = "SideNavItem8"
        Me.SideNavItem8.Panel = Me.SideNavPanel7
        Me.SideNavItem8.Symbol = "57373"
        Me.SideNavItem8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem8.Text = "Reports"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.ProgressBarItem1})
        Me.Bar3.Location = New System.Drawing.Point(0, 678)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(1007, 20)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 9
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Stretch = True
        Me.LabelItem3.Text = "Great Wits Light Invoicing 8.0"
        '
        'ProgressBarItem1
        '
        '
        '
        '
        Me.ProgressBarItem1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarItem1.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'StyleManager2
        '
        Me.StyleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager2.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
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
        'frmInvoiceMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoiceMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Great Wits Light Invoice"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl2.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.SuperTabControlPanel3.PerformLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.SuperTabControlPanel5.PerformLayout()
        CType(Me.dGridCreditNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.dGridProformas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel17.ResumeLayout(False)
        Me.KryptonPanel17.PerformLayout()
        CType(Me.cboUserProforma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel4.PerformLayout()
        CType(Me.dGridQuotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel5.ResumeLayout(False)
        Me.SideNavPanel5.PerformLayout()
        CType(Me.dGridCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm1.ResumeLayout(False)
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel81.ResumeLayout(False)
        Me.KryptonPanel81.PerformLayout()
        CType(Me.cboCustomerSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel3.ResumeLayout(False)
        Me.panelEx1.ResumeLayout(False)
        Me.SideNavPanel7.ResumeLayout(False)
        Me.SideNavPanel7.PerformLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel1.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.PerformLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        CType(Me.pnlPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.dGridPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.integerInput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Protected WithEvents StyleManager2 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel3 As DevComponents.DotNetBar.Controls.SideNavPanel
    Private WithEvents panelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents recentDocsItemPane As DevComponents.DotNetBar.ItemPanel
    Private WithEvents btnOrganisation As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SideNavPanel5 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents dGridCustomers As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel81 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge82 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel67 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCustomerSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar14 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnDeleteCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNotZero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SuperTabControl2 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents Totals As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDiscounts As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTaxes As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnEditInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelected As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSummary As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeliveryNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
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
    Friend WithEvents btnEditCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCreditNotes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
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
    Friend WithEvents btnEditQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSeletedRowQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintQuoteList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshQuotes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavPanel7 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem4 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem6 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem8 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents btnNewCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNewCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNewInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNewQuote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnRunInvoice As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndCreditNote As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartCreditNote As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnRunCreditNote As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndQuote As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartQuote As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnRunQuote As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents grd As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents dGridQuotes As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents dGridCreditNotes As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents btnAccountSettlement As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelectedProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSummaryProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndToProforma As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartFromProforma As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnGoProforma As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dGridProformas As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Bar9 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem12 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalProforma As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem21 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDiscountsProforma As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem23 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTaxesProforma As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel17 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboUserProforma As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnDeleteProforma As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Private WithEvents tvReports As System.Windows.Forms.TreeView
    Friend WithEvents Bar16 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents labelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dGridTransactions As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents integerInput1 As DevComponents.Editors.IntegerInput
    Private WithEvents labelX4 As DevComponents.DotNetBar.LabelX
    Private WithEvents btnPrintPreview As DevComponents.DotNetBar.ButtonX
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents pnlPreview As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridPreview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDeleteInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPayments As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkActiveSearch As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnFind As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents cm1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuNewCustomerQuote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewCashsale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewCreditNote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReceivePayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintCustomerStatement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEmailCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuActivateCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeactivateCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeleteCustomer As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents btnNewInvoice As DevComponents.DotNetBar.ButtonItem
End Class
