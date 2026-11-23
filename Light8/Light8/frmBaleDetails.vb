Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleDetails

    Private Sub frmBaleDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objcommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckTableExistence("BaleDetails") = False Then
            strSql = "Create table BaleDetails([Coupon][NVARCHAR](10)NOT NULL DEFAULT '', " _
                & "[ControlGrade][NVARCHAR](5)NOT NULL DEFAULT '',[CustomerGrade][NVARCHAR](10)NOT NULL DEFAULT '', " _
                & "[Tare][NVARCHAR](2)NOT NULL DEFAULT '', [Weight][NVARCHAR](4)NOT NULL DEFAULT '', " _
                & "[Price][NVARCHAR](4)NOT NULL DEFAULT '', [Grower][NVARCHAR](8) NOT NULL DEFAULT '', " _
                & "[Moisture][NVARCHAR](6)NOT NULL DEFAULT '', [LotNumber][NVARCHAR](30)NOT NULL DEFAULT '', " _
                & "[BarCode][NVARCHAR](35) NOT NULL DEFAULT '')"
            objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objcommand.ExecuteNonQuery()
        End If

        'Load the bale grades

        strSql = "SELECT Grade FROM BaleGrades ORDER BY Grade"
        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objcommand.ExecuteReader()
        With cboControlGrade
            .Items.Clear()
            cboCustomerGrade.Items.Clear()
            While objReader.Read
                .Items.Add(UCase(objReader(0).ToString))
                cboCustomerGrade.Items.Add(UCase(objReader(0).ToString))
            End While
        End With
        objReader.Close()

        'dGrid.Rows.Add(300)
        If boolEditStatus = True Then LoadData()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Form Initialize"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtBarcode.Text) Then
            MessageBox.Show("Please enter the item barcode", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBarcode.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtPrice.Text) Then txtPrice.Text = "0.00"
        If Not IsNumeric(txtWeight.Text) Then txtWeight.Text = "0.00"
        If Not IsNumeric(txtTare.Text) Then txtTare.Text = "0.00"
        If Not IsNumeric(txtMoisture.Text) Then txtMoisture.Text = "0.00"

        Dim strSql As String = Nothing

        If boolEditStatus = False Then
            strSql = "INSERT INTO [BaleItems] " _
                & "([Price],[Barcode],[Grower],[Suffix],[LotNumber],[Weight]," _
                & "[Tare],[Moisture],[BuyerCode],[ControlGrade],[SentStatus], [CustomerGrade]) " _
                & "VALUES (" & txtPrice.Text & ", '" & txtBarcode.Text & "', " _
                & "'" & txtGrower.Text & "', '" & txtSuffix.Text & "', '" & txtLotNumber.Text & "', " _
                & "" & txtWeight.Text & ", " & txtTare.Text & ", " & txtMoisture.Text & ", '" & txtBuyerCode.Text & "', " _
                & "'" & cboControlGrade.Text & "', '" & cboSentStatus.Text & "', '" & cboCustomerGrade.Text & "')"
        Else
            strSql = "UPDATE [BaleItems] SET [Price] = " & txtPrice.Text & ", [Grower] = '" & txtGrower.Text & "', " _
                & "[Suffix] = '" & txtSuffix.Text & "', [LotNumber] = '" & txtLotNumber.Text & "', " _
                & "[Weight] = " & txtWeight.Text & ", [Tare] = " & txtTare.Text & ", [Moisture] = " & txtMoisture.Text & ", " _
                & "[BuyerCode] = '" & txtBuyerCode.Text & "', [ControlGrade] = '" & cboControlGrade.Text & "', " _
                & "[SentStatus] = '" & cboSentStatus.Text & "', CustomerGrade = '" & cboCustomerGrade.Text & "' " _
                & "WHERE [Barcode] = '" & strInventoryItemCode & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On bale details save"
        ShowErrorMessage()
    End Sub

    Private Sub frmBaleDetails_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 670 : Me.Height = 475
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT * FROM BaleItems WHERE BarCode = '" & strInventoryItemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Barcode").ToString) Then txtBarcode.Text = objReader("Barcode").ToString
            If IsNumeric(objReader("Price").ToString) Then txtPrice.Text = Format(CDbl(objReader("Price").ToString), "##0.00")
            If Not IsDBNull(objReader("Grower").ToString) Then txtGrower.Text = objReader("Grower").ToString
            If Not IsDBNull(objReader("Suffix").ToString) Then txtSuffix.Text = objReader("Suffix").ToString
            If Not IsDBNull(objReader("LotNumber").ToString) Then txtLotNumber.Text = objReader("LotNumber").ToString
            If IsNumeric(objReader("Weight").ToString) Then txtWeight.Text = Format(CDbl(objReader("Weight").ToString), "##0.00")
            If IsNumeric(objReader("Tare").ToString) Then txtTare.Text = Format(CDbl(objReader("Tare").ToString), "##0.00")
            If IsNumeric(objReader("Moisture").ToString) Then txtMoisture.Text = Format(CDbl(objReader("Moisture").ToString), "##0.00")
            If Not IsDBNull(objReader("BuyerCode").ToString) Then txtBuyerCode.Text = objReader("BuyerCode").ToString
            If Not IsDBNull(objReader("ControlGrade").ToString) Then cboControlGrade.Text = objReader("ControlGrade").ToString
            If Not IsDBNull(objReader("SentStatus").ToString) Then cboSentStatus.Text = objReader("SentStatus").ToString
            If Not IsDBNull(objReader("SendBatchNo").ToString) Then txtBatchNo.Text = objReader("SendBatchNo").ToString
            If IsDate(objReader("TransmissionDate").ToString) Then txtDateSent.Text = UCase(gwt_comm.shortMonthDateFormat(CDate(objReader("TransmissionDate").ToString)))
            If Not IsDBNull(objReader("CustomerGrade").ToString) Then cboCustomerGrade.Text = objReader("CustomerGrade").ToString
        End If
        objReader.Close()
        txtBarcode.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On bale details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class