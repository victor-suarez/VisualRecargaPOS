Imports Microsoft.VisualBasic
Public Class frmVenta
    Dim fImp As frmImpresora
    Dim arrSeriales() As String

    Private Sub BuscaSaldo()
        Dim lcSql As String = "EXEC PosQryVendedores2 " & glCodVen
        Try
            Dim ilRET As Integer = ExecSP(lcSql, True)
            If Not RecSet.EOF Then
                lblSaldo.Text = CDec(RecSet("SaldoDia").Value).ToString("##,###,###,##0.00")
            Else
                lblTitSaldo.Visible = False
                lblSaldo.Visible = False
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando saldo vendedor."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Sub BuscarUltNroTrans()
        Dim lcSQL As String = "EXEC SpPosConUltNroTrans @ID_Vendedor=" & glCodVen & ",@ID_Estacion=" & glEstacion
        Try
            Dim ilRET As Integer = ExecSP(lcSQL, True)
            If Not RecSet.EOF Then lblUltTrans.Text = RecSet("NroTransaccion").Value.ToString
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando última transacción."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Sub CambiarCodigo()
        If arrSeriales.Length <= 1 Then Exit Sub
        If CInt(lblPrefijo.Tag) = arrSeriales.GetUpperBound(0) Then
            lblPrefijo.Tag = 0
        Else
            lblPrefijo.Tag = CInt(lblPrefijo.Tag) + 1
        End If
        lblPrefijo.Text = arrSeriales(CInt(lblPrefijo.Tag))
        'If lblPrefijo.Text = "0416" Then
        '    lblPrefijo.Text = "0426"
        'ElseIf lblPrefijo.Text = "0426" Then
        '    lblPrefijo.Text = "0416"
        'ElseIf lblPrefijo.Text = "0412" Then
        '    lblPrefijo.Text = "0422"
        'ElseIf lblPrefijo.Text = "0422" Then
        '    lblPrefijo.Text = "0412"
        'ElseIf lblPrefijo.Text = "0414" Then
        '    lblPrefijo.Text = "0424"
        'ElseIf lblPrefijo.Text = "0424" Then
        '    lblPrefijo.Text = "0212"
        'ElseIf lblPrefijo.Text = "0212" Then
        '    lblPrefijo.Text = "0414"
        'ElseIf lblPrefijo.Text.Trim = "" Then
        '    Exit Sub
        'Else
        '    MessageBox.Show("Prefijo de operadora no definido.", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.Close()
        'End If
    End Sub

    Private Sub CargarEmpresas()
        Dim cEmp As clsEmpresa
        Dim rs As ADODB.Recordset
        Dim strSeriales As String
        Call SetStatus("Cargando lista de empresas...")
        cmbOperadora.Items.Clear()
        Dim lcSQL As String = "EXEC PosQryVendedores1 " & glCodVen.ToString
        Try
            Dim ilRET As Integer = ExecSP(lcSQL, True)
            If Not RecSet.EOF Then
                lcSQL = "EXEC PosQryEmpresa " & RecSet("RestringuirEmpresa").Value.ToString & "," & glCodVen.ToString
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando restricción vendedor."
            Call MensajeError(ex, strFixMsg)
        End Try

        Try
            Dim ilRET As Integer = ExecSP(lcSQL, True)
            Do While Not RecSet.EOF
                cEmp = New clsEmpresa(CInt(RecSet("Codigo").Value),
                                      RecSet("Empresa").Value.ToString,
                                      RecSet("NombreProducto").Value.ToString,
                                      RecSet("Serial").Value.ToString,
                                      CShort(RecSet("Longitud").Value),
                                      CDec(RecSet("MontoMinimo").Value),
                                      CDec(RecSet("MontoMaximo").Value),
                                      CDec(RecSet("Multiplo").Value),
                                      RecSet("MsgTicket").Value.ToString,
                                      RecSet("Status").Value.ToString,
                                      CBool(RecSet("UsaCedula").Value))
                strSeriales = ""
                rs = Conx.Execute("EXEC SpConSeriales " & RecSet("Codigo").Value.ToString)
                If Not rs.EOF Then
                    Do While Not rs.EOF
                        strSeriales += rs("Serial").Value.ToString & ";"
                        rs.MoveNext()
                    Loop
                    'quitar el último ";" para que no se cree un elemento vacío
                    strSeriales = strSeriales.Substring(0, strSeriales.Length - 1)
                    rs.Close()
                End If
                cEmp.Seriales = strSeriales
                cmbOperadora.Items.Add(cEmp)
                cEmp = Nothing
                RecSet.MoveNext()
            Loop
            If cmbOperadora.Items.Count = 0 Then
                MessageBox.Show("Disculpe operadoras se encuentran en mantenimiento. " & vbCrLf &
                                "Las operadoras estan fuera de servicio, por favor, espere " & vbCrLf &
                                "a que se reestablezca la conexion con las operadoras ...",
                                "Fuera de Servicio!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando operadoras."
            Call MensajeError(ex, strFixMsg)
        End Try
        Call SetStatus("")
    End Sub

    Private Sub ClearCRT()
        picLogo.Image = Nothing
        lblTranPend.Visible = False

        cmbOperadora.SelectedIndex = -1
        txtCedula.Text = "0"
        lblPrefijo.Text = ""
        lblPrefijo.Tag = Nothing
        txtNumero.Text = ""
        txtMonto.Text = ""

        lblCedula.Visible = False
        txtCedula.Visible = False
        lblCodigo.Visible = False
        lblPrefijo.Visible = False
        lblAyuda.Visible = False

        lblProducto.Text = ""
        lblPrecio.Text = ""
        lblVerificarCedula.Text = "0"
        lblVerificarNumero.Text = ""
        lblProcesando.Visible = False
        pnlBotonesVerificar.Visible = True

        lblTitCedula.Visible = False
        lblVerificarCedula.Visible = False

        grpVerificar.Visible = False
        grpDatos.Visible = False
        grpInicio.Visible = True
    End Sub

    Private Sub GuardarUltRecibo(ByVal strRecibo As String)
        Dim file As System.IO.StreamWriter
        Try
            file = My.Computer.FileSystem.OpenTextFileWriter(glUsrPath & "UltRecibo.Vr", False)
            file.Write(strRecibo)
            file.Close()
            'mdiRecargaPOS.lblStatus.Text = "Último recibo guardado en " & glUsrPath & "UltRecibo.Vr."
        Catch ex As System.IO.IOException
            MessageBox.Show(ex.Message & vbCrLf & "Hubo un problema para escribir el archivo del último recibo." & vbCrLf & "Compruebe el espacio en disco.", "Error Guardando Último Recibo", MessageBoxButtons.OK)
        End Try
        file = Nothing
    End Sub

    Private Sub ImprimirRecibo(ByVal arrRespuesta() As String, ByVal strVoucher As String)
        Dim strToSearch As String
        Dim prnVoucher As String = strVoucher
        Cursor.Current = Cursors.AppStarting
        fImp = New frmImpresora With {
            .iPrinterWidth = 40
        }
        fImp.mClear()

        fImp.mPrint("COPIA - CLIENTE", frmImpresora.prnJustified.justCenter)
        fImp.mPrint()
        ' SUSTITUCIONES:
        'Si no viene el campo mensaje operadora, lo agrego.
        If Not prnVoucher.Contains("@C[11]") Then
            prnVoucher &= "<LF>@C[11]<LF>"
        End If
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
                If (idxFld + 1) = 12 Then
                    prnVoucher = prnVoucher.Replace(strToSearch, DateISOtoDate(arrRespuesta(idxFld + 1)))
                ElseIf (idxFld + 1) = 13 Then
                    prnVoucher = prnVoucher.Replace(strToSearch, TimeISOtoTime(arrRespuesta(idxFld + 1)))
                Else
                    prnVoucher = prnVoucher.Replace(strToSearch, arrRespuesta(idxFld + 1))
                End If
            End If
        Next
        ' Campos de entrada (son pocos y cableados)
        If prnVoucher.Contains("@C[01]") Then prnVoucher = prnVoucher.Replace("@C[01]", "VISUAL RECARGA")
        If prnVoucher.Contains("@C[02]") Then prnVoucher = prnVoucher.Replace("@C[02]", DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre)
        If prnVoucher.Contains("@C[03]") Then prnVoucher = prnVoucher.Replace("@C[03]", "CARACAS")
        If prnVoucher.Contains("@C[04]") Then prnVoucher = prnVoucher.Replace("@C[04]", lblVerificarNumero.Text)
        If prnVoucher.Contains("@C[05]") Then prnVoucher = prnVoucher.Replace("@C[05]", lblProducto.Text)
        If prnVoucher.Contains("@C[10]") Then prnVoucher = prnVoucher.Replace("@C[10]", CDec(txtMonto.Text).ToString("###,###,##0.00"))
        If prnVoucher.Contains("@C[11]") Then prnVoucher = prnVoucher.Replace("@C[11]", DirectCast(cmbOperadora.SelectedItem, clsEmpresa).MsgTicket.Replace("|", vbCrLf))
        If prnVoucher.Contains("@C[12]") Then prnVoucher = prnVoucher.Replace("@C[12]", DateISOtoDate(arrRespuesta(12)))
        Call GuardarUltRecibo(prnVoucher)
        fImp.mPrint(prnVoucher)
        fImp.MdiParent = Me.MdiParent
        fImp.Show()
        Cursor.Current = Cursors.Default
    End Sub

    Private Function ValEntReq() As Boolean
        If cmbOperadora.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar la empresa operadora.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbOperadora.Focus()
            Return False
        End If
        If txtCedula.Visible Then
            If txtCedula.Text.Trim = "" Or txtCedula.Text.Trim = "0" Then
                MessageBox.Show("La cédula del cliente no puede estar en blanco.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCedula.Focus()
                Return False
            End If
        End If
        If txtNumero.MaxLength <> 0 Then
            If txtNumero.Text.Trim = "" Then
                MessageBox.Show("El teléfono o número a recargar no puede estar en blanco.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                Return False
            End If
            If txtNumero.Text.Length < txtNumero.MaxLength Then
                MessageBox.Show("El teléfono o número a recargar NO posee la longitud correcta.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                Return False
            End If
        End If
        If txtMonto.Text.Trim = "" Then
            MessageBox.Show("El monto a recargar no puede estar en blanco.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMonto.Focus()
            Return False
        End If
        If DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Minimo <> 0 Then
            If CDec(txtMonto.Text.Trim) < DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Minimo Then
                MessageBox.Show("El monto a recargar es menor al monto mínimo permitido por la operadora (Bs." &
                                DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Minimo.ToString &
                                ").", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtMonto.Focus()
                Return False
            End If
        End If
        If DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Maximo <> 0 Then
            If CDec(txtMonto.Text.Trim) > DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Maximo Then
                MessageBox.Show("El monto a recargar es mayor al monto máximo permitido por la operadora (Bs." &
                                DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Maximo.ToString &
                                ").", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtMonto.Focus()
                Return False
            End If
        End If
        If CDec(txtMonto.Text.Trim) Mod DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Multiplo <> 0 Then
            MessageBox.Show("La operadora sólo permite recargas en múltiplos de " &
                            DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Multiplo.ToString &
                            ".", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMonto.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function VerificaCampo(ByRef Rs As ADODB.Recordset, Campo As String) As Boolean
        Dim strCampos As String = ""
        For IdxFld As Integer = 0 To (Rs.Fields.Count - 1)
            strCampos &= Rs.Fields(IdxFld).Name
        Next IdxFld
        If strCampos.IndexOf(Campo) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnDatosAceptar_Click(sender As Object, e As EventArgs) Handles btnDatosAceptar.Click
        If Not ValEntReq() Then Exit Sub

        lblProducto.Text = DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Producto
        lblPrecio.Text = CDec(txtMonto.Text).ToString("Bs ##,###,##0.00")
        lblVerificarCedula.Text = CLng(txtCedula.Text).ToString("###,###,###")
        lblVerificarNumero.Text = lblPrefijo.Text & " " & txtNumero.Text

        lblCedula.Visible = txtCedula.Visible
        lblTitCedula.Visible = txtCedula.Visible
        lblVerificarCedula.Visible = txtCedula.Visible

        grpDatos.Visible = False
        grpVerificar.Visible = True
        btnVerificarRegresar.Focus()
    End Sub

    Private Sub btnDatosRegresar_Click(sender As Object, e As EventArgs) Handles btnDatosRegresar.Click
        Call ClearCRT()
    End Sub

    Private Sub btnVentaIniciar_Click(sender As Object, e As EventArgs) Handles btnVentaIniciar.Click
        Call SetStatus("Verificando transacciones pendientes...")
        ' Call Reconectar()
        Dim lcSQL As String = "EXEC PosQryTransaccionesTemp2 'ExisteTran'," & glCodVen.ToString & "," & glEstacion.ToString
        Try
            Dim ilRET As Integer = ExecSP(lcSQL, True)
        Catch ex As Exception
            Call SetStatus("")
            Dim strFixMsg As String = "Error de conexión."
            Call MensajeError(ex, strFixMsg)
            Exit Sub
        End Try
        'MENSAJE DE RESPUESTA PENDIENTE!!!!
        'DE PROCESAR ESTAS TRANSACCIONES PENDIENTES SE ENCARGARÁ LA CONSULTA
        If Not RecSet.EOF Then
            Call mdiRecargaPOS.mnuConsultasTransaccionesEnEspera_Click(Me, Nothing)
        End If
        Call SetStatus("")
        grpDatos.Visible = True
        grpInicio.Visible = False
        cmbOperadora.Focus()
    End Sub

    Private Sub btnVentaSalir_Click(sender As Object, e As EventArgs) Handles btnVentaSalir.Click
        If grpInicio.Visible Then
            Me.Close()
        Else
            If MessageBox.Show("¿Desea salir sin completar la venta?", "Transacción Incompleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnVerificarAceptar_Click(sender As Object, e As EventArgs) Handles btnVerificarAceptar.Click
        Dim lcRespCode As String
        Dim lcSeqNum As Integer
        Dim lcResponse As String
        Dim lcVoucher As String
        Dim lcError As String = ""
        Dim lcMensaje As String = Nothing
        Dim arrRespuesta As String()

        Cursor.Current = Cursors.AppStarting
        pnlBotonesVerificar.Visible = False
        tmrBlink.Start()
        Dim lcSQL As String = "EXEC PosInsTransaccionesTemp3"
        lcSQL &= " @ID_Vendedor=" & glCodVen.ToString
        lcSQL &= ",@ID_Estacion=" & glEstacion.ToString
        lcSQL &= ",@ID_Empresa=" & DirectCast(cmbOperadora.SelectedItem, clsEmpresa).ID.ToString
        lcSQL &= ",@CedulaCliente='" & txtCedula.Text & "'"
        lcSQL &= ",@TelefonoCel='" & lblPrefijo.Text & txtNumero.Text & "'"
        lcSQL &= ",@Usuario='" & glUser & "'"
        lcSQL &= ",@Precio=" & txtMonto.Text.Replace(",", ".")
        Try
            RecSet = Conx.Execute(lcSQL)
            'Dim ilRET As Integer = ExecSP(lcSQL, True)
            'PRESUPONE QUE SI NO VIENE RESPUESTA, ES PORQUE HUBO UN RAISERROR
            'AUNQUE TODAS LAS RESPUESTAS 
            If RecSet.EOF Then
                MessageBox.Show("No se realizó la venta de la recarga.", "Error en la recarga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor.Current = Cursors.Default
                tmrBlink.Stop()
                lblProcesando.Visible = False
                pnlBotonesVerificar.Visible = True
                Call ClearCRT()
                Exit Sub
            End If
            lcRespCode = If(IsDBNull(RecSet("RespCode").Value), "NL", RecSet("RespCode").Value).ToString
            lcSeqNum = CInt(If(IsDBNull(RecSet("SeqNum").Value), 0, RecSet("SeqNum").Value))
            lcResponse = If(IsDBNull(RecSet("Response").Value), " ", RecSet("Response").Value).ToString
            lcVoucher = If(IsDBNull(RecSet("Voucher1").Value), "", RecSet("Voucher1").Value).ToString
            lcVoucher &= If(IsDBNull(RecSet("Voucher2").Value), "", RecSet("Voucher2").Value).ToString
            If VerificaCampo(RecSet, "Voucher3") Then lcVoucher &= If(IsDBNull(RecSet("Voucher3").Value), "", RecSet("Voucher3").Value).ToString
            If VerificaCampo(RecSet, "Voucher4") Then lcVoucher &= If(IsDBNull(RecSet("Voucher4").Value), "", RecSet("Voucher4").Value).ToString
            rsetClose(RecSet)
            arrRespuesta = lcResponse.Split(" ")

            If arrRespuesta.GetUpperBound(0) >= 17 Then
                If arrRespuesta(17).Length > 1 Then lcError = arrRespuesta(17)
            End If
            If arrRespuesta.GetUpperBound(0) >= 18 Then
                If arrRespuesta(18).Length > 1 Then lcMensaje = arrRespuesta(18)
            End If
        Catch ex As Exception 'MANEJO DE LOS RAISERROR???
            MessageBox.Show("Problemas al procesar la venta de la recarga. Por favor intente de nuevo." & vbCrLf & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cursor.Current = Cursors.Default
            tmrBlink.Stop()
            lblProcesando.Visible = False
            pnlBotonesVerificar.Visible = True
            Call ClearCRT()
            Exit Sub
        End Try

        If lcRespCode.Trim <> "" Then
            'RESPUESTA SIN SALDO
            If lcRespCode = "AG" Then 'SIN SALDO
                Cursor.Current = Cursors.Default
                Dim frmSS As New frmSinSaldo
                'frmSS.MdiParent = Me.MdiParent
                frmSS.ShowDialog()
            ElseIf lcRespCode = "00" Then
                lblUltTrans.Text = lcSeqNum.ToString
                Call ImprimirRecibo(arrRespuesta, lcVoucher)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else 'CUALQUIER RESPUESTA DE ERROR
                Call MostrarRespuesta(lcRespCode, lcError, lcMensaje)
            End If
        Else
            MessageBox.Show("No hubo respuesta de la operadora. Intente más tarde.", "Sin respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        tmrBlink.Stop()
        lblProcesando.Visible = False
        pnlBotonesVerificar.Visible = True
        Call BuscaSaldo()

        Cursor.Current = Cursors.Default
        Call ClearCRT()
        Call CargarEmpresas()
    End Sub

    Private Sub btnVerificarRegresar_Click(sender As Object, e As EventArgs) Handles btnVerificarRegresar.Click
        lblProducto.Text = ""
        lblPrecio.Text = ""
        lblVerificarCedula.Text = ""
        lblVerificarNumero.Text = ""

        lblTitCedula.Visible = False
        lblCedula.Visible = False
        lblVerificarCedula.Visible = False

        grpDatos.Visible = True
        grpVerificar.Visible = False
        cmbOperadora.Focus()
    End Sub

    Private Sub cmbOperadora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbOperadora.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cmbOperadora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperadora.SelectedIndexChanged
        If cmbOperadora.SelectedIndex = -1 Then
            picLogo.Image = Nothing
            txtCedula.Text = "0"
            lblCedula.Visible = False
            lblPrefijo.Text = ""
            lblPrefijo.Visible = False
            lblAyuda.Visible = False
            lblMsgLimites.Text = ""
            Exit Sub
        End If
        ReDim arrSeriales(-1)
        arrSeriales = DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Seriales.Split(";")
        If DirectCast(cmbOperadora.SelectedItem, clsEmpresa).UsaCedula Then
            lblCedula.Visible = True
            txtCedula.Visible = True
        Else
            txtCedula.Text = "0"
            lblCedula.Visible = False
            txtCedula.Visible = False
        End If
        If DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Serial.Trim = "" Then
            lblPrefijo.Text = ""
            lblCodigo.Visible = False
            lblPrefijo.Visible = False
            lblAyuda.Visible = False
        Else
            lblCodigo.Visible = True
            lblPrefijo.Visible = True
            lblPrefijo.Text = DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Serial
            lblAyuda.Visible = True
        End If
        txtNumero.MaxLength = DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Longitud
        lblMsgLimites.Text = DirectCast(cmbOperadora.SelectedItem, clsEmpresa).MsgLimites
        'Buscar el logo de la operadora (POR AHORA SIGUE CABLEADO!!!!)
        If DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("DIRECTV") Then
            picLogo.Image = My.Resources.logo_directv
        ElseIf DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("MOVILNET") Then
            picLogo.Image = My.Resources.logo_movilnet
        ElseIf DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("DIGITEL") Then
            picLogo.Image = My.Resources.logo_digitel
        ElseIf DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("MOVISTAR") Then
            picLogo.Image = My.Resources.logo_movistar
        ElseIf DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("NETUNO") Then
            picLogo.Image = My.Resources.logo_netuno
        ElseIf DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("CANTV") Then
            picLogo.Image = My.Resources.logo_cantv
        ElseIf DirectCast(cmbOperadora.SelectedItem, clsEmpresa).Nombre.StartsWith("SIMPLETV") Then
            picLogo.Image = My.Resources.logo_simpletv
        Else
            picLogo.Image = Nothing
        End If
    End Sub

    Private Sub frmVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call CambiarCodigo()
            e.Handled = True
        End If
    End Sub

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Call CargarEmpresas()
        Call BuscarUltNroTrans()
        Call BuscaSaldo()
    End Sub

    Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtCedula.GotFocus, txtNumero.GotFocus, txtMonto.GotFocus
        DirectCast(sender, TextBox).SelectAll()
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress, txtNumero.KeyPress
        If vbNumbers.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If vbMonto.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        'no pueden haber dos comas
        If e.KeyChar = ","c And txtMonto.Text.IndexOf(",") <> -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub tmrBlink_Tick(sender As Object, e As EventArgs) Handles tmrBlink.Tick
        lblProcesando.Visible = Not lblProcesando.Visible
    End Sub
End Class