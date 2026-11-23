Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmInventoryQuantitySplit

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If txtPackSize.Text.Length <= 0 Then
            MessageBox.Show("Please Enter the pack Size", "Missing Field Pack size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPackSize.Focus()
            Exit Sub

        End If
        If txtQty.Text.Length <= 0 Then
            MessageBox.Show("Please Enter the Quantity", "Missing Field Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQty.Focus()
            Exit Sub

        End If
        With dgrid
            'add 1 row to the datagrid
            .Rows.Add(1)

            'Dim x As String = ddItemColor.SelectedColor.ToString
            'Dim strActualColor As String = Mid(x, 8, x.Length - 8)
            'Dim strIdentifier As String = Mid(strActualColor, 1, 2)
            'Dim strRbg As String = Nothing
            'Dim strKnownColor As String = strActualColor
            'If UCase(strIdentifier) = "A=" Then
            '    'We know that it has returned an rbg
            '    Dim strBuffer() As String = Split(strActualColor, ", ")
            '    strRbg = Mid(strBuffer(0), 3, strBuffer(0).Length - 2) & ", " & _
            '        Mid(strBuffer(1), 3, strBuffer(1).Length - 2) & ", " & _
            '        Mid(strBuffer(2), 3, strBuffer(2).Length - 2) & ", " & _
            '        Mid(strBuffer(3), 3, strBuffer(3).Length - 2)
            '    strKnownColor = gwt_comm.GetDefinedColor(CInt(Mid(strBuffer(0), 3, strBuffer(0).Length - 2)), _
            '        CInt(Mid(strBuffer(1), 3, strBuffer(1).Length - 2)), CInt(Mid(strBuffer(2), 3, strBuffer(2).Length - 2)), _
            '        CInt(Mid(strBuffer(3), 3, strBuffer(3).Length - 2)))
            'End If
            .Rows(.Rows.Count - 1).Cells(0).Value = txtPackSize.Text.ToString
            .Rows(.Rows.Count - 1).Cells(1).Value = cboColor.Text 'strActualColor
            .Rows(.Rows.Count - 1).Cells(2).Value = txtQty.Text.ToString
        End With
        ComputeQuantity()

    End Sub

    Public Function GetKnownColor(ByVal iARGBValue As Integer, ByRef strKnownColor As String) As Boolean
        Dim someColor As Color

        Dim aListofKnownColors As Array = [Enum].GetValues(GetType(KnownColor))
        For Each eKnownColor As KnownColor In aListofKnownColors
            someColor = Color.FromKnownColor(eKnownColor)
            If iARGBValue = someColor.ToArgb() AndAlso Not someColor.IsSystemColor Then
                strKnownColor = someColor.Name
                Return True
            End If
        Next
        strKnownColor = ""
        Return False
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If CInt(lblInventoryQty.Text) <> CInt(lblSplitQuantity.Text) Then
            If MessageBox.Show("The split quantity is not equal to the inventory quantity. Do you want to proceed?", _
                "Quantity Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM InventoryQuantitySplit WHERE " _
                    & "ItemCode = '" & strSelectedInventoryItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()

                For n As Integer = 0 To dgrid.Rows.Count - 1
                    Dim strSize As String = Nothing
                    Dim strColor As String = Nothing
                    Dim intQty As Integer = 0
                    If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(0).Value), "")) Then
                        strSize = dgrid.Rows(n).Cells(0).Value.ToString
                        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(1).Value), "")) Then
                            strColor = dgrid.Rows(n).Cells(1).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                            If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                                intQty = CInt(dgrid.Rows(n).Cells(2).Value.ToString)
                            End If
                        End If
                        Dim strSql As String = "INSERT INTO InventoryQuantitySplit ([ItemCode], [ItemDescription], [ItemColor], [Quantity]) " _
                            & "VALUES ('" & strSelectedInventoryItemCode & "', '" & strSize & "', '" & strColor & "', " & intQty & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                Next
                intSelectedInventoryReturnQuantity = CInt(lblSplitQuantity.Text)
                MessageBox.Show("Quantity split details saved successfully", "Inventory Quantity Split", MessageBoxButtons.OK, MessageBoxIcon.Information)
                boolAbort = False
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory quantity split"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeQuantity()
        Dim intCount As Integer = 0
        For n As Integer = 0 To dgrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                    intCount = intCount + CInt(dgrid.Rows(n).Cells(2).Value.ToString)
                End If
            End If
        Next
        lblSplitQuantity.Text = intCount
    End Sub

    Private Sub dgrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgrid.RowsRemoved
        ComputeQuantity()
    End Sub

    Private Sub frmQuantitySplit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblInventoryQty.Text = intSelectedInventoryQuantity
        LoadData()
        LoadColors()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ItemDescription], [ItemColor], [Quantity] FROM InventoryQuantitySplit " _
            & "WHERE [ItemCode] = '" & strSelectedInventoryItemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
        End While
        objReader.Close()
        Exit Sub
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory quantity split"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventoryQuantitySplit_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 642 : Me.Height = 400
    End Sub

    Private Sub LoadColors()
        cboColor.Items.Add("--NA--")
        cboColor.Items.Add("AliceBlue")
        cboColor.Items.Add("AntiqueWhite")
        cboColor.Items.Add("Aqua")
        cboColor.Items.Add("Aquamarine")
        cboColor.Items.Add("Azure")
        cboColor.Items.Add("Beige")
        cboColor.Items.Add("Bisque")
        cboColor.Items.Add("Black")
        cboColor.Items.Add("BlanchedAlmond")
        cboColor.Items.Add("Blue")
        cboColor.Items.Add("BlueViolet")
        cboColor.Items.Add("Brown")
        cboColor.Items.Add("BurlyWood")
        cboColor.Items.Add("CadetBlue")
        cboColor.Items.Add("Chartreuse")
        cboColor.Items.Add("Chocolate")
        cboColor.Items.Add("Coral")
        cboColor.Items.Add("CornflowerBlue")
        cboColor.Items.Add("Cornsilk")
        cboColor.Items.Add("Crimson")
        cboColor.Items.Add("Cyan")
        cboColor.Items.Add("DarkBlue")
        cboColor.Items.Add("DarkCyan")
        cboColor.Items.Add("DarkGoldenrod")
        cboColor.Items.Add("DarkGray")
        cboColor.Items.Add("DarkGreen")
        cboColor.Items.Add("DarkKhaki")
        cboColor.Items.Add("DarkMagenta")
        cboColor.Items.Add("DarkOliveGreen")
        cboColor.Items.Add("DarkOrange")
        cboColor.Items.Add("DarkOrchid")
        cboColor.Items.Add("DarkRed")
        cboColor.Items.Add("DarkSalmon")
        cboColor.Items.Add("DarkSeaGreen")
        cboColor.Items.Add("DarkSlateBlue")
        cboColor.Items.Add("DarkSlateGray")
        cboColor.Items.Add("DarkTurquoise")
        cboColor.Items.Add("DarkViolet")
        cboColor.Items.Add("DeepPink")
        cboColor.Items.Add("DeepSkyBlue")
        cboColor.Items.Add("DimGray")
        cboColor.Items.Add("DodgerBlue")
        cboColor.Items.Add("Firebrick")
        cboColor.Items.Add("FloralWhite")
        cboColor.Items.Add("ForestGreen")
        cboColor.Items.Add("Fuchsia")
        cboColor.Items.Add("Gainsboro")
        cboColor.Items.Add("GhostWhite")
        cboColor.Items.Add("Gold")
        cboColor.Items.Add("Goldenrod")
        cboColor.Items.Add("Gray")
        cboColor.Items.Add("Green")
        cboColor.Items.Add("GreenYellow")
        cboColor.Items.Add("Honeydew")
        cboColor.Items.Add("HotPink")
        cboColor.Items.Add("IndianRed")
        cboColor.Items.Add("Indigo")
        cboColor.Items.Add("Ivory")
        cboColor.Items.Add("Khaki")
        cboColor.Items.Add("Lavender")
        cboColor.Items.Add("LavenderBlush")
        cboColor.Items.Add("LawnGreen")
        cboColor.Items.Add("LemonChiffon")
        cboColor.Items.Add("LightBlue")
        cboColor.Items.Add("LightCoral")
        cboColor.Items.Add("LightCyan")
        cboColor.Items.Add("LightGoldenrodYellow")
        cboColor.Items.Add("LightGray")
        cboColor.Items.Add("LightGreen")
        cboColor.Items.Add("LightPink")
        cboColor.Items.Add("LightSalmon")
        cboColor.Items.Add("LightSeaGreen")
        cboColor.Items.Add("LightSkyBlue")
        cboColor.Items.Add("LightSlateGray")
        cboColor.Items.Add("LightSteelBlue")
        cboColor.Items.Add("LightYellow")
        cboColor.Items.Add("Lime")
        cboColor.Items.Add("LimeGreen")
        cboColor.Items.Add("Linen")
        cboColor.Items.Add("Magenta")
        cboColor.Items.Add("Maroon")
        cboColor.Items.Add("MediumAquamarine")
        cboColor.Items.Add("MediumBlue")
        cboColor.Items.Add("MediumOrchid")
        cboColor.Items.Add("MediumPurple")
        cboColor.Items.Add("MediumSeaGreen")
        cboColor.Items.Add("MediumSlateBlue")
        cboColor.Items.Add("MediumSpringGreen")
        cboColor.Items.Add("MediumTurquoise")
        cboColor.Items.Add("MediumVioletRed")
        cboColor.Items.Add("MidnightBlue")
        cboColor.Items.Add("MintCream")
        cboColor.Items.Add("MistyRose")
        cboColor.Items.Add("Moccasin")
        cboColor.Items.Add("NavajoWhite")
        cboColor.Items.Add("Navy")
        cboColor.Items.Add("OldLace")
        cboColor.Items.Add("Olive")
        cboColor.Items.Add("OliveDrab")
        cboColor.Items.Add("Orange")
        cboColor.Items.Add("OrangeRed")
        cboColor.Items.Add("Orchid")
        cboColor.Items.Add("PaleGoldenrod")
        cboColor.Items.Add("PaleGreen")
        cboColor.Items.Add("PaleTurquoise")
        cboColor.Items.Add("PaleVioletRed")
        cboColor.Items.Add("PapayaWhip")
        cboColor.Items.Add("PeachPuff")
        cboColor.Items.Add("Peru")
        cboColor.Items.Add("Pink")
        cboColor.Items.Add("Plum")
        cboColor.Items.Add("PowderBlue")
        cboColor.Items.Add("Purple")
        cboColor.Items.Add("Red")
        cboColor.Items.Add("RosyBrown")
        cboColor.Items.Add("RoyalBlue")
        cboColor.Items.Add("SaddleBrown")
        cboColor.Items.Add("Salmon")
        cboColor.Items.Add("SandyBrown")
        cboColor.Items.Add("SeaGreen")
        cboColor.Items.Add("SeaShell")
        cboColor.Items.Add("Sienna")
        cboColor.Items.Add("Silver")
        cboColor.Items.Add("SkyBlue")
        cboColor.Items.Add("SlateBlue")
        cboColor.Items.Add("SlateGray")
        cboColor.Items.Add("Snow")
        cboColor.Items.Add("SpringGreen")
        cboColor.Items.Add("SteelBlue")
        cboColor.Items.Add("Tan")
        cboColor.Items.Add("Teal")
        cboColor.Items.Add("Thistle")
        cboColor.Items.Add("Tomato")
        cboColor.Items.Add("Turquoise")
        cboColor.Items.Add("Violet")
        cboColor.Items.Add("Wheat")
        cboColor.Items.Add("White")
        cboColor.Items.Add("WhiteSmoke")
        cboColor.Items.Add("Yellow")
        cboColor.Items.Add("YellowGreen")

    End Sub
End Class
