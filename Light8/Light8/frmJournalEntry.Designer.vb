<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJournalEntry))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnOK = New DevComponents.DotNetBar.ButtonItem()
        Me.btnClear = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
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
        Me.cboCostCenter = New MTGCComboBox()
        Me.cboType = New MTGCComboBox()
        Me.cboAccounts = New MTGCComboBox()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dgrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonDataGridViewComboBoxColumn1 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.dgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(709, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 515)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(709, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(708, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 514)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 514)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnOK, Me.btnClear, Me.btnPrint})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(707, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnOK
        '
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnOK.Text = "Save"
        '
        'btnClear
        '
        Me.btnClear.BeginGroup = True
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnClear.Text = "Clear Entry"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "Print"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(707, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblDescription, Me.LabelItem1, Me.LabelItem2, Me.txtDebits, Me.LabelItem4, Me.txtCredits})
        Me.Bar2.Location = New System.Drawing.Point(1, 490)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(707, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 61
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
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel7.Controls.Add(Me.dpDate)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel7.Controls.Add(Me.txtJournalNumber)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(707, 62)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.TabIndex = 60
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 61)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(707, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'dpDate
        '
        Me.dpDate.BackColor = System.Drawing.Color.White
        Me.dpDate.ForeColor = System.Drawing.Color.Black
        Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDate.Location = New System.Drawing.Point(80, 18)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(95, 22)
        Me.dpDate.TabIndex = 16
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(23, 18)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(54, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 7
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(54, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Date"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(54, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(191, 18)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(68, 22)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 8
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(68, 21)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Journal #"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(68, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'txtJournalNumber
        '
        Me.txtJournalNumber.BackColor = System.Drawing.Color.White
        Me.txtJournalNumber.Enabled = False
        Me.txtJournalNumber.ForeColor = System.Drawing.Color.Black
        Me.txtJournalNumber.Location = New System.Drawing.Point(261, 20)
        Me.txtJournalNumber.Name = "txtJournalNumber"
        Me.txtJournalNumber.Size = New System.Drawing.Size(95, 20)
        Me.txtJournalNumber.TabIndex = 9
        '
        'cboCostCenter
        '
        Me.cboCostCenter.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCostCenter.ArrowColor = System.Drawing.Color.Black
        Me.cboCostCenter.BackColor = System.Drawing.Color.White
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
        Me.cboCostCenter.ForeColor = System.Drawing.Color.Black
        Me.cboCostCenter.GridLineColor = System.Drawing.Color.LightGray
        Me.cboCostCenter.GridLineHorizontal = False
        Me.cboCostCenter.GridLineVertical = False
        Me.cboCostCenter.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboCostCenter.HighlightBorderOnMouseEvents = True
        Me.cboCostCenter.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboCostCenter.Location = New System.Drawing.Point(29, 263)
        Me.cboCostCenter.ManagingFastMouseMoving = True
        Me.cboCostCenter.ManagingFastMouseMovingInterval = 30
        Me.cboCostCenter.Name = "cboCostCenter"
        Me.cboCostCenter.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCostCenter.SelectedItem = Nothing
        Me.cboCostCenter.SelectedValue = Nothing
        Me.cboCostCenter.Size = New System.Drawing.Size(208, 23)
        Me.cboCostCenter.TabIndex = 74
        Me.cboCostCenter.Visible = False
        '
        'cboType
        '
        Me.cboType.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboType.ArrowColor = System.Drawing.Color.Black
        Me.cboType.BackColor = System.Drawing.Color.White
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
        Me.cboType.ForeColor = System.Drawing.Color.Black
        Me.cboType.GridLineColor = System.Drawing.Color.LightGray
        Me.cboType.GridLineHorizontal = False
        Me.cboType.GridLineVertical = False
        Me.cboType.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboType.HighlightBorderOnMouseEvents = True
        Me.cboType.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboType.Location = New System.Drawing.Point(242, 264)
        Me.cboType.ManagingFastMouseMoving = True
        Me.cboType.ManagingFastMouseMovingInterval = 30
        Me.cboType.Name = "cboType"
        Me.cboType.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboType.SelectedItem = Nothing
        Me.cboType.SelectedValue = Nothing
        Me.cboType.Size = New System.Drawing.Size(208, 23)
        Me.cboType.TabIndex = 81
        Me.cboType.Visible = False
        '
        'cboAccounts
        '
        Me.cboAccounts.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboAccounts.ArrowColor = System.Drawing.Color.Black
        Me.cboAccounts.BackColor = System.Drawing.Color.White
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
        Me.cboAccounts.ForeColor = System.Drawing.Color.Black
        Me.cboAccounts.GridLineColor = System.Drawing.Color.LightGray
        Me.cboAccounts.GridLineHorizontal = False
        Me.cboAccounts.GridLineVertical = False
        Me.cboAccounts.HighlightBorderColor = System.Drawing.Color.Transparent
        Me.cboAccounts.HighlightBorderOnMouseEvents = True
        Me.cboAccounts.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboAccounts.Location = New System.Drawing.Point(456, 264)
        Me.cboAccounts.ManagingFastMouseMoving = True
        Me.cboAccounts.ManagingFastMouseMovingInterval = 30
        Me.cboAccounts.Name = "cboAccounts"
        Me.cboAccounts.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboAccounts.SelectedItem = Nothing
        Me.cboAccounts.SelectedValue = Nothing
        Me.cboAccounts.Size = New System.Drawing.Size(208, 23)
        Me.cboAccounts.TabIndex = 80
        Me.cboAccounts.Visible = False
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(1, 489)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(707, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'dgrid
        '
        Me.dgrid.AllowUserToAddRows = False
        Me.dgrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.KryptonDataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn5})
        Me.dgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgrid.Location = New System.Drawing.Point(1, 89)
        Me.dgrid.Name = "dgrid"
        Me.dgrid.RowHeadersWidth = 25
        Me.dgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgrid.Size = New System.Drawing.Size(707, 400)
        Me.dgrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dgrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dgrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.TabIndex = 88
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'frmJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 516)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.cboAccounts)
        Me.Controls.Add(Me.cboCostCenter)
        Me.Controls.Add(Me.dgrid)
        Me.Controls.Add(Me.KryptonBorderEdge9)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.KryptonPanel7)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJournalEntry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Journal Entries"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.dgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblDescription As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtDebits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtCredits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtJournalNumber As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cboCostCenter As MTGCComboBox
    Friend WithEvents cboType As MTGCComboBox
    Friend WithEvents cboAccounts As MTGCComboBox
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dgrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonDataGridViewComboBoxColumn1 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
