using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;


namespace QUANLYBENHVIEN_PH2
{
    public partial class NhanvienTiepTan : Form
    {
        public string connectionString;
        public string username;
        public NhanvienTiepTan()
        {
            InitializeComponent();
        }

        private void NhanvienTiepTan_Load(object sender, EventArgs e)
        {
            tentieptan.Text = username;
            //Danh sach benh nhan
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str = "SELECT * FROM BV.BENHNHAN";
            OracleCommand cmd1 = new OracleCommand(sql_str, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dtgv_thongtinbn.DataSource = dt1;
            //Danh sach ho so kham benh
            string sql_str2 = "SELECT * FROM BV.viewhskb";
            OracleCommand cmd2 = new OracleCommand(sql_str2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dtgv_hosokhambenh.DataSource = dt2;
            con.Close();

        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            ds_login lg = new ds_login();
            this.Hide();
            lg.Show();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "BV.SP_INSERT_BENHNHAN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("benhnhan", OracleDbType.Varchar2).Value = txt_idbn.Text;
            cmd.Parameters.Add("hoten", OracleDbType.Varchar2).Value = txt_hoten.Text;
            cmd.Parameters.Add("ngsinh", OracleDbType.Date).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("sdt", OracleDbType.Varchar2).Value = txt_sdtbn.Text;
            cmd.Parameters.Add("cmnd", OracleDbType.Varchar2).Value = txt_cmnd.Text;
            int rowsUpdated = cmd.ExecuteNonQuery(); ;
            if (rowsUpdated == 0)
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            else
            {
                MessageBox.Show("Thêm thành công!");
                string sql_str = "SELECT * FROM BV.BENHNHAN";
                OracleCommand cmd1 = new OracleCommand(sql_str, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dtgv_thongtinbn.DataSource = dt1;

            }
            con.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "BV.SP_DELETE_BENHNHAN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("benhnhan", OracleDbType.Varchar2).Value = txt_idbn.Text;
            int rowsUpdated = cmd.ExecuteNonQuery(); ;
            if (rowsUpdated == 0)
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            else
            {
                MessageBox.Show("Xóa thành công!");
                string sql_str = "SELECT * FROM BV.BENHNHAN";
                OracleCommand cmd1 = new OracleCommand(sql_str, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dtgv_thongtinbn.DataSource = dt1;
            }
            con.Close();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {


            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql2 = "SELECT ID_BENHNHAN, HOTENBN, NGAYSINHBN,SDT_BN,CMND_BN FROM BV.BENHNHAN WHERE HOTENBN LIKE '%" + txt_tkhoten.Text + "%'";
            OracleCommand cmd2 = new OracleCommand(sql2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dtgv_thongtinbn.DataSource = dt2;
            con.Close();
        }

    
    }
}
