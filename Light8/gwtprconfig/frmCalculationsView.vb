Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmCalculationsView

    Dim boolContinue As Boolean

    Private Sub tsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim f As New frmNewCalculation
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        'Call the calculations form in add new mode
        boolEditStatus = False
        Me.Close()
    End Sub

    Private Sub LoadCalculations()
        On Error GoTo RaiseErr
        dgrid.Rows.Clear()
        boolContinue = True
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT CalculationNo, " _
            & "CalculationName FROM SystemCalculationNames ORDER BY " _
            & "CalculationNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim CurrentCell As DataGridViewCell
        Dim i As Integer = 0

        While objReader.Read
            dgrid.Rows.Add(1)
            CurrentCell = dgrid.Rows(dgrid.Rows.Count - 1).Cells(1)
            If Not IsDBNull(objReader(0).ToString) Then CurrentCell.Value = objReader(0).ToString
            CurrentCell = dgrid.Rows(dgrid.Rows.Count - 1).Cells(2)
            If Not IsDBNull(objReader(1).ToString) Then CurrentCell.Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on Calculations Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCalculationsView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCalculations()
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        boolEditStatus = True
        GetSelectedCalculation()
        Me.Close()
    End Sub

    Private Sub GetSelectedCalculation()
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(1)
        intNextCalculationNumber = CurrentCell.Value
    End Sub

    Private Sub tsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dgrid.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelectedCalculation()
        Me.Close()
    End Sub

    Private Sub tsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dgrid.Rows.Count <= 0 Then Exit Sub
        If MessageBox.Show("Are you sure you want to delete this calculation?", "Calculation Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            GetSelectedCalculation()
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM " _
                & "SystemCalculationNames WHERE CalculationNo " _
                & "= " & intNextCalculationNumber & "", cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM " _
                & "SystemCalculations WHERE CalcNo " _
                & "= " & intNextCalculationNumber & "", cnn)
            sqlCommand.ExecuteNonQuery()
            LoadCalculations()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on Calculations Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class