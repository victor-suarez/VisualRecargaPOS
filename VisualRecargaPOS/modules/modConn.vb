Option Strict On
Imports System.Web
Imports Microsoft.VisualBasic
Module modConn
    '*****************************************************
    '*      Variables de SQL para el Modulo ODBC      *
    '*****************************************************
    Friend Key3 As String
    Friend Const seed2 As String = "10107"
    Friend cxCols As Integer
    Friend cxRows As Integer
    Friend Conx As ADODB.Connection
    Friend ConxU As ADODB.Connection
    Friend RecSet As ADODB.Recordset
    Friend RsetAlt As ADODB.Recordset
    'Variables publicas de uso general
    Friend glSQL As String
    Friend iRET As Integer
    Private Const glQueryTimeout As Short = 30
    Private Const glLoginTimeout As Short = 30

    Friend Const word1 As String = "Visual" 'OJO OJO OJO Cambiar para cada programa
    Friend Const word2 As String = Chr(116) & Chr(117)
    Friend Const word4 As String = "recargado"

    Friend Enum SybProviderEnum
        prODBC = 0
        prSQLSERVER = 1
        prACCESS = 2
        prDBASE = 3
        prORACLE = 4
        prMYSQL = 5
    End Enum

    Friend Function cxLogin(ByRef LogProvider As SybProviderEnum, ByRef mServerName As String, ByRef mDbName As String, ByRef mUserName As String, ByRef mPasswd As String) As Boolean
        Dim strConn As String = ""
        If mUserName = "" Then LogProvider = SybProviderEnum.prODBC
        Try
            Conx = New ADODB.Connection
            Select Case LogProvider
                Case SybProviderEnum.prODBC
                    strConn = "Provider=MSDASQL"
                Case SybProviderEnum.prSQLSERVER
                    With Conx
                        strConn = "Provider=SQLOLEDB"
                        strConn &= ";Data Source=" & mServerName
                        strConn &= ";Initial Catalog=" & mDbName
                        strConn &= ";User Id=" & mUserName
                        strConn &= ";Password=" & mPasswd
                        'PRUEBAS CON UUSARIO PRIVILEGIAO!!!
                        'strConn &= ";User Id=sa"
                        'strConn &= ";Password=SQL4dm1n157r470r"
                        'strConn &= ";Integrated Security=SSPI"
                        strConn &= ";"

                        '.Provider = "SQLOLEDB"
                        '.Properties("Data Source").Value = mServerName
                        '.Properties("Initial Catalog").Value = mDbName
                        '.Properties("User ID").Value = mUserName
                        '.Properties("Password").Value = mPasswd
                    End With
                Case SybProviderEnum.prACCESS
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0"
                Case SybProviderEnum.prDBASE
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    strConn = strConn & "Data Source=" & mDbName
                    'ej Dir base datos :C:\QUANTUM\FMBA\QUANT601.NOR\DBFS\"
                    strConn &= ";Extended Properties="";Jet OLEDB:Engine Type=18;"
                Case SybProviderEnum.prORACLE
                    strConn = "Provider=MSDAORA;"
                    strConn &= "Database=" & mDbName
                Case SybProviderEnum.prMYSQL
                    strConn = "DRIVER={MySQL ODBC 3.51 Driver};"
                    strConn &= "SERVER=" & mServerName & ";"
                    strConn &= "DATABASE=" & mDbName & ";"
                    strConn &= "USER=" & mUserName & ";"
                    strConn &= "PASSWORD=" & mPasswd & ";"
                    strConn &= "OPTION=3;"
            End Select
            Conx.ConnectionString = strConn
            Conx.ConnectionTimeout = glLoginTimeout
            Conx.CommandTimeout = glQueryTimeout
#If DEBUG Then
            System.Diagnostics.Debug.Print(mUserName & "/" & mPasswd)
