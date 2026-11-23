<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBenefitsManagementInterestAllocationRatesSetup
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtAdminFeesRate = New Numberbox.Numberbox()
        Me.KryptonPanel22 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel22 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge30 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSubRate = New Numberbox.Numberbox()
        Me.KryptonPanel26 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge37 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEffectiveDate = New System.Windows.Forms.DateTimePicker()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel22.SuspendLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel26.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(487, 170)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(402, 133)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(321, 133)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 5
        Me.btnOK.Values.Text = "OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dpEffectiveDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAdminFeesRate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel22)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtSubRate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel26)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(465, 116)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'txtAdminFeesRate
        '
        Me.txtAdminFeesRate.AllowDecimal = True
        Me.txtAdminFeesRate.BackColor = System.Drawing.Color.White
        Me.txtAdminFeesRate.ForeColor = System.Drawing.Color.Black
        Me.txtAdminFeesRate.Location = New System.Drawing.Point(195, 45)
        Me.txtAdminFeesRate.Name = "txtAdminFeesRate"
        Me.txtAdminFeesRate.Size = New System.Drawing.Size(120, 20)
        Me.txtAdminFeesRate.TabIndex = 193
        Me.txtAdminFeesRate.Text = "0.00"
        Me.txtAdminFeesRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAdminFeesRate.ThousandsSeperator = False
        Me.txtAdminFeesRate.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel22
        '
        Me.KryptonPanel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel22.Controls.Add(Me.KryptonLabel22)
        Me.KryptonPanel22.Controls.Add(Me.KryptonBorderEdge30)
        Me.KryptonPanel22.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel22.Location = New System.Drawing.Point(32, 44)
        Me.KryptonPanel22.Name = "KryptonPanel22"
        Me.KryptonPanel22.Size = New System.Drawing.Size(162, 21)
        Me.KryptonPanel22.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel22.TabIndex = 192
        '
        'KryptonLabel22
        '
        Me.KryptonLabel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel22.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel22.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel22.Name = "KryptonLabel22"
        Me.KryptonLabel22.Size = New System.Drawing.Size(162, 20)
        Me.KryptonLabel22.TabIndex = 1
        Me.KryptonLabel22.Values.Text = "Admin. Fees Rate"
        '
        'KryptonBorderEdge30
        '
        Me.KryptonBorderEdge30.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge30.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge30.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge30.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge30.Name = "KryptonBorderEdge30"
        Me.KryptonBorderEdge30.Size = New System.Drawing.Size(162, 1)
        Me.KryptonBorderEdge30.Text = "KryptonBorderEdge30"
        '
        'txtSubRate
        '
        Me.txtSubRate.AllowDecimal = True
        Me.txtSubRate.BackColor = System.Drawing.Color.White
        Me.txtSubRate.ForeColor = System.Drawing.Color.Black
        Me.txtSubRate.Location = New System.Drawing.Point(195, 23)
        Me.txtSubRate.Name = "txtSubRate"
        Me.txtSubRate.Size = New System.Drawing.Size(120, 20)
        Me.txtSubRate.TabIndex = 189
        Me.txtSubRate.Text = "0.00"
        Me.txtSubRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSubRate.ThousandsSeperator = False
        Me.txtSubRate.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel26
        '
        Me.KryptonPanel26.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel26.Controls.Add(Me.KryptonLabel17)
        Me.KryptonPanel26.Controls.Add(Me.KryptonBorderEdge37)
        Me.KryptonPanel26.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel26.Location = New System.Drawing.Point(32, 22)
        Me.KryptonPanel26.Name = "KryptonPanel26"
        Me.KryptonPanel26.Size = New System.Drawing.Size(162, 21)
        Me.KryptonPanel26.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel26.TabIndex = 188
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel17.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel17.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Size = New System.Drawing.Size(162, 20)
        Me.KryptonLabel17.TabIndex = 1
        Me.KryptonLabel17.Values.Text = "Interest on Subs"
        '
        'KryptonBorderEdge37
        '
        Me.KryptonBorderEdge37.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge37.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge37.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge37.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge37.Name = "KryptonBorderEdge37"
        Me.KryptonBorderEdge37.Size = New System.Drawing.Size(162, 1)
        Me.KryptonBorderEdge37.Text = "KryptonBorderEdge37"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(486, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 168)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 168)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 169)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(487, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(487, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(32, 67)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(162, 21)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 194
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(162, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Interest rates effective from"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(162, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'dpEffectiveDate
        '
        Me.dpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEffectiveDate.Location = New System.Drawing.Point(195, 68)
        Me.dpEffectiveDate.Name = "dpEffectiveDate"
        Me.dpEffectiveDate.Size = New System.Drawing.Size(120, 20)
        Me.dpEffectiveDate.TabIndex = 195
        '
        'frmBenefitsManagementInterestAllocationRatesSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBenefitsManagementInterestAllocationRatesSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Interest/Allocation Parameters"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel22.ResumeLayout(False)
        Me.KryptonPanel22.PerformLayout()
        CType(Me.KryptonPanel26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel26.ResumeLayout(False)
        Me.KryptonPanel26.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
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
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtAdminFeesRate As Numberbox.Numberbox
    Friend WithEvents KryptonPanel22 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel22 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge30 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSubRate As Numberbox.Numberbox
    Friend WithEvents KryptonPanel26 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge37 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEffectiveDate As System.Windows.Forms.DateTimePicker
End Class
