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

        internal Movie M { get => m; set => m = value; }

        public ItemForm()
        {
            InitializeComponent();
            m = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(type.SelectedIndex == 0)
            {
                m = new Movie(name_textbox.Text, Int32.Parse(duration_textbox.Text), Int32.Parse(year_textbox.Text), genre_textbox.Text);
            } else if (type.SelectedIndex == 1) {
                m = new Cartoon(name_textbox.Text, Int32.Parse(duration_textbox.Text), Int32.Parse(year_textbox.Text), genre_textbox.Text, Int32.Parse(addtion_textbox.Text));

            } else
            {
                m = new Series(name_textbox.Text, Int32.Parse(duration_textbox.Text), Int32.Parse(year_textbox.Text), genre_textbox.Text, Int32.Parse(addtion_textbox.Text));

            }

            Close();
        }
    }
}
