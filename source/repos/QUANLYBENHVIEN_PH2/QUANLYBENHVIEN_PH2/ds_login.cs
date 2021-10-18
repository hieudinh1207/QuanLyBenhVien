using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
namespace QUANLYBENHVIEN_PH2
{
    
    public partial class ds_login : Form
    {
        String connectionString;
     
        public ds_login()
        {
            InitializeComponent();
            txt_matkhau.PasswordChar = '*';
        }
        private void ds_login_Load(object sender, EventArgs e)
        {

        }
        public string loadusername()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            string sqlname = "SELECT HOTENNV  FROM BV.NHANVIEN WHERE ID_NV = '" + txt_username.Text + "'";
            OracleCommand cmd1 = new OracleCommand(sqlname, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            string name = dt1.Rows[0][0].ToString();
            con.Close();
            return name;
        }
        private void btn_dnhap_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_matkhau.Text;
            connectionString = "Data Source = (DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = XEPDB1))); User Id = " + username + "; Password = " + password + "; ";
            
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();

            try
            {
                if (txt_username.Text == "" || txt_matkhau.Text == "")
                {
                    MessageBox.Show(" Nhập vào tên đăng nhập và mật khẩu.");
                    return;
                }
                if (username == "BV" && password == "abcd1234")
                {
                    con.Open();
                    Quanlyhethong fmht = new Quanlyhethong();
                    fmht.connectionString = connectionString;
                    fmht.username = username;
                    this.Hide();
                    fmht.Show();
                    dt.Clear();
                    con.Close();
                }
                else
                {
                    con.Open();
                    cmd = new OracleCommand("SELECT * FROM BV.NHANVIEN where ID_NV=:user_name and MatKhau=:pswd", con);
                    cmd.Parameters.Add(new OracleParameter(":user_name", txt_username.Text));
                    cmd.Parameters.Add(new OracleParameter(":pswd", txt_matkhau.Text));
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);
                    int i = dt.Rows.Count;
                    if (i == 1)
                    {
                        string type = dt.Rows[0]["VaiTro"].ToString();
                        if (type == "DV01")
                        {
                            NhanvienBacsi fm = new NhanvienBacsi();// bac si
                            fm.connectionString = connectionString;
                            fm.username = loadusername();
                            fm.ID = username;
                            this.Hide();
                            fm.Show();
                            dt.Clear();
                        }
                        else if (type == "DV06") // quan ly nhan su
                        {
                            Quanlynhansu frm = new Quanlynhansu();
                            frm.connectionString = connectionString;
                            frm.username = loadusername();
                            this.Hide();
                            frm.Show();
                            dt.Clear();
                        }
                        else if (type == "DV03")// Nhan vien ke toan 
                        {
                            nhanvienKeToan frm3 = new nhanvienKeToan();
                            frm3.connectionString = connectionString;
                            frm3.username = loadusername();
                            this.Hide();
                            frm3.Show();
                            dt.Clear();
                        }
                        else if (type == "DV04")// Nhan vien tiep tan  
                        {
                            NhanvienTiepTan frm4 = new NhanvienTiepTan();
                            frm4.connectionString = connectionString;
                            frm4.username = loadusername();
                            this.Hide();
                            frm4.Show();
                            dt.Clear();
                        }
                        else if (type == "DV07")// Quan ly chuyen mon
                        {
                            Quanlychuyenmon frm5 = new Quanlychuyenmon();
                            frm5.connectionString = connectionString;
                            frm5.username = loadusername();
                            this.Hide();
                            frm5.Show();
                            dt.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Người dùng chưa đăng kí...Hoặc mật khẩu không hợp lệ");
                        txt_username.Text = "";
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Người dùng chưa đăng kí...Hoặc mật khẩu không hợp lệ");
            }


            con.Close();
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
