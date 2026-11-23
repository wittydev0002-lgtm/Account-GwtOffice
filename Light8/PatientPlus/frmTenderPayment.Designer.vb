<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTenderPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTenderPayment))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblBillTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOthers = New Numberbox.Numberbox()
        Me.txtTransfer = New Numberbox.Numberbox()
        Me.txtSwipe = New Numberbox.Numberbox()
        Me.txtEcocash = New Numberbox.Numberbox()
        Me.txtCash = New Numberbox.Numberbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.lblChange)
        Me.KryptonPanel1.Controls.Add(Me.Label9)
        Me.KryptonPanel1.Controls.Add(Me.lblTotalPaid)
        Me.KryptonPanel1.Controls.Add(Me.Label8)
        Me.KryptonPanel1.Controls.Add(Me.lblBillTotal)
        Me.KryptonPanel1.Controls.Add(Me.Label6)
        Me.KryptonPanel1.Controls.Add(Me.txtOthers)
        Me.KryptonPanel1.Controls.Add(Me.txtTransfer)
        Me.KryptonPanel1.Controls.Add(Me.txtSwipe)
        Me.KryptonPanel1.Controls.Add(Me.txtEcocash)
        Me.KryptonPanel1.Controls.Add(Me.txtCash)
        Me.KryptonPanel1.Controls.Add(Me.Label5)
        Me.KryptonPanel1.Controls.Add(Me.Label4)
        Me.KryptonPanel1.Controls.Add(Me.Label3)
        Me.KryptonPanel1.Controls.Add(Me.Label2)
        Me.KryptonPanel1.Controls.Add(Me.Label1)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(301, 365)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.btnCancel)
        Me.KryptonPanel2.Controls.Add(Me.btnOk)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(1, 296)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(299, 68)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.StateCommon.Color2 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 20
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(149, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(53, 47)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Values.Image = CType(resources.GetObject("btnCancel.Values.Image"), System.Drawing.Image)
        Me.btnCancel.Values.Text = ""
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.White
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Location = New System.Drawing.Point(90, 10)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(53, 47)
        Me.btnOk.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnOk.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnOk.TabIndex = 1
        Me.btnOk.Values.Image = CType(resources.GetObject("btnOk.Values.Image"), System.Drawing.Image)
        Me.btnOk.Values.Text = ""
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(299, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'lblChange
        '
        Me.lblChange.BackColor = System.Drawing.Color.White
        Me.lblChange.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.ForeColor = System.Drawing.Color.Black
        Me.lblChange.Location = New System.Drawing.Point(150, 250)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblChange.Size = New System.Drawing.Size(112, 25)
        Me.lblChange.TabIndex = 19
        Me.lblChange.Text = "0.00"
        Me.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(38, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label9.Size = New System.Drawing.Size(106, 25)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Change"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.BackColor = System.Drawing.Color.White
        Me.lblTotalPaid.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPaid.Location = New System.Drawing.Point(150, 216)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTotalPaid.Size = New System.Drawing.Size(112, 25)
        Me.lblTotalPaid.TabIndex = 17
        Me.lblTotalPaid.Text = "0.00"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(38, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(106, 25)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total Paid"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBillTotal
        '
        Me.lblBillTotal.BackColor = System.Drawing.Color.White
        Me.lblBillTotal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillTotal.ForeColor = System.Drawing.Color.Black
        Me.lblBillTotal.Location = New System.Drawing.Point(150, 25)
        Me.lblBillTotal.Name = "lblBillTotal"
        Me.lblBillTotal.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblBillTotal.Size = New System.Drawing.Size(112, 25)
        Me.lblBillTotal.TabIndex = 15
        Me.lblBillTotal.Text = "0.00"
        Me.lblBillTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(38, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(106, 25)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Bill Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOthers
        '
        Me.txtOthers.AllowDecimal = True
        Me.txtOthers.BackColor = System.Drawing.Color.White
        Me.txtOthers.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOthers.ForeColor = System.Drawing.Color.Black
        Me.txtOthers.Location = New System.Drawing.Point(150, 175)
        Me.txtOthers.Name = "txtOthers"
        Me.txtOthers.Size = New System.Drawing.Size(112, 23)
        Me.txtOthers.TabIndex = 13
        Me.txtOthers.Text = "0.00"
        Me.txtOthers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOthers.ThousandsSeperator = False
        Me.txtOthers.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtTransfer
        '
        Me.txtTransfer.AllowDecimal = True
        Me.txtTransfer.BackColor = System.Drawing.Color.White
        Me.txtTransfer.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransfer.ForeColor = System.Drawing.Color.Black
        Me.txtTransfer.Location = New System.Drawing.Point(150, 148)
        Me.txtTransfer.Name = "txtTransfer"
        Me.txtTransfer.Size = New System.Drawing.Size(112, 23)
        Me.txtTransfer.TabIndex = 12
        Me.txtTransfer.Text = "0.00"
        Me.txtTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTransfer.ThousandsSeperator = False
        Me.txtTransfer.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtSwipe
        '
        Me.txtSwipe.AllowDecimal = True
        Me.txtSwipe.BackColor = System.Drawing.Color.White
        Me.txtSwipe.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSwipe.ForeColor = System.Drawing.Color.Black
        Me.txtSwipe.Location = New System.Drawing.Point(150, 121)
        Me.txtSwipe.Name = "txtSwipe"
        Me.txtSwipe.Size = New System.Drawing.Size(112, 23)
        Me.txtSwipe.TabIndex = 11
        Me.txtSwipe.Text = "0.00"
        Me.txtSwipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSwipe.ThousandsSeperator = False
        Me.txtSwipe.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtEcocash
        '
        Me.txtEcocash.AllowDecimal = True
        Me.txtEcocash.BackColor = System.Drawing.Color.White
        Me.txtEcocash.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEcocash.ForeColor = System.Drawing.Color.Black
        Me.txtEcocash.Location = New System.Drawing.Point(150, 94)
        Me.txtEcocash.Name = "txtEcocash"
        Me.txtEcocash.Size = New System.Drawing.Size(112, 23)
        Me.txtEcocash.TabIndex = 10
        Me.txtEcocash.Text = "0.00"
        Me.txtEcocash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEcocash.ThousandsSeperator = False
        Me.txtEcocash.ZeroOutEmptyStringOnLostFocus = False
        '
        'txtCash
        '
        Me.txtCash.AllowDecimal = True
        Me.txtCash.BackColor = System.Drawing.Color.White
        Me.txtCash.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.ForeColor = System.Drawing.Color.Black
        Me.txtCash.Location = New System.Drawing.Point(150, 66)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Size = New System.Drawing.Size(112, 23)
        Me.txtCash.TabIndex = 9
        Me.txtCash.Text = "0.00"
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCash.ThousandsSeperator = False
        Me.txtCash.ZeroOutEmptyStringOnLostFocus = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(38, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(106, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Others"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(38, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(106, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Transfer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(106, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Swipe"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(38, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ecocash"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(38, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(106, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cash"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 363)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(300, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 363)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 364)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(301, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(301, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'frmTenderPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 365)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTenderPayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Amount Tender"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblChange As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblBillTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtOthers As Numberbox.Numberbox
    Friend WithEvents txtTransfer As Numberbox.Numberbox
    Friend WithEvents txtSwipe As Numberbox.Numberbox
    Friend WithEvents txtEcocash As Numberbox.Numberbox
    Friend WithEvents txtCash As Numberbox.Numberbox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
