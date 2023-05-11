Friend Class clsEmpresa
    Private mvarID As Integer
    Private mvarNombre As String
    Private mvarProducto As String
    Private mvarSerial As String
    Private mvarLongitud As Short
    Private mvarMinimo As Decimal
    Private mvarMaximo As Decimal
    Private mvarMultiplo As Decimal
    Private mvarMsgTicket As String
    Private mvarStatus As String
    Private mvarUsaCedula As Boolean
    Private mvarArrSeriales As String
    Private mvarMsgLimites As String

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
    Public ReadOnly Property Producto() As String
        Get
            Return mvarProducto
        End Get
    End Property
    Public ReadOnly Property Serial() As String
        Get
            Return mvarSerial
        End Get
    End Property
    Public ReadOnly Property Longitud() As Short
        Get
            Return mvarLongitud
        End Get
    End Property
    Public ReadOnly Property Minimo() As Decimal
        Get
            Return mvarMinimo
        End Get
    End Property
    Public ReadOnly Property Maximo() As Decimal
        Get
            Return mvarMaximo
        End Get
    End Property
    Public ReadOnly Property Multiplo() As Decimal
        Get
            Return mvarMultiplo
        End Get
    End Property
    Public ReadOnly Property MsgTicket() As String
        Get
            Return mvarMsgTicket
        End Get
    End Property
    Public ReadOnly Property Status() As String
        Get
            Return mvarStatus
        End Get
    End Property
    Public ReadOnly Property UsaCedula() As Boolean
        Get
            Return mvarUsaCedula
        End Get
    End Property
    Public Property Seriales() As String
        Get
            Return mvarArrSeriales
        End Get
        Set(ByVal value As String)
            mvarArrSeriales = value
        End Set
    End Property
    Public ReadOnly Property MsgLimites() As String
        Get
            Return mvarMsgLimites
        End Get
    End Property
    Public Sub New(ByVal ID As Integer, ByVal Nombre As String, ByVal Producto As String, ByVal Serial As String, ByVal Longitud As Short, ByVal Minimo As Decimal, ByVal Maximo As Decimal, ByVal Multiplo As Decimal, ByVal MsgTicket As String, ByVal Status As String, Optional ByRef UsaCedula As Boolean = False)
        mvarID = ID
        mvarNombre = Nombre
        mvarProducto = Producto
        mvarSerial = Serial
        mvarLongitud = Longitud
        mvarMinimo = Minimo
        mvarMaximo = Maximo
        mvarMultiplo = Multiplo
        mvarMsgTicket = MsgTicket
        mvarStatus = Status
        mvarUsaCedula = UsaCedula
        mvarArrSeriales = ""
        mvarMsgLimites = "Monto entre " & Minimo.ToString("##,###,##0.00") & " y " & Maximo.ToString("##,###,##0.00") & " en múltiplos de " & Multiplo.ToString("##,###,##0.00")
    End Sub
    Public Overrides Function ToString() As String
        Return mvarNombre
    End Function
End Class
