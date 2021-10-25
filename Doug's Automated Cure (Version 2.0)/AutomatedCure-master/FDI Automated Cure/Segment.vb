'Segment Class
'Variable containing all necessary information for each segment of a cure cycle

Public Class Segment
    Private _segType As String 'Type of Segment..... Ramp Up, Ramp Down, Soak, End
    Private _temperature As CureCycleTemperature
    Private _time As CureSegmentDuration
    Private _rate As CureRate

    Public Sub New()
    End Sub

    Public Sub New(SegType As String, Rate As CureRate)
        _segType = SegType
        Me.Rate = Rate
    End Sub 'New for Ramp Segment

    Public Sub New(SegType As String, Temperature As CureCycleTemperature, Time As CureSegmentDuration)
        _segType = SegType
        _temperature = Temperature
        _time = Time
    End Sub 'New for Soak Segment

    Public Sub New(SegType As String, Temperature As CureCycleTemperature)
        _segType = SegType
        _temperature = Temperature
    End Sub 'New for End Segment

    Public Property SegType As String
        Get
            Return _segType
        End Get
        Set(value As String)
            _segType = value
        End Set
    End Property

    Public Property Temperature As CureCycleTemperature
        Get
            Return _temperature
        End Get
        Set(value As CureCycleTemperature)
            _temperature = value
        End Set
    End Property

    Public Property Time As CureSegmentDuration
        Get
            Return _time
        End Get
        Set(value As CureSegmentDuration)
            _time = value
        End Set
    End Property

    Public Property Rate As CureRate
        Get
            Return _rate
        End Get
        Set(value As CureRate)
            _rate = value
        End Set
    End Property
End Class
