Public Class frmVerificar
    Friend lcCodVen As Integer
    Friend lcEstacion As Short
    Friend lcOperadora As String
    Friend lcCodProd As Integer
    Friend lcNomProd As String
    Friend lcCedula As String
    Friend lcPrefijo As String
    Friend lcNumero As String
    Friend lcMonto As Integer
    Friend lcMensaje As String
    Friend lcUser As String
    Friend lcCedulaVisible As Boolean

    Dim fImp As frmImpresora

    Private Sub ImprimirRecibo(arrRespuesta() As String, strVoucher As String)
        Dim strCtrlChar As Char = "", vChar As Char = "", vCtrl As String = ""
        Dim strRecibo As String = "", strToSearch As String = ""
        Dim prnVoucher As String = strVoucher
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        fImp = New frmImpresora
        fImp.mClear()

        fImp.mPrint("COPIA - CLIENTE", frmImpresora.prnJustified.justCenter)
        fImp.mPrint()
        ' SUSTITUCIONES:
        ' Caracteres de control
        prnVoucher.Replace("<P1>", "").Replace("</P1>", "")
        prnVoucher.Replace("<CC>", "").Replace("</CC>", "")
        prnVoucher.Replace("<OC>", "").Replace("</OC>", "")
        prnVoucher.Replace("<UT>", "").Replace("</UT>", "")
        prnVoucher.Replace("<LF>", vbCrLf).Replace("|", " ")
        ' Campos de la respuesta
        For idxFld As Integer = 0 To arrRespuesta.GetUpperBound(0)
            strToSearch = "@F[" & (idxFld + 1).ToString("00") & "]"
            'Sólo dos casos especiales: La fecha y La hora.
            If idxFld = 12 Then
                prnVoucher.Replace(strToSearch, glFecHora.ToShortDateString)
            ElseIf idxFld = 13 Then
                prnVoucher.Replace(strToSearch, glFecHora.ToShortTimeString)
            Else
                prnVoucher.Replace(strToSearch, arrRespuesta(idxFld))
            End If
        Next
        ' Campos de entrada (son pocos y cableados)
        prnVoucher.Replace("@C[01]", "VISUAL RECARGA")
        prnVoucher.Replace("@C[02]", lcOperadora)
        prnVoucher.Replace("@C[03]", "CARACAS")
        prnVoucher.Replace("@C[04]", lcPrefijo & " " & lcNumero)
        prnVoucher.Replace("@C[05]", lcNomProd)
        prnVoucher.Replace("@C[10]", lcMonto.ToString("###,###,##0.00"))
        prnVoucher.Replace("@C[11]", lcMensaje.Replace("|", vbCrLf))
        fImp.mPrint(prnVoucher)
        fImp.MdiParent = Me.MdiParent
        fImp.Show()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Function VerificaCampo(ByRef Rs As ADODB.Recordset, Campo As String) As Boolean
        Dim strCampos As String = "", Idx As Integer
        For Idx = 0 To (Rs.Fields.Count - 1)
            strCampos = strCampos & Rs.Fields(Idx).name
        Next Idx
        If strCampos.IndexOf(Campo) <> 0 Then Return True Else Return False
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim lcRespCode As String = ""
        Dim lcSeqNum As Integer = 0
        Dim lcResponse As String = ""
        Dim lcVoucher As String = ""
        Dim lcError As String = ""
        Dim lcMensaje As String = ""
        Dim arrRespuesta() As String = Nothing

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        pnlBotones.Visible = False
        tmrBlink.Start()
        Try
            glSQL = "EXEC PosInsTransaccionesTemp3"
            glSQL = glSQL & " @ID_Vendedor=" & lcCodVen.ToString
            glSQL = glSQL & ",@ID_Estacion=" & lcEstacion.ToString
            glSQL = glSQL & ",@ID_Producto" & lcCodProd.ToString
            glSQL = glSQL & ",@CedulaCliente='" & lcCedula & "'"
            glSQL = glSQL & ",@TelefonoCel='" & lcPrefijo & lcNumero & "'"
            glSQL = glSQL & ",@Usuario='" & lcUser & "'"
            glSQL = glSQL & ",@Precio=" & lcMonto.ToString
            iRET = ExecSP(glSQL, True)
            If RecSet.EOF Then
                MessageBox.Show("No se realizó la venta de la recarga.", "Error en la recarga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Me.Close()
            End If
            lcRespCode = IIf(IsDBNull(RecSet("RespCode").Value), "NL", RecSet("RespCode").Value).ToString
            lcSeqNum = RecSet("SeqNum").Value.ToString
            lcResponse = RecSet("Response").Value.ToString
            lcVoucher = IIf(IsDBNull(RecSet("Voucher1").Value), "", RecSet("Voucher1").Value).ToString
            lcVoucher = lcVoucher & IIf(IsDBNull(RecSet("Voucher2").Value), "", RecSet("Voucher2").Value).ToString
            If VerificaCampo(RecSet, "Voucher3") Then lcVoucher = lcVoucher & IIf(IsDBNull(RecSet("Voucher3").Value), "", RecSet("Voucher3").Value).ToString
            If VerificaCampo(RecSet, "Voucher4") Then lcVoucher = lcVoucher & IIf(IsDBNull(RecSet("Voucher4").Value), "", RecSet("Voucher4").Value).ToString
            rsetClose(RecSet)
            arrRespuesta = lcResponse.Split(" ")

            If arrRespuesta.GetUpperBound(0) >= 17 Then
                lcError = arrRespuesta(17)
            Else
                lcError = ""
            End If
            If arrRespuesta.GetUpperBound(0) >= 18 Then
                lcMensaje = arrRespuesta(18)
            Else
                lcMensaje = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Problemas al procesar la venta de la recarga. Por favor intente de nuevo." & vbCrLf & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.Close()
        End Try

        tmrBlink.Stop()

        'RESPUESTA SIN SALDO
        If lcRespCode = "AG" Then 'SIN SALDO
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Dim frmSS As New frmSinSaldo
            frmSS.MdiParent = Me.MdiParent
            frmSS.ShowDialog()
            Me.Close()
        ElseIf lcRespCode = "00" Then
            Call ImprimirRecibo(arrRespuesta, lcVoucher)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Else 'CUALQUIER RESPUESTA DE ERROR
            Call MostrarRespuesta(lcRespCode, lcError, lcError)
        End If
        lblProcesando.Visible = False
        pnlBotones.Visible = True

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmVerificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picLogo.Image = frmVenta.picLogo.Image
        picLogo.Refresh()
        lblProducto.Text = lcNomProd
        lblPrecio.Text = lcMonto.ToString("Bs ##,###,##0.00")
        lblTitCedula.Visible = lcCedulaVisible
        lblCedula.Visible = lcCedulaVisible
        If lblCedula.Visible Then lblCedula.Text = CLng(lcCedula).ToString("###,###,###")
        lblNumero.Text = lcPrefijo & " " & lcNumero
    End Sub

    Private Sub tmrBlink_Tick(sender As Object, e As EventArgs) Handles tmrBlink.Tick
        lblProcesando.Visible = Not lblProcesando.Visible
    End Sub
End Class