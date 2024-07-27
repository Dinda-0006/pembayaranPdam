Imports System.Drawing.Printing
Public Class pembayaran
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog

    Private Sub pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = 0
    End Sub

    'untuk menampilkan data yang diinginkan
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            TextBox2.Text = 0
        ElseIf TextBox1.Text = "" Then
            TextBox2.Text = 0
        Else
            TextBox3.Text = Double.Parse(TextBox2.Text) - Double.Parse(TextBox1.Text)
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("Data Kosong")
        Else
            Dim sql = "insert into transaksi values ('" & Menu_Utama.id_admin & "','" & Menu_Utama.id & "','" & Menu_Utama.Id_satuan & "','" & Menu_Utama.TextBox5.Text & "',
                      '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "','" & Date.Now.ToString("yyyy/MM/dd") & "','dibayar')"
            'MsgBox(sql)
            exc(sql)
            MsgBox("pembayaran berhasil")
            TextBox1.Clear()
            TextBox2.Text = 0
            TextBox3.Clear()
            clearForm(Menu_Utama.GroupBox2)
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14 As New Font("Times New Roman", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "-------------------------------------------------------------------------"

        e.Graphics.DrawString("PDAM KOTA TUBAN", f14, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl.Pramuka No.17, Latsari, Kab. Tuban", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("No.Telp : 0853-4391-8894", f10, Brushes.Black, centermargin, 40, tengah)

        e.Graphics.DrawString("No Faktur", f10, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f10, Brushes.Black, 65, 60)
        e.Graphics.DrawString("12345", f10, Brushes.Black, 75, 60)

        e.Graphics.DrawString("Admin", f10, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f10, Brushes.Black, 65, 75)
        e.Graphics.DrawString("Dinda", f10, Brushes.Black, 75, 75)

        e.Graphics.DrawString("13/05/2024 08.30", f10, Brushes.Black, 0, 90)

        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 100)

        Dim yPos As Integer = 80


        Dim Nama_Pelanggan As String = Menu_Utama.TextBox2.Text
        Dim Satuan As String = Menu_Utama.TextBox3.Text
        Dim Harga As String = Menu_Utama.TextBox4.Text
        Dim Pemakaian_Bulanan As String = Menu_Utama.TextBox5.Text
        Dim Total As String = TextBox1.Text
        Dim Bayar As String = TextBox2.Text
        Dim Kembali As String = TextBox3.Text

        yPos += 40
        e.Graphics.DrawString("Nama Pelanggan : " & Nama_Pelanggan, f10, Brushes.Black, 5, yPos)
        yPos += 20
        e.Graphics.DrawString("Satuan : " & Satuan, f10, Brushes.Black, 5, yPos)
        yPos += 20
        e.Graphics.DrawString("Harga: " & Harga, f10, Brushes.Black, 5, yPos)
        yPos += 20
        e.Graphics.DrawString("Pemakaian Bulanan : " & Pemakaian_Bulanan, f10, Brushes.Black, 5, yPos)
        yPos += 20

        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 190)

        e.Graphics.DrawString("Total : " & Total, f10b, Brushes.Black, rightmargin, 200, kanan)
        yPos += 20
        e.Graphics.DrawString("Bayar : " & Bayar, f10, Brushes.Black, 5, yPos)
        yPos += 20
        e.Graphics.DrawString("Kembali : " & Kembali, f10, Brushes.Black, 5, yPos)

        e.Graphics.DrawString("Simpanlah struk ini sebagai", f10, Brushes.Black, centermargin, 270, tengah)
        e.Graphics.DrawString("bukti pembayaran anda", f10, Brushes.Black, centermargin, 290, tengah)
        e.Graphics.DrawString("~Terima Kasih~", f10b, Brushes.Black, centermargin, 310, tengah)

    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 340, 340)
        PD.DefaultPageSettings = pagesetup
    End Sub
End Class
