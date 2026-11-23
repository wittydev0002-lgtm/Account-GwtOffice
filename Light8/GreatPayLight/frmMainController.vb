Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO
Imports System.Text

Public Class frmMainController

    Dim strReportHeader As String
    Dim intPayslipFormat As Integer
    Public itm As Integer = 0

    Dim strNewPrintDetails As New ArrayList
    Dim strMyNewPrintLine As String
    Dim boolPrintFinalTotals As Boolean = False

    Dim sSummaryLineText() As String
    Dim strCurrentEmployeeBeingProcessed As String
    Dim strCurrentEmployeeBankDetails As String
    Dim strCurrentEmployeeBeingProcessedArray() As String
    Dim strCurrentEmployeeBankDetailsArray() As String
    Dim strCurrentEmployeeEmploymentDetails As String
    Dim strCurrentEmployeeEmploymentDetailsArray() As String

    Dim objPayslipRunfile As StreamReader
    Dim strRunfText As String
    Dim intPrintCodes() As Integer
    Dim intPrintValues() As Double
    Dim strRunfLine() As String
    Dim boolNewPage As Boolean = True
    Dim pageNum As Integer
    Dim dblSummaryTotals() As Double
    Dim dblGroupTotals() As Double
    Dim strSummaryColumnType As String

    Dim dblFinalGrossSalaryTotal As Double
    Dim dblFinalTotalDeductionsTotal As Double
    Dim dblFinalNetSalaryTotal As Double

    Dim dblGroupGrossSalaryTotal As Double
    Dim dblGroupNetSalaryTotal As Double
    Dim dblGroupTotalDeductionsTotal As Double

    Dim boolPrintingFinalPage As Boolean = False
    Dim boolPrintFromPreview As Boolean
    Dim boolPrintingCommerced As Boolean
    Dim strSortBreak As String
    Dim boolStarting As Boolean

    Dim nz As Integer 'item line counter

    Private Sub frmMainController_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        Dim f As New frmLogin
        f.ShowDialog()
        If boolAbort = True Then End

        If boolDbCreateMode = True Then
            navHome.Enabled = False
            navBatches.Enabled = False
            btnPayrollRun.Enabled = False
            navReports.Enabled = False
            navUtilities.Enabled = True
            btnParmsMain.Enabled = False
            btnImports.Enabled = False
            navUtilities.Enabled = False
            btnOrganisation.Enabled = False
            navSettings.Select()
        Else
            tabEmployees.Tabs.Clear()
            tabParameters.Tabs.Clear()
            tabParameters.Visible = False
            tabBatches.Tabs.Clear()
            tabBatches.Visible = False
            Dim frm As New frmEmployeeListing
            Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
            AddTabbedForm(frm, tabEmployees, CurrentTabColor)
            Dim frm2 As New frmPayrollBatchesListing
            CurrentTabColor = New DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Orange
            AddTabbedForm(frm2, tabBatches, CurrentTabColor)
            tvReports.ExpandAll()
        End If

    End Sub

    Private Sub frmMainController_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        RefreshTabs(tabParameters)
        RefreshTabs(tabEmployees)
        RefreshTabs(tabBatches)
    End Sub

    Private Sub tabEmployees_TabRemoved(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabRemovedEventArgs) Handles tabEmployees.TabRemoved
        If tabEmployees.Tabs.Count <= 0 Then
            tabEmployees.Visible = False
        End If
    End Sub

    Private Sub tabParameters_TabRemoved(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabRemovedEventArgs) Handles tabParameters.TabRemoved
        If tabParameters.Tabs.Count <= 0 Then
            tabParameters.Visible = False
        End If
    End Sub

    Public Sub AddTabbedForm(ByVal frm As System.Windows.Forms.Form, _
               ByVal ActiveTab As DevComponents.DotNetBar.SuperTabControl, _
               ByVal TabColor As DevComponents.DotNetBar.eTabItemColor)
        'Iterate through the item tabs and make sure that the item has not be loaded before
        'If item already loaded then activate it instead
        Cursor = Cursors.WaitCursor

        Dim boolTabLoaded As Boolean = False
        For i As Integer = 0 To ActiveTab.Tabs.Count - 1
            If UCase(ActiveTab.Tabs.Item(i).Text) = UCase(frm.Text) Then
                boolTabLoaded = True
                ActiveTab.SelectedTabIndex = i
                Cursor = Cursors.Default
                Exit Sub
            End If
        Next

        If boolTabLoaded = False Then
            frm.TopLevel = False
            frm.Visible = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill

            Dim myTabPanel As New DevComponents.DotNetBar.SuperTabControlPanel 'TabControlPanel()
            Dim myTabItem As New DevComponents.DotNetBar.SuperTabItem 'TabItem()

            myTabItem.Text = frm.Text
            ActiveTab.Controls.Add(myTabPanel)
            myTabItem.AttachedControl = myTabPanel
            ActiveTab.Tabs.Add(myTabItem)

            myTabPanel.Location = New System.Drawing.Point(0, 26)
            myTabPanel.Name = "TabControlPanel" & ActiveTab.Tabs.Count
            myTabPanel.Padding = New System.Windows.Forms.Padding(0)
            myTabPanel.Size = New System.Drawing.Size(616, 385)
            myTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            myTabPanel.Dock = System.Windows.Forms.DockStyle.Fill
            myTabPanel.TabItem = myTabItem
            myTabItem.PredefinedColor = TabColor ' DevComponents.DotNetBar.eTabItemColor.Purple
            myTabPanel.Controls.Add(frm)
            ActiveTab.Refresh()
            ActiveTab.Visible = True
            RefreshTabs(ActiveTab)
            ActiveTab.SelectedTabIndex = ActiveTab.Tabs.Count - 1
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub RefreshTabs(ByVal ActiveTab As DevComponents.DotNetBar.SuperTabControl)
        Me.Refresh()
        ActiveTab.Refresh()
    End Sub

    Private Sub SideNavItem1_Click(sender As System.Object, e As System.EventArgs) Handles SideNavItem1.Click
        RefreshTabs(tabEmployees)
    End Sub

    Private Sub btnPayrollRun_Click(sender As System.Object, e As System.EventArgs) Handles btnPayrollRun.Click
        Dim f As New frmPayrollRuns
        f.ShowDialog()
    End Sub

    Private Sub btnCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnCodes.Click
        Dim frm As New frmCodes
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabParameters, CurrentTabColor)
    End Sub

    Private Sub btnCalculations_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculations.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            boolAbort = False
            Dim f As New frmCalculationsView
            f.ShowDialog()
            If boolAbort = True Then Exit Sub
            Dim frm As New frmCalculations
            frm.Text = "Calculations-" & intNextCalculationNumber
            Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Blue
            AddTabbedForm(frm, tabParameters, CurrentTabColor)
        Else
            gwt_comm.AccessViolation()
            Exit Sub
        End If
    End Sub

    Private Sub btnDates_Click(sender As System.Object, e As System.EventArgs) Handles btnDates.Click
        Dim frm As New frmSystemDates
        frm.ShowDialog()
    End Sub

    Private Sub btnConstants_Click(sender As System.Object, e As System.EventArgs) Handles btnConstants.Click
        Dim frm As New frmConstants
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItem6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem6.Click
        Dim frm As New frmSystemReferences
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItem5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem5.Click
        Dim frm As New frmFlagsListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Coral
        AddTabbedForm(frm, tabParameters, CurrentTabColor)
    End Sub

    Private Sub btnTrekkedFields_Click(sender As System.Object, e As System.EventArgs) Handles btnTrekkedFields.Click
        Dim frm As New frmTrekkedFields
        frm.ShowDialog()
    End Sub

    Private Sub btnKeyFields_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyFields.Click
        Dim frm As New frmKeyData
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Gold
        AddTabbedForm(frm, tabParameters, CurrentTabColor)
    End Sub

    Private Sub btnColumnReports_Click(sender As System.Object, e As System.EventArgs) Handles btnColumnReports.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicStoresManagement > 0 Then
            Dim frm = New frmPayrollUserReportsListing
            Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
            AddTabbedForm(frm, tabParameters, CurrentTabColor)
        Else
            gwt_comm.AccessViolation()
            Exit Sub
        End If
    End Sub

    Private Sub btnCreate_Click(sender As System.Object, e As System.EventArgs) Handles btnCreate.Click
        On Error GoTo RaiseErr

        boolAbort = False
        Dim frm As New frmDbConfiguration
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim commNew As Data.OleDb.OleDbConnection

        Dim strCreateConnection As String = Nothing

        If UCase(strAuthentication) = UCase("SQL Server Authentication") Then
            strCreateConnection = "Data Source=" & strServerName & ";Initial Catalog=Master;User ID=" & strLoginName & ";Password=" & strPassword & ";provider=SQLOLEDB"
        Else
            strCreateConnection = "Provider=SQLOLEDB;Data Source=" & strServerName & ";Initial Catalog=Master;Integrated Security=SSPI"
        End If

        commNew = New Data.OleDb.OleDbConnection(strCreateConnection)
        commNew.Open()

        If File.Exists(Application.StartupPath & "\Data\sysconfigdb.txt") Then
            Cursor = Cursors.WaitCursor
            Dim objFile As New System.IO.StreamReader(Application.StartupPath & "\Data\sysconfigdb.txt")
            Dim strData As String = objFile.ReadToEnd()
            objFile.Close()
            Dim strLines() As String = Split(strData, vbCrLf)
            pb1.Value = 0
            pb1.Visible = True
            pb1.Maximum = strLines.Length + 10

            'Create the database here
            Dim strSql As String = "CREATE DATABASE [" & strDatabaseName & "]"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, commNew)
            objCommand.ExecuteNonQuery()

            strSql = "USE [" & strDatabaseName & "]"
            objCommand = New Data.OleDb.OleDbCommand(strSql, commNew)
            objCommand.ExecuteNonQuery()

            For p As Integer = 0 To strLines.Length - 1
                If Not String.IsNullOrEmpty(strLines(p)) Then
                    objCommand = New Data.OleDb.OleDbCommand(strLines(p), commNew)
                    objCommand.ExecuteNonQuery()
                End If
                pb1.Value = pb1.Value + 1
            Next

            'Write the details to the configuration file
            Dim objConfile As New System.IO.StreamWriter(Application.StartupPath & "\Data\PayCatalogue.txt", True)
            objConfile.WriteLine(strNewCompanyName & "|" & "data source=" & strServerName & ";initial catalog=" & strDatabaseName & ";User ID=" & strLoginName & ";Password=" & strPassword & ";provider=SQLOLEDB")
            objConfile.Close()

            pb1.Value = pb1.Maximum
            Cursor = Cursors.Default
            MessageBox.Show("Process has been completed successfully. " _
                            & "Application will close and you will have to restart",
                            "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        Else
            MessageBox.Show("Application could not locate the configuration file. " _
                & vbCrLf & "Please contact you software supplier for assistance",
                "Application Configuration Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & "On database create")
    End Sub

    Private Sub btnPaywellDbImport_Click(sender As System.Object, e As System.EventArgs) Handles btnPaywellDbImport.Click
        Dim frm As New frmPaywellImports
        frm.ShowDialog()
    End Sub

    Private Sub btnSplitCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnSplitCodes.Click
        Dim frm As New frmSplitCodesSetup
        frm.ShowDialog()
    End Sub

    Private Sub btnBanks_Click(sender As System.Object, e As System.EventArgs) Handles btnBanks.Click
        Dim frm As New frmBanksPreview
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Pink
        AddTabbedForm(frm, tabParameters, CurrentTabColor)
    End Sub

    Private Sub btnBankExtracts_Click(sender As System.Object, e As System.EventArgs) Handles btnBankExtracts.Click
        Dim frm As New frmBankExtract
        frm.ShowDialog()
    End Sub

    Private Sub tvReports_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvReports.DoubleClick
        strReportHeader = UCase(tvReports.SelectedNode.Text)
        Select Case UCase(tvReports.SelectedNode.Text)

            Case Is = UCase("Employee Full Masterfile")
                strReportHeader = tvReports.SelectedNode.Text
                PrintMasterFileData()

            Case Is = UCase("A5 Payslips")
                intPayslipFormat = 1
                PrintSmallPayslip()

            Case Is = UCase("A5 Payslips Format 2")
                intPayslipFormat = 2
                PrintSmallPayslip()

            Case Is = UCase("Employee Control")
                Dim f As New frmPrintPayrollRegister
                f.ShowDialog()

            Case Is = UCase("Payroll Control Totals")
                PrintControlTotals()

            Case Is = UCase("Bank Transfer Schedule")
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                PrintBankSchedules()

            Case Is = UCase("Payroll Summary")
                PrintPayrollSummary()

            Case Is = UCase("Audit Trail")
                boolAbort = False
                Dim f As New frmAuditPrintSpecification
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                PrintAuditReport()

            Case Is = UCase("Coinage Analysis")
                PrintCoinageAnalysis()

            Case Is = UCase("Tax Certificates")
                Dim f As New frmEmployeeTaxCertificates
                f.ShowDialog()

        End Select

    End Sub

    Private Sub PrintSmallPayslip()
        'payslip printing
        boolAbort = False
        boolDrawBorders = True

        Dim f As New frmDateSpecificationCustom
        f.ShowDialog()

        If boolAbort = True Then Exit Sub
        gwt_comm.GetKeyDataFields()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignProcessedEmployeeNumbers() 'Read from the current run file
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignPersonalDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignBankingDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignEmploymentDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignCompanyDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.GetPayslipDetails()
        If boolAbort = True Then Exit Sub
        itm = 0

        Dim img As Icon
        img = New Icon(Application.StartupPath & "\Data\people.ico")
        ppd.Icon = img

        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        If intPayslipFormat = 2 Then
            ppd.Document = pdFormatTwo
        Else
            ppd.Document = pdSmallPayslips
        End If
        ppd.ShowDialog()
    End Sub

    Public Sub PrintControlTotals()
        'Print and preview payroll control totals. The style is the same as that of the payroll register
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim arrPrintCodeValues As New ArrayList

        objCommand = New Data.OleDb.OleDbCommand("SELECT RunAmounts FROM EmployeeRunFile", cnn)
        objReader = objCommand.ExecuteReader
        '
        'Build only one string line for all the totals
        '
        Dim dblCodeTotals(0 To 0) As Double
        Dim cnt As Integer = 0
        Dim strSplitter() As String
        While objReader.Read
            strSplitter = Split(objReader(0).ToString, "|")
            If cnt = 0 Then
                ReDim dblCodeTotals(0 To (strSplitter.Length - 1))
            End If
            For n = 0 To strSplitter.Length - 1
                dblCodeTotals(n) = dblCodeTotals(n) + CDbl(strSplitter(n))
            Next
            cnt = cnt + 1
        End While
        objReader.Close()

        For n = 0 To dblCodeTotals.Length - 1
            Dim objCommandCodes As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CodeNo) +';'+ Description AS [CodeDetails] FROM SystemCodes WHERE CodeNo = " & (n + 1) & "", cnn)
            Dim objReadCodes As Data.OleDb.OleDbDataReader = objCommandCodes.ExecuteReader
            objReadCodes.Read()
            If CDbl(dblCodeTotals(n)) <> 0 Then
                Dim strAmount As String = CStr(Format(CDbl(dblCodeTotals(n)), "#,##0.00"))
                Dim strDesc As String = objReadCodes(0).ToString
                arrPrintCodeValues.Add(strDesc & ";" & strAmount)
            End If
        Next

        If arrPrintCodeValues.Count > 0 Then
            'Format the code numbers first
            Dim z As Integer = 0
            For z = 0 To arrPrintCodeValues.Count - 1
                Dim strSplitted() As String = Split(arrPrintCodeValues.Item(z), ";")
                arrPrintCodeValues.Item(z) = CStr(Format(CInt(strSplitted(0)), "000")) & ";" & strSplitted(1) & ";" & strSplitted(2)
            Next
            'Call the BraincoSmartReport writer to handle the output
            Dim intRecordsCount As Integer = arrPrintCodeValues.Count
            Dim intIteration As Integer = 0
            If intRecordsCount Mod 2 = 0 Then
                intIteration = intRecordsCount / 2
            Else
                arrPrintCodeValues.Add(";;")
                intRecordsCount = intRecordsCount + 1
                intIteration = intRecordsCount / 2
            End If

            Dim strPrintDetails(0 To (intIteration - 1)) As String
            Dim y As Integer = 0
            For p = 0 To intIteration - 1
                strPrintDetails(p) = arrPrintCodeValues.Item(y) & ";;" & arrPrintCodeValues(y + 1)
                y = y + 2
            Next

            Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
            With rpt
                .intPrintRecordsCount = strPrintDetails.Length
                .intNumberOfColumns = 7
                .strColumnHeaders = "CODE|DESCRIPTION|AMOUNT| |CODE|DESCRIPTION|AMOUNT"
                .strColumnAlignments = "0|0|2|0|0|0|2"
                .strColumnWidths = "40|170|80|30|40|170|80"
                .strFooterCaption = "Employee payroll register " & Now
                .strMainCaption = UCase(strDefaultReportHeader)
                .strMainHeader2 = "PAYROLL CONTROL TOTALS: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
                .strMainHeader3 = ""
                .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .DrawBorder = True
                .HorizontalLines = True
                .VerticalLines = True
                .GridColor = Color.Gray
                .BorderColor = Color.FromName("LightGray")
                .DetailFont = fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .boolPrintRecordCount = False
                .PrintSummary = False
                .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
                .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
                .intKeyFieldIndex = 0
                .strPrintValues = strPrintDetails
            End With
            ppdUserReports.Document = rpt
            ppdUserReports.ShowDialog()
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payroll Control Totals Print"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Public Sub EmployeePayrollRegister(ByVal strEmpNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim arrPrintCodeValues As New ArrayList
        Dim strPersonalDetails As String = Nothing
        If Not String.IsNullOrEmpty(strEmpNumber) Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = '" & strEmpNumber & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    'Get the employee personal details
                    Dim objCommandPersonal As New Data.OleDb.OleDbCommand("SELECT EmployeeNo +' '+ LastName +' '+ Inits AS [Personal] FROM EmployeeMaster WHERE EmployeeNo = '" & strEmpNumber & "'", cnn)
                    Dim objReadPersonal As Data.OleDb.OleDbDataReader = objCommandPersonal.ExecuteReader
                    If objReadPersonal.HasRows Then
                        objReadPersonal.Read()
                        If Not IsDBNull(objReadPersonal(0).ToString) Then strPersonalDetails = objReadPersonal(0).ToString
                    End If
                    objReadPersonal.Close()
                    Dim strBuffer() As String = Split(objReader(0).ToString, "|")
                    Dim i As Integer = 0
                    For i = 0 To strBuffer.Length - 1
                        Dim objCommandCodes As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CodeNo) +';'+ Description AS [CodeDetails] FROM SystemCodes WHERE CodeNo = " & (i + 1) & "", cnn)
                        Dim objReadCodes As Data.OleDb.OleDbDataReader = objCommandCodes.ExecuteReader
                        objReadCodes.Read()
                        If CDbl(strBuffer(i)) <> 0 Then
                            Dim strAmount As String = CStr(Format(CDbl(strBuffer(i)), "#,##0.00"))
                            Dim strDesc As String = objReadCodes(0).ToString
                            arrPrintCodeValues.Add(strDesc & ";" & strAmount)
                        End If
                        objReadCodes.Close()
                    Next
                End If
            End If
            objReader.Close()
        Else
            MessageBox.Show("Please enter the employee number for whom the register is to be printed", _
                "Invalid Selective Print Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If arrPrintCodeValues.Count > 0 Then
            'Format the code numbers first
            Dim z As Integer = 0
            For z = 0 To arrPrintCodeValues.Count - 1
                Dim strSplitted() As String = Split(arrPrintCodeValues.Item(z), ";")
                arrPrintCodeValues.Item(z) = CStr(Format(CInt(strSplitted(0)), "000")) & ";" & strSplitted(1) & ";" & strSplitted(2)
            Next
            'Call the BraincoSmartReport writer to handle the output
            Dim intRecordsCount As Integer = arrPrintCodeValues.Count
            Dim intIteration As Integer = 0
            If intRecordsCount Mod 2 = 0 Then
                intIteration = intRecordsCount / 2
            Else
                arrPrintCodeValues.Add(";;")
                intRecordsCount = intRecordsCount + 1
                intIteration = intRecordsCount / 2
            End If

            Dim strPrintDetails(0 To (intIteration - 1)) As String
            Dim y As Integer = 0
            For p = 0 To intIteration - 1
                strPrintDetails(p) = arrPrintCodeValues.Item(y) & ";;" & arrPrintCodeValues(y + 1)
                y = y + 2
            Next

            Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
            With rpt
                .intPrintRecordsCount = strPrintDetails.Length
                .intNumberOfColumns = 7
                .strColumnHeaders = "CODE|DESCRIPTION|AMOUNT| |CODE|DESCRIPTION|AMOUNT"
                .strColumnAlignments = "0|0|2|0|0|0|2"
                .strColumnWidths = "40|170|80|30|40|170|80"
                .strFooterCaption = "Employee payroll register " & Now
                .strMainCaption = UCase(strDefaultReportHeader)
                .strMainHeader2 = "PAYROLL REGISTER: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
                .strMainHeader3 = strPersonalDetails
                .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .DrawBorder = True
                .HorizontalLines = True
                .VerticalLines = True
                .GridColor = Color.Gray
                .BorderColor = Color.FromName("LightGray")
                .DetailFont = fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .boolPrintRecordCount = False
                .PrintSummary = False
                .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
                .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
                .intKeyFieldIndex = 0
                .strPrintValues = strPrintDetails
            End With
            Dim prnt As New PrintDialog
            prnt.ShowDialog()
            ppdUserReports.Document = rpt
            ppdUserReports.ShowDialog()
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payroll Register Print"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub PrintCoinageAnalysis()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrCoinage As New ArrayList
        Dim strArr() As String

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT EmployeeBanks.EmployeeNo, " _
            & "EmployeeMaster.LastName, EmployeeMaster.Inits, EmployeeBanks.PayMethod FROM EmployeeBanks LEFT JOIN " _
            & "EmployeeMaster ON EmployeeBanks.EmployeeNo = EmployeeMaster.EmployeeNo WHERE PayMethod = 'CASH' " _
            & "AND EmployeeMaster.Status = 'ACTIVE' ORDER BY EmployeeMaster.LastName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        gwt_comm.GetKeyDataFields()

        While objReader.Read

            'Get the employee net salary and pass it for spliting

            objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeRunFile WHERE EmployeeNo = '" & objReader(0).ToString & "'", cnn)
            Dim objReadAmounts As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadAmounts.HasRows Then
                objReadAmounts.Read()

                Dim dblamout As Double = 0
                Dim strSplitAmounts() As String = Split(objReadAmounts("RunAmounts").ToString, "|")
                If IsNumeric(strSplitAmounts(intPayrollNetIncomeCode - 1)) Then
                    dblamout = CDbl(strSplitAmounts(intPayrollNetIncomeCode - 1))
                End If

                strArr = gwt_comm.Breakdown(CStr(Format(dblamout, "##0.00")))

                Dim strHundreds As String = "0"
                Dim strFifties As String = "0"
                Dim strTwenties As String = "0"
                Dim strTens As String = "0"
                Dim strFives As String = "0"
                Dim strTwos As String = "0"
                Dim strOnes As String = "0"
                Dim strFiftyCents As String = "0"
                Dim strTenCents As String = "0"
                Dim strFiveCents As String = "0"
                Dim strCents As String = "0"

                'Divide the number first with 100
                Dim y As Integer = Math.Floor(dblamout / 100)
                strHundreds = CStr(y)
                'Get the fifties by multiplying back the hundreds and subtracting from original figure
                Dim dblHundreds As Double = y * 100
                Dim dblFifties As Double = dblamout - dblHundreds
                y = Math.Floor(dblFifties / 50)
                strFifties = CStr(y)
                Dim dblTwenties As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50)
                y = Math.Floor(dblTwenties / 20)
                strTwenties = CStr(y)

                Dim dblTens As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20)
                y = Math.Floor(dblTens / 10)
                strTens = CStr(y)

                Dim dblFives As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20 + CDbl(strTens) * 10)
                y = Math.Floor(dblFives / 5)
                strFives = CStr(y)

                Dim dblTwos As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20 + CDbl(strTens) * 10 + CDbl(strFives) * 5)
                y = Math.Floor(dblTwos / 2)
                strTwos = CStr(y)

                Dim dblOnes As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20 + CDbl(strTens) * 10 + CDbl(strFives) * 5 + CDbl(strTwos) * 2)
                y = Math.Floor(dblOnes / 1)
                strOnes = CStr(y)

                'Get the cents values
                Dim dblAmountsInCents As Double = CDbl(strArr(strArr.Length - 2) & strArr(strArr.Length - 1))

                y = Math.Floor(dblAmountsInCents / 50)
                strFiftyCents = CStr(y)

                'Get the 10 cents
                Dim dblTenCents As Double = dblAmountsInCents - (CDbl(strFiftyCents) * 50)
                y = Math.Floor(dblTenCents / 10)
                strTenCents = CStr(y)

                'Get the 5 cents
                Dim dblFiveCents As Double = dblAmountsInCents - (CDbl(strFiftyCents) * 50 + CDbl(strTenCents) * 10)
                y = Math.Floor(dblFiveCents / 5)
                strFiveCents = CStr(y)

                'Get the last cents
                Dim dblCents As Double = dblAmountsInCents - (CDbl(strFiftyCents) * 50 + CDbl(strTenCents) * 10 + CDbl(strFiveCents) * 5)
                y = Math.Floor(dblCents / 1)
                strCents = CStr(y)

                arrCoinage.Add(objReader(1) & " " & objReader(2) & " " & objReader(0) & ";" & strHundreds & ";" & strFifties & ";" & strTwenties & ";" & strTens & ";" & strFives & ";" _
                    & strTwos & ";" & strOnes & ";" & strFiftyCents & ";" & strTenCents & ";" & strFiveCents & ";" & strCents & ";" & Format(dblamout, "##0.00"))
            End If
            objReadAmounts.Close()
        End While
        objReader.Close()

        Dim strPrintDetails(0 To arrCoinage.Count - 1) As String

        For i As Integer = 0 To arrCoinage.Count - 1
            strPrintDetails(i) = arrCoinage.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 13
            .strColumnHeaders = "EMPLOYEE|100.00|50.00|20.00|10.00|5.00|2.00|1.00|0.50|0.10|0.05|0.01|NET"
            .strColumnAlignments = "0|2|2|2|2|2|2|2|2|2|2|2|2"
            .strColumnWidths = "120|40|40|40|40|40|40|40|40|40|40|40|60"
            .strFooterCaption = "COINAGE ANALYSIS - DETAILED"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "COINAGE ANAYLYSIS - " & UCase(strCompanyName)
            .strMainHeader3 = "PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strColumnTotals = "NO|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On coinage analysis print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub PrintPayrollSummary()
        'Payroll summary
        On Error GoTo RaiseErr
        boolAbort = False
        ' DepartmentSurnameSort("Department/Surname")
        'If boolAbort = True Then Exit Sub
        Dim f As New frmPayrollSummarySortOptions
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        gwt_comm.PayrollSummaryPrintCodes()
        gwt_comm.AssignProcessedEmployeeNumbers()
        If boolAbort = True Then Exit Sub

        '******************* THIS PROCEDURE IS NOT AVAILABLE IN THIS VERSION **************************
        '**                                                                                          ** 
        '** GetKeyDataFields()                                                                       **
        '** If boolAbort = True Then Exit Sub                                                        **
        '**********************************************************************************************


        'ReadSortFileData()
        gwt_comm.AssignCompanyDetails()
        gwt_comm.GetReportTaxPeriodNumber()
        If boolAbort = True Then Exit Sub
        boolPrintFromPreview = False
        itm = 0 : nz = 0 : dblFinalGrossSalaryTotal = 0 : dblFinalTotalDeductionsTotal = 0 : dblFinalNetSalaryTotal = 0
        pageNum = 1
        'initialize the totals array
        Dim p As Integer
        ReDim dblSummaryTotals(0 To (strSummaryLineCodes.Length - 1))
        ReDim dblGroupTotals(0 To (strSummaryLineCodes.Length - 1))
        ReDim intPrintCodes(0 To (strSummaryLineCodes.Length - 1))
        ReDim intPrintValues(0 To (strSummaryLineCodes.Length - 1))
        For p = 0 To strSummaryLineCodes.Length - 1
            dblSummaryTotals(p) = 0
            dblGroupTotals(p) = 0
        Next

        boolNewPage = True : boolPrintingFinalPage = False
        strSortBreak = "" : boolStarting = False
        CreatePrintArray()
        If boolAbort = True Then Exit Sub

        'Use the brainco smart reporter
        '
        'THE REPORT FORMAT IS AS FOLLOWS
        '
        'GetCompanyDetails()
        Dim intRecordsCount As Integer = strNewPrintDetails.Count
        Dim strPrintDetails(0 To (intRecordsCount - 1)) As String
        If intRecordsCount <= 0 Then
            MessageBox.Show("No details to print", "No Print Records", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        'Select the details from the temp summary table
        Dim strSqlStatement As String = Nothing

        'strSqlStatement = "SELECT Description0, Col1Description, " _
        '    & "CAST(Col1Unit1 AS DECIMAL (10,2)), CAST(Col1Unit2 AS DECIMAL (10,2)), Col2Description, " _
        '    & "CAST(Col2Unit1 AS DECIMAL (10,2)), CAST(Col2Unit2 AS DECIMAL (10,2)), SortKey FROM " _
        '    & "TempSummary ORDER BY TransactionId"

        'Dim objSummary As New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
        'Dim objReadSummary As Data.OleDb.OleDbDataReader = objSummary.ExecuteReader
        'Dim arrRetrievedData As New ArrayList
        'While objReadSummary.Read
        '    If String.IsNullOrEmpty(Trim(objReadSummary(1))) And String.IsNullOrEmpty(Trim(objReadSummary(4))) Then
        '        arrRetrievedData.Add(" ; ; ; ; ; ; ;" & objReadSummary(7))
        '    Else
        '        arrRetrievedData.Add(objReadSummary(0) & ";" & objReadSummary(1) & ";" _
        '            & objReadSummary(2) & ";" & objReadSummary(3) & ";" & objReadSummary(4) & ";" _
        '            & objReadSummary(5) & ";" & objReadSummary(6) & ";" & objReadSummary(7))
        '    End If
        'End While
        'objReadSummary.Close()



        Dim strPrintDetails2(0 To (strNewPrintDetails.Count - 1)) As String

        For p = 0 To strNewPrintDetails.Count - 1
            strPrintDetails2(p) = UCase(strNewPrintDetails.Item(p))
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 8
            .strColumnHeaders = "EMPLOYEE|EARNINGS|UNITS|AMOUNT|DEDUCTIONS|UNIT|AMOUNT|"
            .strColumnAlignments = "0|0|2|2|0|2|2|0"
            .strColumnWidths = "120|120|70|75|120|70|75|0"
            .strFooterCaption = "Powered by Brainco Software Solutions"
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "PAYROLL SUMMARY FOR " & UCase(strCompanyName)
            .strMainHeader3 = "PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .AlternateBackColor = Color.WhiteSmoke
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .RestartPageNumbersOnGroupChange = True
            .boolPrintTotals = False
            .boolGenericReport = True
            .intBreakIndex = 7
            .intKeyFieldIndex = 7
            .strColumnFormating = "NO|NO|YES|YES|NO|YES|YES|NO"
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails2
        End With
        ppd.Document = rpt
        ppd.ShowDialog()
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Summary Print"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub CreatePrintArray()
        On Error GoTo RaiseErr
        Dim str As String
        strNewPrintDetails = New ArrayList
        Dim dblPrintTotals(0 To (strSummaryLineCodes.Length - 1)) As Double
        Dim intInitialize As Integer = 0
        Dim arrEarningsLine As New ArrayList
        Dim arrDeductionsLine As New ArrayList
        Dim intEarningsCount As Integer = 0, intDeductionsCount As Integer = 0
        For intInitialize = 0 To strSummaryLineCodes.Length - 1
            dblPrintTotals(intInitialize) = 0
        Next
        gwt_comm.GetKeyDataFields()
        While itm < intPayslipProcessingCount

            Dim strGroupKey As String = GetGroupKey(strProcessedEmployeeNumbers(itm), strReportSortOption)

            'Open the payslip runfile and get the current employee details
            Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeRunFile where EmployeeNo = " _
                & "'" & strProcessedEmployeeNumbers(itm) & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                'Get the employee being processed's details
                Dim strBlockEmployeeNo As String = Nothing
                Dim sqlCommandEmpDetails As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ Inits +' '+ EmployeeNo " _
                    & "AS [Details] FROM EmployeeMaster WHERE EmployeeNo = '" & strProcessedEmployeeNumbers(itm) & "'", cnn)
                Dim objReadDetails As Data.OleDb.OleDbDataReader = sqlCommandEmpDetails.ExecuteReader
                If objReadDetails.HasRows Then
                    objReadDetails.Read()
                    If Not IsDBNull(objReadDetails(0).ToString) Then strCurrentEmployeeBeingProcessed = objReadDetails(0).ToString
                End If
                'strCurrentEmployeeBeingProcessed = strEmployeeFullDetails(itm)
                'strCurrentEmployeeBeingProcessedArray = Split(strCurrentEmployeeBeingProcessed, ";")
                If Not IsDBNull(objReader("RunAmounts").ToString) Then
                    strRunfLine = Split(objReader("RunAmounts").ToString, "|")
                    Dim z As Integer = 0
                    For z = 0 To strSummaryLineCodes.Length - 1
                        intPrintValues(z) = CDbl(strRunfLine(z))
                        dblPrintTotals(z) = dblPrintTotals(z) + CDbl(strRunfLine(z))
                    Next z
                End If
            End If

            objReader.Close()
            intEarningsCount = 0 : intDeductionsCount = 0
            arrEarningsLine = New ArrayList
            arrDeductionsLine = New ArrayList
            '0773926348

            For nz = 0 To strSummaryLineCodes.Length - 1
                strMyNewPrintLine = ""
                'If nz = 236 Then
                '    MessageBox.Show(nz)
                'End If
                sSummaryLineText = Split(strSummaryLineCodes(nz), ";")
                strSummaryColumnType = sSummaryLineText(2)
                Dim strUnitAmt As String = "0.00"
                If IsNumeric(sSummaryLineText(4)) Then
                    If CInt(sSummaryLineText(4) - 1) > 0 Then
                        strUnitAmt = CStr(Format(intPrintValues(CInt(sSummaryLineText(4) - 1)), "#,##0.00"))
                    End If
                End If

                Select Case UCase(strSummaryColumnType)
                    Case Is = "E"
                        str = CStr(Format(intPrintValues(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                        If CDbl(str) <> 0 Then
                            If intEarningsCount = 0 Then
                                arrEarningsLine.Add(strCurrentEmployeeBeingProcessed & ";" & sSummaryLineText(1) & ";" & strUnitAmt & ";" & str)
                            Else
                                arrEarningsLine.Add(" ;" & sSummaryLineText(1) & ";" & strUnitAmt & ";" & str)
                            End If
                            intEarningsCount = intEarningsCount + 1
                        End If
                    Case Is = "D"
                        str = CStr(Format(intPrintValues(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                        If CDbl(str) <> 0 Then
                            arrDeductionsLine.Add(sSummaryLineText(1) & ";" & strUnitAmt & ";" & str)
                            intDeductionsCount = intDeductionsCount + 1
                        End If
                End Select
            Next
            'Print the net salary, gross salary and total deductions totals
            str = CStr(Format(intPrintValues(CInt(intPayrollGrossIncomeCode - 1)), "#,##0.00"))
            arrEarningsLine.Add(" ;GROSS PAY;;" & str)
            intEarningsCount = intEarningsCount + 1
            'Print the total deductions amount
            str = CStr(Format(intPrintValues(CInt(intPayrollTotalDeductions - 1)), "#,##0.00"))
            arrEarningsLine.Add(" ;TOTAL DEDUCTIONS;;" & str)
            intEarningsCount = intEarningsCount + 1
            'Print the net salary
            str = CStr(Format(intPrintValues(CInt(intPayrollNetIncomeCode - 1)), "#,##0.00"))
            arrEarningsLine.Add(" ;NET PAY;;" & str)
            intEarningsCount = intEarningsCount + 1

            If intEarningsCount > intDeductionsCount Then
                Dim n As Integer = 0
                For n = (intDeductionsCount + 1) To intEarningsCount
                    arrDeductionsLine.Add(" ; ; ")
                    intDeductionsCount = intDeductionsCount + 1
                Next
            Else
                Dim n As Integer = 0
                For n = (intEarningsCount + 1) To intDeductionsCount
                    arrEarningsLine.Add(" ; ; ; ")
                    intEarningsCount = intEarningsCount + 1
                Next
            End If
            For nz = 0 To intDeductionsCount - 1
                strNewPrintDetails.Add(arrEarningsLine(nz) & ";" & arrDeductionsLine(nz) & ";" & strGroupKey)
            Next nz
            'Add a blank line
            strNewPrintDetails.Add(" ; ; ; ; ; ; ;" & strGroupKey)
            itm += 1
        End While

        'Print the report total at end

        intEarningsCount = 0 : intDeductionsCount = 0
        arrEarningsLine = New ArrayList
        arrDeductionsLine = New ArrayList

        For nz = 0 To strSummaryLineCodes.Length - 1
            strMyNewPrintLine = ""
            sSummaryLineText = Split(strSummaryLineCodes(nz), ";")
            strSummaryColumnType = sSummaryLineText(2)
            Select Case UCase(strSummaryColumnType)
                Case Is = "E"
                    str = CStr(Format(dblPrintTotals(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                    If CDbl(str) <> 0 Then
                        If intEarningsCount = 0 Then
                            arrEarningsLine.Add("TOTALS ;" & sSummaryLineText(1) & ";;" & str)
                        Else
                            arrEarningsLine.Add(" ;" & sSummaryLineText(1) & ";;" & str)
                        End If
                        intEarningsCount = intEarningsCount + 1
                    End If
                Case Is = "D"
                    str = CStr(Format(dblPrintTotals(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                    If CDbl(str) <> 0 Then
                        arrDeductionsLine.Add(sSummaryLineText(1) & ";;" & str)
                        intDeductionsCount = intDeductionsCount + 1
                    End If
            End Select
        Next
        'Print the net salary, gross salary and total deductions totals
        str = CStr(Format(dblPrintTotals(CInt(intPayrollGrossIncomeCode - 1)), "#,##0.00"))
        arrEarningsLine.Add(" ;GROSS PAY;;" & str)
        intEarningsCount = intEarningsCount + 1
        'Print the total deductions amount
        str = CStr(Format(dblPrintTotals(CInt(intPayrollTotalDeductions - 1)), "#,##0.00"))
        arrEarningsLine.Add(" ;TOTAL DEDUCTIONS;;" & str)
        intEarningsCount = intEarningsCount + 1
        'Print the net salary
        str = CStr(Format(dblPrintTotals(CInt(intPayrollNetIncomeCode - 1)), "#,##0.00"))
        arrEarningsLine.Add(" ;NET PAY;;" & str)
        intEarningsCount = intEarningsCount + 1

        If intEarningsCount > intDeductionsCount Then
            Dim n As Integer = 0
            For n = (intDeductionsCount + 1) To intEarningsCount
                arrDeductionsLine.Add(" ; ; ")
                intDeductionsCount = intDeductionsCount + 1
            Next
        Else
            Dim n As Integer = 0
            For n = (intEarningsCount + 1) To intDeductionsCount
                arrEarningsLine.Add(" ; ; ; ")
                intEarningsCount = intEarningsCount + 1
            Next
        End If
        For nz = 0 To intDeductionsCount - 1
            strNewPrintDetails.Add(arrEarningsLine(nz) & ";" & arrDeductionsLine(nz) & "; ")
        Next nz

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Summary Details Spooling"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function GetGroupKey(EmployeeNumber As String, Grouping As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim strSql As String = Nothing

        Select Case UCase(Grouping)
            Case Is = UCase("Employee Number")
                strReturn = EmployeeNumber
                Exit Function
            Case Is = UCase("Surname")
                strSql = "SELECT LastName +' '+ OtherNames FROM EmployeeMaster WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Is = UCase("Department")
                strSql = "SELECT Department FROM Employment WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Is = UCase("Cost Center")
                strSql = "SELECT CostCenter FROM Employment WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Is = UCase("Pay Point")
                strSql = "SELECT PayPoint FROM Employment WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Else
                strReturn = EmployeeNumber
                Exit Function
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                strReturn = objReader(0).ToString
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On payroll report print"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Function

    Public Sub PrintBankSchedules()
        'Will print the bank schedules in the order of banks
        '***************************************************************************************************
        'LOGIC
        '
        'Get the bank file information, the bankcode, name and address
        'Get all the employees with the bank status on and put them in an array sorted by bank code
        'Build a new array list containg the bank code, bank name, employee names, account number and net salary
        '
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Get all the employees with the bank status set to 
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT EmployeeBanks.EmployeeNo, " _
            & "EmployeeMaster.LastName, EmployeeMaster.Inits, EmployeeBanks.BankCode, " _
            & "SystemBanks.BankName, SystemBanks.Address1, SystemBanks.Address2, " _
            & "SystemBanks.Address3, SystemBanks.Address4, EmployeeBanks.AccountNumber, " _
            & "EmployeeBanks.PayMethod  FROM EmployeeBanks LEFT JOIN EmployeeMaster ON " _
            & "EmployeeBanks.EmployeeNo = EmployeeMaster.EmployeeNo LEFT JOIN SystemBanks " _
            & "ON CONVERT(INT, EmployeeBanks.BankCode ) = CONVERT(INT, SystemBanks.BankCode) " _
            & "WHERE PayMethod = 'BANK' AND EmployeeMaster.Status = 'ACTIVE' " _
            & "ORDER BY EmployeeBanks.BankCode", cnn)
        objReader = objCommand.ExecuteReader

        'Get the key data fields to get the net salary code

        gwt_comm.GetKeyDataFields()

        Dim arrBankSchedule As New ArrayList
        Dim i As Integer
        Dim intCounter As Integer = 1
        Dim strBankCode As String = Nothing
        '
        'Build the ouput string to be handled by the reporting class
        '
        Dim strKeyBreak As String = Nothing
        Dim dblTransferTotal As Double = 0
        While objReader.Read
            Dim strEcNum As String = Nothing
            Dim strEmpSurnames As String = Nothing
            Dim strEmpInitials As String = Nothing
            Dim strBankName As String = Nothing
            Dim strBankAddress1 As String = Nothing
            Dim strBankAddress2 As String = Nothing
            Dim strBankAddress3 As String = Nothing
            Dim strBankAddress4 As String = Nothing
            Dim strEmpAccountNumber As String = Nothing
            Dim dblNetSalary As Double = 0
            If Not IsDBNull(objReader("EmployeeNo").ToString) Then strEcNum = objReader("EmployeeNo").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then strEmpSurnames = objReader("LastName").ToString
            If Not IsDBNull(objReader("Inits").ToString) Then strEmpInitials = objReader("Inits").ToString
            If Not IsDBNull(objReader("BankCode").ToString) Then strBankCode = objReader("BankCode").ToString Else strBankCode = Nothing
            If Not IsDBNull(objReader("BankName").ToString) Then strBankName = objReader("BankName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then strBankAddress1 = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then strBankAddress2 = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then strBankAddress3 = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then strBankAddress4 = objReader("Address4").ToString
            If Not IsDBNull(objReader("AccountNumber").ToString) Then strEmpAccountNumber = objReader("AccountNumber").ToString
            '
            'Get the employee net salary from the run file
            '
            Dim objCommandNet As New Data.OleDb.OleDbCommand("SELECT RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = '" & strEcNum & "'", cnn)
            Dim objReadNet As Data.OleDb.OleDbDataReader = objCommandNet.ExecuteReader
            If objReadNet.HasRows Then
                objReadNet.Read()
                Dim strBuffer() As String = Split(objReadNet(0).ToString, "|")
                If IsNumeric(strBuffer(intPayrollNetIncomeCode - 1)) Then
                    dblNetSalary = CDbl(strBuffer(intPayrollNetIncomeCode - 1))
                End If
                If dblNetSalary > 0 Then
                    'Check that the string break is different or not
                    If strKeyBreak <> strBankCode Then
                        If dblTransferTotal > 0 Then
                            arrBankSchedule.Add(" ; ; ; ; ; ;" & strKeyBreak)
                            arrBankSchedule.Add(" ;TOTAL TRANSFERED; ; ;" & Format(dblTransferTotal, "#,##0.00") & "; ;" & strKeyBreak)
                        End If
                        strKeyBreak = strBankCode
                        dblTransferTotal = 0
                        intCounter = 1
                        'Write the header lines before writing the details
                        arrBankSchedule.Add(" ;" & strBankCode & " " & strBankName & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress1 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress2 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress3 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress4 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        'Print the column headers
                        arrBankSchedule.Add("EC NO.;SURNAME;INITS;ACCOUNT NO.;NET SALARY;REC.NO.;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        'Print the first detail line
                        arrBankSchedule.Add(strEcNum & ";" & strEmpSurnames & ";" & strEmpInitials & ";" & strEmpAccountNumber & ";" & Format(dblNetSalary, "#,##0.00") & ";" & Format(intCounter, "0000") & ";" & strBankCode)

                        dblTransferTotal = dblTransferTotal + dblNetSalary
                    Else
                        arrBankSchedule.Add(strEcNum & ";" & strEmpSurnames & ";" & strEmpInitials & ";" & strEmpAccountNumber & ";" & Format(dblNetSalary, "#,##0.00") & ";" & Format(intCounter, "0000") & ";" & strBankCode)
                        dblTransferTotal = dblTransferTotal + dblNetSalary
                        intCounter = intCounter + 1
                    End If
                End If
            End If
        End While
        '
        'At the end, add the total line for the last branch code
        If dblTransferTotal > 0 Then
            arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
            arrBankSchedule.Add(" ;TOTAL TRANSFERED; ; ;" & Format(dblTransferTotal, "#,##0.00") & "; ;" & strBankCode)
        End If
        objReader.Close()

        '
        'Send the details for printing
        '
        Dim strTransferDetails(0 To arrBankSchedule.Count - 1) As String
        For i = 0 To arrBankSchedule.Count - 1
            strTransferDetails(i) = arrBankSchedule.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .NewPageBreak = True
            .intPrintRecordsCount = strTransferDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = " | | | | | | "
            .strColumnAlignments = "0|0|0|0|2|0|0"
            .strColumnWidths = "80|200|40|80|80|40|80"
            .strFooterCaption = "Bank transfer schedule " & Now
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "BANK TRANSFER SCHEDULES: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strMainHeader3 = "TRANSFER EFFECTIVE ON " & UCase(gwt_comm.shortMonthDateFormat(CDate(dtSetDate)))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .boolGroupDetails = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 6
            .strPrintValues = strTransferDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        ppd.Document = rpt
        ppd.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Bank Transfer Schedules Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub PrintAuditReport()
        On Error GoTo RaiseErr
        'Check that the variables are correctly set
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If UCase(strSelectedValue) = "ALL" Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, " _
                & "ChangeDate, 105) as [ChangeDate], UserNAme, ElementId, ValueBefore, " _
                & "ValueAfter FROM Audit ORDER BY TransactionId", cnn)
        Else
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, " _
                & "ChangeDate, 105) as [ChangeDate], UserNAme, ElementId, ValueBefore, " _
                & "ValueAfter FROM Audit WHERE ChangeDate BETWEEN '" & strReportStartDate & "' " _
                & "AND '" & strReportEndDate & "' ORDER BY TransactionId", cnn)
        End If
        objReader = objCommand.ExecuteReader

        Dim arrPrintResults As New ArrayList
        While objReader.Read
            Dim str1 As String = Nothing, str2 As String = Nothing, str3 As String = Nothing
            Dim str4 As String = Nothing, str5 As String = Nothing
            If Not IsDBNull(objReader(0).ToString) Then str1 = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then str2 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then str3 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then str4 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then str5 = objReader(4).ToString
            arrPrintResults.Add(str1 & ";" & str2 & ";" & str3 & ";" & str4 & ";" & str5)
        End While
        objReader.Close()

        Dim strPrintValues(0 To arrPrintResults.Count - 1) As String

        For i = 0 To arrPrintResults.Count - 1
            strPrintValues(i) = arrPrintResults.Item(i)
        Next

        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog

        'Build the print details string based on the checked fields
        'For each column value, remove the semicolon so that the class does not fall over
        With Me.pb1
            .Visible = True
            .Value = 0
            .Maximum = strPrintValues.Length
        End With
        'lblStatus.Text = "Processing Report. Please Wait !!!"

        Cursor = Cursors.WaitCursor

        Me.pb1.Value = Me.pb1.Maximum
        With myReport
            .intNumberOfColumns = 5
            .intPrintRecordsCount = strPrintValues.Length   'Or number of records in the text file
            .strColumnAlignments = "0|0|0|0|0"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strColumnHeaders = "DATE|OPERATOR|DESCRIPTION|BEFORE|AFTER"
            .strColumnWidths = "80|80|150|150|150"
            .strColumnTotals = "NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .boolPrintTotals = boolPrintFinalTotals
            .BorderColor = Color.FromName("LightGray")
            .GridColor = Color.FromName("LightGray")
            .strPrintValues = strPrintValues
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "AUDIT REPORT PRINT: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber
            If UCase(strSelectedValue) = "ALL" Then
                .strMainHeader3 = "ALL RECORDS PRINT"
            Else
                .strMainHeader3 = "SELECTED RANGE FROM " & strReportStartDate & " TO " & strReportEndDate
            End If
            .strFooterCaption = "Audit Trail Print"
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
        End With
        Me.pb1.Visible = False
        Cursor = Cursors.Default
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        DocumentPreview.Document = myReport
        DocumentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Audit Report Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        Dim frm As New frmOrganisation
        frm.ShowDialog()
    End Sub

    Private Sub pdSmallPayslips_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdSmallPayslips.PrintPage

    End Sub

    Private Sub btnCalendar_Click(sender As System.Object, e As System.EventArgs) Handles btnCalendar.Click
        Dim frm As New frmCalendarSetup
        frm.ShowDialog()
    End Sub

End Class