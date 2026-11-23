<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalendarSetup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.tsSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroup1 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.txtNumberOfRuns = New Numberbox.Numberbox()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dGrid = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn()
        Me.Column3 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn()
        Me.Column4 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup1.Panel.SuspendLayout()
        Me.KryptonGroup1.SuspendLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.tsSave)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroup1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Padding = New System.Windows.Forms.Padding(12)
        Me.KryptonPanel.Size = New System.Drawing.Size(667, 480)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(580, 444)
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
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'tsSave
        '
        Me.tsSave.BackColor = System.Drawing.Color.White
        Me.tsSave.ForeColor = System.Drawing.Color.Black
        Me.tsSave.Location = New System.Drawing.Point(499, 444)
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(75, 25)
        Me.tsSave.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.tsSave.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.tsSave.StateCommon.Back.ColorAngle = 100.0!
        Me.tsSave.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.tsSave.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.tsSave.StateCommon.Border.Rounding = 0
        Me.tsSave.TabIndex = 16
        Me.tsSave.Values.Text = "&Save"
        '
        'KryptonGroup1
        '
        Me.KryptonGroup1.BackColor = System.Drawing.Color.White
        Me.KryptonGroup1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonGroup1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonGroup1.Name = "KryptonGroup1"
        '
        'KryptonGroup1.Panel
        '
        Me.KryptonGroup1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonGroup1.Panel.Controls.Add(Me.txtNumberOfRuns)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonPanel13)
        Me.KryptonGroup1.Panel.Controls.Add(Me.dGrid)
        Me.KryptonGroup1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroup1.Size = New System.Drawing.Size(643, 426)
        Me.KryptonGroup1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroup1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup1.StateCommon.Border.Rounding = 0
        Me.KryptonGroup1.StateCommon.Border.Width = 1
        Me.KryptonGroup1.TabIndex = 15
        '
        'txtNumberOfRuns
        '
        Me.txtNumberOfRuns.AllowDecimal = True
        Me.txtNumberOfRuns.BackColor = System.Drawing.Color.White
        Me.txtNumberOfRuns.ForeColor = System.Drawing.Color.Black
        Me.txtNumberOfRuns.Location = New System.Drawing.Point(165, 21)
        Me.txtNumberOfRuns.MaxLength = 5
        Me.txtNumberOfRuns.Name = "txtNumberOfRuns"
        Me.txtNumberOfRuns.Size = New System.Drawing.Size(67, 20)
        Me.txtNumberOfRuns.TabIndex = 47
        Me.txtNumberOfRuns.ThousandsSeperator = False
        Me.txtNumberOfRuns.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel13.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel13.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel13.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel13.Location = New System.Drawing.Point(14, 15)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Size = New System.Drawing.Size(150, 26)
        Me.KryptonPanel13.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel13.TabIndex = 46
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 25)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(150, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(150, 26)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Number of Runs per year"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column6, Me.Column2, Me.Column3, Me.Column4})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dGrid.Location = New System.Drawing.Point(0, 58)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.Size = New System.Drawing.Size(641, 366)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 3
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Tx Period"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 90
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Curr. Run"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 90
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Total Runs"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 95
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.CalendarTodayDate = New Date(2015, 9, 28, 0, 0, 0, 0)
        Me.Column2.Checked = False
        Me.Column2.CustomFormat = "dd-MMM-yyyy"
        Me.Column2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Column2.HeaderText = "Start Date"
        Me.Column2.MinimumWidth = 100
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column2.Width = 100
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.CalendarTodayDate = New Date(2015, 9, 28, 0, 0, 0, 0)
        Me.Column3.Checked = False
        Me.Column3.CustomFormat = "dd-MMM-yyyy"
        Me.Column3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Column3.HeaderText = "End Date"
        Me.Column3.MinimumWidth = 100
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 100
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.DropDownWidth = 121
        Me.Column4.HeaderText = "Status"
        Me.Column4.Items.AddRange(New String() {"Y", "N"})
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 72
        '
        'frmCalendarSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 480)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalendarSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calendar Setup"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.Panel.ResumeLayout(False)
        Me.KryptonGroup1.Panel.PerformLayout()
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.ResumeLayout(False)
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        Me.KryptonPanel13.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonGroup1 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents tsSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn
    Friend WithEvents Column3 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn
    Friend WithEvents Column4 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
    Friend WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtNumberOfRuns As Numberbox.Numberbox
    'Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
