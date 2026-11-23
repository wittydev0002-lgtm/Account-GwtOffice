
Public Class Form1

    Dim strCompanyCountry As String = "zimbabwe"

    Dim fntHeaderFont As New System.Drawing.Font("Arial", 10, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim fntDetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim fntFooterFontItalic As New System.Drawing.Font("Times New Roman", 6, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
    Dim fntDetailsFontBold As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim doc As New SmartDocumentWriter.DocumentPrint
        With doc

            '.MainTitleFont = fntHeaderFont
            '.SubTitleFont = fntDetailsFontBold
            '.DetailFontRegular = fntDetailsFont
            '.DetailFontBold = fntDetailsFontBold

            .CompanyName = UCase("Embassy and Associates")
            .CompanyAddress1 = UCase("5663 Knowe")
            .CompanyAddress2 = UCase("Phase 2")
            .CompanyAddress3 = UCase("Norton")
            .CompanyAddress4 = UCase("Zimbabwe")
            .CompanyTelephone = UCase("04-2010704")
            .CompanyEmail = "phirie@greatwits.co.zw"
            .CompanyVatNumber = "1000142"
            .CompanyBpNumber = "AB00012002"
            .PrintPageBorder = True
            .DrawVerticals = True
            .DocumentHeader = UCase("customer statement")
            .BorderColor = Color.LightGray
            .LogoPath = "C:\Great Wits Images\Great Wits New Small.jpg"
            .LogoXposition = 100
            .CompanyRegistrationNumber = "1000100"
            If UCase(strCompanyCountry) = "SOUTH AFRICA" Then
                .CompanyRegCaption = "CK NO."
            Else
                If UCase(.DocumentHeader) = "COOP MEMBER STATEMENT" Then
                    .CompanyRegCaption = "CERTIFICATE NO."
                Else
                    If UCase(.DocumentHeader) = "PLAINTIFF STATEMENT" Or UCase(.DocumentHeader) = "DEFENDANT STATEMENT" Then
                        .CompanyRegCaption = "CASE NO."
                    Else
                        .CompanyRegCaption = "COY NO."
                    End If
                End If
            End If
            .MainCustomerName = "Goldtech Electronics"
            .MainCustomerAddress1 = "7 George Silundika Avenue"
            .MainCustomerAddress2 = "Kuwirirana House"
            .MainCustomerAddress3 = "Harare"
            .MainCustomerAddress4 = "Zimbabwe"
            .MainCustomerTelephone = "04-747474"
            .MainCustomerVat = "8008008"
            .strColumnHeaders = "Date|Description|Debit|Credit|Balance"
            .strColumnWidths = "100|250|80|80|80"
            .strColumnAlignments = "0|0|2|2|2"
            .intNumberOfColumns = 5

            Dim arrPrintData As New ArrayList
            For q As Integer = 0 To 250
                arrPrintData.Add(shortMonthDateformat(DateAdd(DateInterval.Day, q, Now)) & "|Description - " & Format((q + 1), "0000") & "|00.00|00.00|00.00")
            Next

            Dim strPrintData(0 To (arrPrintData.Count - 1)) As String
            For q As Integer = 0 To arrPrintData.Count - 1
                strPrintData(q) = arrPrintData.Item(q)
            Next

            .PrintData = strPrintData

            .SummaryCaptions = "Balance Before|Total Debits|Sub Total|Less Credits|Balance After"
            .SummaryValues = "2500.00|150.00|2650.00|300.00|2350.00"


            Dim arrBankDetails As New ArrayList
            arrBankDetails.Add("51001|STEWARD BANK JOINA CITY|GREAT WITS TECHNOLOGIES PVT LTD|1006734495")

            Dim documentNo As Integer = 256
            Dim arrDocInfo As New ArrayList
            With arrDocInfo
                .Add("DATE|" & CStr(shortMonthDateformat(Now)))
                .Add("DOC NO.|" & CStr(documentNo))
                .Add("PERIOD|25-JAN-2015 TO 31-JAN-2015")
            End With
            .arrDocumentInformation = arrDocInfo

            'Format of the banking details array list
            ''
            .arrCompanyBankDetails = arrBankDetails
            .PrintBankDetails = True

        End With
        Dim ppd As New PrintPreviewDialog
        ppd.Document = doc
        ppd.ShowDialog()

    End Sub

    Private Function shortMonthDateformat(ByVal inDate As Date) As String
        Dim strReturn As String = Nothing
        If IsDate(inDate) Then
            strReturn = CStr(Format(DatePart(DateInterval.Day, inDate), "00")) & "-" &
                Mid(MonthName(DatePart(DateInterval.Month, inDate), True), 1, 3) & "-" &
                CStr(Format(DatePart(DateInterval.Year, inDate), "0000"))
        Else
            Return inDate.ToString
        End If
        Return strReturn
    End Function

End Class
