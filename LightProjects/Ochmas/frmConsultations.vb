Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmConsultations

    '    Dim boolFormLoading As Boolean

    '    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
    '        If e.KeyChar = "." Then Exit Sub
    '        If e.KeyChar = "-" Then Exit Sub
    '        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    '    End Sub

    '    Private Sub dGridConEntries_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridConEntries.CellEndEdit
    '        If dGridConEntries.CurrentCell.ColumnIndex = 10 Then
    '            If IsNumeric(dGridConEntries.CurrentCell.Value) Then
    '                dGridConEntries.CurrentCell.Value = Format(CDbl(dGridConEntries.CurrentCell.Value.ToString), "##0.00")
    '            End If
    '        End If
    '    End Sub

    '    Private Sub dGridConEntries_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridConEntries.EditingControlShowing
    '        Try
    '            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
    '                AddHandler e.Control.KeyPress, AddressOf CheckCell
    '            Else
    '                'In order to prevent optical problems, we had to call the removeHandler twice
    '                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
    '                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub cboAccident_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAccident.SelectedIndexChanged
    '        If UCase(cboAccident.Text) = "OTHER" Then
    '            txtOtherAccidents.Enabled = True
    '        Else
    '            txtOtherAccidents.Enabled = False
    '        End If
    '    End Sub

    '    Private Sub btnNewPatient_Click(sender As System.Object, e As System.EventArgs) Handles btnNewPatient.Click
    '        boolEditStatus = False
    '        Dim frm As New frmPatientDetails
    '        frm.ShowDialog()
    '        LoadPatientDetails()
    '    End Sub

    '    Private Sub LoadPatientDetails()
    '        On Error GoTo RaiseErr
    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +'|'+ " _
    '            & "UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) " _
    '            & "+'|'+ IdNumber +'|'+ CONVERT(NVARCHAR, PatientId) AS " _
    '            & "[Details] FROM OchmasPatients ORDER BY LastName, FirstName, BirthDate", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        Dim arrData As New ArrayList

    '        While objReader.Read
    '            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
    '        End While
    '        objReader.Close()

    '        Dim intWidth1 As Integer = cboMemberName.Width - 80

    '        'Add the items to the drop down box
    '        With cboMemberName
    '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
    '            .ColumnNum = 4
    '            .HighlightBorderOnMouseEvents = True
    '            .ManagingFastMouseMoving = True
    '            .Enabled = True
    '            .GridLineHorizontal = True
    '            .GridLineVertical = True
    '            .ColumnWidth = "200;80;80;0"
    '        End With

    '        'Get a count of the items
    '        Dim intItemsCount As Integer = arrData.Count
    '        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

    '        cboMemberName.Items.Clear()

    '        For i As Integer = 0 To arrData.Count - 1
    '            'File the listview with details.
    '            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
    '                Dim strRecordText() As String = Split(arrData.Item(i), "|")
    '                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
    '            End If
    '        Next

    '        'Load the clients to the combo box
    '        If intItemsCount > 0 Then
    '            With cboMemberName
    '                .SelectedIndex = -1
    '                .Items.Clear()
    '                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
    '                .Items.AddRange(DropDownItems)
    '            End With
    '        End If
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Names Load"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub ClearControls()
    '        lblClaimNumber.Text = Nothing
    '        lblAddress1.Text = Nothing
    '        lblEmployer.Text = Nothing
    '        lblMedicalAid.Text = Nothing
    '        lblDateOfBirth.Text = Nothing
    '        cboMemberName.Text = Nothing
    '        cboPatientName.Text = Nothing
    '        txtMemberNumber.Text = Nothing
    '        cboAccident.Text = Nothing
    '        txtOtherAccidents.Text = Nothing
    '        txtReferingPractitioner.Text = Nothing
    '        txtReferingAnaesthetist.Text = Nothing
    '        txtReferingSurgicalAssistance.Text = Nothing
    '        txtDiagnosis.Text = Nothing
    '        txtDiagnosisDetails.Text = Nothing
    '        dGridConEntries.Rows.Clear()
    '        dGridConEntries.Rows.Add(10)
    '    End Sub

    '    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
    '        SaveConsultation()
    '        'Clear controls and increament to next number
    '        ClearControls()
    '        lblClaimNumber.Text = Format(gwt_comm.GetNextDocumentNumber("Claims"), "000000")
    '    End Sub

    '    Private Sub SaveConsultation()
    '        On Error GoTo RaiseErr

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Consultation Save"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub btnMedicines_Click(sender As Object, e As System.EventArgs) Handles btnMedicines.Click
    '        Dim frm As New frmMedication
    '        frm.ShowDialog()
    '    End Sub

    '    Private Sub frmConsultations_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '        boolFormLoading = True
    '        dGridConEntries.Rows.Add(10)
    '        LoadPatientDetails()
    '        lblClaimNumber.BackColor = Color.WhiteSmoke
    '        lblAddress1.BackColor = Color.WhiteSmoke
    '        lblEmployer.BackColor = Color.WhiteSmoke
    '        lblMedicalAid.BackColor = Color.WhiteSmoke
    '        lblDateOfBirth.BackColor = Color.WhiteSmoke
    '        btnMedicines.Enabled = True
    '        boolFormLoading = False
    '    End Sub

End Class
