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
            this.uxFindDarkestAndPathFill = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uxClosingResultPictureBox = new System.Windows.Forms.PictureBox();
            this.uxExpandSimilarityAlgorithmPictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxThresholdTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxClosingResultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxExpandSimilarityAlgorithmPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxPictureBox.Location = new System.Drawing.Point(3, 3);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(643, 540);
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(657, 572);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.uxFindDarkestAndPathFill);
            this.tabPage1.Controls.Add(this.uxThresholdTrackBar);
            this.tabPage1.Controls.Add(this.uxPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(649, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // uxFindDarkestAndPathFill
            // 
            this.uxFindDarkestAndPathFill.Location = new System.Drawing.Point(266, 15);
            this.uxFindDarkestAndPathFill.Name = "uxFindDarkestAndPathFill";
            this.uxFindDarkestAndPathFill.Size = new System.Drawing.Size(75, 23);
            this.uxFindDarkestAndPathFill.TabIndex = 2;
            this.uxFindDarkestAndPathFill.Text = "Start/Stop";
            this.uxFindDarkestAndPathFill.UseVisualStyleBackColor = true;
            this.uxFindDarkestAndPathFill.Click += new System.EventHandler(this.uxFindDarkestAndPathFill_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uxExpandSimilarityAlgorithmPictureBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(649, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ExpandSimilarityAlgorithm Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uxClosingResultPictureBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(492, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Closing Result";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uxClosingResultPictureBox
            // 
            this.uxClosingResultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxClosingResultPictureBox.Location = new System.Drawing.Point(3, 3);
            this.uxClosingResultPictureBox.Name = "uxClosingResultPictureBox";
            this.uxClosingResultPictureBox.Size = new System.Drawing.Size(486, 389);
            this.uxClosingResultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uxClosingResultPictureBox.TabIndex = 2;
            this.uxClosingResultPictureBox.TabStop = false;
            // 
            // uxExpandSimilarityAlgorithmPictureBox
            // 
            this.uxExpandSimilarityAlgorithmPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxExpandSimilarityAlgorithmPictureBox.Location = new System.Drawing.Point(3, 3);
            this.uxExpandSimilarityAlgorithmPictureBox.Name = "uxExpandSimilarityAlgorithmPictureBox";
            this.uxExpandSimilarityAlgorithmPictureBox.Size = new System.Drawing.Size(643, 540);
            this.uxExpandSimilarityAlgorithmPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uxExpandSimilarityAlgorithmPictureBox.TabIndex = 2;
            this.uxExpandSimilarityAlgorithmPictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save Bitmaps";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(657, 572);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Cardiovascular-Imaging";
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxThresholdTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxClosingResultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxExpandSimilarityAlgorithmPictureBox)).EndInit();
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
        private System.Windows.Forms.PictureBox uxExpandSimilarityAlgorithmPictureBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox uxClosingResultPictureBox;
        private System.Windows.Forms.Button button1;
    }
}

