namespace Cardiovascular_Imaging
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
            this.components = new System.ComponentModel.Container();
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.uxTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxPictureBox.Location = new System.Drawing.Point(0, 0);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(500, 421);
            this.uxPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uxPictureBox.TabIndex = 0;
            this.uxPictureBox.TabStop = false;
            // 
            // uxTimer
            // 
            this.uxTimer.Interval = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 421);
            this.Controls.Add(this.uxPictureBox);
            this.Name = "MainForm";
            this.Text = "Cardiovascular-Imaging";
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.Timer uxTimer;
    }
}

