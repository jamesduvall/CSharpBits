using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CsharpBits
{
    public partial class ConfigForm : Form
    {
        private XmlConfig xc;
        private Dictionary<string, string> vals;
        /*
         * Initializes the configuration form by reading the values from the config manager and setting them on the form
         */
        public ConfigForm(XmlConfig conf)
        {
            InitializeComponent();
            xc = conf;

            vals = new Dictionary<string,string>(xc.GetValueDic());

            cmbImageHost.Text = vals["imagehost"];

            txtFfmpeg.Text = vals["ffmpegpath"];
            txtMediainfo.Text = vals["mediainfopath"];
            txtImgur.Text = vals["imgurapikey"];
            txtImageShack.Text = vals["imageshackapikey"];
            int tmp = 0;
            int.TryParse(vals["numscreenshots"], out tmp);
            numScreenshots.Value = tmp;
            cbGuessTitle.Checked = vals["guesstitle"] == "true" ? true : false;
            cbNullProxy.Checked = vals["nullproxy"] == "true" ? true : false;
            cbImgLinks.Checked = vals["openscreens"] == "false" ? false : true;
            cbImdbImage.Checked = vals["imdbimage"] == "true" ? true : false;
            cmbImageHost.SelectedItem = (object)vals["imagehost"];
            txtDescFormat.Text = vals["descriptionformat"].Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }

        /*
         * Handle the return of either 'browse' button. If they hit okay fill the relevant text box
         */
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.Title == "Choose ffmpeg.exe please")
                txtFfmpeg.Text = openFileDialog1.FileName;
            else
                txtMediainfo.Text = openFileDialog1.FileName;
        }

        /*
         * Ffmpeg browse button clicked
         */
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Filter = "ffmpeg.exe|*.exe";
            openFileDialog1.Title = "Choose ffmpeg.exe please";
            openFileDialog1.ShowDialog();
        }

        /*
         * Mediainfo browse button clicked
         */
        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Filter = "mediainfo.exe|*.exe";
            openFileDialog1.Title = "Choose mediainfo.exe (CLI) please";
            openFileDialog1.ShowDialog();
        }

        /*
         * Open the imgur api website
         */
        private void button7_Click(object sender, EventArgs e)
        {
            try //Try because this fails on some firefoxes that have been installed but not run yet. 
            {
                System.Diagnostics.Process.Start("http://imgur.com/register/api_anon");
            }
            catch (Exception) { }

        }

        /*
         * Save button clicked. Store the values and save everything.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            xc.SetValueDic(vals);
            xc.SaveConfig();
            this.Close();
        }

        /*
         * Cancel button. Close without saving.
         */
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Could probably do something useful here. Whatever.
        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try //Try because this fails on some firefoxes that have been installed but not run yet. 
            {
                System.Diagnostics.Process.Start("http://stream.imageshack.us/api/");
            }
            catch (Exception) { }
        }

        private void txtDescFormat_TextChanged(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtImgur_TextChanged(object sender, EventArgs e)
        {
            vals["imgurapikey"] = txtImgur.Text;
        }

        private void txtImageShack_TextChanged(object sender, EventArgs e)
        {
            vals["imageshackapikey"] = txtImageShack.Text;
        }

        private void txtFfmpeg_TextChanged(object sender, EventArgs e)
        {
            vals["ffmpegpath"] = txtFfmpeg.Text;
        }

        private void txtMediainfo_TextChanged(object sender, EventArgs e)
        {
            vals["mediainfopath"] = txtMediainfo.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            vals["numscreenshots"] = ((int)numScreenshots.Value).ToString();
        }

        private void cmbImageHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            vals["imagehost"] = cmbImageHost.Text;
        }

        private void cbNullProxy_CheckedChanged(object sender, EventArgs e)
        {
            vals["nullproxy"] = cbNullProxy.Checked ? "true" : "false";
        }

        private void cbImgLinks_CheckedChanged(object sender, EventArgs e)
        {
            vals["openscreens"] = cbImgLinks.Checked ? "true" : "false";
        }

        private void cbGuessTitle_CheckedChanged(object sender, EventArgs e)
        {
            vals["guesstitle"] = cbGuessTitle.Checked ? "true" : "false";
        }

        private void txtDescFormat_TextChanged_1(object sender, EventArgs e)
        {
            vals["descriptionformat"] = txtDescFormat.Text;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbImdbImage_CheckedChanged(object sender, EventArgs e)
        {
            vals["imdbimage"] = cbImdbImage.Checked ? "true" : "false";
        }
    }
}
