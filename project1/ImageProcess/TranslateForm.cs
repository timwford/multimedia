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
    public partial class TranslateForm : Form
    {

        public int xTran { get; set; }
        public int yTran { get; set; }

        public TranslateForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                xTran = Int32.Parse(xTranslate.Text);
                yTran = Int32.Parse(yTranslate.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.FormatException)
            {
                label1.Text = "Translate x (integer values)";
            }
        }
    }
}
