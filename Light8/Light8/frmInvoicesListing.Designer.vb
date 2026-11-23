<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoicesListing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoicesListing))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grd = New AdvancedDataGridView.TreeGridView()
        Me.Column2 = New AdvancedDataGridView.TreeGridColumn()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.Totals = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotal = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.lblDiscounts = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTaxes = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboGroup = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndInvoice = New System.Windows.Forms.DateTimePicker()
        Me.dpStartInvoice = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnRunInvoice = New ComponentFactory.Krypton.Toolkit.KryptonButton()
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
        Me.btnView = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUnpaidInvoices = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBalances = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshInvoice = New DevComponents.DotNetBar.ButtonItem()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.imageStrip = New System.Windows.Forms.ImageList(Me.components)
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.cboGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(716, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 458)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(716, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(715, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 457)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 457)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.grd)
        Me.KryptonPanel1.Controls.Add(Me.Bar4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(714, 457)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 4
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.AllowUserToResizeColumns = False
        Me.grd.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd.BackgroundColor = System.Drawing.Color.White
        Me.grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column1, Me.Column4, Me.Column5, Me.Column6})
        Me.grd.ContextMenuStrip = Me.cm1
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grd.DefaultCellStyle = DataGridViewCellStyle6
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd.GridColor = System.Drawing.Color.White
        Me.grd.ImageList = Nothing
        Me.grd.Location = New System.Drawing.Point(0, 77)
        Me.grd.Name = "grd"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grd.RowHeadersWidth = 25
        Me.grd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.grd.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd.Size = New System.Drawing.Size(714, 360)
        Me.grd.TabIndex = 165
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.DefaultNodeImage = Nothing
        Me.Column2.HeaderText = "Date"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 36
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
        Me.Bar4.Location = New System.Drawing.Point(0, 437)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(714, 20)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 158
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
        'KryptonPanel4
        '
        Me.KryptonPanel4.AutoScroll = True
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.cboGroup)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel4.Controls.Add(Me.dpEndInvoice)
        Me.KryptonPanel4.Controls.Add(Me.dpStartInvoice)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel4.Controls.Add(Me.btnRunInvoice)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(0, 26)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(714, 51)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel4.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel4.TabIndex = 157
        '
        'cboGroup
        '
        Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroup.DropDownWidth = 121
        Me.cboGroup.Items.AddRange(New Object() {"None", "Date", "Customer"})
        Me.cboGroup.Location = New System.Drawing.Point(450, 13)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboGroup.Size = New System.Drawing.Size(121, 21)
        Me.cboGroup.TabIndex = 153
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(372, 15)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 152
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Group by ..."
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(714, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(208, 15)
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
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(57, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'dpEndInvoice
        '
        Me.dpEndInvoice.BackColor = System.Drawing.Color.White
        Me.dpEndInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpEndInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndInvoice.Location = New System.Drawing.Point(267, 14)
        Me.dpEndInvoice.Name = "dpEndInvoice"
        Me.dpEndInvoice.Size = New System.Drawing.Size(95, 20)
        Me.dpEndInvoice.TabIndex = 5
        '
        'dpStartInvoice
        '
        Me.dpStartInvoice.BackColor = System.Drawing.Color.White
        Me.dpStartInvoice.ForeColor = System.Drawing.Color.Black
        Me.dpStartInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartInvoice.Location = New System.Drawing.Point(99, 14)
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
        Me.KryptonPanel2.Location = New System.Drawing.Point(20, 15)
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
        Me.btnRunInvoice.Location = New System.Drawing.Point(577, 13)
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
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(714, 1)
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
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewInvoice, Me.btnEditInvoice, Me.btnDeleteInvoice, Me.btnPrint, Me.btnAccountSettlement, Me.btnDeliveryNote, Me.btnView, Me.btnRefreshInvoice})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(714, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 152
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
        Me.btnBalances.Text = "Customer Balances"
        '
        'btnRefreshInvoice
        '
        Me.btnRefreshInvoice.BeginGroup = True
        Me.btnRefreshInvoice.Image = CType(resources.GetObject("btnRefreshInvoice.Image"), System.Drawing.Image)
        Me.btnRefreshInvoice.Name = "btnRefreshInvoice"
        Me.btnRefreshInvoice.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshInvoice.Text = "Refresh"
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
        'imageStrip
        '
        Me.imageStrip.ImageStream = CType(resources.GetObject("imageStrip.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageStrip.TransparentColor = System.Drawing.Color.Transparent
        Me.imageStrip.Images.SetKeyName(0, "Tracking_Small.png")
        Me.imageStrip.Images.SetKeyName(1, "Female.png")
        Me.imageStrip.Images.SetKeyName(2, "attach.png")
        Me.imageStrip.Images.SetKeyName(3, "User group.png")
        Me.imageStrip.Images.SetKeyName(4, "Male.png")
        Me.imageStrip.Images.SetKeyName(5, "Forward.png")
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Customer Name"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 89
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Doc. #"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 46
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Discount"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 54
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Taxes"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 42
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column6.HeaderText = "Value"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 39
        '
        'frmInvoicesListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 459)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Name = "frmInvoicesListing"
        Me.Text = "Invoices"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.cboGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelected As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSummary As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAccountSettlement As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeliveryNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshInvoice As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnRunInvoice As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents Totals As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDiscounts As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTaxes As DevComponents.DotNetBar.LabelItem
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
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
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents grd As AdvancedDataGridView.TreeGridView
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboGroup As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Private WithEvents imageStrip As System.Windows.Forms.ImageList
    Friend WithEvents Column2 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnView As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUnpaidInvoices As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBalances As DevComponents.DotNetBar.ButtonItem
End Class
