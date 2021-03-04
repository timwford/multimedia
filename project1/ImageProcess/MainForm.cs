/*

Mark off what items are complete, and put a P if partially complete. For the categories, name the filter and its points. If you crete more than one per category, list their names and their poitns below the required command for that catagory.

Total available points:  200 (250 for CSC 692)

 _x_ 8pt make a new\open\save image under a File Menu and add Project 1 menu
 _x_ 2pt display the current state of the image 
 _x_ 10pt A 3X3 sharpen filter 
 _x_ 15pt A 5X5 Prewit filter 
 _x_ 10pt A rotate about the center (uses a dialog box to set the amount) 
 _x_ 15pt A flip horizontally and translate (x and y) afterwards (uses a dialog box to set the amount) 
 _x_ 20pt A blue screen composition. You may use a default image for the mask. 
 
_Pointilize__       [30pt] Required Blur\Sharpen\Contrast\Filter

_Sobel_______       [10pt] Required Feature Extraction
_Red Channel filter [10pt] Other Feature Extraction

_Scale_______       [20pt] Required Linear warp

_Triangle____       [30pt] Required Non-linear warp ** THIS ONE HAS BUGS (see below) ** 

_Red Screen__       [20pt] Required Composition

Total: 220ish

Bugs:
- The only bug I know of is that my Triangle warp doesn't quite work and I didn't have a chance to fix it, I think it's close

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

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateForm rotateDialog = new RotateForm("Rotate by degrees (integer):");
            rotateDialog.ShowDialog();

            ImageGenerate.rotateImage(model, rotateDialog.value);
        }

        private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.flipHorizontally(model);
        }

        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranslateForm dialog = new TranslateForm();
            dialog.ShowDialog();

            ImageGenerate.Translate(model, dialog.xTran, dialog.yTran);
        }

        private void blueScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.BlueScreen(model);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Sobel(model);
        }

        private void redFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.RedChannelFilter(model);
        }

        private void linearWarpscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 dialog = new Form1();
            dialog.ShowDialog();

            ImageGenerate.Scale(model, dialog.value);
        }

        private void triangelWarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Triangle(model);
        }

        private void compositionRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.ComposeRed(model);
        }

        private void pointilismToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageGenerate.Point(model);
        }
    }
}