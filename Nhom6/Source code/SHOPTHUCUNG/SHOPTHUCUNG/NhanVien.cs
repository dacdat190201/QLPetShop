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
    public partial class NhanVien : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt, dt2;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadlistbox();
        }
        void loadlistbox()
        {
            loadCombobox();
            dt = xldt.DocDuLieu("Select * from NHANVIEN");
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
                list.SubItems.Add(dong[8].ToString());
            }
        }
        public void loadCombobox()
        {
            cbo_cv.Items.Add("Nhân Viên");
            cbo_cv.Items.Add("Quản Lý");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_manv.Enabled = false;
            if (listView1.SelectedItems.Count > 0)
            {
                txt_manv.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tennv.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_date.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_diachi.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_dth.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txt_luong.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txt_tk.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txt_mk.Text = listView1.SelectedItems[0].SubItems[7].Text;
                cbo_cv.SelectedItem = listView1.SelectedItems[0].SubItems[8].Text;
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
            errorProvider7.Clear();
            errorProvider8.Clear();
            if(txt_manv.Text == "")
            {
                errorProvider1.SetError(txt_manv, "Không được để trống mã nhân viên");
                txt_manv.Focus();
                return;
            }
            if (txt_tennv.Text == "")
            {
                errorProvider2.SetError(txt_tennv, "Không được để trống tên nhân viên");
                txt_tennv.Focus();
                return;
            }
            if (txt_diachi.Text == "")
            {
                errorProvider3.SetError(txt_diachi, "Không được để trống địa chỉ");
                txt_diachi.Focus();
                return;
            }
            if (txt_luong.Text == "" || !char.IsDigit(txt_luong.Text.ToString(), 0))
            {
                errorProvider4.SetError(txt_luong, "Không được để trống lương và lương phải là số");
                txt_luong.Focus();
                return;
            }
            if (txt_dth.Text == "" || !char.IsDigit(txt_dth.Text.ToString(), 0))
            {
                errorProvider5.SetError(txt_dth, "Không được để trống số đth và số đth phải là số");
                txt_dth.Focus();
                return;
            }
            if (txt_tk.Text == "")
            {
                errorProvider6.SetError(txt_tk, "Không được để trống tài khoản");
                txt_tk.Focus();
                return;
            }
            if (txt_mk.Text == "")
            {
                errorProvider7.SetError(txt_mk, "Không được để trống mật khẩu");
                txt_mk.Focus();
                return;
            }
            if (cbo_cv != null)
            {
                errorProvider8.SetError(cbo_cv, "Không được để trống lương và lương phải là số");
                cbo_cv.Focus();
                return;
            }
            string sql = "insert into NHANVIEN(MANV, TENNV, NGSINH, DIACHI,DTHOAI,LUONG,TAIKHOAN,MATKHAU,CHUCVU) values ('" + txt_manv.Text + "', N'" + txt_tennv.Text + "','" + txt_date.Value + "','" + txt_diachi.Text + "','" + txt_dth.Text + "','" + txt_luong.Text + "','" + txt_tk.Text + "','" + txt_mk.Text + "','" + cbo_cv.SelectedItem + "')";
            if (xldt.ThemXoaSua(sql) != -1)
            {
                loadlistbox();
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
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


                    string sql = "delete from NHANVIEN where MANV = '" + txt_manv.Text + "'";
                    if (xldt.ThemXoaSua(sql) != -1)
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Chọn item muốn sửa");
                return;
            }
            else
            {
                DialogResult h = MessageBox.Show
                 ("Bạn có chắc muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {


                    string sql = "update NHANVIEN set  TENNV = N'" + txt_tennv.Text + "', NGSINH = '" + txt_date.Value + "', DIACHI = N'" + txt_diachi.Text + "', DTHOAI = '" + txt_dth.Text + "', LUONG = '" + txt_luong.Text + "', TAIKHOAN = '" + txt_tk.Text + "', MATKHAU = '" + txt_mk.Text + "', CHUCVU = N'" + cbo_cv.SelectedItem + "'  where MANV = '" + txt_manv.Text + "'";
                    if (xldt.ThemXoaSua(sql) != -1)
                    {
                        loadlistbox();
                        MessageBox.Show("Sửa thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Sửa that bai");
                    }
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txt_manv.Enabled = true;
            txt_tennv.Enabled = true;
            txt_dth.Enabled = true;
            txt_diachi.Enabled = true;
            txt_date.Enabled = true;
            txt_tk.Enabled = true;
            txt_mk.Enabled = true;
            cbo_cv.Enabled = true;
            txt_manv.Clear();
            txt_tennv.Clear();
            txt_dth.Clear();
            txt_luong.Clear();
            txt_diachi.Clear();
            txt_tk.Clear();
            txt_mk.Clear();
            cbo_cv.Text = "";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu frm = new TrangChu();
            frm.ShowDialog();
        }

        private void label15_Click_1(object sender, EventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
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