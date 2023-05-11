Option Strict On
Public Class clsCesar
    '---------------------------------------------------------------------------------------
    ' Module    : CesarKey
    ' DateTime  : 12/04/2005 03:25 pm
    ' Author    : Joaco
    ' Purpose   : Para encriptar datos en clave Cesar con semilla variable
    '           : y múltiples iteraciones.
    '---------------------------------------------------------------------------------------
    Public cSemilla As String
    Public cLimiteInf As Integer = 48
    Public cLimiteSup As Integer = 90
    Public cCarInvInf As Integer = 58   ' por encima de 9
    Public cCarInvSup As Integer = 64   ' por debajo de A
    Public cCarInvOff As Integer = 39   ' a minuscula
    Public cInterac As Integer = 1
    Public cFormatoBD As Boolean
    Public ArrKeys(0 To 9) As String
    Public ArrSems(0 To 9) As String

    Private Sub CargarKeys()
        ArrKeys(0) = "2W8F3" : ArrKeys(1) = "9DS2X"
        ArrKeys(2) = "9C5Q8" : ArrKeys(3) = "S7X7D"
        ArrKeys(4) = "A8L7F" : ArrKeys(5) = "C6F38"
        ArrKeys(6) = "4AF8J" : ArrKeys(7) = "A12F6"
        ArrKeys(8) = "Y0D6A" : ArrKeys(9) = "G415X"

        ArrSems(0) = "62072" : ArrSems(1) = "96231"
        ArrSems(2) = "53719" : ArrSems(3) = "72678"
        ArrSems(4) = "95936" : ArrSems(5) = "29109"
        ArrSems(6) = "63758" : ArrSems(7) = "07286"
        ArrSems(8) = "93435" : ArrSems(9) = "62196"
    End Sub

    '---------------------------------------------------------------------------------------
    ' Procedure : EncriptarCs
    ' DateTime  : 12/04/2005 03:25 pm
    ' Author    : Joaco
    ' Purpose   : Encripta el valor del string de entrada, al ser de tipo string
    '           : su tamaño máximo debe ser de 255 caracteres. (Separa caracteres no deseados)
    '---------------------------------------------------------------------------------------
    '
    Public Function EncriptarCs(ByVal valor As String) As String
        If cSemilla Is Nothing Then
            Throw New System.Exception("clsCesar: La semilla debe ser inicializada.")
            Return ""
        End If
        If cSemilla.Length = 0 Or cSemilla.Trim = " " Then
            Throw New System.Exception("clsCesar: La semilla debe ser inicializada.")
            Return ""
        End If
        Return Encrypt(valor)
    End Function
    '---------------------------------------------------------------------------------------
    ' Procedure : Encrypt
    ' DateTime  : 06/05/2015 16:08
    ' Author    : Vittorio
    ' Purpose   : Convierte la función de encriptación en privada
    '           : y deja la anterior como pública sin exponer el código.
    '---------------------------------------------------------------------------------------
    '
    Private Function Encrypt(ByVal valor As String) As String
        Dim idxVal As Integer, idxSem As Integer, iChar As Integer, sResult As String, ioffSet As Integer, sTempVal As String
        Dim CicloInter As Integer
        sResult = ""
        sTempVal = valor
        idxSem = 0
        ioffSet = cLimiteSup - cLimiteInf + 1
        For CicloInter = 1 To cInterac
            sResult = ""
            For idxVal = 0 To (sTempVal.Length - 1)
                'idxSem = idxSem + 1
                If idxSem = cSemilla.Length Then idxSem = 0
                iChar = System.Convert.ToByte(sTempVal.Chars(idxVal)) + Integer.Parse(cSemilla.Chars(idxSem))
                If cCarInvOff <> 0 Then
                    If iChar >= cCarInvInf AndAlso iChar <= cCarInvSup Then
                        iChar = iChar + cCarInvOff
                        GoTo ContEncrypt
                    End If
                End If
                If iChar > cLimiteSup Then
                    iChar = iChar - ioffSet
                End If
                'Esta rutina protege el obtener resultados comilla simple ('),
                'es sólo para guardar el resultado en Base de datos SQL
ContEncrypt:
                If cFormatoBD And iChar = 39 And CicloInter = cInterac Then
                    sResult = sResult & "''"
                Else
                    sResult = sResult & System.Convert.ToChar(iChar)
                End If
                idxSem += 1
            Next idxVal
            sTempVal = sResult
        Next CicloInter
        Return sResult
    End Function

    '---------------------------------------------------------------------------------------
    ' Procedure : DecriptarCs
    ' DateTime  : 12/04/2005 03:25 pm
    ' Author    : Joaco
    ' Purpose   : Decripta el valor del string de entrada, al ser de tipo string
    '           : su tamaño máximo debe ser de 255 caracteres.
    '---------------------------------------------------------------------------------------
    '
    Public Function DecriptarCs(ByVal valor As String) As String
        If cSemilla Is Nothing Then
            Throw New System.Exception("clsCesar: La semilla debe ser inicializada.")
            Return ""
        End If
        If cSemilla.Trim.Length = 0 Or cSemilla.Trim = " " Then
            Throw New System.Exception("clsCesar: La semilla debe ser inicializada.")
            Return ""
        End If
        Return Decrypt(valor)
    End Function
    '---------------------------------------------------------------------------------------
    ' Procedure : Dencrypt
    ' DateTime  : 06/05/2015 16:08
    ' Author    : Vittorio
    ' Purpose   : Convierte la función de decriptación en privada
    '           : y deja la anterior como pública sin exponer el código.
    '---------------------------------------------------------------------------------------
    '
    Private Function Decrypt(ByVal valor As String) As String
        Dim idxVal As Integer, idxSem As Integer, iChar As Integer, sResult As String, ioffSet As Integer, sTempVal As String
        Dim CicloInter As Integer
        sResult = ""
        sTempVal = valor
        idxSem = 0
        ioffSet = cLimiteSup - cLimiteInf + 1
        For CicloInter = 1 To cInterac
            sResult = ""
            For idxVal = 0 To (sTempVal.Length - 1)
                'idxSem = idxSem + 1
                If idxSem = cSemilla.Length Then idxSem = 0
                Try
                    iChar = System.Convert.ToByte(sTempVal.Chars(idxVal))
                Catch ex As Exception
                    Throw New System.Exception(ex.Source & ": " & ex.Message)
                End Try

                If cCarInvOff <> 0 Then
                    If iChar > cLimiteSup Then
                        iChar = iChar - cCarInvOff
                    End If
                End If
                Try
                    iChar = iChar - Integer.Parse(cSemilla.Chars(idxSem))
                Catch ex As Exception
                    Throw New System.Exception(ex.Source & ": " & ex.Message)
                End Try

                If iChar < cLimiteInf Then
                    iChar = iChar + ioffSet
                End If
                sResult = sResult & System.Convert.ToChar(iChar)
                idxSem += 1
            Next idxVal
            sTempVal = sResult
        Next CicloInter
        Return sResult
    End Function

    Public Sub New()
        Call CargarKeys()
    End Sub
End Class
