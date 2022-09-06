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
    public partial class TrangChu : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt;
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            String sql = "Select Count(masp) from SANPHAM where Maloai = 1";
            String sql1 = "Select Count(masp) from SANPHAM where Maloai = 2";
            String sql2 = "Select Count(masp) from SANPHAM where Maloai = 3";
            lb_slcho.Text =  xldt.DemSoLuong(sql).ToString();
            lb_slphu.Text = xldt.DemSoLuong(sql2).ToString();
            lb_slmeo.Text = xldt.DemSoLuong(sql1).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product frm = new Product();
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frm = new HoaDon();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
      ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
            frm.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien frm = new NhanVien();
            frm.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHang frm = new KhachHang();
            frm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhaphang frm = new Nhaphang();
            frm.ShowDialog();
        }
    }
}
