/*

Mark off what items are complete (e.g. x, done, checkmark, etc), and put a P if partially complete. If 'P' include how to test what is working for partial credit below the checklist line.

Total available points:  100

___x___	25	Tutorial completed (if not, what was the last section completed)
___x___	10	My Favorite Color
___x___	5	Horizontal Gradient Image
___x___	5	Vertical Gradient Image
___x___	10	Diagonal Gradient Image
___x___	5	Horizontal Line
___x___	5	Vertical Wider Line
___x___	10	Diagonal Line
___x___	10	Monochrome Image Filter
___x___	15	Median Filter
______	Total (please add the points and include the total here)

 */




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class MainForm : Form
    {
        enum ModelType { None, Generate, Process}; //mode for menu enabling

        Image model;
        ImageEditor editor;


        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true; //stop flicker

            SetMenuOptionEnable(ModelType.None);
        }

        //main Paint function
        protected override void OnPaint(PaintEventArgs e)
        {
            if (model == null)
                return;

            model.OnPaint(e);
        }

        //redraw on resize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }


        //
        //forward mouse calls
        //

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (model == null)
                return;

            base.OnMouseDown(e);
            editor.MousePress(model, e.X, e.Y);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (model == null)
                return;

            base.OnMouseUp(e);
            editor.MouseRelease();
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (model == null)
                return;

            base.OnMouseMove(e);
            editor.MouseMove(model, e.X, e.Y);
            Invalidate();
        }


        //
        //forward menu calls-------------------------------------------------------------------------
        //
        private void newMenu_Click(object sender, EventArgs e)
        {
            editor = new ImageGenerate();
            model = new Image(menuStrip1.Height);
            ImageGenerate.FillBlack(model);
            SetMenuOptionEnable(ModelType.Generate);
            Invalidate();
        }

        private void drawMenu_Click(object sender, EventArgs e)
        {
            editor.SetMode(ImageEditor.MODE.Draw);

            drawMenu.Checked = editor.MouseMode == ImageEditor.MODE.Draw;
         
            Invalidate();
        }

        private void copyMenu_Click(object sender, EventArgs e)
        {
            model.Reset();

            Invalidate();
        }

        private void negativeMenu_Click(object sender, EventArgs e)
        {
            editor.SetMode(ImageEditor.MODE.None);
            ImageProcess.OnFilterNegative(model);
            drawMenu.Checked = editor.MouseMode == ImageEditor.MODE.Draw;

            Invalidate();
        }

        private void thresholdMenu_Click(object sender, EventArgs e)
        {
            editor.SetMode(ImageEditor.MODE.Threshold);
            drawMenu.Checked = editor.MouseMode == ImageEditor.MODE.Draw;
        }

        private void warpMenu_Click(object sender, EventArgs e)
        {
            editor.SetMode(ImageEditor.MODE.Warp);
            drawMenu.Checked = editor.MouseMode == ImageEditor.MODE.Draw;
        }

        private void warpBilinearMenu_Click(object sender, EventArgs e)
        {
            editor.SetMode(ImageEditor.MODE.WarpNearest);
            drawMenu.Checked = editor.MouseMode == ImageEditor.MODE.Draw;
        }

        private void fillWhiteMenu_Click(object sender, EventArgs e)
        {
            ImageGenerate.FillWhite(model);
        }

        private void openTestMenu_Click(object sender, EventArgs e)
        {
            model = new Image(menuStrip1.Height);
            model.OnOpenDocument(null);
            editor = new ImageProcess();
            SetMenuOptionEnable(ModelType.Process);
            Invalidate();
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                model = new Image(menuStrip1.Height);
                model.OnOpenDocument(openFileDialog1.FileName);
                editor = new ImageProcess();
                SetMenuOptionEnable(ModelType.Process);
                Invalidate();
            }
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            model.Close();
            model = null;
            SetMenuOptionEnable(ModelType.None);
            Invalidate();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                model.OnSaveDocument(saveFileDialog1.FileName, saveFileDialog1.FilterIndex);
            }
        }

        private void SetMenuOptionEnable(ModelType mode)
        {
            bool on = true;
            switch(mode)
            {
                case ModelType.None:
                    on = false;
                    fillWhiteMenu.Enabled = on;
                    copyMenu.Enabled = on;
                    negativeMenu.Enabled = on;
                    thresholdMenu.Enabled = on;
                    warpMenu.Enabled = on;
                    warpBilinearMenu.Enabled = on;
                    drawMenu.Enabled = on;
                    drawMenu.Checked = false;
                    break;
                case ModelType.Generate:
                    drawMenu.Enabled = true;

                    fillWhiteMenu.Enabled = on;
                    copyMenu.Enabled = !on;
                    negativeMenu.Enabled = !on;
                    thresholdMenu.Enabled = !on;
                    warpMenu.Enabled = !on;
                    warpBilinearMenu.Enabled = !on;
                    
                    break;
                case ModelType.Process:
                    drawMenu.Enabled = true;

                    on = !on;
                    fillWhiteMenu.Enabled = on;
                    copyMenu.Enabled = !on;
                    negativeMenu.Enabled = !on;
                    thresholdMenu.Enabled = !on;
                    warpMenu.Enabled = !on;
                    warpBilinearMenu.Enabled = !on;
                    break;
            }    
        }

        private void fillGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.FillGreen(model);
        }
        
        private void dimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.OnFilterDim(model);
        }

        private void tintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.OnFilterTint(model);
        }

        private void lowPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.OnFilterLowpass(model);
        }

        private void fillCornflowerBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.FillCornflowerBlue(model);
        }

        private void horizontalGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.FillHorizontalGradient(model);
        }

        private void verticalBlueGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.FillVerticalBlueGradient(model);
        }

        private void diagonalGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.FillDiagonalGradient(model);
        }

        private void horizontalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.HorizontalLine(model);
        }

        private void verticalLIneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.VerticalLine(model);
        }

        private void diagonalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.DiagonalLine(model);
        }

        private void monochromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Mono(model);
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Median(model);
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Sharpen(model);
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Prewitt(model);
        }
    }
}