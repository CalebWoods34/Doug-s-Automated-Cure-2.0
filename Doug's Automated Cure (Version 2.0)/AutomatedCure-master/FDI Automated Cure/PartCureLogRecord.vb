Public Class PartCureLogRecord
    Private _date As DateTime
    Private _temperature As Single
    Private _setpoint As Single
    Private _thermocoupleTemperatures As New List(Of Single)

    Public Property [Date] As Date
        Get
            Return _date
        End Get
        Set(value As Date)
            _date = value
        End Set
    End Property

    Public Property Temperature As Single
        Get
            Return _temperature
        End Get
        Set(value As Single)
            If value < 0 Or value = Nothing Then
                _temperature = Single.NaN
            Else
                _temperature = value
            End If
        End Set
    End Property

    Public Property Setpoint As Single
        Get
            Return _setpoint
        End Get
        Set(value As Single)
            If value < 0 Or value = Nothing Then
                _setpoint = Single.NaN
            Else
                _setpoint = value
            End If
        End Set
    End Property

    Public Property Thermocouples As List(Of Single)
        Get
            Return _thermocoupleTemperatures
        End Get
        Set(value As List(Of Single))
            _thermocoupleTemperatures = value
        End Set
    End Property

    Public Sub New()
    End Sub

End Class
