using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOPTHUCUNG
{
    public partial class TrangChuNV : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        public TrangChuNV()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHangNV frm = new KhachHangNV();
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDonNV frm = new HoaDonNV();
            frm.ShowDialog();
        }

        private void TrangChuNV_Load(object sender, EventArgs e)
        {
            String sql = "Select Count(masp) from SANPHAM where Maloai = 1";
            String sql1 = "Select Count(masp) from SANPHAM where Maloai = 2";
            String sql2 = "Select Count(masp) from SANPHAM where Maloai = 3";
            lb_slcho.Text = xldt.DemSoLuong(sql).ToString();
            lb_slphu.Text = xldt.DemSoLuong(sql2).ToString();
            lb_slmeo.Text = xldt.DemSoLuong(sql1).ToString();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
     ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPhamNV frm = new SanPhamNV();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
