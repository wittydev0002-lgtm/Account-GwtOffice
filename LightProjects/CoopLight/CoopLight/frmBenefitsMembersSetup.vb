Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Drawing.Printing

Public Class frmBenefitsMembersSetup

    Dim strFequency As String = Nothing

    Dim X(0 To 7) As Integer
    Dim W(0 To 7) As Integer
    Dim Y As Integer
    Dim itm As Integer

    Private Sub frmBenefitsMembersSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadBenefits()
        If boolEditStatus = True Then
            LoadData()
            LoadFinancials()
            LoadBankingDetails()
            LoadHistory()
            txtPolicyNumber.Enabled = False
            LoadAttachedDocuments()
        End If
        txtPolicyNumber.Select()

    End Sub

    Private Sub LoadAttachedDocuments()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT FileName, DocumentName FROM BM_AttachedDocuments " _
            & "WHERE PolicyNumber = '" & strSelectedAccount & "' ORDER BY DocumentName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridDocuments.Rows.Clear()
        While objReader.Read
            dGridDocuments.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On co-op member documents load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadHistory()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT TransYear, Amount, CoopFee, AdminFee, Status, TransactionId FROM  BM_TransactionHistory " _
            & "WHERE PolicyNumber = '" & strSelectedAccount & "' ORDER BY TransYear"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridSummary.Rows.Clear()
        While objReader.Read
            dGridSummary.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Add summation
        Dim dblAmount As Double = 0
        Dim intYear As Integer
        Dim dblCoopAmt As Double = 0
        Dim dblAdminAmt As Double = 0

        For p As Integer = 0 To dGridSummary.Rows.Count - 1

            If Not Object.Equals(dGridSummary.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSummary.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGridSummary.Rows(p).Cells(0).Value.ToString) Then
                        intYear = CInt(dGridSummary.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridSummary.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSummary.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGridSummary.Rows(p).Cells(1).Value.ToString) Then
                        dblAmount = dblAmount + CDbl(dGridSummary.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridSummary.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSummary.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGridSummary.Rows(p).Cells(2).Value.ToString) Then
                        dblCoopAmt = dblCoopAmt + CDbl(dGridSummary.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridSummary.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSummary.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGridSummary.Rows(p).Cells(3).Value.ToString) Then
                        dblAdminAmt = dblAdminAmt + CDbl(dGridSummary.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If
        Next

        lblGross.Text = Format(dblAmount, "#,##,0.00")
        lblAdmin.Text = Format(dblAdminAmt, "#,##0.00")
        lblCoop.Text = Format(dblCoopAmt, "#,##0.00")
        If Not IsNumeric(txtCapitalAmt.Text) Then txtCapitalAmt.Text = "0.00" Else lblPropVal.Text = txtCapitalAmt.Text
        lblSumBalance.Text = CDbl(lblPropVal.Text) - dblCoopAmt

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On co-op member history load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadBenefits()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Benefit FROM BM_Benefits ORDER BY Benefit", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboBenefitType.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboBenefitType.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        If gwt_comm.CheckColumnExistence("BM_Master", "PhotoPath") = False Then
            Dim strSql As String = "ALTER TABLE BM_Master ADD [PhotoPath][NVARCHAR](MAX) NOT NULL DEFAULT ''"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing

        'If gwt_comm.CheckColumnExistence("BM_Master", "PhotoPath") = False Then
        '    strSql = "ALTER TABLE BM_Master ADD [PhotoPath][NVARCHAR](MAX) NOT NULL DEFAULT ''"
        '    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '    objCommand.ExecuteNonQuery()
        'End If

        strSql = "SELECT * FROM [BM_Master] " _
            & "WHERE PolicyNumber = '" & strSelectedAccount & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("PolicyNumber").ToString) Then txtPolicyNumber.Text = objReader("PolicyNumber").ToString
            If IsDate(objReader("DateOfBirth").ToString) Then dpBirthDate.Value = CDate(objReader("DateOfBirth").ToString)
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If IsDate(objReader("InceptionDate").ToString) Then dpTakenDate.Value = CDate(objReader("InceptionDate").ToString)
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If IsNumeric(objReader("PeriodPremiums").ToString) Then txtPremium.Text = Format(CDbl(objReader("PeriodPremiums").ToString), "##0.00")
            If Not IsDBNull(objReader("Remarks").ToString) Then txtRemarks.Text = objReader("Remarks").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("Frequency").ToString) Then
                cboFrequency.Text = objReader("Frequency").ToString
                strFequency = objReader("Frequency").ToString
            End If
            If Not IsDBNull(objReader("BenefitType").ToString) Then cboBenefitType.Text = objReader("BenefitType").ToString
            If Not IsDBNull(objReader("EmployeeNo").ToString) Then txtEmployeeNumber.Text = objReader("EmployeeNo").ToString
            If Not IsDBNull(objReader("Employer").ToString) Then txtEmployerName.Text = objReader("Employer").ToString
            If Not IsDBNull(objReader("EmployeeDepartment").ToString) Then txtDepartment.Text = objReader("EmployeeDepartment").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("PayMode").ToString) Then cboPayMethod.Text = objReader("PayMode").ToString
            If IsNumeric(objReader("Capital").ToString) Then txtCapitalAmt.Text = Format(CDbl(objReader("Capital").ToString), "##0.00")
            If Not IsDBNull(objReader("AlternateNumber").ToString) Then txtAlternateNumber.Text = objReader("AlternateNumber").ToString
            If IsNumeric(objReader("StandSize").ToString) Then txtSize.Text = Format(CDbl(objReader("StandSize").ToString), "##0.00")
            If IsDate(objReader("AllocationDate").ToString) Then dpAllocation.Value = CDate(objReader("AllocationDate").ToString)
            If IsNumeric(objReader("InterestRate").ToString) Then txtInterestRate.Text = Format(CDbl(objReader("InterestRate").ToString), "##0.00")

            If Not IsDBNull(objReader("CoopAddress1").ToString) Then txtCoopAddress1.Text = objReader("CoopAddress1").ToString
            If Not IsDBNull(objReader("CoopAddress2").ToString) Then txtCoopAddress2.Text = objReader("CoopAddress2").ToString
            If Not IsDBNull(objReader("CoopAddress3").ToString) Then txtCoopAddress3.Text = objReader("CoopAddress3").ToString
            If Not IsDBNull(objReader("CoopAddress4").ToString) Then txtCoopAddress4.Text = objReader("CoopAddress4").ToString

            If Not IsDBNull(objReader("PhotoPath").ToString) Then
                lblImagePath.Text = objReader("PhotoPath").ToString
                LoadImage(lblImagePath.Text)
            End If


        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadFinancials()
        On Error GoTo RaiseErr

        Dim dblPropertyValue As Double = 0
        Dim objPropValue As New Data.OleDb.OleDbCommand("SELECT Capital FROM BM_Master WHERE PolicyNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReadValue As Data.OleDb.OleDbDataReader = objPropValue.ExecuteReader
        If objReadValue.HasRows Then
            objReadValue.Read()
            If IsNumeric(objReadValue(0).ToString) Then dblPropertyValue = CDbl(objReadValue(0).ToString)
        End If
        objReadValue.Close()

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, PeriodMonth AS [Month], PeriodYear AS [Year], " _
            & "CAST(Amount AS DECIMAL (10,2)) AS [Billed Amount], CAST(CapitalPayment AS DECIMAL (10,2)) as [Prop. Amt], " _
            & "CAST(AdminFees AS DECIMAL (10,2)) AS [Admin. Fee], CAST(InterestsCharged AS DECIMAL (10,2)) AS [Int.], " _
            & "CAST(InterestsPaid AS DECIMAL (10,2)) AS [Int. Pd], TransactionId FROM BM_Financials " _
            & "WHERE PolicyNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate, TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        Dim dblRunningBalance As Double = 0
        Dim dblRunningInterest As Double = 0
        While objReader.Read
            dblPropertyValue = dblPropertyValue - (CDbl(objReader(6).ToString))
            dblRunningInterest = dblRunningInterest + CDbl(objReader(8).ToString) - CDbl(objReader(9).ToString)

            dblRunningBalance = dblRunningBalance + (CDbl(objReader(5).ToString) - ((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString))))

            'Dim dblInterest As Double = dblRunningBalance * (dblCoopOverdueSubsInterest / 100)
            Dim dblInterestPlusBalance As Double = dblRunningBalance + dblRunningInterest 'CDbl(objReader(8).ToString)

            dGrid.Rows.Add(objReader(0), objReader(1),
                objReader(2), objReader(3),
                objReader(4), objReader(5),
                Format((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString) + CDbl(objReader(9).ToString)), "##0.00"),
                objReader(9), objReader(7), objReader(6), Format(dblRunningBalance, "##0.00"), Format(CDbl(objReader(8).ToString), "##0.00"),
                Format(dblInterestPlusBalance, "##0.00"), Format(dblPropertyValue, "##0.00"), objReader(10))
        End While
        objReader.Close()
        dGrid.Columns(1).Frozen = True

        With dGrid
            .Columns(6).DefaultCellStyle.BackColor = Color.LightGreen
            .Columns(7).DefaultCellStyle.BackColor = Color.LightGreen
            .Columns(8).DefaultCellStyle.BackColor = Color.LightGreen
            .Columns(9).DefaultCellStyle.BackColor = Color.LightGreen
        End With
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Setup"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblBalance As Double = 0
        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not Object.Equals(dGrid.Rows(i).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                        dblCredit = CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                    End If
                End If
            End If
            dblCreditTotal = dblCreditTotal + dblCredit
        Next

        'Compute the amount due based on the inception date and payment frequency

        Dim intMonths As Integer = DateDiff(DateInterval.Month, dpTakenDate.Value, Now)
        If intMonths < 0 Then intMonths = 0
        If Not IsNumeric(txtPremium.Text) Then txtPremium.Text = "0"
        Select Case UCase(strFequency)
            Case Is = UCase("Monthly")
                dblDebitTotal = CInt(txtPremium.Text) * intMonths
            Case Is = UCase("Quarterly")
                dblDebitTotal = CInt(txtPremium.Text) * CInt((intMonths / 3))
            Case Is = UCase("Half Yearly")
                dblDebitTotal = CInt(txtPremium.Text) * CInt((intMonths / 6))
            Case Is = UCase("Annually")
                dblDebitTotal = CInt(txtPremium.Text) * CInt((intMonths / 12))
        End Select

        dblBalance = dblBalance + (dblDebitTotal - dblCreditTotal)

        lblBalance.Text = Format(dblBalance, "#,##0.00")
        lblDebits.Text = Format(dblDebitTotal, "#,##0.00")
        lblCredits.Text = Format(dblCreditTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Financials Deatails Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtPolicyNumber.Text) Then
            MessageBox.Show("Please enter the policy number", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPolicyNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter Address", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboFrequency.Text) Then
            MessageBox.Show("Please enter the payment frequency", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboFrequency.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboBenefitType.Text) Then
            MessageBox.Show("Please enter the benefit type", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBenefitType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPayMethod.Text) Then
            cboPayMethod.Text = "CASH"
        End If
        If Not IsNumeric(txtInterestRate.Text) Then
            txtInterestRate.Text = "0.00"
        End If
        SaveData()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        Dim strSql As String
        If Not IsNumeric(txtPremium.Text) Then txtPremium.Text = "0.00"
        If Not IsNumeric(txtCapitalAmt.Text) Then txtCapitalAmt.Text = "0.00"
        If Not IsNumeric(txtSize.Text) Then txtSize.Text = "0.00"
        If boolEditStatus = False Then
            strSql = "INSERT INTO [BM_Master]([PolicyNumber],[DateOfBirth],[Address1],[Address2]," _
                & "[Address3],[Address4],[Telephone],[InceptionDate],[IdNumber]," _
                & "[Remarks],[LastName],[FirstName],[OtherNames], " _
                & "[Frequency], [BenefitType], [EmployeeNo], [Employer], [EmployeeDepartment], " _
                & "[Cellphone], [PeriodPremiums], [EmailAddress], [PayMode], [Capital], " _
                & "[AlternateNumber], [StandSize], [InterestRate], " _
                & "[CoopAddress1], [CoopAddress2], [CoopAddress3], [CoopAddress4], [PhotoPath]) VALUES ('" & txtPolicyNumber.Text & "', " _
                & "'" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', '" & txtAddress1.Text & "', " _
                & "'" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "', " _
                & "'" & txtTelephone.Text & "', '" & Format(dpTakenDate.Value, "dd-MMM-yyyy") & "', " _
                & "'" & txtIdNumber.Text & "', '" & txtRemarks.Text & "', '" & txtLastName.Text & "', '" & txtFirstName.Text & "', " _
                & "'" & txtOtherNames.Text & "', '" & cboFrequency.Text & "', '" & cboBenefitType.Text & "', " _
                & "'" & txtEmployeeNumber.Text & "', '" & txtEmployerName.Text & "', " _
                & "'" & txtDepartment.Text & "', '" & txtCellphone.Text & "', " & txtPremium.Text & ", " _
                & "'" & txtEmailAddress.Text & "', '" & cboPayMethod.Text & "', " & txtCapitalAmt.Text & ", " _
                & "'" & txtAlternateNumber.Text & "', " & txtSize.Text & ", " & txtInterestRate.Text & ", " _
                & "'" & txtCoopAddress1.Text & "', '" & txtCoopAddress2.Text & "', " _
                & "'" & txtCoopAddress3.Text & "', '" & txtCoopAddress4.Text & "', '" & lblImagePath.Text & "')"
        Else
            strSql = "UPDATE [BM_Master] SET [DateOfBirth] = '" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', " _
                & "[Address1] = '" & txtAddress1.Text & "', [Address2] = '" & txtAddress2.Text & "', " _
                & "[Address3] = '" & txtAddress3.Text & "', [Address4] = '" & txtAddress4.Text & "', " _
                & "[Telephone] = '" & txtTelephone.Text & "', [InceptionDate] = '" & Format(dpTakenDate.Value, "dd-MMM-yyyy") & "', " _
                & "[IdNumber] = '" & txtIdNumber.Text & "', [Remarks] = '" & txtRemarks.Text & "', [LastName] = '" & txtLastName.Text & "', " _
                & "[FirstName] = '" & txtFirstName.Text & "', [OtherNames] = '" & txtOtherNames.Text & "', " _
                & "[Frequency] = '" & cboFrequency.Text & "', [BenefitType] = '" & cboBenefitType.Text & "', " _
                & "[EmployeeNo] = '" & txtEmployeeNumber.Text & "', [Employer] = '" & txtEmployerName.Text & "', " _
                & "[EmployeeDepartment] = '" & txtDepartment.Text & "', [Cellphone] = '" & txtCellphone.Text & "', " _
                & "[PeriodPremiums] = " & txtPremium.Text & ", [EmailAddress] = '" & txtEmailAddress.Text & "', " _
                & "[PayMode] = '" & cboPayMethod.Text & "', [Capital] = " & txtCapitalAmt.Text & ", " _
                & "AlternateNumber = '" & txtAlternateNumber.Text & "', [StandSize] = " & txtSize.Text & ", " _
                & "[InterestRate] = " & txtInterestRate.Text & ", [CoopAddress1] = '" & txtCoopAddress1.Text & "', " _
                & "[CoopAddress2] = '" & txtCoopAddress2.Text & "', [CoopAddress3] = '" & txtCoopAddress3.Text & "', " _
                & "[CoopAddress4] = '" & txtCoopAddress4.Text & "', [PhotoPath] = '" & lblImagePath.Text & "' " _
                & "WHERE [PolicyNumber] = '" & txtPolicyNumber.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Whether new or edting the allocation date will need to be put seperately
        If Not String.IsNullOrEmpty(dpAllocation.Text) Then
            If IsDate(dpAllocation.Value) Then
                objCommand = New Data.OleDb.OleDbCommand("UPDATE BM_Master SET " _
                    & "AllocationDate = '" & Format(dpAllocation.Value, "dd-MMM-yyyy") & "' " _
                    & "WHERE PolicyNumber = '" & txtPolicyNumber.Text & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If
        'Save the banking details
        'bmusunha90@gmail.com
        If boolEditStatus = False Then
            strSql = "DELETE FROM [BM_BankingDetails] WHERE [PolicyNumber] = '" & txtPolicyNumber.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO [BM_BankingDetails] ([PolicyNumber],[BankCode],[BankName],[AccountNumber]) VALUES " _
            & "('" & txtPolicyNumber.Text & "', '" & txtBankCode.Text & "', '" & txtBankName.Text & "', '" & txtAccountNumber.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If boolEditStatus = True Then
            MessageBox.Show("Process completed auccessfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Process completed auccessfully. Do you want to add another record?",
                "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ClearControls()
                boolEditStatus = False
                txtPolicyNumber.Select()
            Else
                Me.Close()
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Setup"
        ShowErrorMessage()
    End Sub

    Private Sub NavigateTo(NextIndex As Integer)
        Select Case NextIndex
            Case Is = 1
                txtPolicyNumber.Focus()
            Case Is = 2
                txtAlternateNumber.Focus()
            Case Is = 3
                txtIdNumber.Focus()
            Case Is = 4
                cboBenefitType.Focus()
            Case Is = 5
                txtLastName.Focus()
            Case Is = 6
                txtFirstName.Focus()
            Case Is = 7
                txtOtherNames.Focus()
            Case Is = 8
                txtAddress1.Focus()
            Case Is = 9
                txtAddress2.Focus()
            Case Is = 10
                txtAddress3.Focus()
            Case Is = 11
                txtAddress4.Focus()
            Case Is = 12
                txtTelephone.Focus()
            Case Is = 13
                txtCellphone.Focus()
            Case Is = 14
                txtEmailAddress.Focus()
            Case Is = 15
                dpBirthDate.Focus()
        End Select
    End Sub

    Private Sub ClearControls()
        txtPolicyNumber.Clear()
        txtIdNumber.Clear()
        txtAccountNumber.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtOtherNames.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAddress3.Clear()
        txtAddress4.Clear()
        txtAlternateNumber.Clear()
        txtTelephone.Clear()
        txtCapitalAmt.Text = "0.00"
        txtCellphone.Clear()
        txtPremium.Text = "0.00"
        txtSize.Text = "0.00"
        txtEmailAddress.Clear()
    End Sub

    Private Sub LoadBankingDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT BankCode, BankName, AccountNumber FROM BM_BankingDetails WHERE PolicyNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtBankCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtBankName.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtAccountNumber.Text = objReader(2).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintHistory.Click
        PrintTransactionHistory()
    End Sub

    Private Sub PrintTransactionHistory()
        On Error GoTo RaiseErr
        Dim arrPrintData As New ArrayList
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strLineEntry As String = Nothing
            For i As Integer = 0 To dGrid.ColumnCount - 2
                Dim strColData As String = Nothing
                If i = 3 Or i = 4 Then
                    'Do nothing 
                Else
                    If Not Object.Equals(dGrid.Rows(p).Cells(i).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(i).Value.ToString) Then
                            strColData = dGrid.Rows(p).Cells(i).Value.ToString
                        End If
                    End If
                    strLineEntry = strLineEntry & strColData & ";"
                End If
            Next
            strLineEntry = UCase(Mid(strLineEntry, 1, (strLineEntry.Length - 1)))
            arrPrintData.Add(strLineEntry)
        Next

        Dim pd As New PrintDialog
        pd.ShowDialog()
        strSessionPrinter = pd.PrinterSettings.PrinterName

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        'Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter

        'Dim prnt As New PrintDialog
        'prnt.ShowDialog()
        'strSessionPrinter = prnt.PrinterSettings.PrinterName
        Dim documentPreview As New PrintPreviewDialog
        'rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 12
            'Bill	Property	Admin	Pay Int.	Total	Run Bal.	Interest	Bal+Int	Prop. Bal
            .strColumnHeaders = "DATE|DESCRIPTION|REF.|BILL|AMT PAID|INTEREST|ADMIN. FEE|TO PROP.|RUN BAL|CUR. INT|BAL. ALL|PROP. BALANCE"
            .strColumnAlignments = "0|0|0|2|2|2|2|2|2|2|2|2"
            .strColumnWidths = "80|120|70|55|55|55|55|55|55|55|55|80"
            .strFooterCaption = "STATEMENT OF ACCOUNT"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "STATEMENT OF ACCOUNT FOR " & UCase(txtLastName.Text & " " & txtFirstName.Text)
            .strMainHeader3 = "STAND NO " & UCase(txtPolicyNumber.Text) & " : COOP NO. " & UCase(txtAlternateNumber.Text)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = False
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntFooterFont 'fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Financial History Print"
        ShowErrorMessage()
    End Sub

    Private Sub txtPolicyNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPolicyNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(2)
        End If
    End Sub

    Private Sub txtAlternateNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlternateNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(3)
        End If
    End Sub

    Private Sub txtIdNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(4)
        End If
    End Sub


    Private Sub cboBenefitType_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboBenefitType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(5)
        End If
    End Sub

    Private Sub txtLastName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(6)
        End If
    End Sub

    Private Sub txtFirstName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(7)
        End If
    End Sub

    Private Sub txtOtherNames_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherNames.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(8)
        End If
    End Sub

    Private Sub txtAddress1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(9)
        End If
    End Sub

    Private Sub txtAddress2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(10)
        End If
    End Sub

    Private Sub txtAddress3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(11)
        End If
    End Sub

    Private Sub txtAddress4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(12)
        End If
    End Sub

    Private Sub txtTelephone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(13)
        End If
    End Sub

    Private Sub txtCellphone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCellphone.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(14)
        End If
    End Sub

    Private Sub txtEmailAddress_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If Asc(e.KeyChar) = 13 Then
            NavigateTo(15)
        End If
    End Sub

    Private Sub txtPremium_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPremium.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtCapitalAmt.Select()
        End If
    End Sub

    Private Sub txtCapitalAmt_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCapitalAmt.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtSize.Select()
        End If
    End Sub

    Private Sub txtSize_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSize.KeyDown
        If e.KeyValue = Keys.Enter Then
            dpTakenDate.Select()
        End If
    End Sub

    Private Sub cboFrequency_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboFrequency.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboPayMethod.Select()
        End If
    End Sub

    Private Sub cboPayMethod_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPayMethod.KeyDown
        If e.KeyValue = Keys.Enter Then
            dpAllocation.Select()
        End If
    End Sub

    Private Sub btnPrintStatement_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintStatement.Click
        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub
        PrintStatement()
    End Sub

    Private Sub PrintStatement()

        Dim arrPriorBalances As New ArrayList

        Dim dblCapitalAmount As Double = 0
        Dim dblCapitalPayments As Double = 0
        Dim dblCapitalBalance As Double = 0

        If IsNumeric(txtCapitalAmt.Text) Then dblCapitalAmount = CDbl(txtCapitalAmt.Text)

        Dim objCmdCapital As New Data.OleDb.OleDbCommand("SELECT SUM(CapitalPayment) FROM BM_Financials " _
            & "WHERE PolicyNumber = '" & txtPolicyNumber.Text & "' AND TransactionDate < '" & StartDate & "'", cnn)
        Dim objRd As Data.OleDb.OleDbDataReader = objCmdCapital.ExecuteReader
        If objRd.HasRows Then
            objRd.Read()
            If IsNumeric(objRd(0).ToString) Then
                dblCapitalPayments = CDbl(objRd(0).ToString)
            End If
        End If
        objRd.Close()

        dblCapitalBalance = dblCapitalAmount - dblCapitalPayments

        arrPriorBalances = StatementBalances(strSelectedAccount, StartDate)

        arrStatementDetails = New ArrayList

        'Immediately add the balance line to the array list
        arrStatementDetails.Add(Format(StartDate, "dd-MMM-yyyy") & "|BALANCES B/F| 0.00|0.00|0.00|" &
            Format(CDbl(arrPriorBalances.Item(0)), "##0.00") & "|" & Format(CDbl(arrPriorBalances.Item(1)), "##0.00"))

        'Get the details to print within the selected period
        Dim arrPrintData As New ArrayList
        arrPrintData = StatementPrintDetails(strSelectedAccount, StartDate, EndDate, CDbl(arrPriorBalances.Item(1)))

        dblBillingTotals = 0
        dblInterestCharges = 0
        dblPaymentTotals = 0

        For p As Integer = 0 To arrPrintData.Count - 1

            Dim strBuffer() As String = Split(arrPrintData.Item(p), "|")

            Dim strDate As String = Nothing
            Dim strDescription As String = Nothing
            Dim strBilling As String = "0.00"
            Dim strPayment As String = "0.00"
            Dim strInterest As String = "0.00"
            Dim strDuesBalance As String = "0.00"
            Dim strPropBalance As String = "0.00"

            If Not String.IsNullOrEmpty(strBuffer(0)) Then strDate = strBuffer(0)
            If Not String.IsNullOrEmpty(strBuffer(1)) Then strDescription = strBuffer(1)
            If IsNumeric(strBuffer(5)) Then
                strBilling = CStr(Format(CDbl(strBuffer(5).ToString), "##0.00"))
                dblBillingTotals = dblBillingTotals + CDbl(strBuffer(5).ToString)
            End If
            If IsNumeric(strBuffer(6).ToString) Then
                strPayment = CStr(Format(CDbl(strBuffer(6).ToString), "##0.00"))
                dblPaymentTotals = dblPaymentTotals + CDbl(strBuffer(6).ToString)
            End If
            If IsNumeric(strBuffer(11).ToString) Then
                strInterest = CStr(Format(CDbl(strBuffer(11).ToString), "##0.00"))
                dblInterestCharges = dblInterestCharges + CDbl(strBuffer(11).ToString)
            End If
            If IsNumeric(strBuffer(12).ToString) Then
                strDuesBalance = CStr(Format(CDbl(strBuffer(12).ToString), "##0.00"))
            End If
            If IsNumeric(strBuffer(13).ToString) Then
                strPropBalance = CStr(Format(CDbl(strBuffer(13).ToString), "##0.00"))
            End If

            If CDbl(strBilling) = 0 And CDbl(strPayment) = 0 And CDbl(strInterest) = 0 Then
                'Do nothing about this record (And CDbl(strDuesBalance) = 0)
            Else
                arrStatementDetails.Add(strDate & "|" & strDescription & "|" & strBilling & "|" &
                    strPayment & "|" & strInterest & "|" & strDuesBalance & "|" & strPropBalance)
            End If

        Next

        If arrStatementDetails.Count > 0 Then
            CommonLibrary.Commons.DocumentWriter.CoopAddress1 = txtCoopAddress1.Text
            CommonLibrary.Commons.DocumentWriter.CoopAddress2 = txtCoopAddress2.Text
            CommonLibrary.Commons.DocumentWriter.CoopAddress3 = txtCoopAddress3.Text
            CommonLibrary.Commons.DocumentWriter.CoopAddress4 = txtCoopAddress4.Text
            dblPriorPeriodStatementBalance = CDbl(arrPriorBalances.Item(0))
            gwt_comm.PrintCustomerDocument(1, "MEMBER STATEMENT")
        End If

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim frm As New frmBenefitsHistory
        frm.ShowDialog()
        LoadFinancials()
        LoadHistory()
    End Sub

    Private Sub btnCloseSummary_Click(sender As Object, e As EventArgs) Handles btnCloseSummary.Click
        On Error GoTo RaiseErr
        'Post the transactions
        With dGridSummary
            For p As Integer = 0 To .Rows.Count - 1
                Dim IntYear As Integer = 0
                Dim dblPaid As Integer = 0
                Dim dblCoop As Double = 0
                Dim dblAdmin As Double = 0
                Dim intId As Integer = 0
                Dim strStatus As String = Nothing
                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If IsNumeric(.Rows(p).Cells(0).Value.ToString) Then
                        IntYear = CInt(.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If IsNumeric(.Rows(p).Cells(1).Value.ToString) Then
                        dblPaid = CDbl(.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If IsNumeric(.Rows(p).Cells(2).Value.ToString) Then
                        dblCoop = CDbl(.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If IsNumeric(.Rows(p).Cells(3).Value.ToString) Then
                        dblAdmin = CDbl(.Rows(p).Cells(3).Value.ToString)
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        strStatus = .Rows(p).Cells(4).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                        intId = CInt(.Rows(p).Cells(5).Value.ToString)
                    End If
                End If

                If UCase(strStatus) = "OPEN" Then
                    Dim strDate As String = "31-DEC-" & CStr(IntYear)
                    Dim dblAmount As Double = 0 'dblAdmin + dblCoop
                    Dim strSql As String = "INSERT INTO BM_Financials (PolicyNumber, Amount, PeriodMonth, " _
                        & "PeriodYear, TransactionDate, UserName, Description, CapitalPayment, AdminFees) VALUES " _
                        & "('" & strSelectedAccount & "', " & dblAmount & ", 12, " & IntYear & ", '" & strDate & "', " _
                        & "'" & strUserName & "', 'PAYMENT SUMMARY FOR WHOLE YEAR', " & dblCoop & ", " & dblAdmin & ")"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    strSql = "UPDATE BM_TransactionHistory SET Status = 'CLOSED' WHERE TransactionId = " & intId & ""
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End With
        LoadHistory()
        LoadFinancials()
        MessageBox.Show("Process completed successfully", "process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Financial History Close"
        ShowErrorMessage()
    End Sub

    Private Sub btnSummaryStatement_Click(sender As Object, e As EventArgs) Handles btnSummaryStatement.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        strSql = "SELECT REPLACE(UPPER(CONVERT(NVARCHAR, TransactionDate, 106)), ' ', '-') AS [Date], " _
            & "Description, Reference, Amount AS [Billed], " _
            & "(CapitalPayment + AdminFees + InterestsCharged + InterestsPaid) AS [Payments], " _
            & "PeriodMonth AS [Mth], PeriodYear AS [Yr] FROM BM_Financials " _
            & "WHERE BM_Financials.PolicyNumber = '" & txtPolicyNumber.Text & "' " _
            & "ORDER BY PolicyNumber, PeriodYear, PeriodMonth, TransactionDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrPrintData As New ArrayList

        Dim dblBalance As Double = 0
        Dim dblPropertyValue As Double = 0

        'Get the property value here

        Dim objComPro As New Data.OleDb.OleDbCommand("SELECT Capital FROM BM_Master WHERE PolicyNumber = '" & txtPolicyNumber.Text & "'", cnn)
        Dim objReadProp As Data.OleDb.OleDbDataReader = objComPro.ExecuteReader
        If objReadProp.HasRows Then
            objReadProp.Read()
            If IsNumeric(objReadProp(0).ToString) Then
                dblPropertyValue = CDbl(objReadProp(0).ToString)
            End If
        End If
        objReadProp.Close()

        Dim intKey As Integer = 0
        Dim dblYrBill As Double = 0
        Dim dblYrPaid As Double = 0

        While objReader.Read

            Dim strDte As String = Nothing
            Dim strDesc As String = Nothing
            Dim strRef As String = Nothing
            Dim dblBilled As Double = 0
            Dim dblPaid As Double = 0

            If intKey = 0 Then intKey = CInt(objReader("Yr").ToString)

            If intKey <> CInt(objReader("yr").ToString) Then
                arrPrintData.Add(" ;TOTALS FOR THE YEAR " & CStr(intKey) & "; ;" &
                             CStr(Format(dblYrBill, "##0.00")) & ";" &
                             CStr(Format(dblYrPaid, "##0.00")) & "; ; ; ")
                arrPrintData.Add(" ; ; ; ; ; ; ; ")
                intKey = CInt(objReader("Yr").ToString)
                dblYrBill = 0 : dblYrPaid = 0
            End If

            If Not IsDBNull(objReader(0).ToString) Then strDte = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strDesc = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strRef = objReader(2).ToString
            If IsNumeric(objReader(3).ToString) Then dblBilled = CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblPaid = CDbl(objReader(4).ToString)

            dblBalance = dblBalance + (dblBilled - dblPaid)
            dblPropertyValue = dblPropertyValue - dblPaid

            If dblBilled = 0 And dblPaid = 0 Then
                'Do nothing
            Else
                arrPrintData.Add(strDte & ";" & strDesc & ";" & strRef & ";" &
                             CStr(Format(dblBilled, "##0.00")) & ";" &
                             CStr(Format(dblPaid, "##0.00")) & ";" & CStr(Format(dblBalance, "##0.00")) & ";" &
                             CStr(Format(dblPropertyValue, "##0.00")) & ";" & CStr(objReader("Yr").ToString))
                dblYrBill = dblYrBill + dblBilled
                dblYrPaid = dblYrPaid + dblPaid
            End If

        End While
        objReader.Close()

        arrPrintData.Add(" ;TOTALS FOR YEAR " & CStr(intKey) & "; ;" &
                             CStr(Format(dblYrBill, "##0.00")) & ";" &
                             CStr(Format(dblYrPaid, "##0.00")) & "; ; ; ")
        arrPrintData.Add(" ; ; ; ; ; ; ; ")
        dblYrBill = 0 : dblYrPaid = 0

        'Send to the printing class with grouping and summary totals
        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog
        Dim strPrintValues(0 To arrPrintData.Count - 1) As String
        Dim i As Integer = 0
        For i = 0 To arrPrintData.Count - 1
            strPrintValues(i) = arrPrintData.Item(i)
        Next
        With myReport
            .intNumberOfColumns = 8
            .intPrintRecordsCount = strPrintValues.Length   'Or number of records in the text file
            .strColumnAlignments = "0|0|0|2|2|2|2|0"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO"
            .strColumnHeaders = "DATE|DESCRIPTION|REFERENCE|BILLED|PAID|DUE|BAL. PROP|"
            .strColumnWidths = "80|180|80|80|80|80|80|0"
            .strColumnTotals = "NO|NO|NO|YES|YES|NO|NO|NO"
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .boolGenericReport = True
            '.PrintSummary = True
            .DrawBorder = True
            .BorderColor = Color.FromName("Black")
            .DrawSummaryChart = False
            .VerticalLines = True
            .HorizontalLines = True
            .GridColor = Color.FromName("WhiteSmoke")
            .strPrintValues = strPrintValues
            .strMainCaption = UCase(txtLastName.Text) & " " & UCase(txtFirstName.Text) & UCase(txtOtherNames.Text)
            .strMainHeader2 = "CO-OP NO. " & UCase(txtPolicyNumber.Text)
            .strMainHeader3 = UCase(txtAddress1.Text) & " " & UCase(txtAddress2.Text) & " " & UCase(txtAddress3.Text) & " " & UCase(txtAddress4.Text)
            '.intKeyFieldIndex = 6
            .strKeyName = "YEAR TOTALS"
            .boolGroupDetails = False
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|NO"
            '.intRowHeight = 10
            .NewPageBreak = False
            .boolPrintGroupCount = False
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
        End With

        With DocumentPreview
            .Document = myReport
            .WindowState = FormWindowState.Maximized
            .PrintPreviewControl.Zoom = 1.5
            .Text = "Summary Statement"
            .ShowDialog()
        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Financial Statement Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddDoc_Click(sender As System.Object, e As System.EventArgs) Handles btnAddDoc.Click
        Dim frm As New frmAttachDocument
        frm.ShowDialog()
        LoadAttachedDocuments()
    End Sub

    Private Sub btnDeleteDoc_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteDoc.Click
        If dGridDocuments.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Dim strSql As String = "DELETE FROM BM_AttachedDocuments WHERE " _
            & "PolicyNumber = '" & strSelectedAccount & "' AND " _
            & "FileName = '" & dGridDocuments.CurrentRow.Cells(0).Value.ToString & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Document link has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadAttachedDocuments()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Attached Documents Delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnViewDoc_Click(sender As System.Object, e As System.EventArgs) Handles btnViewDoc.Click
        LoadFile()
    End Sub

    Private Sub LoadFile()
        If dGridDocuments.Rows.Count <= 0 Then Exit Sub
        strSelectedFileName = Nothing
        If Not Object.Equals(dGridDocuments.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridDocuments.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedFileName = dGridDocuments.CurrentRow.Cells(0).Value.ToString
                gwt_comm.ShowWebBrowser()
            End If
        End If
    End Sub

    Private Sub dGridDocuments_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridDocuments.DoubleClick
        LoadFile()
    End Sub

    Private Sub btnAddImage_Click(sender As System.Object, e As System.EventArgs) Handles btnAddImage.Click
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strSelectedFileName = ofd.FileName
        If Not String.IsNullOrEmpty(strSelectedFileName) Then
            lblImagePath.Text = strSelectedFileName
            LoadImage(strSelectedFileName)
        End If
    End Sub

    Private Sub LoadImage(ByVal ImagePath As String)
        On Error GoTo RaiseErr
        If System.IO.File.Exists(ImagePath) Then
            picImage.Load(ImagePath)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On loading photo"
        ShowErrorMessage()
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        lblImagePath.Text = Nothing
        picImage.Image = Nothing
    End Sub

End Class
