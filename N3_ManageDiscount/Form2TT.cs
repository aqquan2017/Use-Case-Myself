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

namespace Thang_CNPM
{
    partial class Form2
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=LAQUAN;Integrated Security=True");

        void addProduct()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Bạn đã nhập thiếu thông tin !!", "Thông báo");
                return;
            }


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                //code thêm sản phẩm vào database
                string sqlAdd = "INSERT INTO Discount VALUES (@codeprogram, @name , @codeproduct , @start,@finish,@type,@state,@delete)";
                SqlCommand cmd = new SqlCommand(sqlAdd, con);

                cmd.Parameters.AddWithValue("codeprogram", textBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("codeproduct", textBox3.Text);
                cmd.Parameters.AddWithValue("start", textBox4.Text);
                cmd.Parameters.AddWithValue("finish", textBox5.Text);
                cmd.Parameters.AddWithValue("type", textBox6.Text);
                cmd.Parameters.AddWithValue("state", textBox7.Text);
                cmd.Parameters.AddWithValue("delete", false);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                //Đặt khóa chính là name nên nếu lưu trùng tên sẽ throw ra lỗi
                editProduct();
                MessageBox.Show("Sản phẩm sửa thành công (vì trùng tên) !", "Thông báo");
                return;
            }
            catch (Exception e)
            {
                //xử lý kiểu
                MessageBox.Show("Nhập sai kiểu !!!", "Thông báo");
                return;
            }
            MessageBox.Show("Sản phẩm thêm thành công !", "Thông báo");
            Form1.instance.connect();
            connect(textBox1.Text);
        }
        void editProduct()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sqlAdd = "UPDATE Discount SET codeprogram=@codeprogram,name=@name ,codeproduct=@codeproduct," +
                    "start=@start,finish=@finish,type=@type,state=@state where codeprogram=@codeprogram";
                SqlCommand cmd = new SqlCommand(sqlAdd, con);

                cmd.Parameters.AddWithValue("codeprogram", textBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("codeproduct", textBox3.Text);
                cmd.Parameters.AddWithValue("start", textBox4.Text);
                cmd.Parameters.AddWithValue("finish", textBox5.Text);
                cmd.Parameters.AddWithValue("type", textBox6.Text);
                cmd.Parameters.AddWithValue("state", textBox7.Text);
                //cmd.Parameters.AddWithValue("delete", false);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
                return;
            }
            Form1.instance.connect();
            connect(textBox1.Text);
        }
        public void connect(string s)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "Select * from Discount where codeprogram='" + s + "'";

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
    }
}
