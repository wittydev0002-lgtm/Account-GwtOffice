Imports System.Drawing
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocBidders

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtBidNumber.Text) Then
            MessageBox.Show("Please enter the card number", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBidNumber.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtBidNumber.Text) Then
            MessageBox.Show("Please enter a numeric value for the card number", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBidNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtGivenNames.Text) Then
            MessageBox.Show("Please enter the bidder name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGivenNames.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the address", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCellphone.Text) Then
            MessageBox.Show("Please enter the cellphone or alternate contact number", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCellphone.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCategory.Text) Then
            MessageBox.Show("Please select the bid classification", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCellphone.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            'Delete the record first
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Bidders WHERE CardNo = '" & txtBidNumber.Text & "' " _
                & "AND AuctionDate = '" & Format(dpAuctionDate.Value, "dd-MMM-yyyy") & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If

        If Not IsNumeric(txtDepositAmount.Text) Then
            txtDepositAmount.Text = "0.00"
        End If

        If Not IsNumeric(txtCardAmount.Text) Then
            txtCardAmount.Text = "0.00"
        End If

        If boolEditStatus = False Then
            If CheckBidCardIfUsed(txtBidNumber.Text) = True Then
                MessageBox.Show("This card has already been bought for this auction", "Card Alread Sold", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtBidNumber.Focus()
                Exit Sub
            End If
        End If

        Dim strSql As String = "INSERT INTO Bidders (CardNo, Address1, Address2, Address3, Address4, " _
            & "Telephone, Cellphone, EmailAddress, AuctionDate, Classification, GivenNames, IdNumber, DepositAmount, CardAmount) VALUES " _
            & "('" & CInt(txtBidNumber.Text) & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtTelephone.Text & "', " _
            & "'" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', " _
            & "'" & Format(dpAuctionDate.Value, "dd-MMM-yyyy") & "', '" & cboCategory.Text & "', " _
            & "'" & txtGivenNames.Text & "', '" & txtIdNumber.Text & "', " & CDbl(txtDepositAmount.Text) & ", " & CDbl(txtCardAmount.Text) & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        PrintStatement()

        MessageBox.Show("Bidder details saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If boolEditStatus = False Then
            'Clear the controls
            txtAddress1.Clear()
            txtAddress2.Clear()
            txtAddress3.Clear()
            txtAddress4.Clear()
            txtTelephone.Clear()
            txtCellphone.Clear()
            txtBidNumber.Clear()
            txtEmailAddress.Clear()
            'txtCardAmount.Text = "0.00"
            'txtDepositAmount.Text = "0.00"
            txtIdNumber.Clear()
            txtGivenNames.Clear()
            txtBidNumber.Focus()
        Else
            Me.Close()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bidders data update"
        ShowErrorMessage()
    End Sub

    Private Sub LoadClassifications()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(Classification) FROM MocBidClassifications ORDER BY Classification", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCategory.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCategory.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bidders classes data lod"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Bidders WHERE CardNo = " & strSelectedAccount & " " _
            & "AND AuctionDate = '" & strSelectedDate & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("CardNo").ToString) Then txtBidNumber.Text = objReader("CardNo").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If IsDate(objReader("AuctionDate").ToString) Then dpAuctionDate.Value = CDate(objReader("AuctionDate").ToString)
            If Not IsDBNull(objReader("Classification").ToString) Then cboCategory.Text = objReader("Classification").ToString
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtGivenNames.Text = objReader("GivenNames").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If IsNumeric(objReader("DepositAmount").ToString) Then txtDepositAmount.Text = Format(CDbl(objReader("DepositAmount").ToString), "##0.00")
            If IsNumeric(objReader("CardAmount").ToString) Then txtCardAmount.Text = Format(CDbl(objReader("CardAmount").ToString), "##0.00")
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bidders data update"
        ShowErrorMessage()
    End Sub

    Private Sub frmMocBidders_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadClassifications()
        If boolEditStatus = True Then
            LoadData()
        End If
    End Sub

    Private Function GetDepositAmountRequired(PaymentType As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Cost FROM MocBidClassifications " _
            & "WHERE Classification = '" & PaymentType & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bidders amount fetch"
        ShowErrorMessage()
    End Function

    Private Sub cboCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        txtDepositAmount.Text = Format(GetDepositAmountRequired(cboCategory.Text), "##0.00")
    End Sub

    Private Sub txtBidNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBidNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtGivenNames.Focus()
        End If
    End Sub
    Private Sub txtGivenNames_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGivenNames.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtIdNumber.Focus()
        End If
    End Sub
    Private Sub txtIdNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAddress1.Focus()
        End If
    End Sub
    Private Sub txtAddress1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAddress2.Focus()
        End If
    End Sub
    Private Sub txtAddress2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAddress3.Focus()
        End If
    End Sub
    Private Sub txtAddress3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAddress4.Focus()
        End If
    End Sub
    Private Sub txtAddress4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtTelephone.Focus()
        End If
    End Sub
    Private Sub txtTelephone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtCellphone.Focus()
        End If
    End Sub
    Private Sub txtCellphone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCellphone.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtEmailAddress.Focus()
        End If
    End Sub
    Private Sub txtEmailAddress_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dpAuctionDate.Focus()
        End If
    End Sub
    Private Sub dpAuctionDate_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dpAuctionDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cboCategory.Focus()
        End If
    End Sub
    Private Sub cboCategory_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtDepositAmount.Focus()
        End If
    End Sub
    Private Sub txtDepositAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepositAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtCardAmount.Focus()
        End If
    End Sub
    Private Sub txtCardAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCardAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnOk.Focus()
        End If
    End Sub

    Private Function CheckBidCardIfUsed(BidNumber As Integer) As Boolean
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CardNo FROM Bidders WHERE CardNo = " & BidNumber & " " _
            & "AND AuctionDate = '" & Format(dpAuctionDate.Value, "dd-MMM-yyyy") & "'", cnn)
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
        strErrorMessages = Err.Description & " " & Err.Number & " on bid card validation"
        ShowErrorMessage()
    End Function

    Private Sub PrintStatement()
        Dim m_print As New PrintControl.ControlPrint
        m_print.SetControl(gPanel)
        Dim ppd As New EnhancedPrintPreviewDialog
        ppd.Document = DirectCast(m_print, PrintDocument)
        ppd.ShowDialog()
    End Sub

End Class