#End If
            Conx.Open()
            If Conx.State = ADODB.ObjectStateEnum.adStateClosed Then
                MessageBox.Show("Problemas con la conexión.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            'Dim strFixMsg As String = "Problemas con la conexión"
            'MessageBox.Show(If(glIsDebuggin, New StackTrace().GetFrame(0).GetMethod.ToString() & vbCrLf, "").ToString & ex.Message & vbCrLf & strFixMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
            Return False
        End Try
        Return True
    End Function

    Friend Function cxLoginUnq(ByRef LogProvider As SybProviderEnum, ByRef mServerName As String, ByRef mDbName As String, ByRef mUserName As String, ByRef mPasswd As String) As Boolean
        Dim strConn As String = ""
        If mUserName = "" Then LogProvider = SybProviderEnum.prODBC
        Try
            ConxU = New ADODB.Connection
            Select Case LogProvider
                Case SybProviderEnum.prODBC
                    strConn = "Provider=MSDASQL"
                Case SybProviderEnum.prSQLSERVER
                    With ConxU
                        .Provider = "SQLOLEDB"
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
                    strConn &= ";Extended Properties="";Jet OLEDB:Engine Type=18;"
                Case SybProviderEnum.prORACLE
                    strConn = "Provider=MSDAORA;"
                    strConn &= "Database=" & mDbName
                Case SybProviderEnum.prMYSQL
                    strConn = "DRIVER={MySQL ODBC 3.51 Driver};"
                    strConn &= "SERVER=" & mServerName & ";"
                    strConn &= "DATABASE=" & mDbName & ";"
                    strConn &= "USER=" & mUserName & ";"
                    strConn &= "PASSWORD=" & mPasswd & ";"
                    strConn &= "OPTION=3;"
            End Select
            ConxU.ConnectionString = strConn
            ConxU.ConnectionTimeout = glLoginTimeout
            ConxU.CommandTimeout = glQueryTimeout
#If DEBUG Then
            System.Diagnostics.Debug.Print(mUserName & "/" & mPasswd)
#End If
            ConxU.Open()
            If ConxU.State = ADODB.ObjectStateEnum.adStateClosed Then
                MessageBox.Show("Problemas con la conexión", "cxLogin", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            'Dim strFixMsg As String = "Problemas con la conexión"
            'MessageBox.Show(If(glIsDebuggin, New StackTrace().GetFrame(0).GetMethod.ToString() & vbCrLf, "").ToString & ex.Message & vbCrLf & strFixMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
            Return False
        End Try
        Return True
    End Function

    Friend Function ExecSP(ByRef Sp As String, ByRef IgnoreExec As Boolean) As Integer
        cxRows = 0 : cxCols = 0
        Call Reconectar()
        Try
            If Not IgnoreExec Then
                Conx.Execute(Sp, CObj(cxRows), ADODB.CommandTypeEnum.adCmdText)
                Return cxRows
            Else
                RecSet = New ADODB.Recordset With {
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                }
                RecSet.Open(Sp, Conx, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If RecSet.State = ADODB.ObjectStateEnum.adStateOpen Then cxRows = RecSet.RecordCount : cxCols = RecSet.Fields.Count
                Return cxRows
            End If
        Catch ex As Exception
            If ex.Message.Contains("Error en la conexión") Then
                Conx.Close()
                Throw
            ElseIf ex.Source = "Microsoft OLE DB Provider for SQL Server" Then
                Throw
            Else
                Call MensajeError(ex, "Error Comando SQL.")
                Throw
            End If
            Return -1
        End Try
    End Function

    Friend Sub rsetClose(ByRef rs As ADODB.Recordset)
        Try
            If rs Is Nothing Then Exit Sub
            If rs.State <> ADODB.ObjectStateEnum.adStateClosed Then rs.Close()
            rs = Nothing
        Catch ex As Exception
            Call MensajeError(ex, "Error cerrando cursor.")
        End Try
        'If Err.Number = 40011 Or Err.Number = 91 Or Err.Number = 3704 Then Resume Next
    End Sub

    Friend Sub conxClose(ByRef cx As ADODB.Connection)
        Try
            If cx Is Nothing Then Exit Sub
            If cx.State <> ADODB.ObjectStateEnum.adStateClosed Then cx.Close()
            cx = Nothing
        Catch ex As Exception
            Call MensajeError(ex, "Error cerrando conexión.")
        End Try
        'If Err.Number = 40011 Or Err.Number = 91 Or Err.Number = 3704 Then Resume Next
    End Sub

    Friend Sub Reconectar()
        If Conx IsNot Nothing Then
            If Conx.Errors.Count > 0 Then
                If Conx.Errors(0).NativeError <> 5701 And
                   Conx.Errors(0).NativeError <> 8153 Then
                    Conx.Close()
                End If
            End If
            If Conx.State = ADODB.ObjectStateEnum.adStateOpen Then Exit Sub
        End If
#If Not DEBUG Then
        Call ConectarAmiSQL() 'OJO OJO Seguridad desactivada en debug!
#End If
        Dim clC As New clsCesar
        glPswdUnq = word1.ToUpper & word2.ToUpper & word4.ToUpper
        glPswdUnq = glPswdUnq.Substring(0, 15)
        clC.cSemilla = clC.ArrSems(4) & clC.ArrSems(5) & clC.ArrSems(6)

        If Not cxLoginUnq(modConn.SybProviderEnum.prSQLSERVER, glIPServer, "VR", glUserUnq, clC.EncriptarCs(glPswdUnq)) Then
            MessageBox.Show("Problemas para reconectar con el servidor. El programa se cerrará" & vbCrLf & "Por favor revise su conexión e intente arrancar de nuevo.", "Error Crítico de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If

        Dim lcSQL As String = "EXEC SpConDato @Tipo='T',@Grupo='" & glGrupo.ToUpper & "'"
        Try
            RecSet = ConxU.Execute(lcSQL)
        Catch ex As Exception
            Dim strFixMsg As String = "Error reconectando con el servidor."
            Call MensajeError(ex, strFixMsg)
            End
        End Try
        If RecSet.EOF Then
            MessageBox.Show("Problemas para reconectar con el servidor. El programa se cerrará" & vbCrLf & "Por favor revise su conexión e intente arrancar de nuevo.", "Error Crítico de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call rsetClose(RecSet)
            End
        End If
        'Muevo los datos a variables globales
        glCodSemilla = RecSet(0).Value.ToString
        Call conxClose(ConxU)
        ConxU = Nothing 'DESTRUYO EL OBJETO PARA EL PROX LOGIN

        Key1 = glCodSemilla.Substring(0, 10)
        Key2 = glCodSemilla.Substring(9, 10)
        Key3 = glCodSemilla.Substring(20, 5)
        clC.cSemilla = Key1 & Key2 & Key3

        If Not cxLogin(modConn.SybProviderEnum.prSQLSERVER, glIPServer, glBaseDatos, glUserDef, clC.EncriptarCs(glPswdDef)) Then
            MessageBox.Show("Problemas para reconectar con el servidor. El programa se cerrará" & vbCrLf & "Por favor revise su conexión e intente arrancar de nuevo.", "Error Crítico de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            HouseCleaning()
            End
        End If
    End Sub
End Module
