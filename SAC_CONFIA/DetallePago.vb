Public Class DetallePago
    Private idPago As Integer
    Private NoPago As Integer
    Private Monto As Double
    Private Interes As Double
    Private HaAbonado As Double
    Private Pendiente As Double
    Private Abonado As Double
    Private Concepto As String
    Private recibido As Double
    Private Descuento As Double
    Public Sub New(_idpago As Integer, _NoPago As Integer, _Monto As Double, _interes As Double, _HaAbonado As Double, _Pendiente As Double, _Abonado As Double, _Concepto As String, _recibido As Double, _descuento As Double)
        idPago = _idpago
        NoPago = _NoPago
        Monto = _NoPago
        Interes = _interes
        HaAbonado = _HaAbonado
        Pendiente = _Pendiente
        Abonado = _Abonado
        Concepto = _Concepto
        recibido = _recibido
        Descuento = _descuento
    End Sub


    Public Sub setidPago(_idpago As Integer)
        idPago = _idpago

    End Sub

    Public Sub setNoPago(_NoPago As Integer)
        NoPago = _NoPago

    End Sub

    Public Sub setMonto(_Monto As Double)
        Monto = _Monto
    End Sub

    Public Sub setInteres(_Interes As Double)
        Interes = _Interes

    End Sub

    Public Sub setHaAbonado(_HaAbonado As Double)
        HaAbonado = _HaAbonado
    End Sub

    Public Sub setPendiente(_Pendiente As Double)
        Pendiente = _Pendiente
    End Sub

    Public Sub setAbonado(_Abonado As Double)
        Abonado = _Abonado
    End Sub

    Public Sub setConcepto(_Concepto As String)
        Concepto = _Concepto
    End Sub
    Public Sub setDescuento(_Descuento As String)
        Descuento = _Descuento
    End Sub
    Public Function getIdPago() As Integer
        Return idPago
    End Function

    Public Function getNoPago() As Integer
        Return NoPago
    End Function

    Public Function getMonto() As Double
        Return Monto
    End Function

    Public Function getInteres() As Double
        Return Interes
    End Function

    Public Function getHaAbonado() As Double
        Return HaAbonado
    End Function


    Public Function getPendiente() As Double
        Return Pendiente
    End Function

    Public Function getAbonado() As Double
        Return Abonado
    End Function

    Public Function getConcepto() As String
        Return Concepto
    End Function
    Public Function getDescuento() As String
        Return Descuento
    End Function

    Public Function GenInteres(pcmil As Double) As Double
        Dim interesDesglosado As Double
        interesDesglosado = (pcmil / 1000) * (Abonado)
        Return interesDesglosado

    End Function

    Public Property EfectivoRecibido() As Double
        Get
            Return recibido
        End Get
        Set(value As Double)
            recibido = value
        End Set
    End Property




End Class
