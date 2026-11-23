Imports System.Threading
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.IO
Imports System.Security.Cryptography

Public Class frmLight8

    Dim strCurrentProcessingEmployee As String

    Dim dGridTransactions As AdvancedDataGridViewControl.AdvancedDatagridview
    Dim intPayslipFormat As Integer
    Dim fntPrintFont As New Font("Arial", 7, FontStyle.Regular)
    Dim titleFont As New Font("Arial", 8, FontStyle.Bold)
    Public HeadingFont As New Font("Arial", 12, FontStyle.Bold)
    Dim fntSmallPrintFont As New Font("Arial", 7, FontStyle.Bold)
    Dim fntSmallPrintFontRegular As New Font("Arial", 7, FontStyle.Regular)
    Dim SubHeadingFont As New Font("Arial", 7, FontStyle.Bold)
    Dim fntFooter As New Font("Arial", 6, FontStyle.Bold)
    'our user defined report has six columns in each page which are declared here
    Dim X1, X2, X3, X4, X5, X6 As Integer
    Dim W1, W2, W3, W4, W5, W6 As Integer
    Dim Y As Integer
    Public itm As Integer = 0
    Dim nz As Integer 'item line counter
    Dim strPayslipColumnType As String
    Dim sPayslipLineText() As String
    Dim strSummaryColumnType As String
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

    Dim strNewPrintDetails As New ArrayList
    Dim strMyNewPrintLine As String

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

    Dim boolStartPrint As Boolean
    Dim intPrintRecordsCount As Integer
    Dim strEmployeeFields As New ArrayList
    Dim strBankDetails As New ArrayList
    Dim strKeyBreak As String
    Dim strBnkSortCode() As String

    Dim strFinalPrintLine As ArrayList 'The record lines from which the payroll summary prints from
    Dim strDetailPrintLine() As String 'Used to split the print details line
    Dim strEmployeeIdentificationLine As String
    Dim boolOne As Boolean

    Dim dblTransferAmount As Double
    Dim strPrintDetails As New ArrayList
    Dim strBatchPrintArray As ArrayList

    Dim intBatchLineCount As Integer
    Dim strBatchPrintDetails() As String

    Dim xp As PrintPreviewDialog


    'new brainco reporter variables

    Dim strPrintColumns As String = Nothing
    Dim strColumnHeaders As String = Nothing
    Dim strColumnSizes As String = Nothing
    Dim strColumnFormating As String = Nothing
    Dim strColumnAlignment As String = Nothing
    Dim strColumnTotals As String = Nothing
    Dim intColumns As Integer = 0

    'Declare and set the default fonts
    'Dim fntHeaderFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    'Dim fntDetailsFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    'Dim fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim strHeaderFontName As String = "Arial"
    Dim strFooterFontName As String = "Arial"
    Dim strDetailFontName As String = "Arial"

    Dim intHeaderFontSize As Integer = 8
    Dim intFooterFontSize As Integer = 6
    Dim intDetailFontSize As Integer = 8

    Dim strHeaderFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strFooterFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strDetailFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 6, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"

    Dim strFooterForeColor As String = "Black"
    Dim strHeaderForeColor As String = "Black"
    Dim strDetailForeColor As String = "Black"

    Dim strGridLinesColor As String = "Black"
    Dim boolVerticalLines As Boolean = False
    Dim boolHorizontalLines As Boolean = False

    Dim boolPrintSummary As Boolean = False
    Dim boolDrawGraph As Boolean = False
    Dim boolPrintFinalTotals As Boolean = False

    Dim boolGroupData As Boolean = False
    Dim intBreakIndex As Integer = -1
    Dim strHighlights As String = Nothing
    Dim strPrintBorder As String = "False"
    Dim boolPrintBorder As Boolean = False
    Dim strBorderColor As String = "Black"
    Dim boolPreviewReport As Boolean
    Dim fntFinePrintFont As New Font("Verdana", 6, FontStyle.Regular)

    '------------------------------------------------------------------

    Private strFormat As StringFormat  'Used to format the grid rows.  
    Private arrColumnLefts As New ArrayList()  'Used to save left coordinates of columns  
    Private arrColumnWidths As New ArrayList()  'Used to save column widths  
    Private iCellHeight As Integer = 0  'Used to get/set the datagridview cell height  
    Private iTotalWidth As Integer = 0  '  
    Private iRow As Integer = 0  'Used as counter  
    Private bFirstPage As Boolean = False  'Used to check whether we are printing first page  
    Private bNewPage As Boolean = False  ' Used to check whether we are printing a new page  
    Private iHeaderHeight As Integer = 0  'Used for the header height  

    Dim arrReportItems As ArrayList
    Dim strSelectedReport As String
    Dim _originalSplitterDistance As Integer
    Dim _CurrentSplitterDistance As Integer

    Dim boolFormLoading As Boolean
    Dim strReportHeader As String


    Private Declare Function FindWindow _
        Lib "user32" Alias "FindWindowA" _
        (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

    Private Declare Function SetParent _
        Lib "user32" (ByVal nWndChild As Long,
        ByVal nWndNewParent As Long) As Long

    Private Declare Function ShellExecute _
        Lib "shell32.dll" Alias "ShellExecuteA" _
        (ByVal hwnd As Long, ByVal lpOperation As String,
         ByVal lpFile As String, ByVal lpParameters As String,
         ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

    Private Declare Function MoveWindow _
        Lib "user32" (ByVal hwnd As Long,
                      ByVal x As Long, ByVal y As Long,
                      ByVal nWidth As Long, ByVal nHeight As Long,
                      ByVal bRepaint As Long) As Long

    Private Const SW_SHOWNORMAL = 1

    Dim rs As New Resizer
    Dim intPriorSplitterDistance As Integer
    Dim arrMenus As ArrayList

    Dim objMenuFile As StreamWriter
    Dim strRootName As String = Nothing
    '
    'The messages to look for.
    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004
    Private Const DBT_DEVTYP_VOLUME As Integer = &H2  '
    '
    'Get the information about the detected volume.
    Private Structure DEV_BROADCAST_VOLUME

        Dim Dbcv_Size As Integer

        Dim Dbcv_Devicetype As Integer

        Dim Dbcv_Reserved As Integer

        Dim Dbcv_Unitmask As Integer

        Dim Dbcv_Flags As Short
        ' mwanangu

    End Structure

    Protected Overrides Sub WndProc(ByRef M As System.Windows.Forms.Message)
        '
        'These are the required subclassing codes for detecting device based removal and arrival.
        '
        If M.Msg = WM_DEVICECHANGE Then
            Select Case M.WParam
                '
                'Check if a device was added.
                Case DBT_DEVICEARRIVAL
                    Dim DevType As Integer = Runtime.InteropServices.Marshal.ReadInt32(M.LParam, 4)
                    If DevType = DBT_DEVTYP_VOLUME Then
                        Dim Vol As New DEV_BROADCAST_VOLUME
                        Vol = Runtime.InteropServices.Marshal.PtrToStructure(M.LParam, GetType(DEV_BROADCAST_VOLUME))
                        If Vol.Dbcv_Flags = 0 Then
                            For i As Integer = 0 To 20
                                If Math.Pow(2, i) = Vol.Dbcv_Unitmask Then
                                    Dim Usb As String = Chr(65 + i) + ":\"
                                    If MessageBox.Show("Looks like a USB device was plugged in!" &
                                           vbNewLine & "The drive letter is: " & Usb.ToString & vbCrLf _
                                           & "Do you want to make copy of the system to this device?",
                                           "USB Device Plugged In", MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        strAutoBackupName = cnn.Database & "_" & Format(Now, "ddMMyy") & "_" &
                                            Format(DatePart(DateInterval.Hour, Now), "00") &
                                            Format(DatePart(DateInterval.Minute, Now), "00") &
                                            Format(DatePart(DateInterval.Second, Now), "00") & ".BAK"
                                        strAutoBackupPath = Usb & "FltBackups\"
                                        gwt_comm.BackupDatabase()
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    '
                    'Check if the message was for the removal of a device.
                Case DBT_DEVICEREMOVECOMPLETE
                    Dim DevType As Integer = Runtime.InteropServices.Marshal.ReadInt32(M.LParam, 4)
                    If DevType = DBT_DEVTYP_VOLUME Then
                        Dim Vol As New DEV_BROADCAST_VOLUME
                        Vol = Runtime.InteropServices.Marshal.PtrToStructure(M.LParam, GetType(DEV_BROADCAST_VOLUME))
                        If Vol.Dbcv_Flags = 0 Then
                            For i As Integer = 0 To 20
                                If Math.Pow(2, i) = Vol.Dbcv_Unitmask Then
                                    Dim Usb As String = Chr(65 + i) + ":\"
                                    MessageBox.Show("Looks like a volume device was removed!" &
                                       vbNewLine & vbNewLine & "The drive letter is: " & Usb.ToString,
                                       "USB Device Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit For
                                End If
                            Next
                        End If
                    End If
            End Select
        End If
        MyBase.WndProc(M)

    End Sub

    Private Sub frmLight8_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        'DisableAllModules()

        Dim frm As Form
        If File.Exists(Application.StartupPath & "\gwtlk") = False Then
            boolRegistrationSuccessfull = False
            frm = New frmApplicationActivation
            frm.ShowDialog()
            If boolRegistrationSuccessfull = False Then End
        Else
            boolAbort = False
            frm = New frmLogin
            frm.ShowDialog()
            If boolAbort = True Then
                Settings.Visible = True
                Exit Sub
            End If
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckTableExistence("SystemKeyCurrencyRates") = True Then
            If gwt_comm.CheckColumnExistence("SystemKeyCurrencyRates", "SwipeRate") = False Then
                strSql = "ALTER TABLE SystemKeyCurrencyRates ADD [SwipeRate][FLOAT] NOT NULL DEFAULT 0"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        If gwt_comm.CheckTableExistence("SystemKeyCurrencyRates") = True Then
            If gwt_comm.CheckColumnExistence("SystemKeyCurrencyRates", "EcocashRate") = False Then
                strSql = "ALTER TABLE SystemKeyCurrencyRates ADD [EcocashRate][FLOAT] NOT NULL DEFAULT 0"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        ', EcocashRate, SwipeRate
        If gwt_comm.CheckTableExistence("SalesMain") = True Then
            If gwt_comm.CheckColumnExistence("SalesMain", "EcocashRate") = False Then 'EcocashRate'. 
                strSql = "ALTER TABLE SalesMain ADD [EcocashRate][FLOAT] NOT NULL DEFAULT 0"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        If gwt_comm.CheckTableExistence("SalesMain") = True Then
            If gwt_comm.CheckColumnExistence("SalesMain", "SwipeRate") = False Then
                strSql = "ALTER TABLE SalesMain ADD [SwipeRate][FLOAT] NOT NULL DEFAULT 0"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        CheckSynchronisationStatus()

        ActivateModules()

        HRManagement.Enabled = True
        HRManagement.Visible = True
        btnPayroll.Enabled = True
        btnPayrollParameters.Enabled = True

        'Load the purchasing module

        LoadSuppliers()
        LoadReceiving()
        LoadCustomers()

        If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
            btnAdministration.Enabled = True
        End If

        HomePageUserPreferences()
        lblAccountsStatus.Text = strAccountSettingStatus
        Me.Text = Me.Text & " [" & strCompanyName & "]"
        lblDb.Text = UCase(Mid(cnn.Database, 1, 1)) & LCase(Mid(cnn.Database, 2, cnn.Database.Length - 1))
        'HRManagement.Visible = False

        If UCase(strUserLevel) = UCase("cashier") Then
            Me.Hide()
            frm = New frmPosMain2
            frm.ShowDialog()
            End
        End If
    End Sub

    Private Sub CheckSynchronisationStatus()
        If UCase(strUserLevel) = UCase("MANAGER") Or UCase(strUserLevel) = "ADMINISTRATOR" Then
            Dim f As New frmDatabaseSynchronization
            f.ShowDialog()
        Else
            gwt_comm.DenyAccess()
            Exit Sub
        End If
    End Sub

    Private Sub LoadCustomers()
        Dim frm As New frmCustomersListing
        tabDebtors.Tabs.Clear()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabDebtors, CurrentTabColor)
    End Sub

    Private Sub LoadSuppliers()
        Dim frm As New frmSupplierListing
        tabCreditors.Tabs.Clear()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabCreditors, CurrentTabColor)
    End Sub

    Private Sub LoadReceiving()
        tabPurchasing.Tabs.Clear()

        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor

        ' Add the orders listing 
        '
        Dim frmO As New frmOrdersListing
        CurrentTabColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frmO, tabPurchasing, CurrentTabColor)

        ' Add the inventory receipt
        '
        Dim frm As New frmInventoryReceiving
        CurrentTabColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        AddTabbedForm(frm, tabPurchasing, CurrentTabColor)
        tabPurchasing.SelectedTabIndex = 0

    End Sub

    Private Sub tabPurchasing_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabPurchasing.TabItemClose
        If UCase(e.Tab.Text) = UCase("Goods In") Or
            UCase(e.Tab.Text) = UCase("Orders") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub tabDebtors_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabDebtors.TabItemClose
        If UCase(e.Tab.Text) = UCase("Customers") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub HomePageUserPreferences()
        On Error GoTo RaiseErr

        Dim strSql As String = "IF OBJECT_ID(N'SystemHomePageModules', N'U') IS NULL " _
            & "CREATE TABLE SystemHomePageModules ([ModuleName][NVARCHAR](350) NOT NULL DEFAULT '', " _
            & "[UserName][NVARCHAR](150) NOT NULL REFERENCES Users (UserName), " _
            & "[TransactionId][INT] Not NULL PRIMARY KEY IDENTITY (1,1))"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'metInventory.Visible = False ' inventory Management
        'metPos.Visible = False       'Point of Sale
        'mtOrders.Visible = False     'Purchases And Orders
        'metCashbook.Visible = False  'Cashbook
        'mtLoans.Visible = False      'Loan Manager
        'metAccounts.Visible = False  'Accounts
        'metInvoice.Visible = False   'Invoicing
        'metSchoola.Visible = False   'Scholastica
        'mtProjects.Visible = False   'Projects
        'mtAssets.Visible = False     'Asset Management
        'metPersonnel.Visible = False 'Employee Management
        'metPayroll.Visible = False   'Payroll
        'mtDebtCollection.Visible = False     'Debt Collection
        'mtDoctors.Visible = False    'Patient Management
        'mtDispensing.Visible = False
        'mtnHotels.Visible = False
        'mtrCrm.Visible = False

        'Get the user preferences
        objCommand = New Data.OleDb.OleDbCommand("SELECT ModuleName FROM SystemHomePageModules " _
            & "WHERE UserName = '" & strUserName & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0)) Then
                Select Case UCase(objReader(0).ToString)
                    Case Is = UCase("Inventory Management")
                        'metInventory.Visible = True
                        'metInventory.Enabled = True
                    Case Is = UCase("Point of Sale")
                        'metPos.Visible = True
                        'metPos.Enabled = True
                    Case Is = UCase("Purchases And Orders")
                        'mtOrders.Visible = True
                        'mtOrders.Enabled = True
                    Case Is = UCase("Cashbook")
                        'metCashbook.Visible = True
                        'metCashbook.Enabled = True
                    Case Is = UCase("Loan Manager")
                        'mtLoans.Visible = True
                        'mtLoans.Enabled = True
                    Case Is = UCase("General Ledger Accounts")
                        'metAccounts.Visible = True
                        'metAccounts.Enabled = True
                    Case Is = UCase("Invoicing")
                        'metInvoice.Visible = True
                        'metInvoice.Enabled = True
                    Case Is = UCase("Scholastica")
                        'metSchoola.Visible = True
                        'metSchoola.Enabled = True
                    Case Is = UCase("Projects")
                        'mtProjects.Visible = True
                        'mtProjects.Enabled = True
                    Case Is = UCase("Asset Management")
                        'mtAssets.Visible = True
                        'mtAssets.Enabled = True
                    Case Is = UCase("Employee Management")
                        'metPersonnel.Visible = True
                        'metPersonnel.Enabled = True
                    Case Is = UCase("Payroll")
                        'metPayroll.Visible = True
                        'metPayroll.Enabled = True
                    Case Is = UCase("Debt Collection")
                        'mtDebtCollection.Visible = True
                        'mtDebtCollection.Enabled = True
                    Case Is = UCase("Patient Management")
                        'mtDoctors.Visible = True
                        'mtDoctors.Enabled = True
                    Case Is = UCase("Medicines Dispensing")
                        'mtDispensing.Visible = True
                        'mtDispensing.Enabled = True
                    Case Is = UCase("Hotel Management")
                        'mtnHotels.Visible = True
                        'mtnHotels.Enabled = True
                    Case Is = UCase("Customer Relations Management")
                        'mtrCrm.Visible = True
                        'mtrCrm.Enabled = True
                End Select
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Home page preferences activation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function StringToBytes(ByVal str As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function

    Private Sub ActivateModules()
        'On Error GoTo RaiseErr
        Dim intOneActive As Integer = 0
        If File.Exists(Application.StartupPath & "\gwtlk") Then
            Dim objFileReader As New System.IO.StreamReader(Application.StartupPath & "\gwtlk")
            Dim strData As String = objFileReader.ReadLine
            objFileReader.Close()

            Dim strActiveModules As String = EncryptDecryptData.SSTCryptographer.Decrypt(strData, "greatwits")

            Dim strBuffer() As String = Split(strActiveModules, "-")
            For p As Integer = 0 To strBuffer.Length - 1
                Select Case UCase(strBuffer(p))
                    Case Is = "01" 'Invoicing
                        Sales.Visible = True
                        With Accounts
                            .Enabled = True
                            .Visible = True
                            btnInvoicing.Enabled = True
                            btnCrm.Enabled = True
                        End With

                        HRManagement.Enabled = True
                        HRManagement.Visible = True
                        btnPayroll.Enabled = True
                        btnPayrollParameters.Enabled = True

                        'metInvoice.Enabled = True
                        intOneActive = 1
                    Case Is = "02" 'Point of Sale
                        Sales.Visible = True
                        With btnPos
                            .Enabled = True
                            .Visible = True
                        End With
                        'metPos.Enabled = True
                        'btnAdministration.Enabled = True
                        intOneActive = 1
                    Case Is = "03" 'Inventory
                        With Inventory
                            .Visible = True
                            .Enabled = True
                            btnInventory.Enabled = True
                        End With
                        'metInventory.Enabled = True
                        intOneActive = 1
                    Case Is = "04" 'Purchasing
                        With Inventory
                            .Visible = True
                            .Enabled = True
                            'btnReceiveInventory.Enabled = True
                        End With
                        intOneActive = 1
                    Case Is = "05" 'Payroll
                        HRManagement.Enabled = True
                        HRManagement.Visible = True
                        btnPayroll.Enabled = True
                        btnPayrollParameters.Enabled = True
                        intOneActive = 1
                        'metPayroll.Enabled = True
                    Case Is = "06" 'Projects Manager
                        With Accounts
                            .Enabled = True
                            .Visible = True
                            btnProjects.Enabled = True
                            intOneActive = 1
                        End With
                    Case Is = "07" 'Financials
                        With Accounts
                            .Enabled = True
                            .Visible = True
                            btnLedgers.Enabled = True
                            btnCashbooks.Enabled = True
                            btnChartOfAccounts.Enabled = True
                            btnBudgets.Enabled = True
                            btnLoans.Enabled = True
                            btnAssets.Enabled = True
                            intOneActive = 1
                        End With
                        'metCashbook.Enabled = True
                        'metAccounts.Enabled = True
                    Case Is = "08" 'Legal Practice
                        'With LegalPractice
                        '    .Enabled = True
                        '    .Visible = True
                        btnLegalPractice.Enabled = True
                        intOneActive = 1
                        'End With
                    Case Is = "09" 'Debt Collection
                        'With LegalPractice
                        '.Enabled = True
                        '.Visible = True
                        btnDebtCollection.Enabled = True
                        intOneActive = 1
                        'End With
                    Case Is = "10" 'Medi-light
                        'With HealthServices
                        '    .Enabled = True
                        '    .Visible = True
                        'btnPharmacy.Enabled = True
                        intOneActive = 1
                        'End With
                    Case Is = "11" 'Ochmas
                        'With HealthServices
                        '    .Enabled = True
                        '    .Visible = True
                        'btnPatients.Enabled = True
                        intOneActive = 1
                        'End With
                    Case Is = "12" 'Scholastica
                        'With Scholastica
                        '    .Enabled = True
                        '    .Visible = True
                        btnScholastica.Enabled = True
                        '    intOneActive = 1
                        'End With
                        'metSchoola.Enabled = True
                    Case Is = "13" 'corperatives
                        With btnCorps
                            .Enabled = True
                            .Visible = True
                            intOneActive = 1
                        End With
                    Case Is = "14" 'Library Manager
                        'With Scholastica
                        '    .Enabled = True
                        '    .Visible = True
                        btnLibrary.Enabled = True
                        '    intOneActive = 1
                        'End With
                    Case Is = "15" 'Human Resources Management
                        HRManagement.Enabled = True
                        HRManagement.Visible = True
                        btnPersonnelManagement.Enabled = True
                        'btnTraining.Enabled = True
                        'btnIR.Enabled = True
                        'btnPerformanceManagement.Enabled = True
                        intOneActive = 1
                        'metPersonnel.Enabled = True
                    Case Is = "16" 'MOC and Corp Light
                        'With LegalPractice
                        '    .Enabled = True
                        '    .Visible = True
                        btnMoc.Enabled = True
                        intOneActive = 1
                        'End With
                End Select
            Next
            If intOneActive > 0 Then
                With Settings
                    .Enabled = True
                    .Visible = True
                    EnableUtilityButtons()
                End With
            End If
        Else
            MessageBox.Show("Application has not been properly licensed." & vbCrLf &
                "Contact your software consultant for assistance",
                "Application Registration Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
        End If

        Me.Refresh()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & "On Application Modules Activation"
        ShowErrorMessage()
    End Sub

    Private Sub ApplicationStartError()
        MessageBox.Show("The called module is not licensed on your computer" & vbCrLf &
            "Please contact your software provider for assistance", "Application Licensing Error",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function ApplicationIsLicensed(ByVal FileName As String) As Boolean
        Dim boolReturn As Boolean = False
        If System.IO.File.Exists(FileName) Then
            boolReturn = True
        End If
        Return boolReturn
    End Function

    Private Sub DisableAllModules()
        'Home.Visible = True
        'tabInventory.Visible = False
        'tabInventory.Tabs.RemoveAt(0)

        'tabHr.Visible = False
        'tabHr.Tabs.RemoveAt(0)

        Accounts.Visible = False
        Inventory.Visible = False
        HRManagement.Visible = False
        'LegalPractice.Visible = False
        'HealthServices.Visible = False
        'Scholastica.Visible = False
        btnPos.Visible = False
        btnPropertyManager.Visible = False
        btnCorps.Visible = False
        Sales.Visible = False
        btnFundManager.Visible = False
        Settings.Visible = False
    End Sub

    Private Sub EnableUtilityButtons()

        btnBackups.Enabled = True
        btnSms.Enabled = True
        btnEmail.Enabled = True
        btnLightSpreadsheet.Enabled = True
        btnInternetBrowser.Enabled = True
        btnQueryBuilder.Enabled = True
        btnSynchronizeData.Enabled = True
        btnOrganisation.Enabled = True
        btnDataTransfer.Enabled = True
        'btnAdministration.Enabled = True
        btnRestore.Enabled = True

    End Sub

    'Private Sub ButtonItem3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem3.Click
    '    LoadLedgers()
    'End Sub

    Private Sub LoadLedgers()
        'Cursor = Cursors.WaitCursor
        'If System.IO.File.Exists(Application.StartupPath & "\gwtAccounting.dll") Then
        '    Dim obj As New gwtAccounting.Accounting
        '    obj.Activate(strConnection)
        '    obj = Nothing
        'Else
        '    MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        'Cursor = Cursors.Default
    End Sub

    'Private Sub btnCashbooks_Click(sender As System.Object, e As System.EventArgs) Handles btnCashbooks.Click
    '    LoadCashbooks()
    'End Sub

    'Private Sub LoadCashbooks()
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\gwtCashbook.dll") Then
    '        Dim obj As New gwtCashbook.Cashbook
    '        obj.Activate(strConnection)
    '        obj = Nothing
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub btnInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnInventory.Click
        LoadInventory()
    End Sub

    Private Sub btnDebtCollection_Click(sender As System.Object, e As System.EventArgs) Handles btnDebtCollection.Click
        LoadDebtCollection()
    End Sub

    Private Sub LoadDebtCollection()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\DebtCollector.dll") Then
            Dim obj As New DebtCollector.DebtCollection
            obj.Activate(strConnection)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
                "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        LoadOrganisation()
    End Sub

    Private Sub LoadOrganisation()
        Dim frm As New frmOrganisation
        frm.ShowDialog()
    End Sub

    Private Sub btnBackups_Click(sender As System.Object, e As System.EventArgs) Handles btnBackups.Click
        gwt_comm.BackupDatabase()
    End Sub

    Private Sub btnSynchronizeData_Click(sender As System.Object, e As System.EventArgs) Handles btnSynchronizeData.Click
        Dim frm As New frmDatabaseSynchronization
        frm.ShowDialog()
    End Sub

    Private Sub btnDataTransfer_Click(sender As System.Object, e As System.EventArgs) Handles btnDataTransfer.Click
        Dim frm As New frmDatabaseDataInterchange
        frm.ShowDialog()
    End Sub

    Private Sub btnAdministration_Click(sender As System.Object, e As System.EventArgs) Handles btnAdministration.Click
        LoadAdministration()
    End Sub

    Private Sub LoadAdministration()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\gwtAdministration.dll") Then
            Dim obj As New gwtAdministration.AdministrationTools
            obj.Activate(strConnection)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    'Private Sub btnReceiveInventory_Click(sender As System.Object, e As System.EventArgs)
    '    LoadOrders()
    'End Sub

    Private Sub LoadOrders()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\LightPurchasing.dll") Then
            Dim obj As New LightPurchasing.Purchasing
            obj.Activate(strConnection)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnScholastica_Click(sender As System.Object, e As System.EventArgs) Handles btnScholastica.Click
        LoadScholastica()
    End Sub

    Private Sub LoadScholastica()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\Scholastica.exe") Then
            Shell(Application.StartupPath & "\Scholastica.exe", AppWinStyle.NormalFocus, True, 0)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnProjects_Click(sender As System.Object, e As System.EventArgs) Handles btnProjects.Click
        LoadProjects()
    End Sub

    Private Sub LoadProjects()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\ProjectLight.dll") Then
            Dim obj As New ProjectLight.Projects
            obj.Activate(strConnection)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
                "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    'Private Sub btnAssets_Click(sender As System.Object, e As System.EventArgs) Handles btnAssets.Click
    '    LoadAssets()
    'End Sub

    'Private Sub LoadAssets()
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\gwtAssets.dll") Then
    '        Dim obj As New gwtAssets.AssetManagement
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub btnRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnRestore.Click
        gwt_comm.RestoreDatabase()
    End Sub

    ' ho borrowdale sam levy left zuva after robots right turn to banks 2nd right turn into iona close #2

    'Private Sub LoadPos()
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\pos.dll") Then
    '        Dim obj As New POS.pos
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub btnPersonnelManagement_Click(sender As System.Object, e As System.EventArgs) Handles btnPersonnelManagement.Click
    '    LoadPersonnel()
    'End Sub
    'Private Sub LoadPersonnel()
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\gwtEmployees.dll") Then
    '        Dim obj As New gwtEmployees.Employees
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub btnPayrollParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnPayrollParameters.Click
        LoadPayrollParameters()
    End Sub

    Private Sub LoadPayrollParameters()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\gwtprconfig.dll") Then
            Dim obj As New gwtprconfig.PayrollParameters
            obj.Activate(strConnection)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
                "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RunCorporatives()
        Cursor = Cursors.WaitCursor
        If System.IO.File.Exists(Application.StartupPath & "\CoopLight.dll") Then
            'Dim obj As New CoopLight.Coperatives
            'obj.Activate(strConnection)
        Else
            MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
                "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
    End Sub

    'Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
    '    LoadPayroll()
    'End Sub

    'Private Sub LoadPayroll()
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\PayLight.dll") Then
    '        Dim obj As New PayLight.Payroll
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub metAccounts_Click(sender As Object, e As EventArgs) Handles metAccounts.Click
    '    LoadAccounts()
    'End Sub

    Private Sub LoadAccounts()
        'Cursor = Cursors.WaitCursor
        'If System.IO.File.Exists(Application.StartupPath & "\gwtAccounting.dll") Then
        '    Dim obj As New gwtAccounting.Accounting
        '    obj.Activate(strConnection)
        '    obj = Nothing
        'Else
        '    MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''End If
        'Cursor = Cursors.Default
    End Sub

    'Private Sub metInventory_Click(sender As Object, e As EventArgs) Handles metInventory.Click
    '    LoadInventory()
    'End Sub

    Private Sub LoadInventory()
        Dim frm As New frmInventoryMaster
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabInventory, CurrentTabColor)
    End Sub

    'Private Sub metInvoice_Click(sender As Object, e As EventArgs) Handles metInvoice.Click
    '    LoadInvoices()
    'End Sub

    Private Sub LoadInvoices()
        'Cursor = Cursors.WaitCursor
        'If System.IO.File.Exists(Application.StartupPath & "\LightInvoice.dll") Then
        '    boolAbort = False
        '    Dim obj As New LightInvoice.Invoice
        '    obj.Activate(strConnection)
        '    obj = Nothing
        'Else
        '    MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        'Cursor = Cursors.Default
    End Sub

    'Private Sub metBackup_Click(sender As Object, e As EventArgs) Handles metBackup.Click
    '    gwt_comm.BackupDatabase()
    'End Sub

    'Private Sub metCashbook_Click(sender As Object, e As EventArgs) Handles metCashbook.Click
    '    LoadCashbook()
    'End Sub

    Private Sub LoadCashbook()
        'Cursor = Cursors.WaitCursor
        'If System.IO.File.Exists(Application.StartupPath & "\gwtCashbook.dll") Then
        '    Dim obj As New gwtCashbook.Cashbook
        '    obj.Activate(strConnection)
        '    obj = Nothing
        'Else
        '    MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub btnCreateDatabase_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateDatabase.Click
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

    'Private Sub metSchoola_Click(sender As Object, e As EventArgs) Handles metSchoola.Click
    '    LoadScholastica()
    'End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    '---------------------- REPORTING MODULES ------------------------------------

    Private Sub tvReports_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvReports.DoubleClick
        strReportHeader = UCase(tvReports.SelectedNode.Text)
        Cursor = Cursors.WaitCursor
        Select Case UCase(tvReports.SelectedNode.Text)
            Case Is = UCase("Received Inventory")
                boolAbort = False
                gwt_comm.DateRangeSpecification()
                If boolAbort = True Then Exit Sub
                PrintReceivedInventoryReport()
            Case Is = UCase("Inventory Sales History")
                'Dim f As New frmInventorySalesHistoryAnalysis
                'f.ShowDialog()
            Case Is = UCase("Daily Stores Reconciliation")
                'boolAbort = False
                'gwt_comm.DateRangeSpecification()
                'If boolAbort = True Then Exit Sub
                'gwt_comm.ShowStoresIssues()
            Case Is = "INVENTORY LIST"
                strReportHeader = tvReports.SelectedNode.Text
                InventoryListing()
            Case Is = UCase("Periodic Accounts Analysis")
                PrintPeriodicSalesAnalysis()
                'Case Is = UCase("Employee Full Masterfile")
                '    strReportHeader = tvReports.SelectedNode.Text
                '    PrintMasterFileData()
                'Case Is = "EXPENSES"
                '    strReportHeader = tvReports.SelectedNode.Text
                '    boolAbort = False
                '    Dim f As New frmExpensesParameters
                '    f.ShowDialog()
                '    If boolAbort = True Then Exit Sub
                '    LoadExpenses()
                '    AlternateColors()
            Case Is = "TRANSFERS"
                strReportHeader = tvReports.SelectedNode.Text
                PrintTransfersReport()

            Case Is = UCase("General Ledger Report")
                boolAbort = False
                gwt_comm.LedgerAccountsPrint()
                If boolAbort = True Then Exit Sub

            Case Is = UCase("Trial Balance")
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                Cursor = Cursors.WaitCursor
                gwt_comm.PrintStandardTrialBalance(dtSetDate)
                Cursor = Cursors.Default
                'Case Is = UCase("Stock Movements Summary")
                '    boolAbort = False
                '    Dim f As New frmDateSpecifier
                '    f.ShowDialog()
                '    If boolAbort = True Then Exit Sub
                '    StockMovementsReports(StartDate, EndDate)
            Case Is = UCase("Stock Movements Details")
                boolAbort = False
                gwt_comm.DateRangeSpecification()
                If boolAbort = True Then
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    DetailedStockMovements()
                End If
                'Case Is = UCase("Individual Stock Movement")
                '    boolAbort = False
                '    Dim f As New frmInventoryItemMovementReport
                '    f.ShowDialog()
            Case Is = UCase("Profit and Loss Standard")

                boolAbort = False
                gwt_comm.FinancialReportsParameters()
                If boolAbort = True Then Exit Sub

                If boolSelectiveReportPrinting = True Then
                    For i As Integer = 0 To arrSelectedItems.Count - 1
                        gwt_comm.ProfitAndLossAccount(CInt(arrSelectedItems.Item(i)))
                    Next
                Else
                    gwt_comm.ProfitAndLossAccount()
                End If

            Case Is = UCase("Balance Sheet")
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                gwt_comm.PrintBalanceSheet(dtSetDate)
            Case Is = UCase("Ledger Account Balances")
                PrintLedgerAccounts()
            Case Is = UCase("Stock Valuation Summary")
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    Dim arrValues As New ArrayList
                    arrValues = gwt_comm.RecalculatePurchasesValue(StartDate, EndDate)
                    PrintCostOfSalesReport(arrValues)
                End If
            Case Is = UCase("Customer Balances")
                PrintCustomerBalances()

            Case Is = UCase("Customer Balances At Specified Date")
                PrintCustomerBalancesAtSpecifiedDate()

            Case Is = UCase("Sales Tax Liability")
                PrintVatReturnsReport()


            Case Is = UCase("A5 Payslips")
                intPayslipFormat = 1
                PrintSmallPayslip()
            Case Is = UCase("A5 Payslips Format 2")
                intPayslipFormat = 2
                PrintSmallPayslip()
            Case Is = UCase("Employee Control")
                boolAbort = False
                gwt_comm.EmployeeNumberInputBox()
                If boolAbort = True Then Exit Sub
                EmployeePayrollRegister(strSelectedEmployee)
            Case Is = UCase("Payroll Control Totals")
                PrintControlTotals()
            Case Is = UCase("Bank Transfer Schedule")
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                PrintBankSchedules()
            Case = UCase("Payroll Trekked Fields History")
                PrintTrekkedFieldsHistory()
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
                'Case Is = UCase("Tax Certificates")
                '    Dim f As New frmEmployeeTaxCertificates
                '    f.ShowDialog()
            Case Is = UCase("Detailed Stock History")
                StockMovementHistory()
            Case Is = UCase("Sales Sheets")
                PrintDailySalesSheets()
            Case Is = UCase("--")

            Case Is = UCase("Customer Statements")
                PrintCustomerStatements()
            Case Is = UCase("A/R Aging Analysis")
                PrintAgingAnalysis()
            Case Is = UCase("Cashbook Transactions")
                strAccountClass = "CASHBOOK"
                PrintFinancials()
            Case Is = UCase("Ledger Transactions")
                strAccountClass = "LEDGER"
                PrintFinancials()
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub DetailedStockMovements()

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor
        Dim arrItems As New ArrayList
        boolAbort = False
        arrItems = StockMovementsDetails(StartDate, EndDate)
        If boolAbort = True Then Exit Sub

        Dim dGrid As New AdvancedDataGridViewControl.AdvancedDatagridview

        Me.pb1.Value = 0 : Me.pb1.Maximum = arrItems.Count + 200
        For p As Integer = 0 To arrItems.Count - 1
            Dim strDetails() As String = Split(arrItems.Item(p), "|")
            If p = 0 Then
                dGrid.Columns.Add("Column1", "Item Code")
                dGrid.Columns.Add("Column2", "Current Qty")
                dGrid.Columns.Add("Column3", "Start Qty")
                dGrid.Columns.Add("Column4", "Received")
                dGrid.Columns.Add("Column5", "Trans.In")
                dGrid.Columns.Add("Column6", "Sold")
                dGrid.Columns.Add("Column7", "Trans.Out")
                dGrid.Columns.Add("Column8", "End Qty")
            End If
            dGrid.Rows.Add(strDetails(0), strDetails(1), strDetails(2), strDetails(3), strDetails(4),
                strDetails(5), strDetails(6), strDetails(7))
            Me.pb1.Value = Me.pb1.Value + 1
        Next

        Me.pb1.Value = Me.pb1.Maximum

        For j As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(j).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Detailed stock movements report print failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub StockMovementHistory()
        On Error GoTo RaiseErr
        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        'Sample report layout

        'N201   NOKIA 201
        '       RECEIVED            
        '                           DATE    3000200110
        '                           DATE    5222142225
        '                           DATE    7226269994
        '       TOTAL RECEIVED                          3
        '       TRANSFERS IN        
        '                           DATE    5452020522
        '                           DATE    8822224222
        '       TOTAL TRANSFERS IN                      2
        '       SOLD                
        '                           DATE    4522252122
        '                           DATE    4522252215
        '       TOTAL SOLD                                  (2)
        '       TRANSFER OUT        
        '                           DATE    4222252152
        '       TOTAL TRANSFERS OUT                         (1)
        '       DONATIONS AND OTHER
        '                           DATE    8755541222      
        '       TOTAL DONATIONS                             (1)
        '       NET MOVEMENT                                        1
        '       CURRENT IN STOCK
        '                                   7888555885
        '                                   7885552222
        '       TOTAL IN STOCK                                      2
        '



        'Get the individual stocks for specific items first
        Dim arrPrintDetails As New ArrayList
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Get the count of the items for the progress bar
        Dim intItemsCount As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM InventoryItems WHERE InventoryType = 'SPECIFIC'", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then intItemsCount = CInt(objReader(0).ToString)
        End While
        objReader.Close()

        With Me.pb1
            .Value = 0
            .Visible = True
            .Maximum = intItemsCount + 10
        End With


        Dim strSql As String = "SELECT ItemCode, GroupName FROM InventoryItems WHERE InventoryType = 'SPECIFIC' ORDER BY ItemCode"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read

            'Initialize totals
            Dim dblTotalReceipts As Double = 0
            Dim dblTotalTransfersIn As Double = 0
            Dim dblTotalSales As Double = 0
            Dim dblTotalTransfersOut As Double = 0
            Dim dblNetMovement As Double = 0

            'add the item code into the first and second columns
            arrPrintDetails.Add(UCase(objReader(0).ToString) & "|" & UCase(objReader(1).ToString) & "| | | | | ")

            'Get the received goods from the specified date to current
            'At end write out the total
            objCommand = New Data.OleDb.OleDbCommand("SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
                & "BaseBarCode +''+ SerialNumbers FROM ordersreceipt WHERE ItemCode = '" & objReader(0).ToString & "' AND " _
                & "Transdate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "'", cnn)
            Dim objReadDetails As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim intQuantity As Integer = 0
            arrPrintDetails.Add(" |RECEIVED| | | | | ")
            While objReadDetails.Read
                arrPrintDetails.Add(" | |" & UCase(objReadDetails(0).ToString) & "|" & UCase(objReadDetails(1).ToString) & "| | | ")
                intQuantity = intQuantity + 1
            End While
            objReadDetails.Close()
            arrPrintDetails.Add(" |RECEIVED TOTAL| ||" & intQuantity & "| | ")
            dblTotalReceipts = CDbl(intQuantity)

            'Get the transfes in
            objCommand = New Data.OleDb.OleDbCommand("SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
                & "SourceSerialNo FROM InventoryTransfers WHERE ItemCode = '" & objReader(0).ToString & "' AND " _
                & "Transdate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' AND " _
                & "ReceivingBranch = '" & strUserBranch & "'", cnn)
            objReadDetails = objCommand.ExecuteReader
            intQuantity = 0
            arrPrintDetails.Add(" |TRANSFERS IN| | | | | ")
            While objReadDetails.Read
                arrPrintDetails.Add(" | |" & UCase(objReadDetails(0).ToString) & "|" & UCase(objReadDetails(1).ToString) & "| | | ")
                intQuantity = intQuantity + 1
            End While
            objReadDetails.Close()
            arrPrintDetails.Add(" |TRANSFERS IN TOTAL| ||" & intQuantity & "| | ")
            dblTotalTransfersIn = CDbl(intQuantity)

            'Get the sales out
            objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT UPPER(REPLACE(CONVERT(CHAR(11), Sales.TransDate, 106), ' ', '-')) as [Date], " _
                & "OrdersReceipt.BaseBarcode +''+ Sales.SerialNumbers FROM Sales, OrdersReceipt " _
                & "WHERE Sales.SerialNumbers = OrdersReceipt.SerialNumbers AND Sales.ItemCode = '" & objReader(0).ToString & "' AND " _
                & "Sales.Transdate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "'", cnn)
            objReadDetails = objCommand.ExecuteReader
            intQuantity = 0
            arrPrintDetails.Add(" |SALES| | | | | ")
            While objReadDetails.Read
                arrPrintDetails.Add(" | |" & UCase(objReadDetails(0).ToString) & "|" & UCase(objReadDetails(1).ToString) & "| | | ")
                intQuantity = intQuantity + 1
            End While
            objReadDetails.Close()
            arrPrintDetails.Add(" |SALES TOTAL| |||(" & intQuantity & ")| ")
            dblTotalSales = CDbl(intQuantity)

            'Get the transfers out
            objCommand = New Data.OleDb.OleDbCommand("SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
                & "SourceSerialNo FROM InventoryTransfers WHERE ItemCode = '" & objReader(0).ToString & "' AND " _
                & "Transdate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' AND " _
                & "SourceBranch = '" & strUserBranch & "'", cnn)
            objReadDetails = objCommand.ExecuteReader
            intQuantity = 0
            arrPrintDetails.Add(" |TRANSFERS OUT| | | | | ")
            While objReadDetails.Read
                arrPrintDetails.Add(" | |" & UCase(objReadDetails(0).ToString) & "|" & UCase(objReadDetails(1).ToString) & "| | | ")
                intQuantity = intQuantity + 1
            End While
            objReadDetails.Close()
            arrPrintDetails.Add(" |TRANSFERS OUT TOTAL| ||" & intQuantity & "| | ")
            dblTotalTransfersOut = CDbl(intQuantity)

            dblNetMovement = (dblTotalReceipts + dblTotalTransfersIn) - (dblTotalSales + dblTotalTransfersOut)
            arrPrintDetails.Add(" |PERIOD MOVEMENT| ||| |" & dblNetMovement)

            'Print the current serial analysis
            intQuantity = 0
            arrPrintDetails.Add(" |CURRENT SERIES| | | | | ")
            objCommand = New Data.OleDb.OleDbCommand("SELECT BarcodeNo +''+ SerialNumber FROM serialNumbers " _
                & "WHERE ItemCode = '" & objReader(0).ToString & "'", cnn)
            objReadDetails = objCommand.ExecuteReader
            While objReadDetails.Read
                arrPrintDetails.Add(" | | |" & UCase(objReadDetails(0).ToString) & "| | | ")
                intQuantity = intQuantity + 1
            End While
            objReadDetails.Close()
            arrPrintDetails.Add(" |CURRENT TOTAL| ||" & intQuantity & "| | ")

            Me.pb1.Value = Me.pb1.Value + 1
        End While
        objReader.Close()
        Me.pb1.Value = Me.pb1.Maximum

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = Replace(arrPrintDetails.Item(i), "|", ";", 1)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "ITEM CODE|DESCRIPTION|DATE|SERIAL NO|QTY|QTY|QTY"
            .strColumnWidths = "140|180|80|100|60|60|60"
            .strColumnAlignments = "0|0|0|0|0|0|0"
            .strFooterCaption = strReportHeader
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = UCase(strReportHeader)
            .strMainHeader3 = "PERIOD COVERED " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & " - " & UCase(gwt_comm.shortMonthDateFormat(EndDate))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            '.intBreakIndex = 7
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = True
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Stock movements history print failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub PrintDailySalesSheets()

        On Error GoTo RaiseErr

        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        Dim objCommandDates As New Data.OleDb.OleDbCommand("SELECT DISTINCT TransDate FROM SalesMain WHERE TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "'", cnn)
        Dim objReadDates As Data.OleDb.OleDbDataReader = objCommandDates.ExecuteReader

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        'Get the count
        'objCommandDates = New Data.OleDb.OleDbCommand("SELECT DISTICT COUNT(TransDate) FROM SalesMain", cnn)

        While objReadDates.Read
            Dim strSql As String = Nothing
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                strSql = "SELECT InventoryItems.GroupName, Sales.SalesPrice, Sales.Quantity, " _
                    & "Sales.DiscountAllowed, Sales.Taxes, Sales.SerialNumbers, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) - 0) AS [Paid], " _
                    & "InventoryItems.Category FROM Sales " _
                    & "LEFT JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                    & "WHERE Sales.TransDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' ORDER BY InventoryItems.Category, Sales.ItemCode"
            Else
                strSql = "SELECT InventoryItems.GroupName, Sales.SalesPrice, Sales.Quantity, " _
                    & "Sales.DiscountAllowed, Sales.Taxes, Sales.SerialNumbers, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) + Sales.Taxes) AS [Paid], " _
                    & "InventoryItems.Category FROM Sales " _
                    & "LEFT JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                    & "WHERE Sales.TransDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' ORDER BY InventoryItems.Category, Sales.ItemCode"
            End If
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim arrPrintData As New ArrayList
            While objReader.Read
                Dim strItemName As String = Nothing
                Dim strUnitPrice As String = "0.00"
                Dim strQuantity As String = "1.00"
                Dim strDiscount As String = "0.00"
                Dim strTaxes As String = "0.00"
                Dim strSerial As String = Nothing
                Dim strAmtPaid As String = "0.00"
                Dim strCategory As String = Nothing
                If Not IsDBNull(objReader(0).ToString) Then strItemName = UCase(objReader(0).ToString)
                If IsNumeric(objReader(1).ToString) Then strUnitPrice = Format(CDbl(objReader(1).ToString), "##0.00")
                If IsNumeric(objReader(2).ToString) Then strQuantity = Format(CDbl(objReader(2).ToString), "##0.00")
                If IsNumeric(objReader(3).ToString) Then strDiscount = Format(CDbl(objReader(3).ToString), "##0.00")
                If IsNumeric(objReader(4).ToString) Then strTaxes = Format(CDbl(objReader(4).ToString), "##0.00")
                If Not IsDBNull(objReader(5).ToString) Then strSerial = UCase(objReader(5).ToString)
                If IsNumeric(objReader(6).ToString) Then strAmtPaid = Format(CDbl(objReader(6).ToString), "##0.00")
                If Not IsDBNull(objReader(7).ToString) Then strCategory = UCase(objReader(7).ToString)
                arrPrintData.Add(strItemName & ";" & strUnitPrice & ";" & strQuantity & ";" & strDiscount & ";" & strTaxes & ";" & strSerial & ";" & strAmtPaid & ";" & strCategory)
            End While
            objReader.Close()

            'Get the laybye payments for that day
            arrPrintData.Add("ADD LAYBYE PAYMENTS; ; ; ; ; ; ;LAYBYES")
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, LaybyCustomers.AccountName) +'-'+ CONVERT(NVARCHAR, " _
                & "LaybyTransactions.AccountNumber) +';0;0;0;0;'+ CONVERT(NVARCHAR, LaybyTransactions.DocumentNumber) +';'+ " _
                & "CONVERT(NVARCHAR, CAST(SUM(LaybyTransactions.Amount) AS DECIMAL (30,2))) +';LAYBYES' AS [LineDetail] FROM LaybyTransactions " _
                & "LEFT OUTER JOIN LaybyCustomers ON LaybyCustomers.AccountNumber = LaybyTransactions.AccountNumber " _
                & "WHERE TransDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' AND TransType = 'PAYMENT' " _
                & " GROUP BY LaybyTransactions.AccountNumber, LaybyCustomers.AccountName, LaybyTransactions.DocumentNumber", cnn)
            objReader = objCommand.ExecuteReader()
            While objReader.Read
                arrPrintData.Add(objReader(0))
            End While
            objReader.Close()

            'Get the customer payments for that day
            arrPrintData.Add("ADD CUSTOMER ACCOUNT PAYMENTS; ; ; ; ; ; ;ACCOUNT PAYMENTS")
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, Customers.AccountName) +'-'+ " _
                & "CONVERT(NVARCHAR, CustomerTransactions.AccountNumber) +';0;0;0;0;'+ " _
                & "CONVERT(NVARCHAR, CustomerTransactions.ReferenceNumber) +';'+ " _
                & "CONVERT(NVARCHAR, CAST(SUM(CustomerTransactions.Amount) AS DECIMAL (30,2))) +';" _
                & "ACCOUNT PAYMENTS' AS [LineDetail] FROM CustomerTransactions LEFT OUTER JOIN Customers ON " _
                & "Customers.AccountNumber = CustomerTransactions.AccountNumber WHERE TransactionDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' " _
                & "AND TransactionType = 'PAYMENT' GROUP BY CustomerTransactions.AccountNumber, " _
                & "Customers.AccountName, CustomerTransactions.ReferenceNumber", cnn)
            objReader = objCommand.ExecuteReader()
            While objReader.Read
                arrPrintData.Add(objReader(0))
            End While
            objReader.Close()

            'Get the expenses for that day
            arrPrintData.Add("LESS EXPENSES; ; ; ; ; ; ;EXPENSES")
            strSql = "SELECT  (CashbookTransactions.Description +';0;0;0;0;'+ CashbookTransactions.ContraAccount +';'+ " _
                & "CONVERT(NVARCHAR, CAST((0 - CashbookTransactions.Amount) AS DECIMAL (30,2)))) +';EXPENSES' AS [ExpenseDetails] " _
                & "FROM CashbookTransactions WHERE TransactionType = 'CREDIT' AND TransactionDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader()
            While objReader.Read
                arrPrintData.Add(objReader(0))
            End While
            objReader.Close()

            If arrPrintData.Count >= 0 Then

                'Send the information to the printing class
                Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
                For i As Integer = 0 To arrPrintData.Count - 1 ' strPrintDetails.Length - 1
                    If Not Object.Equals(arrPrintData.Item(i), Nothing) Then
                        If Not String.IsNullOrEmpty(arrPrintData.Item(i).ToString) Then
                            strPrintDetails(i) = arrPrintData.Item(i)
                        End If
                    End If
                Next
                Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
                With rpt
                    .intPrintRecordsCount = strPrintDetails.Length
                    .intNumberOfColumns = 8
                    .strColumnHeaders = "ITEM|UNIT PRICE|QTY|DISCOUNTS|TAXES|SERIAL/REC #|RECEIVED|"
                    .strColumnAlignments = "0|2|2|2|2|0|2|0"
                    .strColumnWidths = "200|80|50|80|60|100|80|0"
                    .strFooterCaption = "Daily Sales Cashout"
                    .strMainCaption = UCase(strCompanyName)
                    .strMainHeader2 = "DAILY SALES SHEET : " & UCase(gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)))
                    .strMainHeader3 = UCase(strUserBranch)
                    .strColumnTotals = "NO|NO|NO|NO|NO|NO|YES|NO"
                    .FooterColor = Color.FromName("Black")
                    .TitleColor = Color.FromName("Black")
                    .DetailColor = Color.FromName("Black")
                    .DrawBorder = True
                    .HorizontalLines = True
                    .VerticalLines = True
                    .GridColor = Color.WhiteSmoke
                    .BorderColor = Color.FromName("WhiteSmoke")
                    .DetailFont = fntDetailsFont
                    .HeaderFont = fntHeaderFont
                    .FooterFont = fntFooterFont
                    .boolGroupDetails = True
                    .boolPrintTotals = True
                    .boolGenericReport = False
                    .boolPrintRecordCount = True
                    .PrintSummary = True
                    .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|NO"
                    .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO"
                    .strSummaryTotals = "NO|NO|NO|NO|NO|NO|YES|NO"
                    .intKeyFieldIndex = 7
                    .strPrintValues = strPrintDetails
                End With

                Dim pd As New PrintDialog()
                pd.PrinterSettings = New System.Drawing.Printing.PrinterSettings()

                rpt.PrinterSettings.PrinterName = strSessionPrinter
                rpt.Print()
            End If
            'Dim documentPreview As New PrintPreviewDialog
            'documentPreview.Document = rpt
            'documentPreview.print()
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        'Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to print daily sales report"
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
                & "ValueAfter FROM Audit WHERE ChangeDate BETWEEN '" & shortMonthDateFormat(strReportStartDate) & "' " _
                & "AND '" & shortMonthDateFormat(strReportEndDate) & "' ORDER BY TransactionId", cnn)
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

    Private Sub PrintFinancials()
        boolAbort = False
        gwt_comm.DetailedFinancialsPrintParameters()
        If boolAbort = True Then
            strAccountClass = Nothing
            Exit Sub
        End If
        gwt_comm.CashbookLedgerTransactionsPrint()
    End Sub

    Private Sub PrintAgingAnalysis()

        On Error GoTo RaiseErr

        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        CreateTransactionGrid()

        boolPrinterAlreadySelected = False

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'Get the count of the records

        objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM Customers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()

        Me.pb1.Value = 0
        Me.pb1.Visible = True
        Me.pb1.Maximum = intCount + 3

        Dim arrPrintDetails As New ArrayList

        While objReader.Read

            LoadTransactions(objReader(0).ToString)

            Dim strStatementArray As New ArrayList

            'Get the aging balances
            Dim arrAgeBalances As New ArrayList
            arrAgeBalances = gwt_comm.ComputeAgingBalances(dGridTransactions)

            'Assign the age balances to common variables
            dblBetween00and30 = CDbl(arrAgeBalances.Item(0))
            dblBetween30and60 = CDbl(arrAgeBalances.Item(1))
            dblBetween60and90 = CDbl(arrAgeBalances.Item(2))
            dblOver90 = CDbl(arrAgeBalances.Item(3))

            Dim dblCummulativeStatementBalance As Double = dblBetween00and30 + dblBetween30and60 + dblBetween60and90 + dblOver90

            If dblCummulativeStatementBalance <> 0 Then
                arrPrintDetails.Add(objReader(0).ToString & ";" & UCase(objReader(1).ToString) & ";" &
                    Format(dblBetween00and30, "##0.00") & ";" & Format(dblBetween30and60, "##0.00") & ";" & Format(dblBetween60and90, "##0.00") & ";" &
                    Format(dblOver90, "##0.00") & ";" & Format(dblCummulativeStatementBalance, "##0.00"))
            End If

            Me.pb1.Value = Me.pb1.Value + 1

        End While

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = Replace(arrPrintDetails.Item(i), "|", ";", 1)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "ACCOUNT NO|CUSTOMER NAME|0-30 DYS|30-60 DYS|60-90 DYS|OVER 90 DYS|BALANCE"
            .strColumnWidths = "80|190|75|75|75|75|75"
            .strColumnAlignments = "0|0|2|2|2|2|2"
            .strFooterCaption = strReportHeader
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = UCase(strReportHeader)
            .strMainHeader3 = "PERIOD COVERED " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & " - " & UCase(gwt_comm.shortMonthDateFormat(EndDate))
            .strColumnTotals = "NO|NO|YES|YES|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            '.intBreakIndex = 7
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = True
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|YES|YES|YES|YES|YES"
            .strSummaryTotals = "NO|NO|YES|YES|YES|YES|YES"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On age analysis print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintCustomerStatements()
        On Error GoTo RaiseErr

        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        boolPrinterAlreadySelected = False

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT accountNumber FROM Customers ORDER BY AccountNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'Get the count of the records

        objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM Customers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()

        Me.pb1.Value = 0
        Me.pb1.Visible = True
        Me.pb1.Maximum = intCount + 3

        'Create a datagrid to hold the transactions
        CreateTransactionGrid()

        While objReader.Read

            LoadTransactions(objReader(0).ToString)

            Dim strStatementArray As New ArrayList

            'Get the aging balances
            Dim arrAgeBalances As New ArrayList
            arrAgeBalances = gwt_comm.ComputeAgingBalances(dGridTransactions)

            'Assign the age balances to common variables
            dblBetween00and30 = CDbl(arrAgeBalances.Item(0))
            dblBetween30and60 = CDbl(arrAgeBalances.Item(1))
            dblBetween60and90 = CDbl(arrAgeBalances.Item(2))
            dblOver90 = CDbl(arrAgeBalances.Item(3))

            Dim dblCummulativeStatementBalance As Double = 0

            'Get the balance brought forwd
            For i As Integer = 0 To dGridTransactions.Rows.Count - 3

                Dim dblDr As Double = 0
                Dim dblCr As Double = 0
                Dim strDt As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(0).Value), "")) Then
                    strDt = dGridTransactions.Rows(i).Cells(0).Value.ToString
                End If
                strDt = Mid(strDt, 1, 2) & "-" & MonthName(CInt(Mid(strDt, 4, 2)), True) & "-" & Mid(strDt, 7, 4)

                If CDate(strDt) < StartDate Then
                    'If CDate(strDt) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridTransactions.Rows(i).Cells(4).Value.ToString) Then
                            dblDr = CDbl(dGridTransactions.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(5).Value), "")) Then
                        If IsNumeric(dGridTransactions.Rows(i).Cells(5).Value.ToString) Then
                            dblCr = CDbl(dGridTransactions.Rows(i).Cells(5).Value.ToString)
                        End If
                    End If
                    dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                    'End If
                End If

            Next

            strStatementArray.Add(UCase(gwt_comm.shortMonthDateFormat(StartDate)) & "|" & "Balance brought forward" & "| | | | |" & Format(dblCummulativeStatementBalance, "#,##0.00"))
            Dim dblBalance As Double = dblCummulativeStatementBalance

            For i As Integer = 0 To dGridTransactions.Rows.Count - 3
                Dim strDate As String = Nothing
                Dim strReference As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblDebit As Double = 0
                Dim dblCredit As Double = 0
                Dim strProjectName As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(0).Value), "")) Then
                    strDate = dGridTransactions.Rows(i).Cells(0).Value.ToString
                End If
                strDate = Mid(strDate, 1, 2) & "-" & MonthName(CInt(Mid(strDate, 4, 2)), True) & "-" & Mid(strDate, 7, 4)

                If CDate(strDate) >= StartDate Then
                    If CDate(strDate) <= EndDate Then
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(1).Value), "")) Then
                            strReference = dGridTransactions.Rows(i).Cells(1).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(2).Value), "")) Then
                            strDescription = dGridTransactions.Rows(i).Cells(2).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(4).Value), "")) Then
                            If IsNumeric(dGridTransactions.Rows(i).Cells(4).Value.ToString) Then
                                dblDebit = CDbl(dGridTransactions.Rows(i).Cells(4).Value.ToString)
                            End If
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(5).Value), "")) Then
                            If IsNumeric(dGridTransactions.Rows(i).Cells(5).Value.ToString) Then
                                dblCredit = CDbl(dGridTransactions.Rows(i).Cells(5).Value.ToString)
                            End If
                        End If
                        dblBalance = dblBalance + (dblDebit - dblCredit)
                        'DATE, DESCRIPTION, REF, PROJECT, DEBIT, CREDIT, BALANCE
                        strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & strProjectName & "|" &
                            Format(dblDebit, "#,##0.00") & "|" & Format(dblCredit, "#,##0.00") & "|" &
                            Format(dblBalance, "#,##0.00"))
                    End If
                End If
            Next
            itm = 0

            dblCurrentStatementBalance = dblBalance
            'Adjustment of the moving balance ***

            arrStatementDetails = New ArrayList
            arrStatementDetails = strStatementArray

            If dblCummulativeStatementBalance <> 0 Or dblBalance <> 0 Then
                boolDirectPrinting = True
                gwt_comm.PrintCustomerDocument(intSelectedTransaction, "STATEMENT")
            End If

            Me.pb1.Value = Me.pb1.Value + 1

        End While

        Me.pb1.Value = Me.pb1.Maximum

        MessageBox.Show("Printing Completed Successfully", "Statements Print", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to print Customer Statements"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CreateTransactionGrid()
        Dim dGridTransactions = New AdvancedDataGridViewControl.AdvancedDatagridview
        'Date, ref, description, qty, debit, credit, type
        With dGridTransactions
            .Columns.Add("Column1", "Date")
            .Columns.Add("Column2", "ref")
            .Columns.Add("Column3", "Description")
            .Columns.Add("Column4", "Qty")
            .Columns.Add("Column5", "Debit")
            .Columns.Add("Column6", "Credit")
            .Columns.Add("Column7", "Type")
        End With
    End Sub

    Private Sub LoadTransactions(AccountNumber As String)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT CONVERT(NVARCHAR, TransDate, 102) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed) AS DECIMAL (30,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate"
        Else
            strSql = "SELECT CONVERT(NVARCHAR, TransDate, 102) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed + Taxes) AS DECIMAL (30,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrTransactions As New ArrayList
        While objReader.Read
            Dim strLine As String = Nothing
            For n As Integer = 0 To objReader.FieldCount - 1
                If n = 2 Then
                    strLine = strLine & ";POSTED INVOICE;0;" & objReader(n).ToString
                Else
                    strLine = strLine & ";" & objReader(n).ToString
                End If
            Next
            strLine = Mid(strLine, 2, (strLine.Length - 1)) & ";"
            arrTransactions.Add(strLine & ";INVOICE")
        End While
        objReader.Close()
        'Get the payments
        strSql = "SELECT CONVERT(NVARCHAR, TransactionDate, 102) AS [Dte], [ReferenceNumber], " _
            & "[Description], CAST(Amount AS DECIMAL (30,2)) AS [Amt] FROM CustomerTransactions " _
            & "WHERE AccountNumber = '" & AccountNumber & "' ORDER BY TransactionDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        Dim strLastPaymentAmount As String = "0.00"
        Dim strLastPaymentDate As String = Nothing
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";1;;" & objReader(3).ToString & ";PAYMENT")
            If IsDate(objReader(0).ToString) Then strLastPaymentDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
            If IsNumeric(objReader(3).ToString) Then strLastPaymentAmount = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
        End While
        objReader.Close()

        'Get the credit note entries
        strSql = "SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 102) as [Date], CreditNoteEntries.NoteNumber, " _
            & "CreditNoteEntries.Description, SUM(CreditNoteEntries.Quantity) as [Qty], " _
            & "CAST(SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) + CreditNoteEntries.Taxes) AS DECIMAL (30,2)) as [Paid] " _
            & "FROM CreditNoteEntries, CreditNotesMain WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
            & "AND CreditNotesMain.AccountId = '" & AccountNumber & "' AND ((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - 0) > 0 " _
            & "GROUP BY CreditNotesMain.TransDate, CreditNoteEntries.NoteNumber, CreditNoteEntries.Description " _
            & "ORDER BY CreditNotesMain.TransDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";" & objReader(3).ToString & ";;" & objReader(4).ToString & ";CREDIT NOTE")
        End While
        objReader.Close()

        If arrTransactions.Count > 0 Then arrTransactions.Sort()

        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblBalance As Double = 0
        dGridTransactions.Rows.Clear()
        For i As Integer = 0 To arrTransactions.Count - 1
            dGridTransactions.Rows.Add(1)
            Dim strValues() As String = Split(arrTransactions(i), ";")
            For n As Integer = 0 To strValues.Length - 1
                With dGridTransactions
                    If n = 0 Then
                        'Format the date. Its in the format 2013.03.31
                        Dim strDate As String = Nothing
                        Dim strDateParts() As String = Split(strValues(0), ".")
                        strDate = strDateParts(2) & "-" & strDateParts(1) & "-" & strDateParts(0) 'UCase(MonthName(CInt(strDateParts(1)), True))
                        .Rows(.Rows.Count - 1).Cells(n).Value = UCase(strDate)
                    Else
                        .Rows(.Rows.Count - 1).Cells(n).Value = strValues(n)
                    End If
                End With
            Next n
            If IsNumeric(strValues(strValues.Length - 3)) Then
                dblDebitTotal = dblDebitTotal + CDbl(strValues(strValues.Length - 3))
            End If
            If IsNumeric(strValues(strValues.Length - 2)) Then
                dblCreditTotal = dblCreditTotal + CDbl(strValues(strValues.Length - 2))
            End If
        Next
        dblBalance = dblDebitTotal - dblCreditTotal

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintSmallPayslip()
        'payslip printing
        boolAbort = False
        boolDrawBorders = True
        gwt_comm.PayslipPrintParameters()
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

        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        If intPayslipFormat = 2 Then
            ppd.Document = pdFormatTwo
        Else
            ppd.Document = pdSmallPayslips
        End If
        ppd.ShowDialog()
    End Sub

    Private Sub InventoryListing() ''' ************ KEY CODE ************************** ''
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode as [Item Code], GroupName as [Description], Category, " _
            & "SubCategory as [Sub Category], Quantity as [Qty], CAST(CostPrice AS DECIMAL (30,2)) AS [Cost Price], " _
            & "CAST(SellingPrice AS DECIMAL (30,2)) AS [Sale Price], Location, Offering " _
            & "FROM InventoryItems ORDER BY ItemCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrPrintData As New ArrayList
        While objReader.Read
            arrPrintData.Add(objReader(0).ToString & ";" &
                objReader(1).ToString & ";" &
                objReader(2).ToString & ";" &
                objReader(3).ToString & ";" &
                objReader(4).ToString & ";" &
                objReader(5).ToString & ";" &
                objReader(6).ToString & ";" &
                objReader(7).ToString & ";" &
                objReader(8).ToString)
        End While
        objReader.Close()

        If arrPrintData.Count > 0 Then
            Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
            For n As Integer = 0 To arrPrintData.Count - 1
                strPrintDetails(n) = arrPrintData.Item(n)
            Next
            'Send the details to the printer
            Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
            Dim DocumentPreview As New PrintPreviewDialog
            Cursor = Cursors.WaitCursor

            With myReport
                .intNumberOfColumns = 9
                .intPrintRecordsCount = strPrintDetails.Length   'Or number of records in the text file
                .strColumnAlignments = "0|0|0|0|2|2|2|0|0"
                .strColumnFormating = "NO|NO|NO|NO|YES|YES|YES|NO|NO"
                .strColumnHeaders = "CODE #|DESCRIPTION|CATEGORY|SUB CAT.|QTY|COST $|SALE $|LOCATION|TYPE"
                .strColumnWidths = "80|140|80|80|40|65|65|80|50"
                .strColumnTotals = "NO|NO|NO|NO|NO|YES|YES|NO|NO"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .intKeyFieldIndex = 0
                .PrintSummary = False
                .DrawBorder = True
                .BorderColor = Color.FromName("WhiteSmoke")
                .DrawSummaryChart = False
                .VerticalLines = True
                .HorizontalLines = True
                .GridColor = Color.FromName("WhiteSmoke")
                .strPrintValues = strPrintDetails
                .strMainHeader2 = "INVENTORY LISTING AS AT " & UCase(gwt_comm.shortMonthDateFormat(Now))
                .strMainCaption = UCase(strCompanyName)
                .strFooterCaption = "Great Wits Financial Light. Technology In Motion"
                .DetailFont = fntFooterFont 'fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
                .boolPrintRecordCount = True
            End With
            Cursor = Cursors.Default
            DocumentPreview.Document = myReport
            DocumentPreview.ShowDialog()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory List Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintLedgerAccounts()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            'do nothing
            boolAbort = False
            gwt_comm.DateSpecification()
            If boolAbort = True Then Exit Sub

            Cursor = Cursors.WaitCursor
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM LedgerAccounts ORDER BY AccountNumber", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim arrPrintData As New ArrayList
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim dblBalance() As Double = gwt_comm.LedgerAccountBalances(StartDate, EndDate, objReader(0).ToString, , , , )
                    Dim dblStartBalance As Double = dblBalance(0)

                    objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
                        & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (30,2)) AS [Amt], TransactionType, TransactionId " _
                        & "FROM LedgerTransactions WHERE AccountNumber = '" & objReader(0).ToString & "' " _
                        & "AND TransactionDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "'", cnn)
                    Dim objReadTransactions As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

                    Dim dblEndBalance As Double = 0
                    Dim dblvalue As Double = 0

                    While objReadTransactions.Read
                        Dim dblDr As Double = 0
                        Dim dblCr As Double = 0
                        If Not IsDBNull(objReadTransactions(5).ToString) Then
                            Dim strValue As String = objReadTransactions(4).ToString
                            If UCase(objReadTransactions(5).ToString) = "CREDIT" Then
                                dblCr = CDbl(strValue)
                            Else
                                dblDr = CDbl(strValue)
                            End If
                        End If
                        dblvalue = dblvalue + (dblDr - dblCr)
                    End While
                    objReadTransactions.Close()

                    If dblStartBalance < 0 Then
                        dblEndBalance = dblStartBalance + dblvalue
                    Else
                        dblEndBalance = dblStartBalance + dblvalue
                    End If

                    If dblEndBalance < 0 Then
                        arrPrintData.Add(UCase(objReader(0).ToString) & ";" & UCase(objReader(1).ToString) & ";" & Format(dblStartBalance, "##0.00") & ";" & Format(dblEndBalance, "##0.00") & ";CR;" & Format(dblvalue, "##0.00"))
                    Else
                        arrPrintData.Add(UCase(objReader(0).ToString) & ";" & UCase(objReader(1).ToString) & ";" & Format(dblStartBalance, "##0.00") & ";" & Format(dblEndBalance, "##0.00") & ";DR;" & Format(dblvalue, "##0.00"))
                    End If
                End If
            End While
            objReader.Close()

            Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
            For n As Integer = 0 To arrPrintData.Count - 1
                strPrintDetails(n) = arrPrintData.Item(n)
            Next
            'Send the details to the printer
            Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
            Dim DocumentPreview As New PrintPreviewDialog
            Cursor = Cursors.WaitCursor

            With myReport
                .intNumberOfColumns = 6
                .intPrintRecordsCount = strPrintDetails.Length   'Or number of records in the text file
                .strColumnAlignments = "0|0|2|2|0|2"
                .strColumnFormating = "NO|NO|YES|YES|NO|YES"
                .strColumnHeaders = "ACCOUNT #|DESCRIPTION|START BAL|END BAL|TYPE|MOVEMENT"
                .strColumnWidths = "100|200|100|100|40|100"
                .strColumnTotals = "NO|NO|YES|YES|NO|YES"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .intKeyFieldIndex = 0
                .PrintSummary = False
                .DrawBorder = True
                .BorderColor = Color.FromName("WhiteSmoke")
                .DrawSummaryChart = False
                .VerticalLines = True
                .HorizontalLines = True
                .GridColor = Color.FromName("WhiteSmoke")
                .strPrintValues = strPrintDetails
                .strMainCaption = "LEDGER ACCOUNT FOR THE PERIOD " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & "-" & UCase(shortMonthDateFormat(CDate(EndDate)))
                .strFooterCaption = "Great Wits Financial Light. Technology In Motion"
                .DetailFont = fntFooterFont 'fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
                .boolPrintRecordCount = True
            End With
            Cursor = Cursors.Default
            DocumentPreview.Document = myReport
            DocumentPreview.ShowDialog()

            Exit Sub
        Else
            MessageBox.Show("You do not have the right to access this part of the system", "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

    End Sub

    Private Sub PrintCostOfSalesReport(ByVal Values As ArrayList)

        Cursor = Cursors.WaitCursor

        Dim strPrintDetails(0 To 13) As String

        'dblReturn.Add(dblPeriodStockTransfersOutValue)
        'dblReturn.Add(dblPeriodStockTransfersInValue)
        'dblReturn.Add(dblPeriodStockPromotionsValue)
        Dim dblSubTotal1 As Double = 0
        Dim dblSubTotal2 As Double = 0
        Dim dblSubTotal3 As Double = 0
        Dim dblSubTotal4 As Double = 0

        strPrintDetails(0) = "CURRENT STOCK VALUE;;" & Format(CDbl(Values.Item(0)), "#,##0.00") & " ;"
        strPrintDetails(1) = "Add Sales from Start Date;" & Format(CDbl(Values.Item(1)), "#,##0.00") & " ; ; "
        strPrintDetails(2) = "Add Transfers Out from Start Date;" & Format(CDbl(Values.Item(2)), "#,##0.00") & " ; ; "
        dblSubTotal1 = CDbl(Values(0)) + CDbl(Values(1)) + CDbl(Values(2))
        strPrintDetails(3) = "SUB TOTAL; ;" & Format(dblSubTotal1, "#,##0.00") & "; "

        strPrintDetails(4) = "Less Stocks Received From Start Date;" & Format(CDbl(Values.Item(3)), "#,##0.00") & " ; ; "
        strPrintDetails(5) = "Less Stocks Transfers-In From Start Date;" & Format(CDbl(Values.Item(4)), "#,##0.00") & "; ; "
        dblSubTotal2 = dblSubTotal1 - (CDbl(Values(3)) + CDbl(Values(4)))

        strPrintDetails(6) = "STOCK VALUE AT START DATE; ;" & Format(dblSubTotal2, "#,##0.00") & " ;"

        strPrintDetails(7) = "Add Period Stocks Received;" & Format(CDbl(Values.Item(5)), "#,##0.00") & " ; ;"
        strPrintDetails(8) = "Add Period Stocks Transfers-In;" & Format(CDbl(Values.Item(6)), "#,##0.00") & " ; ;"
        dblSubTotal3 = dblSubTotal2 + CDbl(Values.Item(5)) + CDbl(Values.Item(6))

        strPrintDetails(9) = "SUB TOTAL; ;" & Format(dblSubTotal3, "#,##0.00") & " ;"
        strPrintDetails(10) = "Less Period Sales;" & Format(CDbl(Values.Item(7)), "#,##0.00") & " ; ;"
        strPrintDetails(11) = "Less Period Stocks Transfers-Out;" & Format(CDbl(Values.Item(8)), "#,##0.00") & " ; ;"
        strPrintDetails(12) = "Less Period Stocks Donated (Promotions);" & Format(CDbl(Values.Item(9)), "#,##0.00") & " ; ;"

        dblSubTotal4 = dblSubTotal3 - (CDbl(Values.Item(7)) + CDbl(Values.Item(8)) + CDbl(Values.Item(9)))

        strPrintDetails(13) = "CLOSING STOCK VALUE;;" & Format(dblSubTotal4, "#,##0.00") & " ;"

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "DESCRIPTION|AMOUNT|AMOUNT|"
            .strColumnAlignments = "0|2|2|0"
            .strColumnWidths = "240|100|100|100"
            .strFooterCaption = "Inventory Stock Status Report "
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "INVENTORY STOCK ANALYSIS REPORT"
            .strMainHeader3 = "PERIOD COVERED " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & " - " & UCase(shortMonthDateFormat(CDate(EndDate)))
            .strColumnTotals = "NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            '.intBreakIndex = 7
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = True
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub PrintTrekkedFieldsHistory()

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrPrintData As New ArrayList
        Dim strSql As String = Nothing
        strSql = "SELECT DISTINCT(EmployeeNo) FROM EmployeeTrakkedFields ORDER BY EmployeeNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    Dim strEmployeeNames As String = EmployeeNames(objReader(0).ToString)
                    strSql = "SELECT DISTINCT(PeriodNumber), TrekYear FROM EmployeeTrakkedFields 
                        WHERE EmployeeNo = '" & objReader(0).ToString & "' GROUP BY TrekYear, PeriodNumber   
                        ORDER BY PeriodNumber"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objInnerReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    While objInnerReader.Read
                        If IsNumeric(objInnerReader(0).ToString) Then
                            Dim arrPeriodData As New ArrayList
                            arrPeriodData = TrekkedFieldsHistory(objReader(0).ToString, objInnerReader(0).ToString)
                            If arrPeriodData.Count > 0 Then
                                arrPrintData.Add(UCase(objReader(0).ToString) &
                                    "|" & UCase(strEmployeeNames) & "|||")
                                arrPrintData.Add("PERIOD" & "|" & CStr(objInnerReader(0).ToString) &
                                    "-" & CStr(objInnerReader(1).ToString) & "|||")
                                For p As Integer = 0 To arrPeriodData.Count - 1
                                    arrPrintData.Add(arrPeriodData.Item(p))
                                Next
                                arrPrintData.Add(StrDup(10, "*") & "|" & StrDup(60, "*") & "|" _
                                    & StrDup(10, "*") & "|" & StrDup(10, "*") & "|" & StrDup(10, "*"))
                            End If
                        End If
                    End While
                    objInnerReader.Close()
                End If
            End If
        End While
        objReader.Close()

        ' Send the data to the smart report printer
        '
        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = Replace(arrPrintData.Item(i), "|", ";", 1)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 5
            .strColumnHeaders = "KEY|DESCRIPTION|EARNING|DEDUCTIONS|BASE/COY"
            .strColumnAlignments = "0|0|2|2|2"
            .strColumnWidths = "80|300|80|80|80"
            .strFooterCaption = "Comprehensive Trekked Payroll Fields History"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "PAYROLL TREKKED FIELDS HISTORY"
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|YES|YES|YES"
            .strSummaryTotals = "NO|NO|YES|YES|YES"
            '.intKeyFieldIndex = 7
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
        Cursor = DefaultCursor
        boolAbort = True
        strErrorMessages = Err.Description & vbCrLf & "Error Number: " & Err.Number & vbCrLf & "On Employee Trekked Fields History Print"
        ShowErrorMessage()
    End Sub

    Private Sub PrintCustomerBalances()

        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.GetBalance(objReaderCustomers(0).ToString)
            'If boolIncludeZeroBalance = False Then
            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            End If
            'Else
            'arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            'End If
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CUSTOMER NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CUSTOMER BALANCES"
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
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
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance printing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintVatReturnsReport()
        On Error GoTo RaiseErr
        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim arrPrintData As New ArrayList

        Dim strSql As String = Nothing

        Dim dblGrossTtl As Double = 0
        Dim dblTaxTtl As Double = 0

        Dim dblTaxReceived As Double = 0
        Dim dblTaxPaidout As Double = 0

        'Get the vat from sales invoices first
        If UCase(strTaxComputationType) = "EXCLUSIVE" Then
            strSql = "SELECT CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], " _
                & "CustomerSalesMain.InvoiceNumber, Customers.AccountName, (CustomerSalesMain.Amount - CustomerSalesMain.Taxes) as [Gross], " _
                & "CustomerSalesMain.Taxes from CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate " _
                & "BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
                & "ORDER BY CustomerSalesMain.InvoiceNumber"
        Else
            strSql = "SELECT CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], " _
                & "CustomerSalesMain.InvoiceNumber, Customers.AccountName, (CustomerSalesMain.Amount) as [Gross], " _
                & "CustomerSalesMain.Taxes from CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate " _
                & "BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
                & "ORDER BY CustomerSalesMain.InvoiceNumber"
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read
            arrPrintData.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & objReader(2).ToString & ";" & objReader(3).ToString & ";" & objReader(4).ToString & ";")
            If IsNumeric(objReader(3).ToString) Then dblGrossTtl = dblGrossTtl + CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblTaxTtl = dblTaxTtl + CDbl(objReader(4).ToString)
        End While
        objReader.Close()

        'Get the vat from cash sales
        If UCase(strTaxComputationType) = "EXCLUSIVE" Then
            strSql = "SELECT CONVERT(NVARCHAR, SalesMain.TransDate, 105) AS [Date], SalesMain.InvoiceNumber, " _
                & "'CASH SALE', (SalesMain.Amount - SalesMain.Taxes) as [Gross], SalesMain.Taxes from SalesMain  WHERE TransDate " _
                & "BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
                & "ORDER BY SalesMain.InvoiceNumber"
        Else
            strSql = "SELECT CONVERT(NVARCHAR, SalesMain.TransDate, 105) AS [Date], SalesMain.InvoiceNumber, " _
                & "'CASH SALE', (SalesMain.Amount) as [Gross], SalesMain.Taxes from SalesMain  WHERE TransDate " _
                & "BETWEEN '" & shortMonthDateFormat(CDate(StartDate)) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
                & "ORDER BY SalesMain.InvoiceNumber"
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read
            arrPrintData.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & objReader(2).ToString & ";" & objReader(3).ToString & ";" & objReader(4).ToString & ";")
            If IsNumeric(objReader(3).ToString) Then dblGrossTtl = dblGrossTtl + CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblTaxTtl = dblTaxTtl + CDbl(objReader(4).ToString)
        End While
        objReader.Close()

        'Sort the array
        For i As Integer = 0 To arrPrintData.Count - 1
            Dim strBuffer() As String = Split(arrPrintData.Item(i), ";")
            Dim strFields() As String = Split(strBuffer(0), "-")
            strBuffer(0) = Format(CInt(strFields(2)), "0000") & "-" & Format(CInt(strFields(1)), "000") & "-" & strFields(0)
            arrPrintData.Item(i) = strBuffer(0) & ";" & strBuffer(1) & ";" & strBuffer(2) & ";" &
                strBuffer(3) & ";" & strBuffer(4) & ";" & strBuffer(5)
        Next
        arrPrintData.Sort()
        For i As Integer = 0 To arrPrintData.Count - 1
            Dim strBuffer() As String = Split(arrPrintData.Item(i), ";")
            Dim strFields() As String = Split(strBuffer(0), "-")
            strBuffer(0) = Format(CInt(strFields(2)), "00") & "-" & MonthName(CInt(strFields(1)), True) & "-" & CInt(strFields(0))
            strBuffer(0) = UCase(gwt_comm.shortMonthDateFormat(CDate(strBuffer(0))))
            arrPrintData.Item(i) = strBuffer(0) & ";" & strBuffer(1) & ";" & strBuffer(2) & ";" &
                strBuffer(3) & ";" & strBuffer(4) & ";" & strBuffer(5)
        Next

        'Get the sum total 0f all the vat incomes
        arrPrintData.Add(" ; ;TOTAL;" & dblGrossTtl & ";" & dblTaxTtl & ";" & dblTaxTtl)
        arrPrintData.Add(" ; ;;" & "" & ";" & "" & ";" & "")
        arrPrintData.Add(" ; ;;" & "" & ";" & "" & ";" & "")
        arrPrintData.Add(" ; ;LESS VAT FROM PAYMENTS;" & "" & ";" & "" & ";" & "")
        dblTaxReceived = dblTaxReceived + dblTaxTtl

        Dim arrCredits As New ArrayList

        dblGrossTtl = 0 : dblTaxTtl = 0
        'Get the vat from the cashbook
        objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, Transactiondate, 105) AS [Date], " _
            & "Reference, Description +' VAT No. '+ VatNumber as [Description], Amount, VatAmount FROM CashbookTransactions WHERE TransactionType = 'CREDIT' " _
            & "AND Transactiondate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
            & "AND VatAmount <> 0 ORDER BY TransactionDate", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrCredits.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & objReader(2).ToString & ";" & objReader(3).ToString & ";" & objReader(4).ToString & ";")
            If IsNumeric(objReader(3).ToString) Then dblGrossTtl = dblGrossTtl + CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblTaxTtl = dblTaxTtl + CDbl(objReader(4).ToString)
        End While
        objReader.Close()

        'Get the vat from the creditors
        objCommand = New Data.OleDb.OleDbCommand("select CONVERT(NVARCHAR, SupplierTransactions.TransactionDate, 105) AS [Date], " _
            & "SupplierTransactions.ReferenceNumber, Suppliers.AccountName +' VAT No. '+ Suppliers.VatNumber AS [AccountName], SupplierTransactions.Amount, " _
            & "SupplierTransactions.Taxes FROM SupplierTransactions LEFT OUTER JOIN Suppliers ON " _
            & "SupplierTransactions.AccountNumber = Suppliers.AccountNumber WHERE TransactionDate " _
            & "BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
            & "AND SupplierTransactions.Taxes <> 0 ORDER BY SupplierTransactions.TransactionDate", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrCredits.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & objReader(2).ToString & ";" & objReader(3).ToString & ";" & objReader(4).ToString & ";")
            If IsNumeric(objReader(3).ToString) Then dblGrossTtl = dblGrossTtl + CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblTaxTtl = dblTaxTtl + CDbl(objReader(4).ToString)
        End While
        objReader.Close()

        'Sort the array list
        For i As Integer = 0 To arrCredits.Count - 1
            Dim strBuffer() As String = Split(arrCredits.Item(i), ";")
            Dim strFields() As String = Split(strBuffer(0), "-")
            strBuffer(0) = Format(CInt(strFields(2)), "0000") & "-" & Format(CInt(strFields(1)), "000") & "-" & strFields(0)
            arrCredits.Item(i) = strBuffer(0) & ";" & strBuffer(1) & ";" & strBuffer(2) & ";" &
                strBuffer(3) & ";" & strBuffer(4) & ";" & strBuffer(5)
        Next
        arrCredits.Sort()
        For i As Integer = 0 To arrCredits.Count - 1
            Dim strBuffer() As String = Split(arrCredits.Item(i), ";")
            Dim strFields() As String = Split(strBuffer(0), "-")
            strBuffer(0) = Format(CInt(strFields(2)), "00") & "-" & MonthName(CInt(strFields(1)), True) & "-" & CInt(strFields(0))
            strBuffer(0) = UCase(gwt_comm.shortMonthDateFormat(CDate(strBuffer(0))))
            arrCredits.Item(i) = strBuffer(0) & ";" & strBuffer(1) & ";" & strBuffer(2) & ";" &
                strBuffer(3) & ";" & strBuffer(4) & ";" & strBuffer(5)
        Next

        For i As Integer = 0 To arrCredits.Count - 1
            arrPrintData.Add(arrCredits.Item(i))
        Next

        'Get the sum total 0f all the vat incomes
        arrPrintData.Add(" ; ;TOTAL;" & dblGrossTtl & ";" & dblTaxTtl & ";" & (0 - dblTaxTtl))
        arrPrintData.Add(" ; ;;" & "" & ";" & "" & ";" & "")
        arrPrintData.Add(" ; ;;" & "" & ";" & "" & ";" & "")
        arrPrintData.Add(" ; ;NET PAYABLE;" & "" & ";" & "" & ";" & dblTaxReceived - dblTaxTtl)

        If MessageBox.Show("Do you want to print the report to Excel?", "Print To File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

            boolAbort = False
            strSelectedFileName = Nothing

            gwt_comm.FileSpecification()
            If boolAbort = True Then Exit Sub

            'Send the file to excel to 
            If String.IsNullOrEmpty(strSelectedFileName) Then
                MessageBox.Show("The file name has not been specified. Process will be terminated",
                    "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim arrXcelData As New ArrayList
            Dim strHeaders As New ArrayList
            strHeaders.Add("VAT RETURNS REPORT - " & UCase(strCompanyName) & ": |" & UCase(CStr(gwt_comm.shortMonthDateFormat(StartDate))) & " TO " & UCase(CStr(shortMonthDateFormat(CDate(EndDate)))) & "| | ")
            strHeaders.Add("DATE|INVOICE #|DESCRIPTION|AMOUNT|VAT| ")
            For t As Integer = 0 To arrPrintData.Count - 1
                Dim strXcelLine As String = Nothing
                Dim strRecordLine() As String = Split(arrPrintData.Item(t), ";")
                For z As Integer = 0 To strRecordLine.Length - 1
                    'Dim strTextData() As String = Split(strRecordLine(z), "|")
                    'If UCase(strTextData(0)) <> UCase("<DRAWLINE>") Then
                    strXcelLine = strXcelLine & strRecordLine(z) & "|"
                    'End If
                Next
                arrXcelData.Add(strXcelLine)
            Next

            'Write the details to the file
            boolAbort = False
            gwt_comm.WriteExcelFile(strHeaders, arrXcelData, strSelectedFileName & ".xls")
            If boolAbort = True Then Exit Sub
            MessageBox.Show("Details written successfully to Microsoft Excel", "Data Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub

        End If

        'Send the information to the printer

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DATE|INVOICE #|DESCRIPTION|AMOUNT|VAT| "
            .strColumnAlignments = "0|0|0|2|2|2"
            .strColumnWidths = "100|80|200|80|80|80"
            .strFooterCaption = "VAT Return Report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "VAT RETURNS REPORT"
            .strMainHeader3 = "PERIOD COVERED " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & " - " & UCase(gwt_comm.shortMonthDateFormat(EndDate))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|YES|YES|YES"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            '.intKeyFieldIndex = 7
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
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On VAT Returns Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintCustomerBalancesAtSpecifiedDate()
        'CustomerBalanceOnSpecificDate
        boolAbort = False
        gwt_comm.DateSpecification()
        If boolAbort = True Then Exit Sub

        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.ClientBalanceOnSpecificDate(objReaderCustomers(0).ToString, dtSetDate, "customer")
            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            End If
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CUSTOMER NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CUSTOMER BALANCES AS AT " & UCase(gwt_comm.shortMonthDateFormat(dtSetDate))
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
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
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance printing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintPeriodicSalesAnalysis()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            Dim fr = New frmMonthlyAccounts
            fr.ShowDialog()
            Exit Sub
        Else
            MessageBox.Show("You do not have the right to access this part of the system", "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    'Private Sub lnkConfigure_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkConfigure.Click
    '    boolAbort = False
    '    Dim frm As New frmHomePageCustomization
    '    frm.ShowDialog()
    '    If boolAbort = True Then Exit Sub
    '    HomePageUserPreferences()
    'End Sub

    'Private Sub metPos_Click(sender As Object, e As EventArgs) Handles metPos.Click
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\pos.dll") Then
    '        Dim obj As New POS.pos
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub PrintTransfersReport()
        On Error GoTo RaiseErr
        boolAbort = False
        Dim f As New frmDateBranchFilter
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        If UCase(strPrintBranchFilter) = "ALL" Then
            strSql = "SELECT InventoryTransfers.TransDate AS [Date], " _
                & "inventorytransfers.ItemCode as [Code], InventoryItems.GroupName as [Description], " _
                & "SUM(inventorytransfers.Quantity) AS [Qty], " _
                & "CAST(InventoryItems.CostPrice AS DECIMAL (30,2)) AS [Unit Cost], " _
                & "CAST(SUM(inventorytransfers.Quantity * InventoryItems.CostPrice) AS DECIMAL (30,2)) as [Total Cost], " _
                & "inventorytransfers.SourceBranch as [Source], inventorytransfers.ReceivingBranch as [Receiving]" _
                & "FROM inventorytransfers " _
                & "LEFT OUTER JOIN InventoryItems ON inventorytransfers.ItemCode = InventoryItems.ItemCode " _
                & "WHERE TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "' " _
                & "GROUP BY inventorytransfers.ItemCode, InventoryItems.GroupName, inventorytransfers.Quantity, " _
                & "InventoryItems.CostPrice, inventorytransfers.SourceBranch, inventorytransfers.ReceivingBranch, inventorytransfers.transdate " _
                & "ORDER BY InventoryTransfers.TransDate"
        Else
            strSql = "SELECT InventoryTransfers.TransDate AS [Date], " _
                & "inventorytransfers.ItemCode as [Code], InventoryItems.GroupName as [Description], " _
                & "SUM(inventorytransfers.Quantity) AS [QTY], " _
                & "CAST(InventoryItems.CostPrice AS DECIMAL (30,2)) AS [Unit Cost], " _
                & "CAST(SUM(inventorytransfers.Quantity * InventoryItems.CostPrice) AS DECIMAL (30,2)) as [Total Cost], " _
                & "inventorytransfers.SourceBranch as [Source], inventorytransfers.ReceivingBranch as [Receiving]" _
                & "FROM inventorytransfers " _
                & "LEFT OUTER JOIN InventoryItems ON inventorytransfers.ItemCode = InventoryItems.ItemCode " _
                & "WHERE TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "' AND " _
                & "inventorytransfers.ReceivingBranch = '" & strPrintBranchFilter & "' " _
                & "GROUP BY inventorytransfers.ItemCode, InventoryItems.GroupName, inventorytransfers.Quantity, " _
                & "InventoryItems.CostPrice, inventorytransfers.SourceBranch, inventorytransfers.ReceivingBranch, inventorytransfers.transdate " _
                & "ORDER BY InventoryTransfers.TransDate"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim arrPrintData As New ArrayList

        While objReader.Read
            arrPrintData.Add(Format(CDate(objReader(0).ToString), "dd-MM-yyyy") & "|" &
                objReader(1).ToString & "|" &
                objReader(2).ToString & "|" &
                objReader(3).ToString & "|" &
                objReader(4).ToString & "|" &
                objReader(5).ToString & "|" &
                objReader(6).ToString & "|" &
                objReader(7).ToString)
        End While
        objReader.Close()

        'Send the information to the printer

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = Replace(arrPrintData.Item(i), "|", ";", 1)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 8
            .strColumnHeaders = "DATE|ITEM CODE|NAME|QTY|UNIT $|TOTAL|SOURCE|DESTINE"
            .strColumnAlignments = "0|0|0|2|2|2|0|0"
            .strColumnWidths = "60|100|150|40|65|67|80|80"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "INVENTORY TRANSFER REPORT AS AT " & UCase(gwt_comm.shortMonthDateFormat(dtSetDate))
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|NO|YES|YES|YES|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|YES|YES|YES|NO|NO"
            .strSummaryTotals = "NO|NO|NO|YES|YES|YES|NO|NO"
            '.intKeyFieldIndex = 7
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
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Stock transfers report failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdSmallPayslips_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdSmallPayslips.PrintPage
        'Resest
        On Error GoTo RaiseErr
        'If boolPrintFirstThreePayslips = True Then
        '    If itm > 2 Then
        '        e.HasMorePages = False
        '        itm = 0
        '        Exit Sub
        '    End If
        'End If
        HeadingFont = New Font("Arial", 7, FontStyle.Regular)
        Dim intStatsCount As Integer = 0
        Dim eLineCnt As Integer, dLineCnt As Integer, sLineCnt As Integer
        Dim intX1, intX2, intY1, intY2 As Integer
        intLeftMargin = 50 : intRightMargin = 100 : intTopMargin = 40 : intBottomMargin = 40
        intX1 = intLeftMargin ' e.PageBounds.Left + 50
        intX2 = e.PageBounds.Right - intRightMargin
        intY1 = intTopMargin ' e.PageBounds.Top + 100
        intY2 = 500 'e.PageBounds.Bottom - intBottomMargin
        nz = 0

        Dim str As String
        Dim strAmt As String
        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        'Draw the main border
        Dim sbCurrent As SolidBrush 'penCurrent As Pen
        reccurrent = New Rectangle(intX1, intY1, (intX2 - 43), intY2)
        If boolDrawBorders = True Then e.Graphics.DrawRectangle(Pens.Navy, reccurrent)
        Dim intRectangleWidth As Integer = reccurrent.Width
        'chech that it is not a blank payslip
        'If intPrintValues(CInt(intPayslipGrossSalaryCode - 1)) = 0 And _
        '        intPrintValues(CInt(intPayslipTotalDeductionsCode - 1)) = 0 And _
        '        intPrintValues(CInt(intPayslipNetSalaryCode - 1)) = 0 Then
        '    itm = itm + 1
        '    e.HasMorePages = True
        '    Exit Sub
        'End If


        'Print the company logo as a watermark
        If Not String.IsNullOrEmpty(strCompanyLogoPath) Then
            If System.IO.File.Exists(strCompanyLogoPath) Then
                Dim picPrint As New PictureBox
                picPrint.SizeMode = PictureBoxSizeMode.AutoSize
                picPrint.Load(strCompanyLogoPath)
                Dim R As New Rectangle(390, 280, picPrint.Width, picPrint.Height)
                'Dim R As New Rectangle(20, 20, picPrint.Width, picPrint.Height)
                e.Graphics.DrawImage(picPrint.Image, R)
            End If
        End If

        '*** Start Printing and drawing the prefixed item
        '*** the value start position of x = intX1 and that of y = intY1

        'Print the pay advice header
        If boolDrawBorders = True Then Call gwt_comm.DrawStringInBoxLeft(e, intX1, intY1 - 30, intX1 + 200, intY1 - 30, "PAY ADVICE", HeadingFont, Brushes.Black)
        If boolDrawBorders = True Then Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 400, intY1 - 30, intX1 + 600, intY1 - 30, "DOCUMENT NO: " & Format((itm + 1), "000000"), HeadingFont, Brushes.Black)
        'Print the company name and the pay date the same font as that for document no
        e.Graphics.DrawString(UCase(strCompanyName), HeadingFont, System.Drawing.Brushes.Black, intX1 + 1, intTopMargin + 10)
        e.Graphics.DrawString(UCase(gwt_comm.shortMonthDateFormat(dtPayslip)), HeadingFont, System.Drawing.Brushes.Black, intX1 + 570, intTopMargin + 10)
        'e.Graphics.DrawString("Powered by Embassy@Great Wits Technologies", fntSmallPrintFont, Brushes.Black, intX1, intY2 + ((intBottomMargin / 2) * 1.5))
        'Draw the 3 lines after
        intY1 = intY1 + 40
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print the headers
        intY1 = intY1 + 5
        If boolDrawBorders = True Then
            With e.Graphics
                .DrawString("PAYROLL", fntFinePrintFont, Brushes.Navy, intX1 + 1, intY1)
                .DrawString("PAYPOINT", fntFinePrintFont, Brushes.Navy, intX1 + 53, intY1)
                .DrawString("EMPLOYEE NO", fntFinePrintFont, Brushes.Navy, intX1 + 103, intY1)
                .DrawString("CLOCK NO", fntFinePrintFont, Brushes.Navy, intX1 + 175, intY1)
                .DrawString("TAX CODE", fntFinePrintFont, Brushes.Navy, intX1 + 235, intY1)
                .DrawString("COST CENTER", fntFinePrintFont, Brushes.Navy, intX1 + 293, intY1)
                .DrawString("BASIC RATE", fntFinePrintFont, Brushes.Navy, intX1 + 435, intY1)
                .DrawString("BANK ACCOUNT NUMBER", fntFinePrintFont, Brushes.Navy, intX1 + 531, intY1)
                'Draw the small box margins
                'right of payroll column header
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 50, intY1 - 5,
                                intX1 + 50, intY1 + 60)
                'right of paypoint column header
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 100, intY1 - 5,
                                intX1 + 100, intY1 + 60)
                'right of employee number column header
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 173, intY1 - 5,
                                intX1 + 173, intY1 + 60)
                'right of the clock number code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 233, intY1 - 5,
                                intX1 + 233, intY1 + 60)
                'right of the tax code code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 290, intY1 - 5,
                                intX1 + 290, intY1 + 60)
                'right of the cost center code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 432, intY1 - 5,
                                intX1 + 432, intY1 + 60)
                'right of the basic rate code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 528, intY1 - 5,
                                intX1 + 528, intY1 + 60)

                'The next 3 lines drop down further that the others
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 190, intY1 + 60,
                                intX1 + 190, (intY2 + 41)) ' intY1 + 655)
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 303, intY1 + 60,
                                intX1 + 303, (intY2 + 41)) ' intY1 + 655)
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 408, intY1 + 60,
                                intX1 + 408, intY1 + 453)
                ''e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 453, intY1 - 5, _
                ''                intX1 + 453, intY1 + 60)
                ''e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 528, intY1 - 45, _
                ''                intX1 + 528, intY1 + 60)
                'Print the earnings amount left division line
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 600, intY1 + 60,
                                intX1 + 600, intY2 + 41) ' intY1 + 655)
                'Draw the totals horizontal lines
                e.Graphics.DrawLine(Pens.Navy, intX1, intY1 + 225, reccurrent.Right, intY1 + 225)
                e.Graphics.DrawLine(Pens.Navy, intX1, intY1 + 255, reccurrent.Right, intY1 + 255)
                e.Graphics.DrawLine(Pens.Navy, intX1, intY1 + 285, reccurrent.Right, intY1 + 285)
            End With
        End If
        'Draw the horizontal lines for the employment and earnings and deduction sections
        intY1 = intY1 + 20
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        intY1 = intY1 + 40
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        intY1 = intY1 + 30
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print column headers at - 20 the value of y
        If boolDrawBorders = True Then e.Graphics.DrawString("EARNINGS", SubHeadingFont, Brushes.Navy, intX1 + 1, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("UNITS", SubHeadingFont, Brushes.Navy, intX1 + 223, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("AMOUNT", SubHeadingFont, Brushes.Navy, intX1 + 323, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("DEDUCTIONS", SubHeadingFont, Brushes.Navy, intX1 + 406, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("AMOUNT", SubHeadingFont, Brushes.Navy, intX1 + 628, intY1 - 20)
        'Print the totals row header
        If boolDrawBorders = True Then e.Graphics.DrawString("TOTALS", SubHeadingFont, Brushes.Navy, intX1 + 1, 320)
        Dim intTotalsYaxis As Integer = intY1 + 240
        'We begin printing the individual pay details
        '*******************************************************************************************
        '
        'Begin by getting the print details
        'Open the payslip runfile and get the current employee details
        strCurrentEmployeeBeingProcessed = strEmployeeFullDetails(itm)
        'Get the bank account details
        strCurrentEmployeeBankDetails = strBankAccountDetails(itm)
        If String.IsNullOrEmpty(strCurrentEmployeeBeingProcessed) Then strCurrentEmployeeBeingProcessed = ";;"
        If String.IsNullOrEmpty(strCurrentEmployeeBankDetails) Then strCurrentEmployeeBankDetails = ";;"
        strCurrentEmployeeBeingProcessedArray = Split(strCurrentEmployeeBeingProcessed, ";")
        strCurrentEmployeeBankDetailsArray = Split(strCurrentEmployeeBankDetails, ";")
        'Get the employment details
        strCurrentEmployeeEmploymentDetails = strEmploymentFullDetails(itm)
        If String.IsNullOrEmpty(strCurrentEmployeeEmploymentDetails) Then strCurrentEmployeeEmploymentDetails = ";;;;"
        strCurrentEmployeeEmploymentDetailsArray = Split(strCurrentEmployeeEmploymentDetails, ";")

        '-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        'Employee number
        e.Graphics.DrawString(strCurrentEmployeeBeingProcessedArray(0), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 102, (125 + (intEmploymentIndent * 15)))
        'Paypoint
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(1), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 53, (125 + (intEmploymentIndent * 15)))
        'Clock number
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(3), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 175, (125 + (intEmploymentIndent * 15)))
        'Tax Code
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(4), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 235, (125 + (intEmploymentIndent * 15)))

        'Build the surname and initials string
        Dim strShortName As String = strCurrentEmployeeBeingProcessedArray(1)
        If Not String.IsNullOrEmpty(strCurrentEmployeeBeingProcessedArray(2)) Then
            strShortName = strShortName & " " & strCurrentEmployeeBeingProcessedArray(2)
        End If
        'If Not String.IsNullOrEmpty(strCurrentEmployeeBeingProcessedArray(3)) Then
        '    strShortName = strShortName & " " & Mid(strCurrentEmployeeBeingProcessedArray(3), 1, 1)
        'End If
        'Print the employee name up in the same row as company name
        e.Graphics.DrawString(UCase(strShortName), HeadingFont, System.Drawing.Brushes.Black, intX1 + 305, (intTopMargin + 10))

        'Print the bank account number
        e.Graphics.DrawString(UCase(strCurrentEmployeeBankDetailsArray(2)), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 530, (125 + (intEmploymentIndent * 15)))

        '-*- Print the employment details for the cost center and department and paypoint
        '-*- Limit the six of these fields accordingly so that there is no printing overlap

        '-*- EMPLOYEE NUMBER -*-
        If strCurrentEmployeeEmploymentDetailsArray(2).Length > 8 Then strCurrentEmployeeEmploymentDetailsArray(2) = Mid(strCurrentEmployeeEmploymentDetailsArray(2), 1, 8)

        '-*- COST CENTER -*-
        If strCurrentEmployeeEmploymentDetailsArray(5).Length > 15 Then strCurrentEmployeeEmploymentDetailsArray(5) = Mid(strCurrentEmployeeEmploymentDetailsArray(5), 1, 15)
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(5), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 305, (125 + (intEmploymentIndent * 15)))
        'PRINT PAYROLL NUMBER
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(0), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 20, (125 + (intEmploymentIndent * 15)))
        '' ''****e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(6), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 205, 180)

        '-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        'Get the runfile details from the run table
        Dim strSql As String = Nothing
        Dim strRunfText As String = Nothing

        'strSql = "SELECT CONVERT(NVARCHAR, EmpNo) +';'+ CONVERT(NVARCHAR, OrdinalNo) +';'+ CONVERT(NVARCHAR, Amt) AS [Details] FROM PW_RunfAmts WHERE Usage = 1" 'Verify the value for the non manual payslips
        strSql = "SELECT RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = '" & strCurrentEmployeeBeingProcessedArray(0) & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objPayslipRunfile As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objPayslipRunfile.HasRows Then
            objPayslipRunfile.Read()
            strRunfText = objPayslipRunfile(0).ToString
            Dim intCdeCnt As Integer = 0
            Dim strRunfLine() As String = Split(strRunfText, "|")
            ReDim intPrintValues(0 To strRunfLine.Length - 1)
            For intCdeCnt = 0 To strRunfLine.Length - 1
                If Not String.IsNullOrEmpty(strRunfLine(intCdeCnt)) Then
                    intPrintValues(intCdeCnt) = CDbl(strRunfLine(intCdeCnt))
                Else
                    intPrintValues(intCdeCnt) = 0
                End If
            Next
        End If

        'Close the file
        objPayslipRunfile.Close()

        'Loop through payslip file and print details based on it
        eLineCnt = intY1 + (intEarningsIndent * 15) + 5 : dLineCnt = intY1 + (intEarningsIndent * 15) + 5
        sLineCnt = intY1 + (intStatisticsIndent * 15) + 200
        'Print the employee main details here

        For nz = 0 To intPayslipLinesCount - 1

            sPayslipLineText = Split(strPayslipLineDetails(nz), ";")
            strPayslipColumnType = sPayslipLineText(2)

            'Get the value of the amounts
            Dim dblUnitValue As Double = 0
            Dim dblAmountValue As Double = 0

            If CInt(sPayslipLineText(3)) - 1 >= 0 Then dblUnitValue = intPrintValues(CInt(sPayslipLineText(3)) - 1)
            If CInt(sPayslipLineText(4)) - 1 >= 0 Then dblAmountValue = intPrintValues(CInt(sPayslipLineText(4)) - 1)

            Select Case UCase(strPayslipColumnType)
                Case Is = "E"
                    'check that the value is greater than zero
                    If CInt(sPayslipLineText(4)) > 0 Then

                        '********* strAmt = CStr(Format(intPrintValues(CInt(sPayslipLineText(3) - 1)), "#,##0.00"))
                        If CDbl(dblAmountValue) > 0 Then
                            'Print the description
                            str = sPayslipLineText(1)
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1, eLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)

                            'Print the units. First get the value of the unit column from the run file
                            If CInt(sPayslipLineText(3)) > 0 Then
                                If dblUnitValue > 0 Then
                                    str = CStr(Format(dblUnitValue, "#,##0.00"))
                                    Call gwt_comm.DrawStringInBoxRight(e, intX1 + 303, eLineCnt, W1, 100, str, fntPrintFont, Brushes.Black)
                                End If
                            End If

                            'Print the amounts
                            str = CStr(Format(dblAmountValue, "#,##0.00"))
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 403, eLineCnt, W1, 100, str, fntPrintFont, Brushes.Black)
                            'increament the line counter for earnings
                            eLineCnt = eLineCnt + 15
                        End If
                    End If
                Case Is = "D"
                    'Print the description
                    If CInt(sPayslipLineText(4)) > 0 Then
                        strAmt = CStr(Format(dblAmountValue, "#,##0.00"))
                        If CDbl(strAmt) > 0 Then
                            str = sPayslipLineText(1)
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 409, dLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)
                            'Print the amounts
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 680, dLineCnt, W1, 100, strAmt, fntPrintFont, Brushes.Black)
                            'increament the line counter for deductions
                            dLineCnt = dLineCnt + 15
                        End If
                    End If
                Case Is = "L"
                    'Print the description
                    If CInt(sPayslipLineText(4)) > 0 Then
                        strAmt = CStr(Format(dblAmountValue, "#,##0.00"))
                        If CDbl(strAmt) > 0 Then
                            str = sPayslipLineText(1)
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 409, dLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)
                            'Print the amounts
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 680, dLineCnt, W1, 100, strAmt, fntPrintFont, Brushes.Black)
                            'increament the line counter for deductions
                            dLineCnt = dLineCnt + 15
                        End If
                    End If
                Case Is = "S"
                    'Print the description
                    If CInt(sPayslipLineText(4)) > 0 Then
                        strAmt = CStr(Format(dblAmountValue, "#,##0.00"))
                        If CDbl(strAmt) > 0 Then
                            If intStatsCount < 10 Then
                                str = sPayslipLineText(1)
                                Call gwt_comm.DrawStringInBoxLeft(e, intX1, sLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)
                                'Print the amounts
                                Call gwt_comm.DrawStringInBoxRight(e, intX1 + 300, sLineCnt, W1, 100, strAmt, fntPrintFont, Brushes.Black)
                                'increament the line counter for statistics
                                sLineCnt = sLineCnt + 15
                                intStatsCount += 1
                            End If
                        End If
                    End If
            End Select
        Next
        'Print the payslip gross and deductions total
        'intY1 = intY1 - 30
        str = CStr(Format(intPrintValues(intPayrollGrossIncomeCode - 1), "#,##0.00"))
        Call gwt_comm.DrawStringInBoxRight(e, X1 + 443, 320, W1, 100, str, fntPrintFont, Brushes.Black)
        'Print the total deductions amount
        str = CStr(Format(intPrintValues(intPayrollTotalDeductions - 1), "#,##0.00"))
        Call gwt_comm.DrawStringInBoxRight(e, X1 + 723, 325, W1, 100, str, fntPrintFont, Brushes.Black)
        'print the net salary
        str = CStr(Format(intPrintValues(intPayrollNetIncomeCode - 1), "#,##0.00"))
        If boolDrawBorders = True Then Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 410, 350, W1, 150, "NET PAY", SubHeadingFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X1 + 730, 350, W1, 100, str, fntPrintFont, Brushes.Black)
        'Print the net salary line divide with messages

        'Print the employer details
        'If Not String.IsNullOrEmpty(strCompanyAddressInformation) Then
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 600, W1, 250, UCase("Proudly employed by:"), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 615, W1, 250, UCase(strCompanyName), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 630, W1, 250, UCase(strCompanyAddress1), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 645, W1, 250, UCase(strCompanyAddress2), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 660, W1, 250, UCase(strCompanyAddress3), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 675, W1, 250, UCase(strCompanyAddress4), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 690, W1, 250, UCase(strCompanyTelephone), fntFooter, Brushes.Black)
        'End if
        If itm >= (intPayslipProcessingCount - 1) Then
            e.HasMorePages = False
            itm = 0
        Else
            e.HasMorePages = True
            itm = itm + 1
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payslip Print"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Public Sub PrintPayrollSummary()
        'Payroll summary
        On Error GoTo RaiseErr
        boolAbort = False
        gwt_comm.PayrollSummarySortOptions()
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
        '    & "CAST(Col1Unit1 AS DECIMAL (30,2)), CAST(Col1Unit2 AS DECIMAL (30,2)), Col2Description, " _
        '    & "CAST(Col2Unit1 AS DECIMAL (30,2)), CAST(Col2Unit2 AS DECIMAL (30,2)), SortKey FROM " _
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
            .BorderColor = Color.FromName("LightGray")
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
            MessageBox.Show("Please enter the employee number for whom the register is to be printed",
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
                Return strReturn
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
                Return strReturn
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

    'Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
    '    If System.IO.File.Exists(Application.StartupPath & "\PatientPlus.dll") Then
    '        Dim obj As New PatientPlus.PatientPlus
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

    Public Function StockMovementsDetails(ByVal SelectedStartDate As Date, ByVal SelectedEndDate As Date) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryItems.ItemCode +'|'+ CONVERT(NVARCHAR, " _
        '    & "InventoryItems.Quantity), InventoryItems.GroupName, Sales.ItemCode FROM Sales, InventoryItems " _
        '    & "WHERE Sales.ItemCode = InventoryItems.ItemCode AND Sales.TransDate BETWEEN '" & SelectedDateFrom & "' " _
        '    & "AND '" & SelectedDateTo & "' GROUP BY InventoryItems.ItemCode, InventoryItems.GroupName, " _
        '    & "Sales.ItemCode, InventoryItems.Quantity", cnn)
        'objReader = objCommand.ExecuteReader

        Dim strStartingDate As String = CStr(gwt_comm.shortMonthDateFormat(SelectedEndDate))
        Dim strEndingDate As String = CStr(gwt_comm.shortMonthDateFormat(SelectedStartDate))

        objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryItems.ItemCode +'|'+ CONVERT(NVARCHAR, " _
            & "InventoryItems.Quantity), InventoryItems.GroupName FROM InventoryItems " _
            & "WHERE InventoryItems.ItemCode IN (SELECT DISTINCT(ItemCode) FROM Sales WHERE " _
            & "Sales.TransDate BETWEEN '" & strStartingDate & "' AND '" & strEndingDate & "')", cnn)
        objReader = objCommand.ExecuteReader

        Dim intCount As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(DISTINCT ItemCode) FROM Sales WHERE " _
            & "Sales.TransDate BETWEEN '" & strStartingDate & "' AND '" & strEndingDate & "'", cnn)
        Dim objReadCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadCount.HasRows = True Then
            objReadCount.Read()
            intCount = CInt(objReadCount(0).ToString)
        End If
        objReadCount.Close()

        'Get also from the customer sales table
        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(DISTINCT ItemCode) FROM CustomerSales WHERE " _
            & "CustomerSales.TransDate BETWEEN '" & strStartingDate & "' AND '" & strEndingDate & "'", cnn)
        objReadCount = objCommand.ExecuteReader
        If objReadCount.HasRows = True Then
            objReadCount.Read()
            intCount = intCount + CInt(objReadCount(0).ToString)
        End If
        objReadCount.Close()

        With Me.pb1
            .Value = 0
            .Maximum = intCount + 1
            .Visible = True
        End With

        While objReader.Read
            'Get the list of movements to date from the start date
            Dim intQuantitySold As Integer = 0
            Dim intQuantityReceived As Integer = 0
            Dim intQuantityTransferIn As Integer = 0
            Dim intQuantityTransferOut As Integer = 0

            Dim strBuffer() As String = Split(objReader(0).ToString, "|")

            Dim strSql As String

            '
            'Get the sales quantity
            '
            strSql = "SELECT SUM(Quantity) FROM Sales WHERE ItemCode = '" & strBuffer(0) & "' AND TransDate >= '" & shortMonthDateFormat(StartDate) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadQuantities As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            'Get from the customer sales tables as well
            strSql = "SELECT SUM(Quantity) FROM CustomerSales WHERE ItemCode = '" & strBuffer(0) & "' AND TransDate >= '" & shortMonthDateFormat(StartDate) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = intQuantitySold + CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the received quantity
            '
            strSql = "SELECT SUM(Quantity) FROM OrdersReceipt WHERE ItemCode = '" & strBuffer(0) & "' AND TransDate >= '" & shortMonthDateFormat(StartDate) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityReceived = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers in quantity
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate >= '" & shortMonthDateFormat(StartDate) & "' AND ReceivingBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferIn = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers out quantity
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate >= '" & shortMonthDateFormat(StartDate) & "' AND SourceBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferOut = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            'Current Balance + Transfers Out - Transfers in

            Dim intStartQuantities As Integer = CInt(strBuffer(1)) + ((intQuantityReceived + intQuantityTransferIn) - (intQuantitySold + intQuantityTransferOut))

            'Get the quantities based on the range dates
            '***************************************************************************************************************
            '
            intQuantityReceived = 0 : intQuantitySold = 0 : intQuantityTransferIn = 0 : intQuantityTransferOut = 0

            '
            'Get the sales quantity for the period in question
            '
            strSql = "SELECT SUM(Quantity) FROM Sales WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            'Accumulate the customer sales as well
            strSql = "SELECT SUM(Quantity) FROM CustomerSales WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = intQuantitySold + CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the received quantity for the period
            '
            strSql = "SELECT SUM(Quantity) FROM OrdersReceipt WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityReceived = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers in quantity for the period
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & EndDate & "' AND ReceivingBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferIn = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers out quantity for the period
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & shortMonthDateFormat(StartDate) & "' AND '" & shortMonthDateFormat(EndDate) & "' AND SourceBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferOut = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()


            '
            '** BUILD THE OUTPUT ARRAY TO SHOW AS FOLLOWS
            '
            'ITEM CODE|CURRENT-BAL|PERIOD START BAL|RECEIVED|TRANSFERS-IN|SOLD|TRANSFER OUT|END BAL
            '
            '/// intStartQuantities = (intQuantityReceived + intQuantityTransferIn) - (intQuantitySold + intQuantityTransferOut)
            intStartQuantities = (CInt(strBuffer(1)) + (intQuantityTransferOut + intQuantitySold)) - (intQuantityTransferIn + intQuantityReceived)

            If intStartQuantities < 0 Then intStartQuantities = 0
            Dim intEndQuantities As Integer = intStartQuantities + ((intQuantityReceived + intQuantityTransferIn) - (intQuantitySold + intQuantityTransferOut))

            arrReturn.Add(strBuffer(0) & "|" & strBuffer(1) & "|" & intStartQuantities & "|" & intQuantityReceived _
                & "|" & intQuantityTransferIn & "|" & intQuantitySold & "|" & intQuantityTransferOut & "|" & intEndQuantities)

            'Check that the item is not specific in nature. If it is then detail the serial numbers affected

            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType FROM InventoryItems WHERE ItemCode = '" & strBuffer(0) & "'", cnn)
            Dim objReadItem As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadItem.HasRows Then
                objReadItem.Read()
                If objReadItem(0).ToString = "SPECIFIC" Then

                    'Select the serial numbers from received items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM OrdersReceipt WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & strStartingDate & "' " _
                        & "AND '" & strEndingDate & "'", cnn)
                    Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    Dim arrReceived As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrReceived.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from transfers in items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM InventoryTransfers WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & strStartingDate & "' " _
                        & "AND '" & strEndingDate & "' AND ReceivingBranch = '" & strUserBranch & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    Dim arrTransfersIn As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrTransfersIn.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from transfers out items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM InventoryTransfers WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & strStartingDate & "' " _
                        & "AND '" & strEndingDate & "' AND SourceBranch = '" & strUserBranch & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    Dim arrTransfersOut As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrTransfersOut.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from Sales items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM Sales WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & strStartingDate & "' " _
                        & "AND '" & SelectedEndDate & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    Dim arrSales As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrSales.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from CustomerSales items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM CustomerSales WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & strStartingDate & "' " _
                        & "AND '" & shortMonthDateFormat(SelectedEndDate) & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrSales.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    Dim intLines As Integer = 0
                    If intLines < arrReceived.Count Then intLines = arrReceived.Count
                    If intLines < arrTransfersIn.Count Then intLines = arrTransfersIn.Count
                    If intLines < arrTransfersOut.Count Then intLines = arrTransfersOut.Count
                    If intLines < arrSales.Count Then intLines = arrSales.Count

                    'Add the lines to the output array
                    '
                    For p As Integer = 0 To intLines - 1
                        'ITEM CODE|CURRENT-BAL|PERIOD START BAL|RECEIVED|TRANSFERS-IN|SOLD|TRANSFER OUT|END BAL
                        '

                        Dim strReceivedSerial As String = Nothing
                        Dim strTransInSerial As String = Nothing
                        Dim strSalesSerial As String = Nothing
                        Dim strTransOutSerial As String = Nothing

                        If (p < arrReceived.Count And arrReceived.Count > 0) Then strReceivedSerial = arrReceived.Item(p)
                        If (p < arrTransfersIn.Count And arrTransfersIn.Count > 0) Then strTransInSerial = arrTransfersIn.Item(p)
                        If (p < arrSales.Count And arrSales.Count > 0) Then strSalesSerial = arrSales.Item(p)
                        If (p < arrTransfersOut.Count And arrTransfersOut.Count > 0) Then strTransOutSerial = arrTransfersOut.Item(p)

                        arrReturn.Add("     Affected Serials| | |" & strReceivedSerial & "|" & strTransInSerial & "|" & strSalesSerial & "|" & strTransOutSerial & "| ")

                    Next

                End If
            End If
            objReadItem.Close()

            'Add blank line after each item
            'arrReturn.Add(" | | | | | | | ")

            Me.pb1.Value = Me.pb1.Value + 1

        End While
        objReader.Close()

        Me.pb1.Value = Me.pb1.Maximum

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Detailed Stock movement report generation"
        gwt_comm.ShowErrorMessage()
    End Function

    'Private Sub mtAssets_Click(sender As Object, e As EventArgs) Handles mtAssets.Click
    '    LoadAssets()
    'End Sub

    'Private Sub mtDebtCollection_Click(sender As Object, e As EventArgs) Handles mtDebtCollection.Click
    '    LoadDebtCollection()
    'End Sub

    'Private Sub mtDispensing_Click(sender As Object, e As EventArgs) Handles mtDispensing.Click

    'End Sub

    'Private Sub mtDoctors_Click(sender As Object, e As EventArgs) Handles mtDoctors.Click
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\PatientPlus.dll") Then
    '        Dim obj As New PatientPlus.PatientPlus
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub mtLoans_Click(sender As Object, e As EventArgs) Handles mtLoans.Click
    '    'LoadLoans
    'End Sub

    'Private Sub mtOrders_Click(sender As Object, e As EventArgs) Handles mtOrders.Click
    '    LoadOrders()
    'End Sub

    'Private Sub mtOrganisation_Click(sender As Object, e As EventArgs) Handles mtOrganisation.Click
    '    LoadOrganisation()
    'End Sub

    'Private Sub mtProjects_Click(sender As Object, e As EventArgs) Handles mtProjects.Click
    '    LoadProjects()
    'End Sub

    'Private Sub mtnHotels_Click(sender As Object, e As EventArgs) Handles mtnHotels.Click
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\HotelManagement.dll") Then
    '        Dim obj As New HotelManagement.HotelManager
    '        obj.Activate(strConnection)
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
    '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    ''Private Sub mtrCrm_Click(sender As Object, e As EventArgs) Handles mtrCrm.Click
    ''    LoadCrm()
    ''End Sub

    Private Sub btnPos_Click(sender As System.Object, e As System.EventArgs) Handles btnPos.Click
        'LoadPos()
        'If UCase(cnn.Database) = UCase("iTel") Then
        Dim frm As New frmPosMain2
        frm.ShowDialog()
        'Else
        '    Cursor = Cursors.WaitCursor
        '    If System.IO.File.Exists(Application.StartupPath & "\pos.dll") Then
        '        Dim obj As New POS.pos
        '        obj.Activate(strConnection)
        '    Else
        '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider",
        '            "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        '    Cursor = Cursors.Default
        'End If
    End Sub

    'Private Sub btnCrm_Click(sender As System.Object, e As System.EventArgs) Handles btnCrm.Click
    '    LoadCrm()
    'End Sub

    'Private Sub LoadCrm()
    '    Cursor = Cursors.WaitCursor
    '    If System.IO.File.Exists(Application.StartupPath & "\CrmLight.dll") Then
    '        boolAbort = False
    '        Dim obj As New CRMLight.crm
    '        obj.Activate(strConnection)
    '        obj = Nothing
    '    Else
    '        MessageBox.Show("The called module is not licensed on to you. Please contact your software provider", _
    '                        "Missing Application Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub btnCorps_Click(sender As System.Object, e As System.EventArgs) Handles btnCorps.Click
        RunCorporatives()
    End Sub

    Private Sub btnBudgets_Click(sender As System.Object, e As System.EventArgs) Handles btnBudgets.Click
        Dim frm As New frmBudgets
        frm.ShowDialog()
    End Sub

    Private Sub btnChartOfAccounts_Click(sender As System.Object, e As System.EventArgs) Handles btnChartOfAccounts.Click
        Dim frm As New frmLedgerAccountsSetupListing
        'frm.ShowDialog()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabAccounts, CurrentTabColor)
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
        RefreshTabs(tabInventory)
        RefreshTabs(tabHr)
    End Sub

    Private Sub btnExitPasses_Click(sender As System.Object, e As System.EventArgs) Handles btnExitPasses.Click
        LoadPasses()
    End Sub

    Private Sub LoadPasses()
        Dim frm As New frmGatePassesListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        AddTabbedForm(frm, tabInventory, CurrentTabColor)
    End Sub

    'Private Sub tabInventory_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabInventory.TabItemClose
    '    If UCase(e.Tab.Text) = UCase("Home") Then
    '        e.Cancel = True
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub tabHr_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabSales.TabItemClose
        If UCase(e.Tab.Text) = UCase("Home") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub btnTransfers_Click(sender As System.Object, e As System.EventArgs) Handles btnTransfers.Click
        Dim frm As New frmInventoryTransfers
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        AddTabbedForm(frm, tabInventory, CurrentTabColor)
    End Sub

    Private Sub btnPaywellImport_Click(sender As System.Object, e As System.EventArgs) Handles btnPaywellImport.Click
        Dim frm As New frmPaywellImports
        frm.ShowDialog()
    End Sub

    Private Sub btnPersonnelManagement_Click(sender As System.Object, e As System.EventArgs) Handles btnPersonnelManagement.Click
        Dim frm As New frmEmployeeListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabHr, CurrentTabColor)
        'tabHr.SelectedTabIndex = tabHr.Tabs.Count - 1
    End Sub

    Private Sub btnJobProfiles_Click(sender As System.Object, e As System.EventArgs) Handles btnJobProfiles.Click
        Dim frm As New frmJobsListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        AddTabbedForm(frm, tabHr, CurrentTabColor)
        'tabHr.SelectedTabIndex = tabHr.Tabs.Count - 1
    End Sub

    Private Sub btnTraining_Click(sender As System.Object, e As System.EventArgs) Handles btnTraining.Click
        Dim frm As New frmEducationCoursesView
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        AddTabbedForm(frm, tabHr, CurrentTabColor)
        'tabHr.SelectedTabIndex = tabHr.Tabs.Count - 1
    End Sub

    Private Sub btnPayroll_Click(sender As System.Object, e As System.EventArgs) Handles btnPayroll.Click

        boolAbort = False
        Dim frm As New frmRunMode
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        intSelectedEmployeesCnt = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Count(EmployeeNo) FROM EmployeeMaster WHERE Status = 'ACTIVE'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intSelectedEmployeesCnt = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        Dim arrNos As New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM EmployeeMaster WHERE Status = 'ACTIVE'", cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrNos.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        If arrNos.Count <= 0 Then
            MessageBox.Show("No records were found to process in payroll", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ReDim strSelectedEmployees(0 To (intSelectedEmployeesCnt - 1))
        'Get the employees numbers of all the employees and populate to the array
        For n As Integer = 0 To arrNos.Count - 1
            strSelectedEmployees(n) = arrNos.Item(n)
        Next
        ProcessPayrollControl()
        Cursor = Cursors.Default

    End Sub

    '=======PAYROLL RUN MODULES==================

    Public Sub ProcessPayrollControl()
        'On Error GoTo RaiseErr
        boolAbort = False
        'First Get the neccessary resources from the files to run the payroll
        'First make a backup of the post run
        InitializePayrollRun()
        If boolAbort = True Then boolAbort = False

        With gwt_comm
            .AssignSystemCodes()
            If boolAbort = True Then Exit Sub
            .BalanceDeductionCodes()
            If boolAbort = True Then Exit Sub
            .AssignSystemMasterFields()
            If boolAbort = True Then Exit Sub
            .LoadCalculationsToArray()
            If boolAbort = True Then Exit Sub
            'TableValues()
            If boolAbort = True Then Exit Sub
            .CheckCalendar()
            If boolAbort = True Then Exit Sub
            .InitializeExceptionFile()
            If boolAbort = True Then Exit Sub
            .GetKeyDataFields()
            If boolAbort = True Then Exit Sub
            .AssignTrekkedFields()
            If boolAbort = True Then Exit Sub
            .AssignYearToDates()
            If boolAbort = True Then Exit Sub
            .AssignBatchesToArray()
            If boolAbort = True Then Exit Sub
            .LoadConstantsToArray()
            If boolAbort = True Then Exit Sub
            .GetTaxTables()
            If boolAbort = True Then Exit Sub
        End With

        Dim p As Integer
        Me.pb1.Value = 0
        Me.pb1.Visible = True
        Me.pb1.Maximum = intSelectedEmployeesCnt
        '

        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunFile", cnn)
        sqlCommand.ExecuteNonQuery()
        'initialize the employee run array
        '
        arrPayrollRunCodes = New ArrayList
        arrPayrollStorageCodes = New ArrayList
        arrPayrollQmfCodes = New ArrayList
        arrExceptionsRaised = New ArrayList
        arrPayrollRunMasterFields = New ArrayList

        Cursor = Cursors.WaitCursor

        For p = 0 To (intSelectedEmployeesCnt - 1)
            strCurrentProcessingEmployee = strSelectedEmployees(p)
            'Crete a single line employee codes file
            gwt_comm.UpdateOnelineEmployeeCodes(strCurrentProcessingEmployee)
            If boolAbort = True Then Exit Sub
            gwt_comm.UpdateOnelineEmployeeMasterFields(strCurrentProcessingEmployee)
            If boolAbort = True Then Exit Sub
            gwt_comm.LoadIndicatorsToArray(strCurrentProcessingEmployee)
            If boolAbort = True Then Exit Sub
            'Load the current employee dates
            dtCurrentEmployeeBirthDate = CDate(gwt_comm.LoadBirthDate(strCurrentProcessingEmployee))
            If boolAbort = True Then GoTo CloseRoutine
            dtCurrentEmployeeHireDate = CDate(gwt_comm.LoadHireDate(strCurrentProcessingEmployee))
            If boolAbort = True Then GoTo CloseRoutine
            'based on the current employee, load that particular employee pay field values to an array
            gwt_comm.LoadActiveEmployeePayrollCodes(strCurrentProcessingEmployee)
            If boolAbort = True Then GoTo CloseRoutine
            gwt_comm.LoadActiveEmployeePayrollMasterFields(strCurrentProcessingEmployee)
            If boolAbort = True Then GoTo CloseRoutine
            gwt_comm.ComputePayroll(strCurrentProcessingEmployee)
            If boolAbort = True Then GoTo CloseRoutine
            Me.pb1.Value = Me.pb1.Value + 1
        Next

        'Update the current run period to Y
        UpdateCalendar()

        'Clear payroll batches
        Dim objClearBatches As Data.OleDb.OleDbCommand
        objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        objClearBatches.ExecuteNonQuery()

        'If MessageBox.Show("Do you want to clear the current payroll batches or move them to batch buffer?" & vbCrLf &
        '    "Press YES to clear without saving. Otherwise press NO to save and then clear", "Confirm Batch Clearance",
        '    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
        '    objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        '    objClearBatches.ExecuteNonQuery()
        'Else
        '    'move them to the batches trek file
        '    UpdateBatchHistory()
        '    objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        '    objClearBatches.ExecuteNonQuery()
        'End If
        'Request for the postrun backup

        boolAbort = False
        gwt_comm.BackupDatabase()
        If boolAbort = True Then Exit Sub
        gwt_comm.GetCurrentPeriodRunDetails()
        MessageBox.Show("Payroll Run Completed Successfully", "Payroll Run Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
CloseRoutine:
        'Close all the opn files
        'objTemporaryRunFile.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Payroll Run Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Sub InitializePayrollRun()
        On Error GoTo RaiseErr
        'Request for a backup of the current files
        boolAbort = False
        gwt_comm.BackupDatabase()
        If boolAbort = True Then Exit Sub
        'Initialize the payroll runfile table
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunCodes", cnn)
        sqlCommand.ExecuteNonQuery()

        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunFile", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Run Initialization"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub UpdateBatchHistory()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [EntryLineNo],[BatchNo],[EmployeeNo],[Amount],[TransDate],[CodeNo]" _
            & ",[CostCode],[UserName],[EffectivePeriod],[Class] FROM [EmployeeBatches]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strSql = "INSERT INTO [EmployeeBatches]([EntryLineNo],[BatchNo],[EmployeeNo],[Amount]" _
               & ",[TransDate],[CodeNo],[CostCode],[UserName],[EffectivePeriod]" _
               & ",[Class]) VALUES (" & objReader(0).ToString & "" _
               & "," & objReader(1).ToString & ", '" & objReader(2).ToString & "'" _
               & "," & objReader(3).ToString & ", '" & objReader(4).ToString & "'" _
               & "," & objReader(5).ToString & ", '" & objReader(6).ToString & "'" _
               & ",'" & objReader(7).ToString & "', " & objReader(8).ToString & "" _
               & "," & objReader(9).ToString & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Batch History Update"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub UpdateCalendar()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("UPDATE SystemCalendar SET " _
            & "RunStatus = 'Y' WHERE TaxPeriod = " & intCurrentRunNumber & "", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calendar Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnIvoices_Click(sender As System.Object, e As System.EventArgs) Handles btnInvoicing.Click
        Dim frm As New frmInvoicesListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    Private Sub tabSales_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabSales.TabItemClose
        If UCase(e.Tab.Text) = UCase("Home") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub btnCreditNotes_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditNotes.Click
        Dim frm As New frmCreditNotesListings
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Orange
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    Private Sub btnQuotations_Click(sender As System.Object, e As System.EventArgs) Handles btnQuotations.Click
        Dim frm As New frmQuotationsListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    Private Sub btnCustomerPayments_Click(sender As System.Object, e As System.EventArgs) Handles btnCustomerPayments.Click
        boolAbort = False
        gwt_comm.CashbookSelection()
        If boolAbort = True Then Exit Sub
        Dim frm2 As New frmAdvanceInvoiceSettlement
        frm2.ShowDialog()
    End Sub

    Private Sub tabInventory_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabInventory.TabItemClose
        If UCase(e.Tab.Text) = UCase("Home") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub tabCreditors_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabCreditors.TabItemClose
        If UCase(e.Tab.Text) = UCase("Creditors and Suppliers") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub tabAccounts_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabAccounts.TabItemClose
        If UCase(e.Tab.Text) = UCase("Home") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub btnLedgerEntries_Click(sender As System.Object, e As System.EventArgs) Handles btnLedgerEntries.Click
        Dim frm As New frmLedgerTransactions
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabAccounts, CurrentTabColor)
    End Sub

    Private Sub btnLedgers_Click(sender As System.Object, e As System.EventArgs) Handles btnLedgers.Click
        Dim frm As New frmJournals
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Orange
        AddTabbedForm(frm, tabAccounts, CurrentTabColor)
    End Sub

    Private Sub btnCashbooks_Click(sender As System.Object, e As System.EventArgs) Handles btnCashbooks.Click
        Dim frm As New frmCashbookTransactions
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Coral
        AddTabbedForm(frm, tabAccounts, CurrentTabColor)
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Dim frm As New frmSupplierPayments
        frm.ShowDialog()
    End Sub

    Private Sub btnBillEntries_Click(sender As Object, e As EventArgs) Handles btnBillEntries.Click
        Dim frm As New frmBillsListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Blue
        AddTabbedForm(frm, tabAccounts, CurrentTabColor)
    End Sub

    Private Sub btnDeliveryNotes_Click(sender As Object, e As EventArgs) Handles btnDeliveryNotes.Click
        Dim frm As New frmDeliveryNotesListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Gold
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    Private Sub btnZeroYtd_Click(sender As Object, e As EventArgs) Handles btnZeroYtd.Click
        PayrollYearEndClearDown()
    End Sub

    Public Sub PayrollYearEndClearDown()
        On Error GoTo RaiseErr

        Dim intCounter As Integer = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT COUNT(YtdCode) FROM SystemCodes WHERE YtdCode <> 0", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intCounter = CInt(objReader(0).ToString)
        End If
        objReader.Close()

        Dim strSql As String = "SELECT YtdCode from SystemCodes WHERE YtdCode <> 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        'First require a backup
        If MessageBox.Show("Are you sure you want to proceed and reset the payroll year to dates to 0?",
            "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If MessageBox.Show("It is recommended to backup before you continue. Do you want to backup data now?",
                "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                boolAbort = False
                gwt_comm.BackupDatabase()
                If boolAbort = True Then Exit Sub
            End If
            With Me.pb1
                .Visible = True
                .Value = 0
                .Maximum = intCounter + 5

                While objReader.Read
                    objCommand = New Data.OleDb.OleDbCommand("Update EmployeeCodes SET Amount = 0 WHERE CodeNo = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    .Value = .Value + 1
                End While
                .Value = .Maximum
            End With
            MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payroll year end clear down"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSalesSpecials_Click(sender As Object, e As EventArgs) Handles btnSalesSpecials.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicInventory > 0 Then
            Dim frm As New frmInventorySpecialsView
            Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
            AddTabbedForm(frm, tabSales, CurrentTabColor)
        Else
            gwt_comm.DenyAccess()
            Exit Sub
        End If
    End Sub

    Private Sub btnFinancialYearEndClearDown_Click(sender As Object, e As EventArgs) Handles btnFinancialYearEndClearDown.Click
        Dim frm As New frmFinancialYearEndClearDown
        frm.ShowDialog()
    End Sub

    Private Sub btnLoyalityCustomerProgram_Click(sender As Object, e As EventArgs) Handles btnLoyalityCustomerProgram.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicCustomers >= 2 Then
            Dim frm As New frmLoyalityCustomersListing
            Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
            AddTabbedForm(frm, tabSales, CurrentTabColor)
        Else
            gwt_comm.DenyAccess()
            Exit Sub
        End If
    End Sub

    Private Sub btnLoyalityProgramSettings_Click(sender As Object, e As EventArgs) Handles btnLoyalityProgramSettings.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicCustomers >= 2 Then
            Dim frm As New frmLoyalityProgramsListing
            Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
            AddTabbedForm(frm, tabSales, CurrentTabColor)
        Else
            gwt_comm.DenyAccess()
            Exit Sub
        End If
    End Sub

    Private Sub btnAssets_Click(sender As System.Object, e As System.EventArgs) Handles btnAssets.Click
        Dim frm As New frmAssetListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Blue
        AddTabbedForm(frm, tabAccounts, CurrentTabColor)
    End Sub

    Private Sub btnCrm_Click(sender As System.Object, e As System.EventArgs) Handles btnCrm.Click
        Dim frm As New frmCrmListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    Private Sub btnLayByes_Click(sender As System.Object, e As System.EventArgs) Handles btnLayByes.Click
        Dim frm As New frmLaybyCustomersListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    'Private Sub btnSuppliers_Click(sender As System.Object, e As System.EventArgs) Handles btnSuppliers.Click
    '    Dim frm As New frmSupplierListing
    '    Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Teal
    '    AddTabbedForm(frm, tabInventory, CurrentTabColor)
    'End Sub

    Private Sub btnPayrollBatches_Click(sender As System.Object, e As System.EventArgs) Handles btnPayrollBatches.Click
        Dim frm As New frmPayrollBatchesListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabHr, CurrentTabColor)
    End Sub

    Private Sub btnProjectCallings_Click(sender As System.Object, e As System.EventArgs) Handles btnProjectCallings.Click
        Dim frm As New frmProjectCallings
        frm.ShowDialog()
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim frm As New frmLoansDashboard
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmQrCodes
        frm.ShowDialog()
    End Sub

    Private Sub btnJobServiceParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnJobServiceParameters.Click
        Dim frm As New frmJobsServiceParameters
        frm.ShowDialog()
    End Sub

    Private Sub btnProjectsListings_Click(sender As System.Object, e As System.EventArgs) Handles btnProjectsListings.Click
        Dim frm As New frmProjectsListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabProjects, CurrentTabColor)
    End Sub

    Private Sub btnJobs_Click(sender As System.Object, e As System.EventArgs) Handles btnJobs.Click
        Dim frm As New frmJobsAndServices
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Orange
        AddTabbedForm(frm, tabProjects, CurrentTabColor)
    End Sub

    Private Sub tabProjects_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabProjects.TabItemClose
        If UCase(e.Tab.Text) = UCase("Menus") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub btnProjectClaims_Click(sender As System.Object, e As System.EventArgs) Handles btnProjectClaims.Click
        Dim frm As New frmProjectClaims
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Blue
        AddTabbedForm(frm, tabProjects, CurrentTabColor)
    End Sub

    Private Sub btnProformas_Click(sender As System.Object, e As System.EventArgs) Handles btnProformas.Click
        Dim frm As New frmProformaInvoiceListing
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabSales, CurrentTabColor)
    End Sub

    Private Sub tvReports_DoubleClick1(sender As Object, e As System.EventArgs) Handles tvReports.DoubleClick
        strReportHeader = UCase(tvReports.SelectedNode.Text)
        Select Case UCase(tvReports.SelectedNode.Text)
            Case Is = UCase("Received Inventory")
                boolAbort = False
                gwt_comm.DateRangeSpecification()
                If boolAbort = True Then Exit Sub
                PrintReceivedInventoryReport()
            Case Is = UCase("Inventory Sales History")
                Dim f As New frmInventorySalesHistoryAnalysis
                f.ShowDialog()
                'Case Is = UCase("Daily Stores Reconciliation")
                '    boolAbort = False
                '    gwt_comm.DateRangeSpecification()
                '    If boolAbort = True Then Exit Sub
                '    ShowStoresIssues()
            Case Is = "INVENTORY LIST"
                strReportHeader = tvReports.SelectedNode.Text
                InventoryListing()
            Case Is = UCase("Periodic Accounts Analysis")
                strReportHeader = tvReports.SelectedNode.Text
                PrintPeriodicSalesAnalysis()
                'Case Is = UCase("Employee Full Masterfile")
                '    strReportHeader = tvReports.SelectedNode.Text
                '    PrintMasterFileData()
                'Case Is = "EXPENSES"
                '    strReportHeader = tvReports.SelectedNode.Text
                '    boolAbort = False
                '    Dim f As New frmExpensesParameters
                '    f.ShowDialog()
                '    If boolAbort = True Then Exit Sub
                '    LoadExpenses()
            Case Is = "TRANSFERS"
                strReportHeader = tvReports.SelectedNode.Text
                PrintTransfersReport()
            Case Is = UCase("General Ledger Report")
                Dim f As New CommonLibrary.frmLedgerPrintParameters
                f.ShowDialog()
            Case Is = UCase("Trial Balance")
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                Cursor = Cursors.WaitCursor
                gwt_comm.PrintStandardTrialBalance(dtSetDate)
                Cursor = Cursors.Default
            Case Is = UCase("Stock Movements Summary")
                boolAbort = False
                gwt_comm.DateRangeSpecification()
                If boolAbort = True Then Exit Sub
                'StockMovementsReports(StartDate, EndDate)
            Case Is = UCase("Stock Movements Details")
                boolAbort = False
                gwt_comm.DateRangeSpecification()
                If boolAbort = True Then Exit Sub Else DetailedStockMovements()
            Case Is = UCase("Individual Stock Movement")
                boolAbort = False
                'Dim f As New frmInventoryItemMovementReport
                'f.ShowDialog()
            Case Is = UCase("Profit and Loss Standard")

                boolAbort = False
                Dim f As New CommonLibrary.frmFinancialReportsParameters ' frmDateSpecifier
                f.ShowDialog()
                If boolAbort = True Then Exit Sub

                If boolSelectiveReportPrinting = True Then
                    For i As Integer = 0 To arrSelectedItems.Count - 1
                        gwt_comm.ProfitAndLossAccount(CInt(arrSelectedItems.Item(i)))
                    Next
                Else
                    gwt_comm.ProfitAndLossAccount()
                End If

            Case Is = UCase("Balance Sheet")
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                gwt_comm.PrintBalanceSheet(dtSetDate)
            Case Is = UCase("Ledger Account Balances")
                PrintLedgerAccounts()
            Case Is = UCase("Stock Valuation Summary")
                boolAbort = False
                gwt_comm.DateRangeSpecification()
                If boolAbort = True Then
                    Exit Sub
                Else
                    Dim arrValues As New ArrayList
                    arrValues = gwt_comm.RecalculatePurchasesValue(StartDate, EndDate)
                    PrintCostOfSalesReport(arrValues)
                End If
            Case Is = UCase("Customer Balances")
                PrintCustomerBalances()

            Case Is = UCase("Customer Balances At Specified Date")
                PrintCustomerBalancesAtSpecifiedDate()

            Case Is = UCase("Sales Tax Liability")
                PrintVatReturnsReport()


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
                'Case Is = UCase("Tax Certificates")
                '    Dim f As New frmEmployeeTaxCertificates
                '    f.ShowDialog()
            Case Is = UCase("Detailed Stock History")
                StockMovementHistory()
            Case Is = UCase("Sales Sheets")
                PrintDailySalesSheets()
            Case Is = UCase("--")

            Case Is = UCase("Customer Statements")
                PrintCustomerStatements()
            Case Is = UCase("A/R Aging Analysis")
                PrintAgingAnalysis()
            Case Is = UCase("Cashbook Transactions")
                strAccountClass = "CASHBOOK"
                PrintFinancials()
            Case Is = UCase("Ledger Transactions")
                strAccountClass = "LEDGER"
                PrintFinancials()
        End Select
    End Sub

    'Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
    '    Dim prnPreview As New PrintPreviewDialog
    '    Dim myDoc As New CustomerDocumentWriter.WriteDocument
    '    prnPreview.Document = myDoc
    '    Try
    '        prnPreview.ShowDialog()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString())
    '    End Try
    'End Sub

    Private Sub pdSummary_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdSummary.PrintPage

    End Sub

    Private Sub btnKeyCurrencies_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyCurrencies.Click
        Dim frm As New frmKeyExchangeRates
        frm.ShowDialog()
    End Sub

    Private Sub frmLight8_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim intTop As Integer = (Me.Height - pnlMain.Height) / 2
        Dim intLeft As Integer = (Me.Width - pnlMain.Width) / 2
        With pnlMain
            .Top = intTop - 100
            .Left = intLeft - 100
            .Visible = True
        End With
    End Sub

End Class