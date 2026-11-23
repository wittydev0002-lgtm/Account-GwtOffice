<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountSettlement
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
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtAmountExchange = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cboCurrency = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountExchange)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmount)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(478, 111)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Text = "Payments"
        Me.KryptonGroupBox1.Values.Heading = "Payments"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel4.Location = New System.Drawing.Point(59, 41)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(170, 23)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 14
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(170, 22)
        Me.KryptonLabel3.TabIndex = 14
        Me.KryptonLabel3.Values.Text = "Default Currency Equevalent"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(170, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'txtAmountExchange
        '
        Me.txtAmountExchange.Enabled = False
        Me.txtAmountExchange.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountExchange.Location = New System.Drawing.Point(230, 42)
        Me.txtAmountExchange.Name = "txtAmountExchange"
        Me.txtAmountExchange.Size = New System.Drawing.Size(117, 22)
        Me.txtAmountExchange.TabIndex = 8
        Me.txtAmountExchange.Text = "0.00"
        Me.txtAmountExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.Color.Red
        Me.txtAmount.Location = New System.Drawing.Point(230, 17)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(117, 22)
        Me.txtAmount.TabIndex = 7
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel3.Location = New System.Drawing.Point(59, 16)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(170, 23)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 13
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(170, 22)
        Me.KryptonLabel2.TabIndex = 14
        Me.KryptonLabel2.Values.Text = "Payment Amount"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(170, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(334, 157)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 1
        Me.btnOK.Values.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(415, 157)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
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
        'cboCurrency
        '
        Me.cboCurrency.DropDownHeight = 100
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.DropDownWidth = 328
        Me.cboCurrency.Location = New System.Drawing.Point(105, 11)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(385, 21)
        Me.cboCurrency.TabIndex = 11
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel2.Location = New System.Drawing.Point(12, 11)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(93, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 12
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel1.TabIndex = 13
        Me.KryptonLabel1.Values.Text = "Currency"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(93, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.cboCurrency)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(502, 195)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 194)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(502, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 194)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(501, 0)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 194)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'frmAccountSettlement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 195)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAccountSettlement"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.ColorAngle = 100.0!
        Me.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Pay Out"
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtAmountExchange As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cboCurrency As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
