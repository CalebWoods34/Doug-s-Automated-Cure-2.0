'Cure Class
'These variables contain all of the necessary cure information to execute cure properly
Imports System.IO

Public Class CureCycle
    Private _segments As New List(Of Segment)
    Private _usePreheat As Boolean = True
    Private _preheatTemperature As Int16 = 77
    Private _preheatDuration As Int16 = 1
    Private _criticalPoints As New CureCriticalPoints

    Public Property UsePreheat As Boolean
        Get
            Return _usePreheat
        End Get
        Set(value As Boolean)
            _usePreheat = value
        End Set
    End Property

    Public Property PreheatTemperature As Short
        Get
            Return _preheatTemperature
        End Get
        Set(value As Short)
            _preheatTemperature = value
        End Set
    End Property

    Public Property PreheatDuration As Short
        Get
            Return _preheatDuration
        End Get
        Set(value As Short)
            _preheatDuration = value
        End Set
    End Property

    Public Property Segments As List(Of Segment)
        Get
            Return _segments
        End Get
        Set(value As List(Of Segment))
            _segments = value
        End Set
    End Property

    Public Property CriticalPoints As CureCriticalPoints
        Get
            Return _criticalPoints
        End Get
        Set(value As CureCriticalPoints)
            _criticalPoints = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub ParseInputTextFile(FilePathAndName As String, FilePosition As Int16)
        Try
            Dim textin As New StreamReader(New FileStream(FilePathAndName, FileMode.Open, FileAccess.Read))

            For i As Int16 = 0 To FilePosition
                textin.ReadLine()
            Next

            For i As Integer = 0 To 9
                If SplitString(textin.ReadLine, ":", 1) = "Checked" Then
                    Dim IntType As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                    Dim StrType As String
                    If IntType = 0 Then
                        StrType = "Ramp Up"
                        Dim Rate As Double = Val(SplitString(textin.ReadLine, ":", 1))
                        Dim RateL As Double = Val(SplitString(textin.ReadLine, ":", 1))
                        Dim RateH As Double = Val(SplitString(textin.ReadLine, ":", 1))

                        textin.ReadLine()
                        textin.ReadLine()
                        textin.ReadLine()
                        Dim NewRate = New CureRate(Rate, RateL, RateH)
                        Dim NewSeg = New Segment(StrType, NewRate)
                        Segments.Add(NewSeg)
                    Else
                        If IntType = 1 Then
                            StrType = "Ramp Down"

                            Dim DblRate As Double = Val(SplitString(textin.ReadLine, ":", 1))
                            Dim DblRateL As Double = Val(SplitString(textin.ReadLine, ":", 1))
                            Dim DblRateH As Double = Val(SplitString(textin.ReadLine, ":", 1))
                            textin.ReadLine()
                            textin.ReadLine()
                            textin.ReadLine()
                            Dim NewRate = New CureRate(DblRate, DblRateL, DblRateH)
                            Dim NewSeg = New Segment(StrType, NewRate)
                            Segments.Add(NewSeg)
                        Else
                            If IntType = 2 Then
                                StrType = "Soak"
                                Dim IntSP As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                Dim IntSpl As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                Dim IntSph As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                Dim IntTime As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                Dim IntTimeL As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                Dim IntTimeH As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                Dim NewTemp = New CureCycleTemperature(IntSP, IntSpl, IntSph)
                                Dim NewTime = New CureSegmentDuration(IntTime, IntTimeL, IntTimeH)
                                Dim NewSeg = New Segment(StrType, NewTemp, NewTime)
                                Segments.Add(NewSeg)

                            Else
                                If IntType = 3 Then
                                    StrType = "End"
                                    Dim IntSP As Integer = Int(SplitString(textin.ReadLine, ":", 1))
                                    textin.ReadLine()
                                    textin.ReadLine()
                                    textin.ReadLine()
                                    textin.ReadLine()
                                    textin.ReadLine()
                                    Dim NewTemp = New CureCycleTemperature(IntSP, IntSP, IntSP)
                                    Dim NewSeg = New Segment(StrType, NewTemp)
                                    Segments.Add(NewSeg)
                                End If
                            End If
                        End If
                    End If

                Else
                    For j As Integer = 0 To 6
                        textin.ReadLine()
                    Next
                End If

            Next
            textin.Close()

        Catch ex As Exception
            MsgBox("B" + ex.Message)
        End Try

        _criticalPoints.ParseTextFile(FilePathAndName, 96) 'file position 96

    End Sub

    Private Function SplitString(StrString As String, StrSeperator As String, IntIndex As Integer) As String
        Dim StrReturn() As String = Split(StrString, StrSeperator)
        If IntIndex = 777 Then
            Return StrReturn(StrReturn.Count - 1)
        End If
        Return StrReturn(IntIndex)
    End Function 'Returns String given string to split,seperator,and index to return

    Private Function GetMinimumTemperatureList() As Short()
        Dim _minimumTemperaturePoints As New List(Of Short)

        For Each segment In _segments
            If segment.Temperature IsNot Nothing Then
                _minimumTemperaturePoints.Add(segment.Temperature.Low)
            Else
                _minimumTemperaturePoints.Add(0)
            End If

        Next


        While _minimumTemperaturePoints.Count < 10
            _minimumTemperaturePoints.Add(0)
        End While

        Return _minimumTemperaturePoints.ToArray
    End Function

    Private Function GetMaximumTemperatureList() As UShort()
        Dim _maximumTemperaturePoints As New List(Of UShort)

        For Each segment In _segments
            If segment.Temperature IsNot Nothing Then
                _maximumTemperaturePoints.Add(segment.Temperature.High)
            Else
                _maximumTemperaturePoints.Add(0)
            End If
        Next

        While _maximumTemperaturePoints.Count < 10
            _maximumTemperaturePoints.Add(0)
        End While

        Return _maximumTemperaturePoints.ToArray
    End Function

    Public Function GetRecipeArray() As UShort()
        Dim RecipeArray = New List(Of UShort)

        For Each item In _criticalPoints.AsArray()
            RecipeArray.Add(item)
        Next

        For Each item In GetMinimumTemperatureList()
            RecipeArray.Add(item)
        Next

        For Each item In GetMaximumTemperatureList()
            RecipeArray.Add(item)
        Next

        Return RecipeArray.ToArray

    End Function

    Public Shared Function GetCureCycleAsText(_cureCycle As CureCycle) As List(Of String)
        Dim segments As New List(Of String)
        If _cureCycle.UsePreheat Then
            segments.Add($"Preheat {_cureCycle._preheatTemperature}°F, {_cureCycle._preheatDuration} min minimum")
        Else
            segments.Add("No Preheat Required")
        End If

        For Each CureSegment As Segment In _cureCycle._segments
            Dim SegType As String = CureSegment.SegType
            If SegType.Contains("Ramp") Then
                segments.Add($"Ramp {CureSegment.Rate.Nominal}°F/min, min {CureSegment.Rate.Low}°F/min, max {CureSegment.Rate.High}°F/min")
            Else
                If SegType.Contains("Soak") Then
                    segments.Add($"Soak {CureSegment.Temperature.Nominal}°F, min {CureSegment.Temperature.Low}°F, max {CureSegment.Temperature.High}°F, {CureSegment.Time.Nominal} minutes")
                Else
                    If SegType.Contains("End") Then
                        segments.Add($"End {CureSegment.Temperature.Nominal}°F")
                    End If
                End If
            End If
        Next
        Return segments
    End Function

End Class
