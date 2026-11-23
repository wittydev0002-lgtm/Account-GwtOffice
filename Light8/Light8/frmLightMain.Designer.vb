<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLightMain
    Inherits DevComponents.DotNetBar.Metro.MetroForm ' ComponentFactory.Krypton.Toolkit.KryptonForm 

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLightMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trade Debtors", 2, 3)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lay-by Clients", 4, 4)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Farmers Listing")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customers", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cash Sales", 10, 9)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quotations", 10, 9)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Invoices", 10, 9)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proforma Invoices", 10, 9)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Credit Notes", 10, 9)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Payments", 10, 9)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Refunds", 10, 9)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Straight Exchange", 10, 9)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exchange and Top-up", 10, 9)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exchanges", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Specials", 10, 9)
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Loyality Programs", 10, 9)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Settings", New System.Windows.Forms.TreeNode() {TreeNode16, TreeNode17})
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Day/Period Processes", 10, 9)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Cashout", New System.Windows.Forms.TreeNode() {TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Projects", 10, 9)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Claims", 10, 9)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Jobs", 10, 9)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Jobs Service Parameters", 10, 9)
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Projects and Jobs", New System.Windows.Forms.TreeNode() {TreeNode21, TreeNode22, TreeNode23, TreeNode24})
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loan Types", 10, 9)
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loan Customers", 10, 9)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Advance Loan", 10, 9)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Repay Loan", 10, 9)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loans", New System.Windows.Forms.TreeNode() {TreeNode26, TreeNode27, TreeNode28, TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cashbook", 10, 9)
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ledgers", 10, 9)
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Journals", 10, 9)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Accounting Entries", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode31, TreeNode32, TreeNode33})
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Chart Of Accounts", 10, 9)
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cashbooks Setup", 10, 9)
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Financial Periods", 10, 9)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Special Ledger Accounts", 10, 9)
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Settings", New System.Windows.Forms.TreeNode() {TreeNode35, TreeNode36, TreeNode37, TreeNode38})
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Assets", 10, 9)
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Classifications", 10, 9)
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Asset Management", New System.Windows.Forms.TreeNode() {TreeNode40, TreeNode41})
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Suppliers", 10, 9)
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Creditors Grouping", 10, 9)
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Suppliers", New System.Windows.Forms.TreeNode() {TreeNode43, TreeNode44})
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Supplier Invoices", 10, 9)
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Debit Notes", 10, 9)
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders", 10, 9)
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Supplier Payments", 10, 9)
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Actvities", New System.Windows.Forms.TreeNode() {TreeNode46, TreeNode47, TreeNode48, TreeNode49})
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Enter Bills", 10, 9)
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pay Bills and Orders", 10, 9)
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Supplier Refunds", 10, 9)
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bills", New System.Windows.Forms.TreeNode() {TreeNode51, TreeNode52, TreeNode53})
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employees", 4, 2)
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Work Structures", 10, 9)
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Human Resources", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode55, TreeNode56})
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Batch Transaction Entries", 10, 9)
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Run", 10, 9)
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bank Extracts", 10, 9)
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reset Employee YTDs", 10, 9)
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode58, TreeNode59, TreeNode60, TreeNode61})
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Calculations", 10, 9)
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Codes", 10, 9)
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Constants", 10, 9)
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Dates", 10, 9)
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reference Numbers", 10, 9)
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Flags", 10, 9)
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("6 Column Report Writer", 10, 9)
        Dim TreeNode70 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Special Codes", 10, 9)
        Dim TreeNode71 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tax Tables", 10, 9)
        Dim TreeNode72 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trekked Codes", 10, 9)
        Dim TreeNode73 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ITF16 Calculations", 10, 9)
        Dim TreeNode74 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Summary Reports", 10, 9)
        Dim TreeNode75 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Calendar", 10, 9)
        Dim TreeNode76 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exception Messages", 10, 9)
        Dim TreeNode77 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tables", 10, 9)
        Dim TreeNode78 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tax Rebates", 10, 9)
        Dim TreeNode79 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Settings", New System.Windows.Forms.TreeNode() {TreeNode63, TreeNode64, TreeNode65, TreeNode66, TreeNode67, TreeNode68, TreeNode69, TreeNode70, TreeNode71, TreeNode72, TreeNode73, TreeNode74, TreeNode75, TreeNode76, TreeNode77, TreeNode78})
        Dim TreeNode80 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory List", 5, 5)
        Dim TreeNode81 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Received Inventory", 5, 5)
        Dim TreeNode82 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Non Moving Stock", 5, 5)
        Dim TreeNode83 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock Take Sheets", 5, 5)
        Dim TreeNode84 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Critically Low Inventory", 5, 5)
        Dim TreeNode85 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Individual Stock Movement", 5, 5)
        Dim TreeNode86 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detailed Stock History", 5, 5)
        Dim TreeNode87 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock Movements Summary", 5, 5)
        Dim TreeNode88 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock Movements Details", 5, 5)
        Dim TreeNode89 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transfers", 5, 5)
        Dim TreeNode90 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock Valuation Summary", 5, 5)
        Dim TreeNode91 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Daily Stores Reconciliation", 5, 5)
        Dim TreeNode92 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory Sales History", 5, 5)
        Dim TreeNode93 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory", 6, 6, New System.Windows.Forms.TreeNode() {TreeNode80, TreeNode81, TreeNode82, TreeNode83, TreeNode84, TreeNode85, TreeNode86, TreeNode87, TreeNode88, TreeNode89, TreeNode90, TreeNode91, TreeNode92})
        Dim TreeNode94 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales By Customer Summary", 5, 5)
        Dim TreeNode95 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales By Customer Detail", 5, 5)
        Dim TreeNode96 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales By Item Summary", 5, 5)
        Dim TreeNode97 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales By Item Detail", 5, 5)
        Dim TreeNode98 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Today's Sales By Item", 5, 5)
        Dim TreeNode99 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Comparison (By week, Month, Year)", 5, 5)
        Dim TreeNode100 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Most Profitable Products/Services", 5, 5)
        Dim TreeNode101 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Sheets", 5, 5)
        Dim TreeNode102 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Z-Report", 5, 5)
        Dim TreeNode103 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales", 7, 7, New System.Windows.Forms.TreeNode() {TreeNode94, TreeNode95, TreeNode96, TreeNode97, TreeNode98, TreeNode99, TreeNode100, TreeNode101, TreeNode102})
        Dim TreeNode104 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Analysis", 5, 5)
        Dim TreeNode105 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchases Analysis", 5, 5)
        Dim TreeNode106 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendor List", 5, 5)
        Dim TreeNode107 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payments List", 5, 5)
        Dim TreeNode108 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Invoice List", 5, 5)
        Dim TreeNode109 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee List", 5, 5)
        Dim TreeNode110 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer List", 5, 5)
        Dim TreeNode111 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Periodic Accounts Analysis")
        Dim TreeNode112 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Expenses", 5, 5)
        Dim TreeNode113 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Analysis Tools", 13, 13, New System.Windows.Forms.TreeNode() {TreeNode104, TreeNode105, TreeNode106, TreeNode107, TreeNode108, TreeNode109, TreeNode110, TreeNode111, TreeNode112})
        Dim TreeNode114 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cashbook Transactions", 5, 5)
        Dim TreeNode115 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bank Reconciliation Statement", 5, 5)
        Dim TreeNode116 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Trial Balance", 5, 5)
        Dim TreeNode117 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ledger Transactions", 5, 5)
        Dim TreeNode118 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Profit and Loss Standard", 5, 5)
        Dim TreeNode119 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Balance Sheet", 5, 5)
        Dim TreeNode120 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cash Flow Statement", 5, 5)
        Dim TreeNode121 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction Detail by Account", 5, 5)
        Dim TreeNode122 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General Ledger Report", 5, 5)
        Dim TreeNode123 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Tax Liability", 5, 5)
        Dim TreeNode124 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction Detail by Tax Code", 5, 5)
        Dim TreeNode125 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("YTD Profit Compared to Last Year", 5, 5)
        Dim TreeNode126 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Tax Collected Per Period", 5, 5)
        Dim TreeNode127 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Assets Depreciation Schedule", 5, 5)
        Dim TreeNode128 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ledger Account Balances", 5, 5)
        Dim TreeNode129 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Financial", 12, 12, New System.Windows.Forms.TreeNode() {TreeNode114, TreeNode115, TreeNode116, TreeNode117, TreeNode118, TreeNode119, TreeNode120, TreeNode121, TreeNode122, TreeNode123, TreeNode124, TreeNode125, TreeNode126, TreeNode127, TreeNode128})
        Dim TreeNode130 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Balances", 5, 5)
        Dim TreeNode131 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A/R Aging Analysis", 5, 5)
        Dim TreeNode132 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Transaction History", 5, 5)
        Dim TreeNode133 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Open Invoiced By Due Date", 5, 5)
        Dim TreeNode134 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Most Profitable Customers", 5, 5)
        Dim TreeNode135 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Statements", 5, 5)
        Dim TreeNode136 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customer Balances At Specified Date", 5, 5)
        Dim TreeNode137 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customers and Receivables", 9, 9, New System.Windows.Forms.TreeNode() {TreeNode130, TreeNode131, TreeNode132, TreeNode133, TreeNode134, TreeNode135, TreeNode136})
        Dim TreeNode138 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Creditors Transaction History", 5, 5)
        Dim TreeNode139 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Today's Creditors Payments", 5, 5)
        Dim TreeNode140 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Amounts Due to Creditors", 5, 5)
        Dim TreeNode141 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders", 5, 5)
        Dim TreeNode142 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendors/Creditors", 10, 10, New System.Windows.Forms.TreeNode() {TreeNode138, TreeNode139, TreeNode140, TreeNode141})
        Dim TreeNode143 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Full Masterfile", 5, 5)
        Dim TreeNode144 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Listing", 5, 5)
        Dim TreeNode145 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salary Increaments", 5, 5)
        Dim TreeNode146 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("New Entrants", 5, 5)
        Dim TreeNode147 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Leavers", 5, 5)
        Dim TreeNode148 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Staff Turnover", 5, 5)
        Dim TreeNode149 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transfers", 5, 5)
        Dim TreeNode150 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personnel", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode143, TreeNode144, TreeNode145, TreeNode146, TreeNode147, TreeNode148, TreeNode149})
        Dim TreeNode151 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A5 Payslips", 5, 5)
        Dim TreeNode152 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A5 Payslips Format 2", 5, 5)
        Dim TreeNode153 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Employee Control", 5, 5)
        Dim TreeNode154 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Control Totals", 5, 5)
        Dim TreeNode155 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bank Transfer Schedule", 5, 5)
        Dim TreeNode156 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll Summary", 5, 5)
        Dim TreeNode157 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Audit Trail", 5, 5)
        Dim TreeNode158 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Coinage Analysis", 5, 5)
        Dim TreeNode159 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tax Certificates", 5, 5)
        Dim TreeNode160 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll", 11, 11, New System.Windows.Forms.TreeNode() {TreeNode151, TreeNode152, TreeNode153, TreeNode154, TreeNode155, TreeNode156, TreeNode157, TreeNode158, TreeNode159})
        Dim TreeNode161 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Course Bookings", 5, 5)
        Dim TreeNode162 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Course Delegates", 5, 5)
        Dim TreeNode163 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Feed Backs", 5, 5)
        Dim TreeNode164 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Training", 14, 14, New System.Windows.Forms.TreeNode() {TreeNode161, TreeNode162, TreeNode163})
        Dim TreeNode165 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Issued Loans", 5, 5)
        Dim TreeNode166 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loan Balances", 5, 5)
        Dim TreeNode167 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Defaulters", 5, 5)
        Dim TreeNode168 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loan Incomes", 5, 5)
        Dim TreeNode169 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loans", New System.Windows.Forms.TreeNode() {TreeNode165, TreeNode166, TreeNode167, TreeNode168})
        Dim TreeNode170 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Create and Manage Products", 10, 9)
        Dim TreeNode171 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory Setup", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode170})
        Dim TreeNode172 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("From Stores to Sales", 10, 9)
        Dim TreeNode173 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("From Sales to Stores", 10, 9)
        Dim TreeNode174 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inter-branch Transfers", 10, 9)
        Dim TreeNode175 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exit Passes", 10, 9)
        Dim TreeNode176 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transfers", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode172, TreeNode173, TreeNode174, TreeNode175})
        Dim TreeNode177 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receive Inventory", 10, 9)
        Dim TreeNode178 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Receiving", New System.Windows.Forms.TreeNode() {TreeNode177})
        Dim TreeNode179 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tobacco Bales", 10, 9)
        Dim TreeNode180 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bales Out", 10, 9)
        Dim TreeNode181 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transmission File", 10, 9)
        Dim TreeNode182 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("File Regeneration and Print", 10, 9)
        Dim TreeNode183 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Create and Maintain Bale Grades", 10, 9)
        Dim TreeNode184 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bale Data Analyses and Print", 10, 9)
        Dim TreeNode185 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction File Reverse", 10, 9)
        Dim TreeNode186 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Farming", New System.Windows.Forms.TreeNode() {TreeNode179, TreeNode180, TreeNode181, TreeNode182, TreeNode183, TreeNode184, TreeNode185})
        Dim SuperTabColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Dim SuperTabControlBoxStateColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabControlBoxStateColorTable = New DevComponents.DotNetBar.Rendering.SuperTabControlBoxStateColorTable()
        Dim SuperTabPanelColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable = New DevComponents.DotNetBar.Rendering.SuperTabPanelColorTable()
        Dim SuperTabPanelItemColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable = New DevComponents.DotNetBar.Rendering.SuperTabPanelItemColorTable()
        Dim SuperTabLinearGradientColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlMain = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.NavigationPane1 = New DevComponents.DotNetBar.NavigationPane()
        Me.NavigationPanePanel1 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvSales = New System.Windows.Forms.TreeView()
        Me.btnSales = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPanePanel6 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.NavigationPanePanel4 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvAccounts = New System.Windows.Forms.TreeView()
        Me.btnAccounts = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPanePanel3 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvSuppliers = New System.Windows.Forms.TreeView()
        Me.btnSuppliers = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPanePanel7 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvEmployees = New System.Windows.Forms.TreeView()
        Me.btnEmployees = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPanePanel2 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvReports = New System.Windows.Forms.TreeView()
        Me.imageListRpt = New System.Windows.Forms.ImageList(Me.components)
        Me.btnReports = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPanePanel5 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvInventory = New System.Windows.Forms.TreeView()
        Me.btnInventory = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tabMain = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.KryptonPanel23 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel8 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblMainCaption = New DevComponents.DotNetBar.LabelX()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.lblDb = New DevComponents.DotNetBar.LabelItem()
        Me.lblAccountsStatus = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ProgressBar1 = New DevComponents.DotNetBar.ProgressBarItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCompanySetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOpenCompany = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateCompany = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImportExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLedgerImports = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBankImports = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.AddinApplicationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScholastica = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCoopLight = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLegal = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMicroFinancing = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrinterSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilityProgramsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BasicDataImporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSalesFromTillslipFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SynchronizeDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OnlineTransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InternetBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteDesktopConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSpreadSheet = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMSMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.InvoiceStatusUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InlandRevenueReturnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.WifiSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WifiDashboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDocumentBuilder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFormBuilder = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoanAmortizerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOwnProfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResetDocumentKeysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalesSMSAlertTimesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMSHTTPSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBanks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.SynchronizationSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnitsOfMeasureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FinancialYearEndRolloverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBackupPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReconnectDb = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCustomerTransactionFix = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.RegisterProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TroubleShootingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TechnicalSupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutFinancialLightEdgeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pdSmallPayslips = New System.Drawing.Printing.PrintDocument()
        Me.pdTotals = New System.Drawing.Printing.PrintDocument()
        Me.pdSummary = New System.Drawing.Printing.PrintDocument()
        Me.pdSchedules = New System.Drawing.Printing.PrintDocument()
        Me.pdFormatTwo = New System.Drawing.Printing.PrintDocument()
        Me.pdMasterFile = New System.Drawing.Printing.PrintDocument()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.ppdUserReports = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        Me.NavigationPane1.SuspendLayout()
        Me.NavigationPanePanel1.SuspendLayout()
        Me.NavigationPanePanel4.SuspendLayout()
        Me.NavigationPanePanel3.SuspendLayout()
        Me.NavigationPanePanel7.SuspendLayout()
        Me.NavigationPanePanel2.SuspendLayout()
        Me.NavigationPanePanel5.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.SuperTabControlPanel7.SuspendLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 697)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1007, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(1006, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 697)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1006, 1)
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
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 696)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
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
        Me.imageList.Images.SetKeyName(9, "11.png")
        Me.imageList.Images.SetKeyName(10, "13.png")
        Me.imageList.Images.SetKeyName(11, "14.png")
        Me.imageList.Images.SetKeyName(12, "15.png")
        Me.imageList.Images.SetKeyName(13, "16.png")
        Me.imageList.Images.SetKeyName(14, "17.png")
        Me.imageList.Images.SetKeyName(15, "25.png")
        Me.imageList.Images.SetKeyName(16, "26.png")
        Me.imageList.Images.SetKeyName(17, "41.png")
        Me.imageList.Images.SetKeyName(18, "42.png")
        Me.imageList.Images.SetKeyName(19, "45.png")
        Me.imageList.Images.SetKeyName(20, "46.png")
        Me.imageList.Images.SetKeyName(21, "47.png")
        Me.imageList.Images.SetKeyName(22, "112.png")
        Me.imageList.Images.SetKeyName(23, "129.png")
        Me.imageList.Images.SetKeyName(24, "136.png")
        Me.imageList.Images.SetKeyName(25, "137.png")
        Me.imageList.Images.SetKeyName(26, "149.png")
        Me.imageList.Images.SetKeyName(27, "202.png")
        Me.imageList.Images.SetKeyName(28, "420.png")
        Me.imageList.Images.SetKeyName(29, "folder_16.png")
        Me.imageList.Images.SetKeyName(30, "folder_add_16.png")
        Me.imageList.Images.SetKeyName(31, "folder_rss_16.png")
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.SplitContainer1)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge6)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge5)
        Me.pnlMain.Controls.Add(Me.Bar2)
        Me.pnlMain.Controls.Add(Me.MenuStrip1)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.ForeColor = System.Drawing.Color.Black
        Me.pnlMain.Location = New System.Drawing.Point(1, 1)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1005, 696)
        Me.pnlMain.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.pnlMain.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.pnlMain.TabIndex = 18
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ExpandablePanel1)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.KryptonPanel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblMainCaption)
        Me.SplitContainer1.Panel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Size = New System.Drawing.Size(1005, 646)
        Me.SplitContainer1.SplitterDistance = 183
        Me.SplitContainer1.TabIndex = 26
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.NavigationPane1)
        Me.ExpandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel1.HideControlsWhenCollapsed = True
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(183, 646)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 32
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Navigation"
        '
        'NavigationPane1
        '
        Me.NavigationPane1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel1)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel6)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel4)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel3)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel7)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel2)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel5)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPane1.ForeColor = System.Drawing.Color.Black
        Me.NavigationPane1.ItemPaddingBottom = 2
        Me.NavigationPane1.ItemPaddingTop = 2
        Me.NavigationPane1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSales, Me.btnSuppliers, Me.btnAccounts, Me.btnInventory, Me.btnEmployees, Me.btnReports})
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 26)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.NavigationBarHeight = 246
        Me.NavigationPane1.Size = New System.Drawing.Size(183, 620)
        Me.NavigationPane1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NavigationPane1.TabIndex = 32
        '
        '
        '
        Me.NavigationPane1.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.NavigationPane1.TitlePanel.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPane1.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPane1.TitlePanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPane1.TitlePanel.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPane1.TitlePanel.Name = "panelTitle"
        Me.NavigationPane1.TitlePanel.Size = New System.Drawing.Size(183, 24)
        Me.NavigationPane1.TitlePanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.NavigationPane1.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.NavigationPane1.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPane1.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.NavigationPane1.TitlePanel.Style.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPane1.TitlePanel.Style.ForeColor.Color = System.Drawing.Color.White
        Me.NavigationPane1.TitlePanel.Style.GradientAngle = 90
        Me.NavigationPane1.TitlePanel.Style.MarginLeft = 4
        Me.NavigationPane1.TitlePanel.TabIndex = 0
        Me.NavigationPane1.TitlePanel.Text = "Sales and Debtors"
        '
        'NavigationPanePanel1
        '
        Me.NavigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel1.Controls.Add(Me.tvSales)
        Me.NavigationPanePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel1.Location = New System.Drawing.Point(0, 24)
        Me.NavigationPanePanel1.Name = "NavigationPanePanel1"
        Me.NavigationPanePanel1.ParentItem = Me.btnSales
        Me.NavigationPanePanel1.Size = New System.Drawing.Size(183, 350)
        Me.NavigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel1.Style.GradientAngle = 90
        Me.NavigationPanePanel1.TabIndex = 5
        '
        'tvSales
        '
        Me.tvSales.BackColor = System.Drawing.Color.White
        Me.tvSales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvSales.ForeColor = System.Drawing.Color.Black
        Me.tvSales.HideSelection = False
        Me.tvSales.ImageIndex = 0
        Me.tvSales.ImageList = Me.imageList
        Me.tvSales.Location = New System.Drawing.Point(0, 0)
        Me.tvSales.Name = "tvSales"
        TreeNode1.ImageIndex = 2
        TreeNode1.Name = "NodeYearlyReview"
        TreeNode1.SelectedImageIndex = 3
        TreeNode1.Text = "Trade Debtors"
        TreeNode2.ImageIndex = 4
        TreeNode2.Name = "NodeCandidateInterview"
        TreeNode2.SelectedImageIndex = 4
        TreeNode2.Text = "Lay-by Clients"
        TreeNode3.ImageKey = "08.png"
        TreeNode3.Name = "Node0"
        TreeNode3.SelectedImageIndex = 7
        TreeNode3.Text = "Farmers Listing"
        TreeNode4.ImageIndex = 0
        TreeNode4.Name = "NodeAppointments"
        TreeNode4.SelectedImageIndex = 0
        TreeNode4.Text = "Customers"
        TreeNode5.ImageIndex = 10
        TreeNode5.Name = "NodeAdministration"
        TreeNode5.SelectedImageIndex = 9
        TreeNode5.Text = "Cash Sales"
        TreeNode6.ImageIndex = 10
        TreeNode6.Name = "Programmers"
        TreeNode6.SelectedImageIndex = 9
        TreeNode6.Text = "Quotations"
        TreeNode7.ImageIndex = 10
        TreeNode7.Name = "NodeManagers"
        TreeNode7.SelectedImageIndex = 9
        TreeNode7.Text = "Invoices"
        TreeNode8.ImageIndex = 10
        TreeNode8.Name = "Node0"
        TreeNode8.SelectedImageIndex = 9
        TreeNode8.Text = "Proforma Invoices"
        TreeNode9.ImageIndex = 10
        TreeNode9.Name = "Node0"
        TreeNode9.SelectedImageIndex = 9
        TreeNode9.Text = "Credit Notes"
        TreeNode10.ImageIndex = 10
        TreeNode10.Name = "Node0"
        TreeNode10.SelectedImageIndex = 9
        TreeNode10.Text = "Customer Payments"
        TreeNode11.ImageIndex = 10
        TreeNode11.Name = "Node0"
        TreeNode11.SelectedImageIndex = 9
        TreeNode11.Text = "Customer Refunds"
        TreeNode12.ImageIndex = 0
        TreeNode12.Name = "NodeEmployees"
        TreeNode12.SelectedImageIndex = 0
        TreeNode12.Text = "Sales"
        TreeNode13.ImageIndex = 10
        TreeNode13.Name = "Node5"
        TreeNode13.SelectedImageIndex = 9
        TreeNode13.Text = "Straight Exchange"
        TreeNode14.ImageIndex = 10
        TreeNode14.Name = "Node6"
        TreeNode14.SelectedImageIndex = 9
        TreeNode14.Text = "Exchange and Top-up"
        TreeNode15.Name = "Node4"
        TreeNode15.Text = "Exchanges"
        TreeNode16.ImageIndex = 10
        TreeNode16.Name = "Node1"
        TreeNode16.SelectedImageIndex = 9
        TreeNode16.Text = "Sales Specials"
        TreeNode17.ImageIndex = 10
        TreeNode17.Name = "Node3"
        TreeNode17.SelectedImageIndex = 9
        TreeNode17.Text = "Customer Loyality Programs"
        TreeNode18.Name = "Node0"
        TreeNode18.Text = "Settings"
        TreeNode19.ImageIndex = 10
        TreeNode19.Name = "Node5"
        TreeNode19.SelectedImageIndex = 9
        TreeNode19.Text = "Day/Period Processes"
        TreeNode20.Name = "Node4"
        TreeNode20.Text = "Sales Cashout"
        TreeNode21.ImageIndex = 10
        TreeNode21.Name = "Node1"
        TreeNode21.SelectedImageIndex = 9
        TreeNode21.Text = "Projects"
        TreeNode22.ImageIndex = 10
        TreeNode22.Name = "Node1"
        TreeNode22.SelectedImageIndex = 9
        TreeNode22.Text = "Claims"
        TreeNode23.ImageIndex = 10
        TreeNode23.Name = "Node2"
        TreeNode23.SelectedImageIndex = 9
        TreeNode23.Text = "Jobs"
        TreeNode24.ImageIndex = 10
        TreeNode24.Name = "Node3"
        TreeNode24.SelectedImageIndex = 9
        TreeNode24.Text = "Jobs Service Parameters"
        TreeNode25.Name = "Node0"
        TreeNode25.Text = "Projects and Jobs"
        TreeNode26.ImageIndex = 10
        TreeNode26.Name = "Node1"
        TreeNode26.SelectedImageIndex = 9
        TreeNode26.Text = "Loan Types"
        TreeNode27.ImageIndex = 10
        TreeNode27.Name = "Node2"
        TreeNode27.SelectedImageIndex = 9
        TreeNode27.Text = "Loan Customers"
        TreeNode28.ImageIndex = 10
        TreeNode28.Name = "Node3"
        TreeNode28.SelectedImageIndex = 9
        TreeNode28.Text = "Advance Loan"
        TreeNode29.ImageIndex = 10
        TreeNode29.Name = "Node4"
        TreeNode29.SelectedImageIndex = 9
        TreeNode29.Text = "Repay Loan"
        TreeNode30.Name = "Node0"
        TreeNode30.Text = "Loans"
        Me.tvSales.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode12, TreeNode15, TreeNode18, TreeNode20, TreeNode25, TreeNode30})
        Me.tvSales.SelectedImageIndex = 0
        Me.tvSales.Size = New System.Drawing.Size(183, 350)
        Me.tvSales.TabIndex = 1
        '
        'btnSales
        '
        Me.btnSales.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSales.Checked = True
        Me.btnSales.Image = CType(resources.GetObject("btnSales.Image"), System.Drawing.Image)
        Me.btnSales.Name = "btnSales"
        Me.btnSales.OptionGroup = "navBar"
        Me.btnSales.Symbol = "57895"
        Me.btnSales.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSales.Text = "Sales and Debtors"
        '
        'NavigationPanePanel6
        '
        Me.NavigationPanePanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel6.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPanePanel6.Name = "NavigationPanePanel6"
        Me.NavigationPanePanel6.ParentItem = Nothing
        Me.NavigationPanePanel6.Size = New System.Drawing.Size(183, 374)
        Me.NavigationPanePanel6.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel6.Style.GradientAngle = 90
        Me.NavigationPanePanel6.TabIndex = 34
        '
        'NavigationPanePanel4
        '
        Me.NavigationPanePanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel4.Controls.Add(Me.tvAccounts)
        Me.NavigationPanePanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel4.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPanePanel4.Name = "NavigationPanePanel4"
        Me.NavigationPanePanel4.ParentItem = Me.btnAccounts
        Me.NavigationPanePanel4.Size = New System.Drawing.Size(183, 374)
        Me.NavigationPanePanel4.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel4.Style.GradientAngle = 90
        Me.NavigationPanePanel4.TabIndex = 17
        '
        'tvAccounts
        '
        Me.tvAccounts.BackColor = System.Drawing.Color.White
        Me.tvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvAccounts.ForeColor = System.Drawing.Color.Black
        Me.tvAccounts.HideSelection = False
        Me.tvAccounts.ImageIndex = 0
        Me.tvAccounts.ImageList = Me.imageList
        Me.tvAccounts.Location = New System.Drawing.Point(0, 0)
        Me.tvAccounts.Name = "tvAccounts"
        TreeNode31.ImageIndex = 10
        TreeNode31.Name = "NodeYearlyReview"
        TreeNode31.SelectedImageIndex = 9
        TreeNode31.Text = "Cashbook"
        TreeNode32.ImageIndex = 10
        TreeNode32.Name = "NodeCandidateInterview"
        TreeNode32.SelectedImageIndex = 9
        TreeNode32.Text = "Ledgers"
        TreeNode33.ImageIndex = 10
        TreeNode33.Name = "NodeProjectMilestone"
        TreeNode33.SelectedImageIndex = 9
        TreeNode33.Text = "Journals"
        TreeNode34.ImageIndex = 0
        TreeNode34.Name = "NodeAppointments"
        TreeNode34.SelectedImageIndex = 0
        TreeNode34.Text = "Accounting Entries"
        TreeNode35.ImageIndex = 10
        TreeNode35.Name = "Node1"
        TreeNode35.SelectedImageIndex = 9
        TreeNode35.Text = "Chart Of Accounts"
        TreeNode36.ImageIndex = 10
        TreeNode36.Name = "Node2"
        TreeNode36.SelectedImageIndex = 9
        TreeNode36.Text = "Cashbooks Setup"
        TreeNode37.ImageIndex = 10
        TreeNode37.Name = "Node4"
        TreeNode37.SelectedImageIndex = 9
        TreeNode37.Text = "Financial Periods"
        TreeNode38.ImageIndex = 10
        TreeNode38.Name = "Node0"
        TreeNode38.SelectedImageIndex = 9
        TreeNode38.Text = "Special Ledger Accounts"
        TreeNode39.Name = "Node0"
        TreeNode39.Text = "Settings"
        TreeNode40.ImageIndex = 10
        TreeNode40.Name = "Node6"
        TreeNode40.SelectedImageIndex = 9
        TreeNode40.Text = "Assets"
        TreeNode41.ImageIndex = 10
        TreeNode41.Name = "Node7"
        TreeNode41.SelectedImageIndex = 9
        TreeNode41.Text = "Classifications"
        TreeNode42.Name = "Node5"
        TreeNode42.Text = "Asset Management"
        Me.tvAccounts.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode34, TreeNode39, TreeNode42})
        Me.tvAccounts.SelectedImageIndex = 0
        Me.tvAccounts.Size = New System.Drawing.Size(183, 374)
        Me.tvAccounts.TabIndex = 1
        '
        'btnAccounts
        '
        Me.btnAccounts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAccounts.Image = CType(resources.GetObject("btnAccounts.Image"), System.Drawing.Image)
        Me.btnAccounts.Name = "btnAccounts"
        Me.btnAccounts.OptionGroup = "navBar"
        Me.btnAccounts.Symbol = "57532"
        Me.btnAccounts.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnAccounts.Text = "Accounting"
        '
        'NavigationPanePanel3
        '
        Me.NavigationPanePanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel3.Controls.Add(Me.tvSuppliers)
        Me.NavigationPanePanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel3.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPanePanel3.Name = "NavigationPanePanel3"
        Me.NavigationPanePanel3.ParentItem = Me.btnSuppliers
        Me.NavigationPanePanel3.Size = New System.Drawing.Size(183, 374)
        Me.NavigationPanePanel3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel3.Style.GradientAngle = 90
        Me.NavigationPanePanel3.TabIndex = 13
        '
        'tvSuppliers
        '
        Me.tvSuppliers.BackColor = System.Drawing.Color.White
        Me.tvSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvSuppliers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvSuppliers.ForeColor = System.Drawing.Color.Black
        Me.tvSuppliers.HideSelection = False
        Me.tvSuppliers.ImageIndex = 0
        Me.tvSuppliers.ImageList = Me.imageList
        Me.tvSuppliers.Location = New System.Drawing.Point(0, 0)
        Me.tvSuppliers.Name = "tvSuppliers"
        TreeNode43.ImageIndex = 10
        TreeNode43.Name = "Node0"
        TreeNode43.SelectedImageIndex = 9
        TreeNode43.Text = "Suppliers"
        TreeNode44.ImageIndex = 10
        TreeNode44.Name = "Node0"
        TreeNode44.SelectedImageIndex = 9
        TreeNode44.Text = "Creditors Grouping"
        TreeNode45.Name = "Node8"
        TreeNode45.Text = "Suppliers"
        TreeNode46.ImageIndex = 10
        TreeNode46.Name = "Node4"
        TreeNode46.SelectedImageIndex = 9
        TreeNode46.Text = "Supplier Invoices"
        TreeNode47.ImageIndex = 10
        TreeNode47.Name = "Node5"
        TreeNode47.SelectedImageIndex = 9
        TreeNode47.Text = "Debit Notes"
        TreeNode48.ImageIndex = 10
        TreeNode48.Name = "Node3"
        TreeNode48.SelectedImageIndex = 9
        TreeNode48.Text = "Orders"
        TreeNode49.ImageIndex = 10
        TreeNode49.Name = "Node0"
        TreeNode49.SelectedImageIndex = 9
        TreeNode49.Text = "Supplier Payments"
        TreeNode50.Name = "Node6"
        TreeNode50.Text = "Actvities"
        TreeNode51.ImageIndex = 10
        TreeNode51.Name = "Node1"
        TreeNode51.SelectedImageIndex = 9
        TreeNode51.Text = "Enter Bills"
        TreeNode52.ImageIndex = 10
        TreeNode52.Name = "Node2"
        TreeNode52.SelectedImageIndex = 9
        TreeNode52.Text = "Pay Bills and Orders"
        TreeNode53.ImageIndex = 10
        TreeNode53.Name = "Node0"
        TreeNode53.SelectedImageIndex = 9
        TreeNode53.Text = "Supplier Refunds"
        TreeNode54.Name = "Node7"
        TreeNode54.Text = "Bills"
        Me.tvSuppliers.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode50, TreeNode54})
        Me.tvSuppliers.SelectedImageIndex = 0
        Me.tvSuppliers.Size = New System.Drawing.Size(183, 374)
        Me.tvSuppliers.TabIndex = 1
        '
        'btnSuppliers
        '
        Me.btnSuppliers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSuppliers.Image = CType(resources.GetObject("btnSuppliers.Image"), System.Drawing.Image)
        Me.btnSuppliers.Name = "btnSuppliers"
        Me.btnSuppliers.OptionGroup = "navBar"
        Me.btnSuppliers.Symbol = ""
        Me.btnSuppliers.Text = "Purchases and Suppliers"
        '
        'NavigationPanePanel7
        '
        Me.NavigationPanePanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel7.Controls.Add(Me.tvEmployees)
        Me.NavigationPanePanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel7.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPanePanel7.Name = "NavigationPanePanel7"
        Me.NavigationPanePanel7.ParentItem = Me.btnEmployees
        Me.NavigationPanePanel7.Size = New System.Drawing.Size(183, 374)
        Me.NavigationPanePanel7.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel7.Style.GradientAngle = 90
        Me.NavigationPanePanel7.TabIndex = 38
        '
        'tvEmployees
        '
        Me.tvEmployees.BackColor = System.Drawing.Color.White
        Me.tvEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvEmployees.ForeColor = System.Drawing.Color.Black
        Me.tvEmployees.HideSelection = False
        Me.tvEmployees.ImageIndex = 0
        Me.tvEmployees.ImageList = Me.imageList
        Me.tvEmployees.Location = New System.Drawing.Point(0, 0)
        Me.tvEmployees.Name = "tvEmployees"
        TreeNode55.ImageIndex = 4
        TreeNode55.Name = "NodeYearlyReview"
        TreeNode55.SelectedImageIndex = 2
        TreeNode55.Text = "Employees"
        TreeNode56.ImageIndex = 10
        TreeNode56.Name = "NodeCandidateInterview"
        TreeNode56.SelectedImageIndex = 9
        TreeNode56.Text = "Work Structures"
        TreeNode57.ImageIndex = 0
        TreeNode57.Name = "NodeAppointments"
        TreeNode57.SelectedImageIndex = 0
        TreeNode57.Text = "Human Resources"
        TreeNode58.ImageIndex = 10
        TreeNode58.Name = "NodeAdministration"
        TreeNode58.SelectedImageIndex = 9
        TreeNode58.Text = "Batch Transaction Entries"
        TreeNode59.ImageIndex = 10
        TreeNode59.Name = "NodeProjectMilestone"
        TreeNode59.SelectedImageIndex = 9
        TreeNode59.Text = "Payroll Run"
        TreeNode60.ImageIndex = 10
        TreeNode60.Name = "Programmers"
        TreeNode60.SelectedImageIndex = 9
        TreeNode60.Text = "Bank Extracts"
        TreeNode61.ImageIndex = 10
        TreeNode61.Name = "NodeManagers"
        TreeNode61.SelectedImageIndex = 9
        TreeNode61.Text = "Reset Employee YTDs"
        TreeNode62.ImageIndex = 0
        TreeNode62.Name = "NodeEmployees"
        TreeNode62.SelectedImageIndex = 0
        TreeNode62.Text = "Payroll"
        TreeNode63.ImageIndex = 10
        TreeNode63.Name = "Node1"
        TreeNode63.SelectedImageIndex = 9
        TreeNode63.Text = "Calculations"
        TreeNode64.ImageIndex = 10
        TreeNode64.Name = "Node2"
        TreeNode64.SelectedImageIndex = 9
        TreeNode64.Text = "Codes"
        TreeNode65.ImageIndex = 10
        TreeNode65.Name = "Node3"
        TreeNode65.SelectedImageIndex = 9
        TreeNode65.Text = "Constants"
        TreeNode66.ImageIndex = 10
        TreeNode66.Name = "Node4"
        TreeNode66.SelectedImageIndex = 9
        TreeNode66.Text = "Dates"
        TreeNode67.ImageIndex = 10
        TreeNode67.Name = "Node5"
        TreeNode67.SelectedImageIndex = 9
        TreeNode67.Text = "Reference Numbers"
        TreeNode68.ImageIndex = 10
        TreeNode68.Name = "Node6"
        TreeNode68.SelectedImageIndex = 9
        TreeNode68.Text = "Flags"
        TreeNode69.ImageIndex = 10
        TreeNode69.Name = "Node7"
        TreeNode69.SelectedImageIndex = 9
        TreeNode69.Text = "6 Column Report Writer"
        TreeNode70.ImageIndex = 10
        TreeNode70.Name = "Node8"
        TreeNode70.SelectedImageIndex = 9
        TreeNode70.Text = "Special Codes"
        TreeNode71.ImageIndex = 10
        TreeNode71.Name = "Node9"
        TreeNode71.SelectedImageIndex = 9
        TreeNode71.Text = "Tax Tables"
        TreeNode72.ImageIndex = 10
        TreeNode72.Name = "Node10"
        TreeNode72.SelectedImageIndex = 9
        TreeNode72.Text = "Trekked Codes"
        TreeNode73.ImageIndex = 10
        TreeNode73.Name = "Node11"
        TreeNode73.SelectedImageIndex = 9
        TreeNode73.Text = "ITF16 Calculations"
        TreeNode74.ImageIndex = 10
        TreeNode74.Name = "Node12"
        TreeNode74.SelectedImageIndex = 9
        TreeNode74.Text = "Summary Reports"
        TreeNode75.ImageIndex = 10
        TreeNode75.Name = "Node13"
        TreeNode75.SelectedImageIndex = 9
        TreeNode75.Text = "Calendar"
        TreeNode76.ImageIndex = 10
        TreeNode76.Name = "Node14"
        TreeNode76.SelectedImageIndex = 9
        TreeNode76.Text = "Exception Messages"
        TreeNode77.ImageIndex = 10
        TreeNode77.Name = "Node15"
        TreeNode77.SelectedImageIndex = 9
        TreeNode77.Text = "Tables"
        TreeNode78.ImageIndex = 10
        TreeNode78.Name = "Node0"
        TreeNode78.SelectedImageIndex = 9
        TreeNode78.Text = "Tax Rebates"
        TreeNode79.Name = "Node0"
        TreeNode79.Text = "Settings"
        Me.tvEmployees.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode57, TreeNode62, TreeNode79})
        Me.tvEmployees.SelectedImageIndex = 0
        Me.tvEmployees.Size = New System.Drawing.Size(183, 374)
        Me.tvEmployees.TabIndex = 2
        '
        'btnEmployees
        '
        Me.btnEmployees.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEmployees.Image = CType(resources.GetObject("btnEmployees.Image"), System.Drawing.Image)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.OptionGroup = "navBar"
        Me.btnEmployees.Symbol = "58941"
        Me.btnEmployees.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnEmployees.Text = "Employees"
        '
        'NavigationPanePanel2
        '
        Me.NavigationPanePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel2.Controls.Add(Me.tvReports)
        Me.NavigationPanePanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel2.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPanePanel2.Name = "NavigationPanePanel2"
        Me.NavigationPanePanel2.ParentItem = Me.btnReports
        Me.NavigationPanePanel2.Size = New System.Drawing.Size(183, 374)
        Me.NavigationPanePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel2.Style.GradientAngle = 90
        Me.NavigationPanePanel2.TabIndex = 53
        '
        'tvReports
        '
        Me.tvReports.BackColor = System.Drawing.Color.White
        Me.tvReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReports.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvReports.ForeColor = System.Drawing.Color.Black
        Me.tvReports.HideSelection = False
        Me.tvReports.ImageIndex = 0
        Me.tvReports.ImageList = Me.imageListRpt
        Me.tvReports.Location = New System.Drawing.Point(0, 0)
        Me.tvReports.Name = "tvReports"
        TreeNode80.ImageIndex = 5
        TreeNode80.Name = "Node7"
        TreeNode80.SelectedImageIndex = 5
        TreeNode80.Text = "Inventory List"
        TreeNode81.ImageIndex = 5
        TreeNode81.Name = "Node0"
        TreeNode81.SelectedImageIndex = 5
        TreeNode81.Text = "Received Inventory"
        TreeNode82.ImageIndex = 5
        TreeNode82.Name = "Node22"
        TreeNode82.SelectedImageIndex = 5
        TreeNode82.Text = "Non Moving Stock"
        TreeNode83.ImageIndex = 5
        TreeNode83.Name = "Node23"
        TreeNode83.SelectedImageIndex = 5
        TreeNode83.Text = "Stock Take Sheets"
        TreeNode84.ImageIndex = 5
        TreeNode84.Name = "Node24"
        TreeNode84.SelectedImageIndex = 5
        TreeNode84.Text = "Critically Low Inventory"
        TreeNode85.ImageIndex = 5
        TreeNode85.Name = "Node0"
        TreeNode85.SelectedImageIndex = 5
        TreeNode85.Text = "Individual Stock Movement"
        TreeNode86.ImageIndex = 5
        TreeNode86.Name = "Node0"
        TreeNode86.SelectedImageIndex = 5
        TreeNode86.Text = "Detailed Stock History"
        TreeNode87.ImageIndex = 5
        TreeNode87.Name = "Node25"
        TreeNode87.SelectedImageIndex = 5
        TreeNode87.Text = "Stock Movements Summary"
        TreeNode88.ImageIndex = 5
        TreeNode88.Name = "Node0"
        TreeNode88.SelectedImageIndex = 5
        TreeNode88.Text = "Stock Movements Details"
        TreeNode89.ImageIndex = 5
        TreeNode89.Name = "Node0"
        TreeNode89.SelectedImageIndex = 5
        TreeNode89.Text = "Transfers"
        TreeNode90.ImageIndex = 5
        TreeNode90.Name = "Node0"
        TreeNode90.SelectedImageIndex = 5
        TreeNode90.Text = "Stock Valuation Summary"
        TreeNode91.ImageIndex = 5
        TreeNode91.Name = "Node1"
        TreeNode91.SelectedImageIndex = 5
        TreeNode91.Text = "Daily Stores Reconciliation"
        TreeNode92.ImageIndex = 5
        TreeNode92.Name = "Node0"
        TreeNode92.SelectedImageIndex = 5
        TreeNode92.Text = "Inventory Sales History"
        TreeNode93.ImageIndex = 6
        TreeNode93.Name = "Node21"
        TreeNode93.SelectedImageIndex = 6
        TreeNode93.Text = "Inventory"
        TreeNode94.ImageIndex = 5
        TreeNode94.Name = "Node3"
        TreeNode94.SelectedImageIndex = 5
        TreeNode94.Text = "Sales By Customer Summary"
        TreeNode95.ImageIndex = 5
        TreeNode95.Name = "Node4"
        TreeNode95.SelectedImageIndex = 5
        TreeNode95.Text = "Sales By Customer Detail"
        TreeNode96.ImageIndex = 5
        TreeNode96.Name = "Node0"
        TreeNode96.SelectedImageIndex = 5
        TreeNode96.Text = "Sales By Item Summary"
        TreeNode97.ImageIndex = 5
        TreeNode97.Name = "Node1"
        TreeNode97.SelectedImageIndex = 5
        TreeNode97.Text = "Sales By Item Detail"
        TreeNode98.ImageIndex = 5
        TreeNode98.Name = "Node2"
        TreeNode98.SelectedImageIndex = 5
        TreeNode98.Text = "Today's Sales By Item"
        TreeNode99.ImageIndex = 5
        TreeNode99.Name = "Node3"
        TreeNode99.SelectedImageIndex = 5
        TreeNode99.Text = "Sales Comparison (By week, Month, Year)"
        TreeNode100.ImageIndex = 5
        TreeNode100.Name = "Node4"
        TreeNode100.SelectedImageIndex = 5
        TreeNode100.Text = "Most Profitable Products/Services"
        TreeNode101.ImageIndex = 5
        TreeNode101.Name = "Node0"
        TreeNode101.SelectedImageIndex = 5
        TreeNode101.Text = "Sales Sheets"
        TreeNode102.ImageIndex = 5
        TreeNode102.Name = "Node0"
        TreeNode102.SelectedImageIndex = 5
        TreeNode102.Text = "Z-Report"
        TreeNode103.ImageIndex = 7
        TreeNode103.Name = "Node2"
        TreeNode103.SelectedImageIndex = 7
        TreeNode103.Text = "Sales"
        TreeNode104.ImageIndex = 5
        TreeNode104.Name = "NodeYearlyReview"
        TreeNode104.SelectedImageIndex = 5
        TreeNode104.Text = "Sales Analysis"
        TreeNode105.ImageIndex = 5
        TreeNode105.Name = "NodeProjectMilestone"
        TreeNode105.SelectedImageIndex = 5
        TreeNode105.Text = "Purchases Analysis"
        TreeNode106.ImageIndex = 5
        TreeNode106.Name = "Node5"
        TreeNode106.SelectedImageIndex = 5
        TreeNode106.Text = "Vendor List"
        TreeNode107.ImageIndex = 5
        TreeNode107.Name = "Node6"
        TreeNode107.SelectedImageIndex = 5
        TreeNode107.Text = "Payments List"
        TreeNode108.ImageIndex = 5
        TreeNode108.Name = "Node8"
        TreeNode108.SelectedImageIndex = 5
        TreeNode108.Text = "Invoice List"
        TreeNode109.ImageIndex = 5
        TreeNode109.Name = "Node9"
        TreeNode109.SelectedImageIndex = 5
        TreeNode109.Text = "Employee List"
        TreeNode110.ImageIndex = 5
        TreeNode110.Name = "Node10"
        TreeNode110.SelectedImageIndex = 5
        TreeNode110.Text = "Customer List"
        TreeNode111.ImageIndex = 5
        TreeNode111.Name = "Node0"
        TreeNode111.SelectedImageKey = "TableSmall.png"
        TreeNode111.Text = "Periodic Accounts Analysis"
        TreeNode112.ImageIndex = 5
        TreeNode112.Name = "Node0"
        TreeNode112.SelectedImageIndex = 5
        TreeNode112.Text = "Expenses"
        TreeNode113.ImageIndex = 13
        TreeNode113.Name = "NodeAppointments"
        TreeNode113.SelectedImageIndex = 13
        TreeNode113.Text = "Analysis Tools"
        TreeNode114.ImageIndex = 5
        TreeNode114.Name = "Node28"
        TreeNode114.SelectedImageIndex = 5
        TreeNode114.Text = "Cashbook Transactions"
        TreeNode115.ImageIndex = 5
        TreeNode115.Name = "Node26"
        TreeNode115.SelectedImageIndex = 5
        TreeNode115.Text = "Bank Reconciliation Statement"
        TreeNode116.ImageIndex = 5
        TreeNode116.Name = "PHC"
        TreeNode116.SelectedImageIndex = 5
        TreeNode116.Text = "Trial Balance"
        TreeNode117.ImageIndex = 5
        TreeNode117.Name = "Node0"
        TreeNode117.SelectedImageIndex = 5
        TreeNode117.Text = "Ledger Transactions"
        TreeNode118.ImageIndex = 5
        TreeNode118.Name = "Node11"
        TreeNode118.SelectedImageIndex = 5
        TreeNode118.Text = "Profit and Loss Standard"
        TreeNode119.ImageIndex = 5
        TreeNode119.Name = "OHS"
        TreeNode119.SelectedImageIndex = 5
        TreeNode119.Text = "Balance Sheet"
        TreeNode120.ImageIndex = 5
        TreeNode120.Name = "IOD"
        TreeNode120.SelectedImageIndex = 5
        TreeNode120.Text = "Cash Flow Statement"
        TreeNode121.ImageIndex = 5
        TreeNode121.Name = "CDM"
        TreeNode121.SelectedImageIndex = 5
        TreeNode121.Text = "Transaction Detail by Account"
        TreeNode122.ImageIndex = 5
        TreeNode122.Name = "TBM"
        TreeNode122.SelectedImageIndex = 5
        TreeNode122.Text = "General Ledger Report"
        TreeNode123.ImageIndex = 5
        TreeNode123.Name = "HIVM"
        TreeNode123.SelectedImageIndex = 5
        TreeNode123.Text = "Sales Tax Liability"
        TreeNode124.ImageIndex = 5
        TreeNode124.Name = "MS"
        TreeNode124.SelectedImageIndex = 5
        TreeNode124.Text = "Transaction Detail by Tax Code"
        TreeNode125.ImageIndex = 5
        TreeNode125.Name = "DSM"
        TreeNode125.SelectedImageIndex = 5
        TreeNode125.Text = "YTD Profit Compared to Last Year"
        TreeNode126.ImageIndex = 5
        TreeNode126.Name = "ABSM"
        TreeNode126.SelectedImageIndex = 5
        TreeNode126.Text = "Sales Tax Collected Per Period"
        TreeNode127.ImageIndex = 5
        TreeNode127.Name = "Node27"
        TreeNode127.SelectedImageIndex = 5
        TreeNode127.Text = "Assets Depreciation Schedule"
        TreeNode128.ImageIndex = 5
        TreeNode128.Name = "Node0"
        TreeNode128.SelectedImageIndex = 5
        TreeNode128.Text = "Ledger Account Balances"
        TreeNode129.ImageIndex = 12
        TreeNode129.Name = "NodeEmployees"
        TreeNode129.SelectedImageIndex = 12
        TreeNode129.Text = "Financial"
        TreeNode130.ImageIndex = 5
        TreeNode130.Name = "Node0"
        TreeNode130.SelectedImageIndex = 5
        TreeNode130.Text = "Customer Balances"
        TreeNode131.ImageIndex = 5
        TreeNode131.Name = "Node12"
        TreeNode131.SelectedImageIndex = 5
        TreeNode131.Text = "A/R Aging Analysis"
        TreeNode132.ImageIndex = 5
        TreeNode132.Name = "Node13"
        TreeNode132.SelectedImageIndex = 5
        TreeNode132.Text = "Customer Transaction History"
        TreeNode133.ImageIndex = 5
        TreeNode133.Name = "Node14"
        TreeNode133.SelectedImageIndex = 5
        TreeNode133.Text = "Open Invoiced By Due Date"
        TreeNode134.ImageIndex = 5
        TreeNode134.Name = "Node15"
        TreeNode134.SelectedImageIndex = 5
        TreeNode134.Text = "Most Profitable Customers"
        TreeNode135.ImageIndex = 5
        TreeNode135.Name = "Node29"
        TreeNode135.SelectedImageIndex = 5
        TreeNode135.Text = "Customer Statements"
        TreeNode136.ImageIndex = 5
        TreeNode136.Name = "Node0"
        TreeNode136.SelectedImageIndex = 5
        TreeNode136.Text = "Customer Balances At Specified Date"
        TreeNode137.ImageIndex = 9
        TreeNode137.Name = "Node1"
        TreeNode137.SelectedImageIndex = 9
        TreeNode137.Text = "Customers and Receivables"
        TreeNode138.ImageIndex = 5
        TreeNode138.Name = "Node17"
        TreeNode138.SelectedImageIndex = 5
        TreeNode138.Text = "Creditors Transaction History"
        TreeNode139.ImageIndex = 5
        TreeNode139.Name = "Node18"
        TreeNode139.SelectedImageIndex = 5
        TreeNode139.Text = "Today's Creditors Payments"
        TreeNode140.ImageIndex = 5
        TreeNode140.Name = "Node19"
        TreeNode140.SelectedImageIndex = 5
        TreeNode140.Text = "Amounts Due to Creditors"
        TreeNode141.ImageIndex = 5
        TreeNode141.Name = "Node20"
        TreeNode141.SelectedImageIndex = 5
        TreeNode141.Text = "Orders"
        TreeNode142.ImageIndex = 10
        TreeNode142.Name = "Node2"
        TreeNode142.SelectedImageIndex = 10
        TreeNode142.Text = "Vendors/Creditors"
        TreeNode143.ImageIndex = 5
        TreeNode143.Name = "Node1"
        TreeNode143.SelectedImageIndex = 5
        TreeNode143.Text = "Employee Full Masterfile"
        TreeNode144.ImageIndex = 5
        TreeNode144.Name = "Node20"
        TreeNode144.SelectedImageIndex = 5
        TreeNode144.Text = "Employee Listing"
        TreeNode145.ImageIndex = 5
        TreeNode145.Name = "Node21"
        TreeNode145.SelectedImageIndex = 5
        TreeNode145.Text = "Salary Increaments"
        TreeNode146.ImageIndex = 5
        TreeNode146.Name = "Node22"
        TreeNode146.SelectedImageIndex = 5
        TreeNode146.Text = "New Entrants"
        TreeNode147.ImageIndex = 5
        TreeNode147.Name = "Node23"
        TreeNode147.SelectedImageIndex = 5
        TreeNode147.Text = "Leavers"
        TreeNode148.ImageIndex = 5
        TreeNode148.Name = "Node24"
        TreeNode148.SelectedImageIndex = 5
        TreeNode148.Text = "Staff Turnover"
        TreeNode149.ImageIndex = 5
        TreeNode149.Name = "Node25"
        TreeNode149.SelectedImageIndex = 5
        TreeNode149.Text = "Transfers"
        TreeNode150.ImageIndex = 2
        TreeNode150.Name = "Node0"
        TreeNode150.SelectedImageIndex = 2
        TreeNode150.Text = "Personnel"
        TreeNode151.ImageIndex = 5
        TreeNode151.Name = "Node1"
        TreeNode151.SelectedImageIndex = 5
        TreeNode151.Text = "A5 Payslips"
        TreeNode152.ImageIndex = 5
        TreeNode152.Name = "Node2"
        TreeNode152.SelectedImageIndex = 5
        TreeNode152.Text = "A5 Payslips Format 2"
        TreeNode153.ImageIndex = 5
        TreeNode153.Name = "Node3"
        TreeNode153.SelectedImageIndex = 5
        TreeNode153.Text = "Employee Control"
        TreeNode154.ImageIndex = 5
        TreeNode154.Name = "Node4"
        TreeNode154.SelectedImageIndex = 5
        TreeNode154.Text = "Payroll Control Totals"
        TreeNode155.ImageIndex = 5
        TreeNode155.Name = "Node5"
        TreeNode155.SelectedImageIndex = 5
        TreeNode155.Text = "Bank Transfer Schedule"
        TreeNode156.ImageIndex = 5
        TreeNode156.Name = "Node6"
        TreeNode156.SelectedImageIndex = 5
        TreeNode156.Text = "Payroll Summary"
        TreeNode157.ImageIndex = 5
        TreeNode157.Name = "Node7"
        TreeNode157.SelectedImageIndex = 5
        TreeNode157.Text = "Audit Trail"
        TreeNode158.ImageIndex = 5
        TreeNode158.Name = "Node8"
        TreeNode158.SelectedImageIndex = 5
        TreeNode158.Text = "Coinage Analysis"
        TreeNode159.ImageIndex = 5
        TreeNode159.Name = "Node9"
        TreeNode159.SelectedImageIndex = 5
        TreeNode159.Text = "Tax Certificates"
        TreeNode160.ImageIndex = 11
        TreeNode160.Name = "Node0"
        TreeNode160.SelectedImageIndex = 11
        TreeNode160.Text = "Payroll"
        TreeNode161.ImageIndex = 5
        TreeNode161.Name = "Node11"
        TreeNode161.SelectedImageIndex = 5
        TreeNode161.Text = "Course Bookings"
        TreeNode162.ImageIndex = 5
        TreeNode162.Name = "Node12"
        TreeNode162.SelectedImageIndex = 5
        TreeNode162.Text = "Course Delegates"
        TreeNode163.ImageIndex = 5
        TreeNode163.Name = "Node13"
        TreeNode163.SelectedImageIndex = 5
        TreeNode163.Text = "Feed Backs"
        TreeNode164.ImageIndex = 14
        TreeNode164.Name = "Node10"
        TreeNode164.SelectedImageIndex = 14
        TreeNode164.Text = "Training"
        TreeNode165.ImageIndex = 5
        TreeNode165.Name = "Node1"
        TreeNode165.SelectedImageIndex = 5
        TreeNode165.Text = "Issued Loans"
        TreeNode166.ImageIndex = 5
        TreeNode166.Name = "Node2"
        TreeNode166.SelectedImageIndex = 5
        TreeNode166.Text = "Loan Balances"
        TreeNode167.ImageIndex = 5
        TreeNode167.Name = "Node3"
        TreeNode167.SelectedImageIndex = 5
        TreeNode167.Text = "Defaulters"
        TreeNode168.ImageIndex = 5
        TreeNode168.Name = "Node4"
        TreeNode168.SelectedImageIndex = 5
        TreeNode168.Text = "Loan Incomes"
        TreeNode169.Name = "Node0"
        TreeNode169.Text = "Loans"
        Me.tvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode93, TreeNode103, TreeNode113, TreeNode129, TreeNode137, TreeNode142, TreeNode150, TreeNode160, TreeNode164, TreeNode169})
        Me.tvReports.SelectedImageIndex = 0
        Me.tvReports.Size = New System.Drawing.Size(183, 374)
        Me.tvReports.TabIndex = 27
        '
        'imageListRpt
        '
        Me.imageListRpt.ImageStream = CType(resources.GetObject("imageListRpt.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageListRpt.TransparentColor = System.Drawing.Color.Transparent
        Me.imageListRpt.Images.SetKeyName(0, "Folder.ico")
        Me.imageListRpt.Images.SetKeyName(1, "calendar.png")
        Me.imageListRpt.Images.SetKeyName(2, "user2.png")
        Me.imageListRpt.Images.SetKeyName(3, "dude1.png")
        Me.imageListRpt.Images.SetKeyName(4, "businessman2.png")
        Me.imageListRpt.Images.SetKeyName(5, "TableSmall.png")
        Me.imageListRpt.Images.SetKeyName(6, "Delivery.png")
        Me.imageListRpt.Images.SetKeyName(7, "Money.png")
        Me.imageListRpt.Images.SetKeyName(8, "49.png")
        Me.imageListRpt.Images.SetKeyName(9, "07.png")
        Me.imageListRpt.Images.SetKeyName(10, "10.png")
        Me.imageListRpt.Images.SetKeyName(11, "25.png")
        Me.imageListRpt.Images.SetKeyName(12, "133.png")
        Me.imageListRpt.Images.SetKeyName(13, "Search.bmp")
        Me.imageListRpt.Images.SetKeyName(14, "420.png")
        '
        'btnReports
        '
        Me.btnReports.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.OptionGroup = "navBar"
        Me.btnReports.Symbol = ""
        Me.btnReports.Text = "Reports"
        '
        'NavigationPanePanel5
        '
        Me.NavigationPanePanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel5.Controls.Add(Me.tvInventory)
        Me.NavigationPanePanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel5.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPanePanel5.Name = "NavigationPanePanel5"
        Me.NavigationPanePanel5.ParentItem = Me.btnInventory
        Me.NavigationPanePanel5.Size = New System.Drawing.Size(183, 374)
        Me.NavigationPanePanel5.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel5.Style.GradientAngle = 90
        Me.NavigationPanePanel5.TabIndex = 30
        '
        'tvInventory
        '
        Me.tvInventory.BackColor = System.Drawing.Color.White
        Me.tvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvInventory.ForeColor = System.Drawing.Color.Black
        Me.tvInventory.HideSelection = False
        Me.tvInventory.ImageIndex = 0
        Me.tvInventory.ImageList = Me.imageList
        Me.tvInventory.Location = New System.Drawing.Point(0, 0)
        Me.tvInventory.Name = "tvInventory"
        TreeNode170.ImageIndex = 10
        TreeNode170.Name = "NodeYearlyReview"
        TreeNode170.SelectedImageIndex = 9
        TreeNode170.Text = "Create and Manage Products"
        TreeNode171.ImageIndex = 0
        TreeNode171.Name = "NodeAppointments"
        TreeNode171.SelectedImageIndex = 0
        TreeNode171.Text = "Inventory Setup"
        TreeNode172.ImageIndex = 10
        TreeNode172.Name = "NodeCandidateInterview"
        TreeNode172.SelectedImageIndex = 9
        TreeNode172.Text = "From Stores to Sales"
        TreeNode173.ImageIndex = 10
        TreeNode173.Name = "NodeProjectMilestone"
        TreeNode173.SelectedImageIndex = 9
        TreeNode173.Text = "From Sales to Stores"
        TreeNode174.ImageIndex = 10
        TreeNode174.Name = "NodeAdministration"
        TreeNode174.SelectedImageIndex = 9
        TreeNode174.Text = "Inter-branch Transfers"
        TreeNode175.ImageIndex = 10
        TreeNode175.Name = "Programmers"
        TreeNode175.SelectedImageIndex = 9
        TreeNode175.Text = "Exit Passes"
        TreeNode176.ImageIndex = 0
        TreeNode176.Name = "NodeEmployees"
        TreeNode176.SelectedImageIndex = 0
        TreeNode176.Text = "Transfers"
        TreeNode177.ImageIndex = 10
        TreeNode177.Name = "Node1"
        TreeNode177.SelectedImageIndex = 9
        TreeNode177.Text = "Receive Inventory"
        TreeNode178.Name = "Node0"
        TreeNode178.Text = "Receiving"
        TreeNode179.ImageIndex = 10
        TreeNode179.Name = "Node1"
        TreeNode179.SelectedImageIndex = 9
        TreeNode179.Text = "Tobacco Bales"
        TreeNode180.ImageIndex = 10
        TreeNode180.Name = "Node0"
        TreeNode180.SelectedImageIndex = 9
        TreeNode180.Text = "Bales Out"
        TreeNode181.ImageIndex = 10
        TreeNode181.Name = "Node0"
        TreeNode181.SelectedImageIndex = 9
        TreeNode181.Text = "Transmission File"
        TreeNode182.ImageIndex = 10
        TreeNode182.Name = "Node0"
        TreeNode182.SelectedImageIndex = 9
        TreeNode182.Text = "File Regeneration and Print"
        TreeNode183.ImageIndex = 10
        TreeNode183.Name = "Node0"
        TreeNode183.SelectedImageIndex = 9
        TreeNode183.Text = "Create and Maintain Bale Grades"
        TreeNode184.ImageIndex = 10
        TreeNode184.Name = "Node0"
        TreeNode184.SelectedImageIndex = 9
        TreeNode184.Text = "Bale Data Analyses and Print"
        TreeNode185.ImageIndex = 10
        TreeNode185.Name = "Node0"
        TreeNode185.SelectedImageIndex = 9
        TreeNode185.Text = "Transaction File Reverse"
        TreeNode186.Name = "Node0"
        TreeNode186.Text = "Farming"
        Me.tvInventory.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode171, TreeNode176, TreeNode178, TreeNode186})
        Me.tvInventory.SelectedImageIndex = 0
        Me.tvInventory.Size = New System.Drawing.Size(183, 374)
        Me.tvInventory.TabIndex = 2
        '
        'btnInventory
        '
        Me.btnInventory.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnInventory.Image = CType(resources.GetObject("btnInventory.Image"), System.Drawing.Image)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.OptionGroup = "navBar"
        Me.btnInventory.Symbol = "58712"
        Me.btnInventory.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnInventory.Text = "Inventory"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.tabMain)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 29)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(9)
        Me.KryptonPanel1.Size = New System.Drawing.Size(817, 617)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 3
        '
        'tabMain
        '
        Me.tabMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.tabMain.ControlBox.CloseBox.Name = ""
        Me.tabMain.ControlBox.CloseBox.Visible = True
        '
        '
        '
        Me.tabMain.ControlBox.MenuBox.Name = ""
        Me.tabMain.ControlBox.Name = ""
        Me.tabMain.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabMain.ControlBox.MenuBox, Me.tabMain.ControlBox.CloseBox})
        Me.tabMain.Controls.Add(Me.SuperTabControlPanel7)
        Me.tabMain.Controls.Add(Me.SuperTabControlPanel8)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.ForeColor = System.Drawing.Color.Black
        Me.tabMain.Location = New System.Drawing.Point(9, 9)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.ReorderTabsEnabled = True
        Me.tabMain.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabMain.SelectedTabIndex = -1
        Me.tabMain.Size = New System.Drawing.Size(799, 599)
        Me.tabMain.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.tabMain.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.TabIndex = 44
        Me.tabMain.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem5})
        SuperTabLinearGradientColorTable2.AdaptiveGradient = False
        SuperTabLinearGradientColorTable2.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
        SuperTabColorTable1.Background = SuperTabLinearGradientColorTable2
        SuperTabControlBoxStateColorTable1.Image = System.Drawing.Color.Black
        SuperTabColorTable1.ControlBoxDefault = SuperTabControlBoxStateColorTable1
        Me.tabMain.TabStripColor = SuperTabColorTable1
        Me.tabMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabMain.Text = "Financial Light"
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.SuperTabControlPanel7.Controls.Add(Me.KryptonPanel23)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Padding = New System.Windows.Forms.Padding(1)
        SuperTabLinearGradientColorTable1.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))}
        SuperTabLinearGradientColorTable1.GradientAngle = 100
        SuperTabLinearGradientColorTable1.Positions = New Single() {90.0!, 230.0!}
        SuperTabPanelItemColorTable1.Background = SuperTabLinearGradientColorTable1
        SuperTabPanelColorTable1.Bottom = SuperTabPanelItemColorTable1
        Me.SuperTabControlPanel7.PanelColor = SuperTabPanelColorTable1
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(799, 576)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.SuperTabItem5
        '
        'KryptonPanel23
        '
        Me.KryptonPanel23.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel23.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel23.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel23.Name = "KryptonPanel23"
        Me.KryptonPanel23.Padding = New System.Windows.Forms.Padding(9)
        Me.KryptonPanel23.Size = New System.Drawing.Size(797, 574)
        Me.KryptonPanel23.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel23.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel23.TabIndex = 0
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel7
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        Me.SuperTabItem5.Text = "Home"
        '
        'SuperTabControlPanel8
        '
        Me.SuperTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel8.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel8.Name = "SuperTabControlPanel8"
        Me.SuperTabControlPanel8.Size = New System.Drawing.Size(799, 576)
        Me.SuperTabControlPanel8.TabIndex = 1
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(1, 28)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(817, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'lblMainCaption
        '
        Me.lblMainCaption.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        '
        '
        '
        Me.lblMainCaption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMainCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMainCaption.ForeColor = System.Drawing.Color.Black
        Me.lblMainCaption.Location = New System.Drawing.Point(1, 0)
        Me.lblMainCaption.Name = "lblMainCaption"
        Me.lblMainCaption.PaddingLeft = 12
        Me.lblMainCaption.PaddingRight = 12
        Me.lblMainCaption.Size = New System.Drawing.Size(817, 28)
        Me.lblMainCaption.TabIndex = 1
        Me.lblMainCaption.Text = "Active Page"
        Me.lblMainCaption.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 646)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 671)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1005, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 24)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1005, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblDb, Me.lblAccountsStatus, Me.LabelItem1, Me.ProgressBar1})
        Me.Bar2.Location = New System.Drawing.Point(0, 672)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 3
        Me.Bar2.PaddingLeft = 12
        Me.Bar2.PaddingRight = 12
        Me.Bar2.PaddingTop = 3
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(1005, 24)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 8
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'lblDb
        '
        Me.lblDb.Name = "lblDb"
        Me.lblDb.PaddingLeft = 12
        Me.lblDb.PaddingRight = 12
        '
        'lblAccountsStatus
        '
        Me.lblAccountsStatus.ForeColor = System.Drawing.Color.Yellow
        Me.lblAccountsStatus.Name = "lblAccountsStatus"
        Me.lblAccountsStatus.PaddingLeft = 12
        Me.lblAccountsStatus.PaddingRight = 12
        Me.lblAccountsStatus.Stretch = True
        Me.lblAccountsStatus.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "A product of Great Wits Technologies"
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
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UtilityProgramsToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1005, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCompanySetup, Me.ToolStripSeparator13, Me.mnuOpenCompany, Me.mnuCreateCompany, Me.ToolStripMenuItem1, Me.mnuImportExport, Me.TestToolStripMenuItem, Me.AddinApplicationsToolStripMenuItem, Me.ToolStripSeparator16, Me.mnuBackup, Me.mnuRestore, Me.ToolStripMenuItem3, Me.mnuPrinterSettings, Me.mnuPrint, Me.ToolStripMenuItem4, Me.mnuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuCompanySetup
        '
        Me.mnuCompanySetup.Name = "mnuCompanySetup"
        Me.mnuCompanySetup.Size = New System.Drawing.Size(187, 22)
        Me.mnuCompanySetup.Text = "Organization Settings"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(184, 6)
        '
        'mnuOpenCompany
        '
        Me.mnuOpenCompany.Image = CType(resources.GetObject("mnuOpenCompany.Image"), System.Drawing.Image)
        Me.mnuOpenCompany.Name = "mnuOpenCompany"
        Me.mnuOpenCompany.Size = New System.Drawing.Size(187, 22)
        Me.mnuOpenCompany.Text = "Switch Organozation"
        '
        'mnuCreateCompany
        '
        Me.mnuCreateCompany.Name = "mnuCreateCompany"
        Me.mnuCreateCompany.Size = New System.Drawing.Size(187, 22)
        Me.mnuCreateCompany.Text = "New Company ..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(184, 6)
        '
        'mnuImportExport
        '
        Me.mnuImportExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLedgerImports, Me.ToolStripSeparator14, Me.mnuBankImports})
        Me.mnuImportExport.Image = CType(resources.GetObject("mnuImportExport.Image"), System.Drawing.Image)
        Me.mnuImportExport.Name = "mnuImportExport"
        Me.mnuImportExport.Size = New System.Drawing.Size(187, 22)
        Me.mnuImportExport.Text = "Import"
        '
        'mnuLedgerImports
        '
        Me.mnuLedgerImports.Name = "mnuLedgerImports"
        Me.mnuLedgerImports.Size = New System.Drawing.Size(163, 22)
        Me.mnuLedgerImports.Text = "Ledger Accounts"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(160, 6)
        '
        'mnuBankImports
        '
        Me.mnuBankImports.Name = "mnuBankImports"
        Me.mnuBankImports.Size = New System.Drawing.Size(163, 22)
        Me.mnuBankImports.Text = "Bank Names"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(184, 6)
        '
        'AddinApplicationsToolStripMenuItem
        '
        Me.AddinApplicationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuScholastica, Me.ToolStripSeparator15, Me.mnuCoopLight, Me.ToolStripMenuItem5, Me.mnuLegal, Me.ToolStripMenuItem6, Me.mnuMoc, Me.ToolStripMenuItem7, Me.mnuMicroFinancing})
        Me.AddinApplicationsToolStripMenuItem.Name = "AddinApplicationsToolStripMenuItem"
        Me.AddinApplicationsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AddinApplicationsToolStripMenuItem.Text = "Add-in Applications"
        '
        'mnuScholastica
        '
        Me.mnuScholastica.Name = "mnuScholastica"
        Me.mnuScholastica.Size = New System.Drawing.Size(160, 22)
        Me.mnuScholastica.Text = "Scholastica"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(157, 6)
        '
        'mnuCoopLight
        '
        Me.mnuCoopLight.Name = "mnuCoopLight"
        Me.mnuCoopLight.Size = New System.Drawing.Size(160, 22)
        Me.mnuCoopLight.Text = "Co-op Light"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(157, 6)
        '
        'mnuLegal
        '
        Me.mnuLegal.Name = "mnuLegal"
        Me.mnuLegal.Size = New System.Drawing.Size(160, 22)
        Me.mnuLegal.Text = "Legal Manager"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(157, 6)
        '
        'mnuMoc
        '
        Me.mnuMoc.Name = "mnuMoc"
        Me.mnuMoc.Size = New System.Drawing.Size(160, 22)
        Me.mnuMoc.Text = "MOC"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(157, 6)
        '
        'mnuMicroFinancing
        '
        Me.mnuMicroFinancing.Name = "mnuMicroFinancing"
        Me.mnuMicroFinancing.Size = New System.Drawing.Size(160, 22)
        Me.mnuMicroFinancing.Text = "Micro-financing"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(184, 6)
        '
        'mnuBackup
        '
        Me.mnuBackup.Image = CType(resources.GetObject("mnuBackup.Image"), System.Drawing.Image)
        Me.mnuBackup.Name = "mnuBackup"
        Me.mnuBackup.Size = New System.Drawing.Size(187, 22)
        Me.mnuBackup.Text = "Backup Database"
        '
        'mnuRestore
        '
        Me.mnuRestore.Name = "mnuRestore"
        Me.mnuRestore.Size = New System.Drawing.Size(187, 22)
        Me.mnuRestore.Text = "Restore Database"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(184, 6)
        '
        'mnuPrinterSettings
        '
        Me.mnuPrinterSettings.Image = CType(resources.GetObject("mnuPrinterSettings.Image"), System.Drawing.Image)
        Me.mnuPrinterSettings.Name = "mnuPrinterSettings"
        Me.mnuPrinterSettings.Size = New System.Drawing.Size(187, 22)
        Me.mnuPrinterSettings.Text = "Printer Settings"
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(187, 22)
        Me.mnuPrint.Text = "Print ..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(184, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(187, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'UtilityProgramsToolStripMenuItem
        '
        Me.UtilityProgramsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BasicDataImporterToolStripMenuItem, Me.ImportSalesFromTillslipFileToolStripMenuItem, Me.SynchronizeDataToolStripMenuItem, Me.ToolStripSeparator1, Me.OnlineTransfersToolStripMenuItem, Me.InternetBrowserToolStripMenuItem, Me.RemoteDesktopConnectionToolStripMenuItem, Me.ToolStripSeparator5, Me.mnuSpreadSheet, Me.SMSMessagesToolStripMenuItem, Me.ToolStripSeparator4, Me.InvoiceStatusUpdateToolStripMenuItem, Me.InlandRevenueReturnsToolStripMenuItem, Me.ToolStripSeparator2, Me.WifiSettingsToolStripMenuItem, Me.WifiDashboardToolStripMenuItem, Me.ToolStripSeparator3, Me.DataViewerToolStripMenuItem, Me.mnuDocumentBuilder, Me.ToolStripMenuItem8, Me.mnuFormBuilder, Me.LoanAmortizerToolStripMenuItem})
        Me.UtilityProgramsToolStripMenuItem.Name = "UtilityProgramsToolStripMenuItem"
        Me.UtilityProgramsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.UtilityProgramsToolStripMenuItem.Text = "&Utilities"
        '
        'BasicDataImporterToolStripMenuItem
        '
        Me.BasicDataImporterToolStripMenuItem.Image = CType(resources.GetObject("BasicDataImporterToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BasicDataImporterToolStripMenuItem.Name = "BasicDataImporterToolStripMenuItem"
        Me.BasicDataImporterToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.BasicDataImporterToolStripMenuItem.Text = "Basic Data Importer"
        '
        'ImportSalesFromTillslipFileToolStripMenuItem
        '
        Me.ImportSalesFromTillslipFileToolStripMenuItem.Name = "ImportSalesFromTillslipFileToolStripMenuItem"
        Me.ImportSalesFromTillslipFileToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ImportSalesFromTillslipFileToolStripMenuItem.Text = "Import Sales From Tillslip File"
        '
        'SynchronizeDataToolStripMenuItem
        '
        Me.SynchronizeDataToolStripMenuItem.Name = "SynchronizeDataToolStripMenuItem"
        Me.SynchronizeDataToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.SynchronizeDataToolStripMenuItem.Text = "Synchronize Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'OnlineTransfersToolStripMenuItem
        '
        Me.OnlineTransfersToolStripMenuItem.Name = "OnlineTransfersToolStripMenuItem"
        Me.OnlineTransfersToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.OnlineTransfersToolStripMenuItem.Text = "Online Transfers"
        '
        'InternetBrowserToolStripMenuItem
        '
        Me.InternetBrowserToolStripMenuItem.Image = CType(resources.GetObject("InternetBrowserToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InternetBrowserToolStripMenuItem.Name = "InternetBrowserToolStripMenuItem"
        Me.InternetBrowserToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.InternetBrowserToolStripMenuItem.Text = "Internet Browser"
        '
        'RemoteDesktopConnectionToolStripMenuItem
        '
        Me.RemoteDesktopConnectionToolStripMenuItem.Name = "RemoteDesktopConnectionToolStripMenuItem"
        Me.RemoteDesktopConnectionToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.RemoteDesktopConnectionToolStripMenuItem.Text = "Remote Desktop Connection"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(225, 6)
        '
        'mnuSpreadSheet
        '
        Me.mnuSpreadSheet.Image = CType(resources.GetObject("mnuSpreadSheet.Image"), System.Drawing.Image)
        Me.mnuSpreadSheet.Name = "mnuSpreadSheet"
        Me.mnuSpreadSheet.Size = New System.Drawing.Size(228, 22)
        Me.mnuSpreadSheet.Text = "Light Spread Sheet"
        '
        'SMSMessagesToolStripMenuItem
        '
        Me.SMSMessagesToolStripMenuItem.Image = CType(resources.GetObject("SMSMessagesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SMSMessagesToolStripMenuItem.Name = "SMSMessagesToolStripMenuItem"
        Me.SMSMessagesToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.SMSMessagesToolStripMenuItem.Text = "SMS Messages"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(225, 6)
        '
        'InvoiceStatusUpdateToolStripMenuItem
        '
        Me.InvoiceStatusUpdateToolStripMenuItem.Name = "InvoiceStatusUpdateToolStripMenuItem"
        Me.InvoiceStatusUpdateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.InvoiceStatusUpdateToolStripMenuItem.Text = "Invoice Status Update"
        '
        'InlandRevenueReturnsToolStripMenuItem
        '
        Me.InlandRevenueReturnsToolStripMenuItem.Name = "InlandRevenueReturnsToolStripMenuItem"
        Me.InlandRevenueReturnsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.InlandRevenueReturnsToolStripMenuItem.Text = "Inland Revenue Returns"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(225, 6)
        '
        'WifiSettingsToolStripMenuItem
        '
        Me.WifiSettingsToolStripMenuItem.Name = "WifiSettingsToolStripMenuItem"
        Me.WifiSettingsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.WifiSettingsToolStripMenuItem.Text = "Wi-fi Settings"
        '
        'WifiDashboardToolStripMenuItem
        '
        Me.WifiDashboardToolStripMenuItem.Name = "WifiDashboardToolStripMenuItem"
        Me.WifiDashboardToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.WifiDashboardToolStripMenuItem.Text = "Wi-fi Dashboard"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(225, 6)
        '
        'DataViewerToolStripMenuItem
        '
        Me.DataViewerToolStripMenuItem.Image = CType(resources.GetObject("DataViewerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DataViewerToolStripMenuItem.Name = "DataViewerToolStripMenuItem"
        Me.DataViewerToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DataViewerToolStripMenuItem.Text = "Query Builder"
        '
        'mnuDocumentBuilder
        '
        Me.mnuDocumentBuilder.Name = "mnuDocumentBuilder"
        Me.mnuDocumentBuilder.Size = New System.Drawing.Size(228, 22)
        Me.mnuDocumentBuilder.Text = "Report Builder"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(225, 6)
        '
        'mnuFormBuilder
        '
        Me.mnuFormBuilder.Name = "mnuFormBuilder"
        Me.mnuFormBuilder.Size = New System.Drawing.Size(228, 22)
        Me.mnuFormBuilder.Text = "Form Builder"
        '
        'LoanAmortizerToolStripMenuItem
        '
        Me.LoanAmortizerToolStripMenuItem.Name = "LoanAmortizerToolStripMenuItem"
        Me.LoanAmortizerToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.LoanAmortizerToolStripMenuItem.Text = "Loan Amortizer"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOwnProfile, Me.ToolStripSeparator8, Me.ResetDocumentKeysToolStripMenuItem, Me.ToolStripSeparator9, Me.SalesSMSAlertTimesToolStripMenuItem, Me.SMSHTTPSettingsToolStripMenuItem, Me.ToolStripSeparator12, Me.mnuBanks, Me.ToolStripSeparator7, Me.SynchronizationSettingsToolStripMenuItem, Me.UnitsOfMeasureToolStripMenuItem, Me.ToolStripSeparator6, Me.FinancialYearEndRolloverToolStripMenuItem, Me.ToolStripMenuItem2, Me.mnuBackupPath, Me.mnuReconnectDb, Me.ToolStripMenuItem9, Me.mnuCustomerTransactionFix})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'mnuOwnProfile
        '
        Me.mnuOwnProfile.Name = "mnuOwnProfile"
        Me.mnuOwnProfile.Size = New System.Drawing.Size(244, 22)
        Me.mnuOwnProfile.Text = "Own Profile Change"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(241, 6)
        '
        'ResetDocumentKeysToolStripMenuItem
        '
        Me.ResetDocumentKeysToolStripMenuItem.Image = CType(resources.GetObject("ResetDocumentKeysToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ResetDocumentKeysToolStripMenuItem.Name = "ResetDocumentKeysToolStripMenuItem"
        Me.ResetDocumentKeysToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.ResetDocumentKeysToolStripMenuItem.Text = "Reset Receipts/Invoice Numbers"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(241, 6)
        '
        'SalesSMSAlertTimesToolStripMenuItem
        '
        Me.SalesSMSAlertTimesToolStripMenuItem.Name = "SalesSMSAlertTimesToolStripMenuItem"
        Me.SalesSMSAlertTimesToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.SalesSMSAlertTimesToolStripMenuItem.Text = "Sales SMS Alert Times"
        '
        'SMSHTTPSettingsToolStripMenuItem
        '
        Me.SMSHTTPSettingsToolStripMenuItem.Name = "SMSHTTPSettingsToolStripMenuItem"
        Me.SMSHTTPSettingsToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.SMSHTTPSettingsToolStripMenuItem.Text = "SMS HTTP Settings"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(241, 6)
        '
        'mnuBanks
        '
        Me.mnuBanks.Name = "mnuBanks"
        Me.mnuBanks.Size = New System.Drawing.Size(244, 22)
        Me.mnuBanks.Text = "Banks Setup"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(241, 6)
        '
        'SynchronizationSettingsToolStripMenuItem
        '
        Me.SynchronizationSettingsToolStripMenuItem.Name = "SynchronizationSettingsToolStripMenuItem"
        Me.SynchronizationSettingsToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.SynchronizationSettingsToolStripMenuItem.Text = "Synchronization Settings"
        '
        'UnitsOfMeasureToolStripMenuItem
        '
        Me.UnitsOfMeasureToolStripMenuItem.Name = "UnitsOfMeasureToolStripMenuItem"
        Me.UnitsOfMeasureToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.UnitsOfMeasureToolStripMenuItem.Text = "Units of Measure"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(241, 6)
        '
        'FinancialYearEndRolloverToolStripMenuItem
        '
        Me.FinancialYearEndRolloverToolStripMenuItem.Name = "FinancialYearEndRolloverToolStripMenuItem"
        Me.FinancialYearEndRolloverToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.FinancialYearEndRolloverToolStripMenuItem.Text = "Financial Year-End"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(241, 6)
        '
        'mnuBackupPath
        '
        Me.mnuBackupPath.Name = "mnuBackupPath"
        Me.mnuBackupPath.Size = New System.Drawing.Size(244, 22)
        Me.mnuBackupPath.Text = "Databases Backup Path"
        '
        'mnuReconnectDb
        '
        Me.mnuReconnectDb.Name = "mnuReconnectDb"
        Me.mnuReconnectDb.Size = New System.Drawing.Size(244, 22)
        Me.mnuReconnectDb.Text = "Check/Reconnect Database"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(241, 6)
        '
        'mnuCustomerTransactionFix
        '
        Me.mnuCustomerTransactionFix.Name = "mnuCustomerTransactionFix"
        Me.mnuCustomerTransactionFix.Size = New System.Drawing.Size(244, 22)
        Me.mnuCustomerTransactionFix.Text = "Customer Transactions Fix"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHelpToolStripMenuItem, Me.ToolStripSeparator11, Me.RegisterProductToolStripMenuItem, Me.CheckForUpdatesToolStripMenuItem, Me.TroubleShootingToolStripMenuItem, Me.TechnicalSupportToolStripMenuItem, Me.ToolStripSeparator10, Me.AboutFinancialLightEdgeToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ViewHelpToolStripMenuItem
        '
        Me.ViewHelpToolStripMenuItem.Image = CType(resources.GetObject("ViewHelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewHelpToolStripMenuItem.Name = "ViewHelpToolStripMenuItem"
        Me.ViewHelpToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ViewHelpToolStripMenuItem.Text = "View Help"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(213, 6)
        '
        'RegisterProductToolStripMenuItem
        '
        Me.RegisterProductToolStripMenuItem.Name = "RegisterProductToolStripMenuItem"
        Me.RegisterProductToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RegisterProductToolStripMenuItem.Text = "Register Product"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for Updates"
        '
        'TroubleShootingToolStripMenuItem
        '
        Me.TroubleShootingToolStripMenuItem.Name = "TroubleShootingToolStripMenuItem"
        Me.TroubleShootingToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.TroubleShootingToolStripMenuItem.Text = "Trouble Shooting"
        '
        'TechnicalSupportToolStripMenuItem
        '
        Me.TechnicalSupportToolStripMenuItem.Image = CType(resources.GetObject("TechnicalSupportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TechnicalSupportToolStripMenuItem.Name = "TechnicalSupportToolStripMenuItem"
        Me.TechnicalSupportToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.TechnicalSupportToolStripMenuItem.Text = "Technical Support"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(213, 6)
        '
        'AboutFinancialLightEdgeToolStripMenuItem
        '
        Me.AboutFinancialLightEdgeToolStripMenuItem.Name = "AboutFinancialLightEdgeToolStripMenuItem"
        Me.AboutFinancialLightEdgeToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.AboutFinancialLightEdgeToolStripMenuItem.Text = "About Financial Light Edge"
        '
        'pdSmallPayslips
        '
        '
        'ppd
        '
        Me.ppd.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ppd.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd.Enabled = True
        Me.ppd.Icon = CType(resources.GetObject("ppd.Icon"), System.Drawing.Icon)
        Me.ppd.Name = "ppd"
        Me.ppd.Visible = False
        '
        'ppdUserReports
        '
        Me.ppdUserReports.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdUserReports.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdUserReports.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdUserReports.Enabled = True
        Me.ppdUserReports.Icon = CType(resources.GetObject("ppdUserReports.Icon"), System.Drawing.Icon)
        Me.ppdUserReports.Name = "ppdUserReports"
        Me.ppdUserReports.Visible = False
        '
        'frmLightMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BackgroundImageUnderCaption = True
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(1007, 698)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmLightMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Great Wits Financial Light"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.NavigationPane1.ResumeLayout(False)
        Me.NavigationPanePanel1.ResumeLayout(False)
        Me.NavigationPanePanel4.ResumeLayout(False)
        Me.NavigationPanePanel3.ResumeLayout(False)
        Me.NavigationPanePanel7.ResumeLayout(False)
        Me.NavigationPanePanel2.ResumeLayout(False)
        Me.NavigationPanePanel5.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.SuperTabControlPanel7.ResumeLayout(False)
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Private WithEvents imageList As ImageList
    Friend WithEvents pnlMain As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ProgressBar1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuCreateCompany As ToolStripMenuItem
    Friend WithEvents mnuOpenCompany As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuImportExport As ToolStripMenuItem
    Friend WithEvents mnuBackup As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents NavigationPane1 As DevComponents.DotNetBar.NavigationPane
    Friend WithEvents NavigationPanePanel1 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents btnSales As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NavigationPanePanel3 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents btnSuppliers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NavigationPanePanel4 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents btnAccounts As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents lblMainCaption As DevComponents.DotNetBar.LabelX
    Private WithEvents tvAccounts As System.Windows.Forms.TreeView
    Private WithEvents tvSales As System.Windows.Forms.TreeView
    Private WithEvents tvSuppliers As System.Windows.Forms.TreeView
    Friend WithEvents NavigationPanePanel5 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents btnInventory As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NavigationPanePanel7 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents btnEmployees As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NavigationPanePanel6 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tabMain As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents KryptonPanel23 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel8 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrinterSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UtilityProgramsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tvEmployees As System.Windows.Forms.TreeView
    Private WithEvents tvInventory As System.Windows.Forms.TreeView
    Friend WithEvents lblAccountsStatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDb As DevComponents.DotNetBar.LabelItem
    Friend WithEvents BasicDataImporterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnlineTransfersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportSalesFromTillslipFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InternetBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSpreadSheet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteDesktopConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InlandRevenueReturnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMSMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SynchronizeDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoiceStatusUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WifiSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WifiDashboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDocumentBuilder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RegisterProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TroubleShootingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TechnicalSupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutFinancialLightEdgeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavigationPanePanel2 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents btnReports As DevComponents.DotNetBar.ButtonItem
    Private WithEvents imageListRpt As System.Windows.Forms.ImageList
    Private WithEvents tvReports As System.Windows.Forms.TreeView
    Friend WithEvents pdSmallPayslips As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdTotals As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdSummary As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdSchedules As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdFormatTwo As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdMasterFile As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppd As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ppdUserReports As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents mnuCompanySetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOwnProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ResetDocumentKeysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalesSMSAlertTimesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMSHTTPSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SynchronizationSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnitsOfMeasureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FinancialYearEndRolloverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuReconnectDb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBanks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLedgerImports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBankImports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddinApplicationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuScholastica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCoopLight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLegal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMicroFinancing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFormBuilder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCustomerTransactionFix As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBackupPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoanAmortizerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
