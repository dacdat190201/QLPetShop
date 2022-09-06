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
    public partial class EditNhapHang : Form
    {
        DAO.Connection xldl = new DAO.Connection();
        DataTable dt;
        public EditNhapHang()
        {
            InitializeComponent();
        }

        private void EditNhapHang_Load(object sender, EventArgs e)
        {
            loadlistbox();
        }
        public void loadCombobox()
        {
            dt = xldl.DocDuLieu("select MACC from NHACUNGCAP");

            foreach (DataRow dong in dt.Rows)
            {
                cboNCC.Items.Add(dong[0].ToString());
            }

        }
        void loadlistbox()
        {
            loadCombobox();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtMaNhap.Text = listView1.SelectedItems[0].SubItems[0].Text;
                cboNCC.SelectedItem = listView1.SelectedItems[0].SubItems[1].Text;
                txtTienDauTu.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtNgayNhap.Text = listView1.SelectedItems[0].SubItems[3].Text;  
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNhap.Text = "";
            txtTienDauTu.Text = "";
            txtNgayNhap.Text = "";
            txtMaNhap.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();

            //if (txtMaNhap.Text == "")
            //{
            //    errorProvider1.SetError(txtMaNhap, "Không được để trống Mã");
            //    txtMaNhap.Focus();
            //    return;
            //}
            
            if (txtTienDauTu.Text == "" || !char.IsDigit(txtTienDauTu.Text.ToString(), 0))
            {
                errorProvider3.SetError(txtTienDauTu, "Không được để trống và tiền đầu tư phải là số");
                txtTienDauTu.Focus();
                return;
            }
            //if (txtNgayNhap.Text == "")
            //{
            //    errorProvider4.SetError(txtNgayNhap, "Không được để trống địa chỉ");
            //    txtNgayNhap.Focus();
            //    return;
            //}


            string sql;
            sql = "insert into NHAPHANG(MACC,TIENDAUTU,NGAYNHAP) values ('"+cboNCC.SelectedItem+"',"+txtTienDauTu.Text+",getdate())";
            
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

        private void btnCapNhat_Click(object sender, EventArgs e)
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


                    string sql = "update NHAPHANG set  MACC=N'" + cboNCC.SelectedItem + "',TIENDAUTU=" + txtTienDauTu.Text + ",NGAYNHAP='" + txtNgayNhap.Text + "' where MANHAP=" + txtMaNhap.Text +"";
                    if (xldl.ThemXoaSua(sql) != -1)
                    {
                        loadlistbox();
                        MessageBox.Show("Sửa thanh cong");
                        txtMaNhap.Enabled = false;
                        txtNgayNhap.Enabled = false;
                        
                    }
                    else
                    {
                        MessageBox.Show("Sửa that bai");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNhap.Enabled = true;
            txtNgayNhap.Enabled = true;

        }
    }
}
