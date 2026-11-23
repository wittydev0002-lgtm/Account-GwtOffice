<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTenderAmount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTenderAmount))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cboPaymentMethod = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAmountTendered = New Numberbox.Numberbox()
        Me.txtTenderExchange = New Numberbox.Numberbox()
        Me.txtBillTotal = New Numberbox.Numberbox()
        Me.txtBillExchange = New Numberbox.Numberbox()
        Me.txtChange = New Numberbox.Numberbox()
        Me.txtChangeExchange = New Numberbox.Numberbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.cboCurrency = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cboPaymentMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.cboCurrency)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(491, 300)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(388, 259)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Values.Image = CType(resources.GetObject("btnCancel.Values.Image"), System.Drawing.Image)
        Me.btnCancel.Values.Text = "Cancel [F8]"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(307, 259)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOK.StateCommon.Back.ColorAngle = 100.0!
        Me.btnOK.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnOK.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnOK.StateCommon.Border.Rounding = 0
        Me.btnOK.TabIndex = 2
        Me.btnOK.Values.Image = CType(resources.GetObject("btnOK.Values.Image"), System.Drawing.Image)
        Me.btnOK.Values.Text = "OK [F3]"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(18, 54)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboPaymentMethod)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.TableLayoutPanel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel3)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(455, 199)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 1
        Me.KryptonGroupBox1.Text = "Amounts"
        Me.KryptonGroupBox1.Values.Heading = "Amounts"
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMethod.DropDownWidth = 360
        Me.cboPaymentMethod.Items.AddRange(New Object() {"Cash", "Ecocash", "Swipe", "Transfer"})
        Me.cboPaymentMethod.Location = New System.Drawing.Point(77, 137)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboPaymentMethod.Size = New System.Drawing.Size(360, 21)
        Me.cboPaymentMethod.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.50512!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.49488!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAmountTendered, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTenderExchange, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBillTotal, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBillExchange, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtChange, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtChangeExchange, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(419, 111)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(304, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Default Par Rate"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(197, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tender Currency"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmountTendered
        '
        Me.txtAmountTendered.AllowDecimal = True
        Me.txtAmountTendered.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAmountTendered.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountTendered.Location = New System.Drawing.Point(197, 32)
        Me.txtAmountTendered.Name = "txtAmountTendered"
        Me.txtAmountTendered.Size = New System.Drawing.Size(99, 21)
        Me.txtAmountTendered.TabIndex = 0
        Me.txtAmountTendered.Text = "0.00"
        Me.txtAmountTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountTendered.ThousandsSeperator = False
        Me.txtAmountTendered.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtTenderExchange
        '
        Me.txtTenderExchange.AllowDecimal = True
        Me.txtTenderExchange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenderExchange.Enabled = False
        Me.txtTenderExchange.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenderExchange.Location = New System.Drawing.Point(304, 32)
        Me.txtTenderExchange.Name = "txtTenderExchange"
        Me.txtTenderExchange.Size = New System.Drawing.Size(110, 21)
        Me.txtTenderExchange.TabIndex = 1
        Me.txtTenderExchange.Text = "0.00"
        Me.txtTenderExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchange.ThousandsSeperator = False
        Me.txtTenderExchange.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtBillTotal
        '
        Me.txtBillTotal.AllowDecimal = True
        Me.txtBillTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBillTotal.Enabled = False
        Me.txtBillTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillTotal.Location = New System.Drawing.Point(197, 59)
        Me.txtBillTotal.Name = "txtBillTotal"
        Me.txtBillTotal.Size = New System.Drawing.Size(99, 21)
        Me.txtBillTotal.TabIndex = 1
        Me.txtBillTotal.Text = "0.00"
        Me.txtBillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBillTotal.ThousandsSeperator = False
        Me.txtBillTotal.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtBillExchange
        '
        Me.txtBillExchange.AllowDecimal = True
        Me.txtBillExchange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBillExchange.Enabled = False
        Me.txtBillExchange.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillExchange.Location = New System.Drawing.Point(304, 59)
        Me.txtBillExchange.Name = "txtBillExchange"
        Me.txtBillExchange.Size = New System.Drawing.Size(110, 21)
        Me.txtBillExchange.TabIndex = 3
        Me.txtBillExchange.Text = "0.00"
        Me.txtBillExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBillExchange.ThousandsSeperator = False
        Me.txtBillExchange.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtChange
        '
        Me.txtChange.AllowDecimal = True
        Me.txtChange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChange.Enabled = False
        Me.txtChange.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChange.Location = New System.Drawing.Point(197, 86)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(99, 21)
        Me.txtChange.TabIndex = 2
        Me.txtChange.Text = "0.00"
        Me.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChange.ThousandsSeperator = False
        Me.txtChange.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtChangeExchange
        '
        Me.txtChangeExchange.AllowDecimal = True
        Me.txtChangeExchange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChangeExchange.Enabled = False
        Me.txtChangeExchange.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangeExchange.Location = New System.Drawing.Point(304, 86)
        Me.txtChangeExchange.Name = "txtChangeExchange"
        Me.txtChangeExchange.Size = New System.Drawing.Size(110, 21)
        Me.txtChangeExchange.TabIndex = 5
        Me.txtChangeExchange.Text = "0.00"
        Me.txtChangeExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChangeExchange.ThousandsSeperator = False
        Me.txtChangeExchange.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 25)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Tender Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(184, 25)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Bill Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 26)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Change"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.Label6)
        Me.KryptonPanel3.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel3.Location = New System.Drawing.Point(18, 134)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Size = New System.Drawing.Size(59, 24)
        Me.KryptonPanel3.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel3.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Paid In"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 23)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(59, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(490, 1)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(1, 298)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 298)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 299)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(491, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(491, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.Label3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel2.Location = New System.Drawing.Point(18, 17)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(127, 24)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Currency tendered"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 23)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(127, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownHeight = 100
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.DropDownWidth = 328
        Me.cboCurrency.Location = New System.Drawing.Point(146, 20)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.cboCurrency.Size = New System.Drawing.Size(328, 21)
        Me.cboCurrency.StateCommon.ComboBox.Content.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.cboCurrency.TabIndex = 0
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmTenderAmount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTenderAmount"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Content.LongText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.LongText.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White
        Me.Text = "Cashout"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cboPaymentMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.cboCurrency, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboCurrency As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAmountTendered As Numberbox.Numberbox
    Friend WithEvents txtTenderExchange As Numberbox.Numberbox
    Friend WithEvents txtBillTotal As Numberbox.Numberbox
    Friend WithEvents txtBillExchange As Numberbox.Numberbox
    Friend WithEvents txtChange As Numberbox.Numberbox
    Friend WithEvents txtChangeExchange As Numberbox.Numberbox
    Friend WithEvents cboPaymentMethod As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
