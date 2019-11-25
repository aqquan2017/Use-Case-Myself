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
    public partial class Form1 : Form
    {
        //Chức năng tìm kiếm sản phẩm
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin sản phẩm !", "Thông báo");
                return;
            }

            add();

            if (dataGridView2.RowCount == 1)
            {
                MessageBox.Show("Không có sản phẩm nào", "Thông báo");
            }
            else MessageBox.Show("Tìm thành công!!!", "Thông báo"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
         //   this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không", "Xác nhận xóa ?", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.Yes)
                {
                    delete(e.RowIndex);
                    connect();
                }
                else
                {
                    connect();
                }
            }
        }
    }
}
