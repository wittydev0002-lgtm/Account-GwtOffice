<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsedIndicators
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsedIndicators))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnPrint = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonWrapLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.KryptonWrapLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.KryptonGroup1 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.dgrd = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup1.Panel.SuspendLayout()
        Me.KryptonGroup1.SuspendLayout()
        CType(Me.dgrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.btnPrint)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.KryptonWrapLabel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonWrapLabel1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroup1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(337, 421)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Location = New System.Drawing.Point(168, 383)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnPrint.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnPrint.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnPrint.StateCommon.Border.Rounding = 0
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Values.Text = "&Print"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(249, 383)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'KryptonWrapLabel2
        '
        Me.KryptonWrapLabel2.AutoSize = False
        Me.KryptonWrapLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonWrapLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.KryptonWrapLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KryptonWrapLabel2.Location = New System.Drawing.Point(90, 12)
        Me.KryptonWrapLabel2.Name = "KryptonWrapLabel2"
        Me.KryptonWrapLabel2.Size = New System.Drawing.Size(234, 53)
        Me.KryptonWrapLabel2.Text = "The indicator you are trying to delete has been used in the following calculation" & _
    "s. Remove it from calculations first."
        Me.KryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonWrapLabel1
        '
        Me.KryptonWrapLabel1.AutoSize = False
        Me.KryptonWrapLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonWrapLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.KryptonWrapLabel1.Image = CType(resources.GetObject("KryptonWrapLabel1.Image"), System.Drawing.Image)
        Me.KryptonWrapLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KryptonWrapLabel1.Location = New System.Drawing.Point(13, 12)
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        Me.KryptonWrapLabel1.Size = New System.Drawing.Size(69, 53)
        Me.KryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonGroup1
        '
        Me.KryptonGroup1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroup1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup1.Location = New System.Drawing.Point(13, 74)
        Me.KryptonGroup1.Name = "KryptonGroup1"
        '
        'KryptonGroup1.Panel
        '
        Me.KryptonGroup1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroup1.Panel.Controls.Add(Me.dgrd)
        Me.KryptonGroup1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup1.Size = New System.Drawing.Size(311, 303)
        Me.KryptonGroup1.TabIndex = 1
        '
        'dgrd
        '
        Me.dgrd.AllowUserToAddRows = False
        Me.dgrd.AllowUserToDeleteRows = False
        Me.dgrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrd.Location = New System.Drawing.Point(0, 0)
        Me.dgrd.Name = "dgrd"
        Me.dgrd.ReadOnly = True
        Me.dgrd.RowHeadersWidth = 25
        Me.dgrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrd.Size = New System.Drawing.Size(309, 301)
        Me.dgrd.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dgrd.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dgrd.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgrd.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrd.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrd.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrd.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrd.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrd.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrd.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgrd.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dgrd.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrd.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column1.HeaderText = "Calc No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 78
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column2.HeaderText = "Line No"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 77
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Indicator"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 420)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(337, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(337, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(336, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 419)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 419)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'frmUsedIndicators
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 421)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsedIndicators"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Indicator Usage In Calculations"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.ResumeLayout(False)
        CType(Me.dgrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonGroup1 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents dgrd As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnPrint As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonWrapLabel2 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents KryptonWrapLabel1 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
