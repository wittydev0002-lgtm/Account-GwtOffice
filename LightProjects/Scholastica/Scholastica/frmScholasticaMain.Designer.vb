<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScholasticaMain
    Inherits DevComponents.DotNetBar.Metro.MetroForm ' ComponentFactory.Krypton.Toolkit.KryptonForm

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScholasticaMain))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Balance by Sponsor", 5, 5)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Students by Sponsor", 5, 5)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Students by Type", 5, 5)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General Reports", 9, 9, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.splitMain = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.dGridStatements = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dGridStudents = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.tvClasses = New System.Windows.Forms.TreeView()
        Me.imageListStudents = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.lblActiveClass = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalSelected = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblCurrentClass = New System.Windows.Forms.Label()
        Me.chkActiveSearch = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnFind = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNewStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTerminateStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnActivities = New DevComponents.DotNetBar.ButtonItem()
        Me.btnReceiptSelected = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBillSelectedStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAdhocBilling = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTerminateSelectedStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelectedStudentStatement = New DevComponents.DotNetBar.ButtonItem()
        Me.btnInvoiceSelectedStudent = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnMasterImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTransactionImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportAll = New DevComponents.DotNetBar.ButtonItem()
        Me.btnManageStudents = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTerminate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnMassTerminate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintStudents = New DevComponents.DotNetBar.ButtonItem()
        Me.btnStudentsListing = New DevComponents.DotNetBar.ButtonItem()
        Me.btnStudentStatement = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllStatements = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshStudents = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.cboGender = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.cboType = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel3 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.splitOwings = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.dGridOwings = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.optUnselectAll = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonBorderEdge48 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge49 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge46 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.tvClasses2 = New System.Windows.Forms.TreeView()
        Me.KryptonBorderEdge47 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar6 = New DevComponents.DotNetBar.Bar()
        Me.lblActiveClassOwings = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalOwings = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalRecords = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.txtAmountFrom = New Numberbox.Numberbox()
        Me.txtAmountTo = New Numberbox.Numberbox()
        Me.btnTakeonBalances = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintListOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectedStatementOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAllStatementsOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectedReminder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAllReminders = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintForHandOver = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBilling = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintTermInvoices = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrior = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSmsReminderOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.btnAmtFilter = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel5 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridReceipts = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge35 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge34 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpStartFrom = New System.Windows.Forms.DateTimePicker()
        Me.dpEndTo = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge33 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnGo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge32 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar8 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblAllReceiptAmt = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge31 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar7 = New DevComponents.DotNetBar.Bar()
        Me.btnPayments = New DevComponents.DotNetBar.ButtonItem()
        Me.btnReceiptDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintReceiptDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshReceipts = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.lblReceiptTotalSelected = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge30 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel4 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.panelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.recentDocsItemPane = New DevComponents.DotNetBar.ItemPanel()
        Me.btnSchoolClassification = New DevComponents.DotNetBar.ButtonItem()
        Me.btnNewStudentNumberParameters = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSubjects = New DevComponents.DotNetBar.ButtonItem()
        Me.btnClasses = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFees = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExtraPaymentDescriptions = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPaymentAllocations = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSubjectsPaymentsTable = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrivateSchoolFees = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBilliableMaximum = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSponsors = New DevComponents.DotNetBar.ButtonItem()
        Me.btnYearEndProcedures = New DevComponents.DotNetBar.ButtonItem()
        Me.labelX1 = New DevComponents.DotNetBar.LabelX()
        Me.KryptonBorderEdge39 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge38 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge37 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge36 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel6 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge44 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.pnlPreview = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridPreview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.labelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dGridTransactions = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.integerInput1 = New DevComponents.Editors.IntegerInput()
        Me.labelX4 = New DevComponents.DotNetBar.LabelX()
        Me.btnPrintPreview = New DevComponents.DotNetBar.ButtonX()
        Me.KryptonBorderEdge45 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar16 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge50 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge43 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge42 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge41 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge40 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.dGridSchoolStaff = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.ButtonSpecAny1 = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonComboBox1 = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnNewStaff = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditStaff = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteStaff = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintStaffList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshStaff = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Receipts = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem3 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem4 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem5 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavItem6 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ProgressBar1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.pdoc = New System.Drawing.Printing.PrintDocument()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.pStats = New System.Drawing.Printing.PrintDocument()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        CType(Me.dGridStatements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expandablePanel1.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel3.SuspendLayout()
        CType(Me.splitOwings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitOwings.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitOwings.Panel1.SuspendLayout()
        CType(Me.splitOwings.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitOwings.Panel2.SuspendLayout()
        Me.splitOwings.SuspendLayout()
        CType(Me.dGridOwings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar5.SuspendLayout()
        Me.SideNavPanel5.SuspendLayout()
        CType(Me.dGridReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNavPanel4.SuspendLayout()
        Me.panelEx1.SuspendLayout()
        Me.SideNavPanel6.SuspendLayout()
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
        Me.SideNavPanel2.SuspendLayout()
        CType(Me.dGridSchoolStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.SideNav1)
        Me.KryptonPanel.Controls.Add(Me.Bar1)
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
        Me.SideNav1.Controls.Add(Me.SideNavPanel3)
        Me.SideNav1.Controls.Add(Me.SideNavPanel5)
        Me.SideNav1.Controls.Add(Me.SideNavPanel4)
        Me.SideNav1.Controls.Add(Me.SideNavPanel6)
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem2, Me.Receipts, Me.SideNavItem3, Me.SideNavItem4, Me.SideNavItem5, Me.SideNavItem6})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(1007, 674)
        Me.SideNav1.TabIndex = 2
        Me.SideNav1.Text = "SideNav1"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.splitMain)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.SideNavPanel1.Controls.Add(Me.Bar4)
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.SideNavPanel1.Controls.Add(Me.Bar2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(97, 31)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel1.Size = New System.Drawing.Size(909, 642)
        Me.SideNavPanel1.TabIndex = 2
        '
        'splitMain
        '
        Me.splitMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.splitMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Location = New System.Drawing.Point(7, 81)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.splitMain.Panel1.Controls.Add(Me.dGridStatements)
        Me.splitMain.Panel1.Controls.Add(Me.dGridStudents)
        Me.splitMain.Panel1.Controls.Add(Me.KryptonBorderEdge26)
        Me.splitMain.Panel1.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.splitMain.Panel2.Controls.Add(Me.expandablePanel1)
        Me.splitMain.Panel2.Controls.Add(Me.KryptonBorderEdge27)
        Me.splitMain.Panel2.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.splitMain.Size = New System.Drawing.Size(895, 534)
        Me.splitMain.SplitterDistance = 701
        Me.splitMain.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.StateCommon.Separator.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.StateCommon.Separator.Back.Color2 = System.Drawing.Color.Transparent
        Me.splitMain.TabIndex = 57
        '
        'dGridStatements
        '
        Me.dGridStatements.AllowUserToAddRows = False
        Me.dGridStatements.AllowUserToDeleteRows = False
        Me.dGridStatements.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridStatements.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridStatements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Column12, Me.Column13})
        Me.dGridStatements.Location = New System.Drawing.Point(141, 219)
        Me.dGridStatements.Name = "dGridStatements"
        Me.dGridStatements.ReadOnly = True
        Me.dGridStatements.RowHeadersWidth = 25
        Me.dGridStatements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridStatements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridStatements.Size = New System.Drawing.Size(423, 96)
        Me.dGridStatements.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridStatements.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridStatements.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dGridStatements.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridStatements.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridStatements.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridStatements.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dGridStatements.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridStatements.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridStatements.TabIndex = 166
        Me.dGridStatements.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 41
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 76
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ref #"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 44
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn5.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'Column12
        '
        Me.Column12.HeaderText = "Remarks"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "TID"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'dGridStudents
        '
        Me.dGridStudents.AllowUserToAddRows = False
        Me.dGridStudents.AllowUserToDeleteRows = False
        Me.dGridStudents.AllowUserToResizeRows = False
        Me.dGridStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridStudents.Location = New System.Drawing.Point(0, 0)
        Me.dGridStudents.Name = "dGridStudents"
        Me.dGridStudents.ReadOnly = True
        Me.dGridStudents.RowHeadersVisible = False
        Me.dGridStudents.RowHeadersWidth = 25
        Me.dGridStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridStudents.Size = New System.Drawing.Size(700, 534)
        Me.dGridStudents.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridStudents.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridStudents.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridStudents.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridStudents.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridStudents.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridStudents.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridStudents.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridStudents.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridStudents.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridStudents.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridStudents.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridStudents.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridStudents.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridStudents.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridStudents.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridStudents.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridStudents.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridStudents.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridStudents.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridStudents.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridStudents.TabIndex = 60
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(700, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 534)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'expandablePanel1
        '
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.tvClasses)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(1, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(188, 534)
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
        Me.expandablePanel1.TitleText = "Classes"
        '
        'tvClasses
        '
        Me.tvClasses.BackColor = System.Drawing.Color.White
        Me.tvClasses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvClasses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvClasses.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvClasses.ForeColor = System.Drawing.Color.Black
        Me.tvClasses.ImageIndex = 5
        Me.tvClasses.ImageList = Me.imageListStudents
        Me.tvClasses.Location = New System.Drawing.Point(0, 26)
        Me.tvClasses.Name = "tvClasses"
        Me.tvClasses.SelectedImageIndex = 3
        Me.tvClasses.Size = New System.Drawing.Size(188, 508)
        Me.tvClasses.TabIndex = 4
        '
        'imageListStudents
        '
        Me.imageListStudents.ImageStream = CType(resources.GetObject("imageListStudents.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageListStudents.TransparentColor = System.Drawing.Color.Transparent
        Me.imageListStudents.Images.SetKeyName(0, "Folder.ico")
        Me.imageListStudents.Images.SetKeyName(1, "calendar.png")
        Me.imageListStudents.Images.SetKeyName(2, "user2.png")
        Me.imageListStudents.Images.SetKeyName(3, "dude1.png")
        Me.imageListStudents.Images.SetKeyName(4, "businessman2.png")
        Me.imageListStudents.Images.SetKeyName(5, "TableSmall.png")
        Me.imageListStudents.Images.SetKeyName(6, "41.png")
        Me.imageListStudents.Images.SetKeyName(7, "136.png")
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge27.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(1, 534)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(7, 615)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblActiveClass, Me.LabelItem3, Me.lblTotalSelected})
        Me.Bar4.Location = New System.Drawing.Point(7, 616)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.PaddingBottom = 0
        Me.Bar4.PaddingLeft = 3
        Me.Bar4.PaddingRight = 3
        Me.Bar4.PaddingTop = 0
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(895, 19)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 26
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'lblActiveClass
        '
        Me.lblActiveClass.Name = "lblActiveClass"
        Me.lblActiveClass.PaddingLeft = 6
        Me.lblActiveClass.PaddingRight = 6
        Me.lblActiveClass.Stretch = True
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = "Total"
        Me.LabelItem3.Width = 150
        '
        'lblTotalSelected
        '
        Me.lblTotalSelected.BeginGroup = True
        Me.lblTotalSelected.Name = "lblTotalSelected"
        Me.lblTotalSelected.PaddingBottom = 1
        Me.lblTotalSelected.PaddingLeft = 3
        Me.lblTotalSelected.PaddingRight = 3
        Me.lblTotalSelected.PaddingTop = 1
        Me.lblTotalSelected.Text = "0.00"
        Me.lblTotalSelected.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblTotalSelected.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.lblCurrentClass)
        Me.KryptonPanel2.Controls.Add(Me.chkActiveSearch)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel2.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel2.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(7, 36)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(895, 45)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel2.TabIndex = 25
        '
        'lblCurrentClass
        '
        Me.lblCurrentClass.AutoSize = True
        Me.lblCurrentClass.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCurrentClass.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentClass.Location = New System.Drawing.Point(683, 16)
        Me.lblCurrentClass.Name = "lblCurrentClass"
        Me.lblCurrentClass.Size = New System.Drawing.Size(26, 13)
        Me.lblCurrentClass.TabIndex = 164
        Me.lblCurrentClass.Text = "ALL"
        Me.lblCurrentClass.Visible = False
        '
        'chkActiveSearch
        '
        Me.chkActiveSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkActiveSearch.ForeColor = System.Drawing.Color.Black
        Me.chkActiveSearch.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkActiveSearch.Location = New System.Drawing.Point(572, 12)
        Me.chkActiveSearch.Name = "chkActiveSearch"
        Me.chkActiveSearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003
        Me.chkActiveSearch.Size = New System.Drawing.Size(95, 22)
        Me.chkActiveSearch.TabIndex = 163
        Me.chkActiveSearch.Text = "Active serach"
        Me.chkActiveSearch.Values.Text = "Active serach"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(26, 12)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 162
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel2.TabIndex = 148
        Me.KryptonLabel2.Values.Text = "Search by"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(280, 12)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 161
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel3.TabIndex = 148
        Me.KryptonLabel3.Values.Text = "Search for"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSearchString.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnFind})
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(357, 10)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(205, 24)
        Me.txtSearchString.TabIndex = 159
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl
        Me.btnFind.Text = "Find"
        Me.btnFind.UniqueName = "3D638EA06E7B4A035DBF6E67BA01E8F6"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboSearchBy.Items.AddRange(New Object() {"--All--", "Class", "First Name", "Last Name", "Student Number"})
        Me.cboSearchBy.Location = New System.Drawing.Point(103, 13)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchBy.Size = New System.Drawing.Size(168, 21)
        Me.cboSearchBy.Sorted = True
        Me.cboSearchBy.TabIndex = 160
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 44)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(7, 35)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewStudent, Me.btnEditStudent, Me.btnTerminateStudent, Me.btnDeleteStudent, Me.btnActivities, Me.btnImport, Me.btnManageStudents, Me.btnPrintStudents, Me.btnRefreshStudents, Me.LabelItem2, Me.cboGender, Me.LabelItem9, Me.cboType})
        Me.Bar2.Location = New System.Drawing.Point(7, 7)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(895, 28)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 23
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnNewStudent
        '
        Me.btnNewStudent.Image = CType(resources.GetObject("btnNewStudent.Image"), System.Drawing.Image)
        Me.btnNewStudent.Name = "btnNewStudent"
        Me.btnNewStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewStudent.Text = "ButtonItem1"
        '
        'btnEditStudent
        '
        Me.btnEditStudent.Image = CType(resources.GetObject("btnEditStudent.Image"), System.Drawing.Image)
        Me.btnEditStudent.Name = "btnEditStudent"
        Me.btnEditStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditStudent.Text = "ButtonItem2"
        '
        'btnTerminateStudent
        '
        Me.btnTerminateStudent.BeginGroup = True
        Me.btnTerminateStudent.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTerminateStudent.Image = CType(resources.GetObject("btnTerminateStudent.Image"), System.Drawing.Image)
        Me.btnTerminateStudent.Name = "btnTerminateStudent"
        Me.btnTerminateStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTerminateStudent.Text = "Terminate"
        '
        'btnDeleteStudent
        '
        Me.btnDeleteStudent.BeginGroup = True
        Me.btnDeleteStudent.Image = CType(resources.GetObject("btnDeleteStudent.Image"), System.Drawing.Image)
        Me.btnDeleteStudent.Name = "btnDeleteStudent"
        Me.btnDeleteStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteStudent.Text = "ButtonItem3"
        '
        'btnActivities
        '
        Me.btnActivities.BeginGroup = True
        Me.btnActivities.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnActivities.Image = CType(resources.GetObject("btnActivities.Image"), System.Drawing.Image)
        Me.btnActivities.Name = "btnActivities"
        Me.btnActivities.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnActivities.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReceiptSelected, Me.btnBillSelectedStudent, Me.btnAdhocBilling, Me.btnTerminateSelectedStudent, Me.btnPrintSelectedStudentStatement, Me.btnInvoiceSelectedStudent})
        Me.btnActivities.Text = "&Activities"
        '
        'btnReceiptSelected
        '
        Me.btnReceiptSelected.Name = "btnReceiptSelected"
        Me.btnReceiptSelected.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReceiptSelected.Text = "Receipt Selected Student"
        '
        'btnBillSelectedStudent
        '
        Me.btnBillSelectedStudent.Name = "btnBillSelectedStudent"
        Me.btnBillSelectedStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBillSelectedStudent.Text = "Bill Selected Student"
        '
        'btnAdhocBilling
        '
        Me.btnAdhocBilling.Name = "btnAdhocBilling"
        Me.btnAdhocBilling.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAdhocBilling.Text = "Adhoc and Take-on Billing"
        '
        'btnTerminateSelectedStudent
        '
        Me.btnTerminateSelectedStudent.BeginGroup = True
        Me.btnTerminateSelectedStudent.Name = "btnTerminateSelectedStudent"
        Me.btnTerminateSelectedStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTerminateSelectedStudent.Text = "Terminate Selected Student"
        '
        'btnPrintSelectedStudentStatement
        '
        Me.btnPrintSelectedStudentStatement.BeginGroup = True
        Me.btnPrintSelectedStudentStatement.Name = "btnPrintSelectedStudentStatement"
        Me.btnPrintSelectedStudentStatement.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelectedStudentStatement.Text = "Print Selected Student Statement"
        Me.btnPrintSelectedStudentStatement.Visible = False
        '
        'btnInvoiceSelectedStudent
        '
        Me.btnInvoiceSelectedStudent.BeginGroup = True
        Me.btnInvoiceSelectedStudent.Name = "btnInvoiceSelectedStudent"
        Me.btnInvoiceSelectedStudent.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnInvoiceSelectedStudent.Text = "Invoice Selected Student"
        Me.btnInvoiceSelectedStudent.Visible = False
        '
        'btnImport
        '
        Me.btnImport.BeginGroup = True
        Me.btnImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImport.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnMasterImport, Me.btnTransactionImport, Me.btnImportAll})
        Me.btnImport.Text = "Imports"
        '
        'btnMasterImport
        '
        Me.btnMasterImport.BeginGroup = True
        Me.btnMasterImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnMasterImport.Name = "btnMasterImport"
        Me.btnMasterImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnMasterImport.Text = "Master Import"
        '
        'btnTransactionImport
        '
        Me.btnTransactionImport.BeginGroup = True
        Me.btnTransactionImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTransactionImport.Name = "btnTransactionImport"
        Me.btnTransactionImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTransactionImport.Text = "Transaction Import"
        '
        'btnImportAll
        '
        Me.btnImportAll.BeginGroup = True
        Me.btnImportAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImportAll.Name = "btnImportAll"
        Me.btnImportAll.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImportAll.Text = "Import All"
        '
        'btnManageStudents
        '
        Me.btnManageStudents.BeginGroup = True
        Me.btnManageStudents.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnManageStudents.Image = CType(resources.GetObject("btnManageStudents.Image"), System.Drawing.Image)
        Me.btnManageStudents.Name = "btnManageStudents"
        Me.btnManageStudents.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnManageStudents.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnTerminate, Me.btnMassTerminate})
        Me.btnManageStudents.Text = "Manage"
        '
        'btnTerminate
        '
        Me.btnTerminate.BeginGroup = True
        Me.btnTerminate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTerminate.Name = "btnTerminate"
        Me.btnTerminate.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTerminate.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnTerminate.Text = "De-activate"
        '
        'btnMassTerminate
        '
        Me.btnMassTerminate.BeginGroup = True
        Me.btnMassTerminate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnMassTerminate.Name = "btnMassTerminate"
        Me.btnMassTerminate.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnMassTerminate.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnMassTerminate.Text = "De-activate Enmass"
        '
        'btnPrintStudents
        '
        Me.btnPrintStudents.BeginGroup = True
        Me.btnPrintStudents.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintStudents.Image = CType(resources.GetObject("btnPrintStudents.Image"), System.Drawing.Image)
        Me.btnPrintStudents.Name = "btnPrintStudents"
        Me.btnPrintStudents.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintStudents.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnStudentsListing, Me.btnStudentStatement, Me.btnPrintAllStatements})
        Me.btnPrintStudents.Text = "Print"
        '
        'btnStudentsListing
        '
        Me.btnStudentsListing.BeginGroup = True
        Me.btnStudentsListing.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnStudentsListing.Name = "btnStudentsListing"
        Me.btnStudentsListing.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnStudentsListing.Text = "Selected Students Listing"
        '
        'btnStudentStatement
        '
        Me.btnStudentStatement.BeginGroup = True
        Me.btnStudentStatement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnStudentStatement.Name = "btnStudentStatement"
        Me.btnStudentStatement.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnStudentStatement.Text = "Print Selected Student Statement"
        '
        'btnPrintAllStatements
        '
        Me.btnPrintAllStatements.BeginGroup = True
        Me.btnPrintAllStatements.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintAllStatements.Name = "btnPrintAllStatements"
        Me.btnPrintAllStatements.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintAllStatements.Text = "Print Listed Students Statement"
        '
        'btnRefreshStudents
        '
        Me.btnRefreshStudents.BeginGroup = True
        Me.btnRefreshStudents.Image = CType(resources.GetObject("btnRefreshStudents.Image"), System.Drawing.Image)
        Me.btnRefreshStudents.Name = "btnRefreshStudents"
        Me.btnRefreshStudents.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshStudents.Text = "ButtonItem7"
        '
        'LabelItem2
        '
        Me.LabelItem2.BeginGroup = True
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 12
        Me.LabelItem2.Text = "Gender Filter"
        '
        'cboGender
        '
        Me.cboGender.ComboWidth = 120
        Me.cboGender.DropDownHeight = 106
        Me.cboGender.ItemHeight = 17
        Me.cboGender.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.cboGender.Name = "cboGender"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "All"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Female"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Male"
        '
        'LabelItem9
        '
        Me.LabelItem9.Name = "LabelItem9"
        Me.LabelItem9.PaddingLeft = 6
        Me.LabelItem9.Text = "Type filer "
        '
        'cboType
        '
        Me.cboType.ComboWidth = 100
        Me.cboType.DropDownHeight = 106
        Me.cboType.ItemHeight = 17
        Me.cboType.Items.AddRange(New Object() {Me.ComboItem7, Me.ComboItem8, Me.ComboItem9})
        Me.cboType.Name = "cboType"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "ALL"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "Boarder"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "Day"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(902, 7)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(6, 635)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'SideNavPanel3
        '
        Me.SideNavPanel3.Controls.Add(Me.splitOwings)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge24)
        Me.SideNavPanel3.Controls.Add(Me.Bar6)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge23)
        Me.SideNavPanel3.Controls.Add(Me.Bar5)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge22)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge21)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge20)
        Me.SideNavPanel3.Controls.Add(Me.KryptonBorderEdge19)
        Me.SideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel3.Location = New System.Drawing.Point(97, 31)
        Me.SideNavPanel3.Name = "SideNavPanel3"
        Me.SideNavPanel3.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel3.Size = New System.Drawing.Size(909, 642)
        Me.SideNavPanel3.TabIndex = 10
        Me.SideNavPanel3.Visible = False
        '
        'splitOwings
        '
        Me.splitOwings.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.splitOwings.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitOwings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitOwings.ForeColor = System.Drawing.Color.Black
        Me.splitOwings.Location = New System.Drawing.Point(7, 40)
        Me.splitOwings.Name = "splitOwings"
        '
        'splitOwings.Panel1
        '
        Me.splitOwings.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.splitOwings.Panel1.Controls.Add(Me.dGridOwings)
        Me.splitOwings.Panel1.Controls.Add(Me.KryptonPanel10)
        Me.splitOwings.Panel1.Controls.Add(Me.KryptonBorderEdge46)
        Me.splitOwings.Panel1.ForeColor = System.Drawing.Color.Black
        Me.splitOwings.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'splitOwings.Panel2
        '
        Me.splitOwings.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.splitOwings.Panel2.Controls.Add(Me.ExpandablePanel2)
        Me.splitOwings.Panel2.Controls.Add(Me.KryptonBorderEdge47)
        Me.splitOwings.Panel2.ForeColor = System.Drawing.Color.Black
        Me.splitOwings.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.splitOwings.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.splitOwings.Size = New System.Drawing.Size(895, 575)
        Me.splitOwings.SplitterDistance = 701
        Me.splitOwings.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitOwings.StateCommon.Separator.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitOwings.StateCommon.Separator.Back.Color2 = System.Drawing.Color.Transparent
        Me.splitOwings.TabIndex = 168
        '
        'dGridOwings
        '
        Me.dGridOwings.AllowUserToAddRows = False
        Me.dGridOwings.AllowUserToDeleteRows = False
        Me.dGridOwings.AllowUserToResizeRows = False
        Me.dGridOwings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridOwings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridOwings.Location = New System.Drawing.Point(0, 27)
        Me.dGridOwings.Name = "dGridOwings"
        Me.dGridOwings.RowHeadersWidth = 25
        Me.dGridOwings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridOwings.Size = New System.Drawing.Size(700, 548)
        Me.dGridOwings.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridOwings.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridOwings.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOwings.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridOwings.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridOwings.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridOwings.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridOwings.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridOwings.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridOwings.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridOwings.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOwings.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridOwings.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridOwings.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridOwings.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridOwings.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.TabIndex = 170
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.optUnselectAll)
        Me.KryptonPanel10.Controls.Add(Me.optSelectAll)
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge48)
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge49)
        Me.KryptonPanel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(700, 27)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel10.StateCommon.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonPanel10.TabIndex = 168
        '
        'optUnselectAll
        '
        Me.optUnselectAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.optUnselectAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.optUnselectAll.ForeColor = System.Drawing.Color.Black
        Me.optUnselectAll.Location = New System.Drawing.Point(539, 0)
        Me.optUnselectAll.Name = "optUnselectAll"
        Me.optUnselectAll.Size = New System.Drawing.Size(89, 26)
        Me.optUnselectAll.TabIndex = 3
        Me.optUnselectAll.Values.Text = "De-select all"
        '
        'optSelectAll
        '
        Me.optSelectAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.optSelectAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.optSelectAll.ForeColor = System.Drawing.Color.Black
        Me.optSelectAll.Location = New System.Drawing.Point(628, 0)
        Me.optSelectAll.Name = "optSelectAll"
        Me.optSelectAll.Size = New System.Drawing.Size(72, 26)
        Me.optSelectAll.TabIndex = 2
        Me.optSelectAll.Values.Text = "Select All"
        '
        'KryptonBorderEdge48
        '
        Me.KryptonBorderEdge48.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge48.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge48.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge48.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge48.Name = "KryptonBorderEdge48"
        Me.KryptonBorderEdge48.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge48.Size = New System.Drawing.Size(1, 26)
        Me.KryptonBorderEdge48.Text = "KryptonBorderEdge48"
        '
        'KryptonBorderEdge49
        '
        Me.KryptonBorderEdge49.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge49.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge49.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge49.Location = New System.Drawing.Point(0, 26)
        Me.KryptonBorderEdge49.Name = "KryptonBorderEdge49"
        Me.KryptonBorderEdge49.Size = New System.Drawing.Size(700, 1)
        Me.KryptonBorderEdge49.Text = "KryptonBorderEdge49"
        '
        'KryptonBorderEdge46
        '
        Me.KryptonBorderEdge46.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge46.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge46.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge46.Location = New System.Drawing.Point(700, 0)
        Me.KryptonBorderEdge46.Name = "KryptonBorderEdge46"
        Me.KryptonBorderEdge46.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge46.Size = New System.Drawing.Size(1, 575)
        Me.KryptonBorderEdge46.Text = "KryptonBorderEdge46"
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.tvClasses2)
        Me.ExpandablePanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpandablePanel2.Location = New System.Drawing.Point(1, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(188, 575)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandablePanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 15
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleStyle.MarginLeft = 6
        Me.ExpandablePanel2.TitleText = "Classes"
        '
        'tvClasses2
        '
        Me.tvClasses2.BackColor = System.Drawing.Color.White
        Me.tvClasses2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvClasses2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvClasses2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvClasses2.ForeColor = System.Drawing.Color.Black
        Me.tvClasses2.ImageIndex = 5
        Me.tvClasses2.ImageList = Me.imageListStudents
        Me.tvClasses2.Location = New System.Drawing.Point(0, 26)
        Me.tvClasses2.Name = "tvClasses2"
        Me.tvClasses2.SelectedImageIndex = 3
        Me.tvClasses2.Size = New System.Drawing.Size(188, 549)
        Me.tvClasses2.TabIndex = 4
        '
        'KryptonBorderEdge47
        '
        Me.KryptonBorderEdge47.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge47.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge47.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge47.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge47.Name = "KryptonBorderEdge47"
        Me.KryptonBorderEdge47.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge47.Size = New System.Drawing.Size(1, 575)
        Me.KryptonBorderEdge47.Text = "KryptonBorderEdge47"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(7, 615)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'Bar6
        '
        Me.Bar6.AntiAlias = True
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar6.IsMaximized = False
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblActiveClassOwings, Me.LabelItem6, Me.lblTotalOwings, Me.lblTotalRecords})
        Me.Bar6.Location = New System.Drawing.Point(7, 616)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.PaddingLeft = 3
        Me.Bar6.PaddingRight = 3
        Me.Bar6.RoundCorners = False
        Me.Bar6.Size = New System.Drawing.Size(895, 19)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar6.TabIndex = 11
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'lblActiveClassOwings
        '
        Me.lblActiveClassOwings.Name = "lblActiveClassOwings"
        Me.lblActiveClassOwings.PaddingLeft = 6
        Me.lblActiveClassOwings.PaddingRight = 6
        Me.lblActiveClassOwings.Stretch = True
        '
        'LabelItem6
        '
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingLeft = 3
        Me.LabelItem6.PaddingRight = 3
        Me.LabelItem6.Text = "Total Owings"
        Me.LabelItem6.Width = 150
        '
        'lblTotalOwings
        '
        Me.lblTotalOwings.BeginGroup = True
        Me.lblTotalOwings.Name = "lblTotalOwings"
        Me.lblTotalOwings.PaddingLeft = 3
        Me.lblTotalOwings.PaddingRight = 3
        Me.lblTotalOwings.Text = "0.00"
        Me.lblTotalOwings.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblTotalOwings.Width = 80
        '
        'lblTotalRecords
        '
        Me.lblTotalRecords.BackColor = System.Drawing.Color.Orange
        Me.lblTotalRecords.BeginGroup = True
        Me.lblTotalRecords.Name = "lblTotalRecords"
        Me.lblTotalRecords.PaddingLeft = 3
        Me.lblTotalRecords.PaddingRight = 3
        Me.lblTotalRecords.Text = "0"
        Me.lblTotalRecords.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(7, 39)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.Controls.Add(Me.txtAmountFrom)
        Me.Bar5.Controls.Add(Me.txtAmountTo)
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnTakeonBalances, Me.btnPrintOwings, Me.btnBilling, Me.btnPrior, Me.btnSmsReminderOwings, Me.btnRefreshOwings, Me.LabelItem4, Me.ControlContainerItem2, Me.LabelItem5, Me.ControlContainerItem1, Me.btnAmtFilter})
        Me.Bar5.Location = New System.Drawing.Point(7, 7)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.RoundCorners = False
        Me.Bar5.Size = New System.Drawing.Size(895, 32)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 9
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'txtAmountFrom
        '
        Me.txtAmountFrom.AllowDecimal = True
        Me.txtAmountFrom.BackColor = System.Drawing.Color.White
        Me.txtAmountFrom.ForeColor = System.Drawing.Color.Black
        Me.txtAmountFrom.Location = New System.Drawing.Point(560, 4)
        Me.txtAmountFrom.Name = "txtAmountFrom"
        Me.txtAmountFrom.Size = New System.Drawing.Size(100, 23)
        Me.txtAmountFrom.TabIndex = 167
        Me.txtAmountFrom.Text = "0.00"
        Me.txtAmountFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountFrom.ThousandsSeperator = False
        Me.txtAmountFrom.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtAmountTo
        '
        Me.txtAmountTo.AllowDecimal = True
        Me.txtAmountTo.BackColor = System.Drawing.Color.White
        Me.txtAmountTo.ForeColor = System.Drawing.Color.Black
        Me.txtAmountTo.Location = New System.Drawing.Point(698, 4)
        Me.txtAmountTo.Name = "txtAmountTo"
        Me.txtAmountTo.Size = New System.Drawing.Size(100, 23)
        Me.txtAmountTo.TabIndex = 166
        Me.txtAmountTo.Text = "99999.00"
        Me.txtAmountTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountTo.ThousandsSeperator = False
        Me.txtAmountTo.ZeroOutEmptyStringOnLostFocus = False
        '
        'btnTakeonBalances
        '
        Me.btnTakeonBalances.BeginGroup = True
        Me.btnTakeonBalances.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTakeonBalances.Image = CType(resources.GetObject("btnTakeonBalances.Image"), System.Drawing.Image)
        Me.btnTakeonBalances.Name = "btnTakeonBalances"
        Me.btnTakeonBalances.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTakeonBalances.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnTakeonBalances.Text = "Take-on Balances"
        '
        'btnPrintOwings
        '
        Me.btnPrintOwings.BeginGroup = True
        Me.btnPrintOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintOwings.Image = CType(resources.GetObject("btnPrintOwings.Image"), System.Drawing.Image)
        Me.btnPrintOwings.Name = "btnPrintOwings"
        Me.btnPrintOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintOwings.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintListOwings, Me.btnSelectedStatementOwings, Me.btnAllStatementsOwings, Me.btnSelectedReminder, Me.btnAllReminders, Me.btnPrintForHandOver})
        Me.btnPrintOwings.Text = "Print"
        '
        'btnPrintListOwings
        '
        Me.btnPrintListOwings.BeginGroup = True
        Me.btnPrintListOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintListOwings.Name = "btnPrintListOwings"
        Me.btnPrintListOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintListOwings.Text = "Summary Listing"
        '
        'btnSelectedStatementOwings
        '
        Me.btnSelectedStatementOwings.BeginGroup = True
        Me.btnSelectedStatementOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSelectedStatementOwings.Name = "btnSelectedStatementOwings"
        Me.btnSelectedStatementOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSelectedStatementOwings.Text = "Selected Statement"
        '
        'btnAllStatementsOwings
        '
        Me.btnAllStatementsOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAllStatementsOwings.Name = "btnAllStatementsOwings"
        Me.btnAllStatementsOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAllStatementsOwings.Text = "All Statements"
        '
        'btnSelectedReminder
        '
        Me.btnSelectedReminder.BeginGroup = True
        Me.btnSelectedReminder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSelectedReminder.Name = "btnSelectedReminder"
        Me.btnSelectedReminder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSelectedReminder.Text = "Selected Reminder"
        '
        'btnAllReminders
        '
        Me.btnAllReminders.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAllReminders.Name = "btnAllReminders"
        Me.btnAllReminders.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAllReminders.Text = "All Reminders"
        '
        'btnPrintForHandOver
        '
        Me.btnPrintForHandOver.BeginGroup = True
        Me.btnPrintForHandOver.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintForHandOver.Name = "btnPrintForHandOver"
        Me.btnPrintForHandOver.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintForHandOver.Text = "Debtors Hand-over Listing"
        '
        'btnBilling
        '
        Me.btnBilling.BeginGroup = True
        Me.btnBilling.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBilling.Image = CType(resources.GetObject("btnBilling.Image"), System.Drawing.Image)
        Me.btnBilling.Name = "btnBilling"
        Me.btnBilling.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBilling.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintInvoice, Me.btnPrintTermInvoices})
        Me.btnBilling.Text = "Term Billing"
        '
        'btnPrintInvoice
        '
        Me.btnPrintInvoice.BeginGroup = True
        Me.btnPrintInvoice.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintInvoice.Name = "btnPrintInvoice"
        Me.btnPrintInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintInvoice.Text = "Bill and Print Selected Invoice to Next Period"
        '
        'btnPrintTermInvoices
        '
        Me.btnPrintTermInvoices.BeginGroup = True
        Me.btnPrintTermInvoices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintTermInvoices.Image = CType(resources.GetObject("btnPrintTermInvoices.Image"), System.Drawing.Image)
        Me.btnPrintTermInvoices.Name = "btnPrintTermInvoices"
        Me.btnPrintTermInvoices.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintTermInvoices.Text = "Bill and Print All Term/Period Invoices"
        '
        'btnPrior
        '
        Me.btnPrior.BeginGroup = True
        Me.btnPrior.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrior.Image = CType(resources.GetObject("btnPrior.Image"), System.Drawing.Image)
        Me.btnPrior.Name = "btnPrior"
        Me.btnPrior.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrior.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPrior.Text = "Mass Receipts"
        '
        'btnSmsReminderOwings
        '
        Me.btnSmsReminderOwings.BeginGroup = True
        Me.btnSmsReminderOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSmsReminderOwings.Image = CType(resources.GetObject("btnSmsReminderOwings.Image"), System.Drawing.Image)
        Me.btnSmsReminderOwings.Name = "btnSmsReminderOwings"
        Me.btnSmsReminderOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSmsReminderOwings.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSmsReminderOwings.Text = "SMS"
        '
        'btnRefreshOwings
        '
        Me.btnRefreshOwings.BeginGroup = True
        Me.btnRefreshOwings.Image = CType(resources.GetObject("btnRefreshOwings.Image"), System.Drawing.Image)
        Me.btnRefreshOwings.Name = "btnRefreshOwings"
        Me.btnRefreshOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshOwings.Text = "Refresh"
        '
        'LabelItem4
        '
        Me.LabelItem4.BeginGroup = True
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 6
        Me.LabelItem4.Text = "Balance from "
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.Control = Me.txtAmountFrom
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'LabelItem5
        '
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingLeft = 6
        Me.LabelItem5.PaddingRight = 6
        Me.LabelItem5.Text = "and"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.txtAmountTo
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'btnAmtFilter
        '
        Me.btnAmtFilter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAmtFilter.Image = CType(resources.GetObject("btnAmtFilter.Image"), System.Drawing.Image)
        Me.btnAmtFilter.Name = "btnAmtFilter"
        Me.btnAmtFilter.Text = "Process"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(902, 7)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(6, 635)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'SideNavPanel5
        '
        Me.SideNavPanel5.Controls.Add(Me.dGridReceipts)
        Me.SideNavPanel5.Controls.Add(Me.KryptonPanel7)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge32)
        Me.SideNavPanel5.Controls.Add(Me.Bar8)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge31)
        Me.SideNavPanel5.Controls.Add(Me.Bar7)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge30)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge29)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge28)
        Me.SideNavPanel5.Controls.Add(Me.KryptonBorderEdge25)
        Me.SideNavPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel5.Location = New System.Drawing.Point(97, 31)
        Me.SideNavPanel5.Name = "SideNavPanel5"
        Me.SideNavPanel5.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel5.Size = New System.Drawing.Size(909, 642)
        Me.SideNavPanel5.TabIndex = 23
        Me.SideNavPanel5.Visible = False
        '
        'dGridReceipts
        '
        Me.dGridReceipts.AllowUserToAddRows = False
        Me.dGridReceipts.AllowUserToDeleteRows = False
        Me.dGridReceipts.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridReceipts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dGridReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column7})
        Me.dGridReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridReceipts.Location = New System.Drawing.Point(7, 78)
        Me.dGridReceipts.Name = "dGridReceipts"
        Me.dGridReceipts.ReadOnly = True
        Me.dGridReceipts.RowHeadersWidth = 25
        Me.dGridReceipts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridReceipts.Size = New System.Drawing.Size(895, 537)
        Me.dGridReceipts.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridReceipts.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridReceipts.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridReceipts.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridReceipts.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridReceipts.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridReceipts.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridReceipts.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dGridReceipts.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridReceipts.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridReceipts.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridReceipts.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dGridReceipts.TabIndex = 153
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Date"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 41
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Rec. No."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 59
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Student No."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 79
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Student Names"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 95
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column6.HeaderText = "Total"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 41
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column7.HeaderText = "Break Down"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 80
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.AutoScroll = True
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonButton1)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel7.Controls.Add(Me.dpStartFrom)
        Me.KryptonPanel7.Controls.Add(Me.dpEndTo)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge33)
        Me.KryptonPanel7.Controls.Add(Me.btnGo)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(7, 33)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(895, 45)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.TabIndex = 152
        '
        'KryptonButton1
        '
        Me.KryptonButton1.AutoSize = True
        Me.KryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.KryptonButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonButton1.ForeColor = System.Drawing.Color.Black
        Me.KryptonButton1.Location = New System.Drawing.Point(499, 11)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(48, 22)
        Me.KryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonButton1.StateCommon.Back.ColorAngle = 100.0!
        Me.KryptonButton1.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 0
        Me.KryptonButton1.TabIndex = 170
        Me.KryptonButton1.Values.Image = CType(resources.GetObject("KryptonButton1.Values.Image"), System.Drawing.Image)
        Me.KryptonButton1.Values.Text = "Test"
        Me.KryptonButton1.Visible = False
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge35)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(228, 11)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 168
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel6.TabIndex = 148
        Me.KryptonLabel6.Values.Text = "Date To"
        '
        'KryptonBorderEdge35
        '
        Me.KryptonBorderEdge35.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge35.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge35.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge35.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge35.Name = "KryptonBorderEdge35"
        Me.KryptonBorderEdge35.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge35.Text = "KryptonBorderEdge35"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge34)
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(36, 11)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 167
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel5.TabIndex = 148
        Me.KryptonLabel5.Values.Text = "Date From"
        '
        'KryptonBorderEdge34
        '
        Me.KryptonBorderEdge34.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge34.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge34.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge34.Name = "KryptonBorderEdge34"
        Me.KryptonBorderEdge34.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge34.Text = "KryptonBorderEdge34"
        '
        'dpStartFrom
        '
        Me.dpStartFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartFrom.ForeColor = System.Drawing.Color.Black
        Me.dpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFrom.Location = New System.Drawing.Point(112, 13)
        Me.dpStartFrom.Name = "dpStartFrom"
        Me.dpStartFrom.Size = New System.Drawing.Size(98, 20)
        Me.dpStartFrom.TabIndex = 10
        '
        'dpEndTo
        '
        Me.dpEndTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndTo.ForeColor = System.Drawing.Color.Black
        Me.dpEndTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndTo.Location = New System.Drawing.Point(304, 13)
        Me.dpEndTo.Name = "dpEndTo"
        Me.dpEndTo.Size = New System.Drawing.Size(95, 20)
        Me.dpEndTo.TabIndex = 5
        '
        'KryptonBorderEdge33
        '
        Me.KryptonBorderEdge33.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge33.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge33.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge33.Location = New System.Drawing.Point(0, 44)
        Me.KryptonBorderEdge33.Name = "KryptonBorderEdge33"
        Me.KryptonBorderEdge33.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge33.Text = "KryptonBorderEdge33"
        '
        'btnGo
        '
        Me.btnGo.AutoSize = True
        Me.btnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnGo.ForeColor = System.Drawing.Color.Black
        Me.btnGo.Location = New System.Drawing.Point(403, 11)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(67, 22)
        Me.btnGo.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnGo.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnGo.StateCommon.Back.ColorAngle = 100.0!
        Me.btnGo.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnGo.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnGo.StateCommon.Border.Rounding = 0
        Me.btnGo.TabIndex = 139
        Me.btnGo.Values.Image = CType(resources.GetObject("btnGo.Values.Image"), System.Drawing.Image)
        Me.btnGo.Values.Text = "Process"
        '
        'KryptonBorderEdge32
        '
        Me.KryptonBorderEdge32.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge32.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge32.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge32.Location = New System.Drawing.Point(7, 615)
        Me.KryptonBorderEdge32.Name = "KryptonBorderEdge32"
        Me.KryptonBorderEdge32.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge32.Text = "KryptonBorderEdge32"
        '
        'Bar8
        '
        Me.Bar8.AntiAlias = True
        Me.Bar8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar8.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar8.IsMaximized = False
        Me.Bar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem8, Me.lblAllReceiptAmt})
        Me.Bar8.Location = New System.Drawing.Point(7, 616)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.Size = New System.Drawing.Size(895, 19)
        Me.Bar8.Stretch = True
        Me.Bar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar8.TabIndex = 150
        Me.Bar8.TabStop = False
        Me.Bar8.Text = "Bar8"
        '
        'LabelItem8
        '
        Me.LabelItem8.ForeColor = System.Drawing.Color.Black
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.Stretch = True
        '
        'lblAllReceiptAmt
        '
        Me.lblAllReceiptAmt.Name = "lblAllReceiptAmt"
        Me.lblAllReceiptAmt.PaddingLeft = 3
        Me.lblAllReceiptAmt.PaddingRight = 3
        Me.lblAllReceiptAmt.Text = "0.00"
        Me.lblAllReceiptAmt.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'KryptonBorderEdge31
        '
        Me.KryptonBorderEdge31.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge31.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge31.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge31.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge31.Name = "KryptonBorderEdge31"
        Me.KryptonBorderEdge31.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge31.Text = "KryptonBorderEdge31"
        '
        'Bar7
        '
        Me.Bar7.AntiAlias = True
        Me.Bar7.BackColor = System.Drawing.Color.Transparent
        Me.Bar7.ColorScheme.BarCaptionInactiveBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar7.ColorScheme.ExplorerBarBackground = System.Drawing.Color.Transparent
        Me.Bar7.ColorScheme.ItemCheckedBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar7.ColorScheme.MenuBarBackground = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar7.IsMaximized = False
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPayments, Me.btnReceiptDetails, Me.btnPrintReceiptDetails, Me.btnRefreshReceipts, Me.LabelItem7, Me.lblReceiptTotalSelected})
        Me.Bar7.Location = New System.Drawing.Point(7, 7)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(895, 25)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar7.TabIndex = 145
        Me.Bar7.TabStop = False
        Me.Bar7.Text = "Bar7"
        '
        'btnPayments
        '
        Me.btnPayments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPayments.Image = CType(resources.GetObject("btnPayments.Image"), System.Drawing.Image)
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPayments.Text = "Payments"
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
        'btnPrintReceiptDetails
        '
        Me.btnPrintReceiptDetails.BeginGroup = True
        Me.btnPrintReceiptDetails.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintReceiptDetails.Image = CType(resources.GetObject("btnPrintReceiptDetails.Image"), System.Drawing.Image)
        Me.btnPrintReceiptDetails.Name = "btnPrintReceiptDetails"
        Me.btnPrintReceiptDetails.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintReceiptDetails.Text = "&Print"
        '
        'btnRefreshReceipts
        '
        Me.btnRefreshReceipts.BeginGroup = True
        Me.btnRefreshReceipts.Image = CType(resources.GetObject("btnRefreshReceipts.Image"), System.Drawing.Image)
        Me.btnRefreshReceipts.Name = "btnRefreshReceipts"
        Me.btnRefreshReceipts.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshReceipts.Text = "ButtonItem1"
        '
        'LabelItem7
        '
        Me.LabelItem7.BeginGroup = True
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.PaddingLeft = 12
        Me.LabelItem7.PaddingRight = 6
        Me.LabelItem7.Stretch = True
        Me.LabelItem7.Text = "Total records selected"
        Me.LabelItem7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblReceiptTotalSelected
        '
        Me.lblReceiptTotalSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblReceiptTotalSelected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptTotalSelected.ForeColor = System.Drawing.Color.White
        Me.lblReceiptTotalSelected.Name = "lblReceiptTotalSelected"
        Me.lblReceiptTotalSelected.Text = "0"
        Me.lblReceiptTotalSelected.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblReceiptTotalSelected.Width = 50
        '
        'KryptonBorderEdge30
        '
        Me.KryptonBorderEdge30.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge30.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge30.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge30.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge30.Name = "KryptonBorderEdge30"
        Me.KryptonBorderEdge30.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge30.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge30.Text = "KryptonBorderEdge30"
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(902, 7)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge28.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(6, 635)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'SideNavPanel4
        '
        Me.SideNavPanel4.Controls.Add(Me.panelEx1)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge39)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge38)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge37)
        Me.SideNavPanel4.Controls.Add(Me.KryptonBorderEdge36)
        Me.SideNavPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel4.Location = New System.Drawing.Point(97, 31)
        Me.SideNavPanel4.Name = "SideNavPanel4"
        Me.SideNavPanel4.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel4.Size = New System.Drawing.Size(909, 642)
        Me.SideNavPanel4.TabIndex = 14
        Me.SideNavPanel4.Visible = False
        '
        'panelEx1
        '
        Me.panelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.panelEx1.Controls.Add(Me.recentDocsItemPane)
        Me.panelEx1.Controls.Add(Me.labelX1)
        Me.panelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.panelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelEx1.Location = New System.Drawing.Point(7, 7)
        Me.panelEx1.Name = "panelEx1"
        Me.panelEx1.Padding = New System.Windows.Forms.Padding(12)
        Me.panelEx1.Size = New System.Drawing.Size(505, 628)
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
        Me.recentDocsItemPane.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSchoolClassification, Me.btnNewStudentNumberParameters, Me.btnSubjects, Me.btnClasses, Me.btnFees, Me.btnExtraPaymentDescriptions, Me.btnPaymentAllocations, Me.btnSubjectsPaymentsTable, Me.btnPrivateSchoolFees, Me.btnBilliableMaximum, Me.btnSponsors, Me.btnYearEndProcedures})
        Me.recentDocsItemPane.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.recentDocsItemPane.Location = New System.Drawing.Point(12, 35)
        Me.recentDocsItemPane.Name = "recentDocsItemPane"
        Me.recentDocsItemPane.Size = New System.Drawing.Size(481, 581)
        Me.recentDocsItemPane.TabIndex = 1
        '
        'btnSchoolClassification
        '
        Me.btnSchoolClassification.BeginGroup = True
        Me.btnSchoolClassification.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSchoolClassification.CommandParameter = ""
        Me.btnSchoolClassification.ForeColor = System.Drawing.Color.Black
        Me.btnSchoolClassification.Image = CType(resources.GetObject("btnSchoolClassification.Image"), System.Drawing.Image)
        Me.btnSchoolClassification.Name = "btnSchoolClassification"
        Me.btnSchoolClassification.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSchoolClassification.Symbol = "57772"
        Me.btnSchoolClassification.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSchoolClassification.Text = "School Classification<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Define school type</font>"
        '
        'btnNewStudentNumberParameters
        '
        Me.btnNewStudentNumberParameters.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNewStudentNumberParameters.CommandParameter = ""
        Me.btnNewStudentNumberParameters.ForeColor = System.Drawing.Color.Black
        Me.btnNewStudentNumberParameters.Image = CType(resources.GetObject("btnNewStudentNumberParameters.Image"), System.Drawing.Image)
        Me.btnNewStudentNumberParameters.Name = "btnNewStudentNumberParameters"
        Me.btnNewStudentNumberParameters.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewStudentNumberParameters.Symbol = "58367"
        Me.btnNewStudentNumberParameters.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewStudentNumberParameters.Text = "Student Number Allocation Options<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Specify how new studen" &
    "t numbers will be created by the system</font>"
        '
        'btnSubjects
        '
        Me.btnSubjects.BeginGroup = True
        Me.btnSubjects.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSubjects.CommandParameter = ""
        Me.btnSubjects.ForeColor = System.Drawing.Color.Black
        Me.btnSubjects.Image = CType(resources.GetObject("btnSubjects.Image"), System.Drawing.Image)
        Me.btnSubjects.Name = "btnSubjects"
        Me.btnSubjects.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSubjects.Symbol = "57789"
        Me.btnSubjects.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSubjects.Text = "Subjects<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and maintain subjects offered</fon" &
    "t>"
        '
        'btnClasses
        '
        Me.btnClasses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnClasses.CommandParameter = ""
        Me.btnClasses.ForeColor = System.Drawing.Color.Black
        Me.btnClasses.Image = CType(resources.GetObject("btnClasses.Image"), System.Drawing.Image)
        Me.btnClasses.Name = "btnClasses"
        Me.btnClasses.Symbol = "57773"
        Me.btnClasses.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnClasses.Text = "Classes<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and modify classes. Also assign cla" &
    "sses to teachers</font>"
        '
        'btnFees
        '
        Me.btnFees.BeginGroup = True
        Me.btnFees.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFees.CommandParameter = ""
        Me.btnFees.ForeColor = System.Drawing.Color.Black
        Me.btnFees.Image = CType(resources.GetObject("btnFees.Image"), System.Drawing.Image)
        Me.btnFees.Name = "btnFees"
        Me.btnFees.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnFees.Symbol = "57895"
        Me.btnFees.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnFees.Text = "Term Fees <br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and maintain term fee (amounts) " &
    "in total per cost center.<br/>May include tuition fees and other tuition related" &
    " fees</font>"
        '
        'btnExtraPaymentDescriptions
        '
        Me.btnExtraPaymentDescriptions.BeginGroup = True
        Me.btnExtraPaymentDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExtraPaymentDescriptions.CommandParameter = ""
        Me.btnExtraPaymentDescriptions.ForeColor = System.Drawing.Color.Black
        Me.btnExtraPaymentDescriptions.Image = CType(resources.GetObject("btnExtraPaymentDescriptions.Image"), System.Drawing.Image)
        Me.btnExtraPaymentDescriptions.Name = "btnExtraPaymentDescriptions"
        Me.btnExtraPaymentDescriptions.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExtraPaymentDescriptions.Symbol = "57895"
        Me.btnExtraPaymentDescriptions.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnExtraPaymentDescriptions.Text = "Additional Payment Descriptions<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Create, view and maintai" &
    "n payment descriptions on items over and aboves <br/>tuition fees and other tuit" &
    "ion related fees</font>"
        '
        'btnPaymentAllocations
        '
        Me.btnPaymentAllocations.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPaymentAllocations.CommandParameter = ""
        Me.btnPaymentAllocations.ForeColor = System.Drawing.Color.Black
        Me.btnPaymentAllocations.Image = CType(resources.GetObject("btnPaymentAllocations.Image"), System.Drawing.Image)
        Me.btnPaymentAllocations.Name = "btnPaymentAllocations"
        Me.btnPaymentAllocations.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPaymentAllocations.Symbol = "57369"
        Me.btnPaymentAllocations.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPaymentAllocations.Text = "Payment Descriptions and Allocations<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Defines the order o" &
    "f allocating payments based on the set priority in the <br/>payment descriptions" &
    "</font>"
        '
        'btnSubjectsPaymentsTable
        '
        Me.btnSubjectsPaymentsTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSubjectsPaymentsTable.CommandParameter = ""
        Me.btnSubjectsPaymentsTable.ForeColor = System.Drawing.Color.Black
        Me.btnSubjectsPaymentsTable.Image = CType(resources.GetObject("btnSubjectsPaymentsTable.Image"), System.Drawing.Image)
        Me.btnSubjectsPaymentsTable.Name = "btnSubjectsPaymentsTable"
        Me.btnSubjectsPaymentsTable.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSubjectsPaymentsTable.Symbol = "57519"
        Me.btnSubjectsPaymentsTable.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSubjectsPaymentsTable.Text = "Subjects Payments Table<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Defines payments descriptions ba" &
    "sed on the number of subjects that a student <br/> is taking</font>"
        '
        'btnPrivateSchoolFees
        '
        Me.btnPrivateSchoolFees.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrivateSchoolFees.CommandParameter = ""
        Me.btnPrivateSchoolFees.ForeColor = System.Drawing.Color.Black
        Me.btnPrivateSchoolFees.Image = CType(resources.GetObject("btnPrivateSchoolFees.Image"), System.Drawing.Image)
        Me.btnPrivateSchoolFees.Name = "btnPrivateSchoolFees"
        Me.btnPrivateSchoolFees.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrivateSchoolFees.Symbol = "57391"
        Me.btnPrivateSchoolFees.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnPrivateSchoolFees.Text = "Non Conventional Private Schools Fee Payment Plans<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Defin" &
    "es payments plans used in a private school</font>"
        '
        'btnBilliableMaximum
        '
        Me.btnBilliableMaximum.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBilliableMaximum.CommandParameter = ""
        Me.btnBilliableMaximum.ForeColor = System.Drawing.Color.Black
        Me.btnBilliableMaximum.Image = CType(resources.GetObject("btnBilliableMaximum.Image"), System.Drawing.Image)
        Me.btnBilliableMaximum.Name = "btnBilliableMaximum"
        Me.btnBilliableMaximum.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBilliableMaximum.Symbol = "58358"
        Me.btnBilliableMaximum.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnBilliableMaximum.Text = "Maximum Billable Subjects<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Specify the number of subjects" &
    " up to whic a student can be billed at a flat rate</font>"
        '
        'btnSponsors
        '
        Me.btnSponsors.BeginGroup = True
        Me.btnSponsors.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSponsors.CommandParameter = ""
        Me.btnSponsors.ForeColor = System.Drawing.Color.Black
        Me.btnSponsors.Image = CType(resources.GetObject("btnSponsors.Image"), System.Drawing.Image)
        Me.btnSponsors.Name = "btnSponsors"
        Me.btnSponsors.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSponsors.Symbol = "57772"
        Me.btnSponsors.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSponsors.Text = "Sponsors<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Define sponsors than offer scholarships</font>"
        '
        'btnYearEndProcedures
        '
        Me.btnYearEndProcedures.BeginGroup = True
        Me.btnYearEndProcedures.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnYearEndProcedures.CommandParameter = ""
        Me.btnYearEndProcedures.ForeColor = System.Drawing.Color.Black
        Me.btnYearEndProcedures.Image = CType(resources.GetObject("btnYearEndProcedures.Image"), System.Drawing.Image)
        Me.btnYearEndProcedures.Name = "btnYearEndProcedures"
        Me.btnYearEndProcedures.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnYearEndProcedures.Symbol = "57375"
        Me.btnYearEndProcedures.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnYearEndProcedures.Text = "Year-End/Year-Start Class Procedures<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""Gray"">Updates the student" &
    " classes to the next class in the following year</font>"
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
        Me.labelX1.Size = New System.Drawing.Size(481, 23)
        Me.labelX1.TabIndex = 0
        Me.labelX1.Text = "General Settings"
        '
        'KryptonBorderEdge39
        '
        Me.KryptonBorderEdge39.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge39.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge39.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge39.Location = New System.Drawing.Point(902, 7)
        Me.KryptonBorderEdge39.Name = "KryptonBorderEdge39"
        Me.KryptonBorderEdge39.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge39.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge39.Text = "KryptonBorderEdge39"
        '
        'KryptonBorderEdge38
        '
        Me.KryptonBorderEdge38.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge38.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge38.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge38.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge38.Name = "KryptonBorderEdge38"
        Me.KryptonBorderEdge38.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge38.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge38.Text = "KryptonBorderEdge38"
        '
        'KryptonBorderEdge37
        '
        Me.KryptonBorderEdge37.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge37.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge37.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge37.Location = New System.Drawing.Point(6, 635)
        Me.KryptonBorderEdge37.Name = "KryptonBorderEdge37"
        Me.KryptonBorderEdge37.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge37.Text = "KryptonBorderEdge37"
        '
        'KryptonBorderEdge36
        '
        Me.KryptonBorderEdge36.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge36.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge36.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge36.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge36.Name = "KryptonBorderEdge36"
        Me.KryptonBorderEdge36.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge36.Text = "KryptonBorderEdge36"
        '
        'SideNavPanel6
        '
        Me.SideNavPanel6.Controls.Add(Me.KryptonSplitContainer1)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge43)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge42)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge41)
        Me.SideNavPanel6.Controls.Add(Me.KryptonBorderEdge40)
        Me.SideNavPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel6.Location = New System.Drawing.Point(97, 31)
        Me.SideNavPanel6.Name = "SideNavPanel6"
        Me.SideNavPanel6.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel6.Size = New System.Drawing.Size(909, 642)
        Me.SideNavPanel6.TabIndex = 33
        Me.SideNavPanel6.Visible = False
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.ForeColor = System.Drawing.Color.Black
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(7, 7)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.tvReports)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonBorderEdge44)
        Me.KryptonSplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color2 = System.Drawing.Color.White
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.pnlPreview)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonPanel18)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.Bar16)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge50)
        Me.KryptonSplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(895, 628)
        Me.KryptonSplitContainer1.SplitterDistance = 248
        Me.KryptonSplitContainer1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color1 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.StateCommon.Separator.Back.Color2 = System.Drawing.Color.White
        Me.KryptonSplitContainer1.TabIndex = 4
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
        TreeNode1.Text = "Balance by Sponsor"
        TreeNode2.ImageIndex = 5
        TreeNode2.Name = "Node12"
        TreeNode2.SelectedImageIndex = 5
        TreeNode2.Text = "Students by Sponsor"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "Node13"
        TreeNode3.SelectedImageIndex = 5
        TreeNode3.Text = "Students by Type"
        TreeNode4.ImageIndex = 9
        TreeNode4.Name = "Node1"
        TreeNode4.SelectedImageIndex = 9
        TreeNode4.Text = "General Reports"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(247, 628)
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
        'KryptonBorderEdge44
        '
        Me.KryptonBorderEdge44.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge44.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge44.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge44.Location = New System.Drawing.Point(247, 0)
        Me.KryptonBorderEdge44.Name = "KryptonBorderEdge44"
        Me.KryptonBorderEdge44.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge44.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge44.Text = "KryptonBorderEdge44"
        '
        'pnlPreview
        '
        Me.pnlPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.pnlPreview.Controls.Add(Me.dGridPreview)
        Me.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreview.ForeColor = System.Drawing.Color.Black
        Me.pnlPreview.Location = New System.Drawing.Point(1, 24)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(641, 477)
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
        Me.dGridPreview.Size = New System.Drawing.Size(641, 477)
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
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.labelX5)
        Me.KryptonPanel18.Controls.Add(Me.dGridTransactions)
        Me.KryptonPanel18.Controls.Add(Me.integerInput1)
        Me.KryptonPanel18.Controls.Add(Me.labelX4)
        Me.KryptonPanel18.Controls.Add(Me.btnPrintPreview)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge45)
        Me.KryptonPanel18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(1, 501)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(641, 127)
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
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dGridTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn11})
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
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Ref #"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn9.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn10.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn16.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 44
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
        'KryptonBorderEdge45
        '
        Me.KryptonBorderEdge45.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge45.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge45.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge45.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge45.Name = "KryptonBorderEdge45"
        Me.KryptonBorderEdge45.Size = New System.Drawing.Size(641, 1)
        Me.KryptonBorderEdge45.Text = "KryptonBorderEdge45"
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
        Me.Bar16.Size = New System.Drawing.Size(641, 24)
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
        'KryptonBorderEdge50
        '
        Me.KryptonBorderEdge50.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge50.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge50.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge50.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge50.Name = "KryptonBorderEdge50"
        Me.KryptonBorderEdge50.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge50.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge50.Text = "KryptonBorderEdge50"
        '
        'KryptonBorderEdge43
        '
        Me.KryptonBorderEdge43.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge43.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge43.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge43.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge43.Name = "KryptonBorderEdge43"
        Me.KryptonBorderEdge43.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge43.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge43.Text = "KryptonBorderEdge43"
        '
        'KryptonBorderEdge42
        '
        Me.KryptonBorderEdge42.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge42.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge42.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge42.Location = New System.Drawing.Point(902, 7)
        Me.KryptonBorderEdge42.Name = "KryptonBorderEdge42"
        Me.KryptonBorderEdge42.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge42.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge42.Text = "KryptonBorderEdge42"
        '
        'KryptonBorderEdge41
        '
        Me.KryptonBorderEdge41.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge41.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge41.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge41.Location = New System.Drawing.Point(6, 635)
        Me.KryptonBorderEdge41.Name = "KryptonBorderEdge41"
        Me.KryptonBorderEdge41.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge41.Text = "KryptonBorderEdge41"
        '
        'KryptonBorderEdge40
        '
        Me.KryptonBorderEdge40.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge40.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge40.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge40.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge40.Name = "KryptonBorderEdge40"
        Me.KryptonBorderEdge40.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge40.Text = "KryptonBorderEdge40"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Controls.Add(Me.dGridSchoolStaff)
        Me.SideNavPanel2.Controls.Add(Me.KryptonPanel4)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge15)
        Me.SideNavPanel2.Controls.Add(Me.Bar3)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge14)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge13)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge12)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.SideNavPanel2.Controls.Add(Me.KryptonBorderEdge9)
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(97, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel2.Size = New System.Drawing.Size(909, 642)
        Me.SideNavPanel2.TabIndex = 6
        Me.SideNavPanel2.Visible = False
        '
        'dGridSchoolStaff
        '
        Me.dGridSchoolStaff.AllowUserToAddRows = False
        Me.dGridSchoolStaff.AllowUserToDeleteRows = False
        Me.dGridSchoolStaff.AllowUserToResizeRows = False
        Me.dGridSchoolStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridSchoolStaff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSchoolStaff.Location = New System.Drawing.Point(7, 78)
        Me.dGridSchoolStaff.Name = "dGridSchoolStaff"
        Me.dGridSchoolStaff.ReadOnly = True
        Me.dGridSchoolStaff.RowHeadersVisible = False
        Me.dGridSchoolStaff.RowHeadersWidth = 25
        Me.dGridSchoolStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridSchoolStaff.Size = New System.Drawing.Size(895, 556)
        Me.dGridSchoolStaff.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridSchoolStaff.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridSchoolStaff.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridSchoolStaff.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSchoolStaff.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridSchoolStaff.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridSchoolStaff.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSchoolStaff.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSchoolStaff.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridSchoolStaff.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridSchoolStaff.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSchoolStaff.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSchoolStaff.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSchoolStaff.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSchoolStaff.TabIndex = 61
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel4.Controls.Add(Me.KryptonTextBox1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonComboBox1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(7, 33)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(895, 45)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.TabIndex = 26
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(26, 12)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 166
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel1.TabIndex = 148
        Me.KryptonLabel1.Values.Text = "Search by"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(280, 12)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 165
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel4.TabIndex = 148
        Me.KryptonLabel4.Values.Text = "Search for"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonTextBox1.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.ButtonSpecAny1})
        Me.KryptonTextBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonTextBox1.Location = New System.Drawing.Point(357, 10)
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.Size = New System.Drawing.Size(205, 24)
        Me.KryptonTextBox1.TabIndex = 163
        '
        'ButtonSpecAny1
        '
        Me.ButtonSpecAny1.Image = CType(resources.GetObject("ButtonSpecAny1.Image"), System.Drawing.Image)
        Me.ButtonSpecAny1.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl
        Me.ButtonSpecAny1.Text = "Find"
        Me.ButtonSpecAny1.UniqueName = "3D638EA06E7B4A035DBF6E67BA01E8F6"
        '
        'KryptonComboBox1
        '
        Me.KryptonComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonComboBox1.DropDownWidth = 163
        Me.KryptonComboBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonComboBox1.Items.AddRange(New Object() {"--All--", "Class", "First Name", "Last Name", "Student Number"})
        Me.KryptonComboBox1.Location = New System.Drawing.Point(103, 13)
        Me.KryptonComboBox1.Name = "KryptonComboBox1"
        Me.KryptonComboBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.KryptonComboBox1.Size = New System.Drawing.Size(168, 21)
        Me.KryptonComboBox1.Sorted = True
        Me.KryptonComboBox1.TabIndex = 164
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 44)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(7, 32)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(895, 1)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewStaff, Me.btnEditStaff, Me.btnDeleteStaff, Me.btnPrintStaffList, Me.btnRefreshStaff})
        Me.Bar3.Location = New System.Drawing.Point(7, 7)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(895, 25)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 24
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnNewStaff
        '
        Me.btnNewStaff.Image = CType(resources.GetObject("btnNewStaff.Image"), System.Drawing.Image)
        Me.btnNewStaff.Name = "btnNewStaff"
        Me.btnNewStaff.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewStaff.Text = "ButtonItem1"
        '
        'btnEditStaff
        '
        Me.btnEditStaff.Image = CType(resources.GetObject("btnEditStaff.Image"), System.Drawing.Image)
        Me.btnEditStaff.Name = "btnEditStaff"
        Me.btnEditStaff.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditStaff.Text = "ButtonItem2"
        '
        'btnDeleteStaff
        '
        Me.btnDeleteStaff.BeginGroup = True
        Me.btnDeleteStaff.Image = CType(resources.GetObject("btnDeleteStaff.Image"), System.Drawing.Image)
        Me.btnDeleteStaff.Name = "btnDeleteStaff"
        Me.btnDeleteStaff.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteStaff.Text = "ButtonItem3"
        '
        'btnPrintStaffList
        '
        Me.btnPrintStaffList.BeginGroup = True
        Me.btnPrintStaffList.Image = CType(resources.GetObject("btnPrintStaffList.Image"), System.Drawing.Image)
        Me.btnPrintStaffList.Name = "btnPrintStaffList"
        Me.btnPrintStaffList.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintStaffList.Text = "ButtonItem6"
        '
        'btnRefreshStaff
        '
        Me.btnRefreshStaff.BeginGroup = True
        Me.btnRefreshStaff.Image = CType(resources.GetObject("btnRefreshStaff.Image"), System.Drawing.Image)
        Me.btnRefreshStaff.Name = "btnRefreshStaff"
        Me.btnRefreshStaff.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshStaff.Text = "ButtonItem7"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(902, 7)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(1, 627)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(6, 7)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(1, 627)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(6, 634)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(6, 635)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
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
        Me.SideNavItem2.Checked = True
        Me.SideNavItem2.Name = "SideNavItem2"
        Me.SideNavItem2.Panel = Me.SideNavPanel1
        Me.SuperTooltip1.SetSuperTooltip(Me.SideNavItem2, New DevComponents.DotNetBar.SuperTooltipInfo("Students Data Management", "Students", "View, Create and maintain students information", CType(resources.GetObject("SideNavItem2.SuperTooltip"), System.Drawing.Image), Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.SideNavItem2.Symbol = "58699"
        Me.SideNavItem2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem2.Text = "Students"
        '
        'Receipts
        '
        Me.Receipts.Name = "Receipts"
        Me.Receipts.Panel = Me.SideNavPanel5
        Me.Receipts.Symbol = "57895"
        Me.Receipts.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Receipts.Text = "Payments"
        '
        'SideNavItem3
        '
        Me.SideNavItem3.Name = "SideNavItem3"
        Me.SideNavItem3.Panel = Me.SideNavPanel2
        Me.SideNavItem3.Symbol = "58941"
        Me.SideNavItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem3.Text = "Teachers"
        '
        'SideNavItem4
        '
        Me.SideNavItem4.Name = "SideNavItem4"
        Me.SideNavItem4.Panel = Me.SideNavPanel3
        Me.SideNavItem4.Symbol = "57532"
        Me.SideNavItem4.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.SideNavItem4.Text = "Billing"
        Me.SideNavItem4.Title = "Balances and Billing"
        '
        'SideNavItem5
        '
        Me.SideNavItem5.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.SideNavItem5.Name = "SideNavItem5"
        Me.SideNavItem5.Panel = Me.SideNavPanel4
        Me.SideNavItem5.Symbol = ""
        Me.SideNavItem5.Text = "Settings"
        '
        'SideNavItem6
        '
        Me.SideNavItem6.Name = "SideNavItem6"
        Me.SideNavItem6.Panel = Me.SideNavPanel6
        Me.SideNavItem6.Symbol = ""
        Me.SideNavItem6.Text = "Reports"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ProgressBar1})
        Me.Bar1.Location = New System.Drawing.Point(0, 674)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(1007, 24)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 1
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Great Wits Technologies Scholastica 2016"
        '
        'ProgressBar1
        '
        '
        '
        '
        Me.ProgressBar1.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBar1.ChunkGradientAngle = 0!
        Me.ProgressBar1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.RecentlyUsed = False
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "All"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Female"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Male"
        '
        'pdoc
        '
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
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
        'pStats
        '
        '
        'frmScholasticaMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BackgroundImageUnderCaption = True
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScholasticaMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scholastica"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
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
        CType(Me.dGridStatements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expandablePanel1.ResumeLayout(False)
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel3.ResumeLayout(False)
        Me.SideNavPanel3.PerformLayout()
        CType(Me.splitOwings.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitOwings.Panel1.ResumeLayout(False)
        Me.splitOwings.Panel1.PerformLayout()
        CType(Me.splitOwings.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitOwings.Panel2.ResumeLayout(False)
        Me.splitOwings.Panel2.PerformLayout()
        CType(Me.splitOwings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitOwings.ResumeLayout(False)
        CType(Me.dGridOwings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar5.ResumeLayout(False)
        Me.Bar5.PerformLayout()
        Me.SideNavPanel5.ResumeLayout(False)
        Me.SideNavPanel5.PerformLayout()
        CType(Me.dGridReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNavPanel4.ResumeLayout(False)
        Me.SideNavPanel4.PerformLayout()
        Me.panelEx1.ResumeLayout(False)
        Me.SideNavPanel6.ResumeLayout(False)
        Me.SideNavPanel6.PerformLayout()
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
        Me.SideNavPanel2.ResumeLayout(False)
        Me.SideNavPanel2.PerformLayout()
        CType(Me.dGridSchoolStaff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.KryptonComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Protected WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel4 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel3 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem3 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem4 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem5 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewStudent As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditStudent As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteStudent As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintStudents As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshStudents As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalSelected As DevComponents.DotNetBar.LabelItem
    Friend WithEvents splitMain As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Private WithEvents imageListStudents As System.Windows.Forms.ImageList
    Friend WithEvents tvClasses As System.Windows.Forms.TreeView
    Friend WithEvents dGridStudents As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents lblCurrentClass As System.Windows.Forms.Label
    Friend WithEvents chkActiveSearch As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnFind As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboGender As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents btnImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnMasterImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTransactionImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnManageStudents As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTerminate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnMassTerminate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewStaff As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditStaff As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteStaff As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintStaffList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshStaff As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents ButtonSpecAny1 As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonComboBox1 As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents dGridSchoolStaff As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents txtAmountFrom As Numberbox.Numberbox
    Friend WithEvents txtAmountTo As Numberbox.Numberbox
    Friend WithEvents btnPrintOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintListOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSelectedStatementOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAllStatementsOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSelectedReminder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAllReminders As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintForHandOver As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSmsReminderOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents btnAmtFilter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalOwings As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalRecords As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents pdoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents dGridStatements As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SideNavPanel5 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents Receipts As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents KryptonBorderEdge30 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge31 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReceiptDetails As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintReceiptDetails As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblReceiptTotalSelected As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge32 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar8 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblAllReceiptAmt As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge35 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge34 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpStartFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpEndTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge33 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnGo As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dGridReceipts As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnActivities As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnReceiptSelected As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBillSelectedStudent As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTerminateSelectedStudent As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelectedStudentStatement As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnInvoiceSelectedStudent As DevComponents.DotNetBar.ButtonItem
    Private WithEvents panelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents recentDocsItemPane As DevComponents.DotNetBar.ItemPanel
    Private WithEvents btnClasses As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnSubjects As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnExtraPaymentDescriptions As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnSubjectsPaymentsTable As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPrivateSchoolFees As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnSchoolClassification As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnNewStudentNumberParameters As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnBilliableMaximum As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents KryptonBorderEdge39 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge38 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge37 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge36 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnTakeonBalances As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblActiveClass As DevComponents.DotNetBar.LabelItem
    Friend WithEvents splitOwings As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents optUnselectAll As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optSelectAll As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonBorderEdge48 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge49 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge46 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents tvClasses2 As System.Windows.Forms.TreeView
    Friend WithEvents KryptonBorderEdge47 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridOwings As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents lblActiveClassOwings As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Private WithEvents btnYearEndProcedures As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ProgressBar1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents btnRefreshReceipts As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboType As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents btnImportAll As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPayments As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnStudentsListing As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnStudentStatement As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTerminateStudent As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPaymentAllocations As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SideNavPanel6 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents KryptonBorderEdge43 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge42 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge41 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge40 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SideNavItem6 As DevComponents.DotNetBar.Controls.SideNavItem
    Private WithEvents imageList1 As ImageList
    Private WithEvents imageList2 As ImageList
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Private WithEvents tvReports As TreeView
    Friend WithEvents KryptonBorderEdge44 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents pnlPreview As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridPreview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents labelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dGridTransactions As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Private WithEvents integerInput1 As DevComponents.Editors.IntegerInput
    Private WithEvents labelX4 As DevComponents.DotNetBar.LabelX
    Private WithEvents btnPrintPreview As DevComponents.DotNetBar.ButtonX
    Friend WithEvents KryptonBorderEdge45 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar16 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge50 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Private WithEvents btnSponsors As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnPrior As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnFees As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBilling As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintTermInvoices As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllStatements As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pStats As Printing.PrintDocument
    Friend WithEvents btnAdhocBilling As DevComponents.DotNetBar.ButtonItem
End Class
