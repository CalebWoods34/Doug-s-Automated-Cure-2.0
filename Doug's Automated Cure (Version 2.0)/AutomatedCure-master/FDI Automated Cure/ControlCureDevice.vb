Imports System.IO
Imports FDI_Automated_Cure

Public Class ControlCureDevice
    Private CurrentCureDevice As CureDevice
    Public TmrTempLogLight As New Timer 'Temperature Logging Light

    Public Sub New(device As CureDevice)

        ' This call is required by the designer.
        InitializeComponent()
        CurrentCureDevice = device
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub ControlCureDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call InitializeTempChart()
        Call InitializeCureChart()
        If CurrentCureDevice.DeviceType <> "Oven" Then
            'RemoveHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
            'DGVPart.Columns(3).Visible = False
            'AddHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
            Label2.Text = "Part Temp"
        Else
            Label2.Text = "Oven Temp"
        End If
        TmrTempLogLight.Interval = 1000
        AddHandler TmrTempLogLight.Tick, AddressOf TmrLogTempLightTick
        InitializeDGVCureInformation()
        Me.Dock = DockStyle.Fill
    End Sub 'Control Load

    Private Sub InitializeDGVCureInformation()
        If DGVCureInformation.Rows.Count > 0 Then
            ClearDGVCureInformation()
        End If
        DGVCureInformation.Rows.Add(2)
        DGVCureInformation.Rows(0).Cells(0).Value = "Preheat"
        DGVCureInformation.Rows(0).Cells(1).Value = "N/A"
        DGVCureInformation.Rows(1).Cells(0).Value = "Cure"
        DGVCureInformation.Rows(1).Cells(1).Value = "No Automated cure available."
    End Sub

    Private Sub ClearDGVCureInformation()
        DGVCureInformation.Rows.Clear()
    End Sub

    Public Sub UpdatePartNumberComboList()
        CurrentCureDevice.BuildListOfPartsForThisCureDevice()
        ClmPartNumber.Items.Clear()
        For Each partNumber In CurrentCureDevice.ListOfParts
            ClmPartNumber.Items.Add(partNumber)
        Next
    End Sub 'Updates Part Number List

    Private Sub InitializeTempChart()
        TemperatureLogChart.Series.RemoveAt(0) 'Removes initial Series
        TemperatureLogChart.Series.Add("Temp")
        TemperatureLogChart.Series.Add("Setpoint")
        TemperatureLogChart.ChartAreas(0).AxisY.MinorGrid.Interval = 10
        TemperatureLogChart.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray
        TemperatureLogChart.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray
        TemperatureLogChart.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray
        TemperatureLogChart.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray
        TemperatureLogChart.ChartAreas(0).AxisY2.MajorGrid.Enabled = True

        TemperatureLogChart.ChartAreas(0).AxisY.Title = "Temp (°F)"
        'TemperatureLogChart.ChartAreas(0).AxisY.Minimum = 70
        'TemperatureLogChart.ChartAreas(0).AxisY.Maximum = 400
        TemperatureLogChart.ChartAreas(0).AxisY.Interval = 50
        TemperatureLogChart.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        TemperatureLogChart.ChartAreas(0).AxisY.MinorGrid.Interval = 10
        TemperatureLogChart.ChartAreas(0).AxisY.MinorGrid.Enabled = True

        TemperatureLogChart.ChartAreas(0).AxisX.Title = "Time (min)"
        TemperatureLogChart.ChartAreas(0).AxisX.Minimum = 0
        TemperatureLogChart.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount

        TemperatureLogChart.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        TemperatureLogChart.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary

        Dim counter = 0
        For Each _thermocouple In CurrentCureDevice.ListOfAllDeviceTCs
            TemperatureLogChart.Series.Add("TC" + (_thermocouple.Id).ToString)
            TemperatureLogChart.Series(counter + 2).ChartType = DataVisualization.Charting.SeriesChartType.Line
            TemperatureLogChart.Series(counter + 2).XAxisType = DataVisualization.Charting.AxisType.Primary
            TemperatureLogChart.Series(counter + 2).LegendText = "TC" + (_thermocouple.Id).ToString
            counter += 1
        Next

        TemperatureLogChart.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
        TemperatureLogChart.Series(1).XAxisType = DataVisualization.Charting.AxisType.Primary
        TemperatureLogChart.Series(1).LegendText = "Setpoint"

        TemperatureLogChart.Titles.Add("Setpoint and Part Temperature vs. Time")

        TemperatureLogChart.Series(1).Color = Color.Blue
        TemperatureLogChart.Series(0).Color = Color.Red

        TemperatureLogChart.BorderlineColor = Color.Black
        TemperatureLogChart.BorderlineWidth = 10

    End Sub 'Initialize Temperature Chart

    Private Sub InitializeCureChart()
        'CureChart.Series.RemoveAt(0) 'Removes initial Series
        'CureChart.Series.Add("Temp")
        CureChart.Legends(0).Enabled = False
        CureChart.ChartAreas(0).AxisY.MinorGrid.Interval = 10
        CureChart.ChartAreas(0).AxisY2.MajorGrid.Enabled = True

        CureChart.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray
        CureChart.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray
        CureChart.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray
        CureChart.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray

        CureChart.ChartAreas(0).AxisY.Title = "Temp (°F)"
        CureChart.ChartAreas(0).AxisY.Minimum = 0
        'CureChart.ChartAreas(0).AxisY.Maximum = 400
        CureChart.ChartAreas(0).AxisY.Interval = 40
        CureChart.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        CureChart.ChartAreas(0).AxisY.MinorGrid.Interval = 20
        CureChart.ChartAreas(0).AxisY.MinorGrid.Enabled = True

        CureChart.ChartAreas(0).AxisX.Title = "Time (min)"
        CureChart.ChartAreas(0).AxisX.Minimum = 0
        CureChart.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount

        'CureChart.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        'CureChart.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary
        ''CureChart.Series(0).LegendText = "Temp"
        'CureChart.Series(0).MarkerSize = 10
        'CureChart.Series(0).MarkerSize = 100

        CureChart.Titles.Add("Cure Profiles for Parts")

    End Sub 'Intialize Cure Chart

    Private Sub BtnAddPartRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPart.Click
        Call UpdatePartNumberComboList() ' this just handles the case where a new recipe was added since the program was started
        RemoveHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
        DGVPart.Rows.Add()
        AddHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
    End Sub 'Add Row

    Private Sub BtnDeletePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeletePart.Click
        If DGVPart.SelectedCells.Count <> 0 Then
            If DGVPart.CurrentRow.Cells(0).Tag IsNot Nothing Then
                CurrentCureDevice.RemovePart(DGVPart.CurrentRow.Cells(0).Tag)

                DGVPart.CurrentRow.Cells(0).Tag = Nothing
            End If

            DGVPart.Rows.Remove(DGVPart.SelectedCells(0).OwningRow) 'only deletes one row, but the user can figure this out
        End If
        If DGVPart.Rows.Count = 0 Then
            ClearCureInformationChart()
            InitializeDGVCureInformation()
        End If

    End Sub 'Delete Row

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DGVPart.Rows.Clear()
    End Sub 'Clear All Rows from Parts List

    Private Sub ClearCureInformationChart()
        For i As UShort = 0 To CureChart.Series.Count - 1
            CureChart.Series(i).Points.Clear()
        Next i
    End Sub

    Private Sub UpdateCureInformationTable(PartToUpdate As Part)
        If PartToUpdate.CureCycle Is Nothing Or PartToUpdate.PreheatTemperature Is Nothing Then
            Call InitializeDGVCureInformation()
            Call ClearCureInformationChart()
        Else

            ' CurrentCureDevice.AddParts(PartToUpdate)
            Call ClearDGVCureInformation()
            Call ClearCureInformationChart()

            If PartToUpdate.PreheatTemperature.Nominal Then
                DGVCureInformation.Rows.Add()
                DGVCureInformation.Rows(0).Cells(0).Value = "Preheat"
                DGVCureInformation.Rows(0).Cells(1).Value = $"{PartToUpdate.PreheatTemperature.Nominal}°F, {PartToUpdate.PreheatTime.Nominal} min minimum"
            Else

                DGVCureInformation.Rows.Add()
                DGVCureInformation.Rows(0).Cells(0).Value = "Preheat"
                DGVCureInformation.Rows(0).Cells(1).Value = "No Preheat Required"
            End If

            Dim IntSegment As Integer = 1 'Cure segment no.
            For Each CureSegment As Segment In PartToUpdate.CureCycle.Segments
                Dim SegType As String = CureSegment.SegType

                If SegType.Contains("Ramp") Then

                    DGVCureInformation.Rows.Add()
                    DGVCureInformation.Rows(DGVCureInformation.Rows.Count - 1).Cells(0).Value = "Cure Seg " + IntSegment.ToString
                    DGVCureInformation.Rows(DGVCureInformation.Rows.Count - 1).Cells(1).Value =
                            $"Ramp {CureSegment.Rate.Nominal} °F/min, min {CureSegment.Rate.Low}, max {CureSegment.Rate.High}"
                Else
                    If SegType.Contains("Soak") Then

                        DGVCureInformation.Rows.Add()
                        DGVCureInformation.Rows(DGVCureInformation.Rows.Count - 1).Cells(0).Value = "Cure Seg " + IntSegment.ToString
                        DGVCureInformation.Rows(DGVCureInformation.Rows.Count - 1).Cells(1).Value =
                            $"Soak {CureSegment.Temperature.Nominal}°F, min {CureSegment.Temperature.Low}°F, max {CureSegment.Temperature.High}°F, {CureSegment.Time.Nominal} minutes"
                    Else
                        If SegType.Contains("End") Then
                            DGVCureInformation.Rows.Add()
                            DGVCureInformation.Rows(DGVCureInformation.Rows.Count - 1).Cells(0).Value = "Cure Seg " + IntSegment.ToString
                            DGVCureInformation.Rows(DGVCureInformation.Rows.Count - 1).Cells(1).Value = $"End {CureSegment.Temperature.Nominal}°F"
                        End If
                    End If
                End If

                IntSegment += 1
            Next

            ' UpdateCureChart(PartToUpdate)
            Call UpdateCureChart()
        End If
    End Sub 'Update Part Requirements Fields

    Private Sub UpdateCureChart()
        CureChart.Series.Clear()
        Dim counter = 0
        For Each PartToUpdate As Part In CurrentCureDevice.Parts
            CureChart.Series.Add(counter.ToString)
            CureChart.Series(counter).ChartType = DataVisualization.Charting.SeriesChartType.Line
            CureChart.Series(counter).XAxisType = DataVisualization.Charting.AxisType.Primary
            CureChart.Series(counter).MarkerSize = 10
            CureChart.Series(counter).MarkerSize = 100
            For i As Integer = 0 To PartToUpdate.CureCycle.CriticalPoints.CriticalTimes.Count - 1
                Dim x = PartToUpdate.CureCycle.CriticalPoints.CriticalTimes(i)
                Dim y As Integer = PartToUpdate.CureCycle.CriticalPoints.CriticalTemperatures(i)
                CureChart.Series(counter).Points.AddXY(x, y)
            Next
            counter += 1
        Next
    End Sub

    Private Sub Btn_LoggingOn()
        CurrentCureDevice.ResetTemperatureLogTime()
        ClearTempChart()
        Call CurrentCureDevice.TemperatureLoggingOn()
        Call ClearTempChart()
        BtnPreheat.Enabled = False
        If CurrentCureDevice.Status = "Cure in Progress" Then
            BtnCure.Enabled = True
        Else
            BtnCure.Enabled = False
        End If
        DGVPart.Enabled = False
        BtnAddPart.Enabled = False
        BtnDeletePart.Enabled = False
        BtnClearChart.Enabled = False
        BtnLog.Tag = "On"
        BtnLog.Text = "End Temperature Log"
        BtnLog.BackColor = Color.Red
        TmrTempLogLight.Enabled = True
        TxtStatus.Text = CurrentCureDevice.Status
        TxtLogStatus.Text = "Logging..."
    End Sub

    Private Sub Btn_LoggingOff()
        Call CurrentCureDevice.TemperatureLoggingOff()
        TmrTempLogLight.Enabled = False
        ChkTemp.Checked = False
        DGVPart.Enabled = True
        BtnPreheat.Enabled = True
        BtnAddPart.Enabled = True
        BtnDeletePart.Enabled = True
        BtnCure.Enabled = True
        BtnClearChart.Enabled = True
        BtnLog.Tag = "Off"
        BtnLog.Text = "Start Temperature Log"
        BtnLog.BackColor = Color.Lime
        TxtStatus.Text = CurrentCureDevice.Status
        TxtLogStatus.Text = "Not Logging"
        For Each _part In CurrentCureDevice.Parts
            If _part.CureLog IsNot Nothing Then
                Call AddCureLog(_part)
            End If
        Next
    End Sub

    Private Sub AddCureLog(_part As Part)
        If DGVCureLogs.Rows.Count > 0 Then
            For Each _row As DataGridViewRow In DGVCureLogs.Rows
                If _row.Cells(1).Value = _part.PartNumber And _row.Cells(2).Value = _part.JobNumber Then
                    DGVCureLogs.Rows.Remove(_row)
                End If
            Next
        End If
        AddRowToCureLogs(_part)
    End Sub

    Private Sub AddRowToCureLogs(_part As Part)
        Dim cureLogFilename As String = $"{_part.PartNumber}_{_part.JobNumber}.xlsx"
        Dim index = DGVCureLogs.Rows.Add(_part.CureLog.Records.Last.Date.ToShortDateString, _part.PartNumber, _part.JobNumber, cureLogFilename)
        DGVCureLogs.Rows(index).Tag = cureLogFilename ' remove when excel logs are no longer used
        'DGVCureLogs.Rows(index).Tag = $"{_part.TemperatureLogFilepath}\{_part.CureLogFilename}" 
    End Sub

    Private Function IsInvalidInput() As Boolean
        Dim IsMissingRequirement As Boolean = False
        If DGVPart.RowCount > 0 Then
            For Each row As DataGridViewRow In DGVPart.Rows
                If (row.Cells(0).Value.ToString = "") Or (row.Cells(1).Value.ToString = "") Then 'check for part number and job number. Serial number is not required.
                    IsMissingRequirement = True
                Else
                    IsMissingRequirement = False
                End If
            Next
        Else
            IsMissingRequirement = True
        End If
        Return IsMissingRequirement
    End Function 'Checks User Entries Returns True if error

    Private Sub TmrLogTempLightTick()
        If ChkTemp.Checked = False Then
            ChkTemp.Checked = True
        Else
            ChkTemp.Checked = False
        End If
    End Sub 'Logging Light Tick

    Private Sub BtnLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLog.Click
        Dim IsMissingRequirement As Boolean = IsInvalidInput()
        If IsMissingRequirement = False Then
            If BtnLog.Tag = "On" Then
                Call Btn_LoggingOff()
            Else
                Call Btn_LoggingOn()
            End If
        Else
            MsgBox("Please enter a valid Part, Serial, And Job Number before starting a log.")
        End If
    End Sub 'Log Button Click

    Private Sub BtnPreheat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreheat.Click

        If BtnPreheat.Tag = "On" Then
            Btn_PreheatOff()
        Else
            Dim IsMissingRequirement As Boolean = IsInvalidInput()
            If IsMissingRequirement = True Then
                MsgBox("Please ensure part information Is entered properly.")
                Exit Sub
            End If
            Btn_PreheatOn()
        End If
    End Sub 'Preheat Button

    Private Sub Btn_PreheatOn()
        CurrentCureDevice.StartPreheat()
        BtnPreheat.Tag = "On"
        BtnLog.Enabled = False
        BtnAddPart.Enabled = False
        BtnDeletePart.Enabled = False
        BtnPreheat.Text = "Stop Preheat"
        BtnPreheat.BackColor = Color.Red
        TxtStatus.Text = CurrentCureDevice.Status
        MsgBox("Preheat setpoint sent to temperature controller. Press 'Start Cure' when you're ready to run the curing program.")
    End Sub

    Private Sub Btn_PreheatOff()
        CurrentCureDevice.StopPreheat()
        BtnPreheat.Tag = "Off"
        ToolTip1.SetToolTip(BtnDeletePart, "Parts may not be deleted while log is in progress.")
        ToolTip1.SetToolTip(DGVPart, "Parts may not be deleted while log is in progress.")
        BtnAddPart.Enabled = True
        BtnLog.Enabled = True
        BtnDeletePart.Enabled = True
        TxtStatus.Text = CurrentCureDevice.Status
        BtnPreheat.Text = "Start Preheat"
        BtnPreheat.BackColor = Color.Lime
        MsgBox("Controller setpoint set to room temperature.")
    End Sub

    Private Sub BtnCure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCure.Click
        Dim IsMissingRequirement As Boolean = Me.IsInvalidInput()
        If IsMissingRequirement = False Then
            If Not CurrentCureDevice.Status = "Cure in Progress" Then
                Btn_CureOn()
            Else
                Btn_CureOff()
            End If
        Else
            MsgBox("Please ensure part information is entered properly.")
        End If
    End Sub 'Cure Button

    Private Sub Btn_CureOn()
        Call CurrentCureDevice.StartCure()
        TmrTempLogLight.Enabled = True
        Call ClearTempChart()
        TxtStatus.Text = CurrentCureDevice.Status

        BtnCure.Tag = "On"
        BtnCure.Text = "End Cure"
        BtnCure.BackColor = Color.Red

        BtnPreheat.Enabled = False

        BtnLog.Enabled = False
        BtnLog.BackColor = Color.Red
        BtnLog.Text = "Logging"
        TxtLogStatus.Text = "Logging..."

        BtnAddPart.Enabled = False

        BtnDeletePart.Enabled = False

        BtnClearChart.Enabled = False
    End Sub

    Private Sub Btn_CureOff()
        Call CurrentCureDevice.EndCure()
        TmrTempLogLight.Enabled = False
        TxtStatus.Text = CurrentCureDevice.Status

        BtnCure.Tag = "Off"
        BtnCure.Text = "Start Cure"
        BtnCure.BackColor = Color.Lime

        BtnPreheat.Enabled = True

        BtnLog.Enabled = True
        BtnLog.BackColor = Color.Lime
        BtnLog.Text = "Start Temperature Log"
        TxtLogStatus.Text = "Not Logging"

        BtnDeletePart.Enabled = True

        BtnAddPart.Enabled = True


        BtnClearChart.Enabled = True

        For Each _part In CurrentCureDevice.Parts
            If _part.CureLog IsNot Nothing Then
                Call AddCureLog(_part)
            End If
        Next
    End Sub

    Private Sub DGVPart_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVPart.SelectionChanged
        If DGVPart.Rows.Count > 0 Then
            If Not IsNothing(DGVPart.CurrentRow.Cells(0).Tag) Then
                UpdateCureInformationTable(DGVPart.CurrentRow.Cells(0).Tag)
            End If
        End If
    End Sub

    Private Sub DGVPart_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVPart.CellValidating
        'Allow user to enter new values for all DataGridViewComboBox controls in the DataGridView
        If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = cmb.Text
                '// Add value to list if not there
                If cmb.Items.IndexOf(value) = -1 Then
                    '// Must add to both the current combobox as well as the template, to avoid duplicate entries...
                    cmb.Items.Add(value)
                    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                    If cmbCol IsNot Nothing Then
                        cmbCol.Items.Add(value)
                    End If
                End If
                grid.CurrentCell.Value = value
            End If
        End If

    End Sub

    Private Sub DGVPart_EditingControlShowing_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGVPart.EditingControlShowing
        'Allow user to enter new values for ALL DataGridViewComboBox controls in the DataGridView
        If (TypeOf e.Control Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            If cmb IsNot Nothing Then
                cmb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
    End Sub

    Private Sub BtnClearChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearChart.Click
        CurrentCureDevice.ResetTemperatureLogTime()
        ClearTempChart()
    End Sub 'Clear Chart Button

    Private Sub ClearTempChart()
        For i As UShort = 0 To TemperatureLogChart.Series.Count - 1
            TemperatureLogChart.Series(i).Points.Clear()
        Next i
    End Sub

    Private Sub BtnViewSelectedLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewSelectedLog.Click
        If DGVCureLogs.CurrentRow IsNot Nothing Then
            Dim _file As String = $"{FrmMain.cureLogBaseDirectory}\{CurrentCureDevice.Name}\{DGVCureLogs.CurrentRow.Tag.ToString}"
            If File.Exists(_file) Then
                System.Diagnostics.Process.Start(_file)
            Else
                MsgBox($"Could not find {_file}.")
            End If
        End If
    End Sub

    Private Sub BtnPrintSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintSelectedLog.Click
        If DGVCureLogs.CurrentRow IsNot Nothing Then
            Dim _file As String = $"{FrmMain.cureLogBaseDirectory}\{CurrentCureDevice.Name}\{DGVCureLogs.CurrentRow.Tag.ToString}"
            If File.Exists(_file) Then
                Dim _MyProcess As New Process
                _MyProcess.StartInfo.CreateNoWindow = False
                _MyProcess.StartInfo.Verb = "print"
                _MyProcess.StartInfo.FileName = _file
                _MyProcess.Start()
                _MyProcess.Close()
                _MyProcess = Nothing
            Else
                MsgBox($"Could not print {_file}. File may have been moved to another location or disk is full.")
            End If
        End If
    End Sub

    Private Sub DGVPart_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPart.CellContentClick
        If DGVPart.Rows.Count > 0 Then
            If DGVPart.CurrentCell.ColumnIndex = 3 AndAlso DGVPart.CurrentRow.Cells(0).Value IsNot Nothing Then 'prevents null pointer select part number first
                'Dim PartToAttachThermocouplesTo As Part
                If Not IsNothing(DGVPart.CurrentRow.Cells(0).Tag) Then
                    Dim PartNumberCell = DGVPart.CurrentRow.Cells(0)
                    Dim PartToAttachThermocouplesTo As Part = PartNumberCell.Tag
                    Dim ThermocoupleForm As New OvenThermocouples(PartToAttachThermocouplesTo, CurrentCureDevice)
                    Dim result = ThermocoupleForm.ShowDialog()
                    If result = DialogResult.OK Then
                        Me.ClmAttachedThermocouples.UseColumnTextForButtonValue = False
                        Me.DGVPart.CurrentCell.Value = PartToAttachThermocouplesTo.ListOfTCsAsString()
                        ThermocoupleForm.Dispose()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DGVPart_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGVPart.DataError

    End Sub 'Copy Paste Correction

    Private Sub DGVPart_ClearThermocoupleCell()
        DGVPart.CurrentRow.Cells(3).Value = "Select"
    End Sub

    Private Sub DGVPart_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPart.CellValueChanged
        If DGVPart.RowCount > 0 Then
            Dim PartNumberCell = DGVPart.CurrentRow.Cells(0)
            Dim JobNumberCell = DGVPart.CurrentRow.Cells(1)
            Dim SerialNumberCell = DGVPart.CurrentRow.Cells(2)
            Try
                If PartNumberCell.Value = String.Empty And DGVPart.CurrentCell.ColumnIndex = 0 Then
                    MsgBox("Part number cannot be blank. Press the delete part button and start again.")
                    RemoveHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
                    CurrentCureDevice.RemovePart(PartNumberCell.Tag)
                    PartNumberCell.Tag = Nothing
                    JobNumberCell.Value = String.Empty
                    SerialNumberCell.Value = String.Empty
                    AddHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
                    DGVPart.Rows.Remove(DGVPart.CurrentCell.OwningRow)
                    DGVPart_ClearThermocoupleCell()
                    ClearDGVCureInformation()


                ElseIf DGVPart.CurrentCell.ColumnIndex = 0 Then
                    RemoveHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
                    DGVPart.CurrentCell.ReadOnly = True
                    PartNumberCell.Tag = Nothing
                    JobNumberCell.Value = String.Empty
                    SerialNumberCell.Value = String.Empty
                    DGVPart_ClearThermocoupleCell()
                    ClearDGVCureInformation()
                    PartNumberCell.Tag = CurrentCureDevice.AddPart(PartNumberCell.Value)
                    AddHandler DGVPart.CellValueChanged, AddressOf DGVPart_CellValueChanged
                ElseIf DGVPart.CurrentCell.ColumnIndex = 1 Then
                    PartNumberCell.Tag.JobNumber = JobNumberCell.Value
                ElseIf DGVPart.CurrentCell.ColumnIndex = 2 Then
                    PartNumberCell.Tag.SerialNumber = SerialNumberCell.Value
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtSetpoint_MouseClick(sender As Object, e As MouseEventArgs) Handles TxtSetpoint.MouseClick
        Dim StrSetpoint As String = InputBox("Enter the desired setpoint temperature (°F).")
        If IsNumeric(StrSetpoint) Then
            Dim ParsedSetpoint = Single.Parse(StrSetpoint)
            TxtSetpoint.Text = StrSetpoint
            Call CurrentCureDevice.ChangeControllerSetpoint(ParsedSetpoint)
            MsgBox("Sending new setpoint to controller.")
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        If RadioButton2.Checked Then
            ComboBoxRecipe.Enabled = True
            ComboBoxRecipe.Show()
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        If RadioButton1.Checked Then
            ComboBoxRecipe.Enabled = True
            ComboBoxRecipe.Hide()
            RadioButton2.Checked = False
        End If
    End Sub
End Class
