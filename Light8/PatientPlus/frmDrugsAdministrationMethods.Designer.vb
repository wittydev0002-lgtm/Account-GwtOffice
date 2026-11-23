<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrugsAdministrationMethods
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrugsAdministrationMethods))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnAdd = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtMethod = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge20 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Controls.Add(Me.btnAdd)
        Me.KryptonPanel1.Controls.Add(Me.txtMethod)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel9)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(364, 411)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.dGrid)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(15, 58)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(327, 299)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 28
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(1, 1)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(325, 297)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Method"
        Me.Column1.Name = "Column1"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 297)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(326, 1)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 297)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 298)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(327, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(327, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(268, 370)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(187, 370)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 26
        Me.btnOK.Values.Text = "&OK"
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Location = New System.Drawing.Point(295, 18)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAdd.StateCommon.Border.Rounding = 0
        Me.btnAdd.TabIndex = 25
        Me.btnAdd.Values.Image = CType(resources.GetObject("btnAdd.Values.Image"), System.Drawing.Image)
        Me.btnAdd.Values.Text = "Add"
        '
        'txtMethod
        '
        Me.txtMethod.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtMethod.Border.Class = "TextBoxBorder"
        Me.txtMethod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMethod.DisabledBackColor = System.Drawing.Color.White
        Me.txtMethod.ForeColor = System.Drawing.Color.Black
        Me.txtMethod.Location = New System.Drawing.Point(74, 18)
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.PreventEnterBeep = True
        Me.txtMethod.Size = New System.Drawing.Size(218, 22)
        Me.txtMethod.TabIndex = 24
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel9.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel9.Controls.Add(Me.KryptonBorderEdge20)
        Me.KryptonPanel9.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel9.Location = New System.Drawing.Point(12, 18)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Size = New System.Drawing.Size(61, 22)
        Me.KryptonPanel9.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel9.TabIndex = 23
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(61, 21)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Method"
        '
        'KryptonBorderEdge20
        '
        Me.KryptonBorderEdge20.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge20.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge20.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge20.Name = "KryptonBorderEdge20"
        Me.KryptonBorderEdge20.Size = New System.Drawing.Size(61, 1)
        Me.KryptonBorderEdge20.Text = "KryptonBorderEdge20"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 409)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(363, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 409)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 410)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(364, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(364, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'frmDrugsAdministrationMethods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 411)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDrugsAdministrationMethods"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Medicines Administration Methods"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnAdd As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtMethod As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge20 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
