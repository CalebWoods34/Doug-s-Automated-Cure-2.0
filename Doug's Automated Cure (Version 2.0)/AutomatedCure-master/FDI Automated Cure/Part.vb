'Part Class
'These are the parts run during each cure/injection
Imports System.IO
Imports System.Text

Public Class Part
    Private _partDescription As String 'Name of part (Tail Spar)
    Private _partNumber As String 'Part Number (UPC23102....etc)
    Private _serialNumber As String
    Private _jobNumber As String
    Private _assignedThermocouples As New List(Of Thermocouple)
    Private _thisCureCycle As CureCycle
    Private _preheatTemperature As CureCycleTemperature
    Private _preheatTime As CureSegmentDuration
    Private _pidSettings As New CureDevicePidSettings
    Private _cureDeviceName As String
    Private _partCureLog As PartCureLog


    Public Property PreheatTime As CureSegmentDuration
        Get
            Return _preheatTime
        End Get
        Set(ByVal value As CureSegmentDuration)
            _preheatTime = value
        End Set
    End Property

    Public Property PreheatTemperature As CureCycleTemperature
        Get
            Return _preheatTemperature
        End Get
        Set(ByVal value As CureCycleTemperature)
            _preheatTemperature = value
        End Set
    End Property

    Public Property PartDescription As String
        Get
            Return _partDescription
        End Get
        Set(ByVal value As String)
            _partDescription = value
        End Set
    End Property

    Public Property PartNumber As String
        Get
            Return _partNumber
        End Get
        Set(value As String)
            _partNumber = value
        End Set
    End Property

    Public Property SerialNumber As String
        Get
            Return _serialNumber
        End Get
        Set(value As String)
            _serialNumber = value
        End Set
    End Property

    Public Property JobNumber As String
        Get
            Return _jobNumber
        End Get
        Set(value As String)
            _jobNumber = value
        End Set
    End Property

    Public Property PidSettings As CureDevicePidSettings
        Get
            Return _pidSettings
        End Get
        Set(ByVal value As CureDevicePidSettings)
            _pidSettings = value
        End Set
    End Property

    Public Property CureCycle As CureCycle
        Get
            Return _thisCureCycle
        End Get
        Set(ByVal value As CureCycle)
            _thisCureCycle = value
        End Set
    End Property

    Public Property AssignedThermocouples As List(Of Thermocouple)
        Get
            Return _assignedThermocouples
        End Get
        Set(value As List(Of Thermocouple))
            _assignedThermocouples = value
        End Set
    End Property

    Public Property CureDeviceName As String
        Get
            Return _cureDeviceName
        End Get
        Set(value As String)
            _cureDeviceName = value
        End Set
    End Property

    Public Property CureLog As PartCureLog
        Get
            Return _partCureLog
        End Get
        Set(value As PartCureLog)
            _partCureLog = value
        End Set
    End Property

    Public Sub New(PartNumber As String, CureDeviceName As String)
        _partNumber = PartNumber
        _thisCureCycle = New CureCycle()
        Me.CureDeviceName = CureDeviceName
    End Sub

    Public Sub AddThermocouple(ThisThermocouple As Thermocouple)
        Dim IsAssigned As Boolean = False
        For Each tc In _assignedThermocouples
            If tc.GetHashCode.Equals(ThisThermocouple.GetHashCode) Then
                IsAssigned = True
            End If
        Next
        If Not IsAssigned Then
            _assignedThermocouples.Add(ThisThermocouple)
        End If
        _assignedThermocouples.Sort()
    End Sub

    Public Sub RemoveThermocouple(ThisThermocouple As Thermocouple)
        For Each tc In _assignedThermocouples.ToArray()
            If tc.Id = ThisThermocouple.Id Then
                _assignedThermocouples.Remove(tc)
            End If
        Next
    End Sub

    Public Sub RemoveThermocouple(tcId As UShort)
        For Each tc In _assignedThermocouples.ToArray()
            If tc.Id = tcId Then
                _assignedThermocouples.Remove(tc)
            End If
        Next
    End Sub

    Public Function IsThermocoupleAssigned(tcId As UShort) As Boolean
        Dim result As Boolean = False
        For Each _thermocouple As Thermocouple In _assignedThermocouples
            If _thermocouple.Id = tcId Then
                result = True
            End If
        Next
        Return result
    End Function

    Public Overrides Function ToString() As String
        Return _partNumber
    End Function

    Public Sub PopulatePartRecipe()
        Dim FileNameAndPath = $"{FrmMain.baseDirectory}\Data\Part Recipes\{PartNumber}_{CureDeviceName}.prf"
        Try
            Dim textin As New StreamReader(New FileStream(FileNameAndPath, FileMode.Open, FileAccess.Read))
            _partDescription = SplitString(textin.ReadLine(), ":", 1) 'Read part description
            textin.ReadLine() 'Read Part Number but we already have it
            If SplitString(textin.ReadLine, ":", 1) = "True" Then
                _preheatTemperature = New CureCycleTemperature() With {
                .Nominal = Int(SplitString(textin.ReadLine, ":", 1)),
                .Low = Int(SplitString(textin.ReadLine, ":", 1)),
                .High = Int(SplitString(textin.ReadLine, ":", 1))
            }
                _preheatTime = New CureSegmentDuration(Int(SplitString(textin.ReadLine, ":", 1))) 'single argument constructor takes care of low and high values for us
            Else
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
                textin.ReadLine()
            End If
            textin.Close()

            '_thisCureCycle = New CureCycle()
            _thisCureCycle.ParseInputTextFile(FileNameAndPath, 6) 'file position 6'

            '_pidSettings = New CureDevicePidSettings()
            _pidSettings.ParseTextFile(FileNameAndPath, 86) 'file position 86'

        Catch ex As Exception
            MsgBox("Part threw and exception. ", ex.Message)
        End Try

    End Sub

    Private Function SplitString(StrString As String, StrSeperator As String, IntIndex As Integer) As String
        Dim StrReturn() As String = Split(StrString, StrSeperator)
        If IntIndex = 777 Then
            Return StrReturn(StrReturn.Count - 1)
        End If
        Return StrReturn(IntIndex)
    End Function 'Returns String given string to split,seperator,and index to return

    Public Sub ClearAllAssignedThermocouples()
        AssignedThermocouples.Clear()
    End Sub

    Public Function ListOfTCsAsString() As String
        Dim sb As New StringBuilder
        If AssignedThermocouples.Count > 1 Then
            sb.Append($"{_assignedThermocouples(0)}")
            For i = 1 To _assignedThermocouples.Count - 1
                sb.Append($",{_assignedThermocouples(i)}")
            Next
        ElseIf AssignedThermocouples.Count = 1 Then
            sb.Append($"{_assignedThermocouples(0)}")
        Else
            sb.Append("Select")
        End If
        Return sb.ToString
    End Function

    Public Sub MakeLogFileReadonly()

        Dim fileDetail As IO.FileInfo = My.Computer.FileSystem.GetFileInfo($"{FrmMain.cureLogBaseDirectory}\{CureDeviceName}\{_partNumber}_{JobNumber}.log")
        fileDetail.IsReadOnly = True
        'fileDetail.Attributes = FileAttributes.Hidden ' Uncommenting this will set the file attribute to hidden.
    End Sub

End Class
