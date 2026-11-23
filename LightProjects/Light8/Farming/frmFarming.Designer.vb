<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFarming
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.SideNav1 = New DevComponents.DotNetBar.Controls.SideNav()
        Me.SideNavItem1 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.Separator1 = New DevComponents.DotNetBar.Separator()
        Me.SideNavItem2 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavPanel1 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.SideNavItem3 = New DevComponents.DotNetBar.Controls.SideNavItem()
        Me.SideNavPanel2 = New DevComponents.DotNetBar.Controls.SideNavPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAccountDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportData = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportFarmers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportPayments = New DevComponents.DotNetBar.ButtonItem()
        Me.btnArchive = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBalances = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.cboSearchBy = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.txtSearchString = New DevComponents.DotNetBar.TextBoxItem()
        Me.dGrid = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SideNav1.SuspendLayout()
        Me.SideNavPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer)))
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Location = New System.Drawing.Point(0, 569)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(930, 26)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'SideNav1
        '
        Me.SideNav1.Controls.Add(Me.SideNavPanel1)
        Me.SideNav1.Controls.Add(Me.SideNavPanel2)
        Me.SideNav1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNav1.EnableClose = False
        Me.SideNav1.EnableMaximize = False
        Me.SideNav1.EnableSplitter = False
        Me.SideNav1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideNavItem1, Me.Separator1, Me.SideNavItem2, Me.SideNavItem3})
        Me.SideNav1.Location = New System.Drawing.Point(0, 0)
        Me.SideNav1.Name = "SideNav1"
        Me.SideNav1.Padding = New System.Windows.Forms.Padding(1)
        Me.SideNav1.Size = New System.Drawing.Size(930, 569)
        Me.SideNav1.TabIndex = 1
        Me.SideNav1.Text = "SideNav1"
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
        Me.SideNavItem2.Symbol = ""
        Me.SideNavItem2.Text = "Farmers"
        '
        'SideNavPanel1
        '
        Me.SideNavPanel1.Controls.Add(Me.dGrid)
        Me.SideNavPanel1.Controls.Add(Me.KryptonPanel3)
        Me.SideNavPanel1.Controls.Add(Me.Bar2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.SideNavPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.SideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel1.Location = New System.Drawing.Point(122, 31)
        Me.SideNavPanel1.Name = "SideNavPanel1"
        Me.SideNavPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.SideNavPanel1.Size = New System.Drawing.Size(807, 537)
        Me.SideNavPanel1.TabIndex = 2
        '
        'SideNavItem3
        '
        Me.SideNavItem3.Name = "SideNavItem3"
        Me.SideNavItem3.Panel = Me.SideNavPanel2
        Me.SideNavItem3.Symbol = ""
        Me.SideNavItem3.Text = "Disbursements"
        '
        'SideNavPanel2
        '
        Me.SideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideNavPanel2.Location = New System.Drawing.Point(122, 31)
        Me.SideNavPanel2.Name = "SideNavPanel2"
        Me.SideNavPanel2.Size = New System.Drawing.Size(807, 537)
        Me.SideNavPanel2.TabIndex = 6
        Me.SideNavPanel2.Visible = False
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(6, 530)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(795, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(800, 6)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 524)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(6, 6)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 524)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(7, 6)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(793, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnExport, Me.btnImportData, Me.btnArchive, Me.btnPrint, Me.btnBalances, Me.btnRefresh})
        Me.Bar2.Location = New System.Drawing.Point(7, 7)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 2
        Me.Bar2.PaddingLeft = 2
        Me.Bar2.PaddingRight = 2
        Me.Bar2.PaddingTop = 2
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(793, 49)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.Bar2.TabIndex = 47
        Me.Bar2.TabStop = False
        '
        'btnNew
        '
        Me.btnNew.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnNew.ForeColor = System.Drawing.Color.White
        Me.btnNew.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
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
        Me.btnImportData.Symbol = ""
        Me.btnImportData.SymbolColor = System.Drawing.Color.White
        Me.btnImportData.Text = "Import"
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
        'btnArchive
        '
        Me.btnArchive.BeginGroup = True
        Me.btnArchive.FixedSize = New System.Drawing.Size(44, 44)
        Me.btnArchive.ForeColor = System.Drawing.Color.White
        Me.btnArchive.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
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
        Me.btnRefresh.Symbol = ""
        Me.btnRefresh.SymbolColor = System.Drawing.Color.White
        Me.btnRefresh.Text = "Refresh"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(7, 56)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Padding = New System.Windows.Forms.Padding(8)
        Me.KryptonPanel3.Size = New System.Drawing.Size(793, 53)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.TabIndex = 49
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.Bar3)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(8, 8)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.KryptonPanel1.Size = New System.Drawing.Size(777, 37)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel1.TabIndex = 0
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.BackColor = System.Drawing.Color.Transparent
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.cboSearchBy, Me.txtSearchString})
        Me.Bar3.Location = New System.Drawing.Point(3, 5)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(771, 28)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 0
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
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
        Me.dGrid.BackgroundColor = System.Drawing.Color.White
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
        Me.dGrid.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dGrid.Location = New System.Drawing.Point(7, 109)
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
        Me.dGrid.Size = New System.Drawing.Size(793, 421)
        Me.dGrid.TabIndex = 56
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
        'frmFarming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 595)
        Me.Controls.Add(Me.SideNav1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "frmFarming"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Farming"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SideNav1.ResumeLayout(False)
        Me.SideNav1.PerformLayout()
        Me.SideNavPanel1.ResumeLayout(False)
        Me.SideNavPanel1.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents SideNav1 As DevComponents.DotNetBar.Controls.SideNav
    Friend WithEvents SideNavPanel2 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavPanel1 As DevComponents.DotNetBar.Controls.SideNavPanel
    Friend WithEvents SideNavItem1 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Separator1 As DevComponents.DotNetBar.Separator
    Friend WithEvents SideNavItem2 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents SideNavItem3 As DevComponents.DotNetBar.Controls.SideNavItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Private WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAccountDetails As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportData As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportFarmers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportPayments As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnArchive As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBalances As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGrid As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboSearchBy As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents txtSearchString As DevComponents.DotNetBar.TextBoxItem
End Class
