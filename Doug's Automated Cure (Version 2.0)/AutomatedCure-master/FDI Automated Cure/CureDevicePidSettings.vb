Imports System.IO

Public Class CureDevicePidSettings
    Private _propBand1 As Int16 = 0
    Private _reset1 As Int16 = 0
    Private _deriv1 As Int16 = 0
    Private _deadBand1 As Int16 = 0
    Private _hysterisis1 As Int16 = 0
    Private _propBand2 As Int16 = 0
    Private _reset2 As Int16 = 0
    Private _deriv2 As Int16 = 0
    Private _deadBand2 As Int16 = 0
    Private _hysteresis2 As Int16 = 0
    Public ReadOnly numberOfElements As UInt16 = 10
    Public _isRequired As Boolean = False

    Public Property PropBand1 As Int16
        Get
            Return _propBand1
        End Get
        Set(value As Int16)
            _propBand1 = value
        End Set
    End Property

    Public Property Reset1 As Short
        Get
            Return _reset1
        End Get
        Set(value As Short)
            _reset1 = value
        End Set
    End Property

    Public Property Deriv1 As Short
        Get
            Return _deriv1
        End Get
        Set(value As Short)
            _deriv1 = value
        End Set
    End Property

    Public Property DeadBand1 As Short
        Get
            Return _deadBand1
        End Get
        Set(value As Short)
            _deadBand1 = value
        End Set
    End Property

    Public Property Hysteresis1 As Short
        Get
            Return _hysterisis1
        End Get
        Set(value As Short)
            _hysterisis1 = value
        End Set
    End Property

    Public Property PropBand2 As Short
        Get
            Return _propBand2
        End Get
        Set(value As Short)
            _propBand2 = value
        End Set
    End Property

    Public Property Reset2 As Short
        Get
            Return _reset2
        End Get
        Set(value As Short)
            _reset2 = value
        End Set
    End Property

    Public Property Deriv2 As Short
        Get
            Return _deriv2
        End Get
        Set(value As Short)
            _deriv2 = value
        End Set
    End Property

    Public Property DeadBand2 As Short
        Get
            Return _deadBand2
        End Get
        Set(value As Short)
            _deadBand2 = value
        End Set
    End Property

    Public Property Hysteresis2 As Short
        Get
            Return _hysteresis2
        End Get
        Set(value As Short)
            _hysteresis2 = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Function AsArray() As Int16()
        Dim array(9) As Int16

        array(0) = _propBand1
        array(1) = _reset1
        array(2) = _deriv1
        array(3) = _deadBand1
        array(4) = _hysterisis1
        array(5) = _propBand2
        array(6) = _reset2
        array(7) = _deriv2
        array(8) = _deadBand2
        array(9) = _hysteresis2

        Return array
    End Function

    Public Shared Function DescriptionAsList() As List(Of String)
        Dim _list = New List(Of String) From {
            "HeatPropband",
            "HeatReset",
            "HeatDerivative",
            "HeatDeadBand",
            "HeatHysteresis",
            "CoolPropband",
            "CoolReset",
            "CoolDerivative",
            "CoolDeadBand",
            "CoolHysteresis"
        }
        Return _list
    End Function

    Public Sub ParseTextFile(FilePathAndName As String, FilePosition As Int16)

        Try
            Dim textin As New StreamReader(New FileStream(FilePathAndName, FileMode.Open, FileAccess.Read))

            For i As Int16 = 0 To FilePosition
                textin.ReadLine()
            Next

            PropBand1 = Int(SplitString(textin.ReadLine, ":", 1))
            Reset1 = Int(SplitString(textin.ReadLine, ":", 1))
            Deriv1 = Int(SplitString(textin.ReadLine, ":", 1))
            DeadBand1 = Int(SplitString(textin.ReadLine, ":", 1))
            Hysteresis1 = Int(SplitString(textin.ReadLine, ":", 1))
            PropBand2 = Int(SplitString(textin.ReadLine, ":", 1))
            Reset2 = Int(SplitString(textin.ReadLine, ":", 1))
            Deriv2 = Int(SplitString(textin.ReadLine, ":", 1))
            DeadBand2 = Int(SplitString(textin.ReadLine, ":", 1))
            Hysteresis2 = Int(SplitString(textin.ReadLine, ":", 1))

            textin.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function SplitString(StrString As String, StrSeperator As String, IntIndex As Integer) As String
        Dim StrReturn() As String = Split(StrString, StrSeperator)
        If IntIndex = 777 Then
            Return StrReturn(StrReturn.Count - 1)
        End If
        Return StrReturn(IntIndex)
    End Function 'Returns String given string to split,seperator,and index to return


End Class
