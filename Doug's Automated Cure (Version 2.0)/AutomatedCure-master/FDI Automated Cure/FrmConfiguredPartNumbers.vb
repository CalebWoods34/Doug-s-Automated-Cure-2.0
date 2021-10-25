Imports System.IO


Public Class FrmConfiguredPartNumbers

    Public LstCureDeviceNames As New List(Of String) 'List of Station Names

    Private Sub FrmConfiguredPartNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.LstCureDeviceNames.Count = 0 Then
            For Each s As String In LstCureDeviceNames
                Dim ClmNew As New DataGridViewTextBoxColumn
                ClmNew.HeaderText = s
                ClmNew.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                DGV1.Columns.Add(ClmNew)
            Next
        End If

        Dim LstPartNumbers As New List(Of String) 'List of potential parts with configured recipes
        If Directory.Exists("C:\Programs\FDI MPCS\Data\Part Recipes") Then
            Dim DirInfo As New IO.DirectoryInfo("C:\Programs\FDI MPCS\Data\Part Recipes")
            Dim Dir1 As IO.FileInfo() = DirInfo.GetFiles()
            For Each D As IO.FileInfo In Dir1
                If D.ToString.Contains(".prf") Then
                    Dim StrSplit As String = FrmMain.SplitString(D.ToString, "\", 777)
                    StrSplit = FrmMain.SplitString(StrSplit, "_", 0)
                    LstPartNumbers.Add(StrSplit) '
                End If
            Next
        End If

        For Each s As String In LstPartNumbers
            Dim BoolAlreadyExists As Boolean = False
            For Each r As DataGridViewRow In DGV1.Rows()
                If r.Cells(0).Value = s Then
                    BoolAlreadyExists = True
                End If
            Next
            If BoolAlreadyExists = False Then
                DGV1.Rows.Add(s)
            End If
        Next
        If Directory.Exists("C:\Programs\FDI MPCS\Data\Part Recipes") Then
            Dim DirInfo As New IO.DirectoryInfo("C:\Programs\FDI MPCS\Data\Part Recipes")
            Dim Dir1 As IO.FileInfo() = DirInfo.GetFiles()
            For i As Integer = 1 To DGV1.Columns.Count - 1
                For j As Integer = 0 To DGV1.Rows.Count - 1
                    For Each d As IO.FileInfo In Dir1
                        If d.ToString.Contains(DGV1.Columns(i).HeaderText) And d.ToString.Contains(DGV1.Rows(j).Cells(0).Value) Then
                            DGV1.Rows(j).Cells(i).Value = "X"
                        End If
                    Next
                Next
            Next
        End If

        'Resizing of Form
        Dim IntWidth As Integer = 0
        Dim IntHeight As Integer = 0
        For Each c As DataGridViewColumn In DGV1.Columns
            IntWidth = IntWidth + c.Width
        Next
        For Each t As DataGridViewRow In DGV1.Rows
            IntHeight = IntHeight + t.Height
        Next
        Me.Size = New System.Drawing.Size(IntWidth + 85, IntHeight + 100)
        Label2.Text = System.DateTime.Now.ToString
    End Sub 'Form Load

    Private Sub FrmConfiguredPartNumbers_closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub 'Form Closing

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintDocument1.Print()
    End Sub 'Print Button

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DGV1.Width, Me.DGV1.Height)
        DGV1.DrawToBitmap(bm, New System.Drawing.Rectangle(0, 0, Me.DGV1.Width, Me.DGV1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub 'Print Document Writing

End Class