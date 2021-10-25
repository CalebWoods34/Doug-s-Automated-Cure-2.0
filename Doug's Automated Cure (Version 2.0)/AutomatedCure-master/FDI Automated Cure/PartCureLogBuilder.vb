Imports System.IO
Imports System.Net

Public Class PartCureLogBuilder
    Private _cureRecipe As CureCycle
    Private _deviceName As String
    Private _jobNumber As String
    Private _partNumber As String
    Private _serialNumber As String
    Private _partDescription As String
    Private _assignedThermocouples As New List(Of UShort)
    Private _cureDeviceLog As CureDeviceLog


    Public Sub New(_part As Part, _cureDeviceLog As CureDeviceLog)
        _deviceName = _part.CureDeviceName
        _jobNumber = _part.JobNumber
        _partNumber = _part.PartNumber
        _serialNumber = _part.SerialNumber
        _partDescription = _part.PartDescription
        _cureRecipe = _part.CureCycle
        Me._cureDeviceLog = _cureDeviceLog
        Call BuildListOfThermocoupleIds(_part)
    End Sub

    Public Sub BuildListOfThermocoupleIds(_part As Part)
        For Each _thermocouple In _part.AssignedThermocouples
            _assignedThermocouples.Add(_thermocouple.Id)
        Next
        Call _assignedThermocouples.Sort()
    End Sub

    Public Sub CreatePartCureLogFile()
        Dim partCureLog As New PartCureLog
        Dim records As New List(Of PartCureLogRecord)
        partCureLog.CureDeviceName = _deviceName
        partCureLog.PartRecipe = _cureRecipe
        partCureLog.AssignedThermocouples = _assignedThermocouples
        partCureLog.PartNumber = _partNumber
        partCureLog.JobNumber = _jobNumber
        partCureLog.SerialNumber = _serialNumber
        partCureLog.PartDescription = _partDescription

        For Each deviceRecord In _cureDeviceLog.Records
            records.Add(ParseRelevantItemsFromRecord(deviceRecord))
        Next
        partCureLog.Records = records
        SaveCureLogToDisk(partCureLog)
    End Sub

    Public Sub SaveCureLogToDisk(cureLog As PartCureLog)
        Try
            If Not Directory.Exists($"{FrmMain.cureLogBaseDirectory}\{_deviceName}") Then
                Directory.CreateDirectory($"{FrmMain.cureLogBaseDirectory}\{_deviceName}")
            End If
            Dim _xmlFormat As New Xml.Serialization.XmlSerializer(GetType(PartCureLog))
            Dim _file As New StreamWriter($"{FrmMain.cureLogBaseDirectory}\{_deviceName}\{_partNumber}_{_jobNumber}.log")
            _xmlFormat.Serialize(_file, cureLog)
            _file.Close()

        Catch ex As Exception
            MsgBox($"Error saving {_partNumber}_{_jobNumber}.log to disk.{vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Function ParseRelevantItemsFromRecord(_record As CureDeviceLogRecord) As PartCureLogRecord

        Dim _parsedThermocouples As New List(Of Single)
        For Each _thermocouple In _record.Thermocouples
            If _assignedThermocouples.Contains(_thermocouple.Id) Then
                _parsedThermocouples.Add(_thermocouple.Temperature)
            End If
        Next

        Dim _newRecord = New PartCureLogRecord() With {
            .Date = _record.Date,
            .Temperature = _record.Temperature,
            .Setpoint = _record.Setpoint,
            .Thermocouples = _parsedThermocouples
        }
        Return _newRecord
    End Function

End Class
