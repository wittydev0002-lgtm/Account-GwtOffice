<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchoolClassification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchoolClassification))
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.optConvemtional = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonWrapLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.KryptonWrapLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.optNonConventional = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(515, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 297)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(515, 1)
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
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 296)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(514, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 296)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(13, 11)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonWrapLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optNonConventional)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonWrapLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optConvemtional)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(489, 246)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'optConvemtional
        '
        Me.optConvemtional.Location = New System.Drawing.Point(48, 20)
        Me.optConvemtional.Name = "optConvemtional"
        Me.optConvemtional.Size = New System.Drawing.Size(171, 20)
        Me.optConvemtional.TabIndex = 0
        Me.optConvemtional.Values.Text = "Conventional Public School"
        '
        'KryptonWrapLabel1
        '
        Me.KryptonWrapLabel1.AutoSize = False
        Me.KryptonWrapLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.KryptonWrapLabel1.Location = New System.Drawing.Point(64, 52)
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        Me.KryptonWrapLabel1.Size = New System.Drawing.Size(374, 67)
        Me.KryptonWrapLabel1.Text = resources.GetString("KryptonWrapLabel1.Text")
        '
        'KryptonWrapLabel2
        '
        Me.KryptonWrapLabel2.AutoSize = False
        Me.KryptonWrapLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.KryptonWrapLabel2.Location = New System.Drawing.Point(64, 154)
        Me.KryptonWrapLabel2.Name = "KryptonWrapLabel2"
        Me.KryptonWrapLabel2.Size = New System.Drawing.Size(374, 67)
        Me.KryptonWrapLabel2.Text = resources.GetString("KryptonWrapLabel2.Text")
        '
        'optNonConventional
        '
        Me.optNonConventional.Location = New System.Drawing.Point(48, 122)
        Me.optNonConventional.Name = "optNonConventional"
        Me.optNonConventional.Size = New System.Drawing.Size(202, 20)
        Me.optNonConventional.TabIndex = 3
        Me.optNonConventional.Values.Text = "Non Conventional Private School"
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOK.Location = New System.Drawing.Point(346, 263)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(427, 263)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        '
        'frmSchoolClassification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 298)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.KryptonGroupBox1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSchoolClassification"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "School Classification"
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonWrapLabel2 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents optNonConventional As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonWrapLabel1 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents optConvemtional As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
End Class
