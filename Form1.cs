using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_123
{
    public partial class Form1 : Form
    {
        Funclions func = new Funclions();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable data = func.data();
            guna2DataGridView1.DataSource = data;
            ListColumns.Items.Clear();
            guna2DataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            for(int i = 0; i < data.Columns.Count; i++)
            {
                ListColumns.Items.Add(data.Columns[i].ColumnName);
            }
            ListColumns.StartIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form_Add add = new Form_Add();
            add.FormClosed += new FormClosedEventHandler(refresh);
            add.ShowDialog();
        }
        public void refresh(object s, FormClosedEventArgs e)
        {
            guna2DataGridView1.DataSource = func.data();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable data = func.data(Search_tb, ListColumns);
            guna2DataGridView1.DataSource = data;
        }

        private void ListColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int rowindex = guna2DataGridView1.SelectedCells[0].RowIndex;
            string id = guna2DataGridView1[0, rowindex].Value.ToString();
            string param = guna2DataGridView1.Columns[0].Name;
            func.data(id, param);
            DataTable data = func.data();
            guna2DataGridView1.DataSource = data;

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DataTable data = func.data();
            guna2DataGridView1.DataSource = data;
        }
    }
}
