using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private Items items;
        public MainForm()
        {
            InitializeComponent();
            items = new Items();
            items.Add("M;Name;120;10;Genre");
            items.Add("C;Name;12;34;Genre;10");
            items.Add("S;Name;23142;222;Genre;10");
            print();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            restoran.Cler();
            dataGridView1.Rows.Clear();
            string[] readfile = File.ReadAllText(filename).Split('\n');
            for (int i = 0; i < readfile.Length; i++)
            {
                restoran.AddString(readfile[i]);
            }
            print();*/
        }
        private void print()
        {
            //вивід у dataGridView
            dataGridView1.Rows.Clear();
            try
            {

                foreach (var val in items.movies)
                    dataGridView1.Rows.Add(val.ToString().Split());
            }
            catch
            {

            }


        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ItemForm form = new ItemForm();
            form.ShowDialog();
            items.Add(form.M);
            form.Close();
            print();
        }
    }
}
