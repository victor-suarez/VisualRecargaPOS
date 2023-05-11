Option Strict On
Public Class frmResetRegistro
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Not Me.IsMdiChild Then End
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        My.Settings.Reset()
        End
    End Sub

    Private Sub frmResetRegistro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblHost.Text = glIPServer
        Me.lblGrupo.Text = glGrupo
        Me.lblCodAge.Text = glCodVen.ToString
        Me.lblNomAge.Text = glNomVen
        Me.lblTaquilla.Text = glEstacion.ToString("00")
    End Sub
End Class