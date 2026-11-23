<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLedgerAccountCodeChange
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnAdvanced = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtNewCode = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboItems = New MTGCComboBox()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.btnAdvanced)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(542, 191)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 1
        '
        'btnAdvanced
        '
        Me.btnAdvanced.BackColor = System.Drawing.Color.White
        Me.btnAdvanced.ForeColor = System.Drawing.Color.Black
        Me.btnAdvanced.Location = New System.Drawing.Point(279, 148)
        Me.btnAdvanced.Name = "btnAdvanced"
        Me.btnAdvanced.Size = New System.Drawing.Size(75, 25)
        Me.btnAdvanced.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.btnAdvanced.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAdvanced.StateCommon.Back.ColorAngle = 100.0!
        Me.btnAdvanced.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnAdvanced.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAdvanced.StateCommon.Border.Rounding = 0
        Me.btnAdvanced.TabIndex = 5
        Me.btnAdvanced.Values.Text = "&Advanced ..."
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(450, 148)
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
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.White
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(369, 148)
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
        Me.btnOK.TabIndex = 3
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.White
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(17, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.ProgressBar1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDescription)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtNewCode)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboItems)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(508, 130)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ProgressBar1.Location = New System.Drawing.Point(111, 88)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(379, 19)
        Me.ProgressBar1.TabIndex = 136
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.Location = New System.Drawing.Point(111, 42)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(379, 22)
        Me.lblDescription.TabIndex = 141
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNewCode
        '
        Me.txtNewCode.BackColor = System.Drawing.Color.White
        Me.txtNewCode.ForeColor = System.Drawing.Color.Black
        Me.txtNewCode.Location = New System.Drawing.Point(111, 66)
        Me.txtNewCode.Name = "txtNewCode"
        Me.txtNewCode.Size = New System.Drawing.Size(379, 20)
        Me.txtNewCode.TabIndex = 138
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel5.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel5.Location = New System.Drawing.Point(17, 66)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(93, 20)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 140
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(93, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.BackColor = System.Drawing.Color.White
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel3.TabIndex = 0
        Me.KryptonLabel3.Values.Text = "New code"
        '
        'cboItems
        '
        Me.cboItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.ArrowColor = System.Drawing.Color.Black
        Me.cboItems.BackColor = System.Drawing.Color.White
        Me.cboItems.BindedControl = Nothing
        Me.cboItems.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboItems.ColumnNum = 1
        Me.cboItems.ColumnWidth = "121"
        Me.cboItems.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboItems.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboItems.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboItems.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboItems.DisplayMember = "Text"
        Me.cboItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboItems.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboItems.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboItems.DropDownForeColor = System.Drawing.Color.Black
        Me.cboItems.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboItems.DropDownWidth = 141
        Me.cboItems.ForeColor = System.Drawing.Color.Black
        Me.cboItems.GridLineColor = System.Drawing.Color.LightGray
        Me.cboItems.GridLineHorizontal = False
        Me.cboItems.GridLineVertical = False
        Me.cboItems.HighlightBorderColor = System.Drawing.Color.DarkGray
        Me.cboItems.HighlightBorderOnMouseEvents = True
        Me.cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboItems.Location = New System.Drawing.Point(111, 18)
        Me.cboItems.ManagingFastMouseMoving = True
        Me.cboItems.ManagingFastMouseMovingInterval = 30
        Me.cboItems.Name = "cboItems"
        Me.cboItems.NormalBorderColor = System.Drawing.Color.DarkGray
        Me.cboItems.SelectedItem = Nothing
        Me.cboItems.SelectedValue = Nothing
        Me.cboItems.Size = New System.Drawing.Size(379, 23)
        Me.cboItems.Sorted = True
        Me.cboItems.TabIndex = 137
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(16, 21)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(93, 20)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 139
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(93, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel2.TabIndex = 0
        Me.KryptonLabel2.Values.Text = "Current code"
        '
        'frmLedgerAccountCodeChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLedgerAccountCodeChange"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ledger Account Code Change"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnAdvanced As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtNewCode As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboItems As MTGCComboBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
