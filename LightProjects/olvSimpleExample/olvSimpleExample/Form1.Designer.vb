<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ObjectListView1 = New BrightIdeasSoftware.TreeListView()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.ObjectListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.ObjectListView1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(430, 309)
        Me.KryptonPanel.TabIndex = 0
        '
        'ObjectListView1
        '
        Me.ObjectListView1.CellEditUseWholeCell = False
        Me.ObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectListView1.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.ObjectListView1.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.ObjectListView1.Location = New System.Drawing.Point(0, 0)
        Me.ObjectListView1.Name = "ObjectListView1"
        Me.ObjectListView1.ShowGroups = False
        Me.ObjectListView1.Size = New System.Drawing.Size(430, 309)
        Me.ObjectListView1.TabIndex = 0
        Me.ObjectListView1.UseCompatibleStateImageBehavior = False
        Me.ObjectListView1.View = System.Windows.Forms.View.Details
        Me.ObjectListView1.VirtualMode = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 309)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.ObjectListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents ObjectListView1 As BrightIdeasSoftware.TreeListView
End Class
