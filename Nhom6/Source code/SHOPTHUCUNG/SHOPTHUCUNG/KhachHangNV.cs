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
    public partial class KhachHangNV : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt, dt2;
        public KhachHangNV()
        {
            InitializeComponent();
        }

        private void KhachHangNV_Load(object sender, EventArgs e)
        {
            loadlistbox();
            loadcombox();
        }
        void loadlistbox()
        {
            dt = xldt.DocDuLieu("Select * from KHACHHANG");
            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
                list.SubItems.Add(dong[4].ToString());
                list.SubItems.Add(dong[5].ToString());
            }
        }
        public void loadcombox()
        {
            cbo_phanloai.Items.Add("VIP");
            cbo_phanloai.Items.Add("Vãng lai");
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_makh.Enabled = false;
            if (listView1.SelectedItems.Count > 0)
            {
                txt_makh.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tenkh.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_date.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_diachi.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_dth.Text = listView1.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            if (txt_makh.Text == "")
            {
                errorProvider1.SetError(txt_makh, "Không được để trống mã khách hàng");
                txt_makh.Focus();
                return;
            }
            if (txt_tenkh.Text == "")
            {
                errorProvider2.SetError(txt_tenkh, "Không được để trống tên khách hàng");
                txt_tenkh.Focus();
                return;
            }
            if (txt_diachi.Text == "")
            {
                errorProvider3.SetError(txt_diachi, "Không được để trống địa chỉ");
                txt_diachi.Focus();
                return;
            }
            if (txt_dth.Text == "" || !char.IsDigit(txt_dth.Text.ToString(), 0))
            {
                errorProvider4.SetError(txt_dth, "Không được để trống số điện thoại và số điện thoại phải là số");
                txt_dth.Focus();
                return;
            }
            string sql = "insert into KHACHHANG(MAKH, TENKH,NGSINH,PHANLOAI,DIACHI, DTHOAI) values ('" + txt_makh.Text + "', N'" + txt_tenkh.Text + "', '" + txt_date.Text + "',N'" + cbo_phanloai.SelectedItem + "',N'" + txt_diachi.Text + "', '" + txt_dth.Text + "')";
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


                    string sql = "delete from KHACHHANG where MAKH = '" + txt_makh.Text + "'";
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
                    string sql = "update KHACHHANG set  TENKH = N'" + txt_tenkh.Text + "', NGSINH = '" + txt_date.Value + "',PHANLOAI = N'" + cbo_phanloai.SelectedItem + "', DIACHI = N'" + txt_diachi.Text + "', DTHOAI = '" + txt_dth.Text + "'  where MAKH = '" + txt_makh.Text + "'";
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

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txt_makh.Enabled = true;
            txt_makh.Clear();
            txt_tenkh.Clear();
            txt_date.Refresh();
            txt_diachi.Clear();
            txt_dth.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPhamNV frm = new SanPhamNV();
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
