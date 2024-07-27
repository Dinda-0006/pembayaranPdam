Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Menu_Utama
    Public id_admin, Id_satuan, id
    'Dim id = "0"
    Dim aksi = False
    Sub awal()
        DataGridView1.DataSource = getData("select * from pelanggan where nama_pelanggan like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "pelanggan"
        DataGridView1.Columns(2).HeaderText = "alamat"
        DataGridView1.Columns(3).HeaderText = "no_telp"

        aksi = True
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value

            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub


    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        admin.ShowDialog()
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PelangganToolStripMenuItem.Click
        pelanggan.ShowDialog()
    End Sub
    Private Sub SatuanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatuanToolStripMenuItem.Click
        satuan.ShowDialog()
    End Sub

    Private Sub Menu_Utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cari_satuan.ShowDialog()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "" Then
            TextBox5.Text = 0
        Else
            TextBox6.Text = Double.Parse(TextBox5.Text) * Double.Parse(TextBox4.Text)
        End If

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        laporan.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        clearForm(GroupBox2)
    End Sub

    'Mengerluaarkan user dari penggunakan aplikasi
    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click
        aksi = True
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pembayaran.TextBox1.Text = TextBox6.Text
        pembayaran.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Menu_Utama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If aksi = False Then
            Login.Close()
        End If
    End Sub
End Class