Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim rp As New SmartRichReportWriter.RichReportWriter
        With rp
            .strMainHeader1 = "Header 1"
            .strMainHeader2 = "Header 2"
            .strMainHeader3 = "Header 3"
            .intTitleXposition = 250
            .TitleColor = Color.Black
            .Data = "<row><data>text=Embassy;X=100;Y=15;FN=Arial;FS=6;FC=red;FB=False;FI=False;FU=False;BC=White;CH=20;AL=0;CW=200</data></row>" & _
                "<row><data>text=Phiri;X=300;Y=15;FN=Tahoma;FS=18;FC=Black;FB=True;FI=True;FU=True;BC=WhiteSmoke;CH=20;AL=0;CW=300</data></row>" & _
                "<row><data>text=Fiona Phiri;X=150;Y=15;FN=Arial;FS=12;FC=black;FB=true;FI=False;FU=False;BC=White;CH=20;AL=0;CW=100</data>" & _
                "<data>text=5663 Knowe, Norton;X=250;Y=15;FN=Arial;FS=12;FC=black;FB=true;FI=False;FU=False;BC=White;CH=20;AL=0;CW=200</data></row>"
            .boolDrawBorder = True
            .GridColor = Color.Black
            .HorizontalLines = True
            .FooterColor = Color.Black
            .strFooterCaption = "Embassy and Associates"
            .intFooterXposition = 100
            .intPageNumXposition = 700
            .HeaderRow = "<header>text=HEADER-1;X=100;Y=15;FN=Tahoma;FS=18;FC=Black;FB=True;FI=True;FU=True;BC=WhiteSmoke;CH=20;AL=0;CW=300</header>" & _
                "<header>text=HEADER-2;X=200;Y=15;FN=Tahoma;FS=18;FC=Black;FB=True;FI=True;FU=True;BC=WhiteSmoke;CH=20;AL=0;CW=300</header>" & _
                "<header>text=HEADER-3;X=300;Y=15;FN=Tahoma;FS=18;FC=Black;FB=True;FI=True;FU=True;BC=WhiteSmoke;CH=20;AL=0;CW=300</header>"
        End With
        Dim ppd As New PrintPreviewDialog
        ppd.Document = rp
        ppd.ShowDialog()
    End Sub

End Class
