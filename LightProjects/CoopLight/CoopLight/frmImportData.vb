Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmImportData

    Dim intStartNumber As Integer = DatePart(DateInterval.Year, Now) & DatePart(DateInterval.Day, Now)

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName
        If String.IsNullOrEmpty(strFileName) Then
            MessageBox.Show("Please enter as valid file name", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        Else
            txtFilename.Text = strFileName
        End If
    End Sub

    Private Function AutoAllocateNumber() As String
        intStartNumber = intStartNumber + 1
        Return CStr(intStartNumber)
    End Function

    Private Sub ProcessFile(FileName As String)
        On Error GoTo RaiseErr
        If System.IO.File.Exists(FileName) Then
            Dim objFile As New System.IO.StreamReader(FileName)
            Dim strData As String = objFile.ReadToEnd
            objFile.Close()
            Dim strLines() As String = Split(strData, vbCrLf)

            With pb1
                .Value = 0
                .Visible = True
                .Maximum = strLines.Length + 10
            End With

            For p As Integer = 1 To strLines.Length - 1
                If Not String.IsNullOrEmpty(strLines(p)) Then
                    Dim strFields() As String = Split(strLines(p), "|")

                    Dim strKeyNumber As String = Trim(strFields(1))
                    If String.IsNullOrEmpty(strKeyNumber) Then
                        strKeyNumber = AutoAllocateNumber()
                    End If
                    strKeyNumber = "IHC" & strKeyNumber

                    Dim strDob As String = Trim(strFields(4))
                    Dim strDateParts() As String = Split(strDob, "-")

                    Dim strDobIn As String = "01-JAN-1975"
                    If strDateParts.Length > 2 Then
                        If IsNumeric(strDateParts(0)) Then
                            If IsNumeric(strDateParts(1)) Then
                                If IsNumeric(strDateParts(2)) Then
                                    If CInt(strDateParts(1)) > 12 Then strDateParts(1) = "12"
                                    If strDateParts(2).Length < 4 Then strDateParts(2) = Mid(strDateParts(2), 1, 2)
                                    strDobIn = strDateParts(0) & "-" & MonthName(CInt(strDateParts(1))) & "-" & strDateParts(2)
                                End If
                            End If
                        End If

                    End If

                    Dim strAddress As String = strFields(2) & " IMBAHURU HOUSING"
                    Dim strLastName As String = Nothing
                    Dim strFirstName As String = Nothing
                    Dim strOtherNames As String = Nothing

                    Dim strNames() As String = Split(strFields(0), " ")

                    If strNames.Length > 0 Then
                        strLastName = strNames(0)
                    End If

                    If strNames.Length > 1 Then
                        strFirstName = strNames(1)
                    End If

                    If strNames.Length > 2 Then
                        strOtherNames = strNames(2)
                    End If

                    If strNames.Length > 3 Then
                        strOtherNames = strOtherNames & " " & strNames(3)
                    End If

                    If strNames.Length > 4 Then
                        strOtherNames = strOtherNames & " " & strNames(4)
                    End If

                    Dim dblPrems As Double = 0
                    If IsNumeric(strFields(6)) Then
                        dblPrems = CDbl(strFields(6))
                    End If

                    Dim dblSize As Double = 0
                    If IsNumeric(strFields(2)) Then
                        dblSize = CDbl(strFields(2))
                    End If

                    If recordExists(strKeyNumber) = False Then

                        'NAME|STAND NUMBER|STAND SIZE|ID NUMBER|DOB|CELL NUMBER|JAN|FEB|MAR|TOTAL
                        Dim strSql As String = "INSERT INTO [BM_Master]([PolicyNumber],[DateOfBirth],[Address1],[InceptionDate],[IdNumber]," _
                        & "[Remarks],[LastName],[FirstName],[OtherNames], [Cellphone], " _
                        & "[Frequency], [BenefitType], [PeriodPremiums], [PayMode], " _
                        & "[StandSize], [InterestRate], [CoopAddress1]) VALUES " _
                        & "('" & strKeyNumber & "', '" & strDobIn & "', '" & strAddress & "', '" & Format(Now, "dd-MMM-yyyy") & "', " _
                        & "'" & Trim(strFields(3)) & "', 'TAKE ON DATA DIRECTLY IMPORTED FROM EXCEL', " _
                        & "'" & strLastName & "', '" & strFirstName & "', '" & strOtherNames & "', " _
                        & "'0" & strFields(5) & "', 'MONTHLY', 'HOUSING', " & dblPrems & ", 'CASH', " & dblSize & ", " _
                        & "0, '" & strAddress & "')"
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        Dim Period As Integer = 0

                        'Add the financials
                        For q As Integer = 6 To strFields.Length - 1
                            Dim dblAmount As Double = 0
                            If IsNumeric(strFields(q)) Then
                                dblAmount = CDbl(strFields(q))
                            End If

                            Select Case q
                                Case = 6
                                    Period = 1
                                Case = 7
                                    Period = 2
                                Case = 8
                                    Period = 3
                            End Select
                            Dim strDescription As String = CStr(Format(Period, "00")) & "-2017"

                            strSql = "INSERT INTO BM_Financials (PolicyNumber, Amount, PeriodMonth, PeriodYear, " _
                            & "Reference, TransactionDate, UserName, Description, CapitalPayment, AdminFees, " _
                            & "InterestsCharged, InterestsPaid) " _
                            & "VALUES ('" & strKeyNumber & "', " & dblAmount & ", " & Period & ", 2017, 'IHP001', " _
                            & "'" & Format(Now, "dd-MMM-yyyy") & "', '" & strUserName & "', " _
                            & "'" & strDescription & "',  " & dblAmount & ", 0, 0, 0)"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                        Next

                    Else
                        Dim objErr As New System.IO.StreamWriter(Application.StartupPath & "\Errors.txt", True)
                        objErr.Write(strLines(p))
                        objErr.Close()
                    End If

                End If

                    pb1.Value = pb1.Value + 1

            Next

            MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Please enter as valid file name", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On data coop light import"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ProcessFile(txtFilename.Text)
    End Sub

    Private Function recordExists(Key As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT PolicyNumber FROM BM_Master WHERE PolicyNumber = '" & Key & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On data coop light import"
        ShowErrorMessage()
    End Function
End Class