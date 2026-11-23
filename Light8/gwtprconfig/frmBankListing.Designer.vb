<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankListing
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankListing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnChangeCode = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.cboSearchBy = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.txtSearchString = New DevComponents.DotNetBar.TextBoxItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.ppd = New System.Windows.Forms.PrintPreviewDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dgrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pb1 = New System.Windows.Forms.ToolStripProgressBar()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 513)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(600, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 513)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(599, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 513)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnEdit, Me.btnChangeCode, Me.btnDelete, Me.btnImport, Me.btnPrint, Me.btnRefresh, Me.LabelItem2, Me.cboSearchBy, Me.LabelItem4, Me.txtSearchString})
        Me.Bar3.Location = New System.Drawing.Point(1, 0)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(598, 28)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 22
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAdd.Text = "ButtonItem1"
        Me.btnAdd.Tooltip = "Add new bank"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "ButtonItem2"
        Me.btnEdit.Tooltip = "Edit Bank Details"
        '
        'btnChangeCode
        '
        Me.btnChangeCode.BeginGroup = True
        Me.btnChangeCode.Image = CType(resources.GetObject("btnChangeCode.Image"), System.Drawing.Image)
        Me.btnChangeCode.Name = "btnChangeCode"
        Me.btnChangeCode.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnChangeCode.Text = "Change Code"
        Me.btnChangeCode.Tooltip = "Change Code"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Text = "ButtonItem3"
        Me.btnDelete.Tooltip = "Delete bank"
        '
        'btnImport
        '
        Me.btnImport.BeginGroup = True
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImport.Text = "ButtonItem4"
        Me.btnImport.Tooltip = "Import from text file"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.Text = "ButtonItem6"
        Me.btnPrint.Tooltip = "Print bank listing"
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Text = "ButtonItem7"
        Me.btnRefresh.Tooltip = "Refresh view"
        '
        'LabelItem2
        '
        Me.LabelItem2.BeginGroup = True
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 5
        Me.LabelItem2.PaddingRight = 5
        Me.LabelItem2.Text = "Search by"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.ComboWidth = 140
        Me.cboSearchBy.DropDownHeight = 106
        Me.cboSearchBy.ItemHeight = 17
        Me.cboSearchBy.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cboSearchBy.Name = "cboSearchBy"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Code"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Name"
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 6
        Me.LabelItem4.PaddingRight = 6
        Me.LabelItem4.Text = "Search for "
        '
        'txtSearchString
        '
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.TextBoxWidth = 120
        Me.txtSearchString.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 28)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(598, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'ppd
        '
        Me.ppd.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppd.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppd.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppd.Enabled = True
        Me.ppd.Icon = CType(resources.GetObject("ppd.Icon"), System.Drawing.Icon)
        Me.ppd.Name = "ppd"
        Me.ppd.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.pb1})
        Me.StatusStrip1.Location = New System.Drawing.Point(1, 491)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(598, 22)
        Me.StatusStrip1.TabIndex = 30
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(1, 490)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(598, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.dgrid)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 29)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(598, 461)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 32
        '
        'dgrid
        '
        Me.dgrid.AllowUserToAddRows = False
        Me.dgrid.AllowUserToDeleteRows = False
        Me.dgrid.AllowUserToResizeColumns = False
        Me.dgrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column2, Me.Column3, Me.Column5, Me.Column6})
        Me.dgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrid.Location = New System.Drawing.Point(0, 0)
        Me.dgrid.Name = "dgrid"
        Me.dgrid.ReadOnly = True
        Me.dgrid.RowHeadersWidth = 25
        Me.dgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrid.Size = New System.Drawing.Size(598, 461)
        Me.dgrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dgrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dgrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dgrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dgrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrid.TabIndex = 19
        '
        'Column1
        '
        Me.Column1.HeaderText = "Sort Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Bank Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Address1"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Address2"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Address3"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Address4"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(481, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'pb1
        '
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(100, 16)
        '
        'frmBankListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 514)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge6)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar3)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBankListing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "System Banks"
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.dgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImport As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cboSearchBy As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtSearchString As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnChangeCode As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ppd As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pb1 As Windows.Forms.ToolStripProgressBar
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dgrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As Windows.Forms.DataGridViewTextBoxColumn
End Class
