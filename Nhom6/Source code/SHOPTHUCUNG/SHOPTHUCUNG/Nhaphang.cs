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
    public partial class Nhaphang : Form
    {
        DAO.Connection xldl = new DAO.Connection();
        DataTable dt;
        public Nhaphang()
        {
            InitializeComponent();
            loadNhaCungCap();
        }
        void loadNhaCungCap()
        {
            //loadCombobox();
            dt = xldl.DocDuLieu("Select * from NhaCungCap");
            listView3.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView3.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());


            }
        }
        void loadlistbox()
        {
            //loadCombobox();
            dt = xldl.DocDuLieu("Select * from NHAPHANG");
            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());


            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu frm = new TrangChu();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product frm = new Product();
            frm.ShowDialog();
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

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
           HoaDon frm = new HoaDon();
            frm.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
            frm.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }

        private void Nhaphang_Load(object sender, EventArgs e)
        {
            loadlistbox();
            loadNhaCungCap();
            rdoNow.Checked = true;
            btnThem.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.SelectedItems[0].SubItems[0].Text;//Lấy mã

                dt = xldl.DocDuLieu("Select * from CTNHAPHANG WHERE MANHAP='" + s + "'");
                listView2.Items.Clear();
                foreach (DataRow dong in dt.Rows)
                {
                    ListViewItem list = listView2.Items.Add(dong[0].ToString());
                    list.SubItems.Add(dong[1].ToString());
                    list.SubItems.Add(dong[2].ToString());
                    list.SubItems.Add(dong[3].ToString());


                }
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (rdoNow.Checked == true)
            {

                rdoNgayLap.Enabled = true;
                rdoTongTien.Enabled = true;

                txtTimKiem.Enabled = true;
                btnLoc.Enabled = true;
                btnRS.Enabled = true;
                bt_xoa.Enabled = true;
                btnLoc.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                btnThem.Enabled = false;
                loadNhaCungCap();
            }
            else if (rdoThayDoi.Checked == true)
            {

                rdoNgayLap.Enabled = false;
                rdoTongTien.Enabled = false;

                txtTimKiem.Enabled = false;
                btnLoc.Enabled = false;
                btnRS.Enabled = false;
                bt_xoa.Enabled = false;
                btnLoc.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                btnThem.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaCungCap frm = new NhaCungCap();
            frm.ShowDialog();
            this.Show();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (rdoTongTien.Checked)
            {

                string sql = "exec show_HD_TongTien_Giam";
                dt = xldl.DocDuLieu(sql);
                listView1.Items.Clear();
                foreach (DataRow dong in dt.Rows)
                {
                    ListViewItem list = listView1.Items.Add(dong[0].ToString());
                    list.SubItems.Add(dong[1].ToString());
                    list.SubItems.Add(dong[2].ToString());
                    list.SubItems.Add(dong[3].ToString());


                }


            }
            else if (rdoNgayLap.Checked)
            {
                string sql = "select * from NHAPHANG order by MONTH(NGAYNHAP) DESC";
                dt = xldl.DocDuLieu(sql);
                listView1.Items.Clear();
                foreach (DataRow dong in dt.Rows)
                {
                    ListViewItem list = listView1.Items.Add(dong[0].ToString());
                    list.SubItems.Add(dong[1].ToString());
                    list.SubItems.Add(dong[2].ToString());
                    list.SubItems.Add(dong[3].ToString());


                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            loadlistbox();
            string sql = "select count(MANHAP) FROM NHAPHANG";
            int a = xldl.DemSoLuong(sql);
            txtSL.Text = a.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = @"select * from NHAPHANG where MaNhap LIKE N'%" + txtTimKiem.Text + "%'";
            dt = xldl.DocDuLieu(str);
            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
            }
        }

        private void txtTKCC_TextChanged(object sender, EventArgs e)
        {
            if (rdoMaCC.Checked)
            {
                string str = "exec TimKiem_Macc '" + txtTKCC.Text + "'";
                dt = xldl.DocDuLieu(str);
                listView3.Items.Clear();
                foreach (DataRow dong in dt.Rows)
                {
                    ListViewItem list = listView3.Items.Add(dong[0].ToString());
                    list.SubItems.Add(dong[1].ToString());
                    list.SubItems.Add(dong[2].ToString());
                    list.SubItems.Add(dong[3].ToString());
                }
            }
            else if (rdoTenCC.Checked)
            {
                string str = "select * from NHACUNGCAP where TENCC Like N'%" + txtTKCC.Text + "%'";
                dt = xldl.DocDuLieu(str);
                listView3.Items.Clear();
                foreach (DataRow dong in dt.Rows)
                {
                    ListViewItem list = listView3.Items.Add(dong[0].ToString());
                    list.SubItems.Add(dong[1].ToString());
                    list.SubItems.Add(dong[2].ToString());
                    list.SubItems.Add(dong[3].ToString());
                }
            }
            else if (rdoDTCC.Checked)
            {
                string str = "select * from NHACUNGCAP where DTHOAI like '%" + txtTKCC.Text + "%'";
                dt = xldl.DocDuLieu(str);
                listView3.Items.Clear();
                foreach (DataRow dong in dt.Rows)
                {
                    ListViewItem list = listView3.Items.Add(dong[0].ToString());
                    list.SubItems.Add(dong[1].ToString());
                    list.SubItems.Add(dong[2].ToString());
                    list.SubItems.Add(dong[3].ToString());
                }
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            loadlistbox();
            txtTimKiem.Text = "";
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string s = listView1.SelectedItems[0].SubItems[0].Text;//Lấy mã

            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Chọn sản phẩm muốn xóa!!!");
                return;
            }
            else
            {
                DialogResult h = MessageBox.Show
                 ("Bạn có chắc muốn xoa không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {


                    string sql = "delete from NHAPHANG where MANHAP = '" + s + "'";
                    if (xldl.ThemXoaSua(sql) != -1)
                    {
                        loadlistbox();
                        MessageBox.Show("Xóa thành công!!!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !!!");
                    }
                }
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditNhapHang frm = new EditNhapHang();
            frm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditCTNH frm = new EditCTNH();
            frm.ShowDialog();
            this.Show();
        }

        private void bt_in_Click(object sender, EventArgs e)
        {
            InNhap frm = new InNhap();
            frm.ShowDialog();
        }
    }
}
