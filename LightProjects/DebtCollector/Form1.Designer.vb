<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.panelPrint = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblFileAccountNumber = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPotfolio = New System.Windows.Forms.Label()
        Me.txtReceivedBy = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.txtReceivedFrom = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtDate = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dGridPrint = New AdvancedDataGridViewControl.AdvancedDatagridview()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.panelPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPrint.SuspendLayout()
        CType(Me.dGridPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelPrint
        '
        Me.panelPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.panelPrint.Controls.Add(Me.lblFileAccountNumber)
        Me.panelPrint.Controls.Add(Me.Label5)
        Me.panelPrint.Controls.Add(Me.lblPotfolio)
        Me.panelPrint.Controls.Add(Me.txtReceivedBy)
        Me.panelPrint.Controls.Add(Me.Label3)
        Me.panelPrint.Controls.Add(Me.lblReceiptNo)
        Me.panelPrint.Controls.Add(Me.txtReceivedFrom)
        Me.panelPrint.Controls.Add(Me.txtDate)
        Me.panelPrint.Controls.Add(Me.Label2)
        Me.panelPrint.Controls.Add(Me.Label1)
        Me.panelPrint.Controls.Add(Me.dGridPrint)
        Me.panelPrint.Controls.Add(Me.PictureBox1)
        Me.panelPrint.ForeColor = System.Drawing.Color.Black
        Me.panelPrint.Location = New System.Drawing.Point(22, 19)
        Me.panelPrint.Name = "panelPrint"
        Me.panelPrint.Size = New System.Drawing.Size(662, 506)
        Me.panelPrint.StateCommon.Color1 = System.Drawing.Color.White
        Me.panelPrint.StateCommon.Color2 = System.Drawing.Color.White
        Me.panelPrint.TabIndex = 5
        '
        'lblFileAccountNumber
        '
        Me.lblFileAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblFileAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileAccountNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblFileAccountNumber.Location = New System.Drawing.Point(14, 186)
        Me.lblFileAccountNumber.Name = "lblFileAccountNumber"
        Me.lblFileAccountNumber.Size = New System.Drawing.Size(626, 20)
        Me.lblFileAccountNumber.TabIndex = 29
        Me.lblFileAccountNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(444, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "TRUST ACCOUNT"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPotfolio
        '
        Me.lblPotfolio.BackColor = System.Drawing.Color.White
        Me.lblPotfolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPotfolio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPotfolio.ForeColor = System.Drawing.Color.Black
        Me.lblPotfolio.Location = New System.Drawing.Point(14, 163)
        Me.lblPotfolio.Name = "lblPotfolio"
        Me.lblPotfolio.Size = New System.Drawing.Size(427, 20)
        Me.lblPotfolio.TabIndex = 27
        Me.lblPotfolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.BackColor = System.Drawing.Color.White
        Me.txtReceivedBy.ForeColor = System.Drawing.Color.Black
        Me.txtReceivedBy.Location = New System.Drawing.Point(111, 464)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(365, 20)
        Me.txtReceivedBy.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 464)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Received by "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.BackColor = System.Drawing.Color.White
        Me.lblReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceiptNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptNo.ForeColor = System.Drawing.Color.Black
        Me.lblReceiptNo.Location = New System.Drawing.Point(554, 211)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(86, 20)
        Me.lblReceiptNo.TabIndex = 24
        Me.lblReceiptNo.Text = "1"
        Me.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReceivedFrom
        '
        Me.txtReceivedFrom.BackColor = System.Drawing.Color.White
        Me.txtReceivedFrom.ForeColor = System.Drawing.Color.Black
        Me.txtReceivedFrom.Location = New System.Drawing.Point(187, 211)
        Me.txtReceivedFrom.Name = "txtReceivedFrom"
        Me.txtReceivedFrom.Size = New System.Drawing.Size(365, 20)
        Me.txtReceivedFrom.TabIndex = 23
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.ForeColor = System.Drawing.Color.Black
        Me.txtDate.Location = New System.Drawing.Point(50, 211)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(86, 20)
        Me.txtDate.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(137, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "From "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dGridPrint
        '
        Me.dGridPrint.AllowUserToAddRows = False
        Me.dGridPrint.AllowUserToDeleteRows = False
        Me.dGridPrint.AllowUserToResizeColumns = False
        Me.dGridPrint.AllowUserToResizeRows = False
        Me.dGridPrint.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn1})
        Me.dGridPrint.Location = New System.Drawing.Point(14, 233)
        Me.dGridPrint.Name = "dGridPrint"
        Me.dGridPrint.ReadOnly = True
        Me.dGridPrint.RowHeadersVisible = False
        Me.dGridPrint.RowHeadersWidth = 25
        Me.dGridPrint.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridPrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridPrint.Size = New System.Drawing.Size(629, 219)
        Me.dGridPrint.StateCommon.Background.Color1 = System.Drawing.Color.Transparent
        Me.dGridPrint.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dGridPrint.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPrint.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White
        Me.dGridPrint.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White
        Me.dGridPrint.StateCommon.HeaderColumn.Back.ColorAngle = 100.0!
        Me.dGridPrint.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPrint.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridPrint.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.dGridPrint.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.White
        Me.dGridPrint.StateCommon.HeaderRow.Back.ColorAngle = 100.0!
        Me.dGridPrint.StateCommon.HeaderRow.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.dGridPrint.TabIndex = 16
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewComboBoxColumn1.HeaderText = "Description"
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 260
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewComboBoxColumn1.Width = 260
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Comment"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 300
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 260
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.ForeColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(17, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(621, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 568)
        Me.Controls.Add(Me.panelPrint)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.panelPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPrint.ResumeLayout(False)
        Me.panelPrint.PerformLayout()
        CType(Me.dGridPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelPrint As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblFileAccountNumber As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPotfolio As System.Windows.Forms.Label
    Friend WithEvents txtReceivedBy As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
    Friend WithEvents txtReceivedFrom As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtDate As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dGridPrint As AdvancedDataGridViewControl.AdvancedDatagridview
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
