using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADO.NET
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql_str;
            string con_string = System.Configuration.ConfigurationManager.ConnectionStrings["TTTH"].ConnectionString;
            SqlConnection cnn = new SqlConnection(con_string);
            cnn.Open();
            MessageBox.Show("Connection thanh cong!");
            sql_str = "SELECT * FROM ADO_TEST.dbo.VITRI";
            SqlCommand command = new SqlCommand(sql_str, cnn);
            //command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(command);
           DataTable dt = new DataTable();
            sda.Fill(dt);
            gridview1.DataSource = dt;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "TenViTri";
            comboBox1.ValueMember = "ID";

            cnn.Close();
        }

        private void datagridview1(object sender, DataGridViewCellEventArgs e)
        {       
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_str;
            string con_string = System.Configuration.ConfigurationManager.ConnectionStrings["TTTH"].ConnectionString;
            SqlConnection cnn = new SqlConnection(con_string);
            cnn.Open();
            SqlCommand Comman = new SqlCommand("SELECT ID,TenViTri FROM ADO_TEST.dbo.VITRI", cnn);
            SqlDataAdapter sda = new SqlDataAdapter(Comman);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "TenViTri";
            comboBox1.ValueMember = "ID";
            cnn.Close();
        }
    }
}
