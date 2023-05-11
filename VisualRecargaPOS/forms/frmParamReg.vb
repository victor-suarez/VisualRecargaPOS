Option Strict On
Imports System
Imports Microsoft.Win32
Friend Class frmParamReg
    Inherits System.Windows.Forms.Form

    Private arrValues(,) As String

    Private Const seed1 As String = "51804"
    Private Const seed3 As String = "03629"
    Public Const key3 As String = "36291"


    Private word1 As String
    Private word2 As String
    Private Const word3 As String = "recargado"
    Private Const gfDBDef As String = "VR" ' Base de datos generica (master)
    Private gfUser As String
    Private gfUserDef As String       ' Usuario generico (unico)
    Private gfPswd As String

    Private gfIPServer As String
    Private gfBaseDatos As String

    Private gfCodVen As Integer
    Private gfNomVen As String
    Private gfGrupo As String
    Private gfSerial As String
    Private gfEstacion As Short
    Private gfVersion As Short
    Private gfPCName As String
    Private Const gfAppType As String = "T" 'Esto cambia en cada programa OJO OJO OJO
    Private Const gfAplicacion As String = "VisualRecarga"

    Private Function GenerarSerial() As String
        Dim strSerial As String, bolLetraNro As Boolean, strChar As Char
        Dim Generator As System.Random = New System.Random()
        strSerial = ""
        Try
            Do While strSerial.Length < 32
                bolLetraNro = (CInt(Generator.Next(0, 100)) < 50)
                If bolLetraNro Then
                    strChar = System.Convert.ToChar((Char.ConvertToUtf32("Z", 0) - Char.ConvertToUtf32("A", 0)) * CInt(Generator.Next(0, 1)) + Char.ConvertToUtf32("A", 0))
                Else
                    strChar = System.Convert.ToChar((Char.ConvertToUtf32("9", 0) - Char.ConvertToUtf32("0", 0)) * CInt(Generator.Next(0, 1)) + Char.ConvertToUtf32("0", 0))
                End If
                strSerial = strSerial & strChar
            Loop
        Catch ex As Exception
            Call MensajeError(ex)
        End Try
        GenerarSerial = strSerial
    End Function

    Private Sub GetAppDataConex()
        Try
            gfCodVen = My.Settings.CodVendedor
            gfBaseDatos = My.Settings.BaseDatos
            gfIPServer = My.Settings.Host
            gfNomVen = My.Settings.NomVendedor
            gfEstacion = My.Settings.Estacion
            gfVersion = My.Settings.Version
            LBNombrePCReg.Text = System.Environment.MachineName
        Catch ex As Exception
            Dim strFixMsg As String = "Error consiguiendo los datos de conexión."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Function ObtenerSerial() As String
        Dim Serial As String
        Try
            Serial = FingerPrint.Value()
            If Serial.Trim.Length = 0 Then Serial = GenerarSerial()
            If Serial.Trim.Length < 32 Then Serial = Serial.PadLeft(32, "0"c)
        Catch ex As Exception
            Serial = GenerarSerial()
        End Try
        Return Serial
    End Function

    Private Function ValEntReq() As Boolean
        ValEntReq = True
        If INServidor.Text = "" Then
            MessageBox.Show("Debe colocar la dirección o el nombre del servidor de datos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            INServidor.Focus()
            Exit Function
        End If
        If INBaseDatos.Text = "" Then
            MessageBox.Show("Debe colocar el nombre del grupo", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            INBaseDatos.Focus()
            Exit Function
        End If
        If CBVersion.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar la version a utilizar", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBVersion.Focus()
            Exit Function
        End If
        If INVendedor.Text = "" Then
            MessageBox.Show("Debe colocar el codigó de la agencia a registrar", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            INVendedor.Focus()
            Exit Function
        End If
        If INNroTaquilla.Text = "" Then
            MessageBox.Show("Debe colocar el código de la taquilla a conectarse", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            INNroTaquilla.Focus()
            Exit Function
        End If
        ValEntReq = False
    End Function

    Private Sub CargarParametrosRegistro()
        gfIPServer = My.Settings.Host
        gfBaseDatos = My.Settings.BaseDatos
        gfCodVen = My.Settings.CodVendedor
        gfEstacion = My.Settings.Estacion
        gfNomVen = My.Settings.NomVendedor
        gfVersion = My.Settings.Version

        INServidor.Text = gfIPServer
        INBaseDatos.Text = gfBaseDatos
        CBVersion.SelectedIndex = gfVersion
        INVendedor.Text = gfCodVen.ToString
        LBVendedor.Text = gfCodVen.ToString
        LBNomVendedor.Text = gfNomVen
        INNroTaquilla.Text = gfEstacion.ToString
        LBNroTaquilla.Text = gfEstacion.ToString
        If gfNomVen = "" Or gfSerial Is Nothing Then
            LBSerialAReg.Text = ObtenerSerial()
            gfSerial = LBSerialAReg.Text
        Else
            LBSerialAReg.Text = gfSerial
        End If
        LBSerialReg.Text = gfSerial
        LBNombrePCAct.Text = System.Environment.MachineName
        LBNombrePCReg.Text = System.Environment.MachineName
    End Sub

    Private Sub VerificarRegistro()
        Dim strSerialEnviado As String
        TitVerificado.Visible = False
        Dim clC As New clsCesar
        clC.cSemilla = seed1 & seed2 & seed3
        If BTVerificar.Text = "V&erificar" Then
            ' Verifico parametros recibidos
            If Convert.IsDBNull(RecSet("Serial").Value.ToString) Then
                strSerialEnviado = ""
            Else
                strSerialEnviado = clC.DecriptarCs(RecSet("Serial").Value.ToString)
            End If

            If strSerialEnviado <> LBSerialAReg.Text Then
                MessageBox.Show("El serial es distinto al serial registrado en el sistema." & vbCrLf & "Debe enviar el número presionando el boton de enviar serial para ser registrado en su sistema.", "Registrar Serial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BTEnvSerial.Visible = True
                'Exit Sub
            End If
            LBVendedor.Text = RecSet("ID_Vendedor").Value.ToString
            LBNroTaquilla.Text = RecSet("ID_Estacion").Value.ToString
            LBNomVendedor.Text = RecSet("Nombre").Value.ToString
            If RecSet("Serial").Value.ToString <> "NO DEFINIDO" Then
                LBSerialReg.Text = clC.DecriptarCs(RecSet("Serial").Value.ToString)
            Else
                LBSerialReg.Text = RecSet("Serial").Value.ToString
            End If
            LBNombrePCReg.Text = If(Convert.IsDBNull(RecSet("NombrePC").Value.ToString), "", RecSet("NombrePC").Value.ToString).ToString
            gfSerial = LBSerialAReg.Text
            gfNomVen = If(Convert.IsDBNull(RecSet("Nombre").Value.ToString), "", RecSet("Nombre").Value.ToString).ToString
            TitVerificado.Visible = True
            BTVerificar.Text = "&Registrar PC"
            Exit Sub
        ElseIf BTVerificar.Text = "&Registrar PC" Then
            If LBNombrePCAct.Text <> If(Convert.IsDBNull(RecSet("NombrePC").Value.ToString), "", RecSet("NombrePC").Value.ToString).ToString Then
                MessageBox.Show("El nombre de su PC es distinto al nombre registrado en sistema" & vbCrLf & "Favor presione el botón para registrarlo en el sistema.", "Registrar PC", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            LBNombrePCReg.Text = LBNombrePCAct.Text
            gfPCName = LBNombrePCAct.Text
            TitVerificado.Text = "PC Registrado"
            TitVerificado.Visible = True
            BTVerificar.Text = "&Guardar"
        End If
        If Not SaveAppDataReg() Then Exit Sub
        BTVerificar.Visible = False

        MessageBox.Show("Registro concluído. Pulse el botón [Salir] para ingresar al sistema.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'MessageBox.Show("Para culminar el registro debe configurar la impresora en el Menú" & vbCrLf & "Mantenimiento -> Configuración" & vbCrLf & "Ahi se procederá a chequear el registro de la comercializadora en la memoria fiscal." & vbCrLf & "Debe conectar la impresora y tenerla en línea para este procedimiento. Una vez encendida puede continuar.", "Conectar Impresora", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Call rsetClose(RecSet)
        Call conxClose(Conx)
    End Sub

    Private Function SaveAppDataReg() As Boolean
        Dim aServers As System.Collections.Specialized.StringCollection
        Try
            'Save the value to the registry
            '''''''''''''''''''''My.Settings.Serial = clC.EncriptarCs(gfSerial)
            ' Luego registro los parametros de la agencia
            My.Settings.CodVendedor = gfCodVen
            My.Settings.BaseDatos = gfGrupo
            My.Settings.Host = gfIPServer
            My.Settings.NomVendedor = gfNomVen
            My.Settings.Estacion = gfEstacion
            My.Settings.Version = gfVersion

            'Agrego los parámetros del registro a la lista de servidores de conexión.
            'Por supuesto con el usuario en blanco porque nunca se deben haber conectado.
            aServers = My.Settings.Servers
            If aServers Is Nothing Then
                aServers = New System.Collections.Specialized.StringCollection
                aServers.Add(gfIPServer & "|" & gfGrupo & "|" & gfCodVen & "|" & gfEstacion & "|" & "|" & gfNomVen)
                My.Settings.Servers = aServers
            Else
                If lcIsNewServer(aServers, gfIPServer, gfGrupo) Then
                    aServers.Add(gfIPServer & "|" & gfGrupo & "|" & gfCodVen & "|" & gfEstacion & "|" & "|" & gfNomVen)
                    My.Settings.Servers = aServers
                End If
            End If
            My.Settings.Save()

            glCodVen = gfCodVen
            glGrupo = gfGrupo
            glIPServer = gfIPServer
            glNomVen = gfNomVen
            glEstacion = gfEstacion
            glVersion = gfVersion
            Return True
        Catch ex As Exception
            Dim strFixMsg As String = "Error guardando data de conexión."
            Call MensajeError(ex, strFixMsg)
            Return False
        End Try
    End Function

    Private Function lcIsNewServer(ByVal aServers As System.Collections.Specialized.StringCollection, ByVal strServer As String, ByVal strDatabase As String) As Boolean
        For Each sSrv As String In aServers
            If sSrv.StartsWith(strServer & "|" & strDatabase) Then Return False
        Next
        Return True
    End Function

    Private Sub BTEnvSerial_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BTEnvSerial.Click
        Dim iRET As Integer = 0
        Dim strSQL As String = ""
        Dim clC As New clsCesar
#If Not DEBUG Then
        modSLM.ConectarAmiSQL()
#End If
        clC.cSemilla = seed1 & seed2 & seed3

        Cursor.Current = Cursors.AppStarting
        If Conx Is Nothing Then
            MessageBox.Show("Debe presionar el botón de verificar antes de enviar el serial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Try
            strSQL = "EXEC SpProRegTerm @Modo='E'"
            strSQL = strSQL & ",@ID_Vendedor='" & gfCodVen & "'"
            strSQL = strSQL & ",@ID_Estacion=" & gfEstacion
            strSQL = strSQL & ",@Serial='" & clC.EncriptarCs(LBSerialAReg.Text) & "'"
            ' Usuario para registro automático (Sin llamada al CALLCENTER)
            If txtUsuario.Text <> "" Then
                strSQL = strSQL & ",@Usuario='" & txtUsuario.Text.Trim & "'"
                strSQL = strSQL & ",@Password='" & clC.EncriptarCs(txtPassword.Text.Trim) & "'"
            End If
            iRET = ExecSP(strSQL, True)
        Catch ex As Exception
            Dim strFixMsg As String = "Problemas para enviar el registro al sistema."
            Call MensajeError(ex, strFixMsg)
            Exit Sub
        End Try
        Call rsetClose(RecSet)
        TitVerificado.Text = "Serial Enviado"
        TitVerificado.Visible = True
        BTEnvSerial.Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BTSalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BTSalir.Click
        Call rsetClose(RecSet)
        Call conxClose(Conx)
        Application.DoEvents()
        Me.Close()
    End Sub

    Private Sub frmParamReg_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.AppStarting
        GetAppDataConex()

        ' Modulo por seguridad
#If Not DEBUG Then
        modSLM.ConectarAmiSQL()
#End If
        word2 = Microsoft.VisualBasic.Chr(116) & Microsoft.VisualBasic.Chr(117)

        Call CargarParametrosRegistro()

        Cursor.Current = Cursors.Default
        lblVersion.Text = String.Format("V:{0}", My.Application.Info.Version.ToString)
    End Sub

    Private Sub BTVerificar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BTVerificar.Click
        Dim iRET As Integer
        Dim strSQL As String
        Dim clC As New clsCesar
        strSQL = ""
        'modulo de seguridad desactivado OJO OJO OJO
#If Not DEBUG Then
        modSLM.ConectarAmiSQL()
#End If
        Try
            If BTVerificar.Text = "V&erificar" Then
                If ValEntReq() Then Exit Sub
                ' Arreglo la semilla del login de instalacion
                clC.cSemilla = clC.ArrSems(4) & clC.ArrSems(9) & clC.ArrSems(2) & clC.ArrSems(8) & clC.ArrSems(0)
                Cursor.Current = Cursors.AppStarting

                gfIPServer = INServidor.Text
                gfBaseDatos = gfDBDef
                word1 = Microsoft.VisualBasic.Chr(118) &
                        Microsoft.VisualBasic.Chr(105) &
                        Microsoft.VisualBasic.Chr(115) &
                        Microsoft.VisualBasic.Chr(117) &
                        Microsoft.VisualBasic.Chr(97) &
                        Microsoft.VisualBasic.Chr(108)

                gfUser = word1 & "1"
                gfUser = Vuelta("+î)îJî'îTî*îî2î")

                gfPswd = word1.ToUpper & word2.ToUpper & word3.ToUpper
                gfPswd = gfPswd.Substring(0, 15)
                clC.cSemilla = clC.ArrSems(4) & clC.ArrSems(5) & clC.ArrSems(6)
                'Dim sTemp As String = clC.EncriptarCs(gfPswd)
                gfCodVen = CInt(INVendedor.Text)
                gfEstacion = CShort(INNroTaquilla.Text)

                If Conx Is Nothing Then
                    If Not cxLogin(SybProviderEnum.prSQLSERVER, gfIPServer, gfBaseDatos, gfUser, clC.EncriptarCs(gfPswd)) Then
                        conxClose(Conx)
                        MessageBox.Show("Error_BTVerificar_Click" & vbCrLf & "No hay conexión con el servidor." & vbCrLf & "Revise los parametros de conexión.", "Error Conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Cursor.Current = Cursors.Default
                        Exit Sub
                    End If
                End If
                strSQL = "USE " & gfDBDef & ";"
                iRET = ExecSP(strSQL, False)
                'OJO OJO OJO NO HAY MANEJO DE ERRORES LOCAL
                'Buscar la base de datos y el grupo.
                strSQL = "EXEC SpConDato @Tipo='" & gfAppType & "',@Grupo='" & INBaseDatos.Text & "'"
                iRET = ExecSP(strSQL, True)
                If RecSet.EOF Then
                    MessageBox.Show("El grupo no está registrado en el sistema por la empresa. Comuníquese para su registro.", "Grupo No Registrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Call rsetClose(RecSet)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
                ' Cambiar usuario de base de datos segun datos de entrada del login
                gfBaseDatos = RecSet("Posicion").Value.ToString
                gfGrupo = INBaseDatos.Text.Trim.ToUpper

                'Se agregan los corchetes para bases de dato con nombres que contienen caracteres especiales,
                'espacios o comienzan con número [9NOINNING].
                strSQL = "USE [" & gfBaseDatos.Replace("[", "").Replace("]", "") & "];"
                iRET = ExecSP(strSQL, False)

                strSQL = "EXEC SpConEstaciones @ID_Vendedor='" & gfCodVen & "',@ID_Estacion=" & gfEstacion
                iRET = 0
                iRET = ExecSP(strSQL, True)
                If RecSet.EOF Then
                    If txtUsuario.Text.Trim <> "" AndAlso txtPassword.Text.Trim <> "" Then
                        clC.cSemilla = seed1 & seed2 & seed3
                        strSQL = "EXEC SpAddEstaciones @ID_Vendedor" & gfCodVen
                        strSQL = strSQL & ",@ID_Estacion=" & gfEstacion
                        strSQL = strSQL & ",@Tipo='T'" 'Genérica tipo taquilla
                        strSQL = strSQL & ",@UsrAdd='" & txtUsuario.Text.Trim & "'"
                        strSQL = strSQL & ",@Password='" & clC.EncriptarCs(txtPassword.Text.Trim) & "'"
                        Try
                            iRET = ExecSP(strSQL, True)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message & vbCrLf & "Usuario registrador no es válido.", "Estación No Registrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Call rsetClose(RecSet)
                            Cursor.Current = Cursors.Default
                            Exit Sub
                        End Try
                    Else
                        MessageBox.Show("Estación no registrada por la administración. Comuníquese para su registro.", "Estación No Registrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Call rsetClose(RecSet)
                        Cursor.Current = Cursors.Default
                        Exit Sub
                    End If
                End If
                Call VerificarRegistro()
            ElseIf BTVerificar.Text = "&Registrar PC" Then
                strSQL = "EXEC SpProRegTerm @Modo='P'"
                strSQL = strSQL & ",@ID_Vendedor=" & gfCodVen.ToString
                strSQL = strSQL & ",@ID_Estacion=" & gfEstacion.ToString
                strSQL = strSQL & ",@NombrePC='" & LBNombrePCAct.Text & "'"
                iRET = 0
                iRET = ExecSP(strSQL, True)
                If RecSet.EOF Then
                    MessageBox.Show("Estación no registrada en el sistema.", "Estación No Registrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
                If RecSet("NombrePC").Value.ToString = "EXISTE" Then
                    MessageBox.Show("Nombre del PC ya existe en el sistema" & vbCrLf & "Debe cambiar el nombre su equipo para volver ser registrado.", "Nombre PC Existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
                Call VerificarRegistro()
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Problemas para verificar estación."
            Call MensajeError(ex, strFixMsg)
            Call conxClose(Conx)
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub INCampo_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles INServidor.Enter, INBaseDatos.Enter, INNroTaquilla.Enter, INVendedor.Enter
        DirectCast(eventSender, TextBox).SelectAll()
    End Sub

    Private Sub INServidor_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles INServidor.KeyPress
        If ("0123456789abcdefghijklmnopqrstuvwxyz.-_" & System.Convert.ToChar(Keys.Back) & System.Convert.ToChar(Keys.Return)).IndexOf(eventArgs.KeyChar) = -1 Then eventArgs.Handled = True : Exit Sub
        If eventArgs.KeyChar = System.Convert.ToChar(Keys.Return) Then eventArgs.Handled = True : SelectNextControl(INServidor, True, True, True, False)
    End Sub

    Private Sub INBaseDatos_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles INBaseDatos.KeyPress
        If eventArgs.KeyChar = System.Convert.ToChar(Keys.Return) Then eventArgs.Handled = True : SelectNextControl(INBaseDatos, True, True, True, False)
    End Sub

    Private Sub CBVersion_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CBVersion.SelectedIndexChanged
        gfVersion = CShort(CBVersion.SelectedIndex)
    End Sub

    Private Sub CBVersion_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles CBVersion.KeyPress
        If eventArgs.KeyChar = System.Convert.ToChar(Keys.Return) Then eventArgs.Handled = True : SelectNextControl(CBVersion, True, True, True, False)
    End Sub

    Private Sub INNroTaquilla_KeyPress(ByVal eventSender As System.Object, ByVal e As KeyPressEventArgs) Handles INNroTaquilla.KeyPress
        If vbNumbers.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then e.Handled = True : SelectNextControl(INNroTaquilla, True, True, True, False)
    End Sub

    Private Sub INVendedor_KeyPress(ByVal eventSender As System.Object, ByVal e As KeyPressEventArgs) Handles INVendedor.KeyPress
        If vbNumbers.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            SelectNextControl(INVendedor, True, True, True, False)
            e.Handled = True
        End If
    End Sub

    Private Sub INVendedor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles INVendedor.Validated
        INVendedor.Text = INVendedor.Text.ToString.Replace(" ", "").PadLeft(5, "0"c)
    End Sub
End Class