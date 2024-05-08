<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConvert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConvert))
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.txtLabel1 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.Label()
        Me.btnSwitch = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSpace = New System.Windows.Forms.Button()
        Me.btnAddVariable = New System.Windows.Forms.Button()
        Me.txtVariable = New System.Windows.Forms.TextBox()
        Me.numSpaces = New System.Windows.Forms.NumericUpDown()
        Me.txtLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numSpaces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInput.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInput.Location = New System.Drawing.Point(12, 162)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInput.Size = New System.Drawing.Size(426, 138)
        Me.txtInput.TabIndex = 2
        '
        'txtLabel1
        '
        Me.txtLabel1.AutoSize = True
        Me.txtLabel1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtLabel1.Location = New System.Drawing.Point(12, 137)
        Me.txtLabel1.Name = "txtLabel1"
        Me.txtLabel1.Size = New System.Drawing.Size(43, 14)
        Me.txtLabel1.TabIndex = 2
        Me.txtLabel1.Text = "Query :"
        '
        'txtFrom
        '
        Me.txtFrom.AutoSize = True
        Me.txtFrom.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(118, 23)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(42, 19)
        Me.txtFrom.TabIndex = 5
        Me.txtFrom.Text = "SQL"
        '
        'txtTo
        '
        Me.txtTo.AutoSize = True
        Me.txtTo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTo.Location = New System.Drawing.Point(283, 23)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(69, 19)
        Me.txtTo.TabIndex = 6
        Me.txtTo.Text = "VB.NET"
        '
        'btnSwitch
        '
        Me.btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSwitch.Image = Global.CodeHelper.My.Resources.Resources.left_and_right
        Me.btnSwitch.Location = New System.Drawing.Point(212, 19)
        Me.btnSwitch.Name = "btnSwitch"
        Me.btnSwitch.Size = New System.Drawing.Size(32, 23)
        Me.btnSwitch.TabIndex = 1
        Me.btnSwitch.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCopy.Image = Global.CodeHelper.My.Resources.Resources.copy
        Me.btnCopy.Location = New System.Drawing.Point(406, 132)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(32, 23)
        Me.btnCopy.TabIndex = 3
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnConvert
        '
        Me.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConvert.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btnConvert.Location = New System.Drawing.Point(154, 328)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(153, 23)
        Me.btnConvert.TabIndex = 4
        Me.btnConvert.Text = "Convert Code (F5)"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSpace)
        Me.GroupBox1.Controls.Add(Me.btnAddVariable)
        Me.GroupBox1.Controls.Add(Me.txtVariable)
        Me.GroupBox1.Controls.Add(Me.numSpaces)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 61)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Additional Settings"
        '
        'btnSpace
        '
        Me.btnSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSpace.Font = New System.Drawing.Font("Arial", 7.5!)
        Me.btnSpace.Location = New System.Drawing.Point(11, 25)
        Me.btnSpace.Name = "btnSpace"
        Me.btnSpace.Size = New System.Drawing.Size(78, 23)
        Me.btnSpace.TabIndex = 16
        Me.btnSpace.Text = "Add Space"
        Me.btnSpace.UseVisualStyleBackColor = True
        '
        'btnAddVariable
        '
        Me.btnAddVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddVariable.Font = New System.Drawing.Font("Arial", 7.5!)
        Me.btnAddVariable.Location = New System.Drawing.Point(142, 25)
        Me.btnAddVariable.Name = "btnAddVariable"
        Me.btnAddVariable.Size = New System.Drawing.Size(78, 23)
        Me.btnAddVariable.TabIndex = 12
        Me.btnAddVariable.Text = "Add Variable"
        Me.btnAddVariable.UseVisualStyleBackColor = True
        '
        'txtVariable
        '
        Me.txtVariable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVariable.Location = New System.Drawing.Point(226, 27)
        Me.txtVariable.Name = "txtVariable"
        Me.txtVariable.Size = New System.Drawing.Size(100, 20)
        Me.txtVariable.TabIndex = 15
        '
        'numSpaces
        '
        Me.numSpaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numSpaces.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.numSpaces.Location = New System.Drawing.Point(95, 27)
        Me.numSpaces.Name = "numSpaces"
        Me.numSpaces.Size = New System.Drawing.Size(37, 21)
        Me.numSpaces.TabIndex = 13
        '
        'txtLabel
        '
        Me.txtLabel.AutoSize = True
        Me.txtLabel.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.txtLabel.ForeColor = System.Drawing.Color.Blue
        Me.txtLabel.Location = New System.Drawing.Point(12, 303)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(19, 13)
        Me.txtLabel.TabIndex = 12
        Me.txtLabel.Text = "F5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 303)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = ": Convert Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(181, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = ": Switch"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(135, 303)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Ctrl + S"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(294, 303)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = ": Copy"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(248, 303)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Ctrl + C"
        '
        'frmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 365)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLabel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnSwitch)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.txtLabel1)
        Me.Controls.Add(Me.txtInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConvert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmConvert"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numSpaces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInput As Windows.Forms.TextBox
    Friend WithEvents txtLabel1 As Windows.Forms.Label
    Friend WithEvents txtFrom As Windows.Forms.Label
    Friend WithEvents txtTo As Windows.Forms.Label
    Friend WithEvents btnSwitch As Windows.Forms.Button
    Friend WithEvents btnCopy As Windows.Forms.Button
    Friend WithEvents btnConvert As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents numSpaces As Windows.Forms.NumericUpDown
    Friend WithEvents txtVariable As Windows.Forms.TextBox
    Friend WithEvents btnAddVariable As Windows.Forms.Button
    Friend WithEvents txtLabel As Windows.Forms.Label
    Private WithEvents Label1 As Windows.Forms.Label
    Private WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Private WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btnSpace As Windows.Forms.Button
End Class
