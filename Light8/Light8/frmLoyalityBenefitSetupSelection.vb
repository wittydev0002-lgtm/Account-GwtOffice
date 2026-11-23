Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityBenefitSetupSelection

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub cboBenefitType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBenefitType.SelectedIndexChanged
        If cboBenefitType.Text = "FREEBIES" Then
            lblInformation.Text = "This will allow you to set up a program where loyal customers are given free products after a given number of visits. The count can be per product/service or per visit"
        Else
            lblInformation.Text = "This will allow you to set up a program where loyal " _
                & "customers are given discounts after a given number of visits or cummulative dollar sales. The count " _
                & "can be per product/service or per visit"
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboBenefitType.Text) Then
            MessageBox.Show("Please select the desired benefit type", "No Selection Made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBenefitType.Focus()
            Exit Sub
        End If
        strPublicBenefitType = UCase(cboBenefitType.Text)
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmLoyalityBenefitSetupSelection_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 540 : Me.Height = 250
    End Sub

End Class
