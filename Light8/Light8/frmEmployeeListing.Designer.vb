<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeListing
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeListing))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grd = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.chkAutoIncreament = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnOptions = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonSeparator1 = New ComponentFactory.Krypton.Toolkit.KryptonSeparator()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgrdDetails = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTerminate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSpecialChange = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintDisplayedEmployees = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelectedEmployee = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintAllEmployeeList = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintMasterFile = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dgrdDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(761, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.grd)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel4.Controls.Add(Me.KryptonSeparator1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel4.Controls.Add(Me.Bar1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(761, 550)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel4.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel4.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel4.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel4.TabIndex = 2
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(1, 66)
        Me.grd.Name = "grd"
        Me.grd.ReadOnly = True
        Me.grd.RowHeadersVisible = False
        Me.grd.RowHeadersWidth = 25
        Me.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd.Size = New System.Drawing.Size(563, 483)
        Me.grd.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.grd.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.grd.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.grd.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grd.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.grd.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.grd.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.grd.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
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
        'Column1
        '
        Me.Column1.HeaderText = "EC Number"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Last Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "First Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Other Names"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "ID No."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel3.Controls.Add(Me.chkAutoIncreament)
        Me.KryptonPanel3.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel3.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(1, 26)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(563, 40)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.TabIndex = 25
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 39)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(563, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'chkAutoIncreament
        '
        Me.chkAutoIncreament.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkAutoIncreament.Location = New System.Drawing.Point(346, 11)
        Me.chkAutoIncreament.Name = "chkAutoIncreament"
        Me.chkAutoIncreament.Size = New System.Drawing.Size(225, 20)
        Me.chkAutoIncreament.TabIndex = 5
        Me.chkAutoIncreament.Text = "Auto Increament Employee Numbers"
        Me.chkAutoIncreament.Values.Text = "Auto Increament Employee Numbers"
        '
        'txtSearchString
        '
        Me.txtSearchString.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnOptions})
        Me.txtSearchString.Location = New System.Drawing.Point(150, 11)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(185, 20)
        Me.txtSearchString.TabIndex = 1
        Me.txtSearchString.Text = "Search Employee"
        '
        'btnOptions
        '
        Me.btnOptions.UniqueName = "41E18DF68FB84A5F41E18DF68FB84A5F"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.Items.AddRange(New Object() {"Employee Number", "Surname", "First Name", "Other Names", "Id Number"})
        Me.cboSearchBy.Location = New System.Drawing.Point(21, 10)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchBy.Size = New System.Drawing.Size(119, 21)
        Me.cboSearchBy.TabIndex = 4
        Me.cboSearchBy.Text = "Search by"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(564, 26)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 523)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonSeparator1
        '
        Me.KryptonSeparator1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonSeparator1.Location = New System.Drawing.Point(565, 26)
        Me.KryptonSeparator1.Name = "KryptonSeparator1"
        Me.KryptonSeparator1.Size = New System.Drawing.Size(5, 523)
        Me.KryptonSeparator1.TabIndex = 23
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dgrdDetails)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonPanel1.Location = New System.Drawing.Point(570, 26)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(190, 523)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 22
        '
        'dgrdDetails
        '
        Me.dgrdDetails.AllowUserToAddRows = False
        Me.dgrdDetails.AllowUserToDeleteRows = False
        Me.dgrdDetails.AllowUserToResizeRows = False
        Me.dgrdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgrdDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6})
        Me.dgrdDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrdDetails.Location = New System.Drawing.Point(1, 0)
        Me.dgrdDetails.Name = "dgrdDetails"
        Me.dgrdDetails.ReadOnly = True
        Me.dgrdDetails.RowHeadersVisible = False
        Me.dgrdDetails.RowHeadersWidth = 25
        Me.dgrdDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrdDetails.Size = New System.Drawing.Size(189, 523)
        Me.dgrdDetails.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dgrdDetails.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dgrdDetails.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrdDetails.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgrdDetails.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrdDetails.StateCommon.HeaderColumn.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dgrdDetails.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrdDetails.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgrdDetails.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgrdDetails.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dgrdDetails.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dgrdDetails.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrdDetails.TabIndex = 35
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(1, 523)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(1, 25)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(759, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnTerminate, Me.btnSpecialChange, Me.btnPrint, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(1, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(759, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 20
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.SymbolSize = 16.0!
        Me.btnNew.Text = "New"
        Me.btnNew.Tooltip = "New employee record"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.SymbolSize = 16.0!
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.Tooltip = "Modify employee record"
        '
        'btnTerminate
        '
        Me.btnTerminate.BeginGroup = True
        Me.btnTerminate.Image = CType(resources.GetObject("btnTerminate.Image"), System.Drawing.Image)
        Me.btnTerminate.Name = "btnTerminate"
        Me.btnTerminate.SymbolSize = 16.0!
        Me.btnTerminate.Text = "Terminate"
        Me.btnTerminate.Tooltip = "Terminate employee"
        '
        'btnSpecialChange
        '
        Me.btnSpecialChange.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSpecialChange.Image = CType(resources.GetObject("btnSpecialChange.Image"), System.Drawing.Image)
        Me.btnSpecialChange.Name = "btnSpecialChange"
        Me.btnSpecialChange.SymbolSize = 16.0!
        Me.btnSpecialChange.Text = "Special Edit"
        Me.btnSpecialChange.Tooltip = "Special Masterfile Change"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.PersonalizedMenus = DevComponents.DotNetBar.ePersonalizedMenus.DisplayOnHover
        Me.btnPrint.SplitButton = True
        Me.btnPrint.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintDisplayedEmployees, Me.btnPrintSelectedEmployee, Me.btnPrintAllEmployeeList, Me.btnPrintMasterFile})
        Me.btnPrint.SymbolSize = 16.0!
        Me.btnPrint.Text = "Print"
        '
        'btnPrintDisplayedEmployees
        '
        Me.btnPrintDisplayedEmployees.Name = "btnPrintDisplayedEmployees"
        Me.btnPrintDisplayedEmployees.Text = "Displayed Employee List"
        '
        'btnPrintSelectedEmployee
        '
        Me.btnPrintSelectedEmployee.Name = "btnPrintSelectedEmployee"
        Me.btnPrintSelectedEmployee.Text = "Selected Employee Record"
        '
        'btnPrintAllEmployeeList
        '
        Me.btnPrintAllEmployeeList.Name = "btnPrintAllEmployeeList"
        Me.btnPrintAllEmployeeList.Text = "All Employees List"
        '
        'btnPrintMasterFile
        '
        Me.btnPrintMasterFile.Name = "btnPrintMasterFile"
        Me.btnPrintMasterFile.Text = "Master File Records"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.SymbolSize = 16.0!
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.Tooltip = "Refresh listing"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(760, 0)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 549)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 549)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 549)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(761, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'frmEmployeeListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 551)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel4)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmployeeListing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employees"
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.dgrdDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents grd As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents chkAutoIncreament As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnOptions As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonSeparator1 As ComponentFactory.Krypton.Toolkit.KryptonSeparator
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgrdDetails As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTerminate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSpecialChange As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintDisplayedEmployees As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelectedEmployee As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintAllEmployeeList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintMasterFile As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
