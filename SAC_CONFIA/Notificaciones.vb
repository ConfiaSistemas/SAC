Public Class Notificaciones
    Private _id As Integer
    Private _Tipo As String
    Private _Usuario As String
    Private _UsuarioDestino As String
    Private _Notificacion As Boolean
    Private _Valor As String
    Private _Mensaje As String
    Private _Comentario As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value

        End Set
    End Property

    Public Property UsuarioDestino As String
        Get
            Return _UsuarioDestino
        End Get
        Set(value As String)
            _UsuarioDestino = value
        End Set
    End Property

    Public Property Notificacion As Boolean
        Get
            Return _Notificacion
        End Get
        Set(value As Boolean)
            _Notificacion = value
        End Set
    End Property

    Public Property Valor As String
        Get
            Return _Valor
        End Get
        Set(value As String)
            _Valor = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property Comentario As String
        Get
            Return _Comentario
        End Get
        Set(value As String)
            _Comentario = value
        End Set
    End Property

End Class
