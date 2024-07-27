Public Class laporan
    Dim id
    Sub awal()
        DataGridView1.DataSource = getData("select nama_admin, nama_pelanggan, alamat, no_telp, satuan, harga, pemakaian_bulanan, total, bayar,
                                   kembali, status, tgl_bayar from Pembayaran where nama_pelanggan like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).HeaderText = "nama_admin"
        DataGridView1.Columns(1).HeaderText = "nama_admin"
        DataGridView1.Columns(1).HeaderText = "nama_pelanggan"

    End Sub

    Private Sub laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "Excel Files (.xlsx)|.xlsx"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xlaapp As Microsoft.Office.Interop.Excel.Application
            Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misvalue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlaapp = New Microsoft.Office.Interop.Excel.Application
            xlworkbook = xlaapp.Workbooks.Add(misvalue)
            xlworksheet = xlworkbook.Sheets.Item(1)
            For j = 0 To DataGridView1.RowCount - 1
                xlworksheet.Cells(1, j + 1) = DataGridView1.Columns(j).HeaderText
            Next
            For i = 0 To DataGridView1.RowCount - 1
                For j = 0 To DataGridView1.ColumnCount - 1
                    xlworksheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString
                Next
            Next



            xlworksheet.SaveAs(SaveFileDialog1.FileName)
            xlworkbook.Close()
            xlaapp.Quit()

            relaseobject(xlaapp)
            relaseobject(xlworkbook)
            relaseobject(xlworksheet)

            MsgBox("Ekspor Berhasil")

        End If
    End Sub
End Class