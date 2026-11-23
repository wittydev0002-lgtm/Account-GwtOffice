<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.pnlMain = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.dGrid = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtSearchString = New System.Windows.Forms.TextBox()
        Me.txtPatientReference = New Numberbox.Numberbox()
        Me.KryptonPanel122 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel109 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge172 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.AdvancedDatagridview1 = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel122, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel122.SuspendLayout()
        CType(Me.AdvancedDatagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.dGrid)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge4)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge3)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge2)
        Me.pnlMain.Controls.Add(Me.KryptonBorderEdge1)
        Me.pnlMain.Controls.Add(Me.KryptonPanel2)
        Me.pnlMain.Location = New System.Drawing.Point(30, 50)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(492, 260)
        Me.pnlMain.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.pnlMain.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.pnlMain.TabIndex = 0
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.AllowUserToResizeColumns = False
        Me.dGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGrid.Location = New System.Drawing.Point(1, 23)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersWidth = 25
        Me.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.Size = New System.Drawing.Size(490, 236)
        Me.dGrid.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.dGrid.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.dGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGrid.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGrid.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGrid.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderColumn.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGrid.StateSelected.HeaderRow.Content.Color1 = System.Drawing.Color.White
        Me.dGrid.StateSelected.HeaderRow.Content.Color2 = System.Drawing.Color.White
        Me.dGrid.TabIndex = 5
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(491, 23)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 236)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 23)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 236)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 259)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(492, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 22)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(492, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.txtSearchString)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(492, 22)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 0
        '
        'txtSearchString
        '
        Me.txtSearchString.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSearchString.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchString.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(124, 22)
        Me.txtSearchString.TabIndex = 0
        '
        'txtPatientReference
        '
        Me.txtPatientReference.AllowDecimal = True
        Me.txtPatientReference.BackColor = System.Drawing.Color.White
        Me.txtPatientReference.ForeColor = System.Drawing.Color.Black
        Me.txtPatientReference.Location = New System.Drawing.Point(349, 13)
        Me.txtPatientReference.Name = "txtPatientReference"
        Me.txtPatientReference.Size = New System.Drawing.Size(75, 20)
        Me.txtPatientReference.TabIndex = 411
        Me.txtPatientReference.Text = "1"
        Me.txtPatientReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPatientReference.ThousandsSeperator = False
        Me.txtPatientReference.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel122
        '
        Me.KryptonPanel122.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel122.Controls.Add(Me.KryptonLabel109)
        Me.KryptonPanel122.Controls.Add(Me.KryptonBorderEdge172)
        Me.KryptonPanel122.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel122.Location = New System.Drawing.Point(244, 12)
        Me.KryptonPanel122.Name = "KryptonPanel122"
        Me.KryptonPanel122.Size = New System.Drawing.Size(103, 21)
        Me.KryptonPanel122.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel122.TabIndex = 410
        '
        'KryptonLabel109
        '
        Me.KryptonLabel109.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonLabel109.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel109.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel109.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel109.Name = "KryptonLabel109"
        Me.KryptonLabel109.Size = New System.Drawing.Size(103, 20)
        Me.KryptonLabel109.TabIndex = 275
        Me.KryptonLabel109.Values.Text = "Patient ref #"
        '
        'KryptonBorderEdge172
        '
        Me.KryptonBorderEdge172.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge172.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge172.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge172.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge172.Name = "KryptonBorderEdge172"
        Me.KryptonBorderEdge172.Size = New System.Drawing.Size(103, 1)
        Me.KryptonBorderEdge172.Text = "KryptonBorderEdge172"
        '
        'AdvancedDatagridview1
        '
        Me.AdvancedDatagridview1.AllowUserToAddRows = False
        Me.AdvancedDatagridview1.AllowUserToDeleteRows = False
        Me.AdvancedDatagridview1.AllowUserToResizeColumns = False
        Me.AdvancedDatagridview1.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AdvancedDatagridview1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.AdvancedDatagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.AdvancedDatagridview1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column13, Me.Column6, Me.Column7, Me.Column8})
        Me.AdvancedDatagridview1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AdvancedDatagridview1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.AdvancedDatagridview1.Location = New System.Drawing.Point(0, 265)
        Me.AdvancedDatagridview1.Name = "AdvancedDatagridview1"
        Me.AdvancedDatagridview1.RowHeadersWidth = 25
        Me.AdvancedDatagridview1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.AdvancedDatagridview1.Size = New System.Drawing.Size(555, 84)
        Me.AdvancedDatagridview1.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.AdvancedDatagridview1.StateCommon.Background.Color2 = System.Drawing.Color.White
        Me.AdvancedDatagridview1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.AdvancedDatagridview1.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvancedDatagridview1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.AdvancedDatagridview1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.AdvancedDatagridview1.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.AdvancedDatagridview1.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvancedDatagridview1.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.AdvancedDatagridview1.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.AdvancedDatagridview1.StateCommon.HeaderRow.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.AdvancedDatagridview1.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvancedDatagridview1.TabIndex = 412
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 42
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 44
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Info"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 37
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Freq"
        Me.Column4.MinimumWidth = 50
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 50
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Dosage"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 53
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column13.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column13.DropDownWidth = 121
        Me.Column13.HeaderText = "Admin"
        Me.Column13.Items.AddRange(New String() {"Injection", "Intra", "Mouth", "Other", ""})
        Me.Column13.Name = "Column13"
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column13.Width = 65
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column6.HeaderText = "Duration"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 58
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column7.DropDownWidth = 121
        Me.Column7.HeaderText = "Repeat"
        Me.Column7.Items.AddRange(New String() {"N", "Y"})
        Me.Column7.Name = "Column7"
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.Width = 52
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Image = CType(resources.GetObject("Column8.Image"), System.Drawing.Image)
        Me.Column8.MinimumWidth = 25
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 25
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 349)
        Me.Controls.Add(Me.AdvancedDatagridview1)
        Me.Controls.Add(Me.txtPatientReference)
        Me.Controls.Add(Me.KryptonPanel122)
        Me.Controls.Add(Me.pnlMain)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel122, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel122.ResumeLayout(False)
        Me.KryptonPanel122.PerformLayout()
        CType(Me.AdvancedDatagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlMain As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents txtSearchString As TextBox
    Friend WithEvents dGrid As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents txtPatientReference As Numberbox.Numberbox
    Friend WithEvents KryptonPanel122 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel109 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge172 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents AdvancedDatagridview1 As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
    Friend WithEvents Column8 As DataGridViewImageColumn
End Class
