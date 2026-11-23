<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchesListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBatchesListing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnEditBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteBatch = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.cboFilter = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.btnFilter = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.lblBatchesCount = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblAmountTotals = New DevComponents.DotNetBar.LabelItem()
        Me.pnlMain = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtUsers = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dpStart = New System.Windows.Forms.DateTimePicker()
        Me.pnlRight = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblRight = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblLeft = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dGridTransactions = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.pnlRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRight.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(435, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 477)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(435, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 476)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(434, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 476)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnEditBatch, Me.btnDeleteBatch, Me.LabelItem3, Me.cboFilter, Me.btnFilter})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(433, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnEditBatch
        '
        Me.btnEditBatch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEditBatch.Image = CType(resources.GetObject("btnEditBatch.Image"), System.Drawing.Image)
        Me.btnEditBatch.Name = "btnEditBatch"
        Me.btnEditBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditBatch.Text = "Edit Batch"
        '
        'btnDeleteBatch
        '
        Me.btnDeleteBatch.BeginGroup = True
        Me.btnDeleteBatch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDeleteBatch.Image = CType(resources.GetObject("btnDeleteBatch.Image"), System.Drawing.Image)
        Me.btnDeleteBatch.Name = "btnDeleteBatch"
        Me.btnDeleteBatch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteBatch.Text = "Delete Batch"
        '
        'LabelItem3
        '
        Me.LabelItem3.BeginGroup = True
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingLeft = 3
        Me.LabelItem3.PaddingRight = 3
        Me.LabelItem3.Text = "Filter by"
        '
        'cboFilter
        '
        Me.cboFilter.ComboWidth = 120
        Me.cboFilter.DropDownHeight = 106
        Me.cboFilter.ItemHeight = 17
        Me.cboFilter.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cboFilter.Name = "cboFilter"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Date"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Processor"
        '
        'btnFilter
        '
        Me.btnFilter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnFilter.Text = "Filter"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 29)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(433, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem2, Me.lblBatchesCount, Me.LabelItem4, Me.lblAmountTotals})
        Me.Bar2.Location = New System.Drawing.Point(1, 457)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(433, 20)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 6
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 3
        Me.LabelItem2.PaddingRight = 3
        Me.LabelItem2.Text = "Number of batches"
        '
        'lblBatchesCount
        '
        Me.lblBatchesCount.Name = "lblBatchesCount"
        Me.lblBatchesCount.PaddingLeft = 3
        Me.lblBatchesCount.PaddingRight = 3
        Me.lblBatchesCount.Text = "0"
        '
        'LabelItem4
        '
        Me.LabelItem4.BeginGroup = True
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 3
        Me.LabelItem4.PaddingRight = 3
        Me.LabelItem4.Text = "Amount totals"
        '
        'lblAmountTotals
        '
        Me.lblAmountTotals.Name = "lblAmountTotals"
        Me.lblAmountTotals.PaddingLeft = 3
        Me.lblAmountTotals.PaddingRight = 3
        Me.lblAmountTotals.Text = "0.00"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.txtUsers)
        Me.pnlMain.Controls.Add(Me.dpEnd)
        Me.pnlMain.Controls.Add(Me.dpStart)
        Me.pnlMain.Controls.Add(Me.pnlRight)
        Me.pnlMain.Controls.Add(Me.KryptonPanel2)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge6)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.ForeColor = System.Drawing.Color.Black
        Me.pnlMain.Location = New System.Drawing.Point(1, 30)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(433, 58)
        Me.pnlMain.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.pnlMain.StateCommon.Color2 = System.Drawing.SystemColors.Control
        Me.pnlMain.TabIndex = 7
        '
        'txtUsers
        '
        Me.txtUsers.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUsers.Border.Class = "TextBoxBorder"
        Me.txtUsers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsers.DisabledBackColor = System.Drawing.Color.White
        Me.txtUsers.ForeColor = System.Drawing.Color.Black
        Me.txtUsers.Location = New System.Drawing.Point(94, 16)
        Me.txtUsers.Name = "txtUsers"
        Me.txtUsers.PreventEnterBeep = True
        Me.txtUsers.Size = New System.Drawing.Size(201, 22)
        Me.txtUsers.TabIndex = 5
        '
        'dpEnd
        '
        Me.dpEnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpEnd.ForeColor = System.Drawing.Color.Black
        Me.dpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEnd.Location = New System.Drawing.Point(298, 16)
        Me.dpEnd.Name = "dpEnd"
        Me.dpEnd.Size = New System.Drawing.Size(104, 22)
        Me.dpEnd.TabIndex = 4
        '
        'dpStart
        '
        Me.dpStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dpStart.ForeColor = System.Drawing.Color.Black
        Me.dpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStart.Location = New System.Drawing.Point(94, 16)
        Me.dpStart.Name = "dpStart"
        Me.dpStart.Size = New System.Drawing.Size(104, 22)
        Me.dpStart.TabIndex = 3
        '
        'pnlRight
        '
        Me.pnlRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.pnlRight.Controls.Add(Me.lblRight)
        Me.pnlRight.Controls.Add(Me.KryptonBorderEdge8)
        Me.pnlRight.ForeColor = System.Drawing.Color.Black
        Me.pnlRight.Location = New System.Drawing.Point(223, 17)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(74, 21)
        Me.pnlRight.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.pnlRight.TabIndex = 2
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRight.ForeColor = System.Drawing.Color.Black
        Me.lblRight.Location = New System.Drawing.Point(0, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(74, 20)
        Me.lblRight.TabIndex = 1
        Me.lblRight.Values.Text = "Date to"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(74, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.lblLeft)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(18, 17)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(74, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 1
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLeft.ForeColor = System.Drawing.Color.Black
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(74, 20)
        Me.lblLeft.TabIndex = 1
        Me.lblLeft.Values.Text = "Date from"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(74, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 57)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(433, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'dGridTransactions
        '
        Me.dGridTransactions.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn5})
        Me.dGridTransactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridTransactions.Location = New System.Drawing.Point(1, 88)
        Me.dGridTransactions.Name = "dGridTransactions"
        Me.dGridTransactions.RowHeadersWidth = 25
        Me.dGridTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridTransactions.Size = New System.Drawing.Size(433, 369)
        Me.dGridTransactions.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridTransactions.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridTransactions.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridTransactions.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridTransactions.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridTransactions.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.TabIndex = 26
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Batch #"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 81
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 63
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Processed By"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'frmTransactionBatchesListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 478)
        Me.Controls.Add(Me.dGridTransactions)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransactionBatchesListing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transaction Batches"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.pnlRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRight.ResumeLayout(False)
        Me.pnlRight.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnEditBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteBatch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblBatchesCount As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblAmountTotals As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pnlMain As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridTransactions As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboFilter As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents btnFilter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlRight As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblRight As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblLeft As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtUsers As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
