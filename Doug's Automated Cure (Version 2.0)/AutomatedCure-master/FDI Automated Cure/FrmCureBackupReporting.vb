Imports System.IO
'Imports Microsoft.Office.Interop

Public Class FrmCureBackupReporting
    Public IntStartDataPoint As Integer = 0
    Public IntEndDataPoint As Integer = 1
    Private deviceName As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Open Backup Data Log (.csv)"
        OpenFileDialog1.Filter = "Comma Seperated Value File (*.csv)|*.csv"
        OpenFileDialog1.ShowDialog()
        Dim StrFile As String = OpenFileDialog1.FileName
        If StrFile = "" Then
            MsgBox("Please select a file.")
        End If

        If File.Exists(StrFile) Then
            LoadCSV(StrFile)
            TxtBackupLogFile.Text = StrFile
        Else
            MsgBox("Selected file does not exist.")
        End If
    End Sub 'Browse for CSV File

    Private Function ParseDateFromLogFilename() As Date
        Dim year As UShort
        Dim month As UShort
        Dim day As UShort

        Dim LstPartNumbers As New List(Of String) 'List of potential parts with configured recipes


        If Directory.Exists($"{FrmMain.BackupTempLogPath}\{deviceName}") Then
            Dim DirInfo As New IO.DirectoryInfo($"{FrmMain.BackupTempLogPath}\{deviceName}")
            Dim Dir1 As IO.FileInfo() = DirInfo.GetFiles()
            For Each D As IO.FileInfo In Dir1
                If D.ToString.Contains(".CSV") Then
                    If D.ToString.Contains(Name) Then
                        LstPartNumbers.Add(FrmMain.SplitString(D.ToString, ".", 0))
                    End If
                End If
            Next
        End If

    End Function

    Private Sub LoadCSV(ByVal InputFile As String)
        DGV1.Columns.Clear()
        DGV1.Rows.Clear()
        Dim textin As StreamReader
        Try
            textin = New StreamReader(New FileStream(InputFile, FileMode.Open, FileAccess.Read))
            Dim Writestring() As String = Split(textin.ReadLine, ",")
            For i As Integer = 0 To Writestring.Count - 1
                DGV1.Columns.Add(Writestring(i), Writestring(i))
            Next
            Dim intcount As Integer = Writestring.Count - 1
            Do While textin.Peek <> -1
                Dim Write() As String = Split(textin.ReadLine, ",")
                DGV1.Rows.Add(Write)
            Loop
            textin.Close()
        Catch e As Exception
            MsgBox("Selected file does not exist. ", e.Message)
        End Try
    End Sub 'Load CSV File

    Private Sub FrmCureBackupReporting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each c As CureDevice In FrmMain.CureDevices
            Cbo1.Items.Add(c.Name.ToString)
        Next
        For Each p As PumpDevice In FrmMain.PumpDevices
            Cbo1.Items.Add(p.Name.ToString)
        Next
    End Sub 'Load Button

    Private Sub FrmCureBackupReporting_Closing() '''''''''''''''''''FIGURE CLOSING OUT
        Me.Dispose()
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        'GC.Collect()
    End Sub 'Form Closing

    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        If DGV1.SelectedRows.Count = 1 Then
            TxtStart.Text = DGV1.SelectedRows(0).Cells(1).Value
            IntStartDataPoint = DGV1.SelectedRows(0).Index
        Else
            MsgBox("Select a row to be the first data point")
        End If
    End Sub 'Start Data Point Button

    Private Sub BtnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnd.Click
        If DGV1.SelectedRows.Count = 1 Then
            TxtEnd.Text = DGV1.SelectedRows(0).Cells(1).Value
            IntEndDataPoint = DGV1.SelectedRows(0).Index
        Else
            MsgBox("Select a row to be the first data point")
        End If
    End Sub 'End Data Point Button

    Private Sub BtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLoad.Click
        If File.Exists(TxtBackupLogFile.Text) Then
            Call LoadCSV(TxtBackupLogFile.Text)
        Else
            MsgBox("Please select a backup log file.")
        End If
    End Sub 'Load Button

    Private Sub BtnCreateLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateLog.Click
        Console.WriteLine("create log button clicked.")
        MsgBox("Create log button clicked.")
        'Dim BoolCheck As Boolean = CheckEntries()
        'If BoolCheck = True Then
        '    Exit Sub
        'End If

        'Dim StrType As String = ""
        'For Each c As CureDevice In FrmMain.CureDevices
        '    If Cbo1.Text = c.Name Then
        '        StrType = "Temperature"
        '        Exit For
        '    End If
        'Next

        'For Each p As PumpDevice In FrmMain.PumpDevices
        '    If Cbo1.Text = p.Name Then
        '        StrType = "Injection"
        '        Exit For
        '    End If
        'Next

        'If StrType = "Temperature" Then '______________________________________________________________
        '    Dim ObjInformation(2, 0) As Object 'Object Containing Cure Information
        '    Dim ObjBatchInformation(15, 3) As Object 'Object Containing Batch Part Information
        '    ObjInformation(0, 0) = Cbo1.Text
        '    ObjInformation(1, 0) = System.DateTime.Now.ToString

        '    ObjBatchInformation(0, 0) = TxtPartNumber.Text
        '    ObjBatchInformation(0, 1) = TxtJobNumber.Text
        '    ObjBatchInformation(0, 2) = TxtSerialNumber.Text

        '    Dim StrLoggedDates As New List(Of String)
        '    Dim StrPartTemp As New List(Of String)
        '    Dim StrSetpoint As New List(Of String)

        '    'Dim textin As New StreamReader(New FileStream(Me.TempLogFile, FileMode.Open, FileAccess.Read))
        '    'Do While textin.Peek <> -1
        '    '    Dim strsplit() As String = Split(textin.ReadLine, ",")
        '    '    StrLoggedDates.Add(strsplit(0))
        '    '    StrPartTemp.Add(strsplit(1))
        '    '    StrSetpoint.Add(strsplit(2))
        '    'Loop

        '    For i As Integer = IntStartDataPoint To IntEndDataPoint
        '        StrLoggedDates.Add(DGV1.Rows(i).Cells(1).Value)
        '        StrPartTemp.Add(DGV1.Rows(i).Cells(2).Value)
        '        StrSetpoint.Add(DGV1.Rows(i).Cells(3).Value)
        '    Next

        '    Dim ObjTempData(StrLoggedDates.Count, 5) As Object
        '    For x = 0 To StrLoggedDates.Count - 1
        '        ObjTempData(x, 0) = x
        '        ObjTempData(x, 1) = x * 2
        '        ObjTempData(x, 2) = StrLoggedDates(x)
        '        ObjTempData(x, 3) = StrPartTemp(x)
        '        ObjTempData(x, 4) = StrSetpoint(x)
        '    Next

        '    'Get List of all existing Excel Process IDs
        '    Dim lstOldProcessID As New System.Collections.Generic.Dictionary(Of Integer, Process)
        '    Dim localAll As Process()
        '    localAll = Process.GetProcesses
        '    For i As Integer = 0 To localAll.Length - 1
        '        If localAll(i).ProcessName.ToUpper = "EXCEL" Then
        '            lstOldProcessID.Add(localAll(i).Id, localAll(i))
        '        End If
        '    Next

        '    'Initialize Excel Application 
        '    Dim app As New Excel.Application

        '    'Identifies new Excel Process ID
        '    Dim newProcess As Process = Nothing
        '    localAll = Process.GetProcesses()
        '    For i As Integer = 0 To localAll.Length - 1
        '        If localAll(i).ProcessName.ToUpper = "EXCEL" AndAlso Not lstOldProcessID.ContainsKey(localAll(i).Id) Then
        '            newProcess = localAll(i)
        '            Exit For
        '        End If
        '    Next

        '    Dim workbook As Excel.Workbook
        '    Dim worksheet As Excel.Worksheet
        '    Dim xlrng As Excel.Range
        '    'Instance
        '    Dim StrReportFile As String = "C:\Programs\FDI MPCS\FDI Cure Log Template"
        '    workbook = app.Workbooks.Open(StrReportFile)
        '    worksheet = DirectCast(workbook.Worksheets("sheet1"), Excel.Worksheet)
        '    'Writing to Report File
        '    xlrng = worksheet.Range("B9:B10")
        '    xlrng.Value = ObjInformation
        '    xlrng = worksheet.Range("B14:D28")
        '    xlrng.Value = ObjBatchInformation
        '    xlrng = worksheet.Range("B50:F" + (StrLoggedDates.Count + 50).ToString)
        '    xlrng.Value = ObjTempData
        '    xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        '    'Dim spdfname As String
        '    'Dim spdfpath As String
        '    'Dim strsplitfilename() As String = Split(StrReportFile, "\")
        '    'Dim strsplitpdfname() As String = Split(strsplitfilename(strsplitfilename.Count - 1), ".")
        '    'Dim strxlfile As String = strsplitpdfname(0)
        '    'spdfname = strxlfile + ".pdf" 'Creates PDF File Name
        '    'spdfpath = workbook.Path.ToString 'Sets path to report directory
        '    'Dim strpdffile As String = spdfpath + "\" + strxlfile + ".pdf"
        '    'strxlfile = spdfpath + "\" + strxlfile + ".xlsx"
        '    Dim StrXLFile As String = "C:\Programs\FDI MPCS\Data\Logs\Temperature\" + Cbo1.Text + "\" + _
        '                    TxtPartNumber.Text + "_" + _
        '                    TxtJobNumber.Text
        '    app.DisplayAlerts = False
        '    workbook.SaveAs(StrXLFile)
        '    'worksheet.PrintOutEx() '''''''''Auto Printing
        '    app.Quit()
        '    newProcess.Kill() 'Kills Excel Process
        '    lstOldProcessID = Nothing
        '    newProcess = Nothing
        '    localAll = Nothing
        '    xlrng = Nothing
        '    worksheet = Nothing
        '    workbook = Nothing
        '    app = Nothing


        '    Dim StrPDFFile As String = FrmMain.SplitString(StrXLFile, ".", 0)
        '    StrPDFFile = StrPDFFile + ".pdf"
        '    Call convertreport(StrXLFile, StrPDFFile)
        '    'Add File to Cure Logs DatagridView
        '    GC.Collect()
        '    GC.WaitForPendingFinalizers()
        '    GC.Collect()
        'End If '_______________________________________________________________________________________

        'If StrType = "Injection" Then
        '    If FrmMain.PumpDevices(FrmMain.GetPumpDeviceObject(Cbo1.Text)).pumptype = "FDI Pump" Then
        '        Dim objvalues(3, 0) As Object 'object containing report write data
        '        'Get Log Setup Information from Log File
        '        'Dim textin As New StreamReader(New FileStream(strlogfile, FileMode.Open, FileAccess.Read))
        '        objvalues(0, 0) = TxtPartNumber.Text ' Part Number 
        '        objvalues(1, 0) = TxtJobNumber.Text ' Job Number
        '        objvalues(2, 0) = TxtSerialNumber.Text ' Serial Number
        '        objvalues(3, 0) = "Date:" + DateTime.Now.ToString

        '        Dim strloggeddates As New List(Of String)
        '        Dim strloggedpressures As New List(Of String)
        '        Dim strloggedflowrates As New List(Of String)

        '        'Get Data from Log File
        '        'If Me.pumptype = "FDI Pump" Then
        '        '    Do While textin.Peek <> -1
        '        '        Dim strsplit() As String = Split(textin.ReadLine, ",")
        '        '        strloggeddates.Add(strsplit(0))
        '        '        strloggedpressures.Add(strsplit(1))
        '        '        strloggedflowrates.Add(strsplit(2))
        '        '    Loop
        '        'End If

        '        For i As Integer = IntStartDataPoint To IntEndDataPoint
        '            strloggeddates.Add(DGV1.Rows(i).Cells(1).Value)
        '            strloggedpressures.Add(DGV1.Rows(i).Cells(3).Value)
        '            strloggedflowrates.Add(DGV1.Rows(i).Cells(2).Value)
        '        Next

        '        'Place log file data into 2d object array

        '        Dim objdata(strloggeddates.Count, 4) As Object 'Data to be written to report from FDI pump

        '        For x = 0 To strloggeddates.Count - 1
        '            objdata(x, 0) = x
        '            objdata(x, 1) = x / 6
        '            objdata(x, 2) = strloggeddates(x)
        '            objdata(x, 3) = strloggedpressures(x)
        '            objdata(x, 4) = strloggedflowrates(x)
        '        Next


        '        'Get List of all existing Excel Process IDs
        '        Dim lstOldProcessID As New System.Collections.Generic.Dictionary(Of Integer, Process)
        '        Dim localAll As Process()
        '        localAll = Process.GetProcesses
        '        For i As Integer = 0 To localAll.Length - 1
        '            If localAll(i).ProcessName.ToUpper = "EXCEL" Then
        '                lstOldProcessID.Add(localAll(i).Id, localAll(i))
        '            End If
        '        Next

        '        'Initialize Excel Application 
        '        Dim app As New Excel.Application

        '        'Identifies new Excel Process ID
        '        Dim newProcess As Process = Nothing
        '        localAll = Process.GetProcesses()
        '        For i As Integer = 0 To localAll.Length - 1
        '            If localAll(i).ProcessName.ToUpper = "EXCEL" AndAlso Not lstOldProcessID.ContainsKey(localAll(i).Id) Then
        '                newProcess = localAll(i)
        '                Exit For
        '            End If
        '        Next

        '        Dim workbook As Excel.Workbook
        '        Dim worksheet As Excel.Worksheet
        '        Dim xlrng As Excel.Range
        '        'Instance
        '        Dim strreportfile As String = "C:\Programs\FDI MPCS\Data\Logs\Injections\" + TxtJobNumber.Text + _
        '    "-" + TxtPartNumber.Text + ".xlsx"
        '        If File.Exists(strreportfile) Then
        '            File.Delete(strreportfile)
        '        End If
        '        System.IO.File.Copy("C:\Programs\FDI Data Logger R0.0\FDI Log Template R1.xlsx", strreportfile)
        '        workbook = app.Workbooks.Open(strreportfile)
        '        worksheet = DirectCast(workbook.Worksheets("sheet1"), Excel.Worksheet)
        '        'Writing to Report File
        '        xlrng = worksheet.Range("A9:A12")
        '        xlrng.Value = objvalues 'Write log information to report
        '        xlrng = worksheet.Range("A9:C12") 'Sets Range so merged celss can also be bordered
        '        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        '        xlrng = worksheet.Range("B31:F" + (strloggeddates.Count + 31).ToString)
        '        xlrng.Value = objdata
        '        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        '        'Convert to .pdf
        '        'Dim pdfjob As New PDFCreator.clsPDFCreator
        '        Dim spdfname As String
        '        Dim spdfpath As String
        '        Dim strsplitfilename() As String = Split(strreportfile, "\")
        '        Dim strsplitpdfname() As String = Split(strsplitfilename(strsplitfilename.Count - 1), ".")
        '        Dim strxlfile As String = strsplitpdfname(0)
        '        spdfname = strxlfile + ".pdf" 'Creates PDF File Name
        '        spdfpath = workbook.Path.ToString 'Sets path to report directory
        '        Dim strpdffile As String = spdfpath + "\" + strxlfile + ".pdf"
        '        strxlfile = spdfpath + "\" + strxlfile + ".xlsx"



        '        app.DisplayAlerts = False
        '        workbook.Save()
        '        'release(xlrng)
        '        'release(worksheet)
        '        'release(workbook)
        '        'worksheet.PrintOutEx()
        '        app.Quit()
        '        'release(app)
        '        newProcess.Kill() 'Kills Excel Process
        '        lstOldProcessID = Nothing
        '        newProcess = Nothing
        '        localAll = Nothing
        '        xlrng = Nothing
        '        worksheet = Nothing
        '        workbook = Nothing
        '        app = Nothing

        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '        GC.Collect()

        '        'Convert XL Log file to PDF
        '        Me.convertreport(strxlfile, strpdffile)

        '    Else 'MAHR PUMP-------------------------------------------------------------------------
        '        Dim objvalues(3, 0) As Object 'object containing report write data
        '        'Get Log Setup Information from Log File
        '        'Dim textin As New StreamReader(New FileStream(strlogfile, FileMode.Open, FileAccess.Read))
        '        objvalues(0, 0) = TxtPartNumber.Text ' Part Number 
        '        objvalues(1, 0) = TxtJobNumber.Text ' Job Number
        '        objvalues(2, 0) = TxtSerialNumber.Text ' Serial Number
        '        objvalues(3, 0) = "Date:" + DateTime.Now.ToString

        '        Dim strloggeddates As New List(Of String)
        '        Dim strparam1 As New List(Of String) 'Resin Flow Rate
        '        Dim strparam2 As New List(Of String) 'Hardener Flow Rate
        '        Dim strparam3 As New List(Of String) 'Resin Pump Pressure
        '        Dim strparam4 As New List(Of String) 'Hardener Pump Pressure
        '        Dim strparam5 As New List(Of String) 'Resin Head Pressure
        '        Dim strparam6 As New List(Of String) 'Hardener Head Pressure
        '        Dim strparam7 As New List(Of String) 'Resin Temp
        '        Dim strparam8 As New List(Of String) 'Hardener Temp
        '        Dim strparam9 As New List(Of String) 'Ratio
        '        Dim strparam10 As New List(Of String) 'Dispense On/Off
        '        Dim strparam11 As New List(Of String) ' Combined flow rate
        '        Dim strparam12 As New List(Of String) ' Cummulative flow
        '        Dim cummulativeflow As Double = 0

        '        'Get Data from Log File
        '        'Do While textin.Peek <> -1
        '        For i As Integer = IntStartDataPoint To IntEndDataPoint
        '            'Dim strsplit() As String = Split(textin.ReadLine, ",")
        '            'msgBox(strsplit.ToString) 'Displays data from split string
        '            strloggeddates.Add(DGV1.Rows(i).Cells(1).Value.ToString)
        '            strparam1.Add(DGV1.Rows(i).Cells(2).Value.ToString)
        '            ' Check for numeric entry of Hardener flow rate
        '            Dim dblparam2 As Double = Val(DGV1.Rows(i).Cells(3).Value) / 10
        '            strparam2.Add(dblparam2.ToString)
        '            strparam3.Add(DGV1.Rows(i).Cells(4).Value)
        '            strparam4.Add(DGV1.Rows(i).Cells(5).Value)
        '            strparam5.Add(DGV1.Rows(i).Cells(6).Value)
        '            strparam6.Add(DGV1.Rows(i).Cells(7).Value)
        '            strparam7.Add(DGV1.Rows(i).Cells(8).Value)
        '            strparam8.Add(DGV1.Rows(i).Cells(9).Value)
        '            Dim dblparam9 As Double = Val(DGV1.Rows(i).Cells(10).Value) / 10
        '            strparam9.Add(dblparam9.ToString)
        '            If Val(DGV1.Rows(i).Cells(10).Value) = 0 Then
        '                strparam10.Add("Off")
        '            Else
        '                strparam10.Add("On")
        '            End If
        '            Dim combinedflowrate As Double = 0
        '            combinedflowrate = Val(DGV1.Rows(i).Cells(2).Value) + Val(DGV1.Rows(i).Cells(3).Value) / 10
        '            cummulativeflow = cummulativeflow + combinedflowrate * 0.1666666666
        '            strparam11.Add(combinedflowrate.ToString)
        '            strparam12.Add(cummulativeflow.ToString)
        '        Next
        '        'Loop

        '        Dim objdata(strloggeddates.Count, 15) As Object 'Data to be written to report from FDI pump

        '        For x = 0 To strloggeddates.Count - 1
        '            objdata(x, 0) = x
        '            objdata(x, 1) = x / 6
        '            objdata(x, 2) = strloggeddates(x)
        '            objdata(x, 3) = strparam1(x)
        '            objdata(x, 4) = strparam2(x)
        '            objdata(x, 5) = strparam3(x)
        '            objdata(x, 6) = strparam4(x)
        '            objdata(x, 7) = strparam5(x)
        '            objdata(x, 8) = strparam6(x)
        '            objdata(x, 9) = strparam7(x)
        '            objdata(x, 10) = strparam8(x)
        '            objdata(x, 11) = strparam9(x)
        '            objdata(x, 12) = strparam10(x)
        '            objdata(x, 13) = strparam11(x)
        '            objdata(x, 14) = strparam12(x)

        '        Next


        '        'Get List of all existing Excel Process IDs
        '        Dim lstOldProcessID As New System.Collections.Generic.Dictionary(Of Integer, Process)
        '        Dim localAll As Process()
        '        localAll = Process.GetProcesses
        '        For i As Integer = 0 To localAll.Length - 1
        '            If localAll(i).ProcessName.ToUpper = "EXCEL" Then
        '                lstOldProcessID.Add(localAll(i).Id, localAll(i))
        '            End If
        '        Next

        '        'Initialize Excel Application 
        '        Dim app As New Excel.Application

        '        'Identifies new Excel Process ID
        '        Dim newProcess As Process = Nothing
        '        localAll = Process.GetProcesses()
        '        For i As Integer = 0 To localAll.Length - 1
        '            If localAll(i).ProcessName.ToUpper = "EXCEL" AndAlso Not lstOldProcessID.ContainsKey(localAll(i).Id) Then
        '                newProcess = localAll(i)
        '                Exit For
        '            End If
        '        Next

        '        Dim workbook As Excel.Workbook
        '        Dim worksheet As Excel.Worksheet
        '        Dim xlrng As Excel.Range
        '        'Instance
        '        Dim strreportfile As String = "C:\Programs\FDI MPCS\Data\Logs\Injections\" + TxtJobNumber.Text + _
        '    "-" + TxtPartNumber.Text + ".xlsx"
        '        If File.Exists(strreportfile) Then
        '            File.Delete(strreportfile)
        '        End If
        '        System.IO.File.Copy("C:\Programs\FDI Data Logger R0.0\FDI Log Template R1-Mahr.xlsx", strreportfile)
        '        workbook = app.Workbooks.Open(strreportfile)
        '        worksheet = DirectCast(workbook.Worksheets("sheet1"), Excel.Worksheet)
        '        'Writing to Report File
        '        xlrng = worksheet.Range("A9:A12")
        '        xlrng.Value = objvalues 'Write log information to report
        '        xlrng = worksheet.Range("A9:C12") 'Sets Range so merged celss can also be bordered
        '        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        '        xlrng = worksheet.Range("A36:O" + (strloggeddates.Count + 36).ToString)
        '        xlrng.Value = objdata
        '        xlrng.Borders.Weight = Excel.XlBorderWeight.xlThin

        '        'Convert to .pdf
        '        'Dim pdfjob As New PDFCreator.clsPDFCreator
        '        Dim spdfname As String
        '        Dim spdfpath As String
        '        Dim strsplitfilename() As String = Split(strreportfile, "\")
        '        Dim strsplitpdfname() As String = Split(strsplitfilename(strsplitfilename.Count - 1), ".")
        '        Dim strxlfile As String = strsplitpdfname(0)
        '        spdfname = strxlfile + ".pdf" 'Creates PDF File Name
        '        spdfpath = workbook.Path.ToString 'Sets path to report directory
        '        Dim strpdffile As String = spdfpath + "\" + strxlfile + ".pdf"
        '        strxlfile = spdfpath + "\" + strxlfile + ".xlsx"


        '        app.DisplayAlerts = False
        '        workbook.Save()
        '        'release(xlrng)
        '        'release(worksheet)
        '        'release(workbook)
        '        'worksheet.PrintOutEx()
        '        app.Quit()
        '        'release(app)
        '        newProcess.Kill() 'Kills Excel Process
        '        lstOldProcessID = Nothing
        '        newProcess = Nothing
        '        localAll = Nothing
        '        xlrng = Nothing
        '        worksheet = Nothing
        '        workbook = Nothing
        '        app = Nothing


        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '        GC.Collect()

        '        'Call pdfconverter------------

        '        ' Open PDF Reader Form
        '        'Dim openfile As String = (spdfpath + "\" + spdfname).ToString

        '        'Convert XL Log file to PDF
        '        Me.convertreport(strxlfile, strpdffile)

        '    End If

        'End If

    End Sub 'Create Log

    Private Sub convertreport(ByVal strxlfile, ByVal strpdffile)
        Console.WriteLine("report converted to pdf.")
        '' Declare variables to hold references to the Excel ApplicationClass
        '' and Workbook objects.          
        ''Dim excelApplication As ApplicationClass = Nothing
        'Dim excelApplication As Workbook = Nothing
        'Dim excelWorkbook As Workbook = Nothing

        '' Declare a variable for the path to the workbook to convert.
        'Dim paramSourceBookPath As String = strxlfile

        '' Declare variables for the Document.ExportAsFixedFormat method parameters.
        'Dim paramExportFilePath As String = strpdffile
        'Dim paramExportFormat As XlFixedFormatType = XlFixedFormatType.xlTypePDF
        'Dim paramExportQuality As XlFixedFormatQuality = XlFixedFormatQuality.xlQualityStandard
        'Dim paramOpenAfterPublish As Boolean = True
        'Dim paramIncludeDocProps As Boolean = True
        'Dim paramIgnorePrintAreas As Boolean = True

        'Try
        '    ' Create an instance of Excel.
        '    excelApplication = New Workbook()

        '    ' Open the source workbook.
        '    excelWorkbook = excelApplication.Workbooks.Open(paramSourceBookPath)

        '    ' Save it in the target format.
        '    If Not excelWorkbook Is Nothing Then
        '        excelWorkbook.ExportAsFixedFormat(paramExportFormat, paramExportFilePath, paramExportQuality, _
        '            paramIncludeDocProps, paramIgnorePrintAreas, , , paramOpenAfterPublish)
        '    End If
        'Catch ex As Exception
        '    ' Respond to the error
        '    MsgBox(ex.Message.ToString)
        'Finally
        '    ' Close the Workbook object.
        '    If Not excelWorkbook Is Nothing Then
        '        excelWorkbook.Close(False)
        '        excelWorkbook = Nothing
        '    End If

        '    ' Close the ApplicationClass object.
        '    If Not excelApplication Is Nothing Then
        '        excelApplication.Quit()
        '        excelApplication = Nothing
        '    End If

        '    GC.Collect()
        '    GC.WaitForPendingFinalizers()
        '    GC.Collect()
        '    GC.WaitForPendingFinalizers()
        'End Try

        ''Copy file to server
        'Try
        '    Dim StrBackupPath As String = FrmMain.BackupTempLogPath + "\" + Me.Name

        '    If Not Directory.Exists(StrBackupPath) Then
        '        Directory.CreateDirectory(StrBackupPath)
        '    End If
        '    Dim StrPDFName As String = FrmMain.SplitString(strpdffile, "\", 777)
        '    System.IO.File.Copy(strpdffile, (StrBackupPath + "\" + StrPDFName))
        '    Exit Sub
        'Catch err As Exception
        '    MsgBox("Unable to write report to server. Report will be saved locally. Please notify Colin of this message.")
        'End Try






    End Sub 'Convert XL File to PDF and Show

    Private Function CheckEntries() As Boolean
        If Not File.Exists(TxtBackupLogFile.Text) Then
            Return True
        End If
        If IntEndDataPoint = 1 Then
            Return True
        End If
        If TxtPartNumber.Text = "" Then
            MsgBox("Enter a valid Part Number.")
            Return True
        End If
        If TxtJobNumber.Text = "" Then
            MsgBox("Enter a valid Job Number.")
            Return True
        End If
        If TxtSerialNumber.Text = "" Then
            MsgBox("Enter a valid Serial Number.")
            Return True
        End If
        If Cbo1.Text = "" Then
            MsgBox("Select a valid device name.")
            Return True
        End If
        Return False
    End Function 'Checks for proper user entries, Returns true if error

    Private Sub FrmCureBackupReporting_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose()
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        'GC.Collect()
    End Sub 'Form Closing Event

End Class