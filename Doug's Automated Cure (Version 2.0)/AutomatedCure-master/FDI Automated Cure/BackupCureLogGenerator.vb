Public Class BackupCureLogGenerator
    Private bookmark As New CureDeviceBookmark
    Private deviceName As String
    Private _deviceCureLog As CureDeviceLog
    Private _parts As List(Of Part)
    Private startDate As DateTime
    Private endDate As DateTime

    Public Sub New(deviceName As String)
        Me.deviceName = deviceName
        Dim partNumber1 As String = "7510145-1"
        Dim jobNumber1 As String = "J123454"
        Dim device = New CureDevice(deviceName, True)
        Dim part1 As New Part(partNumber1, device.Name)
        part1.AddThermocouple(New Thermocouple(2))
        device.Parts.Add(part1)
        Dim bookmark As New CureDeviceBookmark()
        bookmark._cureDeviceName = device.Name
        bookmark.StartDate = New Date(2021, 9, 28, 10, 0, 0)
        bookmark.EndDate = New Date(2021, 9, 28, 14, 30, 0)
        bookmark.AddPartBookmarkFilename(part1)
        bookmark.SaveBookmarkToDisk(device.Name)

        Dim builder = New CureLogBuilder(device.Name)
        builder.CreatePartCureLogs(device.Parts)
    End Sub
End Class
