Imports System.IO
Imports System.Text

Public Class frmLaschCustomerDataImport

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Me.ofd.ShowDialog()
        Me.txtFilename.Text = Me.ofd.FileName
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If Me.txtFilename.Text.Length = 0 Then
            MessageBox.Show("Please enter the name of the file to import from", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnBrowse.Focus()
            Exit Sub
        End If
        'Check that the file exists
        If File.Exists(Me.txtFilename.Text) Then
            ImportFile(Me.txtFilename.Text)
        Else
            MessageBox.Show("The selected file does not exist", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnBrowse.Focus()
        End If
    End Sub

    Private Sub ImportFile(ByVal strFilename As String)

        On Error GoTo RaiseErr

        Dim objStreamReader As StreamReader

        Dim strTextLine As String = Nothing
        'Open the file based on which file is being imported
        objStreamReader = New StreamReader(strFilename)
        
        'Read and write to file the records

        Dim strFileData As String = objStreamReader.ReadToEnd
        objStreamReader.Close()

        Dim strRecords() As String = Split(strFileData, vbCrLf)
        Me.pb1.Visible = True
        Me.pb1.Maximum = strRecords.Length

        For i As Integer = 1 To strRecords.Length - 2

            Dim strFields() As String = Split(strRecords(i), "|")

            'Check the record existence first based on the id number and given names

            Dim strReturn As String = LaschMasterfileDuplicateEntryCheck(strFields(6), Trim(strFields(2)), Trim(strFields(3)))
            Dim ReturnStatus() As String = Split(strReturn, "|")

            If UCase(ReturnStatus(0)) = "TRUE" Then
                'This record will cause duplicates. Write it to error file
                Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\IMPORTERR.TXT", True)
                objFileWriter.WriteLine(strRecords(i) & "**** " & ReturnStatus(1) & " **** " & UCase(Now))
                objFileWriter.Close()

            Else
                'Get the next customer number. If the province and district are blank set to default harare, harare city

                If String.IsNullOrEmpty(strFields(9)) Then strFields(9) = "Harare"
                If String.IsNullOrEmpty(strFields(10)) Then strFields(10) = "Harare City"

                Dim strNewAccountNumber As String = LaschNextCustomerNumber(strFields(9), strFields(10))
                Dim strTitle As String = "Mr"
                Dim strGender As String = "FEMALE"
                If UCase(Mid(Trim(strFields(4)), 1, 1)) = "F" Then
                    strTitle = "Ms"
                    strGender = "FEMALE"
                Else
                    strTitle = "Mr"
                    strGender = "MALE"
                End If

                Dim dblAcreage As Double = 0
                If IsNumeric(Trim(strFields(14))) Then
                    dblAcreage = CDbl(Trim(strFields(14)))
                End If

                Dim strDateOfBirth As String = "01-JAN-1998"
                If Not String.IsNullOrEmpty(Trim(strFields(5))) Then
                    Dim DateFields() As String = Split(Trim(strFields(5)), "/")
                    If DateFields.Length >= 3 Then
                        If IsNumeric(DateFields(1)) Then
                            If IsNumeric(DateFields(0)) Then
                                If IsNumeric(DateFields(2)) Then
                                    If CInt(DateFields(1)) > 12 Then
                                        strDateOfBirth = DateFields(1) & "-" & getMonth(CInt(DateFields(0))) & "-" & DateFields(2)
                                    Else
                                        strDateOfBirth = DateFields(0) & "-" & getMonth(CInt(DateFields(1))) & "-" & DateFields(2)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                If Not IsDate(strDateOfBirth) Then strDateOfBirth = "01-JAN-1998"

                'TransDate|ReceiptNo|FirstName|LastName|Gender|DateOfBirth|IdNumber|Cellphone|FarmName|Province|District|Ward|Crop|FarmType|Acreage|FmlSumAssured|FmlPremium|HamiltonPremium|TotalPremiums

                Dim dblFmlAssured As Double = 0
                If IsNumeric(Trim(strFields(15))) Then
                    dblFmlAssured = CDbl(Trim(strFields(15)))
                End If

                Dim dblFmlPremium As Double = 0
                If IsNumeric(Trim(strFields(16))) Then
                    dblFmlAssured = CDbl(Trim(strFields(16)))
                End If

                Dim dblHamiltonPremium As Double = 0
                If IsNumeric(Trim(strFields(17))) Then
                    dblHamiltonPremium = CDbl(Trim(strFields(17)))
                End If

                Dim dblHamiltonCover As Double = 0

                Dim strSql As String = "INSERT INTO LaschCustomers ([AccountNumber], [Title], [LastName], [FirstName], [OtherNames], " _
                    & "[DateOfBirth], [IdNumber], [Address1], [Address2], [Address3], [Address4], [Telephone], [Cellphone], " _
                    & "[EmailAddress], [KinName], [KinContactNo], [FarmName], [Province], [District], [Ward], [ChiefName], " _
                    & "[Acreage], [FarmerOrganisation], [AgritexOfficer], [LaschOfficer], [FmlPlan], [FmlSumAssured], [FmlPremium], " _
                    & "[FmlOfficer], [HamiltonPlan], [HamiltonSumAssured], [HamiltonPremium], [HamiltonOfficer], [Gender], [Crop], [FarmType]) VALUES " _
                    & "('" & strNewAccountNumber & "', '" & strTitle & "', '" & Trim(strFields(3)) & "', '" & Trim(strFields(2)) & "', '', " _
                    & "'" & strDateOfBirth & "', '" & strFields(6) & "', '', " _
                    & "'', '', '" & strFields(10) & "', '', '" & strFields(7) & "', " _
                    & "'', '', '', '" & strFields(8) & "', " _
                    & "'" & strFields(9) & "', '" & strFields(10) & "', '" & strFields(11) & "', '', " _
                    & "" & dblAcreage & ", '', '', " _
                    & "'', 'WHOLE LIFE', " & dblFmlAssured & ", " & dblFmlPremium & ", " _
                    & "'', 'SHORT TERM COVER', " & dblHamiltonCover & ", " _
                    & "" & dblHamiltonPremium & ", '', '" & strGender & "', '" & strFields(12) & "', '" & strFields(13) & "')"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Update premiums as well as the ledger

                Dim dblTotalPrems As Double = dblFmlPremium + dblHamiltonPremium
                Dim strName As String = UCase(Trim(strFields(3)) & " " & Trim(strFields(2)))

                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LaschCustomersPremiumMatrix WHERE AccountNumber = '" & strNewAccountNumber & "'", cnn)
                objCommand.ExecuteNonQuery()

                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomersPremiumMatrix " _
                    & "(Hectarage, FmlPremium, HamiltonPremium, Assurance, TotalPremiums, AccountNumber, Crop) VALUES " _
                    & "(" & dblAcreage & ", " & dblFmlPremium & ", " & dblHamiltonPremium & ", " & dblFmlAssured & ", " _
                    & "" & dblTotalPrems & ", '" & strNewAccountNumber & "', '" & strFields(12) & "')", cnn)
                objCommand.ExecuteNonQuery()

                Dim myCommand As Data.OleDb.OleDbCommand
                Dim strProcessType As String = "INIATILIZATION PREMIUMS "

                If boolEditStatus = True Then
                    myCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                        & "Description = '" & strProcessType & strName & "'", cnn)
                    myCommand.ExecuteNonQuery()
                    myCommand = New Data.OleDb.OleDbCommand("DELETE FROM LaschCustomerTransactions WHERE " _
                        & "[AccountNumber] = '" & strNewAccountNumber & "' AND [Description] = 'INIATILIZATION PREMIUMS'", cnn)
                    myCommand.ExecuteNonQuery()
                End If

                Dim intSpecialKey As Integer = SpecialKey()
                Dim dblPremiums As Double = dblTotalPrems

                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                    & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                    & "('" & strPublicLaschPremiumsControlAccount & "', '" & Format(Now, "dd-MMM-yyyy") & "', " & dblPremiums & ", 'CREDIT', " _
                    & "'" & strNewAccountNumber & "', '" & strProcessType & strName & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & intSpecialKey & ", " & intSpecialKey & ")", cnn)
                myCommand.ExecuteNonQuery()

                'Update the debtors control account
                If String.IsNullOrEmpty(strPublicDebtorsAccount) Then
                    MessageBox.Show("The debtors control account has not been setup. This will seriously affect the trial balance",
                         "Debtors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                        & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                        & "('" & strPublicDebtorsAccount & "', '" & Format(Now, "dd-MMM-yyyy") & "', " & dblPremiums & ", 'DEBIT', " _
                        & "'" & strNewAccountNumber & "', '" & strProcessType & strName & "', '" & strUserName & "', " _
                        & "'" & strUserBranch & "', " & intSpecialKey & ", " & intSpecialKey & ")", cnn)
                    myCommand.ExecuteNonQuery()
                End If

                'Update the lasch customer transactions
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomerTransactions ([AccountNumber],[TransDate]," _
                        & "[Debit],[Description],[DocumentNumber],[UserName],[ChangeDate]) " _
                        & "VALUES('" & strNewAccountNumber & "', '" & Format(Now, "dd-MMM-yyyy") & "', " _
                        & "" & dblPremiums & ", 'INIATILIZATION PREMIUMS', '" & intSpecialKey & "', " _
                        & "'" & strUserName & "', '" & Now & "')", cnn)
                myCommand.ExecuteNonQuery()


            End If

            Me.pb1.Value = Me.pb1.Value + 1
        Next

        Me.pb1.Value = Me.pb1.Maximum

        MessageBox.Show("File details imported successfully", "Data File Import", MessageBoxButtons.OK, MessageBoxIcon.Information)
        
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Data Import Error"
        ShowErrorMessage()
    End Sub

End Class
