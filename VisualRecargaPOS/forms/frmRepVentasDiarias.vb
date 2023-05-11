Public Class frmRepVentasDiarias
    Private gfTotalRecargas As Integer = 0
    Private gfTotalMonto As Integer = 0

    Private Sub CargarEstaciones()
        cmbEstacion.Items.Clear()
        cmbEstacion.Items.Add("TODAS")
        glSQL = "EXEC PosQryEstaciones 'TODAS'," & glCodVen
        iRET = ExecSP(glSQL, True)
        Do While Not RecSet.EOF
            cmbEstacion.Items.Add(RecSet("ID_Estacion").Value.ToString)
            RecSet.MoveNext()
        Loop
        If cmbEstacion.Items.Count > 0 Then cmbEstacion.SelectedIndex = 0
    End Sub

    Private Sub CargarUsuarios()
        cmbUsuario.Items.Clear()
        cmbUsuario.Items.Add("TODOS")
        glSQL = "EXEC SegQryUsuarios 'AllUsersVend'," & glCodVen
        iRET = ExecSP(glSQL, True)
        Do While Not RecSet.EOF
            cmbUsuario.Items.Add(RecSet("Login").Value.ToString)
            RecSet.MoveNext()
        Loop
        If cmbUsuario.Items.Count > 0 Then cmbUsuario.SelectedIndex = 0
    End Sub

    Private Sub EjecutarReporte()
        gfTotalRecargas = 0
        gfTotalMonto = 0

        glSQL = "EXEC PosRepVentas 'RESUMIDO',"
        glSQL = glSQL & "'" & dtpDesde.Value.ToString("yyyyMMdd") & "',"
        glSQL = glSQL & "'" & dtpHasta.Value.ToString("yyyyMMdd") & "',"
        glSQL = glSQL & glCodVen & ","
        If cmbUsuario.SelectedIndex > 0 Then
            glSQL = glSQL & "'" & cmbUsuario.SelectedItem.ToString & "',"
        Else
            glSQL = glSQL & "NULL,"
        End If
        If cmbEstacion.SelectedIndex > 0 Then
            glSQL = glSQL & "'" & cmbEstacion.SelectedItem.ToString & "'"
        Else
            glSQL = glSQL & "'T'"
        End If
        iRET = ExecSP(glSQL, True)

        VP.Clear()
        Call ImprimirHeader()
        Do While Not RecSet.EOF
            Call ImprimirDetalle()
            gfTotalRecargas += CInt(RecSet("Recargas").Value)
            gfTotalMonto += CInt(RecSet("Monto").Value)
            RecSet.MoveNext()
        Loop
        Call ImprimirFooter()
    End Sub

    Private Sub ImprimirDetalle()
        Dim strLine As String = ""
        strLine = New String(" "c, glMargenIzq)
        strLine += CDate(RecSet("Fecha").Value).ToString("dd-MM-yyyy") & "  "
        strLine += CInt(RecSet("Estacion").Value).ToString("00") & "   "
        strLine += CInt(RecSet("Monto").Value).ToString("###,###,##0").PadLeft(11)
        VP.Add(strLine & vbCrLf)
    End Sub

    Private Sub ImprimirFooter()
        VP.Add(New String(" "c, glMargenIzq) & "---------- ---   -----------" & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "TOTALES          " & gfTotalMonto.ToString("###,###,##0").PadLeft(11) & vbCrLf)
        VP.Add(vbCrLf)
        For idxLine = 0 To glSaltarDespues
            VP.Add(vbCrLf)
        Next
    End Sub

    Private Sub ImprimirHeader()
        For idxLine = 0 To glSaltarAntes
            VP.Add(vbCrLf)
        Next
        VP.Add(New String(" "c, glMargenIzq) & "Visual Recarga - REPORTE DE VENTAS" & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "VENDEDOR: " & glCodVen & "-" & glNomVen & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "FECHA   : " & glFecHora.ToShortDateString & " " & glFecHora.ToShortTimeString & vbCrLf)

        VP.Add(New String(" "c, glMargenIzq) & "DEL " & dtpDesde.Value.ToShortDateString & " AL " & dtpHasta.Value.ToShortDateString & vbCrLf)
        If cmbUsuario.SelectedIndex > 0 Then
            VP.Add(New String(" "c, glMargenIzq) & "USUARIO : " & cmbUsuario.SelectedItem.ToString & vbCrLf)
        Else
            VP.Add(New String(" "c, glMargenIzq) & "ESTACION: " & cmbEstacion.SelectedItem.ToString & vbCrLf)
        End If
        VP.Add(New String(" "c, 40) & vbCrLf)
        VP.Add(vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "  FECHA    EST      MONTO    " & vbCrLf)
        VP.Add(New String(" "c, glMargenIzq) & "---------- ---   -----------" & vbCrLf)
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

    Private Sub cmbEstacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstacion.SelectedIndexChanged
        If cmbEstacion.SelectedIndex > 0 Then cmbUsuario.SelectedIndex = 0
    End Sub

    Private Sub cmbUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuario.SelectedIndexChanged
        If cmbUsuario.SelectedIndex > 0 Then cmbEstacion.SelectedIndex = 0
    End Sub

    Private Sub frmRepVentasDiarias_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 1
        Me.Left = 1
        dtpDesde.MaxDate = glFecHora.Date
        dtpHasta.MaxDate = glFecHora.Date
        dtpDesde.Value = glFecHora.Date
        dtpHasta.Value = glFecHora.Date
        Call CargarEstaciones()
        Call CargarUsuarios()
    End Sub
End Class