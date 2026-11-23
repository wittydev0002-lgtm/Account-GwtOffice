<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAmortizer
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAmortizer))
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grd = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtYrs = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtApr = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtAmt = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel6 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.lblPrincipal = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.lblInterest = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.lblInstallment = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnRateTable = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPayment = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAmort = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.SmartColumnReportWriter1 = New SmartColumnReportWriter.SmartColumnReportWriter()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel6.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel1.Controls.Add(Me.Bar2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel1.Controls.Add(Me.Bar1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(658, 421)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.grd)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel3.Location = New System.Drawing.Point(1, 108)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(656, 288)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 9
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 0)
        Me.grd.Name = "grd"
        Me.grd.ReadOnly = True
        Me.grd.RowHeadersWidth = 25
        Me.grd.Size = New System.Drawing.Size(656, 288)
        Me.grd.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.grd.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.grd.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.grd.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.grd.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.grd.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.grd.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grd.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Period"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 72
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Principal"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 84
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Interest"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 81
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Instalment"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 97
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Balance"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 81
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.txtYrs)
        Me.KryptonPanel2.Controls.Add(Me.txtApr)
        Me.KryptonPanel2.Controls.Add(Me.txtAmt)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel6)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel5)
        Me.KryptonPanel2.Controls.Add(Me.KryptonPanel4)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel2.Location = New System.Drawing.Point(1, 60)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(656, 48)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 8
        '
        'txtYrs
        '
        Me.txtYrs.Location = New System.Drawing.Point(415, 14)
        Me.txtYrs.Name = "txtYrs"
        Me.txtYrs.Size = New System.Drawing.Size(125, 20)
        Me.txtYrs.TabIndex = 5
        Me.txtYrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtApr
        '
        Me.txtApr.Location = New System.Drawing.Point(244, 14)
        Me.txtApr.Name = "txtApr"
        Me.txtApr.Size = New System.Drawing.Size(70, 20)
        Me.txtApr.TabIndex = 4
        Me.txtApr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmt
        '
        Me.txtAmt.Location = New System.Drawing.Point(90, 14)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(91, 20)
        Me.txtAmt.TabIndex = 3
        Me.txtAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonPanel6
        '
        Me.KryptonPanel6.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel6.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel6.Location = New System.Drawing.Point(322, 13)
        Me.KryptonPanel6.Name = "KryptonPanel6"
        Me.KryptonPanel6.Size = New System.Drawing.Size(91, 21)
        Me.KryptonPanel6.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel6.TabIndex = 2
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(91, 20)
        Me.KryptonLabel3.TabIndex = 1
        Me.KryptonLabel3.Values.Text = "Period (mths)"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(91, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel5.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel5.Location = New System.Drawing.Point(190, 13)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Size = New System.Drawing.Size(52, 21)
        Me.KryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel5.TabIndex = 1
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(52, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Rate"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(52, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel4.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel4.Location = New System.Drawing.Point(13, 13)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Size = New System.Drawing.Size(75, 21)
        Me.KryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel4.TabIndex = 0
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(75, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Principal"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(75, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(1, 396)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(656, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.BackColor = System.Drawing.Color.Transparent
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.lblPrincipal, Me.LabelItem3, Me.lblInterest, Me.LabelItem5, Me.lblInstallment})
        Me.Bar2.Location = New System.Drawing.Point(1, 397)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(656, 23)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 6
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Image = CType(resources.GetObject("LabelItem1.Image"), System.Drawing.Image)
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Principal Repayment"
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Text = "0.00"
        Me.lblPrincipal.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem3
        '
        Me.LabelItem3.Image = CType(resources.GetObject("LabelItem3.Image"), System.Drawing.Image)
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = "Interest Payment"
        '
        'lblInterest
        '
        Me.lblInterest.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblInterest.Name = "lblInterest"
        Me.lblInterest.Text = "0.00"
        Me.lblInterest.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelItem5
        '
        Me.LabelItem5.Image = CType(resources.GetObject("LabelItem5.Image"), System.Drawing.Image)
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.Text = "Total Installment"
        '
        'lblInstallment
        '
        Me.lblInstallment.BorderType = DevComponents.DotNetBar.eBorderType.Sunken
        Me.lblInstallment.Name = "lblInstallment"
        Me.lblInstallment.Text = "0.00"
        Me.lblInstallment.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 59)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(656, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.Transparent
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnRateTable, Me.btnPayment, Me.btnAmort, Me.btnPrint})
        Me.Bar1.Location = New System.Drawing.Point(1, 1)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(656, 58)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnRateTable
        '
        Me.btnRateTable.FixedSize = New System.Drawing.Size(55, 55)
        Me.btnRateTable.Image = CType(resources.GetObject("btnRateTable.Image"), System.Drawing.Image)
        Me.btnRateTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnRateTable.Name = "btnRateTable"
        Me.btnRateTable.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnRateTable.Text = "Compute"
        '
        'btnPayment
        '
        Me.btnPayment.FixedSize = New System.Drawing.Size(55, 55)
        Me.btnPayment.Image = CType(resources.GetObject("btnPayment.Image"), System.Drawing.Image)
        Me.btnPayment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPayment.Text = "Repay"
        '
        'btnAmort
        '
        Me.btnAmort.FixedSize = New System.Drawing.Size(55, 55)
        Me.btnAmort.Image = CType(resources.GetObject("btnAmort.Image"), System.Drawing.Image)
        Me.btnAmort.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAmort.Name = "btnAmort"
        Me.btnAmort.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAmort.Text = "Amortize"
        '
        'btnPrint
        '
        Me.btnPrint.FixedSize = New System.Drawing.Size(55, 55)
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPrint.Text = "Print"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(657, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 419)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 419)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(658, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 420)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(658, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'SmartColumnReportWriter1
        '
        Me.SmartColumnReportWriter1.AlternateBackColor = System.Drawing.Color.Empty
        Me.SmartColumnReportWriter1.boolGenericReport = False
        Me.SmartColumnReportWriter1.boolGroupDetails = False
        Me.SmartColumnReportWriter1.boolPrintTotals = False
        Me.SmartColumnReportWriter1.BorderColor = System.Drawing.Color.Empty
        Me.SmartColumnReportWriter1.DetailColor = System.Drawing.Color.Empty
        Me.SmartColumnReportWriter1.DetailFont = Nothing
        Me.SmartColumnReportWriter1.DrawBorder = False
        Me.SmartColumnReportWriter1.DrawSummaryChart = False
        Me.SmartColumnReportWriter1.FooterColor = System.Drawing.Color.Empty
        Me.SmartColumnReportWriter1.FooterFont = Nothing
        Me.SmartColumnReportWriter1.GridColor = System.Drawing.Color.Empty
        Me.SmartColumnReportWriter1.HeaderFont = Nothing
        Me.SmartColumnReportWriter1.HorizontalLines = False
        Me.SmartColumnReportWriter1.intBreakIndex = 0
        Me.SmartColumnReportWriter1.intKeyFieldIndex = 0
        Me.SmartColumnReportWriter1.intPrintRecordsCount = 0
        Me.SmartColumnReportWriter1.LogoPath = Nothing
        Me.SmartColumnReportWriter1.PrintSummary = False
        Me.SmartColumnReportWriter1.SqlStatement = Nothing
        Me.SmartColumnReportWriter1.strDatabaseConnectionString = Nothing
        Me.SmartColumnReportWriter1.strFooterCaption = Nothing
        Me.SmartColumnReportWriter1.strMainCaption = Nothing
        Me.SmartColumnReportWriter1.TitleColor = System.Drawing.Color.Empty
        Me.SmartColumnReportWriter1.VerticalLines = False
        '
        'frmAmortizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 421)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAmortizer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.Text = "Loan Amortizer"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.KryptonPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel6.ResumeLayout(False)
        Me.KryptonPanel6.PerformLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnRateTable As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents grd As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnPayment As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAmort As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel6 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtAmt As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtApr As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtYrs As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lblPrincipal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblInterest As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblInstallment As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmartColumnReportWriter1 As SmartColumnReportWriter.SmartColumnReportWriter
End Class
