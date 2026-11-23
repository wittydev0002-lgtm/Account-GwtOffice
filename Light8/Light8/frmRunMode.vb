Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmRunMode

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If cboCalculation.Text = "" Then
            MessageBox.Show("Please select the payroll calculation to use for this run", "Payroll Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCalculation.Focus()
            Exit Sub
        End If
        If cboRunMode.Text = "" Then
            MessageBox.Show("Please select the run type", "Invalid Payroll Run Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboRunMode.Focus()
            Exit Sub
        End If
        intRunCalculation = cboCalculation.Text
        strRunType = cboRunMode.Text
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmRunMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load the payroll calculations
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT CalculationNo, " _
            & "CalculationName FROM SystemCalculationNames ORDER BY CalculationNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim intWidth As Integer = cboCalculation.Width

        With cboCalculation
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "30;140"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(CalculationNo) FROM SystemCalculationNames", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCalculation.Items.Clear()
        Dim i As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                DropDownItems(i) = New MTGCComboBoxItem(objReader(0).ToString, objReader(1).ToString)
            End If
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboCalculation.SelectedIndex = -1
            cboCalculation.Items.Clear()
            cboCalculation.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCalculation.Items.AddRange(DropDownItems)
        End If

        'Get the next payroll run number 

        Dim strSql As String = "SELECT TaxPeriod from SystemCalendar where runstatus = 'N' ORDER BY TaxPeriod ASC"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0)) Then
                If IsNumeric(objReader(0).ToString) Then
                    intCurrentRunNumber = CInt(objReader(0).ToString)
                End If
            End If
        End If
        objReader.Close()

        lblRunNo.Text = intCurrentRunNumber

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Calculations Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboCalculation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalculation.SelectedIndexChanged
        If cboCalculation.Focused = False Then Exit Sub
        If Not cboCalculation.SelectedItem Is Nothing Then
            lblRunNo.Text = cboCalculation.SelectedItem.Col2
        Else
            lblRunNo.Text = ""
        End If
    End Sub

    Private Sub frmRunMode_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 532 : Me.Height = 256
    End Sub

End Class