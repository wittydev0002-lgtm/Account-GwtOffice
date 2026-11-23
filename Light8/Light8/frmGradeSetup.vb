Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmGradeSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter a description for this grade. The description is usually the grading method " _
                & vbCrLf & "the grading method e.g. Castellion or Hay Broad Band", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtInternalGrade.Text) Then
            MessageBox.Show("Please enter internal grade", "Invalid Grade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtInternalGrade.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNecGrade.Text) Then
            MessageBox.Show("Please enter the NEC grade equivalent.", "Invalid NEC Grade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNecGrade.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO JobGrades (Description, InternalGrade, NecGrade) VALUES " _
                & "('" & txtDescription.Text & "', '" & txtInternalGrade.Text & "', '" & txtNecGrade.Text & "')"
        Else
            strSql = "UPDATE JobGrades SET Description = '" & txtDescription.Text & "', " _
                & "InternalGrade = '" & txtInternalGrade.Text & "', NecGrade = '" & txtNecGrade.Text & "' " _
                & "WHERE TransactionId = " & intSelectedTransaction & ""
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatusTwo = False Then
            If MessageBox.Show("Grade saved successfully. Do you want to add further grades?", "Grade Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                boolEditStatusTwo = False
                txtDescription.Clear()
                txtInternalGrade.Clear()
                txtNecGrade.Clear()
                txtDescription.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("Grade saved successfully.", "Grade Setup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Grades Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmGradeSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If boolEditStatusTwo = True Then
            'Read the data from the database
            objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM JobGrades WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("Description").ToString) Then
                    txtDescription.Text = objReader("Description").ToString
                End If
                If Not IsDBNull(objReader("InternalGrade").ToString) Then
                    txtInternalGrade.Text = objReader("InternalGrade").ToString
                End If
                If Not IsDBNull(objReader("NecGrade").ToString) Then
                    txtNecGrade.Text = objReader("NecGrade").ToString
                End If
            End If
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Grades Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then txtInternalGrade.Focus()
    End Sub

    Private Sub txtInternalGrade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInternalGrade.KeyPress
        If Asc(e.KeyChar) = 13 Then txtNecGrade.Focus()
    End Sub

    Private Sub txtNecGrade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNecGrade.KeyPress
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

End Class
