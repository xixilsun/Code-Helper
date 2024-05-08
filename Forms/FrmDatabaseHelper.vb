Imports DevExpress.Xpo.DB.Helpers
Imports IDR.Common
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FrmDatabaseHelper
    Private Property IsFirstLoad As Boolean = True
    Public Function GetConnectionString(databaseName As String) As String
        Return IDR.Common.modSQL.GetConnectionString("CodeHelper", "172.18.3.14", databaseName, "", "", True)
    End Function

    Private Sub FrmDatabaseHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtServer.Text = "172.18.3.14"
        Dim DatabaseName = modSQL.GetDataTable("SELECT name AS DatabaseName FROM sysdatabases WHERE name LIKE 'HRdb%'", GetConnectionString("Master"))
        With cboDatabase
            .DataSource = DatabaseName
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DisplayMember = "DatabaseName"
            .ValueMember = "DatabaseName"
            .SelectedIndex = 0
        End With

        IsFirstLoad = False
        'Show table list
        FillTableDropDownList(cboDatabase.SelectedValue)

        Me.KeyPreview = True
    End Sub

    Private Sub frmConvert_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            btnCopy_Click(sender, e)
        ElseIf e.Shift AndAlso e.KeyCode = Keys.S Then
            btnSelect_Click(sender, e)
        ElseIf e.Shift AndAlso e.KeyCode = Keys.I Then
            btnInsert_Click(sender, e)
        ElseIf e.Shift AndAlso e.KeyCode = Keys.U Then
            btnUpdate_Click(sender, e)
        ElseIf e.Shift AndAlso e.KeyCode = Keys.D Then
            btnDelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            btnConvert_Click(sender, e)
        End If
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        txtQuery.Text = "SELECT " & GetColumnList(cboTable.SelectedValue, cboDatabase.SelectedValue) & " FROM " & cboTable.SelectedValue
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim ColumnList = GetColumnList(cboTable.SelectedValue, cboDatabase.SelectedValue)
        Dim ParameterList = GetParameterList(cboTable.SelectedValue, cboDatabase.SelectedValue)
        txtQuery.Text = "INSERT INTO " & cboTable.SelectedValue & "(" & ColumnList & ")" & vbCrLf &
                         "VALUES (" & ParameterList & ")"
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Dim Form As New frmConvert
        Form.InputText = txtQuery.Text
        Form.ConvertInput(txtQuery.Text, "SQL", "VB.NET")
        Form.Show()
    End Sub

    Private Sub cboDatabase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDatabase.SelectedIndexChanged
        If Not IsFirstLoad Then
            FillTableDropDownList(cboDatabase.SelectedValue)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        txtQuery.Text = "DELETE " & cboTable.SelectedValue & vbCrLf & "WHERE "
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Sql = "SELECT column_name AS ColumnName, CONCAT('@',column_name) AS ParameterName" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboTable.SelectedValue)
        Dim Dt As DataTable = GetDataTable(Sql, GetConnectionString(cboDatabase.SelectedValue))

        Dim Output = "UPDATE " & cboTable.SelectedValue & vbCrLf & "SET "

        For Each row As DataRow In Dt.Rows
            Output &= vbCrLf & row!ColumnName & " = " & row!ParameterName
        Next

        Output &= vbCrLf & "WHERE "

        txtQuery.Text = Output
    End Sub

#Region "Method"
    Private Sub FillTableDropDownList(databaseName As String)
        Dim sql = "SELECT TABLE_NAME AS TableName" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.TABLES" & vbCrLf &
                  "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = " & SqlStr(databaseName) & vbCrLf &
                  "ORDER BY TableName"
        'Dim cmd As New SqlCommand(sql)
        'cmd.Parameters.AddWithValue("@table", cboDatabase.SelectedValue)
        Dim TableNames = modSQL.GetDataTable(sql, GetConnectionString(databaseName))
        With cboTable
            .DataSource = TableNames
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DisplayMember = "TableName"
            .ValueMember = "TableName"
            .SelectedIndex = 0
        End With
    End Sub

    Private Function GetColumnList(tableName As String, databaseName As String) As String
        Dim Sql = "SELECT STRING_AGG(column_name,', ') AS ColumnList" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(tableName) & vbCrLf &
                  "GROUP BY TABLE_NAME"
        Return modSQL.GetOneData(Sql, "", GetConnectionString(databaseName))
    End Function

    Private Function GetParameterList(tableName As String, databaseName As String) As String
        Dim Sql = "SELECT STRING_AGG('@' + column_name,', ') AS ColumnList" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(tableName) & vbCrLf &
                  "GROUP BY TABLE_NAME"
        Return modSQL.GetOneData(Sql, "", GetConnectionString(databaseName))
    End Function
    Public Function SqlStr(param As String) As String
        Return "'" & param & "'"
    End Function

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If txtQuery.Text.Trim = "" Then Exit Sub
        Clipboard.SetText(txtQuery.Text)
        btnCopy.Image = CodeHelper.My.Resources.Resources.copy2
    End Sub

    Private Sub txtQuery_TextChanged(sender As Object, e As EventArgs) Handles txtQuery.TextChanged
        If Not IsFirstLoad Then
            btnCopy.Image = CodeHelper.My.Resources.Resources.copy
        End If
    End Sub

    Private Sub btnParameter_Click(sender As Object, e As EventArgs) Handles btnParameter.Click
        Dim Sql = "SELECT COLUMN_NAME AS ColumnName, CONCAT('@', COLUMN_NAME) AS ParameterName, " & vbCrLf &
                  "CONCAT('SqlDbType.',DATA_TYPE , CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NOT NULL THEN CONCAT(', ', CHARACTER_MAXIMUM_LENGTH) ELSE '' END) AS DataType" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS " & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboTable.SelectedValue)
        Dim Dt As DataTable = modSQL.GetDataTable(Sql, GetConnectionString(cboDatabase.SelectedValue))

        If Dt.Rows.Count <= 0 Then Exit Sub

        Dim Output = "Dim Cmd As New SqlCommand(Sql, Connection)" & vbCrLf
        For Each row As DataRow In Dt.Rows
            Output &= vbCrLf & $"Cmd.Parameters.Add(""{row!ParameterName}"", {row!DataType})"
        Next

        Output &= vbCrLf

        For Each Row As DataRow In Dt.Rows
            Output &= vbCrLf & $"Cmd.Parameters(""{Row!ParameterName}"").Value = {cboTable.SelectedValue}.{Row!ColumnName}"
        Next

        txtQuery.Text = Output
    End Sub

#End Region
End Class