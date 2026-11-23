Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmHotelierMain

    Dim strMonthStartDate As String = Nothing
    Dim strMonthEndDate As String = Nothing

    Private Sub frmHotelierMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboMonth.Text = UCase(MonthName(DatePart(DateInterval.Month, Now), True))
        cboYear.Text = DatePart(DateInterval.Year, Now)

        strMonthStartDate = gwt_comm.FirstDateofMonth(DatePart(DateInterval.Month, Now), DatePart(DateInterval.Year, Now))
        strMonthEndDate = gwt_comm.LastDateofMonth(DatePart(DateInterval.Month, Now), DatePart(DateInterval.Year, Now))

        'Load the active guest information
        LoadActiveGuests()

        'Load the room status
        LoadRoomStatus()

        'Load the rooms for setup and maintainance
        LoadRooms()
    End Sub


    Private Sub LoadActiveGuests()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT GuestName AS [Guest], RoomNo AS [Room], " _
            & "UPPER(REPLACE(CONVERT(NVARCHAR, DateFrom, 106), ' ', '-')) AS [From], " _
            & "UPPER(REPLACE(CONVERT(NVARCHAR, DateTo, 106), ' ', '-')) AS [To], " _
            & "TourClassification AS [Type] FROM HotelMaster WHERE CheckStatus = 'IN'"
        Dim objCommant As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommant.ExecuteReader
        With dGrid
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), "")
            End While
            objReader.Close()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On hotel active guests listing load"
        gwt_comm.ShowErrorMessage()
    End Sub
    Private Sub dGridRooms_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridRooms.CellContentClick

    End Sub

    Private Sub ClearDates(ByVal ctrlParent As Control)
        Dim ctrl As Control
        For Each ctrl In ctrlParent.Controls
            If TypeOf ctrl Is ComponentFactory.Krypton.Toolkit.KryptonLabel Then
                ctrl.Text = "0"
            End If
            If TypeOf ctrl Is ComponentFactory.Krypton.Toolkit.KryptonButton Then
                ctrl.BackColor = Color.White
                ctrl.ForeColor = Color.Black
            End If
            If ctrl.HasChildren Then
                ClearDates(ctrl)
            End If
        Next
    End Sub

    Private Sub btnNewBooking_Click(sender As Object, e As EventArgs) Handles btnNewBooking.Click
        'ClearDates(pnlDate)
        boolAbort = False
        boolEditStatus = False
        Dim frm As New frmBooking
        frm.ShowDialog()
    End Sub

    Private Sub btnNewInvoice_Click(sender As Object, e As EventArgs) Handles btnNewInvoice.Click
        boolEditStatus = False
        Dim frm As New frmRoomSetup
        frm.ShowDialog()
        LoadRooms()
    End Sub

    Private Sub LoadRooms()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT RoomNo, Beds, Description, Toilet FROM HotelRooms ORDER BY RoomNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridListedRooms
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), "")
            End While
            objReader.Close()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On hotel rooms maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefreshInvoice_Click(sender As Object, e As EventArgs) Handles btnRefreshInvoice.Click
        LoadRooms()
    End Sub

    Private Sub btnEditInvoice_Click(sender As Object, e As EventArgs) Handles btnEditInvoice.Click
        If dGridListedRooms.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelectedRoom()
        If String.IsNullOrEmpty(strSelectedAccount) Then
            MessageBox.Show("No valid room number was selected", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim frm As New frmRoomSetup
        frm.ShowDialog()
        LoadRooms()
    End Sub

    Private Sub GetSelectedRoom()
        strSelectedAccount = Nothing
        If Not Object.Equals(dGridListedRooms.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridListedRooms.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedAccount = dGridListedRooms.CurrentRow.Cells(0).Value.ToString
            End If
        End If
    End Sub

    Private Sub dGridListedRooms_DoubleClick(sender As Object, e As EventArgs) Handles dGridListedRooms.DoubleClick
        If dGridListedRooms.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelectedRoom()
        If String.IsNullOrEmpty(strSelectedAccount) Then
            MessageBox.Show("No valid room number was selected", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim frm As New frmRoomSetup
        frm.ShowDialog()
        LoadRooms()
    End Sub

    Private Sub btnDeleteInvoice_Click(sender As Object, e As EventArgs) Handles btnDeleteInvoice.Click
        On Error GoTo RaiseErr
        strSelectedAccount = Nothing
        GetSelectedRoom()
        If MessageBox.Show("Are you sure you want to delete room no " & strSelectedAccount & "?",
                           "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM HotelRoomExtras " _
                           & "WHERE RoomNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM HotelRooms " _
                           & "WHERE RoomNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On hotel rooms maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadRoomStatus()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT HotelRooms.RoomNo AS [Room], " _
            & "UPPER(REPLACE(CONVERT(NVARCHAR, HotelMaster.DateFrom, 106), ' ', '-')) AS [From], " _
            & "UPPER(REPLACE(CONVERT(NVARCHAR, HotelMaster.DateTo, 106), ' ', '-')) AS [To], " _
            & "HotelMaster.GuestName AS [Guest] FROM HotelRooms LEFT OUTER JOIN HotelMaster ON " _
            & "HotelRooms.RoomNo = HotelMaster.RoomNo WHERE HotelRooms.Status = 'VACANT'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        With dGridRooms
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), "", objReader(1), objReader(2), objReader(3))
            End While
            objReader.Close()

            For p As Integer = 0 To .Rows.Count - 1
                Dim strName As String = Nothing
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        strName = .Rows(p).Cells(4).Value.ToString
                    End If
                End If
                If String.IsNullOrEmpty(strName) Then
                    .Rows(p).Cells(1).Value = "VACANT"
                Else
                    .Rows(p).Cells(1).Value = "OCCUPIED"
                End If
            Next
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On hotel room status data load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
