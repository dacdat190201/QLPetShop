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
    public partial class InBaoCaoThang : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        public InBaoCaoThang()
        {
            InitializeComponent();
        }

        private void InBaoCaoThang_Load(object sender, EventArgs e)
        {
            LoadBaoCao();
        }
        public void LoadBaoCao()
        {
            DataTable dt = new DataTable();
            dt = xldt.DocDuLieu("select TENSP,CTNHAPHANG.DONGIA,CTHOADON.DONGIA as DONGIABAN, CTHOADON.soLuong,(CTHOADON.soLuong*CTHOADON.DONGIA - CTHOADON.soLuong*CTNHAPHANG.DONGIA) as TongTien \n" +
        "  " + "                 from HOADON,CTHOADON,SANPHAM,NHAPHANG,CTNHAPHANG\n" +
        "   " + "              where NHAPHANG.MANHAP = CTNHAPHANG.MANHAP and CTNHAPHANG.MASP = SANPHAM.MASP and HOADON.MAHD = CTHOADON.MAHD and SANPHAM.MASP = CTHOADON.MASP" +
        "   " + "                and MONTH(NGAYHD) = " + TruyenDuLieu.thang + " and YEAR(NGAYHD) = " + TruyenDuLieu.nam + "");

            RPBaoCao rpBao = new RPBaoCao();
            rpBao.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpBao;
        }
    }
}
