<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientsAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientsAdmin))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAdditionals = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTestSearch = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.txtSearchString = New System.Windows.Forms.TextBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.imageStrip = New System.Windows.Forms.ImageList(Me.components)
        Me.dGrid = New AdvancedDataGridView.TreeGridView()
        Me.Column1 = New AdvancedDataGridView.TreeGridColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditPatient = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBillPatient = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeletePatient = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintPatient = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(884, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(883, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 598)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 598)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.ForeColor = System.Drawing.Color.Black
        Me.StatusStrip1.Location = New System.Drawing.Point(1, 577)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(882, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 576)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(882, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnPrint, Me.btnRefresh, Me.btnAdditionals, Me.btnTestSearch})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(882, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 6
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.BeginGroup = True
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDelete.Text = "Delete"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.Text = "Print"
        '
        'btnRefresh
        '
        Me.btnRefresh.BeginGroup = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefresh.Text = "Refresh"
        '
        'btnAdditionals
        '
        Me.btnAdditionals.BeginGroup = True
        Me.btnAdditionals.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdditionals.Image = CType(resources.GetObject("btnAdditionals.Image"), System.Drawing.Image)
        Me.btnAdditionals.Name = "btnAdditionals"
        Me.btnAdditionals.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAdditionals.Text = "Billing"
        '
        'btnTestSearch
        '
        Me.btnTestSearch.BeginGroup = True
        Me.btnTestSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTestSearch.Image = CType(resources.GetObject("btnTestSearch.Image"), System.Drawing.Image)
        Me.btnTestSearch.Name = "btnTestSearch"
        Me.btnTestSearch.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTestSearch.Text = "Test"
        Me.btnTestSearch.Visible = False
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(882, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel7.Controls.Add(Me.ListBox1)
        Me.KryptonPanel7.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel7.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel7.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel7.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel7.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Size = New System.Drawing.Size(882, 61)
        Me.KryptonPanel7.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel7.TabIndex = 8
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(526, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(130, 30)
        Me.ListBox1.TabIndex = 52
        Me.ListBox1.Visible = False
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.White
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(97, 21)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(223, 20)
        Me.txtSearchString.TabIndex = 50
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(29, 20)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(66, 22)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 49
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(66, 21)
        Me.KryptonLabel1.TabIndex = 18
        Me.KryptonLabel1.Values.Text = "search for"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(66, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 60)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(882, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "Folder.ico")
        Me.imageList1.Images.SetKeyName(1, "calendar.png")
        Me.imageList1.Images.SetKeyName(2, "user2.png")
        Me.imageList1.Images.SetKeyName(3, "dude1.png")
        Me.imageList1.Images.SetKeyName(4, "businessman2.png")
        Me.imageList1.Images.SetKeyName(5, "TableSmall.png")
        Me.imageList1.Images.SetKeyName(6, "41.png")
        Me.imageList1.Images.SetKeyName(7, "136.png")
        Me.imageList1.Images.SetKeyName(8, "blueflag-16.png")
        Me.imageList1.Images.SetKeyName(9, "red-flag-16.png")
        Me.imageList1.Images.SetKeyName(10, "right1-16.png")
        Me.imageList1.Images.SetKeyName(11, "right-16.png")
        '
        'imageStrip
        '
        Me.imageStrip.ImageStream = CType(resources.GetObject("imageStrip.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageStrip.TransparentColor = System.Drawing.Color.Transparent
        Me.imageStrip.Images.SetKeyName(0, "Tracking_Small.png")
        Me.imageStrip.Images.SetKeyName(1, "Female.png")
        Me.imageStrip.Images.SetKeyName(2, "attach.png")
        Me.imageStrip.Images.SetKeyName(3, "User group.png")
        Me.imageStrip.Images.SetKeyName(4, "Male.png")
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.BackgroundColor = System.Drawing.Color.White
        Me.dGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4, Me.Column2, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        Me.dGrid.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dGrid.DefaultCellStyle = DataGridViewCellStyle4
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dGrid.GridColor = System.Drawing.Color.White
        Me.dGrid.ImageList = Nothing
        Me.dGrid.Location = New System.Drawing.Point(1, 88)
        Me.dGrid.Name = "dGrid"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dGrid.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(882, 488)
        Me.dGrid.TabIndex = 70
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.DefaultNodeImage = Nothing
        Me.Column1.HeaderText = "Given Names"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 75
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Gender"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 48
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Billing Method"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 78
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "DOB"
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 34
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Age"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 32
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Patient Id"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Medical Aid"
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 66
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Medaid No."
        Me.Column8.Name = "Column8"
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 67
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Suffix"
        Me.Column9.Name = "Column9"
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column9.Width = 41
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditPatient, Me.ToolStripMenuItem1, Me.mnuBillPatient, Me.ToolStripMenuItem2, Me.mnuDeletePatient, Me.ToolStripMenuItem3, Me.mnuPrintPatient})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 110)
        '
        'mnuEditPatient
        '
        Me.mnuEditPatient.Image = CType(resources.GetObject("mnuEditPatient.Image"), System.Drawing.Image)
        Me.mnuEditPatient.Name = "mnuEditPatient"
        Me.mnuEditPatient.Size = New System.Drawing.Size(179, 22)
        Me.mnuEditPatient.Text = "Edit Patient"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(176, 6)
        '
        'mnuBillPatient
        '
        Me.mnuBillPatient.Image = CType(resources.GetObject("mnuBillPatient.Image"), System.Drawing.Image)
        Me.mnuBillPatient.Name = "mnuBillPatient"
        Me.mnuBillPatient.Size = New System.Drawing.Size(179, 22)
        Me.mnuBillPatient.Text = "Bill Patient"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(176, 6)
        '
        'mnuDeletePatient
        '
        Me.mnuDeletePatient.Image = CType(resources.GetObject("mnuDeletePatient.Image"), System.Drawing.Image)
        Me.mnuDeletePatient.Name = "mnuDeletePatient"
        Me.mnuDeletePatient.Size = New System.Drawing.Size(179, 22)
        Me.mnuDeletePatient.Text = "Delete Patient"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(176, 6)
        '
        'mnuPrintPatient
        '
        Me.mnuPrintPatient.Image = CType(resources.GetObject("mnuPrintPatient.Image"), System.Drawing.Image)
        Me.mnuPrintPatient.Name = "mnuPrintPatient"
        Me.mnuPrintPatient.Size = New System.Drawing.Size(179, 22)
        Me.mnuPrintPatient.Text = "Print Patient Record"
        '
        'frmPatientsAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 599)
        Me.Controls.Add(Me.dGrid)
        Me.Controls.Add(Me.KryptonPanel7)
        Me.Controls.Add(Me.KryptonBorderEdge6)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Name = "frmPatientsAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patients"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSearchString As TextBox
    Private WithEvents imageList1 As ImageList
    Friend WithEvents btnAdditionals As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTestSearch As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ListBox1 As ListBox
    Private WithEvents imageStrip As ImageList
    Friend WithEvents dGrid As AdvancedDataGridView.TreeGridView
    Friend WithEvents Column1 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditPatient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBillPatient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeletePatient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintPatient As System.Windows.Forms.ToolStripMenuItem
End Class
