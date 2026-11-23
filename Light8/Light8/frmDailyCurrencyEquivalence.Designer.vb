<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyCurrencyEquivalence
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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtAmount = New Numberbox.Numberbox()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtRatedRand = New Numberbox.Numberbox()
        Me.txtRatedUsd = New Numberbox.Numberbox()
        Me.txtRatedEcocash = New Numberbox.Numberbox()
        Me.txtRatedBond = New Numberbox.Numberbox()
        Me.txtRatedSwipe = New Numberbox.Numberbox()
        Me.txtRatedTransfer = New Numberbox.Numberbox()
        Me.txtRatedOther = New Numberbox.Numberbox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.Label1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Location = New System.Drawing.Point(17, 15)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(106, 23)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "US Dollar Amount"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(106, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'txtAmount
        '
        Me.txtAmount.AllowDecimal = True
        Me.txtAmount.Location = New System.Drawing.Point(127, 18)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(91, 20)
        Me.txtAmount.TabIndex = 1
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.ThousandsSeperator = False
        Me.txtAmount.ZeroOutEmptyStringOnLostFocus = False
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(220, 16)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(66, 23)
        Me.btnCalculate.TabIndex = 2
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(17, 53)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedRand)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedUsd)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedEcocash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedBond)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedSwipe)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedTransfer)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtRatedOther)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label9)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label8)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label6)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(268, 223)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 3
        Me.KryptonGroupBox1.Text = "Equivalent to ..."
        Me.KryptonGroupBox1.Values.Heading = "Equivalent to ..."
        '
        'txtRatedRand
        '
        Me.txtRatedRand.AllowDecimal = True
        Me.txtRatedRand.Enabled = False
        Me.txtRatedRand.Location = New System.Drawing.Point(128, 47)
        Me.txtRatedRand.Name = "txtRatedRand"
        Me.txtRatedRand.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedRand.TabIndex = 86
        Me.txtRatedRand.Text = "0.00"
        Me.txtRatedRand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedRand.ThousandsSeperator = False
        Me.txtRatedRand.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtRatedUsd
        '
        Me.txtRatedUsd.AllowDecimal = True
        Me.txtRatedUsd.Enabled = False
        Me.txtRatedUsd.Location = New System.Drawing.Point(128, 25)
        Me.txtRatedUsd.Name = "txtRatedUsd"
        Me.txtRatedUsd.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedUsd.TabIndex = 85
        Me.txtRatedUsd.Text = "0.00"
        Me.txtRatedUsd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedUsd.ThousandsSeperator = False
        Me.txtRatedUsd.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtRatedEcocash
        '
        Me.txtRatedEcocash.AllowDecimal = True
        Me.txtRatedEcocash.Enabled = False
        Me.txtRatedEcocash.Location = New System.Drawing.Point(128, 91)
        Me.txtRatedEcocash.Name = "txtRatedEcocash"
        Me.txtRatedEcocash.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedEcocash.TabIndex = 81
        Me.txtRatedEcocash.Text = "0.00"
        Me.txtRatedEcocash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedEcocash.ThousandsSeperator = False
        Me.txtRatedEcocash.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtRatedBond
        '
        Me.txtRatedBond.AllowDecimal = True
        Me.txtRatedBond.Enabled = False
        Me.txtRatedBond.Location = New System.Drawing.Point(128, 69)
        Me.txtRatedBond.Name = "txtRatedBond"
        Me.txtRatedBond.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedBond.TabIndex = 80
        Me.txtRatedBond.Text = "0.00"
        Me.txtRatedBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedBond.ThousandsSeperator = False
        Me.txtRatedBond.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtRatedSwipe
        '
        Me.txtRatedSwipe.AllowDecimal = True
        Me.txtRatedSwipe.Enabled = False
        Me.txtRatedSwipe.Location = New System.Drawing.Point(128, 113)
        Me.txtRatedSwipe.Name = "txtRatedSwipe"
        Me.txtRatedSwipe.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedSwipe.TabIndex = 82
        Me.txtRatedSwipe.Text = "0.00"
        Me.txtRatedSwipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedSwipe.ThousandsSeperator = False
        Me.txtRatedSwipe.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtRatedTransfer
        '
        Me.txtRatedTransfer.AllowDecimal = True
        Me.txtRatedTransfer.Enabled = False
        Me.txtRatedTransfer.Location = New System.Drawing.Point(128, 135)
        Me.txtRatedTransfer.Name = "txtRatedTransfer"
        Me.txtRatedTransfer.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedTransfer.TabIndex = 83
        Me.txtRatedTransfer.Text = "0.00"
        Me.txtRatedTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedTransfer.ThousandsSeperator = False
        Me.txtRatedTransfer.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtRatedOther
        '
        Me.txtRatedOther.AllowDecimal = True
        Me.txtRatedOther.Enabled = False
        Me.txtRatedOther.Location = New System.Drawing.Point(128, 157)
        Me.txtRatedOther.Name = "txtRatedOther"
        Me.txtRatedOther.Size = New System.Drawing.Size(118, 20)
        Me.txtRatedOther.TabIndex = 84
        Me.txtRatedOther.Text = "0.00"
        Me.txtRatedOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRatedOther.ThousandsSeperator = False
        Me.txtRatedOther.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(21, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label9.Size = New System.Drawing.Size(101, 20)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Cash RAND"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(21, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(101, 20)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Cash USD"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(21, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(101, 20)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Other"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(21, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Transfer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 112)
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
        Me.Label2.Location = New System.Drawing.Point(21, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Ecocash"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(21, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(101, 20)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "CASH BOND"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(219, 282)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmDailyCurrencyEquivalence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 320)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.KryptonGroupBox1)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDailyCurrencyEquivalence"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "USD Equivalent"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As Numberbox.Numberbox
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRatedRand As Numberbox.Numberbox
    Friend WithEvents txtRatedUsd As Numberbox.Numberbox
    Friend WithEvents txtRatedEcocash As Numberbox.Numberbox
    Friend WithEvents txtRatedBond As Numberbox.Numberbox
    Friend WithEvents txtRatedSwipe As Numberbox.Numberbox
    Friend WithEvents txtRatedTransfer As Numberbox.Numberbox
    Friend WithEvents txtRatedOther As Numberbox.Numberbox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
