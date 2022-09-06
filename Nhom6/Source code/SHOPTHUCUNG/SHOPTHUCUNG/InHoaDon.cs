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
    public partial class InHoaDon : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        public InHoaDon()
        {
            InitializeComponent();
        }

        private void InHoaDon_Load(object sender, EventArgs e)
        {
            LoadBaoCao();
        }
        public void LoadBaoCao()
        {
            DataTable dt = new DataTable();
            dt = xldt.DocDuLieu(" select TENSP,CTHOADON.DONGIA,CTHOADON.Soluong,CTHOADON.SOLUONG * CTHOADON.DONGIA AS Expr1, HOADON.NGAYHD, KHACHHANG.TENKH, NHANVIEN.TENNV \n" +
  "  " + "  FROM  CTHOADON INNER JOIN \n" +
             "   " + "        HOADON ON CTHOADON.MAHD = HOADON.MAHD INNER JOIN  \n" +
"   " + " KHACHHANG ON HOADON.MAKH = KHACHHANG.MAKH INNER JOIN  \n" +
      "   " + "            NHANVIEN ON HOADON.MANV = NHANVIEN.MANV INNER JOIN\n" +
            "   " + "      SANPHAM ON CTHOADON.MASP = SANPHAM.MaSP where CTHOADON.MAHD = "+TruyenDuLieu.MAHD+"");

            RPHoaDon rpBao = new RPHoaDon();
            rpBao.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpBao;
        }
    }
}
