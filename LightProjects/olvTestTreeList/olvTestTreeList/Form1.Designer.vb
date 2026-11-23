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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.treeListView1 = New BrightIdeasSoftware.TreeListView()
        Me.olvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.treeListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.treeListView1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(630, 428)
        Me.KryptonPanel.TabIndex = 0
        '
        'treeListView1
        '
        Me.treeListView1.AllColumns.Add(Me.olvColumn1)
        Me.treeListView1.AllColumns.Add(Me.olvColumn2)
        Me.treeListView1.AllColumns.Add(Me.olvColumn3)
        Me.treeListView1.AllColumns.Add(Me.olvColumn4)
        Me.treeListView1.CellEditUseWholeCell = False
        Me.treeListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvColumn1, Me.olvColumn2, Me.olvColumn3, Me.olvColumn4})
        Me.treeListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeListView1.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.treeListView1.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.treeListView1.Location = New System.Drawing.Point(0, 0)
        Me.treeListView1.Name = "treeListView1"
        Me.treeListView1.ShowGroups = False
        Me.treeListView1.Size = New System.Drawing.Size(630, 428)
        Me.treeListView1.SmallImageList = Me.imageList1
        Me.treeListView1.TabIndex = 1
        Me.treeListView1.UseCompatibleStateImageBehavior = False
        Me.treeListView1.View = System.Windows.Forms.View.Details
        Me.treeListView1.VirtualMode = True
        '
        'olvColumn1
        '
        Me.olvColumn1.AspectName = "Title"
        Me.olvColumn1.Text = "Title"
        Me.olvColumn1.Width = 254
        '
        'olvColumn2
        '
        Me.olvColumn2.AspectName = "SizeInBytes"
        Me.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.olvColumn2.Text = "Size"
        Me.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.olvColumn2.Width = 102
        '
        'olvColumn3
        '
        Me.olvColumn3.AspectName = "LastPlayed"
        Me.olvColumn3.AspectToStringFormat = "{0:dd-MMM-yyyy HH:MM}"
        Me.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumn3.Text = "Last Played"
        Me.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumn3.Width = 110
        '
        'olvColumn4
        '
        Me.olvColumn4.AspectName = "Rating"
        Me.olvColumn4.Text = "Rating"
        Me.olvColumn4.Width = 85
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "star")
        Me.imageList1.Images.SetKeyName(1, "song")
        Me.imageList1.Images.SetKeyName(2, "user")
        Me.imageList1.Images.SetKeyName(3, "folder")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 428)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.treeListView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents treeListView1 As BrightIdeasSoftware.TreeListView
    Private WithEvents olvColumn1 As BrightIdeasSoftware.OLVColumn
    Private WithEvents olvColumn2 As BrightIdeasSoftware.OLVColumn
    Private WithEvents olvColumn3 As BrightIdeasSoftware.OLVColumn
    Private WithEvents olvColumn4 As BrightIdeasSoftware.OLVColumn
End Class
