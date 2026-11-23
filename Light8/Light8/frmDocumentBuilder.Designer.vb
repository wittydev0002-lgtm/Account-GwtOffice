<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentBuilder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentBuilder))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.rtbDoc = New RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.KryptonBorderEdge11 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge10 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge9 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge12 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge8 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.lblFileName = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonBorderEdge7 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbrNew = New System.Windows.Forms.ToolStripButton()
        Me.tbrOpen = New System.Windows.Forms.ToolStripButton()
        Me.tbrSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnInsertField = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrFont = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrLeft = New System.Windows.Forms.ToolStripButton()
        Me.tbrCenter = New System.Windows.Forms.ToolStripButton()
        Me.tbrRight = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrBold = New System.Windows.Forms.ToolStripButton()
        Me.tbrItalic = New System.Windows.Forms.ToolStripButton()
        Me.tbrUnderline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbrFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCreateDocumentFields = New System.Windows.Forms.ToolStripButton()
        Me.btnViewFields = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindAndReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.InsertImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectFontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FontColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItalicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.PageColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParagraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndent20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAlign = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BulletsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBulletsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveBulletsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonBorderEdge6 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge5 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge8)
        Me.KryptonPanel.Controls.Add(Me.Bar1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge7)
        Me.KryptonPanel.Controls.Add(Me.ToolStrip1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.MenuStrip1)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge6)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge5)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(801, 553)
        Me.KryptonPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.KryptonPanel.StateCommon.ColorAngle = 100.0!
        Me.KryptonPanel.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding2
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.rtbDoc)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge11)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge10)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge9)
        Me.KryptonPanel1.Controls.Add(Me.KryptonBorderEdge12)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(1, 52)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(12)
        Me.KryptonPanel1.Size = New System.Drawing.Size(799, 479)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.KryptonPanel1.TabIndex = 33
        '
        'rtbDoc
        '
        Me.rtbDoc.BackColor = System.Drawing.Color.White
        Me.rtbDoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbDoc.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbDoc.ForeColor = System.Drawing.Color.Black
        Me.rtbDoc.Location = New System.Drawing.Point(13, 13)
        Me.rtbDoc.Name = "rtbDoc"
        Me.rtbDoc.Size = New System.Drawing.Size(773, 453)
        Me.rtbDoc.TabIndex = 41
        Me.rtbDoc.Text = ""
        '
        'KryptonBorderEdge11
        '
        Me.KryptonBorderEdge11.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge11.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge11.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge11.Location = New System.Drawing.Point(786, 13)
        Me.KryptonBorderEdge11.Name = "KryptonBorderEdge11"
        Me.KryptonBorderEdge11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge11.Size = New System.Drawing.Size(1, 453)
        Me.KryptonBorderEdge11.Text = "KryptonBorderEdge11"
        '
        'KryptonBorderEdge10
        '
        Me.KryptonBorderEdge10.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge10.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge10.Location = New System.Drawing.Point(12, 13)
        Me.KryptonBorderEdge10.Name = "KryptonBorderEdge10"
        Me.KryptonBorderEdge10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge10.Size = New System.Drawing.Size(1, 453)
        Me.KryptonBorderEdge10.Text = "KryptonBorderEdge10"
        '
        'KryptonBorderEdge9
        '
        Me.KryptonBorderEdge9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge9.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge9.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge9.Location = New System.Drawing.Point(12, 12)
        Me.KryptonBorderEdge9.Name = "KryptonBorderEdge9"
        Me.KryptonBorderEdge9.Size = New System.Drawing.Size(775, 1)
        Me.KryptonBorderEdge9.Text = "KryptonBorderEdge9"
        '
        'KryptonBorderEdge12
        '
        Me.KryptonBorderEdge12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge12.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge12.Location = New System.Drawing.Point(12, 466)
        Me.KryptonBorderEdge12.Name = "KryptonBorderEdge12"
        Me.KryptonBorderEdge12.Size = New System.Drawing.Size(775, 1)
        Me.KryptonBorderEdge12.Text = "KryptonBorderEdge12"
        '
        'KryptonBorderEdge8
        '
        Me.KryptonBorderEdge8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge8.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge8.Location = New System.Drawing.Point(1, 531)
        Me.KryptonBorderEdge8.Name = "KryptonBorderEdge8"
        Me.KryptonBorderEdge8.Size = New System.Drawing.Size(799, 1)
        Me.KryptonBorderEdge8.Text = "KryptonBorderEdge8"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblFileName})
        Me.Bar1.Location = New System.Drawing.Point(1, 532)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingLeft = 12
        Me.Bar1.PaddingRight = 12
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(799, 19)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 31
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'lblFileName
        '
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Text = "Active File Name"
        '
        'KryptonBorderEdge7
        '
        Me.KryptonBorderEdge7.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge7.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge7.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge7.Location = New System.Drawing.Point(1, 51)
        Me.KryptonBorderEdge7.Name = "KryptonBorderEdge7"
        Me.KryptonBorderEdge7.Size = New System.Drawing.Size(799, 1)
        Me.KryptonBorderEdge7.Text = "KryptonBorderEdge7"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.ForeColor = System.Drawing.Color.Black
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbrNew, Me.tbrOpen, Me.tbrSave, Me.ToolStripSeparator1, Me.btnInsertField, Me.ToolStripSeparator8, Me.btnPrint, Me.ToolStripSeparator7, Me.tbrFont, Me.ToolStripSeparator4, Me.tbrLeft, Me.tbrCenter, Me.tbrRight, Me.ToolStripSeparator2, Me.tbrBold, Me.tbrItalic, Me.tbrUnderline, Me.ToolStripSeparator3, Me.tbrFind, Me.ToolStripSeparator9, Me.btnCreateDocumentFields, Me.btnViewFields, Me.ToolStripSeparator11})
        Me.ToolStrip1.Location = New System.Drawing.Point(1, 26)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(799, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbrNew
        '
        Me.tbrNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrNew.Image = CType(resources.GetObject("tbrNew.Image"), System.Drawing.Image)
        Me.tbrNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrNew.Name = "tbrNew"
        Me.tbrNew.Size = New System.Drawing.Size(23, 22)
        Me.tbrNew.Text = "New"
        '
        'tbrOpen
        '
        Me.tbrOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrOpen.Image = CType(resources.GetObject("tbrOpen.Image"), System.Drawing.Image)
        Me.tbrOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrOpen.Name = "tbrOpen"
        Me.tbrOpen.Size = New System.Drawing.Size(23, 22)
        Me.tbrOpen.Text = "Open"
        '
        'tbrSave
        '
        Me.tbrSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrSave.Image = CType(resources.GetObject("tbrSave.Image"), System.Drawing.Image)
        Me.tbrSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrSave.Name = "tbrSave"
        Me.tbrSave.Size = New System.Drawing.Size(23, 22)
        Me.tbrSave.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnInsertField
        '
        Me.btnInsertField.Image = CType(resources.GetObject("btnInsertField.Image"), System.Drawing.Image)
        Me.btnInsertField.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertField.Name = "btnInsertField"
        Me.btnInsertField.Size = New System.Drawing.Size(84, 22)
        Me.btnInsertField.Text = "Insert Field"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'btnPrint
        '
        Me.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(23, 22)
        Me.btnPrint.Text = "Print"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tbrFont
        '
        Me.tbrFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrFont.Image = CType(resources.GetObject("tbrFont.Image"), System.Drawing.Image)
        Me.tbrFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrFont.Name = "tbrFont"
        Me.tbrFont.Size = New System.Drawing.Size(23, 22)
        Me.tbrFont.Text = "Font"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tbrLeft
        '
        Me.tbrLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrLeft.Image = CType(resources.GetObject("tbrLeft.Image"), System.Drawing.Image)
        Me.tbrLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrLeft.Name = "tbrLeft"
        Me.tbrLeft.Size = New System.Drawing.Size(23, 22)
        Me.tbrLeft.Text = "Left"
        '
        'tbrCenter
        '
        Me.tbrCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrCenter.Image = CType(resources.GetObject("tbrCenter.Image"), System.Drawing.Image)
        Me.tbrCenter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrCenter.Name = "tbrCenter"
        Me.tbrCenter.Size = New System.Drawing.Size(23, 22)
        Me.tbrCenter.Text = "Center"
        '
        'tbrRight
        '
        Me.tbrRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrRight.Image = CType(resources.GetObject("tbrRight.Image"), System.Drawing.Image)
        Me.tbrRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrRight.Name = "tbrRight"
        Me.tbrRight.Size = New System.Drawing.Size(23, 22)
        Me.tbrRight.Text = "Right"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tbrBold
        '
        Me.tbrBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrBold.Image = CType(resources.GetObject("tbrBold.Image"), System.Drawing.Image)
        Me.tbrBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrBold.Name = "tbrBold"
        Me.tbrBold.Size = New System.Drawing.Size(23, 22)
        Me.tbrBold.Text = "Bold"
        '
        'tbrItalic
        '
        Me.tbrItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrItalic.Image = CType(resources.GetObject("tbrItalic.Image"), System.Drawing.Image)
        Me.tbrItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrItalic.Name = "tbrItalic"
        Me.tbrItalic.Size = New System.Drawing.Size(23, 22)
        Me.tbrItalic.Text = "Italic"
        '
        'tbrUnderline
        '
        Me.tbrUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrUnderline.Image = CType(resources.GetObject("tbrUnderline.Image"), System.Drawing.Image)
        Me.tbrUnderline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrUnderline.Name = "tbrUnderline"
        Me.tbrUnderline.Size = New System.Drawing.Size(23, 22)
        Me.tbrUnderline.Text = "Underline"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbrFind
        '
        Me.tbrFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbrFind.Image = CType(resources.GetObject("tbrFind.Image"), System.Drawing.Image)
        Me.tbrFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbrFind.Name = "tbrFind"
        Me.tbrFind.Size = New System.Drawing.Size(23, 22)
        Me.tbrFind.Text = "Find"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'btnCreateDocumentFields
        '
        Me.btnCreateDocumentFields.Image = CType(resources.GetObject("btnCreateDocumentFields.Image"), System.Drawing.Image)
        Me.btnCreateDocumentFields.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCreateDocumentFields.Name = "btnCreateDocumentFields"
        Me.btnCreateDocumentFields.Size = New System.Drawing.Size(90, 22)
        Me.btnCreateDocumentFields.Text = "Setup Fields"
        '
        'btnViewFields
        '
        Me.btnViewFields.Image = CType(resources.GetObject("btnViewFields.Image"), System.Drawing.Image)
        Me.btnViewFields.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewFields.Name = "btnViewFields"
        Me.btnViewFields.Size = New System.Drawing.Size(85, 22)
        Me.btnViewFields.Text = "View Fields"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(1, 25)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(799, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.FontToolStripMenuItem, Me.ParagraphToolStripMenuItem, Me.BulletsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(1, 1)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(799, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripMenuItem1, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripMenuItem2, Me.mnuPageSetup, Me.PreviewToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ToolStripMenuItem3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 6)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.OpenToolStripMenuItem.Text = "&Open..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SaveToolStripMenuItem.Text = "&Save..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(139, 6)
        '
        'mnuPageSetup
        '
        Me.mnuPageSetup.Name = "mnuPageSetup"
        Me.mnuPageSetup.Size = New System.Drawing.Size(142, 22)
        Me.mnuPageSetup.Text = "Page Setup..."
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PreviewToolStripMenuItem.Text = "Pre&view..."
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PrintToolStripMenuItem.Text = "&Print..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(139, 6)
        Me.ToolStripMenuItem3.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        Me.ExitToolStripMenuItem.Visible = False
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUndo, Me.mnuRedo, Me.ToolStripSeparator6, Me.FindToolStripMenuItem, Me.FindAndReplaceToolStripMenuItem, Me.ToolStripMenuItem4, Me.SelectAllToolStripMenuItem, Me.ToolStripMenuItem5, Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem8, Me.InsertImageToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'mnuUndo
        '
        Me.mnuUndo.Image = CType(resources.GetObject("mnuUndo.Image"), System.Drawing.Image)
        Me.mnuUndo.Name = "mnuUndo"
        Me.mnuUndo.Size = New System.Drawing.Size(173, 22)
        Me.mnuUndo.Text = "&Undo"
        '
        'mnuRedo
        '
        Me.mnuRedo.Image = CType(resources.GetObject("mnuRedo.Image"), System.Drawing.Image)
        Me.mnuRedo.Name = "mnuRedo"
        Me.mnuRedo.Size = New System.Drawing.Size(173, 22)
        Me.mnuRedo.Text = "&Redo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(170, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Image = CType(resources.GetObject("FindToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FindToolStripMenuItem.Text = "Fi&nd..."
        '
        'FindAndReplaceToolStripMenuItem
        '
        Me.FindAndReplaceToolStripMenuItem.Image = CType(resources.GetObject("FindAndReplaceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindAndReplaceToolStripMenuItem.Name = "FindAndReplaceToolStripMenuItem"
        Me.FindAndReplaceToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FindAndReplaceToolStripMenuItem.Text = "Find and &Replace..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(170, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(170, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CutToolStripMenuItem.Text = "C&ut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PasteToolStripMenuItem.Text = "Pas&te"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(170, 6)
        '
        'InsertImageToolStripMenuItem
        '
        Me.InsertImageToolStripMenuItem.Name = "InsertImageToolStripMenuItem"
        Me.InsertImageToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.InsertImageToolStripMenuItem.Text = "Insert Image..."
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectFontToolStripMenuItem, Me.ToolStripMenuItem6, Me.FontColorToolStripMenuItem, Me.ToolStripSeparator5, Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.UnderlineToolStripMenuItem, Me.NormalToolStripMenuItem, Me.ToolStripMenuItem7, Me.PageColorToolStripMenuItem})
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.FontToolStripMenuItem.Text = "F&ont"
        '
        'SelectFontToolStripMenuItem
        '
        Me.SelectFontToolStripMenuItem.Image = CType(resources.GetObject("SelectFontToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectFontToolStripMenuItem.Name = "SelectFontToolStripMenuItem"
        Me.SelectFontToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SelectFontToolStripMenuItem.Text = "Se&lect Font..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(138, 6)
        '
        'FontColorToolStripMenuItem
        '
        Me.FontColorToolStripMenuItem.Name = "FontColorToolStripMenuItem"
        Me.FontColorToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.FontColorToolStripMenuItem.Text = "Font &Color..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(138, 6)
        '
        'BoldToolStripMenuItem
        '
        Me.BoldToolStripMenuItem.Image = CType(resources.GetObject("BoldToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem"
        Me.BoldToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.BoldToolStripMenuItem.Text = "&Bold"
        '
        'ItalicToolStripMenuItem
        '
        Me.ItalicToolStripMenuItem.Image = CType(resources.GetObject("ItalicToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem"
        Me.ItalicToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ItalicToolStripMenuItem.Text = "&Italic"
        '
        'UnderlineToolStripMenuItem
        '
        Me.UnderlineToolStripMenuItem.Image = CType(resources.GetObject("UnderlineToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnderlineToolStripMenuItem.Name = "UnderlineToolStripMenuItem"
        Me.UnderlineToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.UnderlineToolStripMenuItem.Text = "&Underline"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.NormalToolStripMenuItem.Text = "&Normal"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(138, 6)
        '
        'PageColorToolStripMenuItem
        '
        Me.PageColorToolStripMenuItem.Name = "PageColorToolStripMenuItem"
        Me.PageColorToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.PageColorToolStripMenuItem.Text = "&Page Color..."
        '
        'ParagraphToolStripMenuItem
        '
        Me.ParagraphToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndentToolStripMenuItem, Me.mnuAlign})
        Me.ParagraphToolStripMenuItem.Name = "ParagraphToolStripMenuItem"
        Me.ParagraphToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ParagraphToolStripMenuItem.Text = "P&aragraph"
        '
        'IndentToolStripMenuItem
        '
        Me.IndentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuIndent0, Me.mnuIndent5, Me.mnuIndent10, Me.mnuIndent15, Me.mnuIndent20})
        Me.IndentToolStripMenuItem.Name = "IndentToolStripMenuItem"
        Me.IndentToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.IndentToolStripMenuItem.Text = "&Indent"
        '
        'mnuIndent0
        '
        Me.mnuIndent0.Name = "mnuIndent0"
        Me.mnuIndent0.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent0.Text = "None"
        '
        'mnuIndent5
        '
        Me.mnuIndent5.Name = "mnuIndent5"
        Me.mnuIndent5.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent5.Text = "5 pts"
        '
        'mnuIndent10
        '
        Me.mnuIndent10.Name = "mnuIndent10"
        Me.mnuIndent10.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent10.Text = "10 pts"
        '
        'mnuIndent15
        '
        Me.mnuIndent15.Name = "mnuIndent15"
        Me.mnuIndent15.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent15.Text = "15 pts"
        '
        'mnuIndent20
        '
        Me.mnuIndent20.Name = "mnuIndent20"
        Me.mnuIndent20.Size = New System.Drawing.Size(105, 22)
        Me.mnuIndent20.Text = "20 pts"
        '
        'mnuAlign
        '
        Me.mnuAlign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeftToolStripMenuItem, Me.CenterToolStripMenuItem, Me.RightToolStripMenuItem})
        Me.mnuAlign.Name = "mnuAlign"
        Me.mnuAlign.Size = New System.Drawing.Size(108, 22)
        Me.mnuAlign.Text = "&Align"
        '
        'LeftToolStripMenuItem
        '
        Me.LeftToolStripMenuItem.Image = CType(resources.GetObject("LeftToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem"
        Me.LeftToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.LeftToolStripMenuItem.Text = "Left"
        '
        'CenterToolStripMenuItem
        '
        Me.CenterToolStripMenuItem.Image = CType(resources.GetObject("CenterToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem"
        Me.CenterToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.CenterToolStripMenuItem.Text = "Center"
        '
        'RightToolStripMenuItem
        '
        Me.RightToolStripMenuItem.Image = CType(resources.GetObject("RightToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RightToolStripMenuItem.Name = "RightToolStripMenuItem"
        Me.RightToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.RightToolStripMenuItem.Text = "Right"
        '
        'BulletsToolStripMenuItem
        '
        Me.BulletsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBulletsToolStripMenuItem, Me.RemoveBulletsToolStripMenuItem})
        Me.BulletsToolStripMenuItem.Name = "BulletsToolStripMenuItem"
        Me.BulletsToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.BulletsToolStripMenuItem.Text = "&Bullets"
        '
        'AddBulletsToolStripMenuItem
        '
        Me.AddBulletsToolStripMenuItem.Name = "AddBulletsToolStripMenuItem"
        Me.AddBulletsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.AddBulletsToolStripMenuItem.Text = "A&dd Bullets"
        '
        'RemoveBulletsToolStripMenuItem
        '
        Me.RemoveBulletsToolStripMenuItem.Name = "RemoveBulletsToolStripMenuItem"
        Me.RemoveBulletsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.RemoveBulletsToolStripMenuItem.Text = "&Remove Bullets"
        '
        'KryptonBorderEdge6
        '
        Me.KryptonBorderEdge6.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge6.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge6.Location = New System.Drawing.Point(1, 551)
        Me.KryptonBorderEdge6.Name = "KryptonBorderEdge6"
        Me.KryptonBorderEdge6.Size = New System.Drawing.Size(799, 1)
        Me.KryptonBorderEdge6.Text = "KryptonBorderEdge6"
        '
        'KryptonBorderEdge5
        '
        Me.KryptonBorderEdge5.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge5.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge5.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge5.Location = New System.Drawing.Point(1, 0)
        Me.KryptonBorderEdge5.Name = "KryptonBorderEdge5"
        Me.KryptonBorderEdge5.Size = New System.Drawing.Size(799, 1)
        Me.KryptonBorderEdge5.Text = "KryptonBorderEdge5"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(800, 0)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(1, 552)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(0, 0)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 552)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(0, 552)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(801, 1)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'frmDocumentBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 553)
        Me.Controls.Add(Me.KryptonPanel)
        Me.DoubleBuffered = True
        Me.Name = "frmDocumentBuilder"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Builder"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge6 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge5 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRedo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindAndReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InsertImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectFontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BoldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItalicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PageColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParagraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndent0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndent5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndent10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndent15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndent20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAlign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BulletsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddBulletsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveBulletsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonBorderEdge7 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbrNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbrFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbrLeft As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrCenter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrRight As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbrBold As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrItalic As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrUnderline As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbrFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnInsertField As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCreateDocumentFields As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnViewFields As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents rtbDoc As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents KryptonBorderEdge11 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge10 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge9 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge12 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge8 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblFileName As DevComponents.DotNetBar.LabelItem
End Class
