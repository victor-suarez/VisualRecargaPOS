Public Class frmError
    Friend Sub SetMessage(ByVal strCode As String, ByVal strError As String, Optional ByRef strMessage As String = Nothing)
        lblMensajeError.Text = strCode & "-" & strError
        If Not strMessage Is Nothing Then lblError.Text = strMessage Else lblError.Text = ""
    End Sub

    Private Sub frmError_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 121 Then e.Handled = True : Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class