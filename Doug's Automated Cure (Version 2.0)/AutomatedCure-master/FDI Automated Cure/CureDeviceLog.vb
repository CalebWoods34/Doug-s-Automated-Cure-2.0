Imports System.IO
Imports FDI_Automated_Cure

Public Class CureDeviceLog
    Private _records As New List(Of CureDeviceLogRecord)

    Public Property Records As List(Of CureDeviceLogRecord)
        Get
            Return _records
        End Get
        Set(value As List(Of CureDeviceLogRecord))
            _records = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub ReadCureLogFromFile(_fileName As String, _cureLogPath As String)
        Dim cureLog As New CureDeviceLog
        Try
            Dim xmlFormat As New Xml.Serialization.XmlSerializer(GetType(CureDeviceLog))
            Dim _file As New StreamReader($"{_cureLogPath}\{_fileName}")
            cureLog = CType(xmlFormat.Deserialize(_file), CureDeviceLog)

            Records = cureLog.Records

            _file.Close()
        Catch ex As Exception
            MsgBox($"Not able to read {_fileName}.xml bookmark.{vbCrLf}{ex.Message}")
        End Try
    End Sub

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
