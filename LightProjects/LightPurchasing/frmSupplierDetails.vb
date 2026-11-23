Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupplierDetails

    Private Sub frmSupplierDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTermsOptions()
        LoadSupplierGroups()
        If boolEditStatus = True Then
            LoadIdentityData()
            LoadData()
            LoadTerms()
            GetBalance()
            GetLastPayment()
            'LoadTransactions()
        End If
    End Sub

    Private Sub LoadTerms()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Terms FROM SupplierTerms WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtNotes.Text = objReader(0).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Terms and Condictions Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmSupplierDetails_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.Height = 534
            Me.Width = 766 '766, 534
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IntPublicSuppliers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the account holder full names", "Invalid Account Holder Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the account holder address", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        boolAbort = False
        SaveAccountDetails()
        If boolAbort = True Then Exit Sub
        SaveTerms()
        If boolAbort = True Then Exit Sub
        'DELETE THE EMPLOYMENT RECORD BEFORE ADDING ANY
        If boolEditStatus = True Then
            MessageBox.Show("Supplier details have been saved successfully", "Supplier Details Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Supplier Details Saved Successfully. Do you want to add more supplier record?", "Supplier Details Save Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtAccountNo.Clear()
                txtAccountName.Clear()
                txtAddress1.Clear()
                txtAddress2.Clear()
                txtAddress3.Clear()
                txtAddress4.Clear()
                txtCellphone.Clear()
                txtContactPerson.Clear()
                txtEmailAddress.Clear()
                txtFaxNumber.Clear()
                txtTelephone.Clear()
                txtVatNumber.Clear()
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub LoadIdentityData()
        On Error GoTo RaiseErr
        txtAccountNo.Enabled = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName, " _
            & "TakeOnDate, Address1, Address2, Address3, Address4, ContactPerson, PhoneNumber, " _
            & "FaxNumber, Cellphone, EmailAddress, VatNumber, CreditorType FROM Suppliers WHERE " _
            & "AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNo.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
            If IsDate(objReader("TakeOnDate").ToString) Then dpDateOn.Value = CDate(objReader("TakeOnDate").ToString)
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("ContactPerson").ToString) Then txtContactPerson.Text = objReader("ContactPerson").ToString
            If Not IsDBNull(objReader("PhoneNumber").ToString) Then txtTelephone.Text = objReader("PhoneNumber").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then txtFaxNumber.Text = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("VatNumber").ToString) Then txtVatNumber.Text = objReader("VatNumber").ToString
            If Not IsDBNull(objReader("CreditorType").ToString) Then cboCreditorType.Text = objReader("CreditorType").ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Supplier Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveAccountDetails()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO Suppliers (AccountNumber, AccountName, " _
                & "TakeOnDate, Address1, Address2, Address3, Address4, ContactPerson, PhoneNumber, " _
                & "FaxNumber, Cellphone, EmailAddress, VatNumber, CreditorType) VALUES ('" & txtAccountNo.Text & "', " _
                & "'" & txtAccountName.Text & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtContactPerson.Text & "', '" & txtTelephone.Text & "', " _
                & "'" & txtFaxNumber.Text & "', '" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', " _
                & "'" & txtVatNumber.Text & "', '" & cboCreditorType.Text & "')", cnn)
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE Suppliers SET AccountName = '" & txtAccountName.Text & "', " _
                & "TakeOnDate = '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', Address1 = '" & txtAddress1.Text & "', " _
                & "Address2 = '" & txtAddress2.Text & "', Address3 = '" & txtAddress3.Text & "', " _
                & "Address4 = '" & txtAddress4.Text & "', ContactPerson = '" & txtContactPerson.Text & "', " _
                & "PhoneNumber = '" & txtTelephone.Text & "', FaxNumber = '" & txtFaxNumber.Text & "', " _
                & "Cellphone = '" & txtCellphone.Text & "', EmailAddress = '" & txtEmailAddress.Text & "', " _
                & "VatNumber = '" & txtVatNumber.Text & "', CreditorType = '" & cboCreditorType.Text & "' " _
                & "WHERE AccountNumber = '" & txtAccountNo.Text & "'", cnn)
        End If
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Supplier Details Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], ReferenceNumber, " _
            & "Description, CAST(Amount AS DECIMAL (10,2)) AS [Amt], TransactionType FROM " _
            & "SupplierTransactions WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate, ReferenceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim dblMovingBalance As Double = 0
        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then
                    If UCase(objReader(4).ToString) = "PURCHASES" Then
                        .Rows(.Rows.Count - 1).Cells(4).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                        dblMovingBalance = dblMovingBalance + CDbl(objReader(3).ToString)
                    Else
                        dblMovingBalance = dblMovingBalance - CDbl(objReader(3).ToString)
                        .Rows(.Rows.Count - 1).Cells(5).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                    End If
                End If
                .Rows(.Rows.Count - 1).Cells(6).Value = objReader(4)
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Supplier Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetBalance()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(Amount AS DECIMAL (10,2)) AS [Amt], TransactionType FROM " _
            & "SupplierTransactions WHERE AccountNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim dblMovingBalance As Double = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(1).ToString) = "PURCHASES" Then
                    dblMovingBalance = dblMovingBalance + CDbl(objReader(0).ToString)
                Else
                    dblMovingBalance = dblMovingBalance - CDbl(objReader(0).ToString)
                End If
            End If
        End While
        objReader.Close()
        lblCurrentBalance.Text = Format(dblMovingBalance, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Supplier Balance Computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetLastPayment()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(Amount AS DECIMAL (10,2)) AS [Amt], TransactionDate FROM " _
            & "SupplierTransactions WHERE AccountNumber = '" & strSelectedAccount & "' AND " _
            & "TransactionType = 'PAYMENT' ORDER BY TransactionDate DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    lblAmtPaid.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
                End If
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If IsDate(objReader(1).ToString) Then
                    lblPaymentDate.Text = UCase(Format(CDate(objReader(1).ToString), "dd-MMM-yyyy"))
                End If
            End If
        End If
        objReader.Close()
        'Get the Year to date sales
        strSql = "SELECT SUM(Amount) FROM SupplierTransactions WHERE AccountNumber = '" & strSelectedAccount & "' " _
            & "AND TransactionType = 'INVOICE'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                lblYearToDate.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Supplier Last Payment Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) as [Date], " _
            & "OrderNumber, Description, SUM(Quantity) as [Qty], CAST(SUM((CostPrice * " _
            & "Quantity) - DiscountReceived) AS DECIMAL (10,2)) as [Ordered] FROM SupplierOrders " _
            & "WHERE SupplierId = '" & strSelectedAccount & "' GROUP " _
            & "BY TransDate, ItemCode, OrderNumber, Description, SerialNumbers ORDER BY TransDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrTransactions As New ArrayList
        While objReader.Read
            Dim strLine As String = Nothing
            For n As Integer = 0 To objReader.FieldCount - 1
                strLine = strLine & ";" & objReader(n).ToString
            Next
            strLine = Mid(strLine, 2, (strLine.Length - 1)) & ";"
            arrTransactions.Add(strLine)
        End While
        objReader.Close()
        'Get the payments
        strSql = "SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Dte], [ReferenceNumber], " _
            & "[Description], CAST(Amount AS DECIMAL (10,2)) AS [Amt] FROM SupplierTransactions " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        Dim strLastPaymentAmount As String = "0.00"
        Dim strLastPaymentDate As String = Nothing
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";1;;" & objReader(3).ToString)
            If IsDate(objReader(0).ToString) Then strLastPaymentDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
            If IsNumeric(objReader(3).ToString) Then strLastPaymentAmount = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
        End While
        objReader.Close()

        If arrTransactions.Count > 0 Then arrTransactions.Sort()

        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblBalance As Double = 0
        dGrid.Rows.Clear()
        For i As Integer = 0 To arrTransactions.Count - 1
            dGrid.Rows.Add(1)
            Dim strValues() As String = Split(arrTransactions(i), ";")
            For n As Integer = 0 To strValues.Length - 1
                With dGrid
                    .Rows(.Rows.Count - 1).Cells(n).Value = strValues(n)
                End With
            Next n
            If IsNumeric(strValues(strValues.Length - 2)) Then
                dblDebitTotal = dblDebitTotal + CDbl(strValues(strValues.Length - 2))
            End If
            If IsNumeric(strValues(strValues.Length - 1)) Then
                dblCreditTotal = dblCreditTotal + CDbl(strValues(strValues.Length - 1))
            End If
        Next
        dblBalance = dblDebitTotal - dblCreditTotal
        lblCurrentBalance.Text = CStr(Format(dblBalance, "##0.00"))
        lblYearToDate.Text = Format(dblDebitTotal, "##0.00")
        lblPaymentDate.Text = strLastPaymentDate
        lblAmtPaid.Text = strLastPaymentAmount
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveTerms()
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtNotes.Text) Then
            Dim objcommand As New Data.OleDb.OleDbCommand("DELETE FROM SupplierTerms WHERE AccountNumber = '" & txtAccountNo.Text & "'", cnn)
            objcommand.ExecuteNonQuery()
            objcommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierTerms (AccountNumber, Terms) VALUES " _
                & "('" & txtAccountNo.Text & "', '" & txtNotes.Text & "')", cnn)
            objcommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Terms and Condictions Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadTermsOptions()
        Dim arrTerms As New ArrayList
        With arrTerms
            .Add("1% 10 Net 30|Discount 1% if paid within 10 days")
            .Add("2% 10 Net 30|Discount 2% if paid within 20 days")
            .Add("Annually|Sales Tax Paid annually")
            .Add("Due on Receipt|Due on receipt")
            .Add("Monthly|Sales Tax paid Monthly")
            .Add("Net 15|Net paid within 15 days")
            .Add("Net 30|Net paid within 30 days")
            .Add("Quarterly|Sales Tax Paid Quaterly")
        End With
        Dim intWidth As Integer = cboPaymentTerms.Width - 55
        With cboPaymentTerms
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "140;" & intWidth - 160

            Dim DropDownItems(arrTerms.Count - 1) As MTGCComboBoxItem

            .Items.Clear()
            For p As Integer = 0 To arrTerms.Count - 1
                Dim strRecordText() As String = Split(arrTerms.Item(p), "|")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            Next
            If arrTerms.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
    End Sub

    Private Sub btnAddGrouping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGrouping.Click
        Dim f As New frmSupplierGroupings
        f.ShowDialog()
        LoadSupplierGroups()
    End Sub

    Private Sub LoadSupplierGroups()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Grouping FROM SupplierGroups ORDER BY Grouping", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboGrouping.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboGrouping.Items.Add(UCase(objReader(0).ToString))
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On supplier groupings load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSaveNew_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveNew.Click
        If IntPublicSuppliers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
    End Sub

    Private Sub btnNewOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnNewOrder.Click

    End Sub
End Class
