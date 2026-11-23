Public Class AdvancedKryptonDataGridView

    Inherits ComponentFactory.Krypton.Toolkit.KryptonDataGridView

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Return Then
            keyData = Keys.Tab
            With msg
                .WParam = Keys.Tab
            End With
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Return Then
            keyData = Keys.Tab
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

End Class
