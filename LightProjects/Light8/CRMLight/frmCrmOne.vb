Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCrmOne

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolAbort = False
        boolEditStatus = False
        Dim frm As New frmProspectSetup
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ProspectId], [ProspectName], [ContactName], " _
            & "REPLACE([Telephone] + '/'+ [Cellphone] +'/'+ [ContactTelephone], '//', '') AS [Contact Numbers], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), ContactDate, 106), ' ', '-')) as [ContactDate], " _
            & "[Agent] FROM Prospects ORDER BY [ProspectName]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Populate the service the prospects are interested in

        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim intId As Integer = 0
            Dim strServices As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        intId = CInt(dGrid.Rows(p).Cells(0).Value.ToString)
                        strSql = "SELECT CrmProspectRequirements.ServiceId, CrmProducts.ProductName " _
                            & "FROM CrmProspectRequirements " _
                            & "LEFT OUTER JOIN CrmProducts ON CrmProspectRequirements.ServiceId = CrmProducts.TransactionId " _
                            & "WHERE ProspectId = " & intId & ""
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objReader = objCommand.ExecuteReader
                        While objReader.Read
                            If Not IsDBNull(objReader(1).ToString) Then
                                strServices = strServices & objReader(1).ToString & ", "
                            End If
                        End While
                        objReader.Close()
                        If Not String.IsNullOrEmpty(strServices) Then
                            strServices = Mid(strServices, 1, strServices.Length - 2)
                        End If
                    End If
                End If
            End If
            dGrid.Rows(p).Cells(dGrid.Columns.Count - 1).Value = strServices
        Next
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prospects Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCrmOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelectedProspect()
    End Sub

    Private Sub GetSelectedProspect()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
        boolAbort = False
        boolEditStatus = True
        Dim frm As New frmProspectSetup
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadData()
    End Sub

    Private Sub btnProducts_Click(sender As System.Object, e As System.EventArgs) Handles btnProducts.Click
        Dim frm As New frmServices
        frm.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub dGrid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellContentDoubleClick
        GetSelectedProspect()
    End Sub

End Class
