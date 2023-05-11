Option Strict On
Imports System.Collections.Specialized
Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class frmLogin
    Friend LoggedIN As Boolean = False

    Private wordx As String

    Private Sub LoadAllServers()
        Dim idxReg, idxAct, idxReal As Integer
        Dim LineaSplit() As String
        Dim sDato As String = ""
        Dim aServers As StringCollection = My.Settings.Servers
        idxReg = 0
        Try
            If aServers Is Nothing Then
                aServers = New StringCollection From {
                    glIPServer & "|" & glBaseDatos & "|" & glCodVen & "|" & glEstacion & "|" & glUltUser & "|" & glNomVen
                }
                My.Settings.Servers = aServers
                My.Settings.Save()
            End If
            ReDim arrValues(aServers.Count - 1, 1)
            For Each sDato In aServers
                arrValues(idxReg, 0) = "Server" & idxReg.ToString.Trim
                arrValues(idxReg, 1) = sDato
                idxReg += 1
            Next
            ReDim arrServers(0 To arrValues.GetUpperBound(0))
            For idxReg = 0 To arrValues.GetUpperBound(0)
                If arrValues(idxReg, 0).ToUpper.Substring(0, 6) = "SERVER" Then
                    LineaSplit = arrValues(idxReg, 1).Split("|"c)
                    cmbServidor.Items.Add(LineaSplit(0) & " (" & LineaSplit(1) & ")")
                    idxReal = cmbServidor.Items.Count - 1
                    arrServers(idxReal).Servidor = LineaSplit(0).Trim           ' SERVIDOR
                    arrServers(idxReal).BaseDatos = LineaSplit(1).Trim          ' BASE DE DATOS
                    arrServers(idxReal).CodVendedor = CInt(LineaSplit(2).Trim)  ' ID. VENDEDOR
                    arrServers(idxReal).NroTaquilla = CShort(LineaSplit(3))     ' NRO. ESTACION
                    arrServers(idxReal).UltUser = LineaSplit(4).Trim            ' ULT. USUARIO
                    arrServers(idxReal).NomVendedor = LineaSplit(5).Trim        ' NOMBRE VENDEDOR
                    If glIPServer = LineaSplit(0).Trim AndAlso glBaseDatos = LineaSplit(1).Trim Then idxAct = idxReal
                End If
            Next idxReg
            cmbServidor.SelectedIndex = idxAct
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando lista de servidores. Indice #" & idxReg.ToString
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Function LoginDB() As Boolean
        Dim clC As New clsCesar, word1 As String = "vrtaq01" 'OJO OJO OJO Cambiar para cada programa

        Try
            'Key1 = glCodSemilla.Substring(0, 10)
            'Key2 = glCodSemilla.Substring(9, 10)
            'Key3 = glCodSemilla.Substring(20, 5)
            'clC.cSemilla = Key1 & Key2 & Key3
            clC.cSemilla = glCodSemilla.Substring(0, 10) & glCodSemilla.Substring(9, 10) & glCodSemilla.Substring(20, 5)

            lblStatus.Text = "Conectando con la base de datos..."
            lblStatus.Refresh()
            'Abriendo conexión con la BD remota
            If cmbServidor.SelectedIndex <> -1 Then
                glIPServer = arrServers(cmbServidor.SelectedIndex).Servidor 'cmbServidor.Text
            Else
                glIPServer = cmbServidor.Text
            End If
            glUser = txtUsuario.Text
            glPswdDef = word1.ToUpper & word2.ToUpper & word4.ToUpper
            glPswdDef = glPswdDef.Substring(0, glPswdDef.Length - 2)
            '''''glPswdDef = glPswdUnq
            ' Conecto al IP y DB seleccionado en login pero con usuario default
            If (Conx Is Nothing) Then
                If Not cxLogin(VisualRecargaPOS.modConn.SybProviderEnum.prSQLSERVER, glIPServer, glBaseDatos, glUserDef, clC.EncriptarCs(glPswdDef)) Then
                    conxClose(Conx)
                    MessageBox.Show("Error al conectar posible problemas de parametros favor revise.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Cursor.Current = Cursors.Default
                    Call rsetClose(RecSet)
                    Call conxClose(Conx)
                    Return False
                End If
            End If
        Catch ex As Exception
            Call MensajeError(ex, "Error de conexión.")
            Call rsetClose(RecSet)
            Call conxClose(Conx)
            Return False
        End Try
        Return True
    End Function

    Private Function LoginDBUnq() As Boolean
        Dim clC As New clsCesar
        Try
            clC.cSemilla = clC.ArrSems(4) & clC.ArrSems(9) & clC.ArrSems(2) & clC.ArrSems(8) & clC.ArrSems(0)
            lblStatus.Text = "Conectando con la base de datos..."
            lblStatus.Refresh()
            'Abriendo conexión con la BD remota
            If cmbServidor.SelectedIndex <> -1 Then
                glIPServer = arrServers(cmbServidor.SelectedIndex).Servidor 'cmbServidor.Text
            Else
                glIPServer = cmbServidor.Text
            End If
            glBaseDatos = "VR"

            wordx = Microsoft.VisualBasic.Chr(118) &
                    Microsoft.VisualBasic.Chr(105) &
                    Microsoft.VisualBasic.Chr(115) &
                    Microsoft.VisualBasic.Chr(117) &
                    Microsoft.VisualBasic.Chr(97) &
                    Microsoft.VisualBasic.Chr(108)

            glUserUnq = wordx & "1"
            glUserUnq = Vuelta("+î)îJî'îTî*îî2î")

            glPswdUnq = word1.ToUpper & word2.ToUpper & word4.ToUpper
            glPswdUnq = glPswdUnq.Substring(0, 15)
            clC.cSemilla = clC.ArrSems(4) & clC.ArrSems(5) & clC.ArrSems(6)

            ' Conecto al IP y DB seleccionado en login pero con usuario default
            If ConxU Is Nothing Then
                If Not cxLoginUnq(modConn.SybProviderEnum.prSQLSERVER, glIPServer, glBaseDatos, glUserUnq, clC.EncriptarCs(glPswdUnq)) Then
                    conxClose(ConxU)
                    MessageBox.Show("Error al conectar posible problemas de parametros favor revise.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Cursor.Current = Cursors.Default
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Call MensajeError(ex, "Error de conexión.")
            Call rsetClose(RecSet)
            Call conxClose(ConxU)
            End
        End Try
    End Function

    Private Sub MostrarDatosEntrada()
        lblServidor.Visible = True
        cmbServidor.Visible = True
        lblGrupo.Visible = True
        txtGrupo.Visible = True
        txtGrupo.Focus()
    End Sub

    Private Sub OcultarDatosEntrada()
        lblServidor.Visible = False
        cmbServidor.Visible = False
        lblGrupo.Visible = False
        txtGrupo.Visible = False
        'OK.Top = 1620
        'Cancel.Top = 1620
        'Me.Height = 2790
    End Sub

    Private Function SaveAppData(ByVal Host As String, ByVal BD As String, ByVal UltUsuario As String) As Boolean
        'Dim strKeyName As String, idxArr As Short
        Dim aServers As StringCollection
        Dim clC As New clsCesar With {
            .cSemilla = seed1 & seed2 & seed3
        }
        Try
            'quitarle a Host el nombre del grupo, si lo tiene.
            If Host.Contains("(") Then
                Host = Host.Substring(0, Host.IndexOf("("c) - 1)
            End If
            My.Settings.Host = Host
            My.Settings.BaseDatos = BD
            My.Settings.UltUser = UltUsuario
            My.Settings.AutoLogin = chkAuto.Checked
            If chkAuto.Checked Then My.Settings.AutoPasswd = clC.EncriptarCs(txtPassword.Text.Trim)

            My.Settings.CodVendedor = glCodVen
            'My.Settings.NomAgencia = glNomVen
            My.Settings.Estacion = CShort(glEstacion)

            'Cambio para usar la estructura de la lista que permite conexión a múltiples bases de datos.
            'by JOEL/VESC 17-04-2015
            aServers = My.Settings.Servers
            If IsNewServer(Host, BD) Then
                aServers.Add(Host & "|" & BD & "|" & glCodVen & "|" & glEstacion & "|" & UltUsuario & "|" & glNomVen)
                My.Settings.Servers = aServers
            End If
            'Reviso el primer item de la colección, es posible que UltUser esté vacío, entonces lo corrijo.
            Dim LineaSplit() As String = aServers(0).Split("|"c)
            If LineaSplit(4).Trim = "" Then
                'destruyo y vuelvo a crear la colección
                aServers.RemoveAt(0)
                aServers.Add(Host & "|" & BD & "|" & glCodVen & "|" & glEstacion & "|" & UltUsuario & "|" & glNomVen)
                My.Settings.Servers = aServers
            End If
            My.Settings.Save()
            Return True
        Catch ex As Exception
            Call MensajeError(ex, "Error guardando en el registry.")
            Return False
        End Try
    End Function

    Private Function ValEntReq() As Boolean
        ValEntReq = False
        If cmbServidor.Text = "" Then
            Console.Beep()
            MessageBox.Show("Debe colocar o seleccionar la dirección del servidor de datos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbServidor.Focus()
            Exit Function
        End If
        If txtGrupo.Text = "" Then
            Console.Beep()
            MessageBox.Show("Debe colocar el nombre del grupo", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGrupo.Focus()
            Exit Function
        End If
        If txtUsuario.Text = "" Then
            Console.Beep()
            MessageBox.Show("Debe colocar el código del usuario a conectarse", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUsuario.Focus()
            Exit Function
        End If
        If txtPassword.Text = "" Then
            Console.Beep()
            MessageBox.Show("Debe colocar la contraseña del usuario a conectarse", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Focus()
            Exit Function
        End If
        ValEntReq = True
    End Function

    'Private Sub VerificarRecursos()
    '    If Not System.IO.File.Exists(glAppPath & "Logo.jpg") Then Call BajarArchivo("CINTILLO")
    '    If Not System.IO.File.Exists(glAppPath & "LogoIni.jpg") Then Call BajarArchivo("LOGOINI")
    '    If Not System.IO.File.Exists(glAppPath & "LogoAdm.jpg") Then Call BajarArchivo("LOGOADM")

    '    If My.Settings.RazonSocial <> cGEN.RazonSocial 
    '    Or My.Settings.RIF.Replace("-", "") <> cGEN.Rif.Replace("-", "") 
    '    Or My.Settings.Contactos <> cGEN.Contacto Then
    '        My.Settings.RazonSocial = cGEN.RazonSocial
    '        My.Settings.RIF = cGEN.Rif.Insert(1, "-").Insert(10, "-")
    '        My.Settings.Contactos = cGEN.Contacto
    '        My.Settings.Save()
    '    End If
    'End Sub

    Private Sub cmbServidor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbServidor.SelectionChangeCommitted
        txtGrupo.Text = arrServers(cmbServidor.SelectedIndex).BaseDatos
        txtUsuario.Text = arrServers(cmbServidor.SelectedIndex).UltUser

        'Se modifican los datos globales si selecciono otra conexión de la lista,
        'de esta manera puede conectarse a múltiples comercializadores (bancas).
        'by JOEL/VESC 17-04-2015 (VisualLoto RULEZ!!!)
        glCodVen = arrServers(cmbServidor.SelectedIndex).CodVendedor
        glEstacion = arrServers(cmbServidor.SelectedIndex).NroTaquilla
        glNomVen = arrServers(cmbServidor.SelectedIndex).NomVendedor
        'Además, tengo que destruir cualquier conexión realizada con los datos anteriores
        Conx = Nothing
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        chkAuto.Checked = False
        MessageBox.Show("Entrada al sistema cancelada por el usuario!", "Login cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub btnEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrar.Click
        Dim clC As New clsCesar, iRET As Long ', lcAppRegistro As String
        ' modulo de seguridad
#If Not DEBUG Then
        Call ConectarAmiSQL() 'OJO OJO Seguridad desactivada en debug!
#End If
        If Not ValEntReq() Then
            chkAuto.Checked = False
            Call MostrarDatosEntrada()
            Exit Sub
        End If
        tmrAutoLogin.Stop()

        Cursor.Current = Cursors.AppStarting
        glIPClient = GetIpAddress()
        ' Obtengo la version de la aplicacion para enviar a chequear version
        glStrVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
        'Select Case glVersion
        '    Case 0
        '        glStrVersion = "TaqWEB." & glStrVersion 'Web
        '    Case 1
        '        glStrVersion = "TaqWRL." & glStrVersion 'Wireless
        '    Case 2
        '        glStrVersion = "TaqUSB." & glStrVersion 'USB Dungeon 
        '    Case 3
        '        glStrVersion = "TaqCEL." & glStrVersion 'Tablet or Smart phone (CHIP)
        'End Select
        'Armar string de parametros de conexion a enviar al socket
        glParamConex = "/\" & "/\" & "/\" & "/\" & "/\" & "/\" & "/\" & glStrVersion & "/\" &
         "/\" & "/\" & "/\" & "/\"
        lblStatus.Text = "Conectando con el servidor..."
        lblStatus.Refresh()
        If Not LoginDBUnq() Then
            Cursor.Current = Cursors.Default
            chkAuto.Checked = False
            Call MostrarDatosEntrada()
            Exit Sub
        End If
        ' Busco el usuario y su semilla correspondiente en la tabla dummy
        ' OJO OJO OJO Puedo colocar otras opciones adicionales por tipo de estación
        glSQL = "EXEC SpConDato @Tipo='T',@Grupo='" & txtGrupo.Text.Trim.ToUpper & "'"
        RecSet = ConxU.Execute(glSQL, CLng(iRET))
        If RecSet.EOF Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("El grupo " & txtGrupo.Text.Trim.ToUpper & " no existe.", "Grupo de datos inválido", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call rsetClose(RecSet)
            End
        End If
        'Muevo los datos a variables globales
        glCodSemilla = RecSet("Valor").Value.ToString
        glUserDef = If(Convert.IsDBNull(RecSet("Dato").Value), "", RecSet("Dato").Value).ToString
        glBaseDatos = RecSet("Posicion").Value.ToString
        glGrupo = txtGrupo.Text.Trim.ToUpper
        Call rsetClose(RecSet)
        Call conxClose(ConxU)
        ConxU = Nothing 'DESTRUYO EL OBJETO PARA EL PROX LOGIN
        'Armar string de parametros de conexion a enviar al socket
        glParamConex = glSerialDD & "/\" & glSerial & "/\" & glPCName & "/\" &
                       glIPClient & "/\" & glCodVen & "/\" & glEstacion & "/\" & txtUsuario.Text & "/\" & glStrVersion & "/\" &
                       glSistOper & "/\" & cmbServidor.Text & "/\" & txtGrupo.Text & "/\" & glNomVen & "/\" & glAppName

        ' Conectar al IP y DB seleccionado
        lblStatus.Text = "Conectando con la base de datos..."
        lblStatus.Refresh()
        If Not LoginDB() Then
            Cursor.Current = Cursors.Default
            chkAuto.Checked = False
            Call MostrarDatosEntrada()
            Conx = Nothing
            Exit Sub
        End If

        lblStatus.Text = "Actualizando fecha y hora..."
        lblStatus.Refresh()
        If Not BuscarFechaHora() Then
            HouseCleaning()
            End
        End If
        lblStatus.Text = "Chequeando estado del sistema..."
        lblStatus.Refresh()
        Try
            glSQL = "EXEC PosQryGeneral 'Status'"
            iRET = ExecSP(glSQL, True)
        Catch ex As Exception
            chkAuto.Checked = False
            Call MensajeError(ex, "Error de LOGIN. El programa de cerrará, intente nuevamente.")
            End
        End Try
        If Not RecSet.EOF Then
            If Not Microsoft.VisualBasic.IsDBNull(RecSet("StatusSistema").Value) Then
                MessageBox.Show("El sistema se encuentra actualmente en mantenimiento.", "Sistema en Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            End If
        End If
        lblStatus.Text = "Buscando datos del usuario..."
        lblStatus.Refresh()
        clC.cSemilla = seed1 & seed2 & seed3
        Try
            glSQL = "EXEC SpProLogin @Login='" & txtUsuario.Text & "',@Passwd='" & clC.EncriptarCs(txtPassword.Text) & "',@ID_Estacion=" & glEstacion & ",@Version=" & glVersion
            iRET = ExecSP(glSQL, True)
        Catch ex As Exception
            chkAuto.Checked = False
            Call MensajeError(ex, "Error de LOGIN. El programa de cerrará, intente nuevamente.")
            End
        End Try
        If RecSet.EOF Then
            chkAuto.Checked = False
            MessageBox.Show("Usuario o contraseña inválidos.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call rsetClose(RecSet)
            txtUsuario.Focus()
            Exit Sub
        End If
        lblStatus.Text = "Verificando serial de la estación..."
        lblStatus.Refresh()
        If glSerial <> clC.DecriptarCs(RecSet("Serial").Value.ToString) Then
            chkAuto.Checked = False
            MessageBox.Show("Los datos del registro de la estación no coinciden." & vbCrLf & "Favor comuníquese con su banca para volver a registrar la misma.", "Registrar Estación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            My.Settings.Reset()
            End
        End If
        'OJO Verifico que el código guardado en el REGISTRY sea igual al que devuelve el Login del usuario
        'Por esto no se puede loggear como banca y grupo al mismo tiempo.
        lblStatus.Text = "Verificando código del vendedor..."
        lblStatus.Refresh()
        'If glCodVen <> CInt(RecSet("ID_Vendedor").Value) Then
        '    chkAuto.Checked = False
        '    MessageBox.Show("Los datos del registro de la estación no coinciden." & vbCrLf & "Favor comuníquese con su banca para volver a registrar la misma.", "Registrar Estación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    My.Settings.Reset()
        '    End
        'End If
        lblStatus.Text = "Verificando nombre del PC..."
        lblStatus.Refresh()
        If Microsoft.VisualBasic.IsDBNull(RecSet("NombrePC").Value) Then
            chkAuto.Checked = False
            MessageBox.Show("El nombre del PC ha sido modificado." & vbCrLf & "Favor vuelva a registrar el equipo.", "Registrar PC", MessageBoxButtons.OK, MessageBoxIcon.Error)
            My.Settings.Reset()
            End
        End If
        If glPCName <> RecSet("NombrePC").Value.ToString Then
            chkAuto.Checked = False
            MessageBox.Show("El nombre del PC ha sido modificado." & vbCrLf & "Favor vuelva a registrar el equipo.", "Registrar PC", MessageBoxButtons.OK, MessageBoxIcon.Error)
            My.Settings.Reset()
            End
        End If
        lblStatus.Text = "Verificando estado del usuario..."
        lblStatus.Refresh()
        If RecSet("UsrStatus").Value.ToString <> "A" Then
            chkAuto.Checked = False
            MessageBox.Show("El usuario está suspendido para utilizar el sistema", "Login (Suspendido)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call rsetClose(RecSet)
            lblStatus.Text = ""
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        lblStatus.Text = "Verificando tipo de usuario..."
        lblStatus.Refresh()
        If RecSet("TipoUsuario").Value.ToString <> "T" Then
            chkAuto.Checked = False
            MessageBox.Show("El usuario no es válido para este sistema", "Login (Tipo Usuario)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call rsetClose(RecSet)
            lblStatus.Text = ""
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        lblStatus.Text = "Verificando estado del vendedor..."
        lblStatus.Refresh()
        If RecSet("VenStatus").Value.ToString = "S" Then
            chkAuto.Checked = False
            MessageBox.Show("El vendedor está suspendido para entrar en el sistema." & vbCrLf & "Contacte a su banca.", "Vendedor Suspendido", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = ""
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        'Se chequea si la agencia esta inactiva para vender
        If RecSet("VenStatus").Value.ToString = "I" Then
            chkAuto.Checked = False
            MessageBox.Show("El vendedor está inactivo para entrar en el sistema." & vbCrLf & "Contacte a su banca.", "Vendedor Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = ""
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        lblStatus.Text = "Verificando tipo de vendedor..."
        lblStatus.Refresh()
        If CShort(RecSet("TipoVendedor").Value) <> 5 Then
            chkAuto.Checked = False
            MessageBox.Show("El vendedor no es válido para este sistema.", "Login (Tipo Vendedor)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = ""
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        glCodVen = CInt(RecSet("ID_Vendedor").Value)
        glNomVen = RecSet("Vendedor").Value.ToString
        glNombre = RecSet("Usuario").Value.ToString
        glPermisos = RecSet("Permisos").Value.ToString
        glUser = txtUsuario.Text
        glUltUser = txtUsuario.Text
        glPasswd = txtPassword.Text

        'Cambio para usar la estructura de la lista que permite conexión a múltiples bases de datos.
        'by JOEL/VESC 17-04-2015
        'Siempre guardar los campos transcritos, porque se puede reutilizar el servidor. by VESC 09-09-2016
        'If cmbServidor.SelectedIndex <> -1 Then
        '    ' Guardo el registro de los parametros de la agencia
        '    Call SaveAppData(arrServers(cmbServidor.SelectedIndex).Servidor, 
        '                     arrServers(cmbServidor.SelectedIndex).BaseDatos, 
        '                     txtUsuario.Text)
        'Else
        ' Guardo el registro de los parametros de la agencia
        Call SaveAppData(cmbServidor.Text, txtGrupo.Text, txtUsuario.Text)
        'End If

        ' Chequear si existe nueva versión
        lblStatus.Text = "Verificando nuevas versiones..."
        lblStatus.Refresh()
        If RecSet("Actualizado").Value.ToString <> "S" Then
            Try
                'Primera consulta (funciona como un cursor)
                glSQL = "EXEC SpConNuevaVersion @ID_Vendedor=" & glCodVen & ",@ID_Estacion=" & glEstacion & ",@Version='" & glStrVersion & "'"
                iRET = ExecSP(glSQL, True)
            Catch ex As Exception
                Call MensajeError(ex, "Error Consultando Nueva Versión.")
            End Try
            Do While RecSet("Actualizacion").Value.ToString <> "NO"
                ' Si este archivo existe, ya se bajó una de las actualizaciones, marcar como lista.
                If ArchivoExiste("TRANSFER_COMPLETED") Then
                    Call EliminarArchivo("TRANSFER_COMPLETED")
                    glSQL = "EXEC SpUpdNuevaVersion @ID_Registro=" & RecSet("ID_Registro").Value.ToString
                    iRET = ExecSP(glSQL, False)
                Else
                    ' Si no existe, hay que bajarlo
                    If ArmarActualizacion(RecSet("NomExeDown").Value.ToString,
                                             RecSet("NomExeReal").Value.ToString,
                                             RecSet("TipoFtp").Value.ToString,
                                             RecSet("FtpIpAddress").Value.ToString,
                                             RecSet("FtpLogin").Value.ToString,
                                             RecSet("FtpPasswd").Value.ToString) Then
                        If Not EjecutarComandoDownLoad() Then End
                    End If
                End If
                'Consulta interna (funciona como un cursor)
                glSQL = "EXEC SpConNuevaVersion @ID_Vendedor=" & glCodVen & ",@ID_Estacion=" & glEstacion & ",@Version='" & glStrVersion & "'"
                iRET = ExecSP(glSQL, True)
            Loop
        End If
        lblStatus.Text = ""
        lblStatus.Refresh()
        LoggedIN = True
        Me.Dispose()
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Dim frmRst As New frmResetRegistro
        Me.Hide()
        frmRst.Show()
    End Sub

    Private Sub chkAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged
        tmrAutoLogin.Enabled = chkAuto.Checked
        If chkAuto.Checked Then
            lblStatus.Text = "Auto login en 5 segundos..." : lblStatus.Refresh()
        Else
            lblStatus.Text = "" : lblStatus.Refresh()
        End If
    End Sub

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If txtUsuario.Text.Trim = "" Then txtUsuario.Focus() Else txtPassword.Focus()
    End Sub

    Private Sub frmLogin_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not LoggedIN Then End
        Call InicializarMDI()
        End
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GetAppDataConex() Then
            LoadAllServers()
            txtGrupo.Text = glBaseDatos
            '
            If cmbServidor.Items.Count = 1 Then OcultarDatosEntrada()
        Else
            LoadAllServers()
            txtGrupo.Text = glBaseDatos
        End If
        txtUsuario.Text = glUltUser

        If glAutoLogin Then
            Dim lcDcr = New clsCesar With {
                .cSemilla = seed1 & seed2 & seed3
            }
            txtPassword.Text = lcDcr.DecriptarCs(My.Settings.AutoPasswd)
            lcDcr = Nothing
            chkAuto.Checked = True
            lblStatus.Text = "Auto login en 5 segundos..."
            lblStatus.Refresh()
            tmrAutoLogin.Enabled = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGrupo.GotFocus, txtUsuario.GotFocus, txtPassword.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrupo.KeyPress, txtUsuario.KeyPress, txtPassword.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Call btnEntrar_Click(sender, e)
        End If
    End Sub

    Private Sub tmrAutoLogin_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrAutoLogin.Tick
        tmrAutoLogin.Stop()
        Call btnEntrar_Click(sender, e)
    End Sub
End Class
