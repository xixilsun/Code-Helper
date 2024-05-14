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
        Try
            txtServer.Text = "172.18.3.14"
            Dim DatabaseName = modSQL.GetDataTable("SELECT name AS DatabaseName FROM sysdatabases WHERE name LIKE 'HRdb%'", GetConnectionString("Master"))
            With cboDatabase
                .DataSource = DatabaseName
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .DisplayMember = "DatabaseName"
                .ValueMember = "DatabaseName"
                .SelectedIndex = 0
            End With

            IsFirstLoad = False
            'Show table list
            FillTableDropDownList(cboDatabase.SelectedValue)

            Me.KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
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
        Dim TableNames = modSQL.GetDataTable(sql, GetConnectionString(databaseName))
        With cboTable
            .DataSource = TableNames
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
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

    Private Sub btnVariable_Click(sender As Object, e As EventArgs) Handles btnVariable.Click
        Dim Sql = "SELECT CONCAT('@', COLUMN_NAME) AS ParameterName," & vbCrLf &
                  "CONCAT('DECLARE @', COLUMN_NAME, ' AS ', DATA_TYPE, CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NOT NULL THEN CONCAT('(', CHARACTER_MAXIMUM_LENGTH, ')') END) AS Result" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboTable.SelectedValue)
        Dim Dt As DataTable = modSQL.GetDataTable(Sql, GetConnectionString(cboDatabase.SelectedValue))

        If Dt.Rows.Count <= 0 Then Exit Sub

        Dim Output As String = ""

        For Each Row As DataRow In Dt.Rows
            Output &= If(Output = "", "", vbCrLf) & Row!Result
        Next

        Output &= vbCrLf

        For Each Row As DataRow In Dt.Rows
            Output &= vbCrLf & $"SET {Row!ParameterName} = " & If((Row!ParameterName) = "@UpdateOn" OrElse (Row!ParameterName) = "@UpdatedOn", "GETDATE()", "")
        Next

        txtQuery.Text = Output
    End Sub

    Private Sub btnCreateTable_Click(sender As Object, e As EventArgs) Handles btnCreateTable.Click
        Try
            Dim Sql = "DECLARE @table_name SYSNAME" & vbCrLf &
                      "SELECT @table_name = " & SqlStr("dbo." & cboTable.SelectedValue) & vbCrLf &
                      "DECLARE " & vbCrLf &
                      "      @object_name SYSNAME" & vbCrLf &
                      "    , @object_id INT" & vbCrLf &
                      "SELECT " & vbCrLf &
                      "      @object_name = '[' + s.name + '].[' + o.name + ']'" & vbCrLf &
                      "    , @object_id = o.[object_id]" & vbCrLf &
                      "FROM sys.objects o WITH (NOWAIT)" & vbCrLf &
                      "JOIN sys.schemas s WITH (NOWAIT) ON o.[schema_id] = s.[schema_id]" & vbCrLf &
                      "WHERE s.name + '.' + o.name = @table_name" & vbCrLf &
                      "    AND o.[type] = 'U'" & vbCrLf &
                      "    AND o.is_ms_shipped = 0" & vbCrLf &
                      "DECLARE @SQL NVARCHAR(MAX) = ''" & vbCrLf &
                      ";WITH index_column AS " & vbCrLf &
                      "(" & vbCrLf &
                      "    SELECT " & vbCrLf &
                      "          ic.[object_id]" & vbCrLf &
                      "        , ic.index_id" & vbCrLf &
                      "        , ic.is_descending_key" & vbCrLf &
                      "        , ic.is_included_column" & vbCrLf &
                      "        , c.name" & vbCrLf &
                      "    FROM sys.index_columns ic WITH (NOWAIT)" & vbCrLf &
                      "    JOIN sys.columns c WITH (NOWAIT) ON ic.[object_id] = c.[object_id] AND ic.column_id = c.column_id" & vbCrLf &
                      "    WHERE ic.[object_id] = @object_id" & vbCrLf &
                      ")," & vbCrLf &
                      "fk_columns AS " & vbCrLf &
                      "(" & vbCrLf &
                      "     SELECT " & vbCrLf &
                      "          k.constraint_object_id" & vbCrLf &
                      "        , cname = c.name" & vbCrLf &
                      "        , rcname = rc.name" & vbCrLf &
                      "    FROM sys.foreign_key_columns k WITH (NOWAIT)" & vbCrLf &
                      "    JOIN sys.columns rc WITH (NOWAIT) ON rc.[object_id] = k.referenced_object_id AND rc.column_id = k.referenced_column_id " & vbCrLf &
                      "    JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = k.parent_object_id AND c.column_id = k.parent_column_id" & vbCrLf &
                      "    WHERE k.parent_object_id = @object_id" & vbCrLf &
                      ")" & vbCrLf &
                      "SELECT @SQL = 'CREATE TABLE ' + @object_name + CHAR(13) + '(' + CHAR(13) + STUFF((" & vbCrLf &
                      "    SELECT CHAR(9) + ', [' + c.name + '] ' + " & vbCrLf &
                      "        CASE WHEN c.is_computed = 1" & vbCrLf &
                      "            THEN 'AS ' + cc.[definition] " & vbCrLf &
                      "            ELSE UPPER(tp.name) + " & vbCrLf &
                      "                CASE WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary', 'text')" & vbCrLf &
                      "                       THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length AS VARCHAR(5)) END + ')'" & vbCrLf &
                      "                     WHEN tp.name IN ('nvarchar', 'nchar', 'ntext')" & vbCrLf &
                      "                       THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length / 2 AS VARCHAR(5)) END + ')'" & vbCrLf &
                      "                     WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset') " & vbCrLf &
                      "                       THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'" & vbCrLf &
                      "                    WHEN tp.name IN ('decimal', 'numeric')" & vbCrLf &
                      "                       THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'" & vbCrLf &
                      "                    ELSE ''" & vbCrLf &
                      "                END +" & vbCrLf &
                      "                CASE WHEN c.collation_name IS NOT NULL THEN ' COLLATE ' + c.collation_name ELSE '' END +" & vbCrLf &
                      "                CASE WHEN c.is_nullable = 1 THEN ' NULL' ELSE ' NOT NULL' END +" & vbCrLf &
                      "                CASE WHEN dc.[definition] IS NOT NULL THEN ' DEFAULT' + dc.[definition] ELSE '' END + " & vbCrLf &
                      "                CASE WHEN ic.is_identity = 1 THEN ' IDENTITY(' + CAST(ISNULL(ic.seed_value, '0') AS CHAR(1)) + ',' + CAST(ISNULL(ic.increment_value, '1') AS CHAR(1)) + ')' ELSE '' END " & vbCrLf &
                      "        END + CHAR(13)" & vbCrLf &
                      "    FROM sys.columns c WITH (NOWAIT)" & vbCrLf &
                      "    JOIN sys.types tp WITH (NOWAIT) ON c.user_type_id = tp.user_type_id" & vbCrLf &
                      "    LEFT JOIN sys.computed_columns cc WITH (NOWAIT) ON c.[object_id] = cc.[object_id] AND c.column_id = cc.column_id" & vbCrLf &
                      "    LEFT JOIN sys.default_constraints dc WITH (NOWAIT) ON c.default_object_id != 0 AND c.[object_id] = dc.parent_object_id AND c.column_id = dc.parent_column_id" & vbCrLf &
                      "    LEFT JOIN sys.identity_columns ic WITH (NOWAIT) ON c.is_identity = 1 AND c.[object_id] = ic.[object_id] AND c.column_id = ic.column_id" & vbCrLf &
                      "    WHERE c.[object_id] = @object_id" & vbCrLf &
                      "    ORDER BY c.column_id" & vbCrLf &
                      "    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, CHAR(9) + ' ')" & vbCrLf &
                      "    + ISNULL((SELECT CHAR(9) + ', CONSTRAINT [' + k.name + '] PRIMARY KEY (' + " & vbCrLf &
                      "                    (SELECT STUFF((" & vbCrLf &
                      "                         SELECT ', [' + c.name + '] ' + CASE WHEN ic.is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END" & vbCrLf &
                      "                         FROM sys.index_columns ic WITH (NOWAIT)" & vbCrLf &
                      "                         JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = ic.[object_id] AND c.column_id = ic.column_id" & vbCrLf &
                      "                         WHERE ic.is_included_column = 0" & vbCrLf &
                      "                             AND ic.[object_id] = k.parent_object_id " & vbCrLf &
                      "                             AND ic.index_id = k.unique_index_id     " & vbCrLf &
                      "                         FOR XML PATH(N''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''))" & vbCrLf &
                      "            + ')' + CHAR(13)" & vbCrLf &
                      "            FROM sys.key_constraints k WITH (NOWAIT)" & vbCrLf &
                      "            WHERE k.parent_object_id = @object_id " & vbCrLf &
                      "                AND k.[type] = 'PK'), '') + ')'  + CHAR(13)" & vbCrLf &
                      "    + ISNULL((SELECT (" & vbCrLf &
                      "        SELECT CHAR(13) +" & vbCrLf &
                      "             'ALTER TABLE ' + @object_name + ' WITH' " & vbCrLf &
                      "            + CASE WHEN fk.is_not_trusted = 1 " & vbCrLf &
                      "                THEN ' NOCHECK' " & vbCrLf &
                      "                ELSE ' CHECK' " & vbCrLf &
                      "              END + " & vbCrLf &
                      "              ' ADD CONSTRAINT [' + fk.name  + '] FOREIGN KEY(' " & vbCrLf &
                      "              + STUFF((" & vbCrLf &
                      "                SELECT ', [' + k.cname + ']'" & vbCrLf &
                      "                FROM fk_columns k" & vbCrLf &
                      "                WHERE k.constraint_object_id = fk.[object_id]" & vbCrLf &
                      "                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')" & vbCrLf &
                      "               + ')' +" & vbCrLf &
                      "              ' REFERENCES [' + SCHEMA_NAME(ro.[schema_id]) + '].[' + ro.name + '] ('" & vbCrLf &
                      "              + STUFF((" & vbCrLf &
                      "                SELECT ', [' + k.rcname + ']'" & vbCrLf &
                      "                FROM fk_columns k" & vbCrLf &
                      "                WHERE k.constraint_object_id = fk.[object_id]" & vbCrLf &
                      "                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')" & vbCrLf &
                      "               + ')'" & vbCrLf &
                      "            + CASE " & vbCrLf &
                      "                WHEN fk.delete_referential_action = 1 THEN ' ON DELETE CASCADE' " & vbCrLf &
                      "                WHEN fk.delete_referential_action = 2 THEN ' ON DELETE SET NULL'" & vbCrLf &
                      "                WHEN fk.delete_referential_action = 3 THEN ' ON DELETE SET DEFAULT' " & vbCrLf &
                      "                ELSE '' " & vbCrLf &
                      "              END" & vbCrLf &
                      "            + CASE " & vbCrLf &
                      "                WHEN fk.update_referential_action = 1 THEN ' ON UPDATE CASCADE'" & vbCrLf &
                      "                WHEN fk.update_referential_action = 2 THEN ' ON UPDATE SET NULL'" & vbCrLf &
                      "                WHEN fk.update_referential_action = 3 THEN ' ON UPDATE SET DEFAULT'  " & vbCrLf &
                      "                ELSE '' " & vbCrLf &
                      "              END " & vbCrLf &
                      "            + CHAR(13) + 'ALTER TABLE ' + @object_name + ' CHECK CONSTRAINT [' + fk.name  + ']' + CHAR(13)" & vbCrLf &
                      "        FROM sys.foreign_keys fk WITH (NOWAIT)" & vbCrLf &
                      "        JOIN sys.objects ro WITH (NOWAIT) ON ro.[object_id] = fk.referenced_object_id" & vbCrLf &
                      "        WHERE fk.parent_object_id = @object_id" & vbCrLf &
                      "        FOR XML PATH(N''), TYPE).value('.', 'NVARCHAR(MAX)')), '')" & vbCrLf &
                      "    + ISNULL(((SELECT" & vbCrLf &
                      "         CHAR(13) + 'CREATE' + CASE WHEN i.is_unique = 1 THEN ' UNIQUE' ELSE '' END " & vbCrLf &
                      "                + ' NONCLUSTERED INDEX [' + i.name + '] ON ' + @object_name + ' (' +" & vbCrLf &
                      "                STUFF((" & vbCrLf &
                      "                SELECT ', [' + c.name + ']' + CASE WHEN c.is_descending_key = 1 THEN ' DESC' ELSE ' ASC' END" & vbCrLf &
                      "                FROM index_column c" & vbCrLf &
                      "                WHERE c.is_included_column = 0" & vbCrLf &
                      "                    AND c.index_id = i.index_id" & vbCrLf &
                      "                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') + ')'  " & vbCrLf &
                      "                + ISNULL(CHAR(13) + 'INCLUDE (' + " & vbCrLf &
                      "                    STUFF((" & vbCrLf &
                      "                    SELECT ', [' + c.name + ']'" & vbCrLf &
                      "                    FROM index_column c" & vbCrLf &
                      "                    WHERE c.is_included_column = 1" & vbCrLf &
                      "                        AND c.index_id = i.index_id" & vbCrLf &
                      "                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') + ')', '')  + CHAR(13)" & vbCrLf &
                      "        FROM sys.indexes i WITH (NOWAIT)" & vbCrLf &
                      "        WHERE i.[object_id] = @object_id" & vbCrLf &
                      "            AND i.is_primary_key = 0" & vbCrLf &
                      "            AND i.[type] = 2" & vbCrLf &
                      "        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)')" & vbCrLf &
                      "    ), '')" & vbCrLf &
                      "SELECT @SQL"
            Dim Output = modSQL.GetOneData(Sql, "", GetConnectionString(cboDatabase.SelectedValue))
            txtQuery.Text = Output.Replace(vbCr, vbCrLf)
            Dim x = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region
End Class