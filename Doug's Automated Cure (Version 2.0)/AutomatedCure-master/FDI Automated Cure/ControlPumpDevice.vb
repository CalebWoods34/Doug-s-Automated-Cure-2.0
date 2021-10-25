Imports System.IO

Public Class ControlPumpDevice
    Public TmrInjectionLight As New Timer 'Temperature Logging Light
    Private _PumpDeviceName As String = "" 'Name Property
    Private _PumpDeviceType As String = "" 'Name Property

    Public Property [PumpDeviceName]() As String
        Get
            Return _PumpDeviceName
        End Get
        Set(ByVal value As String)
            _PumpDeviceName = value
        End Set
    End Property 'Name Property

    Public Property [PumpDeviceType]() As String
        Get
            Return _PumpDeviceType
        End Get
        Set(ByVal value As String)
            _PumpDeviceType = value
        End Set
    End Property 'Pump Type Property

    Private Sub ControlPumpDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call InitializeChart()
    End Sub 'User Control Load

    Private Sub InitializeChart()
        Chart1.Series.RemoveAt(0) 'Removes initial Series
        Chart1.Series.Add("Pressure")
        Chart1.Series.Add("Flowrate")
        Chart1.Titles.Add(Me.PumpDeviceName + "-Pressure and Flowrate vs. Time")
        'Add Font Style Information for title
        Chart1.ChartAreas(0).AxisY2.Enabled = DataVisualization.Charting.AxisEnabled.True
        Chart1.ChartAreas(0).AxisY2.Title = "Flowrate (%)"
        Chart1.ChartAreas(0).AxisY2.Minimum = 0
        Chart1.ChartAreas(0).AxisY2.Maximum = 100
        Chart1.ChartAreas(0).AxisY2.Interval = 20
        Chart1.ChartAreas(0).AxisY.MinorGrid.Interval = 10
        Chart1.ChartAreas(0).AxisY2.MajorGrid.Enabled = True

        Chart1.ChartAreas(0).AxisY.Title = "Pressure (psi)"
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = 400
        Chart1.ChartAreas(0).AxisY.Interval = 40
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        Chart1.ChartAreas(0).AxisY.MinorGrid.Interval = 20
        Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = True

        Chart1.ChartAreas(0).AxisX.Title = "Time (min)"
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount

        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary
        Chart1.Series(0).LegendText = "Pressure"

        Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series(1).XAxisType = DataVisualization.Charting.AxisType.Primary
        Chart1.Series(1).LegendText = "Flowrate"
        Chart1.Series(1).YAxisType = DataVisualization.Charting.AxisType.Secondary
        Chart1.Series(1).Color = Color.Red

        If Me.PumpDeviceType = "Mahr Pump" Then
            Chart1.ChartAreas(0).AxisY2.Title = "Flowrate (g/min)"
            Chart1.ChartAreas(0).AxisY2.Maximum = 400
            Chart1.ChartAreas(0).AxisY2.Interval = 40
            Chart1.ChartAreas(0).AxisY.MinorGrid.Interval = 20
        End If

        Chart1.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray

    End Sub 'Initialize Chart

    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        Dim BoolCheck As Boolean = Me.CheckEntries
        If BoolCheck = False Then
            Dim i As Integer = FrmMain.GetPumpDeviceObject(Me.PumpDeviceName)
            'MsgBox(Me.PumpDeviceName)
            'MsgBox("PumpDevices: " + Me.PumpDeviceName + i.ToString)
            Call FrmMain.PumpDevices(i).Start()
        Else
            MsgBox("Please Ensure Part Informaion is Properly Entered.")
        End If
    End Sub 'Start Injection Log

    Private Sub BtnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnd.Click
        Dim i As Integer = FrmMain.GetPumpDeviceObject(Me.PumpDeviceName)
        Call FrmMain.PumpDevices(i).Endlog()
    End Sub 'End Injection Log

    Private Function CheckEntries() As Boolean
        If DGVPart.RowCount > 0 Then
            For Each r As DataGridViewRow In DGVPart.Rows
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

    Private Sub BtnAddPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPart.Click
        DGVPart.Rows.Add()
    End Sub 'Add Part

    Private Sub BtnDeletePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeletePart.Click
        Dim IntRowCount As Integer = DGVPart.Rows.GetRowCount(DataGridViewElementStates.Selected)
        'Dim l() As Integer = DataGridView1.Rows.IndexOf(DataGridViewElementStates.Selected

        If Not DGVPart.SelectedRows.Count = 0 Then
            For Each row As DataGridViewRow In DGVPart.SelectedRows
                If Not row.IsNewRow Then
                    DGVPart.Rows.Remove(row)
                End If
            Next
        End If

    End Sub 'Delete Selected Part

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        DGVPart.Rows.Clear()
    End Sub 'Clear Part Information

    Private Sub AddPartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPartToolStripMenuItem.Click
        DGVPart.Rows.Add()
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        Dim IntRowCount As Integer = DGVPart.Rows.GetRowCount(DataGridViewElementStates.Selected)
        'Dim l() As Integer = DataGridView1.Rows.IndexOf(DataGridViewElementStates.Selected

        If Not DGVPart.SelectedRows.Count = 0 Then
            For Each row As DataGridViewRow In DGVPart.SelectedRows
                If Not row.IsNewRow Then
                    DGVPart.Rows.Remove(row)
                End If
            Next
        End If
    End Sub

    Private Sub CopyPartInformation()
        DGVPart.EndEdit()
        Dim IntRowCount As Integer = DGVPart.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If Not DGVPart.SelectedRows.Count = 0 Then
            Clipboard.Clear()
            Dim StrCopy As String = ""
            For Each r As DataGridViewRow In DGVPart.SelectedRows
                StrCopy = StrCopy + r.Cells(0).Value.ToString + ":" + r.Cells(1).Value.ToString + ":" + r.Cells(2).Value.ToString + ":"
            Next
            Clipboard.SetText(StrCopy)
            'End If
        End If
    End Sub ' Copy Part Information Subroutine

    Private Sub PastePartInformation()
        Dim StrPaste As String = Clipboard.GetText
        If Not StrPaste.Contains(":") Then
            Exit Sub
        Else
            Dim StrSplit() As String = Split(StrPaste, ":")
            If Not Int((StrSplit.Count - 1) / 3) = Val((StrSplit.Count - 1) / 3) Then
                Exit Sub
            Else
                Dim j As Integer = 0
                For i As Integer = 1 To (StrSplit.Count - 1) / 3
                    Dim NewString() As String = {StrSplit(0), StrSplit(1), StrSplit(2)}
                    DGVPart.Rows.Add(NewString)
                    'DGVPart.Rows(DGVPart.Rows.Count - 1).Cells(0).Value = 0
                    'DGVPart.Rows(DGVPart.Rows.Count - 1).Cells(0).Value = StrSplit(j)
                    'DGVPart.Rows(DGVPart.Rows.Count - 1).Cells(1).Value = StrSplit(j + 1)
                    'DGVPart.Rows(DGVPart.Rows.Count - 1).Cells(2).Value = StrSplit(j + 2)
                    j = j + 3
                Next
            End If
        End If
    End Sub 'Paste Part Information Subroutine

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Call CopyPartInformation()
    End Sub 'Copy Menu Strip

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Call PastePartInformation()
    End Sub 'Paste Menu Strip

    Private Sub BtnViewSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewSelected.Click
        If Not DGVCureLogs.SelectedRows.Count = 0 Then
            Dim fileNameAndPath As String = $"{FrmMain.injectionLogBaseDirectory}\{PumpDeviceName}\{DGVCureLogs.SelectedRows(0).Cells(2).Value.ToString}"
            If File.Exists(fileNameAndPath) Then
                System.Diagnostics.Process.Start(fileNameAndPath)
            Else
                MsgBox("Could not find file.")
            End If
        End If
    End Sub 'View Button

    Private Sub BtnPrintSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintSelected.Click
        If Not DGVCureLogs.SelectedRows.Count = 0 Then
            If File.Exists($"{FrmMain.injectionLogBaseDirectory}\{PumpDeviceName}\{DGVCureLogs.SelectedRows(0).Cells(2).Value.ToString}") Then
                Dim MyProcess As New Process
                MyProcess.StartInfo.CreateNoWindow = False
                MyProcess.StartInfo.Verb = "print"
                MyProcess.StartInfo.FileName = $"{FrmMain.injectionLogBaseDirectory}\{PumpDeviceName}\{DGVCureLogs.SelectedRows(0).Cells(2).Value.ToString}"
                MyProcess.Start()
                MyProcess.WaitForExit(10000)
                'MyProcess.CloseMainWindow()
                MyProcess.Close()
                MyProcess = Nothing
                MsgBox("File has printed to the default printer.")
            Else
                MsgBox("Could not print document. File may have been moved to another location or disk is full.")
            End If
        End If
    End Sub 'Print Button

End Class
