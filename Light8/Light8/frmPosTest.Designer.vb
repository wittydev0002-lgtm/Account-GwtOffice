<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosTest
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
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblResult1 = New System.Windows.Forms.Label()
        Me.btnPrinReceipt = New System.Windows.Forms.Button()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.cboComPort = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel81 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge150 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel68 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.cboComPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel81.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblResult
        '
        Me.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResult.Location = New System.Drawing.Point(33, 217)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Padding = New System.Windows.Forms.Padding(5)
        Me.lblResult.Size = New System.Drawing.Size(743, 91)
        Me.lblResult.TabIndex = 0
        '
        'lblResult1
        '
        Me.lblResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResult1.Location = New System.Drawing.Point(33, 319)
        Me.lblResult1.Name = "lblResult1"
        Me.lblResult1.Padding = New System.Windows.Forms.Padding(5)
        Me.lblResult1.Size = New System.Drawing.Size(743, 91)
        Me.lblResult1.TabIndex = 1
        '
        'btnPrinReceipt
        '
        Me.btnPrinReceipt.Location = New System.Drawing.Point(33, 70)
        Me.btnPrinReceipt.Name = "btnPrinReceipt"
        Me.btnPrinReceipt.Size = New System.Drawing.Size(125, 35)
        Me.btnPrinReceipt.TabIndex = 2
        Me.btnPrinReceipt.Text = "Receipt"
        Me.btnPrinReceipt.UseVisualStyleBackColor = True
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.Location = New System.Drawing.Point(164, 70)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(125, 35)
        Me.btnPrintBarcode.TabIndex = 3
        Me.btnPrintBarcode.Text = "Barcode"
        Me.btnPrintBarcode.UseVisualStyleBackColor = True
        '
        'cboComPort
        '
        Me.cboComPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboComPort.DropDownWidth = 163
        Me.cboComPort.ForeColor = System.Drawing.Color.Black
        Me.cboComPort.Location = New System.Drawing.Point(119, 25)
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboComPort.Size = New System.Drawing.Size(105, 21)
        Me.cboComPort.StateCommon.ComboBox.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cboComPort.StateCommon.ComboBox.Border.Rounding = 1
        Me.cboComPort.TabIndex = 170
        '
        'KryptonPanel81
        '
        Me.KryptonPanel81.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel81.Controls.Add(Me.KryptonBorderEdge150)
        Me.KryptonPanel81.Controls.Add(Me.KryptonLabel68)
        Me.KryptonPanel81.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel81.Location = New System.Drawing.Point(33, 26)
        Me.KryptonPanel81.Name = "KryptonPanel81"
        Me.KryptonPanel81.Size = New System.Drawing.Size(84, 20)
        Me.KryptonPanel81.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel81.TabIndex = 169
        '
        'KryptonBorderEdge150
        '
        Me.KryptonBorderEdge150.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge150.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge150.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge150.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge150.Name = "KryptonBorderEdge150"
        Me.KryptonBorderEdge150.Size = New System.Drawing.Size(84, 1)
        Me.KryptonBorderEdge150.Text = "KryptonBorderEdge150"
        '
        'KryptonLabel68
        '
        Me.KryptonLabel68.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel68.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel68.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel68.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel68.Name = "KryptonLabel68"
        Me.KryptonLabel68.Size = New System.Drawing.Size(84, 20)
        Me.KryptonLabel68.TabIndex = 0
        Me.KryptonLabel68.Values.Text = "Com Port"
        '
        'frmPosTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cboComPort)
        Me.Controls.Add(Me.KryptonPanel81)
        Me.Controls.Add(Me.btnPrintBarcode)
        Me.Controls.Add(Me.btnPrinReceipt)
        Me.Controls.Add(Me.lblResult1)
        Me.Controls.Add(Me.lblResult)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPosTest"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Eltrade Fiscal Printer Test"
        CType(Me.cboComPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel81.ResumeLayout(False)
        Me.KryptonPanel81.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblResult As Label
    Friend WithEvents lblResult1 As Label
    Friend WithEvents btnPrinReceipt As Button
    Friend WithEvents btnPrintBarcode As Button
    Friend WithEvents cboComPort As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel81 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge150 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel68 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
