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
        Me.TreeListView1 = New BrightIdeasSoftware.TreeListView()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Button1 = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.TreeListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.TreeListView1)
        Me.KryptonPanel.Controls.Add(Me.Bar1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(601, 438)
        Me.KryptonPanel.TabIndex = 0
        '
        'TreeListView1
        '
        Me.TreeListView1.CellEditUseWholeCell = False
        Me.TreeListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeListView1.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.TreeListView1.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.TreeListView1.Location = New System.Drawing.Point(0, 25)
        Me.TreeListView1.Name = "TreeListView1"
        Me.TreeListView1.ShowGroups = False
        Me.TreeListView1.Size = New System.Drawing.Size(601, 413)
        Me.TreeListView1.TabIndex = 1
        Me.TreeListView1.UseCompatibleStateImageBehavior = False
        Me.TreeListView1.View = System.Windows.Forms.View.Details
        Me.TreeListView1.VirtualMode = True
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Button1, Me.ButtonItem1})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(601, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Button1
        '
        Me.Button1.Name = "Button1"
        Me.Button1.Text = "ButtonItem1"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.BeginGroup = True
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem1.Text = "Actions"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 438)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.TreeListView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TreeListView1 As BrightIdeasSoftware.TreeListView
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Button1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
End Class
