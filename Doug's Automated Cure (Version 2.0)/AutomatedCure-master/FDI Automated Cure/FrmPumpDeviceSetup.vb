Imports System.IO

Public Class FrmPumpDeviceSetup

    Private Sub FrmPumpDeviceSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboType.SelectedIndex = 0
    End Sub 'Form Load

    Private Sub FrmPumpDeviceSetup_closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closing
        Me.Dispose()
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        'GC.Collect()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboType.SelectedIndexChanged
        DGV1.Rows.Clear()
        If CboType.SelectedIndex = 0 Then 'FDI Pump Selected
            DGV1.Rows.Clear()
            DGV1.Rows.Add()
            DGV1.Rows(0).Cells(0).Value = "Pressure"
            DGV1.Rows.Add()
            DGV1.Rows(1).Cells(0).Value = "Flow Rate"
            TxtIPAddress.Enabled = False
            TxtIPAddress.Text = "NA"
        Else 'Mahr Pump Selected
            TxtIPAddress.Enabled = True
            TxtIPAddress.Text = "192.168.1.24"
            DGV1.Rows.Clear()
            DGV1.Rows.Add()
            DGV1.Rows(0).Cells(0).Value = "Resin Flow Rate"
            DGV1.Rows.Add()
            DGV1.Rows(1).Cells(0).Value = "Hardener Flow Rate"
            DGV1.Rows.Add()
            DGV1.Rows(2).Cells(0).Value = "Resin Pump Pressure"
            DGV1.Rows.Add()
            DGV1.Rows(3).Cells(0).Value = "Hardener Pump Pressure"
            DGV1.Rows.Add()
            DGV1.Rows(4).Cells(0).Value = "Resin Head Pressure"
            DGV1.Rows.Add()
            DGV1.Rows(5).Cells(0).Value = "Hardener Head Pressure"
            DGV1.Rows.Add()
            DGV1.Rows(6).Cells(0).Value = "Resin Temp"
            DGV1.Rows.Add()
            DGV1.Rows(7).Cells(0).Value = "Hardener Temp"
            DGV1.Rows.Add()
            DGV1.Rows(8).Cells(0).Value = "Ratio"
            DGV1.Rows.Add()
            DGV1.Rows(9).Cells(0).Value = "Dispense On/Off"
            DGV1.Rows.Add()
            DGV1.Rows(10).Cells(0).Value = "Fill Time"
            DGV1.Rows.Add()
            DGV1.Rows(11).Cells(0).Value = "Fill Size"

        End If

        'Dim strparam1 As New List(Of String) 'Resin Flow Rate
        'Dim strparam2 As New List(Of String) 'Hardener Flow Rate
        'Dim strparam3 As New List(Of String) 'Resin Pump Pressure
        'Dim strparam4 As New List(Of String) 'Hardener Pump Pressure
        'Dim strparam5 As New List(Of String) 'Resin Head Pressure
        'Dim strparam6 As New List(Of String) 'Hardener Head Pressure
        'Dim strparam7 As New List(Of String) 'Resin Temp
        'Dim strparam8 As New List(Of String) 'Hardener Temp
        'Dim strparam9 As New List(Of String) 'Ratio
        'Dim strparam10 As New List(Of String) 'Dispense On/Off
        'Dim strparam11 As New List(Of String) ' Combined flow rate
        'Dim strparam12 As New List(Of String) ' Cummulative flow

    End Sub 'Pump Type Change

    Private Function CheckEntries() As Boolean
        Dim BoolCheckName As Boolean = frmmain.CheckInvalidString(TxtName.Text)
        If BoolCheckName = True Then
            Return True
        End If
        DGV1.EndEdit()
        DGV1.ClearSelection()
        For Each r As DataGridViewRow In DGV1.Rows
            If Not IsNumeric(r.Cells(1).Value) Then
                Return True
            End If
            If Not Val(r.Cells(1).Value) = Int(r.Cells(1).Value) Then
                Return True
            End If
        Next
        Return False
    End Function 'Checks User Entries, Return True for Error

    Private Function WritePsf(ByVal StrFile As String) As Boolean
        Try
            Dim fsettings As New FileStream(StrFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)
            fsettings.Close()
            Dim textout As New StreamWriter(New FileStream(StrFile, FileMode.Open, FileAccess.Write))
            textout.WriteLine("Pump Name:" + TxtName.Text)
            textout.WriteLine("Pump Type:" + CboType.Text)
            For Each r As DataGridViewRow In DGV1.Rows
                textout.WriteLine(r.Cells(0).Value.ToString + ":" + r.Cells(1).Value.ToString)
            Next
            textout.WriteLine("IP Address:" + TxtIPAddress.Text.ToString)
            textout.Close()
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function 'Writes PSF File, returns True if error

    Private Function ReadPsf(ByVal StrFile As String) As Boolean
        Try
            Dim textin As New StreamReader(New FileStream(StrFile, FileMode.Open, FileAccess.Read))
            TxtName.Text = frmmain.SplitString(textin.ReadLine, ":", 1)
            If frmmain.SplitString(textin.ReadLine, ":", 1) = "FDI Pump" Then
                CboType.SelectedIndex = 0
            Else
                CboType.SelectedIndex = 1
            End If
            For i As Integer = 0 To DGV1.Rows.Count - 1
                DGV1.Rows(i).Cells(1).Value = frmmain.SplitString(textin.ReadLine, ":", 1)
            Next
            If CboType.SelectedIndex = 1 Then
                TxtIPAddress.Text = FrmMain.SplitString(textin.ReadLine, ":", 1)
            End If
            textin.Close()
            Return False
        Catch ex As Exception
            Return True
        End Try

    End Function 'Read PSF File, returns Ture if Error

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If Not Directory.Exists($"{FrmMain.baseDirectory}\Data\Pump Devices") Then
            Directory.CreateDirectory($"{FrmMain.baseDirectory}\Data\Pump Devices")
        End If
        Dim BoolCheckEntries As Boolean = Me.CheckEntries
        If BoolCheckEntries = False Then
            Dim BoolWritePSF As Boolean = Me.WritePsf($"{FrmMain.baseDirectory}\Data\Pump Devices\{TxtName.Text}.psf")
            If BoolWritePSF = False Then
                MsgBox("Pump Device " + TxtName.Text + ".psf has been saved.")
            Else
                MsgBox("Error while saving file.")
            End If
        End If

    End Sub 'Save Button

    Private Sub OpenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem1.Click
        Try
            If Not Directory.Exists($"{FrmMain.baseDirectory}\Data\Pump Devices") Then
                Directory.CreateDirectory($"{FrmMain.baseDirectory}\Data\Pump Devices")
            End If
            OpenFileDialog1.InitialDirectory = $"{FrmMain.baseDirectory}\Data\Pump Devices\"
            OpenFileDialog1.Title = "Open Pump Device Settings File (.psf)"
            OpenFileDialog1.Filter = "Pump Device Settings Files (*.psf)|*.psf"
            OpenFileDialog1.ShowDialog()
            Dim StrFile As String = OpenFileDialog1.FileName
            If StrFile = "" Then
                MsgBox("Please select a file.")
            End If
            OpenFileDialog1.Dispose()

            If File.Exists(StrFile) Then
                Dim BoolRead As Boolean = ReadPsf(StrFile)
                If BoolRead = False Then
                Else
                    MsgBox("Error loading pump settings file.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub 'Open Button

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub 'Close Button

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        DGV1.Rows.Clear()
        TxtName.Text = ""
    End Sub 'New Button
End Class