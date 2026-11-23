<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceCurrency
    Inherits System.Windows.Forms.Form

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
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.btnSwipeNostro = New System.Windows.Forms.Button()
        Me.btnPola = New System.Windows.Forms.Button()
        Me.btnRand = New System.Windows.Forms.Button()
        Me.btnSwipeLocal = New System.Windows.Forms.Button()
        Me.btnEcocash = New System.Windows.Forms.Button()
        Me.btnUsdCash = New System.Windows.Forms.Button()
        Me.btnLocalCash = New System.Windows.Forms.Button()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.Panel9)
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnTransfer)
        Me.KryptonPanel1.Controls.Add(Me.btnSwipeNostro)
        Me.KryptonPanel1.Controls.Add(Me.btnPola)
        Me.KryptonPanel1.Controls.Add(Me.btnRand)
        Me.KryptonPanel1.Controls.Add(Me.btnSwipeLocal)
        Me.KryptonPanel1.Controls.Add(Me.btnEcocash)
        Me.KryptonPanel1.Controls.Add(Me.btnUsdCash)
        Me.KryptonPanel1.Controls.Add(Me.btnLocalCash)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 1)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(655, 207)
        Me.KryptonPanel1.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel9.Controls.Add(Me.Panel11)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Location = New System.Drawing.Point(493, 27)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel9.Size = New System.Drawing.Size(139, 73)
        Me.Panel9.TabIndex = 42
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(1, 1)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.Panel11.Size = New System.Drawing.Size(137, 34)
        Me.Panel11.TabIndex = 1
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.SystemColors.Control
        Me.Panel12.Controls.Add(Me.Label4)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(137, 33)
        Me.Panel12.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(137, 33)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Exchange Rate"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.Control
        Me.Panel10.Controls.Add(Me.lblExchangeRate)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(1, 35)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(137, 37)
        Me.Panel10.TabIndex = 0
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblExchangeRate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExchangeRate.Location = New System.Drawing.Point(0, 0)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.lblExchangeRate.Size = New System.Drawing.Size(137, 37)
        Me.lblExchangeRate.TabIndex = 1
        Me.lblExchangeRate.Text = "0.00"
        Me.lblExchangeRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(492, 106)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(139, 73)
        Me.btnCancel.TabIndex = 41
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnTransfer
        '
        Me.btnTransfer.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransfer.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer.ForeColor = System.Drawing.Color.White
        Me.btnTransfer.Location = New System.Drawing.Point(377, 106)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(110, 73)
        Me.btnTransfer.TabIndex = 39
        Me.btnTransfer.UseVisualStyleBackColor = False
        '
        'btnSwipeNostro
        '
        Me.btnSwipeNostro.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnSwipeNostro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSwipeNostro.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSwipeNostro.ForeColor = System.Drawing.Color.White
        Me.btnSwipeNostro.Location = New System.Drawing.Point(261, 106)
        Me.btnSwipeNostro.Name = "btnSwipeNostro"
        Me.btnSwipeNostro.Size = New System.Drawing.Size(110, 73)
        Me.btnSwipeNostro.TabIndex = 38
        Me.btnSwipeNostro.UseVisualStyleBackColor = False
        '
        'btnPola
        '
        Me.btnPola.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnPola.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPola.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPola.ForeColor = System.Drawing.Color.White
        Me.btnPola.Location = New System.Drawing.Point(377, 27)
        Me.btnPola.Name = "btnPola"
        Me.btnPola.Size = New System.Drawing.Size(110, 73)
        Me.btnPola.TabIndex = 37
        Me.btnPola.UseVisualStyleBackColor = False
        '
        'btnRand
        '
        Me.btnRand.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnRand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRand.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRand.ForeColor = System.Drawing.Color.White
        Me.btnRand.Location = New System.Drawing.Point(261, 27)
        Me.btnRand.Name = "btnRand"
        Me.btnRand.Size = New System.Drawing.Size(110, 73)
        Me.btnRand.TabIndex = 36
        Me.btnRand.UseVisualStyleBackColor = False
        '
        'btnSwipeLocal
        '
        Me.btnSwipeLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnSwipeLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSwipeLocal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSwipeLocal.ForeColor = System.Drawing.Color.White
        Me.btnSwipeLocal.Location = New System.Drawing.Point(139, 106)
        Me.btnSwipeLocal.Name = "btnSwipeLocal"
        Me.btnSwipeLocal.Size = New System.Drawing.Size(110, 73)
        Me.btnSwipeLocal.TabIndex = 35
        Me.btnSwipeLocal.UseVisualStyleBackColor = False
        '
        'btnEcocash
        '
        Me.btnEcocash.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnEcocash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEcocash.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEcocash.ForeColor = System.Drawing.Color.White
        Me.btnEcocash.Location = New System.Drawing.Point(23, 106)
        Me.btnEcocash.Name = "btnEcocash"
        Me.btnEcocash.Size = New System.Drawing.Size(110, 73)
        Me.btnEcocash.TabIndex = 34
        Me.btnEcocash.UseVisualStyleBackColor = False
        '
        'btnUsdCash
        '
        Me.btnUsdCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnUsdCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsdCash.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsdCash.ForeColor = System.Drawing.Color.White
        Me.btnUsdCash.Location = New System.Drawing.Point(139, 27)
        Me.btnUsdCash.Name = "btnUsdCash"
        Me.btnUsdCash.Size = New System.Drawing.Size(110, 73)
        Me.btnUsdCash.TabIndex = 33
        Me.btnUsdCash.UseVisualStyleBackColor = False
        '
        'btnLocalCash
        '
        Me.btnLocalCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnLocalCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLocalCash.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocalCash.ForeColor = System.Drawing.Color.White
        Me.btnLocalCash.Location = New System.Drawing.Point(23, 27)
        Me.btnLocalCash.Name = "btnLocalCash"
        Me.btnLocalCash.Size = New System.Drawing.Size(110, 73)
        Me.btnLocalCash.TabIndex = 32
        Me.btnLocalCash.UseVisualStyleBackColor = False
        '
        'frmInvoiceCurrency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(659, 211)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmInvoiceCurrency"
        Me.Padding = New System.Windows.Forms.Padding(1, 1, 3, 3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoicing Currency"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lblExchangeRate As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnTransfer As Button
    Friend WithEvents btnSwipeNostro As Button
    Friend WithEvents btnPola As Button
    Friend WithEvents btnRand As Button
    Friend WithEvents btnSwipeLocal As Button
    Friend WithEvents btnEcocash As Button
    Friend WithEvents btnUsdCash As Button
    Friend WithEvents btnLocalCash As Button
End Class
