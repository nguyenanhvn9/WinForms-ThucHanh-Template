using System;
using System.Windows.Forms;

namespace TinhDiemWinForms_Ready
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Chào bạn!\n\nVui lòng nhập điểm 3 môn: Toán, Văn, Anh (từ 0 đến 10).\nSau đó nhấn 'Tính điểm' để xem kết quả trung bình và xếp loại học lực.",
                            "Hướng dẫn sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                double toan = double.Parse(txtToan.Text);
                double van = double.Parse(txtVan.Text);
                double anh = double.Parse(txtAnh.Text);

                if (!KiemTraDiem(toan) || !KiemTraDiem(van) || !KiemTraDiem(anh))
                {
                    MessageBox.Show("⚠️ Điểm phải nằm trong khoảng từ 0 đến 10", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dtb = Math.Round((toan + van + anh) / 3, 2);
                string xeploai = XepLoai(dtb);

                lblKQ.Text = $"Điểm trung bình: {dtb:F2} - Xếp loại: {xeploai}";
            }
            catch (FormatException)
            {
                MessageBox.Show("⚠️ Vui lòng nhập đúng định dạng số (không để trống và không nhập chữ)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDiem(double diem)
        {
            return diem >= 0 && diem <= 10;
        }

        private string XepLoai(double dtb)
        {
            if (dtb >= 8.0) return "Giỏi";
            else if (dtb >= 6.5) return "Khá";
            else if (dtb >= 3.0) return "Trung bình";
            else return "Yếu";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
