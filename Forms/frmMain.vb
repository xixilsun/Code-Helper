Imports System.Windows.Forms
Imports DevExpress.XtraTab
Imports IDR.Common

Public Class frmMain
    Private frmConvert As frmConvert
    Private frmDatabaseHelper As FrmDatabaseHelper

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create tab
        Dim tabPage1 As New XtraTabPage()
        tabPage1.Text = "Convert Vb & Sql"
        Dim tabPage2 As New XtraTabPage()
        tabPage2.Text = "Database Helper"

        XtraTabControl1.TabPages.Add(tabPage1)
        XtraTabControl1.TabPages.Add(tabPage2)

        'load
        frmConvert = New frmConvert()
        frmConvert.TopLevel = False
        frmConvert.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmConvert.Dock = Windows.Forms.DockStyle.Fill
        tabPage1.Controls.Add(frmConvert)
        frmConvert.Show()

        frmDatabaseHelper = New FrmDatabaseHelper()
        frmDatabaseHelper.TopLevel = False
        frmDatabaseHelper.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmDatabaseHelper.Dock = Windows.Forms.DockStyle.Fill
        frmDatabaseHelper.MainForm = Me
        tabPage2.Controls.Add(frmDatabaseHelper)
        frmDatabaseHelper.Show()
    End Sub
    Friend Sub ConvertSql(query As String)
        XtraTabControl1.SelectedTabPageIndex = 0
        frmConvert.btnSwitch_Click(Nothing, Nothing)
        frmConvert.ConvertInput(query, "SQL", "VB.NET")
    End Sub

End Class