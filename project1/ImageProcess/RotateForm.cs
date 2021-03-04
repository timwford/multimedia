using System;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class RotateForm : Form
    {
        public int value { get; set; }

        public RotateForm(string text)
        {
            InitializeComponent();
            rotateLabel.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                value = Int32.Parse(maskedTextBox1.Text);
                DialogResult = DialogResult.OK;
                Close();
            } catch (System.FormatException) {
                rotateLabel.Text = "Rotate Degrees (enter an integer please): ";
            }
        }

        private void RotateForm_Load(object sender, EventArgs e)
        {
        }
    }
}
