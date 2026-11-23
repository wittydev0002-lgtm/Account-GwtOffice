<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainOne
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
        Me.components = New System.ComponentModel.Container()
        Dim SuperTabColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabColorTable = New DevComponents.DotNetBar.Rendering.SuperTabColorTable()
        Dim SuperTabLinearGradientColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable = New DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainOne))
        Me.StyleManager2 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tabFinancialMain = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.KryptonBorderEdge4 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge3 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge2 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.btnCases = New DevComponents.DotNetBar.ButtonItem()
        Me.btnReturns = New DevComponents.DotNetBar.ButtonItem()
        Me.btnAttachments = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBidders = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.tabFinancialMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFinancialMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager2
        '
        Me.StyleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager2.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.Teal)
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1})
        Me.Bar1.Location = New System.Drawing.Point(0, 660)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.PaddingBottom = 3
        Me.Bar1.PaddingLeft = 3
        Me.Bar1.PaddingRight = 3
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(1007, 22)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem1
        '
        Me.LabelItem1.ForeColor = System.Drawing.Color.White
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Great Wits Technologies Light Edge MOC, 2016"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel1.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel1.Controls.Add(Me.ItemPanel1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.KryptonPanel1.Size = New System.Drawing.Size(1007, 660)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel1.TabIndex = 5
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.KryptonPanel2.Controls.Add(Me.tabFinancialMain)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge4)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge3)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge2)
        Me.KryptonPanel2.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.ForeColor = System.Drawing.Color.Black
        Me.KryptonPanel2.Location = New System.Drawing.Point(147, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.KryptonPanel2.Size = New System.Drawing.Size(860, 657)
        Me.KryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White
        Me.KryptonPanel2.TabIndex = 3
        '
        'tabFinancialMain
        '
        Me.tabFinancialMain.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.tabFinancialMain.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabFinancialMain.ControlBox.MenuBox.Name = ""
        Me.tabFinancialMain.ControlBox.Name = ""
        Me.tabFinancialMain.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabFinancialMain.ControlBox.MenuBox, Me.tabFinancialMain.ControlBox.CloseBox})
        Me.tabFinancialMain.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabFinancialMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabFinancialMain.ForeColor = System.Drawing.Color.Black
        Me.tabFinancialMain.Location = New System.Drawing.Point(7, 1)
        Me.tabFinancialMain.Name = "tabFinancialMain"
        Me.tabFinancialMain.ReorderTabsEnabled = True
        Me.tabFinancialMain.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabFinancialMain.SelectedTabIndex = 0
        Me.tabFinancialMain.Size = New System.Drawing.Size(852, 655)
        Me.tabFinancialMain.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom
        Me.tabFinancialMain.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabFinancialMain.TabIndex = 5
        Me.tabFinancialMain.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1})
        SuperTabLinearGradientColorTable1.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer))}
        SuperTabColorTable1.Background = SuperTabLinearGradientColorTable1
        Me.tabFinancialMain.TabStripColor = SuperTabColorTable1
        Me.tabFinancialMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabFinancialMain.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(852, 630)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "SuperTabItem1"
        '
        'KryptonBorderEdge4
        '
        Me.KryptonBorderEdge4.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonBorderEdge4.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge4.Location = New System.Drawing.Point(7, 656)
        Me.KryptonBorderEdge4.Name = "KryptonBorderEdge4"
        Me.KryptonBorderEdge4.Size = New System.Drawing.Size(852, 1)
        Me.KryptonBorderEdge4.Text = "KryptonBorderEdge4"
        '
        'KryptonBorderEdge3
        '
        Me.KryptonBorderEdge3.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonBorderEdge3.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge3.Location = New System.Drawing.Point(859, 1)
        Me.KryptonBorderEdge3.Name = "KryptonBorderEdge3"
        Me.KryptonBorderEdge3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge3.Size = New System.Drawing.Size(1, 656)
        Me.KryptonBorderEdge3.Text = "KryptonBorderEdge3"
        '
        'KryptonBorderEdge2
        '
        Me.KryptonBorderEdge2.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonBorderEdge2.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge2.Location = New System.Drawing.Point(6, 1)
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        Me.KryptonBorderEdge2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge2.Size = New System.Drawing.Size(1, 656)
        Me.KryptonBorderEdge2.Text = "KryptonBorderEdge2"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.BackColor = System.Drawing.Color.White
        Me.KryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonBorderEdge1.ForeColor = System.Drawing.Color.Black
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(6, 0)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(854, 1)
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'ItemPanel1
        '
        Me.ItemPanel1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.Size = New System.Drawing.Size(147, 657)
        Me.ItemPanel1.TabIndex = 2
        Me.ItemPanel1.Text = "ItemPanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnCases, Me.btnReturns, Me.btnAttachments, Me.btnBidders, Me.ButtonItem5, Me.ButtonItem6, Me.ButtonItem7, Me.ButtonItem8})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btnCases
        '
        Me.btnCases.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCases.Name = "btnCases"
        Me.btnCases.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnCases.Stretch = True
        Me.btnCases.Text = "Cases"
        '
        'btnReturns
        '
        Me.btnReturns.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReturns.Name = "btnReturns"
        Me.btnReturns.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnReturns.Stretch = True
        Me.btnReturns.Text = "Returns"
        '
        'btnAttachments
        '
        Me.btnAttachments.BeginGroup = True
        Me.btnAttachments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAttachments.Name = "btnAttachments"
        Me.btnAttachments.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnAttachments.Stretch = True
        Me.btnAttachments.Text = "Attachment and Removals"
        '
        'btnBidders
        '
        Me.btnBidders.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBidders.Name = "btnBidders"
        Me.btnBidders.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnBidders.Stretch = True
        Me.btnBidders.Text = "Bidders Registration"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem5.Stretch = True
        Me.ButtonItem5.Text = "Auction Bid Entries"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem6.Stretch = True
        Me.ButtonItem6.Text = "Auction Sales"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem7.Stretch = True
        Me.ButtonItem7.Text = "View and Print Auction Sales"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.BeginGroup = True
        Me.ButtonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.ButtonItem8.Stretch = True
        Me.ButtonItem8.Text = "Plaintiff Statements"
        '
        'frmMainOne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 682)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMainOne"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Messenger Of Court Administration System"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.tabFinancialMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFinancialMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StyleManager2 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonBorderEdge3 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge2 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents tabFinancialMain As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents KryptonBorderEdge4 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btnCases As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAttachments As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnReturns As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBidders As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
End Class
