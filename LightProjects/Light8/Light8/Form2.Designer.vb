<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.picLight = New System.Windows.Forms.PictureBox()
        Me.TreeGridView1 = New AdvancedDataGridView.TreeGridView()
        CType(Me.picLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picLight
        '
        Me.picLight.BackColor = System.Drawing.SystemColors.Control
        Me.picLight.Image = CType(resources.GetObject("picLight.Image"), System.Drawing.Image)
        Me.picLight.Location = New System.Drawing.Point(0, 62)
        Me.picLight.Name = "picLight"
        Me.picLight.Size = New System.Drawing.Size(600, 400)
        Me.picLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLight.TabIndex = 2
        Me.picLight.TabStop = False
        '
        'TreeGridView1
        '
        Me.TreeGridView1.AllowUserToAddRows = False
        Me.TreeGridView1.AllowUserToDeleteRows = False
        Me.TreeGridView1.BackgroundColor = System.Drawing.Color.White
        Me.TreeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TreeGridView1.ImageList = Nothing
        Me.TreeGridView1.Location = New System.Drawing.Point(36, 477)
        Me.TreeGridView1.Name = "TreeGridView1"
        Me.TreeGridView1.Size = New System.Drawing.Size(162, 28)
        Me.TreeGridView1.TabIndex = 3
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 525)
        Me.Controls.Add(Me.TreeGridView1)
        Me.Controls.Add(Me.picLight)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.picLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picLight As System.Windows.Forms.PictureBox
    Friend WithEvents TreeGridView1 As AdvancedDataGridView.TreeGridView
End Class
