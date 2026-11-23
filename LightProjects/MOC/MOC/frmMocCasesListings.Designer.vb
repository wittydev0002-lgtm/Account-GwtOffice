<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMocCasesListings
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
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnMaintainAction = New DevComponents.DotNetBar.ButtonItem()
        Me.btnChangeCaseNumber = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnFind = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnFindNext = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboSearchBy = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboLoadTypes = New MTGCComboBox()
        Me.lblClientId = New System.Windows.Forms.Label()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditRecord = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPayments = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 435)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(653, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnMaintainAction, Me.btnChangeCaseNumber, Me.btnExport, Me.btnPrint, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(653, 32)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 36
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNew.Symbol = ""
        Me.btnNew.SymbolColor = System.Drawing.Color.Green
        Me.btnNew.SymbolSize = 16.0!
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Symbol = ""
        Me.btnEdit.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.SymbolSize = 16.0!
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Symbol = ""
        Me.btnDelete.SymbolColor = System.Drawing.Color.Firebrick
        Me.btnDelete.SymbolSize = 16.0!
        Me.btnDelete.Text = "Delete"
        '
        'btnMaintainAction
        '
        Me.btnMaintainAction.BeginGroup = True
        Me.btnMaintainAction.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnMaintainAction.Name = "btnMaintainAction"
        Me.btnMaintainAction.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnMaintainAction.Symbol = ""
        Me.btnMaintainAction.SymbolColor = System.Drawing.Color.Green
        Me.btnMaintainAction.SymbolSize = 16.0!
        Me.btnMaintainAction.Text = "&Update Action"
        '
        'btnChangeCaseNumber
        '
        Me.btnChangeCaseNumber.BeginGroup = True
        Me.btnChangeCaseNumber.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnChangeCaseNumber.Name = "btnChangeCaseNumber"
        Me.btnChangeCaseNumber.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnChangeCaseNumber.Symbol = ""
        Me.btnChangeCaseNumber.SymbolSize = 16.0!
        Me.btnChangeCaseNumber.Text = "&Change Case No"
        '
        'btnExport
        '
        Me.btnExport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExport.Symbol = ""
        Me.btnExport.SymbolSize = 16.0!
        Me.btnExport.Text = "Export"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.Symbol = ""
        Me.btnPrint.SymbolSize = 16.0!
        Me.btnPrint.Text = "Print Listing"
        '
        'btnRefresh
        '
        Me.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Symbol = ""
        Me.btnRefresh.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRefresh.SymbolSize = 16.0!
        Me.btnRefresh.Text = "Refresh"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 32)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(653, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.AutoScroll = True
        Me.KryptonPanel3.Controls.Add(Me.btnFind)
        Me.KryptonPanel3.Controls.Add(Me.btnFindNext)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel3.Controls.Add(Me.cboSearchBy)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel3.Controls.Add(Me.cboLoadTypes)
        Me.KryptonPanel3.Controls.Add(Me.lblClientId)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel3.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel3.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel3.Location = New System.Drawing.Point(0, 33)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(653, 70)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel3.TabIndex = 38
        '
        'btnFind
        '
        Me.btnFind.AutoSize = True
        Me.btnFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFind.Location = New System.Drawing.Point(678, 16)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(32, 22)
        Me.btnFind.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.btnFind.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFind.StateCommon.Back.ColorAngle = 100.0!
        Me.btnFind.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnFind.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFind.StateCommon.Border.Rounding = 0
        Me.btnFind.TabIndex = 36
        Me.btnFind.Values.Text = "Find"
        '
        'btnFindNext
        '
        Me.btnFindNext.AutoSize = True
        Me.btnFindNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFindNext.Location = New System.Drawing.Point(713, 16)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(34, 22)
        Me.btnFindNext.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.btnFindNext.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnFindNext.StateCommon.Back.ColorAngle = 100.0!
        Me.btnFindNext.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnFindNext.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnFindNext.StateCommon.Border.Rounding = 0
        Me.btnFindNext.TabIndex = 35
        Me.btnFindNext.Values.Text = "Next"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel5.Location = New System.Drawing.Point(344, 16)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(64, 22)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 33
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(64, 21)
        Me.KryptonLabel3.TabIndex = 18
        Me.KryptonLabel3.Values.Text = "Search by"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(64, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownWidth = 163
        Me.cboSearchBy.Items.AddRange(New Object() {"Case Number", "Plaintif Name", "Defendant Name"})
        Me.cboSearchBy.Location = New System.Drawing.Point(410, 17)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(94, 21)
        Me.cboSearchBy.TabIndex = 32
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 52)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(747, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'cboLoadTypes
        '
        Me.cboLoadTypes.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboLoadTypes.ArrowColor = System.Drawing.Color.Black
        Me.cboLoadTypes.BindedControl = Nothing
        Me.cboLoadTypes.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboLoadTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboLoadTypes.ColumnNum = 1
        Me.cboLoadTypes.ColumnWidth = "121"
        Me.cboLoadTypes.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboLoadTypes.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboLoadTypes.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboLoadTypes.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboLoadTypes.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboLoadTypes.DisplayMember = "Text"
        Me.cboLoadTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboLoadTypes.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboLoadTypes.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboLoadTypes.DropDownForeColor = System.Drawing.Color.Black
        Me.cboLoadTypes.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboLoadTypes.DropDownWidth = 141
        Me.cboLoadTypes.GridLineColor = System.Drawing.Color.LightGray
        Me.cboLoadTypes.GridLineHorizontal = False
        Me.cboLoadTypes.GridLineVertical = False
        Me.cboLoadTypes.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboLoadTypes.HighlightBorderOnMouseEvents = True
        Me.cboLoadTypes.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboLoadTypes.Location = New System.Drawing.Point(80, 17)
        Me.cboLoadTypes.ManagingFastMouseMoving = True
        Me.cboLoadTypes.ManagingFastMouseMovingInterval = 30
        Me.cboLoadTypes.Name = "cboLoadTypes"
        Me.cboLoadTypes.NormalBorderColor = System.Drawing.Color.LightGray
        Me.cboLoadTypes.SelectedItem = Nothing
        Me.cboLoadTypes.SelectedValue = Nothing
        Me.cboLoadTypes.Size = New System.Drawing.Size(258, 23)
        Me.cboLoadTypes.TabIndex = 31
        '
        'lblClientId
        '
        Me.lblClientId.AutoSize = True
        Me.lblClientId.Location = New System.Drawing.Point(559, 3)
        Me.lblClientId.Name = "lblClientId"
        Me.lblClientId.Size = New System.Drawing.Size(13, 13)
        Me.lblClientId.TabIndex = 26
        Me.lblClientId.Text = "0"
        Me.lblClientId.Visible = False
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel2.Location = New System.Drawing.Point(506, 16)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(38, 22)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 25
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(38, 21)
        Me.KryptonLabel2.TabIndex = 18
        Me.KryptonLabel2.Values.Text = "For"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(38, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel4.Location = New System.Drawing.Point(13, 16)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 24
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel1.TabIndex = 18
        Me.KryptonLabel1.Values.Text = "Filter for"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'txtSearchString
        '
        Me.txtSearchString.Location = New System.Drawing.Point(545, 18)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(129, 20)
        Me.txtSearchString.TabIndex = 20
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2, Me.Column5, Me.Column4, Me.Column8})
        Me.dGrid.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 103)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(653, 332)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
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
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.TabIndex = 39
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Case #"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 78
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Date In"
        Me.Column3.MinimumWidth = 80
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Defendant"
        Me.Column2.MinimumWidth = 150
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "Plaintif"
        Me.Column5.MinimumWidth = 150
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 150
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Debtor Id"
        Me.Column4.MinimumWidth = 80
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 91
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column8.HeaderText = "Debtor Name"
        Me.Column8.MinimumWidth = 80
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 112
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditRecord, Me.ToolStripMenuItem1, Me.mnuPayments})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(260, 54)
        '
        'mnuEditRecord
        '
        Me.mnuEditRecord.Name = "mnuEditRecord"
        Me.mnuEditRecord.Size = New System.Drawing.Size(259, 22)
        Me.mnuEditRecord.Text = "View and Maintain Selected Record"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(256, 6)
        '
        'mnuPayments
        '
        Me.mnuPayments.Name = "mnuPayments"
        Me.mnuPayments.Size = New System.Drawing.Size(259, 22)
        Me.mnuPayments.Text = "Update Selected Record Payments"
        '
        'frmMocCasesListings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 436)
        Me.Controls.Add(Me.dGrid)
        Me.Controls.Add(Me.KryptonPanel3)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMocCasesListings"
        Me.Text = "Cases"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnMaintainAction As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnChangeCaseNumber As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnFind As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnFindNext As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboSearchBy As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboLoadTypes As MTGCComboBox
    Friend WithEvents lblClientId As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPayments As System.Windows.Forms.ToolStripMenuItem
End Class
