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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txtAmountTenderedOther = New System.Windows.Forms.TextBox()
        Me.txtAmountTenderedTransfer = New System.Windows.Forms.TextBox()
        Me.txtAmountTenderedSwipe = New System.Windows.Forms.TextBox()
        Me.txtAmountTenderedEcocash = New System.Windows.Forms.TextBox()
        Me.txtAmountTenderedCash = New System.Windows.Forms.TextBox()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCurrency = New System.Windows.Forms.ComboBox()
        Me.txtChangeExchange = New Numberbox.Numberbox()
        Me.txtTenderExchangeEcocash = New Numberbox.Numberbox()
        Me.txtChange = New Numberbox.Numberbox()
        Me.txtTenderExchangeCash = New Numberbox.Numberbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTenderExchangeSwipe = New Numberbox.Numberbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTenderExchangeTransfer = New Numberbox.Numberbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenderExchangeOther = New Numberbox.Numberbox()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBillTotal = New Numberbox.Numberbox()
        Me.txtBillExchange = New Numberbox.Numberbox()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Controls.Add(Me.Label6)
        Me.KryptonPanel1.Controls.Add(Me.txtBillTotal)
        Me.KryptonPanel1.Controls.Add(Me.txtBillExchange)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnOK)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.KryptonPanel1.Size = New System.Drawing.Size(363, 410)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(21, 65)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountTenderedOther)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountTenderedTransfer)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountTenderedSwipe)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountTenderedEcocash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtAmountTenderedCash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblTotalPaid)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label7)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboCurrency)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtChangeExchange)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeEcocash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtChange)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeCash)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeSwipe)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label4)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeTransfer)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtTenderExchangeOther)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label1)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(320, 293)
        Me.KryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox1.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox1.TabIndex = 1
        Me.KryptonGroupBox1.Text = "Amounts"
        Me.KryptonGroupBox1.Values.Heading = "Amounts"
        '
        'txtAmountTenderedOther
        '
        Me.txtAmountTenderedOther.Location = New System.Drawing.Point(121, 153)
        Me.txtAmountTenderedOther.Name = "txtAmountTenderedOther"
        Me.txtAmountTenderedOther.Size = New System.Drawing.Size(90, 20)
        Me.txtAmountTenderedOther.TabIndex = 57
        Me.txtAmountTenderedOther.Text = "0.00"
        Me.txtAmountTenderedOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmountTenderedTransfer
        '
        Me.txtAmountTenderedTransfer.Location = New System.Drawing.Point(121, 131)
        Me.txtAmountTenderedTransfer.Name = "txtAmountTenderedTransfer"
        Me.txtAmountTenderedTransfer.Size = New System.Drawing.Size(90, 20)
        Me.txtAmountTenderedTransfer.TabIndex = 56
        Me.txtAmountTenderedTransfer.Text = "0.00"
        Me.txtAmountTenderedTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmountTenderedSwipe
        '
        Me.txtAmountTenderedSwipe.Location = New System.Drawing.Point(121, 109)
        Me.txtAmountTenderedSwipe.Name = "txtAmountTenderedSwipe"
        Me.txtAmountTenderedSwipe.Size = New System.Drawing.Size(90, 20)
        Me.txtAmountTenderedSwipe.TabIndex = 55
        Me.txtAmountTenderedSwipe.Text = "0.00"
        Me.txtAmountTenderedSwipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmountTenderedEcocash
        '
        Me.txtAmountTenderedEcocash.Location = New System.Drawing.Point(121, 87)
        Me.txtAmountTenderedEcocash.Name = "txtAmountTenderedEcocash"
        Me.txtAmountTenderedEcocash.Size = New System.Drawing.Size(90, 20)
        Me.txtAmountTenderedEcocash.TabIndex = 54
        Me.txtAmountTenderedEcocash.Text = "0.00"
        Me.txtAmountTenderedEcocash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmountTenderedCash
        '
        Me.txtAmountTenderedCash.Location = New System.Drawing.Point(121, 66)
        Me.txtAmountTenderedCash.Name = "txtAmountTenderedCash"
        Me.txtAmountTenderedCash.Size = New System.Drawing.Size(90, 20)
        Me.txtAmountTenderedCash.TabIndex = 53
        Me.txtAmountTenderedCash.Text = "0.00"
        Me.txtAmountTenderedCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPaid.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.ForeColor = System.Drawing.Color.White
        Me.lblTotalPaid.Location = New System.Drawing.Point(212, 176)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTotalPaid.Size = New System.Drawing.Size(89, 20)
        Me.lblTotalPaid.TabIndex = 52
        Me.lblTotalPaid.Text = "0.00"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(19, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Change"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(121, 29)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(180, 21)
        Me.cboCurrency.Sorted = True
        Me.cboCurrency.TabIndex = 0
        '
        'txtChangeExchange
        '
        Me.txtChangeExchange.AllowDecimal = True
        Me.txtChangeExchange.Enabled = False
        Me.txtChangeExchange.Location = New System.Drawing.Point(212, 226)
        Me.txtChangeExchange.Name = "txtChangeExchange"
        Me.txtChangeExchange.Size = New System.Drawing.Size(89, 20)
        Me.txtChangeExchange.TabIndex = 12
        Me.txtChangeExchange.Text = "0.00"
        Me.txtChangeExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChangeExchange.ThousandsSeperator = False
        Me.txtChangeExchange.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtTenderExchangeEcocash
        '
        Me.txtTenderExchangeEcocash.AllowDecimal = True
        Me.txtTenderExchangeEcocash.Enabled = False
        Me.txtTenderExchangeEcocash.Location = New System.Drawing.Point(212, 87)
        Me.txtTenderExchangeEcocash.Name = "txtTenderExchangeEcocash"
        Me.txtTenderExchangeEcocash.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeEcocash.TabIndex = 4
        Me.txtTenderExchangeEcocash.Text = "0.00"
        Me.txtTenderExchangeEcocash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeEcocash.ThousandsSeperator = False
        Me.txtTenderExchangeEcocash.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtChange
        '
        Me.txtChange.AllowDecimal = True
        Me.txtChange.BackColor = System.Drawing.Color.LightYellow
        Me.txtChange.Location = New System.Drawing.Point(121, 226)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(90, 20)
        Me.txtChange.TabIndex = 11
        Me.txtChange.Text = "0.00"
        Me.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChange.ThousandsSeperator = False
        Me.txtChange.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtTenderExchangeCash
        '
        Me.txtTenderExchangeCash.AllowDecimal = True
        Me.txtTenderExchangeCash.Enabled = False
        Me.txtTenderExchangeCash.Location = New System.Drawing.Point(212, 66)
        Me.txtTenderExchangeCash.Name = "txtTenderExchangeCash"
        Me.txtTenderExchangeCash.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeCash.TabIndex = 2
        Me.txtTenderExchangeCash.Text = "0.00"
        Me.txtTenderExchangeCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeCash.ThousandsSeperator = False
        Me.txtTenderExchangeCash.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(18, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(101, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Other"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderExchangeSwipe
        '
        Me.txtTenderExchangeSwipe.AllowDecimal = True
        Me.txtTenderExchangeSwipe.Enabled = False
        Me.txtTenderExchangeSwipe.Location = New System.Drawing.Point(212, 109)
        Me.txtTenderExchangeSwipe.Name = "txtTenderExchangeSwipe"
        Me.txtTenderExchangeSwipe.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeSwipe.TabIndex = 6
        Me.txtTenderExchangeSwipe.Text = "0.00"
        Me.txtTenderExchangeSwipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeSwipe.ThousandsSeperator = False
        Me.txtTenderExchangeSwipe.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(18, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Transfer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderExchangeTransfer
        '
        Me.txtTenderExchangeTransfer.AllowDecimal = True
        Me.txtTenderExchangeTransfer.Enabled = False
        Me.txtTenderExchangeTransfer.Location = New System.Drawing.Point(212, 131)
        Me.txtTenderExchangeTransfer.Name = "txtTenderExchangeTransfer"
        Me.txtTenderExchangeTransfer.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeTransfer.TabIndex = 8
        Me.txtTenderExchangeTransfer.Text = "0.00"
        Me.txtTenderExchangeTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeTransfer.ThousandsSeperator = False
        Me.txtTenderExchangeTransfer.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(18, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Swipe"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(18, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Ecocash"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenderExchangeOther
        '
        Me.txtTenderExchangeOther.AllowDecimal = True
        Me.txtTenderExchangeOther.Enabled = False
        Me.txtTenderExchangeOther.Location = New System.Drawing.Point(212, 153)
        Me.txtTenderExchangeOther.Name = "txtTenderExchangeOther"
        Me.txtTenderExchangeOther.Size = New System.Drawing.Size(89, 20)
        Me.txtTenderExchangeOther.TabIndex = 10
        Me.txtTenderExchangeOther.Text = "0.00"
        Me.txtTenderExchangeOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTenderExchangeOther.ThousandsSeperator = False
        Me.txtTenderExchangeOther.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel2.Location = New System.Drawing.Point(17, 29)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(102, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 20
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(102, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Currency Used"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(102, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(18, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Cash"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(58, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(101, 20)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Receipt Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBillTotal
        '
        Me.txtBillTotal.AllowDecimal = True
        Me.txtBillTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtBillTotal.Enabled = False
        Me.txtBillTotal.Location = New System.Drawing.Point(161, 32)
        Me.txtBillTotal.Name = "txtBillTotal"
        Me.txtBillTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtBillTotal.TabIndex = 0
        Me.txtBillTotal.Text = "0.00"
        Me.txtBillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBillTotal.ThousandsSeperator = False
        Me.txtBillTotal.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtBillExchange
        '
        Me.txtBillExchange.AllowDecimal = True
        Me.txtBillExchange.Enabled = False
        Me.txtBillExchange.Location = New System.Drawing.Point(252, 32)
        Me.txtBillExchange.Name = "txtBillExchange"
        Me.txtBillExchange.Size = New System.Drawing.Size(89, 20)
        Me.txtBillExchange.TabIndex = 1
        Me.txtBillExchange.Text = "0.00"
        Me.txtBillExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBillExchange.ThousandsSeperator = False
        Me.txtBillExchange.ZeroOutEmptyStringOnLostFocus = False
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(4, 3)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(355, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(3, 3)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 403)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(359, 3)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(1, 403)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(3, 406)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(357, 1)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(266, 364)
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
        Me.btnCancel.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnCancel.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnCancel.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnCancel.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnCancel.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnCancel.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Values.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.AutoSize = True
        Me.btnOK.Location = New System.Drawing.Point(185, 364)
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
        Me.btnOK.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnOK.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnOK.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnOK.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnOK.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnOK.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnOK.TabIndex = 2
        Me.btnOK.Values.Text = "OK"
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmTenderAmount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 410)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTenderAmount"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Back.ColorAngle = 100.0!
        Me.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Border.Width = 2
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Header.Back.ColorAngle = 100.0!
        Me.StateCommon.Header.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Cash Out"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Private WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents cboCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtChange As Numberbox.Numberbox
    Friend WithEvents txtBillTotal As Numberbox.Numberbox
    Friend WithEvents txtChangeExchange As Numberbox.Numberbox
    Friend WithEvents txtBillExchange As Numberbox.Numberbox
    Friend WithEvents txtTenderExchangeCash As Numberbox.Numberbox
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents txtTenderExchangeOther As Numberbox.Numberbox
    Friend WithEvents txtTenderExchangeTransfer As Numberbox.Numberbox
    Friend WithEvents txtTenderExchangeSwipe As Numberbox.Numberbox
    Friend WithEvents txtTenderExchangeEcocash As Numberbox.Numberbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPaid As System.Windows.Forms.Label
    Friend WithEvents txtAmountTenderedOther As TextBox
    Friend WithEvents txtAmountTenderedTransfer As TextBox
    Friend WithEvents txtAmountTenderedSwipe As TextBox
    Friend WithEvents txtAmountTenderedEcocash As TextBox
    Friend WithEvents txtAmountTenderedCash As TextBox
End Class
