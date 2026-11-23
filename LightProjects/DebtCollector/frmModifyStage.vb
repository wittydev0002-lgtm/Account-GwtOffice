Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmModifyStage

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadGroupActions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [ProcedureId]) +';'+ [ActionName] AS [Data] " _
            & "FROM ProdedureAndActions WHERE [ParentStatus] = 'YES' ORDER BY [ActionName]"
        'WHERE SubAccountOf = 'None' 
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboActionCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .MaxDropDownItems = 10
            .DropDownHeight = 110
            .ColumnWidth = "80;228"
        End With

        Dim arrItems As New ArrayList
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboActionCode.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboActionCode.SelectedIndex = -1
            cboActionCode.Items.Clear()
            cboActionCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboActionCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmModifyStage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        LoadGroupActions()
        If boolAbort = True Then Exit Sub
        On Error GoTo RaiseErr
        txtAction.Text = strSelectedDescription
        lblProcedureId.Text = intSelectedTransaction
        Dim strSql As String = "SELECT [ParentStatus], [SubActionOf] " _
            & "FROM ProdedureAndActions WHERE [ProcedureId] = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then cboParentStatus.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then cboActionCode.Text = objReader(1).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & " On Stage details modification"
        ShowErrorMessage()
    End Sub

    Private Sub cboActionCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboActionCode.SelectedIndexChanged
        lblCodeDescription.Text = ""
        If Not cboActionCode.SelectedItem Is Nothing Then
            lblCodeDescription.Text = cboActionCode.SelectedItem.Col2
        End If
    End Sub

    Private Sub frmModifyStage_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 500 : Me.Height = 212
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtAction.Text) Then
            If String.IsNullOrEmpty(cboParentStatus.Text) Then cboParentStatus.Text = "NO"
            Dim strSql As String = "UPDATE ProdedureAndActions SET [ActionName] = '" & txtAction.Text & "', " _
                & "[SubActionOf] = " & cboActionCode.Text & ", [ParentStatus] = '" & cboParentStatus.Text & "' " _
                & "WHERE [ProcedureId] = " & intSelectedTransaction & ""
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Action saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please enter the action name", "Invalid Action Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAction.Focus()
            Exit Sub
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub
End Class