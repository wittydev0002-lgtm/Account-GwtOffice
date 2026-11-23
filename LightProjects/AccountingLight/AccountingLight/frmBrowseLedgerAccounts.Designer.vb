<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowseLedgerAccounts
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowseLedgerAccounts))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.dGridBrands = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonGroupBox4 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnAdd = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtSearchString = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.optDescription = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.optCode = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.dGridBrands, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox4.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox4.Panel.SuspendLayout()
        Me.KryptonGroupBox4.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox2)
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox4)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(644, 391)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White
        Me.KryptonPanel1.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(555, 354)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCancel.StateCommon.Back.ColorAngle = 100.0!
        Me.btnCancel.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnCancel.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCancel.StateCommon.Border.Rounding = 0
        Me.btnCancel.StateCommon.Border.Width = 1
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(14, 102)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dGridBrands)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(616, 246)
        Me.KryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox2.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox2.TabIndex = 2
        Me.KryptonGroupBox2.Text = "Brand drugs ..."
        Me.KryptonGroupBox2.Values.Heading = "Brand drugs ..."
        '
        'dGridBrands
        '
        Me.dGridBrands.AllowUserToAddRows = False
        Me.dGridBrands.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dGridBrands.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridBrands.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dGridBrands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridBrands.Location = New System.Drawing.Point(0, 0)
        Me.dGridBrands.Name = "dGridBrands"
        Me.dGridBrands.ReadOnly = True
        Me.dGridBrands.RowHeadersWidth = 25
        Me.dGridBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridBrands.Size = New System.Drawing.Size(614, 223)
        Me.dGridBrands.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridBrands.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridBrands.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridBrands.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dGridBrands.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGridBrands.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridBrands.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridBrands.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridBrands.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dGridBrands.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.White
        Me.dGridBrands.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridBrands.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridBrands.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridBrands.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Account Number"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 130
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Account Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'KryptonGroupBox4
        '
        Me.KryptonGroupBox4.Location = New System.Drawing.Point(14, 12)
        Me.KryptonGroupBox4.Name = "KryptonGroupBox4"
        '
        'KryptonGroupBox4.Panel
        '
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.btnAdd)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.txtSearchString)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.optDescription)
        Me.KryptonGroupBox4.Panel.Controls.Add(Me.optCode)
        Me.KryptonGroupBox4.Size = New System.Drawing.Size(616, 73)
        Me.KryptonGroupBox4.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.KryptonGroupBox4.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroupBox4.StateCommon.Border.Rounding = 0
        Me.KryptonGroupBox4.TabIndex = 1
        Me.KryptonGroupBox4.Text = "Search parameters"
        Me.KryptonGroupBox4.Values.Heading = "Search parameters"
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.Location = New System.Drawing.Point(549, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnAdd.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnAdd.StateCommon.Back.ColorAngle = 100.0!
        Me.btnAdd.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.btnAdd.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnAdd.StateCommon.Border.Rounding = 0
        Me.btnAdd.StateCommon.Border.Width = 1
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Values.Image = CType(resources.GetObject("btnAdd.Values.Image"), System.Drawing.Image)
        Me.btnAdd.Values.Text = "&Add"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel2.Location = New System.Drawing.Point(182, 12)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(79, 22)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel2.TabIndex = 4
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(0, 21)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(79, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(79, 22)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Search for"
        '
        'txtSearchString
        '
        Me.txtSearchString.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtSearchString.Border.Class = "TextBoxBorder"
        Me.txtSearchString.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSearchString.DisabledBackColor = System.Drawing.Color.White
        Me.txtSearchString.ForeColor = System.Drawing.Color.Black
        Me.txtSearchString.Location = New System.Drawing.Point(262, 14)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.PreventEnterBeep = True
        Me.txtSearchString.Size = New System.Drawing.Size(281, 20)
        Me.txtSearchString.TabIndex = 2
        '
        'optDescription
        '
        Me.optDescription.Checked = True
        Me.optDescription.Location = New System.Drawing.Point(93, 16)
        Me.optDescription.Name = "optDescription"
        Me.optDescription.Size = New System.Drawing.Size(55, 20)
        Me.optDescription.TabIndex = 1
        Me.optDescription.Values.Text = "Name"
        '
        'optCode
        '
        Me.optCode.Location = New System.Drawing.Point(15, 16)
        Me.optCode.Name = "optCode"
        Me.optCode.Size = New System.Drawing.Size(67, 20)
        Me.optCode.TabIndex = 0
        Me.optCode.Values.Text = "Account"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(644, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'frmBrowseLedgerAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 391)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBrowseLedgerAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ledger Accounts"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.dGridBrands, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox4.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox4.Panel.ResumeLayout(False)
        Me.KryptonGroupBox4.Panel.PerformLayout()
        CType(Me.KryptonGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox4.ResumeLayout(False)
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
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox4 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btnAdd As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtSearchString As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents optDescription As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents optCode As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents dGridBrands As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
