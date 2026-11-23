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
        Me.olvSongs = New BrightIdeasSoftware.TreeListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.olvSongs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.olvSongs)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(412, 340)
        Me.KryptonPanel.TabIndex = 0
        '
        'olvSongs
        '
        Me.olvSongs.AllColumns.Add(Me.OlvColumn1)
        Me.olvSongs.AllColumns.Add(Me.OlvColumn2)
        Me.olvSongs.AllColumns.Add(Me.OlvColumn3)
        Me.olvSongs.AllColumns.Add(Me.OlvColumn4)
        Me.olvSongs.CellEditUseWholeCell = False
        Me.olvSongs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4})
        Me.olvSongs.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvSongs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvSongs.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvSongs.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvSongs.Location = New System.Drawing.Point(0, 0)
        Me.olvSongs.Name = "olvSongs"
        Me.olvSongs.ShowGroups = False
        Me.olvSongs.Size = New System.Drawing.Size(412, 340)
        Me.olvSongs.TabIndex = 0
        Me.olvSongs.UseCompatibleStateImageBehavior = False
        Me.olvSongs.View = System.Windows.Forms.View.Details
        Me.olvSongs.VirtualMode = True
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Title"
        Me.OlvColumn1.AspectToStringFormat = "{0}"
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "LastPlayed"
        Me.OlvColumn2.AspectToStringFormat = "{0:d}"
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "GetSizeInMb"
        Me.OlvColumn3.AspectToStringFormat = "{0:#,##0.0}"
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Rating"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 340)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.olvSongs, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents olvSongs As BrightIdeasSoftware.TreeListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
End Class
