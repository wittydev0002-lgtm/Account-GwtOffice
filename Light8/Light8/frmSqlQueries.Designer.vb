<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSqlQueries
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSqlQueries))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Staff reviews", 1, 1)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Project meetings", 1, 1)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Appointments", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Primary Health Care", 2, 2)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Assistance", 3, 3)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Occupational Health Services", 4, 4)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Injury On Duty", 4, 4)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Chronic Disease Management", 4, 4)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TB Management", 2, 2)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HIV Management", 3, 3)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Medical Screening", 4, 4)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Disability Management", 2, 2)
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Absence Management", 3, 3)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary Report", 1, 1)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Management Reports", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14})
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ColorPalette = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.myDocument = New System.Drawing.Printing.PrintDocument()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tabReport = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel15 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel31 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabItem15 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel14 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel15 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgridCharting = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.KryptonPanel34 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel35 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge30 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnPreviewChart = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cboSourceData = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.txtChartColumnIndex = New System.Windows.Forms.TextBox()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel32 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel33 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel15 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboChartType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.chkPrintSummary = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chkPrintFinalTotals = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chkDrawChart = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.TabItem14 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel13 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel37 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridHighLights = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel38 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboHighlightColor = New System.Windows.Forms.ComboBox()
        Me.btnAddHighLight = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtColumnValue = New System.Windows.Forms.TextBox()
        Me.txtColumnNumber = New System.Windows.Forms.TextBox()
        Me.TabItem13 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel12 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel39 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgridReportFieldProperty = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabItem12 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel11 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel29 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel28 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboGroupIndex = New System.Windows.Forms.ComboBox()
        Me.cboAlternateBackColor = New System.Windows.Forms.ComboBox()
        Me.cboBorderColor = New System.Windows.Forms.ComboBox()
        Me.KryptonPanel27 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel26 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel25 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel24 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboGridColor = New System.Windows.Forms.ComboBox()
        Me.cboGridLines = New System.Windows.Forms.ComboBox()
        Me.cboPrintBorder = New System.Windows.Forms.ComboBox()
        Me.KryptonPanel23 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel22 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge31 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboDetailsFontColor = New System.Windows.Forms.ComboBox()
        Me.cboDetailsFontSize = New System.Windows.Forms.ComboBox()
        Me.cboDetailsFont = New System.Windows.Forms.ComboBox()
        Me.KryptonPanel21 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge32 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel20 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge33 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel19 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge34 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboFooterColor = New System.Windows.Forms.ComboBox()
        Me.cboFooterSize = New System.Windows.Forms.ComboBox()
        Me.cboFooterFont = New System.Windows.Forms.ComboBox()
        Me.TxtFooterTitle = New System.Windows.Forms.TextBox()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge35 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel17 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge36 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboHeaderFontSize = New System.Windows.Forms.ComboBox()
        Me.cboHeaderFont = New System.Windows.Forms.ComboBox()
        Me.cboHeaderColor = New System.Windows.Forms.ComboBox()
        Me.KryptonPanel30 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge37 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtPageHeader = New System.Windows.Forms.TextBox()
        Me.TabItem11 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel36 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TabFunctions = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel9 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.TabItem9 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridRelations = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboJoinType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboRightField = New System.Windows.Forms.ComboBox()
        Me.cboRightTable = New System.Windows.Forms.ComboBox()
        Me.cboLeftField = New System.Windows.Forms.ComboBox()
        Me.cboLeftTable = New System.Windows.Forms.ComboBox()
        Me.btnAddJoin = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel10 = New DevComponents.DotNetBar.TabControlPanel()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.TabItem10 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel8 = New DevComponents.DotNetBar.TabControlPanel()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.TabItem8 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel7 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dGridSorts = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSortFields = New System.Windows.Forms.ComboBox()
        Me.cboDirection = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.TabItem7 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dGridGroups = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboGroupField = New System.Windows.Forms.ComboBox()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAddGroup = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.TabItem6 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dGridFilter = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnAddFilter = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCombination = New System.Windows.Forms.ComboBox()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.cboComparison = New System.Windows.Forms.ComboBox()
        Me.cboDataType = New System.Windows.Forms.ComboBox()
        Me.cboTableField = New System.Windows.Forms.ComboBox()
        Me.cboFilterTableName = New System.Windows.Forms.ComboBox()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonHeader2 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridFields = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNewConnection = New DevComponents.DotNetBar.ButtonItem()
        Me.tsGenerate = New DevComponents.DotNetBar.ButtonItem()
        Me.tsRun = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUnselect = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuSaveReportOnly = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuSaveStructureOnly = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuSaveBoth = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSingleSend = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuPreviewReport = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuPrintReport = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuPublish = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintWysiwhyg = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.lblRowCount = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.tabReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabReport.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel15.SuspendLayout()
        CType(Me.KryptonPanel31, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel31.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabControlPanel14.SuspendLayout()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel15.SuspendLayout()
        CType(Me.dgridCharting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel34, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel34.SuspendLayout()
        CType(Me.KryptonPanel35, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel35.SuspendLayout()
        CType(Me.cboSourceData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel32, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel32.SuspendLayout()
        CType(Me.KryptonPanel33, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel33.SuspendLayout()
        CType(Me.cboChartType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel13.SuspendLayout()
        CType(Me.KryptonPanel37, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel37.SuspendLayout()
        CType(Me.dGridHighLights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel38, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel38.SuspendLayout()
        Me.TabControlPanel12.SuspendLayout()
        CType(Me.KryptonPanel39, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel39.SuspendLayout()
        CType(Me.dgridReportFieldProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel11.SuspendLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel29, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel29.SuspendLayout()
        CType(Me.KryptonPanel28, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel28.SuspendLayout()
        CType(Me.KryptonPanel27, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel27.SuspendLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel26.SuspendLayout()
        CType(Me.KryptonPanel25, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel25.SuspendLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel24.SuspendLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel23.SuspendLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel22.SuspendLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel21.SuspendLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel20.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel17.SuspendLayout()
        CType(Me.KryptonPanel30, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel30.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        CType(Me.KryptonPanel36, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.TabFunctions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFunctions.SuspendLayout()
        Me.TabControlPanel9.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel4.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.dGridRelations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        Me.TabControlPanel10.SuspendLayout()
        Me.TabControlPanel8.SuspendLayout()
        Me.TabControlPanel7.SuspendLayout()
        CType(Me.dGridSorts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        CType(Me.dGridGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        CType(Me.dGridFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.dGridFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.expandablePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Table"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 140
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Field"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Expression"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 160
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Where Value"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Sort by"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Friendly Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AllowFullOpen = False
        Me.ColorDialog1.FullOpen = True
        Me.ColorDialog1.SolidColorOnly = True
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonSplitContainer1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(952, 656)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(1, 27)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonPanel2)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(950, 628)
        Me.KryptonSplitContainer1.SplitterDistance = 750
        Me.KryptonSplitContainer1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonSplitContainer1.StateCommon.Separator.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonSplitContainer1.StateCommon.Separator.Border.Rounding = 0
        Me.KryptonSplitContainer1.TabIndex = 7
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.tabReport)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Padding = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel3.Size = New System.Drawing.Size(749, 628)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 8
        '
        'tabReport
        '
        Me.tabReport.BackColor = System.Drawing.Color.Transparent
        Me.tabReport.CanReorderTabs = True
        Me.tabReport.ColorScheme.TabBackground = System.Drawing.Color.Transparent
        Me.tabReport.ColorScheme.TabBackground2 = System.Drawing.Color.Transparent
        Me.tabReport.ColorScheme.TabBorder = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(249, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(248, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(247, Byte), Integer)), 1.0!)})
        Me.tabReport.ColorScheme.TabItemBorder = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemBorderDark = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemBorderLight = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemHotBackground = System.Drawing.Color.Empty
        Me.tabReport.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(235, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(168, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(89, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer)), 1.0!)})
        Me.tabReport.ColorScheme.TabItemHotBorder = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemHotBorderDark = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemHotBorderLight = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.Orange
        Me.tabReport.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.White
        Me.tabReport.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 1.0!)})
        Me.tabReport.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemSelectedBorderDark = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.Silver
        Me.tabReport.ColorScheme.TabItemText = System.Drawing.SystemColors.ActiveCaptionText
        Me.tabReport.Controls.Add(Me.TabControlPanel1)
        Me.tabReport.Controls.Add(Me.TabControlPanel2)
        Me.tabReport.Controls.Add(Me.TabControlPanel3)
        Me.tabReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabReport.ForeColor = System.Drawing.Color.Black
        Me.tabReport.Location = New System.Drawing.Point(6, 6)
        Me.tabReport.Name = "tabReport"
        Me.tabReport.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabReport.SelectedTabIndex = 3
        Me.tabReport.Size = New System.Drawing.Size(737, 616)
        Me.tabReport.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.tabReport.TabIndex = 3
        Me.tabReport.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabReport.Tabs.Add(Me.TabItem1)
        Me.tabReport.Tabs.Add(Me.TabItem2)
        Me.tabReport.Tabs.Add(Me.TabItem3)
        Me.tabReport.Text = "TabControl1"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.KryptonPanel11)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(737, 589)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.Controls.Add(Me.TabControl1)
        Me.KryptonPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel11.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(735, 587)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.Transparent
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.ColorScheme.TabBackground = System.Drawing.Color.Transparent
        Me.TabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.Transparent
        Me.TabControl1.ColorScheme.TabBorder = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(249, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(248, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(247, Byte), Integer)), 1.0!)})
        Me.TabControl1.ColorScheme.TabItemBorder = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemBorderDark = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemBorderLight = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemHotBackground = System.Drawing.Color.Empty
        Me.TabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(235, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(168, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(89, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer)), 1.0!)})
        Me.TabControl1.ColorScheme.TabItemHotBorder = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemHotBorderDark = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemHotBorderLight = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.Orange
        Me.TabControl1.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.White
        Me.TabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 1.0!)})
        Me.TabControl1.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemSelectedBorderDark = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.Silver
        Me.TabControl1.ColorScheme.TabItemText = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabControl1.Controls.Add(Me.TabControlPanel11)
        Me.TabControl1.Controls.Add(Me.TabControlPanel15)
        Me.TabControl1.Controls.Add(Me.TabControlPanel14)
        Me.TabControl1.Controls.Add(Me.TabControlPanel13)
        Me.TabControl1.Controls.Add(Me.TabControlPanel12)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 3
        Me.TabControl1.Size = New System.Drawing.Size(735, 587)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.TabControl1.TabIndex = 2
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem11)
        Me.TabControl1.Tabs.Add(Me.TabItem12)
        Me.TabControl1.Tabs.Add(Me.TabItem13)
        Me.TabControl1.Tabs.Add(Me.TabItem14)
        Me.TabControl1.Tabs.Add(Me.TabItem15)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel15
        '
        Me.TabControlPanel15.Controls.Add(Me.KryptonPanel31)
        Me.TabControlPanel15.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel15.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel15.Name = "TabControlPanel15"
        Me.TabControlPanel15.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel15.Size = New System.Drawing.Size(735, 560)
        Me.TabControlPanel15.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel15.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel15.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel15.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel15.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel15.Style.GradientAngle = -90
        Me.TabControlPanel15.TabIndex = 5
        Me.TabControlPanel15.TabItem = Me.TabItem15
        '
        'KryptonPanel31
        '
        Me.KryptonPanel31.Controls.Add(Me.TableLayoutPanel2)
        Me.KryptonPanel31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel31.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel31.Name = "KryptonPanel31"
        Me.KryptonPanel31.Size = New System.Drawing.Size(733, 558)
        Me.KryptonPanel31.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel31.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel31.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel31.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel31.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(733, 558)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(5, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(357, 548)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(370, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(358, 548)
        Me.Panel3.TabIndex = 1
        '
        'TabItem15
        '
        Me.TabItem15.AttachedControl = Me.TabControlPanel15
        Me.TabItem15.Name = "TabItem15"
        Me.TabItem15.Text = "Graph Preview"
        '
        'TabControlPanel14
        '
        Me.TabControlPanel14.Controls.Add(Me.KryptonPanel15)
        Me.TabControlPanel14.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel14.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel14.Name = "TabControlPanel14"
        Me.TabControlPanel14.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel14.Size = New System.Drawing.Size(735, 560)
        Me.TabControlPanel14.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel14.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel14.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel14.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel14.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel14.Style.GradientAngle = -90
        Me.TabControlPanel14.TabIndex = 4
        Me.TabControlPanel14.TabItem = Me.TabItem14
        '
        'KryptonPanel15
        '
        Me.KryptonPanel15.Controls.Add(Me.dgridCharting)
        Me.KryptonPanel15.Controls.Add(Me.KryptonPanel34)
        Me.KryptonPanel15.Controls.Add(Me.KryptonPanel32)
        Me.KryptonPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel15.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel15.Name = "KryptonPanel15"
        Me.KryptonPanel15.Size = New System.Drawing.Size(733, 558)
        Me.KryptonPanel15.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.KryptonPanel15.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel15.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel15.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel15.TabIndex = 1
        '
        'dgridCharting
        '
        Me.dgridCharting.AllowUserToAddRows = False
        Me.dgridCharting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgridCharting.Location = New System.Drawing.Point(0, 94)
        Me.dgridCharting.Name = "dgridCharting"
        Me.dgridCharting.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dgridCharting.ReadOnly = True
        Me.dgridCharting.RowHeadersWidth = 25
        Me.dgridCharting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgridCharting.Size = New System.Drawing.Size(733, 464)
        Me.dgridCharting.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dgridCharting.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dgridCharting.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgridCharting.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgridCharting.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridCharting.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridCharting.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgridCharting.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgridCharting.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgridCharting.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridCharting.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridCharting.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dgridCharting.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgridCharting.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgridCharting.TabIndex = 26
        '
        'KryptonPanel34
        '
        Me.KryptonPanel34.Controls.Add(Me.KryptonPanel35)
        Me.KryptonPanel34.Controls.Add(Me.btnPreviewChart)
        Me.KryptonPanel34.Controls.Add(Me.cboSourceData)
        Me.KryptonPanel34.Controls.Add(Me.txtChartColumnIndex)
        Me.KryptonPanel34.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel34.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel34.Location = New System.Drawing.Point(0, 51)
        Me.KryptonPanel34.Name = "KryptonPanel34"
        Me.KryptonPanel34.Size = New System.Drawing.Size(733, 43)
        Me.KryptonPanel34.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel34.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel34.TabIndex = 1
        '
        'KryptonPanel35
        '
        Me.KryptonPanel35.Controls.Add(Me.KryptonLabel16)
        Me.KryptonPanel35.Controls.Add(Me.KryptonBorderEdge30)
        Me.KryptonPanel35.Location = New System.Drawing.Point(20, 11)
        Me.KryptonPanel35.Name = "KryptonPanel35"
        Me.KryptonPanel35.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel35.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel35.TabIndex = 28
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel16.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel16.TabIndex = 1
        Me.KryptonLabel16.Values.Text = "Source Column"
        '
        'KryptonBorderEdge30
        '
        Me.KryptonBorderEdge30.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge30.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge30.Name = "KryptonBorderEdge30"
        Me.KryptonBorderEdge30.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge30.Text = "KryptonBorderEdge30"
        '
        'btnPreviewChart
        '
        Me.btnPreviewChart.AutoSize = True
        Me.btnPreviewChart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPreviewChart.Location = New System.Drawing.Point(267, 10)
        Me.btnPreviewChart.Name = "btnPreviewChart"
        Me.btnPreviewChart.Size = New System.Drawing.Size(83, 22)
        Me.btnPreviewChart.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnPreviewChart.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnPreviewChart.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnPreviewChart.StateCommon.Border.Rounding = 0
        Me.btnPreviewChart.StateCommon.Border.Width = 1
        Me.btnPreviewChart.TabIndex = 27
        Me.btnPreviewChart.Values.Text = "Preview Chart"
        '
        'cboSourceData
        '
        Me.cboSourceData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceData.DropDownWidth = 169
        Me.cboSourceData.Items.AddRange(New Object() {"Values", "Count"})
        Me.cboSourceData.Location = New System.Drawing.Point(169, 11)
        Me.cboSourceData.Name = "cboSourceData"
        Me.cboSourceData.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSourceData.Size = New System.Drawing.Size(92, 21)
        Me.cboSourceData.TabIndex = 26
        '
        'txtChartColumnIndex
        '
        Me.txtChartColumnIndex.Location = New System.Drawing.Point(128, 12)
        Me.txtChartColumnIndex.Name = "txtChartColumnIndex"
        Me.txtChartColumnIndex.Size = New System.Drawing.Size(38, 20)
        Me.txtChartColumnIndex.TabIndex = 25
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 42)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(733, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'KryptonPanel32
        '
        Me.KryptonPanel32.Controls.Add(Me.KryptonBorderEdge28)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel33)
        Me.KryptonPanel32.Controls.Add(Me.cboChartType)
        Me.KryptonPanel32.Controls.Add(Me.chkPrintSummary)
        Me.KryptonPanel32.Controls.Add(Me.chkPrintFinalTotals)
        Me.KryptonPanel32.Controls.Add(Me.chkDrawChart)
        Me.KryptonPanel32.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel32.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel32.Name = "KryptonPanel32"
        Me.KryptonPanel32.Size = New System.Drawing.Size(733, 51)
        Me.KryptonPanel32.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel32.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel32.TabIndex = 0
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(733, 1)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'KryptonPanel33
        '
        Me.KryptonPanel33.Controls.Add(Me.KryptonLabel15)
        Me.KryptonPanel33.Controls.Add(Me.KryptonBorderEdge27)
        Me.KryptonPanel33.Location = New System.Drawing.Point(358, 14)
        Me.KryptonPanel33.Name = "KryptonPanel33"
        Me.KryptonPanel33.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel33.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel33.TabIndex = 27
        '
        'KryptonLabel15
        '
        Me.KryptonLabel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel15.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel15.Name = "KryptonLabel15"
        Me.KryptonLabel15.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel15.TabIndex = 1
        Me.KryptonLabel15.Values.Text = "Chart Type"
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'cboChartType
        '
        Me.cboChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChartType.DropDownWidth = 169
        Me.cboChartType.Location = New System.Drawing.Point(465, 14)
        Me.cboChartType.Name = "cboChartType"
        Me.cboChartType.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboChartType.Size = New System.Drawing.Size(169, 21)
        Me.cboChartType.TabIndex = 26
        '
        'chkPrintSummary
        '
        Me.chkPrintSummary.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkPrintSummary.Location = New System.Drawing.Point(136, 17)
        Me.chkPrintSummary.Name = "chkPrintSummary"
        Me.chkPrintSummary.Size = New System.Drawing.Size(104, 20)
        Me.chkPrintSummary.TabIndex = 24
        Me.chkPrintSummary.Text = "Print Summary"
        Me.chkPrintSummary.Values.Text = "Print Summary"
        '
        'chkPrintFinalTotals
        '
        Me.chkPrintFinalTotals.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkPrintFinalTotals.Location = New System.Drawing.Point(20, 17)
        Me.chkPrintFinalTotals.Name = "chkPrintFinalTotals"
        Me.chkPrintFinalTotals.Size = New System.Drawing.Size(113, 20)
        Me.chkPrintFinalTotals.TabIndex = 23
        Me.chkPrintFinalTotals.Text = "Print Final Totals"
        Me.chkPrintFinalTotals.Values.Text = "Print Final Totals"
        '
        'chkDrawChart
        '
        Me.chkDrawChart.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkDrawChart.Location = New System.Drawing.Point(245, 17)
        Me.chkDrawChart.Name = "chkDrawChart"
        Me.chkDrawChart.Size = New System.Drawing.Size(108, 20)
        Me.chkDrawChart.TabIndex = 25
        Me.chkDrawChart.Text = "Chart Summary"
        Me.chkDrawChart.Values.Text = "Chart Summary"
        '
        'TabItem14
        '
        Me.TabItem14.AttachedControl = Me.TabControlPanel14
        Me.TabItem14.Name = "TabItem14"
        Me.TabItem14.Text = "Summary and Charting"
        '
        'TabControlPanel13
        '
        Me.TabControlPanel13.Controls.Add(Me.KryptonPanel37)
        Me.TabControlPanel13.Controls.Add(Me.KryptonPanel38)
        Me.TabControlPanel13.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel13.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel13.Name = "TabControlPanel13"
        Me.TabControlPanel13.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel13.Size = New System.Drawing.Size(735, 560)
        Me.TabControlPanel13.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel13.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel13.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel13.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel13.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel13.Style.GradientAngle = -90
        Me.TabControlPanel13.TabIndex = 3
        Me.TabControlPanel13.TabItem = Me.TabItem13
        '
        'KryptonPanel37
        '
        Me.KryptonPanel37.Controls.Add(Me.dGridHighLights)
        Me.KryptonPanel37.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel37.Location = New System.Drawing.Point(1, 49)
        Me.KryptonPanel37.Name = "KryptonPanel37"
        Me.KryptonPanel37.Padding = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel37.Size = New System.Drawing.Size(733, 510)
        Me.KryptonPanel37.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel37.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel37.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel37.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel37.TabIndex = 1
        '
        'dGridHighLights
        '
        Me.dGridHighLights.AllowUserToAddRows = False
        Me.dGridHighLights.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column17, Me.Column18, Me.Column19})
        Me.dGridHighLights.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridHighLights.Location = New System.Drawing.Point(6, 6)
        Me.dGridHighLights.Name = "dGridHighLights"
        Me.dGridHighLights.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGridHighLights.ReadOnly = True
        Me.dGridHighLights.RowHeadersWidth = 25
        Me.dGridHighLights.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridHighLights.Size = New System.Drawing.Size(721, 498)
        Me.dGridHighLights.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridHighLights.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridHighLights.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridHighLights.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridHighLights.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridHighLights.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridHighLights.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridHighLights.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridHighLights.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridHighLights.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridHighLights.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridHighLights.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridHighLights.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridHighLights.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridHighLights.TabIndex = 2
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column17.HeaderText = "Column"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 80
        '
        'Column18
        '
        Me.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column18.HeaderText = "Value"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 67
        '
        'Column19
        '
        Me.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column19.HeaderText = "High Light Color"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Width = 127
        '
        'KryptonPanel38
        '
        Me.KryptonPanel38.Controls.Add(Me.Label17)
        Me.KryptonPanel38.Controls.Add(Me.Label16)
        Me.KryptonPanel38.Controls.Add(Me.Label15)
        Me.KryptonPanel38.Controls.Add(Me.cboHighlightColor)
        Me.KryptonPanel38.Controls.Add(Me.btnAddHighLight)
        Me.KryptonPanel38.Controls.Add(Me.txtColumnValue)
        Me.KryptonPanel38.Controls.Add(Me.txtColumnNumber)
        Me.KryptonPanel38.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel38.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel38.Name = "KryptonPanel38"
        Me.KryptonPanel38.Size = New System.Drawing.Size(733, 48)
        Me.KryptonPanel38.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel38.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel38.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel38.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel38.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(339, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 20)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Color"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DimGray
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(133, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 20)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Value"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(15, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 20)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Column #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboHighlightColor
        '
        Me.cboHighlightColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHighlightColor.FormattingEnabled = True
        Me.cboHighlightColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboHighlightColor.Location = New System.Drawing.Point(387, 13)
        Me.cboHighlightColor.Name = "cboHighlightColor"
        Me.cboHighlightColor.Size = New System.Drawing.Size(204, 21)
        Me.cboHighlightColor.TabIndex = 20
        '
        'btnAddHighLight
        '
        Me.btnAddHighLight.AutoSize = True
        Me.btnAddHighLight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddHighLight.Location = New System.Drawing.Point(593, 12)
        Me.btnAddHighLight.Name = "btnAddHighLight"
        Me.btnAddHighLight.Size = New System.Drawing.Size(48, 22)
        Me.btnAddHighLight.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnAddHighLight.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAddHighLight.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAddHighLight.StateCommon.Border.Rounding = 0
        Me.btnAddHighLight.StateCommon.Border.Width = 1
        Me.btnAddHighLight.TabIndex = 19
        Me.btnAddHighLight.Values.Image = CType(resources.GetObject("btnAddHighLight.Values.Image"), System.Drawing.Image)
        Me.btnAddHighLight.Values.Text = "Add"
        '
        'txtColumnValue
        '
        Me.txtColumnValue.Location = New System.Drawing.Point(181, 14)
        Me.txtColumnValue.Name = "txtColumnValue"
        Me.txtColumnValue.Size = New System.Drawing.Size(154, 20)
        Me.txtColumnValue.TabIndex = 18
        '
        'txtColumnNumber
        '
        Me.txtColumnNumber.Location = New System.Drawing.Point(96, 14)
        Me.txtColumnNumber.Name = "txtColumnNumber"
        Me.txtColumnNumber.Size = New System.Drawing.Size(31, 20)
        Me.txtColumnNumber.TabIndex = 17
        Me.txtColumnNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabItem13
        '
        Me.TabItem13.AttachedControl = Me.TabControlPanel13
        Me.TabItem13.Name = "TabItem13"
        Me.TabItem13.Text = "Highlights"
        '
        'TabControlPanel12
        '
        Me.TabControlPanel12.Controls.Add(Me.KryptonPanel39)
        Me.TabControlPanel12.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel12.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel12.Name = "TabControlPanel12"
        Me.TabControlPanel12.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel12.Size = New System.Drawing.Size(735, 560)
        Me.TabControlPanel12.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel12.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel12.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel12.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel12.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel12.Style.GradientAngle = -90
        Me.TabControlPanel12.TabIndex = 2
        Me.TabControlPanel12.TabItem = Me.TabItem12
        '
        'KryptonPanel39
        '
        Me.KryptonPanel39.Controls.Add(Me.dgridReportFieldProperty)
        Me.KryptonPanel39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel39.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel39.Name = "KryptonPanel39"
        Me.KryptonPanel39.Padding = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel39.Size = New System.Drawing.Size(733, 558)
        Me.KryptonPanel39.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel39.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel39.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel39.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel39.TabIndex = 0
        '
        'dgridReportFieldProperty
        '
        Me.dgridReportFieldProperty.AllowUserToAddRows = False
        Me.dgridReportFieldProperty.AllowUserToDeleteRows = False
        Me.dgridReportFieldProperty.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.Column13, Me.Column14, Me.Column15, Me.Column16})
        Me.dgridReportFieldProperty.DataMember = "TestData"
        Me.dgridReportFieldProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgridReportFieldProperty.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed
        Me.dgridReportFieldProperty.Location = New System.Drawing.Point(6, 6)
        Me.dgridReportFieldProperty.Name = "dgridReportFieldProperty"
        Me.dgridReportFieldProperty.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dgridReportFieldProperty.RowHeadersWidth = 25
        Me.dgridReportFieldProperty.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgridReportFieldProperty.RowTemplate.Height = 27
        Me.dgridReportFieldProperty.Size = New System.Drawing.Size(721, 546)
        Me.dgridReportFieldProperty.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dgridReportFieldProperty.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dgridReportFieldProperty.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgridReportFieldProperty.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgridReportFieldProperty.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridReportFieldProperty.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridReportFieldProperty.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgridReportFieldProperty.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgridReportFieldProperty.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgridReportFieldProperty.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridReportFieldProperty.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgridReportFieldProperty.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dgridReportFieldProperty.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgridReportFieldProperty.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgridReportFieldProperty.TabIndex = 18
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = ""
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn10.Width = 30
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.HeaderText = "Field Name"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn12.HeaderText = "Friendly Name"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Size"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 60
        '
        'Column14
        '
        Me.Column14.HeaderText = "Format"
        Me.Column14.Items.AddRange(New Object() {"YES", "NO"})
        Me.Column14.Name = "Column14"
        Me.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column14.Width = 60
        '
        'Column15
        '
        Me.Column15.HeaderText = "Align"
        Me.Column15.Items.AddRange(New Object() {"Left", "Center", "Right"})
        Me.Column15.Name = "Column15"
        Me.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column15.Width = 60
        '
        'Column16
        '
        Me.Column16.HeaderText = "Total"
        Me.Column16.Items.AddRange(New Object() {"YES", "NO"})
        Me.Column16.Name = "Column16"
        Me.Column16.Width = 60
        '
        'TabItem12
        '
        Me.TabItem12.AttachedControl = Me.TabControlPanel12
        Me.TabItem12.Name = "TabItem12"
        Me.TabItem12.Text = "Details"
        '
        'TabControlPanel11
        '
        Me.TabControlPanel11.Controls.Add(Me.KryptonPanel16)
        Me.TabControlPanel11.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel11.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel11.Name = "TabControlPanel11"
        Me.TabControlPanel11.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel11.Size = New System.Drawing.Size(735, 560)
        Me.TabControlPanel11.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel11.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel11.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel11.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel11.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel11.Style.GradientAngle = -90
        Me.TabControlPanel11.TabIndex = 1
        Me.TabControlPanel11.TabItem = Me.TabItem11
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel16.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Padding = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel16.Size = New System.Drawing.Size(733, 558)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel16.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel16.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel16.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel16.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel29)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel28)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboGroupIndex)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboAlternateBackColor)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboBorderColor)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel27)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel26)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel25)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel24)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboGridColor)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboGridLines)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboPrintBorder)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel23)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel22)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboDetailsFontColor)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboDetailsFontSize)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboDetailsFont)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel21)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel20)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel19)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboFooterColor)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboFooterSize)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboFooterFont)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.TxtFooterTitle)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel18)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel17)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboHeaderFontSize)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboHeaderFont)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboHeaderColor)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel30)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtPageHeader)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(721, 546)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'KryptonPanel29
        '
        Me.KryptonPanel29.Controls.Add(Me.KryptonLabel14)
        Me.KryptonPanel29.Controls.Add(Me.KryptonBorderEdge26)
        Me.KryptonPanel29.Location = New System.Drawing.Point(39, 246)
        Me.KryptonPanel29.Name = "KryptonPanel29"
        Me.KryptonPanel29.Size = New System.Drawing.Size(155, 21)
        Me.KryptonPanel29.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel29.TabIndex = 36
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel14.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(155, 20)
        Me.KryptonLabel14.TabIndex = 1
        Me.KryptonLabel14.Values.Text = "Group Key Column Index"
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(155, 1)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'KryptonPanel28
        '
        Me.KryptonPanel28.Controls.Add(Me.KryptonLabel13)
        Me.KryptonPanel28.Controls.Add(Me.KryptonBorderEdge25)
        Me.KryptonPanel28.Location = New System.Drawing.Point(39, 219)
        Me.KryptonPanel28.Name = "KryptonPanel28"
        Me.KryptonPanel28.Size = New System.Drawing.Size(155, 21)
        Me.KryptonPanel28.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel28.TabIndex = 35
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel13.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(155, 20)
        Me.KryptonLabel13.TabIndex = 1
        Me.KryptonLabel13.Values.Text = "Alternate Back Color"
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(155, 1)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'cboGroupIndex
        '
        Me.cboGroupIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroupIndex.FormattingEnabled = True
        Me.cboGroupIndex.Items.AddRange(New Object() {"NO", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.cboGroupIndex.Location = New System.Drawing.Point(196, 245)
        Me.cboGroupIndex.Name = "cboGroupIndex"
        Me.cboGroupIndex.Size = New System.Drawing.Size(46, 21)
        Me.cboGroupIndex.TabIndex = 34
        '
        'cboAlternateBackColor
        '
        Me.cboAlternateBackColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlternateBackColor.FormattingEnabled = True
        Me.cboAlternateBackColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboAlternateBackColor.Location = New System.Drawing.Point(196, 218)
        Me.cboAlternateBackColor.Name = "cboAlternateBackColor"
        Me.cboAlternateBackColor.Size = New System.Drawing.Size(224, 21)
        Me.cboAlternateBackColor.TabIndex = 33
        '
        'cboBorderColor
        '
        Me.cboBorderColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBorderColor.FormattingEnabled = True
        Me.cboBorderColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboBorderColor.Location = New System.Drawing.Point(329, 192)
        Me.cboBorderColor.Name = "cboBorderColor"
        Me.cboBorderColor.Size = New System.Drawing.Size(180, 21)
        Me.cboBorderColor.TabIndex = 32
        '
        'KryptonPanel27
        '
        Me.KryptonPanel27.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel27.Controls.Add(Me.KryptonBorderEdge24)
        Me.KryptonPanel27.Location = New System.Drawing.Point(222, 192)
        Me.KryptonPanel27.Name = "KryptonPanel27"
        Me.KryptonPanel27.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel27.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel27.TabIndex = 31
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel12.TabIndex = 1
        Me.KryptonLabel12.Values.Text = "Border Color"
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'KryptonPanel26
        '
        Me.KryptonPanel26.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel26.Controls.Add(Me.KryptonBorderEdge23)
        Me.KryptonPanel26.Location = New System.Drawing.Point(39, 192)
        Me.KryptonPanel26.Name = "KryptonPanel26"
        Me.KryptonPanel26.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel26.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel26.TabIndex = 30
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel11.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel11.TabIndex = 1
        Me.KryptonLabel11.Values.Text = "Page Border"
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonPanel25
        '
        Me.KryptonPanel25.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel25.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel25.Location = New System.Drawing.Point(39, 165)
        Me.KryptonPanel25.Name = "KryptonPanel25"
        Me.KryptonPanel25.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel25.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel25.TabIndex = 29
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel10.TabIndex = 1
        Me.KryptonLabel10.Values.Text = "Grid Lines"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonPanel24
        '
        Me.KryptonPanel24.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel24.Controls.Add(Me.KryptonBorderEdge21)
        Me.KryptonPanel24.Location = New System.Drawing.Point(403, 165)
        Me.KryptonPanel24.Name = "KryptonPanel24"
        Me.KryptonPanel24.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel24.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel24.TabIndex = 28
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel9.TabIndex = 1
        Me.KryptonLabel9.Values.Text = "Grid Color"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'cboGridColor
        '
        Me.cboGridColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGridColor.FormattingEnabled = True
        Me.cboGridColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboGridColor.Location = New System.Drawing.Point(512, 165)
        Me.cboGridColor.Name = "cboGridColor"
        Me.cboGridColor.Size = New System.Drawing.Size(137, 21)
        Me.cboGridColor.TabIndex = 27
        '
        'cboGridLines
        '
        Me.cboGridLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGridLines.FormattingEnabled = True
        Me.cboGridLines.Items.AddRange(New Object() {"None", "both", "Horizontal", "Vertical"})
        Me.cboGridLines.Location = New System.Drawing.Point(146, 165)
        Me.cboGridLines.Name = "cboGridLines"
        Me.cboGridLines.Size = New System.Drawing.Size(224, 21)
        Me.cboGridLines.TabIndex = 26
        '
        'cboPrintBorder
        '
        Me.cboPrintBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrintBorder.FormattingEnabled = True
        Me.cboPrintBorder.Items.AddRange(New Object() {"YES", "NO"})
        Me.cboPrintBorder.Location = New System.Drawing.Point(146, 192)
        Me.cboPrintBorder.Name = "cboPrintBorder"
        Me.cboPrintBorder.Size = New System.Drawing.Size(53, 21)
        Me.cboPrintBorder.TabIndex = 25
        '
        'KryptonPanel23
        '
        Me.KryptonPanel23.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel23.Controls.Add(Me.KryptonBorderEdge20)
        Me.KryptonPanel23.Location = New System.Drawing.Point(403, 138)
        Me.KryptonPanel23.Name = "KryptonPanel23"
        Me.KryptonPanel23.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel23.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel23.TabIndex = 24
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel8.TabIndex = 1
        Me.KryptonLabel8.Values.Text = "Detail Color"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonPanel22
        '
        Me.KryptonPanel22.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel22.Controls.Add(Me.KryptonBorderEdge31)
        Me.KryptonPanel22.Location = New System.Drawing.Point(39, 138)
        Me.KryptonPanel22.Name = "KryptonPanel22"
        Me.KryptonPanel22.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel22.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel22.TabIndex = 23
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Details Font/Size"
        '
        'KryptonBorderEdge31
        '
        Me.KryptonBorderEdge31.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge31.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge31.Name = "KryptonBorderEdge31"
        Me.KryptonBorderEdge31.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge31.Text = "KryptonBorderEdge19"
        '
        'cboDetailsFontColor
        '
        Me.cboDetailsFontColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDetailsFontColor.FormattingEnabled = True
        Me.cboDetailsFontColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboDetailsFontColor.Location = New System.Drawing.Point(512, 138)
        Me.cboDetailsFontColor.Name = "cboDetailsFontColor"
        Me.cboDetailsFontColor.Size = New System.Drawing.Size(137, 21)
        Me.cboDetailsFontColor.TabIndex = 22
        '
        'cboDetailsFontSize
        '
        Me.cboDetailsFontSize.FormattingEnabled = True
        Me.cboDetailsFontSize.Items.AddRange(New Object() {"6", "7", "8", "9", "10", "11", "12", "14", "16"})
        Me.cboDetailsFontSize.Location = New System.Drawing.Point(324, 138)
        Me.cboDetailsFontSize.Name = "cboDetailsFontSize"
        Me.cboDetailsFontSize.Size = New System.Drawing.Size(46, 21)
        Me.cboDetailsFontSize.TabIndex = 21
        '
        'cboDetailsFont
        '
        Me.cboDetailsFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDetailsFont.FormattingEnabled = True
        Me.cboDetailsFont.Location = New System.Drawing.Point(146, 138)
        Me.cboDetailsFont.Name = "cboDetailsFont"
        Me.cboDetailsFont.Size = New System.Drawing.Size(175, 21)
        Me.cboDetailsFont.TabIndex = 20
        '
        'KryptonPanel21
        '
        Me.KryptonPanel21.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel21.Controls.Add(Me.KryptonBorderEdge32)
        Me.KryptonPanel21.Location = New System.Drawing.Point(403, 111)
        Me.KryptonPanel21.Name = "KryptonPanel21"
        Me.KryptonPanel21.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel21.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel21.TabIndex = 19
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Footer Color"
        '
        'KryptonBorderEdge32
        '
        Me.KryptonBorderEdge32.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge32.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge32.Name = "KryptonBorderEdge32"
        Me.KryptonBorderEdge32.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge32.Text = "KryptonBorderEdge18"
        '
        'KryptonPanel20
        '
        Me.KryptonPanel20.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel20.Controls.Add(Me.KryptonBorderEdge33)
        Me.KryptonPanel20.Location = New System.Drawing.Point(39, 111)
        Me.KryptonPanel20.Name = "KryptonPanel20"
        Me.KryptonPanel20.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel20.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel20.TabIndex = 18
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Footer Font/Size"
        '
        'KryptonBorderEdge33
        '
        Me.KryptonBorderEdge33.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge33.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge33.Name = "KryptonBorderEdge33"
        Me.KryptonBorderEdge33.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge33.Text = "KryptonBorderEdge17"
        '
        'KryptonPanel19
        '
        Me.KryptonPanel19.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge34)
        Me.KryptonPanel19.Location = New System.Drawing.Point(39, 85)
        Me.KryptonPanel19.Name = "KryptonPanel19"
        Me.KryptonPanel19.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel19.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel19.TabIndex = 17
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Page Footer"
        '
        'KryptonBorderEdge34
        '
        Me.KryptonBorderEdge34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge34.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge34.Name = "KryptonBorderEdge34"
        Me.KryptonBorderEdge34.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge34.Text = "KryptonBorderEdge10"
        '
        'cboFooterColor
        '
        Me.cboFooterColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFooterColor.FormattingEnabled = True
        Me.cboFooterColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboFooterColor.Location = New System.Drawing.Point(512, 111)
        Me.cboFooterColor.Name = "cboFooterColor"
        Me.cboFooterColor.Size = New System.Drawing.Size(137, 21)
        Me.cboFooterColor.TabIndex = 16
        '
        'cboFooterSize
        '
        Me.cboFooterSize.FormattingEnabled = True
        Me.cboFooterSize.Items.AddRange(New Object() {"6", "7", "8", "9", "10", "11", "12", "14", "16"})
        Me.cboFooterSize.Location = New System.Drawing.Point(324, 111)
        Me.cboFooterSize.Name = "cboFooterSize"
        Me.cboFooterSize.Size = New System.Drawing.Size(46, 21)
        Me.cboFooterSize.TabIndex = 15
        '
        'cboFooterFont
        '
        Me.cboFooterFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFooterFont.FormattingEnabled = True
        Me.cboFooterFont.Location = New System.Drawing.Point(146, 111)
        Me.cboFooterFont.Name = "cboFooterFont"
        Me.cboFooterFont.Size = New System.Drawing.Size(175, 21)
        Me.cboFooterFont.TabIndex = 14
        '
        'TxtFooterTitle
        '
        Me.TxtFooterTitle.Location = New System.Drawing.Point(146, 86)
        Me.TxtFooterTitle.Name = "TxtFooterTitle"
        Me.TxtFooterTitle.Size = New System.Drawing.Size(503, 20)
        Me.TxtFooterTitle.TabIndex = 13
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge35)
        Me.KryptonPanel18.Location = New System.Drawing.Point(403, 59)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel18.TabIndex = 12
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Header Color"
        '
        'KryptonBorderEdge35
        '
        Me.KryptonBorderEdge35.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge35.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge35.Name = "KryptonBorderEdge35"
        Me.KryptonBorderEdge35.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge35.Text = "KryptonBorderEdge9"
        '
        'KryptonPanel17
        '
        Me.KryptonPanel17.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge36)
        Me.KryptonPanel17.Location = New System.Drawing.Point(39, 59)
        Me.KryptonPanel17.Name = "KryptonPanel17"
        Me.KryptonPanel17.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel17.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel17.TabIndex = 11
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Header Font/Size"
        '
        'KryptonBorderEdge36
        '
        Me.KryptonBorderEdge36.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge36.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge36.Name = "KryptonBorderEdge36"
        Me.KryptonBorderEdge36.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge36.Text = "KryptonBorderEdge8"
        '
        'cboHeaderFontSize
        '
        Me.cboHeaderFontSize.FormattingEnabled = True
        Me.cboHeaderFontSize.Items.AddRange(New Object() {"6", "7", "8", "9", "10", "11", "12", "14", "16"})
        Me.cboHeaderFontSize.Location = New System.Drawing.Point(324, 59)
        Me.cboHeaderFontSize.Name = "cboHeaderFontSize"
        Me.cboHeaderFontSize.Size = New System.Drawing.Size(46, 21)
        Me.cboHeaderFontSize.TabIndex = 9
        '
        'cboHeaderFont
        '
        Me.cboHeaderFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeaderFont.FormattingEnabled = True
        Me.cboHeaderFont.Location = New System.Drawing.Point(146, 59)
        Me.cboHeaderFont.Name = "cboHeaderFont"
        Me.cboHeaderFont.Size = New System.Drawing.Size(175, 21)
        Me.cboHeaderFont.TabIndex = 8
        '
        'cboHeaderColor
        '
        Me.cboHeaderColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeaderColor.FormattingEnabled = True
        Me.cboHeaderColor.Items.AddRange(New Object() {"Default", "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"})
        Me.cboHeaderColor.Location = New System.Drawing.Point(512, 59)
        Me.cboHeaderColor.Name = "cboHeaderColor"
        Me.cboHeaderColor.Size = New System.Drawing.Size(137, 21)
        Me.cboHeaderColor.TabIndex = 10
        '
        'KryptonPanel30
        '
        Me.KryptonPanel30.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel30.Controls.Add(Me.KryptonBorderEdge37)
        Me.KryptonPanel30.Location = New System.Drawing.Point(39, 32)
        Me.KryptonPanel30.Name = "KryptonPanel30"
        Me.KryptonPanel30.Size = New System.Drawing.Size(106, 21)
        Me.KryptonPanel30.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel30.TabIndex = 6
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(106, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Report Header"
        '
        'KryptonBorderEdge37
        '
        Me.KryptonBorderEdge37.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge37.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge37.Name = "KryptonBorderEdge37"
        Me.KryptonBorderEdge37.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge37.Text = "KryptonBorderEdge7"
        '
        'txtPageHeader
        '
        Me.txtPageHeader.Location = New System.Drawing.Point(146, 33)
        Me.txtPageHeader.Name = "txtPageHeader"
        Me.txtPageHeader.Size = New System.Drawing.Size(503, 20)
        Me.txtPageHeader.TabIndex = 5
        '
        'TabItem11
        '
        Me.TabItem11.AttachedControl = Me.TabControlPanel11
        Me.TabItem11.Name = "TabItem11"
        Me.TabItem11.Text = "Report Properties"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Report Designer"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.KryptonPanel36)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(737, 589)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.TabItem3
        '
        'KryptonPanel36
        '
        Me.KryptonPanel36.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel36.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel36.Name = "KryptonPanel36"
        Me.KryptonPanel36.Size = New System.Drawing.Size(735, 587)
        Me.KryptonPanel36.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel36.TabIndex = 0
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Report Preview"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.KryptonPanel4)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(12)
        Me.TabControlPanel1.Size = New System.Drawing.Size(737, 589)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel4.Controls.Add(Me.KryptonHeader1)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel4.Location = New System.Drawing.Point(12, 12)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(713, 565)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 0
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel5.Controls.Add(Me.KryptonHeader2)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 185)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(713, 380)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 2
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.Controls.Add(Me.TabFunctions)
        Me.KryptonPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel6.Location = New System.Drawing.Point(1, 31)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel6.Size = New System.Drawing.Size(711, 348)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 5
        '
        'TabFunctions
        '
        Me.TabFunctions.BackColor = System.Drawing.Color.Transparent
        Me.TabFunctions.CanReorderTabs = True
        Me.TabFunctions.ColorScheme.TabBackground = System.Drawing.Color.Transparent
        Me.TabFunctions.ColorScheme.TabBorder = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(249, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(248, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(247, Byte), Integer)), 1.0!)})
        Me.TabFunctions.ColorScheme.TabItemBorder = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemBorderDark = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemBorderLight = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemHotBackground = System.Drawing.Color.Empty
        Me.TabFunctions.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(235, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(168, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(89, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer)), 1.0!)})
        Me.TabFunctions.ColorScheme.TabItemHotBorder = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemHotBorderDark = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemHotBorderLight = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.Orange
        Me.TabFunctions.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.White
        Me.TabFunctions.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer)), 1.0!)})
        Me.TabFunctions.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemSelectedBorderDark = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.Silver
        Me.TabFunctions.ColorScheme.TabItemText = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabFunctions.Controls.Add(Me.TabControlPanel4)
        Me.TabFunctions.Controls.Add(Me.TabControlPanel9)
        Me.TabFunctions.Controls.Add(Me.TabControlPanel10)
        Me.TabFunctions.Controls.Add(Me.TabControlPanel8)
        Me.TabFunctions.Controls.Add(Me.TabControlPanel7)
        Me.TabFunctions.Controls.Add(Me.TabControlPanel6)
        Me.TabFunctions.Controls.Add(Me.TabControlPanel5)
        Me.TabFunctions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabFunctions.ForeColor = System.Drawing.Color.Black
        Me.TabFunctions.Location = New System.Drawing.Point(5, 5)
        Me.TabFunctions.Name = "TabFunctions"
        Me.TabFunctions.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabFunctions.SelectedTabIndex = 3
        Me.TabFunctions.Size = New System.Drawing.Size(701, 338)
        Me.TabFunctions.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabFunctions.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.TabFunctions.TabIndex = 2
        Me.TabFunctions.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabFunctions.Tabs.Add(Me.TabItem4)
        Me.TabFunctions.Tabs.Add(Me.TabItem5)
        Me.TabFunctions.Tabs.Add(Me.TabItem6)
        Me.TabFunctions.Tabs.Add(Me.TabItem7)
        Me.TabFunctions.Tabs.Add(Me.TabItem8)
        Me.TabFunctions.Tabs.Add(Me.TabItem9)
        Me.TabFunctions.Tabs.Add(Me.TabItem10)
        Me.TabFunctions.Text = "TabControl1"
        '
        'TabControlPanel9
        '
        Me.TabControlPanel9.Controls.Add(Me.dGrid)
        Me.TabControlPanel9.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel9.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel9.Name = "TabControlPanel9"
        Me.TabControlPanel9.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel9.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel9.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel9.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel9.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel9.Style.GradientAngle = -90
        Me.TabControlPanel9.TabIndex = 6
        Me.TabControlPanel9.TabItem = Me.TabItem9
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(1, 1)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.Size = New System.Drawing.Size(699, 309)
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
        Me.dGrid.TabIndex = 1
        '
        'TabItem9
        '
        Me.TabItem9.AttachedControl = Me.TabControlPanel9
        Me.TabItem9.Name = "TabItem9"
        Me.TabItem9.Text = "Results"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.KryptonPanel7)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = -90
        Me.TabControlPanel4.TabIndex = 1
        Me.TabControlPanel4.TabItem = Me.TabItem4
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.Controls.Add(Me.dGridRelations)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel7.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(699, 309)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel7.TabIndex = 0
        '
        'dGridRelations
        '
        Me.dGridRelations.AllowUserToAddRows = False
        Me.dGridRelations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.dGridRelations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridRelations.Location = New System.Drawing.Point(0, 86)
        Me.dGridRelations.Name = "dGridRelations"
        Me.dGridRelations.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGridRelations.ReadOnly = True
        Me.dGridRelations.RowHeadersWidth = 25
        Me.dGridRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridRelations.Size = New System.Drawing.Size(699, 223)
        Me.dGridRelations.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridRelations.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridRelations.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridRelations.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridRelations.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridRelations.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridRelations.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridRelations.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridRelations.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridRelations.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridRelations.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridRelations.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridRelations.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridRelations.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridRelations.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridRelations.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridRelations.TabIndex = 2
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.HeaderText = "Left Table"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 91
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Left Field"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 87
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column10.HeaderText = "Right Table"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 99
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column11.HeaderText = "Right Field"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 95
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column12.HeaderText = "Join Type"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 89
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 85)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(699, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.Controls.Add(Me.Label14)
        Me.KryptonPanel8.Controls.Add(Me.cboJoinType)
        Me.KryptonPanel8.Controls.Add(Me.Label13)
        Me.KryptonPanel8.Controls.Add(Me.Label12)
        Me.KryptonPanel8.Controls.Add(Me.Label11)
        Me.KryptonPanel8.Controls.Add(Me.Label10)
        Me.KryptonPanel8.Controls.Add(Me.cboRightField)
        Me.KryptonPanel8.Controls.Add(Me.cboRightTable)
        Me.KryptonPanel8.Controls.Add(Me.cboLeftField)
        Me.KryptonPanel8.Controls.Add(Me.cboLeftTable)
        Me.KryptonPanel8.Controls.Add(Me.btnAddJoin)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.KryptonPanel8.Size = New System.Drawing.Size(699, 85)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel8.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel8.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DimGray
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(13, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 21)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Join Type"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboJoinType
        '
        Me.cboJoinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoinType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJoinType.FormattingEnabled = True
        Me.cboJoinType.Items.AddRange(New Object() {"Left Outer Join", "Left Inner Join"})
        Me.cboJoinType.Location = New System.Drawing.Point(121, 9)
        Me.cboJoinType.Name = "cboJoinType"
        Me.cboJoinType.Size = New System.Drawing.Size(168, 21)
        Me.cboJoinType.TabIndex = 37
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(360, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 21)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Field"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DimGray
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(360, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 21)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Field"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(13, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 21)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Right Table"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(13, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 21)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Left Table"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRightField
        '
        Me.cboRightField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRightField.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRightField.FormattingEnabled = True
        Me.cboRightField.Location = New System.Drawing.Point(410, 53)
        Me.cboRightField.Name = "cboRightField"
        Me.cboRightField.Size = New System.Drawing.Size(222, 21)
        Me.cboRightField.TabIndex = 30
        '
        'cboRightTable
        '
        Me.cboRightTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRightTable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRightTable.FormattingEnabled = True
        Me.cboRightTable.Location = New System.Drawing.Point(121, 53)
        Me.cboRightTable.Name = "cboRightTable"
        Me.cboRightTable.Size = New System.Drawing.Size(222, 21)
        Me.cboRightTable.TabIndex = 29
        '
        'cboLeftField
        '
        Me.cboLeftField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeftField.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLeftField.FormattingEnabled = True
        Me.cboLeftField.Location = New System.Drawing.Point(410, 31)
        Me.cboLeftField.Name = "cboLeftField"
        Me.cboLeftField.Size = New System.Drawing.Size(222, 21)
        Me.cboLeftField.TabIndex = 28
        '
        'cboLeftTable
        '
        Me.cboLeftTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeftTable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLeftTable.FormattingEnabled = True
        Me.cboLeftTable.Location = New System.Drawing.Point(121, 31)
        Me.cboLeftTable.Name = "cboLeftTable"
        Me.cboLeftTable.Size = New System.Drawing.Size(222, 21)
        Me.cboLeftTable.TabIndex = 27
        '
        'btnAddJoin
        '
        Me.btnAddJoin.AutoSize = True
        Me.btnAddJoin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddJoin.Location = New System.Drawing.Point(636, 52)
        Me.btnAddJoin.Name = "btnAddJoin"
        Me.btnAddJoin.Size = New System.Drawing.Size(48, 22)
        Me.btnAddJoin.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnAddJoin.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAddJoin.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAddJoin.StateCommon.Border.Rounding = 0
        Me.btnAddJoin.StateCommon.Border.Width = 1
        Me.btnAddJoin.TabIndex = 26
        Me.btnAddJoin.Values.Image = CType(resources.GetObject("btnAddJoin.Values.Image"), System.Drawing.Image)
        Me.btnAddJoin.Values.Text = "Add"
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "Relate (Join)"
        '
        'TabControlPanel10
        '
        Me.TabControlPanel10.Controls.Add(Me.txtResults)
        Me.TabControlPanel10.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel10.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel10.Name = "TabControlPanel10"
        Me.TabControlPanel10.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel10.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel10.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel10.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel10.Style.GradientAngle = -90
        Me.TabControlPanel10.TabIndex = 7
        Me.TabControlPanel10.TabItem = Me.TabItem10
        '
        'txtResults
        '
        Me.txtResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResults.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResults.Location = New System.Drawing.Point(1, 1)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(699, 309)
        Me.txtResults.TabIndex = 1
        '
        'TabItem10
        '
        Me.TabItem10.AttachedControl = Me.TabControlPanel10
        Me.TabItem10.Name = "TabItem10"
        Me.TabItem10.Text = "Messages"
        '
        'TabControlPanel8
        '
        Me.TabControlPanel8.Controls.Add(Me.txtSql)
        Me.TabControlPanel8.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel8.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel8.Name = "TabControlPanel8"
        Me.TabControlPanel8.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel8.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel8.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel8.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel8.Style.GradientAngle = -90
        Me.TabControlPanel8.TabIndex = 5
        Me.TabControlPanel8.TabItem = Me.TabItem8
        '
        'txtSql
        '
        Me.txtSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSql.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(1, 1)
        Me.txtSql.Multiline = True
        Me.txtSql.Name = "txtSql"
        Me.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSql.Size = New System.Drawing.Size(699, 309)
        Me.txtSql.TabIndex = 1
        '
        'TabItem8
        '
        Me.TabItem8.AttachedControl = Me.TabControlPanel8
        Me.TabItem8.Name = "TabItem8"
        Me.TabItem8.Text = "Query"
        '
        'TabControlPanel7
        '
        Me.TabControlPanel7.Controls.Add(Me.dGridSorts)
        Me.TabControlPanel7.Controls.Add(Me.KryptonPanel12)
        Me.TabControlPanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel7.Name = "TabControlPanel7"
        Me.TabControlPanel7.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel7.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel7.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel7.Style.GradientAngle = -90
        Me.TabControlPanel7.TabIndex = 4
        Me.TabControlPanel7.TabItem = Me.TabItem7
        '
        'dGridSorts
        '
        Me.dGridSorts.AllowUserToAddRows = False
        Me.dGridSorts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column5})
        Me.dGridSorts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSorts.Location = New System.Drawing.Point(1, 43)
        Me.dGridSorts.Name = "dGridSorts"
        Me.dGridSorts.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGridSorts.ReadOnly = True
        Me.dGridSorts.RowHeadersWidth = 25
        Me.dGridSorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridSorts.Size = New System.Drawing.Size(699, 267)
        Me.dGridSorts.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridSorts.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridSorts.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridSorts.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSorts.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSorts.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSorts.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridSorts.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSorts.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSorts.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSorts.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSorts.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridSorts.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridSorts.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSorts.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSorts.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSorts.TabIndex = 9
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Field Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 99
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Direction"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 87
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel12.Controls.Add(Me.Label1)
        Me.KryptonPanel12.Controls.Add(Me.Label2)
        Me.KryptonPanel12.Controls.Add(Me.cboSortFields)
        Me.KryptonPanel12.Controls.Add(Me.cboDirection)
        Me.KryptonPanel12.Controls.Add(Me.btnAdd)
        Me.KryptonPanel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel12.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(699, 42)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel12.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel12.TabIndex = 8
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 41)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(698, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(698, 0)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 42)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 21)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Data Field"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(300, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Direction"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSortFields
        '
        Me.cboSortFields.FormattingEnabled = True
        Me.cboSortFields.Location = New System.Drawing.Point(85, 10)
        Me.cboSortFields.Name = "cboSortFields"
        Me.cboSortFields.Size = New System.Drawing.Size(210, 21)
        Me.cboSortFields.TabIndex = 2
        '
        'cboDirection
        '
        Me.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDirection.FormattingEnabled = True
        Me.cboDirection.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cboDirection.Location = New System.Drawing.Point(371, 10)
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.Size = New System.Drawing.Size(210, 21)
        Me.cboDirection.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.Location = New System.Drawing.Point(585, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAdd.StateCommon.Border.Rounding = 0
        Me.btnAdd.StateCommon.Border.Width = 1
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Values.Image = CType(resources.GetObject("btnAdd.Values.Image"), System.Drawing.Image)
        Me.btnAdd.Values.Text = "Add"
        '
        'TabItem7
        '
        Me.TabItem7.AttachedControl = Me.TabControlPanel7
        Me.TabItem7.Name = "TabItem7"
        Me.TabItem7.Text = "Sort"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.dGridGroups)
        Me.TabControlPanel6.Controls.Add(Me.KryptonPanel13)
        Me.TabControlPanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = -90
        Me.TabControlPanel6.TabIndex = 3
        Me.TabControlPanel6.TabItem = Me.TabItem6
        '
        'dGridGroups
        '
        Me.dGridGroups.AllowUserToAddRows = False
        Me.dGridGroups.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7})
        Me.dGridGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridGroups.Location = New System.Drawing.Point(1, 43)
        Me.dGridGroups.Name = "dGridGroups"
        Me.dGridGroups.ReadOnly = True
        Me.dGridGroups.RowHeadersWidth = 25
        Me.dGridGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridGroups.Size = New System.Drawing.Size(699, 267)
        Me.dGridGroups.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridGroups.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridGroups.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridGroups.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridGroups.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridGroups.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridGroups.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridGroups.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridGroups.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridGroups.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridGroups.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridGroups.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridGroups.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridGroups.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridGroups.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridGroups.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridGroups.TabIndex = 10
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Field Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 99
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel13.Controls.Add(Me.cboGroupField)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel13.Controls.Add(Me.Label3)
        Me.KryptonPanel13.Controls.Add(Me.btnAddGroup)
        Me.KryptonPanel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel13.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(699, 42)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel13.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel13.TabIndex = 9
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 41)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(698, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'cboGroupField
        '
        Me.cboGroupField.FormattingEnabled = True
        Me.cboGroupField.Location = New System.Drawing.Point(85, 10)
        Me.cboGroupField.Name = "cboGroupField"
        Me.cboGroupField.Size = New System.Drawing.Size(493, 21)
        Me.cboGroupField.TabIndex = 7
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(698, 0)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(1, 42)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data Field"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAddGroup
        '
        Me.btnAddGroup.AutoSize = True
        Me.btnAddGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddGroup.Location = New System.Drawing.Point(579, 10)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Size = New System.Drawing.Size(48, 22)
        Me.btnAddGroup.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAddGroup.StateCommon.Border.Rounding = 0
        Me.btnAddGroup.StateCommon.Border.Width = 1
        Me.btnAddGroup.TabIndex = 5
        Me.btnAddGroup.Values.Image = CType(resources.GetObject("btnAddGroup.Values.Image"), System.Drawing.Image)
        Me.btnAddGroup.Values.Text = "Add"
        '
        'TabItem6
        '
        Me.TabItem6.AttachedControl = Me.TabControlPanel6
        Me.TabItem6.Name = "TabItem6"
        Me.TabItem6.Text = "Group"
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.dGridFilter)
        Me.TabControlPanel5.Controls.Add(Me.KryptonPanel14)
        Me.TabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(701, 311)
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.Silver
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Top), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = -90
        Me.TabControlPanel5.TabIndex = 2
        Me.TabControlPanel5.TabItem = Me.TabItem5
        '
        'dGridFilter
        '
        Me.dGridFilter.AllowUserToAddRows = False
        Me.dGridFilter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.Column6, Me.Column8, Me.Column7})
        Me.dGridFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridFilter.Location = New System.Drawing.Point(1, 85)
        Me.dGridFilter.Name = "dGridFilter"
        Me.dGridFilter.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGridFilter.ReadOnly = True
        Me.dGridFilter.RowHeadersWidth = 25
        Me.dGridFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridFilter.Size = New System.Drawing.Size(699, 225)
        Me.dGridFilter.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridFilter.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridFilter.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridFilter.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridFilter.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFilter.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFilter.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridFilter.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridFilter.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridFilter.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridFilter.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFilter.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFilter.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridFilter.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridFilter.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridFilter.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridFilter.TabIndex = 11
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.HeaderText = "Field Name"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 99
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Comparison"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 105
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Value"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 67
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Combination"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 108
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.Controls.Add(Me.btnAddFilter)
        Me.KryptonPanel14.Controls.Add(Me.Label9)
        Me.KryptonPanel14.Controls.Add(Me.Label8)
        Me.KryptonPanel14.Controls.Add(Me.Label7)
        Me.KryptonPanel14.Controls.Add(Me.Label6)
        Me.KryptonPanel14.Controls.Add(Me.Label5)
        Me.KryptonPanel14.Controls.Add(Me.cboCombination)
        Me.KryptonPanel14.Controls.Add(Me.txtValue)
        Me.KryptonPanel14.Controls.Add(Me.cboComparison)
        Me.KryptonPanel14.Controls.Add(Me.cboDataType)
        Me.KryptonPanel14.Controls.Add(Me.cboTableField)
        Me.KryptonPanel14.Controls.Add(Me.cboFilterTableName)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel14.Controls.Add(Me.Label4)
        Me.KryptonPanel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel14.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(699, 84)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel14.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel14.TabIndex = 10
        '
        'btnAddFilter
        '
        Me.btnAddFilter.AutoSize = True
        Me.btnAddFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddFilter.Location = New System.Drawing.Point(11, 54)
        Me.btnAddFilter.Name = "btnAddFilter"
        Me.btnAddFilter.Size = New System.Drawing.Size(48, 22)
        Me.btnAddFilter.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnAddFilter.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAddFilter.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAddFilter.StateCommon.Border.Rounding = 0
        Me.btnAddFilter.StateCommon.Border.Width = 1
        Me.btnAddFilter.TabIndex = 23
        Me.btnAddFilter.Values.Image = CType(resources.GetObject("btnAddFilter.Values.Image"), System.Drawing.Image)
        Me.btnAddFilter.Values.Text = "Add"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(625, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 21)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Combine"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DimGray
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(494, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 21)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Value"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(385, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 21)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Comparison"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(335, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 21)
        Me.Label6.TabIndex = 19
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(173, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 21)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Data Field"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCombination
        '
        Me.cboCombination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCombination.FormattingEnabled = True
        Me.cboCombination.Items.AddRange(New Object() {"AND", "OR"})
        Me.cboCombination.Location = New System.Drawing.Point(624, 31)
        Me.cboCombination.Name = "cboCombination"
        Me.cboCombination.Size = New System.Drawing.Size(61, 21)
        Me.cboCombination.TabIndex = 17
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(493, 31)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(130, 20)
        Me.txtValue.TabIndex = 16
        '
        'cboComparison
        '
        Me.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComparison.FormattingEnabled = True
        Me.cboComparison.Items.AddRange(New Object() {"Equals", "GreaterOrEquals", "GreaterThan", "In", "LessOrEquals", "LessThan", "Like", "NotEquals", "NotLike"})
        Me.cboComparison.Location = New System.Drawing.Point(385, 31)
        Me.cboComparison.Name = "cboComparison"
        Me.cboComparison.Size = New System.Drawing.Size(107, 21)
        Me.cboComparison.TabIndex = 15
        '
        'cboDataType
        '
        Me.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataType.FormattingEnabled = True
        Me.cboDataType.Location = New System.Drawing.Point(334, 31)
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.Size = New System.Drawing.Size(50, 21)
        Me.cboDataType.TabIndex = 14
        Me.cboDataType.Visible = False
        '
        'cboTableField
        '
        Me.cboTableField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableField.FormattingEnabled = True
        Me.cboTableField.Location = New System.Drawing.Point(173, 31)
        Me.cboTableField.Name = "cboTableField"
        Me.cboTableField.Size = New System.Drawing.Size(160, 21)
        Me.cboTableField.TabIndex = 10
        '
        'cboFilterTableName
        '
        Me.cboFilterTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterTableName.FormattingEnabled = True
        Me.cboFilterTableName.Location = New System.Drawing.Point(11, 31)
        Me.cboFilterTableName.Name = "cboFilterTableName"
        Me.cboFilterTableName.Size = New System.Drawing.Size(161, 21)
        Me.cboFilterTableName.TabIndex = 9
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(0, 83)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(698, 1)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(698, 0)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(1, 84)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(11, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Table name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel5
        Me.TabItem5.Name = "TabItem5"
        Me.TabItem5.Text = "Filter"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(712, 31)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(1, 348)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 31)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(1, 348)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 379)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(713, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge3"
        '
        'KryptonHeader2
        '
        Me.KryptonHeader2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonHeader2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonHeader2.Name = "KryptonHeader2"
        Me.KryptonHeader2.Size = New System.Drawing.Size(713, 31)
        Me.KryptonHeader2.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader2.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader2.StateCommon.Back.ColorAngle = 100.0!
        Me.KryptonHeader2.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonHeader2.StateCommon.Content.LongText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonHeader2.TabIndex = 1
        Me.KryptonHeader2.Values.Description = ""
        Me.KryptonHeader2.Values.Heading = "Conditions and Results"
        Me.KryptonHeader2.Values.Image = Nothing
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge19)
        Me.KryptonPanel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel9.Location = New System.Drawing.Point(0, 31)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(713, 154)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 1
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.Controls.Add(Me.dGridFields)
        Me.KryptonPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel10.Location = New System.Drawing.Point(1, 0)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Padding = New System.Windows.Forms.Padding(5)
        Me.KryptonPanel10.Size = New System.Drawing.Size(711, 154)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 2
        '
        'dGridFields
        '
        Me.dGridFields.AllowUserToAddRows = False
        Me.dGridFields.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column3, Me.Column1})
        Me.dGridFields.DataMember = "TestData"
        Me.dGridFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridFields.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed
        Me.dGridFields.Location = New System.Drawing.Point(5, 5)
        Me.dGridFields.Name = "dGridFields"
        Me.dGridFields.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGridFields.RowHeadersWidth = 25
        Me.dGridFields.RowTemplate.Height = 27
        Me.dGridFields.Size = New System.Drawing.Size(701, 144)
        Me.dGridFields.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridFields.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridFields.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridFields.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridFields.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFields.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFields.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridFields.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridFields.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridFields.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFields.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridFields.TabIndex = 18
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Source Table"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 98
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Field Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 88
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Friendly Name"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 104
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(712, 0)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(1, 154)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(1, 154)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge1"
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonHeader1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(713, 31)
        Me.KryptonHeader1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader1.StateCommon.Back.ColorAngle = 100.0!
        Me.KryptonHeader1.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonHeader1.StateCommon.Content.LongText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonHeader1.TabIndex = 0
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = "Selected Fields"
        Me.KryptonHeader1.Values.Image = Nothing
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Query Designer"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(749, 0)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.expandablePanel1)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(1, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(194, 628)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 1
        '
        'expandablePanel1
        '
        Me.expandablePanel1.AutoScroll = True
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.treeView1)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(194, 628)
        Me.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.expandablePanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile
        Me.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.expandablePanel1.Style.GradientAngle = 90
        Me.expandablePanel1.Style.WordWrap = True
        Me.expandablePanel1.TabIndex = 4
        Me.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.TitleStyle.GradientAngle = 90
        Me.expandablePanel1.TitleStyle.MarginLeft = 6
        Me.expandablePanel1.TitleText = "Tables"
        '
        'treeView1
        '
        Me.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeView1.HideSelection = False
        Me.treeView1.Location = New System.Drawing.Point(0, 26)
        Me.treeView1.Name = "treeView1"
        TreeNode1.ImageIndex = 1
        TreeNode1.Name = "NodeYearlyReview"
        TreeNode1.SelectedImageIndex = 1
        TreeNode1.Text = "Staff reviews"
        TreeNode2.ImageIndex = 1
        TreeNode2.Name = "NodeProjectMilestone"
        TreeNode2.SelectedImageIndex = 1
        TreeNode2.Text = "Project meetings"
        TreeNode3.ImageIndex = 0
        TreeNode3.Name = "NodeAppointments"
        TreeNode3.SelectedImageIndex = 0
        TreeNode3.Text = "Appointments"
        TreeNode4.ImageIndex = 2
        TreeNode4.Name = "PHC"
        TreeNode4.SelectedImageIndex = 2
        TreeNode4.Text = "Primary Health Care"
        TreeNode5.ImageIndex = 3
        TreeNode5.Name = "EAP"
        TreeNode5.SelectedImageIndex = 3
        TreeNode5.Text = "Employee Assistance"
        TreeNode6.ImageIndex = 4
        TreeNode6.Name = "OHS"
        TreeNode6.SelectedImageIndex = 4
        TreeNode6.Text = "Occupational Health Services"
        TreeNode7.ImageIndex = 4
        TreeNode7.Name = "IOD"
        TreeNode7.SelectedImageIndex = 4
        TreeNode7.Text = "Injury On Duty"
        TreeNode8.ImageIndex = 4
        TreeNode8.Name = "CDM"
        TreeNode8.SelectedImageIndex = 4
        TreeNode8.Text = "Chronic Disease Management"
        TreeNode9.ImageIndex = 2
        TreeNode9.Name = "TBM"
        TreeNode9.SelectedImageIndex = 2
        TreeNode9.Text = "TB Management"
        TreeNode10.ImageIndex = 3
        TreeNode10.Name = "HIVM"
        TreeNode10.SelectedImageIndex = 3
        TreeNode10.Text = "HIV Management"
        TreeNode11.ImageIndex = 4
        TreeNode11.Name = "MS"
        TreeNode11.SelectedImageIndex = 4
        TreeNode11.Text = "Medical Screening"
        TreeNode12.ImageIndex = 2
        TreeNode12.Name = "DSM"
        TreeNode12.SelectedImageIndex = 2
        TreeNode12.Text = "Disability Management"
        TreeNode13.ImageIndex = 3
        TreeNode13.Name = "ABSM"
        TreeNode13.SelectedImageIndex = 3
        TreeNode13.Text = "Absence Management"
        TreeNode14.ImageIndex = 1
        TreeNode14.Name = "SUM"
        TreeNode14.SelectedImageIndex = 1
        TreeNode14.Text = "Summary Report"
        TreeNode15.ImageIndex = 0
        TreeNode15.Name = "NodeEmployees"
        TreeNode15.SelectedImageIndex = 0
        TreeNode15.Text = "Management Reports"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode15})
        Me.treeView1.Size = New System.Drawing.Size(194, 602)
        Me.treeView1.TabIndex = 26
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 628)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(950, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewConnection, Me.tsGenerate, Me.tsRun, Me.btnUnselect, Me.btnSingleSend, Me.btnRefresh, Me.lblRowCount})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(950, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 5
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNewConnection
        '
        Me.btnNewConnection.BeginGroup = True
        Me.btnNewConnection.Image = CType(resources.GetObject("btnNewConnection.Image"), System.Drawing.Image)
        Me.btnNewConnection.Name = "btnNewConnection"
        Me.btnNewConnection.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewConnection.Text = "Connect"
        Me.btnNewConnection.Visible = False
        '
        'tsGenerate
        '
        Me.tsGenerate.BeginGroup = True
        Me.tsGenerate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.tsGenerate.Image = CType(resources.GetObject("tsGenerate.Image"), System.Drawing.Image)
        Me.tsGenerate.Name = "tsGenerate"
        Me.tsGenerate.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.tsGenerate.Text = "Script"
        '
        'tsRun
        '
        Me.tsRun.BeginGroup = True
        Me.tsRun.Image = CType(resources.GetObject("tsRun.Image"), System.Drawing.Image)
        Me.tsRun.Name = "tsRun"
        Me.tsRun.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.tsRun.Text = "Run Query"
        '
        'btnUnselect
        '
        Me.btnUnselect.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUnselect.Image = CType(resources.GetObject("btnUnselect.Image"), System.Drawing.Image)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnUnselect.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.mnuSaveReportOnly, Me.mnuSaveStructureOnly, Me.mnuSaveBoth})
        Me.btnUnselect.Text = "Save"
        '
        'mnuSaveReportOnly
        '
        Me.mnuSaveReportOnly.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuSaveReportOnly.Name = "mnuSaveReportOnly"
        Me.mnuSaveReportOnly.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.mnuSaveReportOnly.SymbolSize = 16.0!
        Me.mnuSaveReportOnly.Text = "Report Only"
        '
        'mnuSaveStructureOnly
        '
        Me.mnuSaveStructureOnly.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuSaveStructureOnly.Name = "mnuSaveStructureOnly"
        Me.mnuSaveStructureOnly.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.mnuSaveStructureOnly.SymbolSize = 16.0!
        Me.mnuSaveStructureOnly.Text = "Structure Only"
        '
        'mnuSaveBoth
        '
        Me.mnuSaveBoth.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuSaveBoth.Name = "mnuSaveBoth"
        Me.mnuSaveBoth.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.mnuSaveBoth.SymbolSize = 16.0!
        Me.mnuSaveBoth.Text = "Both Structure and Report"
        '
        'btnSingleSend
        '
        Me.btnSingleSend.BeginGroup = True
        Me.btnSingleSend.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSingleSend.Image = CType(resources.GetObject("btnSingleSend.Image"), System.Drawing.Image)
        Me.btnSingleSend.Name = "btnSingleSend"
        Me.btnSingleSend.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSingleSend.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.mnuPreviewReport, Me.mnuPrintReport, Me.mnuPublish, Me.btnPrintWysiwhyg})
        Me.btnSingleSend.Text = "Report"
        '
        'mnuPreviewReport
        '
        Me.mnuPreviewReport.BeginGroup = True
        Me.mnuPreviewReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuPreviewReport.Name = "mnuPreviewReport"
        Me.mnuPreviewReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.mnuPreviewReport.SymbolSize = 16.0!
        Me.mnuPreviewReport.Text = "Preview Report"
        '
        'mnuPrintReport
        '
        Me.mnuPrintReport.BeginGroup = True
        Me.mnuPrintReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuPrintReport.Name = "mnuPrintReport"
        Me.mnuPrintReport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.mnuPrintReport.SymbolSize = 16.0!
        Me.mnuPrintReport.Text = "Print Report"
        '
        'mnuPublish
        '
        Me.mnuPublish.BeginGroup = True
        Me.mnuPublish.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuPublish.Name = "mnuPublish"
        Me.mnuPublish.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.mnuPublish.SymbolSize = 16.0!
        Me.mnuPublish.Text = "Publish"
        '
        'btnPrintWysiwhyg
        '
        Me.btnPrintWysiwhyg.BeginGroup = True
        Me.btnPrintWysiwhyg.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintWysiwhyg.Name = "btnPrintWysiwhyg"
        Me.btnPrintWysiwhyg.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintWysiwhyg.SymbolSize = 16.0!
        Me.btnPrintWysiwhyg.Text = "Print WYSIWYG"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.SymbolColor = System.Drawing.Color.Navy
        Me.btnRefresh.Text = "Refresh"
        '
        'lblRowCount
        '
        Me.lblRowCount.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblRowCount.BeginGroup = True
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Text = "Number of rows retrieved = 0"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(951, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 654)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 654)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 655)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(952, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(952, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'imageList
        '
        Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList.Images.SetKeyName(0, "Folder.ico")
        Me.imageList.Images.SetKeyName(1, "calendar.png")
        Me.imageList.Images.SetKeyName(2, "user2.png")
        Me.imageList.Images.SetKeyName(3, "dude1.png")
        Me.imageList.Images.SetKeyName(4, "businessman2.png")
        Me.imageList.Images.SetKeyName(5, "05.png")
        Me.imageList.Images.SetKeyName(6, "06.png")
        Me.imageList.Images.SetKeyName(7, "07.png")
        Me.imageList.Images.SetKeyName(8, "08.png")
        Me.imageList.Images.SetKeyName(9, "09.png")
        Me.imageList.Images.SetKeyName(10, "10.png")
        Me.imageList.Images.SetKeyName(11, "35.png")
        Me.imageList.Images.SetKeyName(12, "36.png")
        Me.imageList.Images.SetKeyName(13, "37.png")
        Me.imageList.Images.SetKeyName(14, "38.png")
        Me.imageList.Images.SetKeyName(15, "39.png")
        Me.imageList.Images.SetKeyName(16, "40.png")
        Me.imageList.Images.SetKeyName(17, "46.png")
        Me.imageList.Images.SetKeyName(18, "47.png")
        Me.imageList.Images.SetKeyName(19, "115.png")
        '
        'frmSqlQueries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 656)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Name = "frmSqlQueries"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Report Builder"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel1.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.PerformLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.tabReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabReport.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel15.ResumeLayout(False)
        CType(Me.KryptonPanel31, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel31.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TabControlPanel14.ResumeLayout(False)
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel15.ResumeLayout(False)
        CType(Me.dgridCharting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel34, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel34.ResumeLayout(False)
        Me.KryptonPanel34.PerformLayout()
        CType(Me.KryptonPanel35, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel35.ResumeLayout(False)
        Me.KryptonPanel35.PerformLayout()
        CType(Me.cboSourceData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel32, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel32.ResumeLayout(False)
        Me.KryptonPanel32.PerformLayout()
        CType(Me.KryptonPanel33, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel33.ResumeLayout(False)
        Me.KryptonPanel33.PerformLayout()
        CType(Me.cboChartType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel13.ResumeLayout(False)
        CType(Me.KryptonPanel37, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel37.ResumeLayout(False)
        CType(Me.dGridHighLights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel38, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel38.ResumeLayout(False)
        Me.KryptonPanel38.PerformLayout()
        Me.TabControlPanel12.ResumeLayout(False)
        CType(Me.KryptonPanel39, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel39.ResumeLayout(False)
        CType(Me.dgridReportFieldProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel11.ResumeLayout(False)
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel29, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel29.ResumeLayout(False)
        Me.KryptonPanel29.PerformLayout()
        CType(Me.KryptonPanel28, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel28.ResumeLayout(False)
        Me.KryptonPanel28.PerformLayout()
        CType(Me.KryptonPanel27, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel27.ResumeLayout(False)
        Me.KryptonPanel27.PerformLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel26.ResumeLayout(False)
        Me.KryptonPanel26.PerformLayout()
        CType(Me.KryptonPanel25, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel25.ResumeLayout(False)
        Me.KryptonPanel25.PerformLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel24.ResumeLayout(False)
        Me.KryptonPanel24.PerformLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel23.ResumeLayout(False)
        Me.KryptonPanel23.PerformLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel22.ResumeLayout(False)
        Me.KryptonPanel22.PerformLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel21.ResumeLayout(False)
        Me.KryptonPanel21.PerformLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel20.ResumeLayout(False)
        Me.KryptonPanel20.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        Me.KryptonPanel19.PerformLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel17.ResumeLayout(False)
        Me.KryptonPanel17.PerformLayout()
        CType(Me.KryptonPanel30, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel30.ResumeLayout(False)
        Me.KryptonPanel30.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        CType(Me.KryptonPanel36, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        CType(Me.TabFunctions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFunctions.ResumeLayout(False)
        Me.TabControlPanel9.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel4.ResumeLayout(False)
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.dGridRelations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        Me.TabControlPanel10.ResumeLayout(False)
        Me.TabControlPanel10.PerformLayout()
        Me.TabControlPanel8.ResumeLayout(False)
        Me.TabControlPanel8.PerformLayout()
        Me.TabControlPanel7.ResumeLayout(False)
        CType(Me.dGridSorts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        Me.TabControlPanel6.ResumeLayout(False)
        CType(Me.dGridGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        Me.TabControlPanel5.ResumeLayout(False)
        CType(Me.dGridFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        CType(Me.dGridFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.expandablePanel1.ResumeLayout(False)
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
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ColorPalette As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents myDocument As System.Drawing.Printing.PrintDocument
    ' '' ''Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewConnection As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tsGenerate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tsRun As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUnselect As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSingleSend As DevComponents.DotNetBar.ButtonItem
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Private WithEvents treeView1 As System.Windows.Forms.TreeView
    Friend WithEvents mnuPreviewReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnuPrintReport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnuPublish As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnuSaveReportOnly As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnuSaveStructureOnly As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnuSaveBoth As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tabReport As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TabFunctions As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridRelations As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboJoinType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboRightField As System.Windows.Forms.ComboBox
    Friend WithEvents cboRightTable As System.Windows.Forms.ComboBox
    Friend WithEvents cboLeftField As System.Windows.Forms.ComboBox
    Friend WithEvents cboLeftTable As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddJoin As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents dGridFilter As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnAddFilter As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCombination As System.Windows.Forms.ComboBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cboComparison As System.Windows.Forms.ComboBox
    Friend WithEvents cboDataType As System.Windows.Forms.ComboBox
    Friend WithEvents cboTableField As System.Windows.Forms.ComboBox
    Friend WithEvents cboFilterTableName As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel10 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents TabItem10 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel9 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents TabItem9 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel8 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents TabItem8 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel7 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents dGridSorts As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSortFields As System.Windows.Forms.ComboBox
    Friend WithEvents cboDirection As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents TabItem7 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents dGridGroups As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboGroupField As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAddGroup As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents TabItem6 As DevComponents.DotNetBar.TabItem
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonHeader2 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents dGridFields As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel36 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel11 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel29 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel28 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboGroupIndex As System.Windows.Forms.ComboBox
    Friend WithEvents cboAlternateBackColor As System.Windows.Forms.ComboBox
    Friend WithEvents cboBorderColor As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonPanel27 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel26 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel25 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel24 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboGridColor As System.Windows.Forms.ComboBox
    Friend WithEvents cboGridLines As System.Windows.Forms.ComboBox
    Friend WithEvents cboPrintBorder As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonPanel23 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel22 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge31 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboDetailsFontColor As System.Windows.Forms.ComboBox
    Friend WithEvents cboDetailsFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboDetailsFont As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonPanel21 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge32 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel20 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge33 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge34 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboFooterColor As System.Windows.Forms.ComboBox
    Friend WithEvents cboFooterSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboFooterFont As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFooterTitle As System.Windows.Forms.TextBox
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge35 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel17 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge36 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboHeaderFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeaderFont As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeaderColor As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonPanel30 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge37 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtPageHeader As System.Windows.Forms.TextBox
    Friend WithEvents TabItem11 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel14 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel15 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgridCharting As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents KryptonPanel34 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel35 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge30 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnPreviewChart As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cboSourceData As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtChartColumnIndex As System.Windows.Forms.TextBox
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel32 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel33 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel15 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboChartType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents chkPrintSummary As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkPrintFinalTotals As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkDrawChart As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents TabItem14 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel15 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel31 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TabItem15 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel13 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel37 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridHighLights As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel38 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboHighlightColor As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddHighLight As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtColumnValue As System.Windows.Forms.TextBox
    Friend WithEvents txtColumnNumber As System.Windows.Forms.TextBox
    Friend WithEvents TabItem13 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel12 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents KryptonPanel39 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents dgridReportFieldProperty As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TabItem12 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents lblRowCount As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnPrintWysiwhyg As DevComponents.DotNetBar.ButtonItem

End Class
