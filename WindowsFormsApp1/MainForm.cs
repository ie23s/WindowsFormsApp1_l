using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private Items items;
        private Items not_filter;
        private string filename;
        public MainForm()
        {
            InitializeComponent();
            items = new Items();
            SelectRow();
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
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            items.Clear();
            dataGridView1.Rows.Clear();

            string[] readfile = File.ReadAllText(filename).Split('\n');
            for (int i = 0; i < readfile.Length; i++)
            {
                items.Add(readfile[i]);
            }
            print();
        }
        private void print()
        {
            //вивід у dataGridView
            dataGridView1.Rows.Clear();
            try
            {
                int i = 0;
                foreach (var val in items.movies)
                {
                    dataGridView1.Rows.Add((i + ";" + val).ToString().Split(';'));
                    i++;
                }
            }
            catch
            {

            }


        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ItemForm form = new ItemForm();
            form.ShowDialog();
            if (!form.isOK) return;
            items.Add(form.M);

            if (not_filter != null)
            {
                form.M.SetIndex(not_filter.movies.Count());
                not_filter.Add(form.M);
            }
            form.Close();
            print();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(filename))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = filename;
                Stream fileStream = sfd.OpenFile();
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    string res = "";
                    foreach(Movie val in items.movies) {
                        res += val.ToFileString() + '\n';
                    }
                    sw.Write(res);
                }
            } else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //запис у файл 2
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:";
            sfd.RestoreDirectory = true;
            sfd.FileName = "SaveAs.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    string res = "";
                    foreach (Movie val in items.movies)
                    {
                        res += val.ToFileString() + '\n';
                    }

                    sw.Write(res);
                }
                filename = sfd.FileName;
            }
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            filename = null;
            dataGridView1.Rows.Clear();

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.movies.Count == 0) return;

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            int index = Int32.Parse(Convert.ToString(selectedRow.Cells["index"].Value));

            ItemForm itemForm;

            itemForm = new ItemForm(items.movies[index]);

            itemForm.ShowDialog();
            if (!itemForm.isOK) return;
            items.movies[index] = itemForm.M;
            if(not_filter != null)
            {
                not_filter.movies[items.movies[index].Real_index] = itemForm.M;
            }
            itemForm.Close();

            print();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.movies.Count == 0) return;

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            int index = Int32.Parse(Convert.ToString(selectedRow.Cells["index"].Value));
            if (not_filter != null)
            {
                not_filter.Remove(items.movies[index].Real_index);
            }
            items.Remove(index);

            print();

        }

        public void SelectRow()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        private void Search_Click(object sender, EventArgs e)
        {
            List<Movie> new_list = new List<Movie>();
            if (not_filter == null)
            {
                not_filter = new Items();
                not_filter.movies = new_list;


                for (int i = 0; i < items.movies.Count(); i++)
                {
                    new_list.Add(items.movies[i].SetIndex(i));
                }
            } else
            {
                for(int i = 0; i < not_filter.movies.Count(); i++)
                {
                    new_list.Add(not_filter.movies[i].SetIndex(i));
                }

            }
            var updated_list = from movie in new_list
                               select movie;
            if(filter_type.SelectedIndex >= 0)
            {
                updated_list = from movie in updated_list
                               where movie.OwnType().Equals(filter_type.Text)
                            select movie;
            }
            int a;
            if (!String.IsNullOrEmpty(min_year.Text) && int.TryParse(min_year.Text,out a))
            {
                updated_list = from movie in updated_list
                               where movie.Year >= Int32.Parse(min_year.Text)
                               select movie;
            }
            if (!String.IsNullOrEmpty(max_year.Text) && int.TryParse(max_year.Text, out a))
            {
                updated_list = from movie in updated_list
                               where movie.Year <= Int32.Parse(max_year.Text)
                               select movie;
            }

            if (!String.IsNullOrEmpty(min_dur.Text) && int.TryParse(min_dur.Text, out a))
            {
                updated_list = from movie in updated_list
                               where movie.Durning >= Int32.Parse(min_dur.Text)
                               select movie;
            }
            if (!String.IsNullOrEmpty(max_dur.Text) && int.TryParse(max_dur.Text, out a))
            {
                updated_list = from movie in updated_list
                               where movie.Durning <= Int32.Parse(max_dur.Text)
                               select movie;
            }
            items.Clear();
            foreach (Movie m in updated_list)
            {
                items.Add(m);
                
            }
            print();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (not_filter == null) return;
            items = not_filter;
            filter_type.SelectedIndex = -1;
            max_year.Text = "";
            min_year.Text = "";
            max_dur.Text = "";
            min_dur.Text = "";
            print();
            not_filter = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //запис у файл 2
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:";
            sfd.RestoreDirectory = true;
            sfd.FileName = "SaveAs.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    string res = "";
                    foreach (Movie val in items.movies)
                    {
                        res += val.ToFileString() + '\n';
                    }

                    sw.Write(res);
                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Author().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            new Chart(items).ShowDialog();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Helping().ShowDialog();
        }
    }
}
