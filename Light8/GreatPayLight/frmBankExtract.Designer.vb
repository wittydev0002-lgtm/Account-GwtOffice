<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankExtract
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankExtract))
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.sProcessDate = New System.Windows.Forms.DateTimePicker()
        Me.lstAvailableBanks = New System.Windows.Forms.ListView()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.ppDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge46 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge45 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge44 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge43 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnExit = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroup3 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.XtraTabPage1 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel20 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.XtraTabPage2 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnNext = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroup4 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtCurrency = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtPackageName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtReceiverName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtSenderName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtSenderId = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtReceiverId = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel31 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge42 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtAccNum = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel30 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge41 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboTransType = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboBank = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboVersion = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel29 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge40 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel28 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel15 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge39 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel27 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge38 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel26 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge37 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel25 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge36 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel24 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge35 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel23 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge34 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel22 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge33 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel21 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge32 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.DataGridView1 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XtraTabPage3 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.optUncheckAll = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optCheckAll = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.btnNext1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnBack1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.XtraTabPage4 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkOutputExcel = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.btnSaveSettings = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnProcess = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btn = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroup2 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel19 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblSplit5Description = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge28 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge29 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge30 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge31 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel18 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblSplit4Description = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge24 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge25 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel17 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblSplit3Description = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge21 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge23 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel11 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel16 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblSplit2Description = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge17 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge18 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge19 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel15 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblSplit1Description = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge15 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel12 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblNetDescription = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtDir = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnBrowse = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.cboNetSalary = New MTGCComboBox()
        Me.cboSplitPayCode5 = New MTGCComboBox()
        Me.cboSplitPayCode1 = New MTGCComboBox()
        Me.cboSplitPayCode4 = New MTGCComboBox()
        Me.cboSplitPayCode2 = New MTGCComboBox()
        Me.cboSplitPayCode3 = New MTGCComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.optAll = New System.Windows.Forms.RadioButton()
        Me.optSelective = New System.Windows.Forms.RadioButton()
        Me.grpPaypoints = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkPayPoints = New System.Windows.Forms.CheckedListBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.KryptonPanel32 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel33 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup3.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup3.Panel.SuspendLayout()
        Me.KryptonGroup3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel20.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup4.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup4.Panel.SuspendLayout()
        Me.KryptonGroup4.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonPanel31, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel31.SuspendLayout()
        CType(Me.KryptonPanel30, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel30.SuspendLayout()
        CType(Me.cboTransType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel29, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel29.SuspendLayout()
        CType(Me.KryptonPanel28, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel28.SuspendLayout()
        CType(Me.KryptonPanel27, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel27.SuspendLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel26.SuspendLayout()
        CType(Me.KryptonPanel25, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel25.SuspendLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel24.SuspendLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel23.SuspendLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel22.SuspendLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel21.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup2.Panel.SuspendLayout()
        Me.KryptonGroup2.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel19.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel18.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel17.SuspendLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel11.SuspendLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel16.SuspendLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel15.SuspendLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel12.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grpPaypoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpPaypoints.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPaypoints.Panel.SuspendLayout()
        Me.grpPaypoints.SuspendLayout()
        CType(Me.KryptonPanel32, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel32.SuspendLayout()
        CType(Me.KryptonPanel33, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel33.SuspendLayout()
        Me.SuspendLayout()
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(3, 3)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(592, 337)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.LightGray
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Report Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Image = CType(resources.GetObject("Column2.Image"), System.Drawing.Image)
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 30
        '
        'sProcessDate
        '
        Me.sProcessDate.BackColor = System.Drawing.Color.White
        Me.sProcessDate.ForeColor = System.Drawing.Color.Black
        Me.sProcessDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.sProcessDate.Location = New System.Drawing.Point(171, 19)
        Me.sProcessDate.Name = "sProcessDate"
        Me.sProcessDate.Size = New System.Drawing.Size(89, 22)
        Me.sProcessDate.TabIndex = 6
        '
        'lstAvailableBanks
        '
        Me.lstAvailableBanks.BackColor = System.Drawing.Color.White
        Me.lstAvailableBanks.CheckBoxes = True
        Me.lstAvailableBanks.ForeColor = System.Drawing.Color.Black
        Me.lstAvailableBanks.FullRowSelect = True
        Me.lstAvailableBanks.GridLines = True
        Me.lstAvailableBanks.Location = New System.Drawing.Point(16, 9)
        Me.lstAvailableBanks.Name = "lstAvailableBanks"
        Me.lstAvailableBanks.Size = New System.Drawing.Size(537, 238)
        Me.lstAvailableBanks.TabIndex = 0
        Me.lstAvailableBanks.UseCompatibleStateImageBehavior = False
        Me.lstAvailableBanks.View = System.Windows.Forms.View.Details
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ProgressBar1.Location = New System.Drawing.Point(14, 387)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(350, 25)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Visible = False
        '
        'ppDialog
        '
        Me.ppDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppDialog.Enabled = True
        Me.ppDialog.Icon = CType(resources.GetObject("ppDialog.Icon"), System.Drawing.Icon)
        Me.ppDialog.Name = "ppDialog"
        Me.ppDialog.Visible = False
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge46)
        Me.KryptonPanel1.Controls.Add(Me.btnSaveSettings)
        Me.KryptonPanel1.Controls.Add(Me.btnProcess)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge45)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge44)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge43)
        Me.KryptonPanel1.Controls.Add(Me.btnExit)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroup3)
        Me.KryptonPanel1.Controls.Add(Me.ProgressBar1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(635, 425)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 4
        '
        'KryptonBorderEdge46
        '
        Me.KryptonBorderEdge46.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge46.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge46.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge46.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge46.Name = "KryptonBorderEdge46"
        Me.KryptonBorderEdge46.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge46.Size = New System.Drawing.Size(1, 423)
        Me.KryptonBorderEdge46.Text = "KryptonBorderEdge46"
        '
        'KryptonBorderEdge45
        '
        Me.KryptonBorderEdge45.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge45.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge45.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge45.Location = New System.Drawing.Point(634, 1)
        Me.KryptonBorderEdge45.Name = "KryptonBorderEdge45"
        Me.KryptonBorderEdge45.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge45.Size = New System.Drawing.Size(1, 423)
        Me.KryptonBorderEdge45.Text = "KryptonBorderEdge45"
        '
        'KryptonBorderEdge44
        '
        Me.KryptonBorderEdge44.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge44.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge44.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge44.Location = New System.Drawing.Point(0, 424)
        Me.KryptonBorderEdge44.Name = "KryptonBorderEdge44"
        Me.KryptonBorderEdge44.Size = New System.Drawing.Size(635, 1)
        Me.KryptonBorderEdge44.Text = "KryptonBorderEdge44"
        '
        'KryptonBorderEdge43
        '
        Me.KryptonBorderEdge43.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge43.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge43.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge43.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge43.Name = "KryptonBorderEdge43"
        Me.KryptonBorderEdge43.Size = New System.Drawing.Size(635, 1)
        Me.KryptonBorderEdge43.Text = "KryptonBorderEdge43"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(545, 388)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnExit.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnExit.StateCommon.Back.ColorAngle = 100.0!
        Me.btnExit.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnExit.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnExit.StateCommon.Border.Rounding = 0
        Me.btnExit.TabIndex = 24
        Me.btnExit.Values.Text = "&Cancel"
        '
        'KryptonGroup3
        '
        Me.KryptonGroup3.BackColor = System.Drawing.Color.White
        Me.KryptonGroup3.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup3.Location = New System.Drawing.Point(13, 11)
        Me.KryptonGroup3.Name = "KryptonGroup3"
        '
        'KryptonGroup3.Panel
        '
        Me.KryptonGroup3.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroup3.Panel.Controls.Add(Me.TabControl1)
        Me.KryptonGroup3.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup3.Size = New System.Drawing.Size(608, 371)
        Me.KryptonGroup3.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroup3.StateCommon.Border.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroup3.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup3.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.XtraTabPage1)
        Me.TabControl1.Controls.Add(Me.XtraTabPage2)
        Me.TabControl1.Controls.Add(Me.XtraTabPage3)
        Me.TabControl1.Controls.Add(Me.XtraTabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(606, 369)
        Me.TabControl1.TabIndex = 4
        Me.TabControl1.Text = "XtraTabControl1"
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.XtraTabPage1.Controls.Add(Me.KryptonPanel20)
        Me.XtraTabPage1.ForeColor = System.Drawing.Color.Black
        Me.XtraTabPage1.Location = New System.Drawing.Point(4, 22)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(598, 343)
        Me.XtraTabPage1.TabIndex = 0
        Me.XtraTabPage1.Text = "Saved Extracts"
        '
        'KryptonPanel20
        '
        Me.KryptonPanel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel20.Controls.Add(Me.dGrid)
        Me.KryptonPanel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel20.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel20.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel20.Name = "KryptonPanel20"
        Me.KryptonPanel20.Padding = New System.Windows.Forms.Padding(3)
        Me.KryptonPanel20.Size = New System.Drawing.Size(598, 343)
        Me.KryptonPanel20.StateCommon.Color1 = System.Drawing.Color.LightGray
        Me.KryptonPanel20.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel20.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel20.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel20.TabIndex = 2
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.XtraTabPage2.Controls.Add(Me.KryptonPanel2)
        Me.XtraTabPage2.ForeColor = System.Drawing.Color.Black
        Me.XtraTabPage2.Location = New System.Drawing.Point(4, 22)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(598, 343)
        Me.XtraTabPage2.TabIndex = 1
        Me.XtraTabPage2.Text = "Company Details"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.btnNext)
        Me.KryptonPanel2.Controls.Add(Me.KryptonGroup4)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(598, 343)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel2.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel2.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel2.TabIndex = 2
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.White
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Location = New System.Drawing.Point(510, 304)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 25)
        Me.btnNext.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnNext.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnNext.StateCommon.Back.ColorAngle = 100.0!
        Me.btnNext.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnNext.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnNext.StateCommon.Border.Rounding = 0
        Me.btnNext.TabIndex = 23
        Me.btnNext.Values.Text = "Next >"
        '
        'KryptonGroup4
        '
        Me.KryptonGroup4.BackColor = System.Drawing.Color.White
        Me.KryptonGroup4.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup4.Location = New System.Drawing.Point(14, 13)
        Me.KryptonGroup4.Name = "KryptonGroup4"
        '
        'KryptonGroup4.Panel
        '
        Me.KryptonGroup4.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroup4.Panel.Controls.Add(Me.KryptonPanel6)
        Me.KryptonGroup4.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup4.Size = New System.Drawing.Size(571, 286)
        Me.KryptonGroup4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroup4.TabIndex = 22
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel6.Controls.Add(Me.txtCurrency)
        Me.KryptonPanel6.Controls.Add(Me.txtPackageName)
        Me.KryptonPanel6.Controls.Add(Me.txtReceiverName)
        Me.KryptonPanel6.Controls.Add(Me.txtSenderName)
        Me.KryptonPanel6.Controls.Add(Me.txtSenderId)
        Me.KryptonPanel6.Controls.Add(Me.txtReceiverId)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel31)
        Me.KryptonPanel6.Controls.Add(Me.txtAccNum)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel30)
        Me.KryptonPanel6.Controls.Add(Me.cboTransType)
        Me.KryptonPanel6.Controls.Add(Me.cboBank)
        Me.KryptonPanel6.Controls.Add(Me.cboVersion)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel29)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel28)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel27)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel26)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel25)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel24)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel23)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel22)
        Me.KryptonPanel6.Controls.Add(Me.KryptonPanel21)
        Me.KryptonPanel6.Controls.Add(Me.DataGridView1)
        Me.KryptonPanel6.Controls.Add(Me.sProcessDate)
        Me.KryptonPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(569, 284)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 0
        '
        'txtCurrency
        '
        Me.txtCurrency.BackColor = System.Drawing.Color.White
        Me.txtCurrency.ForeColor = System.Drawing.Color.Black
        Me.txtCurrency.Location = New System.Drawing.Point(171, 244)
        Me.txtCurrency.MaxLength = 3
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(69, 20)
        Me.txtCurrency.TabIndex = 0
        Me.txtCurrency.Text = "USD"
        '
        'txtPackageName
        '
        Me.txtPackageName.BackColor = System.Drawing.Color.White
        Me.txtPackageName.ForeColor = System.Drawing.Color.Black
        Me.txtPackageName.Location = New System.Drawing.Point(171, 222)
        Me.txtPackageName.MaxLength = 30
        Me.txtPackageName.Name = "txtPackageName"
        Me.txtPackageName.Size = New System.Drawing.Size(359, 20)
        Me.txtPackageName.TabIndex = 53
        '
        'txtReceiverName
        '
        Me.txtReceiverName.BackColor = System.Drawing.Color.White
        Me.txtReceiverName.ForeColor = System.Drawing.Color.Black
        Me.txtReceiverName.Location = New System.Drawing.Point(171, 200)
        Me.txtReceiverName.MaxLength = 30
        Me.txtReceiverName.Name = "txtReceiverName"
        Me.txtReceiverName.Size = New System.Drawing.Size(359, 20)
        Me.txtReceiverName.TabIndex = 52
        '
        'txtSenderName
        '
        Me.txtSenderName.BackColor = System.Drawing.Color.White
        Me.txtSenderName.ForeColor = System.Drawing.Color.Black
        Me.txtSenderName.Location = New System.Drawing.Point(171, 178)
        Me.txtSenderName.MaxLength = 30
        Me.txtSenderName.Name = "txtSenderName"
        Me.txtSenderName.Size = New System.Drawing.Size(359, 20)
        Me.txtSenderName.TabIndex = 51
        '
        'txtSenderId
        '
        Me.txtSenderId.BackColor = System.Drawing.Color.White
        Me.txtSenderId.ForeColor = System.Drawing.Color.Black
        Me.txtSenderId.Location = New System.Drawing.Point(171, 111)
        Me.txtSenderId.MaxLength = 9
        Me.txtSenderId.Name = "txtSenderId"
        Me.txtSenderId.Size = New System.Drawing.Size(127, 20)
        Me.txtSenderId.TabIndex = 50
        '
        'txtReceiverId
        '
        Me.txtReceiverId.BackColor = System.Drawing.Color.White
        Me.txtReceiverId.ForeColor = System.Drawing.Color.Black
        Me.txtReceiverId.Location = New System.Drawing.Point(171, 133)
        Me.txtReceiverId.MaxLength = 9
        Me.txtReceiverId.Name = "txtReceiverId"
        Me.txtReceiverId.Size = New System.Drawing.Size(127, 20)
        Me.txtReceiverId.TabIndex = 49
        '
        'KryptonPanel31
        '
        Me.KryptonPanel31.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel31.Controls.Add(Me.KryptonLabel18)
        Me.KryptonPanel31.Controls.Add(Me.KryptonBorderEdge42)
        Me.KryptonPanel31.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel31.Location = New System.Drawing.Point(19, 133)
        Me.KryptonPanel31.Name = "KryptonPanel31"
        Me.KryptonPanel31.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel31.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel31.TabIndex = 48
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.BackColor = System.Drawing.Color.White
        Me.KryptonLabel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel18.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel18.TabIndex = 1
        Me.KryptonLabel18.Values.Text = "Receiver ID"
        '
        'KryptonBorderEdge42
        '
        Me.KryptonBorderEdge42.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge42.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge42.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge42.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge42.Name = "KryptonBorderEdge42"
        Me.KryptonBorderEdge42.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge42.Text = "KryptonBorderEdge42"
        '
        'txtAccNum
        '
        Me.txtAccNum.BackColor = System.Drawing.Color.White
        Me.txtAccNum.ForeColor = System.Drawing.Color.Black
        Me.txtAccNum.Location = New System.Drawing.Point(171, 89)
        Me.txtAccNum.MaxLength = 15
        Me.txtAccNum.Name = "txtAccNum"
        Me.txtAccNum.Size = New System.Drawing.Size(359, 20)
        Me.txtAccNum.TabIndex = 47
        '
        'KryptonPanel30
        '
        Me.KryptonPanel30.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel30.Controls.Add(Me.KryptonLabel17)
        Me.KryptonPanel30.Controls.Add(Me.KryptonBorderEdge41)
        Me.KryptonPanel30.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel30.Location = New System.Drawing.Point(19, 43)
        Me.KryptonPanel30.Name = "KryptonPanel30"
        Me.KryptonPanel30.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel30.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel30.TabIndex = 46
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.BackColor = System.Drawing.Color.White
        Me.KryptonLabel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel17.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel17.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel17.TabIndex = 1
        Me.KryptonLabel17.Values.Text = "File version"
        '
        'KryptonBorderEdge41
        '
        Me.KryptonBorderEdge41.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge41.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge41.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge41.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge41.Name = "KryptonBorderEdge41"
        Me.KryptonBorderEdge41.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge41.Text = "KryptonBorderEdge41"
        '
        'cboTransType
        '
        Me.cboTransType.BackColor = System.Drawing.Color.White
        Me.cboTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransType.DropDownWidth = 359
        Me.cboTransType.ForeColor = System.Drawing.Color.Black
        Me.cboTransType.Items.AddRange(New Object() {"SALARY DEPOSITS", "PAYORD CREDITS", "DEBMUL DEBITS"})
        Me.cboTransType.Location = New System.Drawing.Point(171, 155)
        Me.cboTransType.Name = "cboTransType"
        Me.cboTransType.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboTransType.Size = New System.Drawing.Size(359, 21)
        Me.cboTransType.TabIndex = 45
        '
        'cboBank
        '
        Me.cboBank.BackColor = System.Drawing.Color.White
        Me.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBank.DropDownWidth = 359
        Me.cboBank.ForeColor = System.Drawing.Color.Black
        Me.cboBank.Location = New System.Drawing.Point(171, 66)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboBank.Size = New System.Drawing.Size(359, 21)
        Me.cboBank.TabIndex = 44
        '
        'cboVersion
        '
        Me.cboVersion.BackColor = System.Drawing.Color.White
        Me.cboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVersion.DropDownWidth = 127
        Me.cboVersion.ForeColor = System.Drawing.Color.Black
        Me.cboVersion.Items.AddRange(New Object() {"Version 3", "Version 4"})
        Me.cboVersion.Location = New System.Drawing.Point(171, 43)
        Me.cboVersion.Name = "cboVersion"
        Me.cboVersion.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboVersion.Size = New System.Drawing.Size(127, 21)
        Me.cboVersion.TabIndex = 43
        '
        'KryptonPanel29
        '
        Me.KryptonPanel29.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel29.Controls.Add(Me.KryptonLabel16)
        Me.KryptonPanel29.Controls.Add(Me.KryptonBorderEdge40)
        Me.KryptonPanel29.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel29.Location = New System.Drawing.Point(19, 244)
        Me.KryptonPanel29.Name = "KryptonPanel29"
        Me.KryptonPanel29.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel29.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel29.TabIndex = 42
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.BackColor = System.Drawing.Color.White
        Me.KryptonLabel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel16.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel16.TabIndex = 1
        Me.KryptonLabel16.Values.Text = "Currency"
        '
        'KryptonBorderEdge40
        '
        Me.KryptonBorderEdge40.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge40.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge40.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge40.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge40.Name = "KryptonBorderEdge40"
        Me.KryptonBorderEdge40.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge40.Text = "KryptonBorderEdge40"
        '
        'KryptonPanel28
        '
        Me.KryptonPanel28.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel28.Controls.Add(Me.KryptonLabel15)
        Me.KryptonPanel28.Controls.Add(Me.KryptonBorderEdge39)
        Me.KryptonPanel28.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel28.Location = New System.Drawing.Point(19, 222)
        Me.KryptonPanel28.Name = "KryptonPanel28"
        Me.KryptonPanel28.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel28.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel28.TabIndex = 41
        '
        'KryptonLabel15
        '
        Me.KryptonLabel15.BackColor = System.Drawing.Color.White
        Me.KryptonLabel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel15.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel15.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel15.Name = "KryptonLabel15"
        Me.KryptonLabel15.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel15.TabIndex = 1
        Me.KryptonLabel15.Values.Text = "Package name"
        '
        'KryptonBorderEdge39
        '
        Me.KryptonBorderEdge39.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge39.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge39.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge39.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge39.Name = "KryptonBorderEdge39"
        Me.KryptonBorderEdge39.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge39.Text = "KryptonBorderEdge39"
        '
        'KryptonPanel27
        '
        Me.KryptonPanel27.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel27.Controls.Add(Me.KryptonLabel14)
        Me.KryptonPanel27.Controls.Add(Me.KryptonBorderEdge38)
        Me.KryptonPanel27.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel27.Location = New System.Drawing.Point(19, 200)
        Me.KryptonPanel27.Name = "KryptonPanel27"
        Me.KryptonPanel27.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel27.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel27.TabIndex = 40
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.BackColor = System.Drawing.Color.White
        Me.KryptonLabel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel14.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel14.TabIndex = 1
        Me.KryptonLabel14.Values.Text = "Receiver name"
        '
        'KryptonBorderEdge38
        '
        Me.KryptonBorderEdge38.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge38.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge38.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge38.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge38.Name = "KryptonBorderEdge38"
        Me.KryptonBorderEdge38.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge38.Text = "KryptonBorderEdge38"
        '
        'KryptonPanel26
        '
        Me.KryptonPanel26.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel26.Controls.Add(Me.KryptonLabel13)
        Me.KryptonPanel26.Controls.Add(Me.KryptonBorderEdge37)
        Me.KryptonPanel26.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel26.Location = New System.Drawing.Point(19, 177)
        Me.KryptonPanel26.Name = "KryptonPanel26"
        Me.KryptonPanel26.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel26.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel26.TabIndex = 39
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.BackColor = System.Drawing.Color.White
        Me.KryptonLabel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel13.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel13.TabIndex = 1
        Me.KryptonLabel13.Values.Text = "Sender name"
        '
        'KryptonBorderEdge37
        '
        Me.KryptonBorderEdge37.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge37.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge37.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge37.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge37.Name = "KryptonBorderEdge37"
        Me.KryptonBorderEdge37.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge37.Text = "KryptonBorderEdge37"
        '
        'KryptonPanel25
        '
        Me.KryptonPanel25.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel25.Controls.Add(Me.KryptonLabel12)
        Me.KryptonPanel25.Controls.Add(Me.KryptonBorderEdge36)
        Me.KryptonPanel25.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel25.Location = New System.Drawing.Point(19, 155)
        Me.KryptonPanel25.Name = "KryptonPanel25"
        Me.KryptonPanel25.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel25.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel25.TabIndex = 38
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.BackColor = System.Drawing.Color.White
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel12.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel12.TabIndex = 1
        Me.KryptonLabel12.Values.Text = "Transaction type"
        '
        'KryptonBorderEdge36
        '
        Me.KryptonBorderEdge36.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge36.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge36.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge36.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge36.Name = "KryptonBorderEdge36"
        Me.KryptonBorderEdge36.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge36.Text = "KryptonBorderEdge36"
        '
        'KryptonPanel24
        '
        Me.KryptonPanel24.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel24.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel24.Controls.Add(Me.KryptonBorderEdge35)
        Me.KryptonPanel24.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel24.Location = New System.Drawing.Point(19, 111)
        Me.KryptonPanel24.Name = "KryptonPanel24"
        Me.KryptonPanel24.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel24.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel24.TabIndex = 37
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.BackColor = System.Drawing.Color.White
        Me.KryptonLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel11.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel11.TabIndex = 1
        Me.KryptonLabel11.Values.Text = "Sender ID"
        '
        'KryptonBorderEdge35
        '
        Me.KryptonBorderEdge35.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge35.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge35.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge35.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge35.Name = "KryptonBorderEdge35"
        Me.KryptonBorderEdge35.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge35.Text = "KryptonBorderEdge35"
        '
        'KryptonPanel23
        '
        Me.KryptonPanel23.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel23.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel23.Controls.Add(Me.KryptonBorderEdge34)
        Me.KryptonPanel23.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel23.Location = New System.Drawing.Point(19, 89)
        Me.KryptonPanel23.Name = "KryptonPanel23"
        Me.KryptonPanel23.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel23.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel23.TabIndex = 36
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.BackColor = System.Drawing.Color.White
        Me.KryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel10.TabIndex = 1
        Me.KryptonLabel10.Values.Text = "Company bank account #"
        '
        'KryptonBorderEdge34
        '
        Me.KryptonBorderEdge34.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge34.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge34.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge34.Name = "KryptonBorderEdge34"
        Me.KryptonBorderEdge34.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge34.Text = "KryptonBorderEdge34"
        '
        'KryptonPanel22
        '
        Me.KryptonPanel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel22.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel22.Controls.Add(Me.KryptonBorderEdge33)
        Me.KryptonPanel22.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel22.Location = New System.Drawing.Point(19, 66)
        Me.KryptonPanel22.Name = "KryptonPanel22"
        Me.KryptonPanel22.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel22.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel22.TabIndex = 35
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.BackColor = System.Drawing.Color.White
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel9.TabIndex = 1
        Me.KryptonLabel9.Values.Text = "Company bank sort code"
        '
        'KryptonBorderEdge33
        '
        Me.KryptonBorderEdge33.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge33.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge33.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge33.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge33.Name = "KryptonBorderEdge33"
        Me.KryptonBorderEdge33.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge33.Text = "KryptonBorderEdge33"
        '
        'KryptonPanel21
        '
        Me.KryptonPanel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel21.Controls.Add(Me.KryptonLabel8)
        Me.KryptonPanel21.Controls.Add(Me.KryptonBorderEdge32)
        Me.KryptonPanel21.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel21.Location = New System.Drawing.Point(19, 20)
        Me.KryptonPanel21.Name = "KryptonPanel21"
        Me.KryptonPanel21.Size = New System.Drawing.Size(151, 21)
        Me.KryptonPanel21.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel21.TabIndex = 34
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.BackColor = System.Drawing.Color.White
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel8.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(151, 20)
        Me.KryptonLabel8.TabIndex = 1
        Me.KryptonLabel8.Values.Text = "Process date"
        '
        'KryptonBorderEdge32
        '
        Me.KryptonBorderEdge32.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge32.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge32.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge32.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge32.Name = "KryptonBorderEdge32"
        Me.KryptonBorderEdge32.Size = New System.Drawing.Size(151, 1)
        Me.KryptonBorderEdge32.Text = "KryptonBorderEdge32"
        '
        'DataGridView1
        '
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DataGridView1.Location = New System.Drawing.Point(304, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(239, 28)
        Me.DataGridView1.TabIndex = 22
        Me.DataGridView1.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "EMPLOYEE NAMES"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "BANK"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "BANK NAME"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "|ACC.NO"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "AMOUNT"
        Me.Column7.Name = "Column7"
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.XtraTabPage3.Controls.Add(Me.KryptonPanel3)
        Me.XtraTabPage3.ForeColor = System.Drawing.Color.Black
        Me.XtraTabPage3.Location = New System.Drawing.Point(4, 22)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(598, 343)
        Me.XtraTabPage3.TabIndex = 2
        Me.XtraTabPage3.Text = "Banks to Exclude"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.optUncheckAll)
        Me.KryptonPanel3.Controls.Add(Me.optCheckAll)
        Me.KryptonPanel3.Controls.Add(Me.btnNext1)
        Me.KryptonPanel3.Controls.Add(Me.btnBack1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(598, 343)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel3.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel3.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel3.TabIndex = 3
        '
        'optUncheckAll
        '
        Me.optUncheckAll.BackColor = System.Drawing.Color.White
        Me.optUncheckAll.ForeColor = System.Drawing.Color.Black
        Me.optUncheckAll.Location = New System.Drawing.Point(94, 301)
        Me.optUncheckAll.Name = "optUncheckAll"
        Me.optUncheckAll.Size = New System.Drawing.Size(86, 20)
        Me.optUncheckAll.TabIndex = 27
        Me.optUncheckAll.Values.Text = "Uncheck All"
        '
        'optCheckAll
        '
        Me.optCheckAll.BackColor = System.Drawing.Color.White
        Me.optCheckAll.ForeColor = System.Drawing.Color.Black
        Me.optCheckAll.Location = New System.Drawing.Point(15, 301)
        Me.optCheckAll.Name = "optCheckAll"
        Me.optCheckAll.Size = New System.Drawing.Size(73, 20)
        Me.optCheckAll.TabIndex = 26
        Me.optCheckAll.Values.Text = "Check All"
        '
        'btnNext1
        '
        Me.btnNext1.BackColor = System.Drawing.Color.White
        Me.btnNext1.ForeColor = System.Drawing.Color.Black
        Me.btnNext1.Location = New System.Drawing.Point(511, 301)
        Me.btnNext1.Name = "btnNext1"
        Me.btnNext1.Size = New System.Drawing.Size(75, 25)
        Me.btnNext1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnNext1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnNext1.StateCommon.Back.ColorAngle = 100.0!
        Me.btnNext1.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnNext1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnNext1.StateCommon.Border.Rounding = 0
        Me.btnNext1.TabIndex = 25
        Me.btnNext1.Values.Text = "Next >"
        '
        'btnBack1
        '
        Me.btnBack1.BackColor = System.Drawing.Color.White
        Me.btnBack1.ForeColor = System.Drawing.Color.Black
        Me.btnBack1.Location = New System.Drawing.Point(431, 301)
        Me.btnBack1.Name = "btnBack1"
        Me.btnBack1.Size = New System.Drawing.Size(75, 25)
        Me.btnBack1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnBack1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnBack1.StateCommon.Back.ColorAngle = 100.0!
        Me.btnBack1.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnBack1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnBack1.StateCommon.Border.Rounding = 0
        Me.btnBack1.TabIndex = 24
        Me.btnBack1.Values.Text = "< Back"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.White
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lstAvailableBanks)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(571, 283)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "Check out the banks you want to be excluded"
        Me.KryptonGroupBox1.Values.Heading = "Check out the banks you want to be excluded"
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.XtraTabPage4.Controls.Add(Me.KryptonPanel4)
        Me.XtraTabPage4.ForeColor = System.Drawing.Color.Black
        Me.XtraTabPage4.Location = New System.Drawing.Point(4, 22)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(598, 343)
        Me.XtraTabPage4.TabIndex = 3
        Me.XtraTabPage4.Text = "Extract File Parameters"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.chkOutputExcel)
        Me.KryptonPanel4.Controls.Add(Me.KryptonGroup2)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(598, 343)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel4.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel4.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel4.TabIndex = 5
        '
        'chkOutputExcel
        '
        Me.chkOutputExcel.BackColor = System.Drawing.Color.White
        Me.chkOutputExcel.ForeColor = System.Drawing.Color.Black
        Me.chkOutputExcel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkOutputExcel.Location = New System.Drawing.Point(47, 401)
        Me.chkOutputExcel.Name = "chkOutputExcel"
        Me.chkOutputExcel.Size = New System.Drawing.Size(131, 20)
        Me.chkOutputExcel.TabIndex = 27
        Me.chkOutputExcel.Text = "Generate Excel File?"
        Me.chkOutputExcel.Values.Text = "Generate Excel File?"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.BackColor = System.Drawing.Color.White
        Me.btnSaveSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSaveSettings.Location = New System.Drawing.Point(369, 388)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(91, 25)
        Me.btnSaveSettings.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnSaveSettings.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSaveSettings.StateCommon.Back.ColorAngle = 100.0!
        Me.btnSaveSettings.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnSaveSettings.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSaveSettings.StateCommon.Border.Rounding = 0
        Me.btnSaveSettings.TabIndex = 26
        Me.btnSaveSettings.Values.Text = "&Save Settings"
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.White
        Me.btnProcess.ForeColor = System.Drawing.Color.Black
        Me.btnProcess.Location = New System.Drawing.Point(467, 388)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 25)
        Me.btnProcess.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnProcess.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnProcess.StateCommon.Back.ColorAngle = 100.0!
        Me.btnProcess.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnProcess.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnProcess.StateCommon.Border.Rounding = 0
        Me.btnProcess.TabIndex = 25
        Me.btnProcess.Values.Text = "&Finish"
        '
        'btn
        '
        Me.btn.BackColor = System.Drawing.Color.White
        Me.btn.ForeColor = System.Drawing.Color.Black
        Me.btn.Location = New System.Drawing.Point(482, 272)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(75, 25)
        Me.btn.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btn.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btn.StateCommon.Back.ColorAngle = 100.0!
        Me.btn.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btn.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btn.StateCommon.Border.Rounding = 0
        Me.btn.TabIndex = 24
        Me.btn.Values.Text = "< Back"
        '
        'KryptonGroup2
        '
        Me.KryptonGroup2.BackColor = System.Drawing.Color.White
        Me.KryptonGroup2.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup2.Location = New System.Drawing.Point(13, 14)
        Me.KryptonGroup2.Name = "KryptonGroup2"
        '
        'KryptonGroup2.Panel
        '
        Me.KryptonGroup2.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroup2.Panel.Controls.Add(Me.KryptonPanel5)
        Me.KryptonGroup2.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup2.Size = New System.Drawing.Size(569, 310)
        Me.KryptonGroup2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroup2.TabIndex = 5
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.TabControl2)
        Me.KryptonPanel5.Controls.Add(Me.btn)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Padding = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel5.Size = New System.Drawing.Size(567, 308)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 0
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.ForeColor = System.Drawing.Color.Black
        Me.TabControl2.Location = New System.Drawing.Point(6, 6)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(555, 260)
        Me.TabControl2.TabIndex = 54
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.KryptonPanel32)
        Me.TabPage1.ForeColor = System.Drawing.Color.Black
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(547, 234)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Extract Codes"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(19, 26)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 33
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Net pad code"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonPanel19
        '
        Me.KryptonPanel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel19.Controls.Add(Me.lblSplit5Description)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge28)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge29)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge30)
        Me.KryptonPanel19.Controls.Add(Me.KryptonBorderEdge31)
        Me.KryptonPanel19.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel19.Location = New System.Drawing.Point(205, 145)
        Me.KryptonPanel19.Name = "KryptonPanel19"
        Me.KryptonPanel19.Size = New System.Drawing.Size(315, 22)
        Me.KryptonPanel19.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel19.TabIndex = 53
        '
        'lblSplit5Description
        '
        Me.lblSplit5Description.BackColor = System.Drawing.Color.White
        Me.lblSplit5Description.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSplit5Description.ForeColor = System.Drawing.Color.Black
        Me.lblSplit5Description.Location = New System.Drawing.Point(1, 1)
        Me.lblSplit5Description.Name = "lblSplit5Description"
        Me.lblSplit5Description.Size = New System.Drawing.Size(313, 20)
        Me.lblSplit5Description.TabIndex = 4
        Me.lblSplit5Description.Values.Text = ""
        '
        'KryptonBorderEdge28
        '
        Me.KryptonBorderEdge28.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge28.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge28.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge28.Location = New System.Drawing.Point(314, 1)
        Me.KryptonBorderEdge28.Name = "KryptonBorderEdge28"
        Me.KryptonBorderEdge28.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge28.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge28.Text = "KryptonBorderEdge28"
        '
        'KryptonBorderEdge29
        '
        Me.KryptonBorderEdge29.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge29.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge29.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge29.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge29.Name = "KryptonBorderEdge29"
        Me.KryptonBorderEdge29.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge29.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge29.Text = "KryptonBorderEdge29"
        '
        'KryptonBorderEdge30
        '
        Me.KryptonBorderEdge30.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge30.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge30.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge30.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge30.Name = "KryptonBorderEdge30"
        Me.KryptonBorderEdge30.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge30.Text = "KryptonBorderEdge30"
        '
        'KryptonBorderEdge31
        '
        Me.KryptonBorderEdge31.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge31.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge31.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge31.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge31.Name = "KryptonBorderEdge31"
        Me.KryptonBorderEdge31.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge31.Text = "KryptonBorderEdge31"
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(19, 74)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel7.TabIndex = 31
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Split code 2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel18
        '
        Me.KryptonPanel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel18.Controls.Add(Me.lblSplit4Description)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge24)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge25)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge26)
        Me.KryptonPanel18.Controls.Add(Me.KryptonBorderEdge27)
        Me.KryptonPanel18.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel18.Location = New System.Drawing.Point(205, 121)
        Me.KryptonPanel18.Name = "KryptonPanel18"
        Me.KryptonPanel18.Size = New System.Drawing.Size(315, 22)
        Me.KryptonPanel18.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel18.TabIndex = 52
        '
        'lblSplit4Description
        '
        Me.lblSplit4Description.BackColor = System.Drawing.Color.White
        Me.lblSplit4Description.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSplit4Description.ForeColor = System.Drawing.Color.Black
        Me.lblSplit4Description.Location = New System.Drawing.Point(1, 1)
        Me.lblSplit4Description.Name = "lblSplit4Description"
        Me.lblSplit4Description.Size = New System.Drawing.Size(313, 20)
        Me.lblSplit4Description.TabIndex = 4
        Me.lblSplit4Description.Values.Text = ""
        '
        'KryptonBorderEdge24
        '
        Me.KryptonBorderEdge24.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge24.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge24.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge24.Location = New System.Drawing.Point(314, 1)
        Me.KryptonBorderEdge24.Name = "KryptonBorderEdge24"
        Me.KryptonBorderEdge24.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge24.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge24.Text = "KryptonBorderEdge24"
        '
        'KryptonBorderEdge25
        '
        Me.KryptonBorderEdge25.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge25.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge25.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge25.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge25.Name = "KryptonBorderEdge25"
        Me.KryptonBorderEdge25.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge25.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge25.Text = "KryptonBorderEdge25"
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge27.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(19, 50)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 32
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Split code 1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonPanel17
        '
        Me.KryptonPanel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel17.Controls.Add(Me.lblSplit3Description)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge20)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge21)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel17.Controls.Add(Me.KryptonBorderEdge23)
        Me.KryptonPanel17.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel17.Location = New System.Drawing.Point(205, 97)
        Me.KryptonPanel17.Name = "KryptonPanel17"
        Me.KryptonPanel17.Size = New System.Drawing.Size(315, 22)
        Me.KryptonPanel17.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel17.TabIndex = 51
        '
        'lblSplit3Description
        '
        Me.lblSplit3Description.BackColor = System.Drawing.Color.White
        Me.lblSplit3Description.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSplit3Description.ForeColor = System.Drawing.Color.Black
        Me.lblSplit3Description.Location = New System.Drawing.Point(1, 1)
        Me.lblSplit3Description.Name = "lblSplit3Description"
        Me.lblSplit3Description.Size = New System.Drawing.Size(313, 20)
        Me.lblSplit3Description.TabIndex = 4
        Me.lblSplit3Description.Values.Text = ""
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(314, 1)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonBorderEdge21
        '
        Me.KryptonBorderEdge21.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge21.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge21.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge21.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge21.Name = "KryptonBorderEdge21"
        Me.KryptonBorderEdge21.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge21.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge21.Text = "KryptonBorderEdge21"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge23
        '
        Me.KryptonBorderEdge23.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge23.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge23.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge23.Name = "KryptonBorderEdge23"
        Me.KryptonBorderEdge23.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge23.Text = "KryptonBorderEdge23"
        '
        'KryptonPanel11
        '
        Me.KryptonPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel11.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel11.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel11.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel11.Location = New System.Drawing.Point(19, 122)
        Me.KryptonPanel11.Name = "KryptonPanel11"
        Me.KryptonPanel11.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel11.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel11.TabIndex = 36
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.White
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Split code 4"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel16
        '
        Me.KryptonPanel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel16.Controls.Add(Me.lblSplit2Description)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge17)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge18)
        Me.KryptonPanel16.Controls.Add(Me.KryptonBorderEdge19)
        Me.KryptonPanel16.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel16.Location = New System.Drawing.Point(205, 72)
        Me.KryptonPanel16.Name = "KryptonPanel16"
        Me.KryptonPanel16.Size = New System.Drawing.Size(315, 22)
        Me.KryptonPanel16.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel16.TabIndex = 50
        '
        'lblSplit2Description
        '
        Me.lblSplit2Description.BackColor = System.Drawing.Color.White
        Me.lblSplit2Description.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSplit2Description.ForeColor = System.Drawing.Color.Black
        Me.lblSplit2Description.Location = New System.Drawing.Point(1, 1)
        Me.lblSplit2Description.Name = "lblSplit2Description"
        Me.lblSplit2Description.Size = New System.Drawing.Size(313, 20)
        Me.lblSplit2Description.TabIndex = 4
        Me.lblSplit2Description.Values.Text = ""
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge16.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(314, 1)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonBorderEdge17
        '
        Me.KryptonBorderEdge17.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge17.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge17.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge17.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge17.Name = "KryptonBorderEdge17"
        Me.KryptonBorderEdge17.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge17.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge17.Text = "KryptonBorderEdge17"
        '
        'KryptonBorderEdge18
        '
        Me.KryptonBorderEdge18.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge18.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge18.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge18.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge18.Name = "KryptonBorderEdge18"
        Me.KryptonBorderEdge18.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge18.Text = "KryptonBorderEdge18"
        '
        'KryptonBorderEdge19
        '
        Me.KryptonBorderEdge19.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge19.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge19.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge19.Name = "KryptonBorderEdge19"
        Me.KryptonBorderEdge19.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge19.Text = "KryptonBorderEdge19"
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel10.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel10.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel10.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel10.Location = New System.Drawing.Point(19, 98)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel10.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel10.TabIndex = 37
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.White
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Split code 3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel15
        '
        Me.KryptonPanel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel15.Controls.Add(Me.lblSplit1Description)
        Me.KryptonPanel15.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel15.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel15.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel15.Controls.Add(Me.KryptonBorderEdge15)
        Me.KryptonPanel15.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel15.Location = New System.Drawing.Point(205, 48)
        Me.KryptonPanel15.Name = "KryptonPanel15"
        Me.KryptonPanel15.Size = New System.Drawing.Size(315, 22)
        Me.KryptonPanel15.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel15.TabIndex = 49
        '
        'lblSplit1Description
        '
        Me.lblSplit1Description.BackColor = System.Drawing.Color.White
        Me.lblSplit1Description.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSplit1Description.ForeColor = System.Drawing.Color.Black
        Me.lblSplit1Description.Location = New System.Drawing.Point(1, 1)
        Me.lblSplit1Description.Name = "lblSplit1Description"
        Me.lblSplit1Description.Size = New System.Drawing.Size(313, 20)
        Me.lblSplit1Description.TabIndex = 4
        Me.lblSplit1Description.Values.Text = ""
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(314, 1)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge13.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge14.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'KryptonBorderEdge15
        '
        Me.KryptonBorderEdge15.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge15.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge15.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge15.Name = "KryptonBorderEdge15"
        Me.KryptonBorderEdge15.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge15.Text = "KryptonBorderEdge15"
        '
        'KryptonPanel12
        '
        Me.KryptonPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel12.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel12.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel12.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel12.Location = New System.Drawing.Point(19, 172)
        Me.KryptonPanel12.Name = "KryptonPanel12"
        Me.KryptonPanel12.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel12.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel12.TabIndex = 38
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.White
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "File name"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel14.Controls.Add(Me.lblNetDescription)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel14.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel14.Location = New System.Drawing.Point(205, 24)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(315, 22)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 48
        '
        'lblNetDescription
        '
        Me.lblNetDescription.BackColor = System.Drawing.Color.White
        Me.lblNetDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNetDescription.ForeColor = System.Drawing.Color.Black
        Me.lblNetDescription.Location = New System.Drawing.Point(1, 1)
        Me.lblNetDescription.Name = "lblNetDescription"
        Me.lblNetDescription.Size = New System.Drawing.Size(313, 20)
        Me.lblNetDescription.TabIndex = 4
        Me.lblNetDescription.Values.Text = ""
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(314, 1)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(315, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(19, 146)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(88, 21)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 40
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.BackColor = System.Drawing.Color.White
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel7.TabIndex = 1
        Me.KryptonLabel7.Values.Text = "Split code 5"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(88, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'txtDir
        '
        Me.txtDir.BackColor = System.Drawing.Color.White
        Me.txtDir.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnBrowse})
        Me.txtDir.ForeColor = System.Drawing.Color.Black
        Me.txtDir.Location = New System.Drawing.Point(110, 169)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(411, 24)
        Me.txtDir.TabIndex = 47
        '
        'btnBrowse
        '
        Me.btnBrowse.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.ListItem
        Me.btnBrowse.Text = "Browse ..."
        Me.btnBrowse.UniqueName = "9CA05339E0EB4C174CBDF20B5252EF7C"
        '
        'cboNetSalary
        '
        Me.cboNetSalary.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboNetSalary.ArrowColor = System.Drawing.Color.Black
        Me.cboNetSalary.BackColor = System.Drawing.Color.White
        Me.cboNetSalary.BindedControl = Nothing
        Me.cboNetSalary.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboNetSalary.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboNetSalary.ColumnNum = 1
        Me.cboNetSalary.ColumnWidth = "121"
        Me.cboNetSalary.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboNetSalary.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboNetSalary.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboNetSalary.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboNetSalary.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboNetSalary.DisplayMember = "Text"
        Me.cboNetSalary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboNetSalary.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboNetSalary.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboNetSalary.DropDownForeColor = System.Drawing.Color.Black
        Me.cboNetSalary.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboNetSalary.DropDownWidth = 141
        Me.cboNetSalary.ForeColor = System.Drawing.Color.Black
        Me.cboNetSalary.GridLineColor = System.Drawing.Color.LightGray
        Me.cboNetSalary.GridLineHorizontal = False
        Me.cboNetSalary.GridLineVertical = False
        Me.cboNetSalary.HighlightBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboNetSalary.HighlightBorderOnMouseEvents = True
        Me.cboNetSalary.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboNetSalary.Location = New System.Drawing.Point(110, 24)
        Me.cboNetSalary.ManagingFastMouseMoving = True
        Me.cboNetSalary.ManagingFastMouseMovingInterval = 30
        Me.cboNetSalary.Name = "cboNetSalary"
        Me.cboNetSalary.NormalBorderColor = System.Drawing.Color.DimGray
        Me.cboNetSalary.SelectedItem = Nothing
        Me.cboNetSalary.SelectedValue = Nothing
        Me.cboNetSalary.Size = New System.Drawing.Size(89, 23)
        Me.cboNetSalary.TabIndex = 41
        '
        'cboSplitPayCode5
        '
        Me.cboSplitPayCode5.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode5.ArrowColor = System.Drawing.Color.Black
        Me.cboSplitPayCode5.BackColor = System.Drawing.Color.White
        Me.cboSplitPayCode5.BindedControl = Nothing
        Me.cboSplitPayCode5.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSplitPayCode5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSplitPayCode5.ColumnNum = 1
        Me.cboSplitPayCode5.ColumnWidth = "121"
        Me.cboSplitPayCode5.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode5.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode5.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode5.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSplitPayCode5.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSplitPayCode5.DisplayMember = "Text"
        Me.cboSplitPayCode5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSplitPayCode5.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSplitPayCode5.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSplitPayCode5.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode5.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSplitPayCode5.DropDownWidth = 141
        Me.cboSplitPayCode5.ForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode5.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode5.GridLineHorizontal = False
        Me.cboSplitPayCode5.GridLineVertical = False
        Me.cboSplitPayCode5.HighlightBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboSplitPayCode5.HighlightBorderOnMouseEvents = True
        Me.cboSplitPayCode5.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSplitPayCode5.Location = New System.Drawing.Point(110, 144)
        Me.cboSplitPayCode5.ManagingFastMouseMoving = True
        Me.cboSplitPayCode5.ManagingFastMouseMovingInterval = 30
        Me.cboSplitPayCode5.Name = "cboSplitPayCode5"
        Me.cboSplitPayCode5.NormalBorderColor = System.Drawing.Color.DimGray
        Me.cboSplitPayCode5.SelectedItem = Nothing
        Me.cboSplitPayCode5.SelectedValue = Nothing
        Me.cboSplitPayCode5.Size = New System.Drawing.Size(89, 23)
        Me.cboSplitPayCode5.TabIndex = 46
        '
        'cboSplitPayCode1
        '
        Me.cboSplitPayCode1.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode1.ArrowColor = System.Drawing.Color.Black
        Me.cboSplitPayCode1.BackColor = System.Drawing.Color.White
        Me.cboSplitPayCode1.BindedControl = Nothing
        Me.cboSplitPayCode1.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSplitPayCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSplitPayCode1.ColumnNum = 1
        Me.cboSplitPayCode1.ColumnWidth = "121"
        Me.cboSplitPayCode1.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode1.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode1.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode1.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSplitPayCode1.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSplitPayCode1.DisplayMember = "Text"
        Me.cboSplitPayCode1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSplitPayCode1.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSplitPayCode1.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSplitPayCode1.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode1.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSplitPayCode1.DropDownWidth = 141
        Me.cboSplitPayCode1.ForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode1.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode1.GridLineHorizontal = False
        Me.cboSplitPayCode1.GridLineVertical = False
        Me.cboSplitPayCode1.HighlightBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboSplitPayCode1.HighlightBorderOnMouseEvents = True
        Me.cboSplitPayCode1.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSplitPayCode1.Location = New System.Drawing.Point(110, 48)
        Me.cboSplitPayCode1.ManagingFastMouseMoving = True
        Me.cboSplitPayCode1.ManagingFastMouseMovingInterval = 30
        Me.cboSplitPayCode1.Name = "cboSplitPayCode1"
        Me.cboSplitPayCode1.NormalBorderColor = System.Drawing.Color.DimGray
        Me.cboSplitPayCode1.SelectedItem = Nothing
        Me.cboSplitPayCode1.SelectedValue = Nothing
        Me.cboSplitPayCode1.Size = New System.Drawing.Size(89, 23)
        Me.cboSplitPayCode1.TabIndex = 42
        '
        'cboSplitPayCode4
        '
        Me.cboSplitPayCode4.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode4.ArrowColor = System.Drawing.Color.Black
        Me.cboSplitPayCode4.BackColor = System.Drawing.Color.White
        Me.cboSplitPayCode4.BindedControl = Nothing
        Me.cboSplitPayCode4.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSplitPayCode4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSplitPayCode4.ColumnNum = 1
        Me.cboSplitPayCode4.ColumnWidth = "121"
        Me.cboSplitPayCode4.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode4.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode4.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode4.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSplitPayCode4.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSplitPayCode4.DisplayMember = "Text"
        Me.cboSplitPayCode4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSplitPayCode4.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSplitPayCode4.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSplitPayCode4.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode4.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSplitPayCode4.DropDownWidth = 141
        Me.cboSplitPayCode4.ForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode4.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode4.GridLineHorizontal = False
        Me.cboSplitPayCode4.GridLineVertical = False
        Me.cboSplitPayCode4.HighlightBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboSplitPayCode4.HighlightBorderOnMouseEvents = True
        Me.cboSplitPayCode4.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSplitPayCode4.Location = New System.Drawing.Point(110, 120)
        Me.cboSplitPayCode4.ManagingFastMouseMoving = True
        Me.cboSplitPayCode4.ManagingFastMouseMovingInterval = 30
        Me.cboSplitPayCode4.Name = "cboSplitPayCode4"
        Me.cboSplitPayCode4.NormalBorderColor = System.Drawing.Color.DimGray
        Me.cboSplitPayCode4.SelectedItem = Nothing
        Me.cboSplitPayCode4.SelectedValue = Nothing
        Me.cboSplitPayCode4.Size = New System.Drawing.Size(89, 23)
        Me.cboSplitPayCode4.TabIndex = 45
        '
        'cboSplitPayCode2
        '
        Me.cboSplitPayCode2.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode2.ArrowColor = System.Drawing.Color.Black
        Me.cboSplitPayCode2.BackColor = System.Drawing.Color.White
        Me.cboSplitPayCode2.BindedControl = Nothing
        Me.cboSplitPayCode2.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSplitPayCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSplitPayCode2.ColumnNum = 1
        Me.cboSplitPayCode2.ColumnWidth = "121"
        Me.cboSplitPayCode2.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode2.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode2.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode2.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSplitPayCode2.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSplitPayCode2.DisplayMember = "Text"
        Me.cboSplitPayCode2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSplitPayCode2.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSplitPayCode2.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSplitPayCode2.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode2.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSplitPayCode2.DropDownWidth = 141
        Me.cboSplitPayCode2.ForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode2.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode2.GridLineHorizontal = False
        Me.cboSplitPayCode2.GridLineVertical = False
        Me.cboSplitPayCode2.HighlightBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboSplitPayCode2.HighlightBorderOnMouseEvents = True
        Me.cboSplitPayCode2.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSplitPayCode2.Location = New System.Drawing.Point(110, 72)
        Me.cboSplitPayCode2.ManagingFastMouseMoving = True
        Me.cboSplitPayCode2.ManagingFastMouseMovingInterval = 30
        Me.cboSplitPayCode2.Name = "cboSplitPayCode2"
        Me.cboSplitPayCode2.NormalBorderColor = System.Drawing.Color.DimGray
        Me.cboSplitPayCode2.SelectedItem = Nothing
        Me.cboSplitPayCode2.SelectedValue = Nothing
        Me.cboSplitPayCode2.Size = New System.Drawing.Size(89, 23)
        Me.cboSplitPayCode2.TabIndex = 43
        '
        'cboSplitPayCode3
        '
        Me.cboSplitPayCode3.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode3.ArrowColor = System.Drawing.Color.Black
        Me.cboSplitPayCode3.BackColor = System.Drawing.Color.White
        Me.cboSplitPayCode3.BindedControl = Nothing
        Me.cboSplitPayCode3.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSplitPayCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSplitPayCode3.ColumnNum = 1
        Me.cboSplitPayCode3.ColumnWidth = "121"
        Me.cboSplitPayCode3.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode3.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode3.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSplitPayCode3.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSplitPayCode3.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSplitPayCode3.DisplayMember = "Text"
        Me.cboSplitPayCode3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSplitPayCode3.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSplitPayCode3.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSplitPayCode3.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode3.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSplitPayCode3.DropDownWidth = 141
        Me.cboSplitPayCode3.ForeColor = System.Drawing.Color.Black
        Me.cboSplitPayCode3.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSplitPayCode3.GridLineHorizontal = False
        Me.cboSplitPayCode3.GridLineVertical = False
        Me.cboSplitPayCode3.HighlightBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboSplitPayCode3.HighlightBorderOnMouseEvents = True
        Me.cboSplitPayCode3.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSplitPayCode3.Location = New System.Drawing.Point(110, 96)
        Me.cboSplitPayCode3.ManagingFastMouseMoving = True
        Me.cboSplitPayCode3.ManagingFastMouseMovingInterval = 30
        Me.cboSplitPayCode3.Name = "cboSplitPayCode3"
        Me.cboSplitPayCode3.NormalBorderColor = System.Drawing.Color.DimGray
        Me.cboSplitPayCode3.SelectedItem = Nothing
        Me.cboSplitPayCode3.SelectedValue = Nothing
        Me.cboSplitPayCode3.Size = New System.Drawing.Size(89, 23)
        Me.cboSplitPayCode3.TabIndex = 44
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.KryptonPanel33)
        Me.TabPage2.ForeColor = System.Drawing.Color.Black
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(547, 234)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selective Extract"
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.BackColor = System.Drawing.Color.Transparent
        Me.optAll.Checked = True
        Me.optAll.ForeColor = System.Drawing.Color.Black
        Me.optAll.Location = New System.Drawing.Point(285, 23)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(95, 17)
        Me.optAll.TabIndex = 25
        Me.optAll.TabStop = True
        Me.optAll.Text = "All pay points"
        Me.optAll.UseVisualStyleBackColor = False
        '
        'optSelective
        '
        Me.optSelective.AutoSize = True
        Me.optSelective.BackColor = System.Drawing.Color.Transparent
        Me.optSelective.ForeColor = System.Drawing.Color.Black
        Me.optSelective.Location = New System.Drawing.Point(395, 23)
        Me.optSelective.Name = "optSelective"
        Me.optSelective.Size = New System.Drawing.Size(126, 17)
        Me.optSelective.TabIndex = 26
        Me.optSelective.Text = "Selective pay points"
        Me.optSelective.UseVisualStyleBackColor = False
        '
        'grpPaypoints
        '
        Me.grpPaypoints.BackColor = System.Drawing.Color.White
        Me.grpPaypoints.Enabled = False
        Me.grpPaypoints.ForeColor = System.Drawing.Color.Black
        Me.grpPaypoints.Location = New System.Drawing.Point(19, 46)
        Me.grpPaypoints.Name = "grpPaypoints"
        '
        'grpPaypoints.Panel
        '
        Me.grpPaypoints.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.grpPaypoints.Panel.Controls.Add(Me.chkPayPoints)
        Me.grpPaypoints.Panel.ForeColor = System.Drawing.Color.Black
        Me.grpPaypoints.Panel.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.grpPaypoints.Size = New System.Drawing.Size(502, 159)
        Me.grpPaypoints.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.grpPaypoints.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grpPaypoints.StateCommon.Border.Rounding = 0
        Me.grpPaypoints.TabIndex = 27
        Me.grpPaypoints.Text = "Available Pay Points"
        Me.grpPaypoints.Values.Heading = "Available Pay Points"
        '
        'chkPayPoints
        '
        Me.chkPayPoints.BackColor = System.Drawing.Color.White
        Me.chkPayPoints.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkPayPoints.ForeColor = System.Drawing.Color.Black
        Me.chkPayPoints.FormattingEnabled = True
        Me.chkPayPoints.Location = New System.Drawing.Point(5, 0)
        Me.chkPayPoints.Name = "chkPayPoints"
        Me.chkPayPoints.Size = New System.Drawing.Size(490, 131)
        Me.chkPayPoints.TabIndex = 0
        '
        'KryptonPanel32
        '
        Me.KryptonPanel32.Controls.Add(Me.cboNetSalary)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel32.Controls.Add(Me.cboSplitPayCode3)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel19)
        Me.KryptonPanel32.Controls.Add(Me.cboSplitPayCode2)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel7)
        Me.KryptonPanel32.Controls.Add(Me.cboSplitPayCode4)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel18)
        Me.KryptonPanel32.Controls.Add(Me.cboSplitPayCode1)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel32.Controls.Add(Me.cboSplitPayCode5)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel17)
        Me.KryptonPanel32.Controls.Add(Me.txtDir)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel11)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel13)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel16)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel14)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel12)
        Me.KryptonPanel32.Controls.Add(Me.KryptonPanel15)
        Me.KryptonPanel32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel32.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel32.Name = "KryptonPanel32"
        Me.KryptonPanel32.Size = New System.Drawing.Size(541, 228)
        Me.KryptonPanel32.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel32.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel32.TabIndex = 54
        '
        'KryptonPanel33
        '
        Me.KryptonPanel33.Controls.Add(Me.grpPaypoints)
        Me.KryptonPanel33.Controls.Add(Me.optAll)
        Me.KryptonPanel33.Controls.Add(Me.optSelective)
        Me.KryptonPanel33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel33.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel33.Name = "KryptonPanel33"
        Me.KryptonPanel33.Size = New System.Drawing.Size(541, 228)
        Me.KryptonPanel33.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel33.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel33.TabIndex = 28
        '
        'frmBankExtract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 425)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBankExtract"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bank File Parameter Definitions"
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroup3.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup3.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.KryptonPanel20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel20.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        CType(Me.KryptonGroup4.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup4.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup4.ResumeLayout(False)
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.KryptonPanel31, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel31.ResumeLayout(False)
        Me.KryptonPanel31.PerformLayout()
        CType(Me.KryptonPanel30, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel30.ResumeLayout(False)
        Me.KryptonPanel30.PerformLayout()
        CType(Me.cboTransType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel29, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel29.ResumeLayout(False)
        Me.KryptonPanel29.PerformLayout()
        CType(Me.KryptonPanel28, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel28.ResumeLayout(False)
        Me.KryptonPanel28.PerformLayout()
        CType(Me.KryptonPanel27, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel27.ResumeLayout(False)
        Me.KryptonPanel27.PerformLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel26.ResumeLayout(False)
        Me.KryptonPanel26.PerformLayout()
        CType(Me.KryptonPanel25, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel25.ResumeLayout(False)
        Me.KryptonPanel25.PerformLayout()
        CType(Me.KryptonPanel24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel24.ResumeLayout(False)
        Me.KryptonPanel24.PerformLayout()
        CType(Me.KryptonPanel23, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel23.ResumeLayout(False)
        Me.KryptonPanel23.PerformLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel22.ResumeLayout(False)
        Me.KryptonPanel22.PerformLayout()
        CType(Me.KryptonPanel21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel21.ResumeLayout(False)
        Me.KryptonPanel21.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.XtraTabPage4.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonGroup2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup2.ResumeLayout(False)
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel19.ResumeLayout(False)
        Me.KryptonPanel19.PerformLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel18.ResumeLayout(False)
        Me.KryptonPanel18.PerformLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.KryptonPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel17.ResumeLayout(False)
        Me.KryptonPanel17.PerformLayout()
        CType(Me.KryptonPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel11.ResumeLayout(False)
        Me.KryptonPanel11.PerformLayout()
        CType(Me.KryptonPanel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel16.ResumeLayout(False)
        Me.KryptonPanel16.PerformLayout()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.KryptonPanel10.PerformLayout()
        CType(Me.KryptonPanel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel15.ResumeLayout(False)
        Me.KryptonPanel15.PerformLayout()
        CType(Me.KryptonPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel12.ResumeLayout(False)
        Me.KryptonPanel12.PerformLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grpPaypoints.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPaypoints.Panel.ResumeLayout(False)
        CType(Me.grpPaypoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPaypoints.ResumeLayout(False)
        CType(Me.KryptonPanel32, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel32.ResumeLayout(False)
        Me.KryptonPanel32.PerformLayout()
        CType(Me.KryptonPanel33, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel33.ResumeLayout(False)
        Me.KryptonPanel33.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sProcessDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lstAvailableBanks As System.Windows.Forms.ListView
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ppDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroup2 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents XtraTabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents XtraTabPage2 As System.Windows.Forms.TabPage
    'Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents XtraTabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents XtraTabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents KryptonGroup3 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents btnNext As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroup4 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnExit As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNext1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnBack1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnProcess As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btn As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents optSelective As System.Windows.Forms.RadioButton
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents grpPaypoints As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents chkPayPoints As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSaveSettings As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents optUncheckAll As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optCheckAll As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents chkOutputExcel As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DataGridView1 As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel12 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel11 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboNetSalary As MTGCComboBox
    Friend WithEvents txtDir As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnBrowse As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents cboSplitPayCode5 As MTGCComboBox
    Friend WithEvents cboSplitPayCode4 As MTGCComboBox
    Friend WithEvents cboSplitPayCode3 As MTGCComboBox
    Friend WithEvents cboSplitPayCode2 As MTGCComboBox
    Friend WithEvents cboSplitPayCode1 As MTGCComboBox
    Friend WithEvents KryptonPanel19 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblSplit5Description As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge28 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge29 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge30 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge31 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel18 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblSplit4Description As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge24 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge25 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel17 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblSplit3Description As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge21 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge23 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel16 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblSplit2Description As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge17 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge18 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge19 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel15 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblSplit1Description As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge15 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblNetDescription As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel20 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel29 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge40 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel28 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel15 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge39 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel27 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge38 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel26 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge37 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel25 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge36 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel24 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge35 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel23 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge34 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel22 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge33 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel21 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge32 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboTransType As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboBank As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboVersion As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtCurrency As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtPackageName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtReceiverName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtSenderName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtSenderId As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtReceiverId As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel31 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge42 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtAccNum As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel30 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge41 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents KryptonBorderEdge46 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge45 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge44 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge43 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel32 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel33 As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
