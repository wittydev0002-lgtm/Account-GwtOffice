''' <summary>
''' This class provides two subroutines used to:
''' Find (find the first instance of a search term)
''' Find Next (find other instances of the search term after the first one is found)
''' </summary>
''' <remarks></remarks>

Public Class frmFind

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Dim StartPosition As Integer
        Dim SearchType As CompareMethod

        If chkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If

        StartPosition = InStr(1, frmDocumentBuilder.rtbDoc.Text, txtSearchTerm.Text, SearchType)

        If StartPosition = 0 Then
            MessageBox.Show("String: " & txtSearchTerm.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        frmDocumentBuilder.rtbDoc.Select(StartPosition - 1, txtSearchTerm.Text.Length)
        frmDocumentBuilder.rtbDoc.ScrollToCaret()
        frmDocumentBuilder.Focus()

    End Sub


    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNext.Click

        Dim StartPosition As Integer = frmDocumentBuilder.rtbDoc.SelectionStart + 2
        Dim SearchType As CompareMethod

        If chkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If

        StartPosition = InStr(StartPosition, frmDocumentBuilder.rtbDoc.Text, txtSearchTerm.Text, SearchType)

        If StartPosition = 0 Then
            MessageBox.Show("String: " & txtSearchTerm.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        frmDocumentBuilder.rtbDoc.Select(StartPosition - 1, txtSearchTerm.Text.Length)
        frmDocumentBuilder.rtbDoc.ScrollToCaret()
        frmDocumentBuilder.Focus()

    End Sub

    Private Sub frmFind_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 395 : Me.Height = 155
    End Sub

End Class