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
    public partial class Quanlychuyenmon : Form
    {
        public string connectionString;
        public string username;
        public Quanlychuyenmon()
        {
            InitializeComponent();
        }

        private void Quanlychuyenmon_Load(object sender, EventArgs e)
        {
            tenqlcm.Text = username;
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str2 = "select * from BV.HOSOKHAMBENH";
            OracleCommand cmd2 = new OracleCommand(sql_str2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dtgv_thongtindieutri.DataSource = dt2;
            con.Close();
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            ds_login lg = new ds_login();
            this.Hide();
            lg.Show();
        }
    }
}
