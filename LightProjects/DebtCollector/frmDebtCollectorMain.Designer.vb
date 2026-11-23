<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDebtCollectorMain
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDebtCollectorMain))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.StyleManager2 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.pb1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.splitMain = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar6 = New DevComponents.DotNetBar.Bar()
        Me.lblActiveAction = New DevComponents.DotNetBar.LabelItem()
        Me.Label250 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotals = New DevComponents.DotNetBar.LabelItem()
        Me.lblAmountTotal = New DevComponents.DotNetBar.LabelItem()
        Me.lblSelected = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalSelected = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.tvStages = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnFindNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnFind = New DevComponents.DotNetBar.ButtonX()
        Me.cboClients = New MTGCComboBox()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblClientId = New System.Windows.Forms.Label()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectHighlighted = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPlaceOnHold = New DevComponents.DotNetBar.ButtonItem()
        Me.btnActions = New DevComponents.DotNetBar.ButtonItem()
        Me.btnHistory = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSummaryReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCurrentList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnLegalExpenses = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCurrentSelectionLegalReport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnStatements = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.chkDisable = New DevComponents.DotNetBar.CheckBoxItem()
        Me.chkSelectAll = New DevComponents.DotNetBar.CheckBoxItem()
        Me.lblCount = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel6 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.SuperTabControl2 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridReceipts = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditRecord = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPayments = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PaymentPlansToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnReceiptFind = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnReceiptFindNext = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge33 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboReceiptSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge34 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboReceiptClients = New MTGCComboBox()
        Me.lblReceiptClientId = New System.Windows.Forms.Label()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge35 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge36 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtReceiptSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge55 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar7 = New DevComponents.DotNetBar.Bar()
        Me.btnReceipt = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge54 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge53 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge52 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge51 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SuperTabItem6 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridAllData = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonBorderEdge65 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.StatusStrip5 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalPaymentReceipts = New System.Windows.Forms.ToolStripStatusLabel()
        Me.KryptonPanel19 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboReceiptsPortfolio = New MTGCComboBox()
        Me.txtReceiptPortfolioId = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge61 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel20 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge62 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel21 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge63 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndToReceipts = New System.Windows.Forms.DateTimePicker()
        Me.dpStartFromReceipts = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel22 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel15 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge64 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnGoReceipts = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge60 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar12 = New DevComponents.DotNetBar.Bar()
        Me.btnReceiptDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintReceiptsList = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge59 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge58 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge57 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge56 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SuperTabItem7 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge32 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge31 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge30 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel5 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.SideNavPanel4 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel()
        Me.btnImportBranchTransactions = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportActions = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlTree = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TreeListView1 = New BrightIdeasSoftware.TreeListView()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpDateToAnalysis = New System.Windows.Forms.DateTimePicker()
        Me.dpDateFromAnalysis = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboDateFilter = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblClientIdAnalysis = New System.Windows.Forms.Label()
        Me.cboPortfolioAnalysis = New MTGCComboBox()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.btnAnalysisDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshAnalysis = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintPortfolioAnalysis = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridpp = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblClientspp = New System.Windows.Forms.Label()
        Me.cboClientspp = New MTGCComboBox()
        Me.KryptonPanel17 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge49 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge50 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar11 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.lblPPcnt = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblPPprincipal = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.lblPPBalance = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge48 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar10 = New DevComponents.DotNetBar.Bar()
        Me.btnRunpp = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge47 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge46 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge43 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge42 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dGridUnserved = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar9 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.lblNumberUnserved = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.lblUnservedPrincipal = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblUnservedBalance = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel15 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblUnservedClients = New System.Windows.Forms.Label()
        Me.cboUnservedClients = New MTGCComboBox()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge44 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge45 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge41 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar8 = New DevComponents.DotNetBar.Bar()
        Me.btnRunUnserved = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintUnserved = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge40 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge39 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge38 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge37 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SideNavPanel3 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.panelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.recentDocsItemPane = New DevComponents.DotNetBar.ItemPanel()
        Me.btnPrinters = New DevComponents.DotNetBar.ButtonItem()
        Me.btnLegalStaggings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUpgrades = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPortfolioCosts = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAllocations = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPaymentInitiators = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPaymentDescriptions = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOrganisation = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPaymentPlans = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUnserves = New DevComponents.DotNetBar.ButtonItem()
        Me.labelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SideNavPanel7 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridPortfolio = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboPortfolioStatus = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.txtPortfolioSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboPortfolioSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNewPortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditPortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeletePortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeactivateOnePortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportPortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintPortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshPortfolio = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem8 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem3 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem7 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem4 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem6 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem5 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expandablePanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel6.SuspendLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl2.SuspendLayout()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.dGridReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.cboReceiptSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel7.SuspendLayout()
        CType(Me.dGridAllData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip5.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel20.SuspendLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel21.SuspendLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel22.SuspendLayout()
        CType(Me.Bar12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel4.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.SideNavPanel2.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.pnlTree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTree.SuspendLayout()
        CType(Me.TreeListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.dGridpp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel17.SuspendLayout()
        CType(Me.Bar11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.dGridUnserved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel15.SuspendLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel3.SuspendLayout()
        Me.panelEx1.SuspendLayout()
        Me.SideNavPanel7.SuspendLayout()
        CType(Me.dGridPortfolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.cboPortfolioStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPortfolioSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.pb1})
        Me.Bar1.Location = New System.Drawing.Point(0, 676)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(1007, 22)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Great Wits Technologies, 2016. Light Edge Business Suite 8.0"
        '
        'pb1
        '
        '
        '
        '
        Me.pb1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pb1.ChunkGradientAngle = 0.0!
        Me.pb1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pb1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pb1.Name = "pb1"
        Me.pb1.RecentlyUsed = False
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel6)
        Me.SideNav1.Controls.Add(Me.SideNavPanel5)
        Me.SideNav1.Controls.Add(Me.SideNavPanel4)
        Me.SideNav1.Controls.Add(Me.SideNavPanel3)
        Me.SideNav1.Controls.Add(Me.SideNavPanel7)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem2, Me.SideNavItem8, Me.SideNavItem3, Me.SideNavItem7, Me.SideNavItem4, Me.SideNavItem6, Me.SideNavItem5})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1007, 676)
        Me.SideNav1.TabIndex = 1
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.splitMain)
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel3)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.SideNavPanel1.Controls.Add(Me.Bar3)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel1.Size = New System.Drawing.Size(912, 644)
        Me.SideNavPanel1.TabIndex = 2
        Me.SideNavPanel1.Visible = False
        '
        'splitMain
        '
        Me.splitMain.BackColor = System.Drawing.Color.White
        Me.splitMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Location = New System.Drawing.Point(7, 101)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.splitMain.Panel1.Controls.Add(Me.dGrid)
        Me.splitMain.Panel1.Controls.Add(Me.Bar6)
        Me.splitMain.Panel1.Controls.Add(Me.KryptonBorderEdge26)
        Me.splitMain.Panel1.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.splitMain.Panel2.Controls.Add(Me.expandablePanel1)
        Me.splitMain.Panel2.Controls.Add(Me.KryptonBorderEdge27)
        Me.splitMain.Panel2.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.splitMain.Size = New System.Drawing.Size(898, 536)
        Me.splitMain.SplitterDistance = 705
        Me.splitMain.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.TabIndex = 56
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column1, Me.Column2, Me.Column5, Me.Column7, Me.Column8, Me.Column6})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(704, 514)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGrid.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.TabIndex = 58
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Employee #"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 95
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Last Name"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 88
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "First Name"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 90
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Other Names"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 103
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "ID Number"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 91
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column7.HeaderText = "DOE"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 59
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column8.HeaderText = "DOB"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 60
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 68
        '
        'Bar6
        '
        Me.Bar6.AntiAlias = True
        Me.Bar6.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Bar6.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar6.IsMaximized = False
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblActiveAction, Me.Label250, Me.lblTotals, Me.lblAmountTotal, Me.lblSelected, Me.lblTotalSelected})
        Me.Bar6.Location = New System.Drawing.Point(0, 514)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(704, 22)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar6.TabIndex = 56
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'lblActiveAction
        '
        Me.lblActiveAction.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveAction.Name = "lblActiveAction"
        Me.lblActiveAction.PaddingLeft = 6
        Me.lblActiveAction.PaddingRight = 6
        Me.lblActiveAction.Stretch = True
        '
        'Label250
        '
        Me.Label250.BeginGroup = True
        Me.Label250.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Label250.Name = "Label250"
        Me.Label250.PaddingLeft = 3
        Me.Label250.PaddingRight = 3
        Me.Label250.Text = "Totals"
        '
        'lblTotals
        '
        Me.lblTotals.BeginGroup = True
        Me.lblTotals.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.PaddingLeft = 6
        Me.lblTotals.PaddingRight = 6
        Me.lblTotals.Text = "0"
        Me.lblTotals.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblAmountTotal
        '
        Me.lblAmountTotal.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblAmountTotal.Name = "lblAmountTotal"
        Me.lblAmountTotal.PaddingLeft = 6
        Me.lblAmountTotal.PaddingRight = 6
        Me.lblAmountTotal.Text = "0.00"
        Me.lblAmountTotal.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblSelected
        '
        Me.lblSelected.BeginGroup = True
        Me.lblSelected.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Text = "Total Selected"
        '
        'lblTotalSelected
        '
        Me.lblTotalSelected.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblTotalSelected.Name = "lblTotalSelected"
        Me.lblTotalSelected.PaddingLeft = 12
        Me.lblTotalSelected.PaddingRight = 12
        Me.lblTotalSelected.Text = "0"
        Me.lblTotalSelected.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(704, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 536)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'expandablePanel1
        '
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.tvStages)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(1, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(187, 536)
        Me.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.expandablePanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.Style.GradientAngle = 90
        Me.expandablePanel1.TabIndex = 15
        Me.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.TitleStyle.GradientAngle = 90
        Me.expandablePanel1.TitleStyle.MarginLeft = 6
        Me.expandablePanel1.TitleText = "Collection Stages"
        '
        'tvStages
        '
        Me.tvStages.BackColor = System.Drawing.Color.White
        Me.tvStages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvStages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvStages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvStages.ForeColor = System.Drawing.Color.Black
        Me.tvStages.FullRowSelect = True
        Me.tvStages.ImageIndex = 8
        Me.tvStages.ImageList = Me.imageList1
        Me.tvStages.Location = New System.Drawing.Point(0, 26)
        Me.tvStages.Name = "tvStages"
        Me.tvStages.SelectedImageIndex = 9
        Me.tvStages.Size = New System.Drawing.Size(187, 510)
        Me.tvStages.TabIndex = 4
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
        Me.imageList1.Images.SetKeyName(6, "41.png")
        Me.imageList1.Images.SetKeyName(7, "136.png")
        Me.imageList1.Images.SetKeyName(8, "blueflag-16.png")
        Me.imageList1.Images.SetKeyName(9, "red-flag-16.png")
        Me.imageList1.Images.SetKeyName(10, "right1-16.png")
        Me.imageList1.Images.SetKeyName(11, "right-16.png")
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge27.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(1, 536)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.AutoScroll = True
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.btnFindNext)
        Me.KryptonPanel3.Controls.Add(Me.btnFind)
        Me.KryptonPanel3.Controls.Add(Me.cboClients)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel3.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel3.Controls.Add(Me.lblClientId)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel3.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(7, 39)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(898, 62)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.TabIndex = 49
        '
        'btnFindNext
        '
        Me.btnFindNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFindNext.AutoSize = True
        Me.btnFindNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFindNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFindNext.Location = New System.Drawing.Point(825, 19)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(64, 22)
        Me.btnFindNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFindNext.TabIndex = 40
        Me.btnFindNext.Text = "Find next ..."
        '
        'btnFind
        '
        Me.btnFind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFind.AutoSize = True
        Me.btnFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFind.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.Location = New System.Drawing.Point(776, 19)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(47, 22)
        Me.btnFind.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFind.TabIndex = 39
        Me.btnFind.Text = "Find"
        '
        'cboClients
        '
        Me.cboClients.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboClients.ArrowColor = System.Drawing.Color.Black
        Me.cboClients.BindedControl = Nothing
        Me.cboClients.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboClients.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboClients.ColumnNum = 1
        Me.cboClients.ColumnWidth = "121"
        Me.cboClients.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboClients.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboClients.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboClients.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboClients.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboClients.DisplayMember = "Text"
        Me.cboClients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboClients.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboClients.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboClients.DropDownForeColor = System.Drawing.Color.Black
        Me.cboClients.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboClients.DropDownWidth = 141
        Me.cboClients.GridLineColor = System.Drawing.Color.LightGray
        Me.cboClients.GridLineHorizontal = False
        Me.cboClients.GridLineVertical = False
        Me.cboClients.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboClients.HighlightBorderOnMouseEvents = True
        Me.cboClients.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboClients.Location = New System.Drawing.Point(80, 20)
        Me.cboClients.ManagingFastMouseMoving = True
        Me.cboClients.ManagingFastMouseMovingInterval = 30
        Me.cboClients.Name = "cboClients"
        Me.cboClients.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboClients.SelectedItem = Nothing
        Me.cboClients.SelectedValue = Nothing
        Me.cboClients.Size = New System.Drawing.Size(330, 21)
        Me.cboClients.TabIndex = 38
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(414, 19)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(64, 22)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 33
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(64, 21)
        Me.KryptonLabel3.TabIndex = 18
        Me.KryptonLabel3.Values.Text = "Search by"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(64, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.BackColor = System.Drawing.Color.White
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboSearchBy.Items.AddRange(New Object() {"Number", "Name", "File Number"})
        Me.cboSearchBy.Location = New System.Drawing.Point(480, 20)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchBy.Size = New System.Drawing.Size(118, 21)
        Me.cboSearchBy.TabIndex = 32
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 61)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'lblClientId
        '
        Me.lblClientId.AutoSize = True
        Me.lblClientId.BackColor = System.Drawing.Color.White
        Me.lblClientId.ForeColor = System.Drawing.Color.Black
        Me.lblClientId.Location = New System.Drawing.Point(536, 6)
        Me.lblClientId.Name = "lblClientId"
        Me.lblClientId.Size = New System.Drawing.Size(13, 13)
        Me.lblClientId.TabIndex = 26
        Me.lblClientId.Text = "0"
        Me.lblClientId.Visible = False
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(604, 19)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(38, 22)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 25
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(38, 21)
        Me.KryptonLabel2.TabIndex = 18
        Me.KryptonLabel2.Values.Text = "For"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(38, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(13, 19)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 24
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel1.TabIndex = 18
        Me.KryptonLabel1.Values.Text = "Portfolio"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.White
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(643, 21)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(129, 20)
        Me.txtSearchString.TabIndex = 20
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(7, 38)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSelectHighlighted, Me.btnPlaceOnHold, Me.btnActions, Me.btnHistory, Me.btnImport, Me.btnExport, Me.btnPrint, Me.btnRefresh, Me.chkDisable, Me.chkSelectAll, Me.lblCount})
        Me.Bar3.Location = New System.Drawing.Point(7, 7)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(898, 31)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 22
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNew.Text = "ButtonItem1"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "ButtonItem2"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Text = "ButtonItem3"
        '
        'btnSelectHighlighted
        '
        Me.btnSelectHighlighted.BeginGroup = True
        Me.btnSelectHighlighted.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSelectHighlighted.Name = "btnSelectHighlighted"
        Me.btnSelectHighlighted.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSelectHighlighted.Symbol = ""
        Me.btnSelectHighlighted.SymbolColor = System.Drawing.Color.Firebrick
        Me.btnSelectHighlighted.SymbolSize = 16.0!
        Me.btnSelectHighlighted.Text = "&Select"
        '
        'btnPlaceOnHold
        '
        Me.btnPlaceOnHold.BeginGroup = True
        Me.btnPlaceOnHold.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPlaceOnHold.Name = "btnPlaceOnHold"
        Me.btnPlaceOnHold.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPlaceOnHold.Symbol = ""
        Me.btnPlaceOnHold.SymbolColor = System.Drawing.Color.Firebrick
        Me.btnPlaceOnHold.SymbolSize = 16.0!
        Me.btnPlaceOnHold.Text = "&Hold"
        '
        'btnActions
        '
        Me.btnActions.BeginGroup = True
        Me.btnActions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnActions.Name = "btnActions"
        Me.btnActions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnActions.Symbol = "57393"
        Me.btnActions.SymbolColor = System.Drawing.Color.Green
        Me.btnActions.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnActions.SymbolSize = 16.0!
        Me.btnActions.Text = "&Update Actions"
        '
        'btnHistory
        '
        Me.btnHistory.BeginGroup = True
        Me.btnHistory.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnHistory.Image = CType(resources.GetObject("btnHistory.Image"), System.Drawing.Image)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnHistory.Text = "History"
        '
        'btnImport
        '
        Me.btnImport.BeginGroup = True
        Me.btnImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImport.Text = "Import"
        '
        'btnExport
        '
        Me.btnExport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExport.Text = "Export"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSummaryReport, Me.btnCurrentList, Me.btnLegalExpenses, Me.btnCurrentSelectionLegalReport, Me.btnStatements})
        Me.btnPrint.Text = "Print"
        '
        'btnSummaryReport
        '
        Me.btnSummaryReport.BeginGroup = True
        Me.btnSummaryReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSummaryReport.Name = "btnSummaryReport"
        Me.btnSummaryReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSummaryReport.SymbolSize = 16.0!
        Me.btnSummaryReport.Text = "Actions Summary Report"
        '
        'btnCurrentList
        '
        Me.btnCurrentList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCurrentList.Name = "btnCurrentList"
        Me.btnCurrentList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCurrentList.SymbolSize = 16.0!
        Me.btnCurrentList.Text = "Current Criteria Report"
        '
        'btnLegalExpenses
        '
        Me.btnLegalExpenses.BeginGroup = True
        Me.btnLegalExpenses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnLegalExpenses.Name = "btnLegalExpenses"
        Me.btnLegalExpenses.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnLegalExpenses.SymbolSize = 16.0!
        Me.btnLegalExpenses.Text = "All Legal Expenses Analysis"
        '
        'btnCurrentSelectionLegalReport
        '
        Me.btnCurrentSelectionLegalReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCurrentSelectionLegalReport.Name = "btnCurrentSelectionLegalReport"
        Me.btnCurrentSelectionLegalReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCurrentSelectionLegalReport.SymbolSize = 16.0!
        Me.btnCurrentSelectionLegalReport.Text = "Current Selection Legal Expenses"
        '
        'btnStatements
        '
        Me.btnStatements.BeginGroup = True
        Me.btnStatements.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnStatements.Name = "btnStatements"
        Me.btnStatements.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnStatements.SymbolSize = 16.0!
        Me.btnStatements.Text = "Statements"
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Text = "ButtonItem7"
        '
        'chkDisable
        '
        Me.chkDisable.BeginGroup = True
        Me.chkDisable.Name = "chkDisable"
        Me.chkDisable.Text = "Active Search"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Text = "De/Select All"
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCount.BeginGroup = True
        Me.lblCount.FontBold = True
        Me.lblCount.ForeColor = System.Drawing.Color.White
        Me.lblCount.Name = "lblCount"
        Me.lblCount.PaddingLeft = 6
        Me.lblCount.PaddingRight = 6
        Me.lblCount.Text = "0"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(905, 7)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(900, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(900, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'SideNavPanel6
        '
        Me.SideNavPanel6.Controls.Add(Me.SuperTabControl2)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge32)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge31)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge30)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge29)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge28)
        Me.SideNavPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel6.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel6.Name = "SideNavPanel6"
        Me.SideNavPanel6.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel6.Size = New System.Drawing.Size(912, 644)
        Me.SideNavPanel6.TabIndex = 25
        Me.SideNavPanel6.Visible = False
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
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel6)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel7)
        Me.SuperTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl2.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl2.Location = New System.Drawing.Point(7, 8)
        Me.SuperTabControl2.Name = "SuperTabControl2"
        Me.SuperTabControl2.ReorderTabsEnabled = True
        Me.SuperTabControl2.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl2.SelectedTabIndex = 0
        Me.SuperTabControl2.Size = New System.Drawing.Size(898, 629)
        Me.SuperTabControl2.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl2.TabIndex = 42
        Me.SuperTabControl2.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem6, Me.SuperTabItem7})
        Me.SuperTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl2.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.dGridReceipts)
        Me.SuperTabControlPanel6.Controls.Add(Me.KryptonPanel11)
        Me.SuperTabControlPanel6.Controls.Add(Me.KryptonBorderEdge55)
        Me.SuperTabControlPanel6.Controls.Add(Me.Bar7)
        Me.SuperTabControlPanel6.Controls.Add(Me.KryptonBorderEdge54)
        Me.SuperTabControlPanel6.Controls.Add(Me.KryptonBorderEdge53)
        Me.SuperTabControlPanel6.Controls.Add(Me.KryptonBorderEdge52)
        Me.SuperTabControlPanel6.Controls.Add(Me.KryptonBorderEdge51)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Padding = New System.Windows.Forms.Padding(9)
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(898, 604)
        Me.SuperTabControlPanel6.TabIndex = 1
        Me.SuperTabControlPanel6.TabItem = Me.SuperTabItem6
        '
        'dGridReceipts
        '
        Me.dGridReceipts.AllowUserToAddRows = False
        Me.dGridReceipts.AllowUserToDeleteRows = False
        Me.dGridReceipts.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridReceipts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dGridReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13})
        Me.dGridReceipts.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dGridReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridReceipts.Location = New System.Drawing.Point(10, 97)
        Me.dGridReceipts.Name = "dGridReceipts"
        Me.dGridReceipts.ReadOnly = True
        Me.dGridReceipts.RowHeadersWidth = 25
        Me.dGridReceipts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridReceipts.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridReceipts.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridReceipts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridReceipts.Size = New System.Drawing.Size(878, 497)
        Me.dGridReceipts.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridReceipts.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridReceipts.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dGridReceipts.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReceipts.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReceipts.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridReceipts.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridReceipts.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridReceipts.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridReceipts.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReceipts.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridReceipts.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridReceipts.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridReceipts.TabIndex = 37
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.HeaderText = "Defendant #"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 108
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.HeaderText = "Given Names"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 150
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 150
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn11.HeaderText = "Debits"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn12.HeaderText = "Credits"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn13.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn13.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 81
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditRecord, Me.ToolStripMenuItem1, Me.mnuPayments, Me.ToolStripMenuItem2, Me.PaymentPlansToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(260, 82)
        '
        'mnuEditRecord
        '
        Me.mnuEditRecord.Name = "mnuEditRecord"
        Me.mnuEditRecord.Size = New System.Drawing.Size(259, 22)
        Me.mnuEditRecord.Text = "View and Maintain Selected Record"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(256, 6)
        '
        'mnuPayments
        '
        Me.mnuPayments.Name = "mnuPayments"
        Me.mnuPayments.Size = New System.Drawing.Size(259, 22)
        Me.mnuPayments.Text = "Update Selected Record Payments"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(256, 6)
        '
        'PaymentPlansToolStripMenuItem
        '
        Me.PaymentPlansToolStripMenuItem.Name = "PaymentPlansToolStripMenuItem"
        Me.PaymentPlansToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.PaymentPlansToolStripMenuItem.Text = "Add Payment Plans"
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.AutoScroll = True
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.btnReceiptFind)
        Me.KryptonPanel11.Controls.Add(Me.btnReceiptFindNext)
        Me.KryptonPanel11.Controls.Add(Me.KryptonPanel12)
        Me.KryptonPanel11.Controls.Add(Me.cboReceiptSearchBy)
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge34)
        Me.KryptonPanel11.Controls.Add(Me.cboReceiptClients)
        Me.KryptonPanel11.Controls.Add(Me.lblReceiptClientId)
        Me.KryptonPanel11.Controls.Add(Me.KryptonPanel13)
        Me.KryptonPanel11.Controls.Add(Me.KryptonPanel14)
        Me.KryptonPanel11.Controls.Add(Me.txtReceiptSearchString)
        Me.KryptonPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(10, 36)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(878, 61)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel11.TabIndex = 36
        '
        'btnReceiptFind
        '
        Me.btnReceiptFind.AutoSize = True
        Me.btnReceiptFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReceiptFind.BackColor = System.Drawing.Color.White
        Me.btnReceiptFind.ForeColor = System.Drawing.Color.Black
        Me.btnReceiptFind.Location = New System.Drawing.Point(766, 16)
        Me.btnReceiptFind.Name = "btnReceiptFind"
        Me.btnReceiptFind.Size = New System.Drawing.Size(32, 22)
        Me.btnReceiptFind.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnReceiptFind.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnReceiptFind.StateCommon.Back.ColorAngle = 100.0!
        Me.btnReceiptFind.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnReceiptFind.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnReceiptFind.StateCommon.Border.Rounding = 0
        Me.btnReceiptFind.TabIndex = 36
        Me.btnReceiptFind.Values.Text = "Find"
        '
        'btnReceiptFindNext
        '
        Me.btnReceiptFindNext.AutoSize = True
        Me.btnReceiptFindNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReceiptFindNext.BackColor = System.Drawing.Color.White
        Me.btnReceiptFindNext.ForeColor = System.Drawing.Color.Black
        Me.btnReceiptFindNext.Location = New System.Drawing.Point(801, 16)
        Me.btnReceiptFindNext.Name = "btnReceiptFindNext"
        Me.btnReceiptFindNext.Size = New System.Drawing.Size(34, 22)
        Me.btnReceiptFindNext.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnReceiptFindNext.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnReceiptFindNext.StateCommon.Back.ColorAngle = 100.0!
        Me.btnReceiptFindNext.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnReceiptFindNext.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnReceiptFindNext.StateCommon.Border.Rounding = 0
        Me.btnReceiptFindNext.TabIndex = 35
        Me.btnReceiptFindNext.Values.Text = "Next"
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge33)
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(432, 16)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(64, 22)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel12.TabIndex = 33
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.White
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(64, 21)
        Me.KryptonLabel8.TabIndex = 18
        Me.KryptonLabel8.Values.Text = "Search by"
        '
        'KryptonBorderEdge33
        '
        Me.KryptonBorderEdge33.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge33.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge33.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge33.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge33.Name = "KryptonBorderEdge33"
        Me.KryptonBorderEdge33.Size = New System.Drawing.Size(64, 1)
        Me.KryptonBorderEdge33.Text = "KryptonBorderEdge33"
        '
        'cboReceiptSearchBy
        '
        Me.cboReceiptSearchBy.BackColor = System.Drawing.Color.White
        Me.cboReceiptSearchBy.DropDownWidth = 163
        Me.cboReceiptSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboReceiptSearchBy.Items.AddRange(New Object() {"Number", "Name", "File Number"})
        Me.cboReceiptSearchBy.Location = New System.Drawing.Point(498, 17)
        Me.cboReceiptSearchBy.Name = "cboReceiptSearchBy"
        Me.cboReceiptSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboReceiptSearchBy.Size = New System.Drawing.Size(94, 21)
        Me.cboReceiptSearchBy.TabIndex = 32
        '
        'KryptonBorderEdge34
        '
        Me.KryptonBorderEdge34.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge34.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge34.Location = New System.Drawing.Point(0, 60)
        Me.KryptonBorderEdge34.Name = "KryptonBorderEdge34"
        Me.KryptonBorderEdge34.Size = New System.Drawing.Size(878, 1)
        Me.KryptonBorderEdge34.Text = "KryptonBorderEdge34"
        '
        'cboReceiptClients
        '
        Me.cboReceiptClients.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboReceiptClients.ArrowColor = System.Drawing.Color.Black
        Me.cboReceiptClients.BindedControl = Nothing
        Me.cboReceiptClients.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboReceiptClients.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboReceiptClients.ColumnNum = 1
        Me.cboReceiptClients.ColumnWidth = "121"
        Me.cboReceiptClients.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboReceiptClients.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboReceiptClients.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboReceiptClients.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboReceiptClients.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboReceiptClients.DisplayMember = "Text"
        Me.cboReceiptClients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboReceiptClients.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboReceiptClients.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboReceiptClients.DropDownForeColor = System.Drawing.Color.Black
        Me.cboReceiptClients.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboReceiptClients.DropDownWidth = 141
        Me.cboReceiptClients.GridLineColor = System.Drawing.Color.LightGray
        Me.cboReceiptClients.GridLineHorizontal = False
        Me.cboReceiptClients.GridLineVertical = False
        Me.cboReceiptClients.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboReceiptClients.HighlightBorderOnMouseEvents = True
        Me.cboReceiptClients.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboReceiptClients.Location = New System.Drawing.Point(75, 17)
        Me.cboReceiptClients.ManagingFastMouseMoving = True
        Me.cboReceiptClients.ManagingFastMouseMovingInterval = 30
        Me.cboReceiptClients.Name = "cboReceiptClients"
        Me.cboReceiptClients.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboReceiptClients.SelectedItem = Nothing
        Me.cboReceiptClients.SelectedValue = Nothing
        Me.cboReceiptClients.Size = New System.Drawing.Size(351, 21)
        Me.cboReceiptClients.TabIndex = 31
        '
        'lblReceiptClientId
        '
        Me.lblReceiptClientId.AutoSize = True
        Me.lblReceiptClientId.BackColor = System.Drawing.Color.White
        Me.lblReceiptClientId.ForeColor = System.Drawing.Color.Black
        Me.lblReceiptClientId.Location = New System.Drawing.Point(554, 3)
        Me.lblReceiptClientId.Name = "lblReceiptClientId"
        Me.lblReceiptClientId.Size = New System.Drawing.Size(13, 13)
        Me.lblReceiptClientId.TabIndex = 26
        Me.lblReceiptClientId.Text = "0"
        Me.lblReceiptClientId.Visible = False
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge35)
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(594, 16)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(38, 22)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 25
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.BackColor = System.Drawing.Color.White
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(38, 21)
        Me.KryptonLabel9.TabIndex = 18
        Me.KryptonLabel9.Values.Text = "For"
        '
        'KryptonBorderEdge35
        '
        Me.KryptonBorderEdge35.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge35.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge35.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge35.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge35.Name = "KryptonBorderEdge35"
        Me.KryptonBorderEdge35.Size = New System.Drawing.Size(38, 1)
        Me.KryptonBorderEdge35.Text = "KryptonBorderEdge35"
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge36)
        Me.KryptonPanel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel14.Location = New System.Drawing.Point(8, 16)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 24
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.BackColor = System.Drawing.Color.White
        Me.KryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel10.TabIndex = 18
        Me.KryptonLabel10.Values.Text = "Filter for"
        '
        'KryptonBorderEdge36
        '
        Me.KryptonBorderEdge36.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge36.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge36.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge36.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge36.Name = "KryptonBorderEdge36"
        Me.KryptonBorderEdge36.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge36.Text = "KryptonBorderEdge36"
        '
        'txtReceiptSearchString
        '
        Me.txtReceiptSearchString.BackColor = System.Drawing.Color.White
        Me.txtReceiptSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtReceiptSearchString.Location = New System.Drawing.Point(633, 18)
        Me.txtReceiptSearchString.Name = "txtReceiptSearchString"
        Me.txtReceiptSearchString.Size = New System.Drawing.Size(129, 20)
        Me.txtReceiptSearchString.TabIndex = 20
        '
        'KryptonBorderEdge55
        '
        Me.KryptonBorderEdge55.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge55.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge55.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge55.Location = New System.Drawing.Point(10, 35)
        Me.KryptonBorderEdge55.Name = "KryptonBorderEdge55"
        Me.KryptonBorderEdge55.Size = New System.Drawing.Size(878, 1)
        Me.KryptonBorderEdge55.Text = "KryptonBorderEdge55"
        '
        'Bar7
        '
        Me.Bar7.AntiAlias = True
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar7.IsMaximized = False
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReceipt})
        Me.Bar7.Location = New System.Drawing.Point(10, 10)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(878, 25)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar7.TabIndex = 5
        Me.Bar7.TabStop = False
        Me.Bar7.Text = "Bar7"
        '
        'btnReceipt
        '
        Me.btnReceipt.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReceipt.Image = CType(resources.GetObject("btnReceipt.Image"), System.Drawing.Image)
        Me.btnReceipt.Name = "btnReceipt"
        Me.btnReceipt.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReceipt.Text = "Receipt"
        '
        'KryptonBorderEdge54
        '
        Me.KryptonBorderEdge54.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge54.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge54.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge54.Location = New System.Drawing.Point(9, 10)
        Me.KryptonBorderEdge54.Name = "KryptonBorderEdge54"
        Me.KryptonBorderEdge54.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge54.Size = New System.Drawing.Size(1, 584)
        Me.KryptonBorderEdge54.Text = "KryptonBorderEdge54"
        '
        'KryptonBorderEdge53
        '
        Me.KryptonBorderEdge53.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge53.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge53.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge53.Location = New System.Drawing.Point(888, 10)
        Me.KryptonBorderEdge53.Name = "KryptonBorderEdge53"
        Me.KryptonBorderEdge53.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge53.Size = New System.Drawing.Size(1, 584)
        Me.KryptonBorderEdge53.Text = "KryptonBorderEdge53"
        '
        'KryptonBorderEdge52
        '
        Me.KryptonBorderEdge52.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge52.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge52.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge52.Location = New System.Drawing.Point(9, 594)
        Me.KryptonBorderEdge52.Name = "KryptonBorderEdge52"
        Me.KryptonBorderEdge52.Size = New System.Drawing.Size(880, 1)
        Me.KryptonBorderEdge52.Text = "KryptonBorderEdge52"
        '
        'KryptonBorderEdge51
        '
        Me.KryptonBorderEdge51.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge51.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge51.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge51.Location = New System.Drawing.Point(9, 9)
        Me.KryptonBorderEdge51.Name = "KryptonBorderEdge51"
        Me.KryptonBorderEdge51.Size = New System.Drawing.Size(880, 1)
        Me.KryptonBorderEdge51.Text = "KryptonBorderEdge51"
        '
        'SuperTabItem6
        '
        Me.SuperTabItem6.AttachedControl = Me.SuperTabControlPanel6
        Me.SuperTabItem6.GlobalItem = False
        Me.SuperTabItem6.Name = "SuperTabItem6"
        Me.SuperTabItem6.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        Me.SuperTabItem6.Text = "Make Receipts"
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.dGridAllData)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonBorderEdge65)
        Me.SuperTabControlPanel7.Controls.Add(Me.StatusStrip5)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonPanel19)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonBorderEdge60)
        Me.SuperTabControlPanel7.Controls.Add(Me.Bar12)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonBorderEdge59)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonBorderEdge58)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonBorderEdge57)
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonBorderEdge56)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Padding = New System.Windows.Forms.Padding(9)
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(898, 606)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.SuperTabItem7
        '
        'dGridAllData
        '
        Me.dGridAllData.AllowUserToAddRows = False
        Me.dGridAllData.AllowUserToDeleteRows = False
        Me.dGridAllData.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridAllData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dGridAllData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridAllData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridAllData.Location = New System.Drawing.Point(10, 85)
        Me.dGridAllData.Name = "dGridAllData"
        Me.dGridAllData.ReadOnly = True
        Me.dGridAllData.RowHeadersWidth = 25
        Me.dGridAllData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridAllData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridAllData.Size = New System.Drawing.Size(878, 488)
        Me.dGridAllData.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridAllData.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridAllData.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAllData.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGridAllData.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGridAllData.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridAllData.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridAllData.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridAllData.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAllData.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGridAllData.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.dGridAllData.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridAllData.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridAllData.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridAllData.TabIndex = 174
        '
        'KryptonBorderEdge65
        '
        Me.KryptonBorderEdge65.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge65.Location = New System.Drawing.Point(10, 573)
        Me.KryptonBorderEdge65.Name = "KryptonBorderEdge65"
        Me.KryptonBorderEdge65.Size = New System.Drawing.Size(878, 1)
        Me.KryptonBorderEdge65.Text = "KryptonBorderEdge65"
        '
        'StatusStrip5
        '
        Me.StatusStrip5.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.StatusStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel4, Me.lblTotalPaymentReceipts})
        Me.StatusStrip5.Location = New System.Drawing.Point(10, 574)
        Me.StatusStrip5.Name = "StatusStrip5"
        Me.StatusStrip5.Size = New System.Drawing.Size(878, 22)
        Me.StatusStrip5.SizingGrip = False
        Me.StatusStrip5.TabIndex = 172
        Me.StatusStrip5.Text = "StatusStrip5"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Image = CType(resources.GetObject("ToolStripStatusLabel4.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Padding = New System.Windows.Forms.Padding(24, 0, 0, 0)
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(832, 17)
        Me.ToolStripStatusLabel4.Spring = True
        Me.ToolStripStatusLabel4.Text = "Total"
        Me.ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalPaymentReceipts
        '
        Me.lblTotalPaymentReceipts.BackColor = System.Drawing.Color.ForestGreen
        Me.lblTotalPaymentReceipts.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPaymentReceipts.ForeColor = System.Drawing.Color.White
        Me.lblTotalPaymentReceipts.Name = "lblTotalPaymentReceipts"
        Me.lblTotalPaymentReceipts.Size = New System.Drawing.Size(31, 17)
        Me.lblTotalPaymentReceipts.Text = "0.00"
        '
        'KryptonPanel19
        '
        Me.KryptonPanel19.AutoScroll = True
        Me.KryptonPanel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel19.Controls.Add(Me.cboReceiptsPortfolio)
        Me.KryptonPanel19.Controls.Add(Me.txtReceiptPortfolioId)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge61)
        Me.KryptonPanel19.Controls.Add(Me.KryptonPanel20)
        Me.KryptonPanel19.Controls.Add(Me.KryptonPanel21)
        Me.KryptonPanel19.Controls.Add(Me.dpEndToReceipts)
        Me.KryptonPanel19.Controls.Add(Me.dpStartFromReceipts)
        Me.KryptonPanel19.Controls.Add(Me.KryptonPanel22)
        Me.KryptonPanel19.Controls.Add(Me.btnGoReceipts)
        Me.KryptonPanel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel19.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel19.Location = New System.Drawing.Point(10, 36)
        Me.KryptonPanel19.Name = "KryptonPanel19"
        Me.KryptonPanel19.Size = New System.Drawing.Size(878, 49)
        Me.KryptonPanel19.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel19.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel19.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel19.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel19.TabIndex = 144
        '
        'cboReceiptsPortfolio
        '
        Me.cboReceiptsPortfolio.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboReceiptsPortfolio.ArrowColor = System.Drawing.Color.Black
        Me.cboReceiptsPortfolio.BindedControl = Nothing
        Me.cboReceiptsPortfolio.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboReceiptsPortfolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboReceiptsPortfolio.ColumnNum = 1
        Me.cboReceiptsPortfolio.ColumnWidth = "121"
        Me.cboReceiptsPortfolio.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboReceiptsPortfolio.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboReceiptsPortfolio.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboReceiptsPortfolio.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboReceiptsPortfolio.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboReceiptsPortfolio.DisplayMember = "Text"
        Me.cboReceiptsPortfolio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboReceiptsPortfolio.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboReceiptsPortfolio.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboReceiptsPortfolio.DropDownForeColor = System.Drawing.Color.Black
        Me.cboReceiptsPortfolio.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboReceiptsPortfolio.DropDownWidth = 141
        Me.cboReceiptsPortfolio.GridLineColor = System.Drawing.Color.LightGray
        Me.cboReceiptsPortfolio.GridLineHorizontal = False
        Me.cboReceiptsPortfolio.GridLineVertical = False
        Me.cboReceiptsPortfolio.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboReceiptsPortfolio.HighlightBorderOnMouseEvents = True
        Me.cboReceiptsPortfolio.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboReceiptsPortfolio.Location = New System.Drawing.Point(433, 13)
        Me.cboReceiptsPortfolio.ManagingFastMouseMoving = True
        Me.cboReceiptsPortfolio.ManagingFastMouseMovingInterval = 30
        Me.cboReceiptsPortfolio.Name = "cboReceiptsPortfolio"
        Me.cboReceiptsPortfolio.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboReceiptsPortfolio.SelectedItem = Nothing
        Me.cboReceiptsPortfolio.SelectedValue = Nothing
        Me.cboReceiptsPortfolio.Size = New System.Drawing.Size(330, 21)
        Me.cboReceiptsPortfolio.TabIndex = 156
        '
        'txtReceiptPortfolioId
        '
        Me.txtReceiptPortfolioId.Location = New System.Drawing.Point(815, 15)
        Me.txtReceiptPortfolioId.Name = "txtReceiptPortfolioId"
        Me.txtReceiptPortfolioId.Size = New System.Drawing.Size(26, 20)
        Me.txtReceiptPortfolioId.TabIndex = 153
        Me.txtReceiptPortfolioId.Text = "0"
        Me.txtReceiptPortfolioId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReceiptPortfolioId.Visible = False
        '
        'KryptonBorderEdge61
        '
        Me.KryptonBorderEdge61.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge61.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge61.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge61.Location = New System.Drawing.Point(0, 48)
        Me.KryptonBorderEdge61.Name = "KryptonBorderEdge61"
        Me.KryptonBorderEdge61.Size = New System.Drawing.Size(878, 1)
        Me.KryptonBorderEdge61.Text = "KryptonBorderEdge61"
        '
        'KryptonPanel20
        '
        Me.KryptonPanel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel20.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel20.Controls.Add(Me.KryptonBorderEdge62)
        Me.KryptonPanel20.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel20.Location = New System.Drawing.Point(368, 13)
        Me.KryptonPanel20.Name = "KryptonPanel20"
        Me.KryptonPanel20.Size = New System.Drawing.Size(63, 21)
        Me.KryptonPanel20.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel20.TabIndex = 152
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.BackColor = System.Drawing.Color.White
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(63, 20)
        Me.KryptonLabel12.TabIndex = 1
        Me.KryptonLabel12.Values.Text = "Portfolio"
        '
        'KryptonBorderEdge62
        '
        Me.KryptonBorderEdge62.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge62.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge62.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge62.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge62.Name = "KryptonBorderEdge62"
        Me.KryptonBorderEdge62.Size = New System.Drawing.Size(63, 1)
        Me.KryptonBorderEdge62.Text = "KryptonBorderEdge62"
        '
        'KryptonPanel21
        '
        Me.KryptonPanel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel21.Controls.Add(Me.KryptonLabel14)
        Me.KryptonPanel21.Controls.Add(Me.KryptonBorderEdge63)
        Me.KryptonPanel21.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel21.Location = New System.Drawing.Point(208, 13)
        Me.KryptonPanel21.Name = "KryptonPanel21"
        Me.KryptonPanel21.Size = New System.Drawing.Size(57, 21)
        Me.KryptonPanel21.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel21.TabIndex = 151
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.BackColor = System.Drawing.Color.White
        Me.KryptonLabel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel14.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(57, 20)
        Me.KryptonLabel14.TabIndex = 1
        Me.KryptonLabel14.Values.Text = "Date to"
        '
        'KryptonBorderEdge63
        '
        Me.KryptonBorderEdge63.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge63.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge63.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge63.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge63.Name = "KryptonBorderEdge63"
        Me.KryptonBorderEdge63.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge63.Text = "KryptonBorderEdge63"
        '
        'dpEndToReceipts
        '
        Me.dpEndToReceipts.BackColor = System.Drawing.Color.White
        Me.dpEndToReceipts.ForeColor = System.Drawing.Color.Black
        Me.dpEndToReceipts.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndToReceipts.Location = New System.Drawing.Point(267, 14)
        Me.dpEndToReceipts.Name = "dpEndToReceipts"
        Me.dpEndToReceipts.Size = New System.Drawing.Size(95, 20)
        Me.dpEndToReceipts.TabIndex = 5
        '
        'dpStartFromReceipts
        '
        Me.dpStartFromReceipts.BackColor = System.Drawing.Color.White
        Me.dpStartFromReceipts.ForeColor = System.Drawing.Color.Black
        Me.dpStartFromReceipts.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFromReceipts.Location = New System.Drawing.Point(99, 14)
        Me.dpStartFromReceipts.Name = "dpStartFromReceipts"
        Me.dpStartFromReceipts.Size = New System.Drawing.Size(103, 20)
        Me.dpStartFromReceipts.TabIndex = 10
        '
        'KryptonPanel22
        '
        Me.KryptonPanel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel22.Controls.Add(Me.KryptonLabel15)
        Me.KryptonPanel22.Controls.Add(Me.KryptonBorderEdge64)
        Me.KryptonPanel22.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel22.Location = New System.Drawing.Point(20, 13)
        Me.KryptonPanel22.Name = "KryptonPanel22"
        Me.KryptonPanel22.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel22.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel22.TabIndex = 150
        '
        'KryptonLabel15
        '
        Me.KryptonLabel15.BackColor = System.Drawing.Color.White
        Me.KryptonLabel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel15.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel15.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel15.Name = "KryptonLabel15"
        Me.KryptonLabel15.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel15.TabIndex = 1
        Me.KryptonLabel15.Values.Text = "Date from"
        '
        'KryptonBorderEdge64
        '
        Me.KryptonBorderEdge64.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge64.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge64.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge64.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge64.Name = "KryptonBorderEdge64"
        Me.KryptonBorderEdge64.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge64.Text = "KryptonBorderEdge64"
        '
        'btnGoReceipts
        '
        Me.btnGoReceipts.AutoSize = True
        Me.btnGoReceipts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGoReceipts.BackColor = System.Drawing.Color.White
        Me.btnGoReceipts.ForeColor = System.Drawing.Color.Black
        Me.btnGoReceipts.Location = New System.Drawing.Point(765, 12)
        Me.btnGoReceipts.Name = "btnGoReceipts"
        Me.btnGoReceipts.Size = New System.Drawing.Size(41, 22)
        Me.btnGoReceipts.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnGoReceipts.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnGoReceipts.StateCommon.Back.ColorAngle = 100.0!
        Me.btnGoReceipts.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnGoReceipts.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnGoReceipts.StateCommon.Border.Rounding = 0
        Me.btnGoReceipts.TabIndex = 139
        Me.btnGoReceipts.Values.Text = "Run ..."
        '
        'KryptonBorderEdge60
        '
        Me.KryptonBorderEdge60.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge60.Location = New System.Drawing.Point(10, 35)
        Me.KryptonBorderEdge60.Name = "KryptonBorderEdge60"
        Me.KryptonBorderEdge60.Size = New System.Drawing.Size(878, 1)
        Me.KryptonBorderEdge60.Text = "KryptonBorderEdge60"
        '
        'Bar12
        '
        Me.Bar12.AntiAlias = True
        Me.Bar12.BackColor = System.Drawing.Color.Transparent
        Me.Bar12.ColorScheme.BarCaptionInactiveBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar12.ColorScheme.ExplorerBarBackground = System.Drawing.Color.Transparent
        Me.Bar12.ColorScheme.ItemCheckedBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar12.ColorScheme.MenuBarBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar12.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar12.IsMaximized = False
        Me.Bar12.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReceiptDetails, Me.btnPrintReceiptsList})
        Me.Bar12.Location = New System.Drawing.Point(10, 10)
        Me.Bar12.Name = "Bar12"
        Me.Bar12.RoundCorners = False
        Me.Bar12.Size = New System.Drawing.Size(878, 25)
        Me.Bar12.Stretch = True
        Me.Bar12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar12.TabIndex = 142
        Me.Bar12.TabStop = False
        Me.Bar12.Text = "Bar12"
        '
        'btnReceiptDetails
        '
        Me.btnReceiptDetails.BeginGroup = True
        Me.btnReceiptDetails.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReceiptDetails.Image = CType(resources.GetObject("btnReceiptDetails.Image"), System.Drawing.Image)
        Me.btnReceiptDetails.Name = "btnReceiptDetails"
        Me.btnReceiptDetails.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReceiptDetails.Text = "Details"
        '
        'btnPrintReceiptsList
        '
        Me.btnPrintReceiptsList.BeginGroup = True
        Me.btnPrintReceiptsList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintReceiptsList.Image = CType(resources.GetObject("btnPrintReceiptsList.Image"), System.Drawing.Image)
        Me.btnPrintReceiptsList.Name = "btnPrintReceiptsList"
        Me.btnPrintReceiptsList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintReceiptsList.Text = "&Print"
        '
        'KryptonBorderEdge59
        '
        Me.KryptonBorderEdge59.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge59.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge59.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge59.Location = New System.Drawing.Point(888, 10)
        Me.KryptonBorderEdge59.Name = "KryptonBorderEdge59"
        Me.KryptonBorderEdge59.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge59.Size = New System.Drawing.Size(1, 586)
        Me.KryptonBorderEdge59.Text = "KryptonBorderEdge59"
        '
        'KryptonBorderEdge58
        '
        Me.KryptonBorderEdge58.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge58.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge58.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge58.Location = New System.Drawing.Point(9, 10)
        Me.KryptonBorderEdge58.Name = "KryptonBorderEdge58"
        Me.KryptonBorderEdge58.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge58.Size = New System.Drawing.Size(1, 586)
        Me.KryptonBorderEdge58.Text = "KryptonBorderEdge58"
        '
        'KryptonBorderEdge57
        '
        Me.KryptonBorderEdge57.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge57.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge57.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge57.Location = New System.Drawing.Point(9, 596)
        Me.KryptonBorderEdge57.Name = "KryptonBorderEdge57"
        Me.KryptonBorderEdge57.Size = New System.Drawing.Size(880, 1)
        Me.KryptonBorderEdge57.Text = "KryptonBorderEdge57"
        '
        'KryptonBorderEdge56
        '
        Me.KryptonBorderEdge56.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge56.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge56.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge56.Location = New System.Drawing.Point(9, 9)
        Me.KryptonBorderEdge56.Name = "KryptonBorderEdge56"
        Me.KryptonBorderEdge56.Size = New System.Drawing.Size(880, 1)
        Me.KryptonBorderEdge56.Text = "KryptonBorderEdge56"
        '
        'SuperTabItem7
        '
        Me.SuperTabItem7.AttachedControl = Me.SuperTabControlPanel7
        Me.SuperTabItem7.GlobalItem = False
        Me.SuperTabItem7.Name = "SuperTabItem7"
        Me.SuperTabItem7.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        Me.SuperTabItem7.Text = "View Receipts"
        '
        'KryptonBorderEdge32
        '
        Me.KryptonBorderEdge32.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge32.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge32.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge32.Location = New System.Drawing.Point(7, 7)
        Me.KryptonBorderEdge32.Name = "KryptonBorderEdge32"
        Me.KryptonBorderEdge32.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge32.Text = "KryptonBorderEdge32"
        '
        'KryptonBorderEdge31
        '
        Me.KryptonBorderEdge31.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge31.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge31.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge31.Location = New System.Drawing.Point(905, 7)
        Me.KryptonBorderEdge31.Name = "KryptonBorderEdge31"
        Me.KryptonBorderEdge31.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge31.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge31.Text = "KryptonBorderEdge31"
        '
        'KryptonBorderEdge30
        '
        Me.KryptonBorderEdge30.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge30.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge30.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge30.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge30.Name = "KryptonBorderEdge30"
        Me.KryptonBorderEdge30.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge30.Size = New System.Drawing.Size(1, 630)
        Me.KryptonBorderEdge30.Text = "KryptonBorderEdge30"
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(6, 637)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(900, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge28.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(900, 1)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'SideNavPanel5
        '
        Me.SideNavPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel5.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel5.Name = "SideNavPanel5"
        Me.SideNavPanel5.Size = New System.Drawing.Size(912, 644)
        Me.SideNavPanel5.TabIndex = 21
        Me.SideNavPanel5.Visible = False
        '
        'SideNavPanel4
        '
        Me.SideNavPanel4.Controls.Add(Me.PanelEx2)
        Me.SideNavPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel4.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel4.Name = "SideNavPanel4"
        Me.SideNavPanel4.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel4.Size = New System.Drawing.Size(912, 644)
        Me.SideNavPanel4.TabIndex = 17
        Me.SideNavPanel4.Visible = False
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.ItemPanel1)
        Me.PanelEx2.Controls.Add(Me.LabelX2)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx2.Location = New System.Drawing.Point(12, 12)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Padding = New System.Windows.Forms.Padding(12)
        Me.PanelEx2.Size = New System.Drawing.Size(458, 620)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 16
        Me.PanelEx2.Text = "PanelEx2"
        '
        'ItemPanel1
        '
        Me.ItemPanel1.AutoScroll = True
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnImportBranchTransactions, Me.btnExportActions})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.Location = New System.Drawing.Point(12, 35)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.Size = New System.Drawing.Size(434, 573)
        Me.ItemPanel1.TabIndex = 1
        '
        'btnImportBranchTransactions
        '
        Me.btnImportBranchTransactions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImportBranchTransactions.CommandParameter = ""
        Me.btnImportBranchTransactions.ForeColor = System.Drawing.Color.Black
        Me.btnImportBranchTransactions.Image = CType(resources.GetObject("btnImportBranchTransactions.Image"), System.Drawing.Image)
        Me.btnImportBranchTransactions.Name = "btnImportBranchTransactions"
        Me.btnImportBranchTransactions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImportBranchTransactions.Symbol = "58341"
        Me.btnImportBranchTransactions.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnImportBranchTransactions.Text = "Import Branch Transactions<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Import financial transactions" & _
    " sent from a branch in text file</font>"
        '
        'btnExportActions
        '
        Me.btnExportActions.BeginGroup = True
        Me.btnExportActions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportActions.CommandParameter = ""
        Me.btnExportActions.ForeColor = System.Drawing.Color.Black
        Me.btnExportActions.Image = CType(resources.GetObject("btnExportActions.Image"), System.Drawing.Image)
        Me.btnExportActions.Name = "btnExportActions"
        Me.btnExportActions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportActions.Symbol = "57749"
        Me.btnExportActions.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnExportActions.Text = "Export Actions and Financial Transactions<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Export actions" & _
    " and financial transactions captured at remote branches to text file</font>"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash
        Me.LabelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gray
        Me.LabelX2.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(434, 23)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "General Utility Programss"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Controls.Add(Me.SuperTabControl1)
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel2.Size = New System.Drawing.Size(912, 644)
        Me.SideNavPanel2.TabIndex = 6
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(6, 6)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(900, 632)
        Me.SuperTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 0
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3, Me.SuperTabItem4, Me.SuperTabItem5})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OfficeMobile2014
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.pnlTree)
        Me.SuperTabControlPanel1.Controls.Add(Me.Bar5)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonPanel7)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge21)
        Me.SuperTabControlPanel1.Controls.Add(Me.Bar4)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge20)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge19)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge18)
        Me.SuperTabControlPanel1.Controls.Add(Me.KryptonBorderEdge17)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(900, 599)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'pnlTree
        '
        Me.pnlTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.pnlTree.Controls.Add(Me.TreeListView1)
        Me.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTree.ForeColor = System.Drawing.Color.Black
        Me.pnlTree.Location = New System.Drawing.Point(7, 94)
        Me.pnlTree.Name = "pnlTree"
        Me.pnlTree.Size = New System.Drawing.Size(886, 474)
        Me.pnlTree.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.pnlTree.TabIndex = 63
        '
        'TreeListView1
        '
        Me.TreeListView1.BackColor = System.Drawing.Color.White
        Me.TreeListView1.CellEditUseWholeCell = False
        Me.TreeListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeListView1.ForeColor = System.Drawing.Color.Black
        Me.TreeListView1.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.TreeListView1.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.TreeListView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeListView1.Name = "TreeListView1"
        Me.TreeListView1.ShowGroups = False
        Me.TreeListView1.Size = New System.Drawing.Size(886, 474)
        Me.TreeListView1.TabIndex = 57
        Me.TreeListView1.UseCompatibleStateImageBehavior = False
        Me.TreeListView1.View = System.Windows.Forms.View.Details
        Me.TreeListView1.VirtualMode = True
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2})
        Me.Bar5.Location = New System.Drawing.Point(7, 568)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(886, 24)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 7
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "Totals"
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.dpDateToAnalysis)
        Me.KryptonPanel7.Controls.Add(Me.dpDateFromAnalysis)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel7.Controls.Add(Me.cboDateFilter)
        Me.KryptonPanel7.Controls.Add(Me.lblClientIdAnalysis)
        Me.KryptonPanel7.Controls.Add(Me.cboPortfolioAnalysis)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(7, 33)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(886, 61)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.TabIndex = 6
        '
        'dpDateToAnalysis
        '
        Me.dpDateToAnalysis.BackColor = System.Drawing.Color.White
        Me.dpDateToAnalysis.ForeColor = System.Drawing.Color.Black
        Me.dpDateToAnalysis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDateToAnalysis.Location = New System.Drawing.Point(767, 21)
        Me.dpDateToAnalysis.Name = "dpDateToAnalysis"
        Me.dpDateToAnalysis.Size = New System.Drawing.Size(103, 20)
        Me.dpDateToAnalysis.TabIndex = 46
        '
        'dpDateFromAnalysis
        '
        Me.dpDateFromAnalysis.BackColor = System.Drawing.Color.White
        Me.dpDateFromAnalysis.ForeColor = System.Drawing.Color.Black
        Me.dpDateFromAnalysis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDateFromAnalysis.Location = New System.Drawing.Point(586, 21)
        Me.dpDateFromAnalysis.Name = "dpDateFromAnalysis"
        Me.dpDateFromAnalysis.Size = New System.Drawing.Size(103, 20)
        Me.dpDateFromAnalysis.TabIndex = 45
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge25)
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(700, 19)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 44
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.White
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel7.TabIndex = 18
        Me.KryptonLabel7.Values.Text = "Date to"
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge24)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(519, 19)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 43
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.White
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel6.TabIndex = 18
        Me.KryptonLabel6.Values.Text = "Date from"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'cboDateFilter
        '
        Me.cboDateFilter.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cboDateFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cboDateFilter.ForeColor = System.Drawing.Color.Black
        Me.cboDateFilter.Location = New System.Drawing.Point(424, 18)
        Me.cboDateFilter.Name = "cboDateFilter"
        Me.cboDateFilter.Size = New System.Drawing.Size(100, 23)
        Me.cboDateFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDateFilter.TabIndex = 42
        Me.cboDateFilter.Text = "Filter by date"
        '
        'lblClientIdAnalysis
        '
        Me.lblClientIdAnalysis.AutoSize = True
        Me.lblClientIdAnalysis.BackColor = System.Drawing.Color.White
        Me.lblClientIdAnalysis.ForeColor = System.Drawing.Color.Black
        Me.lblClientIdAnalysis.Location = New System.Drawing.Point(382, 3)
        Me.lblClientIdAnalysis.Name = "lblClientIdAnalysis"
        Me.lblClientIdAnalysis.Size = New System.Drawing.Size(13, 13)
        Me.lblClientIdAnalysis.TabIndex = 41
        Me.lblClientIdAnalysis.Text = "0"
        Me.lblClientIdAnalysis.Visible = False
        '
        'cboPortfolioAnalysis
        '
        Me.cboPortfolioAnalysis.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboPortfolioAnalysis.ArrowColor = System.Drawing.Color.Black
        Me.cboPortfolioAnalysis.BindedControl = Nothing
        Me.cboPortfolioAnalysis.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboPortfolioAnalysis.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPortfolioAnalysis.ColumnNum = 1
        Me.cboPortfolioAnalysis.ColumnWidth = "121"
        Me.cboPortfolioAnalysis.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboPortfolioAnalysis.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboPortfolioAnalysis.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboPortfolioAnalysis.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboPortfolioAnalysis.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboPortfolioAnalysis.DisplayMember = "Text"
        Me.cboPortfolioAnalysis.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPortfolioAnalysis.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboPortfolioAnalysis.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboPortfolioAnalysis.DropDownForeColor = System.Drawing.Color.Black
        Me.cboPortfolioAnalysis.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboPortfolioAnalysis.DropDownWidth = 141
        Me.cboPortfolioAnalysis.GridLineColor = System.Drawing.Color.LightGray
        Me.cboPortfolioAnalysis.GridLineHorizontal = False
        Me.cboPortfolioAnalysis.GridLineVertical = False
        Me.cboPortfolioAnalysis.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboPortfolioAnalysis.HighlightBorderOnMouseEvents = True
        Me.cboPortfolioAnalysis.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboPortfolioAnalysis.Location = New System.Drawing.Point(83, 21)
        Me.cboPortfolioAnalysis.ManagingFastMouseMoving = True
        Me.cboPortfolioAnalysis.ManagingFastMouseMovingInterval = 30
        Me.cboPortfolioAnalysis.Name = "cboPortfolioAnalysis"
        Me.cboPortfolioAnalysis.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboPortfolioAnalysis.SelectedItem = Nothing
        Me.cboPortfolioAnalysis.SelectedValue = Nothing
        Me.cboPortfolioAnalysis.Size = New System.Drawing.Size(330, 21)
        Me.cboPortfolioAnalysis.TabIndex = 40
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge23)
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(16, 20)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 39
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.White
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel5.TabIndex = 18
        Me.KryptonLabel5.Values.Text = "Portfolio"
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 60)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(886, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(886, 1)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAnalysisDetails, Me.btnRefreshAnalysis, Me.btnPrintPortfolioAnalysis})
        Me.Bar4.Location = New System.Drawing.Point(7, 7)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(886, 25)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 4
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'btnAnalysisDetails
        '
        Me.btnAnalysisDetails.BeginGroup = True
        Me.btnAnalysisDetails.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAnalysisDetails.Image = CType(resources.GetObject("btnAnalysisDetails.Image"), System.Drawing.Image)
        Me.btnAnalysisDetails.Name = "btnAnalysisDetails"
        Me.btnAnalysisDetails.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAnalysisDetails.Text = "&Details"
        '
        'btnRefreshAnalysis
        '
        Me.btnRefreshAnalysis.BeginGroup = True
        Me.btnRefreshAnalysis.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefreshAnalysis.Image = CType(resources.GetObject("btnRefreshAnalysis.Image"), System.Drawing.Image)
        Me.btnRefreshAnalysis.Name = "btnRefreshAnalysis"
        Me.btnRefreshAnalysis.Text = "Refresh"
        '
        'btnPrintPortfolioAnalysis
        '
        Me.btnPrintPortfolioAnalysis.BeginGroup = True
        Me.btnPrintPortfolioAnalysis.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintPortfolioAnalysis.Image = CType(resources.GetObject("btnPrintPortfolioAnalysis.Image"), System.Drawing.Image)
        Me.btnPrintPortfolioAnalysis.Name = "btnPrintPortfolioAnalysis"
        Me.btnPrintPortfolioAnalysis.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintPortfolioAnalysis.Text = "Print"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(893, 7)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(1, 585)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(1, 585)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(6, 592)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(888, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(888, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        Me.SuperTabItem1.Text = "Stages Analysis"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.dGridpp)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonPanel16)
        Me.SuperTabControlPanel4.Controls.Add(Me.Bar11)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge48)
        Me.SuperTabControlPanel4.Controls.Add(Me.Bar10)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge47)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge46)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge43)
        Me.SuperTabControlPanel4.Controls.Add(Me.KryptonBorderEdge42)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Padding = New System.Windows.Forms.Padding(6)
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(900, 599)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'dGridpp
        '
        Me.dGridpp.AllowUserToAddRows = False
        Me.dGridpp.AllowUserToDeleteRows = False
        Me.dGridpp.AllowUserToResizeRows = False
        Me.dGridpp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridpp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27})
        Me.dGridpp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridpp.Location = New System.Drawing.Point(7, 94)
        Me.dGridpp.Name = "dGridpp"
        Me.dGridpp.ReadOnly = True
        Me.dGridpp.RowHeadersWidth = 25
        Me.dGridpp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridpp.Size = New System.Drawing.Size(886, 478)
        Me.dGridpp.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridpp.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridpp.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridpp.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridpp.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridpp.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridpp.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridpp.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridpp.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridpp.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridpp.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridpp.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridpp.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridpp.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridpp.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridpp.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridpp.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridpp.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridpp.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridpp.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridpp.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridpp.TabIndex = 60
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn21.HeaderText = "Defendant #"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 101
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn22.HeaderText = "File #"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 64
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn23.HeaderText = "Given Names"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 102
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn24.HeaderText = "Principal"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 80
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn25.HeaderText = "Debits"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 69
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn26.HeaderText = "Credits"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 72
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn27.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Width = 76
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel16.Controls.Add(Me.lblClientspp)
        Me.KryptonPanel16.Controls.Add(Me.cboClientspp)
        Me.KryptonPanel16.Controls.Add(Me.KryptonPanel17)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge50)
        Me.KryptonPanel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel16.Location = New System.Drawing.Point(7, 33)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Size = New System.Drawing.Size(886, 61)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel16.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel16.TabIndex = 10
        '
        'lblClientspp
        '
        Me.lblClientspp.AutoSize = True
        Me.lblClientspp.BackColor = System.Drawing.Color.White
        Me.lblClientspp.ForeColor = System.Drawing.Color.Black
        Me.lblClientspp.Location = New System.Drawing.Point(382, 3)
        Me.lblClientspp.Name = "lblClientspp"
        Me.lblClientspp.Size = New System.Drawing.Size(13, 13)
        Me.lblClientspp.TabIndex = 41
        Me.lblClientspp.Text = "0"
        Me.lblClientspp.Visible = False
        '
        'cboClientspp
        '
        Me.cboClientspp.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboClientspp.ArrowColor = System.Drawing.Color.Black
        Me.cboClientspp.BindedControl = Nothing
        Me.cboClientspp.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboClientspp.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboClientspp.ColumnNum = 1
        Me.cboClientspp.ColumnWidth = "121"
        Me.cboClientspp.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboClientspp.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboClientspp.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboClientspp.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboClientspp.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboClientspp.DisplayMember = "Text"
        Me.cboClientspp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboClientspp.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboClientspp.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboClientspp.DropDownForeColor = System.Drawing.Color.Black
        Me.cboClientspp.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboClientspp.DropDownWidth = 141
        Me.cboClientspp.GridLineColor = System.Drawing.Color.LightGray
        Me.cboClientspp.GridLineHorizontal = False
        Me.cboClientspp.GridLineVertical = False
        Me.cboClientspp.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboClientspp.HighlightBorderOnMouseEvents = True
        Me.cboClientspp.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboClientspp.Location = New System.Drawing.Point(83, 21)
        Me.cboClientspp.ManagingFastMouseMoving = True
        Me.cboClientspp.ManagingFastMouseMovingInterval = 30
        Me.cboClientspp.Name = "cboClientspp"
        Me.cboClientspp.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboClientspp.SelectedItem = Nothing
        Me.cboClientspp.SelectedValue = Nothing
        Me.cboClientspp.Size = New System.Drawing.Size(330, 21)
        Me.cboClientspp.TabIndex = 40
        '
        'KryptonPanel17
        '
        Me.KryptonPanel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel17.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge49)
        Me.KryptonPanel17.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel17.Location = New System.Drawing.Point(16, 20)
        Me.KryptonPanel17.Name = "KryptonPanel17"
        Me.KryptonPanel17.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel17.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel17.TabIndex = 39
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.BackColor = System.Drawing.Color.White
        Me.KryptonLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel11.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel11.TabIndex = 18
        Me.KryptonLabel11.Values.Text = "Portfolio"
        '
        'KryptonBorderEdge49
        '
        Me.KryptonBorderEdge49.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge49.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge49.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge49.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge49.Name = "KryptonBorderEdge49"
        Me.KryptonBorderEdge49.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge49.Text = "KryptonBorderEdge49"
        '
        'KryptonBorderEdge50
        '
        Me.KryptonBorderEdge50.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge50.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge50.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge50.Location = New System.Drawing.Point(0, 60)
        Me.KryptonBorderEdge50.Name = "KryptonBorderEdge50"
        Me.KryptonBorderEdge50.Size = New System.Drawing.Size(886, 1)
        Me.KryptonBorderEdge50.Text = "KryptonBorderEdge50"
        '
        'Bar11
        '
        Me.Bar11.AntiAlias = True
        Me.Bar11.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar11.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar11.IsMaximized = False
        Me.Bar11.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem6, Me.lblPPcnt, Me.LabelItem8, Me.lblPPprincipal, Me.LabelItem10, Me.lblPPBalance})
        Me.Bar11.Location = New System.Drawing.Point(7, 572)
        Me.Bar11.Name = "Bar11"
        Me.Bar11.PaddingLeft = 3
        Me.Bar11.PaddingRight = 3
        Me.Bar11.RoundCorners = False
        Me.Bar11.Size = New System.Drawing.Size(886, 20)
        Me.Bar11.Stretch = True
        Me.Bar11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar11.TabIndex = 9
        Me.Bar11.TabStop = False
        Me.Bar11.Text = "Bar11"
        '
        'LabelItem6
        '
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingLeft = 3
        Me.LabelItem6.PaddingRight = 3
        Me.LabelItem6.Stretch = True
        Me.LabelItem6.Text = "Total records processed "
        '
        'lblPPcnt
        '
        Me.lblPPcnt.Name = "lblPPcnt"
        Me.lblPPcnt.PaddingLeft = 3
        Me.lblPPcnt.PaddingRight = 3
        Me.lblPPcnt.Text = "0"
        '
        'LabelItem8
        '
        Me.LabelItem8.BeginGroup = True
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingLeft = 3
        Me.LabelItem8.PaddingRight = 3
        Me.LabelItem8.Text = "Principal"
        '
        'lblPPprincipal
        '
        Me.lblPPprincipal.Name = "lblPPprincipal"
        Me.lblPPprincipal.PaddingLeft = 6
        Me.lblPPprincipal.PaddingRight = 6
        Me.lblPPprincipal.Text = "0.00"
        '
        'LabelItem10
        '
        Me.LabelItem10.BeginGroup = True
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.PaddingLeft = 3
        Me.LabelItem10.PaddingRight = 3
        Me.LabelItem10.Text = "Balance"
        '
        'lblPPBalance
        '
        Me.lblPPBalance.Name = "lblPPBalance"
        Me.lblPPBalance.PaddingLeft = 6
        Me.lblPPBalance.PaddingRight = 6
        Me.lblPPBalance.Text = "0.00"
        '
        'KryptonBorderEdge48
        '
        Me.KryptonBorderEdge48.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge48.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge48.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge48.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge48.Name = "KryptonBorderEdge48"
        Me.KryptonBorderEdge48.Size = New System.Drawing.Size(886, 1)
        Me.KryptonBorderEdge48.Text = "KryptonBorderEdge48"
        '
        'Bar10
        '
        Me.Bar10.AntiAlias = True
        Me.Bar10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar10.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar10.IsMaximized = False
        Me.Bar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnRunpp, Me.ButtonItem2})
        Me.Bar10.Location = New System.Drawing.Point(7, 7)
        Me.Bar10.Name = "Bar10"
        Me.Bar10.RoundCorners = False
        Me.Bar10.Size = New System.Drawing.Size(886, 25)
        Me.Bar10.Stretch = True
        Me.Bar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar10.TabIndex = 6
        Me.Bar10.TabStop = False
        Me.Bar10.Text = "Bar10"
        '
        'btnRunpp
        '
        Me.btnRunpp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRunpp.Image = CType(resources.GetObject("btnRunpp.Image"), System.Drawing.Image)
        Me.btnRunpp.Name = "btnRunpp"
        Me.btnRunpp.Text = "Run"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.BeginGroup = True
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem2.Text = "Print"
        '
        'KryptonBorderEdge47
        '
        Me.KryptonBorderEdge47.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge47.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge47.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge47.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge47.Name = "KryptonBorderEdge47"
        Me.KryptonBorderEdge47.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge47.Size = New System.Drawing.Size(1, 585)
        Me.KryptonBorderEdge47.Text = "KryptonBorderEdge47"
        '
        'KryptonBorderEdge46
        '
        Me.KryptonBorderEdge46.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge46.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge46.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge46.Location = New System.Drawing.Point(893, 7)
        Me.KryptonBorderEdge46.Name = "KryptonBorderEdge46"
        Me.KryptonBorderEdge46.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge46.Size = New System.Drawing.Size(1, 585)
        Me.KryptonBorderEdge46.Text = "KryptonBorderEdge46"
        '
        'KryptonBorderEdge43
        '
        Me.KryptonBorderEdge43.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge43.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge43.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge43.Location = New System.Drawing.Point(6, 592)
        Me.KryptonBorderEdge43.Name = "KryptonBorderEdge43"
        Me.KryptonBorderEdge43.Size = New System.Drawing.Size(888, 1)
        Me.KryptonBorderEdge43.Text = "KryptonBorderEdge43"
        '
        'KryptonBorderEdge42
        '
        Me.KryptonBorderEdge42.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge42.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge42.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge42.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge42.Name = "KryptonBorderEdge42"
        Me.KryptonBorderEdge42.Size = New System.Drawing.Size(888, 1)
        Me.KryptonBorderEdge42.Text = "KryptonBorderEdge42"
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Payment Plans"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.dGridUnserved)
        Me.SuperTabControlPanel5.Controls.Add(Me.Bar9)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonPanel15)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge41)
        Me.SuperTabControlPanel5.Controls.Add(Me.Bar8)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge40)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge39)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge38)
        Me.SuperTabControlPanel5.Controls.Add(Me.KryptonBorderEdge37)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Padding = New System.Windows.Forms.Padding(6)
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(900, 601)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem5
        '
        'dGridUnserved
        '
        Me.dGridUnserved.AllowUserToAddRows = False
        Me.dGridUnserved.AllowUserToDeleteRows = False
        Me.dGridUnserved.AllowUserToResizeRows = False
        Me.dGridUnserved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridUnserved.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20})
        Me.dGridUnserved.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridUnserved.Location = New System.Drawing.Point(7, 94)
        Me.dGridUnserved.Name = "dGridUnserved"
        Me.dGridUnserved.ReadOnly = True
        Me.dGridUnserved.RowHeadersWidth = 25
        Me.dGridUnserved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridUnserved.Size = New System.Drawing.Size(886, 480)
        Me.dGridUnserved.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridUnserved.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridUnserved.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridUnserved.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridUnserved.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridUnserved.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridUnserved.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridUnserved.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridUnserved.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridUnserved.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridUnserved.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridUnserved.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridUnserved.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridUnserved.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridUnserved.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridUnserved.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridUnserved.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridUnserved.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridUnserved.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridUnserved.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridUnserved.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridUnserved.TabIndex = 59
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn14.HeaderText = "Defendant #"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 101
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn15.HeaderText = "File #"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 64
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn16.HeaderText = "Given Names"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 102
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn17.HeaderText = "Principal"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 80
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn18.HeaderText = "Debits"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 69
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn19.HeaderText = "Credits"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 72
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn20.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 76
        '
        'Bar9
        '
        Me.Bar9.AntiAlias = True
        Me.Bar9.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar9.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar9.IsMaximized = False
        Me.Bar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.lblNumberUnserved, Me.LabelItem5, Me.lblUnservedPrincipal, Me.LabelItem4, Me.lblUnservedBalance})
        Me.Bar9.Location = New System.Drawing.Point(7, 574)
        Me.Bar9.Name = "Bar9"
        Me.Bar9.PaddingLeft = 3
        Me.Bar9.PaddingRight = 3
        Me.Bar9.RoundCorners = False
        Me.Bar9.Size = New System.Drawing.Size(886, 20)
        Me.Bar9.Stretch = True
        Me.Bar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar9.TabIndex = 8
        Me.Bar9.TabStop = False
        Me.Bar9.Text = "Bar9"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingLeft = 3
        Me.LabelItem3.PaddingRight = 3
        Me.LabelItem3.Stretch = True
        Me.LabelItem3.Text = "Total records processed "
        '
        'lblNumberUnserved
        '
        Me.lblNumberUnserved.Name = "lblNumberUnserved"
        Me.lblNumberUnserved.PaddingLeft = 3
        Me.lblNumberUnserved.PaddingRight = 3
        Me.lblNumberUnserved.Text = "0"
        '
        'LabelItem5
        '
        Me.LabelItem5.BeginGroup = True
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingLeft = 3
        Me.LabelItem5.PaddingRight = 3
        Me.LabelItem5.Text = "Principal"
        '
        'lblUnservedPrincipal
        '
        Me.lblUnservedPrincipal.Name = "lblUnservedPrincipal"
        Me.lblUnservedPrincipal.PaddingLeft = 6
        Me.lblUnservedPrincipal.PaddingRight = 6
        Me.lblUnservedPrincipal.Text = "0.00"
        '
        'LabelItem4
        '
        Me.LabelItem4.BeginGroup = True
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 3
        Me.LabelItem4.PaddingRight = 3
        Me.LabelItem4.Text = "Balance"
        '
        'lblUnservedBalance
        '
        Me.lblUnservedBalance.Name = "lblUnservedBalance"
        Me.lblUnservedBalance.PaddingLeft = 6
        Me.lblUnservedBalance.PaddingRight = 6
        Me.lblUnservedBalance.Text = "0.00"
        '
        'KryptonPanel15
        '
        Me.KryptonPanel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel15.Controls.Add(Me.lblUnservedClients)
        Me.KryptonPanel15.Controls.Add(Me.cboUnservedClients)
        Me.KryptonPanel15.Controls.Add(Me.KryptonPanel18)
        Me.KryptonPanel15.Controls.Add(Me.KryptonBorderEdge45)
        Me.KryptonPanel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel15.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel15.Location = New System.Drawing.Point(7, 33)
        Me.KryptonPanel15.Name = "KryptonPanel15"
        Me.KryptonPanel15.Size = New System.Drawing.Size(886, 61)
        Me.KryptonPanel15.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel15.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel15.TabIndex = 7
        '
        'lblUnservedClients
        '
        Me.lblUnservedClients.AutoSize = True
        Me.lblUnservedClients.BackColor = System.Drawing.Color.White
        Me.lblUnservedClients.ForeColor = System.Drawing.Color.Black
        Me.lblUnservedClients.Location = New System.Drawing.Point(382, 3)
        Me.lblUnservedClients.Name = "lblUnservedClients"
        Me.lblUnservedClients.Size = New System.Drawing.Size(13, 13)
        Me.lblUnservedClients.TabIndex = 41
        Me.lblUnservedClients.Text = "0"
        Me.lblUnservedClients.Visible = False
        '
        'cboUnservedClients
        '
        Me.cboUnservedClients.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboUnservedClients.ArrowColor = System.Drawing.Color.Black
        Me.cboUnservedClients.BindedControl = Nothing
        Me.cboUnservedClients.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboUnservedClients.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUnservedClients.ColumnNum = 1
        Me.cboUnservedClients.ColumnWidth = "121"
        Me.cboUnservedClients.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboUnservedClients.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboUnservedClients.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboUnservedClients.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboUnservedClients.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboUnservedClients.DisplayMember = "Text"
        Me.cboUnservedClients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboUnservedClients.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboUnservedClients.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboUnservedClients.DropDownForeColor = System.Drawing.Color.Black
        Me.cboUnservedClients.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboUnservedClients.DropDownWidth = 141
        Me.cboUnservedClients.GridLineColor = System.Drawing.Color.LightGray
        Me.cboUnservedClients.GridLineHorizontal = False
        Me.cboUnservedClients.GridLineVertical = False
        Me.cboUnservedClients.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboUnservedClients.HighlightBorderOnMouseEvents = True
        Me.cboUnservedClients.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboUnservedClients.Location = New System.Drawing.Point(83, 21)
        Me.cboUnservedClients.ManagingFastMouseMoving = True
        Me.cboUnservedClients.ManagingFastMouseMovingInterval = 30
        Me.cboUnservedClients.Name = "cboUnservedClients"
        Me.cboUnservedClients.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboUnservedClients.SelectedItem = Nothing
        Me.cboUnservedClients.SelectedValue = Nothing
        Me.cboUnservedClients.Size = New System.Drawing.Size(330, 21)
        Me.cboUnservedClients.TabIndex = 40
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.KryptonLabel13)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge44)
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(16, 20)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel18.TabIndex = 39
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.BackColor = System.Drawing.Color.White
        Me.KryptonLabel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel13.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel13.TabIndex = 18
        Me.KryptonLabel13.Values.Text = "Portfolio"
        '
        'KryptonBorderEdge44
        '
        Me.KryptonBorderEdge44.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge44.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge44.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge44.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge44.Name = "KryptonBorderEdge44"
        Me.KryptonBorderEdge44.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge44.Text = "KryptonBorderEdge44"
        '
        'KryptonBorderEdge45
        '
        Me.KryptonBorderEdge45.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge45.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge45.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge45.Location = New System.Drawing.Point(0, 60)
        Me.KryptonBorderEdge45.Name = "KryptonBorderEdge45"
        Me.KryptonBorderEdge45.Size = New System.Drawing.Size(886, 1)
        Me.KryptonBorderEdge45.Text = "KryptonBorderEdge45"
        '
        'KryptonBorderEdge41
        '
        Me.KryptonBorderEdge41.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge41.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge41.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge41.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge41.Name = "KryptonBorderEdge41"
        Me.KryptonBorderEdge41.Size = New System.Drawing.Size(886, 1)
        Me.KryptonBorderEdge41.Text = "KryptonBorderEdge41"
        '
        'Bar8
        '
        Me.Bar8.AntiAlias = True
        Me.Bar8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar8.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar8.IsMaximized = False
        Me.Bar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnRunUnserved, Me.btnPrintUnserved})
        Me.Bar8.Location = New System.Drawing.Point(7, 7)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.RoundCorners = False
        Me.Bar8.Size = New System.Drawing.Size(886, 25)
        Me.Bar8.Stretch = True
        Me.Bar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar8.TabIndex = 5
        Me.Bar8.TabStop = False
        Me.Bar8.Text = "Bar8"
        '
        'btnRunUnserved
        '
        Me.btnRunUnserved.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRunUnserved.Image = CType(resources.GetObject("btnRunUnserved.Image"), System.Drawing.Image)
        Me.btnRunUnserved.Name = "btnRunUnserved"
        Me.btnRunUnserved.Text = "Run"
        '
        'btnPrintUnserved
        '
        Me.btnPrintUnserved.BeginGroup = True
        Me.btnPrintUnserved.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintUnserved.Image = CType(resources.GetObject("btnPrintUnserved.Image"), System.Drawing.Image)
        Me.btnPrintUnserved.Name = "btnPrintUnserved"
        Me.btnPrintUnserved.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintUnserved.Text = "Print"
        '
        'KryptonBorderEdge40
        '
        Me.KryptonBorderEdge40.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge40.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge40.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge40.Location = New System.Drawing.Point(893, 7)
        Me.KryptonBorderEdge40.Name = "KryptonBorderEdge40"
        Me.KryptonBorderEdge40.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge40.Size = New System.Drawing.Size(1, 587)
        Me.KryptonBorderEdge40.Text = "KryptonBorderEdge40"
        '
        'KryptonBorderEdge39
        '
        Me.KryptonBorderEdge39.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge39.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge39.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge39.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge39.Name = "KryptonBorderEdge39"
        Me.KryptonBorderEdge39.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge39.Size = New System.Drawing.Size(1, 587)
        Me.KryptonBorderEdge39.Text = "KryptonBorderEdge39"
        '
        'KryptonBorderEdge38
        '
        Me.KryptonBorderEdge38.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge38.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge38.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge38.Location = New System.Drawing.Point(6, 594)
        Me.KryptonBorderEdge38.Name = "KryptonBorderEdge38"
        Me.KryptonBorderEdge38.Size = New System.Drawing.Size(888, 1)
        Me.KryptonBorderEdge38.Text = "KryptonBorderEdge38"
        '
        'KryptonBorderEdge37
        '
        Me.KryptonBorderEdge37.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge37.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge37.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge37.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge37.Name = "KryptonBorderEdge37"
        Me.KryptonBorderEdge37.Size = New System.Drawing.Size(888, 1)
        Me.KryptonBorderEdge37.Text = "KryptonBorderEdge37"
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        Me.SuperTabItem5.Text = "Unserved"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(900, 601)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTooltip1.SetSuperTooltip(Me.SuperTabItem3, New DevComponents.DotNetBar.SuperTooltipInfo("Receipts Analysis", "", "This gives you a report of payments within a given date based on what initiated t" & _
            "he payment e.g. Letter of Demand or visit to debtor from debt tracers", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.SuperTabItem3.Text = "Receipts Analysis"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(900, 601)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        Me.SuperTabItem2.Text = "Process"
        '
        'SideNavPanel3
        '
        Me.SideNavPanel3.Controls.Add(Me.panelEx1)
        Me.SideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel3.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel3.Name = "SideNavPanel3"
        Me.SideNavPanel3.Padding = New System.Windows.Forms.Padding(12)
        Me.SideNavPanel3.Size = New System.Drawing.Size(912, 644)
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
        Me.panelEx1.Size = New System.Drawing.Size(458, 620)
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
        Me.recentDocsItemPane.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrinters, Me.btnLegalStaggings, Me.btnUpgrades, Me.btnPortfolioCosts, Me.btnAllocations, Me.btnPaymentInitiators, Me.btnPaymentDescriptions, Me.btnOrganisation, Me.btnPaymentPlans, Me.btnUnserves})
        Me.recentDocsItemPane.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.recentDocsItemPane.Location = New System.Drawing.Point(12, 35)
        Me.recentDocsItemPane.Name = "recentDocsItemPane"
        Me.recentDocsItemPane.Size = New System.Drawing.Size(434, 573)
        Me.recentDocsItemPane.TabIndex = 1
        '
        'btnPrinters
        '
        Me.btnPrinters.BeginGroup = True
        Me.btnPrinters.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrinters.CommandParameter = ""
        Me.btnPrinters.ForeColor = System.Drawing.Color.Black
        Me.btnPrinters.Image = CType(resources.GetObject("btnPrinters.Image"), System.Drawing.Image)
        Me.btnPrinters.Name = "btnPrinters"
        Me.btnPrinters.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrinters.Symbol = "59565"
        Me.btnPrinters.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPrinters.Text = "Printers<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Define default printer</font>"
        '
        'btnLegalStaggings
        '
        Me.btnLegalStaggings.BeginGroup = True
        Me.btnLegalStaggings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnLegalStaggings.CommandParameter = ""
        Me.btnLegalStaggings.ForeColor = System.Drawing.Color.Black
        Me.btnLegalStaggings.Image = CType(resources.GetObject("btnLegalStaggings.Image"), System.Drawing.Image)
        Me.btnLegalStaggings.Name = "btnLegalStaggings"
        Me.btnLegalStaggings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnLegalStaggings.Symbol = ""
        Me.btnLegalStaggings.SymbolColor = System.Drawing.Color.SlateBlue
        Me.btnLegalStaggings.Text = "Legal Actions and Procedures<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and modify deb" & _
    "t collection actions and procedures in each action</font>"
        '
        'btnUpgrades
        '
        Me.btnUpgrades.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUpgrades.CommandParameter = ""
        Me.btnUpgrades.ForeColor = System.Drawing.Color.Black
        Me.btnUpgrades.Image = CType(resources.GetObject("btnUpgrades.Image"), System.Drawing.Image)
        Me.btnUpgrades.Name = "btnUpgrades"
        Me.btnUpgrades.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnUpgrades.Symbol = "58341"
        Me.btnUpgrades.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnUpgrades.Text = "Stage Upgrade<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Upgrade procedure and action settings from" & _
    " earlier versions</font>"
        '
        'btnPortfolioCosts
        '
        Me.btnPortfolioCosts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPortfolioCosts.CommandParameter = ""
        Me.btnPortfolioCosts.ForeColor = System.Drawing.Color.Black
        Me.btnPortfolioCosts.Image = CType(resources.GetObject("btnPortfolioCosts.Image"), System.Drawing.Image)
        Me.btnPortfolioCosts.Name = "btnPortfolioCosts"
        Me.btnPortfolioCosts.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPortfolioCosts.Symbol = "57895"
        Me.btnPortfolioCosts.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPortfolioCosts.Text = "Portfolio Action Costs<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and maintain action " & _
    "costs by portfolio<br/>These costs will be applied in every action update agains" & _
    "t the debtors</font>"
        '
        'btnAllocations
        '
        Me.btnAllocations.BeginGroup = True
        Me.btnAllocations.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAllocations.CommandParameter = ""
        Me.btnAllocations.ForeColor = System.Drawing.Color.Black
        Me.btnAllocations.Image = CType(resources.GetObject("btnAllocations.Image"), System.Drawing.Image)
        Me.btnAllocations.Name = "btnAllocations"
        Me.btnAllocations.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAllocations.Symbol = "58146"
        Me.btnAllocations.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnAllocations.Text = "Portfolio Allocations<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Assign portfolios to different use" & _
    "rs of the system</font>"
        '
        'btnPaymentInitiators
        '
        Me.btnPaymentInitiators.BeginGroup = True
        Me.btnPaymentInitiators.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPaymentInitiators.CommandParameter = ""
        Me.btnPaymentInitiators.ForeColor = System.Drawing.Color.Black
        Me.btnPaymentInitiators.Image = CType(resources.GetObject("btnPaymentInitiators.Image"), System.Drawing.Image)
        Me.btnPaymentInitiators.Name = "btnPaymentInitiators"
        Me.btnPaymentInitiators.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPaymentInitiators.Symbol = "57699"
        Me.btnPaymentInitiators.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPaymentInitiators.Text = "Payment Initiators<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and update actions that " & _
    "cause debtor to start making payments <br/>towards the debt</font>"
        '
        'btnPaymentDescriptions
        '
        Me.btnPaymentDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPaymentDescriptions.CommandParameter = ""
        Me.btnPaymentDescriptions.ForeColor = System.Drawing.Color.Black
        Me.btnPaymentDescriptions.Image = CType(resources.GetObject("btnPaymentDescriptions.Image"), System.Drawing.Image)
        Me.btnPaymentDescriptions.Name = "btnPaymentDescriptions"
        Me.btnPaymentDescriptions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPaymentDescriptions.Symbol = "57768"
        Me.btnPaymentDescriptions.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPaymentDescriptions.Text = "Payment Descriptions<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and maintain payment d" & _
    "escriptions from which the user will select <br/>when receipting payments</font>" & _
    ""
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
        Me.btnOrganisation.Symbol = ""
        Me.btnOrganisation.SymbolColor = System.Drawing.Color.Red
        Me.btnOrganisation.Text = "Organization Setup<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">View and Maintain Organization Settin" & _
    "gs</font>"
        '
        'btnPaymentPlans
        '
        Me.btnPaymentPlans.BeginGroup = True
        Me.btnPaymentPlans.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPaymentPlans.CommandParameter = ""
        Me.btnPaymentPlans.ForeColor = System.Drawing.Color.Black
        Me.btnPaymentPlans.Image = CType(resources.GetObject("btnPaymentPlans.Image"), System.Drawing.Image)
        Me.btnPaymentPlans.Name = "btnPaymentPlans"
        Me.btnPaymentPlans.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPaymentPlans.Symbol = "57377"
        Me.btnPaymentPlans.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPaymentPlans.Text = "Payment Plan Action Keys<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Define the payment plan action " & _
    "keys for use in the payment plans analysis report</font>"
        '
        'btnUnserves
        '
        Me.btnUnserves.BeginGroup = True
        Me.btnUnserves.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUnserves.CommandParameter = ""
        Me.btnUnserves.ForeColor = System.Drawing.Color.Black
        Me.btnUnserves.Image = CType(resources.GetObject("btnUnserves.Image"), System.Drawing.Image)
        Me.btnUnserves.Name = "btnUnserves"
        Me.btnUnserves.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnUnserves.Symbol = "57377"
        Me.btnUnserves.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnUnserves.Text = "Unserved Action Keys<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Define the unserved action keys for" & _
    " use in the unserved analysis report</font>"
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
        Me.SideNavPanel7.Controls.Add(Me.dGridPortfolio)
        Me.SideNavPanel7.Controls.Add(Me.KryptonPanel1)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge14)
        Me.SideNavPanel7.Controls.Add(Me.Bar2)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge13)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge12)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge11)
        Me.SideNavPanel7.Controls.Add(Me.KryptonBorderEdge10)
        Me.SideNavPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel7.Location = New System.Drawing.Point(94, 31)
        Me.SideNavPanel7.Name = "SideNavPanel7"
        Me.SideNavPanel7.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel7.Size = New System.Drawing.Size(912, 646)
        Me.SideNavPanel7.TabIndex = 29
        Me.SideNavPanel7.Visible = False
        '
        'dGridPortfolio
        '
        Me.dGridPortfolio.AllowUserToAddRows = False
        Me.dGridPortfolio.AllowUserToDeleteRows = False
        Me.dGridPortfolio.AllowUserToResizeRows = False
        Me.dGridPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridPortfolio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dGridPortfolio.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dGridPortfolio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridPortfolio.Location = New System.Drawing.Point(7, 98)
        Me.dGridPortfolio.Name = "dGridPortfolio"
        Me.dGridPortfolio.ReadOnly = True
        Me.dGridPortfolio.RowHeadersVisible = False
        Me.dGridPortfolio.RowHeadersWidth = 25
        Me.dGridPortfolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPortfolio.Size = New System.Drawing.Size(898, 541)
        Me.dGridPortfolio.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridPortfolio.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPortfolio.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPortfolio.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridPortfolio.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridPortfolio.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPortfolio.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPortfolio.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPortfolio.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridPortfolio.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridPortfolio.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPortfolio.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridPortfolio.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridPortfolio.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPortfolio.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPortfolio.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridPortfolio.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridPortfolio.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPortfolio.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPortfolio.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPortfolio.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPortfolio.TabIndex = 51
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Client #"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 76
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Client Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 98
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Date Engaged"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 109
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 77
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Contact Person"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 114
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Contact No."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 97
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Contact Email Address"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel1.Controls.Add(Me.cboPortfolioStatus)
        Me.KryptonPanel1.Controls.Add(Me.txtPortfolioSearchString)
        Me.KryptonPanel1.Controls.Add(Me.cboPortfolioSearchBy)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(7, 36)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(898, 62)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 34
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 61)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(434, 19)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(104, 25)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 24
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.White
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(104, 24)
        Me.KryptonLabel4.TabIndex = 18
        Me.KryptonLabel4.Values.Text = "Filter by status"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(0, 24)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(104, 1)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'cboPortfolioStatus
        '
        Me.cboPortfolioStatus.BackColor = System.Drawing.Color.White
        Me.cboPortfolioStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortfolioStatus.DropDownWidth = 163
        Me.cboPortfolioStatus.ForeColor = System.Drawing.Color.Black
        Me.cboPortfolioStatus.Items.AddRange(New Object() {"ACTIVE", "INACTIVE", "ALL"})
        Me.cboPortfolioStatus.Location = New System.Drawing.Point(540, 23)
        Me.cboPortfolioStatus.Name = "cboPortfolioStatus"
        Me.cboPortfolioStatus.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboPortfolioStatus.Size = New System.Drawing.Size(119, 21)
        Me.cboPortfolioStatus.TabIndex = 23
        '
        'txtPortfolioSearchString
        '
        Me.txtPortfolioSearchString.BackColor = System.Drawing.Color.White
        Me.txtPortfolioSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtPortfolioSearchString.Location = New System.Drawing.Point(137, 24)
        Me.txtPortfolioSearchString.Name = "txtPortfolioSearchString"
        Me.txtPortfolioSearchString.Size = New System.Drawing.Size(291, 20)
        Me.txtPortfolioSearchString.TabIndex = 20
        '
        'cboPortfolioSearchBy
        '
        Me.cboPortfolioSearchBy.BackColor = System.Drawing.Color.White
        Me.cboPortfolioSearchBy.DropDownWidth = 163
        Me.cboPortfolioSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboPortfolioSearchBy.Items.AddRange(New Object() {"Client Number", "Client Name"})
        Me.cboPortfolioSearchBy.Location = New System.Drawing.Point(12, 23)
        Me.cboPortfolioSearchBy.Name = "cboPortfolioSearchBy"
        Me.cboPortfolioSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboPortfolioSearchBy.Size = New System.Drawing.Size(119, 21)
        Me.cboPortfolioSearchBy.TabIndex = 21
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(7, 35)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(898, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewPortfolio, Me.btnEditPortfolio, Me.btnDeletePortfolio, Me.btnDeactivateOnePortfolio, Me.btnExportPortfolio, Me.btnPrintPortfolio, Me.btnRefreshPortfolio})
        Me.Bar2.Location = New System.Drawing.Point(7, 7)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(898, 28)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 23
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnNewPortfolio
        '
        Me.btnNewPortfolio.Image = CType(resources.GetObject("btnNewPortfolio.Image"), System.Drawing.Image)
        Me.btnNewPortfolio.Name = "btnNewPortfolio"
        Me.btnNewPortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewPortfolio.Text = "ButtonItem1"
        '
        'btnEditPortfolio
        '
        Me.btnEditPortfolio.Image = CType(resources.GetObject("btnEditPortfolio.Image"), System.Drawing.Image)
        Me.btnEditPortfolio.Name = "btnEditPortfolio"
        Me.btnEditPortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditPortfolio.Text = "ButtonItem2"
        '
        'btnDeletePortfolio
        '
        Me.btnDeletePortfolio.BeginGroup = True
        Me.btnDeletePortfolio.Image = CType(resources.GetObject("btnDeletePortfolio.Image"), System.Drawing.Image)
        Me.btnDeletePortfolio.Name = "btnDeletePortfolio"
        Me.btnDeletePortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeletePortfolio.Text = "ButtonItem3"
        '
        'btnDeactivateOnePortfolio
        '
        Me.btnDeactivateOnePortfolio.BeginGroup = True
        Me.btnDeactivateOnePortfolio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDeactivateOnePortfolio.Name = "btnDeactivateOnePortfolio"
        Me.btnDeactivateOnePortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeactivateOnePortfolio.Symbol = ""
        Me.btnDeactivateOnePortfolio.SymbolColor = System.Drawing.Color.Firebrick
        Me.btnDeactivateOnePortfolio.SymbolSize = 16.0!
        Me.btnDeactivateOnePortfolio.Text = "&Hold"
        '
        'btnExportPortfolio
        '
        Me.btnExportPortfolio.BeginGroup = True
        Me.btnExportPortfolio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportPortfolio.Image = CType(resources.GetObject("btnExportPortfolio.Image"), System.Drawing.Image)
        Me.btnExportPortfolio.Name = "btnExportPortfolio"
        Me.btnExportPortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportPortfolio.Text = "Export"
        '
        'btnPrintPortfolio
        '
        Me.btnPrintPortfolio.BeginGroup = True
        Me.btnPrintPortfolio.Image = CType(resources.GetObject("btnPrintPortfolio.Image"), System.Drawing.Image)
        Me.btnPrintPortfolio.Name = "btnPrintPortfolio"
        Me.btnPrintPortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintPortfolio.Text = "ButtonItem6"
        '
        'btnRefreshPortfolio
        '
        Me.btnRefreshPortfolio.Image = CType(resources.GetObject("btnRefreshPortfolio.Image"), System.Drawing.Image)
        Me.btnRefreshPortfolio.Name = "btnRefreshPortfolio"
        Me.btnRefreshPortfolio.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshPortfolio.Text = "ButtonItem7"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(905, 7)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(1, 632)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(1, 632)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(6, 639)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(900, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(900, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
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
        'SideNavItem2
        '
        Me.SideNavItem2.Name = "SideNavItem2"
        Me.SideNavItem2.Panel = Me.SideNavPanel1
        Me.SideNavItem2.Symbol = ""
        Me.SideNavItem2.Text = "Home"
        '
        'SideNavItem8
        '
        Me.SideNavItem8.Name = "SideNavItem8"
        Me.SideNavItem8.Panel = Me.SideNavPanel7
        Me.SideNavItem8.Symbol = "58375"
        Me.SideNavItem8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem8.Text = "Portfolios"
        '
        'SideNavItem3
        '
        Me.SideNavItem3.Checked = True
        Me.SideNavItem3.Name = "SideNavItem3"
        Me.SideNavItem3.Panel = Me.SideNavPanel2
        Me.SideNavItem3.Symbol = "57532"
        Me.SideNavItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem3.Text = "Analysis"
        '
        'SideNavItem7
        '
        Me.SideNavItem7.Name = "SideNavItem7"
        Me.SideNavItem7.Panel = Me.SideNavPanel6
        Me.SideNavItem7.Symbol = "57895"
        Me.SideNavItem7.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem7.Text = "Receipts"
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
        Me.SideNavItem6.Symbol = ""
        Me.SideNavItem6.Text = "Reports"
        '
        'SideNavItem5
        '
        Me.SideNavItem5.Name = "SideNavItem5"
        Me.SideNavItem5.Panel = Me.SideNavPanel4
        Me.SideNavItem5.Symbol = "57772"
        Me.SideNavItem5.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem5.Text = "Utilities"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Employee No"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Last Name"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "First Name"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Other Names"
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'frmDebtCollectorMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BackgroundImageUnderCaption = True
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDebtCollectorMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debt Collection Edge 8.0"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel1.PerformLayout()
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.Panel2.PerformLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expandablePanel1.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel6.ResumeLayout(False)
        Me.SideNavPanel6.PerformLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl2.ResumeLayout(False)
        Me.SuperTabControlPanel6.ResumeLayout(False)
        Me.SuperTabControlPanel6.PerformLayout()
        CType(Me.dGridReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.cboReceiptSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel7.ResumeLayout(False)
        Me.SuperTabControlPanel7.PerformLayout()
        CType(Me.dGridAllData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip5.ResumeLayout(False)
        Me.StatusStrip5.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        Me.KryptonPanel19.PerformLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel20.ResumeLayout(False)
        Me.KryptonPanel20.PerformLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel21.ResumeLayout(False)
        Me.KryptonPanel21.PerformLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel22.ResumeLayout(False)
        Me.KryptonPanel22.PerformLayout()
        CType(Me.Bar12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel4.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.SideNavPanel2.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.pnlTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTree.ResumeLayout(False)
        CType(Me.TreeListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel4.PerformLayout()
        CType(Me.dGridpp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        Me.KryptonPanel16.PerformLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel17.ResumeLayout(False)
        Me.KryptonPanel17.PerformLayout()
        CType(Me.Bar11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.SuperTabControlPanel5.PerformLayout()
        CType(Me.dGridUnserved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel15.ResumeLayout(False)
        Me.KryptonPanel15.PerformLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel3.ResumeLayout(False)
        Me.panelEx1.ResumeLayout(False)
        Me.SideNavPanel7.ResumeLayout(False)
        Me.SideNavPanel7.PerformLayout()
        CType(Me.dGridPortfolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.cboPortfolioStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPortfolioSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavPanel3 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem3 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem4 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents lblClientId As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboClients As MTGCComboBox
    Friend WithEvents btnFindNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnFind As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkDisable As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents btnPlaceOnHold As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnActions As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPayments As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PaymentPlansToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents panelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents recentDocsItemPane As DevComponents.DotNetBar.ItemPanel
    Private WithEvents btnPrinters As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnLegalStaggings As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnUpgrades As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPortfolioCosts As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnAllocations As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPaymentDescriptions As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnOrganisation As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SideNavPanel4 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem5 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavPanel5 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem6 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavPanel6 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem7 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavPanel7 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem8 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewPortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditPortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeletePortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeactivateOnePortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportPortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintPortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshPortfolio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboPortfolioStatus As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtPortfolioSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboPortfolioSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridPortfolio As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Protected WithEvents StyleManager2 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnRefreshAnalysis As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cboPortfolioAnalysis As MTGCComboBox
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents lblClientIdAnalysis As System.Windows.Forms.Label
    Friend WithEvents cboDateFilter As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpDateToAnalysis As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpDateFromAnalysis As System.Windows.Forms.DateTimePicker
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents TreeListView1 As BrightIdeasSoftware.TreeListView
    Friend WithEvents splitMain As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents tvStages As System.Windows.Forms.TreeView
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chkSelectAll As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents Label250 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotals As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblAmountTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblSelected As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalSelected As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnSummaryReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCurrentList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnLegalExpenses As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCurrentSelectionLegalReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnStatements As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblActiveAction As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCount As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnSelectHighlighted As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintPortfolioAnalysis As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pnlTree As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents btnPaymentInitiators As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge31 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge30 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge32 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Private WithEvents btnPaymentPlans As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnUnserves As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents KryptonBorderEdge41 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar8 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnRunUnserved As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintUnserved As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge40 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge39 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge38 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge37 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel15 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblUnservedClients As System.Windows.Forms.Label
    Friend WithEvents cboUnservedClients As MTGCComboBox
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge44 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge45 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar9 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridUnserved As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNumberUnserved As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblUnservedPrincipal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblUnservedBalance As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge47 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge46 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge43 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge42 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge48 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar10 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnRunpp As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblClientspp As System.Windows.Forms.Label
    Friend WithEvents cboClientspp As MTGCComboBox
    Friend WithEvents KryptonPanel17 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge49 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge50 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar11 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblPPcnt As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblPPprincipal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblPPBalance As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridpp As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Private WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Private WithEvents btnImportBranchTransactions As DevComponents.DotNetBar.ButtonItem
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnHistory As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pb1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents btnAnalysisDetails As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnExportActions As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControl2 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem6 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents dGridReceipts As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnReceiptFind As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnReceiptFindNext As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge33 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboReceiptSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge34 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboReceiptClients As MTGCComboBox
    Friend WithEvents lblReceiptClientId As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge35 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge36 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtReceiptSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonBorderEdge55 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReceipt As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge54 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge53 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge52 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge51 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem7 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge59 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge58 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge57 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge56 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge60 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar12 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReceiptDetails As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintReceiptsList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtReceiptPortfolioId As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonBorderEdge61 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel20 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge62 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel21 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge63 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndToReceipts As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartFromReceipts As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel22 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel15 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge64 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnGoReceipts As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge65 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents StatusStrip5 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalPaymentReceipts As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dGridAllData As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents cboReceiptsPortfolio As MTGCComboBox
End Class
