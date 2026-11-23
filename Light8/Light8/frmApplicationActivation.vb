Imports System.Management

Public Class frmApplicationActivation

    Private Const MyProductName As String = "GreatWitsTechnologies"

    Private Function IsKeyValid(ByVal KeyCode As Object, ByRef UserName As Object, ByRef ProdName As String) As Boolean
        Dim BinKey As String
        Dim IsValid As Boolean
        Dim HexKey As String

        IsValid = False

        ' First, decode Base32 string into binary one. Remove any dashes in input string

        BinKey = Base32Dec(RemoveDashes(KeyCode))

        HexKey = BinStrToHexStr(BinKey)
        IsValid = ValidateKeyCode(HexKey, UserName, ProdName & MyProductName)

        IsKeyValid = IsValid

    End Function

    Private Function GetKeyFeat(ByVal KeyCode As Object, ByRef UserName As Object, ByRef ProdName As String) As Integer
        Dim IsValid As Object
        Dim BinKey As String
        Dim FeatBMP As Integer
        Dim HexKey As String

        IsValid = False

        ' First, decode Base32 string into binary one. Remove any dashes in input string

        BinKey = Base32Dec(RemoveDashes(KeyCode))

        ' Check length of BinKey - must be 16 to be valid
        If Len(BinKey) = 16 Then
            HexKey = BinStrToHexStr(BinKey)
            FeatBMP = ExtractKeyFBits(HexKey, UserName, ProdName & MyProductName)
        Else
            FeatBMP = 0
        End If

        GetKeyFeat = FeatBMP

    End Function

    Private Sub btnRegister_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnRegister.Click
        Dim features As Object
        Dim UNameT As String
        Dim SerNoT As String
        Dim LKeyT As String

        UNameT = Trim(txtUserName.Text)
        SerNoT = Trim(txtSerialNumber.Text)
        LKeyT = Trim(txtLicenseCode.Text)

        If IsKeyValid(LKeyT, UNameT, SerNoT) Then
            MessageBox.Show("License Key Okay. Restart the application after this process", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            boolRegistrationSuccessfull = True
            features = GetKeyFeat(LKeyT, UNameT, SerNoT)
            Call DoCheckBoxes(features)
            'Write the details to table instead
            Dim strActiveModules As String = ActiveModules()
            Dim obj As New CommonLibrary.Commons.CommonFunctions


            ' txtOutputText.Text = SSTCryptographer.Encrypt(txtInputText.Text,SetKey());
            Dim strEncryptedModules As String = EncryptDecryptData.SSTCryptographer.Encrypt(strActiveModules, "greatwits")

            Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\gwtlk", False)
            objFileWriter.WriteLine(strEncryptedModules)
            objFileWriter.Close()
            lblStatus.Text = "Key Validated."
            strLicenseData = strEncryptedModules
            End
        Else
            Call DoCheckBoxes(0)
            boolRegistrationSuccessfull = False
            lblStatus.Text = "Invalid Key.  Please try again!"
        End If
    End Sub

    Private Sub DoCheckBoxes(ByVal ChkVal As Integer)
        On Error GoTo RaiseErr
        Check1.CheckState = ChkVal And 1
        Check2.CheckState = CInt(ChkVal And 2) / 2
        Check3.CheckState = CInt(ChkVal And 4) / 4
        Check4.CheckState = CInt(ChkVal And 8) / 8
        Check5.CheckState = CInt(ChkVal And 16) / 16
        Check6.CheckState = CInt(ChkVal And 32) / 32
        Check7.CheckState = CInt(ChkVal And 64) / 64
        Check8.CheckState = CInt(ChkVal And 128) / 128
        Check9.CheckState = CInt(ChkVal And 256) / 256
        Check10.CheckState = CInt(ChkVal And 512) / 512
        Check11.CheckState = CInt(ChkVal And 1024) / 1024
        Check12.CheckState = CInt(ChkVal And 2048) / 2048
        Check13.CheckState = CInt(ChkVal And 4096) / 4096
        Check14.CheckState = CInt(ChkVal And 8192) / 8192
        Check15.CheckState = CInt(ChkVal And 16384) / 16384
        Check16.CheckState = CInt(ChkVal And 32768) / 32768
        Exit Sub
RaiseErr:
        MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & "On Application Licensing", "Licensing Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub frmApplicationActivation_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        GetSerialNumber()
        lblStatus.Text = "Enter Registration Information"
        Check1.Enabled = False
        Check2.Enabled = False
        Check3.Enabled = False
        Check4.Enabled = False
        Check5.Enabled = False
        Check6.Enabled = False
        Check7.Enabled = False
        Check8.Enabled = False
        Check9.Enabled = False
        Check10.Enabled = False
        Check11.Enabled = False
        Check12.Enabled = False
        Check13.Enabled = False
        Check14.Enabled = False
        Check15.Enabled = False
        Check16.Enabled = False
        Call DoCheckBoxes(0)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        End
    End Sub

    Private Function ActiveModules() As String
        Dim strReturn As String = Nothing
        If Check1.Checked = True Then strReturn = strReturn & "01-"
        If Check2.Checked = True Then strReturn = strReturn & "02-"
        If Check3.Checked = True Then strReturn = strReturn & "03-"
        If Check4.Checked = True Then strReturn = strReturn & "04-"
        If Check5.Checked = True Then strReturn = strReturn & "05-"
        If Check6.Checked = True Then strReturn = strReturn & "06-"
        If Check7.Checked = True Then strReturn = strReturn & "07-"
        If Check8.Checked = True Then strReturn = strReturn & "08-"
        If Check9.Checked = True Then strReturn = strReturn & "09-"
        If Check10.Checked = True Then strReturn = strReturn & "10-"
        If Check11.Checked = True Then strReturn = strReturn & "11-"
        If Check12.Checked = True Then strReturn = strReturn & "12-"
        If Check13.Checked = True Then strReturn = strReturn & "13-"
        If Check14.Checked = True Then strReturn = strReturn & "14-"
        If Check15.Checked = True Then strReturn = strReturn & "15-"
        If Check16.Checked = True Then strReturn = strReturn & "16-"
        If Not String.IsNullOrEmpty(strReturn) Then
            If strReturn.Length > 2 Then
                strReturn = Mid(strReturn, 1, strReturn.Length - 1)
            End If
        End If
        Return strReturn
    End Function

    Private Sub GetSerialNumber()
        Dim hd As New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
        For Each dvs As ManagementObject In hd.Get()
            Dim serial As String = dvs("SerialNumber").ToString()
            txtSerialNumber.Text = Trim(serial)
            Exit Sub
        Next
    End Sub

End Class
