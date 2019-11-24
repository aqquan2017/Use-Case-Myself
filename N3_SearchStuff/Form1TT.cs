using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace N3_SearchStuff
{
    partial class Form1
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=LAQUAN;Integrated Security=True");
        void connect()
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

        void search()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "Select * from Stuff where Name='" + textBox1.Text + "'";

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
        }
    }
}
