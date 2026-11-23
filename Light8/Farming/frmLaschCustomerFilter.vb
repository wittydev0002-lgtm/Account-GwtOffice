Public Class frmLaschCustomerFilter

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strCriteria As String = Nothing
        Dim strProvince As String = Nothing
        Dim strDistrict As String = Nothing
        Dim strWard As String = Nothing
        Dim strCrop As String = Nothing
        Dim strFarmType As String = Nothing

        If Not String.IsNullOrEmpty(txtProvince.Text) Then
            strProvince = "Province = '" & txtProvince.Text & "'"
        End If
        If Not String.IsNullOrEmpty(txtDistrict.Text) Then
            strDistrict = "District = '" & txtDistrict.Text & "'"
        End If
        If Not String.IsNullOrEmpty(txtCrop.Text) Then
            strCrop = "Crop = '" & txtCrop.Text & "'"
        End If
        If Not String.IsNullOrEmpty(txtFarmType.Text) Then
            strFarmType = "FarmType = '" & txtFarmType.Text & "'"
        End If
        If Not String.IsNullOrEmpty(txtWard.Text) Then
            strWard = "Ward = '" & txtWard.Text & "'"
        End If

        If Not String.IsNullOrEmpty(strProvince) Then
            strCriteria = strCriteria & strProvince
        End If

        'Add district filter 
        If Not String.IsNullOrEmpty(strDistrict) Then
            If Not String.IsNullOrEmpty(strCriteria) Then
                strCriteria = strCriteria & " AND " & strDistrict
            Else
                strCriteria = strCriteria & strDistrict
            End If
        End If

        'Add the ward filter
        If Not String.IsNullOrEmpty(strWard) Then
            If Not String.IsNullOrEmpty(strCriteria) Then
                strCriteria = strCriteria & " AND " & strWard
            Else
                strCriteria = strCriteria & strWard
            End If
        End If

        'Add farmtype filter
        If Not String.IsNullOrEmpty(strFarmType) Then
            If Not String.IsNullOrEmpty(strCriteria) Then
                strCriteria = strCriteria & " AND " & strFarmType
            Else
                strCriteria = strCriteria & strFarmType
            End If
        End If

        'Add farmtype filter
        If Not String.IsNullOrEmpty(strCrop) Then
            If Not String.IsNullOrEmpty(strCriteria) Then
                strCriteria = strCriteria & " AND " & strCrop
            Else
                strCriteria = strCriteria & strCrop
            End If
        End If

        'ADD WHERE CLOSE
        Dim strWhere As String = "WHERE " _
            & "LaschCustomers.Cellphone <> NULL OR LaschCustomers.Cellphone <> ''"

        If Not String.IsNullOrEmpty(strCriteria) Then
            strWhere = strWhere & " AND " & strCriteria
        End If

        'Populate the grid
        strLaschFilterSqlString = "SELECT LaschCustomers.Cellphone, LaschCustomers.LastName +' '+ " _
            & "LaschCustomers.FirstName +' '+ LaschCustomers.OtherNames AS [Given Names], " _
            & "LaschCustomers.Province, LaschCustomers.District FROM LaschCustomers " & strWhere & _
             " ORDER BY LaschCustomers.LastName, LaschCustomers.FirstName, LaschCustomers.OtherNames"
        Cursor = Cursors.Default
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lasch Customers Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelectionData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Dim arrProvinces As New ArrayList
        Dim arrDistricts As New ArrayList
        Dim arrCrops As New ArrayList

        'Get and populate provinces
        txtProvince.Items.Clear()
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(Province) FROM " _
            & "LaschCustomers ORDER BY Province", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                txtProvince.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        'Get and populate districts
        txtDistrict.Items.Clear()
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(District) FROM " _
            & "LaschCustomers ORDER BY District", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                txtDistrict.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        'Get and populate crops
        txtCrop.Items.Clear()
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(Crop) FROM " _
            & "LaschCustomers ORDER BY Crop", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                txtCrop.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        'Get and populate farmtype
        txtFarmType.Items.Clear()
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(FarmType) FROM " _
            & "LaschCustomers ORDER BY FarmType", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                txtFarmType.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Provinces, Districts and Crops Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLaschCustomerFilter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSelectionData()
    End Sub

End Class
