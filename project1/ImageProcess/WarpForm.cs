using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class Form1 : Form
    {
        public double value { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                value = Double.Parse(scaleText.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.FormatException)
            {
                scaleText.Text = "Scale by a value (ex: 0.9):";
            }
        }
    }
}
