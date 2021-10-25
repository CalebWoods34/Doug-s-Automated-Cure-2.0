Public Class PartThermocoupleReading
    Private _dateStamp As Date
    Private _thermocoupleId As UShort
    Private _thermocoupleTemperature As Single

    Public Property DateStamp As Date
        Get
            Return _dateStamp
        End Get
        Set(value As Date)
            _dateStamp = value
        End Set
    End Property

    Public Property ThermocoupleIds As UShort
        Get
            Return _thermocoupleId
        End Get
        Set(value As UShort)
            _thermocoupleId = value
        End Set
    End Property

    Public Property ThermocoupleTemperature As Single
        Get
            Return _thermocoupleTemperature
        End Get
        Set(value As Single)
            _thermocoupleTemperature = value
        End Set
    End Property

    Public Sub New(TimeStamp As Date, TcId As UShort, TemperatureReading As Single)
        _dateStamp = TimeStamp
        _thermocoupleId = TcId
        _thermocoupleTemperature = TemperatureReading
    End Sub

End Class
