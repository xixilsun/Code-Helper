Imports System.Linq
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Resources.ResXFileRef
Imports System.Text.RegularExpressions

Public Class frmConvert
    Private InputQuery As String
    Public Property InputText As String
        Get
            Return InputQuery
        End Get
        Set(value As String)
            InputQuery = value
        End Set
    End Property

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        If txtInput.Text.Trim = "" Then Exit Sub
        ConvertInput(txtInput.Text, txtFrom.Text, txtTo.Text)

        btnCopy.Image = CodeHelper.My.Resources.Resources.copy
    End Sub

    Public Sub ConvertInput(input As String, fromLang As String, toLang As String)
        'Validate input is not empty
        If input.Trim = "" Then Exit Sub
        input = input.TrimStart()

        'Validate input is not in the converting language
        If (toLang = "VB.NET" AndAlso (input(0) = """"c OrElse input(input.Length - 1) = """"c)) OrElse
                (toLang = "SQL" AndAlso input(0) <> """"c AndAlso input(input.Length - 1) <> """"c) Then Exit Sub

        Dim InputArray = input.Split(vbCrLf)
        Dim Converted = ""

        'Converting Process
        Dim i = 0
        For Each line In InputArray
            'Remove additional vbLf & skip empty line
            line = line.Replace(vbLf, "")
            If line.Trim() = "" Then Continue For

            'Check converting language
            If fromLang = "VB.NET" AndAlso toLang = "SQL" Then
                'Condition : Replace '" & SqlStr(xxx)' | Remove D2Str with Backreference Group 2
                'Condition : Remove '"&' | Remove vbCrLf vbNewLine _
                'Condition : Remove excess spaces
                line = Regex.Replace(line, "("" & (SqlStr|D2Str)\((.*?)\))", "'$3'")
                line = Regex.Replace(line, "([""&])|(vbCrLf|vbNewLine| _)", "")
                line = Regex.Replace(line, " {2,}", " ")
                Converted &= If(Converted <> "", vbCrLf, "") & line.Trim() '.Replace(" & vbCrLf &", "").Replace(" & vbNewLine &", "").Replace(" _", "").Replace("""", "").Replace
            ElseIf fromLang = "SQL" AndAlso toLang = "VB.NET" Then
                Converted &= If(Converted <> "", vbCrLf, "") & """" & line & """" & If(i = InputArray.Count - 1, "", " & vbCrLf & _")
            End If
            i += 1
        Next

        txtInput.Text = Converted
    End Sub

    Private Sub btnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwitch.Click
        Dim temp = txtFrom.Text
        txtFrom.Text = txtTo.Text
        txtTo.Text = temp

        txtInput.Clear()
        btnCopy.Image = CodeHelper.My.Resources.Resources.copy
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If txtInput.Text.Trim = "" Then Exit Sub
        Clipboard.SetText(txtInput.Text)
        btnCopy.Image = CodeHelper.My.Resources.Resources.copy2
    End Sub

    Private Sub frmConvert_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            btnCopy_Click(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSwitch_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            btnConvert_Click(sender, e)
        End If
    End Sub

    Private Sub frmConvert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub btnAddVariable_Click(sender As Object, e As EventArgs) Handles btnAddVariable.Click
        If txtVariable.Text.Trim = "" OrElse txtInput.Text.Trim = "" Then Exit Sub

        Dim InsertPos As Integer = txtInput.SelectionStart
        Dim InsertText = If(txtInput.Text(InsertPos - 1) = """"c, "", """") & " & StrSql(" & txtVariable.Text & ")" &
        If(txtInput.Text.Length > InsertPos AndAlso (txtInput.Text(InsertPos) <> "&" AndAlso txtInput.Text(InsertPos + 1) <> "&"), " & """, "")
        txtInput.Text = txtInput.Text.Insert(InsertPos, InsertText)
    End Sub

    Private Sub btnSpace_Click(sender As Object, e As EventArgs) Handles btnSpace.Click
        Dim InputArray = txtInput.Text.Split(vbCrLf)
        Dim Spaces As String = ""
        Dim Output As String = ""
        If txtInput.Text.Trim = "" OrElse InputArray.Count < 2 Then Exit Sub
        For j = 1 To numSpaces.Value
            Spaces &= " "
        Next
        For i = 0 To InputArray.Count - 1
            'Remove additional vbLf & skip empty line
            InputArray(i) = InputArray(i).Replace(vbLf, "")
            If InputArray(i).Trim() = "" Then Continue For

            Output &= If(i > 0, vbCrLf & Spaces, "") & InputArray(i).TrimStart()
        Next
        txtInput.Text = Output
    End Sub
End Class
