Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleHeader

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        strAgentCode = txtAgent.Text
        strCountry = txtOrigin.Text
        strTobaccoType = txtType.Text
        intCropYear = txtCropYear.Text
        strShippingDate = Format(dpDateShipped.Value, "MMddyyyy")
        strLoadNumber = txtLoadNumber.Text
        strVehicleNumber = txtBillLadding.Text
        strCarrierCode = txtCarrierCode.Text
        strShipToLocation = txtSgipToLocation.Text
        strDriverName = txtDriverName.Text
        'Dim strSql As String = Nothing
        'strSql = "INSERT INTO BaleHeaders (Agent, CountryOfOrigin, TobaccoType, CropYear, DateShipped, " _
        '    & "LoadNumber, BillOfLading, CarrierCode, ShipToLocation) VALUES ('" & txtAgent.Text & "', " _
        '    & "'" & txtOrigin.Text & "', '" & txtType.Text & "', '" & txtCropYear.Text & "', " _
        '    & "'" & Format(dpDateShipped.Value, "ddMMyyyy") & "', '" & txtLoadNumber.Text & "', " _
        '    & "'" & txtBillLadding.Text & "', '" & txtCarrierCode.Text & "', '" & txtSgipToLocation.Text & "')"
        'Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        'objCommand.ExecuteNonQuery()

        'MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Dim frm As New frmBaleDetails
        'frm.ShowDialog()
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Save"
        ShowErrorMessage()
    End Sub

    Private Sub frmBaleHeader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        txtCropYear.Text = DatePart(DateInterval.Year, Now)
        'If gwt_comm.CheckTableExistence("BaleHeaders") = False Then
        '    Dim strSql As String = "Create Table BaleHeaders ([Agent][NVARCHAR](3)NOT NULL DEFAULT '', " _
        '        & "[CountryOfOrigin][NVARCHAR](2)NOT NULL DEFAULT '', [TobaccoType][NVARCHAR](2)NOT NULL DEFAULT '', " _
        '        & "[CropYear][NVARCHAR](4)NOT NULL DEFAULT '', [DateShipped][NVARCHAR](8)NOT NULL DEFAULT '', " _
        '        & "[LoadNumber][NVARCHAR](20)NOT NULL DEFAULT '', [BillOfLading][NVARCHAR](8)NOT NULL DEFAULT '', " _
        '        & "[CarrierCode][NVARCHAR](2)NOT NULL DEFAULT '', [ShipToLocation][NVARCHAR](2)NOT NULL DEFAULT'')"
        '    Dim objcommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        '    objcommand.ExecuteNonQuery()
        'End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Form Initialize"
        ShowErrorMessage()
    End Sub

    Private Sub frmBaleHeader_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 670 : Me.Height = 400
    End Sub

End Class