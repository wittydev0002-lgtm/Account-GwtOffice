Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOpenProjectClaims

    Private Sub frmOpenProjectClaims_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadProjectOwners()
    End Sub

    Private Sub LoadProjectOwners()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountName +'|'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        Dim arrData As New ArrayList

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboProjectOwner.Width - 80

        'Add the items to the drop down box
        With cboProjectOwner
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

        cboProjectOwner.Items.Clear()

        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboProjectOwner
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboProjectOwner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.SelectedIndexChanged
        lblProjectOwner.Text = Nothing
        lblProjectOwner.Text = cboProjectOwner.SelectedItem.Col2.ToString
        LoadClientProjects(lblProjectOwner.Text)
    End Sub

    Private Sub LoadClientProjects(ByVal CustomerNumber As String)
        On Error GoTo RaiseErr
        If boolFormInitializing = True Then Exit Sub
        Dim strSql As String = "SELECT ContractName +'|'+ CONVERT(NVARCHAR, ContractNumber) " _
            & "FROM ProjectsMain WHERE CustomerNumber = '" & CustomerNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim arrData As New ArrayList

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboProject.Width - 80

        'Add the items to the drop down box
        With cboProject
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

        cboProject.Items.Clear()

        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboProject
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboProject_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProject.SelectedIndexChanged
        On Error Resume Next
        lblProjectNumber.Text = Nothing
        lblProjectSite.Text = Nothing
        lblProjectNumber.Text = cboProject.SelectedItem.Col2.ToString
        lblProjectSite.Text = cboProject.SelectedItem.Col1.ToString
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        strSelectedDescription = Nothing
        If String.IsNullOrEmpty(lblProjectOwner.Text) Then
            MessageBox.Show("Please select the project owner", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboProjectOwner.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblProjectNumber.Text) Then
            MessageBox.Show("Please select the project to view claims for", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboProject.Focus()
            Exit Sub
        End If
        strSelectedProjectOwnerNumber = lblProjectOwner.Text
        strSelectedAccountName = cboProjectOwner.Text
        intSelectedProjectNumber = CInt(lblProjectNumber.Text)
        strSelectedDescription = lblProjectSite.Text
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmOpenProjectClaims_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 535 : Me.Height = 210
    End Sub

End Class
