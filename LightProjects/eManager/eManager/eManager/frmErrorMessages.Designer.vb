<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorMessages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrorMessages))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.btnReconnect = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEmailError = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSmsError = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnCopy = New DevComponents.DotNetBar.ButtonX()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtErrors = New ComponentFactory.Krypton.Toolkit.KryptonRichTextBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
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
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.ButtonX3)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnCopy)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(552, 298)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(18, 15)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(512, 68)
        Me.KryptonLabel1.TabIndex = 5
        Me.KryptonLabel1.Values.Image = CType(resources.GetObject("KryptonLabel1.Values.Image"), System.Drawing.Image)
        Me.KryptonLabel1.Values.Text = resources.GetString("KryptonLabel1.Values.Text")
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.BackColor = System.Drawing.Color.White
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(251, 266)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.PopupSide = DevComponents.DotNetBar.ePopupSide.Top
        Me.ButtonX3.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonX3.Size = New System.Drawing.Size(112, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.ButtonX3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReconnect, Me.btnEmailError, Me.btnSmsError})
        Me.ButtonX3.TabIndex = 4
        Me.ButtonX3.Text = "Possible Actions"
        '
        'btnReconnect
        '
        Me.btnReconnect.Name = "btnReconnect"
        Me.btnReconnect.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReconnect.Text = "Reconnect Database"
        '
        'btnEmailError
        '
        Me.btnEmailError.BeginGroup = True
        Me.btnEmailError.Name = "btnEmailError"
        Me.btnEmailError.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEmailError.Text = "Email Error Message"
        '
        'btnSmsError
        '
        Me.btnSmsError.Name = "btnSmsError"
        Me.btnSmsError.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSmsError.Text = "SMS Error Message"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Location = New System.Drawing.Point(460, 266)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnCopy
        '
        Me.btnCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCopy.BackColor = System.Drawing.Color.White
        Me.btnCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCopy.Location = New System.Drawing.Point(379, 266)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnCopy.TabIndex = 1
        Me.btnCopy.Text = "Copy"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 106)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtErrors)
        Me.KryptonGroupBox1.Panel.Padding = New System.Windows.Forms.Padding(10)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(523, 154)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "Error message"
        Me.KryptonGroupBox1.Values.Heading = "Error message"
        '
        'txtErrors
        '
        Me.txtErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtErrors.Location = New System.Drawing.Point(10, 10)
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.Size = New System.Drawing.Size(501, 111)
        Me.txtErrors.TabIndex = 1
        Me.txtErrors.Text = ""
        '
        'frmErrorMessages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 298)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmErrorMessages"
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
        Me.Text = "Error Messages"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
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
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtErrors As ComponentFactory.Krypton.Toolkit.KryptonRichTextBox
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReconnect As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEmailError As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSmsError As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCopy As DevComponents.DotNetBar.ButtonX
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
