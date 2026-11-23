<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQrCodes
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSelectPrinter = New System.Windows.Forms.Button()
        Me.cmbPrinters = New System.Windows.Forms.ComboBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLabel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.picQRPreview = New System.Windows.Forms.PictureBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        CType(Me.picQRPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPrint.Location = New System.Drawing.Point(201, 95)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(99, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print QR Code"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnSelectPrinter
        '
        Me.btnSelectPrinter.Location = New System.Drawing.Point(306, 95)
        Me.btnSelectPrinter.Name = "btnSelectPrinter"
        Me.btnSelectPrinter.Size = New System.Drawing.Size(136, 23)
        Me.btnSelectPrinter.TabIndex = 1
        Me.btnSelectPrinter.Text = "Refresh Printers"
        Me.btnSelectPrinter.UseVisualStyleBackColor = True
        '
        'cmbPrinters
        '
        Me.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinters.FormattingEnabled = True
        Me.cmbPrinters.Location = New System.Drawing.Point(54, 48)
        Me.cmbPrinters.Name = "cmbPrinters"
        Me.cmbPrinters.Size = New System.Drawing.Size(213, 21)
        Me.cmbPrinters.TabIndex = 2
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(317, 50)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(211, 20)
        Me.txtData.TabIndex = 3
        Me.txtData.Text = "https://www.gpzim.com"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(314, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "QR Code Data:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select Printer:"
        '
        'txtLabel
        '
        Me.txtLabel.Location = New System.Drawing.Point(47, 101)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(100, 20)
        Me.txtLabel.TabIndex = 6
        Me.txtLabel.Text = "Scan Me"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Label Text:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(54, 174)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "Status"
        '
        'picQRPreview
        '
        Me.picQRPreview.BackColor = System.Drawing.Color.White
        Me.picQRPreview.Location = New System.Drawing.Point(306, 155)
        Me.picQRPreview.Name = "picQRPreview"
        Me.picQRPreview.Size = New System.Drawing.Size(250, 250)
        Me.picQRPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQRPreview.TabIndex = 9
        Me.picQRPreview.TabStop = False
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(47, 211)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(100, 23)
        Me.btnGenerate.TabIndex = 10
        Me.btnGenerate.Text = "Preview QR Code"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'frmQrCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 443)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.picQRPreview)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.cmbPrinters)
        Me.Controls.Add(Me.btnSelectPrinter)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "frmQrCodes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmQrCodes"
        CType(Me.picQRPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents btnSelectPrinter As Button
    Friend WithEvents cmbPrinters As ComboBox
    Friend WithEvents txtData As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLabel As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents picQRPreview As PictureBox
    Friend WithEvents btnGenerate As Button
End Class
