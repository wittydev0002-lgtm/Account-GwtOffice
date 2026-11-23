Public Class Form1

    'Private Declare Function FindWindow _
    'Lib "user32" Alias "FindWindowA" _
    '(ByVal lpClassName As String, ByVal lpWindowName As String) As Long

    'Private Declare Function SetParent _
    '    Lib "user32" (ByVal nWndChild As Long, _
    '    ByVal nWndNewParent As Long) As Long

    'Private Declare Function ShellExecute _
    '    Lib "shell32.dll" Alias "ShellExecuteA" _
    '    (ByVal hwnd As Long, ByVal lpOperation As String, _
    '     ByVal lpFile As String, ByVal lpParameters As String, _
    '     ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

    'Private Declare Function MoveWindow _
    '    Lib "user32" (ByVal hwnd As Long, _
    '                  ByVal x As Long, ByVal y As Long, _
    '                  ByVal nWidth As Long, ByVal nHeight As Long, _
    '                  ByVal bRepaint As Long) As Long

    'Private Const SW_SHOWNORMAL = 1

    'Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
    '    Dim hw
    '    ShellExecute(Me.Handle, vbNullString, "notepad.exe", vbNullString, "C:\", SW_SHOWNORMAL)
    '    hw = FindWindow(vbNullString, "Untitled-Notepad")
    '    SetParent(hw, Me.Handle)
    '    MoveWindow(hw, 0, 0, Me.Width, Me.Height, 1)
    'End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.applicationControl1.ExeName = "C:\Embassy\AccountingLight\AccountingLight\bin\Debug\AccountingLight.exe"
    End Sub

End Class