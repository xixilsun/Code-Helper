Imports IDR.Common

Public Class frmMain
    Private Sub SQLVBNETToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLVBNETToolStripMenuItem.Click
        Dim Form As New frmConvert
        Form.Show()
        Me.Dispose()
    End Sub

    Private Sub DatabaseHelperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseHelperToolStripMenuItem.Click
        Dim Form As New FrmDatabaseHelper
        Form.Show()
        'Me.Dispose()
    End Sub
End Class