<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGatePassPrintOptions
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
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.optBoth = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optDelivery = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optGatePass = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.grpDelivery = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtAddress4 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtAddress3 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtAddress2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtAddress1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel14 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge14 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtCustomer = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge13 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.grpDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpDelivery.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDelivery.Panel.SuspendLayout()
        Me.grpDelivery.SuspendLayout()
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel14.SuspendLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOk)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(517, 283)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(430, 246)
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
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(349, 246)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOk.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOk.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOk.StateCommon.Border.Rounding = 0
        Me.btnOk.TabIndex = 1
        Me.btnOk.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optBoth)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optDelivery)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optGatePass)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.grpDelivery)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(493, 228)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'optBoth
        '
        Me.optBoth.Location = New System.Drawing.Point(284, 18)
        Me.optBoth.Name = "optBoth"
        Me.optBoth.Size = New System.Drawing.Size(48, 20)
        Me.optBoth.TabIndex = 8
        Me.optBoth.Values.Text = "Both"
        '
        'optDelivery
        '
        Me.optDelivery.Location = New System.Drawing.Point(144, 18)
        Me.optDelivery.Name = "optDelivery"
        Me.optDelivery.Size = New System.Drawing.Size(121, 20)
        Me.optDelivery.TabIndex = 7
        Me.optDelivery.Values.Text = "Delivery note only"
        '
        'optGatePass
        '
        Me.optGatePass.Checked = True
        Me.optGatePass.Location = New System.Drawing.Point(23, 18)
        Me.optGatePass.Name = "optGatePass"
        Me.optGatePass.Size = New System.Drawing.Size(102, 20)
        Me.optGatePass.TabIndex = 6
        Me.optGatePass.Values.Text = "Gate pass only"
        '
        'grpDelivery
        '
        Me.grpDelivery.Enabled = False
        Me.grpDelivery.Location = New System.Drawing.Point(14, 52)
        Me.grpDelivery.Name = "grpDelivery"
        '
        'grpDelivery.Panel
        '
        Me.grpDelivery.Panel.Controls.Add(Me.txtAddress4)
        Me.grpDelivery.Panel.Controls.Add(Me.txtAddress3)
        Me.grpDelivery.Panel.Controls.Add(Me.txtAddress2)
        Me.grpDelivery.Panel.Controls.Add(Me.txtAddress1)
        Me.grpDelivery.Panel.Controls.Add(Me.KryptonPanel14)
        Me.grpDelivery.Panel.Controls.Add(Me.txtCustomer)
        Me.grpDelivery.Panel.Controls.Add(Me.KryptonPanel13)
        Me.grpDelivery.Size = New System.Drawing.Size(465, 158)
        Me.grpDelivery.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.grpDelivery.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.grpDelivery.StateCommon.Border.Rounding = 0
        Me.grpDelivery.TabIndex = 5
        Me.grpDelivery.Text = "Recipient"
        Me.grpDelivery.Values.Heading = "Recipient"
        '
        'txtAddress4
        '
        Me.txtAddress4.Location = New System.Drawing.Point(114, 95)
        Me.txtAddress4.MaxLength = 50
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(335, 20)
        Me.txtAddress4.TabIndex = 131
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(114, 75)
        Me.txtAddress3.MaxLength = 50
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(335, 20)
        Me.txtAddress3.TabIndex = 130
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(114, 55)
        Me.txtAddress2.MaxLength = 50
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(335, 20)
        Me.txtAddress2.TabIndex = 129
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(114, 35)
        Me.txtAddress1.MaxLength = 50
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(335, 20)
        Me.txtAddress1.TabIndex = 128
        '
        'KryptonPanel14
        '
        Me.KryptonPanel14.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPanel14.Controls.Add(Me.KryptonBorderEdge14)
        Me.KryptonPanel14.Location = New System.Drawing.Point(11, 34)
        Me.KryptonPanel14.Name = "KryptonPanel14"
        Me.KryptonPanel14.Size = New System.Drawing.Size(101, 21)
        Me.KryptonPanel14.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel14.TabIndex = 127
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(101, 20)
        Me.KryptonLabel6.TabIndex = 116
        Me.KryptonLabel6.Values.Text = "Delivery address"
        '
        'KryptonBorderEdge14
        '
        Me.KryptonBorderEdge14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge14.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge14.Name = "KryptonBorderEdge14"
        Me.KryptonBorderEdge14.Size = New System.Drawing.Size(101, 1)
        Me.KryptonBorderEdge14.Text = "KryptonBorderEdge14"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(114, 12)
        Me.txtCustomer.MaxLength = 75
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(335, 20)
        Me.txtCustomer.TabIndex = 126
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge13)
        Me.KryptonPanel13.Location = New System.Drawing.Point(11, 9)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(101, 23)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 125
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(101, 22)
        Me.KryptonLabel5.TabIndex = 116
        Me.KryptonLabel5.Values.Text = "Recipient name"
        '
        'KryptonBorderEdge13
        '
        Me.KryptonBorderEdge13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge13.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge13.Name = "KryptonBorderEdge13"
        Me.KryptonBorderEdge13.Size = New System.Drawing.Size(101, 1)
        Me.KryptonBorderEdge13.Text = "KryptonBorderEdge13"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 282)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(517, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(516, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 282)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 282)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'frmGatePassPrintOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 283)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGatePassPrintOptions"
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
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Gate Pass Print Options"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.grpDelivery.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDelivery.Panel.ResumeLayout(False)
        Me.grpDelivery.Panel.PerformLayout()
        CType(Me.grpDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDelivery.ResumeLayout(False)
        CType(Me.KryptonPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel14.ResumeLayout(False)
        Me.KryptonPanel14.PerformLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
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
    Friend WithEvents grpDelivery As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtAddress4 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtAddress3 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtAddress2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtAddress1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel14 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge14 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtCustomer As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge13 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents optBoth As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optDelivery As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optGatePass As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
