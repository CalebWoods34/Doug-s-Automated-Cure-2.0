Imports System.IO

Public Class CureRecipe
    Private _partNumber As String
    Private _partDescription As String
    Private _cureDeviceName As String
    Private _thisCureCycle As New CureCycle
    Private _preheatTemperature As CureCycleTemperature
    Private _preheatTime As CureSegmentDuration
    Private _pidSettings As New CureDevicePidSettings

    Public Property PartNumber As String
        Get
            Return _partNumber
        End Get
        Set(value As String)
            _partNumber = value
        End Set
    End Property

    Public Property ThisCureCycle As CureCycle
        Get
            Return _thisCureCycle
        End Get
        Set(value As CureCycle)
            _thisCureCycle = value
        End Set
    End Property

    Public Property PreheatTemperature As CureCycleTemperature
        Get
            Return _preheatTemperature
        End Get
        Set(value As CureCycleTemperature)
            _preheatTemperature = value
        End Set
    End Property

    Public Property PreheatTime As CureSegmentDuration
        Get
            Return _preheatTime
        End Get
        Set(value As CureSegmentDuration)
            _preheatTime = value
        End Set
    End Property

    Public Property PidSettings As CureDevicePidSettings
        Get
            Return _pidSettings
        End Get
        Set(value As CureDevicePidSettings)
            _pidSettings = value
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

    Public Property PartDescription As String
        Get
            Return _partDescription
        End Get
        Set(value As String)
            _partDescription = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Function ReadRecipeFromDisk(_fileName As String, _cureLogPath As String) As CureRecipe
        Dim recipe As New CureRecipe
        Try
            Dim xmlFormat As New Xml.Serialization.XmlSerializer(GetType(CureRecipe))
            Dim _file As New StreamReader($"{_cureLogPath}\{_fileName}.xml")
            recipe = CType(xmlFormat.Deserialize(_file), CureRecipe)
            _file.Close()
            Return recipe
        Catch ex As Exception
            MsgBox($"Not able to read {_fileName}.xml recipe.{vbCrLf}{ex.Message}")
        End Try
        Return recipe
    End Function

    Public Sub SaveRecipeToDisk(recipe As CureRecipe)
        Dim _path As String = $"{FrmMain.baseDirectory}\Data\Part Recipes\{CureDeviceName}"
        Try
            If Not Directory.Exists(_path) Then
                Directory.CreateDirectory(_path)
            End If
            Dim _xmlFormat As New Xml.Serialization.XmlSerializer(GetType(CureRecipe))
            Dim _file As New StreamWriter($"{_path}\{PartNumber}.xml")
            _xmlFormat.Serialize(_file, recipe)
            _file.Close()

        Catch ex As Exception
            MsgBox($"Problem saving {PartNumber}.xml recipe.{Environment.NewLine}{ex.Message}")
        End Try
    End Sub

    Public Sub PopulatePartRecipe(_recipePath As String, _recipeFilename As String)
        Dim FileNameAndPath = $"{_recipePath}\{_recipeFilename}.prf"
        Try
            Dim textin As New StreamReader(New FileStream(FileNameAndPath, FileMode.Open, FileAccess.Read))
            PartDescription = SplitString(textin.ReadLine(), ":", 1) 'Read part description
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

End Class
