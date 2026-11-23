Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDepartmentsSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDepartmentCode.Text) Then
            MessageBox.Show("Please enter the department code", "Missing Department Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDepartmentCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDepartmentName.Text) Then
            MessageBox.Show("Please enter the department name", "Missing Department Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDepartmentName.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        'Check that the department code is in existence
        If boolEditStatusTwo = False Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT DepartmentName FROM SystemDepartments WHERE " _
                & "OrdinalNo = " & txtDepartmentCode.Text & "", Cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("The department code is already in use, please enter a different code", _
                    "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDepartmentCode.Clear()
                txtDepartmentCode.Focus()
                Exit Sub
                objReader.Close()
            End If
            objReader.Close()
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO systemDepartments (OrdinalNo, DepartmentName) " _
                        & "VALUES (" & txtDepartmentCode.Text & ", '" & txtDepartmentName.Text & "')", Cnn)
            objCommand.ExecuteNonQuery()
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE systemDepartments SET " _
                & "DepartmentName = '" & txtDepartmentName.Text & "' " _
                & "WHERE OrdinalNo = " & txtDepartmentCode.Text & "", Cnn)
            objCommand.ExecuteNonQuery()
        End If
        MessageBox.Show("Details Saved Successfully", "Department Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Department Setup Failure"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub txtDepartmentCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartmentCode.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmDepartmentsSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatusTwo = True Then
            txtDepartmentCode.Enabled = False
            txtDepartmentCode.Text = intSelectedTransaction
            txtDepartmentName.Text = strSelectedDescription
            txtDepartmentName.SelectAll()
        End If
    End Sub

End Class
