Module modTaxGrossing

    Public dblActiveEmployeePaye As Double
    Public dblActiveEmployeeAidsLevy As Double
    Public TaxBandMinima As Double
    Public TaxBandMaxima As Double
    Public TaxBandRate As Double
    Public TaxBandBaseDeduction As Double

    Public Function GrossAmount(BaseValue As Double) As Double
        Dim dblReturn As Double = 0
        Dim dblGrossSalary As Double = BaseValue
        Dim boolComplete As Boolean = False
        While boolComplete = False
            dblGrossSalary = dblGrossSalary + 1
            Dim dblPaye As Double = GrossTax(dblGrossSalary - 0.75)
            'Assign tax and aids levy to public variables
            dblActiveEmployeePaye = dblPaye
            dblActiveEmployeeAidsLevy = dblPaye * 0.03
            Dim dblNetValue As Double = (dblGrossSalary - 0.75) - (dblPaye + (dblPaye * 0.03))
            If dblNetValue >= BaseValue And dblNetValue <= (BaseValue + 1) Then
                dblReturn = dblGrossSalary - 0.75
                boolComplete = True
            End If
        End While
        Return dblReturn
    End Function

    Public Function GrossTax(dblTaxableIncome As Double) As Double
        Dim dblReturn As Double = 0
        'Compute tax
        For n As Integer = 0 To arrTaxBands.Count - 1
            Dim strValues() As String = Split(arrTaxBands(n), "|")
            If dblTaxableIncome > CDbl(strValues(0)) And dblTaxableIncome <= CDbl(strValues(1)) Then
                dblReturn = ((dblTaxableIncome * (CDbl(strValues(2)) / 100)) - CDbl(strValues(3)))
                dblEmployeeTaxRate = (CDbl(strValues(2)) / 100)
                dblBaseCredit = CDbl(strValues(3))

                TaxBandMinima = CDbl(strValues(0))
                TaxBandMaxima = CDbl(strValues(1))
                TaxBandRate = dblEmployeeTaxRate
                TaxBandBaseDeduction = dblBaseCredit

                Return dblReturn
                Exit For
            End If
        Next
        Return dblReturn
    End Function

End Module
