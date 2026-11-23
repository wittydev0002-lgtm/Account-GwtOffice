<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOwingStudents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOwingStudents))
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnPrintOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintListOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectedStatementOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAllStatementsOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSelectedReminder = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAllReminders = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSmsReminderOwings = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalOwings = New DevComponents.DotNetBar.LabelItem()
        Me.lblTotalRecords = New DevComponents.DotNetBar.LabelItem()
        Me.dGridOwings = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGridOwings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(553, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 484)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(553, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 483)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(552, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 483)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintOwings, Me.btnSmsReminderOwings})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(551, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnPrintOwings
        '
        Me.btnPrintOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintOwings.Image = CType(resources.GetObject("btnPrintOwings.Image"), System.Drawing.Image)
        Me.btnPrintOwings.Name = "btnPrintOwings"
        Me.btnPrintOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintOwings.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrintListOwings, Me.btnSelectedStatementOwings, Me.btnAllStatementsOwings, Me.btnSelectedReminder, Me.btnAllReminders})
        Me.btnPrintOwings.Text = "Print"
        '
        'btnPrintListOwings
        '
        Me.btnPrintListOwings.BeginGroup = True
        Me.btnPrintListOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintListOwings.Name = "btnPrintListOwings"
        Me.btnPrintListOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintListOwings.Text = "Print List"
        '
        'btnSelectedStatementOwings
        '
        Me.btnSelectedStatementOwings.BeginGroup = True
        Me.btnSelectedStatementOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSelectedStatementOwings.Name = "btnSelectedStatementOwings"
        Me.btnSelectedStatementOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSelectedStatementOwings.Text = "Print Selected Statement"
        '
        'btnAllStatementsOwings
        '
        Me.btnAllStatementsOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAllStatementsOwings.Name = "btnAllStatementsOwings"
        Me.btnAllStatementsOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAllStatementsOwings.Text = "Print All Statement"
        '
        'btnSelectedReminder
        '
        Me.btnSelectedReminder.BeginGroup = True
        Me.btnSelectedReminder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSelectedReminder.Name = "btnSelectedReminder"
        Me.btnSelectedReminder.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSelectedReminder.Text = "Print Selected Reminder"
        '
        'btnAllReminders
        '
        Me.btnAllReminders.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAllReminders.Name = "btnAllReminders"
        Me.btnAllReminders.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAllReminders.Text = "Print Selected All Reminders"
        '
        'btnSmsReminderOwings
        '
        Me.btnSmsReminderOwings.BeginGroup = True
        Me.btnSmsReminderOwings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSmsReminderOwings.Image = CType(resources.GetObject("btnSmsReminderOwings.Image"), System.Drawing.Image)
        Me.btnSmsReminderOwings.Name = "btnSmsReminderOwings"
        Me.btnSmsReminderOwings.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnSmsReminderOwings.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnSmsReminderOwings.Text = "SMS Reminders"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(551, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.lblTotalOwings, Me.lblTotalRecords})
        Me.Bar2.Location = New System.Drawing.Point(1, 464)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.PaddingLeft = 3
        Me.Bar2.PaddingRight = 3
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(551, 20)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 6
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingLeft = 3
        Me.LabelItem1.PaddingRight = 3
        Me.LabelItem1.Stretch = True
        Me.LabelItem1.Text = "Total Owings"
        '
        'lblTotalOwings
        '
        Me.lblTotalOwings.BeginGroup = True
        Me.lblTotalOwings.Name = "lblTotalOwings"
        Me.lblTotalOwings.PaddingLeft = 3
        Me.lblTotalOwings.PaddingRight = 3
        Me.lblTotalOwings.Text = "0.00"
        Me.lblTotalOwings.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblTotalOwings.Width = 80
        '
        'lblTotalRecords
        '
        Me.lblTotalRecords.BackColor = System.Drawing.Color.Orange
        Me.lblTotalRecords.BeginGroup = True
        Me.lblTotalRecords.Name = "lblTotalRecords"
        Me.lblTotalRecords.PaddingLeft = 3
        Me.lblTotalRecords.PaddingRight = 3
        Me.lblTotalRecords.Text = "0"
        Me.lblTotalRecords.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dGridOwings
        '
        Me.dGridOwings.AllowUserToAddRows = False
        Me.dGridOwings.AllowUserToDeleteRows = False
        Me.dGridOwings.AllowUserToResizeRows = False
        Me.dGridOwings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridOwings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridOwings.Location = New System.Drawing.Point(1, 27)
        Me.dGridOwings.Name = "dGridOwings"
        Me.dGridOwings.ReadOnly = True
        Me.dGridOwings.RowHeadersWidth = 25
        Me.dGridOwings.Size = New System.Drawing.Size(551, 437)
        Me.dGridOwings.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridOwings.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridOwings.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOwings.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridOwings.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridOwings.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridOwings.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridOwings.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridOwings.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridOwings.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridOwings.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridOwings.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridOwings.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridOwings.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridOwings.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridOwings.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridOwings.TabIndex = 158
        '
        'frmOwingStudents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 485)
        Me.Controls.Add(Me.dGridOwings)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOwingStudents"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Students With Balances"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGridOwings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnPrintOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSelectedStatementOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAllStatementsOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSmsReminderOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblTotalOwings As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dGridOwings As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents lblTotalRecords As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnPrintListOwings As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSelectedReminder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAllReminders As DevComponents.DotNetBar.ButtonItem
End Class
