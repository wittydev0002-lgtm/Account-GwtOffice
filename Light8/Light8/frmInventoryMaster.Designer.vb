<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryMaster))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grd = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCloneItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuChangeItemCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUpdateQuantityBy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZeroQuantity = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopySelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuConvertPackToSingle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BreakPackToSingleItemsInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkAutoHyphen = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboInventoryStatus = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.chkWildCast = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnViewDeletedInventory = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPriceUpdate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnManageCodes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnChangeCodes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnMergeItemCodes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnChangeSerial = New DevComponents.DotNetBar.ButtonItem()
        Me.btnManageCosts = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeactivateOne = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCostSetup = New DevComponents.DotNetBar.ButtonItem()
        Me.btnStockReconciliation = New DevComponents.DotNetBar.ButtonItem()
        Me.btnInventoryTrek = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImport = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportCostPrices = New DevComponents.DotNetBar.ButtonItem()
        Me.btnShortCodes = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintView = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnQuantityFilter = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalSelected = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.pdWindows = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.imageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.cboInventoryStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.grd)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.Bar2)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(897, 437)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 0
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.AllowUserToResizeRows = False
        Me.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grd.ContextMenuStrip = Me.ContextMenuStrip1
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 85)
        Me.grd.Name = "grd"
        Me.grd.ReadOnly = True
        Me.grd.RowHeadersWidth = 25
        Me.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd.Size = New System.Drawing.Size(897, 352)
        Me.grd.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.grd.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.grd.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.grd.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.grd.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.grd.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.grd.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.grd.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.TabIndex = 38
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCloneItem, Me.mnuChangeItemCode, Me.ToolStripMenuItem1, Me.mnuUpdateQuantityBy, Me.mnuZeroQuantity, Me.ToolStripMenuItem4, Me.mnuDeleteSelection, Me.ToolStripMenuItem2, Me.mnuSelectAll, Me.mnuCopySelected, Me.ToolStripMenuItem3, Me.mnuConvertPackToSingle, Me.ToolStripMenuItem5, Me.BreakPackToSingleItemsInventoryToolStripMenuItem, Me.ToolStripMenuItem6})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(266, 238)
        '
        'mnuCloneItem
        '
        Me.mnuCloneItem.Image = CType(resources.GetObject("mnuCloneItem.Image"), System.Drawing.Image)
        Me.mnuCloneItem.Name = "mnuCloneItem"
        Me.mnuCloneItem.Size = New System.Drawing.Size(265, 22)
        Me.mnuCloneItem.Text = "Clone As .. [F3]"
        '
        'mnuChangeItemCode
        '
        Me.mnuChangeItemCode.Image = CType(resources.GetObject("mnuChangeItemCode.Image"), System.Drawing.Image)
        Me.mnuChangeItemCode.Name = "mnuChangeItemCode"
        Me.mnuChangeItemCode.Size = New System.Drawing.Size(265, 22)
        Me.mnuChangeItemCode.Text = "Change Item Code [F4]"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(262, 6)
        '
        'mnuUpdateQuantityBy
        '
        Me.mnuUpdateQuantityBy.Image = CType(resources.GetObject("mnuUpdateQuantityBy.Image"), System.Drawing.Image)
        Me.mnuUpdateQuantityBy.Name = "mnuUpdateQuantityBy"
        Me.mnuUpdateQuantityBy.Size = New System.Drawing.Size(265, 22)
        Me.mnuUpdateQuantityBy.Text = "Update Quantity By ... [F6]"
        '
        'mnuZeroQuantity
        '
        Me.mnuZeroQuantity.Name = "mnuZeroQuantity"
        Me.mnuZeroQuantity.Size = New System.Drawing.Size(265, 22)
        Me.mnuZeroQuantity.Text = "Zero Quantity"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(262, 6)
        '
        'mnuDeleteSelection
        '
        Me.mnuDeleteSelection.Image = CType(resources.GetObject("mnuDeleteSelection.Image"), System.Drawing.Image)
        Me.mnuDeleteSelection.Name = "mnuDeleteSelection"
        Me.mnuDeleteSelection.Size = New System.Drawing.Size(265, 22)
        Me.mnuDeleteSelection.Text = "Delete Selection [F10]"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(262, 6)
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(265, 22)
        Me.mnuSelectAll.Text = "Select All"
        '
        'mnuCopySelected
        '
        Me.mnuCopySelected.Name = "mnuCopySelected"
        Me.mnuCopySelected.Size = New System.Drawing.Size(265, 22)
        Me.mnuCopySelected.Text = "Copy Selection"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(262, 6)
        '
        'mnuConvertPackToSingle
        '
        Me.mnuConvertPackToSingle.Name = "mnuConvertPackToSingle"
        Me.mnuConvertPackToSingle.Size = New System.Drawing.Size(265, 22)
        Me.mnuConvertPackToSingle.Text = "Convert Pack Quantity to Single"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(262, 6)
        '
        'BreakPackToSingleItemsInventoryToolStripMenuItem
        '
        Me.BreakPackToSingleItemsInventoryToolStripMenuItem.Name = "BreakPackToSingleItemsInventoryToolStripMenuItem"
        Me.BreakPackToSingleItemsInventoryToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.BreakPackToSingleItemsInventoryToolStripMenuItem.Text = "Break Pack to Single Items Inventory"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(262, 6)
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.chkAutoHyphen)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel3.Controls.Add(Me.cboInventoryStatus)
        Me.KryptonPanel3.Controls.Add(Me.chkWildCast)
        Me.KryptonPanel3.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel3.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 30)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(897, 55)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.TabIndex = 35
        '
        'chkAutoHyphen
        '
        Me.chkAutoHyphen.Checked = True
        Me.chkAutoHyphen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoHyphen.Location = New System.Drawing.Point(408, 20)
        Me.chkAutoHyphen.Name = "chkAutoHyphen"
        Me.chkAutoHyphen.Size = New System.Drawing.Size(96, 20)
        Me.chkAutoHyphen.TabIndex = 25
        Me.chkAutoHyphen.Values.Text = "Auto Hyphen"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 54)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel4.Location = New System.Drawing.Point(546, 15)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(104, 25)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 24
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(104, 24)
        Me.KryptonLabel1.TabIndex = 18
        Me.KryptonLabel1.Values.Text = "Filter by status"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 24)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(104, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'cboInventoryStatus
        '
        Me.cboInventoryStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInventoryStatus.DropDownWidth = 163
        Me.cboInventoryStatus.Items.AddRange(New Object() {"ACTIVE", "INACTIVE", "ALL"})
        Me.cboInventoryStatus.Location = New System.Drawing.Point(652, 19)
        Me.cboInventoryStatus.Name = "cboInventoryStatus"
        Me.cboInventoryStatus.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboInventoryStatus.Size = New System.Drawing.Size(119, 21)
        Me.cboInventoryStatus.TabIndex = 23
        '
        'chkWildCast
        '
        Me.chkWildCast.Checked = True
        Me.chkWildCast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWildCast.Location = New System.Drawing.Point(283, 20)
        Me.chkWildCast.Name = "chkWildCast"
        Me.chkWildCast.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.chkWildCast.Size = New System.Drawing.Size(115, 20)
        Me.chkWildCast.TabIndex = 22
        Me.chkWildCast.Values.Text = "Wild Cast Search"
        '
        'txtSearchString
        '
        Me.txtSearchString.Location = New System.Drawing.Point(113, 20)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(160, 23)
        Me.txtSearchString.TabIndex = 20
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.Items.AddRange(New Object() {"Item Code", "Description", "Category", "Sub Category"})
        Me.cboSearchBy.Location = New System.Drawing.Point(12, 19)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchBy.Size = New System.Drawing.Size(98, 21)
        Me.cboSearchBy.TabIndex = 21
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 29)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnViewDeletedInventory, Me.btnPriceUpdate, Me.btnManageCodes, Me.btnInventoryTrek, Me.btnImport, Me.ButtonItem1, Me.btnShortCodes, Me.btnPrint, Me.btnQuantityFilter, Me.btnRefresh, Me.LabelItem4, Me.lblTotalSelected})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 3
        Me.Bar2.PaddingLeft = 3
        Me.Bar2.PaddingRight = 3
        Me.Bar2.PaddingTop = 3
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(897, 29)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 32
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNew.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Text = "Delete"
        '
        'btnViewDeletedInventory
        '
        Me.btnViewDeletedInventory.BeginGroup = True
        Me.btnViewDeletedInventory.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnViewDeletedInventory.Image = CType(resources.GetObject("btnViewDeletedInventory.Image"), System.Drawing.Image)
        Me.btnViewDeletedInventory.Name = "btnViewDeletedInventory"
        Me.btnViewDeletedInventory.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnViewDeletedInventory.Tooltip = "View Deleted Items"
        '
        'btnPriceUpdate
        '
        Me.btnPriceUpdate.BeginGroup = True
        Me.btnPriceUpdate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPriceUpdate.Image = CType(resources.GetObject("btnPriceUpdate.Image"), System.Drawing.Image)
        Me.btnPriceUpdate.Name = "btnPriceUpdate"
        Me.btnPriceUpdate.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPriceUpdate.Text = "Price Update"
        '
        'btnManageCodes
        '
        Me.btnManageCodes.BeginGroup = True
        Me.btnManageCodes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnManageCodes.Image = CType(resources.GetObject("btnManageCodes.Image"), System.Drawing.Image)
        Me.btnManageCodes.Name = "btnManageCodes"
        Me.btnManageCodes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnManageCodes.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnChangeCodes, Me.btnMergeItemCodes, Me.btnChangeSerial, Me.btnManageCosts, Me.btnDeactivateOne, Me.btnCostSetup, Me.btnStockReconciliation})
        Me.btnManageCodes.Text = "Manage"
        '
        'btnChangeCodes
        '
        Me.btnChangeCodes.Name = "btnChangeCodes"
        Me.btnChangeCodes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnChangeCodes.Text = "Change Inventory Code"
        '
        'btnMergeItemCodes
        '
        Me.btnMergeItemCodes.Name = "btnMergeItemCodes"
        Me.btnMergeItemCodes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnMergeItemCodes.Text = "Merge Codes"
        '
        'btnChangeSerial
        '
        Me.btnChangeSerial.BeginGroup = True
        Me.btnChangeSerial.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnChangeSerial.Name = "btnChangeSerial"
        Me.btnChangeSerial.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnChangeSerial.Text = "Change Seial Number"
        '
        'btnManageCosts
        '
        Me.btnManageCosts.BeginGroup = True
        Me.btnManageCosts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnManageCosts.Name = "btnManageCosts"
        Me.btnManageCosts.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnManageCosts.Text = "Mass Change Prices"
        '
        'btnDeactivateOne
        '
        Me.btnDeactivateOne.BeginGroup = True
        Me.btnDeactivateOne.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDeactivateOne.Image = CType(resources.GetObject("btnDeactivateOne.Image"), System.Drawing.Image)
        Me.btnDeactivateOne.Name = "btnDeactivateOne"
        Me.btnDeactivateOne.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeactivateOne.Text = "De-activate Selected"
        Me.btnDeactivateOne.Tooltip = "Archive Inventory Item"
        '
        'btnCostSetup
        '
        Me.btnCostSetup.BeginGroup = True
        Me.btnCostSetup.Name = "btnCostSetup"
        Me.btnCostSetup.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCostSetup.Text = "Inventory Cost Setups"
        '
        'btnStockReconciliation
        '
        Me.btnStockReconciliation.Name = "btnStockReconciliation"
        Me.btnStockReconciliation.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnStockReconciliation.Text = "Stock Take Reconciliation"
        '
        'btnInventoryTrek
        '
        Me.btnInventoryTrek.BeginGroup = True
        Me.btnInventoryTrek.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnInventoryTrek.Image = CType(resources.GetObject("btnInventoryTrek.Image"), System.Drawing.Image)
        Me.btnInventoryTrek.Name = "btnInventoryTrek"
        Me.btnInventoryTrek.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnInventoryTrek.Text = "Trekking"
        '
        'btnImport
        '
        Me.btnImport.BeginGroup = True
        Me.btnImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImport.Tooltip = "Import Inventory Items"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnExport, Me.btnExportCostPrices})
        Me.ButtonItem1.Text = "Export"
        '
        'btnExport
        '
        Me.btnExport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExport.Symbol = ""
        Me.btnExport.Text = "Export All"
        '
        'btnExportCostPrices
        '
        Me.btnExportCostPrices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportCostPrices.Name = "btnExportCostPrices"
        Me.btnExportCostPrices.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportCostPrices.Symbol = ""
        Me.btnExportCostPrices.Text = "Export Costs"
        '
        'btnShortCodes
        '
        Me.btnShortCodes.BeginGroup = True
        Me.btnShortCodes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnShortCodes.Image = CType(resources.GetObject("btnShortCodes.Image"), System.Drawing.Image)
        Me.btnShortCodes.Name = "btnShortCodes"
        Me.btnShortCodes.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnShortCodes.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnShortCodes.Text = "Short Codes"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintView, Me.ButtonItem3})
        Me.btnPrint.Text = "Print"
        '
        'btnPrintView
        '
        Me.btnPrintView.Name = "btnPrintView"
        Me.btnPrintView.Text = "Print Listing"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Print Daily Movements-Specific"
        '
        'btnQuantityFilter
        '
        Me.btnQuantityFilter.BeginGroup = True
        Me.btnQuantityFilter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuantityFilter.Image = CType(resources.GetObject("btnQuantityFilter.Image"), System.Drawing.Image)
        Me.btnQuantityFilter.Name = "btnQuantityFilter"
        Me.btnQuantityFilter.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnQuantityFilter.Text = "Quantity Filter"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnRefresh.Tooltip = "Refresh View"
        '
        'LabelItem4
        '
        Me.LabelItem4.BeginGroup = True
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 12
        Me.LabelItem4.PaddingRight = 6
        Me.LabelItem4.Stretch = True
        Me.LabelItem4.Text = "Total records selected"
        Me.LabelItem4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblTotalSelected
        '
        Me.lblTotalSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalSelected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSelected.ForeColor = System.Drawing.Color.White
        Me.lblTotalSelected.Name = "lblTotalSelected"
        Me.lblTotalSelected.Text = "0"
        Me.lblTotalSelected.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblTotalSelected.Width = 50
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
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
        'imageList3
        '
        Me.imageList3.ImageStream = CType(resources.GetObject("imageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList3.Images.SetKeyName(0, "Folder.ico")
        Me.imageList3.Images.SetKeyName(1, "calendar.png")
        Me.imageList3.Images.SetKeyName(2, "user2.png")
        Me.imageList3.Images.SetKeyName(3, "dude1.png")
        Me.imageList3.Images.SetKeyName(4, "businessman2.png")
        Me.imageList3.Images.SetKeyName(5, "TableSmall.png")
        Me.imageList3.Images.SetKeyName(6, "Delivery.png")
        Me.imageList3.Images.SetKeyName(7, "Money.png")
        Me.imageList3.Images.SetKeyName(8, "49.png")
        Me.imageList3.Images.SetKeyName(9, "07.png")
        Me.imageList3.Images.SetKeyName(10, "10.png")
        Me.imageList3.Images.SetKeyName(11, "25.png")
        Me.imageList3.Images.SetKeyName(12, "133.png")
        Me.imageList3.Images.SetKeyName(13, "Search.bmp")
        Me.imageList3.Images.SetKeyName(14, "420.png")
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(897, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(896, 1)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 436)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 436)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'frmInventoryMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 437)
        Me.Controls.Add(Me.KryptonBorderEdge6)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "frmInventoryMaster"
        Me.Text = "Inventory"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.cboInventoryStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnViewDeletedInventory As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnManageCodes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnChangeCodes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnMergeItemCodes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnChangeSerial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnManageCosts As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnInventoryTrek As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportCostPrices As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnShortCodes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnQuantityFilter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalSelected As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkAutoHyphen As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboInventoryStatus As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents chkWildCast As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCloneItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuChangeItemCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUpdateQuantityBy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZeroQuantity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeleteSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopySelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuConvertPackToSingle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pdWindows As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Private WithEvents imageList3 As System.Windows.Forms.ImageList
    Private WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents grd As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnDeactivateOne As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCostSetup As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnStockReconciliation As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPriceUpdate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents BreakPackToSingleItemsInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPrintView As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
End Class
