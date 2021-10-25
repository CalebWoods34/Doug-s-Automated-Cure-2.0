<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPumpBackupReporting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPumpBackupReporting))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtBackupLogFile = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnCreateLog = New System.Windows.Forms.Button()
        Me.TxtSerialNumber = New System.Windows.Forms.TextBox()
        Me.TxtJobNumber = New System.Windows.Forms.TextBox()
        Me.TxtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cbo1 = New System.Windows.Forms.ComboBox()
        Me.BtnEnd = New System.Windows.Forms.Button()
        Me.TxtEnd = New System.Windows.Forms.TextBox()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.TxtStart = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.InitialDirectory = "C:\Programs\FDI_MPCS_Data_Station_Backup\logs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This form allows creation of cure logs or injection logs from backup log files."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(279, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Browse..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtBackupLogFile)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 55)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Backup Log"
        '
        'TxtBackupLogFile
        '
        Me.TxtBackupLogFile.Location = New System.Drawing.Point(7, 22)
        Me.TxtBackupLogFile.Name = "TxtBackupLogFile"
        Me.TxtBackupLogFile.Size = New System.Drawing.Size(266, 20)
        Me.TxtBackupLogFile.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnLoad)
        Me.GroupBox2.Controls.Add(Me.DGV1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 592)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Backup Log Data"
        '
        'BtnLoad
        '
        Me.BtnLoad.Location = New System.Drawing.Point(6, 19)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(103, 23)
        Me.BtnLoad.TabIndex = 1
        Me.BtnLoad.Text = "Load Backup Log"
        Me.BtnLoad.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 51)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.Size = New System.Drawing.Size(348, 535)
        Me.DGV1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.BtnCreateLog)
        Me.GroupBox3.Controls.Add(Me.TxtSerialNumber)
        Me.GroupBox3.Controls.Add(Me.TxtJobNumber)
        Me.GroupBox3.Controls.Add(Me.TxtPartNumber)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Cbo1)
        Me.GroupBox3.Controls.Add(Me.BtnEnd)
        Me.GroupBox3.Controls.Add(Me.TxtEnd)
        Me.GroupBox3.Controls.Add(Me.BtnStart)
        Me.GroupBox3.Controls.Add(Me.TxtStart)
        Me.GroupBox3.Location = New System.Drawing.Point(375, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(225, 210)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Report Information"
        '
        'BtnCreateLog
        '
        Me.BtnCreateLog.Location = New System.Drawing.Point(7, 181)
        Me.BtnCreateLog.Name = "BtnCreateLog"
        Me.BtnCreateLog.Size = New System.Drawing.Size(75, 23)
        Me.BtnCreateLog.TabIndex = 5
        Me.BtnCreateLog.Text = "Create Log"
        Me.BtnCreateLog.UseVisualStyleBackColor = True
        '
        'TxtSerialNumber
        '
        Me.TxtSerialNumber.Location = New System.Drawing.Point(7, 158)
        Me.TxtSerialNumber.Name = "TxtSerialNumber"
        Me.TxtSerialNumber.Size = New System.Drawing.Size(133, 20)
        Me.TxtSerialNumber.TabIndex = 4
        '
        'TxtJobNumber
        '
        Me.TxtJobNumber.Location = New System.Drawing.Point(7, 132)
        Me.TxtJobNumber.Name = "TxtJobNumber"
        Me.TxtJobNumber.Size = New System.Drawing.Size(133, 20)
        Me.TxtJobNumber.TabIndex = 4
        '
        'TxtPartNumber
        '
        Me.TxtPartNumber.Location = New System.Drawing.Point(7, 107)
        Me.TxtPartNumber.Name = "TxtPartNumber"
        Me.TxtPartNumber.Size = New System.Drawing.Size(133, 20)
        Me.TxtPartNumber.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(146, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Serial Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(146, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Job Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Part Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Device Name"
        '
        'Cbo1
        '
        Me.Cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo1.FormattingEnabled = True
        Me.Cbo1.Location = New System.Drawing.Point(7, 80)
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.Size = New System.Drawing.Size(99, 21)
        Me.Cbo1.TabIndex = 2
        '
        'BtnEnd
        '
        Me.BtnEnd.Location = New System.Drawing.Point(112, 51)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(106, 23)
        Me.BtnEnd.TabIndex = 1
        Me.BtnEnd.Text = "Select Log End"
        Me.ToolTip1.SetToolTip(Me.BtnEnd, "Select a row in the backup log data for the end of the log to be output.")
        Me.BtnEnd.UseVisualStyleBackColor = True
        '
        'TxtEnd
        '
        Me.TxtEnd.Location = New System.Drawing.Point(7, 54)
        Me.TxtEnd.Name = "TxtEnd"
        Me.TxtEnd.Size = New System.Drawing.Size(99, 20)
        Me.TxtEnd.TabIndex = 0
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(112, 19)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(106, 23)
        Me.BtnStart.TabIndex = 1
        Me.BtnStart.Text = "Select Log Start"
        Me.ToolTip1.SetToolTip(Me.BtnStart, "Select a row in the backup log data for the start of the log to be output.")
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'TxtStart
        '
        Me.TxtStart.Location = New System.Drawing.Point(7, 22)
        Me.TxtStart.Name = "TxtStart"
        Me.TxtStart.Size = New System.Drawing.Size(99, 20)
        Me.TxtStart.TabIndex = 0
        '
        'FrmPumpBackupReporting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 700)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPumpBackupReporting"
        Me.Text = "Create Log from Backup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBackupLogFile As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnEnd As System.Windows.Forms.Button
    Friend WithEvents TxtEnd As System.Windows.Forms.TextBox
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents TxtStart As System.Windows.Forms.TextBox
    Friend WithEvents TxtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents TxtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents TxtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbo1 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCreateLog As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
