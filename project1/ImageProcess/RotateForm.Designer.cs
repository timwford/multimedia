
namespace ImageProcess
{
    partial class RotateForm
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.rotateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(12, 53);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(376, 29);
            this.maskedTextBox1.TabIndex = 0;
            // 
            // rotateLabel
            // 
            this.rotateLabel.AutoSize = true;
            this.rotateLabel.Location = new System.Drawing.Point(13, 13);
            this.rotateLabel.Name = "rotateLabel";
            this.rotateLabel.Size = new System.Drawing.Size(167, 25);
            this.rotateLabel.TabIndex = 1;
            this.rotateLabel.Text = "Degrees to rotate:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rotate!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RotateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 154);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.rotateLabel);
            this.Name = "RotateForm";
            this.Text = "Rotate";
            this.Load += new System.EventHandler(this.RotateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label rotateLabel;
        private System.Windows.Forms.Button button1;
    }
}