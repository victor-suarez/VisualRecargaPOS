Friend Class frmConfig
    Private Sub BuscarDatosRegistrados()
        Dim idxOpc As Short
        Try
            glPrintPort = My.Settings.PrintPort
            idxOpc = CShort(BuscarEnCombo(cmbPuerto, glPrintPort))
            cmbPuerto.SelectedIndex = CInt(If(idxOpc > (cmbPuerto.Items.Count - 1), -1, idxOpc)) 'BuscarEnCombo(cmbPuerto, glPrintPort)
            If glPrintPort.EndsWith(":") Then glPrintPort = glPrintPort.Substring(0, glPrintPort.Length - 1)
            cmbPrintTo.SelectedIndex = My.Settings.PrintTo
            glSpeed = My.Settings.Speed
            idxOpc = CShort(BuscarEnCombo(cmbSpeed, glSpeed.ToString))
            cmbSpeed.SelectedIndex = CInt(If(idxOpc > (cmbSpeed.Items.Count - 1), -1, idxOpc)) 'BuscarEnCombo(cmbPuerto, glPrintPort)
            cmbImpresora.SelectedIndex = My.Settings.Impresora
            cmbTipoLetra.SelectedIndex = My.Settings.TipoLetra
            txtMargenIzq.Value = My.Settings.MargenIzq
            txtLineasAntes.Value = My.Settings.SaltarLineasAntes
            txtLineasDespues.Value = My.Settings.SaltarLineasDespues

            chkCortarPapel.Checked = My.Settings.CortarPapel
            chkInterlineado.Checked = My.Settings.Interlineado
            chkNombreEnTicket.Checked = My.Settings.NombreEnTickets
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando datos registrados."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Function BuscarEnCombo(ByVal oCmb As ComboBox, ByVal sValue As String) As Integer
        Dim idx As Integer = -1
        For idx = 0 To (oCmb.Items.Count - 1)
            If oCmb.Items(idx).ToString = sValue Then Exit For
        Next idx
        Return idx
    End Function

    Private Sub CargaCombo(ByVal cmb As ComboBox)
        Dim clsAyu As New clsAyuda(Conx)
        Try
            Call clsAyu.CargaCombo(Me.Name, cmb)
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando combo " & cmb.Name & "."
            Call MensajeError(ex, strFixMsg)
        End Try
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
        clsAyu = Nothing
    End Sub

    'Para imprimir un ticket de prueba
    Private Sub GuardarDatosImpresora()
        glPrintPort = cmbPuerto.Text
        If glPrintPort.EndsWith(":") AndAlso glPrintPort.Contains("COM") Then glPrintPort = glPrintPort.Substring(0, glPrintPort.Length - 1)
        glPrintTo = CType(CShort(cmbPrintTo.SelectedIndex), vlPrintToEnum)
        glSpeed = CInt(cmbSpeed.SelectedItem.ToString)
        glImpresora = CType(cmbImpresora.SelectedIndex, vlImpresoraEnum)
        glTipoLetra = CType(cmbTipoLetra.SelectedIndex, vlTipoLetraEnum)

        glMargenIzq = CShort(txtMargenIzq.Value)
        glSaltarAntes = CShort(txtLineasAntes.Value)
        glSaltarDespues = CShort(txtLineasDespues.Value)
        glCortarPapel = chkCortarPapel.Checked
        glInterlineado = chkInterlineado.Checked
        glNameInTicket = chkNombreEnTicket.Checked

        glEstacion = CShort(lblEstacion.Text)
    End Sub

    Private Sub LlenarOpciones()
        CargaCombo(cmbPrintTo)
        CargaCombo(cmbPuerto)
        CargaCombo(cmbSpeed)
        CargaCombo(cmbImpresora)
        CargaCombo(cmbTipoLetra)

        lblServidor.Text = glIPServer
        lblBaseDatos.Text = glGrupo
        lblEstacion.Text = glEstacion.ToString
        lblNombrePC.Text = glPCName
    End Sub

    Private Sub VerificarValoresPorDefecto()
        If cmbPrintTo.SelectedIndex = -1 Then cmbPrintTo.SelectedIndex = 0
        If cmbPuerto.SelectedIndex = -1 Then cmbPuerto.SelectedIndex = 0
        If cmbSpeed.SelectedIndex = -1 Then cmbSpeed.SelectedIndex = 0
        If cmbImpresora.SelectedIndex = -1 Then cmbImpresora.SelectedIndex = 0
        If cmbTipoLetra.SelectedIndex = -1 Then cmbTipoLetra.SelectedIndex = 0
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Cursor.Current = Cursors.AppStarting
        Call VerificarValoresPorDefecto()
        Try
            My.Settings.PrintTo = CShort(cmbPrintTo.SelectedIndex)
            glPrintTo = CType(cmbPrintTo.SelectedIndex, vlPrintToEnum)
            My.Settings.PrintPort = cmbPuerto.Text
            glPrintPort = cmbPuerto.Text
            If glPrintPort.EndsWith(":") AndAlso glPrintPort.Contains("COM") Then glPrintPort = glPrintPort.Substring(0, glPrintPort.Length - 1)
            My.Settings.Speed = CInt(DirectCast(cmbSpeed.SelectedItem, clsAyuda).Valor)
            glSpeed = CInt(cmbSpeed.Text)
            My.Settings.Impresora = CShort(cmbImpresora.SelectedIndex)
            glImpresora = CType(cmbImpresora.SelectedIndex, vlImpresoraEnum)
            My.Settings.TipoLetra = CShort(cmbTipoLetra.SelectedIndex)
            glTipoLetra = CType(cmbTipoLetra.SelectedIndex, vlTipoLetraEnum)

            My.Settings.MargenIzq = CShort(txtMargenIzq.Text)
            glMargenIzq = CShort(txtMargenIzq.Text)
            My.Settings.SaltarLineasAntes = CShort(txtLineasAntes.Text)
            glSaltarAntes = CShort(txtLineasAntes.Text)
            My.Settings.SaltarLineasDespues = CShort(txtLineasDespues.Text)
            glSaltarDespues = CShort(txtLineasDespues.Text)

            My.Settings.CortarPapel = chkCortarPapel.Checked
            glCortarPapel = chkCortarPapel.Checked
            My.Settings.Interlineado = chkInterlineado.Checked
            glInterlineado = chkInterlineado.Checked
            My.Settings.NombreEnTickets = chkNombreEnTicket.Checked
            glNameInTicket = chkNombreEnTicket.Checked

            'My.Settings.RazonSocial = ""
            'My.Settings.RIF = ""
            'My.Settings.Contactos = ""
            'My.Settings.Email = ""

            My.Settings.Save()
        Catch ex As Exception
            Dim strFixMsg As String = "Error guardando configuración."
            Call MensajeError(ex, strFixMsg)
        End Try
        Cursor.Current = Cursors.Default
        Me.Dispose()
    End Sub

    Private Sub btnTicketPrueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicketPrueba.Click
        Dim lcMargenIzq, lcSaltarAntes, lcSaltarDespues As Short
        Dim lcPrintPort As String, lcSpeed As Integer, lcTipoLetra As vlTipoLetraEnum
        Dim lcCortarPapel, lcInterlineado As Boolean
        iPrinterWidth = 40
        iPrinterHeight = 47

        'Guardo los valores actuales y uso los modificados para la prueba
        'luego los recupero para poder realizar una cancelación si no se guardan los cambios
        lcPrintPort = glPrintPort
        glPrintPort = cmbPuerto.Text
        If glPrintPort.Contains("COM") AndAlso glPrintPort.EndsWith(":") Then glPrintPort = glPrintPort.Substring(0, glPrintPort.Length - 1)
        lcSpeed = glSpeed
        glSpeed = CInt(DirectCast(cmbSpeed.SelectedItem, clsAyuda).Clave)
        lcTipoLetra = glTipoLetra
        glTipoLetra = DirectCast(cmbTipoLetra.SelectedIndex, vlTipoLetraEnum)

        lcMargenIzq = glMargenIzq
        glMargenIzq = CShort(txtMargenIzq.Value)
        lcSaltarAntes = glSaltarAntes
        glSaltarAntes = CShort(txtLineasAntes.Value)
        lcSaltarDespues = glSaltarDespues
        glSaltarDespues = CShort(txtLineasDespues.Value)
        lcCortarPapel = glCortarPapel
        glCortarPapel = chkCortarPapel.Checked
        lcInterlineado = glInterlineado
        glInterlineado = chkInterlineado.Checked

        VP.Clear()
        For idxRow As Short = 0 To glSaltarAntes
            vPrt("")
        Next idxRow
        vPrt(New String(" "c, glMargenIzq) & glCodVen & "-" & glNomVen)
        vPrt(New String(" "c, glMargenIzq) & "Nro.Trans.: " & "00000000")
        vPrt(New String(" "c, glMargenIzq) & "Fecha:      " & System.DateTime.Now.ToString("dd-MM-yyyy HH:mm tt"))
        vPrt(New String(" "c, glMargenIzq) & "Estacion:   " & glEstacion)
        If glNameInTicket Then vPrt(New String(" "c, glMargenIzq) & "Vendedor:   " & glNombre)
        vPrt(New String("-"c, 40))

        vPrt(New String(" "c, glMargenIzq) & "DATOS DE LA RECARGA")
        vPrt(New String(" "c, glMargenIzq) & "Operadora:  " & "Empresa prepago")
        vPrt(New String(" "c, glMargenIzq) & "Producto:   " & "Producto de recarga")
        vPrt(New String(" "c, glMargenIzq) & "Céd.Cliente:" & "99.999.999")
        vPrt(New String(" "c, glMargenIzq) & "Nro.Celular:" & "0419 9999999")

        vPrt(New String(" "c, glMargenIzq) & "TOTAL BOLIVARES: " & (999999).ToString("###.##0"))

        vPrt("")
        vPrt(New String(" "c, glMargenIzq) & "PRIMERA LINEA DE MENSAJE")
        vPrt(New String(" "c, glMargenIzq) & "SEGUNDA LINEA DE MENSAJE")
        vPrt(New String(" "c, glMargenIzq) & "TERCERA LINEA DE MENSAJE")
        For idxRow As Short = 0 To glSaltarDespues
            vPrt("")
        Next idxRow

        If cmbPrintTo.SelectedIndex = vlPrintToEnum.vlToScreen Then
            Call PrintToWindow(40) ' Crear la forma impresora
        Else
            If cmbImpresora.SelectedIndex = vlImpresoraEnum.vlWindows Then
                Call PrintToWinDefault()
            Else
                Call PrintToPort()
            End If
        End If
        glMargenIzq = lcMargenIzq
        glSaltarAntes = lcSaltarAntes
        glSaltarDespues = lcSaltarDespues
        glPrintPort = lcPrintPort
        glSpeed = lcSpeed
        glCortarPapel = lcCortarPapel
        glInterlineado = lcInterlineado
    End Sub

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.AppStarting
        Me.Top = 1
        Me.Left = 1

        Call LlenarOpciones()
        Call BuscarDatosRegistrados()
        Cursor.Current = Cursors.Default
    End Sub
End Class