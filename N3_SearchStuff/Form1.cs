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
        
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Không tồn tại", "Lỗi");
            }
            
        }
    }
}
