<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryTransfers
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryTransfers))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBranches = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboItems = New MTGCComboBox()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtBarcode = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtBatchNo = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtQuantity = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.chkFromStock = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnSerialNumbers = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.lblSubCategory = New System.Windows.Forms.Label()
        Me.txtSerialNumbers = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.Bar5 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.lblQuantityInStock = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.lblCostValue = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.lblSalesValue = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar4 = New DevComponents.DotNetBar.Bar()
        Me.btnRemoveItem = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRecallBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBulkItems = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBulkItemsByBranch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFinishSale = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFile = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintPass = New DevComponents.DotNetBar.ButtonItem()
        Me.btnInternalMovements = New DevComponents.DotNetBar.ButtonItem()
        Me.btnStoresToSales = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSalesToStores = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshItems = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.pdWindows = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.cboBranches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.dGrid)
        Me.KryptonPanel.Controls.Add(Me.KryptonHeader1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel.Controls.Add(Me.Bar5)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.Bar4)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(988, 469)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 0
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewImageColumn2, Me.Column11})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 272)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(988, 172)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 37
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 97
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Serial Numbers"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 124
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn8.HeaderText = ""
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn9.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 84
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn10.HeaderText = "Category"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn11.HeaderText = "SubCategory"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn12.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn13.HeaderText = "Sale Price"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = CType(resources.GetObject("DataGridViewImageColumn2.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn2.MinimumWidth = 25
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Width = 25
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column11.HeaderText = "Full Serial No"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 111
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonHeader1.Location = New System.Drawing.Point(0, 241)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(988, 31)
        Me.KryptonHeader1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonHeader1.StateCommon.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonHeader1.TabIndex = 36
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = "Pending transfers"
        Me.KryptonHeader1.Values.Image = Nothing
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 444)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(988, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.AutoScroll = True
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel5.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 26)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(988, 215)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel5.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel5.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel5.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel5.TabIndex = 34
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(15, 14)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel10)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dpTransDate)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.cboBranches)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.cboItems)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel9)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel11)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.txtBarcode)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel12)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel13)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.txtBatchNo)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonPanel14)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.btnSearch)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.txtQuantity)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.chkFromStock)
        Me.KryptonGroupBox2.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(499, 186)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 166
        Me.KryptonGroupBox2.Text = "Transaction"
        Me.KryptonGroupBox2.Values.Heading = "Transaction"
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel10.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(8, 106)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(111, 20)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 169
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(111, 1)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(111, 20)
        Me.KryptonLabel5.TabIndex = 0
        Me.KryptonLabel5.Values.Text = "Receiving branch"
        '
        'dpTransDate
        '
        Me.dpTransDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpTransDate.ForeColor = System.Drawing.Color.Black
        Me.dpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpTransDate.Location = New System.Drawing.Point(120, 13)
        Me.dpTransDate.Name = "dpTransDate"
        Me.dpTransDate.Size = New System.Drawing.Size(104, 20)
        Me.dpTransDate.TabIndex = 142
        '
        'cboBranches
        '
        Me.cboBranches.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranches.DropDownWidth = 367
        Me.cboBranches.ForeColor = System.Drawing.Color.Black
        Me.cboBranches.Location = New System.Drawing.Point(120, 105)
        Me.cboBranches.Name = "cboBranches"
        Me.cboBranches.Size = New System.Drawing.Size(367, 21)
        Me.cboBranches.TabIndex = 168
        '
        'cboItems
        '
        Me.cboItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.ArrowColor = System.Drawing.Color.Black
        Me.cboItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboItems.BindedControl = Nothing
        Me.cboItems.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboItems.ColumnNum = 1
        Me.cboItems.ColumnWidth = "121"
        Me.cboItems.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboItems.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboItems.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboItems.DisplayMember = "Text"
        Me.cboItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboItems.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboItems.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboItems.DropDownForeColor = System.Drawing.Color.Black
        Me.cboItems.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboItems.DropDownWidth = 141
        Me.cboItems.ForeColor = System.Drawing.Color.Black
        Me.cboItems.GridLineColor = System.Drawing.Color.LightGray
        Me.cboItems.GridLineHorizontal = False
        Me.cboItems.GridLineVertical = False
        Me.cboItems.HighlightBorderColor = System.Drawing.Color.DarkGray
        Me.cboItems.HighlightBorderOnMouseEvents = True
        Me.cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboItems.Location = New System.Drawing.Point(120, 36)
        Me.cboItems.ManagingFastMouseMoving = True
        Me.cboItems.ManagingFastMouseMovingInterval = 30
        Me.cboItems.Name = "cboItems"
        Me.cboItems.NormalBorderColor = System.Drawing.Color.DarkGray
        Me.cboItems.SelectedItem = Nothing
        Me.cboItems.SelectedValue = Nothing
        Me.cboItems.Size = New System.Drawing.Size(346, 21)
        Me.cboItems.Sorted = True
        Me.cboItems.TabIndex = 143
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(8, 13)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(111, 20)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 147
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(111, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(111, 20)
        Me.KryptonLabel6.TabIndex = 0
        Me.KryptonLabel6.Values.Text = "Date"
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(8, 36)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(111, 20)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 148
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(111, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(111, 20)
        Me.KryptonLabel7.TabIndex = 0
        Me.KryptonLabel7.Values.Text = "Item Code"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.Location = New System.Drawing.Point(120, 59)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(367, 20)
        Me.txtBarcode.TabIndex = 145
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel12.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(198, 81)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(68, 20)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel12.TabIndex = 155
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(68, 1)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(68, 20)
        Me.KryptonLabel8.TabIndex = 0
        Me.KryptonLabel8.Values.Text = "Batch No."
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(8, 59)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(111, 20)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 150
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(111, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(111, 20)
        Me.KryptonLabel9.TabIndex = 0
        Me.KryptonLabel9.Values.Text = "Barcode"
        '
        'txtBatchNo
        '
        Me.txtBatchNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtBatchNo.Enabled = False
        Me.txtBatchNo.ForeColor = System.Drawing.Color.Black
        Me.txtBatchNo.Location = New System.Drawing.Point(267, 81)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.Size = New System.Drawing.Size(59, 20)
        Me.txtBatchNo.TabIndex = 119
        Me.txtBatchNo.Text = "0"
        Me.txtBatchNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge19)
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel14.Location = New System.Drawing.Point(8, 81)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(111, 20)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 149
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(111, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(111, 20)
        Me.KryptonLabel10.TabIndex = 0
        Me.KryptonLabel10.Values.Text = "Quantity"
        '
        'btnSearch
        '
        Me.btnSearch.AutoSize = True
        Me.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(468, 36)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(20, 20)
        Me.btnSearch.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnSearch.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSearch.StateCommon.Back.ColorAngle = 100.0!
        Me.btnSearch.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSearch.StateCommon.Border.Rounding = 0
        Me.btnSearch.TabIndex = 153
        Me.btnSearch.Values.Image = CType(resources.GetObject("btnSearch.Values.Image"), System.Drawing.Image)
        Me.btnSearch.Values.Text = ""
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtQuantity.Location = New System.Drawing.Point(120, 81)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(74, 20)
        Me.txtQuantity.TabIndex = 146
        Me.txtQuantity.Text = "1"
        '
        'chkFromStock
        '
        Me.chkFromStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkFromStock.Checked = True
        Me.chkFromStock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFromStock.ForeColor = System.Drawing.Color.Black
        Me.chkFromStock.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkFromStock.Location = New System.Drawing.Point(123, 131)
        Me.chkFromStock.Name = "chkFromStock"
        Me.chkFromStock.Size = New System.Drawing.Size(207, 20)
        Me.chkFromStock.TabIndex = 151
        Me.chkFromStock.Text = "Transfer from branch stock? (Y/N)"
        Me.chkFromStock.Values.Text = "Transfer from branch stock? (Y/N)"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(520, 14)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnSerialNumbers)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDescription)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblPrice)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblItemType)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblSubCategory)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtSerialNumbers)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblCategory)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(273, 186)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 163
        Me.KryptonGroupBox1.Text = "Item Details"
        Me.KryptonGroupBox1.Values.Heading = "Item Details"
        '
        'btnSerialNumbers
        '
        Me.btnSerialNumbers.AutoSize = True
        Me.btnSerialNumbers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSerialNumbers.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnSerialNumbers.ForeColor = System.Drawing.Color.Black
        Me.btnSerialNumbers.Location = New System.Drawing.Point(143, 101)
        Me.btnSerialNumbers.Name = "btnSerialNumbers"
        Me.btnSerialNumbers.Size = New System.Drawing.Size(58, 22)
        Me.btnSerialNumbers.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnSerialNumbers.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSerialNumbers.StateCommon.Back.ColorAngle = 100.0!
        Me.btnSerialNumbers.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSerialNumbers.StateCommon.Border.Rounding = 0
        Me.btnSerialNumbers.TabIndex = 163
        Me.btnSerialNumbers.Values.Text = "Ser&ial No"
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.Location = New System.Drawing.Point(10, 13)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(249, 21)
        Me.lblDescription.TabIndex = 157
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrice
        '
        Me.lblPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.ForeColor = System.Drawing.Color.Black
        Me.lblPrice.Location = New System.Drawing.Point(10, 101)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(129, 21)
        Me.lblPrice.TabIndex = 162
        Me.lblPrice.Text = "0.00"
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblItemType
        '
        Me.lblItemType.BackColor = System.Drawing.Color.Transparent
        Me.lblItemType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemType.ForeColor = System.Drawing.Color.Black
        Me.lblItemType.Location = New System.Drawing.Point(10, 35)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(90, 21)
        Me.lblItemType.TabIndex = 158
        Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubCategory
        '
        Me.lblSubCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblSubCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubCategory.ForeColor = System.Drawing.Color.Black
        Me.lblSubCategory.Location = New System.Drawing.Point(10, 79)
        Me.lblSubCategory.Name = "lblSubCategory"
        Me.lblSubCategory.Size = New System.Drawing.Size(249, 21)
        Me.lblSubCategory.TabIndex = 161
        Me.lblSubCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumbers
        '
        Me.txtSerialNumbers.BackColor = System.Drawing.Color.Transparent
        Me.txtSerialNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumbers.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumbers.ForeColor = System.Drawing.Color.Black
        Me.txtSerialNumbers.Location = New System.Drawing.Point(101, 35)
        Me.txtSerialNumbers.Name = "txtSerialNumbers"
        Me.txtSerialNumbers.Size = New System.Drawing.Size(158, 21)
        Me.txtSerialNumbers.TabIndex = 159
        Me.txtSerialNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.Black
        Me.lblCategory.Location = New System.Drawing.Point(10, 57)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(249, 21)
        Me.lblCategory.TabIndex = 160
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bar5
        '
        Me.Bar5.AntiAlias = True
        Me.Bar5.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar5.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar5.IsMaximized = False
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.lblQuantityInStock, Me.LabelItem5, Me.lblCostValue, Me.LabelItem7, Me.lblSalesValue})
        Me.Bar5.Location = New System.Drawing.Point(0, 445)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.PaddingBottom = 3
        Me.Bar5.PaddingLeft = 3
        Me.Bar5.PaddingRight = 3
        Me.Bar5.PaddingTop = 3
        Me.Bar5.Size = New System.Drawing.Size(988, 24)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar5.TabIndex = 10
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'LabelItem3
        '
        Me.LabelItem3.ForeColor = System.Drawing.Color.Black
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingLeft = 3
        Me.LabelItem3.PaddingRight = 3
        Me.LabelItem3.Text = "Current quantity in stock"
        '
        'lblQuantityInStock
        '
        Me.lblQuantityInStock.ForeColor = System.Drawing.Color.Black
        Me.lblQuantityInStock.Name = "lblQuantityInStock"
        Me.lblQuantityInStock.PaddingLeft = 3
        Me.lblQuantityInStock.PaddingRight = 3
        Me.lblQuantityInStock.Text = "0.00"
        '
        'LabelItem5
        '
        Me.LabelItem5.ForeColor = System.Drawing.Color.Black
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingLeft = 3
        Me.LabelItem5.PaddingRight = 3
        Me.LabelItem5.Text = "Cost Value"
        '
        'lblCostValue
        '
        Me.lblCostValue.ForeColor = System.Drawing.Color.Black
        Me.lblCostValue.Name = "lblCostValue"
        Me.lblCostValue.PaddingLeft = 3
        Me.lblCostValue.PaddingRight = 3
        Me.lblCostValue.Text = "0.00"
        '
        'LabelItem7
        '
        Me.LabelItem7.ForeColor = System.Drawing.Color.Black
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.PaddingLeft = 3
        Me.LabelItem7.PaddingRight = 3
        Me.LabelItem7.Text = "Sale Value"
        '
        'lblSalesValue
        '
        Me.lblSalesValue.ForeColor = System.Drawing.Color.Black
        Me.lblSalesValue.Name = "lblSalesValue"
        Me.lblSalesValue.PaddingLeft = 3
        Me.lblSalesValue.PaddingRight = 3
        Me.lblSalesValue.Text = "0.00"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(988, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar4
        '
        Me.Bar4.AntiAlias = True
        Me.Bar4.BackColor = System.Drawing.Color.Transparent
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar4.IsMaximized = False
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnRemoveItem, Me.btnRecallBatch, Me.btnAdd, Me.btnBulkItems, Me.btnBulkItemsByBranch, Me.btnFinishSale, Me.btnFile, Me.btnPrintPass, Me.btnInternalMovements, Me.btnRefreshItems})
        Me.Bar4.Location = New System.Drawing.Point(0, 0)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.RoundCorners = False
        Me.Bar4.Size = New System.Drawing.Size(988, 25)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar4.TabIndex = 8
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRemoveItem.Image = CType(resources.GetObject("btnRemoveItem.Image"), System.Drawing.Image)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnRecallBatch
        '
        Me.btnRecallBatch.BeginGroup = True
        Me.btnRecallBatch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRecallBatch.Image = CType(resources.GetObject("btnRecallBatch.Image"), System.Drawing.Image)
        Me.btnRecallBatch.Name = "btnRecallBatch"
        Me.btnRecallBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRecallBatch.Text = "Recall Batch"
        '
        'btnAdd
        '
        Me.btnAdd.BeginGroup = True
        Me.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnBulkItems
        '
        Me.btnBulkItems.BeginGroup = True
        Me.btnBulkItems.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBulkItems.Image = CType(resources.GetObject("btnBulkItems.Image"), System.Drawing.Image)
        Me.btnBulkItems.Name = "btnBulkItems"
        Me.btnBulkItems.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBulkItems.Text = "Bulk Items"
        '
        'btnBulkItemsByBranch
        '
        Me.btnBulkItemsByBranch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBulkItemsByBranch.Image = CType(resources.GetObject("btnBulkItemsByBranch.Image"), System.Drawing.Image)
        Me.btnBulkItemsByBranch.Name = "btnBulkItemsByBranch"
        Me.btnBulkItemsByBranch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBulkItemsByBranch.Text = "Branch Items"
        '
        'btnFinishSale
        '
        Me.btnFinishSale.BeginGroup = True
        Me.btnFinishSale.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFinishSale.Image = CType(resources.GetObject("btnFinishSale.Image"), System.Drawing.Image)
        Me.btnFinishSale.Name = "btnFinishSale"
        Me.btnFinishSale.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnFinishSale.Text = "Transfer"
        '
        'btnFile
        '
        Me.btnFile.BeginGroup = True
        Me.btnFile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFile.Image = CType(resources.GetObject("btnFile.Image"), System.Drawing.Image)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnFile.Text = "Export"
        '
        'btnPrintPass
        '
        Me.btnPrintPass.BeginGroup = True
        Me.btnPrintPass.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintPass.Image = CType(resources.GetObject("btnPrintPass.Image"), System.Drawing.Image)
        Me.btnPrintPass.Name = "btnPrintPass"
        Me.btnPrintPass.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'btnInternalMovements
        '
        Me.btnInternalMovements.BeginGroup = True
        Me.btnInternalMovements.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnInternalMovements.Image = CType(resources.GetObject("btnInternalMovements.Image"), System.Drawing.Image)
        Me.btnInternalMovements.Name = "btnInternalMovements"
        Me.btnInternalMovements.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnInternalMovements.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnStoresToSales, Me.btnSalesToStores})
        Me.btnInternalMovements.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnInternalMovements.Text = "Movements"
        '
        'btnStoresToSales
        '
        Me.btnStoresToSales.BeginGroup = True
        Me.btnStoresToSales.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnStoresToSales.Name = "btnStoresToSales"
        Me.btnStoresToSales.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnStoresToSales.Text = "Stores-to-Sales"
        '
        'btnSalesToStores
        '
        Me.btnSalesToStores.BeginGroup = True
        Me.btnSalesToStores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalesToStores.Name = "btnSalesToStores"
        Me.btnSalesToStores.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSalesToStores.Text = "Sales-to-Stores"
        '
        'btnRefreshItems
        '
        Me.btnRefreshItems.BeginGroup = True
        Me.btnRefreshItems.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefreshItems.Image = CType(resources.GetObject("btnRefreshItems.Image"), System.Drawing.Image)
        Me.btnRefreshItems.Name = "btnRefreshItems"
        Me.btnRefreshItems.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'pdWindows
        '
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
        'frmInventoryTransfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 469)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "frmInventoryTransfers"
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.Text = "Transfers"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        Me.KryptonGroupBox2.Panel.PerformLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.cboBranches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnRemoveItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRecallBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBulkItems As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBulkItemsByBranch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFinishSale As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFile As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintPass As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnInternalMovements As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnStoresToSales As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalesToStores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshItems As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblQuantityInStock As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCostValue As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblSalesValue As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboBranches As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboItems As MTGCComboBox
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtBarcode As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtBatchNo As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtQuantity As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents chkFromStock As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnSerialNumbers As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblItemType As System.Windows.Forms.Label
    Friend WithEvents lblSubCategory As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumbers As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents pdWindows As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
