Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions


Public Class frmNewCalculation

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'Get the next available next calculation number
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT CalculationNo " _
            & "FROM SystemCalculationNames ORDER BY CalculationNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        intNextCalculationNumber = 1

        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    intNextCalculationNumber = CInt(objReader(0).ToString) + 1
                End If
            End If
        End If
        objReader.Close()

        If String.IsNullOrEmpty(txtDescription.Text) Or Mid(txtDescription.Text, 1, 1) = " " Then
            MessageBox.Show("Either the description field is empty or begins with spaces. Please re-enter.", _
                "Invalid Calculation Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        Else
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                & "SystemCalculationNames (CalculationNo, CalculationName) " _
                & "VALUES (" & intNextCalculationNumber & ", '" & txtDescription.Text & "')", cnn)
            sqlCommand.ExecuteNonQuery()
            'Initialize the calculation to 1000
            For i = 1 To 1000
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalculations " _
                    & "(CalcNo, OrdinalNo, CalcFunction, OperandOneId, OperandTwoId, " _
                    & "ResultantId, OperandOneCode, OperandTwoCode, ResultantCode, CalcTime) " _
                    & "VALUES (" & intNextCalculationNumber & ", " & i & ", '', '', '', '', 0, 0, 0, 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
        End If
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calculation Initialization"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmNewCalculation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescription.Clear()
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub frmNewCalculation_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 514 : Me.Height = 165
    End Sub

End Class