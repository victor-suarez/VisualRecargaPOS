Option Strict On
Friend Class frmMensaje
    Friend rsMsg As ADODB.Recordset
    Friend nRET As Integer

    Private Sub CargarMensaje()
        Me.Text = "Mensaje " & lblNroMsg.Text & " de " & nRET
        If Not rsMsg.EOF Then
            lblFechaEnvio.Text = CDate(rsMsg("FecEnvio").Value).ToString("dd/MM/yyyy")
            lblEnviadoPor.Text = rsMsg("EnviadoPor").Value.ToString
            txtMensaje.Clear()
            txtMensaje.AppendText("Asunto : " & rsMsg("Titulo").Value.ToString & vbCrLf)
            txtMensaje.AppendText(rsMsg("Mensaje").Value.ToString)
            txtMensaje.Tag = rsMsg("ID_Mensaje").Value
            rsMsg.MoveNext()
        Else
            txtMensaje.Tag = ""
        End If
        If CInt(lblNroMsg.Text) < nRET Then
            btnLeido.Text = "&Siguiente"
        Else
            btnLeido.Text = "&Leido"
        End If
    End Sub

    Private Sub RecibirMensaje()
        Try
            rsMsg = New ADODB.Recordset
            rsMsg.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rsMsg.Open("EXEC SpConMensajes @ID_Vendedor=" & glCodVen & ",@ID_Estacion=" & glEstacion, Conx, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rsMsg.State = ADODB.ObjectStateEnum.adStateOpen Then nRET = rsMsg.RecordCount
        Catch ex As Exception
            Dim strFixMsg As String = "Error recibiendo mensaje."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Sub btnLeido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeido.Click
        Dim Idx As Integer
        If txtMensaje.Tag.ToString = "" Then Exit Sub
        Try
            Call Conx.Execute("EXEC SpUpdMensajes @ID_Mensaje=" & txtMensaje.Tag.ToString & ",@UsrUpd='" & glUser & "'")
            If btnLeido.Text = "&Siguiente" Then
                lblNroMsg.Text = (CInt(lblNroMsg.Text) + 1).ToString
                Call CargarMensaje()
            Else
                For Idx = 0 To (Me.Height + 3)
                    Me.Top = Me.Top + 3
                Next Idx
                rsMsg.Close()
                Me.Dispose()
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Error marcando mensaje como leído."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Sub frmMensaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = mdiRecargaPOS.Bottom - 3
        Me.Left = mdiRecargaPOS.Right - Me.Width - 12
        'tmrRecibirMsg.Start()
        Call RecibirMensaje()
        tmrMensaje.Start()
    End Sub

    Private Sub tmrMensaje_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMensaje.Tick
        tmrMensaje.Stop()
        Dim Limit As Integer = mdiRecargaPOS.Bottom - Me.Height - mdiRecargaPOS.StatusStrip.Height - 60
        Me.lblNroMsg.Text = "1"
        Call CargarMensaje()
        For iTop As Integer = Me.Top To Limit Step -4
            Me.Top = iTop
        Next iTop
        Me.Refresh()
    End Sub

    Private Sub tmrRecibirMsg_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrRecibirMsg.Tick
        tmrRecibirMsg.Stop()
        Call RecibirMensaje()
        tmrMensaje.Start()
    End Sub
End Class