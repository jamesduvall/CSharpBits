namespace CsharpBits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.output = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnCopyDescription = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bgUpdate = new System.ComponentModel.BackgroundWorker();
            this.btnLinks = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(12, 190);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(588, 214);
            this.output.TabIndex = 15;
            this.output.Text = " ";
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(212, 105);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(191, 50);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Generate Description";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.Run_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(155, 70);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(314, 20);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Movie / Series name";
            this.label2.ForeColorChanged += new System.EventHandler(this.label2_ForeColorChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "File name";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(525, 31);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(155, 33);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(364, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfigure.Location = new System.Drawing.Point(109, 132);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(97, 23);
            this.btnConfigure.TabIndex = 30;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCopyDescription
            // 
            this.btnCopyDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCopyDescription.Location = new System.Drawing.Point(409, 132);
            this.btnCopyDescription.Name = "btnCopyDescription";
            this.btnCopyDescription.Size = new System.Drawing.Size(98, 23);
            this.btnCopyDescription.TabIndex = 20;
            this.btnCopyDescription.Text = "Copy Description";
            this.btnCopyDescription.UseVisualStyleBackColor = true;
            this.btnCopyDescription.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(522, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(86, 13);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "v.5b - By Eskimo";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMakeDescription);
            // 
            // btnLinks
            // 
            this.btnLinks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLinks.Location = new System.Drawing.Point(109, 105);
            this.btnLinks.Name = "btnLinks";
            this.btnLinks.Size = new System.Drawing.Size(97, 23);
            this.btnLinks.TabIndex = 10;
            this.btnLinks.Text = "Open Links";
            this.btnLinks.UseVisualStyleBackColor = true;
            this.btnLinks.Click += new System.EventHandler(this.btnLinks_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Section:";
            // 
            // cbSource
            // 
            this.cbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Items.AddRange(new object[] {
            "Movie",
            "TV",
            "Anime"});
            this.cbSource.Location = new System.Drawing.Point(525, 69);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(75, 21);
            this.cbSource.TabIndex = 4;
            this.cbSource.SelectedIndexChanged += new System.EventHandler(this.cbSource_SelectedIndexChanged);
            // 
            // txtImage
            // 
            this.txtImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImage.ForeColor = System.Drawing.Color.LightGray;
            this.txtImage.Location = new System.Drawing.Point(155, 164);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(314, 20);
            this.txtImage.TabIndex = 14;
            this.txtImage.Text = "Title Image";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCopyImage.Location = new System.Drawing.Point(409, 105);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(98, 23);
            this.btnCopyImage.TabIndex = 32;
            this.btnCopyImage.Text = "Copy Image";
            this.btnCopyImage.UseVisualStyleBackColor = true;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnRun;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 416);
            this.Controls.Add(this.btnCopyImage);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.cbSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLinks);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnCopyDescription);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.output);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "Form1";
            this.Text = "CsharpBits";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Button btnCopyDescription;
        private System.Windows.Forms.Label lblVersion;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker bgUpdate;
        private System.Windows.Forms.Button btnLinks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnCopyImage;

    }
}

