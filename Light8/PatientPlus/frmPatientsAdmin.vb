Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports AdvancedDataGridView


Public Class frmPatientsAdmin

    Private data As List(Of Node)
    Dim arrRelativeNodesIds As ArrayList
    Dim strNodePath As String = Nothing
    Dim boolFormLoading As Boolean

    Private Sub frmAdministration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        boolFormLoading = True
        'TreeListView1.Columns.Clear()

        '******* FORMAT THE TREEGRIDVIEW********************************
        Me.imageStrip.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageStrip.TransparentColor = System.Drawing.Color.Magenta
        Me.imageStrip.ImageSize = New Size(16, 16)

        dGrid.ImageList = imageStrip
        '***************************************************************

        LoadAllPatients()
        boolFormLoading = False
    End Sub

    Private Sub LoadAllPatients()
        data = Nothing
        Dim strSql As String = "SELECT OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ " _
            & "OchmasPatients.OtherNames AS [Given Names], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) as [DOB], " _
            & "OchmasPatients.Gender AS [Gender], OchmasPatients.billingmethod AS [Billing], " _
            & "OchmasPatients.PatientId, ISNULL(OchmasSystemMedicalAids.Name, '') as [Medical Aid], " _
            & "ISNULL(OchmasMedaidMembership.MemberNumber, '') AS [Medaid No], " _
            & "ISNULL(OchmasPatients.DependentCode, 0) AS [Sfx] FROM OchmasPatients " _
            & "LEFT OUTER JOIN OchmasMedaidMembership ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
            & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasMedaidMembership.SchemeNumber = OchmasSystemMedicalAids.SchemeCode " _
            & "WHERE MainMemberId = 0 ORDER BY LastName, FirstName, OtherNames"
        InitializeData(strSql)
        'TreeListView1.CollapseAll()
    End Sub

    Private Sub InitializeData(ByVal SqlQuery As String)
        On Error GoTo RaiseErr

        ' Clear the grid of all rows
        dGrid.Rows.Clear()

        Dim boldFont As Font = New Font(dGrid.DefaultCellStyle.Font, FontStyle.Bold)

        'My code cracking
        Dim objCommand As New Data.OleDb.OleDbCommand(SqlQuery, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            'Given Names, Dob, Gender, Billing Method, Patient Id
            Dim dblAge As Double = 0
            If IsDate(objReader(1).ToString) Then dblAge = DateDiff(DateInterval.Year, CDate(objReader(1).ToString), Now)
            Dim node As TreeGridNode = dGrid.Nodes.Add(objReader(0).ToString(), objReader(2).ToString,
                objReader(3).ToString, objReader(1).ToString, CStr(Format(dblAge, "#0.00")), objReader(4).ToString,
                objReader(5).ToString, objReader(6).ToString, CStr(Format(CInt(objReader(7).ToString), "00")))
            node.ImageIndex = 4
            node.DefaultCellStyle.Font = boldFont

            AddNodes(node, CInt(objReader(4).ToString))
            'data.Add(parent1)

        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient listing load"
        ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef sNode As TreeGridNode, ParentId As Integer)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        strSql = "SELECT OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ " _
            & "OchmasPatients.OtherNames AS [Given Names], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) as [DOB], " _
            & "OchmasPatients.Gender AS [Gender], OchmasPatients.billingmethod AS [Billing], " _
            & "OchmasPatients.PatientId, ISNULL(OchmasSystemMedicalAids.Name, '') as [Medical Aid], " _
            & "ISNULL(OchmasMedaidMembership.MemberNumber, '') AS [Medaid No], " _
            & "ISNULL(OchmasPatients.DependentCode, 0) AS [Sfx] FROM OchmasPatients " _
            & "LEFT OUTER JOIN OchmasMedaidMembership ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
            & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasMedaidMembership.SchemeNumber = OchmasSystemMedicalAids.SchemeCode " _
            & "WHERE MainMemberId = " & ParentId & " ORDER BY LastName, FirstName, OtherNames"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read

            Dim dblAge As Double = 0
            If IsDate(objReader(1).ToString) Then dblAge = DateDiff(DateInterval.Year, CDate(objReader(1).ToString), Now)
            sNode.Nodes.Add(objReader(0).ToString(), objReader(2).ToString,
                objReader(3).ToString, objReader(1).ToString, CStr(Format(dblAge, "#0.00")), objReader(4).ToString,
                objReader(5).ToString, objReader(6).ToString, CStr(Format(CInt(objReader(7).ToString), "00")))
            sNode.ImageIndex = 3

        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient listing load"
        ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        boolAbort = False
        boolEditStatus = False
        Dim frm As New frmPatientSetup
        frm.ShowDialog()
        LoadAllPatients()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        getSelectedPatient()
    End Sub

    Private Sub getSelectedPatient()
        With dGrid
            If .RowCount <= 0 Then Exit Sub
            If Not Object.Equals(.CurrentRow.Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(5).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(5).Value.ToString) Then
                        intSelectedPatient = CLng(.CurrentRow.Cells(5).Value.ToString)
                        boolEditStatus = True
                        boolAbort = False
                        Dim frm As New frmPatientSetup
                        frm.ShowDialog()
                        If boolAbort = True Then Exit Sub
                        LoadAllPatients()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        getSelectedPatient()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAllPatients()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then
            SearchForItem("")
        End If
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)

        On Error GoTo RaiseErr

        If boolFormLoading = True Then Exit Sub
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text
        If Not String.IsNullOrEmpty(strCurrentKey) Then strFind = strFind & strCurrentKey
        strActiveSearch = strFind

        Dim strSql As String = "SELECT OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ " _
            & "OchmasPatients.OtherNames AS [GivenNames], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) as [DOB], " _
            & "OchmasPatients.Gender AS [Gender], OchmasPatients.billingmethod AS [Billing], " _
            & "OchmasPatients.PatientId, ISNULL(OchmasSystemMedicalAids.Name, '') as [MedicalAid], " _
            & "ISNULL(OchmasMedaidMembership.MemberNumber, '') AS [MedaidNo], " _
            & "ISNULL(OchmasPatients.DependentCode, 0) AS [Sfx], OchmasPatients.MainMemberId AS [MainMemberId] FROM OchmasPatients " _
            & "LEFT OUTER JOIN OchmasMedaidMembership ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
            & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasMedaidMembership.SchemeNumber = OchmasSystemMedicalAids.SchemeCode " _
            & "WHERE (LastName Like '%" & strFind & "%' OR FirstName LIKE '%" & strFind & "%' OR OtherNames LIKE '%" & strFind & "%') " _
            & "ORDER BY LastName, FirstName, OtherNames"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim boldFont As Font = New Font(dGrid.DefaultCellStyle.Font, FontStyle.Regular)

        ' Clear the grid of all rows
        dGrid.Rows.Clear()

        While objReader.Read
            'Given Names, Dob, Gender, Billing Method, Patient Id
            Dim dblAge As Double = 0
            If IsDate(objReader(1).ToString) Then dblAge = DateDiff(DateInterval.Year, CDate(objReader(1).ToString), Now)
            Dim node As TreeGridNode = dGrid.Nodes.Add(objReader(0).ToString(), objReader(2).ToString,
                objReader(3).ToString, objReader(1).ToString, CStr(Format(dblAge, "#0.00")), objReader(4).ToString,
                objReader(5).ToString, objReader(6).ToString, CStr(Format(CInt(objReader(7).ToString), "00")))
            node.ImageIndex = 4
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On data search"
        ShowErrorMessage()
    End Sub

    Private Sub AddSearchMainNode(ByVal PatientId As Integer, ByVal MainMemberPatientId As Integer)
        On Error GoTo RaiseErr

        Dim boldFont As Font

        Dim strSql As String = Nothing

        If MainMemberPatientId > 0 Then
            boldFont = New Font(dGrid.DefaultCellStyle.Font, FontStyle.Bold)
            strSql = "SELECT OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ " _
                & "OchmasPatients.OtherNames AS [Given Names], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) as [DOB], " _
                & "OchmasPatients.Gender AS [Gender], OchmasPatients.billingmethod AS [Billing], " _
                & "OchmasPatients.PatientId, ISNULL(OchmasSystemMedicalAids.Name, '') as [Medical Aid], " _
                & "ISNULL(OchmasMedaidMembership.MemberNumber, '') AS [Medaid No], " _
                & "ISNULL(OchmasPatients.DependentCode, 0) AS [Sfx] FROM OchmasPatients " _
                & "LEFT OUTER JOIN OchmasMedaidMembership ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
                & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasMedaidMembership.SchemeNumber = OchmasSystemMedicalAids.SchemeCode " _
                & "WHERE OchmasPatients.PatientId = " & MainMemberPatientId & " ORDER BY LastName, FirstName, OtherNames"
        Else
            boldFont = New Font(dGrid.DefaultCellStyle.Font, FontStyle.Regular)
            strSql = "SELECT OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ " _
                & "OchmasPatients.OtherNames AS [Given Names], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) as [DOB], " _
                & "OchmasPatients.Gender AS [Gender], OchmasPatients.billingmethod AS [Billing], " _
                & "OchmasPatients.PatientId, ISNULL(OchmasSystemMedicalAids.Name, '') as [Medical Aid], " _
                & "ISNULL(OchmasMedaidMembership.MemberNumber, '') AS [Medaid No], " _
                & "ISNULL(OchmasPatients.DependentCode, 0) AS [Sfx] FROM OchmasPatients " _
                & "LEFT OUTER JOIN OchmasMedaidMembership ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
                & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasMedaidMembership.SchemeNumber = OchmasSystemMedicalAids.SchemeCode " _
                & "WHERE OchmasPatients.PatientId = " & PatientId & " ORDER BY LastName, FirstName, OtherNames"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            'Given Names, Dob, Gender, Billing Method, Patient Id
            Dim dblAge As Double = 0
            If IsDate(objReader(1).ToString) Then dblAge = DateDiff(DateInterval.Year, CDate(objReader(1).ToString), Now)
            Dim node As TreeGridNode = dGrid.Nodes.Add(objReader(0).ToString(), objReader(2).ToString,
                objReader(3).ToString, objReader(1).ToString, CStr(Format(dblAge, "#0.00")), objReader(4).ToString,
                objReader(5).ToString, objReader(6).ToString, CStr(Format(CInt(objReader(7).ToString), "00")))
            node.ImageIndex = 4
            node.DefaultCellStyle.Font = boldFont

            If MainMemberPatientId > 0 Then AddSearchSubNode(node, MainMemberPatientId)

            'Delete the added record here 
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Temp_Patient_Search WHERE PatientId = " & CInt(objReader("PatientId").ToString) & "", cnn)
            objCommand.ExecuteNonQuery()

        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient listing load"
        ShowErrorMessage()
    End Sub

    Private Sub AddSearchSubNode(ByRef sNode As TreeGridNode, ParentId As Integer)
        On Error GoTo RaiseErr

        Dim strSql As String = "Select OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ " _
            & "OchmasPatients.OtherNames AS [Given Names], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) as [DOB], " _
            & "OchmasPatients.Gender AS [Gender], OchmasPatients.billingmethod AS [Billing], " _
            & "OchmasPatients.PatientId, ISNULL(OchmasSystemMedicalAids.Name, '') as [Medical Aid], " _
            & "ISNULL(OchmasMedaidMembership.MemberNumber, '') AS [Medaid No], " _
            & "ISNULL(OchmasPatients.DependentCode, 0) AS [Sfx] FROM OchmasPatients " _
            & "LEFT OUTER JOIN OchmasMedaidMembership ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
            & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasMedaidMembership.SchemeNumber = OchmasSystemMedicalAids.SchemeCode " _
            & "WHERE OchmasPatients.MainMemberId = " & ParentId & " AND OchmasPatients.PatientId IN " _
            & "(SELECT Temp_Patient_Search.PatientId FROM Temp_Patient_Search WHERE Temp_Patient_Search.MainMemberId = " & ParentId & ") " _
            & "ORDER BY LastName, FirstName, OtherNames"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read

            Dim dblAge As Double = 0
            If IsDate(objReader(1).ToString) Then dblAge = DateDiff(DateInterval.Year, CDate(objReader(1).ToString), Now)
            sNode.Nodes.Add(objReader(0).ToString(), objReader(2).ToString,
                objReader(3).ToString, objReader(1).ToString, CStr(Format(dblAge, "#0.00")), objReader(4).ToString,
                objReader(5).ToString, objReader(6).ToString, CStr(Format(CInt(objReader(7).ToString), "00")))
            sNode.ImageIndex = 3

            'Delete the added record here 
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Temp_Patient_Search WHERE PatientId = " & CInt(objReader("PatientId").ToString) & "", cnn)
            objCommand.ExecuteNonQuery()

        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient listing load"
        ShowErrorMessage()
    End Sub


    Private Sub btnTestSearch_Click(sender As Object, e As EventArgs) Handles btnTestSearch.Click
        Dim frm As New Form1
        frm.ShowDialog()
    End Sub

    Private Sub BillSelectedPatient()
        intSelectedPatient = 0
        On Error Resume Next

        With dGrid
            If .RowCount <= 0 Then Exit Sub
            If Not Object.Equals(.CurrentRow.Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(5).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(5).Value.ToString) Then
                        intSelectedPatient = CLng(.CurrentRow.Cells(5).Value.ToString)
                        LoadPatientForm()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub LoadPatientForm()
        If intSelectedPatient = 0 Then
            MessageBox.Show("Select a patient to bill/receipt", "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            boolAbort = False
            Dim frm As New frmBilling
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnAdditionals_Click(sender As Object, e As EventArgs) Handles btnAdditionals.Click
        strBillingType = "CONSULTATIONS"
        BillSelectedPatient()
    End Sub

    Friend Class AttachmentColumnHeader
        Inherits DataGridViewColumnHeaderCell
        Public _image As Image
        Public Sub New(img As Image)
            MyBase.New()
            Me._image = img
        End Sub
        Protected Overrides Sub Paint(graphics As Graphics, clipBounds As Rectangle, cellBounds As Rectangle, rowIndex As Integer, dataGridViewElementState As DataGridViewElementStates, value As Object,
         formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value,
             formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
            graphics.DrawImage(_image, cellBounds.X + 4, cellBounds.Y + 2)
        End Sub
        Protected Overrides Function GetValue(rowIndex As Integer) As Object
            Return Nothing
        End Function
    End Class

    Private Sub mnuEditPatient_Click(sender As System.Object, e As System.EventArgs) Handles mnuEditPatient.Click
        getSelectedPatient()
    End Sub

    Private Sub mnuBillPatient_Click(sender As System.Object, e As System.EventArgs) Handles mnuBillPatient.Click
        strBillingType = "CONSULTATIONS"
        BillSelectedPatient()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        DeletePatient()
    End Sub

    Private Sub DeletePatient()
        On Error GoTo RaiseErr

        If dGrid.RowCount <= 0 Then Exit Sub

        Cursor = Cursors.WaitCursor

        If MessageBox.Show("Are you sure you want to delete the selected patient records?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            With dGrid
                If .RowCount <= 0 Then Exit Sub
                If Not Object.Equals(.CurrentRow.Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.CurrentRow.Cells(5).Value.ToString) Then
                        If IsNumeric(.CurrentRow.Cells(5).Value.ToString) Then
                            intSelectedPatient = CLng(.CurrentRow.Cells(5).Value.ToString)
                            Dim strSql As String = "DELETE FROM OchmasPatients WHERE PatientId = " & intSelectedPatient & ""
                            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()
                            LoadAllPatients()
                            MessageBox.Show("Record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            End With
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient record delete"
        ShowErrorMessage()
    End Sub

    Private Sub mnuDeletePatient_Click(sender As System.Object, e As System.EventArgs) Handles mnuDeletePatient.Click
        DeletePatient()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        PrintPatientRecord()
    End Sub

    Private Sub PrintPatientRecord()

    End Sub

    Private Sub mnuPrintPatient_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrintPatient.Click
        PrintPatientRecord()
    End Sub

    Private Sub dGrid_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGrid.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGrid.CurrentCell = dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGrid.Rows(e.RowIndex).Selected = True
            dGrid.Focus()
        End If
    End Sub

End Class