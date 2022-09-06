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
    public partial class HoaDonNV : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt, dt2, dt3, dt4, dt5, dtsp;
        public HoaDonNV()
        {
            InitializeComponent();
        }

        private void HoaDonNV_Load(object sender, EventArgs e)
        {
            loadCombobox();
            loadCombobox2();
            loadlistboxSP();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }
        void loadlistbox()
        {


            dt = xldt.DocDuLieu("Select CTHOADON.MaHD,MaSP,Soluong ,DonGia, SOLUONG*DONGIA as TONGTIEN from CTHOADON, HOADON where CTHOADON.MAHD = HOADON.MAHD");
            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
                list.SubItems.Add(dong[4].ToString());
            }
        }
        void loadlistboxSP()
        {
            dtsp = xldt.DocDuLieu("Select MaSP,TenSP, HinhAnh,Soluong,Gia,TinhTrang,MoTa, TENLOAI from SANPHAM,LOAISP where SANPHAM.MALOAI = LOAISP.MALOAI");
            listView2.Items.Clear();
            foreach (DataRow dong in dtsp.Rows)
            {
                ListViewItem list = listView2.Items.Add(dong[0].ToString());
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
            dt3 = xldt.DocDuLieu("select MANV from NHANVIEN");
            dt4 = xldt.DocDuLieu("select MAKH from KHACHHANG");
            foreach (DataRow dong in dt3.Rows)
            {
                cbo_manv.Items.Add(dong[0].ToString());
            }
            foreach (DataRow dong in dt4.Rows)
            {
                cbo_makh.Items.Add(dong[0].ToString());
            }
        }
        public void loadCombobox()
        {
            dt2 = xldt.DocDuLieu("select * from HOADON");
            foreach (DataRow dong in dt2.Rows)
            {
                cbo_mahd.Items.Add(dong[0].ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_sua.Enabled = true;
            bt_xoa.Enabled = true;
            bt_them.Enabled = false;
            if (listView1.SelectedItems.Count > 0)
            {
                cbo_mahd.SelectedItem = listView1.SelectedItems[0].SubItems[0].Text;
                txt_masp.Text = listView1.SelectedItems[0].SubItems[1].Text;
                number.Value = decimal.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                txt_dongia.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            if (txt_sp.Text == "")
            {
                errorProvider1.SetError(txt_sp, "Không được để trống tên hóa đơn");
                txt_sp.Focus();
                return;
            }
            if (txt_dongia.Text == "" || !char.IsDigit(txt_dongia.Text.ToString(), 0))
            {
                errorProvider2.SetError(txt_dongia, "Không được để trống đơn giá");
                txt_dongia.Focus();
                return;
            }
            string sql2 = "select SOLUONG from SanPham where MASP = " + txt_masp.Text + "";
            int i = xldt.LaySLTheoMa(sql2);
            string sql = "insert into CTHOADON (MAHD, MASP,Soluong,DonGia) values(N'" + cbo_mahd.SelectedItem + "', '" + txt_masp.Text + "', " + number.Value + ", " + txt_dongia.Text + ")";
            if (i >= number.Value)
            {
                if (xldt.ThemXoaSua(sql) != -1)
                {

                    MessageBox.Show("Them thanh cong");
                }
                else
                {
                    MessageBox.Show("Them that bai");
                }
            }
            else
            {
                MessageBox.Show("Số lượng " + txt_sp.Text + " không đủ. Vui Lòng Nhập Lại!!");
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


                    string sql = "delete from CTHOADON where MAHD = " + cbo_mahd.SelectedItem + "";
                    if (xldt.ThemXoaSua(sql) != -1)
                    {
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


                    string sql = "update CTHOADON set  SOLUONG = " + number.Value + ", DONGIA = " + txt_dongia.Text + " where MAHD = " + cbo_mahd.SelectedItem + " and  MASP = " + txt_sp.Text + "";
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

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChuNV frm = new TrangChuNV();
            frm.ShowDialog();
        }

        private void bt_mua_Click(object sender, EventArgs e)
        {
            string sql2 = "select SOLUONG from SanPham where MASP = " + txt_masp.Text + "";
            int i = xldt.LaySLTheoMa(sql2);

            if (cbo_mahd.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để thanh toán!!!");
            }
            else
            {
                DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn thanh toán hóa đơn " + cbo_mahd.SelectedItem + " không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {

                    string sql = "Update SanPham set soluong = (select (SANPHAM.SOLUONG - CTHOADON.SOLUONG) from HOADON, CTHOADON where HOADON.MAHD = CTHOADON.MAHD and SANPHAM.MASP = CTHOADON.MASP and CTHOADON.MAHD = " + cbo_mahd.SelectedItem + ") where exists(select * from CTHOADON where SANPHAM.MASP = CTHOADON.MASP and CTHOADON.MAHD = " + cbo_mahd.SelectedItem + ")";
                    if (xldt.ThemXoaSua(sql) != -1)
                    {
                        MessageBox.Show("Đã Thanh toán hóa đơn với giá " + txt_tongtien.Text + "");
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán that bai");
                    }


                }
            }
            loadlistboxSP();
            listView1.Items.Clear();
              
        }

        private void bt_them2_Click(object sender, EventArgs e)
        {
            string sql = "insert into HOADON (MAKH, NGAYHD,MANV) values('" + cbo_makh.SelectedItem + "',  getdate() , '" + cbo_manv.SelectedItem + "')";
            if (xldt.ThemXoaSua(sql) != -1)
            {
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
            cbo_mahd.Items.Clear();
            loadCombobox();
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            cbo_mahd.Enabled = true;
            bt_them.Enabled = true;
            txt_sp.Text = "";
            txt_masp.Text = "";
            txt_dongia.Text = "";
            number.Value = 0;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                txt_masp.Text = listView2.SelectedItems[0].SubItems[0].Text;
                txt_sp.Text = listView2.SelectedItems[0].SubItems[1].Text;
                txt_dongia.Text = listView2.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void cbo_mahd_SelectedIndexChanged(object sender, EventArgs e)
        {
            double tongtien = 0;
            dt = xldt.DocDuLieu("Select CTHOADON.MaHD,MaSP,Soluong ,DonGia, SOLUONG*DONGIA as TONGTIEN from CTHOADON, HOADON where CTHOADON.MAHD = HOADON.MAHD and CTHOADON.MAHD = " + cbo_mahd.SelectedItem + "");

            listView1.Items.Clear();
            foreach (DataRow dong in dt.Rows)
            {
                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
                list.SubItems.Add(dong[4].ToString());
                tongtien += double.Parse(dong[4].ToString());
            }
            txt_tongtien.Text = tongtien.ToString();
            dt5 = xldt.DocDuLieu("select PHANLOAI from KHACHHANG, HOADON where KHACHHANG.MAKH = HOADON.MAKH and MAHD = " + cbo_mahd.SelectedItem + "");
            foreach (DataRow dong in dt5.Rows)
            {
                if (dong[0].ToString() == "VIP")
                {
                    txt_tongtien.Text = (tongtien - (tongtien * 0.1)).ToString();

                }
                else
                {
                    txt_tongtien.Text = txt_tongtien.Text;
                }
                break;
            }
        }

        private void bt_tim_Click(object sender, EventArgs e)
        {
            dtsp = xldt.DocDuLieu("Select MaSP,TenSP, HinhAnh,Soluong,Gia,TinhTrang,MoTa, TENLOAI from SANPHAM,LOAISP where SANPHAM.MALOAI = LOAISP.MALOAI and TENSP like N'%" + txt_timkiem.Text + "%'");
            listView2.Items.Clear();
            foreach (DataRow dong in dtsp.Rows)
            {
                ListViewItem list = listView2.Items.Add(dong[0].ToString());
                list.SubItems.Add(dong[1].ToString());
                list.SubItems.Add(dong[2].ToString());
                list.SubItems.Add(dong[3].ToString());
                list.SubItems.Add(dong[4].ToString());
                list.SubItems.Add(dong[5].ToString());
                list.SubItems.Add(dong[6].ToString());
                list.SubItems.Add(dong[7].ToString());

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPhamNV frm = new SanPhamNV();
            frm.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHangNV frm = new KhachHangNV();
            frm.ShowDialog();
        }
    }
}
