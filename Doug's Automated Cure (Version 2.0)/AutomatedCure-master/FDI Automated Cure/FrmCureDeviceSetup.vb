Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class FrmCureDeviceSetup
    Private ReadOnly Path As String = $"{FrmMain.baseDirectory}\Data\Curing Devices"
    Private currentCureDevice As New CureDeviceConfiguration
    Private streamToPrint As StreamReader
    Private printFont As System.Drawing.Font

    Private Sub FrmCureDeviceSetup_Load(sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CboDeviceType.SelectedIndex = 0
    End Sub 'Form Load

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Try
            Dim NewFrmCureDeviceSetup As New FrmCureDeviceSetup
            NewFrmCureDeviceSetup.Show()
        Catch ex As Exception
            MsgBox("Exception caught while creating new cure device setup form." + ex.Message)
        End Try
    End Sub 'New Cure Device Form

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If FrmMain.CheckInvalidString(txtname.Text) Then
            MsgBox("Illegal filename detected.")
            DGV1.ClearSelection()
            'ElseIf Not Directory.Exists(Path) Then
            '    Directory.CreateDirectory(Path)
        End If

        Call Me.writecsf()

    End Sub 'Save Button

    Public Sub ReadXML(filename)
        Try
            Dim reader As New Xml.Serialization.XmlSerializer(GetType(CureDeviceConfiguration))
            Dim file As New StreamReader(CStr(filename))
            currentCureDevice = CType(reader.Deserialize(file), CureDeviceConfiguration)
            file.Close()
            If Not currentCureDevice.RegisterStartingAddress > 0 Or Not currentCureDevice.RegisterStartingAddress < 65535 Then
                currentCureDevice.RegisterStartingAddress = 2
            End If
        Catch ex As Exception
            MsgBox("There was a problem reading the file.")
        End Try
        Call UpdateInfo()

    End Sub

    Private Sub UpdateInfo()
        txtname.Text = currentCureDevice.Name
        CboDeviceType.Text = currentCureDevice.Type
        registerStartAddress.Text = currentCureDevice.RegisterStartingAddress + 400000
        registerStartAddress.Tag = currentCureDevice.RegisterStartingAddress
        TCnumericBox.Value = currentCureDevice.NumberOfThermocouples

        Call Btn_generate.PerformClick()
    End Sub

    Private Sub writecsf()
        Try
            Dim strname As String = currentCureDevice.Name
            Dim dir As String = $"{Path}\"
            Dim strpath As String = $"{dir}{strname}.csf" 'Defines path of file
            If Not Directory.Exists(dir) Then 'Creates a directory if necessary
                Directory.CreateDirectory(dir)
            End If


            Dim writer As New Xml.Serialization.XmlSerializer(GetType(CureDeviceConfiguration))
            Dim _file As New StreamWriter($"{Path}\{currentCureDevice.Name}.csf")
            writer.Serialize(_file, currentCureDevice)
            _file.Close()

            Dim isActiveDevice = False
            For Each _device In FrmMain.CureDevices
                If _device.Name = currentCureDevice.Name Then
                    isActiveDevice = True
                End If
            Next
            If isActiveDevice Then
                MsgBox($"Automated Cure needs to be restarted to re-load changes to {currentCureDevice.Name}.")
            Else
                FrmMain.CureDevices.Add(New CureDevice(currentCureDevice.Name, False))
                Call FrmMain.CreateIniFile()
            End If

        Catch ex As Exception
            MsgBox("Error while writing .csf file. " + ex.Message)
        End Try
    End Sub 'Writes csf File 

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        'Call Close()
        Call Dispose()
    End Sub 'Close Meunu Item

    Private Sub FrmCureDeviceSetup_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Call Dispose()
    End Sub 'Form Closing X Button

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        Try
            'streamToPrint = New StreamReader("C:\users\dougl\My Documents\MyFile.txt")
            Dim myStringBuilder As StringBuilder = New StringBuilder()
            myStringBuilder.Append($"Modbus Communications Register Map for {currentCureDevice.Name}{vbCrLf}{vbCrLf}")
            For Each _row As DataGridViewRow In DGV1.Rows
                myStringBuilder.Append(String.Format($"{_row.Cells(0).Value,17}  {_row.Cells(1).Value,-7}{vbCrLf}"))
            Next
            myStringBuilder.Append(LogFileFormatString())

            streamToPrint = New StreamReader(GenerateStreamFromString(myStringBuilder.ToString))
            Try
                printFont = New System.Drawing.Font("Courier New", 10)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                Dim _printDialog As New PrintDialog
                _printDialog.Document = pd
                If _printDialog.ShowDialog() = DialogResult.OK Then
                    _printDialog.Document.Print()
                End If

            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function LogFileFormatString() As StringBuilder
        Dim sb = New StringBuilder()
        sb.Append($"{vbCrLf}{vbCrLf}")
        sb.Append($"Log the following items in{vbCrLf}the Red Lion in this exact order.{vbCrLf}")
        sb.Append($"Temp{vbCrLf}")
        sb.Append($"Setpoint{vbCrLf}")
        For i = 1 To currentCureDevice.NumberOfThermocouples
            sb.Append($"TC{i}{vbCrLf}")
        Next
        sb.Append($"CureOnOff")
        Return sb
    End Function

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        OpenFileDialog1.InitialDirectory = Path
        OpenFileDialog1.Title = "Open Cure Device Settings File (.csf)"
        OpenFileDialog1.Filter = "Cure Device Settings Files (*.csf)|*.csf"
        OpenFileDialog1.ShowDialog()
        Dim StrFile As String = OpenFileDialog1.FileName
        If StrFile = "" Then
            MsgBox("Please select a file.")
        ElseIf File.Exists(StrFile) Then
            Call ReadXML(StrFile)
        End If
        DGV1.ClearSelection()

    End Sub 'Open Existing .csf File

    Private Sub GenerateItemAndAddressList()
        Dim items As New List(Of String) From {
            "Temperature",
            "Setpoint",
            "CureOnOff",
            "SegmentCount",
            "CurrentSegment"
        }
        items.AddRange(CureCriticalPoints.DescriptionsAsList())
        If cb_pid.Text = "Yes" Then
            items.AddRange(CureDevicePidSettings.DescriptionAsList())
        End If
        For i = 1 To TCnumericBox.Value
            items.Add($"TC{i}")
        Next
        items.Add("Status")

        Dim startingAddress As Integer
        If Not registerStartAddress.Text = String.Empty Then
            startingAddress = Integer.Parse(registerStartAddress.Text)
        Else
            startingAddress = 0
        End If
        Dim counter = 0
        DGV1.Rows.Clear()
        For Each _row In items
            DGV1.Rows.Add()
            DGV1.Rows(counter).Cells(0).Value = _row
            DGV1.Rows(counter).Cells(1).Value = startingAddress + counter
            counter += 1
        Next
    End Sub

    Private Sub Btn_generate_Click(sender As Object, e As EventArgs) Handles Btn_generate.Click

        currentCureDevice.Name = txtname.Text
        currentCureDevice.RegisterStartingAddress = registerStartAddress.Tag
        If cb_pid.Text = "Yes" Then
            currentCureDevice.NeedsPID = True
        Else
            currentCureDevice.NeedsPID = False
        End If
        currentCureDevice.NumberOfThermocouples = TCnumericBox.Value
        currentCureDevice.Type = CboDeviceType.Text
        Call GenerateItemAndAddressList()
    End Sub

    Private Sub registerStartAddress_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles registerStartAddress.Validating
        Dim hasError As Boolean = False
        If Not registerStartAddress.Text Like "######" Then
            MsgBox("Address must be numeric and 6 digits long.")

            registerStartAddress.Text = "400002"
        End If
        Dim value = Integer.Parse(registerStartAddress.Text)
        If value > 465535 Or value < 400002 Then
            MsgBox("Range is between 400002 and 465535")

            registerStartAddress.Text = "400002"
        End If
        registerStartAddress.Tag = Integer.Parse(registerStartAddress.Text) - 400000
    End Sub

    Private Sub cb_pid_TextChanged(sender As Object, e As EventArgs) Handles cb_pid.TextChanged
        Call Btn_generate.PerformClick()
    End Sub


    Private Function GenerateStreamFromString(s As String) As Stream
        Dim myStream As Stream = New MemoryStream()
        Dim myWriter As StreamWriter = New StreamWriter(myStream)
        myWriter.Write(s)
        myWriter.Flush()
        myStream.Position = 0
        Return myStream
    End Function


    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing
        Dim currentColumn As Integer = 1
        Dim columnWidth As Integer

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)
        columnWidth = printFont.GetHeight() * 17
        ' Print each line of the file.
        While count < linesPerPage
            If count = (Int(linesPerPage)) And columnWidth < (ev.MarginBounds.Right - ev.MarginBounds.Left) Then
                leftMargin += columnWidth
                count = 2 ' this offsets the continued lines downward so they line up
            End If
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While
        leftMargin = ev.MarginBounds.Left
        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub
End Class