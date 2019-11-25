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
    public partial class Form2 : Form
    {
        //Xử lý sự kiện nhân nút
        private void button1_Click(object sender, EventArgs e)
        {
            addProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.instance.Show();
            this.DestroyHandle();
        }

        
    }
}
