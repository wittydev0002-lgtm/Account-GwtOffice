<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoansDashboard
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnIssueLoan = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Light8.My.Resources.Resources.Loan_Customer_information
        Me.PictureBox1.Location = New System.Drawing.Point(2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1160, 785)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1052, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 44)
        Me.btnClose.StateCommon.Border.Color1 = System.Drawing.Color.Red
        Me.btnClose.StateCommon.Border.Color2 = System.Drawing.Color.Red
        Me.btnClose.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnClose.StateCommon.Border.Rounding = 5
        Me.btnClose.StateCommon.Border.Width = 2
        Me.btnClose.TabIndex = 2
        Me.btnClose.Values.Text = "Close"
        '
        'btnIssueLoan
        '
        Me.btnIssueLoan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIssueLoan.Location = New System.Drawing.Point(891, 375)
        Me.btnIssueLoan.Name = "btnIssueLoan"
        Me.btnIssueLoan.Size = New System.Drawing.Size(167, 62)
        Me.btnIssueLoan.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnIssueLoan.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnIssueLoan.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnIssueLoan.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnIssueLoan.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnIssueLoan.StateCommon.Border.Rounding = 5
        Me.btnIssueLoan.StateCommon.Border.Width = 2
        Me.btnIssueLoan.TabIndex = 1
        Me.btnIssueLoan.Values.Text = "Issue Loan"
        '
        'frmLoansDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 792)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnIssueLoan)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLoansDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Loans Management Dashboard"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnClose As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnIssueLoan As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
