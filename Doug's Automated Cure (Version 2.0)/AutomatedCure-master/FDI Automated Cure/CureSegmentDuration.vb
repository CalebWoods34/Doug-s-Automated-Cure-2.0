'Time Class
'Unit is minutes

Public Class CureSegmentDuration
    Private _nominal As UShort = 0 'Nominal time in minutes
    Private _low As UShort = 0 'Lowest tolerable time in minutes
    Private _high As UShort = 0 'Highest tolerable time in minutes

    Public Sub New(Nominal As UShort, Low As UShort, High As UShort)
        _nominal = Nominal
        _low = Low
        _high = High
    End Sub

    Public Sub New(Nominal As UShort) 'If only one value is given at construction, use it for high and low as well
        If Nominal < 1 Then
            _nominal = 1
        Else
        _nominal = Nominal
        End If
        _low = _nominal - 1
        _high = _nominal + 1
    End Sub

    Public Sub New()

    End Sub

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

    Friend Shared Function EmptyDuration() As CureSegmentDuration
        Return New CureSegmentDuration(0, 0, 0)
    End Function
End Class
