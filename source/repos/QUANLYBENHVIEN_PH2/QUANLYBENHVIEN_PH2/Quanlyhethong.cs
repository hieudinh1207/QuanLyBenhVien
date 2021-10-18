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
    
    public partial class Quanlyhethong : Form
    {
        public string connectionString;
        public string username;
        public Quanlyhethong()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Quanlyhethong_Load(object sender, EventArgs e)
        {
            tenad.Text = username;
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str = "select * from DBA_AUDIT_POLICIES";
            OracleCommand cmd = new OracleCommand(sql_str, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_chinhsachaudit.DataSource = dt;
            
        
            //
            string sql_str2 = "SELECT * FROM DBA_STMT_AUDIT_OPTS";
            OracleCommand cmd2 = new OracleCommand(sql_str2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dtgv_Thongtinchitiet_user.DataSource = dt2;
            con.Close();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
      
            con.Close();

        }

        private void btn_Dangxuat_qlht_Click(object sender, EventArgs e)
        {
            ds_login lg = new ds_login();
            this.Hide();
            lg.Show();
        }

        private void btn_ttchitiet_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str1 = "SELECT SESSION_ID,TIMESTAMP,DB_USER,OBJECT_NAME,POLICY_NAME,SQL_TEXT,STATEMENT_TYPE,EXTENDED_TIMESTAMP FROM DBA_FGA_AUDIT_TRAIL";
            OracleCommand cmd1 = new OracleCommand(sql_str1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dtgv_chinhsachaudit.DataSource = dt1;
            con.Close();
        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str = "select * from DBA_AUDIT_POLICIES";
            OracleCommand cmd = new OracleCommand(sql_str, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_chinhsachaudit.DataSource = dt;
            con.Close();
        }

        private void btn_xem_audituser_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str2 = "SELECT * FROM DBA_STMT_AUDIT_OPTS";
            OracleCommand cmd2 = new OracleCommand(sql_str2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dtgv_Thongtinchitiet_user.DataSource = dt2;
            con.Close();
        }

        private void btn_ttctuser_Click(object sender, EventArgs e)
        {

        }
    }
}
