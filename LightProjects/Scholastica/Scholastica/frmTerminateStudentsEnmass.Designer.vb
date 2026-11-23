<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTerminateStudentsEnmass
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
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkLstClasses = New System.Windows.Forms.CheckedListBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cboReason = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboReason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(539, 448)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 1
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(16, 105)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.chkLstClasses)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(507, 290)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 9
        Me.KryptonGroupBox2.Text = "Select classes ...."
        Me.KryptonGroupBox2.Values.Heading = "Select classes ...."
        '
        'chkLstClasses
        '
        Me.chkLstClasses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chkLstClasses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkLstClasses.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstClasses.FormattingEnabled = True
        Me.chkLstClasses.Location = New System.Drawing.Point(0, 0)
        Me.chkLstClasses.Name = "chkLstClasses"
        Me.chkLstClasses.Size = New System.Drawing.Size(505, 267)
        Me.chkLstClasses.Sorted = True
        Me.chkLstClasses.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(449, 401)
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
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(368, 401)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.White
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
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboReason)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dpEndDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel4)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(510, 85)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 4
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'cboReason
        '
        Me.cboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReason.DropDownWidth = 379
        Me.cboReason.Items.AddRange(New Object() {"Completed", "Deceased", "Drop Out", "Other", "Transfer"})
        Me.cboReason.Location = New System.Drawing.Point(116, 40)
        Me.cboReason.Name = "cboReason"
        Me.cboReason.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboReason.Size = New System.Drawing.Size(379, 21)
        Me.cboReason.Sorted = True
        Me.cboReason.TabIndex = 7
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Location = New System.Drawing.Point(23, 40)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(91, 21)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 6
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(91, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Reason"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(91, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'dpEndDate
        '
        Me.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndDate.Location = New System.Drawing.Point(116, 17)
        Me.dpEndDate.Name = "dpEndDate"
        Me.dpEndDate.Size = New System.Drawing.Size(95, 20)
        Me.dpEndDate.TabIndex = 4
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel4.Location = New System.Drawing.Point(23, 16)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(91, 21)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 5
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(91, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Effective date"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(91, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(1, 447)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(537, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(538, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 448)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1, 448)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'frmTerminateStudentsEnmass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 448)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTerminateStudentsEnmass"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Border.Width = 2
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Terminate Students Enmass"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboReason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
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
    Friend WithEvents cboReason As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents chkLstClasses As System.Windows.Forms.CheckedListBox
End Class
