Public Class frmRepEdoCta
    Private Sub EjecutarReporte()
        glSQL = "EXEC PosRepEstadoCuenta " & glCodVen
        glSQL = glSQL & ",'" & dtpDesde.Value.ToString("yyyyMMdd") & "'"
        glSQL = glSQL & ",'" & dtpHasta.Value.ToString("yyyyMMdd") & "'"
        iRET = ExecSP(glSQL, True)

        VP.Clear()
        Call ImprimirHeader()
        Do While Not RecSet.EOF
            Call ImprimirDetalle()
            RecSet.MoveNext()
        Loop
        Call ImprimirFooter()
    End Sub

    Private Sub ImprimirDetalle()
        VP.Add(New String(" "c, glMargenIzq) & New String("-"c, 34) & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "Fecha:" & CDate(RecSet("Fecha").Value).ToShortDateString & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & New String("-"c, 34) & vbCrLf)
        If CInt(RecSet("ID_SubGrupo").Value) = 10000 Then
            VP.Add(New String(" "c, glMargenIzq) & "SaldoAnt.  " & CDec(RecSet("SaldoDiaAnt").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Creditos   " & CDec(RecSet("Creditos").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Depositos  " & CDec(RecSet("Depositos").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Ventas     " & CDec(RecSet("Ventas").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Comisiones " & CDec(RecSet("Comisiones").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "SaldoActual" & CDec(RecSet("SaldoActual").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
        Else
            VP.Add(New String(" "c, glMargenIzq) & "SaldoAnt.  " & CDec(RecSet("SaldoAnterior").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Ventas     " & CDec(RecSet("Venta").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Pagos      " & CDec(RecSet("Pago").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "Comisiones " & CDec(RecSet("Comision").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
            VP.Add(New String(" "c, glMargenIzq) & "SaldoActual" & CDec(RecSet("SaldoTotal").Value).ToString("###,###,##0.00").PadLeft(15) & vbCrLf)
        End If
    End Sub

    Private Sub ImprimirFooter()
        VP.Add(New String(" "c, glMargenIzq) & New String("-"c, 34) & vbCrLf)
        For idxLine = 0 To glSaltarDespues
            VP.Add(vbCrLf)
        Next
    End Sub

    Private Sub ImprimirHeader()
        For idxLine = 0 To glSaltarAntes
            VP.Add(vbCrLf)
        Next
        VP.Add(New String(" "c, glMargenIzq) & "Visual Recarga - ESTADO DE CUENTA" & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "VENDEDOR: " & glCodVen & "-" & glNomVen & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "FECHA   : " & glFecHora.ToShortDateString & " " & glFecHora.ToShortTimeString & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "DEL " & dtpDesde.Value.ToShortDateString & " AL " & dtpHasta.Value.ToShortDateString & vbCrLf)
        VP.Add(vbCrLf)
    End Sub

    Private Function ValEntReq() As Boolean
        If dtpDesde.Value > dtpHasta.Value Then
            MessageBox.Show("La fecha desde debe ser menor o igual que la fecha hasta.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Not ValEntReq() Then Exit Sub
        Cursor.Current = Cursors.AppStarting
        Call EjecutarReporte()
        If glImpresora = vlImpresoraEnum.vlWindows Then
            Call PrintToWinDefault()
        Else
            Call PrintToPort()
        End If
        Cursor.Current = Cursors.Default
        Me.Close()
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim fImp As frmImpresora
        If Not ValEntReq() Then Exit Sub
        Cursor.Current = Cursors.AppStarting
        Call EjecutarReporte()
        fImp = New frmImpresora
        fImp.iPrinterWidth = 40
        fImp.mClear()
        For Each item As String In VP
            fImp.mPrint(item)
        Next
        fImp.MdiParent = Me.MdiParent
        fImp.Show()
        fImp = Nothing
        Cursor.Current = Cursors.Default
        Me.Close()
    End Sub

    Private Sub frmRepVentasDiarias_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 1
        Me.Left = 1
        dtpDesde.MaxDate = glFecHora.Date
        dtpHasta.MaxDate = glFecHora.Date
        dtpDesde.Value = glFecHora.Date
        dtpHasta.Value = glFecHora.Date
    End Sub

    Private Sub ctrl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpDesde.KeyPress, dtpHasta.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub
End Class