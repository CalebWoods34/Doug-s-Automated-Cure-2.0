<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlPumpDevice
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlPumpDevice))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.ChkPump = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnEnd = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtFlowRate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPressure = New System.Windows.Forms.TextBox()
        Me.TxtRunTime = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.DGVPart = New System.Windows.Forms.DataGridView()
        Me.ClmPartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddPartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnDeletePart = New System.Windows.Forms.Button()
        Me.BtnAddPart = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.BtnViewSelected = New System.Windows.Forms.Button()
        Me.BtnPrintSelected = New System.Windows.Forms.Button()
        Me.DGVCureLogs = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Columnforpartnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGVPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DGVCureLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkPump
        '
        Me.ChkPump.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkPump.AutoSize = True
        Me.ChkPump.Location = New System.Drawing.Point(799, 23)
        Me.ChkPump.Name = "ChkPump"
        Me.ChkPump.Size = New System.Drawing.Size(107, 17)
        Me.ChkPump.TabIndex = 16
        Me.ChkPump.Text = "Injection Logging"
        Me.ToolTip1.SetToolTip(Me.ChkPump, "Blinks if injection log is in progress.")
        Me.ChkPump.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnStart)
        Me.GroupBox3.Controls.Add(Me.BtnEnd)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 183)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 114)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Actions"
        '
        'BtnStart
        '
        Me.BtnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnStart.BackColor = System.Drawing.Color.Lime
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStart.ImageKey = "Start Logger.JPG"
        Me.BtnStart.ImageList = Me.ImageList1
        Me.BtnStart.Location = New System.Drawing.Point(6, 22)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(196, 40)
        Me.BtnStart.TabIndex = 6
        Me.BtnStart.Text = "Start Data Logger"
        Me.BtnStart.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PlusMod.jpg")
        Me.ImageList1.Images.SetKeyName(1, "X.jpg")
        Me.ImageList1.Images.SetKeyName(2, "End Logger.JPG")
        Me.ImageList1.Images.SetKeyName(3, "Start Logger.JPG")
        Me.ImageList1.Images.SetKeyName(4, "Check.JPG")
        Me.ImageList1.Images.SetKeyName(5, "X Shaded.JPG")
        '
        'BtnEnd
        '
        Me.BtnEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnEnd.BackColor = System.Drawing.Color.Red
        Me.BtnEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEnd.ImageKey = "End Logger.JPG"
        Me.BtnEnd.ImageList = Me.ImageList1
        Me.BtnEnd.Location = New System.Drawing.Point(6, 68)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(196, 40)
        Me.BtnEnd.TabIndex = 7
        Me.BtnEnd.Text = "End Data Logger"
        Me.BtnEnd.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtStatus)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtFlowRate)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtPressure)
        Me.GroupBox2.Controls.Add(Me.TxtRunTime)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 131)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "In-Process Parameters"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(71, 19)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(131, 20)
        Me.TxtStatus.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtStatus, "Log Status")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Log Status:"
        '
        'TxtFlowRate
        '
        Me.TxtFlowRate.Location = New System.Drawing.Point(85, 106)
        Me.TxtFlowRate.Name = "TxtFlowRate"
        Me.TxtFlowRate.ReadOnly = True
        Me.TxtFlowRate.Size = New System.Drawing.Size(117, 20)
        Me.TxtFlowRate.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtFlowRate, "Flow Rate")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Flow Rate:"
        '
        'TxtPressure
        '
        Me.TxtPressure.Location = New System.Drawing.Point(85, 77)
        Me.TxtPressure.Name = "TxtPressure"
        Me.TxtPressure.ReadOnly = True
        Me.TxtPressure.Size = New System.Drawing.Size(117, 20)
        Me.TxtPressure.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtPressure, "Pump Pressure in psi.")
        '
        'TxtRunTime
        '
        Me.TxtRunTime.Location = New System.Drawing.Point(91, 48)
        Me.TxtRunTime.Name = "TxtRunTime"
        Me.TxtRunTime.ReadOnly = True
        Me.TxtRunTime.Size = New System.Drawing.Size(111, 20)
        Me.TxtRunTime.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtRunTime, "Duration of Injection Log in minutes.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Log Time (min):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pressure (psi):"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(13, 10)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(91, 25)
        Me.LblName.TabIndex = 12
        Me.LblName.Text = "Pump 1"
        '
        'DGVPart
        '
        Me.DGVPart.AllowUserToAddRows = False
        Me.DGVPart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DGVPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClmPartNumber, Me.Column1, Me.Column2})
        Me.DGVPart.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGVPart.Location = New System.Drawing.Point(6, 19)
        Me.DGVPart.Name = "DGVPart"
        Me.DGVPart.RowHeadersVisible = False
        Me.DGVPart.Size = New System.Drawing.Size(313, 252)
        Me.DGVPart.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.DGVPart, "Enter Part Information to start a preheat, cure, or temperature log" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add a par" &
        "t to the list, click Add Part or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To add a part to the list, right click and sel" &
        "ect Add Part" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'ClmPartNumber
        '
        Me.ClmPartNumber.HeaderText = "Part Number"
        Me.ClmPartNumber.Name = "ClmPartNumber"
        Me.ClmPartNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClmPartNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ClmPartNumber.ToolTipText = "Select Part Number"
        Me.ClmPartNumber.Width = 150
        '
        'Column1
        '
        Me.Column1.FillWeight = 150.0!
        Me.Column1.HeaderText = "Job"
        Me.Column1.Name = "Column1"
        Me.Column1.ToolTipText = "Enter Job Number"
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.FillWeight = 150.0!
        Me.Column2.HeaderText = "Serial"
        Me.Column2.Name = "Column2"
        Me.Column2.ToolTipText = "Enter Serial Number"
        Me.Column2.Width = 60
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPartToolStripMenuItem, Me.DeleteSelectedToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(155, 92)
        '
        'AddPartToolStripMenuItem
        '
        Me.AddPartToolStripMenuItem.Image = Global.FDI_Automated_Cure.My.Resources.Resources.PlusMod
        Me.AddPartToolStripMenuItem.Name = "AddPartToolStripMenuItem"
        Me.AddPartToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AddPartToolStripMenuItem.Text = "Add Part"
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Image = Global.FDI_Automated_Cure.My.Resources.Resources.X
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "Delete Selected"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnClear)
        Me.GroupBox1.Controls.Add(Me.BtnDeletePart)
        Me.GroupBox1.Controls.Add(Me.BtnAddPart)
        Me.GroupBox1.Controls.Add(Me.DGVPart)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 303)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 318)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Part Information"
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClear.ImageIndex = 5
        Me.BtnClear.ImageList = Me.ImageList1
        Me.BtnClear.Location = New System.Drawing.Point(236, 277)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(83, 38)
        Me.BtnClear.TabIndex = 4
        Me.BtnClear.Text = "Clear List"
        Me.BtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnDeletePart
        '
        Me.BtnDeletePart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDeletePart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDeletePart.ImageIndex = 5
        Me.BtnDeletePart.ImageList = Me.ImageList1
        Me.BtnDeletePart.Location = New System.Drawing.Point(113, 277)
        Me.BtnDeletePart.Name = "BtnDeletePart"
        Me.BtnDeletePart.Size = New System.Drawing.Size(102, 38)
        Me.BtnDeletePart.TabIndex = 3
        Me.BtnDeletePart.Text = "Remove Part"
        Me.BtnDeletePart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDeletePart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDeletePart.UseVisualStyleBackColor = True
        '
        'BtnAddPart
        '
        Me.BtnAddPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAddPart.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAddPart.ImageKey = "Check.JPG"
        Me.BtnAddPart.ImageList = Me.ImageList1
        Me.BtnAddPart.Location = New System.Drawing.Point(8, 277)
        Me.BtnAddPart.Name = "BtnAddPart"
        Me.BtnAddPart.Size = New System.Drawing.Size(87, 38)
        Me.BtnAddPart.TabIndex = 2
        Me.BtnAddPart.Text = "Add Part"
        Me.BtnAddPart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAddPart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAddPart.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
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
        Me.Chart1.Size = New System.Drawing.Size(675, 251)
        Me.Chart1.TabIndex = 14
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BtnViewSelected)
        Me.GroupBox6.Controls.Add(Me.BtnPrintSelected)
        Me.GroupBox6.Controls.Add(Me.DGVCureLogs)
        Me.GroupBox6.Location = New System.Drawing.Point(354, 303)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(481, 318)
        Me.GroupBox6.TabIndex = 18
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Injection Log Records"
        '
        'BtnViewSelected
        '
        Me.BtnViewSelected.Location = New System.Drawing.Point(283, 277)
        Me.BtnViewSelected.Name = "BtnViewSelected"
        Me.BtnViewSelected.Size = New System.Drawing.Size(95, 33)
        Me.BtnViewSelected.TabIndex = 2
        Me.BtnViewSelected.Text = "View Selected"
        Me.ToolTip1.SetToolTip(Me.BtnViewSelected, "Highlight the log and press View Selected button to view a log.")
        Me.BtnViewSelected.UseVisualStyleBackColor = True
        '
        'BtnPrintSelected
        '
        Me.BtnPrintSelected.Location = New System.Drawing.Point(384, 277)
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
        Me.DGVCureLogs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Columnforpartnumber, Me.DataGridViewTextBoxColumn2})
        Me.DGVCureLogs.Location = New System.Drawing.Point(6, 19)
        Me.DGVCureLogs.MultiSelect = False
        Me.DGVCureLogs.Name = "DGVCureLogs"
        Me.DGVCureLogs.RowHeadersVisible = False
        Me.DGVCureLogs.Size = New System.Drawing.Size(469, 252)
        Me.DGVCureLogs.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.DGVCureLogs, "List of all previously created injection logs since the startup of the FDI Automa" &
        "ted Cure software.")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'Columnforpartnumber
        '
        Me.Columnforpartnumber.HeaderText = "Part Number"
        Me.Columnforpartnumber.Name = "Columnforpartnumber"
        Me.Columnforpartnumber.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "File Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'ControlPumpDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkPump)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblName)
        Me.Name = "ControlPumpDevice"
        Me.Size = New System.Drawing.Size(917, 863)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGVPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.DGVCureLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkPump As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents BtnEnd As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFlowRate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPressure As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRunTime As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents BtnDeletePart As System.Windows.Forms.Button
    Public WithEvents DGVPart As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAddPart As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddPartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClmPartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnViewSelected As System.Windows.Forms.Button
    Friend WithEvents BtnPrintSelected As System.Windows.Forms.Button
    Friend WithEvents DGVCureLogs As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Columnforpartnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
