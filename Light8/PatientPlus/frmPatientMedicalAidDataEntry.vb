Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPatientMedicalAidDataEntry

    Private Sub frmPatientMedicalAidDataEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the medical aid schemes and their packages

    End Sub

    Private Sub frmPatientMedicalAidDataEntry_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 527 : Me.Height = 285
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(cboMedicalAidScheme.Text) Or String.IsNullOrEmpty(lblSchemeCode.Text) Then
            MessageBox.Show("Please select the medical aid scheme from the given list", "Invalid Medical Aid Scheme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboMedicalAidScheme.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPackage.Text) Then
            MessageBox.Show("Please select the scheme package", "Missing Scheme Package", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPackage.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtMedaidNumber.Text) Then
            MessageBox.Show("Please enter the member number", "Missing Member Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMedaidNumber.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtMedaidSuffix.Text) Then
            MessageBox.Show("Please enter a valid suffix", "Invalid Suffix", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMedaidSuffix.Select()
            Exit Sub
        End If

        strSelectedMedicalSchemeName = cboMedicalAidScheme.Text
        strSelectedMedicalSchemePackage = cboPackage.Text
        strSelectedPatientMedaidNumber = txtMedaidNumber.Text
        strSelectedPatientMedaidSuffix = txtMedaidSuffix.Text
        strSelectedMedicalSchemeCode = lblSchemeCode.Text
        strSelectedDate = gwt_comm.shortMonthDateFormat(dpMedaidExpireDate.Value)

        boolAbort = False
        Me.Close()
    End Sub
End Class