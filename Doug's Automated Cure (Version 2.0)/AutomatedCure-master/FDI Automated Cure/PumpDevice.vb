Option Explicit On
Imports System.IO
Imports System.Math
Imports Microsoft.Office.Interop

Public Class PumpDevice
    Public intruntime As Integer = 0 'Log Datalog time
    Public strreportfile As String
    Public intwriterow As Integer = 31 'row to start data entry
    Public strlogfile As String 'Log File to write during runntime
    Public strbackupdirectoryfile As String
    Public strbackupdirectory As String = "" 'Backup directory (place to send reports)
    Public pumptype As String
    Public intfirstaddress As Integer
    Public Name As String 'Name of Pump
    Public Tab As TabPage 'TabPage for Pump device
    Public TabControl As ControlPumpDevice 'User Controls in Tab Page
    Public HomeRow As DataGridViewRow 'Home DGV Row
    Public Status As String 'Status
    Public LogStatus As String 'Log Status
    Public Timer1 As Timer 'Timer for Pump Data Sampling
    Public Pressure As String 'Pump Pressure
    Public FlowRate As String 'Pump Flow Rate
    Public TimerLight As Timer 'Logging Light
    Public IPAddress As String 'IP Address of Pump if the pump is of type Mahr Pump
    Private ReadOnly TRANSDUCER_DISCONNECTED_VALUE As UShort = 65000 'the value read from the Red Lion when a transducer is damaged or disconnected

    Public Sub New(ByVal Name As String)
        Me.Name = Name
        Dim BoolLoad As Boolean = Me.ReadPsf($"{FrmMain.baseDirectory}\Data\Pump Devices\{Name}.PSF")
        If BoolLoad = True Then
            MsgBox("Error while loading cure device settings for " + Me.Name + ".")
        End If
        Me.Tab = New TabPage
        Me.Tab.Text = Me.Name
        Me.TabControl = New ControlPumpDevice
        Me.TabControl.PumpDeviceName = Me.Name
        Me.TabControl.PumpDeviceType = Me.pumptype
        Me.Tab.Controls.Add(Me.TabControl)
        Me.TabControl.LblName.Text = Name
        Me.TabControl.Size = FrmMain.TabControl1.Size
        FrmMain.TabControl1.TabPages.Add(Me.Tab)
        FrmMain.DGV3.Rows.Add(New DataGridViewRow)
        Me.HomeRow = FrmMain.DGV3.Rows(FrmMain.DGV3.Rows.Count - 1)
        AddHandler Me.HomeRow.Cells(0).DataGridView.MouseClick, AddressOf CellClick
        Dim Timer As New Timer
        Timer.Interval = 10000
        Me.Timer1 = Timer
        Me.Timer1.Enabled = False
        AddHandler Timer1.Tick, AddressOf Timer1Tick
        Me.Status = "Awaiting Start"
        Me.strbackupdirectory = FrmMain.BackupInjectionLogPath
        Dim TmrLight As New Timer
        TmrLight.Interval = 1000
        AddHandler TmrLight.Tick, AddressOf TmrLightTick
        Me.TimerLight = TmrLight
        'MsgBox(Me.Name + "," + Me.intfirstaddress.ToString)
        Call UpdateHomeRow()
    End Sub 'New PumpDevice

    Private Function ReadPsf(ByVal StrFile As String) As Boolean
        Try
            Dim textin As New StreamReader(New FileStream(StrFile, FileMode.Open, FileAccess.Read))
            textin.ReadLine() 'read pump name
            Me.pumptype = FrmMain.SplitString(textin.ReadLine, ":", 1)
            Me.intfirstaddress = Int(FrmMain.SplitString(textin.ReadLine, ":", 1))
            If Me.pumptype = "Mahr Pump" Then
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                Me.IPAddress = FrmMain.SplitString(textin.ReadLine, ":", 1)
            End If
            'MsgBox(Me.Name + "," + Me.pumptype + "," + Me.intfirstaddress.ToString)
            textin.Close()
            Return False
        Catch ex As Exception
            Return True
        End Try

    End Function 'Read PSF File, returns Ture if Error

    Public Sub Start()
        Dim boolcheck As Boolean = True ' check boolean
        If boolcheck = Me.CheckEntries() = False Then 'Check User Entries
            Dim strfolder As String = $"{FrmMain.injectionLogBaseDirectory}\{Name}"
            If Not Directory.Exists(strfolder) Then
                Directory.CreateDirectory(strfolder)
            End If

            'Log File Name for data storage during runntime
            strlogfile = strfolder + "\" + Me.TabControl.DGVPart.Rows(0).Cells(1).Value +
            "-" + Me.TabControl.DGVPart.Rows(0).Cells(0).Value + ".txt"
            'Deletes Log File with same name if it exists
            Try
                If File.Exists(strlogfile) Then
                    File.Delete(strlogfile)
                End If
            Catch ex As Exception
                MsgBox($"Unable to delete existing log. Make sure it isn't open in another application.{Environment.NewLine}{ex.Message}")
            End Try

            'Name of report file to be written
            strreportfile = strfolder + "\" + Me.TabControl.DGVPart.Rows(0).Cells(1).Value +
            "-" + Me.TabControl.DGVPart.Rows(0).Cells(0).Value + ".xlsx"
            'Deletes file with same name if it exists
            Try
                If File.Exists(strreportfile) Then
                    File.Delete(strreportfile)
                End If
            Catch ex As Exception
                MsgBox($"Unable to delete file.{Environment.NewLine}{ex.Message}")
            End Try

            'Copy Report Template File to appropriate folder
            Try

                If Me.pumptype = "FDI Pump" Then
                    System.IO.File.Copy($"{FrmMain.baseDirectory}\Data\Logs\FDI Data Logger R0.0\FDI Log Template R1.xlsx", strreportfile)
                End If
                If Me.pumptype = "Mahr Pump" Then
                    System.IO.File.Copy($"{FrmMain.baseDirectory}\Data\Logs\FDI Data Logger R0.0\FDI Log Template R1-Mahr.xlsx", strreportfile)
                End If
            Catch ex As Exception
                MsgBox($"Report Template has been moved or no longer exists.{Environment.NewLine}{ex.Message}")

            End Try

            'Create File Stream Log File
            'Dim fsettings As New FileStream(strlogfile, FileMode.Create, FileAccess.Write, FileShare.Read)
            'fsettings.Close()
            'Write Partnumber,Job Number, and Serial Number to text file
            Dim texout As New StreamWriter(New FileStream(strlogfile, FileMode.Append, FileAccess.Write))
            texout.WriteLine("Part Number: " + Me.TabControl.DGVPart.Rows(0).Cells(0).Value)
            texout.WriteLine("Job Number: " + Me.TabControl.DGVPart.Rows(0).Cells(1).Value)
            texout.WriteLine("Serial Number: " + Me.TabControl.DGVPart.Rows(0).Cells(2).Value)
            texout.Close()
            ' Change user Entry controls to readonly
            Me.TabControl.DGVPart.ReadOnly = True
            'Enable Data Collection and Modifiy controls
            Me.TabControl.BtnStart.Enabled = False
            Me.TabControl.BtnStart.Text = "Logging...."
            Me.TabControl.BtnEnd.Enabled = True
            Me.LogStatus = "Logging"
            Me.TimerLight.Enabled = True
            Me.TabControl.DGVPart.ReadOnly = True

            'Change Mahr Logging Status to Logging
            If Me.pumptype = "Mahr Pump" Then
                Dim Status As SMTN.SMTNControl.MB_STATUS  ' variable for receiving return status
                Dim SMTN1 As New SMTN.SMTNControl("F97B245eE10B3dC2B6fD986Aff02CFE8")
                SMTN1.ServerIPAddress = Me.IPAddress
                SMTN1.ListenPort = 502
                SMTN1.ConnectToServer(True)
                Status = SMTN1.MbPresetSingleReg(1, 0, 1) ' write to holding register (resets logging)
                SMTN1.ConnectToServer(False)
                Status = Nothing
                SMTN1 = Nothing
            End If

            Me.Timer1.Enabled = True
            Call Timer1Tick()
        End If
    End Sub 'Start Injection Log

    Public Sub Endlog()
        Me.Timer1.Enabled = False
        intruntime = 0
        Me.TabControl.BtnStart.Enabled = True
        Me.TabControl.Text = "Start Data Logger"
        Me.TabControl.BtnEnd.Enabled = False
        Me.TabControl.Chart1.Series(0).Points.Clear()
        Me.TabControl.Chart1.Series(1).Points.Clear()
        Me.TabControl.TxtStatus.Text = "Not Logging"
        Me.Status = "Awaiting Start"
        Me.LogStatus = "Not Logging"
        Me.TimerLight.Enabled = False
        Me.TabControl.ChkPump.Checked = False
        Me.TabControl.DGVPart.ReadOnly = False
        Me.TabControl.BtnStart.Text = "Start Data Logger"
        Call UpdateHomeRow()

        If Me.pumptype = "FDI Pump" Then 'Calls Report generation for FDI Pump
            Call generatequickreport()
        End If

        If Me.pumptype = "Mahr Pump" Then 'Calls Report generation for Mahr Pump\
            Call generatequickreportmahr()
            Dim Status As SMTN.SMTNControl.MB_STATUS  ' variable for receiving return status
            Dim SMTN1 As New SMTN.SMTNControl("F97B245eE10B3dC2B6fD986Aff02CFE8")
            SMTN1.ServerIPAddress = Me.IPAddress
            SMTN1.ListenPort = 502
            SMTN1.ConnectToServer(True)
            Status = SMTN1.MbPresetSingleReg(1, 0, 0) ' write to holding register (resets logging)
            SMTN1.ConnectToServer(False)
            Status = Nothing
            SMTN1 = Nothing

        End If
    End Sub 'End Injection Log

    Private Sub generatequickreport() 'Creates Report for FDI Pump
        Console.WriteLine("Quick report generated")
        MsgBox("Quick report generated")
        Dim objvalues(3, 0) As Object 'object containing report write data
        'Get Log Setup Information from Log File
        Dim textin As New StreamReader(New FileStream(strlogfile, FileMode.Open, FileAccess.Read))
        objvalues(0, 0) = $"Pump Name: {Name}"
        objvalues(1, 0) = textin.ReadLine ' Part Number 
        objvalues(2, 0) = textin.ReadLine ' Job Number
        objvalues(3, 0) = textin.ReadLine ' Serial Number
        objvalues(4, 0) = "Date:" + DateTime.Now.ToString

        Dim strloggeddates As New List(Of String)
        Dim strloggedpressures As New List(Of String)
        Dim strloggedflowrates As New List(Of String)

        'Get Data from Log File
        If Me.pumptype = "FDI Pump" Then
            Do While textin.Peek <> -1
                Dim strsplit() As String = Split(textin.ReadLine, ",")
                strloggeddates.Add(strsplit(0))
                strloggedpressures.Add(strsplit(1))
                strloggedflowrates.Add(strsplit(2))
            Loop
        End If

        'Place log file data into 2d object array


        Dim objdata(strloggeddates.Count, 4) As Object 'Data to be written to report from FDI pump

        For x = 0 To strloggeddates.Count - 1
            objdata(x, 0) = x
            objdata(x, 1) = x / 6
            objdata(x, 2) = strloggeddates(x)
            objdata(x, 3) = strloggedpressures(x)
            objdata(x, 4) = strloggedflowrates(x)
        Next


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
        Dim app As New Microsoft.Office.Interop.Excel.Application

        'Identifies new Excel Process ID
        Dim newProcess As Process = Nothing
        localAll = Process.GetProcesses()
        For i As Integer = 0 To localAll.Length - 1
            If localAll(i).ProcessName.ToUpper = "EXCEL" AndAlso Not lstOldProcessID.ContainsKey(localAll(i).Id) Then
                newProcess = localAll(i)
                Exit For
            End If
        Next

        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        Dim xlrng As Excel.Range
        'Instance
        workbook = app.Workbooks.Open(strreportfile)
        worksheet = DirectCast(workbook.Worksheets("sheet1"), Excel.Worksheet)
        'Writing to Report File
        xlrng = worksheet.Range("A9:A12")
        xlrng.Value = objvalues 'Write log information to report
        xlrng = worksheet.Range("A9:C12") 'Sets Range so merged celss can also be bordered
        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        xlrng = worksheet.Range("B31:F" + (strloggeddates.Count + 31).ToString)
        xlrng.Value = objdata
        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        xlrng = worksheet.Range($"B31:B{(strloggeddates.Count + 31)}")
        xlrng.NumberFormat = "#0.00"

        'Convert to .pdf
        'Dim pdfjob As New PDFCreator.clsPDFCreator
        Dim spdfname As String
        Dim spdfpath As String
        Dim strsplitfilename() As String = Split(strreportfile, "\")
        Dim strsplitpdfname() As String = Split(strsplitfilename(strsplitfilename.Count - 1), ".")
        Dim strxlfile As String = strsplitpdfname(0)
        spdfname = strxlfile + ".pdf" 'Creates PDF File Name
        spdfpath = workbook.Path.ToString 'Sets path to report directory
        Dim strpdffile As String = spdfpath + "\" + strxlfile + ".pdf"
        strxlfile = spdfpath + "\" + strxlfile + ".xlsx"



        app.DisplayAlerts = False
        workbook.Save()
        'release(xlrng)
        'release(worksheet)
        'release(workbook)
        worksheet.PrintOutEx()
        app.Quit()
        'release(app)
        newProcess.Kill() 'Kills Excel Process
        lstOldProcessID = Nothing
        newProcess = Nothing
        localAll = Nothing
        xlrng = Nothing
        worksheet = Nothing
        workbook = Nothing
        app = Nothing

        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        'GC.Collect()

        Me.TabControl.DGVCureLogs.Rows.Add(System.DateTime.Now, Me.TabControl.DGVPart.Rows(0).Cells(0).Value,
                                           FrmMain.SplitString(strpdffile, "\", 777))


        'Convert XL Log file to PDF
        Me.convertreport(strxlfile, strpdffile, spdfname)

    End Sub 'Generates report for FDI Pump

    Private Sub generatequickreportmahr() 'Generates report for Mahr Pump
        Console.WriteLine("Mahr quick report generated")
        MsgBox("Mahr quick report generated")
        Dim objvalues(3, 0) As Object 'object containing report write data
        'Get Log Setup Information from Log File
        Dim textin As New StreamReader(New FileStream(strlogfile, FileMode.Open, FileAccess.Read))
        objvalues(0, 0) = $"Pump Name: {Name}"
        objvalues(1, 0) = textin.ReadLine ' Part Number 
        objvalues(2, 0) = textin.ReadLine ' Job Number
        objvalues(3, 0) = textin.ReadLine ' Serial Number
        objvalues(4, 0) = "Date:" + DateTime.Now.ToString

        Dim strloggeddates As New List(Of String)
        Dim strparam1 As New List(Of String) 'Resin Flow Rate
        Dim strparam2 As New List(Of String) 'Hardener Flow Rate
        Dim strparam3 As New List(Of String) 'Resin Pump Pressure
        Dim strparam4 As New List(Of String) 'Hardener Pump Pressure
        Dim strparam5 As New List(Of String) 'Resin Head Pressure
        Dim strparam6 As New List(Of String) 'Hardener Head Pressure
        Dim strparam7 As New List(Of String) 'Resin Temp
        Dim strparam8 As New List(Of String) 'Hardener Temp
        Dim strparam9 As New List(Of String) 'Ratio
        Dim strparam10 As New List(Of String) 'Dispense On/Off
        Dim strparam11 As New List(Of String) ' Combined flow rate
        Dim strparam12 As New List(Of String) ' Flow time
        Dim strparam13 As New List(Of String) ' Flow Size

        Dim cummulativeflow As Double = 0

        'Get Data from Log File
        Do While textin.Peek <> -1
            Dim strsplit() As String = Split(textin.ReadLine, ",")
            Console.WriteLine($"The number of items in the split log record is: {strsplit.Length}.")
            'msgBox(strsplit.ToString) 'Displays data from split string
            strloggeddates.Add(strsplit(0))
            strparam1.Add(strsplit(1))
            ' Check for numeric entry of Hardener flow rate
            If IsNumeric(Val(strsplit(2))) = True Then
                Dim dblparam2 As Double = Val(strsplit(2)) / 10
                strparam2.Add(dblparam2.ToString)
            Else
                strparam2.Add(strsplit(2))
            End If
            strparam3.Add(strsplit(3))
            strparam4.Add(strsplit(4))
            strparam5.Add(strsplit(5))
            strparam6.Add(strsplit(6))
            strparam7.Add(strsplit(7))
            strparam8.Add(strsplit(8))
            If IsNumeric(Val(strsplit(9))) = True Then
                Dim dblparam9 As Double = Val(strsplit(9)) / 10
                strparam9.Add(dblparam9.ToString)
            Else
                strparam9.Add(strsplit(9))
            End If
            If IsNumeric(Val(strsplit(10))) = True Then
                If Val(strsplit(10)) = 0 Then
                    strparam10.Add("Off")
                Else
                    strparam10.Add("On")
                End If

            Else
                strparam10.Add(strsplit(10))
            End If
            Dim combinedflowrate As Single = 0
            If IsNumeric(Val(strsplit(2))) = True Then
                If IsNumeric(Val(strsplit(1))) = True Then
                    combinedflowrate = Val(strsplit(1)) + Val(strsplit(2)) / 10
                    cummulativeflow = cummulativeflow + combinedflowrate * 10 / 6 'again hard-coded interval
                End If
            End If
            strparam11.Add(combinedflowrate.ToString)
            strparam12.Add(strsplit(11) / 6) ' data from controller seems to be increments of 1 every 10 seconds. this converts the number to minutes
            'strparam13.Add(cummulativeflow.ToString)
            strparam13.Add(strsplit(12))

        Loop
        'Place log file data into 2d object array


        Dim objdata(strloggeddates.Count, 14) As Object 'Data to be written to report from FDI pump

        For x = 0 To strloggeddates.Count - 1
            'objdata(x, 0) = x
            objdata(x, 0) = x / 6
            objdata(x, 1) = strloggeddates(x)
            objdata(x, 2) = strparam1(x)
            objdata(x, 3) = strparam2(x)
            objdata(x, 4) = strparam3(x)
            objdata(x, 5) = strparam4(x)
            objdata(x, 6) = strparam5(x)
            objdata(x, 7) = strparam6(x)
            objdata(x, 8) = strparam7(x)
            objdata(x, 9) = strparam8(x)
            objdata(x, 10) = strparam9(x)
            objdata(x, 11) = strparam10(x)
            objdata(x, 12) = strparam11(x)
            objdata(x, 13) = strparam12(x)
            objdata(x, 14) = strparam13(x)

        Next


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

        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        Dim xlrng As Excel.Range
        'Instance
        workbook = app.Workbooks.Open(strreportfile)
        worksheet = DirectCast(workbook.Worksheets("sheet1"), Excel.Worksheet)
        'Writing to Report File
        xlrng = worksheet.Range("A9:A12")
        xlrng.Value = objvalues 'Write log information to report
        xlrng = worksheet.Range("A9:C12") 'Sets Range so merged cells can also be bordered
        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        xlrng = worksheet.Range("A36:O" + (strloggeddates.Count + 36).ToString)
        xlrng.Value = objdata
        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        xlrng = worksheet.Range($"A36:A{strloggeddates.Count + 36}")
        xlrng.NumberFormat = "##0.00"

        'Convert to .pdf
        'Dim pdfjob As New PDFCreator.clsPDFCreator
        Dim spdfname As String
        Dim spdfpath As String
        Dim strsplitfilename() As String = Split(strreportfile, "\")
        Dim strsplitpdfname() As String = Split(strsplitfilename(strsplitfilename.Count - 1), ".")
        Dim strxlfile As String = strsplitpdfname(0)
        spdfname = strxlfile + ".pdf" 'Creates PDF File Name
        spdfpath = workbook.Path.ToString 'Sets path to report directory
        Dim strpdffile As String = spdfpath + "\" + strxlfile + ".pdf"
        strxlfile = spdfpath + "\" + strxlfile + ".xlsx"


        app.DisplayAlerts = False
        workbook.Save()
        'release(xlrng)
        'release(worksheet)
        'release(workbook)
        worksheet.PrintOutEx()
        app.Quit()
        'release(app)
        newProcess.Kill() 'Kills Excel Process
        lstOldProcessID = Nothing
        newProcess = Nothing
        localAll = Nothing
        xlrng = Nothing
        worksheet = Nothing
        workbook = Nothing
        app = Nothing


        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()

        'Call pdfconverter------------
        Me.TabControl.DGVCureLogs.Rows.Add(System.DateTime.Now, Me.TabControl.DGVPart.Rows(0).Cells(0).Value,
                                           FrmMain.SplitString(strpdffile, "\", 777))

        ' Open PDF Reader Form
        'Dim openfile As String = (spdfpath + "\" + spdfname).ToString

        'Convert XL Log file to PDF
        Me.convertreport(strxlfile, strpdffile, spdfname)

    End Sub 'Generates report for FDI Pump

    Private Sub convertreport(ByVal strxlfile, ByVal strpdffile, ByVal spdfname)
        Console.WriteLine("Report converted to pdf.")
        MsgBox("Report converted to pdf")
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
        Dim paramFromPage As Object = Type.Missing
        Dim paramToPage As Object = Type.Missing

        Try
            ' Create an instance of Excel.
            excelApplication = New Workbook()

            ' Open the source workbook.
            excelWorkbook = excelApplication.Workbooks.Open(paramSourceBookPath)


            ' Save it in the target format.
            If Not excelWorkbook Is Nothing Then
                excelWorkbook.ExportAsFixedFormat(paramExportFormat, paramExportFilePath, paramExportQuality,
                    paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage, paramToPage, paramOpenAfterPublish)
            End If
        Catch ex As Exception
            ' Respond to the error
            Console.WriteLine(ex.Message)
        Finally
            ' Close the Workbook object.
            If Not excelWorkbook Is Nothing Then
                excelWorkbook.Close(False)
                excelWorkbook = Nothing
            End If

            ' Close the ApplicationClass object.
            If Not excelApplication Is Nothing Then
                excelApplication.Quit()
                excelApplication = Nothing
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try

        'Copy file to server
        Try
            If Not Directory.Exists(strbackupdirectory) Then
                Directory.CreateDirectory(strbackupdirectory)
            End If
            System.IO.File.Copy(strpdffile, (strbackupdirectory + spdfname))
            Exit Sub
        Catch err As Exception
            'MsgBox("Unable to write report to server. Report will be saved locally. Please notify Colin of this message.")
        End Try

    End Sub

    Private Function CheckEntries() As Boolean
        If Me.TabControl.DGVPart.RowCount > 0 Then
            For Each r As DataGridViewRow In Me.TabControl.DGVPart.Rows
                Dim BoolCheck As Boolean = False
                If Not IsNothing(r.Cells(0).Value) And Not IsNothing(r.Cells(1).Value) And Not IsNothing(r.Cells(2).Value) Then
                    If Not r.Cells(0).Value.ToString = "" Then
                        If Not r.Cells(1).Value.ToString = "" Then
                            If Not r.Cells(2).Value.ToString = "" Then
                                BoolCheck = True
                            End If
                        End If
                    End If
                End If
                If BoolCheck = False Then
                    Return True
                End If
            Next
            Return False
        Else
            Return True
        End If
    End Function 'Checks User Entries Returns True if error

    Private Sub Timer1Tick()
        Dim regdata(1) As UShort
        Dim plotableData(1) As Single
        Dim StatusError As SMTN.SMTNControl.MB_STATUS
        'Dim err As Short
        'Get PressureData from Pumps using SMRN Control

        If Me.pumptype = "FDI Pump" Then
            FrmMain.SMTN1.ConnectToServer(True)
            StatusError = FrmMain.SMTN1.MbReadInputRegs(1, Me.intfirstaddress - 1, regdata.Length, regdata)
            'err = Form1.SMRN1.MbReadHoldingRegs(modbusaddress, pressureaddress, 1, regdata)
            If StatusError = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
                Me.Status = "Logging"
                If regdata(0) > TRANSDUCER_DISCONNECTED_VALUE Then 'a disconnected thermocouple may ready anywhere from 65525 to 65535
                    regdata(0) = 0
                    plotableData(0) = Single.NaN
                Else
                    plotableData(0) = Convert.ToSingle(regdata(0))
                End If
                If regdata(1) > TRANSDUCER_DISCONNECTED_VALUE Then 'a disconnected thermocouple may ready anywhere from 65525 to 65535
                    regdata(1) = 0
                    plotableData(1) = Single.NaN
                Else
                    plotableData(1) = Convert.ToSingle(regdata(1))
                End If
                Me.Pressure = plotableData(0).ToString
                Me.FlowRate = plotableData(1).ToString
                Dim intxmax As Integer = 0
                Me.TabControl.Chart1.Series(0).Points.AddXY(intruntime / 6, plotableData(0))
                Me.TabControl.Chart1.Series(1).Points.AddXY(intruntime / 6, plotableData(1))
            Else
                'MsgBox(StatusError.ToString)
                Me.Pressure = "#N/A"
                Me.FlowRate = "#N/A"
                Me.Status = "Logging....with error"
            End If
        End If


        Dim writestring As String = System.DateTime.Now
        If Me.pumptype = "Mahr Pump" Then
            FrmMain.SMTN1.ConnectToServer(True) 'Connect to Mahr1
            Dim regdatamahr(11) As UShort 'Array for receiving holding register values
            Dim plotableDataMahr(11) As Single
            Dim statusmahr As SMTN.SMTNControl.MB_STATUS 'Variable for recieving return status
            statusmahr = FrmMain.SMTN1.MbReadInputRegs(1, Me.intfirstaddress - 1, regdatamahr.Length, regdatamahr)
            '***********Add code for reading registers
            If statusmahr = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR Then
                'MsgBox("No Error")
                For i = 0 To regdatamahr.Length - 1
                    If IsGoodTransducerValue(regdatamahr(i)) Then
                        plotableDataMahr(i) = Convert.ToSingle(regdatamahr(i))
                    Else
                        plotableDataMahr(i) = Single.NaN
                    End If
                Next
                For Each _value In plotableDataMahr
                    If _value.Equals(Single.NaN) Then
                        writestring = $"{writestring},#N/A"
                    Else
                        writestring = $"{writestring},{_value.ToString}"
                    End If
                Next
                Me.Status = "Logging"

                Me.Pressure = plotableDataMahr(4).ToString
                Dim combinedflowrate As Single = plotableDataMahr(0) + plotableDataMahr(1) / 10
                'Dim combinedflowrate As Single = plotableDataMahr(10) ' hardcoding this index is not the best of ideas
                Me.FlowRate = combinedflowrate.ToString '+ " g/min"
                Me.TabControl.Chart1.Series(0).Points.AddXY(intruntime / 6, plotableDataMahr(4)) '*********Make sure this is the correct index for pressure
                Me.TabControl.Chart1.Series(1).Points.AddXY(intruntime / 6, combinedflowrate) '********Make sure this is the corect index for flowrate
            Else 'if Error present
                'MsgBox("Error")
                Me.Status = "Logging with error"
                Me.Pressure = "#N/A"
                Me.FlowRate = "#N/A"
                writestring = $"{System.DateTime.Now},#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A,#N/A"
            End If

            'Check 4X 0 reg for quitting logger
            'Dim loggingreg(1) As UShort ' array for receiving input register values
            'Dim Status As SMTN.SMTNControl.MB_STATUS  ' variable for receiving return status
            'Form1.SMTN1.ConnectToServer(True)
            'Status = Form1.SMTN1.MbReadHoldingRegs(1, 1, 1, loggingreg)
            'If (Status = SMTN.SMTNControl.MB_STATUS.MB_NO_ERROR) Then
            'If loggingreg(0) = 1 Then
            '     MsgBox("Logging ended at pump unit")
            '      Call Endlog()
            '   End If
            'End If
        End If

        intruntime = intruntime + 1

        'Update Chart X axis Maximum
        'Dim intmax As Integer = Int(Me.TabControl.TxtRunTime.Text)

        'Text File output for FDI Pump
        If Me.pumptype = "FDI Pump" Then
            'Write to Log File
            'Dim fsettings As New FileStream(strlogfile, FileMode.Append, FileAccess.Write, FileShare.Read)
            'fsettings.Close()
            Dim texout As New StreamWriter(New FileStream(strlogfile, FileMode.Append, FileAccess.Write))
            texout.WriteLine(System.DateTime.Now.ToString + "," + Me.Pressure + "," + Me.FlowRate)
            texout.Close()
        End If

        'Text File output for Mahr Pump
        If Me.pumptype = "Mahr Pump" Then
            'Dim fsettings As New FileStream(strlogfile, FileMode.Append, FileAccess.Write, FileShare.Read)
            'fsettings.Close()
            Dim texout As New StreamWriter(New FileStream(strlogfile, FileMode.Append, FileAccess.Write))
            texout.WriteLine(writestring)
            texout.Close()
        End If

        If Me.pumptype = "Mahr Pump" Then
            Dim Status As SMTN.SMTNControl.MB_STATUS  ' variable for receiving return status
            Dim SMTN1 As New SMTN.SMTNControl("F97B245eE10B3dC2B6fD986Aff02CFE8")
            Dim loggingreg(1) As UShort ' array for receiving input register values
            SMTN1.ServerIPAddress = Me.IPAddress
            SMTN1.ListenPort = 502
            SMTN1.ConnectToServer(True)
            Status = SMTN1.MbReadHoldingRegs(1, 1, 1, loggingreg) ' write to holding register (resets logging)
            SMTN1.ConnectToServer(False)
            Status = Nothing
            SMTN1 = Nothing
            If loggingreg(0) = 1 Then
                Call Endlog()
            End If
            loggingreg = Nothing
        End If

        Call UpdateHomeRow()
        Call UpdateInProcessInformation()
    End Sub 'Tick Event for Logging Timer

    Private Function IsGoodTransducerValue(rawValue As UShort) As Boolean
        If rawValue > TRANSDUCER_DISCONNECTED_VALUE Then
            Return False
        Else Return True
        End If
    End Function

    Public Sub UpdateHomeRow()
        Try
            FrmMain.DGV3.ClearSelection()
            Me.HomeRow.Cells(0).Value = Me.Name
            Me.HomeRow.Cells(1).Value = Me.Pressure
            If Me.pumptype = "FDI Pump" Then
                Me.HomeRow.Cells(2).Value = Me.FlowRate + " %"
            Else
                Me.HomeRow.Cells(2).Value = Me.FlowRate + " g/min"
            End If
            Me.HomeRow.Cells(3).Value = Me.Status

            If Me.Timer1.Enabled = True Then
                Me.HomeRow.Cells(4).Value = "1"
            Else
                Me.HomeRow.Cells(4).Value = "0"
            End If
            Dim StrToolTip As String = "" 'String to be displayed in tooltip
            If Me.TabControl.DGVPart.Rows.Count > 1 Then
                Dim StrList As String = ""
                For Each r As DataGridViewRow In Me.TabControl.DGVPart.Rows
                    StrList = StrList + r.Cells(0).Value.ToString + ", "
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

    Public Sub UpdateInProcessInformation()
        Me.TabControl.TxtStatus.Text = Me.Status
        Me.TabControl.TxtRunTime.Text = $"{intruntime / 6:0.##}"
        If Me.pumptype = "FDI Pump" Then
            Me.TabControl.TxtFlowRate.Text = Me.FlowRate + " %"
        Else
            Me.TabControl.TxtFlowRate.Text = Me.FlowRate + " g/min"
        End If
        Me.TabControl.TxtPressure.Text = Me.Pressure
    End Sub 'Update In Process Information

    Private Sub TmrLightTick()
        If Me.TabControl.ChkPump.Checked = False Then
            Me.TabControl.ChkPump.Checked = True
        Else
            Me.TabControl.ChkPump.Checked = False
        End If
    End Sub 'Logging Light Tick

    Private Sub CellClick()
        If HomeRow.Cells(0).Selected = True Then
            FrmMain.TabControl1.SelectedTab = Me.Tab
            Exit Sub
        End If
        If HomeRow.Cells(1).Selected = True Then
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
    End Sub 'Cell Click Event Handler

End Class
