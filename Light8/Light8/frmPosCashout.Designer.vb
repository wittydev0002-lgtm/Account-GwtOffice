<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPosCashout
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtTendered = New Numberbox.Numberbox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblTotalDue = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCashout = New System.Windows.Forms.Button()
        Me.chkPrintFiscal = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel1.Size = New System.Drawing.Size(524, 517)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.chkPrintFiscal)
        Me.Panel2.Controls.Add(Me.txtTendered)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.txtChange)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.btnCashout)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(520, 513)
        Me.Panel2.TabIndex = 0
        '
        'txtTendered
        '
        Me.txtTendered.AllowDecimal = True
        Me.txtTendered.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTendered.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTendered.Location = New System.Drawing.Point(36, 171)
        Me.txtTendered.Name = "txtTendered"
        Me.txtTendered.Size = New System.Drawing.Size(449, 56)
        Me.txtTendered.TabIndex = 8
        Me.txtTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTendered.ThousandsSeperator = False
        Me.txtTendered.ZeroOutEmptyStringOnLostFocus = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(330, 409)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(154, 83)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Location = New System.Drawing.Point(36, 248)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Panel5.Size = New System.Drawing.Size(448, 49)
        Me.Panel5.TabIndex = 30
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.Control
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(448, 47)
        Me.Panel6.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Label3.Size = New System.Drawing.Size(448, 47)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Change"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChange
        '
        Me.txtChange.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChange.Enabled = False
        Me.txtChange.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChange.ForeColor = System.Drawing.Color.Teal
        Me.txtChange.Location = New System.Drawing.Point(36, 314)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(449, 46)
        Me.txtChange.TabIndex = 29
        Me.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Location = New System.Drawing.Point(36, 116)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Panel3.Size = New System.Drawing.Size(448, 49)
        Me.Panel3.TabIndex = 28
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(448, 47)
        Me.Panel4.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Label2.Size = New System.Drawing.Size(448, 47)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Payment"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Location = New System.Drawing.Point(36, 28)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Panel7.Size = New System.Drawing.Size(449, 60)
        Me.Panel7.TabIndex = 26
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.Controls.Add(Me.lblTotalDue)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(449, 58)
        Me.Panel8.TabIndex = 0
        '
        'lblTotalDue
        '
        Me.lblTotalDue.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalDue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalDue.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDue.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDue.Location = New System.Drawing.Point(142, 0)
        Me.lblTotalDue.Name = "lblTotalDue"
        Me.lblTotalDue.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.lblTotalDue.Size = New System.Drawing.Size(307, 58)
        Me.lblTotalDue.TabIndex = 11
        Me.lblTotalDue.Text = "0.00"
        Me.lblTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label1.Size = New System.Drawing.Size(142, 58)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCashout
        '
        Me.btnCashout.BackColor = System.Drawing.Color.SeaGreen
        Me.btnCashout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCashout.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashout.ForeColor = System.Drawing.Color.White
        Me.btnCashout.Location = New System.Drawing.Point(36, 409)
        Me.btnCashout.Name = "btnCashout"
        Me.btnCashout.Size = New System.Drawing.Size(288, 83)
        Me.btnCashout.TabIndex = 9
        Me.btnCashout.Text = "Finish"
        Me.btnCashout.UseVisualStyleBackColor = False
        '
        'chkPrintFiscal
        '
        Me.chkPrintFiscal.AutoSize = True
        Me.chkPrintFiscal.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintFiscal.Location = New System.Drawing.Point(36, 373)
        Me.chkPrintFiscal.Name = "chkPrintFiscal"
        Me.chkPrintFiscal.Size = New System.Drawing.Size(246, 26)
        Me.chkPrintFiscal.TabIndex = 31
        Me.chkPrintFiscal.Text = "Print as Fiscal Receipt?"
        Me.chkPrintFiscal.UseVisualStyleBackColor = True
        '
        'frmPosCashout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 517)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPosCashout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cash-Out"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtChange As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblTotalDue As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCashout As Button
    Friend WithEvents txtTendered As Numberbox.Numberbox
    Friend WithEvents chkPrintFiscal As CheckBox
End Class
