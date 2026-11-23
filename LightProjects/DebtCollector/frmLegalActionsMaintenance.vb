Imports CommonLibrary.Commons

Public Class frmLegalActionsMaintenance

    Private Sub frmLegalActionsMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadActions(strSelectedAccount)
        Me.TextExtra = strSelectedAccountName
    End Sub

    Private Sub LoadActions(ByVal DefendantId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date1], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), ActionDate, 106), ' ', '-')) as [Date2], " _
            & "ProcedureName, ActionKey, TransactionId FROM LegalActions " _
            & "WHERE DefendantId = '" & DefendantId & "' ORDER BY ActionDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridActions.Rows.Clear()
        While objReader.Read
            dGridActions.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), _
                gwt_comm.DaysDue(objReader(2).ToString, objReader(3).ToString, strSelectedAccount, _
                CDate(objReader(1).ToString)), objReader("TransactionId").ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Actions History Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAction.Click
        boolEditStatus = False
        Dim frm As New frmLegalActionsStatusUpdate
        frm.ShowDialog()
        LoadActions(strSelectedAccount)
    End Sub

    Private Sub btnEditAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAction.Click
        If dGridActions.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dGridActions.CurrentRow.Cells(dGridActions.ColumnCount - 1).Value.ToString)
            boolEditStatus = True
            Dim frm As New frmLegalActionsStatusUpdate
            frm.ShowDialog()
            LoadActions(strSelectedAccount)
        End If
    End Sub

    Private Sub btnDeleteAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAction.Click
        On Error GoTo RaiseErr
        If dGridActions.Rows.Count > 0 Then
            Dim boolReverseCosts As Boolean = False
            If MessageBox.Show("Are you sure you want to delete this action", "Confirm Action Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want to reverse costs associated with this action as well?", "Reverse Costs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    boolReverseCosts = True
                End If
                If boolReverseCosts = True Then
                    boolAbort = False
                    Dim frm As New frmLegalActionsCostsReversals
                    frm.showdialog()
                    If boolAbort = True Then
                        MessageBox.Show("The whole process is terminated", "Process Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        'update status
                        PostTransactions("DEFENDANTS", strSelectedAccount, Format(Now, "dd-MMM-yyyy"), _
                            dblPublicCostReversalAmount, "PAYMENTS", "ACTION REVERSAL INCLUDING COSTS", _
                            strUserName, "")
                    End If
                End If
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LegalActions WHERE TransactionId = " & intSelectedTransaction & "", cnn)
                objCommand.ExecuteNonQuery()
                LoadActions(strSelectedAccount)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Action Delete"
        ShowErrorMessage()
    End Sub

    Private Sub dGridActions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridActions.DoubleClick
        If dGridActions.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dGridActions.CurrentRow.Cells(dGridActions.ColumnCount - 1).Value.ToString)
            boolEditStatus = True
            Dim frm As New frmLegalActionsStatusUpdate
            frm.ShowDialog()
            LoadActions(strSelectedAccount)
        End If
    End Sub

    Private Sub frmLegalActionsMaintenance_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 600 : Me.Height = 400
    End Sub

End Class