using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palabras
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 101;
            progressBar1.Value = progressBar1.Value + 1;

            label1.Text = progressBar1.Value + "%";
            if (progressBar1.Value == 101)
                {
                timer1.Enabled = false ;



            Form1 form2 = new Form1();
                this.Hide();
                form2.Show();

            }
        }
    }
}
