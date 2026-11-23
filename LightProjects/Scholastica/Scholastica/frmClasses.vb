Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmClasses

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        AddClass()
    End Sub

    Private Sub AddClass()
        If CheckClassNameExists(txtClasses.Text) = True Then
            MessageBox.Show("This class has already been added.", "Duplicate Record Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClasses.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtClasses.Text) Then
            MessageBox.Show("Please enter the class name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClasses.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboCostCenter.Text) Then
            MessageBox.Show("Please enter the class costing center", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostCenter.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboClassGroups.Text) Then
            MessageBox.Show("Please enter the class group name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClassGroups.Focus()
            Exit Sub
        End If

        dGrid.Rows.Add(txtClasses.Text, cboCostCenter.Text, txtShortName.Text, cboClassGroups.Text)
        txtClasses.Clear()
        txtShortName.Clear()
        txtClasses.Focus()

        Exit Sub
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_Classes", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strSubject As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strSubject = dGrid.Rows(i).Cells(0).Value.ToString
                End If
            End If
            Dim strCostCenter As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    strCostCenter = dGrid.Rows(i).Cells(1).Value.ToString
                End If
            End If
            Dim strShortName As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    strShortName = dGrid.Rows(i).Cells(2).Value.ToString
                End If
            End If
            Dim strGroupName As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    strGroupName = dGrid.Rows(i).Cells(3).Value.ToString
                End If
            End If
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_Classes(ClassName, CostCenter, ShortName, GroupName) " _
                & "VALUES ('" & strSubject & "', '" & strCostCenter & "', '" & strShortName & "', '" & strGroupName & "')", cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Classes Management"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ClassName, CostCenter, ShortName, GroupName FROM SC_Classes ORDER BY ClassName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0).ToString, objReader(1).ToString, objReader(2).ToString, objReader(3).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Classes Management"
        ShowErrorMessage()
    End Sub

    Private Sub frmClasses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RecreateDatagridView()
        LoadData()
        LoadCostCenters()
        LoadClassGroups()
    End Sub

    Private Sub txtSubjects_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClasses.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AddClass()
        End If
    End Sub

    Private Function CheckClassNameExists(ClassName As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName FROM SC_Classes WHERE ClassName = '" & ClassName & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On duplicate record check process"
        ShowErrorMessage()
    End Function

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SystemCostCenters.CostCenterName " _
            & "FROM SystemCostCenters ORDER BY SystemCostCenters.CostCenterName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCostCenter.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCostCenter.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On classes setup"
        ShowErrorMessage()
    End Sub

    Private Sub RecreateDatagridView()
        dGrid.Columns.Clear()

        Dim cmb As New KryptonDataGridViewComboBoxColumn
        With cmb
            .HeaderText = "Cost Center"
            .Name = "cmb"
            .MaxDropDownItems = 4
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .MinimumWidth = 160
        End With

        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CostCenterName FROM SystemCostCenters ORDER BY CostCenterName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cmb.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim txt As New KryptonDataGridViewTextBoxColumn
        With txt
            .HeaderText = "Description"
            .Name = "txt"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With

        Dim txShort As New KryptonDataGridViewTextBoxColumn
        With txt
            .HeaderText = "Short Name"
            .Name = "txShort"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With

        Dim cmbGroups As New KryptonDataGridViewComboBoxColumn
        With cmbGroups
            .HeaderText = "Group Name"
            .Name = "cmbGroup"
            .MaxDropDownItems = 4
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .MinimumWidth = 160
        End With

        objCommand = New Data.OleDb.OleDbCommand("SELECT GroupName FROM SC_ClassGroups ORDER BY GroupName", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cmbGroups.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        dGrid.Columns.Add(txt)
        dGrid.Columns.Add(cmb)
        dGrid.Columns.Add(txShort)
        dGrid.Columns.Add(cmbGroups)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On classes setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnClassGroups_Click(sender As System.Object, e As System.EventArgs) Handles btnClassGroups.Click
        Dim frm As New frmClassGroups
        frm.ShowDialog()
        RecreateDatagridView()
        LoadData()
        LoadCostCenters()
        LoadClassGroups()
    End Sub

    Private Sub LoadClassGroups()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GroupName FROM SC_ClassGroups ORDER BY GroupName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboClassGroups.Items.clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    cboClassGroups.Items.add(objReader(0).ToString)
                End If
            End If
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On class groups load"
        ShowErrorMessage()
    End Sub

End Class
