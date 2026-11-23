<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayMethodChange
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
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBillTotal = New Numberbox.Numberbox()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.txtTenderExchangeEcocash = New Numberbox.Numberbox()
        Me.txtTenderExchangeCash = New Numberbox.Numberbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTenderExchangeSwipe = New Numberbox.Numberbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTenderExchangeTransfer = New Numberbox.Numberbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenderExchangeOther = New Numberbox.Numberbox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.Label6)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.txtBillTotal)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(298, 306)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(209, 260)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(128, 260)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblTotalPaid)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeEcocash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeCash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeSwipe)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeTransfer)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeOther)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label1)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(272, 199)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "Amounts Splits ..."
        Me.KryptonGroupBox1.Values.Heading = "Amounts Splits ..."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(51, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(101, 20)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Receipt Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBillTotal
        '
        Me.txtBillTotal.AllowDecimal = True
        Me.txtBillTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtBillTotal.Enabled = False
        Me.txtBillTotal.Location = New System.Drawing.Point(154, 18)
        Me.txtBillTotal.Name = "txtBillTotal"
        Me.txtBillTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtBillTotal.TabIndex = 51
        Me.txtBillTotal.Text = "0.00"
        Me.txtBillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBillTotal.ThousandsSeperator = False
        Me.txtBillTotal.ZeroOutEmptyStringOnLostFocus = False
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPaid.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.ForeColor = System.Drawing.Color.White
        Me.lblTotalPaid.Location = New System.Drawing.Point(142, 133)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTotalPaid.Size = New System.Drawing.Size(89, 20)
        Me.lblTotalPaid.TabIndex = 68
        Me.lblTotalPaid.Text = "0.00"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTenderExchangeEcocash
        '
        Me.txtTenderExchangeEcocash.AllowDecimal = True
        Me.txtTenderExchangeEcocash.Location = New System.Drawing.Point(142, 44)
        Me.txtTenderExchangeEcocash.Name = "txtTenderExchangeEcocash"
        Me.txtTenderExchangeEcocash.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeEcocash.TabIndex = 56
        Me.txtTenderExchangeEcocash.Text = "0.00"
        Me.txtTenderExchangeEcocash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeEcocash.ThousandsSeperator = False
        Me.txtTenderExchangeEcocash.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtTenderExchangeCash
        '
        Me.txtTenderExchangeCash.AllowDecimal = True
        Me.txtTenderExchangeCash.Location = New System.Drawing.Point(142, 23)
        Me.txtTenderExchangeCash.Name = "txtTenderExchangeCash"
        Me.txtTenderExchangeCash.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeCash.TabIndex = 54
        Me.txtTenderExchangeCash.Text = "0.00"
        Me.txtTenderExchangeCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeCash.ThousandsSeperator = False
        Me.txtTenderExchangeCash.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(39, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(101, 20)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Other"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderExchangeSwipe
        '
        Me.txtTenderExchangeSwipe.AllowDecimal = True
        Me.txtTenderExchangeSwipe.Location = New System.Drawing.Point(142, 66)
        Me.txtTenderExchangeSwipe.Name = "txtTenderExchangeSwipe"
        Me.txtTenderExchangeSwipe.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeSwipe.TabIndex = 58
        Me.txtTenderExchangeSwipe.Text = "0.00"
        Me.txtTenderExchangeSwipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeSwipe.ThousandsSeperator = False
        Me.txtTenderExchangeSwipe.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(39, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Transfer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderExchangeTransfer
        '
        Me.txtTenderExchangeTransfer.AllowDecimal = True
        Me.txtTenderExchangeTransfer.Location = New System.Drawing.Point(142, 88)
        Me.txtTenderExchangeTransfer.Name = "txtTenderExchangeTransfer"
        Me.txtTenderExchangeTransfer.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeTransfer.TabIndex = 60
        Me.txtTenderExchangeTransfer.Text = "0.00"
        Me.txtTenderExchangeTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeTransfer.ThousandsSeperator = False
        Me.txtTenderExchangeTransfer.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(39, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Swipe"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(39, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Ecocash"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderExchangeOther
        '
        Me.txtTenderExchangeOther.AllowDecimal = True
        Me.txtTenderExchangeOther.Location = New System.Drawing.Point(142, 110)
        Me.txtTenderExchangeOther.Name = "txtTenderExchangeOther"
        Me.txtTenderExchangeOther.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeOther.TabIndex = 62
        Me.txtTenderExchangeOther.Text = "0.00"
        Me.txtTenderExchangeOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeOther.ThousandsSeperator = False
        Me.txtTenderExchangeOther.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(39, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Cash"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPayMethodChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 306)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPayMethodChange"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Border.Width = 2
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Receipt Payment Split"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBillTotal As Numberbox.Numberbox
    Friend WithEvents lblTotalPaid As System.Windows.Forms.Label
    Friend WithEvents txtTenderExchangeEcocash As Numberbox.Numberbox
    Friend WithEvents txtTenderExchangeCash As Numberbox.Numberbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTenderExchangeSwipe As Numberbox.Numberbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTenderExchangeTransfer As Numberbox.Numberbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTenderExchangeOther As Numberbox.Numberbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
