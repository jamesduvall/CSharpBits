using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CsharpBits
{
    public partial class Form1 : Form
    {
        XmlConfig xc;
        private string description;
        private List<String> links;
        private string coverImage;
        DescriptionGenerator.ErrorHandler eh;
        DescriptionGenerator.ProgressHandler ph;
        public DebugWindow debug;

        int selectedIndex;

        public Form1()
        {
            InitializeComponent();
            AcceptButton = btnRun;
            selectedIndex = 0;
            cbSource.SelectedIndex = 0;

            xc = new XmlConfig(Application.StartupPath + "\\csharpbits.xml");

            if (!xc.GetBoolValue("imdbimage"))
            {
                txtImage.Hide();
                output.Height += 30;
                output.Location = new Point(output.Location.X, output.Location.Y - 30);
            }

            links = null;
            coverImage = null;
            debug = new DebugWindow();
            if (xc.GetBoolValue("showdebug"))
                debug.Show();
            eh += new DescriptionGenerator.ErrorHandler(debug.AddError);
            ph += new DescriptionGenerator.ProgressHandler(this.updateProgress);
            bgUpdate.DoWork += doUpdateCheck;
            bgUpdate.RunWorkerAsync();
        }

        private void doUpdateCheck(object sender, EventArgs e)
        {
            DialogResult dr;
            if (Updates.CheckForUpdates(xc))
            {
                dr = MessageBox.Show("There is a new version available. Would you like to be taken to the download page?", "", MessageBoxButtons.YesNo);
                while (dr == System.Windows.Forms.DialogResult.None) ;
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try //Try because this fails on some firefoxes that have been installed but not run yet. 
                    {
                        System.Diagnostics.Process.Start("https://code.google.com/p/csharpbits/downloads/list");
                    }
                    catch (Exception) { }
                }
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            btnBrowse.Enabled = false;
            btnCopyDescription.Enabled = false;
            btnConfigure.Enabled = false;
            btnRun.Enabled = false;
            output.Enabled = false;
            txtFilePath.Enabled = false;
            txtTitle.Enabled = false;
            output.Enabled = false;
            btnLinks.Enabled = false;
            btnCopyImage.Enabled = false;
            cbSource.Enabled = false;
            txtImage.Text = "";
            txtImage.Enabled = false;
            output.Text = "";
            output.TextAlign = HorizontalAlignment.Center;

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, EventArgs e)
        {

            btnBrowse.Enabled = true;
            btnCopyDescription.Enabled = true;
            btnConfigure.Enabled = true;
            btnRun.Enabled = true;
            output.Enabled = true;
            txtFilePath.Enabled = true;
            txtTitle.Enabled = true;
            btnLinks.Enabled = true;
            btnCopyImage.Enabled = true;
            cbSource.Enabled = true;
            txtImage.Enabled = true;

            output.TextAlign = HorizontalAlignment.Left;
            output.Enabled = true;
            description = description.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            output.Text = description;

            if(xc.GetBoolValue("imdbimage"))
            {
                txtImage.Text = coverImage;
                txtImage.ForeColor = Color.Black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // see if user is trying to "open with"
            string[] args = Environment.GetCommandLineArgs();
            try
            {
                string fn = args[1];
                openFileDialog1.FileName = fn;
                openFileDialog1_FileOk(this, null);
            }
            catch (IndexOutOfRangeException)
            {
                // no command line param, do display form as normally
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            if (xc.GetBoolValue("guesstitle"))
            {
                string fn = openFileDialog1.SafeFileName;
                string res = "";
                string[] matchers = new string[] 
                {
                    @"(.*)\.S(\d{2})E(\d{2})", 
                        // Derp.Dong.S01E03.720p.derp-HERP
                    @"(.*)\.\d{4}\.((720p|1080p)\.)?(DVDRip|BRRip|BDRip|BluRay|CAM|TS|TC|R5|DVDSCR)",
                        // Dinga.Ding.2009.720p.BRRip.XviD-LOLDONGS
                    @"(.*)\.(\d{4})", 
                        // Unga.Bunga.2010
                    @"(.*)\.(LIMITED|UNRATED|READNFO|INTERNAL|PROPER)", 
                        // sometimes the year is missing and one of these might be in its place
                };
                foreach (string onematch in matchers)
                {
                    Regex r = new Regex(onematch, RegexOptions.IgnoreCase);
                    Match m = r.Match(fn);
                    if (m.Success)
                    {
                        btnRun.Enabled = true;
                        res = m.Groups[1].Value;
                        break;
                    }
                }
                if (res == "")
                { // we've failed, try the directory name
                    string dirname = openFileDialog1.FileName.Replace('\\' + fn, "");
                    dirname = dirname.Substring(dirname.LastIndexOf('\\') + 1);
                    foreach (string onematch in matchers)
                    {
                        Regex r = new Regex(onematch, RegexOptions.IgnoreCase);
                        Match m = r.Match(dirname);
                        if (m.Success)
                        {
                            btnRun.Enabled = true;
                            res = m.Groups[1].Value;
                            break;
                        }
                    }
                }

                if (res == "")
                {   // FOILED, AGAIN!
                    // set label text to red
                    res = fn;
                    label2.ForeColor = System.Drawing.Color.OrangeRed;
                }

                txtTitle.Text = res.Replace('.', ' ');
            }

            if (File.Exists(txtFilePath.Text) && txtTitle.Text.Length > 0)
                btnRun.Enabled = true;
            else
                btnRun.Enabled = false;

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            // user is changing Movie / Series name
            // if label was red, turn it back
            // start with select all, but only if user tabs to control
            //label2.ForeColor = System.Drawing.SystemColors.ControlText;
            //Title.SelectAll();

            if (File.Exists(txtFilePath.Text) && txtTitle.Text.Length > 0)
                btnRun.Enabled = true;
            else
                btnRun.Enabled = false;

        }

        private void label2_ForeColorChanged(object sender, EventArgs e)
        {
            if (label2.ForeColor == System.Drawing.SystemColors.ControlText)
                btnRun.Enabled = true;
            else
                btnRun.Enabled = false;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // grab the first file that user drops and run the file dialog events on it
            string[] filesDropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            openFileDialog1.FileName = filesDropped[0];
            openFileDialog1_FileOk(this, null);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // drag & drop handling
            // if user is dropping a file, allow it
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // user picked a file -> set it in the "File name" input
            txtFilePath.Text = openFileDialog1.FileName;
        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtTitle_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.SystemColors.ControlText;
            txtTitle.SelectAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfigForm cf = new ConfigForm(xc);
            cf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(output.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void bgMakeDescription(object sender, DoWorkEventArgs e)
        {
            string desc = xc.GetValue("descriptionformat");
            description = "";
            DescriptionGenerator.Section s;
            switch (selectedIndex)
            {
                case 0:
                    s = DescriptionGenerator.Section.Movie;
                    break;
                case 1:
                    s = DescriptionGenerator.Section.TV;
                    break;
                case 2:
                    s = DescriptionGenerator.Section.Anime;
                    break;
                default:
                    s = DescriptionGenerator.Section.Movie;
                    break;
            }
                    
            DescriptionGenerator gen = new DescriptionGenerator(txtTitle.Text, txtFilePath.Text,s, xc, eh, ph);
            description = gen.ParseDescription(desc);
            links = gen.GetLinks();
            if (xc.GetBoolValue("imdbimage"))
            {
                coverImage = gen.GetTitleImage();
                if(xc.GetBoolValue("openscreens"))
                    links.Add(coverImage); 
            }
        }


        private void safeWrite(string s)
        {
            if (output.InvokeRequired) //lol, lazy mans thread safety.
            {
                this.Invoke(new Action<string>(safeWrite), new object[] { s });
                return;
            }
            output.Text = s;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCpTitle_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(output.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLinks_Click(object sender, EventArgs e)
        {
            if(links != null && links.Count > 0)
            foreach (string link in links)
            {
                try //Try because this fails on some firefoxes that have been installed but not run yet. 
                {
                    System.Diagnostics.Process.Start(link);
                }
                catch (Exception) { }
            }
        }

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = cbSource.SelectedIndex;
        }

        private void updateProgress(string p)
        {
            if (output.InvokeRequired) //lol, lazy mans thread safety.
            {
                this.Invoke(new Action<string>(updateProgress), new object[] { p });
                return;
            }
            output.Text = p;
        }

        private void btnCopyImage_Click(object sender, EventArgs e)
        {

            try
            {
                Clipboard.SetText(txtImage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
