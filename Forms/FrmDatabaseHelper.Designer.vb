﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDatabaseHelper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDatabaseHelper))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.btnInsert = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.txtLabel1 = New System.Windows.Forms.Label()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCreateTable = New DevExpress.XtraEditors.SimpleButton()
        Me.btnVariable = New DevExpress.XtraEditors.SimpleButton()
        Me.btnParameter = New DevExpress.XtraEditors.SimpleButton()
        Me.cboDatabase = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboTable = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtServer = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(232, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(442, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Table"
        '
        'txtQuery
        '
        Me.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuery.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuery.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQuery.Location = New System.Drawing.Point(15, 161)
        Me.txtQuery.Margin = New System.Windows.Forms.Padding(10)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuery.Size = New System.Drawing.Size(832, 389)
        Me.txtQuery.TabIndex = 10
        '
        'btnSelect
        '
        Me.btnSelect.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnSelect.Appearance.Options.UseFont = True
        Me.btnSelect.Location = New System.Drawing.Point(15, 28)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 4
        Me.btnSelect.Text = "&SELECT"
        '
        'btnInsert
        '
        Me.btnInsert.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnInsert.Appearance.Options.UseFont = True
        Me.btnInsert.Location = New System.Drawing.Point(106, 28)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(75, 23)
        Me.btnInsert.TabIndex = 5
        Me.btnInsert.Text = "&INSERT"
        '
        'btnUpdate
        '
        Me.btnUpdate.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnUpdate.Appearance.Options.UseFont = True
        Me.btnUpdate.Location = New System.Drawing.Point(194, 28)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "&UPDATE"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Location = New System.Drawing.Point(286, 28)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "&DELETE"
        '
        'btnCopy
        '
        Me.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCopy.Image = Global.CodeHelper.My.Resources.Resources.copy
        Me.btnCopy.Location = New System.Drawing.Point(798, 128)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(32, 23)
        Me.btnCopy.TabIndex = 9
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'txtLabel1
        '
        Me.txtLabel1.AutoSize = True
        Me.txtLabel1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtLabel1.Location = New System.Drawing.Point(12, 137)
        Me.txtLabel1.Name = "txtLabel1"
        Me.txtLabel1.Size = New System.Drawing.Size(43, 14)
        Me.txtLabel1.TabIndex = 12
        Me.txtLabel1.Text = "Query :"
        '
        'btnConvert
        '
        Me.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConvert.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btnConvert.Location = New System.Drawing.Point(665, 128)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(125, 23)
        Me.btnConvert.TabIndex = 8
        Me.btnConvert.Text = "Convert to VB.NET"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCreateTable)
        Me.GroupBox1.Controls.Add(Me.btnVariable)
        Me.GroupBox1.Controls.Add(Me.btnParameter)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnSelect)
        Me.GroupBox1.Controls.Add(Me.btnInsert)
        Me.GroupBox1.Controls.Add(Me.btnUpdate)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(815, 68)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Action"
        '
        'btnCreateTable
        '
        Me.btnCreateTable.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnCreateTable.Appearance.Options.UseFont = True
        Me.btnCreateTable.Location = New System.Drawing.Point(562, 28)
        Me.btnCreateTable.Name = "btnCreateTable"
        Me.btnCreateTable.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateTable.TabIndex = 10
        Me.btnCreateTable.Text = "&CREATE"
        '
        'btnVariable
        '
        Me.btnVariable.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnVariable.Appearance.Options.UseFont = True
        Me.btnVariable.Location = New System.Drawing.Point(380, 28)
        Me.btnVariable.Name = "btnVariable"
        Me.btnVariable.Size = New System.Drawing.Size(75, 23)
        Me.btnVariable.TabIndex = 9
        Me.btnVariable.Text = "&VARIABLE"
        '
        'btnParameter
        '
        Me.btnParameter.Appearance.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.btnParameter.Appearance.Options.UseFont = True
        Me.btnParameter.Location = New System.Drawing.Point(470, 28)
        Me.btnParameter.Name = "btnParameter"
        Me.btnParameter.Size = New System.Drawing.Size(75, 23)
        Me.btnParameter.TabIndex = 8
        Me.btnParameter.Text = "&PARAMETER"
        '
        'cboDatabase
        '
        Me.cboDatabase.Location = New System.Drawing.Point(291, 11)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabase.Size = New System.Drawing.Size(122, 20)
        Me.cboDatabase.TabIndex = 16
        '
        'cboTable
        '
        Me.cboTable.Location = New System.Drawing.Point(480, 11)
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTable.Size = New System.Drawing.Size(122, 20)
        Me.cboTable.TabIndex = 17
        '
        'TxtServer
        '
        Me.TxtServer.Location = New System.Drawing.Point(79, 11)
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(117, 20)
        Me.TxtServer.TabIndex = 18
        '
        'FrmDatabaseHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 566)
        Me.Controls.Add(Me.TxtServer)
        Me.Controls.Add(Me.cboTable)
        Me.Controls.Add(Me.cboDatabase)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.txtLabel1)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDatabaseHelper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDatabaseHelper"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtQuery As Windows.Forms.TextBox
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnInsert As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCopy As Windows.Forms.Button
    Friend WithEvents txtLabel1 As Windows.Forms.Label
    Friend WithEvents btnConvert As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnParameter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVariable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCreateTable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboDatabase As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboTable As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtServer As DevExpress.XtraEditors.TextEdit
End Class
