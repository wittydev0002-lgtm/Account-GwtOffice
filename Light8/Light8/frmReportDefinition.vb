Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmReportDefinition

    Private Sub btnHeaderFont_Click(sender As System.Object, e As System.EventArgs) Handles btnHeaderFont.Click
        FontDialog1.ShowDialog()
        txtHeaderFont.Text = FontDialog1.Font.Name
        cboHeaderSize.Text = FontDialog1.Font.Size
        Select Case FontDialog1.Font.Style
            Case Is = FontStyle.Bold
                lblHeaderFontStyle.Text = "Bold"
            Case Is = FontStyle.Italic
                lblHeaderFontStyle.Text = "Italic"
            Case Is = FontStyle.Regular
                lblHeaderFontStyle.Text = "Regular"
            Case Else
                lblHeaderFontStyle.Text = "Regular"
        End Select
    End Sub

    Private Sub btnDetailFont_Click(sender As System.Object, e As System.EventArgs) Handles btnDetailFont.Click
        FontDialog1.ShowDialog()
        txtDetailFont.Text = FontDialog1.Font.Name
        cboDetailSize.Text = FontDialog1.Font.Size
        Select Case FontDialog1.Font.Style
            Case Is = FontStyle.Bold
                lblDetailFontStyle.Text = "Bold"
            Case Is = FontStyle.Italic
                lblDetailFontStyle.Text = "Italic"
            Case Is = FontStyle.Regular
                lblDetailFontStyle.Text = "Regular"
            Case Else
                lblDetailFontStyle.Text = "Regular"
        End Select
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        'HEADER FONT
        Select Case UCase(lblHeaderFontStyle.Text)
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
        Select Case UCase(lblDetailFontStyle.Text)
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
        Select Case UCase(lblFooterFontStyle.Text)
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
        If chkZero.Checked = True Then boolSuppressZeroValues = True Else boolSuppressZeroValues = False
        If chkBreakKey.Checked = True Then boolBreakOnSortKeyChange = True Else boolBreakOnSortKeyChange = False
        strSortOrder = cboSortOrder.Text
        strUserFooterText = txtFooter.Text

        boolAbort = False
        Me.Close()

    End Sub

    Private Sub btnFooterFont_Click(sender As System.Object, e As System.EventArgs) Handles btnFooterFont.Click
        FontDialog1.ShowDialog()
        txtFooterFont.Text = FontDialog1.Font.Name
        cboFooterSize.Text = FontDialog1.Font.Size
        Select Case FontDialog1.Font.Style
            Case Is = FontStyle.Bold
                lblFooterFontStyle.Text = "Bold"
            Case Is = FontStyle.Italic
                lblFooterFontStyle.Text = "Italic"
            Case Is = FontStyle.Regular
                lblFooterFontStyle.Text = "Regular"
            Case Else
                lblFooterFontStyle.Text = "Regular"
        End Select
    End Sub

End Class