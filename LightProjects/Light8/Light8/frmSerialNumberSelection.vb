Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSerialNumberSelection

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Populate the selected numbers to a public array
        arrSelectedSerialNumbers = New ArrayList
        If chkSerials.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            For i = 0 To chkSerials.CheckedItems.Count - 1
                arrSelectedSerialNumbers.Add(chkSerials.CheckedItems(i).ToString)
            Next i
        End If
        Me.Close()
    End Sub

    Private Sub frmSerialNumberSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers " _
                    & "WHERE ItemCode = '" & strPublicItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                chkSerials.Items.Add(objReader(0).ToString())
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Form Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class