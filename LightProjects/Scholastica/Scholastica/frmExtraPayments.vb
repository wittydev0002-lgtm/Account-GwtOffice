Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmExtraPayments

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboDescription.Text) Then
            MessageBox.Show("Please enter the payment description", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDescription.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        dblExtraAmount = CDbl(txtAmount.Text)
        strExtraPaymentDescription = cboDescription.Text
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmExtraPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPaymentDescriptions()
        cboDescription.Select()
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDescription.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmount.Focus()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub frmExtraPayments_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        '545, 186
        Me.Width = 545
        Me.Height = 186
    End Sub

    Private Sub LoadPaymentDescriptions()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT Description +';'+ CONVERT(NVARCHAR, CAST(Amount AS DECIMAL (10,2))) FROM SC_ExtraPaymentDescriptions ORDER BY Description"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboDescription
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "205;80"
        End With
        'Get a count of the items

        Dim arrItems As New ArrayList
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p).ToString, ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If arrItems.Count > 0 Then
            cboDescription.SelectedIndex = -1
            cboDescription.Items.Clear()
            cboDescription.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboDescription.Items.AddRange(DropDownItems)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Preset Payment Descriptions Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboDescription_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDescription.SelectedIndexChanged
        txtAmount.Text = "0.00"
        txtAmount.Text = cboDescription.SelectedItem.Col2
    End Sub

End Class