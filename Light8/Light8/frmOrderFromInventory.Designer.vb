<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrderFromInventory

    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.txtSearchString = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboSearchOptions = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.cboSearchOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 337)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(581, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 337)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(580, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 337)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(307, 11)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(261, 20)
        Me.txtSearchString.TabIndex = 15
        '
        'cboSearchOptions
        '
        Me.cboSearchOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cboSearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchOptions.DropDownWidth = 143
        Me.cboSearchOptions.ForeColor = System.Drawing.Color.Black
        Me.cboSearchOptions.Items.AddRange(New Object() {"Item Code", "Item name"})
        Me.cboSearchOptions.Location = New System.Drawing.Point(83, 13)
        Me.cboSearchOptions.Name = "cboSearchOptions"
        Me.cboSearchOptions.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchOptions.Size = New System.Drawing.Size(143, 21)
        Me.cboSearchOptions.TabIndex = 14
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel4.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel4.Location = New System.Drawing.Point(238, 13)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(68, 21)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 13
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(68, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Search for"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(68, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel3.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel3.Location = New System.Drawing.Point(12, 13)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(70, 21)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 12
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(70, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Search by"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(70, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dGrid)
        Me.KryptonGroupBox1.Panel.ForeColor = System.Drawing.Color.Black
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(556, 248)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 16
        Me.KryptonGroupBox1.Text = "Inventory Items"
        Me.KryptonGroupBox1.Values.Heading = "Inventory Items"
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(0, 0)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(554, 225)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 25
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Item Code"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 78
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Description"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 81
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "Cost Price"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 75
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(493, 303)
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
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(412, 303)
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
        Me.btnOK.TabIndex = 17
        Me.btnOK.Values.Text = "&OK"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(579, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'frmOrderFromInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(581, 338)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.KryptonGroupBox1)
        Me.Controls.Add(Me.txtSearchString)
        Me.Controls.Add(Me.cboSearchOptions)
        Me.Controls.Add(Me.KryptonPanel4)
        Me.Controls.Add(Me.KryptonPanel3)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge2)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrderFromInventory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Order From Inventory"
        CType(Me.cboSearchOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtSearchString As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboSearchOptions As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
