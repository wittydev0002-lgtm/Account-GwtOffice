Imports System.IO
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmPayrollUserReportsListing

    'declare the array that will hold the calculations
    Dim strPrintCalculations As New ArrayList
    'declare the array that will hold the values for headers
    Dim strPrintHeaders As String
    'declare the employee payfields obtained from the run file
    Dim strEmployeeFields As New ArrayList
    Dim strCurrentPrintEmployeeFields As New ArrayList
    Dim strSortedEmployeeDetails() As String
    Dim strTemp() As String
    Dim strPrintRecord As ArrayList
    Dim dblValues(0 To 249) As Double
    Dim strCalcBuffer() As String
    Dim dblColumnValues As New ArrayList
    Dim strRecordToPrint() As String

    Private Sub tsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNew.Click
        boolEditStatus = False
        Dim F As New frmReportWriter
        F.ShowDialog()
        'Refresh the form
        LoadFormDetails()
    End Sub

    Private Sub tsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEdit.Click
        boolEditStatus = True
        'Get the selected row report number
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedReport = CInt(CurrentCell.Value)
        Dim f As New frmReportWriter
        f.ShowDialog()
        boolEditStatus = False
        LoadFormDetails()
    End Sub

    Private Sub frmUserReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadFormDetails()
    End Sub

    Private Sub LoadFormDetails()
        On Error GoTo RaiseErr

        'Check the table existence and create it if it does not exist
        Dim sqlCreateTable As New Data.OleDb.OleDbCommand("IF OBJECT_ID(N'SystemColumnReportHeaders', N'U') IS NULL CREATE " _
             & "TABLE [SystemColumnReportHeaders]([ReportNo] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY, " _
             & "[ReportName] [nvarchar](50) NOT NULL,[ReportHeader] [nvarchar](50) NOT NULL, " _
             & "[ReportFooter] [nvarchar](50) NULL,	[ColumnOneCaption] [nvarchar](50) NULL, " _
             & "[ColumnTwoCaption] [nvarchar](50) NULL,	[ColumnThreeCaption] [nvarchar](50) NULL, " _
             & "[ColumnFourCaption] [nvarchar](50) NULL,[ColumnFiveCaption] [nvarchar](50) NULL, " _
             & "[ColumnSixCaption] [nvarchar](50) NULL,	[ColumnOneWidth] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnTwoWidth] [int] NOT NULL DEFAULT 0,[ColumnThreeWidth] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnFourWidth] [int] NOT NULL DEFAULT 0,[ColumnFiveWidth] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnSixWidth] [int] NOT NULL DEFAULT 0,[ColumnOneAlign] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnTwoAlign] [int] NOT NULL DEFAULT 0,[ColumnThreeAlign] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnFourAlign] [int] NOT NULL DEFAULT 0,[ColumnFiveAlign] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnSixAlign] [int] NOT NULL DEFAULT 0, [SortMethod] [nvarchar] (350) NOT NULL DEFAULT '001', " _
             & "[Grouping][int] NOT NULL DEFAULT 0, [SuppressZero][nvarchar] (3) NOT NULL DEFAULT 'YES', " _
             & "[IncludeManuals][nvarchar] (3) NOT NULL DEFAULT 'NO')", cnn)
        sqlCreateTable.ExecuteNonQuery()
        sqlCreateTable = New Data.OleDb.OleDbCommand("IF OBJECT_ID(N'SystemColumnReportCalcs', N'U') IS NULL CREATE " _
            & "TABLE SystemColumnReportCalcs ([ReportNo][int] NOT NULL, " _
            & "[OrdinalNo][int] NOT NULL DEFAULT 0, [FieldFunctions][nvarchar] (350) NULL, " _
            & "[TransactionNo][int] NOT NULL PRIMARY KEY IDENTITY (1,1))", cnn)
        sqlCreateTable.ExecuteNonQuery()

        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ReportNo, ReportName " _
            & "FROM SystemColumnReportHeaders ORDER BY ReportNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(1).ToString
        End While
        objReader.Close()
        If dgrid.Rows.Count <= 0 Then
            dgrid.Enabled = False
            tsDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            tsEdit.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        Else
            dgrid.Enabled = True
            tsDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            tsEdit.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Column Reports Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        boolEditStatus = True
        'Get the selected row report number
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedReport = CInt(CurrentCell.Value)
        Dim f As New frmReportWriter
        f.ShowDialog()
        boolEditStatus = False
        LoadFormDetails()
    End Sub

    Private Sub tsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDelete.Click
        'Get the selected row report number
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedReport = CInt(CurrentCell.Value)
        DeleteReport()
    End Sub

    Private Sub DeleteReport()
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete the selected report?", _
                "Report Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemColumnReportHeaders WHERE ReportNo = " & intSelectedReport & "", cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemReportColumnCalcs WHERE ReportNo = " & intSelectedReport & "", cnn)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Report has been permanently deleted successfully", "Column Report Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LoadFormDetails()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Reports File Recreation Error"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Get the selected report number
        If dgrid.Enabled = True Then
            If dgrid.Rows.Count > 0 Then
                intSelectedReport = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
                gwt_comm.PrintColumnReport(intSelectedReport)
            End If
        End If
    End Sub

End Class