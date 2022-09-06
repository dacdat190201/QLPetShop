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
    public partial class InNhap : Form
    {
        DAO.Connection xldt = new DAO.Connection();
        public InNhap()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            LoadBaoCao();

        }
        public void LoadBaoCao()
        {
            DataTable dt = new DataTable();
            dt = xldt.DocDuLieu("SELECT SANPHAM.TenSP, CTNHAPHANG.SOLUONG, NHAPHANG.MANHAP, NHAPHANG.MACC, NHAPHANG.TIENDAUTU, NHAPHANG.NGAYNHAP FROM     CTNHAPHANG INNER JOIN NHAPHANG ON CTNHAPHANG.MANHAP = NHAPHANG.MANHAP INNER JOIN SANPHAM ON CTNHAPHANG.MASP = SANPHAM.MaSP");

            RPnhaphang rpBao = new RPnhaphang();
            rpBao.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpBao;
        }
    }
}
