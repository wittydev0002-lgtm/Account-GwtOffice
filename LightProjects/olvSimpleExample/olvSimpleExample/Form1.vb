Imports BrightIdeasSoftware

Public Class Form1

    Public Class Person
        Public Property name As String
        Public Property last As String
        Public Property phone As String
        Public Property address As String
    End Class

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim LvItm As New Person With {.name = "John",
                                      .last = "Smith",
                                      .phone = "555-69997-44",
                                      .address = "Main Str. 1"}
        Dim LvLst As New List(Of Person)
        LvLst.Add(LvItm)

        ObjectListView1.View = View.Details
        ObjectListView1.Columns.Add(New OLVColumn With {.Text = "Name",
                                                        .AspectName = "name"})
        ObjectListView1.Columns.Add(New OLVColumn With {.Text = "Last Name",
                                                        .AspectName = "last"})
        ObjectListView1.Columns.Add(New OLVColumn With {.Text = "Phone",
                                                        .AspectName = "phone"})
        ObjectListView1.Columns.Add(New OLVColumn With {.Text = "Address",
                                                        .AspectName = "address"})
        ObjectListView1.SetObjects(LvLst)
    End Sub
End Class
