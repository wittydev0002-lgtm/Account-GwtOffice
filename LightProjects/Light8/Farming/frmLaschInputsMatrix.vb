Imports System.Transactions

Public Class frmLaschInputsMatrix

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        boolAbort = False
        'Reload the details to the grid
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Crop FROM LaschApprovedCrops ORDER BY Crop", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboCrop.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCrop.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On crop information load"
        ShowErrorMessage()
    End Sub

    Private Sub cboFarmType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFarmType.SelectedIndexChanged
        LoadRates(cboFarmType.Text, cboCrop.Text)
    End Sub

    Private Sub cboCrop_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCrop.SelectedIndexChanged
        LoadRates(cboFarmType.Text, cboCrop.Text)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboFarmType.Text) Then
            MessageBox.Show("Please select the farming area", "Invalid Farm Area", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboFarmType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCrop.Text) Then
            MessageBox.Show("Please select the crop from the given list", "Invalid Crop Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCrop.Focus()
            Exit Sub
        End If

        'First delete any records existing similar to this record

        Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}
        Using InputTransactions = New TransactionScope(TransactionScopeOption.Required, [option])

            Dim objCommand As Data.OleDb.OleDbCommand
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LaschCropOutputMatrix WHERE " _
                & "FarmType = '" & cboFarmType.Text & "' AND Crop = '" & cboCrop.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            For i As Integer = 0 To dGrid.Rows.Count - 1

                Dim dblHecterage As Double = 0
                Dim dblProductionCost As Double = 0
                Dim dblPremium As Double = 0
                Dim intOrdinalNo As Integer = 0

                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(0).Value.ToString) Then
                        dblHecterage = CDbl(dGrid.Rows(i).Cells(0).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        dblProductionCost = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        dblPremium = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                    End If
                End If

                intOrdinalNo = i + 1

                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCropOutputMatrix " _
                    & "([Hectarage], [ProductionCost], [Insurance], [OrdinalNo], [FarmType], [Crop]) " _
                    & "VALUES (" & dblHecterage & ", " & dblProductionCost & ", " & dblPremium & ", " _
                    & "" & intOrdinalNo & ", '" & cboFarmType.Text & "', '" & cboCrop.Text & "')", cnn)
                objCommand.ExecuteNonQuery()

            Next

            InputTransactions.Complete()
        End Using
        If MessageBox.Show("Crop Matrix Data Saved Successfully. Do you want to add more?", "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dGrid.Rows.Clear()
            dGrid.Rows.Add(6)
            cboCrop.Text = ""
            cboFarmType.Text = ""
            cboFarmType.Focus()
        Else
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lasch crop matrix setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnManageCrops_Click(sender As System.Object, e As System.EventArgs) Handles btnManageCrops.Click
        Dim f As New frmLaschCropMatrixSetup
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadRates(FarmType As String, Crop As String)
        On Error GoTo RaiseErr
        'First initialize grid
        dGrid.Rows.Clear()
        dGrid.Rows.Add(6)
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [Hectarage], [ProductionCost], [Insurance] " _
            & "FROM LaschCropOutputMatrix WHERE Crop = '" & Crop & "' AND FarmType = '" & FarmType & "' ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then dGrid.Rows(i).Cells(0).Value = Format(CDbl(objReader(0).ToString), "##0.00") Else dGrid.Rows(i).Cells(0).Value = "0.00"
            If IsNumeric(objReader(1).ToString) Then dGrid.Rows(i).Cells(1).Value = Format(CDbl(objReader(1).ToString), "##0.00") Else dGrid.Rows(i).Cells(1).Value = "0.00"
            If IsNumeric(objReader(2).ToString) Then dGrid.Rows(i).Cells(2).Value = Format(CDbl(objReader(2).ToString), "##0.00") Else dGrid.Rows(i).Cells(2).Value = "0.00"
            i = i + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lasch crop matrix setup"
        ShowErrorMessage()
    End Sub

End Class
