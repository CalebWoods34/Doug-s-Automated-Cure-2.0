'Rate Class
'Contains necessary information to establish rate of a segment for ramp up and ramp down

Public Class CureRate
    Private _nominal As Single 'Nominal Ramp Rate deg/min
    Private _low As Single 'Lowest tolerable ramp rate deg/min
    Private _high As Single  'highest tolerable ramp rate deg/min

    Public Property Nominal As Single
        Get
            Return _nominal
        End Get
        Set(value As Single)
            _nominal = value
        End Set
    End Property

    Public Property Low As Single
        Get
            Return _low
        End Get
        Set(value As Single)
            _low = value
        End Set
    End Property

    Public Property High As Single
        Get
            Return _high
        End Get
        Set(value As Single)
            _high = value
        End Set
    End Property

    Public Sub New(Nominal As Single, Low As Single, High As Single)
        _nominal = Nominal
        _low = Low
        _high = High
    End Sub

    Public Sub New()

    End Sub
End Class
