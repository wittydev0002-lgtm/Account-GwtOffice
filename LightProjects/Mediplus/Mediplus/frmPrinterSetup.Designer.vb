<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrinterSetup
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
        Me.btnTestPrint = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox3 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtComPort = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnSetDefaultPrinter = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.optUsb = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optSerial = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox3.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox3.Panel.SuspendLayout()
        Me.KryptonGroupBox3.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnTestPrint)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox3)
        Me.KryptonPanel.Controls.Add(Me.btnSetDefaultPrinter)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(392, 424)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnTestPrint
        '
        Me.btnTestPrint.Location = New System.Drawing.Point(13, 383)
        Me.btnTestPrint.Name = "btnTestPrint"
        Me.btnTestPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnTestPrint.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnTestPrint.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnTestPrint.StateCommon.Back.ColorAngle = 100.0!
        Me.btnTestPrint.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnTestPrint.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnTestPrint.StateCommon.Border.Rounding = 0
        Me.btnTestPrint.TabIndex = 13
        Me.btnTestPrint.Values.Text = "&Test"
        Me.btnTestPrint.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(302, 383)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(221, 383)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 11
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox3
        '
        Me.KryptonGroupBox3.Location = New System.Drawing.Point(13, 298)
        Me.KryptonGroupBox3.Name = "KryptonGroupBox3"
        '
        'KryptonGroupBox3.Panel
        '
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.txtComPort)
        Me.KryptonGroupBox3.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox3.Size = New System.Drawing.Size(364, 79)
        Me.KryptonGroupBox3.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox3.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox3.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox3.TabIndex = 10
        Me.KryptonGroupBox3.Text = "Com Port"
        Me.KryptonGroupBox3.Values.Heading = "Com Port"
        '
        'txtComPort
        '
        Me.txtComPort.Location = New System.Drawing.Point(269, 18)
        Me.txtComPort.MaxLength = 2
        Me.txtComPort.Name = "txtComPort"
        Me.txtComPort.Size = New System.Drawing.Size(87, 20)
        Me.txtComPort.TabIndex = 1
        Me.txtComPort.Text = "3"
        Me.txtComPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(18, 18)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(148, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Enter COM Port number :"
        '
        'btnSetDefaultPrinter
        '
        Me.btnSetDefaultPrinter.Location = New System.Drawing.Point(110, 383)
        Me.btnSetDefaultPrinter.Name = "btnSetDefaultPrinter"
        Me.btnSetDefaultPrinter.Size = New System.Drawing.Size(95, 25)
        Me.btnSetDefaultPrinter.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnSetDefaultPrinter.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnSetDefaultPrinter.StateCommon.Back.ColorAngle = 100.0!
        Me.btnSetDefaultPrinter.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnSetDefaultPrinter.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSetDefaultPrinter.StateCommon.Border.Rounding = 0
        Me.btnSetDefaultPrinter.TabIndex = 9
        Me.btnSetDefaultPrinter.Values.Text = "Set as default"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(13, 98)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.ListBox1)
        Me.KryptonGroupBox2.Panel.Padding = New System.Windows.Forms.Padding(5, 3, 5, 5)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(363, 191)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 8
        Me.KryptonGroupBox2.Text = "Available Printers"
        Me.KryptonGroupBox2.Values.Heading = "Available Printers"
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Location = New System.Drawing.Point(5, 3)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(351, 160)
        Me.ListBox1.TabIndex = 1
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optUsb)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.optSerial)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(364, 79)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 7
        Me.KryptonGroupBox1.Text = "Connection Type"
        Me.KryptonGroupBox1.Values.Heading = "Connection Type"
        '
        'optUsb
        '
        Me.optUsb.Location = New System.Drawing.Point(184, 16)
        Me.optUsb.Name = "optUsb"
        Me.optUsb.Size = New System.Drawing.Size(71, 20)
        Me.optUsb.TabIndex = 1
        Me.optUsb.Values.Text = "USB Port"
        '
        'optSerial
        '
        Me.optSerial.Checked = True
        Me.optSerial.Location = New System.Drawing.Point(65, 16)
        Me.optSerial.Name = "optSerial"
        Me.optSerial.Size = New System.Drawing.Size(78, 20)
        Me.optSerial.TabIndex = 0
        Me.optSerial.Values.Text = "Serial Port"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(391, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 422)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 422)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(392, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 423)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(392, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmPrinterSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrinterSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Back.ColorAngle = 120.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Switch33
        Me.StateCommon.Header.Content.LongText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.LongText.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White
        Me.Text = "Printer Setup"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox3.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox3.Panel.ResumeLayout(False)
        Me.KryptonGroupBox3.Panel.PerformLayout()
        CType(Me.KryptonGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox3.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
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
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnTestPrint As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox3 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents txtComPort As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnSetDefaultPrinter As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents optUsb As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optSerial As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
End Class
