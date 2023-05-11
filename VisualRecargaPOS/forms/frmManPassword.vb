Option Strict On
Friend Class frmManPassword
    Private Function ValEntReq() As Boolean
        ValEntReq = False
        If txtOldPasswd.Text = "" Then
            MessageBox.Show("Debe transcribir su contraseña actual", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Console.Beep()
            txtOldPasswd.Focus()
            Exit Function
        End If
        If glPasswd <> txtOldPasswd.Text Then
            MessageBox.Show("La contraseña actual no coincide", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Console.Beep()
            txtOldPasswd.Focus()
            Exit Function
        End If
        If txtNewPasswd.Text.Length < 6 Then
            MessageBox.Show("La contraseña debe ser minimo de 6 y maximo de 15 caracteres", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Console.Beep()
            txtNewPasswd.Focus()
            Exit Function
        End If
        If txtNewPasswd.Text = "" Then
            MessageBox.Show("Debe transcribir su nueva contraseña", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Console.Beep()
            txtNewPasswd.Focus()
            Exit Function
        End If
        If txtConPasswd.Text = "" Then
            MessageBox.Show("Debe confirmar su nueva contraseña", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Console.Beep()
            txtConPasswd.Focus()
            Exit Function
        End If
        If txtNewPasswd.Text <> txtConPasswd.Text Then
            MessageBox.Show("Su confirmación no coincide con su nueva contraseña", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Console.Beep()
            txtNewPasswd.Focus()
            Exit Function
        End If
        ValEntReq = True
    End Function

    Private Sub btnCambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        Dim clC As New clsCesar
        Cursor.Current = Cursors.AppStarting
        If Not ValEntReq() Then Exit Sub
        Try
            clC.cSemilla = seed1 & seed2 & seed3
            glSQL = "EXEC SpUpdPassword @Login='" & glUser & "',@PasswUser='" & clC.EncriptarCs(txtNewPasswd.Text.ToUpper) & "'"
            iRET = ExecSP(glSQL, False)
            glPasswd = txtNewPasswd.Text
            MessageBox.Show("Nueva contraseña establecida!", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor.Current = Cursors.Default
            Me.Dispose()
        Catch ex As Exception
            Dim strFixMsg As String = "Problemas para actualizar la contraseña. La contraseña no se actualizó."
            Call MensajeError(ex, strFixMsg)
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frmManPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = 1
        Me.Top = 1
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtOldPasswd.KeyPress, txtNewPasswd.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then Me.SelectNextControl(DirectCast(sender, TextBox), True, True, False, False) : e.Handled = True
    End Sub

    Private Sub txtConPasswd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConPasswd.GotFocus
        txtConPasswd.SelectAll()
    End Sub

    Private Sub txtConPasswd_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtConPasswd.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then Call btnCambiar_Click(sender, e) : e.Handled = True
    End Sub

    Private Sub txtNewPasswd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNewPasswd.GotFocus
        txtNewPasswd.SelectAll()
    End Sub

    Private Sub txtOldPasswd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOldPasswd.GotFocus
        txtOldPasswd.SelectAll()
    End Sub
End Class