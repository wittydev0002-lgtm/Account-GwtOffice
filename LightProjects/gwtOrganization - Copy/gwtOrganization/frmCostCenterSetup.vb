Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCostCenterSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtCostCenterCode.Text) Then
            MessageBox.Show("Please enter the cots center code", "Missing Cost Center Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCostCenterCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCostCenterName.Text) Then
            MessageBox.Show("Please enter the cost center name", "Missing Cost Center Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCostCenterName.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        'Check that the cost center code is in existence
        If boolEditStatusTwo = False Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT CostCenterName FROM SystemCostCenters WHERE " _
                & "OrdinalNo = " & txtCostCenterCode.Text & "", Cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("The cost center code is already in use, please enter a different code", _
                    "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCostCenterName.Clear()
                txtCostCenterCode.Focus()
                Exit Sub
                objReader.Close()
            End If
            objReader.Close()
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO systemCostCenters (OrdinalNo, CostCenterName) " _
                        & "VALUES (" & txtCostCenterCode.Text & ", '" & txtCostCenterName.Text & "')", Cnn)
            objCommand.ExecuteNonQuery()
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE systemCostCenters SET " _
                & "CostCenterName = '" & txtCostCenterName.Text & "' " _
                & "WHERE OrdinalNo = " & txtCostCenterCode.Text & "", Cnn)
            objCommand.ExecuteNonQuery()
        End If
        MessageBox.Show("Details Saved Successfully", "Cost Center Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Cost Center Setup Failure"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub txtDepartmentCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostCenterCode.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmDepartmentsSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatusTwo = True Then
            txtCostCenterCode.Enabled = False
            txtCostCenterCode.Text = intSelectedTransaction
            txtCostCenterName.Text = strSelectedDescription
            txtCostCenterName.SelectAll()
        End If
    End Sub

End Class
