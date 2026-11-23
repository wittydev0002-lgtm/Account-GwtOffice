<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindInventory
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboInventoryStatus = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboSearchType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.chkWildCast = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroup1 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.pnlPickList = New System.Windows.Forms.Panel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel8 = New System.Windows.Forms.Panel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSelectSales = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboInventoryStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup1.Panel.SuspendLayout()
        Me.KryptonGroup1.SuspendLayout()
        Me.pnlPickList.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.cboInventoryStatus)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.cboSearchType)
        Me.KryptonPanel1.Controls.Add(Me.chkWildCast)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroup1)
        Me.KryptonPanel1.Controls.Add(Me.panel8)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(842, 501)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(841, 0)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 459)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 459)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 459)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(842, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(485, 18)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(104, 25)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 52
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(104, 24)
        Me.KryptonLabel3.TabIndex = 18
        Me.KryptonLabel3.Values.Text = "Filter by status"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 24)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(104, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'cboInventoryStatus
        '
        Me.cboInventoryStatus.BackColor = System.Drawing.Color.White
        Me.cboInventoryStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInventoryStatus.DropDownWidth = 163
        Me.cboInventoryStatus.ForeColor = System.Drawing.Color.Black
        Me.cboInventoryStatus.Items.AddRange(New Object() {"ACTIVE", "DE-ACTIVATED", "ALL"})
        Me.cboInventoryStatus.Location = New System.Drawing.Point(591, 22)
        Me.cboInventoryStatus.Name = "cboInventoryStatus"
        Me.cboInventoryStatus.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboInventoryStatus.Size = New System.Drawing.Size(119, 21)
        Me.cboInventoryStatus.TabIndex = 51
        Me.cboInventoryStatus.Text = "ACTIVE"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(10, 42)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(90, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(246, 42)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(90, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'cboSearchType
        '
        Me.cboSearchType.BackColor = System.Drawing.Color.White
        Me.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchType.DropDownWidth = 169
        Me.cboSearchType.ForeColor = System.Drawing.Color.Black
        Me.cboSearchType.Items.AddRange(New Object() {"Item Code", "Description"})
        Me.cboSearchType.Location = New System.Drawing.Point(337, 22)
        Me.cboSearchType.Name = "cboSearchType"
        Me.cboSearchType.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchType.Size = New System.Drawing.Size(142, 21)
        Me.cboSearchType.TabIndex = 3
        '
        'chkWildCast
        '
        Me.chkWildCast.BackColor = System.Drawing.Color.White
        Me.chkWildCast.Checked = True
        Me.chkWildCast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWildCast.ForeColor = System.Drawing.Color.Black
        Me.chkWildCast.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkWildCast.Location = New System.Drawing.Point(717, 23)
        Me.chkWildCast.Name = "chkWildCast"
        Me.chkWildCast.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.chkWildCast.Size = New System.Drawing.Size(115, 22)
        Me.chkWildCast.TabIndex = 4
        Me.chkWildCast.Text = "Wild Cast Search"
        Me.chkWildCast.Values.Text = "Wild Cast Search"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(263, 23)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(70, 20)
        Me.KryptonLabel2.TabIndex = 2
        Me.KryptonLabel2.Values.Text = "Search by :"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.White
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(100, 23)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(142, 20)
        Me.txtSearchString.TabIndex = 1
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(13, 23)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(72, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Search for :"
        '
        'KryptonGroup1
        '
        Me.KryptonGroup1.BackColor = System.Drawing.Color.White
        Me.KryptonGroup1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup1.Location = New System.Drawing.Point(12, 56)
        Me.KryptonGroup1.Name = "KryptonGroup1"
        '
        'KryptonGroup1.Panel
        '
        Me.KryptonGroup1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroup1.Panel.Controls.Add(Me.pnlPickList)
        Me.KryptonGroup1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup1.Size = New System.Drawing.Size(818, 398)
        Me.KryptonGroup1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroup1.TabIndex = 50
        '
        'pnlPickList
        '
        Me.pnlPickList.BackColor = System.Drawing.Color.Transparent
        Me.pnlPickList.Controls.Add(Me.dGrid)
        Me.pnlPickList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPickList.ForeColor = System.Drawing.Color.Black
        Me.pnlPickList.Location = New System.Drawing.Point(0, 0)
        Me.pnlPickList.Name = "pnlPickList"
        Me.pnlPickList.Size = New System.Drawing.Size(816, 396)
        Me.pnlPickList.TabIndex = 49
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet
        Me.dGrid.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet
        Me.dGrid.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.dGrid.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.dGrid.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(816, 396)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 0
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column10.HeaderText = "Item Code"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 97
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column11.HeaderText = "Description"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column12.HeaderText = "Category"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 89
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column13.HeaderText = "Sub Category"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 115
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Location"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "Cost Price"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 94
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Sell Price"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 89
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Tax"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 56
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Qty"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 56
        '
        'Column6
        '
        Me.Column6.HeaderText = "Short Code"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'panel8
        '
        Me.panel8.BackColor = System.Drawing.Color.Transparent
        Me.panel8.Controls.Add(Me.btnCancel)
        Me.panel8.Controls.Add(Me.btnSelectSales)
        Me.panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel8.ForeColor = System.Drawing.Color.Black
        Me.panel8.Location = New System.Drawing.Point(0, 460)
        Me.panel8.Name = "panel8"
        Me.panel8.Size = New System.Drawing.Size(842, 41)
        Me.panel8.TabIndex = 49
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(755, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnSelectSales
        '
        Me.btnSelectSales.BackColor = System.Drawing.Color.White
        Me.btnSelectSales.ForeColor = System.Drawing.Color.Black
        Me.btnSelectSales.Location = New System.Drawing.Point(677, 8)
        Me.btnSelectSales.Name = "btnSelectSales"
        Me.btnSelectSales.Size = New System.Drawing.Size(75, 25)
        Me.btnSelectSales.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnSelectSales.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSelectSales.StateCommon.Back.ColorAngle = 100.0!
        Me.btnSelectSales.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnSelectSales.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSelectSales.StateCommon.Border.Rounding = 0
        Me.btnSelectSales.TabIndex = 0
        Me.btnSelectSales.Values.Text = "&Select"
        '
        'frmFindInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFindInventory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Quick Item Search"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboInventoryStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.ResumeLayout(False)
        Me.pnlPickList.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectSales As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonGroup1 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Private WithEvents pnlPickList As System.Windows.Forms.Panel
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkWildCast As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents cboSearchType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboInventoryStatus As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class