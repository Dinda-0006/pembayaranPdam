Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class cari_satuan

    Sub awal()
        DataGridView1.DataSource = getData("select * from satuan where satuan like '%" & TextBox1.Text & "%'")
        clearForm(GroupBox1)
        DataGridView1.Columns(0).HeaderText = "Id satuan"
        DataGridView1.Columns(1).HeaderText = "satuan"
        DataGridView1.Columns(2).HeaderText = "harga"

    End Sub

    Private Sub cari_satuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Menu_Utama.TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Menu_Utama.TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            Menu_Utama.Id_satuan = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Me.Close()
        End If
    End Sub
End Class