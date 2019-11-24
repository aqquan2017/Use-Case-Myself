using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace N9_ManageOrder
{
    partial class Form1
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=LAQUAN;Integrated Security=True");
        void connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "Select * from Product ";

            // thực thi lệnh trong csdl
            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            dataGridView1.ClearSelection();
            dataGridView1.DataSource = dt;
            //bảng hiển thị dữ liệu trong giao diện           
        }

        void filter()
        {           
            string sql = "Select * from Product where Code='" + comboBox1.Text + "'";

            // thực thi lệnh trong csdl
            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            dataGridView1.DataSource = dt;
            //bảng hiển thị dữ liệu trong giao diện  
        }

        void delete(int row)
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "DELETE FROM Product WHERE Name='"+dataGridView1.Rows[row].Cells["Name"].Value.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            

        }
    }
}
