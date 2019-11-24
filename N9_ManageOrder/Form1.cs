using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N9_ManageOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            if (dataGridView1.RowCount == 1)
            {
                MessageBox.Show("Chưa có đơn hàng nào", "Thông báo");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
            if (dataGridView1.RowCount == 1)
            {
                MessageBox.Show("Chưa có đơn hàng nào", "Thông báo");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                delete(e.RowIndex);
                connect();
                resetCombobox();                
            }
        }
    }
}
