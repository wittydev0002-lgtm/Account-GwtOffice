'   Database backup utility:
'   ========================
'   Copyright (C) 2007  Shabdar Ghata 
'   Email : ghata2002@gmail.com
'   URL : http://www.shabdar.org

'   This program is free software: you can redistribute it and/or modify
'   it under the terms of the GNU General Public License as published by
'   the Free Software Foundation, either version 3 of the License, or
'   (at your option) any later version.

'   This program is distributed in the hope that it will be useful,
'   but WITHOUT ANY WARRANTY; without even the implied warranty of
'   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'   GNU General Public License for more details.

'   You should have received a copy of the GNU General Public License
'   along with this program.  If not, see <http://www.gnu.org/licenses/>.

'   This program comes with ABSOLUTELY NO WARRANTY.


Public Class clsCommon
    Public Shared Sub Format_Grid_Restore(ByRef dg As DataGridView)
        Dim i As Integer
        If Not IsNothing(dg.DataSource) Then
            For i = 0 To dg.Columns.Count - 1
                If i = 0 Then
                    dg.Columns(0).Width = 220
                    dg.Columns(0).ReadOnly = True
                End If
                If i = 1 Then
                    dg.Columns(1).Width = 80
                    dg.Columns(1).ReadOnly = False
                End If
                If i = 2 Then
                    dg.Columns(2).Visible = False
                    dg.Columns(2).ReadOnly = False
                    'dg.Columns(2).Visible = False
                End If
                If i = 3 Then
                    dg.Columns(3).Width = 300
                    dg.Columns(3).ReadOnly = False
                End If
            Next
            dg.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dg.AllowUserToAddRows = False
            dg.AllowUserToDeleteRows = False
            dg.AllowUserToResizeRows = False
        End If
    End Sub
    Public Shared Sub Format_Grid_Backup(ByRef dg As DataGridView)
        Dim i As Integer
        If Not IsNothing(dg.DataSource) Then
            For i = 0 To dg.Columns.Count - 1
                If i = 0 Then
                    dg.Columns(0).Width = 150
                    dg.Columns(0).ReadOnly = True
                End If
                If i = 1 Then
                    dg.Columns(1).Width = 60
                    dg.Columns(1).ReadOnly = False
                End If
                If i = 2 Then
                    dg.Columns(2).Width = 150
                    dg.Columns(2).ReadOnly = False
                    'dg.Columns(2).Visible = False
                End If
                If i = 3 Then
                    dg.Columns(3).Width = 150
                    dg.Columns(3).ReadOnly = False
                End If
                If i = 4 Then
                    dg.Columns(4).Width = 100
                    dg.Columns(4).ReadOnly = False
                    dg.Columns(4).Visible = False
                End If
                If i = 5 Then
                    dg.Columns(5).Width = 100
                    dg.Columns(5).ReadOnly = False
                End If
                If i = 6 Then
                    dg.Columns(6).Width = 100
                    dg.Columns(6).ReadOnly = False
                End If
            Next
            dg.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dg.AllowUserToAddRows = False
            dg.AllowUserToDeleteRows = False
            dg.AllowUserToResizeRows = False
        End If
    End Sub
    Public Shared Function AskDirectory() As String
        Dim folderBrowse As New FolderBrowserDialog
        If folderBrowse.ShowDialog() = DialogResult.OK Then
            Return folderBrowse.SelectedPath
        Else
            Return ""
        End If
    End Function

    Public Shared Function AskSaveAsFile() As String
        Dim fileD As New SaveFileDialog
        fileD.Filter = "Zip Files | *.zip"
        If fileD.ShowDialog() = DialogResult.OK Then
            Return fileD.FileName
        Else
            Return ""
        End If
    End Function
    Public Shared Function AskOpenFile() As String
        Dim fileD As New OpenFileDialog
        fileD.Filter = "Zip Files | *.zip"
        If fileD.ShowDialog() = DialogResult.OK Then
            Return fileD.FileName
        Else
            Return ""
        End If
    End Function

End Class
