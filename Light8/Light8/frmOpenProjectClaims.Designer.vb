<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenProjectClaims
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenProjectClaims))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblProjectNumber = New System.Windows.Forms.Label()
        Me.lblProjectOwner = New System.Windows.Forms.Label()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cboProject = New MTGCComboBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboProjectOwner = New MTGCComboBox()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge22 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.lblProjectSite = New System.Windows.Forms.Label()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.lblProjectSite)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel.Controls.Add(Me.lblProjectNumber)
        Me.KryptonPanel.Controls.Add(Me.lblProjectOwner)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(519, 171)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(1, 170)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(517, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(517, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'lblProjectNumber
        '
        Me.lblProjectNumber.BackColor = System.Drawing.Color.White
        Me.lblProjectNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProjectNumber.ForeColor = System.Drawing.Color.Black
        Me.lblProjectNumber.Location = New System.Drawing.Point(131, 138)
        Me.lblProjectNumber.Name = "lblProjectNumber"
        Me.lblProjectNumber.Size = New System.Drawing.Size(100, 21)
        Me.lblProjectNumber.TabIndex = 10
        Me.lblProjectNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProjectNumber.Visible = False
        '
        'lblProjectOwner
        '
        Me.lblProjectOwner.BackColor = System.Drawing.Color.White
        Me.lblProjectOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProjectOwner.ForeColor = System.Drawing.Color.Black
        Me.lblProjectOwner.Location = New System.Drawing.Point(25, 138)
        Me.lblProjectOwner.Name = "lblProjectOwner"
        Me.lblProjectOwner.Size = New System.Drawing.Size(100, 21)
        Me.lblProjectOwner.TabIndex = 9
        Me.lblProjectOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProjectOwner.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(431, 135)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.White
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(350, 135)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 4
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.White
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboProject)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboProjectOwner)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel8)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(494, 117)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 3
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'cboProject
        '
        Me.cboProject.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboProject.ArrowColor = System.Drawing.Color.Black
        Me.cboProject.BackColor = System.Drawing.Color.White
        Me.cboProject.BindedControl = CType(resources.GetObject("cboProject.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboProject.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboProject.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboProject.ColumnNum = 1
        Me.cboProject.ColumnWidth = "121"
        Me.cboProject.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboProject.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboProject.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboProject.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboProject.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboProject.DisplayMember = "Text"
        Me.cboProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboProject.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboProject.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboProject.DropDownForeColor = System.Drawing.Color.Black
        Me.cboProject.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboProject.DropDownWidth = 141
        Me.cboProject.ForeColor = System.Drawing.Color.Black
        Me.cboProject.GridLineColor = System.Drawing.Color.LightGray
        Me.cboProject.GridLineHorizontal = False
        Me.cboProject.GridLineVertical = False
        Me.cboProject.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboProject.HighlightBorderOnMouseEvents = True
        Me.cboProject.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboProject.Location = New System.Drawing.Point(124, 57)
        Me.cboProject.ManagingFastMouseMoving = True
        Me.cboProject.ManagingFastMouseMovingInterval = 30
        Me.cboProject.Name = "cboProject"
        Me.cboProject.NormalBorderColor = System.Drawing.Color.Silver
        Me.cboProject.SelectedItem = Nothing
        Me.cboProject.SelectedValue = Nothing
        Me.cboProject.Size = New System.Drawing.Size(342, 21)
        Me.cboProject.Sorted = True
        Me.cboProject.TabIndex = 181
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(27, 55)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(96, 23)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 180
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(96, 22)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Project"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(96, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'cboProjectOwner
        '
        Me.cboProjectOwner.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboProjectOwner.ArrowColor = System.Drawing.Color.Black
        Me.cboProjectOwner.BackColor = System.Drawing.Color.White
        Me.cboProjectOwner.BindedControl = CType(resources.GetObject("cboProjectOwner.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboProjectOwner.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboProjectOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboProjectOwner.ColumnNum = 1
        Me.cboProjectOwner.ColumnWidth = "121"
        Me.cboProjectOwner.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboProjectOwner.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboProjectOwner.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboProjectOwner.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboProjectOwner.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboProjectOwner.DisplayMember = "Text"
        Me.cboProjectOwner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboProjectOwner.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboProjectOwner.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboProjectOwner.DropDownForeColor = System.Drawing.Color.Black
        Me.cboProjectOwner.DropDownHeight = 60
        Me.cboProjectOwner.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboProjectOwner.DropDownWidth = 30
        Me.cboProjectOwner.ForeColor = System.Drawing.Color.Black
        Me.cboProjectOwner.GridLineColor = System.Drawing.Color.LightGray
        Me.cboProjectOwner.GridLineHorizontal = False
        Me.cboProjectOwner.GridLineVertical = False
        Me.cboProjectOwner.HighlightBorderColor = System.Drawing.Color.LightGray
        Me.cboProjectOwner.HighlightBorderOnMouseEvents = True
        Me.cboProjectOwner.IntegralHeight = False
        Me.cboProjectOwner.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboProjectOwner.Location = New System.Drawing.Point(124, 29)
        Me.cboProjectOwner.ManagingFastMouseMoving = True
        Me.cboProjectOwner.ManagingFastMouseMovingInterval = 30
        Me.cboProjectOwner.MaxDropDownItems = 10
        Me.cboProjectOwner.Name = "cboProjectOwner"
        Me.cboProjectOwner.NormalBorderColor = System.Drawing.Color.Silver
        Me.cboProjectOwner.SelectedItem = Nothing
        Me.cboProjectOwner.SelectedValue = Nothing
        Me.cboProjectOwner.Size = New System.Drawing.Size(342, 21)
        Me.cboProjectOwner.Sorted = True
        Me.cboProjectOwner.TabIndex = 179
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge22)
        Me.KryptonPanel8.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel8.Location = New System.Drawing.Point(27, 27)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(96, 23)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 178
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.BackColor = System.Drawing.Color.White
        Me.KryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(96, 22)
        Me.KryptonLabel4.TabIndex = 1
        Me.KryptonLabel4.Values.Text = "Project Owner"
        '
        'KryptonBorderEdge22
        '
        Me.KryptonBorderEdge22.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge22.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge22.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge22.Name = "KryptonBorderEdge22"
        Me.KryptonBorderEdge22.Size = New System.Drawing.Size(96, 1)
        Me.KryptonBorderEdge22.Text = "KryptonBorderEdge22"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 171)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(518, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 171)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'lblProjectSite
        '
        Me.lblProjectSite.BackColor = System.Drawing.Color.White
        Me.lblProjectSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProjectSite.ForeColor = System.Drawing.Color.Black
        Me.lblProjectSite.Location = New System.Drawing.Point(237, 139)
        Me.lblProjectSite.Name = "lblProjectSite"
        Me.lblProjectSite.Size = New System.Drawing.Size(100, 21)
        Me.lblProjectSite.TabIndex = 13
        Me.lblProjectSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProjectSite.Visible = False
        '
        'frmOpenProjectClaims
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 171)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpenProjectClaims"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Open Project Claims"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
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
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents cboProject As MTGCComboBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboProjectOwner As MTGCComboBox
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge22 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblProjectNumber As System.Windows.Forms.Label
    Friend WithEvents lblProjectOwner As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents lblProjectSite As System.Windows.Forms.Label
End Class
