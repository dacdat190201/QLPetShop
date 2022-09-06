using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SHOPTHUCUNG.DAO
{
    class Connection
    {
        SqlConnection con;
         SqlCommand cmd;
        SqlDataAdapter da;
        
        public Connection()
        {
            string connection = @"Data source=DESKTOP-QDRGJQ8\SQLEXPRESS; Initial Catalog= QL_SHOPTHUCUNG1; Integrated Security = false; uid = sa;pwd = 123";
            con = new SqlConnection(connection);
        }
        public Connection(string sv,string db,bool au,string uid,string pwd)
        {
            string chuoiketnoi = "";
            if(au == false)
                chuoiketnoi = string.Format(@"Data source={0}; Initial Catalog= {1}; Integrated Security = {2}; uid = {3};pwd = {4}",sv,db,au,uid,pwd);
            else
                chuoiketnoi = string.Format(@"Data source={0}; Initial Catalog= {1}; Integrated Security = {2},sv,db,au");
        }
        public DataTable DocDuLieu(String sql)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sql,con);
            da.Fill(dt);
            return dt;
        }
        public int ThemXoaSua(String sql)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand(sql, con);
                int kq = cmd.ExecuteNonQuery();
                con.Close();
                return kq;
            }
            catch (SqlException e)
            {
                return -1;
            }
        }

        public int TaiKhoan(String sql)
        {

          
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand(sql, con);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                return kq;
            }
            catch (SqlException e)
            {
                return -1;
            }

        }
        public int DemSoLuong(String sql)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand(sql, con);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                return kq;
            }
            catch (SqlException e)
            {
                return -1;
            }

        }
        public double tienThanhToan(String sql)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand(sql, con);
                double kq = (double)cmd.ExecuteScalar();
                con.Close();
                return kq;
            }
            catch (SqlException e)
            {
                return -1;
            }

        }
        public int LaySLTheoMa(String sql)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand(sql, con);
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                return kq;
            }
            catch (SqlException e)
            {
                return -1;
            }

        }
       
    }
}
