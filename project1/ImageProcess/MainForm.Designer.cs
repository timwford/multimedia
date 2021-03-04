namespace ImageProcess
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillWhiteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fillGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillCornflowerBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalBlueGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.drawMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thresholdMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.warpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.warpBilinearMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalLIneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monochromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.project1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearWarpscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangelWarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compositionRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pointilismToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.mouseToolStripMenuItem,
            this.tasksToolStripMenuItem,
            this.project1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1467, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenu,
            this.openTestMenu,
            this.openMenu,
            this.closeMenu,
            this.saveMenu,
            this.exitMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMenu
            // 
            this.newMenu.Name = "newMenu";
            this.newMenu.Size = new System.Drawing.Size(224, 40);
            this.newMenu.Text = "New";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // openTestMenu
            // 
            this.openTestMenu.Name = "openTestMenu";
            this.openTestMenu.Size = new System.Drawing.Size(224, 40);
            this.openTestMenu.Text = "Open Test";
            this.openTestMenu.Click += new System.EventHandler(this.openTestMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(224, 40);
            this.openMenu.Text = "Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // closeMenu
            // 
            this.closeMenu.Name = "closeMenu";
            this.closeMenu.Size = new System.Drawing.Size(224, 40);
            this.closeMenu.Text = "Close";
            this.closeMenu.Click += new System.EventHandler(this.closeMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(224, 40);
            this.saveMenu.Text = "Save";
            this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(224, 40);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillWhiteMenu,
            this.fillGreenToolStripMenuItem,
            this.fillCornflowerBlueToolStripMenuItem,
            this.horizontalGradientToolStripMenuItem,
            this.verticalBlueGradientToolStripMenuItem,
            this.diagonalGradientToolStripMenuItem,
            this.toolStripSeparator2,
            this.drawMenu});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(115, 34);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // fillWhiteMenu
            // 
            this.fillWhiteMenu.Name = "fillWhiteMenu";
            this.fillWhiteMenu.Size = new System.Drawing.Size(330, 40);
            this.fillWhiteMenu.Text = "Fill White";
            this.fillWhiteMenu.Click += new System.EventHandler(this.fillWhiteMenu_Click);
            // 
            // fillGreenToolStripMenuItem
            // 
            this.fillGreenToolStripMenuItem.Name = "fillGreenToolStripMenuItem";
            this.fillGreenToolStripMenuItem.Size = new System.Drawing.Size(330, 40);
            this.fillGreenToolStripMenuItem.Text = "Fill Green";
            this.fillGreenToolStripMenuItem.Click += new System.EventHandler(this.fillGreenToolStripMenuItem_Click);
            // 
            // fillCornflowerBlueToolStripMenuItem
            // 
            this.fillCornflowerBlueToolStripMenuItem.Name = "fillCornflowerBlueToolStripMenuItem";
            this.fillCornflowerBlueToolStripMenuItem.Size = new System.Drawing.Size(330, 40);
            this.fillCornflowerBlueToolStripMenuItem.Text = "Fill Cornflower Blue";
            this.fillCornflowerBlueToolStripMenuItem.Click += new System.EventHandler(this.fillCornflowerBlueToolStripMenuItem_Click);
            // 
            // horizontalGradientToolStripMenuItem
            // 
            this.horizontalGradientToolStripMenuItem.Name = "horizontalGradientToolStripMenuItem";
            this.horizontalGradientToolStripMenuItem.Size = new System.Drawing.Size(330, 40);
            this.horizontalGradientToolStripMenuItem.Text = "Horizontal Gradient";
            this.horizontalGradientToolStripMenuItem.Click += new System.EventHandler(this.horizontalGradientToolStripMenuItem_Click);
            // 
            // verticalBlueGradientToolStripMenuItem
            // 
            this.verticalBlueGradientToolStripMenuItem.Name = "verticalBlueGradientToolStripMenuItem";
            this.verticalBlueGradientToolStripMenuItem.Size = new System.Drawing.Size(330, 40);
            this.verticalBlueGradientToolStripMenuItem.Text = "Vertical Blue Gradient";
            this.verticalBlueGradientToolStripMenuItem.Click += new System.EventHandler(this.verticalBlueGradientToolStripMenuItem_Click);
            // 
            // diagonalGradientToolStripMenuItem
            // 
            this.diagonalGradientToolStripMenuItem.Name = "diagonalGradientToolStripMenuItem";
            this.diagonalGradientToolStripMenuItem.Size = new System.Drawing.Size(330, 40);
            this.diagonalGradientToolStripMenuItem.Text = "Diagonal Gradient";
            this.diagonalGradientToolStripMenuItem.Click += new System.EventHandler(this.diagonalGradientToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(327, 6);
            // 
            // drawMenu
            // 
            this.drawMenu.Name = "drawMenu";
            this.drawMenu.Size = new System.Drawing.Size(330, 40);
            this.drawMenu.Text = "Draw";
            this.drawMenu.Click += new System.EventHandler(this.drawMenu_Click);
            // 
            // mouseToolStripMenuItem
            // 
            this.mouseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenu,
            this.negativeMenu,
            this.dimToolStripMenuItem,
            this.tintToolStripMenuItem,
            this.lowPassToolStripMenuItem,
            this.toolStripSeparator1,
            this.thresholdMenu,
            this.warpMenu,
            this.warpBilinearMenu});
            this.mouseToolStripMenuItem.Name = "mouseToolStripMenuItem";
            this.mouseToolStripMenuItem.Size = new System.Drawing.Size(101, 34);
            this.mouseToolStripMenuItem.Text = "Process";
            // 
            // copyMenu
            // 
            this.copyMenu.Name = "copyMenu";
            this.copyMenu.Size = new System.Drawing.Size(258, 40);
            this.copyMenu.Text = "Copy";
            this.copyMenu.Click += new System.EventHandler(this.copyMenu_Click);
            // 
            // negativeMenu
            // 
            this.negativeMenu.Name = "negativeMenu";
            this.negativeMenu.Size = new System.Drawing.Size(258, 40);
            this.negativeMenu.Text = "Negative";
            this.negativeMenu.Click += new System.EventHandler(this.negativeMenu_Click);
            // 
            // dimToolStripMenuItem
            // 
            this.dimToolStripMenuItem.Name = "dimToolStripMenuItem";
            this.dimToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.dimToolStripMenuItem.Text = "Dim";
            this.dimToolStripMenuItem.Click += new System.EventHandler(this.dimToolStripMenuItem_Click);
            // 
            // tintToolStripMenuItem
            // 
            this.tintToolStripMenuItem.Name = "tintToolStripMenuItem";
            this.tintToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.tintToolStripMenuItem.Text = "Tint";
            this.tintToolStripMenuItem.Click += new System.EventHandler(this.tintToolStripMenuItem_Click);
            // 
            // lowPassToolStripMenuItem
            // 
            this.lowPassToolStripMenuItem.Name = "lowPassToolStripMenuItem";
            this.lowPassToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.lowPassToolStripMenuItem.Text = "Low Pass";
            this.lowPassToolStripMenuItem.Click += new System.EventHandler(this.lowPassToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // thresholdMenu
            // 
            this.thresholdMenu.Name = "thresholdMenu";
            this.thresholdMenu.Size = new System.Drawing.Size(258, 40);
            this.thresholdMenu.Text = "Threshold";
            this.thresholdMenu.Click += new System.EventHandler(this.thresholdMenu_Click);
            // 
            // warpMenu
            // 
            this.warpMenu.Name = "warpMenu";
            this.warpMenu.Size = new System.Drawing.Size(258, 40);
            this.warpMenu.Text = "Warp Nearest";
            this.warpMenu.Click += new System.EventHandler(this.warpMenu_Click);
            // 
            // warpBilinearMenu
            // 
            this.warpBilinearMenu.Name = "warpBilinearMenu";
            this.warpBilinearMenu.Size = new System.Drawing.Size(258, 40);
            this.warpBilinearMenu.Text = "Warp Bilinear";
            this.warpBilinearMenu.Click += new System.EventHandler(this.warpBilinearMenu_Click);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalLineToolStripMenuItem,
            this.verticalLIneToolStripMenuItem,
            this.diagonalLineToolStripMenuItem,
            this.monochromeToolStripMenuItem,
            this.medianToolStripMenuItem});
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(79, 34);
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // horizontalLineToolStripMenuItem
            // 
            this.horizontalLineToolStripMenuItem.Name = "horizontalLineToolStripMenuItem";
            this.horizontalLineToolStripMenuItem.Size = new System.Drawing.Size(271, 40);
            this.horizontalLineToolStripMenuItem.Text = "Horizontal Line";
            this.horizontalLineToolStripMenuItem.Click += new System.EventHandler(this.horizontalLineToolStripMenuItem_Click);
            // 
            // verticalLIneToolStripMenuItem
            // 
            this.verticalLIneToolStripMenuItem.Name = "verticalLIneToolStripMenuItem";
            this.verticalLIneToolStripMenuItem.Size = new System.Drawing.Size(271, 40);
            this.verticalLIneToolStripMenuItem.Text = "Vertical LIne";
            this.verticalLIneToolStripMenuItem.Click += new System.EventHandler(this.verticalLIneToolStripMenuItem_Click);
            // 
            // diagonalLineToolStripMenuItem
            // 
            this.diagonalLineToolStripMenuItem.Name = "diagonalLineToolStripMenuItem";
            this.diagonalLineToolStripMenuItem.Size = new System.Drawing.Size(271, 40);
            this.diagonalLineToolStripMenuItem.Text = "Diagonal Line";
            this.diagonalLineToolStripMenuItem.Click += new System.EventHandler(this.diagonalLineToolStripMenuItem_Click);
            // 
            // monochromeToolStripMenuItem
            // 
            this.monochromeToolStripMenuItem.Name = "monochromeToolStripMenuItem";
            this.monochromeToolStripMenuItem.Size = new System.Drawing.Size(271, 40);
            this.monochromeToolStripMenuItem.Text = "Monochrome";
            this.monochromeToolStripMenuItem.Click += new System.EventHandler(this.monochromeToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(271, 40);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // project1ToolStripMenuItem
            // 
            this.project1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharpenToolStripMenuItem,
            this.prewittToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.flipHorizontalToolStripMenuItem,
            this.translateToolStripMenuItem,
            this.blueScreenToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.redFilterToolStripMenuItem,
            this.linearWarpscaleToolStripMenuItem,
            this.triangelWarpToolStripMenuItem,
            this.compositionRedToolStripMenuItem,
            this.pointilismToolStripMenuItem});
            this.project1ToolStripMenuItem.Name = "project1ToolStripMenuItem";
            this.project1ToolStripMenuItem.Size = new System.Drawing.Size(112, 34);
            this.project1ToolStripMenuItem.Text = "Project 1";
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.prewittToolStripMenuItem.Text = "Prewitt";
            this.prewittToolStripMenuItem.Click += new System.EventHandler(this.prewittToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // flipHorizontalToolStripMenuItem
            // 
            this.flipHorizontalToolStripMenuItem.Name = "flipHorizontalToolStripMenuItem";
            this.flipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.flipHorizontalToolStripMenuItem.Text = "Flip Horizontal";
            this.flipHorizontalToolStripMenuItem.Click += new System.EventHandler(this.flipHorizontalToolStripMenuItem_Click);
            // 
            // translateToolStripMenuItem
            // 
            this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            this.translateToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.translateToolStripMenuItem.Text = "Translate";
            this.translateToolStripMenuItem.Click += new System.EventHandler(this.translateToolStripMenuItem_Click);
            // 
            // blueScreenToolStripMenuItem
            // 
            this.blueScreenToolStripMenuItem.Name = "blueScreenToolStripMenuItem";
            this.blueScreenToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.blueScreenToolStripMenuItem.Text = "Blue Screen";
            this.blueScreenToolStripMenuItem.Click += new System.EventHandler(this.blueScreenToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // redFilterToolStripMenuItem
            // 
            this.redFilterToolStripMenuItem.Name = "redFilterToolStripMenuItem";
            this.redFilterToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.redFilterToolStripMenuItem.Text = "Red Filter";
            this.redFilterToolStripMenuItem.Click += new System.EventHandler(this.redFilterToolStripMenuItem_Click);
            // 
            // linearWarpscaleToolStripMenuItem
            // 
            this.linearWarpscaleToolStripMenuItem.Name = "linearWarpscaleToolStripMenuItem";
            this.linearWarpscaleToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.linearWarpscaleToolStripMenuItem.Text = "Linear warp (scale)";
            this.linearWarpscaleToolStripMenuItem.Click += new System.EventHandler(this.linearWarpscaleToolStripMenuItem_Click);
            // 
            // triangelWarpToolStripMenuItem
            // 
            this.triangelWarpToolStripMenuItem.Name = "triangelWarpToolStripMenuItem";
            this.triangelWarpToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.triangelWarpToolStripMenuItem.Text = "Triangel Warp";
            this.triangelWarpToolStripMenuItem.Click += new System.EventHandler(this.triangelWarpToolStripMenuItem_Click);
            // 
            // compositionRedToolStripMenuItem
            // 
            this.compositionRedToolStripMenuItem.Name = "compositionRedToolStripMenuItem";
            this.compositionRedToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.compositionRedToolStripMenuItem.Text = "Composition (Red)";
            this.compositionRedToolStripMenuItem.Click += new System.EventHandler(this.compositionRedToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|BMP File" +
    "s (*.bmp)| *p.bmp|All files (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|BMP File" +
    "s (*.bmp)| *.bmp";
            // 
            // pointilismToolStripMenuItem
            // 
            this.pointilismToolStripMenuItem.Name = "pointilismToolStripMenuItem";
            this.pointilismToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.pointilismToolStripMenuItem.Text = "Pointilism";
            this.pointilismToolStripMenuItem.Click += new System.EventHandler(this.pointilismToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Project 1: Ford Timothy";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem closeMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenu;
        private System.Windows.Forms.ToolStripMenuItem fillWhiteMenu;
        private System.Windows.Forms.ToolStripMenuItem openTestMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem negativeMenu;
        private System.Windows.Forms.ToolStripMenuItem thresholdMenu;
        private System.Windows.Forms.ToolStripMenuItem warpMenu;
        private System.Windows.Forms.ToolStripMenuItem drawMenu;
        private System.Windows.Forms.ToolStripMenuItem warpBilinearMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fillGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillCornflowerBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalBlueGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalLIneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monochromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem project1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearWarpscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangelWarpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compositionRedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointilismToolStripMenuItem;
    }
}

