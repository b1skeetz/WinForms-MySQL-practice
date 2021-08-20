using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using database_123.Properties;

namespace database_123
{
    public partial class Form_Add : Form
    {
        Funclions func = new Funclions();
        Form1 form1 = new Form1();
        public Form_Add()
        {
            InitializeComponent();
        }

        private void Form_Add_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            func.data(guna2TextBox1, guna2TextBox2);
            this.Close();
        }
    }
}
