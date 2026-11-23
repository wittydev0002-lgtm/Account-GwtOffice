<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiscalTestParameters
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
        Me.cboComPort = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel81 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge150 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel68 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboCurrency = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.cboComPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel81.SuspendLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboComPort
        '
        Me.cboComPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboComPort.DropDownWidth = 163
        Me.cboComPort.ForeColor = System.Drawing.Color.Black
        Me.cboComPort.Location = New System.Drawing.Point(123, 22)
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboComPort.Size = New System.Drawing.Size(105, 21)
        Me.cboComPort.StateCommon.ComboBox.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cboComPort.StateCommon.ComboBox.Border.Rounding = 1
        Me.cboComPort.TabIndex = 172
        '
        'KryptonPanel81
        '
        Me.KryptonPanel81.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel81.Controls.Add(Me.KryptonBorderEdge150)
        Me.KryptonPanel81.Controls.Add(Me.KryptonLabel68)
        Me.KryptonPanel81.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel81.Location = New System.Drawing.Point(37, 23)
        Me.KryptonPanel81.Name = "KryptonPanel81"
        Me.KryptonPanel81.Size = New System.Drawing.Size(84, 20)
        Me.KryptonPanel81.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel81.TabIndex = 171
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
        'cboCurrency
        '
        Me.cboCurrency.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboCurrency.DropDownWidth = 163
        Me.cboCurrency.ForeColor = System.Drawing.Color.Black
        Me.cboCurrency.Items.AddRange(New Object() {"01-ZWL", "02-USD", "03-RAND", "04-PULA"})
        Me.cboCurrency.Location = New System.Drawing.Point(353, 22)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboCurrency.Size = New System.Drawing.Size(105, 21)
        Me.cboCurrency.StateCommon.ComboBox.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cboCurrency.StateCommon.ComboBox.Border.Rounding = 1
        Me.cboCurrency.TabIndex = 174
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(267, 23)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(84, 20)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 173
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(84, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(84, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Currency"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(12, 58)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(470, 20)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 175
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(470, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(330, 84)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 27)
        Me.btnOK.TabIndex = 176
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(407, 84)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 177
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmFiscalTestParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 123)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.KryptonPanel2)
        Me.Controls.Add(Me.cboCurrency)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.cboComPort)
        Me.Controls.Add(Me.KryptonPanel81)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiscalTestParameters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fiscal Test Parameters"
        CType(Me.cboComPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel81, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel81.ResumeLayout(False)
        Me.KryptonPanel81.PerformLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboComPort As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel81 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge150 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel68 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboCurrency As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
