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
    public partial class DangNhap : Form
    {
        DAO.Connection kn = new DAO.Connection();
        DataTable dt;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            
            String Name = txtName.Text;
            String MatKhau = txtPass.Text;
            String sql = "select count(TaiKhoan) from NhanVien where TaiKhoan = '" + Name + "' and MatKhau = '" + MatKhau + "'";
            
            dt = kn.DocDuLieu("select ChucVu from NhanVien where TaiKhoan = '" + Name + "' and MatKhau = '" + MatKhau + "'");
            if (kn.TaiKhoan(sql) > 0)
            {
                foreach(DataRow dong in dt.Rows)
                {
                    if (dong[0].ToString() == "Quản lý")
                    {
                        this.Hide();
                        TrangChu fm = new TrangChu();
                        fm.ShowDialog();
                   
                    }
                    else
                    {
                        this.Hide();
                        TrangChuNV fm = new TrangChuNV();
                        fm.ShowDialog();
                   
                    }
                    break;
                }
             
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtPass.Text = "";
                txtName.Focus();
            }
        }
      
        

        private void DangNhap_Load(object sender, EventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
        ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }
    }
}
