<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

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
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Location = New System.Drawing.Point(38, 33)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(144, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(46, 98)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(81, 48)
        Me.KryptonButton1.TabIndex = 1
        Me.KryptonButton1.Values.Text = "KryptonButton1"
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.KryptonButton1)
        Me.Controls.Add(Me.Bar1)
        Me.Name = "Form5"
        Me.Text = "Form5"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
