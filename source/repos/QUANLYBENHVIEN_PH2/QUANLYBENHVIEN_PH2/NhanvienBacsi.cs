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
   
    public partial class NhanvienBacsi : Form
    {
        
        public string connectionString;
        public string username;
        public string ID;
        public NhanvienBacsi()
        {
            InitializeComponent();
        }
        public void loadcombobox()
        {

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            DataTable table = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand("SELECT ID_DV,TENDICHVU FROM BV.DICHVU", con);
            cmd.ExecuteNonQuery();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            cbx_dichvu.DataSource = table;
            cbx_dichvu.DisplayMember = "TENDICHVU";
            cbx_dichvu.ValueMember = "ID_DV";
            con.Close();   
        }
        private void NhanvienBacsi_Load(object sender, EventArgs e)
        {
            tenbs.Text = username;
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                DataTable table = new DataTable();
                OracleDataAdapter adapter = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd = con.CreateCommand();
                //load ho so kham benh
                cmd.CommandText = "select * from BV.HOSOKHAMBENH";
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                dtgv_hosokhambenh.DataSource = table;
                this.loadcombobox();
                //load ho so dich vu
                string makb = dtgv_hosokhambenh.Rows[0].Cells[0].Value.ToString();
                string sql_str = "select TENDICHVU,KETLUAN,NGAYGIO,NV_THUCHIEN FROM BV.HOSODICHVU, BV.DICHVU WHERE ID_DICHVU = ID_DV AND ID_KHAMBENH = " + "'" + makb + "'";
                OracleCommand cmd1 = new OracleCommand(sql_str, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dtgv_hosodichvu.DataSource = dt1;


                //load thong bao
                string sql_str2 = "select MESSAGE,LABEL_TO_CHAR (ROWLABEL)  from BV.announcements";
                OracleCommand cmd2 = new OracleCommand(sql_str2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dtgv_thongbao.DataSource = dt2;
                //chi tiet don thuoc 
                string sql_str3 = "SELECT BV.CHITIETDONTHUOC.* FROM BV.CHITIETDONTHUOC,BV.HOSOKHAMBENH WHERE ID_KHAMBENH = ID_KB";
                OracleCommand cmd3 = new OracleCommand(sql_str3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dtgv_chithietdonthuoc.DataSource = dt3;
                //Bang thuoc
                string sql_str4 = "select *  from BV.THUOC";
                OracleCommand cmd4 = new OracleCommand(sql_str4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dtgv_bangthuoc.DataSource = dt4;
                //Thong tin ca nhan
                string sql_str5 = "SELECT ID_NV,HOTENNV,NGAYSINHNV,DIACHINV,SDT_NV,STK,KHOA,VAITRO FROM BV.NHANVIEN";
                OracleCommand cmd5 = new OracleCommand(sql_str5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dtgv_thongtincanhan.DataSource = dt5;
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
           
        }

        private void tbn_Dangxuat_nvbs_Click(object sender, EventArgs e)
        {
            ds_login lg = new ds_login();
            this.Hide();
            lg.Show();
        }

        private void dtgv_hosokhambenh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtgv_hosokhambenh.Rows[e.RowIndex];
                    this.txt_ID_KB.Text = row.Cells[0].Value.ToString();
                    this.txt_idkb.Text = row.Cells[0].Value.ToString();
                    string idkb = row.Cells[0].Value.ToString();
                    string sql_str = "select TENDICHVU,KETLUAN,NGAYGIO,NV_THUCHIEN FROM BV.HOSODICHVU, BV.DICHVU WHERE ID_DICHVU = ID_DV AND ID_KHAMBENH = " + "'" + idkb + "'";
                    OracleCommand cmd1 = new OracleCommand(sql_str, con);
                    OracleDataReader dr1 = cmd1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    dtgv_hosodichvu.DataSource = dt1;
                }
                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
            
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "BV.SP_INSERT_HSDV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("idkb", OracleDbType.Varchar2).Value = txt_ID_KB.Text;
                cmd.Parameters.Add("TDV", OracleDbType.Varchar2).Value = cbx_dichvu.Text;
                int rowsUpdated = cmd.ExecuteNonQuery(); ;
                if (rowsUpdated == 0)
                    MessageBox.Show("Thất bại! Vui lòng thử lại!");
                else
                {
                    MessageBox.Show("Thêm thành công!");
                }

                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
 
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                string sqlselect = "update BV.HOSOKHAMBENH SET KETLUAN = '" + txt_ketluan.Text + "' where ID_KB = '" + txt_ID_KB.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0)
                    MessageBox.Show("Thất bại! Vui lòng thử lại!");
                else
                {
                    MessageBox.Show("Cập nhật thành công!");
                    string sql_str = "select * from BV.HOSOKHAMBENH";
                    OracleCommand cmd1 = new OracleCommand(sql_str, con);
                    OracleDataReader dr1 = cmd1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    dtgv_hosokhambenh.DataSource = dt1;
                }
                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
 
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "BV.SP_DELETE_HSDV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("idkb", OracleDbType.Varchar2).Value = txt_ID_KB.Text;
                cmd.Parameters.Add("TDV", OracleDbType.Varchar2).Value = cbx_dichvu.Text;
                int rowsUpdated = cmd.ExecuteNonQuery(); ;
                if (rowsUpdated == 0)
                    MessageBox.Show("Thất bại! Vui lòng thử lại!");
                else
                {
                    MessageBox.Show("Xóa thành công!");
                }

                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
            
        }

        private void dtgv_hosodichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_hosodichvu.Rows[e.RowIndex];
                cbx_dichvu.Text = row.Cells[0].Value.ToString();   
            }
            con.Close();
        }

        private void btn_thongtincanhan_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                string sql_str = "select ID_NV,HOTENNV, BV.F_DECRYPT(STK)STK from BV.NHANVIEN where ID_NV = '" + ID + "'";
                OracleCommand cmd1 = new OracleCommand(sql_str, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dtgv_thongtincanhan.DataSource = dt1;
                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
       
        }

        private void btn_themthuoc_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "BV.SP_insert_Chitietdonthuoc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id_thuoc", OracleDbType.Varchar2).Value = txt_idthuoc.Text;
                cmd.Parameters.Add("id_kb", OracleDbType.Varchar2).Value = txt_idkb.Text;
                cmd.Parameters.Add("sluong", OracleDbType.Int32).Value = Convert.ToInt32(this.txt_soluong.Text);
                cmd.Parameters.Add("ttlieudung", OracleDbType.Varchar2).Value = txt_lieudung.Text;
                cmd.Parameters.Add("ttmota", OracleDbType.Varchar2).Value = txt_mota.Text;
                int rowsUpdated = cmd.ExecuteNonQuery(); ;
                if (rowsUpdated == 0)
                    MessageBox.Show("Thất bại! Vui lòng thử lại!");
                else
                {
                    MessageBox.Show("Thêm thành công!");
                    string sql_str = "SELECT BV.CHITIETDONTHUOC.* FROM BV.CHITIETDONTHUOC,BV.HOSOKHAMBENH WHERE ID_KHAMBENH = ID_KB";
                    OracleCommand cmd1 = new OracleCommand(sql_str, con);
                    OracleDataReader dr1 = cmd1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    dtgv_chithietdonthuoc.DataSource = dt1;
                }
                con.Close();

            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
        }


        private void dtgv_bangthuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtgv_bangthuoc.Rows[e.RowIndex];
                    txt_idthuoc.Text = row.Cells[0].Value.ToString();
                }
                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }

        }



    private void btn_xoadt_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "BV.SP_delete_Chitietdonthuoc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id_thuoc", OracleDbType.Varchar2).Value = txt_idthuoc.Text;
                cmd.Parameters.Add("id_kb", OracleDbType.Varchar2).Value = txt_idkb.Text;
                int rowsUpdated = cmd.ExecuteNonQuery(); ;
                if (rowsUpdated == 0)
                    MessageBox.Show("Thất bại! Vui lòng thử lại!");
                else
                {
                    MessageBox.Show("Xóa thành công!");
                    string sql_str = "SELECT BV.CHITIETDONTHUOC.* FROM BV.CHITIETDONTHUOC,BV.HOSOKHAMBENH WHERE ID_KHAMBENH = ID_KB";
                    OracleCommand cmd1 = new OracleCommand(sql_str, con);
                    OracleDataReader dr1 = cmd1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    dtgv_chithietdonthuoc.DataSource = dt1;
                }
                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
          
        }

        private void btn_ttcn_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                string sql_str5 = "SELECT ID_NV,HOTENNV,NGAYSINHNV,DIACHINV,SDT_NV,STK,KHOA,VAITRO FROM BV.NHANVIEN";
                OracleCommand cmd5 = new OracleCommand(sql_str5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dtgv_thongtincanhan.DataSource = dt5;
                con.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("Thất bại! Vui lòng thử lại!");
            }
       
        }
    }
}
