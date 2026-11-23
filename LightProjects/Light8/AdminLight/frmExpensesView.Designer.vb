<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpensesView
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.pnlDetails = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCloseTip = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.dGridDetails = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.lblTotal = New System.Windows.Forms.Label()
        CType(Me.pnlDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        CType(Me.dGridDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'pnlDetails
        '
        Me.pnlDetails.Controls.Add(Me.lblTotal)
        Me.pnlDetails.Controls.Add(Me.KryptonPanel2)
        Me.pnlDetails.Controls.Add(Me.btnCloseTip)
        Me.pnlDetails.Controls.Add(Me.KryptonBorderEdge11)
        Me.pnlDetails.Controls.Add(Me.dGridDetails)
        Me.pnlDetails.Controls.Add(Me.KryptonBorderEdge9)
        Me.pnlDetails.Controls.Add(Me.KryptonBorderEdge8)
        Me.pnlDetails.Controls.Add(Me.KryptonBorderEdge7)
        Me.pnlDetails.Controls.Add(Me.KryptonBorderEdge6)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetails.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(466, 415)
        Me.pnlDetails.StateCommon.Color1 = System.Drawing.SystemColors.Info
        Me.pnlDetails.TabIndex = 3
        Me.pnlDetails.Visible = False
        '
        'btnCloseTip
        '
        Me.btnCloseTip.Location = New System.Drawing.Point(376, 378)
        Me.btnCloseTip.Name = "btnCloseTip"
        Me.btnCloseTip.Size = New System.Drawing.Size(75, 25)
        Me.btnCloseTip.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCloseTip.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCloseTip.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCloseTip.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCloseTip.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCloseTip.StateCommon.Border.Rounding = 0
        Me.btnCloseTip.TabIndex = 6
        Me.btnCloseTip.Values.Text = "Close"
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(1, 367)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(464, 1)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'dGridDetails
        '
        Me.dGridDetails.AllowUserToAddRows = False
        Me.dGridDetails.AllowUserToDeleteRows = False
        Me.dGridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGridDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12})
        Me.dGridDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.dGridDetails.Location = New System.Drawing.Point(1, 1)
        Me.dGridDetails.Name = "dGridDetails"
        Me.dGridDetails.ReadOnly = True
        Me.dGridDetails.RowHeadersVisible = False
        Me.dGridDetails.Size = New System.Drawing.Size(464, 366)
        Me.dGridDetails.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridDetails.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridDetails.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridDetails.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dGridDetails.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGridDetails.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridDetails.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridDetails.StateCommon.HeaderColumn.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.dGridDetails.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridDetails.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridDetails.TabIndex = 4
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column10.HeaderText = "Description"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column11.HeaderText = "Type"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 63
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column12.HeaderText = "Amount"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 80
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(465, 1)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(1, 413)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(0, 1)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(1, 413)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(0, 414)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(466, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(466, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(26, 382)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(99, 21)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 151
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.BackColor = System.Drawing.Color.White
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(99, 20)
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Total Expenses"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(0, 20)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(99, 1)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Firebrick
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(125, 381)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(121, 21)
        Me.lblTotal.TabIndex = 152
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmExpensesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 415)
        Me.Controls.Add(Me.pnlDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExpensesView"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.StateCommon.Border.Rounding = 0
        Me.StateCommon.Border.Width = 2
        Me.StateCommon.Header.Back.Color1 = System.Drawing.Color.White
        Me.StateCommon.Header.Back.Color2 = System.Drawing.Color.White
        Me.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Text = "Expenses View"
        CType(Me.pnlDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        CType(Me.dGridDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents pnlDetails As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCloseTip As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents dGridDetails As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
End Class
