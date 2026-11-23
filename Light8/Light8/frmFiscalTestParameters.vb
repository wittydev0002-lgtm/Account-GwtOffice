Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmFiscalTestParameters
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboComPort.Text) Then
            MessageBox.Show("Please setup or select the fiscal printer COM port",
                "Invalid Printer COM Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboComPort.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCurrency.Text) Then
            MessageBox.Show("Please select the currency of payment",
                "Invalid Currency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCurrency.Select()
            Exit Sub
        End If
        Dim comPortNumber As Integer = 0
        Dim intCurrency As Integer = 1
        Dim strExtractNumber As String = Regex.Replace(Trim(cboComPort.Text), "\D", "")
        strExtractNumber = Trim(strExtractNumber)
        If IsNumeric(strExtractNumber) Then
            comPortNumber = CLng(strExtractNumber)
        End If
        Dim strBuffer() As String = Split(cboCurrency.Text, "-")
        If IsNumeric(Trim(strBuffer(0))) Then
            intCurrency = CInt(Trim(strBuffer(0)))
        End If
        intPublicTestFiscalCommPort = comPortNumber
        intPublicFiscalCurrency = intCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub GetSerialPortNames()
        cboComPort.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboComPort.Items.Add(sp)
        Next
        Exit Sub
    End Sub

    Private Sub frmFiscalTestParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSerialPortNames()
    End Sub

End Class