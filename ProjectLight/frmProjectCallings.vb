Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectCallings

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim objDeleteAll As New Data.OleDb.OleDbCommand("DELETE FROM ConstructionCallings", cnn)
        objDeleteAll.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.RowCount - 1
            Dim strCalling As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCalling = dGrid.Rows(i).Cells(0).Value.ToString
                Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO ConstructionCallings (Calling) VALUES ('" & strCalling & "')", cnn)
                objCommand.ExecuteNonQuery()
                n = n + 1
            End If
        Next
        If n > 0 Then
            MessageBox.Show("Callings saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Construction callings save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddCalling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCalling.Click
        If Not String.IsNullOrEmpty(txtCalling.Text) Then
            'Check first that there is no similar calling already added
            Dim boolExists As Boolean = False
            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strCalling As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strCalling = dGrid.Rows(i).Cells(0).Value.ToString
                    If UCase(strCalling) = UCase(txtCalling.Text) Then
                        boolExists = True
                        Exit For
                    End If
                End If
            Next
            If boolExists = False Then
                dGrid.Rows.Add(txtCalling.Text)
                txtCalling.Clear()
                txtCalling.Focus()
            End If
        End If
    End Sub

    Private Sub frmConstructionCallings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Calling FROM ConstructionCallings ORDER BY Calling", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0))
            End If
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On construction calling detaild load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class