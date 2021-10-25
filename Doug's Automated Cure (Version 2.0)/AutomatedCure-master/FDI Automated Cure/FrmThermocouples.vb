Public Class OvenThermocouples
    Private _thermocoupleString As String
    Private CurrentPart As Part
    Private CurrentDevice As CureDevice
    Private Checkboxes As New List(Of System.Windows.Forms.CheckBox)

    Public Property ThermocoupleString As String
        Get
            Return _thermocoupleString
        End Get
        Set(value As String)
            _thermocoupleString = value
        End Set
    End Property

    Public Sub New(ByRef ThisPart As Part, ByRef ThisDevice As CureDevice)
        InitializeComponent()
        CurrentPart = ThisPart
        CurrentDevice = ThisDevice
        Call HideUnavailableCheckboxes()
    End Sub

    Private Sub HideUnavailableCheckboxes()
        Dim cb As Control = Me.GetNextControl(Me, True)
        Do Until cb Is Nothing
            If TypeOf cb Is System.Windows.Forms.CheckBox Then
                If UShort.Parse(cb.Tag) > CurrentDevice.ListOfAllDeviceTCs.Count Then
                    cb.Visible = False
                    cb.Enabled = False
                End If
            End If
            cb = Me.GetNextControl(cb, True)
        Loop
    End Sub

    Private Sub PopulatePreCheckedCheckboxes(ListOfCheckboxes As List(Of System.Windows.Forms.CheckBox))
        Console.WriteLine("FrmThermocouples.PopulatePreCheckedCheckboxes")
        RemoveHandler TCCheckBox1.CheckedChanged, AddressOf TCCheckBox1_CheckedChanged
        RemoveHandler TCCheckBox2.CheckedChanged, AddressOf TCCheckBox2_CheckedChanged
        RemoveHandler TCCheckBox3.CheckedChanged, AddressOf TCCheckBox3_CheckedChanged
        RemoveHandler TCCheckBox4.CheckedChanged, AddressOf TCCheckBox4_CheckedChanged
        RemoveHandler TCCheckBox5.CheckedChanged, AddressOf TCCheckBox5_CheckedChanged
        RemoveHandler TCCheckBox6.CheckedChanged, AddressOf TCCheckBox6_CheckedChanged
        RemoveHandler TCCheckBox7.CheckedChanged, AddressOf TCCheckBox7_CheckedChanged
        RemoveHandler TCCheckBox8.CheckedChanged, AddressOf TCCheckBox8_CheckedChanged
        RemoveHandler TCCheckBox9.CheckedChanged, AddressOf TCCheckBox9_CheckedChanged
        RemoveHandler TCCheckBox10.CheckedChanged, AddressOf TCCheckBox10_CheckedChanged
        RemoveHandler TCCheckBox11.CheckedChanged, AddressOf TCCheckBox11_CheckedChanged
        RemoveHandler TCCheckBox12.CheckedChanged, AddressOf TCCheckBox12_CheckedChanged
        RemoveHandler TCCheckBox13.CheckedChanged, AddressOf TCCheckBox13_CheckedChanged
        RemoveHandler TCCheckBox14.CheckedChanged, AddressOf TCCheckBox14_CheckedChanged
        RemoveHandler TCCheckBox15.CheckedChanged, AddressOf TCCheckBox15_CheckedChanged
        RemoveHandler TCCheckBox16.CheckedChanged, AddressOf TCCheckBox16_CheckedChanged
        RemoveHandler TCCheckBox17.CheckedChanged, AddressOf TCCheckbox17_CheckedChanged
        RemoveHandler TCCheckBox18.CheckedChanged, AddressOf TCCheckbox18_CheckedChanged
        RemoveHandler TCCheckBox19.CheckedChanged, AddressOf TCCheckbox19_CheckedChanged
        RemoveHandler TCCheckBox20.CheckedChanged, AddressOf TCCheckbox20_CheckedChanged
        RemoveHandler TCCheckBox21.CheckedChanged, AddressOf TCCheckbox21_CheckedChanged
        RemoveHandler TCCheckBox22.CheckedChanged, AddressOf TCCheckbox22_CheckedChanged
        RemoveHandler TCCheckBox23.CheckedChanged, AddressOf TCCheckbox23_CheckedChanged
        RemoveHandler TCCheckBox24.CheckedChanged, AddressOf TCCheckbox24_CheckedChanged
        RemoveHandler TCCheckBox25.CheckedChanged, AddressOf TCCheckbox25_CheckedChanged
        RemoveHandler TCCheckBox26.CheckedChanged, AddressOf TCCheckbox26_CheckedChanged
        RemoveHandler TCCheckBox27.CheckedChanged, AddressOf TCCheckbox27_CheckedChanged
        RemoveHandler TCCheckBox28.CheckedChanged, AddressOf TCCheckbox28_CheckedChanged
        RemoveHandler TCCheckBox29.CheckedChanged, AddressOf TCCheckbox29_CheckedChanged
        RemoveHandler TCCheckBox30.CheckedChanged, AddressOf TCCheckbox30_CheckedChanged
        RemoveHandler TCCheckBox31.CheckedChanged, AddressOf TCCheckbox31_CheckedChanged
        RemoveHandler TCCheckBox32.CheckedChanged, AddressOf TCCheckbox32_CheckedChanged
        Console.WriteLine($"Thermocouples assigned to this part: {CurrentPart.ListOfTCsAsString}")
        For Each tc In CurrentPart.AssignedThermocouples
            If tc.OnOff = True Then
                Checkboxes(tc.Id - 1).CheckState = CheckState.Checked
            Else
                Checkboxes(tc.Id - 1).CheckState = CheckState.Unchecked
            End If
        Next
        AddHandler TCCheckBox1.CheckedChanged, AddressOf TCCheckBox1_CheckedChanged
        AddHandler TCCheckBox2.CheckedChanged, AddressOf TCCheckBox2_CheckedChanged
        AddHandler TCCheckBox3.CheckedChanged, AddressOf TCCheckBox3_CheckedChanged
        AddHandler TCCheckBox4.CheckedChanged, AddressOf TCCheckBox4_CheckedChanged
        AddHandler TCCheckBox5.CheckedChanged, AddressOf TCCheckBox5_CheckedChanged
        AddHandler TCCheckBox6.CheckedChanged, AddressOf TCCheckBox6_CheckedChanged
        AddHandler TCCheckBox7.CheckedChanged, AddressOf TCCheckBox7_CheckedChanged
        AddHandler TCCheckBox8.CheckedChanged, AddressOf TCCheckBox8_CheckedChanged
        AddHandler TCCheckBox9.CheckedChanged, AddressOf TCCheckBox9_CheckedChanged
        AddHandler TCCheckBox10.CheckedChanged, AddressOf TCCheckBox10_CheckedChanged
        AddHandler TCCheckBox11.CheckedChanged, AddressOf TCCheckBox11_CheckedChanged
        AddHandler TCCheckBox12.CheckedChanged, AddressOf TCCheckBox12_CheckedChanged
        AddHandler TCCheckBox13.CheckedChanged, AddressOf TCCheckBox13_CheckedChanged
        AddHandler TCCheckBox14.CheckedChanged, AddressOf TCCheckBox14_CheckedChanged
        AddHandler TCCheckBox15.CheckedChanged, AddressOf TCCheckBox15_CheckedChanged
        AddHandler TCCheckBox16.CheckedChanged, AddressOf TCCheckBox16_CheckedChanged
        AddHandler TCCheckBox17.CheckedChanged, AddressOf TCCheckbox17_CheckedChanged
        AddHandler TCCheckBox18.CheckedChanged, AddressOf TCCheckbox18_CheckedChanged
        AddHandler TCCheckBox19.CheckedChanged, AddressOf TCCheckbox19_CheckedChanged
        AddHandler TCCheckBox20.CheckedChanged, AddressOf TCCheckbox20_CheckedChanged
        AddHandler TCCheckBox21.CheckedChanged, AddressOf TCCheckbox21_CheckedChanged
        AddHandler TCCheckBox22.CheckedChanged, AddressOf TCCheckbox22_CheckedChanged
        AddHandler TCCheckBox23.CheckedChanged, AddressOf TCCheckbox23_CheckedChanged
        AddHandler TCCheckBox24.CheckedChanged, AddressOf TCCheckbox24_CheckedChanged
        AddHandler TCCheckBox25.CheckedChanged, AddressOf TCCheckbox25_CheckedChanged
        AddHandler TCCheckBox26.CheckedChanged, AddressOf TCCheckbox26_CheckedChanged
        AddHandler TCCheckBox27.CheckedChanged, AddressOf TCCheckbox27_CheckedChanged
        AddHandler TCCheckBox28.CheckedChanged, AddressOf TCCheckbox28_CheckedChanged
        AddHandler TCCheckBox29.CheckedChanged, AddressOf TCCheckbox29_CheckedChanged
        AddHandler TCCheckBox30.CheckedChanged, AddressOf TCCheckbox30_CheckedChanged
        AddHandler TCCheckBox31.CheckedChanged, AddressOf TCCheckbox31_CheckedChanged
        AddHandler TCCheckBox32.CheckedChanged, AddressOf TCCheckbox32_CheckedChanged
    End Sub

    Public Sub OkButton1_Click(sender As Object, e As EventArgs) Handles OkButton1.Click
        BuildAssignedThermocouplesString()
        DialogResult = DialogResult.OK
        Me.Dispose()
    End Sub

    Public Sub BuildAssignedThermocouplesString()
        If CurrentPart.AssignedThermocouples.Count > 0 Then
            ThermocoupleString = CurrentPart.ListOfTCsAsString()
        End If
    End Sub

    Private Sub OvenThermocouples_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cb As Control = Me.GetNextControl(Me, True)
        Do Until cb Is Nothing
            If TypeOf cb Is System.Windows.Forms.CheckBox Then
                Checkboxes.Add(cb)
            End If
            cb = Me.GetNextControl(cb, True)
        Loop
        PopulatePreCheckedCheckboxes(Checkboxes)
    End Sub

    Private Sub TCCheckBox1_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox1.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox2_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox2.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox3_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox3.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox4_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox4.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox5_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox5.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox6_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox6.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox7_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox7.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox8_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox8.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox9_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox9.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox10_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox10.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox11_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox11.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox12_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox12.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox13_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox13.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox14_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox14.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox15_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox15.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckBox16_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox16.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox17_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox17.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox18_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox18.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox19_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox19.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox20_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox20.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox21_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox21.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox22_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox22.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox23_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox23.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox24_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox24.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox25_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox25.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox26_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox26.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox27_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox27.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox28_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox28.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox29_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox29.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox30_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox30.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox31_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox31.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub TCCheckbox32_CheckedChanged(cb As Object, e As EventArgs) Handles TCCheckBox32.CheckedChanged
        ToggleTCValues(cb)
    End Sub

    Private Sub OvenThermocouples_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ToggleTCValues(cb As Object)
        Dim tcId As UShort = cb.tag
        Dim tcListIndex As UShort = cb.tag - 1
        If cb.checked Then
            If Not CurrentPart.IsThermocoupleAssigned(tcId) Then
                CurrentPart.AddThermocouple(CurrentDevice.ListOfAllDeviceTCs(tcListIndex))
            End If
            CurrentDevice.ListOfAllDeviceTCs(tcListIndex).OnOff = True

        Else
            CurrentPart.RemoveThermocouple(tcId)

            If CurrentDevice.TimesInUse(CurrentDevice.ListOfAllDeviceTCs(tcListIndex)) < 1 Then
                CurrentDevice.ListOfAllDeviceTCs(tcListIndex).TurnOff()

            End If
        End If
    End Sub
End Class