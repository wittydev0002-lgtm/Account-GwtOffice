Imports CommonLibrary.Commons

Public Class frmLegalDebtorsPotfolioAssignment

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        'add the first item of the array data
        arrData.Add("--ALL--|0")
        'Add the rest from the database
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClients.Width - 80

        'Add the items to the drop down box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        If Not cboClients.SelectedItem Is Nothing Then
            lblClientId.Text = cboClients.SelectedItem.Col2
        Else
            lblClientId.Text = "0"
        End If
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT UserName FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboUsers.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUsers.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On User Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalDebtorsPotfolioAssignment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadUsers()
        LoadClients()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboUsers.Text) Then
            MessageBox.Show("Please select the user name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboUsers.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DebtorsPotfolios WHERE AssignedUserName = '" & cboUsers.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strPotfolioId As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    strPotfolioId = dGrid.Rows(i).Cells(1).Value.ToString
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DebtorsPotfolios (PotfolionId, AssignedUserName) VALUES " _
                                & "('" & strPotfolioId & "', '" & cboUsers.Text & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next

        MessageBox.Show("Details updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Potfolio Assignment"
        ShowErrorMessage()
    End Sub

    Private Sub cboUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsers.SelectedIndexChanged
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Plaintifs.GivenNames, DebtorsPotfolios.PotfolionId FROM DebtorsPotfolios LEFT OUTER JOIN Plaintifs " _
            & "ON DebtorsPotfolios.PotfolionId = Plaintifs.PlaintifId WHERE AssignedUserName = '" & cboUsers.Text & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Potfolio Assignment"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(lblClientId.Text) Then
            If Not String.IsNullOrEmpty(cboClients.Text) Then
                dGrid.Rows.Add(cboClients.Text, lblClientId.Text)
            End If
        End If
    End Sub

    Private Sub dGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellContentClick
        If e.ColumnIndex = 2 Then
            dGrid.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub frmLegalDebtorsPotfolioAssignment_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 510 : Me.Height = 423
    End Sub

End Class