<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBreakInventoryPack
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDestinationCode = New System.Windows.Forms.TextBox()
        Me.txtSourceDescription = New System.Windows.Forms.TextBox()
        Me.cboDestinationDescription = New MultiColumnComboBox.MultiColumnComboBox()
        Me.txtSourceCode = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.txtDestinationCode)
        Me.GroupBox1.Controls.Add(Me.txtSourceDescription)
        Me.GroupBox1.Controls.Add(Me.cboDestinationDescription)
        Me.GroupBox1.Controls.Add(Me.txtSourceCode)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(674, 133)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(210, 85)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 20)
        Me.txtQuantity.TabIndex = 7
        Me.txtQuantity.Text = "0.00"
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Location = New System.Drawing.Point(17, 82)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.Panel5.Size = New System.Drawing.Size(187, 23)
        Me.Panel5.TabIndex = 6
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.Control
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(187, 22)
        Me.Panel6.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(187, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Number of Packages to Break"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDestinationCode
        '
        Me.txtDestinationCode.Location = New System.Drawing.Point(513, 59)
        Me.txtDestinationCode.Name = "txtDestinationCode"
        Me.txtDestinationCode.ReadOnly = True
        Me.txtDestinationCode.Size = New System.Drawing.Size(144, 20)
        Me.txtDestinationCode.TabIndex = 5
        Me.txtDestinationCode.TabStop = False
        '
        'txtSourceDescription
        '
        Me.txtSourceDescription.Location = New System.Drawing.Point(396, 31)
        Me.txtSourceDescription.Name = "txtSourceDescription"
        Me.txtSourceDescription.Size = New System.Drawing.Size(261, 20)
        Me.txtSourceDescription.TabIndex = 4
        '
        'cboDestinationDescription
        '
        Me.cboDestinationDescription.AutoComplete = False
        Me.cboDestinationDescription.AutoDropdown = False
        Me.cboDestinationDescription.BackColorEven = System.Drawing.Color.White
        Me.cboDestinationDescription.BackColorOdd = System.Drawing.Color.White
        Me.cboDestinationDescription.ColumnNames = ""
        Me.cboDestinationDescription.ColumnWidthDefault = 75
        Me.cboDestinationDescription.ColumnWidths = "250,200"
        Me.cboDestinationDescription.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboDestinationDescription.FormattingEnabled = True
        Me.cboDestinationDescription.LinkedColumnIndex = 0
        Me.cboDestinationDescription.LinkedTextBox = Me.txtDestinationCode
        Me.cboDestinationDescription.Location = New System.Drawing.Point(210, 58)
        Me.cboDestinationDescription.Name = "cboDestinationDescription"
        Me.cboDestinationDescription.Size = New System.Drawing.Size(302, 21)
        Me.cboDestinationDescription.TabIndex = 3
        '
        'txtSourceCode
        '
        Me.txtSourceCode.Location = New System.Drawing.Point(210, 31)
        Me.txtSourceCode.Name = "txtSourceCode"
        Me.txtSourceCode.Size = New System.Drawing.Size(185, 20)
        Me.txtSourceCode.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Location = New System.Drawing.Point(17, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.Panel3.Size = New System.Drawing.Size(187, 23)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(187, 22)
        Me.Panel4.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(187, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Destination Single Item Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(17, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.Panel1.Size = New System.Drawing.Size(187, 23)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(187, 22)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(187, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source Package Item Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(533, 158)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(614, 157)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBreakInventoryPack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 194)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "frmBreakInventoryPack"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Break Inventory Package"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboDestinationDescription As MultiColumnComboBox.MultiColumnComboBox
    Friend WithEvents txtSourceCode As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDestinationCode As TextBox
    Friend WithEvents txtSourceDescription As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
End Class
