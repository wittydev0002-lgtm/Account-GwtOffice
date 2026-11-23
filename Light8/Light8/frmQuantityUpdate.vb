Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmQuantityUpdate

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        Dim dblQuantity As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems " _
            & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblQuantity = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        If IsNumeric(txtQuantity.Text) Then
            dblQuantity = dblQuantity + CDbl(txtQuantity.Text)
        End If
        objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & dblQuantity & " " _
            & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
        objCommand.ExecuteNonQuery()
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Inventory Quantity Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmQuantityUpdate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TextExtra = strInventoryItemCode
        txtQuantity.Select()
        txtQuantity.SelectAll()
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub

End Class
