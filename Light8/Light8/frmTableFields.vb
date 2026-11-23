Imports CommonLibrary.Commons

Public Class frmTableFields

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmTableFields_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboPrimaryField.Items.Clear()
        cboQuantityField.Items.Clear()
        For p As Integer = 0 To arrSelectedArray.Count - 1
            cboPrimaryField.Items.Add(arrSelectedArray.Item(p))
            cboQuantityField.Items.Add(arrSelectedArray.Item(p))
        Next
    End Sub

    Private Sub frmTableFields_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 503 : Me.Height = 185
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboQuantityField.Text) Then
            MessageBox.Show("Please select the Quantity Field", "Missing Quantity Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboQuantityField.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPrimaryField.Text) Then
            MessageBox.Show("Please select the Primary Field", "Missing Primary Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPrimaryField.Focus()
            Exit Sub
        End If
        strSelectedTableQuantityField = cboQuantityField.Text
        strSourceTableKeyField = cboPrimaryField.Text
        boolAbort = False
        Me.Close()
    End Sub

End Class
