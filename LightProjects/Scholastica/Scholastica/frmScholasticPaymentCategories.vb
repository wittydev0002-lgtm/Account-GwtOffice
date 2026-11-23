Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmScholasticPaymentCategories

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        AddSubject()
    End Sub

    Private Sub AddSubject()
        If Not String.IsNullOrEmpty(txtDescription.Text) Then
            dGrid.Rows.Add(txtDescription.Text, "0")
            txtDescription.Clear()
            txtDescription.Focus()
        Else
            MessageBox.Show("Please enter the description", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_PaymentDescriptions", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(i).Cells(0).Value.ToString
                    Dim intPriority As Integer = 0
                    Dim strPaymentType As String = "RECURRING"
                    If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                            If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                                intPriority = CInt(dGrid.Rows(i).Cells(1).Value.ToString)
                            End If
                        End If
                    End If
                    If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                            strPaymentType = dGrid.Rows(i).Cells(2).Value.ToString
                        End If
                    End If
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_PaymentDescriptions " _
                        & "(Description, Priority, PaymentType) VALUES ('" & strDescription & "', " & intPriority & ", '" & strPaymentType & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Payment Descriptions Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Description, Priority, PaymentType FROM SC_PaymentDescriptions ORDER BY Description"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0).ToString, objReader(1).ToString, objReader(2).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Payment Descriptions"
        ShowErrorMessage()
    End Sub

    Private Sub frmStudentSubjects_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub txtSubjects_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AddSubject()
        End If
    End Sub

End Class
