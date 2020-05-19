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
    public partial class Chart : Form
    {
        private Items items;
        
        public Chart(Items items)
        {
            InitializeComponent();
            this.items = items;
        }

        private void Chart_Load(object sender, EventArgs e)
        {

            foreach (var edition in items.movies)
            {
                this.chart1.Series["Year"].Points.AddXY(edition.Name, edition.Year);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
