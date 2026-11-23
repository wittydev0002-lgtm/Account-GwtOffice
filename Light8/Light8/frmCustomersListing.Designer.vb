<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomersListing
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomersListing))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridCustomers = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar14 = New DevComponents.DotNetBar.Bar()
        Me.btnNewCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteCustomer = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnNotZero = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDebtorClasses = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dGridCustomers)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.Bar14)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(716, 487)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 23
        '
        'dGridCustomers
        '
        Me.dGridCustomers.AllowUserToAddRows = False
        Me.dGridCustomers.AllowUserToDeleteRows = False
        Me.dGridCustomers.AllowUserToResizeRows = False
        Me.dGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dGridCustomers.ContextMenuStrip = Me.cm1
        Me.dGridCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCustomers.Location = New System.Drawing.Point(1, 78)
        Me.dGridCustomers.Name = "dGridCustomers"
        Me.dGridCustomers.ReadOnly = True
        Me.dGridCustomers.RowHeadersVisible = False
        Me.dGridCustomers.RowHeadersWidth = 25
        Me.dGridCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCustomers.Size = New System.Drawing.Size(714, 409)
        Me.dGridCustomers.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridCustomers.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridCustomers.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridCustomers.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridCustomers.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCustomers.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridCustomers.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridCustomers.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCustomers.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridCustomers.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridCustomers.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCustomers.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCustomers.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCustomers.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridCustomers.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridCustomers.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCustomers.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCustomers.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCustomers.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCustomers.TabIndex = 32
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Account #"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 94
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Telephone"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 94
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Date In"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 79
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Email"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 67
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Address"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 82
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Cellphone"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 93
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
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(714, 51)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.TabIndex = 20
        '
        'chkActiveSearch
        '
        Me.chkActiveSearch.BackColor = System.Drawing.Color.White
        Me.chkActiveSearch.Checked = True
        Me.chkActiveSearch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActiveSearch.ForeColor = System.Drawing.Color.Black
        Me.chkActiveSearch.Location = New System.Drawing.Point(568, 14)
        Me.chkActiveSearch.Name = "chkActiveSearch"
        Me.chkActiveSearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003
        Me.chkActiveSearch.Size = New System.Drawing.Size(95, 22)
        Me.chkActiveSearch.TabIndex = 165
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
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(714, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(714, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar14
        '
        Me.Bar14.AntiAlias = True
        Me.Bar14.BackColor = System.Drawing.Color.Transparent
        Me.Bar14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar14.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar14.IsMaximized = False
        Me.Bar14.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewCustomer, Me.btnEditCustomer, Me.btnDeleteCustomer, Me.ButtonItem18, Me.btnExportCustomers, Me.btnRefreshCustomers, Me.btnDebtorClasses})
        Me.Bar14.Location = New System.Drawing.Point(1, 1)
        Me.Bar14.Name = "Bar14"
        Me.Bar14.RoundCorners = False
        Me.Bar14.Size = New System.Drawing.Size(714, 25)
        Me.Bar14.Stretch = True
        Me.Bar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar14.TabIndex = 18
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
        Me.btnNewCustomer.Tooltip = "Add new customer record"
        '
        'btnEditCustomer
        '
        Me.btnEditCustomer.Image = CType(resources.GetObject("btnEditCustomer.Image"), System.Drawing.Image)
        Me.btnEditCustomer.Name = "btnEditCustomer"
        Me.btnEditCustomer.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditCustomer.Text = "Edit"
        Me.btnEditCustomer.Tooltip = "Edit customer in the selected row"
        '
        'btnDeleteCustomer
        '
        Me.btnDeleteCustomer.BeginGroup = True
        Me.btnDeleteCustomer.Image = CType(resources.GetObject("btnDeleteCustomer.Image"), System.Drawing.Image)
        Me.btnDeleteCustomer.Name = "btnDeleteCustomer"
        Me.btnDeleteCustomer.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteCustomer.Text = "Delete"
        Me.btnDeleteCustomer.Tooltip = "Delete selected row customer"
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
        Me.btnExportCustomers.Image = CType(resources.GetObject("btnExportCustomers.Image"), System.Drawing.Image)
        Me.btnExportCustomers.Name = "btnExportCustomers"
        Me.btnExportCustomers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportCustomers.Text = "Export"
        Me.btnExportCustomers.Tooltip = "Export"
        '
        'btnRefreshCustomers
        '
        Me.btnRefreshCustomers.BeginGroup = True
        Me.btnRefreshCustomers.Image = CType(resources.GetObject("btnRefreshCustomers.Image"), System.Drawing.Image)
        Me.btnRefreshCustomers.Name = "btnRefreshCustomers"
        Me.btnRefreshCustomers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshCustomers.Text = "&Refresh"
        Me.btnRefreshCustomers.Tooltip = "Refresh Listing"
        '
        'btnDebtorClasses
        '
        Me.btnDebtorClasses.BeginGroup = True
        Me.btnDebtorClasses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDebtorClasses.Image = CType(resources.GetObject("btnDebtorClasses.Image"), System.Drawing.Image)
        Me.btnDebtorClasses.ImagePaddingHorizontal = 15
        Me.btnDebtorClasses.Name = "btnDebtorClasses"
        Me.btnDebtorClasses.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDebtorClasses.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnDebtorClasses.Text = "Customer Classes"
        Me.btnDebtorClasses.Tooltip = "Add new customer record"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(714, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 487)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(715, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 487)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
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
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Telephone"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date In"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cellphone"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'frmCustomersListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 487)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Name = "frmCustomersListing"
        Me.Text = "Customers"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar14 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteCustomer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNotZero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkActiveSearch As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnFind As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel81 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge82 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel67 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCustomerSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
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
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents dGridCustomers As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDebtorClasses As DevComponents.DotNetBar.ButtonItem
End Class
