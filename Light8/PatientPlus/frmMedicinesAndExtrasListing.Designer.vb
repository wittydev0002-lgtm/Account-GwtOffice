<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicinesAndExtrasListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicinesAndExtrasListing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar3 = New DevComponents.DotNetBar.Bar()
        Me.btnNewDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDeleteDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnImportDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnExportDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnRefreshDrug = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDrugCategories = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDrugSuppliers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnManufacturers = New DevComponents.DotNetBar.ButtonItem()
        Me.btnReceiveDrugs = New DevComponents.DotNetBar.ButtonItem()
        Me.lblTotalRecords = New DevComponents.DotNetBar.LabelItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtSearchStringDrug = New System.Windows.Forms.TextBox()
        Me.cboSearchByDrug = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dGridMedicines = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.cboSearchByDrug, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.dGridMedicines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(747, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(746, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 509)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 509)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'Bar3
        '
        Me.Bar3.AntiAlias = True
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar3.IsMaximized = False
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNewDrug, Me.btnEditDrug, Me.btnDeleteDrug, Me.btnImportDrug, Me.btnExportDrug, Me.btnPrintDrug, Me.btnRefreshDrug, Me.btnDrugCategories, Me.btnDrugSuppliers, Me.btnManufacturers, Me.btnReceiveDrugs, Me.lblTotalRecords})
        Me.Bar3.Location = New System.Drawing.Point(1, 1)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.RoundCorners = False
        Me.Bar3.Size = New System.Drawing.Size(745, 25)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar3.TabIndex = 23
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'btnNewDrug
        '
        Me.btnNewDrug.Image = CType(resources.GetObject("btnNewDrug.Image"), System.Drawing.Image)
        Me.btnNewDrug.Name = "btnNewDrug"
        Me.btnNewDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnNewDrug.Text = "ButtonItem1"
        '
        'btnEditDrug
        '
        Me.btnEditDrug.Image = CType(resources.GetObject("btnEditDrug.Image"), System.Drawing.Image)
        Me.btnEditDrug.Name = "btnEditDrug"
        Me.btnEditDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnEditDrug.Text = "ButtonItem2"
        '
        'btnDeleteDrug
        '
        Me.btnDeleteDrug.BeginGroup = True
        Me.btnDeleteDrug.Image = CType(resources.GetObject("btnDeleteDrug.Image"), System.Drawing.Image)
        Me.btnDeleteDrug.Name = "btnDeleteDrug"
        Me.btnDeleteDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDeleteDrug.Text = "ButtonItem3"
        '
        'btnImportDrug
        '
        Me.btnImportDrug.BeginGroup = True
        Me.btnImportDrug.Image = CType(resources.GetObject("btnImportDrug.Image"), System.Drawing.Image)
        Me.btnImportDrug.Name = "btnImportDrug"
        Me.btnImportDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnImportDrug.Text = "ButtonItem4"
        '
        'btnExportDrug
        '
        Me.btnExportDrug.Image = CType(resources.GetObject("btnExportDrug.Image"), System.Drawing.Image)
        Me.btnExportDrug.Name = "btnExportDrug"
        Me.btnExportDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnExportDrug.Text = "ButtonItem5"
        '
        'btnPrintDrug
        '
        Me.btnPrintDrug.BeginGroup = True
        Me.btnPrintDrug.Image = CType(resources.GetObject("btnPrintDrug.Image"), System.Drawing.Image)
        Me.btnPrintDrug.Name = "btnPrintDrug"
        Me.btnPrintDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrintDrug.Text = "ButtonItem6"
        '
        'btnRefreshDrug
        '
        Me.btnRefreshDrug.Image = CType(resources.GetObject("btnRefreshDrug.Image"), System.Drawing.Image)
        Me.btnRefreshDrug.Name = "btnRefreshDrug"
        Me.btnRefreshDrug.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRefreshDrug.Text = "ButtonItem7"
        '
        'btnDrugCategories
        '
        Me.btnDrugCategories.BeginGroup = True
        Me.btnDrugCategories.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDrugCategories.Image = CType(resources.GetObject("btnDrugCategories.Image"), System.Drawing.Image)
        Me.btnDrugCategories.Name = "btnDrugCategories"
        Me.btnDrugCategories.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDrugCategories.Text = "Categories"
        '
        'btnDrugSuppliers
        '
        Me.btnDrugSuppliers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDrugSuppliers.Image = CType(resources.GetObject("btnDrugSuppliers.Image"), System.Drawing.Image)
        Me.btnDrugSuppliers.Name = "btnDrugSuppliers"
        Me.btnDrugSuppliers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnDrugSuppliers.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnDrugSuppliers.Text = "Suppliers"
        '
        'btnManufacturers
        '
        Me.btnManufacturers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnManufacturers.Image = CType(resources.GetObject("btnManufacturers.Image"), System.Drawing.Image)
        Me.btnManufacturers.Name = "btnManufacturers"
        Me.btnManufacturers.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnManufacturers.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnManufacturers.Text = "Manufacturers"
        '
        'btnReceiveDrugs
        '
        Me.btnReceiveDrugs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReceiveDrugs.Image = CType(resources.GetObject("btnReceiveDrugs.Image"), System.Drawing.Image)
        Me.btnReceiveDrugs.Name = "btnReceiveDrugs"
        Me.btnReceiveDrugs.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReceiveDrugs.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.btnReceiveDrugs.Text = "Receive Items"
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
        'ComboItem1
        '
        Me.ComboItem1.Text = "Code"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Description"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 26)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(745, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.txtSearchStringDrug)
        Me.KryptonPanel2.Controls.Add(Me.cboSearchByDrug)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(1, 27)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(745, 60)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel2.TabIndex = 25
        '
        'txtSearchStringDrug
        '
        Me.txtSearchStringDrug.Location = New System.Drawing.Point(315, 19)
        Me.txtSearchStringDrug.Name = "txtSearchStringDrug"
        Me.txtSearchStringDrug.Size = New System.Drawing.Size(204, 22)
        Me.txtSearchStringDrug.TabIndex = 161
        '
        'cboSearchByDrug
        '
        Me.cboSearchByDrug.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchByDrug.DropDownWidth = 121
        Me.cboSearchByDrug.Items.AddRange(New Object() {"Code", "Name"})
        Me.cboSearchByDrug.Location = New System.Drawing.Point(102, 20)
        Me.cboSearchByDrug.Name = "cboSearchByDrug"
        Me.cboSearchByDrug.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboSearchByDrug.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchByDrug.TabIndex = 160
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Location = New System.Drawing.Point(233, 19)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(80, 22)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 159
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(80, 21)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Search for"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(80, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel3.Location = New System.Drawing.Point(20, 19)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(80, 22)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 158
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(80, 21)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Search by"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(80, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 59)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(745, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'dGridMedicines
        '
        Me.dGridMedicines.AllowUserToAddRows = False
        Me.dGridMedicines.AllowUserToDeleteRows = False
        Me.dGridMedicines.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridMedicines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridMedicines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridMedicines.Location = New System.Drawing.Point(1, 87)
        Me.dGridMedicines.Name = "dGridMedicines"
        Me.dGridMedicines.ReadOnly = True
        Me.dGridMedicines.RowHeadersVisible = False
        Me.dGridMedicines.RowHeadersWidth = 25
        Me.dGridMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridMedicines.Size = New System.Drawing.Size(745, 423)
        Me.dGridMedicines.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridMedicines.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridMedicines.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridMedicines.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.SystemColors.Control
        Me.dGridMedicines.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.Control
        Me.dGridMedicines.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridMedicines.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridMedicines.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridMedicines.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black
        Me.dGridMedicines.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black
        Me.dGridMedicines.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridMedicines.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridMedicines.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dGridMedicines.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridMedicines.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridMedicines.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.White
        Me.dGridMedicines.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.White
        Me.dGridMedicines.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridMedicines.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridMedicines.StateSelected.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridMedicines.StateSelected.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dGridMedicines.TabIndex = 43
        '
        'frmMedicinesAndExtrasListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 510)
        Me.Controls.Add(Me.dGridMedicines)
        Me.Controls.Add(Me.KryptonPanel2)
        Me.Controls.Add(Me.KryptonBorderEdge5)
        Me.Controls.Add(Me.Bar3)
        Me.Controls.Add(Me.KryptonBorderEdge4)
        Me.Controls.Add(Me.KryptonBorderEdge3)
        Me.Controls.Add(Me.KryptonBorderEdge1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMedicinesAndExtrasListing"
        Me.Text = "Medicines and Services"
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.cboSearchByDrug, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.dGridMedicines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNewDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDeleteDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImportDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrintDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefreshDrug As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents btnDrugCategories As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDrugSuppliers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnManufacturers As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnReceiveDrugs As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblTotalRecords As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridMedicines As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents txtSearchStringDrug As TextBox
    Friend WithEvents cboSearchByDrug As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
