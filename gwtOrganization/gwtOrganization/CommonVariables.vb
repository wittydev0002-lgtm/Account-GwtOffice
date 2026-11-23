Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonVariables

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

    Public Sub ShowErrorMessage()
        MessageBox.Show(strErrorMessages, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub


End Module
