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
    public partial class Product : Form
    {
        String imLocation = "";
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt;
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
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
        private void btn_them_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            if(txt_tensp.Text == "")
            {
                errorProvider1.SetError(txt_tensp, "Không được để trống tên");
                txt_tensp.Focus();
                return;
            }
            if(txt_hinh.Text == "")
            {
                errorProvider2.SetError(txt_hinh, "Không được để trống hình");
                txt_hinh.Focus();
                return;
            }
            if (txt_gia.Text == "" || !char.IsDigit(txt_gia.Text.ToString(), 0))
            {
                errorProvider3.SetError(txt_gia, "Không được để trống giá và giá phải là số");
                txt_gia.Focus();
                return;
            }
            if (txt_mota.Text == "")
            {
                errorProvider4.SetError(txt_mota, "Không được để trống mô tả");
                txt_mota.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                errorProvider5.SetError(textBox1, "Không được để trống loại sản phẩm");
                textBox1.Focus();
                return;
            }
            
            string sql = "insert into SanPham (TenSP, HinhAnh,Soluong,Gia,MoTa, MALOAI) values(N'" + txt_tensp.Text + "', '" + txt_hinh.Text + "', " + number.Value + ", " + txt_gia.Text + ", N'" + txt_mota.Text + "', " + textBox1.Text + ")";
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

        private void btn_xoa_Click(object sender, EventArgs e)
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


                    string sql = "delete from SANPHAM where MASP = " + txt_ma.Text + "";
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

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu frm = new TrangChu();
            frm.ShowDialog();
        }

        private void btn_sua_Click(object sender, EventArgs e)
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


                    string sql = "update SANPHAM set TENSP = N'" + txt_tensp.Text + "',SoLuong = " + number.Value + ",Mota = N'" + txt_mota.Text + "',GIA = " + txt_gia.Text + ",HINHANH = '" + txt_hinh.Text + "',MALOAI = " + textBox1.Text + " where MASP = " + txt_ma.Text + "";
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

        private void btn_uphinh_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png) |*.png|jpg files(*.jpg)|*.jpg|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imLocation = dialog.FileName.ToString();
                txt_hinh.Text = imLocation;
            }
            pictureBox5.Image = Image.FromFile(imLocation);
        }

       

        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_gia.Text = "";
            txt_ma.Text = "";
            txt_mota.Text = "";
            txt_tensp.Text = "";
            textBox1.Text = "";
            cb_masp.ValueMember = "";
            number.Value = 0;
            bt_them.Enabled = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void cb_masp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_masp.SelectedItem.Equals("Chó"))
            {
                textBox1.Text = "1";
            }
            else if (cb_masp.SelectedItem.Equals("Mèo"))
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = "3";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien frm = new NhanVien();
            frm.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
