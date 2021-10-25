Imports System.IO

Public Class CureDeviceBookmark
    Private _startDate As DateTime
    Private _endDate As DateTime
    Public Property _cureDeviceName As String
    Public Property _listOfPartBookmarkFilenames As List(Of String)

    Public Property StartDate As Date
        Get
            Return _startDate
        End Get
        Set(value As Date)
            _startDate = value
        End Set
    End Property

    Public Property EndDate As Date
        Get
            Return _endDate
        End Get
        Set(value As Date)
            _endDate = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub Create(device As CureDevice, _parts As List(Of Part))
        _cureDeviceName = device.Name
        If BookmarkFileExists(_cureDeviceName) Then
            Call DeleteBookmarkFromDisk(device.Name)
        End If
        Call AddParts(_parts)
        Call MarkStartOfCure()
        _endDate = _startDate.AddMinutes(1) 'prevents an issue where the end date precedes the start date.
        Call SaveBookmarkToDisk(_cureDeviceName)
    End Sub

    Public Sub Create(deviceName As String, parts(,) As String)
        If BookmarkFileExists(deviceName) Then
            Call DeleteBookmarkFromDisk(deviceName)
        End If
        _cureDeviceName = deviceName
        Call AddParts(parts)
        Call MarkStartOfCure()
        _endDate = _startDate.AddMinutes(1) 'prevents an issue where the end date precedes the start date.
        Call SaveBookmarkToDisk(deviceName)
    End Sub

    Public Function BookmarkFileExists(deviceName As String) As Boolean
        Dim result = False
        If File.Exists($"{FrmMain.cureLogBaseDirectory}\{deviceName}\{deviceName}.xml") Then
            result = True
        End If
        Return result
    End Function

    Public Sub MarkStartOfCure()
        StartDate = Date.Now()
    End Sub

    Public Sub MarkEndOfCure(deviceName As String)
        If BookmarkFileExists(deviceName) Then
            Call ReadBookmarkFromDisk(deviceName)
        End If
        If Date.Now > (StartDate.AddMinutes(2)) Then 'this fixes the case where the cure ending timestamp is before the red lion has updated the log.
            EndDate = Date.Now() - New TimeSpan(0, 1, 0)
            Call SaveBookmarkToDisk(deviceName)
        Else
            Call DeleteBookmarkFromDisk(deviceName)
            Throw New Exception("Not enough records to generate log")
        End If
    End Sub

    Public Sub SaveBookmarkToDisk(deviceName As String)
        Try
            Dim strpath As String = $"{FrmMain.cureLogBaseDirectory}\{deviceName}\{deviceName}.xml" 'Defines path of file
            If Not Directory.Exists($"{FrmMain.cureLogBaseDirectory}\{deviceName}") Then 'Creates a directory if necessary
                Directory.CreateDirectory($"{FrmMain.cureLogBaseDirectory}\{deviceName}")
            End If

            Dim writer As New Xml.Serialization.XmlSerializer(GetType(CureDeviceBookmark))
            Dim _file As New StreamWriter(strpath)
            writer.Serialize(_file, Me)
            _file.Close()

        Catch ex As Exception
            MsgBox($"Error while writing bookmark {deviceName}.xml file. {vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Sub ReadBookmarkFromDisk(deviceName As String)
        Try
            Dim temporaryBookmark As CureDeviceBookmark
            Dim strpath As String = $"{FrmMain.cureLogBaseDirectory}\{deviceName}\{deviceName}.xml" 'Defines path of file
            Dim reader As New Xml.Serialization.XmlSerializer(GetType(CureDeviceBookmark))
            Dim _file As New StreamReader(strpath)
            temporaryBookmark = CType(reader.Deserialize(_file), CureDeviceBookmark)

            _startDate = temporaryBookmark.StartDate
            _endDate = temporaryBookmark.EndDate
            _cureDeviceName = temporaryBookmark._cureDeviceName
            _listOfPartBookmarkFilenames = temporaryBookmark._listOfPartBookmarkFilenames

            _file.Close()
        Catch ex As Exception
            MsgBox($"Error while reading {_cureDeviceName}.xml file. {vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Sub DeleteBookmarkFromDisk(deviceName As String)
        Try
            Dim strpath As String = $"{FrmMain.cureLogBaseDirectory}\{deviceName}\{deviceName}.xml" 'Defines path of file
            If File.Exists(strpath) Then
                File.Delete(strpath)
            End If
        Catch ex As Exception
            MsgBox($"Error while deleting {deviceName}.xml file. {vbCrLf}{ex.Message}")
        End Try
    End Sub

    Public Sub AddPartBookmarkFilename(_part As Part)
        Dim bookmarkFilename = $"{_part.PartNumber}_{_part.JobNumber}.xml"
        If Not _listOfPartBookmarkFilenames.Contains(bookmarkFilename) Then
            _listOfPartBookmarkFilenames.Add(bookmarkFilename)
        End If
    End Sub

    Public Sub RemoveBookmarkFilename(_part As Part)
        Dim bookmarkFilename = $"{_part.PartNumber}_{_part.JobNumber}.xml"
        For Each item In _listOfPartBookmarkFilenames.ToArray
            If item = bookmarkFilename Then
                _listOfPartBookmarkFilenames.Remove(bookmarkFilename)
            End If
        Next
    End Sub

    Public Sub AddParts(_parts As List(Of Part))
        Dim partList As New List(Of String)
        For Each _part In _parts
            partList.Add(BuildFilename(_part.PartNumber, _part.JobNumber))
        Next
        _listOfPartBookmarkFilenames = partList
    End Sub

    Public Sub AddParts(_parts(,) As String)
        Dim partList As New List(Of String)
        For i = 0 To (_parts.Length / 2) - 1
            partList.Add(BuildFilename(_parts(i, 0), _parts(i, 1)))
        Next
        _listOfPartBookmarkFilenames = partList
    End Sub

    Private Function BuildFilename(partNumber As String, jobNumber As String) As String
        Return $"{partNumber}_{jobNumber}.xml"
    End Function

End Class

