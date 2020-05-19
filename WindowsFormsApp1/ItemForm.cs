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
    public partial class ItemForm : Form
    {
        private Movie m;
        private bool edit = false;
        public bool isOK = false;

        internal Movie M { get => m; set => m = value; }

        public ItemForm()
        {
            InitializeComponent();
            m = null;
        }

        public ItemForm(Movie m)
        {
            InitializeComponent();
            this.edit = true;

            this.m = m;

            label1.Text = "Edit item";
            type.SelectedIndex = 0;
            name_textbox.Text = m.Name;
            duration_textbox.Text = m.Durning.ToString();
            year_textbox.Text = m.Year.ToString();
            genre_textbox.Text = m.Genre;
            if(m is Series)
            {
                addtion_label.Visible = true;
                addtion_textbox.Visible = true;
                addtion_label.Text = "Number of seasons";
                addtion_textbox.Text = ((Series)m).Seasons.ToString();
                type.SelectedIndex = 2;
            } else if(m is Cartoon)
            {
                type.SelectedIndex = 3;
                addtion_label.Visible = true;
                addtion_textbox.Visible = true;
                addtion_label.Text = "Age catrgory";
                addtion_textbox.Text = ((Cartoon)m).Age.ToString();
            }

            
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.type.SelectedIndex)
            {
                case 0:
                    addtion_label.Visible = false;
                    addtion_textbox.Visible = false;
                    break;
                case 1:
                    addtion_label.Visible = true;
                    addtion_textbox.Visible = true;
                    addtion_label.Text = "Age catrgory";
                    break;
                case 2:
                    addtion_label.Visible = true;
                    addtion_textbox.Visible = true;
                    addtion_label.Text = "Number of seasons";
                    break;

            }
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private bool check()
        {
            if(String.IsNullOrEmpty(name_textbox.Text) ||
                String.IsNullOrEmpty(duration_textbox.Text) ||
                String.IsNullOrEmpty(year_textbox.Text) ||
                String.IsNullOrEmpty(genre_textbox.Text) ||
                (type.SelectedIndex != 0 && String.IsNullOrEmpty(addtion_textbox.Text)))
            {
                MessageBox.Show("Fill in all the fields!", "Error!");
                return false;
            }

            try
            {
                if (duration_textbox.Text.Contains(':'))
                {
                    String[] var1 = duration_textbox.Text.Split(':');
                     int  i = Int32.Parse(var1[0]) * 60 + Int32.Parse(var1[1]);
                }
                else
                {
                    Int32.Parse(duration_textbox.Text);
                }
            } catch
            {

                MessageBox.Show("Duration is not valid!", "Error!");
                return false;
            }

            try
            {

                Int32.Parse(year_textbox.Text);
            }
            catch
            {

                MessageBox.Show("Year is not valid!", "Error!");
                return false;
            }

            try
            {
                if(type.SelectedIndex != 0)
                    Int32.Parse(year_textbox.Text);
            }
            catch
            {

                if (type.SelectedIndex == 1)
                    MessageBox.Show("Age is not valid!", "Error!");
                if (type.SelectedIndex != 2)
                    MessageBox.Show("Seasons is not valid!", "Error!");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!check()) return;
            int var2;
            if (duration_textbox.Text.Contains(':'))
            {
                String[] var1 = duration_textbox.Text.Split(':');
                 var2 = Int32.Parse(var1[0]) * 60 + Int32.Parse(var1[1]);
            } else
            {
                var2 = Int32.Parse(duration_textbox.Text);
            }
            if (type.SelectedIndex == 0)
            {
                m = new Movie(name_textbox.Text, var2, Int32.Parse(year_textbox.Text), genre_textbox.Text);
            } else if (type.SelectedIndex == 1) {
                m = new Cartoon(name_textbox.Text, var2, Int32.Parse(year_textbox.Text), genre_textbox.Text, Int32.Parse(addtion_textbox.Text));

            } else
            {
                m = new Series(name_textbox.Text, var2, Int32.Parse(year_textbox.Text), genre_textbox.Text, Int32.Parse(addtion_textbox.Text));

            }
            isOK = true;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
