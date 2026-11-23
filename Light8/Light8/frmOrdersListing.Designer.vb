<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdersListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdersListing))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNewOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSummaryOrders = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectedOrder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeliveryNote = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshOrders = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.Totals = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalOrders = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.lblDiscounts = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTaxes = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
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
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdOrders = New System.Drawing.Printing.PrintDocument()
        Me.dGridPurchaseOrders = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.dGridPurchaseOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 514)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(887, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(886, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 513)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 513)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewOrder, Me.btnEditOrder, Me.btnPrint, Me.btnDeliveryNote, Me.btnRefreshOrders})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(885, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 152
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
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(885, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Totals, Me.LabelItem4, Me.lblTotalOrders, Me.LabelItem6, Me.lblDiscounts, Me.LabelItem8, Me.lblTaxes})
        Me.Bar4.Location = New System.Drawing.Point(1, 494)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(885, 20)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 154
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
        'KryptonPanel13
        '
        Me.KryptonPanel13.AutoScroll = True
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel13.Controls.Add(Me.dpStartFrom)
        Me.KryptonPanel13.Controls.Add(Me.dpEndTo)
        Me.KryptonPanel13.Controls.Add(Me.btnProcess)
        Me.KryptonPanel13.Controls.Add(Me.KryptonPanel18)
        Me.KryptonPanel13.Controls.Add(Me.KryptonPanel19)
        Me.KryptonPanel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(885, 69)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel13.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel13.TabIndex = 157
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 68)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(885, 1)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'dpStartFrom
        '
        Me.dpStartFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStartFrom.ForeColor = System.Drawing.Color.Black
        Me.dpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFrom.Location = New System.Drawing.Point(57, 21)
        Me.dpStartFrom.Name = "dpStartFrom"
        Me.dpStartFrom.Size = New System.Drawing.Size(113, 20)
        Me.dpStartFrom.TabIndex = 10
        '
        'dpEndTo
        '
        Me.dpEndTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEndTo.ForeColor = System.Drawing.Color.Black
        Me.dpEndTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndTo.Location = New System.Drawing.Point(217, 21)
        Me.dpEndTo.Name = "dpEndTo"
        Me.dpEndTo.Size = New System.Drawing.Size(113, 20)
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
        'pdOrders
        '
        '
        'dGridPurchaseOrders
        '
        Me.dGridPurchaseOrders.AllowUserToAddRows = False
        Me.dGridPurchaseOrders.AllowUserToDeleteRows = False
        Me.dGridPurchaseOrders.AllowUserToResizeRows = False
        Me.dGridPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridPurchaseOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dGridPurchaseOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridPurchaseOrders.Location = New System.Drawing.Point(1, 96)
        Me.dGridPurchaseOrders.Name = "dGridPurchaseOrders"
        Me.dGridPurchaseOrders.ReadOnly = True
        Me.dGridPurchaseOrders.RowHeadersVisible = False
        Me.dGridPurchaseOrders.RowHeadersWidth = 25
        Me.dGridPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPurchaseOrders.Size = New System.Drawing.Size(885, 398)
        Me.dGridPurchaseOrders.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridPurchaseOrders.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridPurchaseOrders.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPurchaseOrders.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridPurchaseOrders.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridPurchaseOrders.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridPurchaseOrders.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridPurchaseOrders.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridPurchaseOrders.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridPurchaseOrders.TabIndex = 164
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Date"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Order #"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 76
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Account #"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 88
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Account Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 110
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Value"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 64
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Buyer"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 65
        '
        'frmOrdersListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(887, 515)
        Me.Controls.Add(Me.dGridPurchaseOrders)
        Me.Controls.Add(Me.KryptonPanel13)
        Me.Controls.Add(Me.Bar4)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Name = "frmOrdersListing"
        Me.Text = "Orders"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        Me.KryptonPanel19.PerformLayout()
        CType(Me.dGridPurchaseOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSummaryOrders As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSelectedOrder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeliveryNote As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshOrders As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents Totals As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalOrders As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblDiscounts As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTaxes As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpStartFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpEndTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnProcess As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents ppd As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdOrders As System.Drawing.Printing.PrintDocument
    Friend WithEvents dGridPurchaseOrders As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
