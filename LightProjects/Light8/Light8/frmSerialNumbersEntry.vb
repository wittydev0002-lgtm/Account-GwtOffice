
Imports CommonLibrary
Imports CommonLibrary.Commons

Public Class frmSerialNumbersEntry

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmSerialNumbersEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dgrvSerialsOrders.Rows.Add(150)
        For i As Integer = 0 To dgrvSerialsOrders.Rows.Count - 1
            With dgrvSerialsOrders
                .Rows(i).Cells(0).Value = (i + 1)
                .Rows(i).Cells(0).Style.BackColor = Color.FromArgb(190, 215, 239)  'Color.LightGray
            End With
        Next
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        dblSerializedCostPrice = 0

        If Not IsNumeric(txtUnitPrice.Text) Then
            MessageBox.Show("Please enter the unit cost price", "Invalid Cost Price", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUnitPrice.Focus()
            Exit Sub
        Else
            dblSerializedCostPrice = CDbl(txtUnitPrice.Text)
        End If

        arrSerialsCaptured = New ArrayList

        For i As Integer = 0 To dgrvSerialsOrders.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dgrvSerialsOrders.Rows(i).Cells(1).Value), "") Then
                arrSerialsCaptured.Add(dgrvSerialsOrders.Rows(i).Cells(1).Value.ToString)
            End If
        Next
        If arrSerialsCaptured.Count <= 0 Then
            MessageBox.Show("All specific type items must have serial numbers. " _
                & "None have been detected therefore process will be terminated", _
                 "Missing Serial Numbers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgrvSerialsOrders.Focus()
            dgrvSerialsOrders.CurrentCell = dgrvSerialsOrders.Rows(0).Cells(1)
            Exit Sub
        Else
            boolAbort = False
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On goods received serial numbers entry"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmSerialNumbersEntry_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 363 : Me.Height = 430
    End Sub

End Class
