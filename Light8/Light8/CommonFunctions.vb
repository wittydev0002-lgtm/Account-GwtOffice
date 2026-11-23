Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Globalization

Module CommonFunctions

    Public strFiscalInvoicingCurrency As String

    Public intSelectedTransactionId As Integer

    Public dblTobaccoTonage As Double
    Public dblTobaccoAveragePrice As Double
    Public dblTobaccoBalesCount As Double
    Public dblTobaccoTotalPrice As Double

    Public strDecontractingReason As String

    Public dblLoanCapitalAmt As Double
    Public dblLoanYears As Double
    Public dblLoanInterestRate As Double

    Public arrMyPrintData As ArrayList

    Public strAgentCode As String
    Public strCountry As String
    Public strTobaccoType As String
    Public intCropYear As Integer
    Public strShippingDate As String
    Public strLoadNumber As String
    Public strVehicleNumber As String
    Public strCarrierCode As String
    Public strShipToLocation As String
    Public strDriverName As String

    Public strSelectedTableQuantityField As String = Nothing
    Public strSourceTableKeyField As String = Nothing
    Public arrSelectedArray As ArrayList
    Public boolRegistrationSuccessfull As Boolean

    Public intMinima As Integer
    Public intMaxima As Integer
    Public strSelectedProjectOwnerNumber As String

    Public strLicenseData As String

    Public strDatabaseName As String
    Public strNewCompanyName As String
    Public strLoginName As String
    Public strServerName As String
    Public strPassword As String
    Public strAuthentication As String

    Public strNewInventoryItemCode As String
    Public strselectedShortCode As String

    Public arrSerialsCaptured As ArrayList
    Public dblSerializedCostPrice As Double

    Public strOrderDate As String
    Public intNewOrderNumber As Integer
    Public strOrderDescription As String
    Public strSelectedVatNumber As String
    Public strReceivingBranchName As String

    Public intAgingDaysPerPeriod As Integer
    Public intAgingIntervals As Integer
    Public intNextInvoiceNumber As Integer
    Public invoiceDate As Date
    Public boolInvoiceOverwritten As Boolean

    Public dblAmountTenderedCash As Double
    Public dblAmountTenderedEcoCash As Double
    Public dblAmountTenderedSwipe As Double
    Public dblAmountTenderedTransfer As Double
    Public dblAmountTenderedOther As Double

    Public dblAmountTenderedUsd As Double
    Public dblAmountTenderedRand As Double

    Public strPrintDocumentsTo As String

    Public Function ThousandSeperatedNumber(ByVal number As Double) As String
        Dim strReturn As String = Nothing
        If IsNumeric(number) Then
            Dim nf As New System.Globalization.NumberFormatInfo()
            nf.NumberGroupSizes = New Integer() {3} 'Groups of 3 digits
            nf.NumberGroupSeparator = ","
            nf.NumberDecimalDigits = 2
            strReturn = number.ToString("N", nf)
        End If
        Return strReturn
    End Function

    Public Function EmployeeNames(ByVal EmployeeNo As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim strSql As String = "SELECT UPPER(RTRIM(LTRIM(EmployeeMaster.LastName +' '+ EmployeeMaster.FirstName +' '+ " _
            & "EmployeeMaster.OtherNames))) AS [Given Names] FROM EmployeeMaster WHERE EmployeeMaster.EmployeeNo = '" & EmployeeNo & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                strReturn = StrConv(objReader(0).ToString, VbStrConv.ProperCase)
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        'Me.Cursor = Cursors.Default
        'Application.DoEvents()
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On employee names get"
        ShowErrorMessage()
    End Function

    'format month 
    Public Function shortMonthDateFormat(ByVal inDate As Date) As String
        Dim strReturn As String = Nothing
        If IsDate(inDate) Then
            strReturn = CStr(Format(DatePart(DateInterval.Day, inDate), "00")) & "-" &
                Mid(MonthName(DatePart(DateInterval.Month, inDate), True), 1, 3) & "-" &
                CStr(Format(DatePart(DateInterval.Year, inDate), "0000"))
        Else
            Return inDate.ToString
        End If
        Return strReturn
    End Function
    'format month 

    Public Function TrekkedFieldsHistory(ByVal EmployeeNumber As String, ByVal PeriodNumber As Integer) As ArrayList
        Dim arrReturn As New ArrayList

        Dim strSql As String = Nothing
        strSql = "SELECT EmployeeTrakkedFields.CodeNo, SystemCodes.Description, 
            CASE WHEN SystemCodes.CodeType = 'E' THEN CAST(EmployeeTrakkedFields.Amt AS decimal (10, 2)) END AS [Earning], 
            CASE WHEN SystemCodes.CodeType = 'D' THEN CAST(EmployeeTrakkedFields.Amt AS decimal (10, 2)) END AS [Deduction], 
            CASE WHEN SystemCodes.CodeType = 'S' THEN CAST(EmployeeTrakkedFields.Amt AS decimal (10, 2)) END AS [Base/Coy] FROM EmployeeTrakkedFields 
            LEFT OUTER JOIN SystemCodes ON EmployeeTrakkedFields.CodeNo = SystemCodes.CodeNo 
            WHERE EmployeeNo = '" & EmployeeNumber & "' AND PeriodNumber = " & PeriodNumber & " 
            AND EmployeeTrakkedFields.Amt <> 0 
            ORDER BY SystemCodes.CodeType ASC, SystemCodes.CodeNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strCodeNo As String = "000"
            Dim strDescription As String = Nothing
            Dim strEarnings As String = Nothing
            Dim strDeductions As String = Nothing
            Dim strBasis As String = Nothing
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    If IsNumeric(objReader(0).ToString) Then
                        strCodeNo = CStr(Format(CInt(objReader(0).ToString), "000"))
                    End If
                End If
            End If
            If Not IsDBNull(objReader(1)) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    strDescription = UCase(objReader(1).ToString)
                End If
            End If
            If Not IsDBNull(objReader(2)) Then
                If Not String.IsNullOrEmpty(objReader(2).ToString) Then
                    If IsNumeric(objReader(2).ToString) Then
                        strEarnings = CStr(Format(CDbl(objReader(2).ToString), "##0.00"))
                    End If
                End If
            End If
            If Not IsDBNull(objReader(3)) Then
                If Not String.IsNullOrEmpty(objReader(3).ToString) Then
                    If IsNumeric(objReader(3).ToString) Then
                        strDeductions = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
                    End If
                End If
            End If
            If Not IsDBNull(objReader(4)) Then
                If Not String.IsNullOrEmpty(objReader(4).ToString) Then
                    If IsNumeric(objReader(4).ToString) Then
                        strBasis = CStr(Format(CDbl(objReader(4).ToString), "##0.00"))
                    End If
                End If
            End If
            arrReturn.Add(strCodeNo & "|" & strDescription & "|" & strEarnings & "|" & strDeductions & "|" & strBasis)
        End While
        objReader.Close()

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & vbCrLf & "Error Number: " & Err.Number & vbCrLf & "On Employee Trekked Fields History Get"
        ShowErrorMessage()
    End Function

    Public Function ScriptTableFields(TableName As String, ScriptType As String, dbConnection As Data.OleDb.OleDbConnection) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing

        Dim dt_field As System.Data.DataTable =
                    dbConnection.GetOleDbSchemaTable(
                        OleDb.OleDbSchemaGuid.Columns,
                        New Object() {Nothing, Nothing, TableName})
        'Add the field names to the treeview view 
        Dim n As Integer = 0

        Select Case UCase(ScriptType)
            Case Is = "INSERT"
                strReturn = "INSERT INTO " & TableName & " ("
            Case Is = "SELECT"
                strReturn = "SELECT "
        End Select

        For Each dr_field As DataRow In dt_field.Rows
            If UCase(dr_field("COLUMN_NAME").ToString) = UCase("TransId") Or
                UCase(dr_field("COLUMN_NAME").ToString) = UCase("TransactionId") Then
                'If UCase(ScriptType) <> "INSERT" Then
                '    strReturn = strReturn & "[" & dr_field("COLUMN_NAME").ToString & "], "
                'End If
            Else
                strReturn = strReturn & "[" & dr_field("COLUMN_NAME").ToString & "], "
            End If
        Next
        strReturn = Mid(strReturn, 1, strReturn.Length - 2)
        Select Case UCase(ScriptType)
            Case Is = "INSERT"
                strReturn = strReturn & ") VALUES ("
            Case Is = "SELECT"
                strReturn = strReturn & " FROM " & TableName
        End Select
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Action Costs Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Function ScriptDataInsertStatement(QuerySring As String, TableName As String, dbConnection As Data.OleDb.OleDbConnection) As String
        Dim strReturn As String = Nothing

        Dim objCommand As New Data.OleDb.OleDbCommand(QuerySring, dbConnection)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim arrData As New ArrayList

        Dim strInsertData As String = ScriptTableFields(TableName, "INSERT", dbConnection)

        While objReader.Read
            Dim strLine As String = strInsertData
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        Dim fileString As String = Nothing
        For p As Integer = 0 To arrData.Count - 1
            fileString = fileString & arrData.Item(p) & vbCrLf
        Next

        strReturn = fileString

        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Action Costs Fetch"
        ShowErrorMessage()
    End Function

    Public Function TableExists(ByVal strTableName As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim myCommand As New Data.OleDb.OleDbCommand("IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES " _
            & "WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" & strTableName & "')SELECT 'tablename exists.'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If objReader(0).ToString = "tablename exists." Then
                    boolReturn = True
                End If
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Table Existence Check Failed"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Function TableColumnNames(TableName As String, Connection As Data.OleDb.OleDbConnection) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT TOP 1 * FROM " & TableName & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, Connection)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        For p As Integer = 0 To objReader.FieldCount - 1
            arrReturn.Add(objReader.GetName(p).ToString)
        Next
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Table Existence Check Failed"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Function LastProspectId() As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 0
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ProspectId FROM Prospects ORDER BY ProspectId DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReturn = CInt(UCase(objReader(0).ToString))
        End If
        objReader.Close()
        Return intReturn

        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on last prospect ID allocated fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Sub DeleteCreditNote(ByVal NoteNumber As Integer)
        On Error GoTo RaiseErr

        Dim intSpecialKey As Integer = 0
        Dim strSql As String = "SELECT SpecialKey FROM CreditNotesMain WHERE NoteNumber = " & NoteNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intSpecialKey = CInt(objReader(0).ToString)
        End If
        objReader.Close()
        'If intSpecialKey = 0 Then
        '    MessageBox.Show("The selected record can only be deleted manually", "Cannot Execute Called Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        If intSpecialKey > 0 Then
            'Delete the record starting with transactions
            strSql = "DELETE FROM CreditNoteEntries WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM CreditNotesMain WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM LedgerTransactions WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM CustomerTransactions WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on last credit note delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub DeleteDebitNote(ByVal NoteNumber As Integer)
        On Error GoTo RaiseErr

        Dim intSpecialKey As Integer = 0
        Dim strSql As String = "SELECT SpecialKey FROM DebitNotesMain WHERE NoteNumber = " & NoteNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intSpecialKey = CInt(objReader(0).ToString)
        End If
        objReader.Close()
        'If intSpecialKey = 0 Then
        '    MessageBox.Show("The selected record can only be deleted manually", "Cannot Execute Called Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        If intSpecialKey > 0 Then
            'Delete the record starting with transactions
            strSql = "DELETE FROM DebitNoteEntries WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM DebitNotesMain WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM LedgerTransactions WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM SupplierTransactions WHERE SpecialKey = " & intSpecialKey & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on last debit note delete"
        ShowErrorMessage()
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
                Dim f As New frmRunBackup
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
            End If
            With frmLight8.pb1
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payroll year end clear down"
        ShowErrorMessage()
    End Sub

    Public Sub PrintDeliveryNote(ByVal NumberOfItems As Integer)
        On Error GoTo RaiseErr

        Dim intY As Integer = 0
        Dim myString As String = Nothing
        Dim arrItems As New ArrayList
        With arrItems
            myString = "<d>TX=TOBACCO DELIVERY STATEMENT;VA=Center;X=100;Y=50;FN=Ariel;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=20;AL=1;TW=600</d>"
            .Add(myString)

            intY = 115

            myString = "<d>TX=DELIVERY NOTE NUMBER;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & UCase(strLoadNumber) & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)

            intY = intY + 35
            myString = "<d>TX=TOTAL NUMBER OF BALES;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & NumberOfItems & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)

            intY = intY + 35
            myString = "<d>TX=TRANSPORTATION DATE;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & gwt_comm.shortMonthDateFormat(Now) & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)

            intY = intY + 35
            myString = "<d>TX=VEHICLE REGISTRATION;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & strVehicleNumber & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)

            intY = intY + 35
            myString = "<d>TX=DRIVER NAME;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & strDriverName & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)

            '
            intY = intY + 35
            myString = "<d>TX=SHIP TO MTC LOCATION;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & strShipToLocation & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)


            intY = intY + 35
            myString = "<DL>LX=100;LY=" & intY & ";LEN=727;LC=Black;LD=Horizontal</DL>"
            .Add(myString)

            intY = intY + 50
            myString = "<d>TX=CLERK;VA=Center;X=105;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=350</d>"
            .Add(myString)
            myString = "<d>TX=" & UCase(strPublicActiveFullUserName) & ";VA=Center;X=450;Y=" & intY & ";FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=15;AL=0;TW=240</d>"
            .Add(myString)

            intY = intY + 50
            myString = "<d>TX=SIS .......................................................;VA=Center;X=105;Y=" & intY & ";" _
                & "FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=20;AL=0;TW=320</d>"
            .Add(myString)
            myString = "<d>TX=Date ....................................................;VA=Center;X=375;Y=" & intY & ";" _
                & "FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=20;AL=0;TW=300</d>"
            .Add(myString)

            intY = intY + 50
            myString = "<d>TX=SECURITY ..................................................;VA=Center;X=105;Y=" & intY & ";" _
                & "FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=20;AL=0;TW=320</d>"
            .Add(myString)
            myString = "<d>TX=Date ....................................................;VA=Center;X=375;Y=" & intY & ";" _
                & "FN=Ariel;FS=10;FC=Black;FB=True;FI=False;FU=False;BC=White;TH=20;AL=0;TW=300</d>"
            .Add(myString)

        End With
        Dim myDoc As New FreeFlowDocumentWriter.FreeWriter
        With myDoc
            .DrawBorder = True
            .BorderColor = Color.Black
            .intPrintRecordsCount = arrItems.Count
            .arrPrintItems = arrItems
            .strFooterCaption = "Great People HCMS"
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "Header2"
            .strMainHeader3 = "Header3"
            .intBorderX = 100
            .intBorderY = 100
        End With

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = myDoc
        documentPreview.ShowDialog()

        PrintFileContent()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Delivery Note Print"
        ShowErrorMessage()
    End Sub

    Public Sub PrintFileContent()
        On Error GoTo RaiseErr

        Dim strPrintDetails(0 To arrMyPrintData.Count - 1) As String
        For i As Integer = 0 To arrMyPrintData.Count - 1
            strPrintDetails(i) = arrMyPrintData.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 11
            .strColumnHeaders = "LN|BATCH|BARCODE|CTRL GRADE|CUS.GRADE|TARE|WEIGHT|PRICE|GROWER|MOIST|LOT #"
            .strColumnWidths = "20|40|80|75|75|45|60|50|60|45|50"
            .strColumnAlignments = "0|2|0|0|0|2|2|2|0|2|2"
            .strFooterCaption = "Bale delivery file details"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = UCase("TOBACCO DELIVERY REPORT")
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|YES|YES|NO|NO|NO"
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
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|YES|YES|NO|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On file content print"
        ShowErrorMessage()
    End Sub

End Module
