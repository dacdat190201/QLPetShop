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
    public partial class NhaCungCap : Form
    {
        DAO.Connection xldl = new DAO.Connection();
        DataTable dt;
        public NhaCungCap()
        {
            InitializeComponent();
        }
        void loadlistbox()
        {
            dt = xldl.DocDuLieu("Select * from NHACUNGCAP");
            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
            }
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            loadlistbox();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtMa.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtDC.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtDT.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();

            if (txtMa.Text == "")
            {
                errorProvider1.SetError(txtMa, "Không được để trống Mã");
                txtMa.Focus();
                return;
            }
            if (txtTen.Text == "")
            {
                errorProvider2.SetError(txtTen, "Không được để trống Tên");
                txtTen.Focus();
                return;
            }

            if (txtDC.Text == "")
            {
                errorProvider3.SetError(txtDC, "Không được để trống địa chỉ");
                txtDC.Focus();
                return;
            }
            if (txtDT.Text == "" || !char.IsDigit(txtDT.Text.ToString(), 0))
            {
                errorProvider4.SetError(txtDT, "Không được để trống giá và điện thoại phải là số");
                txtDT.Focus();
                return;
            }
            string sql;
            sql = string.Format(@"insert into NHACUNGCAP(MACC,TENCC,DIACHI,DTHOAI) values ('{0}',N'{1}',N'{2}','{3}')", txtMa.Text
                , txtTen.Text, txtDC.Text, txtDT.Text);
            if (xldl.ThemXoaSua(sql) != -1)
            {
                loadlistbox();
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDT.Text = "";
            txtDC.Text = "";
            txtMa.Focus();
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


                    string sql = "delete from NHACUNGCAP where MACC = '" + txtMa.Text + "'";
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

        private void button1_Click(object sender, EventArgs e)
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


                    string sql = "update NHACUNGCAP set  TENCC=N'" + txtTen.Text + "',DIACHI=N'" + txtDC.Text + "',DTHOAI='" + txtDT.Text + "' where MACC='" + txtMa.Text + "'";
                    if (xldl.ThemXoaSua(sql) != -1)
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
    }
}
