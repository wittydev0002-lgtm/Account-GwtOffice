<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClassGroups
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClassGroups))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnSaveAll = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtGroup = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnAdd = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(364, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 462)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(364, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 461)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(363, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 461)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSaveAll})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(362, 33)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSaveAll.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSaveAll.Text = "&Save All"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 34)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(362, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(8, 14)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(80, 22)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 6
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(80, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "New group"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(80, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'txtGroup
        '
        Me.txtGroup.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtGroup.Border.Class = "TextBoxBorder"
        Me.txtGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtGroup.DisabledBackColor = System.Drawing.Color.White
        Me.txtGroup.ForeColor = System.Drawing.Color.Black
        Me.txtGroup.Location = New System.Drawing.Point(89, 14)
        Me.txtGroup.MaxLength = 75
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.PreventEnterBeep = True
        Me.txtGroup.Size = New System.Drawing.Size(209, 22)
        Me.txtGroup.TabIndex = 7
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Location = New System.Drawing.Point(301, 14)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control
        Me.btnAdd.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAdd.StateCommon.Border.Rounding = 0
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Values.Image = CType(resources.GetObject("btnAdd.Values.Image"), System.Drawing.Image)
        Me.btnAdd.Values.Text = "Add"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.dGrid)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel2.Controls.Add(Me.btnAdd)
        Me.KryptonPanel2.Controls.Add(Me.txtGroup)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(1, 35)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(362, 427)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.SystemColors.Control
        Me.KryptonPanel2.TabIndex = 9
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dGrid.Location = New System.Drawing.Point(0, 52)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.Size = New System.Drawing.Size(362, 375)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 9
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Group Name"
        Me.Column1.Name = "Column1"
        '
        'frmClassGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 463)
        Me.Controls.Add(Me.KryptonPanel2)
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
        Me.Name = "frmClassGroups"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Class Groups"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSaveAll As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtGroup As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnAdd As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
