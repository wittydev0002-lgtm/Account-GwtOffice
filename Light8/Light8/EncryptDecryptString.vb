Imports System.Security.Cryptography

Module EncryptDecryptString

    Public NotInheritable Class Simple3Des

        Private TripleDes As New TripleDESCryptoServiceProvider

        Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
            Dim sha1 As New SHA1CryptoServiceProvider
            'Hash the key
            Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
            Dim hash() As Byte = sha1.ComputeHash(keyBytes)

            'Truncate or pad the hash
            ReDim Preserve hash(length - 1)
            Return hash
        End Function

        Sub New(ByVal key As String)
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
        End Sub

        Public Function EncryptData(ByRef plainText As String) As String

            'Convert the plain text to byte array
            Dim PlainTextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plainText)

            'Create the stream
            Dim ms As New System.IO.MemoryStream

            'Create the encoder to write to the stream
            Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

            'Use the crypto stream to write the byte array to the stream
            encStream.Write(PlainTextBytes, 0, PlainTextBytes.Length)
            encStream.FlushFinalBlock()

            'Convert the encrypted stream to a printable string
            Return Convert.ToBase64String(ms.ToArray)

        End Function

        Public Function DecryptData(ByVal EncryptedText As String) As String

            'Convert the encrypted text to byte array
            Dim EncryptedBytes() As Byte = Convert.FromBase64String(EncryptedText)

            'Create the stream
            Dim ms As New System.IO.MemoryStream

            'Create the decoder to write to the stream
            Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

            'Use the crypto stream to write the byte array to the stream.
            decStream.Write(EncryptedBytes, 0, EncryptedBytes.Length)
            decStream.FlushFinalBlock()

            'Convert the plain text stream to a string
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)

        End Function

    End Class
    
End Module