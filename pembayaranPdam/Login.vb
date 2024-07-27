Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = "select * from admin where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"
        'MsgBox(sql)
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("username atau password kosonng")
        Else
            If getCount(sql) = 0 Then
                MsgBox("username atau Paswword salah")
            Else
                Menu_Utama.id_admin = getValue(sql, "id_admin")
                Menu_Utama.Label9.Text = getValue(sql, "nama_admin")

                Menu_Utama.Show()
                Me.Hide()
                TextBox1.Clear()
                TextBox2.Clear()
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class
