Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class satuan
    Dim id = "0"
    Dim aksi = False
    Sub awal()
        DataGridView1.DataSource = getData("select * from satuan where satuan like '%" & TextBox4.Text & "%'")
        clearForm(GroupBox2)
        DataGridView1.Columns(0).HeaderText = "Id satuan"
        DataGridView1.Columns(1).HeaderText = "satuan"
        DataGridView1.Columns(2).HeaderText = "harga"


        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        id = "0"
    End Sub
    Sub buka()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
    End Sub
    Private Sub satuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()

    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        awal()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearForm(GroupBox2)
        aksi = False
        buka()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        awal()
        clearForm(GroupBox2)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql
            If Not aksi Then
                sql = "insert into satuan values('" & TextBox1.Text & "','" & TextBox2.Text & "')"
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            Else
                sql = "update satuan set satuan = '" & TextBox1.Text & "',satuan = '" & TextBox2.Text & "',harga = '" & "'  where id_satuan = " & id
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            End If

        End If

    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value


            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from satuan where id_satuan =" & id
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            End If
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            aksi = True
            buka()
        End If
    End Sub
End Class