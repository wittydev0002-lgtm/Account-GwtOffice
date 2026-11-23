<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobsListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobsListing))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.splitMain = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.dGridJobs = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge26 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.expandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.tvStages = New System.Windows.Forms.TreeView()
        Me.KryptonBorderEdge27 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.btnAddJob = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditJob = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteJob = New DevComponents.DotNetBar.ButtonItem()
        Me.btnJobOreps = New DevComponents.DotNetBar.ButtonItem()
        Me.btnJobCVategories = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBrintJob = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        CType(Me.dGridJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expandablePanel1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.splitMain)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.StatusStrip2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.Bar2)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(554, 416)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 0
        '
        'splitMain
        '
        Me.splitMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.splitMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Location = New System.Drawing.Point(0, 26)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.splitMain.Panel1.Controls.Add(Me.dGridJobs)
        Me.splitMain.Panel1.Controls.Add(Me.KryptonBorderEdge26)
        Me.splitMain.Panel1.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.splitMain.Panel2.Controls.Add(Me.expandablePanel1)
        Me.splitMain.Panel2.Controls.Add(Me.KryptonBorderEdge27)
        Me.splitMain.Panel2.ForeColor = System.Drawing.Color.Black
        Me.splitMain.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile
        Me.splitMain.Size = New System.Drawing.Size(554, 367)
        Me.splitMain.SplitterDistance = 433
        Me.splitMain.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.splitMain.TabIndex = 61
        '
        'dGridJobs
        '
        Me.dGridJobs.AllowUserToAddRows = False
        Me.dGridJobs.AllowUserToDeleteRows = False
        Me.dGridJobs.AllowUserToResizeRows = False
        Me.dGridJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column9, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn8})
        Me.dGridJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridJobs.Location = New System.Drawing.Point(0, 0)
        Me.dGridJobs.Name = "dGridJobs"
        Me.dGridJobs.ReadOnly = True
        Me.dGridJobs.RowHeadersWidth = 25
        Me.dGridJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridJobs.Size = New System.Drawing.Size(432, 367)
        Me.dGridJobs.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridJobs.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridJobs.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridJobs.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridJobs.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridJobs.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridJobs.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridJobs.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridJobs.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridJobs.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridJobs.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridJobs.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridJobs.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridJobs.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridJobs.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridJobs.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridJobs.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridJobs.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridJobs.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridJobs.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridJobs.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridJobs.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridJobs.TabIndex = 54
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Job Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 84
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 95
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Location"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Grade"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 67
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Reports To"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 90
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Holders"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 76
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn8.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 68
        '
        'KryptonBorderEdge26
        '
        Me.KryptonBorderEdge26.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge26.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge26.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge26.Location = New System.Drawing.Point(432, 0)
        Me.KryptonBorderEdge26.Name = "KryptonBorderEdge26"
        Me.KryptonBorderEdge26.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge26.Size = New System.Drawing.Size(1, 367)
        Me.KryptonBorderEdge26.Text = "KryptonBorderEdge26"
        '
        'expandablePanel1
        '
        Me.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.expandablePanel1.Controls.Add(Me.tvStages)
        Me.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expandablePanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expandablePanel1.Location = New System.Drawing.Point(1, 0)
        Me.expandablePanel1.Name = "expandablePanel1"
        Me.expandablePanel1.Size = New System.Drawing.Size(115, 367)
        Me.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.expandablePanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.Style.GradientAngle = 90
        Me.expandablePanel1.TabIndex = 15
        Me.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expandablePanel1.TitleStyle.GradientAngle = 90
        Me.expandablePanel1.TitleStyle.MarginLeft = 6
        Me.expandablePanel1.TitleText = "Jobs Hierachy"
        '
        'tvStages
        '
        Me.tvStages.BackColor = System.Drawing.Color.White
        Me.tvStages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvStages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvStages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvStages.ForeColor = System.Drawing.Color.Black
        Me.tvStages.FullRowSelect = True
        Me.tvStages.Location = New System.Drawing.Point(0, 26)
        Me.tvStages.Name = "tvStages"
        Me.tvStages.Size = New System.Drawing.Size(115, 341)
        Me.tvStages.TabIndex = 4
        '
        'KryptonBorderEdge27
        '
        Me.KryptonBorderEdge27.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge27.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge27.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge27.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge27.Name = "KryptonBorderEdge27"
        Me.KryptonBorderEdge27.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge27.Size = New System.Drawing.Size(1, 367)
        Me.KryptonBorderEdge27.Text = "KryptonBorderEdge27"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 393)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(554, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip2.ForeColor = System.Drawing.Color.Black
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 394)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(554, 22)
        Me.StatusStrip2.TabIndex = 51
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(502, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "Total records selected : "
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel3.Text = "0"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(554, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAddJob, Me.btnEditJob, Me.btnDeleteJob, Me.btnJobOreps, Me.btnJobCVategories, Me.btnBrintJob})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(554, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 12
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnAddJob
        '
        Me.btnAddJob.Image = CType(resources.GetObject("btnAddJob.Image"), System.Drawing.Image)
        Me.btnAddJob.Name = "btnAddJob"
        Me.btnAddJob.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAddJob.Text = "Add"
        Me.btnAddJob.Tooltip = "Add"
        '
        'btnEditJob
        '
        Me.btnEditJob.Image = CType(resources.GetObject("btnEditJob.Image"), System.Drawing.Image)
        Me.btnEditJob.Name = "btnEditJob"
        Me.btnEditJob.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditJob.Text = "&Edit"
        Me.btnEditJob.Tooltip = "Edit"
        '
        'btnDeleteJob
        '
        Me.btnDeleteJob.BeginGroup = True
        Me.btnDeleteJob.Image = CType(resources.GetObject("btnDeleteJob.Image"), System.Drawing.Image)
        Me.btnDeleteJob.Name = "btnDeleteJob"
        Me.btnDeleteJob.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteJob.Text = "Delete"
        Me.btnDeleteJob.Tooltip = "Delete Entry"
        '
        'btnJobOreps
        '
        Me.btnJobOreps.BeginGroup = True
        Me.btnJobOreps.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnJobOreps.Image = CType(resources.GetObject("btnJobOreps.Image"), System.Drawing.Image)
        Me.btnJobOreps.Name = "btnJobOreps"
        Me.btnJobOreps.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnJobOreps.Text = "Job Oreps"
        Me.btnJobOreps.Tooltip = "Print"
        '
        'btnJobCVategories
        '
        Me.btnJobCVategories.BeginGroup = True
        Me.btnJobCVategories.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnJobCVategories.Image = CType(resources.GetObject("btnJobCVategories.Image"), System.Drawing.Image)
        Me.btnJobCVategories.Name = "btnJobCVategories"
        Me.btnJobCVategories.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnJobCVategories.Text = "Categories"
        Me.btnJobCVategories.Tooltip = "Print"
        '
        'btnBrintJob
        '
        Me.btnBrintJob.BeginGroup = True
        Me.btnBrintJob.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBrintJob.Image = CType(resources.GetObject("btnBrintJob.Image"), System.Drawing.Image)
        Me.btnBrintJob.Name = "btnBrintJob"
        Me.btnBrintJob.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBrintJob.Text = "Print"
        Me.btnBrintJob.Tooltip = "Print"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(554, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 415)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(554, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(553, 1)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 414)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 414)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'frmJobsListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 416)
        Me.Controls.Add(Me.KryptonBorderEdge6)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.Name = "frmJobsListing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Jobs"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.splitMain.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel1.PerformLayout()
        CType(Me.splitMain.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.Panel2.PerformLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        CType(Me.dGridJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expandablePanel1.ResumeLayout(False)
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnAddJob As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditJob As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteJob As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnJobOreps As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnJobCVategories As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBrintJob As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents splitMain As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents dGridJobs As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge26 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents expandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents tvStages As System.Windows.Forms.TreeView
    Friend WithEvents KryptonBorderEdge27 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
