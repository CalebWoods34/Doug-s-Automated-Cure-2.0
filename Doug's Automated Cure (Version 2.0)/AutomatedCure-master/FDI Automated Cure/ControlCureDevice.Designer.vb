<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlCureDevice
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlCureDevice))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGVPart = New System.Windows.Forms.DataGridView()
        Me.ClmPartNumber = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ClmJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmAttachedThermocouples = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BtnDeletePart = New System.Windows.Forms.Button()
        Me.BtnAddPart = New System.Windows.Forms.Button()
        Me.LblName = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtControllerStatus = New System.Windows.Forms.TextBox()
        Me.LblControllerStatus = New System.Windows.Forms.Label()
        Me.TxtLogStatus = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPartTemp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSetpoint = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TemperatureLogChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnPreheat = New System.Windows.Forms.Button()
        Me.BtnLog = New System.Windows.Forms.Button()
        Me.BtnCure = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DGVCureInformation = New System.Windows.Forms.DataGridView()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnClearChart = New System.Windows.Forms.Button()
        Me.BtnViewSelectedLog = New System.Windows.Forms.Button()
        Me.BtnPrintSelectedLog = New System.Windows.Forms.Button()
        Me.DGVCureLogs = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Columnforpartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChkTemp = New System.Windows.Forms.CheckBox()
        Me.CureChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxRecipe = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TemperatureLogChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DGVCureInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVCureLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CureChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGVPart)
        Me.GroupBox1.Controls.Add(Me.BtnDeletePart)
        Me.GroupBox1.Controls.Add(Me.BtnAddPart)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 349)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 275)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Part Information"
        '
        'DGVPart
        '
        Me.DGVPart.AllowUserToAddRows = False
        Me.DGVPart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGVPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClmPartNumber, Me.ClmJob, Me.ClmSerial, Me.ClmAttachedThermocouples})
        Me.DGVPart.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGVPart.Location = New System.Drawing.Point(3, 16)
        Me.DGVPart.Name = "DGVPart"
        Me.DGVPart.RowHeadersVisible = False
        Me.DGVPart.RowHeadersWidth = 51
        Me.DGVPart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVPart.Size = New System.Drawing.Size(265, 217)
        Me.DGVPart.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.DGVPart, "Enter Part Information to start a preheat, cure, or temperature log" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add a par" &
        "t to the list, click Add Part or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add a part to the list, right click and sel" &
        "ect Add Part" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'ClmPartNumber
        '
        Me.ClmPartNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ClmPartNumber.HeaderText = "Part Number"
        Me.ClmPartNumber.MaxDropDownItems = 20
        Me.ClmPartNumber.MinimumWidth = 30
        Me.ClmPartNumber.Name = "ClmPartNumber"
        Me.ClmPartNumber.Width = 72
        '
        'ClmJob
        '
        Me.ClmJob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ClmJob.HeaderText = "Job"
        Me.ClmJob.MinimumWidth = 30
        Me.ClmJob.Name = "ClmJob"
        Me.ClmJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ClmJob.Width = 30
        '
        'ClmSerial
        '
        Me.ClmSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ClmSerial.HeaderText = "Serial"
        Me.ClmSerial.MinimumWidth = 20
        Me.ClmSerial.Name = "ClmSerial"
        Me.ClmSerial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ClmSerial.Width = 39
        '
        'ClmAttachedThermocouples
        '
        Me.ClmAttachedThermocouples.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ClmAttachedThermocouples.DataPropertyName = "ThermocoupleForm.ThermocoupleString"
        Me.ClmAttachedThermocouples.HeaderText = "TC"
        Me.ClmAttachedThermocouples.MinimumWidth = 30
        Me.ClmAttachedThermocouples.Name = "ClmAttachedThermocouples"
        Me.ClmAttachedThermocouples.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClmAttachedThermocouples.Text = "Select"
        Me.ClmAttachedThermocouples.ToolTipText = "Press to choose thermocouple attached to this part."
        Me.ClmAttachedThermocouples.UseColumnTextForButtonValue = True
        '
        'BtnDeletePart
        '
        Me.BtnDeletePart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDeletePart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDeletePart.ImageIndex = 4
        Me.BtnDeletePart.Location = New System.Drawing.Point(184, 239)
        Me.BtnDeletePart.Name = "BtnDeletePart"
        Me.BtnDeletePart.Size = New System.Drawing.Size(81, 30)
        Me.BtnDeletePart.TabIndex = 3
        Me.BtnDeletePart.Text = "Remove Part"
        Me.BtnDeletePart.UseVisualStyleBackColor = True
        '
        'BtnAddPart
        '
        Me.BtnAddPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAddPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAddPart.ImageIndex = 2
        Me.BtnAddPart.Location = New System.Drawing.Point(99, 239)
        Me.BtnAddPart.Name = "BtnAddPart"
        Me.BtnAddPart.Size = New System.Drawing.Size(79, 30)
        Me.BtnAddPart.TabIndex = 2
        Me.BtnAddPart.Text = "Add Part"
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
        Me.GroupBox2.Controls.Add(Me.TxtControllerStatus)
        Me.GroupBox2.Controls.Add(Me.LblControllerStatus)
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
        Me.GroupBox2.Size = New System.Drawing.Size(274, 158)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "In-Process Parameters"
        '
        'TxtControllerStatus
        '
        Me.TxtControllerStatus.BackColor = System.Drawing.SystemColors.Control
        Me.TxtControllerStatus.Location = New System.Drawing.Point(96, 126)
        Me.TxtControllerStatus.Name = "TxtControllerStatus"
        Me.TxtControllerStatus.ReadOnly = True
        Me.TxtControllerStatus.Size = New System.Drawing.Size(172, 20)
        Me.TxtControllerStatus.TabIndex = 3
        '
        'LblControllerStatus
        '
        Me.LblControllerStatus.AutoSize = True
        Me.LblControllerStatus.Location = New System.Drawing.Point(6, 129)
        Me.LblControllerStatus.Name = "LblControllerStatus"
        Me.LblControllerStatus.Size = New System.Drawing.Size(87, 13)
        Me.LblControllerStatus.TabIndex = 2
        Me.LblControllerStatus.Text = "Controller Status:"
        '
        'TxtLogStatus
        '
        Me.TxtLogStatus.Location = New System.Drawing.Point(96, 100)
        Me.TxtLogStatus.Name = "TxtLogStatus"
        Me.TxtLogStatus.ReadOnly = True
        Me.TxtLogStatus.Size = New System.Drawing.Size(172, 20)
        Me.TxtLogStatus.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtLogStatus, "Shows if temperature log status")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Log Status:"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(96, 74)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(172, 20)
        Me.TxtStatus.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtStatus, resources.GetString("TxtStatus.ToolTip"))
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Status:"
        '
        'TxtPartTemp
        '
        Me.TxtPartTemp.Location = New System.Drawing.Point(96, 48)
        Me.TxtPartTemp.Name = "TxtPartTemp"
        Me.TxtPartTemp.ReadOnly = True
        Me.TxtPartTemp.Size = New System.Drawing.Size(172, 20)
        Me.TxtPartTemp.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtPartTemp, "Temperature measured at input thermocouple")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Part Temp:"
        '
        'TxtSetpoint
        '
        Me.TxtSetpoint.Location = New System.Drawing.Point(96, 22)
        Me.TxtSetpoint.Name = "TxtSetpoint"
        Me.TxtSetpoint.ReadOnly = True
        Me.TxtSetpoint.Size = New System.Drawing.Size(172, 20)
        Me.TxtSetpoint.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtSetpoint, "Click to change setpoint.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Setpoint:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TemperatureLogChart
        '
        Me.TemperatureLogChart.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TemperatureLogChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight
        Me.TemperatureLogChart.BorderlineColor = System.Drawing.Color.Black
        Me.TemperatureLogChart.BorderlineWidth = 3
        ChartArea1.Name = "ChartArea1"
        Me.TemperatureLogChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.TemperatureLogChart.Legends.Add(Legend1)
        Me.TemperatureLogChart.Location = New System.Drawing.Point(291, 46)
        Me.TemperatureLogChart.MinimumSize = New System.Drawing.Size(200, 100)
        Me.TemperatureLogChart.Name = "TemperatureLogChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.TemperatureLogChart.Series.Add(Series1)
        Me.TemperatureLogChart.Size = New System.Drawing.Size(605, 291)
        Me.TemperatureLogChart.TabIndex = 5
        Me.TemperatureLogChart.Text = "Chart1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnPreheat)
        Me.GroupBox3.Controls.Add(Me.BtnLog)
        Me.GroupBox3.Controls.Add(Me.BtnCure)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 210)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(274, 133)
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
        Me.BtnPreheat.Location = New System.Drawing.Point(6, 16)
        Me.BtnPreheat.Name = "BtnPreheat"
        Me.BtnPreheat.Size = New System.Drawing.Size(262, 35)
        Me.BtnPreheat.TabIndex = 6
        Me.BtnPreheat.Tag = "Off"
        Me.BtnPreheat.Text = "Start Preheat"
        Me.BtnPreheat.UseVisualStyleBackColor = False
        '
        'BtnLog
        '
        Me.BtnLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLog.BackColor = System.Drawing.Color.Lime
        Me.BtnLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLog.Location = New System.Drawing.Point(6, 92)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(262, 35)
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
        Me.BtnCure.Location = New System.Drawing.Point(6, 54)
        Me.BtnCure.Name = "BtnCure"
        Me.BtnCure.Size = New System.Drawing.Size(262, 35)
        Me.BtnCure.TabIndex = 7
        Me.BtnCure.Text = "Start Cure"
        Me.BtnCure.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox4.CausesValidation = False
        Me.GroupBox4.Controls.Add(Me.DGVCureInformation)
        Me.GroupBox4.Location = New System.Drawing.Point(296, 349)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(386, 275)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cure Information"
        '
        'DGVCureInformation
        '
        Me.DGVCureInformation.AllowUserToAddRows = False
        Me.DGVCureInformation.AllowUserToDeleteRows = False
        Me.DGVCureInformation.AllowUserToResizeRows = False
        Me.DGVCureInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGVCureInformation.CausesValidation = False
        Me.DGVCureInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCureInformation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn1})
        Me.DGVCureInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVCureInformation.Location = New System.Drawing.Point(3, 16)
        Me.DGVCureInformation.Name = "DGVCureInformation"
        Me.DGVCureInformation.ReadOnly = True
        Me.DGVCureInformation.RowHeadersVisible = False
        Me.DGVCureInformation.RowHeadersWidth = 51
        Me.DGVCureInformation.Size = New System.Drawing.Size(380, 256)
        Me.DGVCureInformation.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.DGVCureInformation, "If an automated cure is configured for the selected part, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This shows the part's" &
        " required cure cycle.")
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewComboBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewComboBoxColumn1.HeaderText = "Cure Parameter"
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 6
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewComboBoxColumn1.ToolTipText = "Cure Parameter."
        Me.DataGridViewComboBoxColumn1.Width = 77
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Description of cure parameter."
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'BtnClearChart
        '
        Me.BtnClearChart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClearChart.Enabled = False
        Me.BtnClearChart.Location = New System.Drawing.Point(291, 319)
        Me.BtnClearChart.Name = "BtnClearChart"
        Me.BtnClearChart.Size = New System.Drawing.Size(75, 23)
        Me.BtnClearChart.TabIndex = 12
        Me.BtnClearChart.Text = "Clear Chart"
        Me.ToolTip1.SetToolTip(Me.BtnClearChart, "Clears all data points on the chart.")
        Me.BtnClearChart.UseVisualStyleBackColor = True
        Me.BtnClearChart.Visible = False
        '
        'BtnViewSelectedLog
        '
        Me.BtnViewSelectedLog.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnViewSelectedLog.Location = New System.Drawing.Point(216, 247)
        Me.BtnViewSelectedLog.Name = "BtnViewSelectedLog"
        Me.BtnViewSelectedLog.Size = New System.Drawing.Size(95, 22)
        Me.BtnViewSelectedLog.TabIndex = 2
        Me.BtnViewSelectedLog.Text = "View Selected"
        Me.ToolTip1.SetToolTip(Me.BtnViewSelectedLog, "Highlight the log and press View Selected button to view a log.")
        Me.BtnViewSelectedLog.UseVisualStyleBackColor = True
        '
        'BtnPrintSelectedLog
        '
        Me.BtnPrintSelectedLog.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnPrintSelectedLog.Enabled = False
        Me.BtnPrintSelectedLog.Location = New System.Drawing.Point(317, 247)
        Me.BtnPrintSelectedLog.Name = "BtnPrintSelectedLog"
        Me.BtnPrintSelectedLog.Size = New System.Drawing.Size(91, 22)
        Me.BtnPrintSelectedLog.TabIndex = 1
        Me.BtnPrintSelectedLog.Text = "Print Selected"
        Me.ToolTip1.SetToolTip(Me.BtnPrintSelectedLog, "Highlight a log and press Print Selected to print a log.")
        Me.BtnPrintSelectedLog.UseVisualStyleBackColor = True
        '
        'DGVCureLogs
        '
        Me.DGVCureLogs.AllowUserToAddRows = False
        Me.DGVCureLogs.AllowUserToDeleteRows = False
        Me.DGVCureLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVCureLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCureLogs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Columnforpartnumber, Me.JobNumber, Me.FileName})
        Me.DGVCureLogs.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGVCureLogs.Location = New System.Drawing.Point(3, 16)
        Me.DGVCureLogs.MultiSelect = False
        Me.DGVCureLogs.Name = "DGVCureLogs"
        Me.DGVCureLogs.ReadOnly = True
        Me.DGVCureLogs.RowHeadersVisible = False
        Me.DGVCureLogs.RowHeadersWidth = 51
        Me.DGVCureLogs.Size = New System.Drawing.Size(422, 225)
        Me.DGVCureLogs.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.DGVCureLogs, "List of all previously created temperature logs since the startup of the FDI Auto" &
        "mated Cure software.")
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Date Created"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 95
        '
        'Columnforpartnumber
        '
        Me.Columnforpartnumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Columnforpartnumber.HeaderText = "Part Number"
        Me.Columnforpartnumber.MinimumWidth = 6
        Me.Columnforpartnumber.Name = "Columnforpartnumber"
        Me.Columnforpartnumber.ReadOnly = True
        Me.Columnforpartnumber.Width = 91
        '
        'JobNumber
        '
        Me.JobNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JobNumber.HeaderText = "Job Number"
        Me.JobNumber.Name = "JobNumber"
        Me.JobNumber.ReadOnly = True
        Me.JobNumber.Width = 89
        '
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FileName.HeaderText = "File Name"
        Me.FileName.MinimumWidth = 6
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        '
        'ChkTemp
        '
        Me.ChkTemp.AutoSize = True
        Me.ChkTemp.Enabled = False
        Me.ChkTemp.Location = New System.Drawing.Point(769, 23)
        Me.ChkTemp.Name = "ChkTemp"
        Me.ChkTemp.Size = New System.Drawing.Size(127, 17)
        Me.ChkTemp.TabIndex = 11
        Me.ChkTemp.Text = "Temperature Logging"
        Me.ToolTip1.SetToolTip(Me.ChkTemp, "Blinks if temperature log is in progress.")
        Me.ChkTemp.UseVisualStyleBackColor = True
        '
        'CureChart
        '
        Me.CureChart.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CureChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight
        ChartArea2.Name = "ChartArea1"
        Me.CureChart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.CureChart.Legends.Add(Legend2)
        Me.CureChart.Location = New System.Drawing.Point(908, 46)
        Me.CureChart.Name = "CureChart"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.CureChart.Series.Add(Series2)
        Me.CureChart.Size = New System.Drawing.Size(425, 291)
        Me.CureChart.TabIndex = 14
        Me.CureChart.Text = "Chart2"
        Me.ToolTip1.SetToolTip(Me.CureChart, "Graphed lines show the recipe for each part." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "For parts to be cured together, the" &
        " curves should" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "lay on top of each other.")
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BtnPrintSelectedLog)
        Me.GroupBox6.Controls.Add(Me.DGVCureLogs)
        Me.GroupBox6.Controls.Add(Me.BtnViewSelectedLog)
        Me.GroupBox6.Location = New System.Drawing.Point(688, 349)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(428, 275)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Temperature Log Records"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ComboBoxRecipe)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.RadioButton1)
        Me.GroupBox7.Controls.Add(Me.RadioButton2)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Location = New System.Drawing.Point(17, 630)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(195, 175)
        Me.GroupBox7.TabIndex = 7
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Recipe Override"
        '
        'ComboBoxRecipe
        '
        Me.ComboBoxRecipe.FormattingEnabled = True
        Me.ComboBoxRecipe.Items.AddRange(New Object() {"post cure 1", "post cure 2", "post cure 3", "post cure 4"})
        Me.ComboBoxRecipe.Location = New System.Drawing.Point(15, 135)
        Me.ComboBoxRecipe.Name = "ComboBoxRecipe"
        Me.ComboBoxRecipe.Size = New System.Drawing.Size(171, 21)
        Me.ComboBoxRecipe.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 65)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Normally the recipe stored with the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "part is the recipe you want to use." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use ca" &
    "ution when overriding recipes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as scrapped parts can result from the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wrong cur" &
    "e recipe."
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(15, 89)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(110, 17)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Use Part's Recipe"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(15, 112)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(117, 17)
        Me.RadioButton2.TabIndex = 7
        Me.RadioButton2.Text = "Use Oven's Recipe"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ControlCureDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoScrollMargin = New System.Drawing.Size(5, 5)
        Me.AutoScrollMinSize = New System.Drawing.Size(1380, 900)
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.CureChart)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.BtnClearChart)
        Me.Controls.Add(Me.ChkTemp)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TemperatureLogChart)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "ControlCureDevice"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.Size = New System.Drawing.Size(1334, 888)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGVPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TemperatureLogChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DGVCureInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVCureLogs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CureChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
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
    Friend WithEvents TemperatureLogChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents BtnCure As System.Windows.Forms.Button
    Friend WithEvents BtnPreheat As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVCureInformation As System.Windows.Forms.DataGridView
    Friend WithEvents BtnLog As System.Windows.Forms.Button
    Friend WithEvents BtnDeletePart As System.Windows.Forms.Button
    Friend WithEvents BtnAddPart As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ChkTemp As System.Windows.Forms.CheckBox
    Public WithEvents DGVPart As DataGridView
    Friend WithEvents BtnClearChart As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVCureLogs As System.Windows.Forms.DataGridView
    Friend WithEvents BtnPrintSelectedLog As System.Windows.Forms.Button
    Friend WithEvents BtnViewSelectedLog As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxRecipe As ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Columnforpartnumber As DataGridViewTextBoxColumn
    Friend WithEvents JobNumber As DataGridViewTextBoxColumn
    Friend WithEvents FileName As DataGridViewTextBoxColumn
    Friend WithEvents ClmPartNumber As DataGridViewComboBoxColumn
    Friend WithEvents ClmJob As DataGridViewTextBoxColumn
    Friend WithEvents ClmSerial As DataGridViewTextBoxColumn
    Friend WithEvents ClmAttachedThermocouples As DataGridViewButtonColumn
    Friend WithEvents TxtControllerStatus As System.Windows.Forms.TextBox
    Friend WithEvents LblControllerStatus As System.Windows.Forms.Label
    Friend WithEvents CureChart As DataVisualization.Charting.Chart
End Class
