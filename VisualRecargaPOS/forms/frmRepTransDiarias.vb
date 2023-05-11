Public Class frmRepTransDiarias
    Private gfTotalMonto As Integer = 0
    Private gfTotalComision As Decimal = 0.0
    Private gfFecha As String = ""

    Private Sub CargaCombo(ByVal cmb As ComboBox)
        Dim clsAyu As New clsAyuda(Conx)
        Try
            Call clsAyu.CargaCombo(Me.Name, cmb)
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando combo " & cmb.Name & "."
            Call MensajeError(ex, strFixMsg)
        End Try
        clsAyu = Nothing
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    Private Sub CargarEstaciones()
        cmbEstacion.Items.Clear()
        cmbEstacion.Items.Add("TODAS")
        glSQL = "EXEC PosQryEstaciones 'TODAS'," & glCodVen
        iRET = ExecSP(glSQL, True)
        Do While Not RecSet.EOF
            cmbEstacion.Items.Add(CInt(RecSet("ID_Estacion").Value).ToString("00"))
            RecSet.MoveNext()
        Loop
        If cmbEstacion.Items.Count > 0 Then cmbEstacion.SelectedIndex = 0
    End Sub

    Private Sub EjecutarReporte()
        gfTotalMonto = 0
        gfTotalComision = 0.0
        gfFecha = ""

        glSQL = "EXEC PosRepTransacciones @Modo='DETALLADO'"
        glSQL = glSQL & ",@Fecha='" & dtpDesde.Value.ToString("yyyyMMdd") & "'"
        glSQL = glSQL & ",@FechaHasta='" & dtpHasta.Value.ToString("yyyyMMdd") & "'"
        glSQL = glSQL & ",@ID_Vendedor=" & glCodVen.ToString

        glSQL = glSQL & ",@ID_Estacion='" & cmbEstacion.SelectedItem.ToString.Substring(0, 2) & "'"
        glSQL = glSQL & ",@TipoTrans='" & DirectCast(cmbTipo.SelectedItem, clsAyuda).Clave & "'"
        iRET = ExecSP(glSQL, True)

        VP.Clear()
        Call ImprimirHeader()
        Do While Not RecSet.EOF
            Call ImprimirDetalle()
            If RecSet("Status").Value.ToString = "AP" Then
                gfTotalComision += CDec(RecSet("Comision").Value)
                gfTotalMonto += CInt(RecSet("Monto").Value)
            Else
                If cmbTipo.SelectedIndex <> 0 Then
                    gfTotalMonto += CInt(RecSet("Monto").Value)
                End If
            End If
            RecSet.MoveNext()
        Loop
        Call ImprimirFooter()
    End Sub

    Private Sub ImprimirDetalle()
        Dim strLine As String = ""
        If dtpDesde.Value <> dtpHasta.Value Then
            If RecSet("Fecha").Value.ToString <> gfFecha Then
                gfFecha = RecSet("Fecha").Value.ToString
                VP.Add(New String(" "c, glMargenIzq) & "FECHA " & RecSet("Fecha").Value.ToString & vbCrLf)
            End If
        End If
        '0000000 XXXXXXXXXX0099,999  99.99 XX
        strLine = New String(" "c, glMargenIzq)
        strLine += CInt(RecSet("NroTransaccion").Value).ToString("0000000") & " "
        strLine += RecSet("NomProd").Value.ToString.PadRight(12)
        strLine += CInt(RecSet("ID_Estacion").Value).ToString("##").PadLeft(2)
        strLine += CInt(RecSet("Monto").Value).ToString("##,##0").PadLeft(6) & " "
        If RecSet("Status").Value.ToString = "AP" Then
            strLine += CDec(RecSet("Comision").Value).ToString("##0.00").PadLeft(6) & " "
        Else
            strLine += "  0.00 "
        End If
        If cmbTipo.SelectedIndex = 0 Then strLine += RecSet("Status").Value.ToString
        VP.Add(strLine & vbCrLf)
    End Sub

    Private Sub ImprimirFooter()
        VP.Add(New String(" "c, glMargenIzq) & New String("-"c, 39) & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "Total Monto    :" & gfTotalMonto.ToString("###,###,##0").PadLeft(12) & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "Total Comisión :" & gfTotalComision.ToString("####,##0.00").PadLeft(12) & vbCrLf)
        For idxLine = 0 To glSaltarDespues
            VP.Add(vbCrLf)
        Next
    End Sub

    Private Sub ImprimirHeader()
        For idxLine = 0 To glSaltarAntes
            VP.Add(vbCrLf)
        Next
        VP.Add(New String(" "c, glMargenIzq) & "Visual Recarga-REPORTE DE TRANSACCIONES" & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "VENDEDOR: " & glCodVen & "-" & glNomVen & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "FECHA   : " & glFecHora.ToShortDateString & " " & glFecHora.ToShortTimeString & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "DEL " & dtpDesde.Value.ToShortDateString & " AL " & dtpHasta.Value.ToShortDateString & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "ESTACION: " & cmbEstacion.SelectedItem.ToString & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "TIPO    : " & cmbTipo.SelectedItem.ToString & vbCrLf)

        VP.Add(vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "NRO.TR. PRODUCTO    ES MONTO   COM.")
        If cmbTipo.SelectedIndex = 0 Then
            VP.Add(" ST" & vbCrLf)
        Else
            VP.Add(vbCrLf)
        End If
        VP.Add(New String("-"c, 39) & vbCrLf)
    End Sub

    Private Function ValEntReq() As Boolean
        If dtpDesde.Value > dtpHasta.Value Then
            MessageBox.Show("La fecha desde debe ser menor o igual que la fecha hasta.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If cmbEstacion.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar la estación que desea imprimir.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If cmbTipo.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar el tipo de transacción que desea imprimir.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Call CargarEstaciones()
        Call CargaCombo(cmbTipo)
    End Sub

    Private Sub ctrl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpDesde.KeyPress, dtpHasta.KeyPress, cmbEstacion.KeyPress, cmbTipo.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub
End Class