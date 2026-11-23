Imports System.Text.RegularExpressions
Imports System.Drawing
Imports System.Drawing.Image
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDocumentBuilder

    'Dim intPriorSplitterDistance As Integer

    'Create a Html Keyword Regex
    Dim htmlkeywords As New System.Text.RegularExpressions.Regex("<html>|</html>|<head>|</head>|<meta|<p>|</p>|<div>|</div>|" _
        & "<B>|</B>|<U>|</U>|<I>|</I>|<L>|</L>|<T>|</T>|<S>|</S>|<E>|</E>|<F>|</F>|<M>|</M>")
    '<----add as many terms as you like between the () don't forget the pipe symbol between each term in the Regex.


#Region "Declarations"
    Private currentFile As String
    Private checkPrint As Integer
#End Region

#Region "Menu Methods"

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If rtbDoc.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("The current document has not been saved, would you like to continue without saving?", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                rtbDoc.Clear()
            Else
                Exit Sub
            End If
        Else
            rtbDoc.Clear()
        End If
        currentFile = ""
        Me.Text = "Editor: New Document"
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If rtbDoc.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("The current document has not been saved, would you like to continue without saving?", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                OpenFile()
            End If
        Else
            OpenFile()
        End If
    End Sub

    Private Sub OpenFile()

        OpenFileDialog1.Title = "RTE - Open File"
        OpenFileDialog1.DefaultExt = "rtf"
        OpenFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = "" Then Exit Sub

        Dim strExt As String
        strExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
        strExt = strExt.ToUpper()

        If System.IO.File.Exists(OpenFileDialog1.FileName) Then
            Select Case strExt
                Case ".RTF"
                    rtbDoc.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.RichText)
                Case Else
                    Dim txtReader As System.IO.StreamReader
                    txtReader = New System.IO.StreamReader(OpenFileDialog1.FileName)
                    rtbDoc.Text = txtReader.ReadToEnd
                    txtReader.Close()
                    txtReader = Nothing
                    rtbDoc.SelectionStart = 0
                    rtbDoc.SelectionLength = 0
            End Select

            currentFile = OpenFileDialog1.FileName
            rtbDoc.Modified = False
            Me.Text = "Editor: " & currentFile.ToString()
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        On Error GoTo RaiseErr
        If currentFile = "" Then
            SaveAsToolStripMenuItem_Click(Me, e)
            Exit Sub
        End If

        Dim strExt As String
        strExt = System.IO.Path.GetExtension(currentFile)
        strExt = strExt.ToUpper()

        Dim strPath As String = System.IO.Path.GetDirectoryName(currentFile)
        Dim strActualName As String = System.IO.Path.GetFileName(currentFile)

        Dim objCommand As Data.OleDb.OleDbCommand

        Select Case strExt
            Case ".RTF"
                rtbDoc.SaveFile(currentFile)
            Case Else
                ' to save as plain text
                Dim txtWriter As System.IO.StreamWriter
                txtWriter = New System.IO.StreamWriter(currentFile)
                txtWriter.Write(rtbDoc.Text)
                txtWriter.Close()
                txtWriter = Nothing
                rtbDoc.SelectionStart = 0
                rtbDoc.SelectionLength = 0
                rtbDoc.Modified = False
        End Select

        Me.lblFileName.Text = "Active File Name : " & currentFile.ToString()

        'Drop the old file name

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemDocuments WHERE FileName = '" & strActualName & "'", cnn)
        objCommand.ExecuteNonQuery()

        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemDocuments ([FileName], [PhysicalPath]) " _
            & "VALUES ('" & strActualName & "', '" & strPath & "')", cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to save document from document builder"
        gwt_comm.ShowErrorMessage()
    End Sub



    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click

        On Error GoTo RaiseErr

        SaveFileDialog1.Title = "RTE - Save File"
        SaveFileDialog1.DefaultExt = "rtf"
        SaveFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.ShowDialog()

        If SaveFileDialog1.FileName = "" Then Exit Sub

        Dim strExt As String
        strExt = System.IO.Path.GetExtension(SaveFileDialog1.FileName)
        strExt = strExt.ToUpper()

        Dim strPath As String = System.IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
        Dim strActualName As String = System.IO.Path.GetFileName(SaveFileDialog1.FileName)

        Select Case strExt
            Case ".RTF"
                rtbDoc.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtWriter As System.IO.StreamWriter
                txtWriter = New System.IO.StreamWriter(SaveFileDialog1.FileName)
                txtWriter.Write(rtbDoc.Text)
                txtWriter.Close()
                txtWriter = Nothing
                rtbDoc.SelectionStart = 0
                rtbDoc.SelectionLength = 0
        End Select

        'Drop the old file name

        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemDocuments WHERE FileName = '" & strActualName & "'", cnn)
        objCommand.ExecuteNonQuery()

        currentFile = SaveFileDialog1.FileName
        rtbDoc.Modified = False
        Me.lblFileName.Text = "Active File Name : " & currentFile.ToString()

        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemDocuments ([FileName], [PhysicalPath]) " _
            & "VALUES ('" & strActualName & "', '" & strPath & "')", cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Document builder file save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If rtbDoc.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("The current document has not been saved, would you like to continue without saving?", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub



    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            rtbDoc.SelectAll()
        Catch exc As Exception
            MessageBox.Show("Unable to select all document content.", "RTE - Select", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            rtbDoc.Copy()
        Catch exc As Exception
            MessageBox.Show("Unable to copy document content.", "RTE - Copy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Try
            rtbDoc.Cut()
        Catch exc As Exception
            MessageBox.Show("Unable to cut document content.", "RTE - Cut", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Try
            rtbDoc.Paste()
        Catch exc As Exception
            MessageBox.Show("Unable to copy clipboard content to document.", "RTE - Paste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SelectFontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFontToolStripMenuItem.Click
        If Not rtbDoc.SelectionFont Is Nothing Then
            FontDialog1.Font = rtbDoc.SelectionFont
        Else
            FontDialog1.Font = Nothing
        End If

        FontDialog1.ShowApply = True

        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbDoc.SelectionFont = FontDialog1.Font
        End If
    End Sub

    Private Sub FontColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripMenuItem.Click
        ColorDialog1.Color = rtbDoc.ForeColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            rtbDoc.SelectionColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub BoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripMenuItem.Click
        'If Not rtbDoc.SelectionFont Is Nothing Then
        '    Dim currentFont As System.Drawing.Font = rtbDoc.SelectionFont
        '    Dim newFontStyle As System.Drawing.FontStyle

        '    If rtbDoc.SelectionFont.Bold = True Then
        '        newFontStyle = FontStyle.Regular
        '    Else
        '        newFontStyle = FontStyle.Bold
        '    End If

        '    rtbDoc.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        'End If
        gwt_comm.ToggleStyle(rtbDoc, FontStyle.Bold)
    End Sub

    Private Sub ItalicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicToolStripMenuItem.Click
        'If Not rtbDoc.SelectionFont Is Nothing Then

        '    Dim currentFont As System.Drawing.Font = rtbDoc.SelectionFont
        '    Dim newFontStyle As System.Drawing.FontStyle

        '    If rtbDoc.SelectionFont.Italic = True Then
        '        newFontStyle = FontStyle.Regular
        '    Else
        '        newFontStyle = FontStyle.Italic
        '    End If

        '    rtbDoc.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        'End If
        gwt_comm.ToggleStyle(rtbDoc, FontStyle.Italic)
    End Sub

    Private Sub UnderlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripMenuItem.Click
        'If Not rtbDoc.SelectionFont Is Nothing Then
        '    Dim currentFont As System.Drawing.Font = rtbDoc.SelectionFont
        '    Dim newFontStyle As System.Drawing.FontStyle
        '    If rtbDoc.SelectionFont.Underline = True Then
        '        newFontStyle = FontStyle.Regular
        '    Else
        '        newFontStyle = FontStyle.Underline
        '    End If
        '    rtbDoc.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        'End If
        gwt_comm.ToggleStyle(rtbDoc, FontStyle.Underline)
    End Sub

    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalToolStripMenuItem.Click
        If Not rtbDoc.SelectionFont Is Nothing Then
            Dim currentFont As System.Drawing.Font = rtbDoc.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            newFontStyle = FontStyle.Regular
            rtbDoc.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub PageColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageColorToolStripMenuItem.Click
        ColorDialog1.Color = rtbDoc.BackColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            rtbDoc.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub mnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUndo.Click
        If rtbDoc.CanUndo Then rtbDoc.Undo()
    End Sub

    Private Sub mnuRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRedo.Click
        If rtbDoc.CanRedo Then rtbDoc.Redo()
    End Sub

    Private Sub LeftToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftToolStripMenuItem.Click
        rtbDoc.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CenterToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripMenuItem.Click
        rtbDoc.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightToolStripMenuItem.Click
        rtbDoc.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub AddBulletsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBulletsToolStripMenuItem.Click
        rtbDoc.BulletIndent = 10
        rtbDoc.SelectionBullet = True
    End Sub

    Private Sub RemoveBulletsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveBulletsToolStripMenuItem.Click
        rtbDoc.SelectionBullet = False
    End Sub

    Private Sub mnuIndent0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIndent0.Click
        rtbDoc.SelectionIndent = 0
    End Sub

    Private Sub mnuIndent5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIndent5.Click
        rtbDoc.SelectionIndent = 5
    End Sub

    Private Sub mnuIndent10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIndent10.Click
        rtbDoc.SelectionIndent = 10
    End Sub

    Private Sub mnuIndent15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIndent15.Click
        rtbDoc.SelectionIndent = 15
    End Sub

    Private Sub mnuIndent20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIndent20.Click
        rtbDoc.SelectionIndent = 20
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        Dim f As New frmFind()
        f.Show()
    End Sub

    Private Sub FindAndReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindAndReplaceToolStripMenuItem.Click
        Dim f As New frmReplace()
        f.Show()
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewToolStripMenuItem.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDoc()
    End Sub

    Private Sub PrintDoc()
        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub mnuPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPageSetup.Click
        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub InsertImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertImageToolStripMenuItem.Click

        OpenFileDialog1.Title = "RTE - Insert Image File"
        OpenFileDialog1.DefaultExt = "rtf"
        OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = "" Then Exit Sub

        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            If System.IO.File.Exists(strImagePath) Then
                Dim img As Image
                img = Image.FromFile(strImagePath)
                Clipboard.SetDataObject(img)
                Dim df As DataFormats.Format
                df = DataFormats.GetFormat(DataFormats.Bitmap)
                If Me.rtbDoc.CanPaste(df) Then
                    Me.rtbDoc.Paste(df)
                End If
            Else
                MessageBox.Show("Unable to insert image format selected.", "Document Builder Paste", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to insert image format selected.", "Document Builder Paste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region "Toolbar Methods"

    Private Sub tbrSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrSave.Click
        SaveToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrOpen.Click
        OpenToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrNew.Click
        NewToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrBold.Click
        BoldToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrItalic.Click
        ItalicToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrUnderline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrUnderline.Click
        UnderlineToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrFont.Click
        SelectFontToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub tbrLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrLeft.Click
        rtbDoc.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub tbrCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrCenter.Click
        rtbDoc.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub tbrRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrRight.Click
        rtbDoc.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub tbrFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrFind.Click
        Dim f As New frmFind()
        f.Show()
    End Sub

#End Region

#Region "Printing"

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ' Adapted from Microsoft's example for extended richtextbox control
        '
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Adapted from Microsoft's example for extended richtextbox control
        '
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = rtbDoc.Print(checkPrint, rtbDoc.TextLength, e)
        ' Look for more pages
        If checkPrint < rtbDoc.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

#End Region

    '    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
    '        If String.IsNullOrEmpty(txtDoc.Text) Then
    '            MessageBox.Show("There is nothing in the document template", "Empty Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            txtDoc.Focus()
    '            Exit Sub
    '        End If
    '        strTemplateContents = txtDoc.Text
    '        Dim frm As New frmDocumentPreview
    '        frm.ShowDialog()
    '    End Sub

    '    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
    '        txtDoc.Clear()
    '    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        PrintDoc()
    End Sub

    Private Sub btnInsertField_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertField.Click
        Dim frm As New frmDocumentFieldsView
        frm.ShowDialog()
    End Sub

    Private Sub btnViewFields_Click(sender As System.Object, e As System.EventArgs) Handles btnViewFields.Click
        Dim frm As New frmDocumentFieldsView
        frm.ShowDialog()
    End Sub

    Private Sub btnCreateDocumentFields_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateDocumentFields.Click
        Dim frm As New frmDocumentKeyFields
        frm.ShowDialog()
    End Sub

End Class
