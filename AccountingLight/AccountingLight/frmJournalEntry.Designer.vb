<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJournalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cboCostCenter = New MTGCComboBox()
        Me.cboType = New MTGCComboBox()
        Me.cboAccounts = New MTGCComboBox()
        Me.dgrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonDataGridViewComboBoxColumn1 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.lblDescription = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtDebits = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.txtCredits = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtJournalNumber = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnOK = New DevComponents.DotNetBar.ButtonItem()
        Me.btnClear = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.cboCostCenter)
        Me.KryptonPanel1.Controls.Add(Me.cboType)
        Me.KryptonPanel1.Controls.Add(Me.cboAccounts)
        Me.KryptonPanel1.Controls.Add(Me.dgrid)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.Bar2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(713, 522)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'cboCostCenter
        '
        Me.cboCostCenter.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCostCenter.ArrowColor = System.Drawing.Color.Black
        Me.cboCostCenter.BindedControl = CType(resources.GetObject("cboCostCenter.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboCostCenter.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboCostCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCostCenter.ColumnNum = 1
        Me.cboCostCenter.ColumnWidth = "121"
        Me.cboCostCenter.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCostCenter.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboCostCenter.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboCostCenter.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboCostCenter.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboCostCenter.DisplayMember = "Text"
        Me.cboCostCenter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboCostCenter.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboCostCenter.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCostCenter.DropDownForeColor = System.Drawing.Color.Black
        Me.cboCostCenter.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboCostCenter.DropDownWidth = 141
        Me.cboCostCenter.GridLineColor = System.Drawing.Color.LightGray
        Me.cboCostCenter.GridLineHorizontal = False
        Me.cboCostCenter.GridLineVertical = False
        Me.cboCostCenter.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboCostCenter.HighlightBorderOnMouseEvents = True
        Me.cboCostCenter.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboCostCenter.Location = New System.Drawing.Point(236, 341)
        Me.cboCostCenter.ManagingFastMouseMoving = True
        Me.cboCostCenter.ManagingFastMouseMovingInterval = 30
        Me.cboCostCenter.Name = "cboCostCenter"
        Me.cboCostCenter.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCostCenter.SelectedItem = Nothing
        Me.cboCostCenter.SelectedValue = Nothing
        Me.cboCostCenter.Size = New System.Drawing.Size(208, 21)
        Me.cboCostCenter.TabIndex = 63
        Me.cboCostCenter.Visible = False
        '
        'cboType
        '
        Me.cboType.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboType.ArrowColor = System.Drawing.Color.Black
        Me.cboType.BindedControl = CType(resources.GetObject("cboType.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboType.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboType.ColumnNum = 1
        Me.cboType.ColumnWidth = "121"
        Me.cboType.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboType.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboType.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboType.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboType.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboType.DisplayMember = "Text"
        Me.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboType.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboType.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboType.DropDownForeColor = System.Drawing.Color.Black
        Me.cboType.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboType.DropDownWidth = 141
        Me.cboType.GridLineColor = System.Drawing.Color.LightGray
        Me.cboType.GridLineHorizontal = False
        Me.cboType.GridLineVertical = False
        Me.cboType.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboType.HighlightBorderOnMouseEvents = True
        Me.cboType.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboType.Location = New System.Drawing.Point(215, 288)
        Me.cboType.ManagingFastMouseMoving = True
        Me.cboType.ManagingFastMouseMovingInterval = 30
        Me.cboType.Name = "cboType"
        Me.cboType.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboType.SelectedItem = Nothing
        Me.cboType.SelectedValue = Nothing
        Me.cboType.Size = New System.Drawing.Size(208, 21)
        Me.cboType.TabIndex = 62
        Me.cboType.Visible = False
        '
        'cboAccounts
        '
        Me.cboAccounts.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccounts.ArrowColor = System.Drawing.Color.Black
        Me.cboAccounts.BindedControl = CType(resources.GetObject("cboAccounts.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboAccounts.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboAccounts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboAccounts.ColumnNum = 1
        Me.cboAccounts.ColumnWidth = "121"
        Me.cboAccounts.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccounts.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboAccounts.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboAccounts.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboAccounts.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboAccounts.DisplayMember = "Text"
        Me.cboAccounts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboAccounts.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboAccounts.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboAccounts.DropDownForeColor = System.Drawing.Color.Black
        Me.cboAccounts.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboAccounts.DropDownWidth = 141
        Me.cboAccounts.GridLineColor = System.Drawing.Color.LightGray
        Me.cboAccounts.GridLineHorizontal = False
        Me.cboAccounts.GridLineVertical = False
        Me.cboAccounts.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboAccounts.HighlightBorderOnMouseEvents = True
        Me.cboAccounts.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboAccounts.Location = New System.Drawing.Point(289, 160)
        Me.cboAccounts.ManagingFastMouseMoving = True
        Me.cboAccounts.ManagingFastMouseMovingInterval = 30
        Me.cboAccounts.Name = "cboAccounts"
        Me.cboAccounts.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboAccounts.SelectedItem = Nothing
        Me.cboAccounts.SelectedValue = Nothing
        Me.cboAccounts.Size = New System.Drawing.Size(208, 21)
        Me.cboAccounts.TabIndex = 61
        Me.cboAccounts.Visible = False
        '
        'dgrid
        '
        Me.dgrid.AllowUserToAddRows = False
        Me.dgrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.KryptonDataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn5})
        Me.dgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrid.Location = New System.Drawing.Point(1, 84)
        Me.dgrid.Name = "dgrid"
        Me.dgrid.RowHeadersWidth = 25
        Me.dgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgrid.Size = New System.Drawing.Size(711, 410)
        Me.dgrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dgrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrid.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dgrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.TabIndex = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Account Number"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Narration/Account Description"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cost Center"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Folio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 43
        '
        'KryptonDataGridViewComboBoxColumn1
        '
        Me.KryptonDataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.KryptonDataGridViewComboBoxColumn1.DropDownWidth = 121
        Me.KryptonDataGridViewComboBoxColumn1.HeaderText = "Action"
        Me.KryptonDataGridViewComboBoxColumn1.Items.AddRange(New String() {"DEBIT", "CREDIT"})
        Me.KryptonDataGridViewComboBoxColumn1.MinimumWidth = 80
        Me.KryptonDataGridViewComboBoxColumn1.Name = "KryptonDataGridViewComboBoxColumn1"
        Me.KryptonDataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.KryptonDataGridViewComboBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn5.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 494)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(711, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblDescription, Me.LabelItem1, Me.LabelItem2, Me.txtDebits, Me.LabelItem4, Me.txtCredits})
        Me.Bar2.Location = New System.Drawing.Point(1, 495)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(711, 26)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 58
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'lblDescription
        '
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Stretch = True
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 3
        Me.LabelItem1.PaddingLeft = 3
        Me.LabelItem1.PaddingRight = 3
        Me.LabelItem1.PaddingTop = 3
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Totals"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 3
        Me.LabelItem2.PaddingLeft = 3
        Me.LabelItem2.PaddingRight = 3
        Me.LabelItem2.PaddingTop = 3
        Me.LabelItem2.Text = "Debits"
        '
        'txtDebits
        '
        Me.txtDebits.Name = "txtDebits"
        Me.txtDebits.PaddingBottom = 3
        Me.txtDebits.PaddingLeft = 3
        Me.txtDebits.PaddingRight = 3
        Me.txtDebits.PaddingTop = 3
        Me.txtDebits.Text = "0.00"
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 3
        Me.LabelItem4.PaddingLeft = 3
        Me.LabelItem4.PaddingRight = 3
        Me.LabelItem4.PaddingTop = 3
        Me.LabelItem4.Text = "Credits"
        '
        'txtCredits
        '
        Me.txtCredits.Name = "txtCredits"
        Me.txtCredits.PaddingBottom = 3
        Me.txtCredits.PaddingLeft = 3
        Me.txtCredits.PaddingRight = 3
        Me.txtCredits.PaddingTop = 3
        Me.txtCredits.Text = "0.00"
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel7.Controls.Add(Me.dpDate)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel7.Controls.Add(Me.txtJournalNumber)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.Location = New System.Drawing.Point(1, 26)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(711, 58)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel7.StateCommon.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonPanel7.TabIndex = 57
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 57)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(711, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'dpDate
        '
        Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDate.Location = New System.Drawing.Point(70, 17)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(95, 20)
        Me.dpDate.TabIndex = 16
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel3.Location = New System.Drawing.Point(16, 15)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(54, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 7
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(54, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Date"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(54, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel4.Location = New System.Drawing.Point(184, 16)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(68, 22)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 8
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(68, 21)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Journal #"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(68, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'txtJournalNumber
        '
        Me.txtJournalNumber.Enabled = False
        Me.txtJournalNumber.Location = New System.Drawing.Point(253, 18)
        Me.txtJournalNumber.Name = "txtJournalNumber"
        Me.txtJournalNumber.Size = New System.Drawing.Size(95, 20)
        Me.txtJournalNumber.TabIndex = 9
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1, 25)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(711, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.White
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnOK, Me.btnClear, Me.btnPrint})
        Me.Bar1.Location = New System.Drawing.Point(1, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(711, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 55
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnOK
        '
        Me.btnOK.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnOK.Text = "Save"
        '
        'btnClear
        '
        Me.btnClear.BeginGroup = True
        Me.btnClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnClear.Text = "Clear Entry"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "Print"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(1, 521)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(711, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(712, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 522)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1, 522)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Account Number"
        Me.Column1.MinimumWidth = 180
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Narration/Account Description"
        Me.Column2.MinimumWidth = 240
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Cost Center"
        Me.Column3.MinimumWidth = 180
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column6.HeaderText = "Folio"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.DropDownWidth = 121
        Me.Column4.HeaderText = "Action"
        Me.Column4.Items.AddRange(New String() {"DEBIT", "CREDIT"})
        Me.Column4.MinimumWidth = 80
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.Width = 100
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Amount"
        Me.Column5.MinimumWidth = 80
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 522)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJournalEntry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.StateCommon.Header.Content.LongText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.LongText.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Journal Entry"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.dgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtJournalNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtDebits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtCredits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonDataGridViewComboBoxColumn1 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboCostCenter As MTGCComboBox
    Friend WithEvents cboType As MTGCComboBox
    Friend WithEvents cboAccounts As MTGCComboBox
    Friend WithEvents lblDescription As DevComponents.DotNetBar.LabelItem
End Class
