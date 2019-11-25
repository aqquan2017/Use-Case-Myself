using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Thang_CNPM
{
    partial class Form1
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=LAQUAN;Integrated Security=True");

        //kết nối csdl
        public void connect()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "Select * from Discount ";

            // thực thi lệnh trong csdl
            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            dataGridView2.DataSource = dt;
            //bảng hiển thị dữ liệu trong giao diện
        }

        void add()
        {
            string sql = "Select * from Discount where codeprogram='" + textBox1.Text + "' ";

            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);

            DataTable dt = new DataTable();

            da.Fill(dt);

            //    con.Close();

            dataGridView2.ClearSelection();
            dataGridView2.DataSource = dt;
        }
        void delete(int row)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "DELETE FROM Discount WHERE codeprogram='" + dataGridView2.Rows[row].Cells["codeprogram"].Value.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }
}
