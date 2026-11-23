<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaschCustomersListing
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCloneItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopySelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFindMatching = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.cboSearchBy = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.txtSearchString = New DevComponents.DotNetBar.TextBoxItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAccountDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportData = New DevComponents.DotNetBar.ButtonItem()
        Me.btnArchive = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBalances = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.tooltipDisplayDelay = New System.Windows.Forms.Timer(Me.components)
        Me.superTooltipWithLink = New DevComponents.DotNetBar.SuperTooltip()
        Me.btnImportFarmers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportPayments = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCloneItem, Me.ToolStripMenuItem1, Me.mnuDeleteSelection, Me.ToolStripMenuItem2, Me.mnuSelectAll, Me.mnuCopySelected, Me.ToolStripMenuItem3, Me.mnuFindMatching})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(210, 132)
        '
        'mnuCloneItem
        '
        Me.mnuCloneItem.Name = "mnuCloneItem"
        Me.mnuCloneItem.Size = New System.Drawing.Size(209, 22)
        Me.mnuCloneItem.Text = "Clone"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(206, 6)
        '
        'mnuDeleteSelection
        '
        Me.mnuDeleteSelection.Name = "mnuDeleteSelection"
        Me.mnuDeleteSelection.Size = New System.Drawing.Size(209, 22)
        Me.mnuDeleteSelection.Text = "Delete Selection"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(206, 6)
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(209, 22)
        Me.mnuSelectAll.Text = "Select All"
        '
        'mnuCopySelected
        '
        Me.mnuCopySelected.Name = "mnuCopySelected"
        Me.mnuCopySelected.Size = New System.Drawing.Size(209, 22)
        Me.mnuCopySelected.Text = "Copy Selection"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(206, 6)
        '
        'mnuFindMatching
        '
        Me.mnuFindMatching.Name = "mnuFindMatching"
        Me.mnuFindMatching.Size = New System.Drawing.Size(209, 22)
        Me.mnuFindMatching.Text = "Find Matching Item Code"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.dGrid)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel5.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel5.Controls.Add(Me.Bar2)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(905, 501)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.KryptonPanel5.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel5.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel5.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel5.TabIndex = 1
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dGrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dGrid.DefaultCellStyle = DataGridViewCellStyle8
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dGrid.Location = New System.Drawing.Point(1, 104)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dGrid.RowHeadersWidth = 25
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dGrid.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(903, 396)
        Me.dGrid.TabIndex = 55
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Account #"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 90
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Last Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 92
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "First Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 93
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Other Names"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 107
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Farm Name"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 97
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Province"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 81
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "District"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 72
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(1, 103)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(903, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(1, 50)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Padding = New System.Windows.Forms.Padding(8)
        Me.KryptonPanel3.Size = New System.Drawing.Size(903, 53)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel3.TabIndex = 48
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(8, 8)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.KryptonPanel1.Size = New System.Drawing.Size(887, 37)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel1.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.cboSearchBy, Me.txtSearchString})
        Me.Bar1.Location = New System.Drawing.Point(3, 5)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(881, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Search filter  "
        '
        'cboSearchBy
        '
        Me.cboSearchBy.ComboWidth = 250
        Me.cboSearchBy.DropDownHeight = 106
        Me.cboSearchBy.ItemHeight = 17
        Me.cboSearchBy.Items.AddRange(New Object() {Me.ComboItem3, Me.ComboItem4})
        Me.cboSearchBy.Name = "cboSearchBy"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Account Name"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Account Number"
        '
        'txtSearchString
        '
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Stretch = True
        Me.txtSearchString.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnExport, Me.btnImportData, Me.btnArchive, Me.btnPrint, Me.btnBalances, Me.btnRefresh})
        Me.Bar2.Location = New System.Drawing.Point(1, 1)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 2
        Me.Bar2.PaddingLeft = 2
        Me.Bar2.PaddingRight = 2
        Me.Bar2.PaddingTop = 2
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(903, 49)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 46
        Me.Bar2.TabStop = False
        '
        'btnNew
        '
        Me.btnNew.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnNew.ForeColor = System.Drawing.Color.White
        Me.btnNew.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnNew, New DevComponents.DotNetBar.SuperTooltipInfo("Add", "", "Create a new inventory item", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnNew.Symbol = ""
        Me.btnNew.SymbolColor = System.Drawing.Color.White
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnEdit, New DevComponents.DotNetBar.SuperTooltipInfo("Edit", "", "Modify an existing inventory item", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnEdit.Symbol = ""
        Me.btnEdit.SymbolColor = System.Drawing.Color.White
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnDelete, New DevComponents.DotNetBar.SuperTooltipInfo("Delete", "", "Delete an inventory item together with all its linked assembly components", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnDelete.Symbol = ""
        Me.btnDelete.SymbolColor = System.Drawing.Color.White
        Me.btnDelete.Text = "Delete"
        '
        'btnExport
        '
        Me.btnExport.BeginGroup = True
        Me.btnExport.FixedSize = New System.Drawing.Size(60, 44)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExport.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAccountDetails})
        Me.SuperTooltip1.SetSuperTooltip(Me.btnExport, New DevComponents.DotNetBar.SuperTooltipInfo("Export Data", "", "Export specific inventory data to a flat file for further usage", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnExport.Symbol = ""
        Me.btnExport.SymbolColor = System.Drawing.Color.White
        Me.btnExport.Text = "Export"
        '
        'btnAccountDetails
        '
        Me.btnAccountDetails.Name = "btnAccountDetails"
        Me.btnAccountDetails.Text = "Account Details"
        '
        'btnImportData
        '
        Me.btnImportData.FixedSize = New System.Drawing.Size(60, 44)
        Me.btnImportData.ForeColor = System.Drawing.Color.White
        Me.btnImportData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnImportData.Name = "btnImportData"
        Me.btnImportData.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImportData.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnImportFarmers, Me.btnImportPayments})
        Me.SuperTooltip1.SetSuperTooltip(Me.btnImportData, New DevComponents.DotNetBar.SuperTooltipInfo("Export Data", "", "Export specific inventory data to a flat file for further usage", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnImportData.Symbol = ""
        Me.btnImportData.SymbolColor = System.Drawing.Color.White
        Me.btnImportData.Text = "Import"
        '
        'btnArchive
        '
        Me.btnArchive.BeginGroup = True
        Me.btnArchive.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnArchive.ForeColor = System.Drawing.Color.White
        Me.btnArchive.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnArchive, New DevComponents.DotNetBar.SuperTooltipInfo("Archive Items", "", "Transfer all inventory data not being used to a specified file", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnArchive.Symbol = ""
        Me.btnArchive.SymbolColor = System.Drawing.Color.White
        Me.btnArchive.Text = "Archive"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnPrint, New DevComponents.DotNetBar.SuperTooltipInfo("Print Data", "", "Print inventory data for all or selected items", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnPrint.Symbol = ""
        Me.btnPrint.SymbolColor = System.Drawing.Color.White
        Me.btnPrint.Text = "Print"
        '
        'btnBalances
        '
        Me.btnBalances.FixedSize = New System.Drawing.Size(54, 44)
        Me.btnBalances.ForeColor = System.Drawing.Color.White
        Me.btnBalances.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnBalances.Name = "btnBalances"
        Me.btnBalances.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnBalances, New DevComponents.DotNetBar.SuperTooltipInfo("Print Data", "", "Print inventory data for all or selected items", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnBalances.Symbol = ""
        Me.btnBalances.SymbolColor = System.Drawing.Color.White
        Me.btnBalances.Text = "Balances"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.SuperTooltip1.SetSuperTooltip(Me.btnRefresh, New DevComponents.DotNetBar.SuperTooltipInfo("Refresh", "", "Refreshes inventory list to its default state", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver, True, False, New System.Drawing.Size(0, 0)))
        Me.btnRefresh.Symbol = ""
        Me.btnRefresh.SymbolColor = System.Drawing.Color.White
        Me.btnRefresh.Text = "Refresh"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(904, 1)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(1, 499)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(1, 499)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(905, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 500)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(905, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Account Number"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Account Name"
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'tooltipDisplayDelay
        '
        Me.tooltipDisplayDelay.Interval = 1000
        '
        'superTooltipWithLink
        '
        Me.superTooltipWithLink.AntiAlias = False
        Me.superTooltipWithLink.DefaultFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.superTooltipWithLink.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.superTooltipWithLink.DelayTooltipHideDuration = 1000
        Me.superTooltipWithLink.PositionBelowControl = False
        '
        'btnImportFarmers
        '
        Me.btnImportFarmers.Name = "btnImportFarmers"
        Me.btnImportFarmers.Text = "Import Farmers"
        '
        'btnImportPayments
        '
        Me.btnImportPayments.Name = "btnImportPayments"
        Me.btnImportPayments.Text = "Import Payments"
        '
        'frmLaschCustomersListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLaschCustomersListing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Border.Width = 1
        Me.Text = "Clients"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCloneItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeleteSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopySelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFindMatching As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents tooltipDisplayDelay As System.Windows.Forms.Timer
    Friend WithEvents superTooltipWithLink As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Private WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnArchive As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents txtSearchString As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGrid As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents btnImportData As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cboSearchBy As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents btnBalances As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAccountDetails As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportFarmers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportPayments As DevComponents.DotNetBar.ButtonItem
    'Friend WithEvents btnViewDeleted As DevComponents.DotNetBar.ButtonItem
End Class
