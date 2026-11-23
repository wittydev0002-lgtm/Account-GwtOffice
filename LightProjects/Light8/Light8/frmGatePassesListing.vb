Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmGatePassesListing

    Private Sub frmExitPasses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadEmployees()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        cboUser.Items.Clear()
        cboUser.Items.Add("ALL")
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUser.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Usernames Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefreshPasses_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshPasses.Click
        LoadEmployees()
        LoadPassDetails()
    End Sub

    Private Sub LoadPassDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridPasses.Rows.Clear()
        Dim strSql As String = Nothing
        If UCase(cboUser.Text) = "ALL" Then
            strSql = "Select PassNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                & "CollectingAgent, PassType from GatePassesMain WHERE TransDate BETWEEN " _
                & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, PassNumber"
        Else
            strSql = "Select PassNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
               & "CollectingAgent, PassType from GatePassesMain WHERE CollectingAgent = '" & UCase(cboUser.Text) & "' " _
               & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
               & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, PassNumber"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGridPasses.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridPasses.Rows(dGridPasses.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader(0).ToString), "000000")
            If Not IsDBNull(objReader(1).ToString) Then dGridPasses.Rows(dGridPasses.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridPasses.Rows(dGridPasses.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridPasses.Rows(dGridPasses.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
        End While
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exit pass details analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        LoadPassDetails()
    End Sub

    Private Sub btnNewPass_Click(sender As System.Object, e As System.EventArgs) Handles btnNewPass.Click
        boolEditStatus = False
        Dim frm As New frmGatePasses
        frm.ShowDialog()
    End Sub

    Private Sub btnEditPass_Click(sender As System.Object, e As System.EventArgs) Handles btnEditPass.Click
        boolEditStatus = True
        If dGridPasses.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridPasses.CurrentRow.Cells(0).Value.ToString)
        Dim frm As New frmGatePasses
        frm.ShowDialog()
    End Sub

    Private Sub dGridPasses_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridPasses.DoubleClick
        boolEditStatus = True
        If dGridPasses.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridPasses.CurrentRow.Cells(0).Value.ToString)
        Dim frm As New frmGatePasses
        frm.ShowDialog()
    End Sub

    Private Sub btnPrintAllPass_Click(sender As Object, e As EventArgs) Handles btnPrintAllPass.Click
        On Error GoTo RaiseErr
        If dGridPasses.Rows.Count <= 0 Then Exit Sub
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        For n As Integer = 0 To dGridPasses.Rows.Count - 1
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGridPasses.Columns.Count - 3
                If i = 0 Then
                    If Not Object.Equals(Convert.ToString(dGridPasses.Rows(n).Cells(i).Value), "") Then
                        strDataRow = Convert.ToString(dGridPasses.Rows(n).Cells(i).Value) & ";"
                    Else
                        strDataRow = ";"
                    End If
                Else
                    If Not Object.Equals(Convert.ToString(dGridPasses.Rows(n).Cells(i).Value), "") Then
                        strDataRow = strDataRow & Convert.ToString(dGridPasses.Rows(n).Cells(i).Value) & ";"
                    Else
                        strDataRow = strDataRow & ";"
                    End If
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "NO.|DATE|COLLECTING AGENT|PASS TYPE"
            .strColumnAlignments = "0|0|0|0"
            .strColumnWidths = "100|100|350|100"
            .strFooterCaption = "Exit Passes Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "EXIT PASS REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO"
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
            .boolGenericReport = True
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO"
            '.intKeyFieldIndex = 3
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Exit Passes Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeletePass_Click(sender As System.Object, e As System.EventArgs) Handles btnDeletePass.Click
        If dGridPasses.RowCount <= 0 Then Exit Sub
        DeleteTransaction()
    End Sub

    Private Sub DeleteTransaction()
        boolVoidSale = True
        boolTransactionVoided = False
        intSelectedTransaction = CInt(dGridPasses.CurrentRow.Cells(0).Value.ToString)
        If MessageBox.Show("Are you sure you want to delete this gate pass", _
            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            If UCase(dGridPasses.CurrentRow.Cells(3).Value.ToString) = "TRANSFER" Then
                MessageBox.Show("The selected pass cannot be edited or voided or viewed from here." _
                    & vbCrLf & "Recall it from inventory transfers instead", "Process Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                boolAbort = False
                VoidGatePass()
                If boolAbort = False Then
                    MessageBox.Show("Transaction has been deleted successfully", "Transaction Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        boolVoidSale = False
        If boolTransactionVoided = True Then LoadPassDetails()
    End Sub

    Private Sub VoidGatePass()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [TransDate],[UserName],[Branch],[ItemCode],[Quantity]," _
            & "[Description],[SerialNumber],[PassNumber],[CollectingAgent],[ProductType],[PassType], " _
            & "BarCodeNo, SourceSerialNo FROM GatePasses WHERE PassNumber = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strSql = "INSERT INTO VoidedGatePasses ([TransDate],[UserName],[Branch],[ItemCode],[Quantity]," _
            & "[Description],[SerialNumber],[PassNumber],[CollectingAgent],[ProductType],[PassType]," _
            & "[BarCodeNo],[SourceSerialNo]) VALUES " _
            & "('" & objReader(0).ToString & "', '" & strUserName & "', '" & strUserBranch & "', '" & objReader(3).ToString & "', " _
            & "" & objReader(4).ToString & ", '" & objReader(5).ToString & "', '" & objReader(6).ToString & "', " _
            & "" & objReader(7).ToString & ", '" & objReader(8).ToString & "', '" & objReader(9).ToString & "', " _
            & "'" & objReader(10).ToString & "', '" & objReader(11).ToString & "', '" & objReader(12).ToString & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Reinstate the item to serial numbers if its of specific type
            If Not IsDBNull(objReader(6).ToString) Then
                If Not String.IsNullOrEmpty(objReader(6).ToString) Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SerialNumbers " _
                        & "(ItemCode, SerialNumber, BarcodeNo, SourceSerialNo, Availability) VALUES " _
                        & "('" & objReader(3).ToString & "', '" & objReader(6).ToString & "', " _
                        & "'" & objReader(11).ToString & "', '" & objReader(12).ToString & "', 'Y')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
            'Add back the quantity in the inventory table
            Dim intCurrentTotal As Integer = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & objReader(3).ToString & "'", cnn)
            Dim objReadQuantity As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadQuantity.HasRows Then
                objReadQuantity.Read()
                If IsNumeric(objReadQuantity(0).ToString) Then intCurrentTotal = CInt(objReadQuantity(0).ToString) + 1
            End If
            objReadQuantity.Close()
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intCurrentTotal & " " _
                & "WHERE ItemCode = '" & objReader(3).ToString & "'", cnn)
            objCommand.ExecuteNonQuery()
        End While
        objReader.Close()

        'Insert into the voided main table
        strSql = "SELECT [PassNumber],[TransDate],[UserName],[Branch],[Comment],[CollectingAgent]," _
            & "[PassType] FROM GatePassesMain WHERE PassNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            strSql = "INSERT INTO VoidedGatePassesMain ([PassNumber],[TransDate],[UserName],[Branch]," _
                & "[Comment],[CollectingAgent],[PassType]) VALUES " _
                & "(" & objReader(0).ToString & ", '" & Format(Now, "dd-MMM-yyyy") & "', " _
                & "'" & strUserName & "', '" & strUserBranch & "', '" & objReader(4).ToString & "', " _
                & "'" & objReader(5).ToString & "', '" & objReader(6).ToString & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM GatePassesMain WHERE PassNumber = " & intSelectedTransaction & "", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM GatePasses WHERE PassNumber = " & intSelectedTransaction & "", cnn)
        objCommand.ExecuteNonQuery()

        LoadPassDetails()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to delete the gate pass"
        gwt_comm.ShowErrorMessage()
    End Sub


End Class
