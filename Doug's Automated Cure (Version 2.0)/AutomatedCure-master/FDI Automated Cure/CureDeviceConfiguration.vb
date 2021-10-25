Public Class CureDeviceConfiguration
    Private _name As String
    Private _type As String
    Private _registerStartingAddress As UInt16
    Private _needsPID As Boolean
    Private _numberOfThermocouples As UInt16

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Type As String
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property

    Public Property RegisterStartingAddress As UShort
        Get
            Return _registerStartingAddress
        End Get
        Set(value As UShort)
            _registerStartingAddress = value
        End Set
    End Property

    Public Property NeedsPID As Boolean
        Get
            Return _needsPID
        End Get
        Set(value As Boolean)
            _needsPID = value
        End Set
    End Property

    Public Property NumberOfThermocouples As UShort
        Get
            Return _numberOfThermocouples
        End Get
        Set(value As UShort)
            _numberOfThermocouples = value
        End Set
    End Property



End Class
