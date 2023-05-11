Imports System.Windows.Forms
Public Class mdiRecargaPOS
    'Variables para el control de formas y evitar que se lancen dos veces
    'Friend fVTA As frmVenta = Nothing
    Private fMSG As frmMensaje = Nothing
    Private fACD As frmAcercaDe = Nothing
    Private fCNG As frmConfig = Nothing
    Private fPSW As frmManPassword = Nothing
    Private fDEP As frmDepositos = Nothing
    Private fVEN As frmVenta = Nothing

    Private fRVD As frmRepVentasDiarias = Nothing
    Private fRTD As frmRepTransDiarias = Nothing
    Private fREC As frmRepEdoCta = Nothing

    Private fCTR As frmConTransaccion = Nothing
    Friend fCTE As frmConTrEnEspera = Nothing
    Private fCRT As frmConResumen = Nothing

    Friend Sub Entrar()
        Me.lblStatus.Text = "Login ok..."
        Me.lblStatus.Text = "Marcando entrada de estación..."
        Try
            glSQL = "EXEC SpProMarcaIOTaq @Modo='I'" &
                                        ",@ID_Vendedor=" & glCodVen &
                                        ",@ID_Estacion=" & glEstacion &
                                        ",@Login='" & glUser & "'" &
                                        ",@IP_Address='" & glIPClient & "'" &
                                        ",@Version='" & glStrVersion & "'"
            iRET = ExecSP(glSQL, False)
            glEstadoTaq = "I"c
        Catch ex As Exception
            Dim strFixMsg As String = "Error marcando entrada estación."
            Call MensajeError(ex, strFixMsg)
        End Try
        Call Me.tmrProyecto_Tick(Nothing, Nothing)
        Me.lblStatus.Text = ""
    End Sub

    Private Sub mdiRecargaPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Seguro de salir del sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
            'Si la conexión está caída no marco nada.
            If Conx Is Nothing Then Exit Sub Else If Conx.State <> ADODB.ObjectStateEnum.adStateOpen Then Exit Sub
            Try
                glSQL = "EXEC SpProMarcaIOTaq @Modo='O'" &
                                            ",@ID_Vendedor=" & glCodVen &
                                            ",@ID_Estacion=" & glEstacion &
                                            ",@Login='" & glUser & "'" &
                                            ",@IP_Address='" & glIPClient & "'" &
                                            ",@Version='" & glStrVersion & "'"
                iRET = ExecSP(glSQL, False)
                glEstadoTaq = "O"c
            Catch ex As Exception
                Dim strFixMsg As String = "Error marcando salida estación."
                Call MensajeError(ex, strFixMsg)
            End Try
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub mdiRecargaPOS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        'Mostrar la forma de ventas al entrar
        'If Not fVEN Is Nothing AndAlso Not fVEN.IsDisposed Then fVEN.BringToFront() : Exit Sub
        'Cursor.Current = Cursors.AppStarting
        fVEN = New frmVenta
        fVEN.MdiParent = Me
        fVEN.Show()
        'También mostrar la lista de transacciones en proceso
        fCTE = New frmConTrEnEspera
        fCTE.MdiParent = Me
        fCTE.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mdiRecargaPOS_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
    End Sub

    Private Sub mnuConfiguracionContraseña_Click(sender As Object, e As EventArgs) Handles mnuConfiguracionContraseña.Click
        If Not fPSW Is Nothing AndAlso Not fPSW.IsDisposed Then fPSW.BringToFront() : Exit Sub
        fPSW = New frmManPassword
        fPSW.MdiParent = Me
        fPSW.Show()
    End Sub

    Private Sub mnuConfiguracionImpresora_Click(sender As Object, e As EventArgs) Handles mnuConfiguracionImpresora.Click
        If Not fCNG Is Nothing AndAlso Not fCNG.IsDisposed Then fCNG.BringToFront() : Exit Sub
        fCNG = New frmConfig
        fCNG.MdiParent = Me
        fCNG.Show()
    End Sub

    Private Sub mnuConsultasResumenDeTransacciones_Click(sender As Object, e As EventArgs) Handles mnuConsultasResumenDeTransacciones.Click
        If Not fCRT Is Nothing AndAlso Not fCRT.IsDisposed Then fCRT.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fCRT = New frmConResumen
        fCRT.MdiParent = Me
        fCRT.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuConsultasTransacciones_Click(sender As Object, e As EventArgs) Handles mnuConsultasTransacciones.Click
        If Not fCTR Is Nothing AndAlso Not fCTR.IsDisposed Then fCTR.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fCTR = New frmConTransaccion
        fCTR.MdiParent = Me
        fCTR.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Friend Sub mnuConsultasTransaccionesEnEspera_Click(sender As Object, e As EventArgs) Handles mnuConsultasTransaccionesEnEspera.Click
        If Not fCTE Is Nothing AndAlso Not fCTE.IsDisposed Then fCTE.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fCTE = New frmConTrEnEspera
        fCTE.MdiParent = Me
        fCTE.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuDeposito_Click(sender As Object, e As EventArgs) Handles mnuDeposito.Click
        If Not fDEP Is Nothing AndAlso Not fDEP.IsDisposed Then fDEP.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fDEP = New frmDepositos
        fDEP.MdiParent = Me
        fDEP.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        If Not fACD Is Nothing AndAlso Not fACD.IsDisposed Then fACD.BringToFront() : Exit Sub
        fACD = New frmAcercaDe
        fACD.MdiParent = Me
        fACD.Show()
    End Sub

    Private Sub mnuReportesEstadoDeCuenta_Click(sender As Object, e As EventArgs) Handles mnuReportesEstadoDeCuenta.Click
        If Not fREC Is Nothing AndAlso Not fREC.IsDisposed Then fREC.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fREC = New frmRepEdoCta
        fREC.MdiParent = Me
        fREC.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuReportesImprimirUltimoRecibo_Click(sender As Object, e As EventArgs) Handles mnuReportesImprimirUltimoRecibo.Click
        Dim fImp As frmImpresora
        Dim strLine As String = ""
        Dim prnVoucher As String = ""
        ' Open the file using a stream reader.
        Try
            Dim file As New System.IO.StreamReader(glUsrPath & "UltRecibo.Vr")
            ' Read the stream to a string and write the string to the console.
            Do Until strLine Is Nothing
                strLine = file.ReadLine()
                prnVoucher &= New String(" "c, glMargenIzq) & strLine & vbCrLf
            Loop
            file.Close()
            file = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "Hubo un problema para leer el archivo del último recibo.", "Error Imprimiendo Último Recibo", MessageBoxButtons.OK)
            Exit Sub
        End Try
        fImp = New frmImpresora
        fImp.iPrinterWidth = 40
        fImp.mClear()
        fImp.mPrint("COPIA - CLIENTE", frmImpresora.prnJustified.justCenter)
        fImp.mPrint()
        fImp.mPrint(prnVoucher)
        fImp.MdiParent = Me
        fImp.Show()
    End Sub

    Private Sub mnuReportesTransaccionesDiarias_Click(sender As Object, e As EventArgs) Handles mnuReportesTransaccionesDiarias.Click
        If Not fRTD Is Nothing AndAlso Not fRTD.IsDisposed Then fRTD.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fRTD = New frmRepTransDiarias
        fRTD.MdiParent = Me
        fRTD.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuReportesVentasPorDia_Click(sender As Object, e As EventArgs) Handles mnuReportesVentasPorDia.Click
        If Not fRVD Is Nothing AndAlso Not fRVD.IsDisposed Then fRVD.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fRVD = New frmRepVentasDiarias
        fRVD.MdiParent = Me
        fRVD.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub mnuVenta_Click(sender As Object, e As EventArgs) Handles mnuVenta.Click
        If Not fVEN Is Nothing AndAlso Not fVEN.IsDisposed Then fVEN.BringToFront() : Exit Sub
        Cursor.Current = Cursors.AppStarting
        fVEN = New frmVenta
        fVEN.MdiParent = Me
        fVEN.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuWindowsArrangeIcons_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuWindowsArrangeIcons.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub mnuWindowsCascade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuWindowsCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuWindowsCloseAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuWindowsCloseAll.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub mnuWindowsTileHorizontal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuWindowsTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuWindowsTileVertical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuWindowsTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Friend Sub Printer_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Printer.PrintPage
        Dim printFont As Font = New System.Drawing.Font("Courier New", 7)
        Dim count As Integer = 0

        Dim fontHeight As Single = printFont.GetHeight(e.Graphics) * CShort(If(glInterlineado, 2, 1))
        Dim leftMargin As Single = 0
        Dim topMargin As Single = 0
        Dim linesPerPage As Integer = CInt(e.MarginBounds.Height / fontHeight)

        While count < linesPerPage And iLinesPrinted < VP.Count
            e.Graphics.DrawString(VP(iLinesPrinted), printFont, Brushes.Black, leftMargin, topMargin + count * fontHeight, StringFormat.GenericDefault)
            count += 1
            iLinesPrinted += 1
        End While
        iPagesPrinted += 1
        If iLinesPrinted < VP.Count Then
            e.HasMorePages = True
        Else
            e.Graphics.DrawString(" ", printFont, Brushes.Black, leftMargin, topMargin + count * fontHeight, StringFormat.GenericDefault)
            e.HasMorePages = False
            iLinesPrinted = 0
        End If
    End Sub

    Friend Sub tmrProyecto_Tick(sender As Object, e As EventArgs) Handles tmrProyecto.Tick
        tmrProyecto.Stop()
        If Not My.Computer.Network.IsAvailable Then
            glFecHora = System.DateTime.Now()
        Else
            Try
                If Not String.IsNullOrEmpty(glFecHora.ToString) Then
                    If Not BuscarFechaHora() Then
                        glFecHora = glFecHora.AddMilliseconds(tmrProyecto.Interval)
                    End If
                Else
                    glFecHora = System.DateTime.Now()
                End If
            Catch ex As Exception
                Dim strFixMsg As String = "Error ajustando fecha y hora del equipo."
                Call MensajeError(ex, strFixMsg)
            End Try
            If ChequearMensaje() Then
                fMSG = New frmMensaje
                fMSG.MdiParent = Me
                fMSG.TopMost = True
                fMSG.Show()
            End If
            'If ChequearChat() Then
            '    fCHT = New frmChat
            '    fCHT.MdiParent = Me
            '    fCHT.TopMost = True
            '    fCHT.Show()
            'End If
        End If
        tmrProyecto.Start()
    End Sub
End Class
