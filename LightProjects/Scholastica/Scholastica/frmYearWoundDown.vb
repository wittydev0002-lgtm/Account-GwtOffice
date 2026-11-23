Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmYearWoundDown

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolabort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Dim strYear As String = CInt(txtYear.Text)
        If Not IsNumeric(txtYear.Text) Or strYear.Length <> 4 Then
            MessageBox.Show("Please enter a valid value for the year", "Invalid Year Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtYear.Select()
            Exit Sub
        End If

        If CInt(txtYear.Text) > DatePart(DateInterval.Year, Now) Then
            MessageBox.Show("You can not wound down ahead of the current year", "Invalid Year Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtYear.SelectAll()
            Exit Sub
        End If

        intYearStudentLeft = CInt(txtYear.Text)
        boolAbort = False
        Me.Close()

    End Sub

    Private Sub frmYearWoundDown_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtYear.Text = DatePart(DateInterval.Year, Now) - 1
    End Sub

End Class
