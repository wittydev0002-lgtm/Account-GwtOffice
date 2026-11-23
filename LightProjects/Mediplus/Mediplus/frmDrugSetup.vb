Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMedicinesSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadManufacturers()
        LoadCategories()
        LoadGenericDrugs()
        If boolEditStatus = True Then
            LoadDrugDetails()
            LoadLinkedGenericDrugs(strDrugCode)
        End If
    End Sub

    Private Sub LoadDrugDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM OchmasSystemMedicines WHERE ProductCode = '" & strDrugCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ProductCode").ToString) Then txtCode.Text = objReader("ProductCode").ToString
            If Not IsDBNull(objReader("ProductName").ToString) Then txtDrugName.Text = objReader("ProductName").ToString
            If Not IsDBNull(objReader("Quantity").ToString) Then txtQuantity.Text = objReader("Quantity").ToString
            If IsNumeric(objReader("CostPrice").ToString) Then txtCostPrice.Text = Format(CDbl(objReader("CostPrice").ToString), "##0.00")
            If Not IsDBNull(objReader("StandardPackSize").ToString) Then txtPackSize.Text = objReader("StandardPackSize").ToString
            If Not IsDBNull(objReader("GenericIndicator").ToString) Then cboGenericIndicator.Text = Trim(objReader("GenericIndicator").ToString)
            If IsNumeric(objReader("SellPrice").ToString) Then txtUnitPrice.Text = Format(CDbl(objReader("SellPrice").ToString), "##0.00")
            If Not IsDBNull(objReader("Category").ToString) Then cboCategory.Text = objReader("Category").ToString
            If Not IsDBNull(objReader("Classification").ToString) Then cboClassification.Text = objReader("Classification").ToString
            If Not IsDBNull(objReader("TaxStatus").ToString) Then cboTax.Text = objReader("TaxStatus").ToString
            If Not IsDBNull(objReader("Strength").ToString) Then txtStrength.Text = objReader("Strength").ToString
            If Not IsDBNull(objReader("ManCode").ToString) Then
                Dim objGetName As New Data.OleDb.OleDbCommand("SELECT ManufacturerName FROM OchmasSystemDrugManufacturers " _
                    & "WHERE ManufacturerCode = '" & objReader("ManCode").ToString & "'", cnn)
                Dim objReadName As Data.OleDb.OleDbDataReader = objGetName.ExecuteReader
                If objReadName.HasRows Then
                    objReadName.Read()
                    If Not IsDBNull(objReadName(0).ToString) Then
                        cboManufacturer.Text = objReader("ManCode").ToString
                        lblCode.Text = objReader("ManCode").ToString
                        lblManufacturer.Text = objReadName(0).ToString
                    End If
                End If
                objReadName.Close()
            End If
        End If
        objReader.Close()
        txtCode.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicine Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If String.IsNullOrEmpty(txtCode.Text) Then
            MsgBox("Please enter the drug code. Preferable the international medicine code", MsgBoxStyle.Exclamation, "Missing Medicine Code")
            txtCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDrugName.Text) Then
            MsgBox("Please enter the drug name. Preferable the international drug name", MsgBoxStyle.Exclamation, "Missing Drug Name")
            txtDrugName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPackSize.Text) Then
            MsgBox("Please enter the package size/quantinty", MsgBoxStyle.Exclamation, "Missing Medicine Pack Size")
            txtPackSize.Focus()
            Exit Sub
        End If
        'TaxStatus
        If String.IsNullOrEmpty(cboTax.Text) Then
            MsgBox("Please enter the tax status", MsgBoxStyle.Exclamation, "Missing Tax Status")
            cboTax.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCategory.Text) Then
            MsgBox("Please select the medicine category", MsgBoxStyle.Exclamation, "Missing Medicine Category")
            cboCategory.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboClassification.Text) Then
            MsgBox("Please enter the classification", MsgBoxStyle.Exclamation, "Missing Item Classification")
            cboClassification.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboGenericIndicator.Text) Then
            MsgBox("Please enter the medicine generic indicator", MsgBoxStyle.Exclamation, "Missing Medicine Generic Indicator")
            cboGenericIndicator.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox("Please enter a numeric value for quantity", MsgBoxStyle.Exclamation, "Invalid Quantity Value")
            txtQuantity.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtUnitPrice.Text) Then
            MsgBox("Please enter a valid selling price", MsgBoxStyle.Exclamation, "Invalid Selling Price")
            txtUnitPrice.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtCostPrice.Text) Then
            MsgBox("Please enter a valid cost price", MsgBoxStyle.Exclamation, "Invalid Cost Price")
            txtCostPrice.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblCode.Text) Then
            MsgBox("Please select the medicine manufacturer", MsgBoxStyle.Exclamation, "Missing Medicine Manufacturer")
            cboManufacturer.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        'Remove any undesirable characters from data e.g ', "", AND

        Dim strReplacers() As String = {"'", "&", """"}
        For i As Integer = 0 To strReplacers.Length - 1
            txtCode.Text = Replace(txtCode.Text, strReplacers(i), "", 1)
            txtDrugName.Text = Replace(txtDrugName.Text, strReplacers(i), "", 1)
            txtPackSize.Text = Replace(txtPackSize.Text, strReplacers(i), "", 1)
            cboGenericIndicator.Text = Replace(cboGenericIndicator.Text, strReplacers(i), "", 1)
            txtUnitPrice.Text = Replace(txtUnitPrice.Text, strReplacers(i), "", 1)
            cboCategory.Text = Replace(cboCategory.Text, strReplacers(i), "", 1)
            txtQuantity.Text = Replace(txtQuantity.Text, strReplacers(i), "", 1)
            lblCode.Text = Replace(lblCode.Text, strReplacers(i), "", 1)
        Next

        If boolEditStatus = False Then
            'Check that the record does not exist
            Dim objCheck As New Data.OleDb.OleDbCommand("SELECT ProductCode FROM OchmasSystemMedicines WHERE ProductCode = '" & txtCode.Text & "'", cnn)
            Dim objReadCheck As Data.OleDb.OleDbDataReader = objCheck.ExecuteReader
            If objReadCheck.HasRows Then
                MsgBox("A similar medicine code already exist. Please enter a different one", MsgBoxStyle.Exclamation, "Duplicate Medicine Code")
                objReadCheck.Close()
                Exit Sub
            End If
            objReadCheck.Close()

            strSql = "INSERT INTO OchmasSystemMedicines ([ProductCode], [ProductName], [ManCode], [Strength], " _
                & "[StandardPackSize], [Classification], [CostPrice], [SellPrice], [EffectiveDate], " _
                & "[Quantity], [TaxStatus], [GenericIndicator], [Category]) VALUES " _
                & "('" & txtCode.Text & "', '" & txtDrugName.Text & "', '" & cboManufacturer.Text & "', " _
                & "'" & txtStrength.Text & "', '" & txtPackSize.Text & "', '" & cboClassification.Text & "', " _
                & "" & txtCostPrice.Text & ", " & txtUnitPrice.Text & ", '" & Format(dpEffective.Value, "dd-MMM-yyyy") & "', " _
                & "" & txtQuantity.Text & ", '" & cboTax.Text & "', '" & cboGenericIndicator.Text & "', " _
                & "  '" & cboCategory.Text & "')"
        Else
            strSql = "UPDATE OchmasSystemMedicines SET [ProductName] = '" & txtDrugName.Text & "', " _
                & "[ManCode] = '" & cboManufacturer.Text & "', [Strength] = '" & txtStrength.Text & "', " _
                & "[StandardPackSize] = '" & txtPackSize.Text & "', [Classification] = '" & cboClassification.Text & "', " _
                & "[CostPrice] = " & txtCostPrice.Text & ", [SellPrice] = " & txtUnitPrice.Text & ", " _
                & "[EffectiveDate] = '" & Format(dpEffective.Value, "dd-MMM-yyyy") & "', " _
                & "[Quantity] = " & txtQuantity.Text & ", [TaxStatus] = '" & cboTax.Text & "', " _
                & "[GenericIndicator] = '" & cboGenericIndicator.Text & "', [Category] = '" & cboCategory.Text & "' " _
                & "WHERE [ProductCode] = '" & txtCode.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Save the generic drug list as well 
        SaveGenerics()

        'Save the ICD10 Link here

        MsgBox("Medicine details have been updates successfully", MsgBoxStyle.Information, "Medicine Details Update Success")
        If boolEditStatus = False Then
            'Clear the controls
            ClearControls()
        Else
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicine Update Process"
        ShowErrorMessage()
    End Sub

    Private Sub ClearControls()
        txtCode.Clear()
        txtDrugName.Clear()
        txtPackSize.Clear()
        txtQuantity.Text = "0"
        txtUnitPrice.Text = "0.00"
        txtCode.Focus()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        cboCategory.Items.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CategoryName FROM OchmasDrugCategories ORDER BY CategoryName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCategory.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Categories Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadManufacturers()
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ManufacturerCode +';'+ ManufacturerName " _
            & "FROM OchmasSystemDrugManufacturers ORDER BY ManufacturerName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboManufacturer
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;220"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ManufacturerCode) FROM OchmasSystemDrugManufacturers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboManufacturer.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboManufacturer.SelectedIndex = -1
            cboManufacturer.Items.Clear()
            cboManufacturer.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboManufacturer.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Manufacturer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboManufacturer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboManufacturer.KeyPress

    End Sub

    Private Sub cboManufacturer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboManufacturer.SelectedIndexChanged
        lblCode.Text = "" : lblManufacturer.Text = ""
        lblCode.Text = cboManufacturer.SelectedItem.Col1
        lblManufacturer.Text = cboManufacturer.SelectedItem.Col2
    End Sub

    Private Sub btnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNew.Click
        Dim boolPriorStatus As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmDrugManufacturers
        f.ShowDialog()
        LoadManufacturers()
        boolEditStatus = boolPriorStatus
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) = 13 Then txtDrugName.Focus()
    End Sub

    Private Sub txtPackSize_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPackSize.KeyPress
        If Asc(e.KeyChar) = 13 Then cboCategory.Focus()
    End Sub

    Private Sub cboGenericIndicator_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboGenericIndicator.KeyPress
        If Asc(e.KeyChar) = 13 Then txtQuantity.Focus()
    End Sub

    Private Sub btnAddCategory_Click(sender As Object, e As System.EventArgs) Handles btnAddCategory.Click
        Dim f As New frmDrugCategories
        f.ShowDialog()
        LoadCategories()
    End Sub

    Private Sub LoadGenericDrugs()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ProductName +';'+ProductCode FROM OchmasSystemMedicines WHERE GenericIndicator = 'G' ORDER BY ProductName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = cboItems.Width - 90 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ProductCode) FROM OchmasSystemMedicines WHERE GenericIndicator = 'G'", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(0 To (intItemsCount - 1)) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim p As Double = 0

        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Generic Medicine Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        lblGenericCode.Text = Nothing
        lblGenericCode.Text = cboItems.SelectedItem.Col2
    End Sub

    Private Sub btnAddGeneric_Click(sender As System.Object, e As System.EventArgs) Handles btnAddGeneric.Click
        If String.IsNullOrEmpty(cboItems.Text) Or String.IsNullOrEmpty(lblGenericCode.Text) Then
            MessageBox.Show("Please select a valid medicine from the given list", "Invalid Medicine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        dGridGenerics.Rows.Add(lblGenericCode.Text, cboItems.Text)
    End Sub

    Private Sub SaveGenerics()
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGridGenerics.Rows.Count - 1
            Dim strCode As String = Nothing
            If Not Object.Equals(dGridGenerics.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridGenerics.Rows(i).Cells(0).Value.ToString) Then
                    strCode = dGridGenerics.Rows(i).Cells(0).Value.ToString
                    Dim strSql As String = "DELETE FROM OchmasSystemBrandGenericLink " _
                        & "WHERE [BrandCode] = '" & txtCode.Text & "' AND [GenericCode] = '" & strCode & "'"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    strSql = "INSERT INTO OchmasSystemBrandGenericLink ([BrandCode], [GenericCode]) VALUES " _
                        & "('" & txtCode.Text & "', '" & strCode & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Medicine Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadLinkedGenericDrugs(BrandCode As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT OchmasSystemBrandGenericLink.GenericCode, OchmasSystemMedicines.ProductName " _
            & "FROM OchmasSystemBrandGenericLink LEFT OUTER JOIN OchmasSystemMedicines ON " _
            & "OchmasSystemBrandGenericLink.GenericCode = OchmasSystemMedicines.ProductCode " _
            & "WHERE OchmasSystemBrandGenericLink.BrandCode = '" & BrandCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridGenerics.Rows.Clear()
        While objReader.Read
            dGridGenerics.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Medicine Details Load"
        ShowErrorMessage()
    End Sub

End Class
