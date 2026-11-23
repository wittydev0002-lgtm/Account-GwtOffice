Imports System.IO
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms


Public Class frmReportWriter

    Dim intColumnOneAlign As Integer = 0
    Dim intColumnTwoAlign As Integer = 0
    Dim intColumnThreeAlign As Integer = 0
    Dim intColumnFourAlign As Integer = 0
    Dim intColumnFiveAlign As Integer = 0
    Dim intColumnSixAlign As Integer = 0
    Dim intGroupingStatus As Integer = 0
    Dim strFunction As String = Nothing
    Dim strTypeOne As String = Nothing
    Dim strCodeOne As String = Nothing
    Dim strTypeTwo As String = Nothing
    Dim strCodeTwo As String = Nothing
    Dim strColumn As String = Nothing
    Dim strColCaptionOne As String = Nothing
    Dim strColCaptionTwo As String = Nothing
    Dim strColCaptionThree As String = Nothing
    Dim strColCaptionFour As String = Nothing
    Dim strColCaptionFive As String = Nothing
    Dim strColCaptionSix As String = Nothing
    Dim strSuppressZero As String = "NO"
    Dim strIncludeManuals As String = "NO"

    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim boolContinue As Boolean = True

        If txtReportName.Text = "" Or Mid(txtReportName.Text, 1, 1) = " " Then
            MessageBox.Show("Either the report name begins with spaces or is empty.", "Invalid Report Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReportName.Focus()
            Exit Sub
        End If

        If RadioButton1.Checked Then intGroupingStatus = 0
        If RadioButton2.Checked Then intGroupingStatus = 1
        If RadioButton3.Checked Then intGroupingStatus = 2

        If chkSuppressZero.Checked = True Then strSuppressZero = "YES" Else strSuppressZero = "NO"
        If chkIncludeManualPay.Checked = True Then strIncludeManuals = "YES" Else strIncludeManuals = "NO"

        strColCaptionOne = txtHeaderOne.Text
        strColCaptionTwo = txtHeaderTwo.Text
        strColCaptionThree = txtHeaderThree.Text
        strColCaptionFour = txtHeaderFour.Text
        strColCaptionFive = txtHeaderFive.Text
        strColCaptionSix = txtHeaderSix.Text

        If Not IsNumeric(txtColWidth1.Text) Then txtColWidth1.Text = "100"
        If Not IsNumeric(txtColWidth2.Text) Then txtColWidth2.Text = "100"
        If Not IsNumeric(txtColWidth3.Text) Then txtColWidth3.Text = "100"
        If Not IsNumeric(txtColWidth4.Text) Then txtColWidth4.Text = "100"
        If Not IsNumeric(txtColWidth5.Text) Then txtColWidth5.Text = "100"
        If Not IsNumeric(txtColWidth6.Text) Then txtColWidth6.Text = "100"

        If String.IsNullOrEmpty(cboVisible1.Text) Then cboVisible1.SelectedIndex = 0
        If String.IsNullOrEmpty(cboVisible2.Text) Then cboVisible2.SelectedIndex = 0
        If String.IsNullOrEmpty(cboVisible3.Text) Then cboVisible3.SelectedIndex = 0
        If String.IsNullOrEmpty(cboVisible4.Text) Then cboVisible4.SelectedIndex = 0
        If String.IsNullOrEmpty(cboVisible5.Text) Then cboVisible5.SelectedIndex = 0
        If String.IsNullOrEmpty(cboVisible6.Text) Then cboVisible6.SelectedIndex = 0

        Select Case UCase(cboAlign1.Text)
            Case Is = "LEFT"
                intColumnOneAlign = 0
            Case Is = "CENTER"
                intColumnOneAlign = 1
            Case Is = "RIGHT"
                intColumnOneAlign = 2
            Case Else
                intColumnOneAlign = 3
        End Select

        Select Case UCase(cboAlign2.Text)
            Case Is = "LEFT"
                intColumnTwoAlign = 0
            Case Is = "CENTER"
                intColumnTwoAlign = 1
            Case Is = "RIGHT"
                intColumnTwoAlign = 2
            Case Else
                intColumnTwoAlign = 3
        End Select

        Select Case UCase(cboAlign3.Text)
            Case Is = "LEFT"
                intColumnThreeAlign = 0
            Case Is = "CENTER"
                intColumnThreeAlign = 1
            Case Is = "RIGHT"
                intColumnThreeAlign = 2
            Case Else
                intColumnThreeAlign = 3
        End Select

        Select Case UCase(cboAlign4.Text)
            Case Is = "LEFT"
                intColumnFourAlign = 0
            Case Is = "CENTER"
                intColumnFourAlign = 1
            Case Is = "RIGHT"
                intColumnFourAlign = 2
            Case Else
                intColumnFourAlign = 3
        End Select

        '0820665196 Abinel

        Select Case UCase(cboAlign5.Text)
            Case Is = "LEFT"
                intColumnFiveAlign = 0
            Case Is = "CENTER"
                intColumnFiveAlign = 1
            Case Is = "RIGHT"
                intColumnFiveAlign = 2
            Case Else
                intColumnFiveAlign = 3
        End Select

        Select Case UCase(cboAlign6.Text)
            Case Is = "LEFT"
                intColumnSixAlign = 0
            Case Is = "CENTER"
                intColumnSixAlign = 1
            Case Is = "RIGHT"
                intColumnSixAlign = 2
            Case Else
                intColumnSixAlign = 3
        End Select

        'Save the report calculations as well
        If boolEditStatus = False Then InsertNewReport() Else UpdateReport()
        If boolAbort = False Then
            MessageBox.Show("Report has been successfully saved", "Report Creation Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Column Report Save Procedure"
        boolAbort = True
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtColWidth1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColWidth1.KeyPress
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmReportWriter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = False Then
            Dim i As Integer
            Dim CurrentCell As DataGridViewCell
            dgrid.Rows.Clear()
            dgrid.Rows.Add(100)
            For i = 0 To 99
                CurrentCell = dgrid.Rows(i).Cells(0)
                CurrentCell.Value = Format(i + 1, "000")
            Next
        Else
            LoadReport()
        End If
    End Sub

    Private Sub LoadReport()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim strFunction As String, strTypeOne As String, strCodeOne As String
        Dim strTypeTwo As String, strCodeTwo As String, strColumn As String
        Dim currentCell As DataGridViewCell

        objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM SystemColumnReportHeaders WHERE ReportNo = " & intSelectedReport & "", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ReportName").ToString) Then txtReportName.Text = objReader("ReportName").ToString
            If Not IsDBNull(objReader("ReportHeader").ToString) Then txtHeaderLine1.Text = objReader("ReportHeader").ToString
            If Not IsDBNull(objReader("ColumnOneCaption").ToString) Then txtHeaderOne.Text = objReader("ColumnOneCaption").ToString
            If Not IsDBNull(objReader("ColumnTwoCaption").ToString) Then txtHeaderTwo.Text = objReader("ColumnTwoCaption").ToString
            If Not IsDBNull(objReader("ColumnThreeCaption").ToString) Then txtHeaderThree.Text = objReader("ColumnThreeCaption").ToString
            If Not IsDBNull(objReader("ColumnFourCaption").ToString) Then txtHeaderFour.Text = objReader("ColumnFourCaption").ToString
            If Not IsDBNull(objReader("ColumnFiveCaption").ToString) Then txtHeaderFive.Text = objReader("ColumnFiveCaption").ToString
            If Not IsDBNull(objReader("ColumnSixCaption").ToString) Then txtHeaderSix.Text = objReader("ColumnSixCaption").ToString
            If Not IsDBNull(objReader("ReportFooter").ToString) Then txtFooter.Text = objReader("ReportFooter").ToString
            If IsNumeric(objReader("ColumnOneWidth").ToString) Then txtColWidth1.Text = objReader("ColumnOneWidth").ToString
            If IsNumeric(objReader("ColumnTwoWidth").ToString) Then txtColWidth2.Text = objReader("ColumnTwoWidth").ToString
            If IsNumeric(objReader("ColumnThreeWidth").ToString) Then txtColWidth3.Text = objReader("ColumnThreeWidth").ToString
            If IsNumeric(objReader("ColumnFourWidth").ToString) Then txtColWidth4.Text = objReader("ColumnFourWidth").ToString
            If IsNumeric(objReader("ColumnFiveWidth").ToString) Then txtColWidth5.Text = objReader("ColumnFiveWidth").ToString
            If IsNumeric(objReader("ColumnSixWidth").ToString) Then txtColWidth6.Text = objReader("ColumnSixWidth").ToString

            If Not IsDBNull(objReader("ColumnOneVisible").ToString) Then cboVisible1.SelectedItem = UCase(objReader("ColumnOneVisible").ToString)
            If Not IsDBNull(objReader("ColumnTwoVisible").ToString) Then cboVisible2.SelectedItem = UCase(objReader("ColumnTwoVisible").ToString)
            If Not IsDBNull(objReader("ColumnThreeVisible").ToString) Then cboVisible3.SelectedItem = UCase(objReader("ColumnThreeVisible").ToString)
            If Not IsDBNull(objReader("ColumnFourVisible").ToString) Then cboVisible4.SelectedItem = UCase(objReader("ColumnFourVisible").ToString)
            If Not IsDBNull(objReader("ColumnFiveVisible").ToString) Then cboVisible5.SelectedItem = UCase(objReader("ColumnFiveVisible").ToString)
            If Not IsDBNull(objReader("ColumnSixVisible").ToString) Then cboVisible6.SelectedItem = UCase(objReader("ColumnSixVisible").ToString)

            If IsNumeric(objReader("ColumnOneAlign").ToString) Then
                Select Case CInt(objReader("ColumnOneAlign").ToString)
                    Case Is = 0
                        cboAlign1.SelectedIndex = 0
                    Case Is = 1
                        cboAlign1.SelectedIndex = 1
                    Case Is = 2
                        cboAlign1.SelectedIndex = 2
                    Case Else
                        cboAlign1.SelectedIndex = 0
                End Select
            Else
                cboAlign1.SelectedIndex = 0
            End If

            If IsNumeric(objReader("ColumnTwoAlign").ToString) Then
                Select Case CInt(objReader("ColumnTwoAlign").ToString)
                    Case Is = 0
                        cboAlign2.SelectedIndex = 0
                    Case Is = 1
                        cboAlign2.SelectedIndex = 1
                    Case Is = 2
                        cboAlign2.SelectedIndex = 2
                    Case Else
                        cboAlign2.SelectedIndex = 0
                End Select
            Else
                cboAlign2.SelectedIndex = 0
            End If

            If IsNumeric(objReader("ColumnThreeAlign").ToString) Then
                Select Case CInt(objReader("ColumnThreeAlign").ToString)
                    Case Is = 0
                        cboAlign3.SelectedIndex = 0
                    Case Is = 1
                        cboAlign3.SelectedIndex = 1
                    Case Is = 2
                        cboAlign3.SelectedIndex = 2
                    Case Else
                        cboAlign3.SelectedIndex = 0
                End Select
            Else
                cboAlign3.SelectedIndex = 0
            End If

            If IsNumeric(objReader("ColumnFourAlign").ToString) Then
                Select Case CInt(objReader("ColumnFourAlign").ToString)
                    Case Is = 0
                        cboAlign4.SelectedIndex = 0
                    Case Is = 1
                        cboAlign4.SelectedIndex = 1
                    Case Is = 2
                        cboAlign4.SelectedIndex = 2
                    Case Else
                        cboAlign4.SelectedIndex = 0
                End Select
            Else
                cboAlign4.SelectedIndex = 0
            End If

            If IsNumeric(objReader("ColumnFiveAlign").ToString) Then
                Select Case CInt(objReader("ColumnFiveAlign").ToString)
                    Case Is = 0
                        cboAlign5.SelectedIndex = 0
                    Case Is = 1
                        cboAlign5.SelectedIndex = 1
                    Case Is = 2
                        cboAlign5.SelectedIndex = 2
                    Case Else
                        cboAlign5.SelectedIndex = 0
                End Select
            Else
                cboAlign5.SelectedIndex = 0
            End If

            If IsNumeric(objReader("ColumnSixAlign").ToString) Then
                Select Case CInt(objReader("ColumnSixAlign").ToString)
                    Case Is = 0
                        cboAlign6.SelectedIndex = 0
                    Case Is = 1
                        cboAlign6.SelectedIndex = 1
                    Case Is = 2
                        cboAlign6.SelectedIndex = 2
                    Case Else
                        cboAlign6.SelectedIndex = 0
                End Select
            Else
                cboAlign6.SelectedIndex = 0
            End If

            If Not IsDBNull(objReader("Grouping").ToString) Then
                If objReader("Grouping").ToString = 0 Then RadioButton1.Checked = True Else RadioButton1.Checked = False
                If objReader("Grouping").ToString = 1 Then RadioButton2.Checked = True Else RadioButton2.Checked = False
                If objReader("Grouping").ToString = 2 Then RadioButton3.Checked = True Else RadioButton3.Checked = False
            End If
            If Not IsDBNull(objReader("SuppressZero").ToString) Then
                If objReader("SuppressZero").ToString = "YES" Then chkSuppressZero.Checked = True Else chkSuppressZero.Checked = False
            End If
            If Not IsDBNull(objReader("IncludeManuals").ToString) Then
                If objReader("IncludeManuals").ToString = "YES" Then chkIncludeManualPay.Checked = True Else chkIncludeManualPay.Checked = False
            End If

        End If

        'Load the calculations
        objCommand = New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "IndNo, IndVal, OpCode, OP1A, OP1N, OP2A, OP2N, OP3A, " _
            & "OP3N FROM SystemReportColumnCalculations WHERE " _
            & "ReportNo = " & intSelectedReport & " ORDER BY OrdinalNo", cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read
            dgrid.Rows.Add()
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(6).Value = objReader(6).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(7).Value = objReader(7).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(8).Value = objReader(8).ToString
            dgrid.Rows(dgrid.Rows.Count - 1).Cells(9).Value = objReader(9).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Report Details and Calculations Load"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub txtHeaderFive_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeaderFive.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtHeaderFour_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeaderFour.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtHeaderOne_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeaderOne.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtHeaderSix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeaderSix.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtHeaderThree_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeaderThree.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtHeaderTwo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeaderTwo.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtReportName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReportName.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtColWidth2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColWidth2.KeyPress
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtColWidth3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColWidth3.KeyPress
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtColWidth4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColWidth4.KeyPress
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtColWidth5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColWidth5.KeyPress
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtColWidth6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColWidth6.KeyPress
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub InsertNewReport()
        On Error GoTo RaiseErr
        'Get the next report number
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ReportNo FROM SystemColumnReportHeaders ORDER BY ReportNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Initialise the value of the selected report to 1
        intSelectedReport = 1
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then intSelectedReport = CInt(objReader(0).ToString) + 1
            End If
        End If
        objReader.Close()
        Dim strSql As String = "INSERT INTO SystemColumnReportHeaders " _
            & "([ReportName],[ReportHeader],[ReportFooter],[ColumnOneCaption] " _
            & ",[ColumnTwoCaption],[ColumnThreeCaption],[ColumnFourCaption] " _
            & ",[ColumnFiveCaption],[ColumnSixCaption],[ColumnOneWidth] " _
            & ",[ColumnTwoWidth],[ColumnThreeWidth],[ColumnFourWidth] " _
            & ",[ColumnFiveWidth],[ColumnSixWidth],[ColumnOneAlign] " _
            & ",[ColumnTwoAlign],[ColumnThreeAlign],[ColumnFourAlign] " _
            & ",[ColumnFiveAlign],[ColumnSixAlign],[ReportNo],[Grouping]," _
            & "[SuppressZero],[IncludeManuals], [ColumnOneVisible], " _
            & "[ColumnTwoVisible], [ColumnThreeVisible], [ColumnFourVisible], " _
            & "[ColumnFiveVisible], [ColumnSixVisible]) VALUES " _
            & "('" & txtReportName.Text & "', '" & txtHeaderLine1.Text & "', " _
            & "'" & txtFooter.Text & "', '" & txtHeaderOne.Text & "', " _
            & "'" & txtHeaderTwo.Text & "', '" & txtHeaderThree.Text & "', " _
            & "'" & txtHeaderFour.Text & "', '" & txtHeaderFive.Text & "', " _
            & "'" & txtHeaderSix.Text & "', " & CInt(txtColWidth1.Text) & ", " _
            & "" & CInt(txtColWidth2.Text) & ", " & CInt(txtColWidth3.Text) & ", " _
            & "" & CInt(txtColWidth4.Text) & ", " & CInt(txtColWidth5.Text) & ", " _
            & "" & CInt(txtColWidth6.Text) & ", " & intColumnOneAlign & ", " _
            & "" & intColumnTwoAlign & ", " & intColumnThreeAlign & ", " & intColumnFourAlign & ", " _
            & "" & intColumnFiveAlign & ", " & intColumnSixAlign & ", " & intSelectedReport & "," _
            & "" & intGroupingStatus & ", '" & strSuppressZero & "', '" & strIncludeManuals & "', " _
            & "'" & cboVisible1.Text & "', '" & cboVisible2.Text & "', '" & cboVisible3.Text & "', " _
            & "'" & cboVisible4.Text & "', '" & cboVisible5.Text & "', '" & cboVisible6.Text & "')"

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Save the report calculations as well
        Dim i As Integer = 0
        For i = 0 To dgrid.Rows.Count - 1
            Dim intIndNo As Integer = 0
            Dim strIndVal As String = Nothing
            Dim strOpCode As String = Nothing
            Dim strOp1a As String = Nothing
            Dim intOp1n As Integer = 0
            Dim strOp2a As String = Nothing
            Dim intOp2n As Integer = 0
            Dim strOp3a As String = Nothing
            Dim intOp3n As Integer = 0
            Dim intOrdinalNumber As Integer = 0

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(0).Value.ToString) Then intOrdinalNumber = CInt(dgrid.Rows(i).Cells(0).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(1).Value.ToString) Then intIndNo = CInt(dgrid.Rows(i).Cells(1).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(2).Value), "")) Then
                strIndVal = dgrid.Rows(i).Cells(2).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(3).Value), "")) Then
                strOpCode = dgrid.Rows(i).Cells(3).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(4).Value), "")) Then
                strOp1a = dgrid.Rows(i).Cells(4).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(5).Value.ToString) Then intOp1n = CInt(dgrid.Rows(i).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(6).Value), "")) Then
                strOp2a = dgrid.Rows(i).Cells(6).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(7).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(7).Value.ToString) Then intOp2n = CInt(dgrid.Rows(i).Cells(7).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(8).Value), "")) Then
                strOp3a = dgrid.Rows(i).Cells(8).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(9).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(9).Value.ToString) Then intOp3n = CInt(dgrid.Rows(i).Cells(9).Value.ToString)
            End If

            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemReportColumnCalculations (" _
                & "IndNo, IndVal, OpCode, OP1A, OP1N, OP2A, OP2N, OP3A, OP3N, OrdinalNo, ReportNo) VALUES " _
                & "(" & intIndNo & ", '" & strIndVal & "', " _
                & "'" & Trim(strOpCode) & "', '" & Trim(strOp1a) & "', " _
                & "" & intOp1n & ", '" & Trim(strOp2a) & "', " & intOp2n & ", " _
                & "'" & Trim(strOp3a) & "', " & intOp3n & ", " & intOrdinalNumber & ", " & intSelectedReport & ")", cnn)
            objCommand.ExecuteNonQuery()
        Next

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " On New Report Creation"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub UpdateReport()
        On Error GoTo RaiseErr
        'Update the report headers
        Dim strSql As String = "UPDATE SystemColumnReportHeaders SET " _
            & "[ReportName] = '" & txtReportName.Text & "', " _
            & "[ReportHeader] = '" & txtHeaderLine1.Text & "', " _
            & "[ReportFooter] = '" & txtFooter.Text & "', " _
            & "[ColumnOneCaption] = '" & txtHeaderOne.Text & "', " _
            & "[ColumnTwoCaption] = '" & txtHeaderTwo.Text & "', " _
            & "[ColumnThreeCaption] = '" & txtHeaderThree.Text & "', " _
            & "[ColumnFourCaption] = '" & txtHeaderFour.Text & "', " _
            & "[ColumnFiveCaption] = '" & txtHeaderFive.Text & "', " _
            & "[ColumnSixCaption] = '" & txtHeaderSix.Text & "', " _
            & "[ColumnOneWidth] = " & CInt(txtColWidth1.Text) & ", " _
            & "[ColumnTwoWidth] = " & CInt(txtColWidth2.Text) & ", " _
            & "[ColumnThreeWidth] = " & CInt(txtColWidth3.Text) & ", " _
            & "[ColumnFourWidth] = " & CInt(txtColWidth4.Text) & ", " _
            & "[ColumnFiveWidth] = " & CInt(txtColWidth5.Text) & ", " _
            & "[ColumnSixWidth] = " & CInt(txtColWidth6.Text) & ", " _
            & "[ColumnOneAlign] = " & intColumnOneAlign & ", " _
            & "[ColumnTwoAlign] = " & intColumnTwoAlign & ", " _
            & "[ColumnThreeAlign] = " & intColumnThreeAlign & ", " _
            & "[ColumnFourAlign] = " & intColumnFourAlign & ", " _
            & "[ColumnFiveAlign] = " & intColumnFiveAlign & ", " _
            & "[ColumnSixAlign] = " & intColumnSixAlign & ", " _
            & "[Grouping] = " & intGroupingStatus & ", " _
            & "[SuppressZero] = '" & strSuppressZero & "', " _
            & "[IncludeManuals] = '" & strIncludeManuals & "', " _
            & "[ColumnOneVisible] = '" & cboVisible1.Text & "', " _
            & "[ColumnTwoVisible] = '" & cboVisible2.Text & "', " _
            & "[ColumnThreeVisible] = '" & cboVisible3.Text & "', " _
            & "[ColumnFourVisible] = '" & cboVisible4.Text & "', " _
            & "[ColumnFiveVisible] = '" & cboVisible5.Text & "', " _
            & "[ColumnSixVisible] = '" & cboVisible6.Text & "' " _
            & "WHERE [ReportNo] = " & intSelectedReport & ""

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Dim i As Integer = 0
        For i = 0 To dgrid.Rows.Count - 1
            Dim intIndNo As Integer = 0
            Dim strIndVal As String = Nothing
            Dim strOpCode As String = Nothing
            Dim strOp1a As String = Nothing
            Dim intOp1n As Integer = 0
            Dim strOp2a As String = Nothing
            Dim intOp2n As Integer = 0
            Dim strOp3a As String = Nothing
            Dim intOp3n As Integer = 0
            Dim intOrdinalNumber As Integer = 0

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(0).Value.ToString) Then intOrdinalNumber = CInt(dgrid.Rows(i).Cells(0).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(1).Value.ToString) Then intIndNo = CInt(dgrid.Rows(i).Cells(1).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(2).Value), "")) Then
                strIndVal = dgrid.Rows(i).Cells(2).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(3).Value), "")) Then
                strOpCode = dgrid.Rows(i).Cells(3).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(4).Value), "")) Then
                strOp1a = dgrid.Rows(i).Cells(4).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(5).Value.ToString) Then intOp1n = CInt(dgrid.Rows(i).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(6).Value), "")) Then
                strOp2a = dgrid.Rows(i).Cells(6).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(7).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(7).Value.ToString) Then intOp2n = CInt(dgrid.Rows(i).Cells(7).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(8).Value), "")) Then
                strOp3a = dgrid.Rows(i).Cells(8).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(9).Value), "")) Then
                If IsNumeric(dgrid.Rows(i).Cells(9).Value.ToString) Then intOp3n = CInt(dgrid.Rows(i).Cells(9).Value.ToString)
            End If

            objCommand = New Data.OleDb.OleDbCommand("UPDATE SystemReportColumnCalculations SET " _
                & "IndNo = " & intIndNo & ", IndVal = '" & strIndVal & "', " _
                & "OpCode = '" & strOpCode & "', OP1A = '" & strOp1a & "', " _
                & "OP1N = " & intOp1n & ", OP2A = '" & strOp2a & "', OP2N = " & intOp2n & ", " _
                & "OP3A = '" & strOp3a & "', OP3N = " & intOp3n & " " _
                & "WHERE OrdinalNo = " & intOrdinalNumber & " AND " _
                & "ReportNo = " & intSelectedReport & "", cnn)
            objCommand.ExecuteNonQuery()
        Next
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " On Report Update"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ppd_Load(sender As System.Object, e As System.EventArgs) Handles ppd.Load

    End Sub
End Class