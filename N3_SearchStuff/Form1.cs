using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace N3_SearchStuff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=LAQUAN;Integrated Security=True");

        //kết nối csdl
        public void connect()
        {
            con.Open();

            string sql = "Select * from Stuff ";

            // thực thi lệnh trong csdl
            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);
            
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Button b = new Button() { Height = 100, Width = 100 };
                b.Text = dr[0].ToString() + dr[1].ToString();
                flowLayoutPanel1.Controls.Add(b);
            }       
            //bảng hiển thị dữ liệu trong giao diện
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            string sql = "Select * from Stuff where Name='"+textBox1.Text+"'";

            // thực thi lệnh trong csdl
            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);
            

            con.Close();

            flowLayoutPanel1.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Button b = new Button() { Height = 100, Width = 100 };
                b.Text = dr[0].ToString() + dr[1].ToString();
                flowLayoutPanel1.Controls.Add(b);
            }
            if(flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Không tồn tại", "Lỗi");
            }
            
        }
    }
}
