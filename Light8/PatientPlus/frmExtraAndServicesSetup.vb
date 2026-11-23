Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmExtraAndServicesSetup

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmExtraAndServicesSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dGrid
            .Rows.Add("Medical Aid", "0.00")
            .Rows.Add("Cash", "0.00")
            .Rows.Add("Other", "0.00")
        End With
        If boolEditStatus = True Then
            LoadSelectedData()
        End If
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 1 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub frmExtraAndServicesSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 570 : Me.Height = 322
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Description, CAST([UnitPriceMedaid] AS DECIMAL (10,2)) AS [MedPrice], " _
            & "CAST([UnitPriceCash] AS DECIMAL (10,2)) AS [CashPrice], CAST([UnitPriceOther] AS DECIMAL (10,2)) AS [OtherPrice], " _
            & "CAST(Quantity AS DECIMAL (10,2)) AS [Qty], [Classification] FROM OchmasExtrasAndServices WHERE TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtDescription.Text = objReader(0).ToString
            If IsNumeric(objReader(1).ToString) Then dGrid.Rows(0).Cells(1).Value = CStr(Format(CDbl(objReader(1).ToString), "##0.00"))
            If IsNumeric(objReader(2).ToString) Then dGrid.Rows(1).Cells(1).Value = CStr(Format(CDbl(objReader(2).ToString), "##0.00"))
            If IsNumeric(objReader(3).ToString) Then dGrid.Rows(2).Cells(1).Value = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
            If IsNumeric(objReader(4).ToString) Then txtQuantity.Text = CStr(Format(CDbl(objReader(4).ToString), "##0.00"))
            If IsNumeric(objReader(5).ToString) Then cboClass.Text = objReader(5).ToString
        End If
        objReader.Close()

        lblTID.Text = intSelectedTransaction

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & " On extras and other services details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter a valid description", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboClass.Text) Then
            cboClass.Text = "PRODUCT"
        End If

        Cursor = Cursors.WaitCursor

        Dim dblMedaid As Double = 0
        Dim dblCash As Double = 0
        Dim dblOther As Double = 0

        For p As Integer = 0 To dGrid.RowCount - 1
            Dim dblValue As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblValue = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            Select Case p
                Case = 0
                    dblMedaid = dblValue
                Case = 1
                    dblCash = dblValue
                Case = 2
                    dblOther = dblValue
            End Select
        Next

        Dim dblQty As Double = 0

        If Not IsNumeric(txtQuantity.Text) Then txtQuantity.Text = "0.00"

        dblQty = txtQuantity.Text

        Dim strSql As String = Nothing

        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = True Then
            strSql = "DELETE FROM OchmasExtrasAndServices WHERE TransactionId = " & lblTID.Text & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO OchmasExtrasAndServices (Description, UnitPriceMedaid, UnitPriceCash, UnitPriceOther, Quantity, Classification) VALUES " _
            & "('" & txtDescription.Text & "', " & dblMedaid & ", " & dblCash & ", " & dblOther & ", " & dblQty & ", '" & cboClass.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Cursor = Cursors.Default
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & " On extras and other services details save"
        ShowErrorMessage()
    End Sub

End Class