Option Explicit On

Imports System.IO


Public Class FrmMain
    Public CureDevices As New List(Of CureDevice)
    Public PumpDevices As New List(Of PumpDevice)
    Public SMTN1 As New SMTN.SMTNControl("F97B245eE10B3dC2B6fD986Aff02CFE8") 'Modbus TCP/IP Control
    Public BoolSampling As Boolean = True 'Allows sampling of controller parameters

    Public baseDirectory As String = "S:\KEVIN\Dougs Automated Cure\AC-CONFIG" '"C:\Programs\FDI MPCS"
    Public cureLogBaseDirectory As String = $"{baseDirectory}\Data\Logs\Temperature"
    Public injectionLogBaseDirectory As String = $"{baseDirectory}\Data\Logs\Injections"
    Public BackupTempLogPath As String 'Path to Server location where temp logs are backed up
    Public BackupInjectionLogPath As String 'Path to Server location where injection logs are backed up
    Public TmrAlarm As Timer 'Timer for Alarm Light
    Public DataStationIpAddress As String

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        SMTN1.ConnectTimeout = 2000 'sets the allowable delay in milliseconds for connection to modbus device
        SMTN1.RcvTimeout = 2000 'sets the allowable delay in milliseconds for receiving data from modbus device
        Dim AlarmTimer As New Timer
        Me.TmrAlarm = AlarmTimer
        Me.TmrAlarm.Interval = 1000
        AddHandler TmrAlarm.Tick, AddressOf AlarmSwitch
        Try
            Call LoadDataStation()
            Call LoadIniFile()
            Call LoadPumpIniFile()
            Call LoadBackupTempLogPath()
        Catch ex As Exception
            MsgBox($"Problem starting up.{Environment.NewLine}{ex.Message}")
        End Try
        'Call StartWebsync()
        'Call UpdateIndex() 'Calls Update Indexes of all Cure Devices so Selected Index will work
        'Call UpdatePumps() 'Updates Pump CboBox List
        'Call CreateCureDevicePage("Oven A")
    End Sub 'Form Load

    Private Sub FrmMain_Closing()
        Call Close()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub 'Form Closing

    Private Sub AlarmSwitch()
        If Me.TabAlarm.ImageIndex = 2 Then
            Me.TabAlarm.ImageIndex = 3
        Else
            Me.TabAlarm.ImageIndex = 2
        End If
    End Sub 'Alarm Switch Light

    Private Sub LoadBackupTempLogPath()
        Dim textin As New StreamReader(New FileStream($"{baseDirectory}\BackupDirectory.txt", FileMode.Open, FileAccess.Read))
        BackupTempLogPath = textin.ReadLine
        BackupInjectionLogPath = textin.ReadLine
    End Sub 'Loads the Default Log Server Backup Locations from BackupDirectory text File

    Private Sub LoadDataStation()
        Try
            Dim textin As New StreamReader(New FileStream($"{baseDirectory}\DataStationConfig.txt", FileMode.Open, FileAccess.Read))
            DataStationIpAddress = textin.ReadLine
            SMTN1.ServerIPAddress = DataStationIpAddress
            textin.Close()
            SMTN1.ListenPort = 502
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub 'Loads IP Address to SMTN1 Var

    Private Sub LoadIniFile()
        Dim ListOfDevices As New List(Of String)
        For Each _device In CureDevices
            ListOfDevices.Add(_device.Name)
        Next
        Try
            Dim textin As New StreamReader(New FileStream($"{baseDirectory}\IniFile.txt", FileMode.Open, FileAccess.Read))
            Do While Not textin.EndOfStream
                Dim StrStation As String = textin.ReadLine
                If StrStation.Length > 0 Then
                    If Not ListOfDevices.Contains(StrStation) Then
                        CureDevices.Add(New CureDevice(StrStation, False))
                        'DGVAlarm.Rows.Add()
                        'TmrAlarm.Enabled = True
                    End If
                End If
            Loop
            textin.Close()
        Catch ex As Exception
            MsgBox($"Error while Loading Stations.{Environment.NewLine}{ex.Message}")

        End Try
    End Sub 'Loads Default Stations from IniFile

    Private Sub LoadPumpIniFile()
        Dim ListOfDevices As New List(Of String)
        For Each _device In PumpDevices
            ListOfDevices.Add(_device.Name)
        Next
        Try
            Dim textin As New StreamReader(New FileStream($"{baseDirectory}\PumpIniFile.txt", FileMode.Open, FileAccess.Read))
            Do While Not textin.EndOfStream
                Dim StrPump As String = textin.ReadLine
                If StrPump.Length > 0 Then
                    If Not ListOfDevices.Contains(StrPump) Then
                        PumpDevices.Add(New PumpDevice(StrPump))
                    End If
                End If
            Loop
            textin.Close()
        Catch ex As Exception
        End Try
    End Sub 'Loads Default Stations from IniFile

    Private Sub StartWebsync()
        Dim StrDataStationAddress As String = SMTN1.ServerIPAddress.ToString
        Dim ID As Integer = Shell("C:\Programs\FDI MPCS\websync.exe -path C:\Programs\FDI_MPCS_Data_Station_Backup -poll 5 " + StrDataStationAddress, AppWinStyle.Hide, False)
    End Sub 'Starts the sync of Data Station Backup Logs to Local PC

    Public Sub CreateIniFile()
        Try
            If Not Directory.Exists(baseDirectory) Then
                Directory.CreateDirectory(baseDirectory)
            End If

            Dim textout As New StreamWriter(New FileStream($"{baseDirectory}\IniFile.txt", FileMode.Create, FileAccess.Write))
            For Each CD As CureDevice In CureDevices
                textout.WriteLine(CD.Name)
            Next
            textout.Close()
        Catch ex As Exception
            MsgBox("Error while writing IniFile. " + ex.Message)
        End Try
    End Sub 'Creates Initialization File    

    Private Sub DGV1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV1.Resize
        Dim IntWidth As Integer = 0
        For i = 0 To DGV1.Columns.Count - 2
            IntWidth += DGV1.Columns(i).Width
        Next
        ClmPartsList.Width = DGV1.Width - IntWidth - 43
    End Sub 'Cure Stations Resize

    Private Sub DGV2_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV2.Resize
        Dim IntWidth As Integer = 0
        For i = 0 To DGV2.Columns.Count - 2
            IntWidth += DGV2.Columns(i).Width
        Next
        DGV2.Columns(DGV2.Columns.Count - 1).Width = DGV2.Width - IntWidth - 43
    End Sub 'Ovens Resize

    Private Sub DGV3_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV3.Resize
        Dim IntWidth As Integer = 0
        For i = 0 To DGV3.Columns.Count - 2
            IntWidth += DGV3.Columns(i).Width
        Next
        DGV3.Columns(DGV3.Columns.Count - 1).Width = DGV3.Width - IntWidth - 43
    End Sub 'RTM Pumps Resize

    Public Function GetPumpDeviceObject(ByVal StrName As String) As Integer
        For i As Integer = 0 To PumpDevices.Count - 1
            If PumpDevices(i).Name = StrName Then
                Return i
            End If
        Next
        Return 999
    End Function 'Returns Index of PumpDevice Object with supplied name

    Public Function CheckIntegerValue(ByVal StrString As String()) As Boolean
        Dim BoolCheck As Boolean = False
        For Each s As String In StrString
            If IsNumeric(s) = True Then
                If Int(s) = Val(s) Then
                    BoolCheck = True
                End If
            End If
            If BoolCheck = False Then
                Return False
            End If
        Next
        Return True
    End Function 'Checks if entry is Integer Returns True if Integer

    Public Function CheckInvalidString(StrString As String) As Boolean
        Dim isInvalid As Boolean = True
        If Not StrString = "" Then
            If Not StrString.Contains("\") Then
                If Not StrString.Contains(".") Then
                    If Not StrString.Contains("/") Then
                        If Not StrString.Contains("?") Then
                            If Not StrString.Contains(":") Then
                                isInvalid = False
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return isInvalid
    End Function 'Checks for Valid string without \ ? etc...

    Private Sub SaveConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim StrPassword As String = InputBox("Rights restricted. Enter the Administrator password.")
        If StrPassword = "fibereng" Then
            Call CreateIniFile()
        Else
            MsgBox("Incorrect Password. Try Again.")
        End If

    End Sub

    Private Sub UpdatePartsListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim StrPassword As String = InputBox("Rights restricted. Enter the Administrator password.")
        If StrPassword = "fibereng" Then
            For Each c As CureDevice In Me.CureDevices
                c.TabControl.UpdatePartNumberComboList()
            Next
        Else
            MsgBox("Incorrect Password. Try Again.")
        End If
    End Sub 'Update Part Numbers List

    Private Sub ViewAvailableAutomatedCuresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAvailableAutomatedCuresToolStripMenuItem.Click
        Dim ConfigureForm As New FrmConfiguredPartNumbers
        For Each c As CureDevice In CureDevices
            ConfigureForm.LstCureDeviceNames.Add(c.Name)
        Next
        ConfigureForm.Show()
    End Sub 'View Configured Part Numbers

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAlarm.Click
        Me.TmrAlarm.Enabled = False
        Me.TabAlarm.ImageIndex = 4
    End Sub 'Alarm Clear Button

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintDocument1.Print()
    End Sub 'Alarm Print Button

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DGVAlarm.Width, Me.DGVAlarm.Height)
        DGVAlarm.DrawToBitmap(bm, New System.Drawing.Rectangle(0, 0, Me.DGVAlarm.Width, Me.DGVAlarm.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub 'Print Document Writing

    Private Sub BtnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearList.Click
        DGVAlarm.Rows.Clear()
    End Sub 'Clear Alarm List

    Private Sub ViewBackupLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewBackupLogsToolStripMenuItem.Click
        If Directory.Exists(BackupTempLogPath) Then
            Process.Start("explorer.exe", BackupTempLogPath)
        End If
    End Sub

    Private Sub CreateLogFromBackupLogFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateLogFromBackupLogFileToolStripMenuItem.Click
        Dim FrmBackupReport As New FrmPumpBackupReporting
        FrmBackupReport.Show()
    End Sub

    Private Sub SetupPartNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupPartNumberToolStripMenuItem.Click
        Dim StrPassword As String = InputBox("Rights restricted. Enter the Administrator password.")
        If StrPassword = "fibereng" Then
            Dim FrmNewPartRecipe As New FrmPartRecipeSetup
            FrmNewPartRecipe.Show()
        Else
            MsgBox("Incorrect Password. Try Again.")
        End If

    End Sub

    Private Sub CureDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CureDeviceToolStripMenuItem.Click
        Dim StrPassword As String = InputBox("Rights restricted. Enter the Administrator password.")
        If StrPassword = "fibereng" Then
            Dim FrmNewStationSetup As New FrmCureDeviceSetup
            FrmNewStationSetup.Show()
        Else
            MsgBox("Incorrect Password. Try Again.")
        End If
    End Sub

    Private Sub PumpDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PumpDeviceToolStripMenuItem.Click
        Dim StrPassword As String = InputBox("Rights restricted. Enter the Administrator password.")
        If StrPassword = "fibereng" Then
            Dim FrmPump As New FrmPumpDeviceSetup
            FrmPump.Show()
        Else
            MsgBox("Incorrect Password. Try Again.")
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Call FrmMain_Closing()
    End Sub 'Exit Menu Item

    Private Sub ViewUserManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewUserManualToolStripMenuItem.Click
        If File.Exists($"{baseDirectory}\Data\Help\Automated Cure User Manual-User.pdf") Then
            System.Diagnostics.Process.Start($"{baseDirectory}\Data\Help\Automated Cure User Manual-User.pdf")
        Else
            MsgBox("Could not find User Manual. Ensure the 'Automated Cure User Manual-User exists.pdf'")
        End If
    End Sub 'User Manual Open

    Private Sub ViewAdministratorManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAdministratorManualToolStripMenuItem.Click
        Dim StrPassword As String = InputBox("Rights restricted. Enter the Administrator password.")
        If StrPassword = "fibereng" Then
            If File.Exists($"{baseDirectory}\Data\Help\Automated Cure User Manual-Admin.pdf") Then
                System.Diagnostics.Process.Start($"{baseDirectory}\Data\Help\Automated Cure User Manual-Admin.pdf")
            Else
                MsgBox("Could not find User Manual. Ensure the 'Automated Cure User Manual-Admin exists.pdf'")
            End If
        Else
            MsgBox("Incorrect password. Try again.")
        End If
    End Sub  'Administrator Manual
    '
    Public Function SplitString(StrString As String, StrSeperator As String, IntIndex As Integer) As String
        Dim StrReturn() As String = Split(StrString, StrSeperator)
        If IntIndex = 777 Then
            Return StrReturn(StrReturn.Count - 1)
        End If
        Return StrReturn(IntIndex)
    End Function 'Returns String given string to split,seperator,and index to return

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub RefreshDevicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshDevicesToolStripMenuItem.Click
        Call LoadIniFile()
        Call LoadPumpIniFile()
    End Sub

    Private Sub AboutAutomatedCureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutAutomatedCureToolStripMenuItem.Click
        Dim _aboutBox = New AboutBox()
        _aboutBox.Show()
    End Sub
End Class
