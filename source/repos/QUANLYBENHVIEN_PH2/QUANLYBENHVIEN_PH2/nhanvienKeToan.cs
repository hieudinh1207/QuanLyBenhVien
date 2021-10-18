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
    public partial class nhanvienKeToan : Form
    {
        public string connectionString;
        public string username;
        public nhanvienKeToan()
        {
            InitializeComponent();
        }

        private void nhanvienKeToan_Load(object sender, EventArgs e)
        {
            ktoan.Text = username;
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str = "select *  from BV.view_thongtinluongnv";
            OracleCommand cmd = new OracleCommand(sql_str, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_luongnhanvien.DataSource = dt;
            con.Close();
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            ds_login lg = new ds_login();
            this.Hide();
            lg.Show();
        }

        private void btn_capnhatluong_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "BV.SP_update_luong_NHANVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("nv", OracleDbType.Varchar2).Value = txt_IDNV.Text;
            cmd.Parameters.Add("lg", OracleDbType.Double).Value = Convert.ToDouble(txt_luong.Text);
            int rowsUpdated = cmd.ExecuteNonQuery(); ;
            if (rowsUpdated == 0)
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            else
            {
                MessageBox.Show("Cập nhật thành công!");
            }

            con.Close();
        }

        private void dtgv_luongnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_luongnhanvien.Rows[e.RowIndex];
                txt_IDNV.Text = row.Cells[0].Value.ToString();
            }
            con.Close();
        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str = "select *  from BV.view_thongtinluongnv";
            OracleCommand cmd = new OracleCommand(sql_str, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_luongnhanvien.DataSource = dt;
            con.Close();
        }
    }
}
