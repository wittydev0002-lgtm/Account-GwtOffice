<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryItemMovementReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryItemMovementReport))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.btnPrint = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.ButtonSpecAny3 = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.btnTrack = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboItems = New MTGCComboBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel.Controls.Add(Me.KryptonHeader1)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(617, 473)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(13, 163)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dGrid)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(591, 294)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 71
        Me.KryptonGroupBox2.Text = "Status Report"
        Me.KryptonGroupBox2.Values.Heading = "Status Report"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(589, 271)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Date In"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 79
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.HeaderText = "Input Serial #"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 116
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Date Out"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 87
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Output Serial #"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 124
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "In-stock Serial #"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 133
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.AllowButtonSpecToolTips = True
        Me.KryptonHeader1.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnCancel, Me.btnPrint, Me.ButtonSpecAny3, Me.btnTrack})
        Me.KryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonHeader1.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Custom1
        Me.KryptonHeader1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(617, 28)
        Me.KryptonHeader1.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.KryptonHeader1.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.KryptonHeader1.StateCommon.Back.ColorAngle = 100.0!
        Me.KryptonHeader1.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonHeader1.StateCommon.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonHeader1.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonHeader1.TabIndex = 70
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = ""
        Me.KryptonHeader1.Values.Image = Nothing
        '
        'btnCancel
        '
        Me.btnCancel.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.FormClose
        Me.btnCancel.Text = "Close"
        Me.btnCancel.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.FormClose
        Me.btnCancel.UniqueName = "59B7377D234E4844C08F7D3AFDA05289"
        Me.btnCancel.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UniqueName = "327A1173D71142043E8400566A970F47"
        '
        'ButtonSpecAny3
        '
        Me.ButtonSpecAny3.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near
        Me.ButtonSpecAny3.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.[False]
        Me.ButtonSpecAny3.Text = "|"
        Me.ButtonSpecAny3.UniqueName = "21B627AB97D843630F877475E9F53961"
        '
        'btnTrack
        '
        Me.btnTrack.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near
        Me.btnTrack.Image = CType(resources.GetObject("btnTrack.Image"), System.Drawing.Image)
        Me.btnTrack.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl
        Me.btnTrack.Text = "Track"
        Me.btnTrack.UniqueName = "8AF129FD3C3E4EA36B932F672AC767FC"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 44)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel6)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboItems)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(593, 113)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "Parameters"
        Me.KryptonGroupBox1.Values.Heading = "Parameters"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.dpEndDate)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel2.Location = New System.Drawing.Point(365, 45)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(115, 22)
        Me.KryptonPanel2.TabIndex = 150
        '
        'dpEndDate
        '
        Me.dpEndDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndDate.Location = New System.Drawing.Point(1, 1)
        Me.dpEndDate.Name = "dpEndDate"
        Me.dpEndDate.Size = New System.Drawing.Size(113, 20)
        Me.dpEndDate.TabIndex = 5
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(114, 1)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(115, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(115, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dpStartDate)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel1.Location = New System.Drawing.Point(156, 45)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(115, 22)
        Me.KryptonPanel1.TabIndex = 149
        '
        'dpStartDate
        '
        Me.dpStartDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartDate.Location = New System.Drawing.Point(1, 1)
        Me.dpStartDate.Name = "dpStartDate"
        Me.dpStartDate.Size = New System.Drawing.Size(113, 20)
        Me.dpStartDate.TabIndex = 5
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(114, 1)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 20)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(115, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(115, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel4.Location = New System.Drawing.Point(276, 47)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(89, 20)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 75
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(89, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(89, 20)
        Me.KryptonLabel2.TabIndex = 0
        Me.KryptonLabel2.Values.Text = "Date to"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel5.Location = New System.Drawing.Point(37, 47)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(119, 20)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 74
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(119, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel3.TabIndex = 0
        Me.KryptonLabel3.Values.Text = "Date from"
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel6.Location = New System.Drawing.Point(37, 21)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(119, 20)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 65
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(119, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(119, 20)
        Me.KryptonLabel4.TabIndex = 0
        Me.KryptonLabel4.Values.Text = "I need to track item "
        '
        'cboItems
        '
        Me.cboItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.ArrowColor = System.Drawing.Color.Black
        Me.cboItems.BindedControl = Nothing
        Me.cboItems.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboItems.ColumnNum = 1
        Me.cboItems.ColumnWidth = "121"
        Me.cboItems.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboItems.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboItems.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboItems.DisplayMember = "Text"
        Me.cboItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboItems.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboItems.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboItems.DropDownForeColor = System.Drawing.Color.Black
        Me.cboItems.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboItems.DropDownWidth = 141
        Me.cboItems.GridLineColor = System.Drawing.Color.LightGray
        Me.cboItems.GridLineHorizontal = False
        Me.cboItems.GridLineVertical = False
        Me.cboItems.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cboItems.HighlightBorderOnMouseEvents = True
        Me.cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboItems.Location = New System.Drawing.Point(156, 20)
        Me.cboItems.ManagingFastMouseMoving = True
        Me.cboItems.ManagingFastMouseMovingInterval = 30
        Me.cboItems.Name = "cboItems"
        Me.cboItems.NormalBorderColor = System.Drawing.Color.Silver
        Me.cboItems.SelectedItem = Nothing
        Me.cboItems.SelectedValue = Nothing
        Me.cboItems.Size = New System.Drawing.Size(398, 21)
        Me.cboItems.Sorted = True
        Me.cboItems.TabIndex = 64
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 472)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(617, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 28)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(1, 444)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(616, 28)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(1, 444)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'frmInventoryItemMovementReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 473)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventoryItemMovementReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Inventory Item Movement Report"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboItems As MTGCComboBox
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents btnPrint As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents ButtonSpecAny3 As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents btnTrack As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
