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
    public partial class EditCTNH : Form
    {
        DAO.Connection xldl = new DAO.Connection();
        DataTable dt, dt1;
        public EditCTNH()
        {
            InitializeComponent();
        }
        void loadlistbox()
        {


            dt = xldl.DocDuLieu("Select * from CTNHAPHANG");
            listView2.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView2.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());

            }
        }
        private void EditCTNH_Load(object sender, EventArgs e)
        {
            loadlistbox();
            loadlistboxSP();
            loadCombobox2();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            if (txtMaSP.Text == "")
            {
                errorProvider1.SetError(txtMaSP, "Không được để trống tên nhập hàng");
                txtMaSP.Focus();
                return;
            }
            if (txt_dongia.Text == "" || !char.IsDigit(txt_dongia.Text.ToString(), 0))
            {
                errorProvider2.SetError(txt_dongia, "Không được để trống giá");
                txt_dongia.Focus();
                return;
            }
            string sql2 = "select SOLUONG from SanPham where MASP = " + txtMaSP.Text + "";
            int i = xldl.LaySLTheoMa(sql2);
            string sql = "insert into CTNHAPHANG (MANHAP, MASP,Soluong,DonGia) values(N'" + cboMaNhap.SelectedItem + "', '" + txtMaSP.Text + "', " + number.Value + ", " + txt_dongia.Text + ")";
            if (i != number.Value)
            {
                if (xldl.ThemXoaSua(sql) != -1)
                {

                    MessageBox.Show("Them thanh cong");
                    loadlistbox();
                }
                else
                {
                    MessageBox.Show("Them that bai");
                }
            }
            else
            {
                MessageBox.Show("Số lượng " + number.Text + " không đủ. Vui Lòng Nhập Lại!!");
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_sua.Enabled = true;
            bt_xoa.Enabled = true;
           
            if (listView2.SelectedItems.Count > 0)
            {
                cboMaNhap.SelectedItem = listView2.SelectedItems[0].SubItems[0].Text;
                txtMaSP.Text = listView2.SelectedItems[0].SubItems[1].Text;
                number.Value = decimal.Parse(listView2.SelectedItems[0].SubItems[2].Text);
                txt_dongia.Text = listView2.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                txtMaSP.Text = listView1.SelectedItems[0].SubItems[0].Text;

            }
        }
        void loadlistboxSP()
        {
            dt = xldl.DocDuLieu("Select MaSP,TenSP, HinhAnh,Soluong,Gia,TinhTrang,MoTa, TENLOAI from SANPHAM,LOAISP where SANPHAM.MALOAI = LOAISP.MALOAI");
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
        public void loadCombobox2()
        {
            dt = xldl.DocDuLieu("select MANHAP from NHAPHANG");

            foreach (DataRow dong in dt.Rows)
            {
                cboMaNhap.Items.Add(dong[0].ToString());
            }

        }

        private void cboMaNhap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count <= 0)
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


                    string sql = "delete from CTNHAPHANG where MANHAP = '" + cboMaNhap.SelectedItem + "'";
                    if (xldl.ThemXoaSua(sql) != -1)
                    {
                        MessageBox.Show("Xóa thành công!!!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !!!");
                    }
                }
            }
            loadlistbox();
            loadlistboxSP();
            loadCombobox2();
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            cboMaNhap.Enabled = true;
            bt_them.Enabled = true;
            txtMaSP.Text = "";
            txt_dongia.Text = "";
            number.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql2 = "select SOLUONG from SanPham where MASP = " + txtMaSP.Text + "";
            int i = xldl.LaySLTheoMa(sql2);

            if (cboMaNhap.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn để nhập hàng!!!");
            }
            else
            {
                DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn cập nhật hàng " + cboMaNhap.SelectedItem + "không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {
                    string sql = "Update SanPham set soluong = (select (SANPHAM.SOLUONG + CTNHAPHANG.SOLUONG) from NHAPHANG,CTNHAPHANG where NHAPHANG.MANHAP = CTNHAPHANG.MANHAP and SANPHAM.MASP = CTNHAPHANG.MASP and CTNHAPHANG.MANHAP = '" + cboMaNhap.SelectedItem + "') where exists(select * from CTNHAPHANG where SANPHAM.MASP = CTNHAPHANG.MASP and CTNHAPHANG.MANHAP = '" + cboMaNhap.SelectedItem + "')";

                    if (xldl.ThemXoaSua(sql) != -1)
                    {
                        MessageBox.Show("Cập nhật thàng công");
                    }
                    else
                    {
                        MessageBox.Show("cập nhật  that bai");
                    }
                }

            }
            loadlistboxSP();    
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count <= 0)
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


                    string sql = "update CTNHAPHANG set  SOLUONG = " + number.Value + ", DONGIA = " + txt_dongia.Text + " where MANHAP = '" + cboMaNhap.SelectedItem + "' and  MASP = '" + txtMaSP.Text + "'";
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
                loadlistboxSP();
            }
        }
    }
}
