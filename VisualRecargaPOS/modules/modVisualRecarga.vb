Option Strict On
Imports System.Collections.Specialized
Imports System.IO
Imports System.IO.Ports
Imports System.Diagnostics
Imports System.Windows.Forms.Keys
Imports Microsoft.VisualBasic.ControlChars

Module modVisualRecarga
    Private Structure SYSTEMTIME
        Friend Year As Short
        Friend Month As Short
        Friend DayOfWeek As Short
        Friend Day As Short
        Friend Hour As Short
        Friend Minute As Short
        Friend Second As Short
        Friend Milliseconds As Short
    End Structure

    <Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True)>
    Private Function SetLocalTime(ByRef lpSystemTime As SYSTEMTIME) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SendMessageA", SetLastError:=True)>
    Private Function SendMessage(ByVal hwnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    Private Const WM_SETREDRAW As Integer = &HB

    Friend SInf As clsSystemInfo

    Friend Key1 As String
    Friend glAppName As String = "VisualRecargaPOS"

    Friend glAppPath As String
    Friend glUsrPath As String
    Friend glIPServer As String
    Friend glIPClient As String
    Friend glPCName As String
    Friend glBaseDatos As String
    Friend glGrupo As String
    Friend glAutoLogin As Boolean
    Friend glSocket As Boolean
    Friend glParamConex As String
    Friend glDBDef As String       ' Base de datos generica (master)
    Friend glEstacion As Short
    Friend glWinDir As String
    Friend glSistOper As String
    Friend glVersion As Short
    Friend glVerNetStat As Boolean
    Friend glStrVersion As String
    Friend glSerial As String
    Friend glSerialDD As String
    Friend glRefreshRate As Integer
    Friend glCodSemilla As String
    Friend glIsDebuggin As Boolean
    Friend glCurSym As String

    Friend glUser As String
    Friend glPasswd As String
    Friend glPermisos As String
    Friend glBanca As Short
    Friend glUserDef As String      ' Usuario de la base de datos
    Friend glUserUnq As String      ' Usuario generico (unico)
    Friend glPswdDef As String      ' Password de la base de datos
    Friend glPswdUnq As String      ' Password generico (unico)
    Friend glUltUser As String      ' Ultimo usuario que entro a la aplicacion (no es variable importante de usuario)
    Friend glNombre As String
    Friend glCodVen As Integer
    Friend glNomVen As String
    Friend BdSerialIFA As String
    Friend glFecHora As DateTime
    Friend glEstadoTaq As Char      'Estado de la taquilla I: Abierta / O: Cerrada

    'PRINTER
    'LPT
    Public Class Win32API
        Public Const GENERIC_WRITE As Integer = &H40000000
        Public Const CREATE_ALWAYS As Integer = 2
        Public Const OPEN_EXISTING As Integer = 3
        Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer
        Public Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Long) As Long
    End Class
    Friend VP As New StringCollection()  'Virtual Printer
    Friend iLinesPrinted As Integer
    Friend iPagesPrinted As Integer
    Friend iPrinterWidth As Short
    Friend iPrinterHeight As Short

    Friend Enum vlPrintToEnum
        vlToScreen
        vlToPrinter
    End Enum
    Friend glPrintTo As vlPrintToEnum
    Friend glPrintPort As String
    Friend glSpeed As Integer
    Friend Enum vlImpresoraEnum
        vlTiquera
        vlEpson
        vlBixolon
        vlBematech
        vlWindows
    End Enum
    Friend glImpresora As vlImpresoraEnum
    Friend Enum vlTipoLetraEnum
        vlNormal
        vlComprimida
    End Enum
    Friend glTipoLetra As vlTipoLetraEnum
    Friend Enum vlTipoTicket
        vlResumido
        vlExtendido
        vlPersonalizado
    End Enum
    Friend glTipoTicket As vlTipoTicket
    Friend glNameInTicket As Boolean
    Friend glMargenIzq As Short
    Friend glSaltarAntes As Short
    Friend glSaltarDespues As Short
    Friend glCortarPapel As Boolean
    Friend glInterlineado As Boolean
    Friend glControlEfectivo As Boolean
    Friend glImpComprobante As Boolean
    Friend glColor As Long
    Friend glVerCuadreCaja As Boolean

    Friend gfFTPEXE As String
    Friend gfFTPCMD As String
    Friend gfFTPPRM As String

    'Variable para el cuadre de caja (total impreso)
    Friend iTotalImpreso As Decimal

    ' Variables para el uso de la impresora fiscal
    Friend glSerialIFA As String
    Friend glNroFactIF As String
    Friend glFechaFiscal As String
    Friend glFlgVerifRifIFA As Boolean
    Friend arrComerc As Object

    Friend vbCr As String = Cr
    Friend vbLf As String = Lf
    Friend vbCrLf As String = CrLf
    Friend vbTab As String = Microsoft.VisualBasic.ControlChars.Tab
    Friend vbNumbers As String = "0123456789" & Convert.ToChar(Keys.Back) & Convert.ToChar(Keys.Return)
    Friend vbMonto As String = "0123456789," & Convert.ToChar(Keys.Back) & Convert.ToChar(Keys.Return)
    Friend vbRIF As String = "JGVE-" & vbNumbers

    Friend Const seed1 As String = "51804"
    Friend Const word3 As String = "1S62058311A63"
    Friend Structure oServer
        Dim Servidor As String
        Dim BaseDatos As String
        Dim CodVendedor As Integer
        Dim NroTaquilla As Short
        Dim UltUser As String
        Dim NomVendedor As String
    End Structure
    Friend arrServers() As oServer
    Friend arrValues(,) As String
    Friend idxServer As Short

    Friend fMSG As frmMensaje

    Friend Function ArchivoExiste(ByVal NomFile As String) As Boolean
        Try
            Return File.Exists(glAppPath & NomFile)
        Catch ex As FileNotFoundException
            Return False
        Catch ex As IOException
            Dim strFixMsg As String = "Error verificando archivo " & NomFile & "."
            Call MensajeError(CType(ex, Exception), strFixMsg)
            Return False
        End Try
    End Function

    Friend Sub BajarArchivo(ByVal ExeDown As String)
        Dim rs As ADODB.Recordset
        Dim st As ADODB.Stream
        Dim NomExeDown As String
        Dim NomExeReal As String
        Dim NomExeBack As String

        glSQL = "EXEC SpConEjecutable @NomEXEDown='" & ExeDown & "'"
        rs = Conx.Execute(glSQL, CLng(iRET))
        If Not rs.EOF Then
            If Not Convert.IsDBNull(rs("Ejecutable").Value) Then
                st = New ADODB.Stream With {
                    .Type = ADODB.StreamTypeEnum.adTypeBinary
                }
                st.Open()
                st.Write(rs("Ejecutable").Value)
                NomExeDown = glAppPath & rs("NomExeDown").Value.ToString
                NomExeReal = glAppPath & rs("NomEXEReal").Value.ToString
                NomExeBack = glAppPath & rs("NomEXEReal").Value.ToString & ".BAK"

                If File.Exists(NomExeDown) Then File.Delete(NomExeDown)
                If File.Exists(NomExeBack) Then File.Delete(NomExeBack)
                If File.Exists(NomExeReal) Then
                    st.SaveToFile(NomExeDown, ADODB.SaveOptionsEnum.adSaveCreateNotExist)
                    Try
                        File.Replace(NomExeDown, NomExeReal, NomExeBack, True)
                    Catch ex As Exception
                        Dim strFixMsg As String = "Problemas bajando archivo."
                        Call MensajeError(ex, strFixMsg)
                        End
                    End Try
                Else
                    st.SaveToFile(NomExeReal, ADODB.SaveOptionsEnum.adSaveCreateNotExist)
                End If
            End If
        End If
        rs.Close()
    End Sub

    Friend Function BuscarFechaHora() As Boolean
        Dim eDateTime As SYSTEMTIME
        Dim rs As New ADODB.Recordset
        Try
            Call Reconectar()
            ' Buscar Fecha y Hora del dia del servidor
            rs = Conx.Execute("EXEC SpGetDateTime")
            If rs.EOF Then Return False
            eDateTime.Day = CShort(rs("Fecha").Value.ToString.Substring(0, 2))
            eDateTime.Month = CShort(rs("Fecha").Value.ToString.Substring(3, 2))
            eDateTime.Year = CShort(rs("Fecha").Value.ToString.Substring(6, 4))

            eDateTime.Hour = CShort(rs("Hora").Value.ToString.Substring(0, 2))
            eDateTime.Minute = CShort(rs("Hora").Value.ToString.Substring(3, 2))
            eDateTime.Second = CShort(rs("Hora").Value.ToString.Substring(6, 2))
            iRET = SetLocalTime(eDateTime)
            Call rsetClose(rs)
            glFecHora = System.DateTime.Now()
            rs = Nothing
            Return True
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando Fecha/Hora en la base de datos."
            Call MensajeError(ex, strFixMsg)
            Call rsetClose(rs)
            rs = Nothing
            Return False
        End Try
    End Function

    Friend Function ArmarActualizacion(ByVal NomExeDown As String, ByVal NomExeReal As String, ByVal TipoFtp As String, ByVal FtpIpAddress As String, ByVal FtpLogin As String, ByVal FtpPasswd As String) As Boolean
        'CHEQUEA SI YA BAJÓ EL PROGRAMA ESPECIFICADO BUSCANDO LA EXISTENCIA DEL ARCHIVO LLAMADO TRANSFER_COMPLETED 
        Try
            'Lo primero es que comando se va a ejecutar y renombrar los FTP si son ellos.
            'Si se va a actualizar el programa de FTP, se renombra y se llama por el nuevo nombre
            If NomExeReal.ToUpper = "VRFTP.EXE" AndAlso TipoFtp = "DW" Then
                If ArchivoExiste("EXEFTP.EXE") Then Call EliminarArchivo("EXEFTP.EXE")
                Call RenombrarArchivo("VRFTP.EXE", "EXEFTP.EXE")
                gfFTPEXE = glAppPath & "EXEFTP.EXE"
            ElseIf NomExeReal.ToUpper = "VRBLOB.EXE" AndAlso TipoFtp = "BD" Then 'Si no es el FTP y no es el blob
                If ArchivoExiste("EXEBLOB.EXE") Then Call EliminarArchivo("EXEBLOB.EXE")
                Call RenombrarArchivo("VRBLOB.EXE", "EXEBLOB.EXE")
                gfFTPEXE = glAppPath & "EXEBLOB.EXE"
            Else
                If TipoFtp = "DW" Then
                    gfFTPEXE = glAppPath & "VRFTP.EXE"
                Else
                    gfFTPEXE = glAppPath & "VRBLOB.EXE"
                End If
            End If
            If TipoFtp = "DW" Then      'Comando via FTP
                gfFTPCMD = gfFTPEXE
                gfFTPPRM = FtpIpAddress & " " &
                           FtpLogin & " " &
                           FtpPasswd & " " &
                           NomExeDown & " " &
                           NomExeReal
            ElseIf TipoFtp = "BD" Then  'Comando via BD BLOB
                gfFTPCMD = gfFTPEXE
                gfFTPPRM = glIPServer & " " &
                           glGrupo.Replace(" ", "#") & " " &
                           NomExeDown & " " &
                           NomExeReal & " POS"
            End If
            Return True
        Catch ex As Exception
            Dim strFixMsg As String = "Error armando la actualización."
            Call MensajeError(ex, strFixMsg)
            Return False
        End Try
    End Function

    Friend Function ChequearMensaje() As Boolean
        If fMSG IsNot Nothing AndAlso Not fMSG.IsDisposed Then Return False
        Dim rs As New ADODB.Recordset
        Try
            Call Reconectar()
            rs = Conx.Execute("EXEC SpConHayMensaje @ID_Vendedor=" & glCodVen & ",@ID_Estacion=" & glEstacion)
            If Not rs.EOF Then
                If rs("HayMensaje").Value.ToString = "SI" Then
                    rsetClose(rs)
                    rs = Nothing
                    Return True
                Else
                    rsetClose(rs)
                    rs = Nothing
                    Return False
                End If
                rsetClose(rs)
                rs = Nothing
                Return False
            Else
                Call rsetClose(rs)
                rs = Nothing
                Return False
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando nuevos mensajes."
            Call MensajeError(ex, strFixMsg)
            Call rsetClose(rs)
            rs = Nothing
            Return False
        End Try
    End Function

    Friend Function DateISOtoDate(strDate As String) As String
        Return strDate.Substring(6, 2) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(0, 4)
    End Function

    Friend Function TimeISOtoTime(strTime As String) As String
        If strTime.Length = 6 Then
            Return CDate(strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2) & ":" & strTime.Substring(4, 2)).ToShortTimeString
        ElseIf strTime.Length = 4 Then
            Return CDate(strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2)).ToShortTimeString
        Else
            Return strTime
        End If
    End Function

    Friend Function EjecutarComandoDownLoad() As Boolean
        Try
            Dim pRET As Process = Process.Start(gfFTPCMD, gfFTPPRM)
            'PROBANDO!!! esperar a que termine el proceso. by VESC 16-05-2016.
            While Not pRET.HasExited : End While
        Catch ex As System.ComponentModel.Win32Exception
            Dim strFixMsg As String = "Error ejecutando la aplicación " & vbCrLf & gfFTPEXE
            Call MensajeError(CType(ex, Exception), strFixMsg)
            Return False
        Catch ex As FileNotFoundException
            Dim strFixMsg As String = "No consigo la aplicación " & vbCrLf & gfFTPEXE
            Call MensajeError(CType(ex, Exception), strFixMsg)
            Return False
        Catch ex As IOException
            Dim strFixMsg As String = "Error ejecutar " & vbCrLf & gfFTPEXE
            Call MensajeError(CType(ex, Exception), strFixMsg)
            Return False
        Catch ex As Exception
            Dim strFixMsg As String = "Error ejecutar " & vbCrLf & gfFTPEXE
            Call MensajeError(ex, strFixMsg)
            Return False
        End Try
        Return True
    End Function

    Friend Sub EliminarArchivo(ByVal FileName As String)
        Try
            File.Delete(glAppPath & FileName)
            Application.DoEvents()
        Catch ex As FileNotFoundException
            Exit Sub
        Catch ex As IOException
            Dim strFixMsg As String = "Error eliminando archivo " & FileName
            Call MensajeError(CType(ex, Exception), strFixMsg)
        End Try
    End Sub

    Friend Function GetAppDataAgencia() As Boolean
        Try
            glAutoLogin = My.Settings.AutoLogin
            glPswdDef = My.Settings.AutoPasswd

            glCodVen = My.Settings.CodVendedor
            glNomVen = My.Settings.NomVendedor
            glEstacion = My.Settings.Estacion
            glVersion = My.Settings.Version
            glUltUser = My.Settings.UltUser
            glPCName = System.Environment.MachineName

            glPrintTo = CType(My.Settings.PrintTo, vlPrintToEnum)
            glPrintPort = My.Settings.PrintPort
            If glPrintPort.EndsWith(":") AndAlso glPrintPort.Contains("COM") Then glPrintPort = glPrintPort.Substring(0, glPrintPort.Length - 1)
            glSpeed = My.Settings.Speed
            glImpresora = CType(My.Settings.Impresora, vlImpresoraEnum)
            glTipoLetra = CType(My.Settings.TipoLetra, vlTipoLetraEnum)
            glNameInTicket = My.Settings.NombreEnTickets
            glTipoTicket = CType(My.Settings.TipoTicket, vlTipoTicket)

            glMargenIzq = My.Settings.MargenIzq
            glSaltarAntes = My.Settings.SaltarLineasAntes
            glSaltarDespues = My.Settings.SaltarLineasDespues
            glCortarPapel = My.Settings.CortarPapel
            glInterlineado = My.Settings.Interlineado

            'glColor = GetSetting(glAppName, "Data", "Color", "&H00C0FFC0&") 'Verde
            'glFechaFiscal = My.Settings.FechaFiscal

            If glCodVen <> 0 And
               glEstacion <> 0 And
               glVersion >= 0 Then
                Return True
            End If
        Catch ex As Exception
            Dim strFixMsg As String = "Error buscando los datos registrados."
            Call MensajeError(ex, strFixMsg)
        End Try
        Return False
    End Function

    Friend Function GetAppDataConex() As Boolean
        Dim clC As New clsCesar With {
            .cSemilla = seed1 & seed2 & seed3
        }

        glIPServer = My.Settings.Host
        glBaseDatos = My.Settings.BaseDatos
        glGrupo = My.Settings.BaseDatos
        glAutoLogin = My.Settings.AutoLogin
        glEstacion = My.Settings.Estacion
        'If glAutoLogin Then txtPassword.Text = clC.DecriptarCs(My.Settings.AutoPasswd)

        'Datos de la nueva pantalla de Login...
        'lblRazonSocial.Text = My.Settings.RazonSocial
        'If My.Settings.RIF <> "" Then
        ' lblRIF.Text = "RIF " & My.Settings.RIF
        ' Else
        'lblRIF.Text = ""
        'End If
        'If My.Settings.Contactos <> "" Then
        'lblTitulo.Text = "Contacto"
        'lblContactos.Text = My.Settings.Contactos
        'Else
        'lblTitulo.Text = ""
        'End If
        'lblEmail.Text = My.Settings.Email

        If glIPServer <> "" And
           glBaseDatos <> "" Then
            Return True
        End If
        Return False
    End Function

    Friend Sub InicializarMDI()
        Cursor.Current = Cursors.AppStarting
        Try
            mdiRecargaPOS.StatusStrip.Visible = True
            mdiRecargaPOS.lblStatus.Text = "Ajustando fecha y hora local..."  '<-
            If Not BuscarFechaHora() Then
                HouseCleaning()
                End
            End If
            Call mdiRecargaPOS.tmrProyecto_Tick(Nothing, Nothing)
            mdiRecargaPOS.Text = "Visual Recarga POS - " & glCodVen & "-" & glNomVen & " - " & " (" & glUser & " - " & glNombre & ")"
            mdiRecargaPOS.lblInformacion.Text = "  IP - " & glIPClient & "@" & glBaseDatos & "    Estación #" & glEstacion.ToString

            mdiRecargaPOS.Entrar()

            'Verificar impresora (fiscal o no)
            mdiRecargaPOS.lblStatus.Text = "Verificando impresora"
            'Verificar que los datos del comercializador esten en la impresora
            'RIF
            'RAZON SOCIAL
            'SERIAL IFA
            'ABRIR FORMA DE VENTA (????)

            mdiRecargaPOS.lblStatus.Text = ""

            mdiRecargaPOS.ShowDialog()
            'VERIFICAR EMISION DE REPORTE Z
        Catch ex As Exception
            Dim strFixMsg As String = "Error inicializando forma principal."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Friend Function IsNewServer(ByVal strServer As String, ByVal strDatabase As String) As Boolean
        Dim idxSrv As Integer
        For idxSrv = 0 To arrServers.GetUpperBound(0)
            'Cambio para usar la estructura de la lista que permite conexión a múltiples bases de datos.
            'by JOEL/VESC 17-04-2015
            If arrServers(idxSrv).Servidor <> "" Then
                If arrServers(idxSrv).Servidor = strServer AndAlso arrServers(idxSrv).BaseDatos = strDatabase Then
                    Return False
                End If
            End If
        Next idxSrv
        Return True
    End Function

    Friend Sub RenombrarArchivo(ByVal OldFileName As String, ByVal NewFileName As String)
        Try
            File.Move(glAppPath & OldFileName, glAppPath & NewFileName)  ' Rename file.
            Application.DoEvents()
        Catch ex As FileNotFoundException
            Exit Sub
        Catch ex As IOException
            File.Delete(glAppPath & NewFileName)
            Dim strFixMsg As String = "Error renombrando archivo " & OldFileName
            Call MensajeError(CType(ex, Exception), strFixMsg)
        End Try
    End Sub

    Friend Function GetIpAddress() As String
        'For idx As Integer = 0 To (strIPAddress.GetUpperBound(0) - 1)
        '    If Not strIPAddress(idx).ToString.Contains(":") Then
        '        Return strIPAddress(idx).ToString
        '    End If
        'Next idx
        Dim myHost As String = Net.Dns.GetHostName
        Dim ipEntry As System.Net.IPHostEntry = Net.Dns.GetHostEntry(myHost)
        Dim ip As String = ""

        For Each tmpIpAddress As System.Net.IPAddress In ipEntry.AddressList
            If tmpIpAddress.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                ip = tmpIpAddress.ToString
                Exit For
            End If
        Next
        If ip = "" Then
            Dim strIPAddress As System.Net.IPAddress() = Net.Dns.GetHostAddresses(Net.Dns.GetHostName())
            Return strIPAddress(0).ToString
        End If
        Return ip
    End Function

    Friend Sub HouseCleaning()
        conxClose(Conx)
    End Sub

    Friend Sub MensajeError(ByRef ex As Exception, Optional sExtendMsg As String = "", Optional ByVal sCaption As String = "")
        Dim errmsg As String, errsrc As String, errsite As String
        errmsg = ex.Message
        errsrc = ex.Source
        errsite = ex.StackTrace.ToString
        If sCaption = "" Then sCaption = "Error"
        If errmsg.Contains("Error Status: 08S01") Then
            Call Reconectar()
        ElseIf errmsg.Contains("Error Status: 08001") Then
            sExtendMsg = "Disculpe no se logra la conexión con el servidor." & vbCrLf & "Por favor revise los parámetros de conexión " & vbCrLf & "o su conexión de red y pruebe de nuevo."
            sCaption = "Error #-1100"
        ElseIf errmsg.Contains("Error Status: 08004") Then
            sExtendMsg = "Usted no es un usuario valido en el grupo (" & glGrupo & ")" & vbCrLf & "Por favor verifique el grupo al que está asociado."
            sCaption = "Error Grupo"
        ElseIf errmsg.Contains("Error Status: HYT00") Then
            sExtendMsg = "Disculpe no hay línea en estos momentos." & vbCrLf & "Por favor intente de nuevo." & "Finalizó el tiempo de espera."
            sCaption = "Error #-1200"
        End If
        MessageBox.Show(errsrc & vbCrLf & errmsg & vbCrLf & sExtendMsg & If(glIsDebuggin, vbCrLf & "En: " & errsite, "").ToString, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Friend Sub MostrarRespuesta(ByVal strCode As String, ByVal strErr As String, Optional ByVal strMsg As String = Nothing)
        Dim strMensaje As String = ""
        If strMsg Is Nothing Then
            Select Case strCode
                Case "NL"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "NO HAY COMUNICACIÓN CON EL SERVIDOR DE RECARGA."
                Case "TM"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "TIEMPO DE ESPERA DEL SERVIDOR DE LA OPERADORA TELEFÓNICA EXCEDIDO. INTENTE DE NUEVO."
                Case "TO"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "SERVIDOR DE RECARGA DE LA OPERADORA TELEFÓNICA NO RESPONDE. INTENTE DE NUEVO!!"
                Case "OM"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "SERVIDOR DE RECARGA DE LA OPERADORA TELEFÓNICA NO RESPONDE. INTENTE DE NUEVO!!"
                Case "ER"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "PROBLEMAS DE COMUNICACIÓN PARA EL REVERSO DE LA TRANSACCIÓN."
                Case "E1"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "PROBLEMAS DE COMUNICACIÓN CON EL SERVIDOR. LA TRANSACCIÓN NO SE REALIZÓ."
                Case "NF"
                    strMensaje = "RESPUESTA NO DEFINIDA"
                    strErr = "RESPUESTA DEL SERVIDOR NO DEFINIDA. (" & strCode & ")"
                Case "XE"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "ERROR DE RESPUESTA EN LA TRANSACCIÓN DE REVERSO."
                Case "99"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "ERROR DE COMUNICACIÓN. TIEMPO DE ESPERA AGOTADO."
                Case "68"
                    strMensaje = "ERROR DE COMUNICACIÓN"
                    strErr = "LA OPERADORA SE TARDA MUCHO TIEMPO EN RESPONDER ..."
                Case Else
                    Try
                        Dim lcSQL As String = "EXEC PosQryErrTransacciones '" & strCode & "'"
                        iRET = ExecSP(lcSQL, True)
                        If RecSet.EOF Then
                            strMensaje = "RESPUESTA NO DEFINIDA"
                            strErr = "CÓDIGO DE ERROR (" & strCode & ") NO ESTÁ DEFINIDO EN EL SISTEMA. POR FAVOR NOTIFÍQUELO."
                        Else
                            strMensaje = "RESPUESTA"
                            strErr = RecSet("Nombre").Value.ToString.ToUpper
                        End If
                    Catch ex As Exception
                        Dim strFixMsg As String = "Error mostrando error."
                        Call MensajeError(ex, strFixMsg)
                        Exit Sub
                    End Try
            End Select
        End If
        Dim FE As New frmError
        FE.SetMessage(strCode, strErr, strMensaje)
        FE.ShowDialog()
        FE.Dispose()
    End Sub

    Friend Sub PrintToPort()
        Dim strLinea As String, idxLin As Integer = 0
        If VP.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.AppStarting
        If glPrintPort.Contains("COM") Then
            Dim SP As New SerialPort(glPrintPort, glSpeed, Parity.None, 8, StopBits.One)
            Try
                SP.Open()
            Catch ex As IOException
                Dim strFixMsg As String = "Error de comunicación con el puerto " & glPrintPort
                Call MensajeError(CType(ex, Exception), strFixMsg)
                SP.Close()
                Cursor.Current = Cursors.Default
                Exit Sub
            Catch ex As System.ArgumentException
                Dim strFixMsg As String = "Error de comunicación con el puerto " & glPrintPort
                Call MensajeError(CType(ex, Exception), strFixMsg)
                SP.Close()
                Cursor.Current = Cursors.Default
                Exit Sub
            End Try
            Try
                For Each strLinea In VP
                    idxLin += 1
                    SP.WriteLine(strLinea)
                    If idxLin Mod 20 = 0 Then 'Una dormidita (4 seg.) cada 20 líneas para probar...
                        System.Threading.Thread.Sleep(4000)
                    End If
                Next
                If glCortarPapel Then SP.Write(System.Convert.ToChar(29) & "V" & System.Convert.ToChar(66) & 0)
            Catch ex As Exception
                Dim strFixMsg As String = "Error de comunicación con el puerto " & glPrintPort
                Call MensajeError(ex, strFixMsg)
            End Try
            SP.Close()
        ElseIf glPrintPort.Contains("LPT") Then
            Dim fh As IntPtr
            Dim SP As IO.StreamWriter
            Dim FS As IO.FileStream
            Try
                fh = CType(Win32API.CreateFile(glPrintPort, Win32API.GENERIC_WRITE, 0, 0, Win32API.CREATE_ALWAYS, 0, 0), IntPtr)
            Catch ex As Exception
                Dim strFixMsg As String = "Error abriendo el puerto de comunicación " & glPrintPort
                Call MensajeError(ex, strFixMsg)
            End Try
            Dim sfh As New Microsoft.Win32.SafeHandles.SafeFileHandle(fh, True)
            FS = New IO.FileStream(sfh, IO.FileAccess.Write)
            FS.Flush()
            SP = New IO.StreamWriter(FS)
            'SW.WriteLine("Simple Text")
            Try
                For Each strLinea In VP
                    idxLin += 1
                    SP.WriteLine(strLinea)
                    If idxLin Mod 20 = 0 Then 'Una dormidita (4 seg.) cada 20 líneas para probar...
                        System.Threading.Thread.Sleep(4000)
                    End If
                Next
                If glCortarPapel Then SP.Write(System.Convert.ToChar(29) & "V" & System.Convert.ToChar(66) & 0)
            Catch ex As Exception
                Dim strFixMsg As String = "Error de comunicación con el puerto " & glPrintPort
                Call MensajeError(ex, strFixMsg)
            End Try
            FS.Flush()
            SP.Close()
            FS.Close()
            sfh.Close()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Friend Sub PrintToWinDefault()
        If VP.Count = 0 Then Exit Sub
        mdiRecargaPOS.Printer.DefaultPageSettings.Margins.Left = 0
        mdiRecargaPOS.Printer.DefaultPageSettings.Margins.Top = 0
        mdiRecargaPOS.Printer.DefaultPageSettings.Margins.Right = 0
        mdiRecargaPOS.Printer.DefaultPageSettings.Margins.Bottom = 0
        mdiRecargaPOS.Printer.Print()
        Application.DoEvents()
    End Sub

    Friend Sub PrintToWindow(ByVal iWidth As Integer)
        Dim prn As frmImpresora
        Dim strLinea As String

        If VP.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.AppStarting
        prn = New frmImpresora With {
            .MdiParent = mdiRecargaPOS,
            .iPrinterWidth = iWidth
        }
        prn.Show()

        prn.mClear()
        For Each strLinea In VP
            prn.mPrint(strLinea & vbCrLf)
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Friend Sub SetStatus(ByVal strStatus As String)
        mdiRecargaPOS.lblStatus.Text = strStatus
    End Sub

    Friend Sub vPrt(ByVal strVal As String, Optional ByVal chrPad As Char = "L"c)
        Dim aLines() As String
        If strVal = "" Then
            VP.Add(" ")
        Else
            If chrPad = "L" Then
                If strVal.IndexOf(vbCrLf) > 0 Then
                    strVal.Replace(vbCrLf, vbCr)
                    aLines = strVal.Split(CChar(vbCr))
                    If aLines(0).Length > iPrinterWidth Then aLines(0) = aLines(0).Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & aLines(0))
                    If aLines(1).Length > iPrinterWidth Then aLines(1) = aLines(1).Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & aLines(1).Replace(vbLf, ""))
                Else
                    If strVal.Length > iPrinterWidth Then strVal = strVal.Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & strVal)
                End If
            ElseIf chrPad = "R" Then
                If strVal.IndexOf(vbCrLf) > 0 Then
                    strVal.Replace(vbCrLf, vbCr)
                    aLines = strVal.Split(CChar(vbCr))
                    If aLines(0).Length > iPrinterWidth Then aLines(0) = aLines(0).Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & aLines(0).PadLeft(iPrinterWidth))
                    If aLines(1).Length > iPrinterWidth Then aLines(1) = aLines(1).Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & aLines(1).Replace(vbLf, "").PadLeft(iPrinterWidth))
                Else
                    If strVal.Length > iPrinterWidth Then strVal = strVal.Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & strVal.PadLeft(iPrinterWidth))
                End If
            ElseIf chrPad = "C" Then
                If strVal.IndexOf(vbCrLf) > 0 Then
                    strVal.Replace(vbCrLf, vbCr)
                    aLines = strVal.Split(CChar(vbCr))
                    If aLines(0).Length > iPrinterWidth Then aLines(0) = aLines(0).Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & New String(" "c, CInt(Math.Round(((iPrinterWidth - aLines(0).Length) / 2), 0))) & aLines(0))
                    If aLines(1).Length > iPrinterWidth Then aLines(1) = aLines(1).Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & New String(" "c, CInt(Math.Round(((iPrinterWidth - aLines(1).Length) / 2), 0))) & aLines(1).Replace(vbLf, ""))
                Else
                    If strVal.Length > iPrinterWidth Then strVal = strVal.Substring(0, iPrinterWidth)
                    VP.Add(New String(" "c, glMargenIzq) & New String(" "c, CInt(Math.Round(((iPrinterWidth - strVal.Length) / 2), 0))) & strVal)
                End If
            End If
        End If
    End Sub

    Friend Function Vuelta(ByVal palabra As String) As String
        Dim var_caracter As String = ""

        For idx As Integer = 0 To (palabra.Length - 1)
            ' si es diferente del caracter 238 entra porque ese es el caracter
            ' de la mascara, se utiliza para alargar la cadena encriptada solamente
            If palabra.Chars(idx) <> Microsoft.VisualBasic.Chr(238) And palabra.Chars(idx) <> "" Then
                ' si el siguiente es chr(1) es porque es impar
                If palabra.Chars(idx + 1) = Microsoft.VisualBasic.Chr(1) Then
                    var_caracter += Microsoft.VisualBasic.Chr(Microsoft.VisualBasic.Asc(palabra.Chars(idx)) - 1)
                    ' si no es porque se dividio entre 2
                Else
                    If palabra.Chars(idx) <> Microsoft.VisualBasic.Chr(1) Then
                        ' pregunto si es menor de 127 para que no de error cuando multiplique
                        If Microsoft.VisualBasic.Asc(palabra.Chars(idx)) <= 127 Then
                            var_caracter += Microsoft.VisualBasic.Chr(Microsoft.VisualBasic.Asc(palabra.Chars(idx)) * 2)
                        Else
                            var_caracter += ""
                        End If
                    Else
                        var_caracter += ""
                    End If
                End If
            End If
        Next idx
        Return var_caracter
    End Function
End Module
