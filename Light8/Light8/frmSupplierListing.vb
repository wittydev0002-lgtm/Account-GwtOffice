Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupplierListing

    Private Sub btnNewSupplier_Click(sender As System.Object, e As System.EventArgs) Handles btnNewSupplier.Click
        boolEditStatus = False
        Dim frm As New frmSupplierDetails
        frm.ShowDialog()
        LoadCreditors("Account Name")
    End Sub

    Private Sub GetSelectedCreditor()
        If dGridCreditors.Rows.Count > 0 Then
            strSelectedAccount = dGridCreditors.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub LoadCreditors(ByVal OrderBy As String)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        If UCase(OrderBy) = UCase("Account Name") Then
            strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), TakeOnDate, 106), ' ', '-')) as [Take On Date], " _
                & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                & "EmailAddress as [Email Address], PhoneNumber +' '+ Cellphone AS [Contact Nos] " _
                & "FROM Suppliers ORDER BY AccountName"
        Else
            strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), TakeOnDate, 106), ' ', '-')) as [Take On Date], " _
                & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                & "EmailAddress as [Email Address], PhoneNumber +' '+ Cellphone AS [Contact Nos] " _
                & "FROM Suppliers ORDER BY AccountNumber"
        End If

        dGridCreditors.Columns.Clear()
        Me.dGridCreditors.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridCreditors.DataSource = dTable
        For p As Integer = 0 To dGridCreditors.Columns.Count - 1
            dGridCreditors.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Creditors Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCreditorSearchBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCreditorSearchBy.SelectedIndexChanged
        If cboCreditorSearchBy.Text = "Account Number" Then
            LoadCreditors("Account Number")
        Else
            LoadCreditors("Account Name")
        End If
    End Sub

    Private Sub btnEditCreditor_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCreditor.Click
        If IntPublicSuppliers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        GetSelectedCreditor()
        boolEditStatus = True
        Dim f As New frmSupplierDetails
        f.ShowDialog()
        If MessageBox.Show("Do you want to refresh the view right now?", "Refresh View", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            LoadCreditors("Account Name")
        End If
    End Sub


    Private Sub btnRefreshCreditors_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshCreditors.Click
        LoadCreditors("Account Name")
    End Sub

    Private Sub dGridCreditors_DoubleClick(sender As Object, e As EventArgs) Handles dGridCreditors.DoubleClick
        If IntPublicSuppliers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        GetSelectedCreditor()
        boolEditStatus = True
        Dim f As New frmSupplierDetails
        f.ShowDialog()
        If MessageBox.Show("Do you want to refresh the view right now?", "Refresh View", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            LoadCreditors("Account Name")
        End If
    End Sub

    Private Sub btnAccountSettlement_Click(sender As System.Object, e As System.EventArgs) Handles btnAccountSettlement.Click
        Dim frm As New frmSupplierAccountPayments
        frm.ShowDialog()
    End Sub

End Class