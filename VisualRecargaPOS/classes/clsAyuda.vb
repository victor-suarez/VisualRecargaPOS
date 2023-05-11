Option Strict On
Friend Class clsAyuda
    Private lcSQL As String
    Private lcx As ADODB.Connection
    Private lrs As New ADODB.Recordset
    Private oRET As Object

    Private mvarClave As String
    Private mvarValor As String
    Public ReadOnly Property Clave() As String
        Get
            Return mvarClave
        End Get
    End Property
    Public ReadOnly Property Valor() As String
        Get
            Return mvarValor
        End Get
    End Property
    Public Sub CargaCombo(ByVal frmName As String, ByVal cmb As System.Windows.Forms.ComboBox)
        cmb.Items.Clear()
        Try
            lcSQL = "EXEC SpConCamposSoporte @Forma='" & frmName & "',@Campo='" & cmb.Name & "'"
            lrs = lcx.Execute(lcSQL, oRET)
            Do While Not lrs.EOF
                cmb.Items.Add(New clsAyuda(lrs("Clave").Value.ToString, lrs("Valor").Value.ToString))
                lrs.MoveNext()
            Loop
            lrs.Close()
            lrs = Nothing
        Catch ex As Exception
            Throw New System.Exception(ex.Source & ": " & ex.Message)
        End Try
        cmb.SelectedIndex = -1
    End Sub
    Public Sub New(Optional ByRef cx As ADODB.Connection = Nothing)
        mvarClave = Nothing
        mvarValor = Nothing
        If Not cx Is Nothing Then lcx = cx
    End Sub
    Public Sub New(ByVal Clave As String, ByVal Valor As String)
        mvarClave = Clave
        mvarValor = Valor
    End Sub
    Public Overrides Function ToString() As String
        Return mvarValor
    End Function
End Class
