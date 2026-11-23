<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierListing
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplierListing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar14 = New DevComponents.DotNetBar.Bar()
        Me.btnNewSupplier = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditCreditor = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteSupplier = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnNotZero = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllCustomers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportSuppliers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAccountSettlement = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshCreditors = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel81 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge82 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel67 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboCreditorSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtCreditorSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.dGridCreditors = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel81.SuspendLayout()
        CType(Me.cboCreditorSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridCreditors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(653, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 435)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(653, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(652, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 434)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 434)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar14
        '
        Me.Bar14.AntiAlias = True
        Me.Bar14.BackColor = System.Drawing.Color.Transparent
        Me.Bar14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar14.IsMaximized = False
        Me.Bar14.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewSupplier, Me.btnEditCreditor, Me.btnDeleteSupplier, Me.ButtonItem18, Me.btnExportSuppliers, Me.btnAccountSettlement, Me.btnRefreshCreditors})
        Me.Bar14.Location = New System.Drawing.Point(1, 1)
        Me.Bar14.Name = "Bar14"
        Me.Bar14.RoundCorners = False
        Me.Bar14.Size = New System.Drawing.Size(651, 25)
        Me.Bar14.Stretch = True
        Me.Bar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar14.TabIndex = 18
        Me.Bar14.TabStop = False
        Me.Bar14.Text = "Bar14"
        '
        'btnNewSupplier
        '
        Me.btnNewSupplier.Image = CType(resources.GetObject("btnNewSupplier.Image"), System.Drawing.Image)
        Me.btnNewSupplier.Name = "btnNewSupplier"
        Me.btnNewSupplier.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewSupplier.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewSupplier.Text = "New"
        '
        'btnEditCreditor
        '
        Me.btnEditCreditor.Image = CType(resources.GetObject("btnEditCreditor.Image"), System.Drawing.Image)
        Me.btnEditCreditor.Name = "btnEditCreditor"
        Me.btnEditCreditor.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditCreditor.Text = "Edit"
        '
        'btnDeleteSupplier
        '
        Me.btnDeleteSupplier.BeginGroup = True
        Me.btnDeleteSupplier.Image = CType(resources.GetObject("btnDeleteSupplier.Image"), System.Drawing.Image)
        Me.btnDeleteSupplier.Name = "btnDeleteSupplier"
        Me.btnDeleteSupplier.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteSupplier.Text = "Delete"
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
        'btnExportSuppliers
        '
        Me.btnExportSuppliers.BeginGroup = True
        Me.btnExportSuppliers.Image = CType(resources.GetObject("btnExportSuppliers.Image"), System.Drawing.Image)
        Me.btnExportSuppliers.Name = "btnExportSuppliers"
        Me.btnExportSuppliers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportSuppliers.Text = "Export"
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
        'btnRefreshCreditors
        '
        Me.btnRefreshCreditors.BeginGroup = True
        Me.btnRefreshCreditors.Image = CType(resources.GetObject("btnRefreshCreditors.Image"), System.Drawing.Image)
        Me.btnRefreshCreditors.Name = "btnRefreshCreditors"
        Me.btnRefreshCreditors.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshCreditors.Text = "&Refresh"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(651, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel8.Controls.Add(Me.KryptonPanel81)
        Me.KryptonPanel8.Controls.Add(Me.cboCreditorSearchBy)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel8.Controls.Add(Me.txtCreditorSearchString)
        Me.KryptonPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(651, 51)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel8.TabIndex = 20
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
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
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
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
        Me.KryptonPanel81.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
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
        Me.KryptonBorderEdge82.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge82.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge82.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge82.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge82.Name = "KryptonBorderEdge82"
        Me.KryptonBorderEdge82.Size = New System.Drawing.Size(86, 1)
        Me.KryptonBorderEdge82.Text = "KryptonBorderEdge82"
        '
        'KryptonLabel67
        '
        Me.KryptonLabel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel67.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel67.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel67.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel67.Name = "KryptonLabel67"
        Me.KryptonLabel67.Size = New System.Drawing.Size(86, 20)
        Me.KryptonLabel67.TabIndex = 0
        Me.KryptonLabel67.Values.Text = "Search filter"
        '
        'cboCreditorSearchBy
        '
        Me.cboCreditorSearchBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboCreditorSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCreditorSearchBy.DropDownWidth = 152
        Me.cboCreditorSearchBy.ForeColor = System.Drawing.Color.Black
        Me.cboCreditorSearchBy.Items.AddRange(New Object() {"Account Number", "Account Name", "Account Type"})
        Me.cboCreditorSearchBy.Location = New System.Drawing.Point(96, 15)
        Me.cboCreditorSearchBy.Name = "cboCreditorSearchBy"
        Me.cboCreditorSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboCreditorSearchBy.Size = New System.Drawing.Size(152, 21)
        Me.cboCreditorSearchBy.TabIndex = 3
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(650, 0)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(1, 50)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 50)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(651, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'txtCreditorSearchString
        '
        Me.txtCreditorSearchString.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCreditorSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtCreditorSearchString.Location = New System.Drawing.Point(352, 15)
        Me.txtCreditorSearchString.Name = "txtCreditorSearchString"
        Me.txtCreditorSearchString.Size = New System.Drawing.Size(211, 20)
        Me.txtCreditorSearchString.TabIndex = 1
        '
        'dGridCreditors
        '
        Me.dGridCreditors.AllowUserToAddRows = False
        Me.dGridCreditors.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridCreditors.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridCreditors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridCreditors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39})
        Me.dGridCreditors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridCreditors.Location = New System.Drawing.Point(1, 78)
        Me.dGridCreditors.Name = "dGridCreditors"
        Me.dGridCreditors.ReadOnly = True
        Me.dGridCreditors.RowHeadersWidth = 25
        Me.dGridCreditors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridCreditors.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridCreditors.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridCreditors.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridCreditors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridCreditors.Size = New System.Drawing.Size(651, 357)
        Me.dGridCreditors.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridCreditors.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridCreditors.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridCreditors.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridCreditors.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCreditors.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridCreditors.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridCreditors.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridCreditors.TabIndex = 23
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn33.HeaderText = "Account No."
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Width = 104
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn34.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 69
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn35.HeaderText = "Telephone"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        Me.DataGridViewTextBoxColumn35.Width = 94
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn36.HeaderText = "Take On Date"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Width = 114
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn37.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn37.HeaderText = "Email Address"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        Me.DataGridViewTextBoxColumn37.Width = 117
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn38.HeaderText = "Address"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        Me.DataGridViewTextBoxColumn38.Width = 82
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn39.HeaderText = "Cellphone"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        Me.DataGridViewTextBoxColumn39.Width = 93
        '
        'frmSupplierListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 436)
        Me.Controls.Add(Me.dGridCreditors)
        Me.Controls.Add(Me.KryptonPanel8)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar14)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSupplierListing"
        Me.Text = "Creditors and Suppliers"
        CType(Me.Bar14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel81.ResumeLayout(False)
        Me.KryptonPanel81.PerformLayout()
        CType(Me.cboCreditorSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridCreditors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar14 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewSupplier As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditCreditor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteSupplier As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNotZero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllCustomers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportSuppliers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAccountSettlement As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshCreditors As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel81 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge82 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel67 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCreditorSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtCreditorSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents dGridCreditors As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
