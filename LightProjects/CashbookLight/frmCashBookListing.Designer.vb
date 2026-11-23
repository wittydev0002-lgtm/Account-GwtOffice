<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBookListing
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashBookListing))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.lblBalance = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNewEmployee = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSelected = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintSheet = New DevComponents.DotNetBar.ButtonItem()
        Me.btnViewEntries = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.dGrid)
        Me.KryptonPanel.Controls.Add(Me.Bar2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel.Controls.Add(Me.Bar1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(616, 442)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(1, 31)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(614, 390)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.TabIndex = 36
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Account Number"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 130
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Account Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Balance"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 23
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.lblBalance})
        Me.Bar2.Location = New System.Drawing.Point(1, 421)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingLeft = 3
        Me.Bar2.PaddingRight = 3
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(614, 20)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 35
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Balance Total"
        '
        'lblBalance
        '
        Me.lblBalance.BeginGroup = True
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.PaddingLeft = 3
        Me.lblBalance.PaddingRight = 3
        Me.lblBalance.Text = "0.00"
        Me.lblBalance.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblBalance.Width = 100
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(1, 30)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(614, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewEmployee, Me.btnEdit, Me.ButtonItem1, Me.btnViewEntries, Me.btnDelete, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.PaddingTop = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(614, 29)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 27
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNewEmployee
        '
        Me.btnNewEmployee.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNewEmployee.Image = CType(resources.GetObject("btnNewEmployee.Image"), System.Drawing.Image)
        Me.btnNewEmployee.Name = "btnNewEmployee"
        Me.btnNewEmployee.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewEmployee.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnNewEmployee.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "Edit"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.BeginGroup = True
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintSelected, Me.btnPrintSheet})
        Me.ButtonItem1.Text = "Print"
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BeginGroup = True
        Me.btnPrintSelected.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSelected.SymbolSize = 16.0!
        Me.btnPrintSelected.Text = "Print Selected Row"
        '
        'btnPrintSheet
        '
        Me.btnPrintSheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintSheet.Name = "btnPrintSheet"
        Me.btnPrintSheet.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintSheet.SymbolSize = 16.0!
        Me.btnPrintSheet.Text = "Print Entire Sheet"
        '
        'btnViewEntries
        '
        Me.btnViewEntries.BeginGroup = True
        Me.btnViewEntries.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnViewEntries.Image = CType(resources.GetObject("btnViewEntries.Image"), System.Drawing.Image)
        Me.btnViewEntries.Name = "btnViewEntries"
        Me.btnViewEntries.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnViewEntries.Text = "View Entries"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Text = "Delete"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.Visible = False
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(615, 1)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 440)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 440)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 441)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(616, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(616, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmCashBookListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 448)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmCashBookListing"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cashbooks"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewEmployee As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSelected As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintSheet As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnViewEntries As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblBalance As DevComponents.DotNetBar.LabelItem
End Class
