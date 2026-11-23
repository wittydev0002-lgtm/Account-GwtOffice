Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmCashBookListing

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEmployee.Click
        boolEditStatus = False
        Dim f As New frmCashbookSetup
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count > 0 Then
            strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelected()
        boolEditStatus = True
        Dim f As New frmCashbookSetup
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
        boolEditStatus = True
        Dim f As New frmCashbookSetup
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        GetSelected()
        If MessageBox.Show("Are you sure you want to delete the selected cashbook from the system?", _
                "Record Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM Cashbooks WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            sqlCommand.ExecuteNonQuery()
        End If
        LoadData()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Record Deletion Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName  FROM Cashbooks ORDER BY AccountName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Cashbook Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCashbookListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
        CashbookBalances()
        Dim dblTotals As Double = 0
        For i As Integer = 0 To dGrid.RowCount - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString()) Then
                    If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        dblTotals = dblTotals + CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        lblBalance.Text = Format(dblTotals, "#,##0.00")
    End Sub

    Private Sub CashbookBalances()
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                Dim strAccount As String = dGrid.Rows(i).Cells(0).Value.ToString
                Dim dblReturnValues() As Double = gwt_comm.CashbookAccountBalances(CDate("01-JAN-1900"), CDate(gwt_comm.shortMonthDateFormat(Now)), strAccount)
                dGrid.Rows(i).Cells(2).Value = Format(dblReturnValues(1), "#,##0.00")
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbook Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCashBookListing_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 632 : Me.Height = 481
    End Sub

End Class