namespace CsharpBits
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDescFormat = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numScreenshots = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtImgur = new System.Windows.Forms.TextBox();
            this.txtImageShack = new System.Windows.Forms.TextBox();
            this.txtFfmpeg = new System.Windows.Forms.TextBox();
            this.txtMediainfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFfmpegBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbImageHost = new System.Windows.Forms.ComboBox();
            this.lblFfmpeg = new System.Windows.Forms.Label();
            this.cbNullProxy = new System.Windows.Forms.CheckBox();
            this.cbImgLinks = new System.Windows.Forms.CheckBox();
            this.lblMediaInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGuessTitle = new System.Windows.Forms.CheckBox();
            this.btnMediainfoBrowse = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cbImdbImage = new System.Windows.Forms.CheckBox();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenshots)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(452, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(533, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"Executable |*.exe|All Files|*.*\"";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtDescFormat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(599, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Description";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDescFormat
            // 
            this.txtDescFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescFormat.Location = new System.Drawing.Point(3, 3);
            this.txtDescFormat.Multiline = true;
            this.txtDescFormat.Name = "txtDescFormat";
            this.txtDescFormat.Size = new System.Drawing.Size(593, 260);
            this.txtDescFormat.TabIndex = 0;
            this.txtDescFormat.TextChanged += new System.EventHandler(this.txtDescFormat_TextChanged_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbImdbImage);
            this.tabPage1.Controls.Add(this.numScreenshots);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.txtImgur);
            this.tabPage1.Controls.Add(this.txtImageShack);
            this.tabPage1.Controls.Add(this.txtFfmpeg);
            this.tabPage1.Controls.Add(this.txtMediainfo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnFfmpegBrowse);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbImageHost);
            this.tabPage1.Controls.Add(this.lblFfmpeg);
            this.tabPage1.Controls.Add(this.cbNullProxy);
            this.tabPage1.Controls.Add(this.cbImgLinks);
            this.tabPage1.Controls.Add(this.lblMediaInfo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbGuessTitle);
            this.tabPage1.Controls.Add(this.btnMediainfoBrowse);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(599, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // numScreenshots
            // 
            this.numScreenshots.Location = new System.Drawing.Point(169, 113);
            this.numScreenshots.Name = "numScreenshots";
            this.numScreenshots.Size = new System.Drawing.Size(32, 20);
            this.numScreenshots.TabIndex = 4;
            this.numScreenshots.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "Number of Screenshots";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(493, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 46;
            this.button1.TabStop = false;
            this.button1.Text = "Get a New Key";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtImgur
            // 
            this.txtImgur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImgur.Location = new System.Drawing.Point(146, 9);
            this.txtImgur.Name = "txtImgur";
            this.txtImgur.Size = new System.Drawing.Size(341, 20);
            this.txtImgur.TabIndex = 1;
            this.txtImgur.TabStop = false;
            this.txtImgur.TextChanged += new System.EventHandler(this.txtImgur_TextChanged);
            // 
            // txtImageShack
            // 
            this.txtImageShack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageShack.Location = new System.Drawing.Point(146, 36);
            this.txtImageShack.Name = "txtImageShack";
            this.txtImageShack.Size = new System.Drawing.Size(341, 20);
            this.txtImageShack.TabIndex = 45;
            this.txtImageShack.TabStop = false;
            this.txtImageShack.TextChanged += new System.EventHandler(this.txtImageShack_TextChanged);
            // 
            // txtFfmpeg
            // 
            this.txtFfmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFfmpeg.Location = new System.Drawing.Point(146, 62);
            this.txtFfmpeg.Name = "txtFfmpeg";
            this.txtFfmpeg.Size = new System.Drawing.Size(341, 20);
            this.txtFfmpeg.TabIndex = 3;
            this.txtFfmpeg.TabStop = false;
            this.txtFfmpeg.TextChanged += new System.EventHandler(this.txtFfmpeg_TextChanged);
            // 
            // txtMediainfo
            // 
            this.txtMediainfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMediainfo.Location = new System.Drawing.Point(146, 90);
            this.txtMediainfo.Name = "txtMediainfo";
            this.txtMediainfo.Size = new System.Drawing.Size(341, 20);
            this.txtMediainfo.TabIndex = 123;
            this.txtMediainfo.TabStop = false;
            this.txtMediainfo.TextChanged += new System.EventHandler(this.txtMediainfo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Imageshack Api Key";
            // 
            // btnFfmpegBrowse
            // 
            this.btnFfmpegBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFfmpegBrowse.Location = new System.Drawing.Point(493, 63);
            this.btnFfmpegBrowse.Name = "btnFfmpegBrowse";
            this.btnFfmpegBrowse.Size = new System.Drawing.Size(97, 20);
            this.btnFfmpegBrowse.TabIndex = 2;
            this.btnFfmpegBrowse.Text = "Browse";
            this.btnFfmpegBrowse.UseVisualStyleBackColor = true;
            this.btnFfmpegBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Imgur Api Key";
            // 
            // cmbImageHost
            // 
            this.cmbImageHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageHost.Items.AddRange(new object[] {
            "Imageshack",
            "Minus",
            "Imgur"});
            this.cmbImageHost.Location = new System.Drawing.Point(92, 157);
            this.cmbImageHost.Name = "cmbImageHost";
            this.cmbImageHost.Size = new System.Drawing.Size(121, 21);
            this.cmbImageHost.TabIndex = 11;
            this.cmbImageHost.SelectedIndexChanged += new System.EventHandler(this.cmbImageHost_SelectedIndexChanged);
            // 
            // lblFfmpeg
            // 
            this.lblFfmpeg.AutoSize = true;
            this.lblFfmpeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFfmpeg.Location = new System.Drawing.Point(6, 65);
            this.lblFfmpeg.Name = "lblFfmpeg";
            this.lblFfmpeg.Size = new System.Drawing.Size(88, 15);
            this.lblFfmpeg.TabIndex = 22;
            this.lblFfmpeg.Text = "Ffmpeg Path";
            // 
            // cbNullProxy
            // 
            this.cbNullProxy.AutoSize = true;
            this.cbNullProxy.Checked = true;
            this.cbNullProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNullProxy.Location = new System.Drawing.Point(196, 138);
            this.cbNullProxy.Name = "cbNullProxy";
            this.cbNullProxy.Size = new System.Drawing.Size(95, 17);
            this.cbNullProxy.TabIndex = 9;
            this.cbNullProxy.Text = "Use null proxy.";
            this.cbNullProxy.UseVisualStyleBackColor = true;
            this.cbNullProxy.CheckedChanged += new System.EventHandler(this.cbNullProxy_CheckedChanged);
            // 
            // cbImgLinks
            // 
            this.cbImgLinks.AutoSize = true;
            this.cbImgLinks.Checked = true;
            this.cbImgLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImgLinks.Location = new System.Drawing.Point(297, 138);
            this.cbImgLinks.Name = "cbImgLinks";
            this.cbImgLinks.Size = new System.Drawing.Size(190, 17);
            this.cbImgLinks.TabIndex = 10;
            this.cbImgLinks.Text = "Open Links opens screenshots too";
            this.cbImgLinks.UseVisualStyleBackColor = true;
            this.cbImgLinks.CheckedChanged += new System.EventHandler(this.cbImgLinks_CheckedChanged);
            // 
            // lblMediaInfo
            // 
            this.lblMediaInfo.AutoSize = true;
            this.lblMediaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaInfo.Location = new System.Drawing.Point(6, 91);
            this.lblMediaInfo.Name = "lblMediaInfo";
            this.lblMediaInfo.Size = new System.Drawing.Size(129, 15);
            this.lblMediaInfo.TabIndex = 28;
            this.lblMediaInfo.Text = "MediaInfo CLI Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Image Host";
            // 
            // cbGuessTitle
            // 
            this.cbGuessTitle.AutoSize = true;
            this.cbGuessTitle.Location = new System.Drawing.Point(9, 138);
            this.cbGuessTitle.Name = "cbGuessTitle";
            this.cbGuessTitle.Size = new System.Drawing.Size(181, 17);
            this.cbGuessTitle.TabIndex = 8;
            this.cbGuessTitle.Text = "Automatically Guess Movie Titles";
            this.cbGuessTitle.UseVisualStyleBackColor = true;
            this.cbGuessTitle.CheckedChanged += new System.EventHandler(this.cbGuessTitle_CheckedChanged);
            // 
            // btnMediainfoBrowse
            // 
            this.btnMediainfoBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMediainfoBrowse.Location = new System.Drawing.Point(493, 89);
            this.btnMediainfoBrowse.Name = "btnMediainfoBrowse";
            this.btnMediainfoBrowse.Size = new System.Drawing.Size(97, 23);
            this.btnMediainfoBrowse.TabIndex = 3;
            this.btnMediainfoBrowse.Text = "Browse";
            this.btnMediainfoBrowse.UseVisualStyleBackColor = true;
            this.btnMediainfoBrowse.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(493, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 23);
            this.button7.TabIndex = 2;
            this.button7.TabStop = false;
            this.button7.Text = "Get a New Key";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 295);
            this.tabControl1.TabIndex = 1;
            // 
            // cbImdbImage
            // 
            this.cbImdbImage.AutoSize = true;
            this.cbImdbImage.Checked = true;
            this.cbImdbImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImdbImage.Location = new System.Drawing.Point(9, 184);
            this.cbImdbImage.Name = "cbImdbImage";
            this.cbImdbImage.Size = new System.Drawing.Size(110, 17);
            this.cbImdbImage.TabIndex = 124;
            this.cbImdbImage.Text = "Grab cover image";
            this.cbImdbImage.UseVisualStyleBackColor = true;
            this.cbImdbImage.CheckedChanged += new System.EventHandler(this.cbImdbImage_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 326);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 285);
            this.Name = "ConfigForm";
            this.Text = "CsharpBits Configuration";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenshots)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtDescFormat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numScreenshots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtImgur;
        private System.Windows.Forms.TextBox txtImageShack;
        private System.Windows.Forms.TextBox txtFfmpeg;
        private System.Windows.Forms.TextBox txtMediainfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFfmpegBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbImageHost;
        private System.Windows.Forms.Label lblFfmpeg;
        private System.Windows.Forms.CheckBox cbNullProxy;
        private System.Windows.Forms.CheckBox cbImgLinks;
        private System.Windows.Forms.Label lblMediaInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbGuessTitle;
        private System.Windows.Forms.Button btnMediainfoBrowse;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox cbImdbImage;

    }
}