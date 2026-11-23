<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditNotesListings
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreditNotesListings))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGridCreditNotes = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar8 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem13 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem14 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem15 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem16 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem17 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem18 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem19 = New DevComponents.DotNetBar.LabelItem()
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
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar7 = New DevComponents.DotNetBar.Bar()
        Me.btnNewCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnListingPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintCreditNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCreditNotes = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
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
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dGridCreditNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dGridCreditNotes)
        Me.KryptonPanel1.Controls.Add(Me.Bar8)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.Bar7)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(534, 472)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 0
        '
        'dGridCreditNotes
        '
        Me.dGridCreditNotes.AllowUserToAddRows = False
        Me.dGridCreditNotes.AllowUserToDeleteRows = False
        Me.dGridCreditNotes.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridCreditNotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dGridCreditNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn15})
        Me.dGridCreditNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCreditNotes.Location = New System.Drawing.Point(1, 78)
        Me.dGridCreditNotes.Name = "dGridCreditNotes"
        Me.dGridCreditNotes.ReadOnly = True
        Me.dGridCreditNotes.RowHeadersWidth = 25
        Me.dGridCreditNotes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridCreditNotes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridCreditNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCreditNotes.Size = New System.Drawing.Size(532, 373)
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
        Me.dGridCreditNotes.TabIndex = 161
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn15.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 80
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
        Me.Bar8.Location = New System.Drawing.Point(1, 451)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.RoundCorners = False
        Me.Bar8.Size = New System.Drawing.Size(532, 20)
        Me.Bar8.Stretch = True
        Me.Bar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar8.TabIndex = 160
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
        Me.KryptonPanel7.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(532, 51)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel7.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel7.TabIndex = 159
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(532, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(208, 14)
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
        Me.dpEndCreditNote.Location = New System.Drawing.Point(267, 13)
        Me.dpEndCreditNote.Name = "dpEndCreditNote"
        Me.dpEndCreditNote.Size = New System.Drawing.Size(95, 20)
        Me.dpEndCreditNote.TabIndex = 5
        '
        'dpStartCreditNote
        '
        Me.dpStartCreditNote.BackColor = System.Drawing.Color.White
        Me.dpStartCreditNote.ForeColor = System.Drawing.Color.Black
        Me.dpStartCreditNote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartCreditNote.Location = New System.Drawing.Point(99, 13)
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
        Me.KryptonPanel11.Location = New System.Drawing.Point(20, 14)
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
        Me.btnRunCreditNote.Location = New System.Drawing.Point(368, 14)
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
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(532, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar7
        '
        Me.Bar7.AntiAlias = True
        Me.Bar7.BackColor = System.Drawing.Color.Transparent
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar7.IsMaximized = False
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewCreditNote, Me.btnEditCreditNote, Me.btnDelete, Me.btnPrint, Me.btnRefreshCreditNotes})
        Me.Bar7.Location = New System.Drawing.Point(1, 1)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(532, 25)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar7.TabIndex = 154
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
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnListingPrint, Me.btnPrintCreditNote})
        Me.btnPrint.Text = "Print"
        '
        'btnListingPrint
        '
        Me.btnListingPrint.BeginGroup = True
        Me.btnListingPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnListingPrint.Name = "btnListingPrint"
        Me.btnListingPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnListingPrint.Text = "Print Listing Summary"
        '
        'btnPrintCreditNote
        '
        Me.btnPrintCreditNote.BeginGroup = True
        Me.btnPrintCreditNote.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintCreditNote.Name = "btnPrintCreditNote"
        Me.btnPrintCreditNote.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintCreditNote.Text = "Print Selected Row"
        '
        'btnRefreshCreditNotes
        '
        Me.btnRefreshCreditNotes.BeginGroup = True
        Me.btnRefreshCreditNotes.Image = CType(resources.GetObject("btnRefreshCreditNotes.Image"), System.Drawing.Image)
        Me.btnRefreshCreditNotes.Name = "btnRefreshCreditNotes"
        Me.btnRefreshCreditNotes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshCreditNotes.Text = "Refresh"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 470)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(533, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 470)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 471)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(534, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(534, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
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
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Text = "Edit"
        '
        'frmCreditNotesListings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(534, 472)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Name = "frmCreditNotesListings"
        Me.Text = "Credit Notes"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.dGridCreditNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCreditNotes As DevComponents.DotNetBar.ButtonItem
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
    Friend WithEvents Bar8 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem13 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem14 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem15 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem16 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem17 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem18 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem19 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridCreditNotes As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
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
    Friend WithEvents btnListingPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintCreditNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
End Class
