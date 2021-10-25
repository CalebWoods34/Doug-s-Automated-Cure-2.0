'Temperature Class

Public Class CureCycleTemperature
    Private _nominal As UShort = 0 'Nominal Temperature
    Private _low As UShort = 0 'Lowest tolerable temperature
    Private _high As UShort = 0 'Highest tolerable temperature

    Public Property Nominal As UShort
        Get
            Return _nominal
        End Get
        Set(value As UShort)
            _nominal = value
        End Set
    End Property

    Public Property Low As UShort
        Get
            Return _low
        End Get
        Set(value As UShort)
            _low = value
        End Set
    End Property

    Public Property High As UShort
        Get
            Return _high
        End Get
        Set(value As UShort)
            _high = value
        End Set
    End Property

    Public Sub New(Nominal As UShort, Low As UShort, High As UShort)
        _nominal = Nominal
        _low = Low
        _high = High

    End Sub

    Public Sub New()

    End Sub

    Friend Shared Function EmptyTemperature() As CureCycleTemperature
        Return New CureCycleTemperature(0, 0, 0)
    End Function
End Class
