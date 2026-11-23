Imports CommonLibrary.Commons

Public Class frmInventoryClone

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolabort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        'get the actions details
        strSql = gwt_comm.ScriptTableFields("InventoryItems", "SELECT")
        strSql = strSql & " WHERE ItemCode = '" & txtParentItemCode.Text & "'"

        Dim strDataInsertSql As String = Nothing
        strDataInsertSql = gwt_comm.ScriptDataInsertStatement(strSql, "InventoryItems")

        strDataInsertSql = Replace(strDataInsertSql, txtParentItemCode.Text, txtCloneItemCode.Text, 1)

        Dim dblQuantity As Double = 0

        'CHECK FOR DUPLICATES
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode FROM InventoryItems WHERE ItemCode = '" & txtCloneItemCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Close()
            If MessageBox.Show("Item with similar code already exist in the system." & vbCrLf & _
                "Do you want to update it instead?", "Duplicate Item Code", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                dblQuantity = 0
                objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems " _
                    & "WHERE ItemCode = '" & txtCloneItemCode.Text & "'", cnn)
                objReader = objCommand.ExecuteReader
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
                    & "WHERE ItemCode = '" & txtCloneItemCode.Text & "'", cnn)
                objCommand.ExecuteNonQuery()
                Me.Close()
                Exit Sub
            Else
                txtCloneItemCode.Focus()
                Exit Sub
            End If
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strDataInsertSql, cnn)
        objCommand.ExecuteNonQuery()

        dblQuantity = 0
        If IsNumeric(txtQuantity.Text) Then
            dblQuantity = CDbl(txtQuantity.Text)
        End If

        objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & dblQuantity & ", " _
            & "ShortCode = '" & txtShortCode.Text & "' WHERE ItemCode = '" & txtCloneItemCode.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Inventory Item has been cloned successfully.", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'If MessageBox.Show("Inventory Item has been cloned successfully." & vbCrLf & "Do you want to view record?", "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    boolEditStatus = True
        '    strInventoryItemCode = txtCloneItemCode.Text
        '    Dim frm As New frmInventorySetup
        '    frm.ShowDialog()
        '    Me.Close()
        'End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Inventory Item Cloning"
        ShowErrorMessage()
    End Sub

    Private Sub frmInventoryClone_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtParentItemCode.Text = strInventoryItemCode
        txtCloneItemCode.Text = strInventoryItemCode
    End Sub

    Private Sub txtCloneItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCloneItemCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
        If Asc(e.KeyChar) = 13 Then txtShortCode.Focus()
    End Sub

    Private Sub txtShortCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
        If Asc(e.KeyChar) = 13 Then txtQuantity.Focus()
    End Sub

    Private Sub txtQuantity_GotFocus(sender As Object, e As System.EventArgs) Handles txtQuantity.GotFocus
        txtQuantity.SelectAll()
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

    Private Sub frmInventoryClone_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 455 : Me.Height = 217
    End Sub

End Class
