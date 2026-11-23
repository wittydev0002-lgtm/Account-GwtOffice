Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmHomePageCustomization
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmHomePageCustomization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim strSql As String = "IF OBJECT_ID(N'SystemHomePageModules', N'U') IS NULL " _
            & "CREATE TABLE SystemHomePageModules ([ModuleName][NVARCHAR](350) NOT NULL DEFAULT '', " _
            & "[UserName][NVARCHAR](150) NOT NULL REFERENCES Users (UserName), " _
            & "[TransactionId][INT] Not NULL PRIMARY KEY IDENTITY (1,1))"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        With dGrid
            .Rows.Add(False, "Inventory Management")
            .Rows.Add(False, "Point of Sale")
            .Rows.Add(False, "Purchases And Orders")
            .Rows.Add(False, "Cashbook")
            .Rows.Add(False, "Loan Manager")
            .Rows.Add(False, "General Ledger Accounts")
            .Rows.Add(False, "Invoicing")
            .Rows.Add(False, "Scholastica")
            .Rows.Add(False, "Projects")
            .Rows.Add(False, "Asset Management")
            .Rows.Add(False, "Employee Management")
            .Rows.Add(False, "Payroll")
            .Rows.Add(False, "Debt Collection")
            .Rows.Add(False, "Patient Management")
            .Rows.Add(False, "Medicines Dispensing")
            .Rows.Add(False, "Hotel Management")
            .Rows.Add(False, "Customer Relations Management")
        End With

        objCommand = New Data.OleDb.OleDbCommand("SELECT ModuleName FROM SystemHomePageModules " _
            & "WHERE UserName = '" & strUserName & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0)) Then
                For p As Integer = 0 To dGrid.Rows.Count - 1
                    If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                            If UCase(objReader(0).ToString) = UCase(dGrid.Rows(p).Cells(1).Value.ToString) Then
                                dGrid.Rows(p).Cells(0).Value = True
                            End If
                        End If
                    End If
                Next
            End If
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Home page user preference settings"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM SystemHomePageModules WHERE UserName = '" & strUserName & "'", cnn)
        objDelete.ExecuteNonQuery()
        With dGrid
            For p As Integer = 0 To .Rows.Count - 1
                If .Rows(p).Cells(0).Value = True Then
                    Dim strModule As String = .Rows(p).Cells(1).Value.ToString
                    Dim strSql As String = "INSERT INTO SystemHomePageModules (ModuleName, UserName) " _
                        & "VALUES ('" & strModule & "', '" & strUserName & "')"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End With
        MessageBox.Show("Your home page preferances have been set successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Home page user preference settings"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_MouseUp(sender As Object, e As MouseEventArgs) Handles dGrid.MouseUp
        dGrid.EndEdit()
    End Sub

End Class