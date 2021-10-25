Imports System.IO
Imports System.Math


Public Class FrmPartRecipeSetup
    Public ChkSeg(9) As System.Windows.Forms.CheckBox
    Public TxtSp(9) As System.Windows.Forms.TextBox
    Public TxtSpl(9) As System.Windows.Forms.TextBox
    Public TxtSph(9) As System.Windows.Forms.TextBox
    Public TxtTime(9) As System.Windows.Forms.TextBox
    Public TxtTimeL(9) As System.Windows.Forms.TextBox
    Public TxtTimeH(9) As System.Windows.Forms.TextBox
    Public CboSegType(9) As ComboBox
    Public LblSp(9) As System.Windows.Forms.Label
    Public LblSpL(9) As System.Windows.Forms.Label
    Public LblSpH(9) As System.Windows.Forms.Label
    Public LblTime(9) As System.Windows.Forms.Label
    Public LblTimeL(9) As System.Windows.Forms.Label
    Public LblTimeH(9) As System.Windows.Forms.Label
    Public SegmentCount As Integer = 0 'Number of Activated Segments

    Private Sub FrmPartRecipeSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupControlArrays()
        Call UpdateStationList()
        Call InitializeChart()

        'Update Ramp/Soak/End Comboboxes
        For Each s As ComboBox In CboSegType
            s.Items.Add("Ramp Up")
            s.Items.Add("Ramp Down")
            s.Items.Add("Soak")
            s.Items.Add("End")
            s.SelectedIndex = 0
        Next
    End Sub 'Form Load

    Private Sub FrmPartRecipeSetup_Closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closing
        Me.Dispose()
    End Sub 'Form Closing

    Private Sub SetupControlArrays()
        ' Control Array Setup
        CboSegType(0) = cbo1
        CboSegType(1) = cbo2
        CboSegType(2) = cbo3
        CboSegType(3) = cbo4
        CboSegType(4) = cbo5
        CboSegType(5) = cbo6
        CboSegType(6) = cbo7
        CboSegType(7) = cbo8
        CboSegType(8) = cbo9
        CboSegType(9) = cbo10

        'Checkbox Array Initialization
        ChkSeg(0) = CheckBox1
        ChkSeg(1) = CheckBox2
        ChkSeg(2) = CheckBox3
        ChkSeg(3) = CheckBox4
        ChkSeg(4) = CheckBox5
        ChkSeg(5) = CheckBox6
        ChkSeg(6) = CheckBox7
        ChkSeg(7) = CheckBox8
        ChkSeg(8) = CheckBox9
        ChkSeg(9) = CheckBox10

        'Setpoint Nominal Control Array Initialization
        TxtSp(0) = txtsp1
        TxtSp(1) = txtsp2
        TxtSp(2) = txtsp3
        TxtSp(3) = txtsp4
        TxtSp(4) = txtsp5
        TxtSp(5) = txtsp6
        TxtSp(6) = txtsp7
        TxtSp(7) = txtsp8
        TxtSp(8) = txtsp9
        TxtSp(9) = txtsp10

        'Setpoint LOW Control Array Initialization
        TxtSpl(0) = txtspl1
        TxtSpl(1) = txtspl2
        TxtSpl(2) = txtspl3
        TxtSpl(3) = txtspl4
        TxtSpl(4) = txtspl5
        TxtSpl(5) = txtspl6
        TxtSpl(6) = txtspl7
        TxtSpl(7) = txtspl8
        TxtSpl(8) = txtspl9
        TxtSpl(9) = txtspl10

        'Setpoint HIGH Control Array Initialization
        TxtSph(0) = txtsph1
        TxtSph(1) = txtsph2
        TxtSph(2) = txtsph3
        TxtSph(3) = txtsph4
        TxtSph(4) = txtsph5
        TxtSph(5) = txtsph6
        TxtSph(6) = txtsph7
        TxtSph(7) = txtsph8
        TxtSph(8) = txtsph9
        TxtSph(9) = txtsph10


        'Time Nominal Control Array Initialization
        TxtTime(0) = txttime1
        TxtTime(1) = txttime2
        TxtTime(2) = txttime3
        TxtTime(3) = txttime4
        TxtTime(4) = txttime5
        TxtTime(5) = txttime6
        TxtTime(6) = txttime7
        TxtTime(7) = txttime8
        TxtTime(8) = txttime9
        TxtTime(9) = txttime10

        'Time Low Control Array Initialization
        TxtTimeL(0) = txttimel1
        TxtTimeL(1) = txttimel2
        TxtTimeL(2) = txttimel3
        TxtTimeL(3) = txttimel4
        TxtTimeL(4) = txttimel5
        TxtTimeL(5) = txttimel6
        TxtTimeL(6) = txttimel7
        TxtTimeL(7) = txttimel8
        TxtTimeL(8) = txttimel9
        TxtTimeL(9) = txttimel10

        'Time HIGH Control Array Initialization
        TxtTimeH(0) = txttimeh1
        TxtTimeH(1) = txttimeh2
        TxtTimeH(2) = txttimeh3
        TxtTimeH(3) = txttimeh4
        TxtTimeH(4) = txttimeh5
        TxtTimeH(5) = txttimeh6
        TxtTimeH(6) = txttimeh7
        TxtTimeH(7) = txttimeh8
        TxtTimeH(8) = txttimeh9
        TxtTimeH(9) = txttimeh10

        'Setpoint Label Control Array Intitialization
        LblSp(0) = lbl11
        LblSp(1) = Lbl21
        LblSp(2) = Lbl31
        LblSp(3) = Lbl41
        LblSp(4) = Lbl51
        LblSp(5) = Lbl61
        LblSp(6) = Lbl71
        LblSp(7) = Lbl81
        LblSp(8) = Lbl91
        LblSp(9) = Lbl101

        'Setpoint Low Label Control Array Intitialization
        LblSpL(0) = Lbl12
        LblSpL(1) = Lbl22
        LblSpL(2) = Lbl32
        LblSpL(3) = Lbl42
        LblSpL(4) = Lbl52
        LblSpL(5) = Lbl62
        LblSpL(6) = Lbl72
        LblSpL(7) = Lbl82
        LblSpL(8) = Lbl92
        LblSpL(9) = Lbl102

        'Setpoint High Label Control Array Intitialization
        LblSpH(0) = Lbl13
        LblSpH(1) = Lbl23
        LblSpH(2) = Lbl33
        LblSpH(3) = Lbl43
        LblSpH(4) = Lbl53
        LblSpH(5) = Lbl63
        LblSpH(6) = Lbl73
        LblSpH(7) = Lbl83
        LblSpH(8) = Lbl93
        LblSpH(9) = Lbl103

        'Time Lable Control Array Initialization
        LblTime(0) = Lbl14
        LblTime(1) = Lbl24
        LblTime(2) = Lbl34
        LblTime(3) = Lbl44
        LblTime(4) = Lbl54
        LblTime(5) = Lbl64
        LblTime(6) = Lbl74
        LblTime(7) = Lbl84
        LblTime(8) = Lbl94
        LblTime(9) = Lbl104

        'Time Low Lable Control Array Initialization
        LblTimeL(0) = Lbl15
        LblTimeL(1) = Lbl25
        LblTimeL(2) = Lbl35
        LblTimeL(3) = Lbl45
        LblTimeL(4) = Lbl55
        LblTimeL(5) = Lbl65
        LblTimeL(6) = Lbl75
        LblTimeL(7) = Lbl85
        LblTimeL(8) = Lbl95
        LblTimeL(9) = Lbl105

        'Time High Lable Control Array Initialization
        LblTimeH(0) = Lbl16
        LblTimeH(1) = Lbl26
        LblTimeH(2) = Lbl36
        LblTimeH(3) = Lbl46
        LblTimeH(4) = Lbl56
        LblTimeH(5) = Lbl66
        LblTimeH(6) = Lbl76
        LblTimeH(7) = Lbl86
        LblTimeH(8) = Lbl96
        LblTimeH(9) = Lbl106
    End Sub 'Sets up all control arrays

    Private Sub UpdateStationList() 'Finds all available Stations and adds to listbox
        Dim DirInfo As New IO.DirectoryInfo($"{FrmMain.baseDirectory}\Data\Curing Devices")
        Dim Dir1 As IO.FileInfo() = DirInfo.GetFiles()
        For Each D As IO.FileInfo In Dir1
            If D.ToString.Contains(".csf") Then
                lstavailablestations.Items.Add(frmmain.SplitString(D.ToString, ".", 0))
            End If
        Next
    End Sub 'Updates the List box with all available curing devices

    Private Sub InitializeChart()
        'Setting Chart Properties
        Chart1.Titles.Add("Cure Cycle: Temperature vs. Time")
        Chart1.Titles(0).Font = New System.Drawing.Font(Chart1.Titles(0).Font, FontStyle.Bold)

        Chart1.ChartAreas(0).AxisX.Title = "Time (min)"
        Chart1.ChartAreas(0).AxisY.Title = "Temperature (°F)"
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = True
        Chart1.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = True
        Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray


        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        Chart1.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MinorGrid.Interval = 25
        Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = True
        Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.Interval = 50
        Chart1.ChartAreas(0).AxisY.Maximum = 400
        Chart1.ChartAreas(0).AxisY.Minimum = 0


        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary
        Chart1.Series(0).LegendText = "Cure Cycle"
        Chart1.Series(0).MarkerSize = 1
    End Sub 'Initializes Cure Chart titles ...etc

    Private Sub UpdateChart()
        Dim BoolCheckPreheat As Boolean = Me.CheckPreheatEntries()
        If BoolCheckPreheat = True Then
            MsgBox("Please ensure preheat parameters are entered properly.")
            Exit Sub
        End If

        Dim BoolCheckCycle As Boolean = Me.CheckCureCycleEntries()
        If BoolCheckCycle = True Then
            MsgBox("Please ensure all cure cycle parameters are entered properly.")
            Exit Sub
        End If

        'Gets All Critical Points
        Dim IntCriticalPoints(SegmentCount, SegmentCount)
        IntCriticalPoints(0, 0) = 0
        If chkusepreheat.Checked = False Then
            IntCriticalPoints(0, 1) = 125
        Else
            IntCriticalPoints(0, 1) = Val(txtpreheat.Text)
        End If
        For i As Integer = 0 To SegmentCount - 1
            If CboSegType(i).SelectedIndex = 0 Then 'Ramp Up Segment
                IntCriticalPoints(i + 1, 1) = Val(TxtSp(i + 1).Text)
                IntCriticalPoints(i + 1, 0) = Int((IntCriticalPoints(i + 1, 1) - IntCriticalPoints(i, 1)) / Val(TxtSp(i).Text)) _
                + IntCriticalPoints(i, 0)
            End If
            If CboSegType(i).SelectedIndex = 1 Then 'Ramp Down Segment
                IntCriticalPoints(i + 1, 1) = Val(TxtSp(i + 1).Text)
                IntCriticalPoints(i + 1, 0) = Int(Abs(Int((IntCriticalPoints(i + 1, 1) - IntCriticalPoints(i, 1)) / Val(TxtSp(i).Text))) _
                + IntCriticalPoints(i, 0))
            End If
            If CboSegType(i).SelectedIndex = 2 Then 'Soak Segment
                IntCriticalPoints(i + 1, 1) = Val(TxtSp(i).Text)
                IntCriticalPoints(i + 1, 0) = IntCriticalPoints(i, 0) + Val(TxtTime(i).Text)
            End If

            'MsgBox("Critical Points: " + IntCriticalPoints(i, 0).ToString + "," + IntCriticalPoints(i, 1).ToString)
        Next

        'Graph Points
        Chart1.Series(0).Points.Clear()
        For j = 0 To SegmentCount - 1
            Chart1.Series(0).Points.AddXY(IntCriticalPoints(j, 0), IntCriticalPoints(j, 1))
        Next

    End Sub 'Updates Cure Cycle Chart

    Private Function CheckPidEntries() As Boolean
        Dim CheckString(9) As String
        CheckString(0) = txtpb1.Text
        CheckString(1) = txtreset1.Text
        CheckString(2) = txtderiv1.Text
        CheckString(3) = txtdb1.Text
        CheckString(4) = txthys1.Text
        CheckString(5) = txtpb2.Text
        CheckString(6) = txtreset2.Text
        CheckString(7) = txtderiv2.Text
        CheckString(8) = txtdb2.Text
        CheckString(9) = txthys2.Text
        Dim BoolCheck As Boolean = frmmain.CheckIntegerValue(CheckString)
        If BoolCheck = False Then
            Return True
        Else
            Return False
        End If
    End Function 'Checks PID Entries, returns true if error

    Private Function CheckPartInfo() As Boolean
        Dim result As Boolean = True
        If Not InvalidPartNumber() And Not InvalidPartName() And Not lststations.Items.Count < 1 Then
            result = False
        End If
        Return result
    End Function 'Checks Part Information Entries, Returns true if error

    Private Function InvalidPartName() As Boolean
        Dim result As Boolean = False
        If txtpartname.Text = "" Then
            MsgBox($"Part name can't be empty. {Environment.NewLine}Copy the part description from the routing.")
            result = True
        End If
        Return result
    End Function

    Private Function InvalidPartNumber() As Boolean
        If Not txtpartnumber.Text = "" Then
            If Not txtpartnumber.Text.Contains("_") Then
                Return False
            End If
        Else
            MsgBox("Problem with the part number. Underscores are not allowed.")
            Return True
        End If
    End Function

    Private Function CheckPreheatEntries() As Boolean
        If chkusepreheat.Checked = False Then
            MsgBox("Preheat not Checked")
            Return False
        Else
            Dim CheckString(3) As String
            CheckString(0) = txtpreheat.Text
            CheckString(1) = txtpreheath.Text
            CheckString(2) = txtpreheatl.Text
            CheckString(3) = txtpreheattime.Text
            Dim BoolCheck As Boolean = frmmain.CheckIntegerValue(CheckString)
            If BoolCheck = False Then
                Return True
            Else
                If Val(txtpreheath.Text) > Val(txtpreheat.Text) Then
                    If Val(txtpreheatl.Text) < Val(txtpreheat.Text) Then
                        Return False
                    End If
                End If
            End If
        End If
        Return True
    End Function 'Check Preheat Entries Return True if error

    Private Function CheckCureCycleEntries()
        For i As Integer = 0 To SegmentCount - 1
            If CboSegType(i).SelectedIndex < 2 Then
                Dim BoolCheckRamp = Me.CheckRampSegment(i)
                If BoolCheckRamp = True Then
                    MsgBox("Entry error in Ramp segment " + i.ToString + ". Cannot update chart")
                    Return True
                End If
            End If
            If CboSegType(i).SelectedIndex = 2 Then
                Dim BoolCheckSoak = Me.CheckSoakSegment(i)
                If BoolCheckSoak = True Then
                    MsgBox("Entry error in Soak segment " + i.ToString + ". Cannot update chart")
                    Return True
                End If
            End If
            If CboSegType(i).SelectedIndex = 3 Then
                Dim BoolCheckEnd = Me.CheckEndSegment(i)
                If BoolCheckEnd = True Then
                    MsgBox("Entry error in End segment " + i.ToString + ". Cannot update chart")
                    Return True
                End If
            End If
        Next
        If Not CboSegType(SegmentCount - 1).SelectedIndex = 3 Then
            MsgBox("Ensure last segment is of type End")
            Return True
        End If

        Return False
    End Function 'Checks Cure cycle entries Returns true for error

    Private Function CheckRampSegment(ByVal IntIndex As Integer) As Boolean
        Dim StrCheck(2) As String
        StrCheck(0) = TxtSp(IntIndex).Text
        StrCheck(1) = TxtSpl(IntIndex).Text
        StrCheck(2) = TxtSph(IntIndex).Text
        Dim BoolCheck As Boolean = frmmain.CheckIntegerValue(StrCheck)
        If BoolCheck = True Then
            If Val(TxtSph(IntIndex).Text) > Val(TxtSp(IntIndex).Text) Then
                If Val(TxtSpl(IntIndex).Text) <= Val(TxtSp(IntIndex).Text) Then
                    If CboSegType(IntIndex + 1).SelectedIndex = 2 Or CboSegType(IntIndex + 1).SelectedIndex = 3 Then
                        Return False
                    End If
                End If
            End If
        End If
        Return True
    End Function 'Checks Ramp Up Segment Returns True if Error

    Private Function CheckRampDownSegment(ByVal IntIndex As Integer) As Boolean
        Dim StrCheck(2) As String
        StrCheck(0) = TxtSp(IntIndex).Text
        StrCheck(1) = TxtSpl(IntIndex).Text
        StrCheck(2) = TxtSph(IntIndex).Text
        Dim BoolCheck As Boolean = frmmain.CheckIntegerValue(StrCheck)
        If BoolCheck = True Then
            If Val(TxtSph(IntIndex).Text) > Val(TxtSp(IntIndex).Text) Then
                If Val(TxtSpl(IntIndex).Text) <= Val(TxtSp(IntIndex).Text) Then
                    If CboSegType(IntIndex + 1).SelectedIndex > 1 Then
                        Return False
                    End If
                End If
            End If
        End If
        Return True
    End Function

    Private Function CheckSoakSegment(ByVal IntIndex As Integer) As Boolean
        Dim StrCheck(5) As String
        StrCheck(0) = TxtSp(IntIndex).Text
        StrCheck(1) = TxtSpl(IntIndex).Text
        StrCheck(2) = TxtSph(IntIndex).Text
        StrCheck(3) = TxtTime(IntIndex).Text
        StrCheck(4) = TxtTimeL(IntIndex).Text
        StrCheck(5) = TxtTimeH(IntIndex).Text
        Dim BoolCheck As Boolean = frmmain.CheckIntegerValue(StrCheck)
        If BoolCheck = True Then
            'MsgBox("Entries were integers")
            If Val(TxtSph(IntIndex).Text) > Val(TxtSp(IntIndex).Text) Then
                If Val(TxtSpl(IntIndex).Text) <= Val(TxtSp(IntIndex).Text) Then
                    If Val(TxtTimeH(IntIndex).Text) > Val(TxtTime(IntIndex).Text) Then
                        If Val(TxtTimeL(IntIndex).Text) <= Val(TxtTime(IntIndex).Text) Then
                            'MsgBox("Returned False")
                            Return False
                        End If
                    End If
                End If

            End If
        End If
        Return True
    End Function 'Checks Soak Segment Returns True if Error

    Private Function CheckEndSegment(ByVal IntIndex As Integer) As Boolean
        Dim StrCheck(0) As String
        StrCheck(0) = TxtSp(IntIndex).Text
        Dim BoolCheck As Boolean = frmmain.CheckIntegerValue(StrCheck)
        If BoolCheck = True Then
            Return False
        Else
            Return True
        End If
    End Function 'Checks End Segment Returns True if Error

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If ChkSeg(0).Checked = True Then
            UpdateSegChck(0, True)
        Else
            UpdateSegChck(0, False)
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If ChkSeg(1).Checked = True Then
            UpdateSegChck(1, True)
        Else
            UpdateSegChck(1, False)
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If ChkSeg(2).Checked = True Then
            UpdateSegChck(2, True)
        Else
            UpdateSegChck(2, False)
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If ChkSeg(3).Checked = True Then
            UpdateSegChck(3, True)
        Else
            UpdateSegChck(3, False)
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If ChkSeg(4).Checked = True Then
            UpdateSegChck(4, True)
        Else
            UpdateSegChck(4, False)
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If ChkSeg(5).Checked = True Then
            UpdateSegChck(5, True)
        Else
            UpdateSegChck(5, False)
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If ChkSeg(6).Checked = True Then
            UpdateSegChck(6, True)
        Else
            UpdateSegChck(6, False)
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If ChkSeg(7).Checked = True Then
            UpdateSegChck(7, True)
        Else
            UpdateSegChck(7, False)
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If ChkSeg(8).Checked = True Then
            UpdateSegChck(8, True)
        Else
            UpdateSegChck(8, False)
        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If ChkSeg(9).Checked = True Then
            UpdateSegChck(9, True)
        Else
            UpdateSegChck(9, False)
        End If
    End Sub

    Sub UpdateSegChck(ByVal index As Integer, ByVal checked As Boolean)
        If checked = True Then
            For i = 0 To index
                ChkSeg(i).CheckState = CheckState.Checked
                TxtSp(i).Enabled = True
                TxtSpl(i).Enabled = True
                TxtSph(i).Enabled = True
                TxtTime(i).Enabled = True
                TxtTimeL(i).Enabled = True
                TxtTimeH(i).Enabled = True
                CboSegType(i).Enabled = True
            Next
        Else
            For i = index To 9
                ChkSeg(i).CheckState = CheckState.Unchecked
                TxtSp(i).Enabled = False
                TxtSpl(i).Enabled = False
                TxtSph(i).Enabled = False
                TxtTime(i).Enabled = False
                TxtTimeL(i).Enabled = False
                TxtTimeH(i).Enabled = False
                CboSegType(i).Enabled = False
            Next
            SegmentCount = index
        End If
    End Sub 'Change in Chk Box State

    Sub UpdateSegmentType(ByVal index As Integer, ByVal type As Integer)
        If type < 2 Then 'If Changed to Ramp
            LblSp(index).Text = "Ramp Nom(°/min)"
            LblSpL(index).Text = "Ramp Low(°/min)"
            LblSpH(index).Text = "Ramp High(°/min)"
            TxtTime(index).ReadOnly = True
            TxtTimeL(index).ReadOnly = True
            TxtTimeH(index).ReadOnly = True
            TxtTime(index).Text = ""
            TxtTimeL(index).Text = ""
            TxtTimeH(index).Text = ""
        End If

        If type = 2 Then
            TxtSp(index).ReadOnly = False
            TxtSpl(index).ReadOnly = False
            TxtSph(index).ReadOnly = False
            TxtTime(index).ReadOnly = False
            TxtTimeL(index).ReadOnly = False
            TxtTimeH(index).ReadOnly = False
            LblSp(index).Text = "Nominal Cure (°F)"
            LblSpL(index).Text = "Low Cure (°F)"
            LblSpH(index).Text = "High Cure (°F)"
        End If

        If type = 3 Then
            Call UpdateSegChck(index + 1, False)
            TxtTime(index).ReadOnly = True
            TxtTimeL(index).ReadOnly = True
            TxtTimeH(index).ReadOnly = True
            TxtSp(index).ReadOnly = False
            LblSp(index).Text = "End Setpoint(°F)"
            TxtSpl(index).ReadOnly = True
            TxtSph(index).ReadOnly = True
        End If
    End Sub 'Update Segment Type

    Private Sub Cbo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo1.SelectedIndexChanged
        Call UpdateSegmentType(0, cbo1.SelectedIndex)
    End Sub

    Private Sub Cbo2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo2.SelectedIndexChanged
        Call UpdateSegmentType(1, cbo2.SelectedIndex)
    End Sub

    Private Sub Cbo3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo3.SelectedIndexChanged
        Call UpdateSegmentType(2, cbo3.SelectedIndex)
    End Sub

    Private Sub Cbo4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo4.SelectedIndexChanged
        Call UpdateSegmentType(3, cbo4.SelectedIndex)
    End Sub

    Private Sub Cbo5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo5.SelectedIndexChanged
        Call UpdateSegmentType(4, cbo5.SelectedIndex)
    End Sub

    Private Sub Cbo6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo6.SelectedIndexChanged
        Call UpdateSegmentType(5, cbo6.SelectedIndex)
    End Sub

    Private Sub Cbo7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo7.SelectedIndexChanged
        Call UpdateSegmentType(6, cbo7.SelectedIndex)
    End Sub

    Private Sub Cbo8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo8.SelectedIndexChanged
        Call UpdateSegmentType(7, cbo8.SelectedIndex)
    End Sub

    Private Sub Cbo9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo9.SelectedIndexChanged
        Call UpdateSegmentType(8, cbo9.SelectedIndex)
    End Sub

    Private Sub Cbo10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo10.SelectedIndexChanged
        Call UpdateSegmentType(9, cbo10.SelectedIndex)
    End Sub

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If lststations.Items.Count = 0 Then
            If lstavailablestations.SelectedIndex <> -1 Then
                For x = 0 To lstavailablestations.SelectedIndices.Count - 1
                    lststations.Items.Add(lstavailablestations.SelectedItems(x).ToString)
                Next
            End If
        End If

        If lststations.Items.Count > 0 Then
            If lstavailablestations.SelectedIndex <> -1 Then
                For x = 0 To lstavailablestations.SelectedIndices.Count - 1
                    For y = 0 To lststations.Items.Count - 1
                        If lstavailablestations.GetItemText(lstavailablestations.SelectedItems(x)) = lststations.GetItemText(lststations.Items(y)) Then
                            Exit For
                        ElseIf y = lststations.Items.Count - 1 Then
                            lststations.Items.Add(lstavailablestations.SelectedItems(x).ToString)
                        End If
                    Next
                Next
            End If
        End If

    End Sub 'Add Station To List

    Private Sub Cbodelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbodelete.Click
        If lststations.SelectedIndex <> -1 Then
            While lststations.SelectedItems.Count > 0
                lststations.Items.Remove(lststations.SelectedItem)
            End While
        End If
    End Sub 'Delete From Station List

    Private Sub Chkusepreheat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkusepreheat.CheckedChanged
        If chkusepreheat.Checked = True Then
            txtpreheat.Enabled = True
            txtpreheatl.Enabled = True
            txtpreheath.Enabled = True
            txtpreheattime.Enabled = True
        Else
            txtpreheat.Enabled = False
            txtpreheatl.Enabled = False
            txtpreheath.Enabled = False
            txtpreheattime.Enabled = False
            txtpreheat.Text = ""
            txtpreheatl.Text = ""
            txtpreheath.Text = ""
            txtpreheattime.Text = ""
        End If
    End Sub 'Preheate  Check Change

    Private Sub Btnupdatechart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatechart1.Click
        If Me.SegmentCount > 1 Then
            Call UpdateChart()
        Else
            MsgBox("Ensure segments are entered properly.")
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Call UpdateChart()
        Dim BoolPID As Boolean = Me.CheckPidEntries()
        If BoolPID = True Then
            MsgBox("Please ensure all PID settings are entered properly.")
            Exit Sub
        End If
        Dim BoolPartInfo As Boolean = Me.CheckPartInfo()
        If BoolPartInfo = True Then
            MsgBox("Please ensure part information is entered properly and you have selected a cure device to apply recipe.")
            Exit Sub
        End If
        For i As Integer = 0 To lststations.Items.Count - 1 'Call Create File for each of the names in station list
            Call WritePrfFile(lststations.Items(i).ToString)
        Next

    End Sub  'Save Button

    Private Sub WritePrfFile(ByVal StrCureDevice As String)
        Dim dir As String = $"{FrmMain.baseDirectory}\Data\Part Recipes"
        Dim strpath As String = $"{dir}\{txtpartnumber.Text}_{StrCureDevice}.prf" 'Defines path of file
        If Not Directory.Exists(dir) Then 'Creates a directory if necessary
            Directory.CreateDirectory(dir)
        End If
        'Dim BoolNewStation As Boolean = False
        'If Not File.Exists(strpath) Then 'Checks if station already exists
        ' BoolNewStation = True
        ' End If

        Dim fsettings As New FileStream(strpath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)
        fsettings.Close()
        Dim textout As New StreamWriter(New FileStream(strpath, FileMode.Open, FileAccess.Write))
        textout.WriteLine("Part Name:" + txtpartname.Text)
        textout.WriteLine("Part Number:" + txtpartnumber.Text)
        If chkusepreheat.Checked = True Then
            textout.WriteLine("Use Preheat:" + "True")
            textout.WriteLine("Nominal Preheat Temp:" + txtpreheat.Text + ":")
            textout.WriteLine("Low Preheat Temp:" + txtpreheatl.Text + ":")
            textout.WriteLine("High Preheat Temp:" + txtpreheath.Text + ":")
            textout.WriteLine("Preheat Time:" + txtpreheattime.Text + ":")
        Else
            textout.WriteLine("Use Preheat:" + "False")
            textout.WriteLine("Nominal Preheat Temp:" + " :")
            textout.WriteLine("Low Preheat Temp:" + " :")
            textout.WriteLine("High Preheat Temp:" + " :")
            textout.WriteLine("Preheat Time:" + " :")
        End If

        For k = 0 To 9
            textout.WriteLine("Segment" + k.ToString + "Checked:" + ChkSeg(k).CheckState.ToString + ":")
            textout.WriteLine("Segment" + k.ToString + "Type:" + CboSegType(k).SelectedIndex.ToString + ":")
            If TxtSp(k).Text = "" Then
                TxtSp(k).Text = " "
            End If
            textout.WriteLine("Segment" + k.ToString + "Sp:" + TxtSp(k).Text + ":")
            If TxtSpl(k).Text = "" Then
                TxtSpl(k).Text = " "
            End If
            textout.WriteLine("Segment" + k.ToString + "Low SP:" + TxtSpl(k).Text + ":")
            If TxtSph(k).Text = "" Then
                TxtSph(k).Text = " "
            End If
            textout.WriteLine("Segment" + k.ToString + "High SP:" + TxtSph(k).Text + ":")
            If TxtTime(k).Text = "" Then
                TxtTime(k).Text = " "
            End If
            textout.WriteLine("Segment" + k.ToString + "Time:" + TxtTime(k).Text + ":")
            If TxtTimeL(k).Text = "" Then
                TxtTimeL(k).Text = " "
            End If
            textout.WriteLine("Segment" + k.ToString + "Time Low:" + TxtTimeL(k).Text + ":")
            If TxtTimeH(k).Text = "" Then
                TxtTimeH(k).Text = " "
            End If
            textout.WriteLine("Segment" + k.ToString + "Time High:" + TxtTimeH(k).Text + ":")
        Next
        textout.WriteLine("PropBand1:" + txtpb1.Text)
        textout.WriteLine("Reset1:" + txtreset1.Text)
        textout.WriteLine("Deriv1:" + txtderiv1.Text)
        textout.WriteLine("Deadband1:" + txtdb1.Text)
        textout.WriteLine("Hysteresis1:" + txthys1.Text)
        textout.WriteLine("PropBand2:" + txtpb2.Text)
        textout.WriteLine("Reset2:" + txtreset2.Text)
        textout.WriteLine("Deriv2:" + txtderiv2.Text)
        textout.WriteLine("Deadband2:" + txtdb2.Text)
        textout.WriteLine("Hysteresis2:" + txthys2.Text)

        Dim IntCriticalPoints(SegmentCount, SegmentCount)
        IntCriticalPoints(0, 0) = 0
        If chkusepreheat.Checked = False Then
            IntCriticalPoints(0, 1) = 125
        Else
            IntCriticalPoints(0, 1) = Val(txtpreheat.Text)
        End If
        For i As Integer = 0 To SegmentCount - 1
            If CboSegType(i).SelectedIndex = 0 Then 'Ramp Up Segment
                IntCriticalPoints(i + 1, 1) = Val(TxtSp(i + 1).Text)
                IntCriticalPoints(i + 1, 0) = Int((IntCriticalPoints(i + 1, 1) - IntCriticalPoints(i, 1)) / Val(TxtSp(i).Text)) _
                + IntCriticalPoints(i, 0)
            End If
            If CboSegType(i).SelectedIndex = 1 Then 'Ramp Down Segment
                IntCriticalPoints(i + 1, 1) = Val(TxtSp(i + 1).Text)
                IntCriticalPoints(i + 1, 0) = Int(Abs(Int((IntCriticalPoints(i + 1, 1) - IntCriticalPoints(i, 1)) / Val(TxtSp(i).Text))) _
                + IntCriticalPoints(i, 0))
            End If
            If CboSegType(i).SelectedIndex = 2 Then 'Soak Segment
                IntCriticalPoints(i + 1, 1) = Val(TxtSp(i).Text)
                IntCriticalPoints(i + 1, 0) = IntCriticalPoints(i, 0) + Val(TxtTime(i).Text)
            End If
            'MsgBox("Critical Points: " + IntCriticalPoints(i, 0).ToString + "," + IntCriticalPoints(i, 1).ToString)
        Next

        For j As Integer = 0 To SegmentCount - 1
            textout.WriteLine("Critical Point" + j.ToString + ":" + IntCriticalPoints(j, 0).ToString + ":" + IntCriticalPoints(j, 1).ToString)
        Next
        textout.Close()
        For Each c As CureDevice In FrmMain.CureDevices
            c.TabControl.UpdatePartNumberComboList()
        Next 'Updates Part Numbers List
        MsgBox(strpath + "has been saved.")
    End Sub 'Writes PRF file given the name of the curing device

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            OpenFileDialog1.InitialDirectory = $"{FrmMain.baseDirectory}\Data\Part Recipes\"
            OpenFileDialog1.Title = "Open Cure Device Settings File (.prf)"
            OpenFileDialog1.Filter = "Cure Device Settings Files (*.prf)|*.prf"
            OpenFileDialog1.ShowDialog()
            Dim StrFile As String = OpenFileDialog1.FileName
            If StrFile = "" Then
                MsgBox("Please select a file.")
            End If

            If File.Exists(StrFile) Then
                'MsgBox(StrFile)
                Call ReadPrf(StrFile)

                'Dim boolerr As Boolean = Me.ReadCsf(StrFile)
                'If boolerr = True Then
                ' MsgBox("Error while reading .csf file. File may be currupt or empty. Manually check the file.")
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub 'Open Button

    Private Sub ClearAllEntries()
        txtpartname.Clear()
        txtpartnumber.Clear()

        chkusepreheat.Checked = True

        txtpreheat.Clear()
        txtpreheatl.Clear()
        txtpreheath.Clear()
        txtpreheattime.Clear()

        For i As Integer = 0 To 9
            ChkSeg(i).Checked = False

            CboSegType(i).SelectedIndex = 0
            TxtSp(i).Clear()
            TxtSpl(i).Clear()
            TxtSph(i).Clear()
            TxtTime(i).Clear()
            TxtTimeL(i).Clear()
            TxtTimeH(i).Clear()
        Next
        txtpb1.Clear()
        txtreset1.Clear()
        txtderiv1.Clear()
        txtdb1.Clear()
        txthys1.Clear()
        txtpb2.Clear()
        txtreset2.Clear()
        txtderiv2.Clear()
        txtdb2.Clear()
        txthys2.Clear()

        Dim StrCureDevice As String = ""

    End Sub 'Read Prf and populate form controls

    Private Sub ReadPrf(ByVal StrFile As String)
        Try

            Dim textin As New StreamReader(New FileStream(StrFile, FileMode.Open, FileAccess.Read))
            txtpartname.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtpartnumber.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            If frmmain.SplitString(textin.ReadLine, ":", 1) = "True" Then
                chkusepreheat.Checked = True
            Else
                chkusepreheat.Checked = False
            End If
            txtpreheat.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtpreheatl.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtpreheath.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtpreheattime.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            For i As Integer = 0 To 9
                If frmmain.SplitString(textin.ReadLine, ":", 1) = "Checked" Then
                    ChkSeg(i).Checked = True
                Else
                    ChkSeg(i).Checked = False
                End If
                CboSegType(i).SelectedIndex = Val(frmmain.SplitString(textin.ReadLine, ":", 1))
                TxtSp(i).Text = frmmain.SplitString(textin.ReadLine, ":", 1)
                TxtSpl(i).Text = frmmain.SplitString(textin.ReadLine, ":", 1)
                TxtSph(i).Text = frmmain.SplitString(textin.ReadLine, ":", 1)
                TxtTime(i).Text = frmmain.SplitString(textin.ReadLine, ":", 1)
                TxtTimeL(i).Text = frmmain.SplitString(textin.ReadLine, ":", 1)
                TxtTimeH(i).Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            Next
            txtpb1.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtreset1.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtderiv1.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtdb1.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txthys1.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtpb2.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtreset2.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtderiv2.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txtdb2.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            txthys2.Text = frmmain.SplitString(textin.ReadLine, ":", 1)

            Dim StrCureDevice As String = FrmMain.SplitString(StrFile, "_", 1)
            StrCureDevice = FrmMain.SplitString(StrCureDevice, ".", 0)
            lststations.Items.Add(StrCureDevice)
            textin.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub 'Read Prf and populate form controls

    Private Sub IntegerValidator(textbox As System.Windows.Forms.TextBox)
        If IsNumeric(textbox.Text) Then
            Dim value As UInt16
            Single.TryParse(textbox.Text, value)
            textbox.Text = Int(value).ToString()
        Else
            textbox.Select(0, textbox.Text.Length - 1)
            MsgBox("Input must be numeric.")
        End If
    End Sub

    Private Sub txtpreheat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpreheat.Validating
        Call IntegerValidator(txtpreheat)
    End Sub

    Private Sub txtpreheatl_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpreheatl.Validating
        Call IntegerValidator(txtpreheatl)
    End Sub

    Private Sub txtpreheath_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpreheath.Validating
        Call IntegerValidator(txtpreheath)
    End Sub

    Private Sub txtpreheattime_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpreheattime.Validating
        Call IntegerValidator(txtpreheattime)
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Call ClearAllEntries()
        Call Chart1.Series.Clear()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Dispose()
    End Sub
End Class