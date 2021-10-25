'Cure Device Class
'These are the curing stations in the shop.... ex OvenA, Press5, ...etc
Option Explicit On

Imports System.IO
Imports System.Math
Imports System.Text
Imports Microsoft.Office.Interop

Public Class CureDevice
    'General Variables
    Public ReadOnly ROOM_TEMP = 77
    Public Name As String 'Device Name
    Public DeviceType As String 'Device Type (Oven, Temperature Controller)
    Public Parts As New List(Of Part) '********************Add Part Class
    Public ListOfParts As New List(Of String)
    Public DeviceSetpoint As Single 'Device Setpoint
    Public Temperature As Single 'Device Temperature
    Public StrDecimalTemperature As String
    Public ListOfAllDeviceTCs As List(Of Thermocouple)
    'Public TC(15) As String 'Thermocouple inputs for Oven
    'Public TCOnOff(15) As Boolean 'Thermocouple inputs On/Off for Oven
    Public UsePreheat As Boolean 'True if Preheat is necessary before injection
    Public PreheatLow As Integer 'Low Allowable Preheat Temp
    Public PreheatNominal As Integer = ROOM_TEMP 'Default value for nominal Preheat Temp
    Public PreheatHigh As Integer ' HighPreheat Temp
    Public PreheatTime As Integer 'Minimum Preheat Time
    Public CureLog As CureDeviceLog
    Public cureBookmarkFilename As String
    Public numberOfThermocouples As UShort
    Public controllerNumericStatus As UShort

    Private _cureCycle As CureCycle
    Private _cureDevicePidSettings As New CureDevicePidSettings

    'Status Variables
    Public Status As String 'Status of Cure Device

    'Modbus Register Address Variables for Control Settings
    Public DeviceTemperatureRegisterAddress As UShort 'These are the modbus addresses within the controller where the PID and control settings are stored/accessed
    Public DeviceSetpointOffset As UShort
    Public DeviceCureOnOffOffset As UShort
    Public DeviceSegmentCountOffset As UShort
    Public DeviceCurrentSegmentOffset As UShort
    Public DeviceRecipeArrayStartOffset As UShort
    Public DeviceThermocoupleArrayStartOffset As UShort
    Public DevicePIDSettingsArrayStartOffset As UShort
    Public DeviceStatusOffset As UShort

    Public TmrTemperatureLogging As Timer 'Timer for Logging Temperature
    Public TmrTempSampling As Timer 'Timer for sampling all of the controller parameters
    Public TmrLogTemp As Timer 'Timer for turning on Sampling Light
    Public TemperatureLogPath As String 'File path for temperature log
    Public IsLoggingTemperature As Boolean  'True if Logging Temperature

    Public TmrLogPump As Timer 'Timer for turning on sampling light
    Public BoolLogPump As Boolean 'True if Logging Pump

    Public CureDeviceTabPage As TabPage 'TabPage for curring device
    Public TabControl As ControlCureDevice 'User Controls in Tab Page
    Public HomeRow As DataGridViewRow 'Home DGV Row

    Public InjectionLogTime As Single 'Number of minutes Injection has been logging/running
    Public TemperatureLogTime As Single = 0 'Number of minutes Temperature has been logging/running
    Private ReadOnly RecipeSize As UShort = 10 * 4
    Private ModbusControllerRegisterBlockSize As UShort '= 5 + RecipeSize + numberOfThermocouples 'Temp, SP, cureonoff,currentsegment,numsegs,recipeblock,tcblock
    Private ReadOnly MAX_TC_VALUE As Single = 5000 'Thermocouples will Return large values When disconnected. This value should be Set     
    'low enough to capture all error conditions and yet high enough to handle the
    ' temperatures held as x10 values in the modbus registers.
    Private ControllerOnOff As UShort

    Public Property CureDevicePidSettings As CureDevicePidSettings
        Get
            Return _cureDevicePidSettings
        End Get
        Set(value As CureDevicePidSettings)
            _cureDevicePidSettings = value
        End Set
    End Property

    Public Sub New(DeviceName As String, IsMinimalDevice As Boolean)
        Name = DeviceName
        Call LoadXMLCureDeviceSettingsFile()
        InitializeListOfAllDeviceTCs(numberOfThermocouples)

        If Not IsMinimalDevice Then
            BuildListOfPartsForThisCureDevice()

            CureDeviceTabPage = New TabPage With {
            .Text = DeviceName
        }
            TabControl = New ControlCureDevice(Me)

            CureDeviceTabPage.Controls.Add(TabControl)
            TabControl.LblName.Text = DeviceName
            TabControl.Size = FrmMain.TabControl1.Size
            FrmMain.TabControl1.TabPages.Add(CureDeviceTabPage)
            If DeviceType = "Oven" Then
                FrmMain.DGV2.Rows.Add(New DataGridViewRow)
                HomeRow = FrmMain.DGV2.Rows(FrmMain.DGV2.Rows.Count - 1)
            Else
                FrmMain.DGV1.Rows.Add(New DataGridViewRow)
                HomeRow = FrmMain.DGV1.Rows(FrmMain.DGV1.Rows.Count - 1)
            End If
            AddHandler Me.HomeRow.Cells(0).DataGridView.MouseClick, AddressOf CellClick
            Dim TmrTempLogging As New Timer
            TmrTemperatureLogging = TmrTempLogging
            ' AddHandler Me.TmrTemperatureLogging.Tick, AddressOf LogPartTemperatures
            Me.TmrTemperatureLogging.Interval = 120 * 1000 'Two minute interval
            Me.TmrTemperatureLogging.Enabled = False
            IsLoggingTemperature = False
            BoolLogPump = False
            Status = "Awaiting Start"

            Call ResetTemperatureLogTime()
            Dim TmrTempSampling As New Timer
            Me.TmrTempSampling = TmrTempSampling
            TmrTempSampling.Interval = 10 * 1000 'Ten second interval
            AddHandler TmrTempSampling.Tick, AddressOf SampleParameters
            'Change 
            Call UpdateHomeRow()
            If FrmMain.BoolSampling = True Then
                Me.TmrTempSampling.Enabled = True
                ' Call SampleParameters()
            End If

        End If
    End Sub 'New CureDevice Class

    Private Sub CreateAutomatedCureDevice()

    End Sub

    Public Sub CellClick()
        If HomeRow.Cells(0).Selected = True Then
            FrmMain.TabControl1.SelectedTab = Me.CureDeviceTabPage
            Exit Sub
        End If
        If HomeRow.Cells(1).Selected = True Then
            Try
                Dim NewSetpoint As Single = InputBox("Enter Desired Setpoint (°F) ", Me.Name.ToString + " Change Setpoint ", Me.DeviceSetpoint.ToString, 230, 70)
                Call Me.ChangeControllerSetpoint(NewSetpoint)
                Call Me.UpdateHomeRow()
            Catch er As Exception
            End Try
            Exit Sub
        End If
        If HomeRow.Cells(2).Selected = True Then
            Exit Sub
        End If
        If HomeRow.Cells(3).Selected = True Then
            Exit Sub
        End If
        If Me.HomeRow.Cells(4).Selected = True Then
            Exit Sub
        End If
        If Me.HomeRow.Cells(5).Selected = True Then
            Exit Sub
        End If
    End Sub 'Cell Click Event

    Public Sub UpdateHomeRow()
        Try
            FrmMain.DGV1.ClearSelection()
            Me.HomeRow.Cells(0).Value = Name
            Me.HomeRow.Cells(1).Value = DeviceSetpoint.ToString
            Me.HomeRow.Cells(2).Value = Temperature.ToString
            Me.HomeRow.Cells(3).Value = Status

            If Me.TmrTemperatureLogging.Enabled = True Then
                Me.HomeRow.Cells(4).Value = "1"
            Else
                Me.HomeRow.Cells(4).Value = "0"
            End If
            Dim StrToolTip As String = "" 'String to be displayed in tooltip
            If Me.TabControl.DGVPart.Rows.Count > 1 Then
                Dim StrList As String = ""
                For Each r As DataGridViewRow In Me.TabControl.DGVPart.Rows
                    If Not IsNothing(r.Cells(0).Value) Then
                        StrList += $"{r.Cells(0).Value}, "
                    End If
                Next
                Me.HomeRow.Cells(5).Value = StrList
            ElseIf Me.TabControl.DGVPart.Rows.Count = 1 Then
                Me.HomeRow.Cells(5).Value = Me.TabControl.DGVPart.Rows(0).Cells(0).Value
            Else 'no parts in parts list
                Me.HomeRow.Cells(5).Value = "No Part Selected"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub 'Update HomeRow in Home Page

    Public Sub LoadXMLCureDeviceSettingsFile()
        Dim currentDeviceConfig As New CureDeviceConfiguration
        Try
            Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(CureDeviceConfiguration))
            Dim _file As New System.IO.StreamReader(CStr($"{FrmMain.baseDirectory}\Data\Curing Devices\{Name}.csf"))
            currentDeviceConfig = CType(reader.Deserialize(_file), CureDeviceConfiguration)
            _file.Close()
            Name = currentDeviceConfig.Name
            DeviceType = currentDeviceConfig.Type
            DeviceTemperatureRegisterAddress = currentDeviceConfig.RegisterStartingAddress
            numberOfThermocouples = currentDeviceConfig.NumberOfThermocouples

            Dim registerOffset = 0
            registerOffset += 5
            DeviceRecipeArrayStartOffset = registerOffset

            registerOffset += RecipeSize
            DevicePIDSettingsArrayStartOffset = registerOffset

            registerOffset += If(currentDeviceConfig.NeedsPID, 10, 0)
            DeviceThermocoupleArrayStartOffset = registerOffset

            registerOffset += numberOfThermocouples
            DeviceStatusOffset = registerOffset

            ModbusControllerRegisterBlockSize = registerOffset + 1 'add one for the 'status' item

        Catch ex As Exception
            MsgBox("Error while loading cure device settings for " + Name + ".")
            Dim StrAlarm() As String = {DateTime.Now.ToString,
                Name, "Error while loading cure device settings.",
                "Ensure the " + Name + "cure device Cure Station File (.csf) exists and is in the correct format."}
            Throw New System.Exception()
        End Try

    End Sub 'Loads Csf File and initializes PID/Communication Settings

    Private Sub InitializeListOfAllDeviceTCs(numberOfThermocouples As UShort)
        Dim _list As New List(Of Thermocouple)
        For i = 0 To numberOfThermocouples - 1
            _list.Add(New Thermocouple With {
                .Id = (i + 1),
                .Temperature = Single.NaN,
                .OnOff = False})
        Next
        ListOfAllDeviceTCs = _list
    End Sub

    Public Sub BeginTemperatureLoggingToFiles()
        TemperatureLogPath = $"{FrmMain.cureLogBaseDirectory}\{Name}"
        Try
            If Not Directory.Exists(TemperatureLogPath) Then
                Directory.CreateDirectory(TemperatureLogPath)
            End If
        Catch e As Exception
            MsgBox("Temperature log directory not found and couldn't be created.")
        End Try
        If Parts.Count > 0 Then
            Dim _parts(Parts.Count - 1, 1) As String
            For i = 0 To Parts.Count - 1
                _parts(i, 0) = Parts(i).PartNumber
                _parts(i, 1) = Parts(i).JobNumber
            Next
            Call New CureDeviceBookmark().Create(Name, _parts)
        Else
            MsgBox("There are no parts in this cure device to create bookmark files.")
        End If

    End Sub

    Public Sub StartPreheat()
        If Not DeviceType = "Oven" Then
            Call SendPidSettings() 'send the first part in the list. There should always be one or preheat will error out.
        End If
        Call ChangeControllerSetpoint(PreheatNominal)
        Status = "Preheat in Progress"
        Call UpdateHomeRow()
    End Sub 'Starts Preheat of Part

    Public Sub StopPreheat()
        Call ChangeControllerSetpoint(ROOM_TEMP) 'hardcoded room temperature value
        Me.Status = "Awaiting start."
        Call UpdateHomeRow()
    End Sub 'Starts Preheat of Part

    Public Sub SendPidSettings()
        Try
            Dim RegData(9) As UShort 'Data to be sent
            RegData(0) = CureDevicePidSettings.PropBand1
            RegData(1) = CureDevicePidSettings.Reset1
            RegData(2) = CureDevicePidSettings.Deriv1
            RegData(3) = CureDevicePidSettings.Hysteresis1
            RegData(4) = CureDevicePidSettings.DeadBand1
            RegData(5) = CureDevicePidSettings.PropBand2
            RegData(6) = CureDevicePidSettings.Reset2
            RegData(7) = CureDevicePidSettings.Deriv2
            RegData(8) = CureDevicePidSettings.Hysteresis2
            RegData(9) = CureDevicePidSettings.DeadBand2
            FrmMain.SMTN1.ConnectToServer(True)
            Dim SMTNStatus As SMTN.SMTNControl.MB_STATUS
            Dim PidSettingsRegisterAddress As UShort = DeviceTemperatureRegisterAddress + DevicePIDSettingsArrayStartOffset - 1
            SMTNStatus = FrmMain.SMTN1.MbPresetMultipleRegs(1, PidSettingsRegisterAddress, RegData.Length, RegData) 'double-check this offset & come up with a more robust solution
            If Not SMTNStatus = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
                MsgBox("Error while sending PID settings. " + SMTNStatus.ToString)
                Dim StrAlarm() As String = {DateTime.Now.ToString,
                Me.Name, "Error while sending PID settings.",
                "Ensure the " + Me.Name + "cure device cure device is mapped to the correct registers within the Red Lion Data Station."}
                FrmMain.DGVAlarm.Rows.Add(StrAlarm)
                FrmMain.TmrAlarm.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub 'Send PID Settings, Red Lion Unit does all of the decimal processing

    Public Sub SendCureCycle()
        Dim RegisterData As New List(Of UShort)

        If Not DeviceType = "Oven" Then
            Call SendPidSettings()
        End If
        RegisterData.Add(_cureCycle.Segments.Count)
        RegisterData.Add(0) 'sets the CurrentSegment register to zero
        RegisterData.AddRange(_cureCycle.GetRecipeArray)

        Try
            FrmMain.SMTN1.ConnectToServer(True)
            Dim SMTNStatus As SMTN.SMTNControl.MB_STATUS
            SMTNStatus = FrmMain.SMTN1.MbPresetMultipleRegs(1, DeviceTemperatureRegisterAddress + 2, RegisterData.Count, RegisterData.ToArray())
            If SMTNStatus = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
                'MsgBox("No Error")
            Else
                Dim StrAlarm() As String = {DateTime.Now.ToString,
                Me.Name, " Error while sending cure information.",
                " Ensure the " + Me.Name + " cure device has blinking red and green lights on the wireless transceiver. If not, replace the transceiver."}
                FrmMain.DGVAlarm.Rows.Add(StrAlarm)
                FrmMain.TmrAlarm.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub 'Send Cure Cycle Data to Controller

    Public Sub TemperatureLoggingOn()
        Status = "Logging"
        TmrTemperatureLogging.Enabled = True
        IsLoggingTemperature = True
        Call BeginTemperatureLoggingToFiles()
    End Sub

    Public Sub TemperatureLoggingOff()
        TmrTemperatureLogging.Enabled = False
        IsLoggingTemperature = False
        Status = "Awaiting Start"
        Try
            Call New CureDeviceBookmark().MarkEndOfCure(Name)
            Call GenerateDeviceCureLog(Name)
            Call AssignCureLogToParts()

            Dim partCureLogs As New List(Of PartCureLog)
            For Each _part In Parts
                partCureLogs.Add(_part.CureLog)
            Next

            If GenerateExcelCurelogs(partCureLogs) Then
                Call DeleteBookmark()
            End If

            Call DeleteDeviceCureLog()
        Catch ex As Exception
            MsgBox($"Please allow more time before trying to generate a cure log.")
        End Try
    End Sub

    Private Sub AssignCureLogToParts()
        For Each _part In Parts
            AssignCureLogToPart(_part)
        Next
    End Sub

    Private Sub AssignCureLogToPart(_part As Part)
        _part.CureLog = PartCureLog.ReadPartCureLogFromFile($"{_part.PartNumber}_{_part.JobNumber}.log", $"{FrmMain.cureLogBaseDirectory}\{_part.CureDeviceName}\")
    End Sub

    Private Sub DeleteBookmark()
        If File.Exists($"{TemperatureLogPath}\{Name}.xml") Then
            Try
                File.Delete($"{TemperatureLogPath}\{Name}.xml")
            Catch ex As Exception
                MsgBox($"Error deleting {Name}.xml bookmark.{Environment.NewLine}{ex.Message}")
            End Try
        End If

    End Sub

    Private Sub DeleteDeviceCureLog()

        If File.Exists($"{TemperatureLogPath}\{Name}.log") Then
            Try
                File.Delete($"{TemperatureLogPath}\{Name}.log")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ClearRecipeFromModbusGateway()
        Dim RegData(RecipeSize + 3 - 1) As UShort 'an array of zeros sized to blank out the recipe registers on the modbus gateway
        FrmMain.SMTN1.ConnectToServer(True)
        Dim SMTNStatus As SMTN.SMTNControl.MB_STATUS
        SMTNStatus = FrmMain.SMTN1.MbPresetMultipleRegs(1, DeviceTemperatureRegisterAddress + 1, RegData.Length, RegData)
        FrmMain.SMTN1.ConnectToServer(False)
    End Sub

    Friend Sub StartCure()
        Call SendCureCycle()
        FrmMain.SMTN1.ConnectToServer(True)
        Dim SMTNStatus As SMTN.SMTNControl.MB_STATUS
        SMTNStatus = FrmMain.SMTN1.MbPresetSingleReg(1, DeviceTemperatureRegisterAddress + 1, 2)
        FrmMain.SMTN1.ConnectToServer(False)
        IsLoggingTemperature = True
        TmrTemperatureLogging.Enabled = True
        Status = "Cure in Progress"
        Call ResetTemperatureLogTime()
        Call BeginTemperatureLoggingToFiles()
        Call UpdateHomeRow()
    End Sub

    Friend Sub EndCure()
        Call ClearRecipeFromModbusGateway()
        Call TemperatureLoggingOff()
        Status = "Cure Completed"
        Call UpdateHomeRow()
    End Sub

    Public Sub ResetTemperatureLogTime()
        TemperatureLogTime = 0
    End Sub

    Public Sub UpdateSetpointChart()
        If Not DeviceSetpoint.Equals(Single.NaN) Then
            Me.TabControl.TxtSetpoint.Text = DeviceSetpoint
            Me.TabControl.TemperatureLogChart.Series(1).Points.AddXY(TemperatureLogTime, DeviceSetpoint)
            Me.TabControl.TemperatureLogChart.Series(1).LegendText = $"Setpoint: {DeviceSetpoint}"
            Call UpdateChartSettings()
        End If
    End Sub 'Updates Station Setpoint controls

    Public Sub UpdateTemperatureChart()
        If Temperature <> Single.NaN Then
            Me.TabControl.TxtPartTemp.Text = Temperature.ToString
            Me.TabControl.TxtControllerStatus.Text = GetStatusTextFromNumber(controllerNumericStatus)
            Me.TabControl.TemperatureLogChart.Series(0).Points.AddXY(TemperatureLogTime, Temperature)
            Me.TabControl.TemperatureLogChart.Series(0).LegendText = $"Temp: {Temperature}"
            'If Me.DeviceType = "Oven" Then
            Dim counter = 0
                For Each _tc As Thermocouple In ListOfAllDeviceTCs
                    If _tc.OnOff = True Then
                        Me.TabControl.TemperatureLogChart.Series(counter + 2).LegendText = $"TC{_tc.Id}: {_tc.Temperature}"
                        Me.TabControl.TemperatureLogChart.Series(counter + 2).Points.AddXY(TemperatureLogTime, _tc.Temperature)
                    Else
                        Me.TabControl.TemperatureLogChart.Series(counter + 2).LegendText = $"TC{(counter + 1)}:"
                    End If
                    counter += 1
                Next
            End If
            Call UpdateChartSettings()
        'Else
        '    Me.TabControl.TxtPartTemp.Text = "Err"
        '    Dim StrAlarm() As String = {DateTime.Now.ToString, Me.Name, " Error while updating temperature.",
        '        " Ensure the " + Me.Name + " cure device has blinking red and green lights on the wireless transceiver. If not, replace the transceiver."}
        '    FrmMain.DGVAlarm.Rows.Add(StrAlarm)
        '    FrmMain.TmrAlarm.Enabled = True
        '    'Call Error Log
        'End If

    End Sub 'Update Station Temperature Controls

    Private Function GetStatusTextFromNumber(controllerStatus As UShort) As String
        Dim statusString As String = ""
        Select Case controllerStatus
            Case Nothing
                statusString = $"Unassigned condition"
            Case 0
                statusString = $"Controller Starting Up"
            Case 1
                statusString = $"No Program Running"
            Case 2
                statusString = $"Ramping"
            Case 3
                statusString = $"Condition Normal"
            Case 4
                statusString = $"Adjusting Setpoint Higher"
            Case 5
                statusString = $"Adjusting Setpoint Lower"
            Case 6
                statusString = $"High Part Temp Warning"
            Case 7
                statusString = $"Low Part Temp Warning"
            Case 8
                statusString = $"Waiting for Low Thermocouple"
            Case 9
                statusString = $"Unassigned condition" ' <-- add additional conditions here
            Case 10
                statusString = $"Unassigned condition" ' <-- add additional conditions here
        End Select
        Return statusString
    End Function

    Public Sub UpdateChartSettings()
        Me.TabControl.TemperatureLogChart.ChartAreas(0).AxisX.Maximum = Round(TemperatureLogTime + 1)
        Me.TabControl.TemperatureLogChart.ChartAreas(0).AxisX.Interval = Me.TabControl.TemperatureLogChart.ChartAreas(0).AxisX.Maximum / 10
    End Sub 'Updates Temperature Chart Max

    Public Sub GenerateDeviceCureLog(deviceName As String)
        Dim logBuilder As New CureLogBuilder(deviceName)
        logBuilder.CreatePartCureLogs(Parts)
    End Sub

    'Public Function GenerateExcelCureLogs(partLog As PartCureLog) As Boolean
    '    File.Create($"{TemperatureLogPath}\{Name}\{partLog.PartNumber}_{partLog.JobNumber}.xlsx")
    '    MsgBox($"Excel log created.")
    '    Return True
    'End Function

    Public Function GenerateExcelCurelogs(_partCureLogs As List(Of PartCureLog)) As Boolean
        Dim success As Boolean = False
        'Get List of all existing Excel Process IDs
        Dim lstOldProcessID As New System.Collections.Generic.Dictionary(Of Integer, Process)
        Dim localAll As Process()
        localAll = Process.GetProcesses
        For i As Integer = 0 To localAll.Length - 1
            If localAll(i).ProcessName.ToUpper = "EXCEL" Then
                lstOldProcessID.Add(localAll(i).Id, localAll(i))
            End If
        Next

        'Initialize Excel Application 
        Try
            Dim app As New Excel.Application
            'Identifies new Excel Process ID
            Dim newProcess As Process = Nothing
            localAll = Process.GetProcesses()
            For i As Integer = 0 To localAll.Length - 1
                If localAll(i).ProcessName.ToUpper = "EXCEL" AndAlso Not lstOldProcessID.ContainsKey(localAll(i).Id) Then
                    newProcess = localAll(i)
                    Exit For
                End If
            Next
            For Each _partCureLog As PartCureLog In _partCureLogs
                success = GenerateExcelCureLog(app, _partCureLog)
            Next

            app.Quit()
            newProcess.Kill() 'Kills Excel Process

        Catch ex As Exception
            MsgBox($"Can't start Microsoft Excel. It may not be installed on this computer.")
            success = False
        End Try

        Return success
    End Function
    Public Function GenerateExcelCureLog(app As Excel.Application, _partCureLog As PartCureLog) As Boolean
        Dim success As Boolean = False

        'loop over the list of parts for this cure device and generate a log for each
        Dim workbook As Excel.Workbook
        Dim logDataworksheet As Excel.Worksheet
        Dim logTitlepage As Excel.Worksheet
        Try
            Dim StrReportFile As String = $"{FrmMain.baseDirectory}\FDI Cure Log Template-Unified.xltx"
            workbook = app.Workbooks.Open(StrReportFile)
            logDataworksheet = DirectCast(workbook.Worksheets("LogData"), Excel.Worksheet)
            logTitlepage = DirectCast(workbook.Worksheets("LogTitlepage"), Excel.Worksheet)
            'Header information on the cure log
            logTitlepage.Range("B6").Value = _partCureLog.CureDeviceName 'the name of the cure device
            logTitlepage.Range("B7").Value = _partCureLog.PartNumber
            logTitlepage.Range("B8").Value = _partCureLog.PartDescription
            logTitlepage.Range("B9").Value = _partCureLog.JobNumber
            logTitlepage.Range("B10").Value = _partCureLog.SerialNumber

            Dim counter = 11
            For Each _cureSegment In CureCycle.GetCureCycleAsText(_partCureLog.PartRecipe)
                logTitlepage.Range($"B{counter}").Value = _cureSegment
                counter += 1
            Next

            logTitlepage.Range("E6:E7").NumberFormat = "mm/dd/yyyy hh:mm"
            logTitlepage.Range("E6").Value = _partCureLog.Records.First.Date
            logTitlepage.Range("E7").Value = _partCureLog.Records.Last.Date
            Dim _leftFooter As String = $"Part Number: {_partCureLog.PartNumber}{Chr(10)}Job Number: {_partCureLog.JobNumber}"

            logDataworksheet.PageSetup.LeftFooter = _leftFooter

            Dim _chart As ChartObject = logTitlepage.ChartObjects("TempChart")
            Dim _seriesCollection = _chart.Chart.SeriesCollection()
            _chart.Chart.ChartType = XlChartType.xlXYScatterLinesNoMarkers
            _chart.Chart.HasLegend = True
            Dim itemsInLegend As Integer = _partCureLog.AssignedThermocouples.Count + 2
            _chart.Chart.Legend.Height = 22 * itemsInLegend
            _chart.Chart.Legend.Width = 100
            _chart.Chart.Axes()

            Dim dataStartingRow As Integer = 3 ' the row where data starts printing on the data worksheet
            Dim timeXlrng, tempXlrng, setpointXlrng As String
            Dim columns As UShort = 3 + _partCureLog.AssignedThermocouples.Count
            Dim rows As UShort = _partCureLog.Records.Count
            Dim dataArray(rows - 1, columns - 1) As Object

            Dim _rowNumber = 0
            For Each _record In _partCureLog.Records
                dataArray(_rowNumber, 0) = _record.Date
                dataArray(_rowNumber, 1) = If(Single.IsNaN(_record.Temperature), "#N/A", _record.Temperature)
                dataArray(_rowNumber, 2) = If(Single.IsNaN(_record.Setpoint), "#N/A", _record.Setpoint)

                Dim tcCounter = 0
                For i = 0 To _partCureLog.AssignedThermocouples.Count - 1
                    dataArray(_rowNumber, 2 + 1 + i) = If(Single.IsNaN(_record.Thermocouples(tcCounter)), "#N/A", _record.Thermocouples(tcCounter))
                    tcCounter += 1
                Next
                _rowNumber += 1
            Next

            timeXlrng = $"'{logDataworksheet.Name}'!A{dataStartingRow}:A{dataStartingRow + rows - 1}"
            tempXlrng = $"'{logDataworksheet.Name}'!B{dataStartingRow}:B{dataStartingRow + rows - 1}"
            setpointXlrng = $"'{logDataworksheet.Name}'!C{dataStartingRow}:C{dataStartingRow + rows - 1}"

            Dim startingColumn As Char = "A"c
            Dim endingColumn As Char = ChrW(Asc(startingColumn) + columns - 1)
            Dim endingRow As Integer = dataStartingRow + rows - 1
            Dim dataXlrng As Excel.Range = logDataworksheet.Range($"{startingColumn}{dataStartingRow}:{endingColumn}{endingRow}")
            dataXlrng.Value = dataArray

            Dim columnLetter = "D"c
            Dim columnCounter = 0
            For Each tcId In _partCureLog.AssignedThermocouples
                logDataworksheet.Range($"{columnLetter}{dataStartingRow - 1}").Value = $"TC{tcId}{Chr(10)}(°F)" 'column heading for thermocouples
                Dim _chartSeries = _seriesCollection.newseries()
                _chartSeries.name = $"TC{tcId}"
                _chartSeries.xvalues = timeXlrng
                _chartSeries.values = $"'{logDataworksheet.Name}'!{columnLetter}{dataStartingRow}:{columnLetter}{endingRow}"
                columnLetter = ChrW(Asc(columnLetter) + 1).ToString
            Next

            Dim tempSeries As Series = _seriesCollection.newseries()
            tempSeries.Name = "Device Temp"
            tempSeries.XValues = timeXlrng
            tempSeries.Values = tempXlrng

            Dim setpointSeries As Series = _seriesCollection.newseries()
            setpointSeries.Name = "Setpoint"
            setpointSeries.XValues = timeXlrng
            setpointSeries.Values = setpointXlrng

            ' apply the appropriate cell format to the cells
            Dim formattingRange As Excel.Range
            formattingRange = logDataworksheet.Range($"A{dataStartingRow}:A{dataStartingRow + rows - 1}")
            formattingRange.NumberFormat = "hh:mm"
            formattingRange = logDataworksheet.Range($"B{dataStartingRow}:{columnLetter}{dataStartingRow + rows - 1}")
            formattingRange.NumberFormat = "##0.0"

            Dim StrXLFile As String = $"{FrmMain.cureLogBaseDirectory}\{_partCureLog.CureDeviceName}\{_partCureLog.PartNumber}_{_partCureLog.JobNumber}"
            app.DisplayAlerts = False
            workbook.SaveAs(StrXLFile)

            workbook.Close()
            If File.Exists($"{StrXLFile}.xlsx") Then
                success = True
                MsgBox($"Cure log {_partCureLog.PartNumber}_{_partCureLog.JobNumber}.xlsx generated.")
            End If

        Catch ex As Exception
            MsgBox($"An error ocurred while creating the Excel cure log{vbCrLf}{ex.Message}")
        End Try

        Return success
    End Function       'Generates Cure Log XL File

    Friend Sub WriteProtectLogs()
        For Each _part In Parts
            _part.MakeLogFileReadonly()
        Next
    End Sub

    Private Sub WriteProtectLog(fileName As String)
        Dim fileDetail As IO.FileInfo = My.Computer.FileSystem.GetFileInfo($"{FrmMain.cureLogBaseDirectory}\{Name}\{fileName}")
        fileDetail.IsReadOnly = True
    End Sub

    Private Sub ConvertXlsxReportToPdf(ByVal strxlfile, ByVal strpdffile)
        ' Declare variables to hold references to the Excel ApplicationClass
        ' and Workbook objects.          
        Dim excelApplication As Workbook = Nothing
        Dim excelWorkbook As Workbook = Nothing

        ' Declare a variable for the path to the workbook to convert.
        Dim paramSourceBookPath As String = strxlfile

        ' Declare variables for the Document.ExportAsFixedFormat method parameters.
        Dim paramExportFilePath As String = strpdffile
        Dim paramExportFormat As XlFixedFormatType = XlFixedFormatType.xlTypePDF
        Dim paramExportQuality As XlFixedFormatQuality = XlFixedFormatQuality.xlQualityStandard
        Dim paramOpenAfterPublish As Boolean = True
        Dim paramIncludeDocProps As Boolean = True
        Dim paramIgnorePrintAreas As Boolean = True

        Try
            ' Create an instance of Excel.
            excelApplication = New Workbook()

            ' Open the source workbook.
            excelWorkbook = excelApplication.Workbooks.Open(paramSourceBookPath)

            ' Save it in the target format.
            If excelWorkbook IsNot Nothing Then
                excelWorkbook.ExportAsFixedFormat(paramExportFormat, paramExportFilePath, paramExportQuality,
                    paramIncludeDocProps, paramIgnorePrintAreas, , , paramOpenAfterPublish)
            End If
        Catch ex As Exception
            ' Respond to the error
            MsgBox($"Error converting Excel log to PDF file.{vbCrLf}{ex.Message}")
        Finally
            ' Close the Workbook object.
            If excelWorkbook IsNot Nothing Then
                excelWorkbook.Close(False)
                excelWorkbook = Nothing
            End If

            ' Close the ApplicationClass object.
            If Not excelApplication Is Nothing Then
                excelApplication.Quit()
                excelApplication = Nothing
            End If

            'GC.Collect()
            'GC.WaitForPendingFinalizers()

        End Try

        'Copy file to server
        Try
            Dim StrBackupPath As String = FrmMain.BackupTempLogPath + "\" + Me.Name

            If Not Directory.Exists(StrBackupPath) Then
                Directory.CreateDirectory(StrBackupPath)
            End If
            Dim StrPDFName As String = FrmMain.SplitString(strpdffile, "\", 777)
            System.IO.File.Copy(strpdffile, (StrBackupPath + "\" + StrPDFName))
            Exit Sub
        Catch err As Exception
            MsgBox("Unable to write report to server. Report will be saved locally. Please notify Colin of this message.")
        End Try
    End Sub 'Convert XL File to PDF and Show

    Public Sub ChangeControllerSetpoint(Setpoint As Single)
        FrmMain.SMTN1.ConnectToServer(True)
        Dim SMTNStatus = FrmMain.SMTN1.MbPresetSingleReg(1, DeviceTemperatureRegisterAddress, Setpoint)
        If SMTNStatus = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
            Call UpdateSetpointChart()
        Else
            Dim StrAlarm() As String = {DateTime.Now.ToString,
            Name, "Error while starting cure.",
            "Ensure the " + Name + " cure device has blinking red and green lights on the wireless transceiver. If not, replace the transceiver."}
            FrmMain.DGVAlarm.Rows.Add(StrAlarm)
            FrmMain.TmrAlarm.Enabled = True
        End If
        FrmMain.SMTN1.ConnectToServer(False)
    End Sub 'Change Temperature Setpoint

    Private Sub CheckIfControllerFinishedCure()
        If (Status = "Cure in Progress") And (ControllerOnOff = 1) Then
            TabControl.BtnCure.PerformClick()
        End If
    End Sub

    Public Sub SampleParameters() ''''''' Change sample parameters for Getting Oven Params

        Dim ModbusStatus As SMTN.SMTNControl.MB_STATUS
        FrmMain.SMTN1.ConnectToServer(True)
        Dim timeout = FrmMain.SMTN1.ConnectTimeout()
        'If Me.DeviceType = "Oven" Then
        Dim RegOven(ModbusControllerRegisterBlockSize) As UShort
            ModbusStatus = FrmMain.SMTN1.MbReadHoldingRegs(1, DeviceTemperatureRegisterAddress - 1, RegOven.Length - 1, RegOven)
        If ModbusStatus = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
            Temperature = CheckThermocoupleBoundsAndConvert(RegOven(0))

            DeviceSetpoint = If(RegOven(1) = 0, Single.NaN, RegOven(1))
            ControllerOnOff = Integer.Parse(RegOven(2))

            For i = 0 To (ListOfAllDeviceTCs.Count - 1)
                ListOfAllDeviceTCs(i).Temperature = CheckThermocoupleBoundsAndConvert(RegOven(DeviceThermocoupleArrayStartOffset + i))
            Next
            controllerNumericStatus = RegOven(DeviceStatusOffset)

        Else
            Temperature = Single.NaN
            DeviceSetpoint = Single.NaN
            ControllerOnOff = Nothing
            For i = 0 To (ListOfAllDeviceTCs.Count - 1)
                ListOfAllDeviceTCs(i).Temperature = Single.NaN
            Next
            controllerNumericStatus = 0
            Dim StrAlarm() As String = {DateTime.Now.ToString,
            Me.Name, " Error while updating setpoint and temperature.",
            "Ensure the " + Me.Name + " cure device has blinking red and green lights on the wireless transceiver. If not, replace the transceiver."}
            FrmMain.DGVAlarm.Rows.Add(StrAlarm)
            FrmMain.TmrAlarm.Enabled = True
            'End If
            'Else
            'Dim RegData(3) As UShort  'Temp and Setpoint to be sampled
            'ModbusStatus = FrmMain.SMTN1.MbReadHoldingRegs(1, DeviceTemperatureRegisterAddress - 1, RegData.Length, RegData)
            'If ModbusStatus = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
            '    Me.Temperature = CheckThermocoupleBoundsAndConvert(RegData(0))
            '    Me.DeviceSetpoint = RegData(1)
            '    ControllerOnOff = Integer.Parse(RegData(2))
            'Else
            '    Temperature = Single.NaN
            '    DeviceSetpoint = Single.NaN
            '    ControllerOnOff = Nothing
            '    Dim StrAlarm() As String = {DateTime.Now.ToString,
            '    Me.Name, " Error while sending cure information.",
            '    " Ensure the " + Me.Name + " cure device has blinking red and green lights on the wireless transceiver. If not, replace the transceiver."}
            '    FrmMain.DGVAlarm.Rows.Add(StrAlarm)
            '    FrmMain.TmrAlarm.Enabled = True
            'End If
        End If

        Call UpdateTemperatureChart()
        Call UpdateSetpointChart()
        Call CheckIfControllerFinishedCure()
        Call UpdateHomeRow()

        TemperatureLogTime += TmrTempSampling.Interval / (60 * 1000)
    End Sub 'Samples all Parameters from the controller

    Private Shared Function Convert4DigitRegisterToTemperature(temperature As UShort) As Single
        Return Val(temperature) / 10.0
    End Function ' converts 4-digit register value to floating point value

    Private Shared Function ConvertTemperatureToRegisterTemp(value As Single) As String
        Return (10 * System.Math.Round(value, 1)).ToString()
    End Function ' converts a floating point temperature to an integer string multiplied by 10

    Private Function CheckThermocoupleBoundsAndConvert(value As UShort) As Single
        Dim Result As Single
        If value < MAX_TC_VALUE And value > 0 Then
            Result = Convert4DigitRegisterToTemperature(value)
        Else
            Result = Single.NaN
        End If
        Return Result
    End Function

    Public Function AddPart(PartNumber As String) As Part
        Dim NewPart = New Part(PartNumber, Name)
        Parts.Add(NewPart)
        If ListOfParts.Contains(PartNumber) Then
            NewPart.PopulatePartRecipe()
            Call SetCureDevicePreheatValue(NewPart)
            Call PointPidSettingsFromPartToDevice(NewPart)
            Call PointCureCycleFromPartToDevice(NewPart)
        End If
        Return NewPart
    End Function

    Private Sub SetCureDevicePreheatValue(_part As Part)
        If _part.PreheatTemperature.Nominal > PreheatNominal Then
            PreheatNominal = _part.PreheatTemperature.Nominal
        End If
    End Sub

    Private Sub SetCureDevicePreheatValue(preheatTemperature As UShort)
        PreheatNominal = preheatTemperature
    End Sub

    Public Sub RemovePart(PartToRemove As Part)
        For Each part In Parts.ToArray
            If part.GetHashCode = PartToRemove.GetHashCode Then
                RemoveThermocouplesFromDevice(part)
                part.ClearAllAssignedThermocouples()
                Parts.Remove(part)
            End If
        Next
    End Sub

    Public Sub RemoveThermocouplesFromDevice(PartToRemove As Part)
        For Each thermocouple In PartToRemove.AssignedThermocouples
            RemoveThermocoupleFromDevice(thermocouple)
        Next
    End Sub

    Public Sub RemoveThermocoupleFromDevice(_thermocouple As Thermocouple)
        _thermocouple.TurnOff()
    End Sub

    Public Sub AddThermocoupleToDevice(_thermocouple As Thermocouple)
        _thermocouple.TurnOn()
    End Sub

    Public Function TimesInUse(_tc As Thermocouple)
        Dim numberOfUses As Integer = 0
        For Each _part As Part In Parts
            For Each _thermocouple In _part.AssignedThermocouples
                If _tc.GetHashCode() = _thermocouple.GetHashCode() Then
                    numberOfUses += 1
                End If
            Next
        Next
        Return numberOfUses
    End Function

    Public Sub BuildListOfPartsForThisCureDevice()
        Dim LstPartNumbers As New List(Of String) 'List of potential parts with configured recipes
        ListOfParts.Clear()

        If Directory.Exists($"{FrmMain.baseDirectory}\Data\Part Recipes") Then
            Dim DirInfo As New IO.DirectoryInfo($"{FrmMain.baseDirectory}\Data\Part Recipes")
            Dim Dir1 As IO.FileInfo() = DirInfo.GetFiles()
            For Each D As IO.FileInfo In Dir1
                If D.ToString.Contains(".prf") Then
                    If D.ToString.Contains(Name) Then
                        Dim StrSplit As String = FrmMain.SplitString(D.ToString, "\", 777)
                        StrSplit = FrmMain.SplitString(StrSplit, "_", 0)
                        ListOfParts.Add(StrSplit)
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub BuildListOfAssignedThermocouples()
        For Each _part In Parts
            For Each _tc In _part.AssignedThermocouples
                _tc.OnOff = True
            Next
        Next
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function

    Private Sub PointPidSettingsFromPartToDevice(_part As Part)
        CureDevicePidSettings = _part.PidSettings
    End Sub

    Private Sub PointCureCycleFromPartToDevice(_part As Part)
        _cureCycle = _part.CureCycle
    End Sub
End Class


