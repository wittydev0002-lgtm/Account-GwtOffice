<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPriceType
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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cboPriceType = New System.Windows.Forms.ComboBox()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(284, 143)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(284, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(283, 1)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 142)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 142)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(283, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 141)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.cboPriceType)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(14, 13)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(256, 89)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 4
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(256, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 88)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(256, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(255, 1)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 87)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 87)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(114, 108)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(195, 108)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.LabelX1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(22, 35)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(72, 20)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 4
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(72, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(0, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(72, 19)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Price type"
        '
        'cboPriceType
        '
        Me.cboPriceType.FormattingEnabled = True
        Me.cboPriceType.Items.AddRange(New Object() {"Public", "Retail", "Special", "Wholesale"})
        Me.cboPriceType.Location = New System.Drawing.Point(96, 34)
        Me.cboPriceType.Name = "cboPriceType"
        Me.cboPriceType.Size = New System.Drawing.Size(138, 21)
        Me.cboPriceType.Sorted = True
        Me.cboPriceType.TabIndex = 5
        '
        'frmPriceType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 143)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPriceType"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Price Type"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboPriceType As System.Windows.Forms.ComboBox
End Class
