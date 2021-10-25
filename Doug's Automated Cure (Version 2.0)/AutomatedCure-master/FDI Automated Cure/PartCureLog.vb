Imports System.IO

Public Class PartCureLog
    Private _cureDeviceName As String
    Private _partNumber As String
    Private _partDescription As String
    Private _jobNumber As String
    Private _serialNumber As String
    Private _assignedThermocouples As List(Of UShort)
    Private _partRecipe As CureCycle
    Private _records As List(Of PartCureLogRecord)

    Public Property Records As List(Of PartCureLogRecord)
        Get
            Return _records
        End Get
        Set(value As List(Of PartCureLogRecord))
            _records = value
        End Set
    End Property

    Public Property PartRecipe As CureCycle
        Get
            Return _partRecipe
        End Get
        Set(value As CureCycle)
            _partRecipe = value
        End Set
    End Property

    Public Property AssignedThermocouples As List(Of UShort)
        Get
            Return _assignedThermocouples
        End Get
        Set(value As List(Of UShort))
            _assignedThermocouples = value
        End Set
    End Property

    Public Property CureDeviceName As String
        Get
            Return _cureDeviceName
        End Get
        Set(value As String)
            _cureDeviceName = value
        End Set
    End Property

    Public Property PartNumber As String
        Get
            Return _partNumber
        End Get
        Set(value As String)
            _partNumber = value
        End Set
    End Property

    Public Property PartDescription As String
        Get
            Return _partDescription
        End Get
        Set(value As String)
            _partDescription = value
        End Set
    End Property

    Public Property JobNumber As String
        Get
            Return _jobNumber
        End Get
        Set(value As String)
            _jobNumber = value
        End Set
    End Property

    Public Property SerialNumber As String
        Get
            Return _serialNumber
        End Get
        Set(value As String)
            _serialNumber = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Shared Function ReadPartCureLogFromFile(_fileName As String, _cureLogPath As String) As PartCureLog
        Dim cureLog As New PartCureLog
        Try
            Dim xmlFormat As New Xml.Serialization.XmlSerializer(GetType(PartCureLog))
            Dim _file As New StreamReader($"{_cureLogPath}\{_fileName}")
            cureLog = CType(xmlFormat.Deserialize(_file), PartCureLog)
            _file.Close()

        Catch ex As Exception
            MsgBox($"Not able to read {_fileName} log.{vbCrLf}{ex.Message}")
        End Try
        Return cureLog
    End Function

    Public Sub DeleteFile(_filename As String, _cureLogPath As String)
        Try
            If File.Exists($"{_cureLogPath}\{_filename}") Then
                File.Delete($"{_cureLogPath}\{_filename}")
            End If
        Catch ex As Exception
            MsgBox($"Error deleting {_filename}.{Environment.NewLine}{ex.Message}")
        End Try
    End Sub
End Class
