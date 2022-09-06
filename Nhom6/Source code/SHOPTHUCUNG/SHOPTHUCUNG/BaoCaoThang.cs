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
    public partial class BaoCaoThang : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt;
        int thang, nam;
        public BaoCaoThang()
        {
            InitializeComponent();
        }
        void loadngay()
        {



            for (int i = 1; i < 13; i++)
            {
                cbo_thang.Items.Add("" + i);
            }


            for (int i = 2001; i < 2050; i++)
            {
                cbo_nam.Items.Add("" + i);
            }
        }

        public Boolean ktNam(int nam)
        {
            if (nam < 1900 || nam > 2200)
            {
                return false;
            }
            return true;
        }

        public Boolean ktThang(int thang)
        {
            if (thang < 0 || thang > 12)
            {
                return false;
            }
            return true;
        }

        private void BaoCaoThang_Load(object sender, EventArgs e)
        {
            loadngay();
        }

        private void bt_tim_Click(object sender, EventArgs e)
        {
            int count = 0;
            double tongThanhTien = 0;
            if (cbo_thang.SelectedItem == null || cbo_nam.SelectedItem == null)
            {
                MessageBox.Show("Chọn tháng và năm cần thống kê!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {


                thang = int.Parse(cbo_thang.SelectedItem.ToString());
                nam = int.Parse(cbo_nam.SelectedItem.ToString());

                if (ktNam(nam))
                {
                    if (ktThang(thang))
                    {

                        //---------------Lấy số lượng ruou bán trong ngày cần kiểm tra
                        try
                        {
                            String sqlSoLuong = "select count(CTHOADON.soLuong)\n" +
    "  " + "                 from HOADON,CTHOADON,SANPHAM\n" +
    "   " + "              where HOADON.MAHD = CTHOADON.MAHD and SANPHAM.MASP = CTHOADON.MASP" +
    "   " + "               and  MONTH(NGAYHD) = " + thang + " and YEAR(NGAYHD) = " + nam + "";
                            count = Int32.Parse(xldt.TaiKhoan(sqlSoLuong).ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                        if (count > 0)
                        {
                            dt = xldt.DocDuLieu("select TENSP,CTNHAPHANG.DONGIA,CTHOADON.DONGIA, CTHOADON.soLuong,(CTHOADON.soLuong*CTHOADON.DONGIA - CTHOADON.soLuong*CTNHAPHANG.DONGIA)\n" +
    "  " + "                 from HOADON,CTHOADON,SANPHAM,NHAPHANG,CTNHAPHANG\n" +
    "   " + "              where NHAPHANG.MANHAP = CTNHAPHANG.MANHAP and CTNHAPHANG.MASP = SANPHAM.MASP and HOADON.MAHD = CTHOADON.MAHD and SANPHAM.MASP = CTHOADON.MASP" +
    "   " + "               and MONTH(NGAYHD) = " + thang + " and YEAR(NGAYHD) = " + nam + "");
                            listView1.Items.Clear();
                            foreach (DataRow dong in dt.Rows)
                            {
                                ListViewItem list = listView1.Items.Add(dong[0].ToString());
                                list.SubItems.Add(dong[1].ToString());
                                list.SubItems.Add(dong[2].ToString());
                                list.SubItems.Add(dong[3].ToString());
                                list.SubItems.Add(dong[4].ToString());
                                tongThanhTien += double.Parse(dong[4].ToString());
                            }
                            txt_tongtien.Text = tongThanhTien.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không có sản phẩm nào được bán trong  tháng " + thang + " năm" + nam + "");
                        }
                    }
                }
            }
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
     ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frm = new HoaDon();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product frm = new Product();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu frm = new TrangChu();
            frm.ShowDialog();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu frm = new TrangChu();
            frm.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
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

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frm = new HoaDon();
            frm.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
            frm.ShowDialog();
        }

        private void bt_in_Click(object sender, EventArgs e)
        {
            if (cbo_thang.SelectedItem == null || cbo_nam.SelectedItem == null)
            {
                MessageBox.Show("Chọn tháng và năm cần thống kê!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                thang = int.Parse(cbo_thang.SelectedItem.ToString());
                nam = int.Parse(cbo_nam.SelectedItem.ToString());

                TruyenDuLieu.thang = thang;
                TruyenDuLieu.nam = nam;
                InBaoCaoThang frm = new InBaoCaoThang();
                frm.ShowDialog();
            }
        }


    }
}
