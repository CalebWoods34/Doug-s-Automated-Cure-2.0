'Part Class
'These are the parts run during each cure/injection
Imports System.IO

Public Class CureCriticalPoints
    Private _criticalTimes As New List(Of UShort)
    Private _criticalTemperatures As New List(Of UShort)

    Public Property CriticalTimes As List(Of UShort)
        Get
            Return _criticalTimes
        End Get
        Set(value As List(Of UShort))
            _criticalTimes = value
        End Set
    End Property

    Public Property CriticalTemperatures As List(Of UShort)
        Get
            Return _criticalTemperatures
        End Get
        Set(value As List(Of UShort))
            _criticalTemperatures = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub ParseTextFile(FilePathAndName As String, FilePosition As Int16)

        Try
            Dim textin As New StreamReader(New FileStream(FilePathAndName, FileMode.Open, FileAccess.Read))

            For i As Int16 = 0 To FilePosition
                textin.ReadLine()
            Next

            _criticalTemperatures.Clear()
            _criticalTimes.Clear()
            Do While Not textin.EndOfStream
                Dim StringArray() As String = Split(textin.ReadLine, ":")
                _criticalTimes.Add(Int(StringArray(1)))
                _criticalTemperatures.Add(Int(StringArray(2)))
            Loop
            textin.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Function AsArray() As Int16()
        Dim array(19) As Int16
        For i As Int16 = 0 To array.Length - 1
            array(i) = 0
        Next
        Dim count = 0
        For Each time In _criticalTimes
            array(count) = time
            count += 1
        Next
        count = 10
        For Each temperature In _criticalTemperatures
            array(count) = temperature
            count += 1
        Next
        Return array
    End Function

    Public Shared Function DescriptionsAsList()
        Dim _descriptions As New List(Of String)
        Dim _headers As New List(Of String)({"TimeArray", "TempArray", "MinArray", "MaxArray"})
        For Each _header In _headers
            For j = 0 To 9
                _descriptions.Add($"{_header}[{j}]")
            Next
        Next
        Return _descriptions
    End Function

End Class
