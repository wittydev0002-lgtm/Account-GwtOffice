<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTakeOnBalancesHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTakeOnBalancesHistory))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge35 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge34 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpStartFrom = New System.Windows.Forms.DateTimePicker()
        Me.dpEndTo = New System.Windows.Forms.DateTimePicker()
        Me.btnGo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalDebits = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalCredits = New DevComponents.DotNetBar.LabelItem()
        Me.dGridTakeOns = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalSelected = New DevComponents.DotNetBar.LabelItem()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridTakeOns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 526)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(722, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(721, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 526)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 526)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.dGridTakeOns)
        Me.KryptonPanel.Controls.Add(Me.Bar2)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.Bar1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(722, 527)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnDelete, Me.btnPrint})
        Me.Bar1.Location = New System.Drawing.Point(1, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(720, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 5
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "&Delete"
        '
        'btnPrint
        '
        Me.btnPrint.BeginGroup = True
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "Print"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(1, 25)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(720, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel8)
        Me.KryptonPanel1.Controls.Add(Me.dpStartFrom)
        Me.KryptonPanel1.Controls.Add(Me.dpEndTo)
        Me.KryptonPanel1.Controls.Add(Me.btnGo)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 26)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(720, 47)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 7
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 46)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(720, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge35)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(222, 12)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 173
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.BackColor = System.Drawing.Color.White
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel6.TabIndex = 148
        Me.KryptonLabel6.Values.Text = "Date To"
        '
        'KryptonBorderEdge35
        '
        Me.KryptonBorderEdge35.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge35.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge35.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge35.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge35.Name = "KryptonBorderEdge35"
        Me.KryptonBorderEdge35.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge35.Text = "KryptonBorderEdge35"
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge34)
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(30, 12)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(75, 22)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 172
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.White
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(75, 21)
        Me.KryptonLabel5.TabIndex = 148
        Me.KryptonLabel5.Values.Text = "Date From"
        '
        'KryptonBorderEdge34
        '
        Me.KryptonBorderEdge34.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge34.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge34.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge34.Name = "KryptonBorderEdge34"
        Me.KryptonBorderEdge34.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge34.Text = "KryptonBorderEdge34"
        '
        'dpStartFrom
        '
        Me.dpStartFrom.BackColor = System.Drawing.Color.White
        Me.dpStartFrom.ForeColor = System.Drawing.Color.Black
        Me.dpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartFrom.Location = New System.Drawing.Point(106, 14)
        Me.dpStartFrom.Name = "dpStartFrom"
        Me.dpStartFrom.Size = New System.Drawing.Size(98, 20)
        Me.dpStartFrom.TabIndex = 170
        '
        'dpEndTo
        '
        Me.dpEndTo.BackColor = System.Drawing.Color.White
        Me.dpEndTo.ForeColor = System.Drawing.Color.Black
        Me.dpEndTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndTo.Location = New System.Drawing.Point(298, 14)
        Me.dpEndTo.Name = "dpEndTo"
        Me.dpEndTo.Size = New System.Drawing.Size(95, 20)
        Me.dpEndTo.TabIndex = 169
        '
        'btnGo
        '
        Me.btnGo.AutoSize = True
        Me.btnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGo.BackColor = System.Drawing.Color.White
        Me.btnGo.ForeColor = System.Drawing.Color.Black
        Me.btnGo.Location = New System.Drawing.Point(397, 12)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(67, 22)
        Me.btnGo.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnGo.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnGo.StateCommon.Back.ColorAngle = 100.0!
        Me.btnGo.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnGo.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnGo.StateCommon.Border.Rounding = 0
        Me.btnGo.TabIndex = 171
        Me.btnGo.Values.Image = CType(resources.GetObject("btnGo.Values.Image"), System.Drawing.Image)
        Me.btnGo.Values.Text = "Process"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem2, Me.lblTotalDebits, Me.LabelItem3, Me.lblTotalCredits, Me.LabelItem4, Me.lblTotalSelected})
        Me.Bar2.Location = New System.Drawing.Point(1, 502)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingBottom = 3
        Me.Bar2.PaddingLeft = 3
        Me.Bar2.PaddingRight = 3
        Me.Bar2.PaddingTop = 3
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(720, 24)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 8
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Total"
        '
        'lblTotalDebits
        '
        Me.lblTotalDebits.BeginGroup = True
        Me.lblTotalDebits.Name = "lblTotalDebits"
        Me.lblTotalDebits.PaddingLeft = 3
        Me.lblTotalDebits.PaddingRight = 3
        Me.lblTotalDebits.Text = "0.00"
        Me.lblTotalDebits.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingLeft = 6
        Me.LabelItem2.PaddingRight = 6
        Me.LabelItem2.Text = "Debits"
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingLeft = 6
        Me.LabelItem3.PaddingRight = 6
        Me.LabelItem3.Text = "Credits"
        '
        'lblTotalCredits
        '
        Me.lblTotalCredits.Name = "lblTotalCredits"
        Me.lblTotalCredits.PaddingLeft = 6
        Me.lblTotalCredits.PaddingRight = 6
        Me.lblTotalCredits.Text = "0.00"
        '
        'dGridTakeOns
        '
        Me.dGridTakeOns.AllowUserToAddRows = False
        Me.dGridTakeOns.AllowUserToDeleteRows = False
        Me.dGridTakeOns.AllowUserToResizeRows = False
        Me.dGridTakeOns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridTakeOns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridTakeOns.Location = New System.Drawing.Point(1, 73)
        Me.dGridTakeOns.Name = "dGridTakeOns"
        Me.dGridTakeOns.ReadOnly = True
        Me.dGridTakeOns.RowHeadersVisible = False
        Me.dGridTakeOns.RowHeadersWidth = 25
        Me.dGridTakeOns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridTakeOns.Size = New System.Drawing.Size(720, 429)
        Me.dGridTakeOns.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridTakeOns.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridTakeOns.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTakeOns.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridTakeOns.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridTakeOns.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridTakeOns.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridTakeOns.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridTakeOns.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridTakeOns.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridTakeOns.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridTakeOns.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridTakeOns.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridTakeOns.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridTakeOns.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridTakeOns.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridTakeOns.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridTakeOns.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridTakeOns.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridTakeOns.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridTakeOns.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridTakeOns.TabIndex = 61
        '
        'LabelItem4
        '
        Me.LabelItem4.BeginGroup = True
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingLeft = 6
        Me.LabelItem4.PaddingRight = 6
        Me.LabelItem4.Text = "Count = "
        '
        'lblTotalSelected
        '
        Me.lblTotalSelected.Name = "lblTotalSelected"
        Me.lblTotalSelected.PaddingLeft = 6
        Me.lblTotalSelected.PaddingRight = 6
        Me.lblTotalSelected.Text = "0"
        '
        'frmTakeOnBalancesHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 527)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTakeOnBalancesHistory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Border.Width = 2
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Take-On Balances History"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridTakeOns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge35 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge34 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpStartFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpEndTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGo As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalDebits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalCredits As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridTakeOns As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalSelected As DevComponents.DotNetBar.LabelItem
End Class
