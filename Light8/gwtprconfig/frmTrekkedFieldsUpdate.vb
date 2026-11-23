Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmTrekkedFieldsUpdate

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadCodeDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT Description +';'+ CONVERT(NVARCHAR, CodeNo) AS [CodeDetails] FROM SystemCodes WHERE Description IS NOT NULL ORDER BY CodeNo"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(CodeNo) FROM SystemCodes WHERE Description IS NOT NULL", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCode.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboCode.SelectedIndex = -1
            cboCode.Items.Clear()
            cboCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Code Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCode.SelectedIndexChanged
        If cboCode.Focused = False Then Exit Sub
        If Not cboCode.SelectedItem Is Nothing Then
            lblCode.Text = cboCode.SelectedItem.Col2
        Else
            lblCode.Text = ""
        End If
    End Sub

    Private Sub frmTrekkedFieldsUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCodeDetails()
        If boolEditStatus = True Then
            lblSelectedCode.Text = intSelectedTransaction
            lblCode.Text = intSelectedBatchNumber
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(lblCode.Text) Then
            MessageBox.Show("Please specify the code to be trekked", "Invalid Code Specification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCode.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            'Update the code
            objCommand = New Data.OleDb.OleDbCommand("UPDATE SystemTrakkedFields SET CodeNo = " & lblCode.Text & " WHERE TransactionId = " & lblSelectedCode.Text & "", cnn)
            objCommand.ExecuteNonQuery()
        Else
            'Insert as new
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemTrakkedFields (CodeNo) VALUES (" & lblCode.Text & ")", cnn)
            objCommand.ExecuteNonQuery()
            If MessageBox.Show("Trekked code added successfully. Do you want to add another code?", _
                    "Trekked Field Add Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                lblCode.Text = ""
            Else
                boolEditStatus = True
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Trekked Fields Setup Save"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

End Class
