Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLaybyCustomersListing

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmLaybyCustomer
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub GetSelectedRecord()
        strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGrid.RowCount > 0 Then
            GetSelectedRecord()
            boolEditStatus = True
            Dim f As New frmLaybyCustomer
            f.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT [AccountNumber], [AccountName], " _
            & "[Address1] +', '+ [Address2] +', '+ [Address3] +', '+ [Address4] AS [Address], [Telephone], " _
            & "[Cellphone],[EmailAddress] FROM LaybyCustomers ORDER BY AccountName, AccountNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), "0.00")
            End With
        End While
        objReader.Close()
        'Get the account balance

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Layby Customer Details Load Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmLaybyCustomersListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.RowCount > 0 Then
            GetSelectedRecord()
            boolEditStatus = True
            Dim f As New frmLaybyCustomer
            f.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub btnPayments_Click(sender As System.Object, e As System.EventArgs) Handles btnPayments.Click
        Dim frm As New frmLaybyeSettlement
        frm.ShowDialog()
    End Sub

    Private Sub btnCashout_Click(sender As System.Object, e As System.EventArgs) Handles btnCashout.Click
        Dim frm As New frmLaybyeCashout
        frm.ShowDialog()
    End Sub

End Class
