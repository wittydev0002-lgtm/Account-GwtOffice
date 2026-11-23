Imports System.IO
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityCustomersImport

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtFileName.Clear()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        txtFileName.Clear()
        ofd.ShowDialog()
        txtFileName.Text = ofd.FileName
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtFileName.Text) Then
            MessageBox.Show("Please enter the source file name", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFileName.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtAccountNumber.Text) Then
            MessageBox.Show("Please enter the first account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If

        If File.Exists(txtFileName.Text) Then
            Dim objFileReader As New StreamReader(txtFileName.Text)
            Dim strData As String = objFileReader.ReadToEnd
            objFileReader.Close()
            Dim strRecords() As String = Split(strData, vbCrLf)

            Dim lngAccountNumber As Long = CLng(txtAccountNumber.Text)

            pb1.Visible = True : pb1.Maximum = strRecords.Length + 2 : pb1.Value = 0

            For i As Integer = 0 To strRecords.Length - 1
                Dim strFileds() As String = Split(strRecords(i), "|")
                Dim strFirstName As String = Nothing
                Dim strLastName As String = Nothing
                Dim strOtherNames As String = Nothing
                Dim strBirthDate As String = "01-JAN-1952"
                Dim strGender As String = "MALE"
                Dim strAddress As String = Nothing
                Dim strCellNumber As String = Nothing
                Dim strEmailAddress As String = Nothing
                'Replace . in the name 
                strFileds(0) = Replace(strFileds(0), ".", " ", 1)
                Dim strNameIn() As String = Split(strFileds(0), " ")

                If strNameIn.Length = 2 Then
                    strFirstName = strNameIn(0)
                    strLastName = strNameIn(1)
                Else
                    If strNameIn.Length = 3 Then
                        strFirstName = strNameIn(0) & " " & strNameIn(1)
                        strLastName = strNameIn(2)
                    End If
                End If

                If Not String.IsNullOrEmpty(strFileds(1)) Then strGender = strFileds(1)

                If Not String.IsNullOrEmpty(strFileds(2)) Then
                    Dim strDateIn() As String = Split(strFileds(2), ".")
                    If strDateIn.Length = 3 Then
                        If IsNumeric(strDateIn(0)) And IsNumeric(strDateIn(1)) And IsNumeric(strDateIn(2)) Then
                            strBirthDate = strDateIn(0) & "-" & gwt_comm.getMonth(CInt(strDateIn(1))) & "-" & strDateIn(2)
                        End If
                    End If
                End If

                strCellNumber = Replace(strFileds(3), " ", "", 1)
                strAddress = strFileds(4)
                strEmailAddress = strFileds(5)

                Dim strSql As String = "INSERT INTO LoyalityCustomers ([AccountNumber],[LastName]," _
                    & "[FirstName],[OtherNames],[MaidenName],[IdNumber],[Gender],[ContactNumber]," _
                    & "[Category],[CurrentDate],[Address1],[Address2],[Address3],[Address4]," _
                    & "[EmailAddress],[DateOfBirth]) VALUES ('" & lngAccountNumber & "', '" & strLastName & "', " _
                    & "'" & strFirstName & "', '', '', '','" & strGender & "', '" & strCellNumber & "', " _
                    & "'---NONE---', '" & Format((DatePart(DateInterval.Year, Now)), "0000") & _
                    Format((DatePart(DateInterval.Month, Now)), "00") & "', '" & strAddress & "', '', '', '', " _
                    & "'" & strEmailAddress & "', '" & strBirthDate & "')"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                lngAccountNumber = lngAccountNumber + 1
                pb1.Value = pb1.Value + 1

            Next
        End If

        MessageBox.Show("Loyality customers imported successfully", "Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Loyality Customers Import Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNumber.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            btnOK.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

End Class
