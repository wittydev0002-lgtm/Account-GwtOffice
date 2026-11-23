Imports System.IO
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmImportSalesFromTillslipFile

    Dim strBuffer() As String

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.ShowDialog()
        txtFileName.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If File.Exists(txtFileName.Text) Then
            pb1.Visible = True
            pb1.Text = "Reading file data. Please wait ..."
            Dim objReader As New StreamReader(txtFileName.Text)
            Dim strLine As String = objReader.ReadToEnd
            objReader.Close()

            'Assign the file details to a public buffer
            strBuffer = Split(strLine, vbCrLf)

            Dim intCounter As Integer = strBuffer.Length + 10
            Dim strFields() As String
            Dim i As Integer = 0
            Dim objCommand As Data.OleDb.OleDbCommand

            pb1.Maximum = intCounter
            pb1.Value = 0

            Dim strIdentifier As String = "@"


            pb1.Text = "Uploading data ... please wait ...."

            If chkClearBufferTableFirst.Checked = True Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM TillslipSales", cnn)
                objCommand.ExecuteNonQuery()
            End If

            For i = 0 To strBuffer.Length - 1
                Dim intPosition As Integer = 0
                intPosition = InStr(strBuffer(i), strIdentifier)

                Dim strDescription As String = Nothing
                Dim intQuantity As Integer = 0
                Dim dblUnitPrice As Double = 0
                Dim dblSoldAt As Double = 0

                If intPosition > 0 Then
                    'Get the previous record which contains the description
                    Dim arrKeyData As New ArrayList
                    strDescription = Trim(strBuffer(i - 1))
                    Dim strSplitCostLine() As String = Split(strBuffer(i), "@")
                    intQuantity = CInt(Trim(strSplitCostLine(0)))
                    dblSoldAt = CDbl(Mid(strSplitCostLine(1), (strSplitCostLine(1).Length - 10), 10))
                    dblUnitPrice = CDbl(Mid(strSplitCostLine(1), 1, 9))
                    arrKeyData = GetDateSalesRepDocumentNumber(i)
                    Dim strSalesAgent As String = Nothing
                    Dim intDocumentNumber As Integer = 0
                    Dim strDate As String = gwt_comm.shortMonthDateFormat(Now)
                    Dim strSerialNumber As String = Nothing
                    Dim strProductType As String = "GENERIC"

                    'Test for serial numbers based on the fact that the description never begins with a number
                    If IsNumeric(Mid(strDescription, 1, 2)) Then
                        Dim strSplitDescription() As String = Split(strDescription, " ")
                        strSerialNumber = strSplitDescription(0)
                        strDescription = Trim(Mid(strDescription, (strSerialNumber.Length + 1), (strDescription.Length - strSplitDescription.Length)))
                        strProductType = "SPECIFIC"
                    End If

                    For p As Integer = 0 To arrKeyData.Count - 1
                        Dim strValues() As String = Split(arrKeyData.Item(p), "|")
                        If UCase(strValues(0)) = "REP" Then
                            strSalesAgent = strValues(1)
                        End If
                        If UCase(strValues(0)) = "DATE" Then
                            strDate = strValues(1)
                        End If
                        If UCase(strValues(0)) = "DOC" Then
                            intDocumentNumber = CInt(strValues(1))
                        End If
                    Next

                    Dim strSql As String = "INSERT INTO TillslipSales ([Description], [Quantity], " _
                        & "[UnitPrice], [SalesAgent], [TransDate], [DocumentNumber], [SoldAt], [SerialNumber], [ProductType]) VALUES " _
                        & "('" & strDescription & "', " & intQuantity & ", " & dblUnitPrice & ", " _
                        & "'" & strSalesAgent & "', '" & strDate & "', " & intDocumentNumber & ", " & dblSoldAt & ", '" & strSerialNumber & "', '" & strProductType & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    pb1.Value = pb1.Value + 1

                End If
                Me.pb1.Value = Me.pb1.Value + 1
            Next

            pb1.Value = 0
            pb1.Text = "Rebuilding affected tables. Please wait ..."

            'Import the data back to the sals, sales main, cashbook and ledger tables
            Dim strSelect As String = "SELECT [Description],[Quantity],[UnitPrice],[SalesAgent]," _
                & "[TransDate],[DocumentNumber],[SoldAt],[TransactionId],[SerialNumber],[ProductType], " _
                & "([TillslipSales].[UnitPrice] - [TillslipSales].[SoldAt]) AS [DiscountAllowed] FROM TillslipSales"
            objCommand = New Data.OleDb.OleDbCommand(strSelect, cnn)
            Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            objCommand = New Data.OleDb.OleDbCommand("SELECT Count(TransactionId) FROM TillslipSales", cnn)
            Dim objReadCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadCount.HasRows Then
                objReadCount.Read()
                If IsNumeric(objReadCount(0).ToString) Then intCounter = objReadCount(0).ToString
            End If
            objReadCount.Close()
            pb1.Maximum = intCounter + 10

            While objReadData.Read

                'Get the itemcode based on the description and selling price
                Dim strDeemedItemCode As String = ""
                Dim dblDeemedCostPrice As Double = 0

                objCommand = New Data.OleDb.OleDbCommand("SELECT CostPrice, ItemCode FROM InventoryItems " _
                    & "WHERE GroupName = '" & objReadData("Description").ToString & "' AND " _
                    & "SellingPrice = " & objReadData("SoldAt").ToString & "", cnn)
                Dim objDeemedCode As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objDeemedCode.HasRows Then
                    objDeemedCode.Read()
                    If IsNumeric(objDeemedCode(0).ToString) Then dblDeemedCostPrice = CDbl(objDeemedCode(0).ToString)
                    If Not IsDBNull(objDeemedCode(1).ToString) Then strDeemedItemCode = objDeemedCode(1).ToString
                End If
                objDeemedCode.Close()

                Dim insertCustomer As String = "INSERT INTO SALES (CustomerId, InvoiceNumber, TransDate, ItemCode, Quantity, " _
                            & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, UserName, SalesRep, CostPrice) VALUES " _
                            & "('0000', " & objReadData("DocumentNumber").ToString & ", '" & objReadData("TransDate").ToString & "', " _
                            & "'" & strDeemedItemCode & "', " & objReadData("Quantity").ToString & ", " & objReadData("UnitPrice").ToString & ", 'CASH SALE', " _
                            & "'" & objReadData("Description").ToString & "', 0, " & objReadData("DiscountAllowed").ToString & ", " _
                            & "'" & objReadData("ProductType").ToString & "', '" & objReadData("SerialNumber").ToString & "', '" & strUserName & "', " _
                            & "'" & objReadData("SalesAgent").ToString & "', " & dblDeemedCostPrice & ")"
                objCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
                objCommand.ExecuteNonQuery()


                pb1.Value = pb1.Value + 1

            End While
            objReadData.Close()

            objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT DocumentNumber FROM TillslipSales ORDER BY DocumentNumber", cnn)
            Dim objReadMap As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            Dim intFirstNumber As Integer = 0
            Dim intLastNumber As Integer = 0
            Dim pt As Integer = 0
            While objReadMap.Read
                If pt = 0 Then intFirstNumber = CInt(objReadMap(0).ToString)
                intLastNumber = CInt(objReadMap(0).ToString)
                pt = pt + 1
            End While
            objReadMap.Close()

            pb1.Value = 0
            pb1.Maximum = pt + 10

            objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT InvoiceNumber, Transdate, " _
                & "SUM(DiscountAllowed) AS [DiscountAllowed], SUM(Taxes) AS Taxes, " _
                & "SUM((Quantity * SalesPrice) - DiscountAllowed) AS [Amount], UserName, SalesRep " _
                & "FROM Sales WHERE InvoiceNumber BETWEEN " & intFirstNumber & " AND " & intLastNumber & " " _
                & "GROUP BY InvoiceNumber, TransDate, Taxes, UserName, SalesRep", cnn)
            Dim objReadForUpdate As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            While objReadForUpdate.Read

                On Error Resume Next

                'Add the record to the sales main
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain (InvoiceNumber, CustomerId, " _
                    & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, ContactNumber, ContactName) VALUES " _
                    & "(" & objReadForUpdate("InvoiceNumber").ToString & ", '0000', '" & objReadForUpdate("TransDate").ToString & "', " _
                    & "" & objReadForUpdate("DiscountAllowed").ToString & ", " & objReadForUpdate("Taxes").ToString & ", " _
                    & "" & objReadForUpdate("Amount").ToString & ", '" & objReadForUpdate("UserName").ToString & "', " _
                    & "'" & objReadForUpdate("SalesRep").ToString & "', " _
                    & "'" & strCustomerTelephoneNumber & "', '" & strTillCustomerName & "')", cnn)
                objCommand.ExecuteNonQuery()

                If chkUpdateLedgerCashTransactions.Checked = True Then
                    'Update the cashbook as well
                    Dim strCashbookDescription As String = "CASH SALE - " & objReadForUpdate("SalesRep").ToString
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
                        & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference) VALUES " _
                        & "('" & strPublicActiveCashbook & "', '" & objReadForUpdate("TransDate").ToString & "', " _
                        & "" & objReadForUpdate("Amount").ToString & ", '" & strCashbookDescription & "', " _
                        & "'" & strPublicSalesAccount & "', '" & objReadForUpdate("UserName").ToString & "', '" & strUserBranch & "', 'DEBIT', " _
                        & "" & objReadForUpdate("InvoiceNumber").ToString & ")", cnn)
                    objCommand.ExecuteNonQuery()

                    'Post the account to the contra ledger account
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber]," _
                        & "[TransactionDate],[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                       & "('" & strPublicSalesAccount & "', '" & objReadForUpdate("TransDate").ToString & "', " _
                       & "" & objReadForUpdate("Amount").ToString & ", 'CREDIT', '" & strPublicActiveCashbook & "', " _
                       & "'" & strCashbookDescription & "', '" & objReadForUpdate("UserName").ToString & "', " _
                       & "'" & strUserBranch & "', " & objReadForUpdate("InvoiceNumber").ToString & ")", cnn)
                    objCommand.ExecuteNonQuery()
                End If

                pb1.Value = pb1.Value + 1

            End While

            'Using the till slip table delete the serial numbers and the update the inventory table

            objCommand = New Data.OleDb.OleDbCommand("SELECT Description, Quantity, SerialNumber FROM TillslipSales", cnn)
            objReadData = objCommand.ExecuteReader
            While objReadData.Read
                Dim strD As String = Nothing
                Dim intQ As Double = 0
                Dim strS As String = Nothing
                If Not IsDBNull(objReadData(0).ToString) Then strD = objReadData(0).ToString
                If IsNumeric(objReadData(1).ToString) Then intQ = CDbl(objReadData(1).ToString)
                If Not IsDBNull(objReadData(2).ToString) Then strS = objReadData(2).ToString
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE SerialNumber = '" & strS & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET " _
                    & "Quantity = (Quantity - " & intQ & ") WHERE GroupName = '" & strD & "'", cnn)
                objCommand.ExecuteNonQuery()
            End While
            Cursor = Cursors.Default
            MessageBox.Show("File Details Imported Successfully", "File Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        If Err.Number = 5 Then
            Resume Next
        Else
            strErrorMessages = Err.Description & " " & Err.Number
            ShowErrorMessage()
        End If
    End Sub

    Public Function GetDateSalesRepDocumentNumber(ByVal RecordNumber As Integer) As ArrayList
        Dim arrReturn As New ArrayList
        Dim intItemsFound As Integer = 0
        For i As Integer = (RecordNumber + 1) To strBuffer.Length - 1
            If intItemsFound >= 3 Then Exit For
            'If i = 101 Then
            '    MessageBox.Show("M")
            'End If
            Dim boolFoundItem As Boolean = False
            Select Case UCase(strBuffer(i))
                Case Is = "  SALES REP :" 'Pick the next line
                    arrReturn.Add("REP|" & Trim(strBuffer(i + 1)))
                    'Case Is = "  TILL OPER :" 'Get the mid up to colon, thereafter its the operator name 
                    'Case Is = "  RECEIPT DATE  25-Oct-2012" 'Get the mid up to where date begin. The date is after
                    'Case Is = "  SALES REP KUDZAI   " 'Get the mid up to end of sales rep. Difference is that there is no colon
                    intItemsFound = intItemsFound + 1
                Case Else
                    'If Mid(strBuffer(i), 1, 16) = "  RECEIPT DATE  " Then
                    '    arrReturn.Add("DATE|" & Mid(strBuffer(i), 17, strBuffer(i).Length - 16))
                    '    intItemsFound = intItemsFound + 1
                    'End If
                    If Mid(strBuffer(i), 1, 12) = "  SALES REP " Then
                        arrReturn.Add("REP|" & Mid(strBuffer(i), 13, strBuffer(i).Length - 12))
                        intItemsFound = intItemsFound + 1
                    End If
                    If Mid(strBuffer(i), 1, 10) = "   DOC NO " Then
                        Dim splitBuffer() As String = Split(strBuffer(i), ":")
                        strBuffer(i) = splitBuffer(0)
                        arrReturn.Add("DOC|" & Mid(strBuffer(i), 11, strBuffer(i).Length - 10))
                        intItemsFound = intItemsFound + 1
                    End If
                    Dim st As String = Nothing ' Mid(strBuffer(i), 1, 19) ' DATE AND TIME 
                    If Mid(strBuffer(i), 1, 15) = " DATE AND TIME " Then
                        boolFoundItem = False
                        'For x As Integer = 0 To arrReturn.Count - 1
                        '    Dim strTest() As String = Split(arrReturn.Item(x), "|")
                        '    If UCase(strTest(0)) = "DATE" Then
                        '        boolFoundItem = True
                        '    End If
                        'Next
                        If boolFoundItem = False Then
                            arrReturn.Add("DATE|" & Mid(strBuffer(i), 16, 11))
                            intItemsFound = intItemsFound + 1
                        End If
                    End If
                    If Mid(strBuffer(i), 1, 19) = "  TAX INVOICE DATE " Then
                        If Mid(strBuffer(i + 1), 1, 19) = "  TAX INVOICE DATE " Then
                            boolFoundItem = False
                            For x As Integer = 0 To arrReturn.Count - 1
                                Dim strTest() As String = Split(arrReturn.Item(x), "|")
                                If UCase(strTest(0)) = "DATE" Then
                                    boolFoundItem = True
                                End If
                            Next
                            If boolFoundItem = False Then
                                arrReturn.Add("DATE|" & Trim(Mid(strBuffer(i), 16, strBuffer(i).Length - 15)))
                                intItemsFound = intItemsFound + 1
                            End If
                        Else
                            boolFoundItem = False
                            For x As Integer = 0 To arrReturn.Count - 1
                                Dim strTest() As String = Split(arrReturn.Item(x), "|")
                                If UCase(strTest(0)) = "DATE" Then
                                    boolFoundItem = True
                                End If
                            Next
                            If boolFoundItem = False Then
                                arrReturn.Add("DATE|" & Trim(Mid(strBuffer(i), 17, 10)))
                                intItemsFound = intItemsFound + 1
                            End If
                        End If
                    End If
                    If Mid(strBuffer(i), 1, 4) = "  DOC " Then
                        Dim splitBuffer() As String = Split(strBuffer(i), ":")
                        strBuffer(i) = splitBuffer(0)
                        arrReturn.Add("DOC|" & Trim(Mid(strBuffer(i), 5, strBuffer(i).Length - 4)))
                        intItemsFound = intItemsFound + 1
                    End If
            End Select
        Next
        Return arrReturn
    End Function

    Private Sub frmImportSalesFromTillslipFile_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 672 : Me.Height = 190
    End Sub

End Class
