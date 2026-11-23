<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportSheet
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportSheet))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBold = New DevComponents.DotNetBar.ButtonItem()
        Me.btnItalic = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUnderline = New DevComponents.DotNetBar.ButtonItem()
        Me.cboFontName = New DevComponents.DotNetBar.ComboBoxItem()
        Me.cboFontSize = New DevComponents.DotNetBar.ComboBoxItem()
        Me.btnFillColor = New DevComponents.DotNetBar.ButtonItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.btnAlternateRowColor = New DevComponents.DotNetBar.ButtonItem()
        Me.btnLeft = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCenter = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRight = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSortUp = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSortDown = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSum = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCount = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAverage = New DevComponents.DotNetBar.ButtonItem()
        Me.btnGroup = New DevComponents.DotNetBar.ButtonItem()
        Me.btnGraph = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCopy = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.dGridTransactions = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnForeColor = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(721, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 372)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(721, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(720, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 371)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 371)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.btnPrint, Me.btnBold, Me.btnItalic, Me.btnUnderline, Me.cboFontName, Me.cboFontSize, Me.btnFillColor, Me.btnForeColor, Me.btnAlternateRowColor, Me.btnLeft, Me.btnCenter, Me.btnRight, Me.btnSortUp, Me.btnSortDown, Me.btnSum, Me.btnCount, Me.btnAverage, Me.btnGroup, Me.btnGraph, Me.btnExport, Me.btnCopy})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(719, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 23
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Tooltip = "Save Report"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Tooltip = "Print report"
        '
        'btnBold
        '
        Me.btnBold.BeginGroup = True
        Me.btnBold.Image = CType(resources.GetObject("btnBold.Image"), System.Drawing.Image)
        Me.btnBold.Name = "btnBold"
        Me.btnBold.Tooltip = "Bold or unbold cell content"
        '
        'btnItalic
        '
        Me.btnItalic.Image = CType(resources.GetObject("btnItalic.Image"), System.Drawing.Image)
        Me.btnItalic.Name = "btnItalic"
        Me.btnItalic.Tooltip = "Make cell content italic or non italic"
        '
        'btnUnderline
        '
        Me.btnUnderline.Image = CType(resources.GetObject("btnUnderline.Image"), System.Drawing.Image)
        Me.btnUnderline.Name = "btnUnderline"
        Me.btnUnderline.Tooltip = "Underline cell content"
        '
        'cboFontName
        '
        Me.cboFontName.DropDownHeight = 106
        Me.cboFontName.ItemHeight = 17
        Me.cboFontName.Name = "cboFontName"
        Me.cboFontName.Stretch = True
        '
        'cboFontSize
        '
        Me.cboFontSize.DropDownHeight = 106
        Me.cboFontSize.ItemHeight = 17
        Me.cboFontSize.Name = "cboFontSize"
        '
        'btnFillColor
        '
        Me.btnFillColor.Image = CType(resources.GetObject("btnFillColor.Image"), System.Drawing.Image)
        Me.btnFillColor.Name = "btnFillColor"
        Me.btnFillColor.Tooltip = "Change background color"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'btnAlternateRowColor
        '
        Me.btnAlternateRowColor.Image = CType(resources.GetObject("btnAlternateRowColor.Image"), System.Drawing.Image)
        Me.btnAlternateRowColor.Name = "btnAlternateRowColor"
        Me.btnAlternateRowColor.Tooltip = "Alternate row color"
        '
        'btnLeft
        '
        Me.btnLeft.BeginGroup = True
        Me.btnLeft.Image = CType(resources.GetObject("btnLeft.Image"), System.Drawing.Image)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Tooltip = "Align left"
        '
        'btnCenter
        '
        Me.btnCenter.Image = CType(resources.GetObject("btnCenter.Image"), System.Drawing.Image)
        Me.btnCenter.Name = "btnCenter"
        Me.btnCenter.Tooltip = "Align center"
        '
        'btnRight
        '
        Me.btnRight.Image = CType(resources.GetObject("btnRight.Image"), System.Drawing.Image)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Tooltip = "Align right"
        '
        'btnSortUp
        '
        Me.btnSortUp.BeginGroup = True
        Me.btnSortUp.Image = CType(resources.GetObject("btnSortUp.Image"), System.Drawing.Image)
        Me.btnSortUp.Name = "btnSortUp"
        Me.btnSortUp.Tooltip = "Sort ascending"
        '
        'btnSortDown
        '
        Me.btnSortDown.Image = CType(resources.GetObject("btnSortDown.Image"), System.Drawing.Image)
        Me.btnSortDown.Name = "btnSortDown"
        Me.btnSortDown.Tooltip = "Sort descending"
        '
        'btnSum
        '
        Me.btnSum.BeginGroup = True
        Me.btnSum.Image = CType(resources.GetObject("btnSum.Image"), System.Drawing.Image)
        Me.btnSum.Name = "btnSum"
        Me.btnSum.Tooltip = "Get sum of cell range"
        '
        'btnCount
        '
        Me.btnCount.Image = CType(resources.GetObject("btnCount.Image"), System.Drawing.Image)
        Me.btnCount.Name = "btnCount"
        Me.btnCount.Tooltip = "Get count of items"
        '
        'btnAverage
        '
        Me.btnAverage.Image = CType(resources.GetObject("btnAverage.Image"), System.Drawing.Image)
        Me.btnAverage.Name = "btnAverage"
        Me.btnAverage.Tooltip = "Get average for the range"
        '
        'btnGroup
        '
        Me.btnGroup.Image = CType(resources.GetObject("btnGroup.Image"), System.Drawing.Image)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Tooltip = "Group items"
        '
        'btnGraph
        '
        Me.btnGraph.Image = CType(resources.GetObject("btnGraph.Image"), System.Drawing.Image)
        Me.btnGraph.Name = "btnGraph"
        Me.btnGraph.Tooltip = "Create graph"
        '
        'btnExport
        '
        Me.btnExport.BeginGroup = True
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Tooltip = "Export data"
        '
        'btnCopy
        '
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Tooltip = "Copy data to clip board"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 29)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(719, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dGridTransactions)
        Me.KryptonPanel1.Controls.Add(Me.dGrid)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 30)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(719, 342)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 25
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersVisible = False
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(719, 342)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGrid.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.TabIndex = 43
        '
        'dGridTransactions
        '
        Me.dGridTransactions.AllowUserToAddRows = False
        Me.dGridTransactions.AllowUserToDeleteRows = False
        Me.dGridTransactions.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column6, Me.Column4, Me.Column5, Me.Column13})
        Me.dGridTransactions.Location = New System.Drawing.Point(185, 113)
        Me.dGridTransactions.Name = "dGridTransactions"
        Me.dGridTransactions.ReadOnly = True
        Me.dGridTransactions.RowHeadersWidth = 25
        Me.dGridTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridTransactions.Size = New System.Drawing.Size(296, 116)
        Me.dGridTransactions.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGridTransactions.StateCommon.Background.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.Background.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridTransactions.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridTransactions.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTransactions.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTransactions.TabIndex = 44
        Me.dGridTransactions.Visible = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Date"
        Me.Column1.MinimumWidth = 100
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Ref #"
        Me.Column2.MinimumWidth = 100
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Description"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column6.HeaderText = "Qty"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Visible = False
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Debit"
        Me.Column4.MinimumWidth = 80
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0.00"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Credit"
        Me.Column5.MinimumWidth = 80
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 80
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column13.HeaderText = "Type"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column13.Width = 44
        '
        'btnForeColor
        '
        Me.btnForeColor.Image = CType(resources.GetObject("btnForeColor.Image"), System.Drawing.Image)
        Me.btnForeColor.Name = "btnForeColor"
        Me.btnForeColor.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnForeColor.Text = "Fore Color"
        '
        'frmReportSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(721, 373)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Name = "frmReportSheet"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Report View"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBold As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnItalic As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUnderline As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cboFontName As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents cboFontSize As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents btnFillColor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents btnAlternateRowColor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnLeft As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCenter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRight As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSortUp As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSortDown As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSum As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCount As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAverage As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnGroup As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnGraph As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCopy As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGridTransactions As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents btnForeColor As DevComponents.DotNetBar.ButtonItem
End Class
