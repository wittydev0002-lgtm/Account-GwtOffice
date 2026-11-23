<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.applicationControl1 = New AppControl.ApplicationControl()
        Me.SuspendLayout()
        '
        'applicationControl1
        '
        Me.applicationControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.applicationControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.applicationControl1.ExeName = "C:\Embassy\AccountingLight\AccountingLight\bin\Debug\AccountingLight.exe"
        Me.applicationControl1.Location = New System.Drawing.Point(31, 27)
        Me.applicationControl1.Name = "applicationControl1"
        Me.applicationControl1.Size = New System.Drawing.Size(577, 399)
        Me.applicationControl1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 458)
        Me.Controls.Add(Me.applicationControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents applicationControl1 As AppControl.ApplicationControl
End Class
