<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmsMessages
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSmsMessages))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar7 = New DevComponents.DotNetBar.Bar()
        Me.btnMessageBalance = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOtherMessage = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshMessages = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSmsSettings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTestMessage = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboFilterFor = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dGridSms = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column28 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.cboFilterFor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridSms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(682, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(681, 1)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 491)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 491)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1, 491)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(680, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar7
        '
        Me.Bar7.AntiAlias = True
        Me.Bar7.BackColor = System.Drawing.Color.White
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Bar7.IsMaximized = False
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnMessageBalance, Me.btnOtherMessage, Me.btnRefreshMessages, Me.btnSmsSettings, Me.btnTestMessage})
        Me.Bar7.Location = New System.Drawing.Point(1, 1)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.RoundCorners = False
        Me.Bar7.Size = New System.Drawing.Size(680, 25)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar7.TabIndex = 36
        Me.Bar7.TabStop = False
        Me.Bar7.Text = "Bar7"
        '
        'btnMessageBalance
        '
        Me.btnMessageBalance.BeginGroup = True
        Me.btnMessageBalance.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnMessageBalance.Image = CType(resources.GetObject("btnMessageBalance.Image"), System.Drawing.Image)
        Me.btnMessageBalance.Name = "btnMessageBalance"
        Me.btnMessageBalance.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnMessageBalance.Text = "Message Balance"
        '
        'btnOtherMessage
        '
        Me.btnOtherMessage.BeginGroup = True
        Me.btnOtherMessage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOtherMessage.Image = CType(resources.GetObject("btnOtherMessage.Image"), System.Drawing.Image)
        Me.btnOtherMessage.Name = "btnOtherMessage"
        Me.btnOtherMessage.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnOtherMessage.Text = "Other Message"
        '
        'btnRefreshMessages
        '
        Me.btnRefreshMessages.BeginGroup = True
        Me.btnRefreshMessages.Image = CType(resources.GetObject("btnRefreshMessages.Image"), System.Drawing.Image)
        Me.btnRefreshMessages.Name = "btnRefreshMessages"
        Me.btnRefreshMessages.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshMessages.Text = "Refresh Grid"
        '
        'btnSmsSettings
        '
        Me.btnSmsSettings.BeginGroup = True
        Me.btnSmsSettings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSmsSettings.Image = CType(resources.GetObject("btnSmsSettings.Image"), System.Drawing.Image)
        Me.btnSmsSettings.Name = "btnSmsSettings"
        Me.btnSmsSettings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSmsSettings.Text = "Settings"
        '
        'btnTestMessage
        '
        Me.btnTestMessage.BeginGroup = True
        Me.btnTestMessage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTestMessage.Image = CType(resources.GetObject("btnTestMessage.Image"), System.Drawing.Image)
        Me.btnTestMessage.Name = "btnTestMessage"
        Me.btnTestMessage.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnTestMessage.Text = "Test Message"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(680, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.chkSelectAll)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.cboFilterFor)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(680, 54)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 38
        '
        'chkSelectAll
        '
        Me.chkSelectAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkSelectAll.Location = New System.Drawing.Point(310, 18)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(126, 20)
        Me.chkSelectAll.TabIndex = 157
        Me.chkSelectAll.Text = "Select/de-select all"
        Me.chkSelectAll.Values.Text = "Select/de-select all"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(23, 16)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(92, 22)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 156
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.White
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(92, 21)
        Me.KryptonLabel2.TabIndex = 148
        Me.KryptonLabel2.Values.Text = "Filter for ..."
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(92, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'cboFilterFor
        '
        Me.cboFilterFor.BackColor = System.Drawing.Color.White
        Me.cboFilterFor.DropDownWidth = 163
        Me.cboFilterFor.ForeColor = System.Drawing.Color.Black
        Me.cboFilterFor.Items.AddRange(New Object() {"Customers", "Employees", "Suppliers"})
        Me.cboFilterFor.Location = New System.Drawing.Point(117, 17)
        Me.cboFilterFor.Name = "cboFilterFor"
        Me.cboFilterFor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboFilterFor.Size = New System.Drawing.Size(168, 21)
        Me.cboFilterFor.Sorted = True
        Me.cboFilterFor.TabIndex = 155
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 53)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(680, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'dGridSms
        '
        Me.dGridSms.AllowUserToAddRows = False
        Me.dGridSms.AllowUserToDeleteRows = False
        Me.dGridSms.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridSms.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridSms.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column28, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.dGridSms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSms.Location = New System.Drawing.Point(1, 81)
        Me.dGridSms.Name = "dGridSms"
        Me.dGridSms.RowHeadersWidth = 25
        Me.dGridSms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridSms.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dGridSms.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dGridSms.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dGridSms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridSms.Size = New System.Drawing.Size(680, 410)
        Me.dGridSms.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGridSms.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridSms.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dGridSms.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridSms.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridSms.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridSms.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSms.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSms.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSms.StateCommon.HeaderRow.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridSms.StateCommon.HeaderRow.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridSms.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridSms.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridSms.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridSms.TabIndex = 151
        '
        'Column28
        '
        Me.Column28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.NullValue = False
        Me.Column28.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column28.FalseValue = Nothing
        Me.Column28.HeaderText = ""
        Me.Column28.IndeterminateValue = Nothing
        Me.Column28.MinimumWidth = 25
        Me.Column28.Name = "Column28"
        Me.Column28.TrueValue = Nothing
        Me.Column28.Width = 25
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ref. #"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 71
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Last Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 96
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "First Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 97
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn8.HeaderText = "Other Names"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 111
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn9.HeaderText = "Cellphone"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 93
        '
        'frmSmsMessages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(682, 492)
        Me.Controls.Add(Me.dGridSms)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar7)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Name = "frmSmsMessages"
        Me.Text = "SMS Messaging"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.cboFilterFor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridSms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnMessageBalance As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnOtherMessage As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshMessages As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSmsSettings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTestMessage As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboFilterFor As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents chkSelectAll As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents dGridSms As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column28 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
