Imports System.IO

Public Class PartCureBookmark
    'Private _startDate As DateTime
    'Private _endDate As DateTime
    Private _cureDeviceName As String
    Private _cureDeviceLogFilename As String
    Private _jobNumber As String
    Private _partNumber As String
    Private _serialNumber As String
    Private _assignedThermocouples As List(Of String)

    'Public Property StartDate As Date
    '    Get
    '        Return _startDate
    '    End Get
    '    Set(value As Date)
    '        _startDate = value
    '    End Set
    'End Property

    'Public Property EndDate As Date
    '    Get
    '        Return _endDate
    '    End Get
    '    Set(value As Date)
    '        _endDate = value
    '    End Set
    'End Property

    Public Property CureDeviceLogFilename As String
        Get
            Return _cureDeviceLogFilename
        End Get
        Set(value As String)
            _cureDeviceLogFilename = value
        End Set
    End Property

    Public Property AssignedThermocouples As List(Of String)
        Get
            Return _assignedThermocouples
        End Get
        Set(value As List(Of String))
            _assignedThermocouples = value
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

    Public Property PartNumber As String
        Get
            Return _partNumber
        End Get
        Set(value As String)
            _partNumber = value
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

    Public Property CureDeviceName As String
        Get
            Return _cureDeviceName
        End Get
        Set(value As String)
            _cureDeviceName = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub Create(_device As CureDevice, _part As Part)
        If BookmarkFileExists(_part) Then
            Call DeleteBookmarkFromDisk(_part)
        End If

        CureDeviceLogFilename = _device.Name
        CureDeviceName = _device.Name
        PartNumber = _part.PartNumber
        JobNumber = _part.JobNumber
        AssignedThermocouples = New List(Of String)

        Call AddThermocouples(_part)
        'Call MarkStartOfCure()
        ' _endDate = _startDate.AddMinutes(1) 'prevents an issue where the end date precedes the start date.
        Call SaveBookmarkToDisk()
    End Sub

    Public Sub Create(_deviceBookmark As CureDeviceBookmark, parts As List(Of String))

    End Sub

    Public Function BookmarkFileExists(_part As Part) As Boolean
        Dim result = False
        Dim _dir As String = $"{FrmMain.cureLogBaseDirectory}\{CureDeviceLogFilename}"
        If File.Exists($"{_dir}\{_part.CureDeviceName}\{_part.PartNumber}_{_part.JobNumber}.xml") Then
            result = True
        End If
        Return result
    End Function

    'Public Sub MarkStartOfCure()
    '    StartDate = Date.Now()
    'End Sub

    'Public Sub MarkEndOfCure(_part As Part)
    '    If BookmarkFileExists(_part) Then
    '        Call ReadBookmarkFromDisk(_part)
    '    End If
    '    If Date.Now < StartDate Then 'this shouldn't normally happen
    '        MsgBox($"The log ending time ({Date.Now.ToShortDateString}) must be after the starting time({StartDate.ToShortDateString})")
    '        EndDate = StartDate.AddMinutes(1)
    '    Else
    '        EndDate = Date.Now()
    '    End If
    '    Call SaveBookmarkToDisk()
    'End Sub

    Public Sub SaveBookmarkToDisk()
        Try
            Dim _dir As String = $"{FrmMain.cureLogBaseDirectory}\{CureDeviceLogFilename}"
            Dim strpath As String = $"{_dir}\{CureDeviceLogFilename}\{PartNumber}_{JobNumber}.xml" 'Defines path of file
            If Not Directory.Exists($"{_dir}\{CureDeviceLogFilename}") Then 'Creates a directory if necessary
                Directory.CreateDirectory(_dir)
            End If

            Dim _xmlFormat As New Xml.Serialization.XmlSerializer(GetType(PartCureBookmark))
            Dim _writer As New StreamWriter(strpath)
            _xmlFormat.Serialize(_writer, Me)
            _writer.Close()

        Catch ex As Exception
            MsgBox($"Error while writing {PartNumber}_{JobNumber}.xml file. {vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Sub ReadBookmarkFromDisk(_part As Part)
        Try
            Dim temporaryBookmark As PartCureBookmark
            Dim _dir As String = $"{FrmMain.cureLogBaseDirectory}\{CureDeviceLogFilename}"
            Dim strpath As String = $"{_dir}\{_part.CureDeviceName}\{_part.PartNumber}_{_part.JobNumber}.xml" 'Defines path of file
            Dim _xmlFormat As New Xml.Serialization.XmlSerializer(GetType(PartCureBookmark))
            Dim _reader As New StreamReader(strpath)
            temporaryBookmark = CType(_xmlFormat.Deserialize(_reader), PartCureBookmark)

            '_startDate = temporaryBookmark.StartDate
            '_endDate = temporaryBookmark.EndDate
            _cureDeviceLogFilename = temporaryBookmark.CureDeviceLogFilename
            _partNumber = temporaryBookmark.PartNumber
            _jobNumber = temporaryBookmark.JobNumber
            AssignedThermocouples = temporaryBookmark.AssignedThermocouples

            _reader.Close()
        Catch ex As Exception
            MsgBox($"Error while reading {PartNumber}_{JobNumber}.xml file. {vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Sub DeleteBookmarkFromDisk(_part As Part)
        Try
            Dim _dir As String = $"{FrmMain.cureLogBaseDirectory}\{CureDeviceLogFilename}"
            Dim strpath As String = $"{_dir}\{_part.CureDeviceName}\{_part.PartNumber}_{_part.JobNumber}.xml" 'Defines path of file
            If File.Exists(strpath) Then
                File.Delete(strpath)
            End If
        Catch ex As Exception
            MsgBox($"Error while deleting {PartNumber}_{JobNumber}.xml file. {vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Sub AddThermocouples(_part As Part)
        _assignedThermocouples.Clear()
        For Each _thermocouple In _part.AssignedThermocouples
            _assignedThermocouples.Add(_thermocouple.Id)
        Next
        Call _assignedThermocouples.Sort() 'might not be necessary but will make indexing thermocouples easier
    End Sub

    Public Function GetRedLionLogFilenameAndPath(_date As Date) As String
        Dim _folderName As String
        _folderName = CureDeviceLogFilename.Remove(" ")
        Dim year = _date.Year.ToString.Substring(_date.Year.ToString.Length - 2) 'the red lion log strips the first two digits out of the year
        Dim month = _date.Month
        Dim day = _date.Day
        Return $"{_folderName}\{year}{month}{day}00.CSV"
    End Function

End Class
