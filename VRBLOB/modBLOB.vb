Option Strict On
Friend Module modBLOB
    Private cx As ADODB.Connection
    Private rs As ADODB.Recordset
    Private st As ADODB.Stream

    Private sSQL As String
    Private iRET As Integer

    Private blbSERVER As String
    Private blbGROUP As String
    Private blbDOWN As String
    Private blbDATABASE As String
    Private blbUSER As String
    Private blbBANCA As String
    Private blbEXE As String
    Private blbSYS As String
    Private blbSEMILLA As String

    Private Const word1 As String = "Visual" 'OJO OJO OJO Cambiar para cada programa
    Private Const word2 As String = Microsoft.VisualBasic.Chr(116) & Microsoft.VisualBasic.Chr(117)
    Private Const word4 As String = "recargado"
    Friend Enum SybProviderEnum
        prODBC = 0
        prSQLSERVER = 1
        prACCESS = 2
        prDBASE = 3
        prORACLE = 4
        prMYSQL = 5
    End Enum

    Private Function cxLogin(ByRef LogProvider As SybProviderEnum, ByRef mServerName As String, ByRef mDbName As String, ByRef mUserName As String, ByRef mPasswd As String) As Boolean
        Dim strConn As String = ""
        If mUserName = "" Then LogProvider = SybProviderEnum.prODBC
        Try
            cx = New ADODB.Connection
            Select Case LogProvider
                Case SybProviderEnum.prODBC
                    strConn = "Provider=MSDASQL"
                Case SybProviderEnum.prSQLSERVER
                    cx.Provider = "SQLOLEDB.1"
                    With cx
                        .Properties("Data Source").Value = mServerName
                        .Properties("Initial Catalog").Value = mDbName
                        .Properties("User ID").Value = mUserName
                        .Properties("Password").Value = mPasswd
                    End With
                Case SybProviderEnum.prACCESS
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0"
                Case SybProviderEnum.prDBASE
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    strConn = strConn & "Data Source=" & mDbName
                    'ej Dir base datos :C:\QUANTUM\FMBA\QUANT601.NOR\DBFS\"
                    strConn = strConn & ";Extended Properties="";Jet OLEDB:Engine Type=18;"
                Case SybProviderEnum.prORACLE
                    strConn = "Provider=MSDAORA;"
                    strConn = strConn & "Database=" & mDbName
                Case SybProviderEnum.prMYSQL
                    strConn = "DRIVER={MySQL ODBC 3.51 Driver};"
                    strConn = strConn & "SERVER=" & mServerName & ";"
                    strConn = strConn & "DATABASE=" & mDbName & ";"
                    strConn = strConn & "USER=" & mUserName & ";"
                    strConn = strConn & "PASSWORD=" & mPasswd & ";"
                    strConn = strConn & "OPTION=3;"
            End Select
            cx.ConnectionString = strConn
            cx.ConnectionTimeout = 15
            cx.CommandTimeout = 15
            cx.Open()
            If cx.State = ADODB.ObjectStateEnum.adStateClosed Then
                Console.WriteLine("Problemas con la conexión.")
                Return True
            End If
            Return False
        Catch ex As Exception
            Console.WriteLine(ex.Message & " Problemas con la conexión.")
            Throw
            Return True
        End Try
    End Function

    Private Function LoginDBUnq() As Boolean
        Dim clC As New clsCesar
        Dim lcBaseDatos As String, lcUserUnq As String, lcPswdUnq As String
        clC.cSemilla = clC.ArrSems(9) & clC.ArrSems(4) & clC.ArrSems(0) & clC.ArrSems(2) & clC.ArrSems(5)

        lcBaseDatos = "VR"
        lcUserUnq = lcBaseDatos & System.Convert.ToChar(84) & System.Convert.ToChar(49)
        lcPswdUnq = clC.ArrKeys(7) & clC.ArrKeys(4) & clC.ArrKeys(1) & clC.ArrKeys(9) & clC.ArrKeys(2)

        Try
            ' Conecto al IP y DB seleccionado en login pero con usuario default
            If cxLogin(SybProviderEnum.prSQLSERVER, blbSERVER, lcBaseDatos, lcUserUnq, clC.EncriptarCs(lcPswdUnq)) Then
                cx.Close()
                Console.WriteLine("Error al conectar posible problemas de parametros favor revise.")
                Return True
            End If
            Return False
        Catch ex As Exception
            Dim errmsg As String, errsrc As String
            errmsg = ex.Message
            errsrc = ex.Source
            If errmsg.IndexOf("Error Status: 08001") <> -1 Then
                Console.WriteLine("Disculpe no se logra la conexión con el servidor.")
            ElseIf errmsg.IndexOf("Error Status: 08S01") <> -1 Then
                Console.WriteLine("Disculpe no hay línea en estos momentos. Por favor pruebe más tarde.")
            ElseIf errmsg.IndexOf("Error Status: HYT00") <> -1 Then
                Console.WriteLine("Disculpe no hay línea en estos momentos. Por favor pruebe más tarde.")
            ElseIf errmsg.IndexOf("Error Nro.   : 18456") <> -1 Then
                Console.WriteLine("Usuario o contraseña inválido. Por intente nuevamente.")
            ElseIf errmsg.IndexOf("Error Status: 08004") <> -1 Then
                Console.WriteLine("Usted no es un usuario valido en el grupo (" & blbGROUP & ") Por favor verifique el grupo al que esta asociado")
            Else
                Console.WriteLine(errmsg & " Error de conexión")
            End If
            Return True
        End Try
    End Function

    Private Function LoginDB() As Boolean
        Dim clC As New clsCesar, word1 As String = "vrtaq01" 'OJO OJO OJO Cambiar para cada programa
        Dim lcPswdUnq As String
        clC.cSemilla = blbSEMILLA.Substring(0, 10) & blbSEMILLA.Substring(9, 10) & blbSEMILLA.Substring(20, 5)

        lcPswdUnq = clC.ArrKeys(7) & clC.ArrKeys(4) & clC.ArrKeys(1) & clC.ArrKeys(9) & clC.ArrKeys(2)
        lcPswdUnq = word1.ToUpper & word2.ToUpper & word4.ToUpper
        lcPswdUnq = lcPswdUnq.Substring(0, lcPswdUnq.Length - 2)
        Try
            ' Conecto al IP y DB seleccionado en login pero con usuario default
            If cxLogin(SybProviderEnum.prSQLSERVER, blbSERVER, blbDATABASE, blbUSER, clC.EncriptarCs(lcPswdUnq)) Then
                Console.WriteLine("Error al conectar posible problemas de parametros favor revise.")
                Return True
            End If
            Return False
        Catch ex As Exception
            Dim errmsg As String, errsrc As String
            errmsg = ex.Message
            errsrc = ex.Source
            If errmsg.IndexOf("Error Status: 08001") <> -1 Then
                Console.WriteLine("Disculpe no se logra la conexión con el servidor.")
            ElseIf errmsg.IndexOf("Error Status: 08S01") <> -1 Then
                Console.WriteLine("Disculpe no hay línea en estos momentos. Por favor pruebe más tarde.")
            ElseIf errmsg.IndexOf("Error Status: HYT00") <> -1 Then
                Console.WriteLine("Disculpe no hay línea en estos momentos. Por favor pruebe más tarde.")
            ElseIf errmsg.IndexOf("Error Nro.   : 18456") <> -1 Then
                Console.WriteLine("Usuario o contraseña inválido. Por intente nuevamente.")
            ElseIf errmsg.IndexOf("Error Status: 08004") <> -1 Then
                Console.WriteLine("Usted no es un usuario valido en el grupo (" & blbGROUP & ") Por favor verifique el grupo al que esta asociado")
            Else
                Console.WriteLine(errmsg & " Error de conexión")
            End If
            Return True
        End Try
    End Function

    Sub Main()
        Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        If Not AppPath.EndsWith("\") Then AppPath = AppPath & "\"
        Dim strInput As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

        If strInput Is Nothing Then Console.WriteLine("Error: Faltan los argumentos del programa") : End
        If strInput.Count <> 5 Then Console.WriteLine("Error: Los parámetros están incompletos") : End
        '           blbSERVER       blbGROUP blbDOWN blbEXE               blbSYS
        'VPBLOB.EXE 178.248.232.134 RECARGA1 VRPOS   VisualRecargaPOS.exe POS
        blbSERVER = strInput.Item(0)                    '178.248.232.134
        blbGROUP = strInput.Item(1).Replace("#", " ")   'RECARGA1
        blbDOWN = strInput.Item(2)                      'VRPOS
        blbEXE = strInput.Item(3)                       'VisualRecargaPOS.exe
        blbSYS = strInput.Item(4)                       'ADM/POS

        Console.WriteLine("Conectando con el servidor...")
        If LoginDBUnq() Then End
        sSQL = "EXEC SpConDato @Tipo='T',@Grupo='" & blbGROUP.Trim.ToUpper & "'"
        Try
            rs = New ADODB.Recordset
            rs = cx.Execute(sSQL)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            End
        End Try
        If rs.EOF Then
            Console.WriteLine("El grupo no existe. Grupo de datos inválido!")
            End
        End If
        rs.MoveFirst()
        blbSEMILLA = rs("Valor").Value.ToString
        blbUSER = rs("Dato").Value.ToString
        blbBANCA = rs("Registro").Value.ToString
        blbDATABASE = rs("Posicion").Value.ToString
        blbGROUP = blbGROUP.Trim.ToUpper

        rs.Close() : cx.Close()
        rs = Nothing : cx = Nothing
        Console.WriteLine("Conectando con la base de datos...")
        If LoginDB() Then End

        Dim sEXEDown As String = AppPath & blbDOWN
        Dim sEXEReal As String = AppPath & blbEXE
        Dim sEXEBak As String = AppPath & blbEXE & "BAK"
        ' Depende del programa que se va a bajar, hay que eliminarlo del disco si existe
        ' El nombre de ese paquete lo leo de la línea de comando
        If System.IO.File.Exists(sEXEDown) Then
            System.IO.File.Delete(sEXEDown)
        End If
        rs = New ADODB.Recordset

        Console.WriteLine("Bajando el ejecutable...")
        'AJÁ JÁ!!!
        sSQL = "EXEC SpConEjecutable @NomEXEDown='" & blbDOWN & "'"
        rs = cx.Execute(sSQL)
        If Not rs.EOF Then
            st = New ADODB.Stream
            st.Type = ADODB.StreamTypeEnum.adTypeBinary
            st.Open()
            st.Write(rs.Fields("Ejecutable").Value)

            If System.IO.File.Exists(sEXEReal) Then
                Console.WriteLine("Guardando el archivo temporal...")
                st.SaveToFile(sEXEDown, ADODB.SaveOptionsEnum.adSaveCreateNotExist)
                If System.IO.File.Exists(sEXEBak) Then System.IO.File.Delete(sEXEBak)
                Try
                    Console.WriteLine("Renombrando el archivo temporal...")
                    System.IO.File.Replace(sEXEDown, sEXEReal, sEXEBak, True)
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                    End
                End Try
            Else
                Console.WriteLine("Guardando el archivo...")
                st.SaveToFile(sEXEReal, ADODB.SaveOptionsEnum.adSaveCreateNotExist)
            End If
            rs.Close()
            rs = Nothing
        End If

        System.IO.File.Create("TRANSFER_COMPLETED")
        Console.WriteLine("Ejecutando el sistema...")
        Dim lAppRun As String
        If blbSYS = "ADM" Then
            lAppRun = AppPath & "VisualRecargaADM.exe"
        Else
            lAppRun = AppPath & "VisualRecargaPOS.exe"
        End If
        Try
            Dim pRET As Process = Process.Start(lAppRun)
        Catch ex As System.ComponentModel.Win32Exception
            Console.WriteLine("Error ejecutando la aplicación: " & lAppRun & " " & ex.Message)
        Catch ex As System.IO.FileNotFoundException
            Console.WriteLine("No consigo la aplicación: " & lAppRun, " Archivo No Existe")
        Catch ex As System.IO.IOException
            Console.WriteLine("Error ejecutando aplicación: " & ex.Source & " " & ex.Message)
        End Try
        End
    End Sub
End Module
