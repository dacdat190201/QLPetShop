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
    public partial class BaoCao : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        DataTable dt;
        int ngay, thang, nam;
        public BaoCao()
        {
            InitializeComponent();
        }
        void loadngay()
        {
            for (int i = 1; i < 32; i++)
            {
                cbo_ngay.Items.Add("" + i);
            }


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

        public Boolean ktNgay(int ngay)
        {
            switch (Int32.Parse(cbo_thang.SelectedItem.ToString()))
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (ngay < 0 || ngay > 31)
                    {
                        return false;
                    }
                    break;
                case 2:
                    if (Int32.Parse(cbo_nam.SelectedItem.ToString()) % 400 == 0 || Int32.Parse(cbo_nam.SelectedItem.ToString()) % 4 == 0)
                    {
                        if (ngay < 0 || ngay > 29)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (ngay < 0 || ngay > 28)
                        {
                            return false;
                        }
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (ngay < 0 || ngay > 30)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
        private void BaoCao_Load(object sender, EventArgs e)
        {
            loadngay();
        }

        private void bt_tim_Click(object sender, EventArgs e)
        {
            int count = 0;
            double tongThanhTien = 0;
            if (cbo_ngay.SelectedItem == null || cbo_thang.SelectedItem == null || cbo_nam.SelectedItem == null)
            {
                MessageBox.Show("Chọn ngày, tháng, năm cần thống kê!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ngay = int.Parse(cbo_ngay.SelectedItem.ToString());
                thang = int.Parse(cbo_thang.SelectedItem.ToString());
                nam = int.Parse(cbo_nam.SelectedItem.ToString());

                if (ktNam(nam))
                {
                    if (ktThang(thang))
                    {
                        if (ktNgay(ngay))
                        {
                            //---------------Lấy số lượng ruou bán trong ngày cần kiểm tra
                            try
                            {
                                String sqlSoLuong = "select count(CTHOADON.soLuong)\n" +
        "  " + "                 from HOADON,CTHOADON,SANPHAM\n" +
        "   " + "              where HOADON.MAHD = CTHOADON.MAHD and SANPHAM.MASP = CTHOADON.MASP" +
        "   " + "               and DAY(NGAYHD) = " + ngay + " and MONTH(NGAYHD) = " + thang + " and YEAR(NGAYHD) = " + nam + "";
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
       "   " + "               and DAY(NGAYHD) = " + ngay + " and MONTH(NGAYHD) = " + thang + " and YEAR(NGAYHD) = " + nam + "");
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
                                MessageBox.Show("Không có sản phẩm nào được bán trong ngày " + ngay + " tháng " + thang + " năm" + nam + "");
                            }
                        }
                        else
                        {
                            switch (thang)
                            {
                                case 4:
                                case 6:
                                case 9:
                                case 11:
                                    if (ngay == 31)
                                    {
                                        MessageBox.Show(this, "Tháng " + thang + " chỉ có 30 ngày. Vui lòng nhập lại !");
                                    }
                                    break;
                                case 2:
                                    if (nam % 400 == 0 || nam % 4 == 0)
                                    {
                                        if (ngay == 30 || ngay == 31)
                                        {
                                            MessageBox.Show(this, "Năm " + nam + " Tháng " + thang + " chỉ có 29 ngày. Vui lòng chọn lại !");
                                        }
                                    }
                                    else
                                    {
                                        if (ngay == 29 || ngay == 30 || ngay == 31)
                                        {
                                            MessageBox.Show(this, "Năm " + nam + " Tháng " + thang + " chỉ có 28 ngày.");
                                        }
                                    }
                                    break;
                            }
                        }
                    }

                }
            }
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien frm = new NhanVien();
            frm.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHang frm = new KhachHang();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCaoThang frm = new BaoCaoThang();
            frm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhaphang frm = new Nhaphang();
            frm.ShowDialog();
        }

        private void bt_in_Click(object sender, EventArgs e)
        {
            if (cbo_ngay.SelectedItem == null || cbo_thang.SelectedItem == null || cbo_nam.SelectedItem == null)
            {
                MessageBox.Show("Chọn ngày, tháng, năm cần in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ngay = int.Parse(cbo_ngay.SelectedItem.ToString());
                thang = int.Parse(cbo_thang.SelectedItem.ToString());
                nam = int.Parse(cbo_nam.SelectedItem.ToString());
                TruyenDuLieu.ngay = ngay;
                TruyenDuLieu.thang = thang;
                TruyenDuLieu.nam = nam;
                InBaoCao frm = new InBaoCao();
                frm.ShowDialog();

            }
        }
    }
}
