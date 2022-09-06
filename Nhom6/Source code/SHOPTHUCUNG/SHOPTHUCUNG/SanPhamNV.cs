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
    public partial class SanPhamNV : Form
    {
        String imLocation = "";
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt;
        public SanPhamNV()
        {
            InitializeComponent();
        }

        private void SanPhamNV_Load(object sender, EventArgs e)
        {
            loadlistbox();
        }
        void loadlistbox()
        {
            loadCombobox();
            dt = xldt.DocDuLieu("Select MaSP,TenSP, HinhAnh,Soluong,Gia,TinhTrang,MoTa, TENLOAI from SANPHAM,LOAISP where SANPHAM.MALOAI = LOAISP.MALOAI");
            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
                list.SubItems.Add(dong[4].ToString());
                list.SubItems.Add(dong[5].ToString());
                list.SubItems.Add(dong[6].ToString());
                list.SubItems.Add(dong[7].ToString());

            }
        }
        public void loadCombobox()
        {
            dt = xldt.DocDuLieu("select TENLOAI from LOAISP");
            cb_masp.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                cb_masp.Items.Add(dong[0].ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txt_ma.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tensp.Text = listView1.SelectedItems[0].SubItems[1].Text;
                pictureBox5.ImageLocation = listView1.SelectedItems[0].SubItems[2].Text;
                number.Value = decimal.Parse(listView1.SelectedItems[0].SubItems[3].Text);
                txt_gia.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txt_mota.Text = listView1.SelectedItems[0].SubItems[6].Text;
                cb_masp.SelectedItem = listView1.SelectedItems[0].SubItems[7].Text;
                txt_hinh.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

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

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChuNV frm = new TrangChuNV();
            frm.ShowDialog();
        }
    }
}
