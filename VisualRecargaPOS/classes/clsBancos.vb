Friend Class clsBancos
    Private lcSQL As String
    Private lcx As ADODB.Connection
    Private lrs As New ADODB.Recordset
    Private oRET As Object

    Private mvarID As Integer
    Private mvarNombre As String
    Private mvarNombreCorto As String
    Private mvarCodigo As String

    Public ReadOnly Property ID() As Integer
        Get
            Return mvarID
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return mvarNombre
        End Get
    End Property
    Public ReadOnly Property NombreCorto() As String
        Get
            Return mvarNombreCorto
        End Get
    End Property
    Public ReadOnly Property Codigo() As String
        Get
            Return mvarCodigo
        End Get
    End Property
    Public Sub CargaCombo(ByVal cmb As System.Windows.Forms.ComboBox)
        cmb.Items.Clear()
        Try
            lcSQL = "EXEC [SpConBancosVzla]"
            lrs = lcx.Execute(lcSQL, oRET)
            Do While Not lrs.EOF
                cmb.Items.Add(New clsBancos(CInt(lrs("ID_BancosVzla").Value), lrs("Nombre").Value.ToString, lrs("NombreCorto").Value.ToString, lrs("Codigo").Value.ToString))
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
        mvarID = Nothing
        mvarNombre = Nothing
        mvarNombreCorto = Nothing
        mvarCodigo = Nothing
        If Not cx Is Nothing Then lcx = cx
    End Sub
    Public Sub New(ByVal ID As Integer, ByVal Nombre As String, ByVal NombreCorto As String, ByVal Codigo As String)
        mvarID = ID
        mvarNombre = Nombre
        mvarNombreCorto = NombreCorto
        mvarCodigo = Codigo
    End Sub
    Public Overrides Function ToString() As String
        Return mvarNombreCorto
    End Function
End Class
