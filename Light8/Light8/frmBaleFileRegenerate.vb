Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleFileRegenerate

    Private Sub frmRegenerateTobaccoBaleFile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckColumnExistence("BaleItems", "DriverName") = False Then
            strSql = "ALTER TABLE BaleItems ADD [DriverName][NVARCHAR](250) NOT NULL DEFAULT ''"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "FileNumber") = False Then
            strSql = "ALTER TABLE BaleItems ADD [FileNumber][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleHeaders", "FileNumber") = False Then
            strSql = "ALTER TABLE BaleHeaders ADD [FileNumber][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "SELECT FileNumber, FileId, " _
            & "UPPER(REPLACE(CONVERT(NVARCHAR, TransmissionDate, 106), ' ', '-')) AS [Date] FROM BaleItems " _
            & "WHERE FileNumber <> 0 GROUP BY FileNumber, FileId, TransmissionDate " _
            & "ORDER BY FileNumber, TransmissionDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmRegenerateTobaccoBaleFile_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 560 : Me.Height = 390
    End Sub

    Private Sub btnRegenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnRegenerate.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        Dim intFileNumber As Integer = GetSelected()
        If intFileNumber <> 0 Then
            GenerateFile(intFileNumber)
        End If
    End Sub

    Private Function GetSelected() As Integer
        Dim intReturn As Integer = 0
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    intReturn = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                End If
            End If
        End If
        Return intReturn
    End Function

    Private Sub GenerateFile(ByVal FileNumber As Integer)
        On Error GoTo RaiseErr

        'Get the file headers
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        arrMyPrintData = New ArrayList

        Dim sfd As New SaveFileDialog
        Dim strFileName As String = Nothing
        sfd.ShowDialog()
        strFileName = sfd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then

            strSql = "SELECT * FROM BaleHeaders WHERE FileNumber = " & FileNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader

            strAgentCode = Nothing
            strCountry = Nothing
            strTobaccoType = Nothing
            intCropYear = DatePart(DateInterval.Year, Now)
            strShippingDate = Nothing
            strLoadNumber = Nothing
            strVehicleNumber = Nothing
            strCarrierCode = Nothing
            strShipToLocation = Nothing

            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("Agent").ToString) Then strAgentCode = objReader("Agent").ToString
                If Not IsDBNull(objReader("CountryOfOrigin").ToString) Then strCountry = objReader("CountryOfOrigin").ToString
                If Not IsDBNull(objReader("TobaccoType").ToString) Then strTobaccoType = objReader("TobaccoType").ToString
                If IsNumeric(objReader("CropYear").ToString) Then intCropYear = CInt(objReader("CropYear").ToString)
                If Not IsDBNull(objReader("DateShipped").ToString) Then strShippingDate = objReader("DateShipped").ToString
                If Not IsDBNull(objReader("LoadNumber").ToString) Then strLoadNumber = objReader("LoadNumber").ToString
                If Not IsDBNull(objReader("BillOfLading").ToString) Then strVehicleNumber = objReader("BillOfLading").ToString
                If Not IsDBNull(objReader("CarrierCode").ToString) Then strCarrierCode = objReader("CarrierCode").ToString
                If Not IsDBNull(objReader("ShipToLocation").ToString) Then strShipToLocation = objReader("ShipToLocation").ToString
            End If
            objReader.Close()

            Dim objFile As New System.IO.StreamWriter(strFileName & ".csv", False)
            objFile.WriteLine(strAgentCode & "," & strCountry & "," & strTobaccoType & "," & _
                              CStr(intCropYear) & "," & strShippingDate & "," & strLoadNumber & "," & _
                              strVehicleNumber & "," & strCarrierCode & "," & strShipToLocation)

            strSql = "SELECT * FROM BaleItems WHERE FileNumber = " & FileNumber & " ORDER BY SendBatchNo, Barcode"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader

            Dim intNumberOfBalesInFile As Integer = 0

            While objReader.Read

                Dim strBarcode As String = Nothing
                Dim strControlGrade As String = Nothing
                Dim strCustomeGrade As String = Nothing
                Dim strTare As String = "0"
                Dim strWeight As String = "0"
                Dim strPrice As String = "0.00"
                Dim strGrower As String = Nothing
                Dim strMoisture As String = "0"
                Dim strLotNumber As String = Nothing
                Dim strBatch As String = Nothing

                If Not IsDBNull(objReader("Barcode").ToString) Then strBarcode = objReader("Barcode").ToString
                If Not IsDBNull(objReader("ControlGrade").ToString) Then strControlGrade = objReader("ControlGrade").ToString
                If Not IsDBNull(objReader("CustomerGrade").ToString) Then strCustomeGrade = objReader("CustomerGrade").ToString
                If IsNumeric(objReader("Tare").ToString) Then strTare = CInt(objReader("Tare").ToString)
                If IsNumeric(objReader("Weight").ToString) Then strWeight = objReader("Weight").ToString
                If IsNumeric(objReader("Price").ToString) Then strPrice = objReader("Price").ToString
                If Not IsDBNull(objReader("Grower").ToString) Then strGrower = objReader("Grower").ToString
                If IsNumeric(objReader("Moisture").ToString) Then strMoisture = objReader("Moisture").ToString
                If Not IsDBNull(objReader("LotNumber").ToString) Then strLotNumber = objReader("LotNumber").ToString
                If Not IsDBNull(objReader("SendBatchNo").ToString) Then strBatch = objReader("SendBatchNo").ToString

                Dim PrintPrice As String = "0.00"
                If IsNumeric(strPrice) Then PrintPrice = Format(CDbl(strPrice), "#,##0.00")

                Dim Tare As String = "0.00"
                If IsNumeric(strTare) Then Tare = Format(CDbl(strTare), "#,##0.00")

                Dim dWeight As String = "0.00"
                If IsNumeric(strWeight) Then dWeight = Format(CDbl(strWeight), "#,##0.00")

                Dim Moisture As String = "0.00"
                If IsNumeric(strMoisture) Then Moisture = Format(CDbl(strMoisture), "#,##0.00")

                arrMyPrintData.Add(CStr(intNumberOfBalesInFile + 1) & ";" & strBatch & ";" & strBarcode & ";" & strControlGrade & ";" &
                    strCustomeGrade & ";" & Tare & ";" & dWeight & ";" & PrintPrice & ";" &
                    strGrower & ";" & Moisture & ";" & strLotNumber)


                objFile.WriteLine(strBarcode & "," & strControlGrade & "," & strCustomeGrade & "," &
                        strTare & "," & strWeight & "," & strPrice & "," & strGrower & "," &
                        strMoisture & "," & strLotNumber)

                intNumberOfBalesInFile = intNumberOfBalesInFile + 1

            End While
            objReader.Close()

            objFile.Close()

            MessageBox.Show("The file has been regenerated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            PrintDeliveryNote(intNumberOfBalesInFile)

        End If

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On file regenerate"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        Dim intFileNumber As Integer = GetSelected()
        If intFileNumber <> 0 Then
            GenerateFile(intFileNumber)
        End If
    End Sub

End Class