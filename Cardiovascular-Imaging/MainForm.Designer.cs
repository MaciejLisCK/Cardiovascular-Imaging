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
            this.uxThresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uxFindDarkestAndPathFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxThresholdTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxPictureBox.Location = new System.Drawing.Point(3, 3);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(486, 389);
            this.uxPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uxPictureBox.TabIndex = 0;
            this.uxPictureBox.TabStop = false;
            // 
            // uxTimer
            // 
            this.uxTimer.Interval = 1;
            // 
            // uxThresholdTrackBar
            // 
            this.uxThresholdTrackBar.Location = new System.Drawing.Point(8, 6);
            this.uxThresholdTrackBar.Maximum = 1000;
            this.uxThresholdTrackBar.Name = "uxThresholdTrackBar";
            this.uxThresholdTrackBar.Size = new System.Drawing.Size(236, 45);
            this.uxThresholdTrackBar.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 421);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.uxFindDarkestAndPathFill);
            this.tabPage1.Controls.Add(this.uxThresholdTrackBar);
            this.tabPage1.Controls.Add(this.uxPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uxFindDarkestAndPathFill
            // 
            this.uxFindDarkestAndPathFill.Location = new System.Drawing.Point(250, 6);
            this.uxFindDarkestAndPathFill.Name = "uxFindDarkestAndPathFill";
            this.uxFindDarkestAndPathFill.Size = new System.Drawing.Size(75, 23);
            this.uxFindDarkestAndPathFill.TabIndex = 2;
            this.uxFindDarkestAndPathFill.Text = "Start/Stop";
            this.uxFindDarkestAndPathFill.UseVisualStyleBackColor = true;
            this.uxFindDarkestAndPathFill.Click += new System.EventHandler(this.uxFindDarkestAndPathFill_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 421);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Cardiovascular-Imaging";
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxThresholdTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.Timer uxTimer;
        private System.Windows.Forms.TrackBar uxThresholdTrackBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button uxFindDarkestAndPathFill;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

