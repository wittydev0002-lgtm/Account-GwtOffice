<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessTransactions
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnProcess = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.pnlSelection = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.pnlDirectors = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.pnlDates = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge16 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.optDirectors = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optDate = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optSpecifiedPending = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optAllPending = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.Column1 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn()
        Me.Column2 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn()
        Me.Column3 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.pnlSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSelection.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelection.Panel.SuspendLayout()
        Me.pnlSelection.SuspendLayout()
        CType(Me.pnlDirectors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDirectors.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDirectors.Panel.SuspendLayout()
        Me.pnlDirectors.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDates.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDates.Panel.SuspendLayout()
        Me.pnlDates.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnProcess)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(616, 403)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.pb1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Location = New System.Drawing.Point(12, 366)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(433, 25)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 4
        '
        'pb1
        '
        Me.pb1.BackColor = System.Drawing.SystemColors.Control
        Me.pb1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb1.Location = New System.Drawing.Point(1, 1)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(431, 23)
        Me.pb1.TabIndex = 4
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(432, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 23)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 23)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 24)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(433, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(433, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(535, 366)
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
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(456, 366)
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
        Me.btnProcess.TabIndex = 2
        Me.btnProcess.Values.Text = "&Process"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.pnlSelection)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optSpecifiedPending)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optAllPending)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(598, 348)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'pnlSelection
        '
        Me.pnlSelection.Location = New System.Drawing.Point(13, 57)
        Me.pnlSelection.Name = "pnlSelection"
        '
        'pnlSelection.Panel
        '
        Me.pnlSelection.Panel.Controls.Add(Me.pnlDirectors)
        Me.pnlSelection.Panel.Controls.Add(Me.pnlDates)
        Me.pnlSelection.Panel.Controls.Add(Me.optDirectors)
        Me.pnlSelection.Panel.Controls.Add(Me.optDate)
        Me.pnlSelection.Size = New System.Drawing.Size(568, 270)
        Me.pnlSelection.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.pnlSelection.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.pnlSelection.StateCommon.Border.Rounding = 0
        Me.pnlSelection.TabIndex = 2
        Me.pnlSelection.Text = "Selection specification"
        Me.pnlSelection.Values.Heading = "Selection specification"
        '
        'pnlDirectors
        '
        Me.pnlDirectors.Location = New System.Drawing.Point(256, 56)
        Me.pnlDirectors.Name = "pnlDirectors"
        '
        'pnlDirectors.Panel
        '
        Me.pnlDirectors.Panel.Controls.Add(Me.dGrid)
        Me.pnlDirectors.Size = New System.Drawing.Size(293, 175)
        Me.pnlDirectors.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.pnlDirectors.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.pnlDirectors.StateCommon.Border.Rounding = 0
        Me.pnlDirectors.TabIndex = 3
        Me.pnlDirectors.Text = "Directors"
        Me.pnlDirectors.Values.Heading = "Directors"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.Size = New System.Drawing.Size(291, 152)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 0
        '
        'pnlDates
        '
        Me.pnlDates.Location = New System.Drawing.Point(17, 56)
        Me.pnlDates.Name = "pnlDates"
        '
        'pnlDates.Panel
        '
        Me.pnlDates.Panel.Controls.Add(Me.dpStartDate)
        Me.pnlDates.Panel.Controls.Add(Me.dpEndDate)
        Me.pnlDates.Panel.Controls.Add(Me.KryptonPanel4)
        Me.pnlDates.Panel.Controls.Add(Me.KryptonPanel8)
        Me.pnlDates.Size = New System.Drawing.Size(233, 175)
        Me.pnlDates.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.pnlDates.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.pnlDates.StateCommon.Border.Rounding = 0
        Me.pnlDates.TabIndex = 2
        Me.pnlDates.Text = "Dates"
        Me.pnlDates.Values.Heading = "Dates"
        '
        'dpStartDate
        '
        Me.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartDate.Location = New System.Drawing.Point(106, 20)
        Me.dpStartDate.Name = "dpStartDate"
        Me.dpStartDate.Size = New System.Drawing.Size(96, 20)
        Me.dpStartDate.TabIndex = 4
        '
        'dpEndDate
        '
        Me.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndDate.Location = New System.Drawing.Point(106, 48)
        Me.dpEndDate.Name = "dpEndDate"
        Me.dpEndDate.Size = New System.Drawing.Size(96, 20)
        Me.dpEndDate.TabIndex = 4
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge16)
        Me.KryptonPanel4.Location = New System.Drawing.Point(28, 47)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(77, 21)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 78
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(77, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Date to"
        '
        'KryptonBorderEdge16
        '
        Me.KryptonBorderEdge16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge16.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge16.Name = "KryptonBorderEdge16"
        Me.KryptonBorderEdge16.Size = New System.Drawing.Size(77, 1)
        Me.KryptonBorderEdge16.Text = "KryptonBorderEdge16"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel8.Location = New System.Drawing.Point(28, 19)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(76, 21)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 76
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(76, 20)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Date from"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(76, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'optDirectors
        '
        Me.optDirectors.Location = New System.Drawing.Point(256, 20)
        Me.optDirectors.Name = "optDirectors"
        Me.optDirectors.Size = New System.Drawing.Size(121, 20)
        Me.optDirectors.TabIndex = 1
        Me.optDirectors.Values.Text = "Selected Directors"
        '
        'optDate
        '
        Me.optDate.Location = New System.Drawing.Point(28, 20)
        Me.optDate.Name = "optDate"
        Me.optDate.Size = New System.Drawing.Size(121, 20)
        Me.optDate.TabIndex = 0
        Me.optDate.Values.Text = "Date Specification"
        '
        'optSpecifiedPending
        '
        Me.optSpecifiedPending.Location = New System.Drawing.Point(210, 16)
        Me.optSpecifiedPending.Name = "optSpecifiedPending"
        Me.optSpecifiedPending.Size = New System.Drawing.Size(115, 20)
        Me.optSpecifiedPending.TabIndex = 1
        Me.optSpecifiedPending.Values.Text = "Process Selective"
        '
        'optAllPending
        '
        Me.optAllPending.Location = New System.Drawing.Point(23, 16)
        Me.optAllPending.Name = "optAllPending"
        Me.optAllPending.Size = New System.Drawing.Size(128, 20)
        Me.optAllPending.TabIndex = 0
        Me.optAllPending.Values.Text = "Process all pending"
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.NullValue = False
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.FalseValue = Nothing
        Me.Column1.HeaderText = ""
        Me.Column1.IndeterminateValue = Nothing
        Me.Column1.Name = "Column1"
        Me.Column1.TrueValue = Nothing
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Director"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 63
        '
        'Column3
        '
        Me.Column3.HeaderText = "Id"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Visible = False
        Me.Column3.Width = 100
        '
        'frmProcessTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessTransactions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Process Payments"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.pnlSelection.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelection.Panel.ResumeLayout(False)
        Me.pnlSelection.Panel.PerformLayout()
        CType(Me.pnlSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelection.ResumeLayout(False)
        CType(Me.pnlDirectors.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDirectors.Panel.ResumeLayout(False)
        CType(Me.pnlDirectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDirectors.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDates.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDates.Panel.ResumeLayout(False)
        CType(Me.pnlDates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDates.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
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
    Friend WithEvents pnlSelection As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents optSpecifiedPending As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optAllPending As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents pnlDirectors As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents pnlDates As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents optDirectors As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optDate As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents dpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge16 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnProcess As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Column1 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn
    Friend WithEvents Column2 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
    Friend WithEvents Column3 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
End Class
