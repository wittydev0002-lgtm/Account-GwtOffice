<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryCodesMerge
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
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.chkDelete = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.lblDestineDescription = New System.Windows.Forms.Label()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboDestinationItems = New MTGCComboBox()
        Me.lblSourceDescription = New System.Windows.Forms.Label()
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboSourceItems = New MTGCComboBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
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
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(569, 215)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.pb1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel2.Location = New System.Drawing.Point(13, 178)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(377, 25)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 4
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(376, 1)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(1, 23)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 23)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 24)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(377, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(377, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(482, 179)
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
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.AutoSize = True
        Me.btnOK.Location = New System.Drawing.Point(401, 179)
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
        Me.btnOK.TabIndex = 2
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.chkDelete)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblDestineDescription)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboDestinationItems)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblSourceDescription)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel8)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboSourceItems)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(545, 161)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 0
        Me.KryptonGroupBox1.Values.Heading = ""
        '
        'chkDelete
        '
        Me.chkDelete.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkDelete.Location = New System.Drawing.Point(139, 121)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(290, 20)
        Me.chkDelete.TabIndex = 27
        Me.chkDelete.Text = "Remove source item code from the system after?"
        Me.chkDelete.Values.Text = "Remove source item code from the system after?"
        '
        'lblDestineDescription
        '
        Me.lblDestineDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.lblDestineDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDestineDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDestineDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDestineDescription.Location = New System.Drawing.Point(140, 90)
        Me.lblDestineDescription.Name = "lblDestineDescription"
        Me.lblDestineDescription.Size = New System.Drawing.Size(386, 21)
        Me.lblDestineDescription.TabIndex = 25
        Me.lblDestineDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Location = New System.Drawing.Point(17, 67)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(123, 20)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 26
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(123, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(123, 20)
        Me.KryptonLabel2.TabIndex = 0
        Me.KryptonLabel2.Values.Text = "To Item Code"
        '
        'cboDestinationItems
        '
        Me.cboDestinationItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDestinationItems.ArrowColor = System.Drawing.Color.Black
        Me.cboDestinationItems.BindedControl = Nothing
        Me.cboDestinationItems.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboDestinationItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDestinationItems.ColumnNum = 1
        Me.cboDestinationItems.ColumnWidth = "121"
        Me.cboDestinationItems.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDestinationItems.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboDestinationItems.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboDestinationItems.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboDestinationItems.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboDestinationItems.DisplayMember = "Text"
        Me.cboDestinationItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDestinationItems.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboDestinationItems.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboDestinationItems.DropDownForeColor = System.Drawing.Color.Black
        Me.cboDestinationItems.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboDestinationItems.DropDownWidth = 141
        Me.cboDestinationItems.GridLineColor = System.Drawing.Color.LightGray
        Me.cboDestinationItems.GridLineHorizontal = False
        Me.cboDestinationItems.GridLineVertical = False
        Me.cboDestinationItems.HighlightBorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.cboDestinationItems.HighlightBorderOnMouseEvents = True
        Me.cboDestinationItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboDestinationItems.Location = New System.Drawing.Point(140, 66)
        Me.cboDestinationItems.ManagingFastMouseMoving = True
        Me.cboDestinationItems.ManagingFastMouseMovingInterval = 30
        Me.cboDestinationItems.Name = "cboDestinationItems"
        Me.cboDestinationItems.NormalBorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.cboDestinationItems.SelectedItem = Nothing
        Me.cboDestinationItems.SelectedValue = Nothing
        Me.cboDestinationItems.Size = New System.Drawing.Size(386, 21)
        Me.cboDestinationItems.Sorted = True
        Me.cboDestinationItems.TabIndex = 24
        '
        'lblSourceDescription
        '
        Me.lblSourceDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.lblSourceDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSourceDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSourceDescription.ForeColor = System.Drawing.Color.Black
        Me.lblSourceDescription.Location = New System.Drawing.Point(140, 39)
        Me.lblSourceDescription.Name = "lblSourceDescription"
        Me.lblSourceDescription.Size = New System.Drawing.Size(386, 21)
        Me.lblSourceDescription.TabIndex = 22
        Me.lblSourceDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel8.Location = New System.Drawing.Point(17, 16)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(123, 20)
        Me.KryptonPanel8.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel8.TabIndex = 23
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 19)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(123, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(123, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Change Item Code"
        '
        'cboSourceItems
        '
        Me.cboSourceItems.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSourceItems.ArrowColor = System.Drawing.Color.Black
        Me.cboSourceItems.BindedControl = Nothing
        Me.cboSourceItems.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboSourceItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSourceItems.ColumnNum = 1
        Me.cboSourceItems.ColumnWidth = "121"
        Me.cboSourceItems.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSourceItems.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSourceItems.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSourceItems.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSourceItems.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSourceItems.DisplayMember = "Text"
        Me.cboSourceItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSourceItems.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboSourceItems.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSourceItems.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSourceItems.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSourceItems.DropDownWidth = 141
        Me.cboSourceItems.GridLineColor = System.Drawing.Color.LightGray
        Me.cboSourceItems.GridLineHorizontal = False
        Me.cboSourceItems.GridLineVertical = False
        Me.cboSourceItems.HighlightBorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.cboSourceItems.HighlightBorderOnMouseEvents = True
        Me.cboSourceItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSourceItems.Location = New System.Drawing.Point(140, 15)
        Me.cboSourceItems.ManagingFastMouseMoving = True
        Me.cboSourceItems.ManagingFastMouseMovingInterval = 30
        Me.cboSourceItems.Name = "cboSourceItems"
        Me.cboSourceItems.NormalBorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.cboSourceItems.SelectedItem = Nothing
        Me.cboSourceItems.SelectedValue = Nothing
        Me.cboSourceItems.Size = New System.Drawing.Size(386, 21)
        Me.cboSourceItems.Sorted = True
        Me.cboSourceItems.TabIndex = 21
        '
        'pb1
        '
        Me.pb1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb1.Location = New System.Drawing.Point(1, 1)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(375, 23)
        Me.pb1.TabIndex = 4
        '
        'frmInventoryCodesMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 215)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventoryCodesMerge"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Inventory Codes Merge"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
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
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents lblSourceDescription As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboSourceItems As MTGCComboBox
    Friend WithEvents lblDestineDescription As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboDestinationItems As MTGCComboBox
    Private WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkDelete As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
End Class
