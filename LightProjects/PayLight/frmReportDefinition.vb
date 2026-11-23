Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmReportDefinition

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        If String.IsNullOrEmpty(cboDetailFontStyle.Text) Then
            cboDetailFontStyle.Text = "Regular"
        End If
        If String.IsNullOrEmpty(cboHeaderFontStyle.Text) Then
            cboHeaderFontStyle.Text = "Regular"
        End If
        If String.IsNullOrEmpty(cboFooterFontStyle.Text) Then
            cboFooterFontStyle.Text = "Regular"
        End If

        'HEADER FONT
        Select Case UCase(cboHeaderFontStyle.Text)
            Case Is = "BOLD"
                fntUserHeaderFont = New System.Drawing.Font(txtHeaderFont.Text, CInt(cboHeaderSize.Text), FontStyle.Bold)
            Case Is = "ITALIC"
                fntUserHeaderFont = New System.Drawing.Font(txtHeaderFont.Text, CInt(cboHeaderSize.Text), FontStyle.Italic)
            Case Is = "REGULAR"
                fntUserHeaderFont = New System.Drawing.Font(txtHeaderFont.Text, CInt(cboHeaderSize.Text), FontStyle.Regular)
            Case Else
                fntUserHeaderFont = New System.Drawing.Font(txtHeaderFont.Text, CInt(cboHeaderSize.Text), FontStyle.Regular)
        End Select

        'DETAIL FONT
        Select Case UCase(cboDetailFontStyle.Text)
            Case Is = "BOLD"
                fntUserDetailsFont = New System.Drawing.Font(txtDetailFont.Text, CInt(cboDetailSize.Text), FontStyle.Bold)
            Case Is = "ITALIC"
                fntUserDetailsFont = New System.Drawing.Font(txtDetailFont.Text, CInt(cboDetailSize.Text), FontStyle.Italic)
            Case Is = "REGULAR"
                fntUserDetailsFont = New System.Drawing.Font(txtDetailFont.Text, CInt(cboDetailSize.Text), FontStyle.Regular)
            Case Else
                fntUserDetailsFont = New System.Drawing.Font(txtDetailFont.Text, CInt(cboDetailSize.Text), FontStyle.Regular)
        End Select

        'FOOTER FONT
        Select Case UCase(cboFooterFontStyle.Text)
            Case Is = "BOLD"
                fntUserFooterFont = New System.Drawing.Font(txtFooterFont.Text, CInt(cboFooterSize.Text), FontStyle.Bold)
            Case Is = "ITALIC"
                fntUserFooterFont = New System.Drawing.Font(txtFooterFont.Text, CInt(cboFooterSize.Text), FontStyle.Italic)
            Case Is = "REGULAR"
                fntUserFooterFont = New System.Drawing.Font(txtFooterFont.Text, CInt(cboFooterSize.Text), FontStyle.Regular)
            Case Else
                fntUserFooterFont = New System.Drawing.Font(txtFooterFont.Text, CInt(cboFooterSize.Text), FontStyle.Regular)
        End Select

        If chkPageBreak.Checked = True Then boolPageBreak = True Else boolPageBreak = False
        If chkPrintZeros.Checked = True Then boolSuppressZeroValues = True Else boolSuppressZeroValues = False
        If chkBreakKey.Checked = True Then boolBreakOnSortKeyChange = True Else boolBreakOnSortKeyChange = False
        strSortOrder = cboSortOrder.Text
        
        boolAbort = False
        Me.Close()

    End Sub

End Class