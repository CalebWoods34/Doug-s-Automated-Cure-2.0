<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlCureDevice
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlCureDevice))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DGVPart = New System.Windows.Forms.DataGridView
        Me.ClmPartNumber = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ClmJob = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClmSerial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnClear = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnDeletePart = New System.Windows.Forms.Button
        Me.BtnAddPart = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtLogStatus = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtStatus = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPartTemp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSetpoint = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnPreheat = New System.Windows.Forms.Button
        Me.BtnLog = New System.Windows.Forms.Button
        Me.BtnCure = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.DGVCureInformation = New System.Windows.Forms.DataGridView
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.BtnPID = New System.Windows.Forms.Button
        Me.DGVPID = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BrnClear = New System.Windows.Forms.Button
        Me.BtnViewSelected = New System.Windows.Forms.Button
        Me.BtnPrintSelected = New System.Windows.Forms.Button
        Me.DGVCureLogs = New System.Windows.Forms.DataGridView
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Columnforpartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChkTemp = New System.Windows.Forms.CheckBox
        Me.CMSLogging = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartTemperatureLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EndTemperatureLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVCureInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGVPID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVCureLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSLogging.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPartToolStripMenuItem, Me.DeleteSelectedToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(154, 92)
        '
        'AddPartToolStripMenuItem
        '
        Me.AddPartToolStripMenuItem.Image = Global.FDI_Automated_Cure.My.Resources.Resources.PlusMod
        Me.AddPartToolStripMenuItem.Name = "AddPartToolStripMenuItem"
        Me.AddPartToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AddPartToolStripMenuItem.Text = "Add Part"
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Image = Global.FDI_Automated_Cure.My.Resources.Resources.X
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "Delete Selected"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGVPart)
        Me.GroupBox1.Controls.Add(Me.BtnClear)
        Me.GroupBox1.Controls.Add(Me.BtnDeletePart)
        Me.GroupBox1.Controls.Add(Me.BtnAddPart)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 322)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 289)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Part Information"
        '
        'DGVPart
        '
        Me.DGVPart.AllowUserToAddRows = False
        Me.DGVPart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClmPartNumber, Me.ClmJob, Me.ClmSerial})
        Me.DGVPart.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGVPart.Location = New System.Drawing.Point(8, 19)
        Me.DGVPart.Name = "DGVPart"
        Me.DGVPart.Size = New System.Drawing.Size(315, 231)
        Me.DGVPart.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.DGVPart, "Enter Part Information to start a preheat, cure, or temperature log" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add a par" & _
                "t to the list, click Add Part or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add a part to the list, right click and sel" & _
                "ect Add Part" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'ClmPartNumber
        '
        Me.ClmPartNumber.HeaderText = "Part Number"
        Me.ClmPartNumber.MaxDropDownItems = 20
        Me.ClmPartNumber.Name = "ClmPartNumber"
        Me.ClmPartNumber.Width = 150
        '
        'ClmJob
        '
        Me.ClmJob.HeaderText = "Job"
        Me.ClmJob.Name = "ClmJob"
        Me.ClmJob.Width = 60
        '
        'ClmSerial
        '
        Me.ClmSerial.HeaderText = "Serial"
        Me.ClmSerial.Name = "ClmSerial"
        Me.ClmSerial.Width = 60
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClear.ImageIndex = 3
        Me.BtnClear.ImageList = Me.ImageList1
        Me.BtnClear.Location = New System.Drawing.Point(237, 256)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(82, 30)
        Me.BtnClear.TabIndex = 4
        Me.BtnClear.Text = "Clear List"
        Me.BtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PlusMod.jpg")
        Me.ImageList1.Images.SetKeyName(1, "X.jpg")
        Me.ImageList1.Images.SetKeyName(2, "Check.JPG")
        Me.ImageList1.Images.SetKeyName(3, "X Shaded.JPG")
        Me.ImageList1.Images.SetKeyName(4, "Start Logger.JPG")
        Me.ImageList1.Images.SetKeyName(5, "End Logger.JPG")
        Me.ImageList1.Images.SetKeyName(6, "Start Cure.JPG")
        Me.ImageList1.Images.SetKeyName(7, "End Cure.JPG")
        Me.ImageList1.Images.SetKeyName(8, "Start Preheat.JPG")
        Me.ImageList1.Images.SetKeyName(9, "End Preheat.JPG")
        Me.ImageList1.Images.SetKeyName(10, "PID Settings.JPG")
        '
        'BtnDeletePart
        '
        Me.BtnDeletePart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDeletePart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDeletePart.ImageIndex = 3
        Me.BtnDeletePart.ImageList = Me.ImageList1
        Me.BtnDeletePart.Location = New System.Drawing.Point(114, 256)
        Me.BtnDeletePart.Name = "BtnDeletePart"
        Me.BtnDeletePart.Size = New System.Drawing.Size(102, 30)
        Me.BtnDeletePart.TabIndex = 3
        Me.BtnDeletePart.Text = "Remove Part"
        Me.BtnDeletePart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDeletePart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDeletePart.UseVisualStyleBackColor = True
        '
        'BtnAddPart
        '
        Me.BtnAddPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAddPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAddPart.ImageIndex = 2
        Me.BtnAddPart.ImageList = Me.ImageList1
        Me.BtnAddPart.Location = New System.Drawing.Point(8, 256)
        Me.BtnAddPart.Name = "BtnAddPart"
        Me.BtnAddPart.Size = New System.Drawing.Size(79, 30)
        Me.BtnAddPart.TabIndex = 2
        Me.BtnAddPart.Text = "Add Part"
        Me.BtnAddPart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAddPart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAddPart.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(13, 10)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(89, 25)
        Me.LblName.TabIndex = 3
        Me.LblName.Text = "Oven A"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtLogStatus)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtStatus)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtPartTemp)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TxtSetpoint)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 131)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "In-Process Parameters"
        '
        'TxtLogStatus
        '
        Me.TxtLogStatus.Location = New System.Drawing.Point(71, 100)
        Me.TxtLogStatus.Name = "TxtLogStatus"
        Me.TxtLogStatus.ReadOnly = True
        Me.TxtLogStatus.Size = New System.Drawing.Size(131, 20)
        Me.TxtLogStatus.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtLogStatus, "Shows if temperature log status")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Log Status:"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(71, 74)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(131, 20)
        Me.TxtStatus.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtStatus, resources.GetString("TxtStatus.ToolTip"))
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Status:"
        '
        'TxtPartTemp
        '
        Me.TxtPartTemp.Location = New System.Drawing.Point(71, 48)
        Me.TxtPartTemp.Name = "TxtPartTemp"
        Me.TxtPartTemp.ReadOnly = True
        Me.TxtPartTemp.Size = New System.Drawing.Size(131, 20)
        Me.TxtPartTemp.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtPartTemp, "Temperature measured at input thermocouple")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Part Temp:"
        '
        'TxtSetpoint
        '
        Me.TxtSetpoint.Location = New System.Drawing.Point(71, 22)
        Me.TxtSetpoint.Name = "TxtSetpoint"
        Me.TxtSetpoint.Size = New System.Drawing.Size(131, 20)
        Me.TxtSetpoint.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtSetpoint, "Double-Click to change setpoint.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Setpoint: "
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight
        Me.Chart1.BorderlineColor = System.Drawing.Color.Black
        Me.Chart1.BorderlineWidth = 3
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(231, 46)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(985, 270)
        Me.Chart1.TabIndex = 5
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnPreheat)
        Me.GroupBox3.Controls.Add(Me.BtnLog)
        Me.GroupBox3.Controls.Add(Me.BtnCure)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 183)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 133)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Actions"
        '
        'BtnPreheat
        '
        Me.BtnPreheat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPreheat.BackColor = System.Drawing.Color.Lime
        Me.BtnPreheat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreheat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPreheat.ImageIndex = 8
        Me.BtnPreheat.ImageList = Me.ImageList1
        Me.BtnPreheat.Location = New System.Drawing.Point(6, 16)
        Me.BtnPreheat.Name = "BtnPreheat"
        Me.BtnPreheat.Size = New System.Drawing.Size(196, 35)
        Me.BtnPreheat.TabIndex = 6
        Me.BtnPreheat.Text = "Start Preheat"
        Me.BtnPreheat.UseVisualStyleBackColor = False
        '
        'BtnLog
        '
        Me.BtnLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLog.BackColor = System.Drawing.Color.Lime
        Me.BtnLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLog.ImageIndex = 4
        Me.BtnLog.ImageList = Me.ImageList1
        Me.BtnLog.Location = New System.Drawing.Point(6, 92)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(196, 35)
        Me.BtnLog.TabIndex = 7
        Me.BtnLog.Text = "Start Temperature Log"
        Me.BtnLog.UseVisualStyleBackColor = False
        '
        'BtnCure
        '
        Me.BtnCure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCure.BackColor = System.Drawing.Color.Lime
        Me.BtnCure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCure.ImageIndex = 6
        Me.BtnCure.ImageList = Me.ImageList1
        Me.BtnCure.Location = New System.Drawing.Point(6, 54)
        Me.BtnCure.Name = "BtnCure"
        Me.BtnCure.Size = New System.Drawing.Size(196, 35)
        Me.BtnCure.TabIndex = 7
        Me.BtnCure.Text = "Start Cure"
        Me.BtnCure.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Chart2)
        Me.GroupBox4.Controls.Add(Me.DGVCureInformation)
        Me.GroupBox4.Location = New System.Drawing.Point(356, 322)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(860, 289)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cure Information"
        '
        'Chart2
        '
        Me.Chart2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(375, 19)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(479, 264)
        Me.Chart2.TabIndex = 2
        Me.Chart2.Text = "Chart2"
        Me.ToolTip1.SetToolTip(Me.Chart2, "If an automated cure is configured for the selected part, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "this chart shows the " & _
                "cure cycle vs. time.")
        '
        'DGVCureInformation
        '
        Me.DGVCureInformation.AllowUserToAddRows = False
        Me.DGVCureInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DGVCureInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCureInformation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn1})
        Me.DGVCureInformation.Location = New System.Drawing.Point(6, 19)
        Me.DGVCureInformation.Name = "DGVCureInformation"
        Me.DGVCureInformation.Size = New System.Drawing.Size(363, 264)
        Me.DGVCureInformation.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.DGVCureInformation, "If an automated cure is configured for the selected part, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This shows the part's" & _
                " required cure cycle.")
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "Cure Parameter"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewComboBoxColumn1.ToolTipText = "Cure Parameter."
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Description of cure parameter."
        Me.DataGridViewTextBoxColumn1.Width = 220
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BtnPID)
        Me.GroupBox5.Controls.Add(Me.DGVPID)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 617)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(285, 280)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "PID Settings"
        '
        'BtnPID
        '
        Me.BtnPID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPID.BackColor = System.Drawing.Color.Lime
        Me.BtnPID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPID.ImageKey = "PID Settings.JPG"
        Me.BtnPID.ImageList = Me.ImageList1
        Me.BtnPID.Location = New System.Drawing.Point(36, 244)
        Me.BtnPID.Name = "BtnPID"
        Me.BtnPID.Size = New System.Drawing.Size(181, 33)
        Me.BtnPID.TabIndex = 5
        Me.BtnPID.Text = "Send PID Settings"
        Me.BtnPID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPID.UseVisualStyleBackColor = False
        '
        'DGVPID
        '
        Me.DGVPID.AllowUserToAddRows = False
        Me.DGVPID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVPID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPID.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DGVPID.Location = New System.Drawing.Point(6, 19)
        Me.DGVPID.Name = "DGVPID"
        Me.DGVPID.Size = New System.Drawing.Size(271, 222)
        Me.DGVPID.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.DGVPID, resources.GetString("DGVPID.ToolTip"))
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Parameter"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ToolTipText = "Enter Job Number"
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ToolTipText = "Enter Serial Number"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'BrnClear
        '
        Me.BrnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrnClear.Location = New System.Drawing.Point(1141, 293)
        Me.BrnClear.Name = "BrnClear"
        Me.BrnClear.Size = New System.Drawing.Size(75, 23)
        Me.BrnClear.TabIndex = 12
        Me.BrnClear.Text = "Clear Chart"
        Me.ToolTip1.SetToolTip(Me.BrnClear, "Clears all data points on the chart.")
        Me.BrnClear.UseVisualStyleBackColor = True
        '
        'BtnViewSelected
        '
        Me.BtnViewSelected.Location = New System.Drawing.Point(283, 244)
        Me.BtnViewSelected.Name = "BtnViewSelected"
        Me.BtnViewSelected.Size = New System.Drawing.Size(95, 33)
        Me.BtnViewSelected.TabIndex = 2
        Me.BtnViewSelected.Text = "View Selected"
        Me.ToolTip1.SetToolTip(Me.BtnViewSelected, "Highlight the log and press View Selected button to view a log.")
        Me.BtnViewSelected.UseVisualStyleBackColor = True
        '
        'BtnPrintSelected
        '
        Me.BtnPrintSelected.Location = New System.Drawing.Point(384, 244)
        Me.BtnPrintSelected.Name = "BtnPrintSelected"
        Me.BtnPrintSelected.Size = New System.Drawing.Size(91, 33)
        Me.BtnPrintSelected.TabIndex = 1
        Me.BtnPrintSelected.Text = "Print Selected"
        Me.ToolTip1.SetToolTip(Me.BtnPrintSelected, "Highlight a log and press Print Selected to print a log.")
        Me.BtnPrintSelected.UseVisualStyleBackColor = True
        '
        'DGVCureLogs
        '
        Me.DGVCureLogs.AllowUserToAddRows = False
        Me.DGVCureLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVCureLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCureLogs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Columnforpartnumber, Me.Column1})
        Me.DGVCureLogs.Location = New System.Drawing.Point(6, 19)
        Me.DGVCureLogs.MultiSelect = False
        Me.DGVCureLogs.Name = "DGVCureLogs"
        Me.DGVCureLogs.Size = New System.Drawing.Size(469, 222)
        Me.DGVCureLogs.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.DGVCureLogs, "List of all previously created temperature logs since the startup of the FDI Auto" & _
                "mated Cure software.")
        '
        'Column2
        '
        Me.Column2.HeaderText = "Date Created"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 120
        '
        'Columnforpartnumber
        '
        Me.Columnforpartnumber.HeaderText = "Part Number"
        Me.Columnforpartnumber.Name = "Columnforpartnumber"
        Me.Columnforpartnumber.Width = 120
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "File Name"
        Me.Column1.Name = "Column1"
        '
        'ChkTemp
        '
        Me.ChkTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTemp.AutoSize = True
        Me.ChkTemp.ContextMenuStrip = Me.CMSLogging
        Me.ChkTemp.Location = New System.Drawing.Point(1089, 23)
        Me.ChkTemp.Name = "ChkTemp"
        Me.ChkTemp.Size = New System.Drawing.Size(127, 17)
        Me.ChkTemp.TabIndex = 11
        Me.ChkTemp.Text = "Temperature Logging"
        Me.ToolTip1.SetToolTip(Me.ChkTemp, "Blinks if temperature log is in progress.")
        Me.ChkTemp.UseVisualStyleBackColor = True
        '
        'CMSLogging
        '
        Me.CMSLogging.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartTemperatureLogToolStripMenuItem, Me.EndTemperatureLogToolStripMenuItem})
        Me.CMSLogging.Name = "CMSLogging"
        Me.CMSLogging.Size = New System.Drawing.Size(184, 48)
        '
        'StartTemperatureLogToolStripMenuItem
        '
        Me.StartTemperatureLogToolStripMenuItem.Image = Global.FDI_Automated_Cure.My.Resources.Resources.Start_Logger
        Me.StartTemperatureLogToolStripMenuItem.Name = "StartTemperatureLogToolStripMenuItem"
        Me.StartTemperatureLogToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.StartTemperatureLogToolStripMenuItem.Text = "Start Temperature Log"
        '
        'EndTemperatureLogToolStripMenuItem
        '
        Me.EndTemperatureLogToolStripMenuItem.Image = Global.FDI_Automated_Cure.My.Resources.Resources.End_Logger
        Me.EndTemperatureLogToolStripMenuItem.Name = "EndTemperatureLogToolStripMenuItem"
        Me.EndTemperatureLogToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.EndTemperatureLogToolStripMenuItem.Text = "End Temperature Log"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BtnViewSelected)
        Me.GroupBox6.Controls.Add(Me.BtnPrintSelected)
        Me.GroupBox6.Controls.Add(Me.DGVCureLogs)
        Me.GroupBox6.Location = New System.Drawing.Point(309, 617)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(481, 280)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Temperature Log Records"
        '
        'ControlCureDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BrnClear)
        Me.Controls.Add(Me.ChkTemp)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "ControlCureDevice"
        Me.Size = New System.Drawing.Size(1227, 900)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGVPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVCureInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DGVPID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVCureLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSLogging.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLogStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPartTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSetpoint As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents BtnCure As System.Windows.Forms.Button
    Friend WithEvents BtnPreheat As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVCureInformation As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVPID As System.Windows.Forms.DataGridView
    Friend WithEvents BtnLog As System.Windows.Forms.Button
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents BtnDeletePart As System.Windows.Forms.Button
    Friend WithEvents BtnAddPart As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BtnPID As System.Windows.Forms.Button
    Friend WithEvents ChkTemp As System.Windows.Forms.CheckBox
    Friend WithEvents CMSLogging As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StartTemperatureLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EndTemperatureLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DGVPart As System.Windows.Forms.DataGridView
    Friend WithEvents BrnClear As System.Windows.Forms.Button
    Friend WithEvents ClmPartNumber As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ClmJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVCureLogs As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Columnforpartnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnPrintSelected As System.Windows.Forms.Button
    Friend WithEvents BtnViewSelected As System.Windows.Forms.Button

End Class
