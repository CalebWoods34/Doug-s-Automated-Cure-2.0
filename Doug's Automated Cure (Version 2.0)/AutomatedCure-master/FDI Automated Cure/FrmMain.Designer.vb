<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupPartNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CureDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PumpDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAvailableAutomatedCuresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewBackupLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateLogFromBackupLogFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewUserManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAdministratorManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutAutomatedCureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabHome = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGV2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.ClmPress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmSetpoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmPartTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmLogStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ClmPartsList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabAlarm = New System.Windows.Forms.TabPage()
        Me.BtnClearList = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnAlarm = New System.Windows.Forms.Button()
        Me.DGVAlarm = New System.Windows.Forms.DataGridView()
        Me.ClmTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmDevice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmAlarm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmActiion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabHome.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAlarm.SuspendLayout()
        CType(Me.DGVAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.UserToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Enabled = False
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.RefreshDevicesToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.ToolsToolStripMenuItem.Text = "Administrator"
        Me.ToolsToolStripMenuItem.ToolTipText = "Administrator Tools" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "These tools are restricted to supervisory personnel only."
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetupPartNumberToolStripMenuItem, Me.CureDeviceToolStripMenuItem, Me.PumpDeviceToolStripMenuItem})
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.AdminToolStripMenuItem.Text = "Setup"
        '
        'SetupPartNumberToolStripMenuItem
        '
        Me.SetupPartNumberToolStripMenuItem.Name = "SetupPartNumberToolStripMenuItem"
        Me.SetupPartNumberToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SetupPartNumberToolStripMenuItem.Text = "Part Recipe"
        Me.SetupPartNumberToolStripMenuItem.ToolTipText = "Allows setup or modification of part number recipe information."
        '
        'CureDeviceToolStripMenuItem
        '
        Me.CureDeviceToolStripMenuItem.Name = "CureDeviceToolStripMenuItem"
        Me.CureDeviceToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CureDeviceToolStripMenuItem.Text = "Cure Device"
        Me.CureDeviceToolStripMenuItem.ToolTipText = "Allows setup or modification of cure station (press or oven)."
        '
        'PumpDeviceToolStripMenuItem
        '
        Me.PumpDeviceToolStripMenuItem.Name = "PumpDeviceToolStripMenuItem"
        Me.PumpDeviceToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PumpDeviceToolStripMenuItem.Text = "Pump Device"
        Me.PumpDeviceToolStripMenuItem.ToolTipText = "Allows setup or modification of injection pump."
        '
        'RefreshDevicesToolStripMenuItem
        '
        Me.RefreshDevicesToolStripMenuItem.Name = "RefreshDevicesToolStripMenuItem"
        Me.RefreshDevicesToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RefreshDevicesToolStripMenuItem.Text = "Refresh Devices"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAvailableAutomatedCuresToolStripMenuItem, Me.ViewBackupLogsToolStripMenuItem, Me.CreateLogFromBackupLogFileToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'ViewAvailableAutomatedCuresToolStripMenuItem
        '
        Me.ViewAvailableAutomatedCuresToolStripMenuItem.Name = "ViewAvailableAutomatedCuresToolStripMenuItem"
        Me.ViewAvailableAutomatedCuresToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.ViewAvailableAutomatedCuresToolStripMenuItem.Text = "View Configured Part Numbers"
        Me.ViewAvailableAutomatedCuresToolStripMenuItem.ToolTipText = "Displays list of all part numbers configured" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for automated cure."
        '
        'ViewBackupLogsToolStripMenuItem
        '
        Me.ViewBackupLogsToolStripMenuItem.Name = "ViewBackupLogsToolStripMenuItem"
        Me.ViewBackupLogsToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.ViewBackupLogsToolStripMenuItem.Text = "View Backup Logs"
        Me.ViewBackupLogsToolStripMenuItem.ToolTipText = "Displays backup logs within the Red Lion Data Station." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "These are for both inject" &
    "ion logs and temperature logs." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "THESE SHOULD BE USED IF THE USER FORGOT TO START" &
    " A LOG."
        '
        'CreateLogFromBackupLogFileToolStripMenuItem
        '
        Me.CreateLogFromBackupLogFileToolStripMenuItem.Name = "CreateLogFromBackupLogFileToolStripMenuItem"
        Me.CreateLogFromBackupLogFileToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.CreateLogFromBackupLogFileToolStripMenuItem.Text = "Create Log from Backup Log File"
        Me.CreateLogFromBackupLogFileToolStripMenuItem.ToolTipText = "This allows creation of FDI Cure or Injection Logs" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from backup logs within the R" &
    "ed Lion Data Station." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "USE THIS IF USER FORGOT TO START A LOG." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "USE THIS IF PRIM" &
    "ARY LOG FAILED."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewUserManualToolStripMenuItem, Me.ViewAdministratorManualToolStripMenuItem, Me.AboutAutomatedCureToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ViewUserManualToolStripMenuItem
        '
        Me.ViewUserManualToolStripMenuItem.Name = "ViewUserManualToolStripMenuItem"
        Me.ViewUserManualToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ViewUserManualToolStripMenuItem.Text = "View User Manual"
        '
        'ViewAdministratorManualToolStripMenuItem
        '
        Me.ViewAdministratorManualToolStripMenuItem.Name = "ViewAdministratorManualToolStripMenuItem"
        Me.ViewAdministratorManualToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ViewAdministratorManualToolStripMenuItem.Text = "View Administrator Manual"
        '
        'AboutAutomatedCureToolStripMenuItem
        '
        Me.AboutAutomatedCureToolStripMenuItem.Name = "AboutAutomatedCureToolStripMenuItem"
        Me.AboutAutomatedCureToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AboutAutomatedCureToolStripMenuItem.Text = "About Automated Cure"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabHome)
        Me.TabControl1.Controls.Add(Me.TabAlarm)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(782, 842)
        Me.TabControl1.TabIndex = 4
        '
        'TabHome
        '
        Me.TabHome.AutoScroll = True
        Me.TabHome.Controls.Add(Me.Label3)
        Me.TabHome.Controls.Add(Me.Label2)
        Me.TabHome.Controls.Add(Me.DGV3)
        Me.TabHome.Controls.Add(Me.Label1)
        Me.TabHome.Controls.Add(Me.DGV2)
        Me.TabHome.Controls.Add(Me.DGV1)
        Me.TabHome.ImageKey = "Home Icon Shaded2.JPG"
        Me.TabHome.Location = New System.Drawing.Point(4, 39)
        Me.TabHome.Name = "TabHome"
        Me.TabHome.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHome.Size = New System.Drawing.Size(774, 799)
        Me.TabHome.TabIndex = 0
        Me.TabHome.Text = "Home"
        Me.ToolTip1.SetToolTip(Me.TabHome, "Home Tab" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This shows current process parameters for all equipment.")
        Me.TabHome.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 545)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "RTM Pumps"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 329)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Ovens"
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn10})
        Me.DGV3.Location = New System.Drawing.Point(8, 572)
        Me.DGV3.MinimumSize = New System.Drawing.Size(300, 100)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.Size = New System.Drawing.Size(758, 200)
        Me.DGV3.TabIndex = 6
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Press Name"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Pressure (psi)"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Flow Rate (g/min)"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 70
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 120
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.FalseValue = "0"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Log Status"
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.TrueValue = "1"
        Me.DataGridViewCheckBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.HeaderText = "Parts in Process"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Temperature Controllers"
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn5})
        Me.DGV2.Location = New System.Drawing.Point(8, 356)
        Me.DGV2.MinimumSize = New System.Drawing.Size(300, 100)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.Size = New System.Drawing.Size(758, 177)
        Me.DGV2.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Oven Name"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 82
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Setpoint (F)"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 79
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Part Temp (F)"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 78
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 62
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.FalseValue = "0"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Log Status"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.TrueValue = "1"
        Me.DataGridViewCheckBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Parts in Process"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClmPress, Me.ClmSetpoint, Me.ClmPartTemp, Me.ClmStatus, Me.ClmLogStatus, Me.ClmPartsList})
        Me.DGV1.Location = New System.Drawing.Point(14, 32)
        Me.DGV1.MinimumSize = New System.Drawing.Size(300, 100)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(760, 294)
        Me.DGV1.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.DGV1, "This shows all in-process parameters for Temperature Controllers." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click a name t" &
        "o access the temperature controller's page.")
        '
        'ClmPress
        '
        Me.ClmPress.HeaderText = "Press Name"
        Me.ClmPress.MinimumWidth = 60
        Me.ClmPress.Name = "ClmPress"
        Me.ClmPress.ReadOnly = True
        Me.ClmPress.Width = 150
        '
        'ClmSetpoint
        '
        Me.ClmSetpoint.HeaderText = "Setpoint (F)"
        Me.ClmSetpoint.MinimumWidth = 60
        Me.ClmSetpoint.Name = "ClmSetpoint"
        '
        'ClmPartTemp
        '
        Me.ClmPartTemp.HeaderText = "Part Temp (F)"
        Me.ClmPartTemp.MinimumWidth = 60
        Me.ClmPartTemp.Name = "ClmPartTemp"
        Me.ClmPartTemp.ReadOnly = True
        '
        'ClmStatus
        '
        Me.ClmStatus.HeaderText = "Status"
        Me.ClmStatus.MinimumWidth = 60
        Me.ClmStatus.Name = "ClmStatus"
        Me.ClmStatus.ReadOnly = True
        Me.ClmStatus.Width = 200
        '
        'ClmLogStatus
        '
        Me.ClmLogStatus.FalseValue = "0"
        Me.ClmLogStatus.HeaderText = "Log Status"
        Me.ClmLogStatus.IndeterminateValue = ""
        Me.ClmLogStatus.MinimumWidth = 60
        Me.ClmLogStatus.Name = "ClmLogStatus"
        Me.ClmLogStatus.ReadOnly = True
        Me.ClmLogStatus.TrueValue = "1"
        Me.ClmLogStatus.Width = 80
        '
        'ClmPartsList
        '
        Me.ClmPartsList.HeaderText = "Parts in Process"
        Me.ClmPartsList.MinimumWidth = 100
        Me.ClmPartsList.Name = "ClmPartsList"
        Me.ClmPartsList.ReadOnly = True
        Me.ClmPartsList.Width = 200
        '
        'TabAlarm
        '
        Me.TabAlarm.AutoScroll = True
        Me.TabAlarm.Controls.Add(Me.BtnClearList)
        Me.TabAlarm.Controls.Add(Me.BtnPrint)
        Me.TabAlarm.Controls.Add(Me.BtnAlarm)
        Me.TabAlarm.Controls.Add(Me.DGVAlarm)
        Me.TabAlarm.Controls.Add(Me.Label4)
        Me.TabAlarm.ImageIndex = 4
        Me.TabAlarm.Location = New System.Drawing.Point(4, 39)
        Me.TabAlarm.Name = "TabAlarm"
        Me.TabAlarm.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAlarm.Size = New System.Drawing.Size(774, 799)
        Me.TabAlarm.TabIndex = 1
        Me.TabAlarm.Text = "Alarms"
        Me.ToolTip1.SetToolTip(Me.TabAlarm, "Alarms Tab" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This shows in-process alarms." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If alarms appear, follow the described" &
        " corrective action or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "contact engineering.")
        Me.TabAlarm.UseVisualStyleBackColor = True
        '
        'BtnClearList
        '
        Me.BtnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClearList.Location = New System.Drawing.Point(554, 15)
        Me.BtnClearList.Name = "BtnClearList"
        Me.BtnClearList.Size = New System.Drawing.Size(75, 23)
        Me.BtnClearList.TabIndex = 4
        Me.BtnClearList.Text = "Clear List"
        Me.BtnClearList.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Location = New System.Drawing.Point(473, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnAlarm
        '
        Me.BtnAlarm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAlarm.Location = New System.Drawing.Point(635, 15)
        Me.BtnAlarm.Name = "BtnAlarm"
        Me.BtnAlarm.Size = New System.Drawing.Size(75, 23)
        Me.BtnAlarm.TabIndex = 2
        Me.BtnAlarm.Text = "Clear Alarms"
        Me.BtnAlarm.UseVisualStyleBackColor = True
        '
        'DGVAlarm
        '
        Me.DGVAlarm.AllowUserToAddRows = False
        Me.DGVAlarm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVAlarm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClmTime, Me.ClmDevice, Me.ClmAlarm, Me.ClmActiion})
        Me.DGVAlarm.Location = New System.Drawing.Point(12, 42)
        Me.DGVAlarm.Name = "DGVAlarm"
        Me.DGVAlarm.Size = New System.Drawing.Size(754, 749)
        Me.DGVAlarm.TabIndex = 1
        '
        'ClmTime
        '
        Me.ClmTime.HeaderText = "Time"
        Me.ClmTime.Name = "ClmTime"
        Me.ClmTime.Width = 120
        '
        'ClmDevice
        '
        Me.ClmDevice.HeaderText = "Station Name"
        Me.ClmDevice.Name = "ClmDevice"
        Me.ClmDevice.Width = 120
        '
        'ClmAlarm
        '
        Me.ClmAlarm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ClmAlarm.FillWeight = 80.0!
        Me.ClmAlarm.HeaderText = "Alarm Description"
        Me.ClmAlarm.MinimumWidth = 150
        Me.ClmAlarm.Name = "ClmAlarm"
        Me.ClmAlarm.Width = 150
        '
        'ClmActiion
        '
        Me.ClmActiion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ClmActiion.HeaderText = "Corrective Action"
        Me.ClmActiion.Name = "ClmActiion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Alarms"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "HomeIcon.ico")
        Me.ImageList1.Images.SetKeyName(1, "Home Icon Shaded2.JPG")
        Me.ImageList1.Images.SetKeyName(2, "Alarm1.JPG")
        Me.ImageList1.Images.SetKeyName(3, "Alarm2.JPG")
        Me.ImageList1.Images.SetKeyName(4, "No Alarm.JPG")
        '
        'PrintDocument1
        '
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(782, 866)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1080)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "FrmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "FDI Automated Cure"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabHome.ResumeLayout(False)
        Me.TabHome.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAlarm.ResumeLayout(False)
        Me.TabAlarm.PerformLayout()
        CType(Me.DGVAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabHome As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ClmPress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmSetpoint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmPartTemp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmLogStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ClmPartsList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAvailableAutomatedCuresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabAlarm As System.Windows.Forms.TabPage
    Friend WithEvents DGVAlarm As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnAlarm As System.Windows.Forms.Button
    Friend WithEvents ClmTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmDevice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmAlarm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmActiion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents BtnClearList As System.Windows.Forms.Button
    Friend WithEvents ViewBackupLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CreateLogFromBackupLogFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupPartNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CureDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PumpDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewUserManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAdministratorManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshDevicesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents AboutAutomatedCureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
End Class
