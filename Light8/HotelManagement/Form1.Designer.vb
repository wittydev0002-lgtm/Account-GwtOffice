<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.KryptonGroupBox3 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtRoomNumber = New Numberbox.Numberbox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        CType(Me.KryptonGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox3.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox3.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonGroupBox3
        '
        Me.KryptonGroupBox3.Location = New System.Drawing.Point(435, 303)
        Me.KryptonGroupBox3.Name = "KryptonGroupBox3"
        Me.KryptonGroupBox3.Size = New System.Drawing.Size(297, 196)
        Me.KryptonGroupBox3.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox3.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox3.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox3.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox3.TabIndex = 114
        Me.KryptonGroupBox3.Text = "Bill to ..."
        Me.KryptonGroupBox3.Values.Heading = "Bill to ..."
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(435, 78)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(297, 187)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 111
        Me.KryptonGroupBox2.Text = "Other services"
        Me.KryptonGroupBox2.Values.Heading = "Other services"
        '
        'txtRoomNumber
        '
        Me.txtRoomNumber.AllowDecimal = True
        Me.txtRoomNumber.Location = New System.Drawing.Point(559, 52)
        Me.txtRoomNumber.Name = "txtRoomNumber"
        Me.txtRoomNumber.Size = New System.Drawing.Size(59, 20)
        Me.txtRoomNumber.TabIndex = 110
        Me.txtRoomNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoomNumber.ThousandsSeperator = False
        Me.txtRoomNumber.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(435, 52)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(123, 20)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 109
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(123, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(123, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Room number"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(28, 303)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(395, 196)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 108
        Me.KryptonGroupBox1.Text = "Deposited items ..."
        Me.KryptonGroupBox1.Values.Heading = "Deposited items ..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 548)
        Me.Controls.Add(Me.KryptonGroupBox3)
        Me.Controls.Add(Me.KryptonGroupBox2)
        Me.Controls.Add(Me.txtRoomNumber)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonGroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.KryptonGroupBox3.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox3.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonGroupBox3 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtRoomNumber As Numberbox.Numberbox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
End Class
