Option Strict On
Imports Microsoft.VisualBasic
Public Class frmConTrEnEspera
    Private Sub CargarTransacciones()
        Dim rsTrEE As New ADODB.Recordset
        Dim item As ListViewItem
        Dim hStart As DateTime = Now
        lvwTransacciones.Items.Clear()
        glSQL = "EXEC [SpQryTransaccEnProceso] " & glCodVen.ToString & "," & glEstacion.ToString
        '''' DATA DE PRUEBA!!!
        '''''glSQL = "EXEC [SpQryTransaccEnProceso] "
        rsTrEE = Conx.Execute(glSQL)
        If Not rsTrEE.EOF Then
            Do While Not rsTrEE.EOF
                item = lvwTransacciones.Items.Add(rsTrEE("NroTransaccion").Value.ToString)
                item.SubItems.Add(rsTrEE("Operadora").Value.ToString)
                item.SubItems.Add(rsTrEE("Numero").Value.ToString)
                item.SubItems.Add(rsTrEE("Monto").Value.ToString)
                item.SubItems.Add(CDate(rsTrEE("Hora").Value).ToString("HH:mm:ss"))
                item.SubItems.Add(rsTrEE("Segundos").Value.ToString)
                item.SubItems.Add(rsTrEE("Estatus").Value.ToString)
                item.SubItems.Add(If(IsDBNull(rsTrEE("CodError").Value), "", rsTrEE("CodError").Value).ToString)
                item.BackColor = If(rsTrEE("Tipo").Value.ToString = "T", Color.Green, lvwTransacciones.BackColor)
                rsTrEE.MoveNext()
            Loop
        End If
        rsTrEE.Close()
        rsTrEE = Nothing
    End Sub

    Private Sub ReImprimirTicket(ByVal NroTransaccion As String, ByVal Status As String)
        Dim arrRespuesta() As String = Nothing
        Dim strToSearch As String = ""
        Dim prnVoucher As String = ""
        glSQL = "EXEC SpPosQryRespuesta @NroTransaccion=" & NroTransaccion
        iRET = ExecSP(glSQL, True)
        If Not RecSet.EOF Then
            arrRespuesta = RecSet("Respuesta").Value.ToString.Split(" "c)
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
            If Status <> "AP" And arrRespuesta.GetUpperBound(0) >= 17 Then
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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If lvwTransacciones.SelectedItems.Count = 0 Then Exit Sub
        Dim item As ListViewItem = lvwTransacciones.SelectedItems(0)
        If item.SubItems(6).Text = "AP" Then
            Call ReImprimirTicket(item.Text, item.SubItems(6).Text)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmConTrEnEspera_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        lblHora.ForeColor = Color.Red
        tmrConsulta.Stop()
    End Sub

    Private Sub frmConTrEnEspera_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        lblHora.ForeColor = SystemColors.ControlText
        tmrConsulta.Start()
    End Sub

    Private Sub frmConTrEnEspera_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Left = 1
        Me.Top = Me.MdiParent.Bottom - Me.Height - 112
        lblHora.Text = Now.ToString("HH:mm:ss") : lblHora.Refresh()
        Call CargarTransacciones()
    End Sub

    Private Sub lvwTransacciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwTransacciones.SelectedIndexChanged
        Dim item As ListViewItem = Nothing
        If lvwTransacciones.SelectedItems.Count > 0 Then
            item = lvwTransacciones.SelectedItems(0)
            Try
                If Not IsNothing(item.SubItems(6).Text) Then
                    mdiRecargaPOS.lblStatus.Text = item.Text & " " & item.SubItems(6).Text
                    If item.SubItems(6).Text = "AP" Then
                        btnImprimir.Enabled = True
                    Else
                        btnImprimir.Enabled = False
                    End If
                End If
            Catch ex As Exception
                mdiRecargaPOS.lblStatus.Text = ex.Message & " " & lvwTransacciones.SelectedItems.Count.ToString
            End Try
        End If
    End Sub

    Private Sub tmrConsulta_Tick(sender As Object, e As EventArgs) Handles tmrConsulta.Tick
        tmrConsulta.Stop()
        lblHora.Text = Now.ToString("HH:mm:ss") : lblHora.Refresh()
        Call CargarTransacciones()
        tmrConsulta.Start()
    End Sub
End Class