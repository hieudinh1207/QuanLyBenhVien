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
    public partial class Quanlynhansu : Form
    {

        public string connectionString;
        public string username;
        public Quanlynhansu()
        {
            InitializeComponent();
        }
        private void Quanlynhansu_Load(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            tenqlds.Text = username;
            //danh sach nhan vien
            string sql_str1 = "select *  from BV.NHANVIEN";
            OracleCommand cmd1 = new OracleCommand(sql_str1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dtgv_danhsachnv.DataSource = dt1;

            //danh sach phong ban
            string sql_str2 = "select *  from BV.DONVI";
            OracleCommand cmd2 = new OracleCommand(sql_str2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dtgv_donvi.DataSource = dt2;

            con.Close();
        }

        private void btn_dangxuat_qlns_Click(object sender, EventArgs e)
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
            cmd.CommandText = "BV.SP_INSERT_NHANVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("nv", OracleDbType.Varchar2).Value = txt_IDNV.Text;
            cmd.Parameters.Add("hoten", OracleDbType.Varchar2).Value = txt_hoten.Text;
            cmd.Parameters.Add("mk", OracleDbType.Varchar2).Value = txt_matkhau.Text;
            cmd.Parameters.Add("ngsinh", OracleDbType.Date).Value = ngaysinhnv.Text;
            cmd.Parameters.Add("diachi", OracleDbType.Varchar2).Value = txt_diachi.Text;
            cmd.Parameters.Add("sdt", OracleDbType.Varchar2).Value = txt_sdt.Text;
            cmd.Parameters.Add("lg", OracleDbType.Double).Value = txt_luong.Text;
            cmd.Parameters.Add("sotk", OracleDbType.Varchar2).Value = txt_stk.Text;
            cmd.Parameters.Add("tenkh", OracleDbType.Varchar2).Value = cbx_khoa.Text;
            cmd.Parameters.Add("tenvt", OracleDbType.Varchar2).Value = cbx_donvi.Text;
            int rowsUpdated = cmd.ExecuteNonQuery(); ;
            if (rowsUpdated == 0)
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            else
            {
                MessageBox.Show("Thêm thành công!");
            }

            con.Close();
        }

        private void btn_dsnhanvien_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sql_str1 = "select *  from BV.NHANVIEN";
            OracleCommand cmd1 = new OracleCommand(sql_str1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dtgv_danhsachnv.DataSource = dt1;
            con.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "BV.SP_DELETE_NHANVIEN";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("nv", OracleDbType.Varchar2).Value = txt_IDNV.Text;
            int rowsUpdated = cmd.ExecuteNonQuery(); ;
            if (rowsUpdated == 0)
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            else
            {
                MessageBox.Show("Xóa thành công!");
            }

            con.Close();
        }

        private void dtgv_danhsachnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_danhsachnv.Rows[e.RowIndex];
                txt_IDNV.Text = row.Cells[0].Value.ToString();
            }
            con.Close();
        }
    }
}
