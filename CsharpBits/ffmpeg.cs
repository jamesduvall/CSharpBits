using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Windows.Forms;

namespace CsharpBits
{
    class Ffmpeg
    {
        private string file;
        private string ffmpeg;
        private string imageHost;
        private string tmpDir;
        private int duration;
        private int numShots;
        private XmlConfig conf;

        public Ffmpeg(string filename, string ffmpegPath, ref XmlConfig xc)
        {
            imageHost = null;
            tmpDir = null;
            duration = -1;
            numShots = -1;
            file = filename;
            ffmpeg = ffmpegPath;
            conf = xc;
        }

        public bool FfmpegFound()
        {
            if (File.Exists(ffmpeg))
                return true;
            return false;
        }

        public string TakeScreenshot(int shotnum)
        {
            setGlobals();

            string shot = "";

            if (File.Exists(tmpDir + "screen" + shotnum + ".png"))
            {
                try
                {
                    File.Delete(tmpDir + "screen" + shotnum + ".png");
                }
                catch (Exception) { }
            }

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = ffmpeg;
            p.StartInfo.Arguments = "-ss " + duration * shotnum / (numShots + 1) + " -vframes 1 -i \"" + file + "\" -y -sameq -f image2 \"" + tmpDir + "screen" + shotnum + ".png\"";
            p.Start();
            p.WaitForExit();
            p.Dispose();

            shot = tmpDir + "screen" + shotnum + ".png";
            string tmpImg = shot;
            try
            {
               shot = UploadImage(shot);
            }
            catch (Exception)
            {
                shot = "";
            }
            File.Delete(tmpImg);
            return shot;
        }

        public string[] TakeScreenshots(ref XmlConfig xc)
        {
            setGlobals();

            string[] shots = new string[numShots];

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = ffmpeg;
            
            for (int i = 1; i <= numShots; i++)
            {
                if (File.Exists(tmpDir + "screen" + i + ".png"))
                {
                    try
                    {
                        File.Delete(tmpDir + "screen" + i + ".png");
                    }
                    catch (Exception) { }
                }

                p.StartInfo.Arguments = "-ss " + duration * i / (numShots + 1) + " -vframes 1 -i \"" + file + "\" -y -sameq -f image2 \"" + tmpDir + "screen" + i + ".png\"";
                p.Start();
                p.WaitForExit();
                shots[i - 1] = tmpDir + "screen" + i + ".png";
            }

            string tmpImg;
            for (int i = 0; i < shots.Length; i++)
            {
                tmpImg = shots[i];
                try
                {
                    shots[i] = UploadImage(shots[i]);
                    
                }
                catch (Exception)
                {
                    shots[i] = "";
                }
                try
                {
                    File.Delete(tmpImg);
                }
                catch (Exception)
                {
                    //Darnit imageshack, why.
                }
            }
            p.Dispose();
            return shots;
        }

        private void setGlobals()
        {
            if (duration == -1)
                duration = getDuration();
            if (numShots == -1)
                numShots = conf.GetIntValue("numscreenshots");
            if (imageHost == null)
                imageHost = conf.GetValue("imagehost");
            if (tmpDir == null)
            {
                tmpDir = Path.GetTempPath() + "\\csharpbits\\";
                if (!Directory.Exists(tmpDir))
                    Directory.CreateDirectory(tmpDir);
            }
        }

        private string UploadImage(string path)
        {
            string ret;
            switch (imageHost.ToLower())
            {
                case "imgur":
                    ret = Imgur.UploadImage(path, conf.GetValue("imgurapikey"));
                    break;
                case "minus":
                    ret = Minus.UploadImage(path);
                    break;
                default:
                    ret = ImageShack.UploadImage(path, conf.GetValue("imageshackapikey"));
                    break;
            }
            return ret;
        }

        private int getDuration()
        {
            ProcessStartInfo psi = new ProcessStartInfo(ffmpeg, "-i \"" + file + "\"");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            string output = null;
            StreamReader sr = null;

            try
            {
                Process p = Process.Start(psi);
                p.WaitForExit(120000);
                sr = p.StandardError;
                output = sr.ReadToEnd();
                p.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            Regex re = new Regex("[D|d]uration:.((\\d|:|\\.)*)");
            Match m = re.Match(output);
            string[] hms;
            if (m.Success)
                hms = m.Groups[1].Value.Split(new char[]{ ':', '.'});
            else
                hms = new string[0];
            try
            {
                return int.Parse(hms[0]) * 3600 + int.Parse(hms[1]) * 60 + int.Parse(hms[2]);
            }
            catch(Exception)
            {
                throw new Exception("Ffmpeg could not find the duration of the given media file.");
            }
        }
    }
}
