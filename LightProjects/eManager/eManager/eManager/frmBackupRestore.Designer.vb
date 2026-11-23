<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupRestore
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
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnRestore = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnBackup = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(220, 136)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnRestore)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnBackup)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(195, 82)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 3
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'btnRestore
        '
        Me.btnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRestore.Location = New System.Drawing.Point(29, 40)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(134, 22)
        Me.btnRestore.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnRestore.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnRestore.StateCommon.Back.ColorAngle = 100.0!
        Me.btnRestore.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnRestore.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnRestore.StateCommon.Border.Rounding = 0
        Me.btnRestore.TabIndex = 2
        Me.btnRestore.Values.Text = "&Restore data"
        '
        'btnBackup
        '
        Me.btnBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBackup.Location = New System.Drawing.Point(29, 12)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(134, 22)
        Me.btnBackup.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnBackup.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnBackup.StateCommon.Back.ColorAngle = 100.0!
        Me.btnBackup.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnBackup.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnBackup.StateCommon.Border.Rounding = 0
        Me.btnBackup.TabIndex = 1
        Me.btnBackup.Values.Text = "&Backup data"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(132, 99)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'frmBackupRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(220, 136)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackupRestore"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Data Backup and Restore"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
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
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnBackup As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnRestore As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
End Class
