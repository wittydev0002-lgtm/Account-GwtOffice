Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmRoomSetup
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        If String.IsNullOrEmpty(txtRoomNumber.Text) Then
            MessageBox.Show("Please enter the room number", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRoomNumber.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtBeds.Text) Then
            MessageBox.Show("Please the number of beds", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBeds.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboToilets.Text) Then
            MessageBox.Show("Please specify toilet location", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboToilets.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            'Check that the record number does not exist first
            If gwt_comm.RecordExists("RoomNo", "HotelRooms", txtRoomNumber.Text, "TEXT") = True Then
                MessageBox.Show("The room number already exists. Please re-enter", "Duplicate Record Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRoomNumber.Select()
                Exit Sub
            End If
            strSql = "INSERT INTO HotelRooms (RoomNo, Beds, Description, Toilet) VALUES " _
                & "('" & txtRoomNumber.Text & "', " & txtBeds.Text & ", '" & txtExtraInfo.Text & "', " _
                & "'" & cboToilets.Text & "')"
        Else
            strSql = "UPDATE HotelRooms SET Beds = " & txtBeds.Text & ", " _
                & "Description = '" & txtExtraInfo.Text & "', Toilet = '" & cboToilets.Text & "' " _
                & "WHERE RoomNo = '" & txtRoomNumber.Text & "'"
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If boolEditStatus = False Then
            If MessageBox.Show("Room details have been saved successfully. Do you want to add more?", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.Yes Then
                txtRoomNumber.Clear()
                txtBeds.Text = 0
                txtRoomNumber.Text = Nothing
                txtRoomNumber.Select()
                Exit Sub
            End If
        Else
            MessageBox.Show("Room details have been saved successfully.", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Hotel System Room Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmRoomSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM HotelRooms WHERE RoomNo = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("RoomNo").ToString) Then txtRoomNumber.Text = objReader("RoomNo").ToString
            If Not IsDBNull(objReader("Beds").ToString) Then txtBeds.Text = objReader("Beds").ToString
            If Not IsDBNull(objReader("Description").ToString) Then txtExtraInfo.Text = objReader("Description").ToString
            If Not IsDBNull(objReader("Toilet").ToString) Then cboToilets.Text = objReader("Toilet").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Hotel System Room Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class