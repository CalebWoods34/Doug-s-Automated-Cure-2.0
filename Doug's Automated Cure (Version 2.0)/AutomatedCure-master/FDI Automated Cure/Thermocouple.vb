Public Class Thermocouple
    Implements IComparable(Of Thermocouple)
    Private _id As UShort
    Private _temperature As Single = Nothing
    Private _OnOff As Boolean = False 'true for on and false for off

    Public Property Id As UShort
        Get
            Return _id
        End Get
        Set(value As UShort)
            _id = value
        End Set
    End Property

    Public Property Temperature As Single
        Get
            Return _temperature
        End Get
        Set(value As Single)
            _temperature = value
        End Set
    End Property

    Public Property OnOff As Boolean
        Get
            Return _OnOff
        End Get
        Set(value As Boolean)
            _OnOff = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ThermocoupleId As UShort)
        _id = ThermocoupleId
        _OnOff = True
    End Sub

    Public Sub New(ThermocoupleId As UShort, Temperature As Single)
        _id = ThermocoupleId
        _temperature = Temperature
    End Sub

    Public Sub SetTemperature(Temperature As Single)
        _temperature = Temperature
    End Sub

    Public Function CompareTo(other As Thermocouple) As Integer Implements IComparable(Of Thermocouple).CompareTo
        If other.Id < Me.Id Then
            Return 1
        ElseIf other.Id > Me.Id Then
            Return -1
        Else Return 0
        End If
    End Function

    Public Overrides Function ToString() As String
        Return _id.ToString()
    End Function

    Public Sub TurnOn()
        OnOff = True
    End Sub

    Public Sub TurnOff()
        OnOff = False
    End Sub
End Class
