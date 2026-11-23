Imports System.Windows.Forms.DataVisualization.Charting
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBreakInventoryPack

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(Trim(txtSourceCode.Text)) Then
            MessageBox.Show("Process cannot be completed as there is no source inventory code",
                "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceCode.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Trim(txtDestinationCode.Text)) Then
            MessageBox.Show("Process cannot be completed as there is no destination inventory code",
                "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDestinationCode.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Please enter the number of cases to be converted to single units",
                    "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQuantity.Select()
            Exit Sub
        End If

        If CDbl(txtQuantity.Text) <= 0 Then
            MessageBox.Show("The number of cases to be converted to single units must be greater than 0",
                    "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQuantity.Select()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Dim dblCurrentSourceQuantity As Double = 0

        Dim strSql As String = "SELECT [Quantity] FROM [InventoryItems] 
            WHERE [ItemCode] = '" & txtSourceCode.Text & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    If IsNumeric(Trim(objReader(0).ToString)) Then
                        dblCurrentSourceQuantity = CDbl(Trim(objReader(0).ToString))
                    End If
                End If
            End If
        End If
        objReader.Close()

        Dim dblAfterTransactSourceQty As Double = dblCurrentSourceQuantity - CDbl(txtQuantity.Text)

        If dblAfterTransactSourceQty < 0 Then
            Cursor = Cursors.Default
            MessageBox.Show("The number of cases to be converted to single below the quantity in stock",
                    "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQuantity.Select()
            Exit Sub
        End If

        strSql = "UPDATE [InventoryItems] SET [Quantity] = " & dblAfterTransactSourceQty & "
            WHERE [ItemCode] = '" & txtSourceCode.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        ' Get the source item package size
        '
        Dim dblQuantityInPackage As Double = 0

        strSql = "SELECT [SupplyPackagingQuantity] FROM [InventoryItems] 
            WHERE [ItemCode] = '" & txtSourceCode.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    If IsNumeric(Trim(objReader(0).ToString)) Then
                        dblQuantityInPackage = CDbl(Trim(objReader(0).ToString))
                    End If
                End If
            End If
        End If
        objReader.Close()

        Dim dblSingleUnitsTransfered As Double = dblQuantityInPackage * CDbl(txtQuantity.Text)

        strSql = "UPDATE [InventoryItems] SET [Quantity] = [Quantity] + " & dblSingleUnitsTransfered & " 
            WHERE [ItemCode] = '" & txtDestinationCode.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Inventory Cases Converted Successfully to Single Units",
            "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub

RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & vbCrLf & "Error Number: " & Err.Number & vbCrLf &
            "On inventory item convert from pack to single unit items"
        ShowErrorMessage()
    End Sub

    Private Sub LoadDestinationItems()

        On Error GoTo RaiseErr


        Cursor = Cursors.WaitCursor

        Dim arrItems As New ArrayList
        Dim strSql As String = "SELECT [ItemCode] +'|'+ [GroupName] FROM [InventoryItems] 
            WHERE [SupplyPackaging] = 'SINGLE'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(Trim(objReader(0).ToString)) Then
                    arrItems.Add(UCase(Trim(objReader(0).ToString)))
                End If
            End If
        End While
        objReader.Close()

        Dim comboArray(0 To arrItems.Count - 1) As ComboItem
        For p As Integer = 0 To arrItems.Count - 1
            Dim strBuffer() As String = Split(arrItems.Item(p), "|")
            comboArray(p) = New ComboItem(strBuffer(0), strBuffer(1))
        Next

        With cboDestinationDescription
            .DataSource = comboArray
            .DisplayMember = "Column0"
            .ValueMember = "Column0"
        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & vbCrLf & "Error Number: " & Err.Number & vbCrLf &
            "On possible single units inventory items load"
        ShowErrorMessage()
    End Sub

    Private Sub frmBreakInventoryPack_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtSourceCode.Text = strSelectedInventoryItemCode
        txtSourceDescription.Text = strSelectedDescription
        txtSourceCode.Enabled = False
        txtSourceDescription.Enabled = False
        LoadDestinationItems()
    End Sub

End Class