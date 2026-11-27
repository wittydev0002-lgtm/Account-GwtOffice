Imports CommonLibrary.Commons

''' <summary>
''' One simple screen to see and change the next number of every document type
''' (invoices, quotes, pro forma invoices, orders, ...), including a quick way to start a new year.
''' </summary>
Public Class frmGtiDocumentNumbers
    Inherits Form

    Private Class DocumentType
        Public Title As String
        Public ControlColumn As String   ' column in ControlNumbers holding the last number used
        Public DocumentTable As String   ' table holding the saved documents (for the duplicate check)
        Public DocumentColumn As String
        Public Sub New(ByVal title As String, ByVal controlColumn As String, ByVal documentTable As String, ByVal documentColumn As String)
            Me.Title = title : Me.ControlColumn = controlColumn : Me.DocumentTable = documentTable : Me.DocumentColumn = documentColumn
        End Sub
    End Class

    Private ReadOnly documentTypes As DocumentType() = {
        New DocumentType("Invoices", "Invoices", "CustomerSalesMain", "InvoiceNumber"),
        New DocumentType("Quotations", "Quotations", "QuoteMain", "ReferenceNumber"),
        New DocumentType("Pro forma invoices", "Proforma", "ProformaMain", "ReferenceNumber"),
        New DocumentType("Purchase orders", "Orders", "PurchasesOrderMain", "OrderNumber"),
        New DocumentType("Credit notes", "CreditNotes", "CreditNotesMain", "NoteNumber"),
        New DocumentType("Debit notes", "DebitNotes", "DebitNotesMain", "NoteNumber"),
        New DocumentType("Job cards", "JobCards", "JobCards", "ReferenceNumber"),
        New DocumentType("Job invoices", "JobInvoices", "JobInvoiceMain", "ReferenceNumber"),
        New DocumentType("Supplier invoices", "SupplierInvoices", "", ""),
        New DocumentType("Project claims", "ProjectClaims", "ProjectClaimsMain", "ClaimNumber"),
        New DocumentType("Projects", "ProjectsNumber", "ProjectsMain", "ContractNumber"),
        New DocumentType("Statements", "StatementNumber", "", "")}

    Private Const ColSelect As Integer = 0
    Private Const ColTitle As Integer = 1
    Private Const ColLast As Integer = 2
    Private Const ColNext As Integer = 3

    Private WithEvents grid As New DataGridView()
    Private WithEvents btnNewYear As New Button()
    Private WithEvents btnSave As New Button()
    Private WithEvents btnClose As New Button()
    Private numYear As New NumericUpDown()
    Private lblInfo As New Label()
    Private loading As Boolean = False

    Public Sub New()
        Me.Text = "Document Numbers"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.ClientSize = New Size(640, 520)
        Me.BackColor = Color.White

        lblInfo.SetBounds(12, 10, 616, 52)
        lblInfo.Text = "Each document type has its own number. Change 'Next number' to set the next document's number." _
            & vbCrLf & "To start a new year: tick the document types, choose the year, click 'Start new year', then Save."
        Me.Controls.Add(lblInfo)

        With grid
            .SetBounds(12, 66, 616, 366)
            .AllowUserToAddRows = False : .AllowUserToDeleteRows = False : .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 28
            .RowTemplate.Height = 26

            Dim cSel As New DataGridViewCheckBoxColumn() With {.HeaderText = "New year", .Width = 70}
            Dim cTitle As New DataGridViewTextBoxColumn() With {.HeaderText = "Document", .ReadOnly = True, .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill}
            Dim cLast As New DataGridViewTextBoxColumn() With {.HeaderText = "Last number used", .ReadOnly = True, .Width = 140}
            Dim cNext As New DataGridViewTextBoxColumn() With {.HeaderText = "Next number", .Width = 140}
            cLast.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cLast.DefaultCellStyle.ForeColor = Color.DimGray
            cNext.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cNext.DefaultCellStyle.Font = New Font(Me.Font, FontStyle.Bold)
            .Columns.AddRange(New DataGridViewColumn() {cSel, cTitle, cLast, cNext})
            For Each c As DataGridViewColumn In .Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With
        Me.Controls.Add(grid)

        Dim lblYear As New Label() With {.Text = "Year:", .AutoSize = True}
        lblYear.Location = New Point(12, 449)
        Me.Controls.Add(lblYear)

        numYear.SetBounds(52, 445, 70, 25)
        numYear.Minimum = 2000 : numYear.Maximum = 2999
        numYear.Value = Date.Today.Year
        Me.Controls.Add(numYear)

        btnNewYear.SetBounds(132, 443, 130, 28)
        btnNewYear.Text = "Start new year"
        Me.Controls.Add(btnNewYear)

        btnSave.SetBounds(442, 480, 90, 28)
        btnSave.Text = "Save"
        Me.Controls.Add(btnSave)

        btnClose.SetBounds(538, 480, 90, 28)
        btnClose.Text = "Close"
        Me.Controls.Add(btnClose)

        Me.AcceptButton = Nothing
        Me.CancelButton = btnClose
    End Sub

    Private Sub frmGtiDocumentNumbers_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadNumbers()
    End Sub

    Private Sub LoadNumbers()
        loading = True
        Try
            grid.Rows.Clear()
            Dim numbers As DataTable = GtiTable("SELECT * FROM ControlNumbers")
            If numbers.Rows.Count = 0 Then
                MessageBox.Show("The document numbers have not been set up for this company yet." & vbCrLf _
                    & "Please save them once under Organization Settings first.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False : btnNewYear.Enabled = False
                Exit Sub
            End If
            For Each doc As DocumentType In documentTypes
                If Not numbers.Columns.Contains(doc.ControlColumn) Then Continue For
                Dim last As Long = 0
                Dim raw As Object = numbers.Rows(0)(doc.ControlColumn)
                If Not IsDBNull(raw) AndAlso IsNumeric(raw) Then last = CLng(CDbl(raw))
                Dim index As Integer = grid.Rows.Add(LooksLikeYearNumber(last), doc.Title, last.ToString(), (last + 1).ToString())
                grid.Rows(index).Tag = doc
            Next
        Catch ex As Exception
            MessageBox.Show("The document numbers could not be loaded." & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loading = False
        End Try
    End Sub

    ''' <summary>True for numbers in the "year + running number" style, for example 2025030.</summary>
    Private Shared Function LooksLikeYearNumber(ByVal number As Long) As Boolean
        Dim text As String = number.ToString()
        If text.Length <> 7 Then Return False
        Dim year As Integer = CInt(text.Substring(0, 4))
        Return year >= 2000 AndAlso year <= 2999
    End Function

    Private Sub btnNewYear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewYear.Click
        grid.EndEdit()
        Dim year As Integer = CInt(numYear.Value)
        Dim changed As Integer = 0
        For Each row As DataGridViewRow In grid.Rows
            If CBool(row.Cells(ColSelect).Value) Then
                row.Cells(ColNext).Value = (CLng(year) * 1000 + 1).ToString()
                changed += 1
            End If
        Next
        If changed = 0 Then
            MessageBox.Show("Tick the document types that should start a new year first.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("The ticked documents will start at " & (CLng(year) * 1000 + 1).ToString() & "." & vbCrLf _
                & "Check the numbers and click Save to apply them.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub grid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grid.CurrentCellDirtyStateChanged
        If grid.CurrentCell IsNot Nothing AndAlso grid.CurrentCell.ColumnIndex = ColSelect AndAlso grid.IsCurrentCellDirty Then
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        grid.EndEdit()

        ' 1. Validate and collect the changes.
        Dim changes As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In grid.Rows
            Dim text As String = Trim(Convert.ToString(row.Cells(ColNext).Value))
            Dim nextNumber As Long
            If Not Long.TryParse(text, nextNumber) OrElse nextNumber < 1 OrElse nextNumber > 2000000000 Then
                MessageBox.Show("'" & text & "' is not a valid number for " & Convert.ToString(row.Cells(ColTitle).Value) & "." & vbCrLf _
                    & "Please enter a whole number, for example 2027001.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grid.CurrentCell = row.Cells(ColNext)
                Exit Sub
            End If
            If nextNumber - 1 <> CLng(row.Cells(ColLast).Value) Then changes.Add(row)
        Next
        If changes.Count = 0 Then
            MessageBox.Show("No numbers were changed.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            ' 2. Warn when a new number would run into documents that already exist.
            Dim warnings As New List(Of String)
            For Each row As DataGridViewRow In changes
                Dim doc As DocumentType = CType(row.Tag, DocumentType)
                Dim nextNumber As Long = CLng(row.Cells(ColNext).Value)
                Dim existing As Integer = ExistingDocuments(doc, nextNumber)
                If existing > 0 Then
                    warnings.Add("- " & doc.Title & ": " & existing & " saved document(s) already use numbers from " & nextNumber & " upwards.")
                End If
            Next
            If warnings.Count > 0 Then
                If MessageBox.Show("Some of the new numbers are already in use:" & vbCrLf & vbCrLf & String.Join(vbCrLf, warnings.ToArray()) & vbCrLf & vbCrLf _
                    & "Saving could create duplicate document numbers. Do you still want to save?", Me.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then Exit Sub
            End If

            ' 3. Save only the numbers that were changed.
            Dim summary As New List(Of String)
            For Each row As DataGridViewRow In changes
                Dim doc As DocumentType = CType(row.Tag, DocumentType)
                Dim nextNumber As Long = CLng(row.Cells(ColNext).Value)
                GtiExecute("UPDATE ControlNumbers SET [" & doc.ControlColumn & "] = ?", nextNumber - 1)
                summary.Add(doc.Title & " " & Convert.ToString(row.Cells(ColLast).Value) & " > " & (nextNumber - 1).ToString())
            Next
            GtiLogActivity("ControlNumbers", "Document numbers changed: " & String.Join("; ", summary.ToArray()))

            MessageBox.Show("The document numbers have been saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadNumbers()
        Catch ex As Exception
            MessageBox.Show("The document numbers could not be saved." & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Number of saved documents in the 1000 numbers starting at the given number.</summary>
    Private Shared Function ExistingDocuments(ByVal doc As DocumentType, ByVal fromNumber As Long) As Integer
        If String.IsNullOrEmpty(doc.DocumentTable) Then Return 0
        If Not GtiColumnExists(doc.DocumentTable, doc.DocumentColumn) Then Return 0
        Dim value As Object = GtiScalar("SELECT COUNT(*) FROM [" & doc.DocumentTable & "] WHERE [" & doc.DocumentColumn & "] >= ? AND [" & doc.DocumentColumn & "] < ?",
            fromNumber, fromNumber + 1000)
        If value Is Nothing OrElse IsDBNull(value) Then Return 0
        Return CInt(value)
    End Function

    Private Sub grid_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles grid.DataError
        e.ThrowException = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
