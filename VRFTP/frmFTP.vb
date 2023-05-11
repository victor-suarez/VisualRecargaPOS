Friend Class frmFTP
    Public bCancelar As Boolean = False

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        bCancelar = True
    End Sub
End Class