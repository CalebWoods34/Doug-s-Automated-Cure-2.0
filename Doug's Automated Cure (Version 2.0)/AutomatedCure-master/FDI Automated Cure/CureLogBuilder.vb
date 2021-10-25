Imports System.IO
Imports System.Net

Public Class CureLogBuilder
    Private _deviceName As String
    Private bookmark As CureDeviceBookmark
    Private deviceCureLog As CureDeviceLog

    Public Sub New(deviceName As String)
        _deviceName = deviceName
        CreateDeviceCureLog()
    End Sub

    Public Sub CreateDeviceCureLog()
        Dim deviceCureLog As New CureDeviceLog
        Call ReadDeviceBookmark()
        Dim _records = BuildRawLogs()
        For Each _record In _records
            Dim result As CureDeviceLogRecord = ParseRelevantItemsFromCsv(_record)
            If result IsNot Nothing Then
                deviceCureLog.Records.Add(result)
            End If
        Next
        Me.deviceCureLog = deviceCureLog
    End Sub

    Public Sub CreatePartCureLogs(parts As List(Of Part))
        For Each _part In parts
            CreatePartCureLog(_part)
        Next
    End Sub

    Private Sub CreatePartCureLog(_part As Part)
        Dim builder As New PartCureLogBuilder(_part, deviceCureLog)
        builder.CreatePartCureLogFile()
    End Sub

    Private Sub ReadDeviceBookmark()
        Try
            Dim xmlFormat As New Xml.Serialization.XmlSerializer(GetType(CureDeviceBookmark))
            Dim _file As New StreamReader($"{FrmMain.cureLogBaseDirectory}\{_deviceName}\{_deviceName}.xml")
            bookmark = CType(xmlFormat.Deserialize(_file), CureDeviceBookmark)
            _file.Close()

        Catch ex As Exception
            MsgBox($"Not able to read {_deviceName}.xml bookmark.{vbCrLf}{ex.Message}")
        End Try
    End Sub

    Private Function GetLogStartFilename(bookmark As CureDeviceBookmark) As String
        Return (GetRedLionLogFilename(bookmark.StartDate))
    End Function

    Private Function GetLogEndFilename(bookmark As CureDeviceBookmark) As String
        Return (GetRedLionLogFilename(bookmark.EndDate))
    End Function

    Public Function GetRedLionLogFilename(_date As Date) As String
        Dim year = PadSingleDigit(_date.Year - 2000) 'the red lion log strips the 20 out of the year
        Dim month = PadSingleDigit(_date.Month)
        Dim day = PadSingleDigit(_date.Day)
        Return $"{year}{month}{day}00.CSV"
    End Function

    Private Function PadSingleDigit(int As UShort) As String
        Dim result As String
        If int.ToString().Length < 2 Then
            result = $"0{int}"
        Else
            result = int.ToString
        End If
        Return result
    End Function

    Private Function BuildRawLogs() As List(Of String)
        Dim output As New List(Of String)
        Dim startLogFilename = GetLogStartFilename(bookmark)
        Dim endLogFilename = GetLogEndFilename(bookmark)
        output = GetParsedCsvData(startLogFilename)
        If endLogFilename <> startLogFilename Then
            output.AddRange(GetParsedCsvData(endLogFilename))
        End If
        Return output
    End Function

    Public Sub SaveCureLogToDisk(log As CureDeviceLog)
        Try
            Dim _xmlFormat As New Xml.Serialization.XmlSerializer(GetType(CureDeviceLog))
            Dim _file As New StreamWriter($"{FrmMain.cureLogBaseDirectory}\{_deviceName}\{_deviceName}.log")
            _xmlFormat.Serialize(_file, log)
            _file.Close()

        Catch ex As Exception
            MsgBox($"Problem saving cure log {_deviceName}.log to disk.{Environment.NewLine}{ex.Message}")
        End Try
    End Sub

    Private Function GetParsedCsvData(logFileName As String) As List(Of String)
        Dim output As New List(Of String)
        Dim response As String
        response = GetCsvFromServer($"http://{FrmMain.DataStationIpAddress}/logs/{_deviceName.Replace(" ", "")}/{logFileName}")
        If response <> "Not Found" Then
            output = ParseCsvToLines(response)
        Else
            response = GetCsvFile(logFileName)
            If response <> "Not Found" Then
                output = ParseCsvToLines(response)
            End If
        End If
        Return output
    End Function

    Public Function GetCsvFromServer(Url As String) As String
        Try
            Using client = New WebClient()
                Dim myString = Text.Encoding.ASCII.GetString(client.DownloadData(Url))
                Return myString
            End Using
        Catch ex As Exception
            ' MsgBox($"Error in reaching the Red Lion on the network.{Environment.NewLine}{ex.Message}")
            Return "Not Found"
        End Try
    End Function

    Public Function GetCsvFile(fileName As String) As String
        Dim output As String = ""
        Try
            Using sr As New StreamReader($"{FrmMain.BackupTempLogPath}\{_deviceName.Replace(" ", "")}\{fileName}")
                output = sr.ReadToEnd().ToString
            End Using
        Catch ex As Exception
            MsgBox($"Problem reading data from {FrmMain.BackupTempLogPath}\{_deviceName.Replace(" ", "")}\{fileName}.{vbCrLf}{ex.Message}")
            output = "Not Found"
        End Try
        Return output
    End Function

    Public Function ParseCsvToLines(csvString As String) As List(Of String)
        Dim lines As List(Of String)
        lines = Strings.Split(csvString, vbCrLf).ToList
        If lines(lines.Count - 1).Length = 0 Then
            lines.RemoveAt(lines.Count - 1) 'removes the last blank line in the file
        End If
        If lines.Count > 1 Then
            lines.RemoveAt(0) ' removes the first line in the file since it contains only header information
        End If
        Return lines
    End Function

    Public Function ParseRelevantItemsFromCsv(csvString As String) As CureDeviceLogRecord
        Dim stringArray = Strings.Split(csvString, ",")
        Dim _parsedThermocouples As New List(Of Thermocouple)
        Dim id As UShort = 1
        For i = 4 To stringArray.Length - 2 'assumes fixed format of the red lion log record
            _parsedThermocouples.Add(New Thermocouple(id, ParseTemperature(stringArray(i))))
            id += 1
        Next
        If stringArray(0) <> "Not Found" Then
            Dim _date = ParseDateAndTime(stringArray(0), stringArray(1))
            Dim _temperature = ParseTemperature(stringArray(2))
            Dim _setpoint = ParseTemperature(stringArray(3))
            Dim _cureOnOff = ParseCureOnOff(stringArray(stringArray.Length - 1))
            If _date > bookmark.StartDate And _date < bookmark.EndDate Then
                Dim _record = New CureDeviceLogRecord() With {
                    .Date = _date,
                    .Temperature = _temperature,
                    .Setpoint = _setpoint,
                    .Thermocouples = _parsedThermocouples,
                    .CureOnOff = _cureOnOff
                }
                Return _record
            End If
        End If
        Return Nothing
    End Function

    Public Function ParseDateAndTime(dayString As String, timeString As String) As Date
        Dim splitDayString As String()
        splitDayString = Strings.Split(dayString, "/")
        Dim year As UShort = ParseYearFromString(splitDayString(0))
        Dim month As UShort = splitDayString(1)
        Dim day As UShort = splitDayString(2)
        Dim splitTimeString As String()
        splitTimeString = Strings.Split(timeString, ":")
        Dim hour As UShort = splitTimeString(0)
        Dim minute As UShort = splitTimeString(1)
        Dim second As UShort = splitTimeString(2)
        Return New Date(year, month, day, hour, minute, second)
    End Function

    Public Function ParseTemperature(tempString As String)
        Dim value As New Single
        If Single.TryParse(tempString, value) Then
            If value <= 0 Then ' in the absence of a response from the thermocouple, the red lion uses 0 for a value
                value = Single.NaN
            End If
        End If
        Return value
    End Function

    Private Function ParseYearFromString(yearString As String) As UShort
        Dim year As New UShort
        If Integer.TryParse(yearString, year) Then
        End If
        Return year
    End Function

    Private Function ParseCureOnOff(cureOnOffString As String) As Boolean
        Dim isCureOn As New Boolean
        Dim parsedValue As UShort
        If Integer.TryParse(cureOnOffString, parsedValue) Then
            If parsedValue = 1 Then
                isCureOn = True
            Else
                isCureOn = False
            End If
        End If
        Return isCureOn
    End Function
End Class
