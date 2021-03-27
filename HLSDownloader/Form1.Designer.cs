namespace HLSDownloader
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.mediaUrlTextBox = new System.Windows.Forms.TextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.downloadPercent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.threadCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.resetButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.threadCountLabel = new System.Windows.Forms.Label();
            this.button_union = new System.Windows.Forms.Button();
            this.textBox_chunkName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // mediaUrlTextBox
            // 
            this.mediaUrlTextBox.Location = new System.Drawing.Point(143, 32);
            this.mediaUrlTextBox.Name = "mediaUrlTextBox";
            this.mediaUrlTextBox.Size = new System.Drawing.Size(555, 20);
            this.mediaUrlTextBox.TabIndex = 1;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(213, 265);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(143, 96);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(555, 23);
            this.progressBar.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.statusLabel.Location = new System.Drawing.Point(162, 148);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(31, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "IDLE";
            // 
            // downloadPercent
            // 
            this.downloadPercent.AutoSize = true;
            this.downloadPercent.Location = new System.Drawing.Point(704, 73);
            this.downloadPercent.Name = "downloadPercent";
            this.downloadPercent.Size = new System.Drawing.Size(0, 13);
            this.downloadPercent.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Eş zamanlı indirme sayısı";
            // 
            // threadCountNumericUpDown
            // 
            this.threadCountNumericUpDown.Location = new System.Drawing.Point(185, 176);
            this.threadCountNumericUpDown.Name = "threadCountNumericUpDown";
            this.threadCountNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.threadCountNumericUpDown.TabIndex = 10;
            this.threadCountNumericUpDown.UseWaitCursor = true;
            this.threadCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(333, 265);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Sıfırla";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Thread Sayısı";
            // 
            // threadCountLabel
            // 
            this.threadCountLabel.AutoSize = true;
            this.threadCountLabel.Location = new System.Drawing.Point(162, 215);
            this.threadCountLabel.Name = "threadCountLabel";
            this.threadCountLabel.Size = new System.Drawing.Size(13, 13);
            this.threadCountLabel.TabIndex = 13;
            this.threadCountLabel.Text = "1";
            // 
            // button_union
            // 
            this.button_union.Location = new System.Drawing.Point(476, 265);
            this.button_union.Name = "button_union";
            this.button_union.Size = new System.Drawing.Size(75, 23);
            this.button_union.TabIndex = 14;
            this.button_union.Text = "Union";
            this.button_union.UseVisualStyleBackColor = true;
            this.button_union.Click += new System.EventHandler(this.button_union_Click);
            // 
            // textBox_chunkName
            // 
            this.textBox_chunkName.Location = new System.Drawing.Point(143, 66);
            this.textBox_chunkName.Name = "textBox_chunkName";
            this.textBox_chunkName.Size = new System.Drawing.Size(555, 20);
            this.textBox_chunkName.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Chunk Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 322);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_chunkName);
            this.Controls.Add(this.button_union);
            this.Controls.Add(this.threadCountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.threadCountNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.downloadPercent);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.mediaUrlTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mediaUrlTextBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label downloadPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown threadCountNumericUpDown;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label threadCountLabel;
        private System.Windows.Forms.Button button_union;
        private System.Windows.Forms.TextBox textBox_chunkName;
        private System.Windows.Forms.Label label5;
    }
}

