Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFunctionsDefinition

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmFunctionsDefinition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With dGrid
            dGrid.Rows.Add("ADC", "ADD AND ACCUMULATE VALUE")
            dGrid.Rows.Add("ADD", "ADD THE TWO VALUES")
            dGrid.Rows.Add("ADV", "ADVANCE VALUE 3 TO NET PAY")
            dGrid.Rows.Add("AGE", "COMPUTE AGE BASED ON THE CURRENT SYSTEM DATE")
            dGrid.Rows.Add("DBC", "DEDUCTION BALANCE CHECK")
            dGrid.Rows.Add("DBU", "DEDUCTION BALANCE UPDATE")
            dGrid.Rows.Add("DIC", "DIVIDE AND ACCUMULATE VALUE")
            dGrid.Rows.Add("DIV", "DIVIDE VALUE 1 BY VALUE 2")
            dGrid.Rows.Add("DT1", "ASSIGN CALENDAR VALUES TO OP-CODES IN DAYS")
            dGrid.Rows.Add("EQ", "CONDITIONAL EXECUTE IF EQUAL TO")
            dGrid.Rows.Add("EXC", "RAISE EXCEPTION BASED ON OP-CODES STATUS")
            dGrid.Rows.Add("GO", "JUMP TO LINE SPECIFIED WITHIN THE CALCULATIONS")
            dGrid.Rows.Add("GT", "CONDITIONAL EXECUTE IF GREATER THAN")
            dGrid.Rows.Add("HR", "HALF ROUND")
            dGrid.Rows.Add("IND", "INDICATOR VALUE")
            dGrid.Rows.Add("LT", "CONDITIONAL EXECUTE IF LESS THAN")
            dGrid.Rows.Add("MOV", "MOVE VALUE 1 TO VALUE 3")
            dGrid.Rows.Add("MUC", "MULTIPLY AND ACCUMULATE RESULT")
            dGrid.Rows.Add("MUL", "MULTIPLY VALUE 1 BY VALUE 2")
            dGrid.Rows.Add("NEQ", "CONDITIONAL EXECUTE IF NOT EQUAL TO")
            dGrid.Rows.Add("NGT", "CONDITIONAL EXECUTE IF NOT GREATER THAN")
            dGrid.Rows.Add("NLT", "CONDITIONAL EXECUTE IF NOT LESS THAN")
            dGrid.Rows.Add("RUP", "ROUNDS NUMBER UP BY DECIMAL PLACES IN OP2")
            dGrid.Rows.Add("SRV", "COMPUTES SERVICE PERIOD IN MONTHS")
            dGrid.Rows.Add("SUB", "SUBTRACT VALUE 1 FROM VALUE 2")
            dGrid.Rows.Add("TBL", "CHECK VALUES FROM GIVE TABLE NUMBER")
            dGrid.Rows.Add("ZRO", "SET THE GIVEN VALUES TO '0'")
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        strFunctionCode = dGrid.CurrentRow.Cells(0).Value.ToString
        Me.Close()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        strFunctionCode = dGrid.CurrentRow.Cells(0).Value.ToString
        Me.Close()
    End Sub

    Private Sub frmFunctionsDefinition_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 460 : Me.Height = 457
    End Sub

End Class
