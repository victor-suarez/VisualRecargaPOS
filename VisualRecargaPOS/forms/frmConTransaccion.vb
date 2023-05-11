Public Class frmConTransaccion

    Private Sub ConsultarTicket(ByVal NroTicket As String)
        Dim item As ListViewItem = Nothing
        Cursor.Current = Cursors.AppStarting
        Call ClearCrt()
        txtNroTicket.Text = NroTicket
        glSQL = "EXEC PosQryTransaccionesVendedor " & NroTicket & "," & glCodVen.ToString
        Try
            iRET = ExecSP(glSQL, True)
            If Not RecSet.EOF Then
                For idxFld = 0 To (RecSet.Fields.Count - 1)
                    Select Case RecSet(idxFld).Name
                        Case "ID_Vendedor"
                            item = lstDatos.Items.Add("Vendedor")
                            item.SubItems.Add(RecSet("ID_Vendedor").Value.ToString.Trim & " - " & RecSet("Nombre").Value.ToString)
                        Case "Fecha"
                            item = lstDatos.Items.Add("Fecha")
                            item.SubItems.Add(CDate(RecSet("Fecha").Value).ToShortDateString)
                        Case "Hora"
                            item = lstDatos.Items.Add("Hora")
                            item.SubItems.Add(CDate(RecSet("Hora").Value).ToShortTimeString)
                        Case "Monto"
                            item = lstDatos.Items.Add("Monto")
                            item.SubItems.Add(CInt(RecSet("Monto").Value).ToString("###,###,##0.00"))
                        Case "Comision"
                            item = lstDatos.Items.Add("Comisión")
                            item.SubItems.Add(CDec(RecSet("Comision").Value).ToString("#,##0.00"))
                        Case "ComisionPorc"
                            item = lstDatos.Items.Add("Porcentaje")
                            item.SubItems.Add(CDec(RecSet("ComisionPorc").Value).ToString("#0.00") & "%")
                        Case "Producto"
                            item = lstDatos.Items.Add("Producto")
                            item.SubItems.Add(RecSet("Producto").Value.ToString)
                        Case "CedulaCliente"
                            item = lstDatos.Items.Add("Cliente")
                            item.SubItems.Add(RecSet("CedulaCliente").Value.ToString)
                        Case "TelefonoCel"
                            item = lstDatos.Items.Add("Teléfono/Código")
                            item.SubItems.Add(RecSet("TelefonoCel").Value.ToString)
                        Case "Status"
                            lblStatus.Tag = RecSet("Status").Value.ToString
                            If RecSet("Status").Value.ToString = "AP" Then
                                lblStatus.Text = "APROBADA"
                                lblStatus.ForeColor = Color.Green
                            ElseIf RecSet("Status").Value.ToString = "RZ" Then
                                lblStatus.Text = "RECHAZADA"
                                lblStatus.ForeColor = Color.Red
                            ElseIf RecSet("Status").Value.ToString = "RV" Then
                                lblStatus.Text = "REVERSADA"
                                lblStatus.ForeColor = Color.Red
                            End If
                    End Select
                Next
            Else
                lblStatus.Text = "NO ENCOTRADA"
                lblStatus.ForeColor = Color.Gray
            End If
        Catch ex As Exception
            MessageBox.Show("Problema consultando ticket. Por favor intente de nuevo." & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '        lstDatos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ClearCrt()
        txtNroTicket.Text = ""
        lblStatus.Text = ""
        lstDatos.Items.Clear()
    End Sub

    Private Sub ReImprimirTicket(ByVal NroTransaccion As String)
        Dim arrRespuesta() As String = Nothing
        Dim strToSearch As String = ""
        Dim prnVoucher As String = ""
        glSQL = "EXEC SpPosQryRespuesta @NroTransaccion=" & NroTransaccion
        iRET = ExecSP(glSQL, True)
        If Not RecSet.EOF Then
            arrRespuesta = RecSet("Respuesta").Value.ToString.Split(" ")
            prnVoucher = RecSet("Voucher").Value.ToString

            Dim fImp = New frmImpresora
            Cursor.Current = Cursors.AppStarting
            fImp.iPrinterWidth = 40
            fImp.mClear()

            fImp.mPrint("REIMPRESION - TICKET", frmImpresora.prnJustified.justCenter)
            fImp.mPrint()
            ' SUSTITUCIONES:
            ' Caracteres de control
            prnVoucher = prnVoucher.Replace("<P1>", "").Replace("</P1>", "")
            prnVoucher = prnVoucher.Replace("<CC>", "").Replace("</CC>", "")
            prnVoucher = prnVoucher.Replace("<OC>", "").Replace("</OC>", "")
            prnVoucher = prnVoucher.Replace("<UT>", "").Replace("</UT>", "")
            prnVoucher = prnVoucher.Replace("<LF>", vbCrLf).Replace("|", " ")
            ' Campos de la respuesta
            For idxFld As Integer = 0 To arrRespuesta.GetUpperBound(0)
                strToSearch = "@F[" & (idxFld + 1).ToString("00") & "]"
                If prnVoucher.Contains(strToSearch) Then
                    'Sólo dos casos especiales: La fecha y La hora.
                    If idxFld = 12 Then
                        prnVoucher = prnVoucher.Replace(strToSearch, DateISOtoDate(arrRespuesta(idxFld)))
                    ElseIf idxFld = 13 Then
                        prnVoucher = prnVoucher.Replace(strToSearch, TimeISOtoTime(arrRespuesta(idxFld)))
                    Else
                        prnVoucher = prnVoucher.Replace(strToSearch, arrRespuesta(idxFld))
                    End If
                End If
            Next
            ' Campos de entrada (son pocos y cableados)
            If prnVoucher.Contains("@C[01]") Then prnVoucher = prnVoucher.Replace("@C[01]", "VISUAL RECARGA")
            If prnVoucher.Contains("@C[02]") Then prnVoucher = prnVoucher.Replace("@C[02]", RecSet("Operadora").Value.ToString)
            If prnVoucher.Contains("@C[03]") Then prnVoucher = prnVoucher.Replace("@C[03]", "CARACAS")
            If prnVoucher.Contains("@C[04]") Then prnVoucher = prnVoucher.Replace("@C[04]", NroTransaccion)
            If prnVoucher.Contains("@C[05]") Then prnVoucher = prnVoucher.Replace("@C[05]", RecSet("Producto").Value.ToString)
            If prnVoucher.Contains("@C[10]") Then prnVoucher = prnVoucher.Replace("@C[10]", CInt(RecSet("Monto").Value).ToString("###,###,##0.00"))
            ' Si es un rechazo y existe el campo 17, lo coloco en el ticket.
            If lblStatus.Tag.ToString = "RZ" And arrRespuesta.GetUpperBound(0) >= 17 Then
                prnVoucher = prnVoucher & arrRespuesta(17) & vbCrLf
            End If
            If prnVoucher.Contains("@C[11]") Then prnVoucher = prnVoucher.Replace("@C[11]", RecSet("MsgTicket").Value.ToString.Replace("|", vbCrLf))
            If prnVoucher.Contains("@C[12]") Then prnVoucher = prnVoucher.Replace("@C[12]", DateISOtoDate(arrRespuesta(12)))
            fImp.mPrint(prnVoucher)
            fImp.MdiParent = Me.MdiParent
            fImp.Show()
        Else
            MessageBox.Show("El mensaje de respuesta no se encuentra en la base de datos." & vbCrLf & "No se puede imprimir la copia del ticket.", "Repuesta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnReImprimir_Click(sender As Object, e As EventArgs) Handles btnReImprimir.Click
        If txtNroTicket.Text.Trim = "" Then Exit Sub
        Call ReImprimirTicket(txtNroTicket.Text)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frmConTransaccion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 1
        Me.Left = 1
        Call ClearCrt()
    End Sub

    Private Sub txtNroTicket_GotFocus(sender As Object, e As EventArgs) Handles txtNroTicket.GotFocus
        txtNroTicket.SelectAll()
    End Sub

    Private Sub txtNroTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroTicket.KeyPress
        Dim NroTck As Long
        If vbNumbers.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Long.TryParse(txtNroTicket.Text, NroTck) Then
                Call ConsultarTicket(txtNroTicket.Text)
            Else
                MessageBox.Show("El número de ticket debe ser numérico", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Call ClearCrt()
                txtNroTicket.Focus()
            End If
        End If
    End Sub
End Class