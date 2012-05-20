using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CsharpBits
{
    class MediaInfo
    {
        string file;
        string mediainfo;
        public string MediaInfoText;

        public string VideoCodec;
        public string AudioCodec;
        public string Resolution;
        public string SourceGuess;
        public string AudioLanguages;
        public bool Subtitled;
        public int Width;
        public int Height;
        public double AspectRatio;
        List<string> audios = new List<string>();
        List<string> subs = new List<string>();

        public MediaInfo(string videoFile, string mediaInfoPath)
        {
            file = videoFile;
            mediainfo = mediaInfoPath;
        }

        public bool MediaInfoFound()
        {
            if (File.Exists(mediainfo))
                return true;
            return false;
        }

        public string GetMediaInfo()
        {
            ProcessStartInfo psi = new ProcessStartInfo(mediainfo, "\"" + file + "\"");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            string output = "";
            StreamReader sr = null;

            try
            {
                Process p = Process.Start(psi);
                p.WaitForExit(120000);
                sr = p.StandardOutput;
                output = sr.ReadToEnd();
                p.Close();
            }
            catch (Exception) 
            {
                output = "";
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            string[] lines = output.Split('\n');
            output = "";
            string section = null;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Contains(":"))
                    section = lines[i].Trim();

                if (lines[i].StartsWith("Complete name"))
                    output += lines[i].Substring(0, lines[i].IndexOf(':') + 1) + " " + lines[i].Substring(lines[i].LastIndexOf('\\') + 1) + "\n"; // C:\User\Bob\Movie.avi = Movie.avi
                else if (!(lines[i].StartsWith("Unique ID")))
                    output += lines[i] + "\n";

                if (section.StartsWith("Video")) //Assumes either one vid stream or all streams are the same quality/format
                {
                    if (lines[i].Trim().StartsWith("Format"))
                    {
                        VideoCodec = lines[i].Trim().Substring(lines[i].IndexOf(":") + 1).Trim();
                        if (VideoCodec == "AVC")
                            VideoCodec = "x264";
                    }
                    else if (lines[i].Trim().StartsWith("Width"))
                    {
                        int.TryParse(lines[i].Trim().Substring(lines[i].IndexOf(":") + 1).Replace("pixels", "").Replace(" ", "").Trim(), out Width);
                    }
                    else if (lines[i].Trim().StartsWith("Height"))
                    {
                        int.TryParse(lines[i].Trim().Substring(lines[i].IndexOf(":") + 1).Replace("pixels", "").Replace(" ", "").Trim(), out Height);
                    }
                }
                else if (section.StartsWith("Audio")) //Audio #x
                {
                    if (section == "Audio") //Single audio stream
                    {

                    }
                }

            }

            MediaInfoText = output.Trim();

            parseTitleStuff();
            
            return MediaInfoText;
        }

        private void parseTitleStuff()
        {
        /*public string VideoCodec;
        public string AudioCodec;
        public string Resolution;
        public string SourceGuess;
        public string AudioLanguages;
        public bool Subtitled;*/


            //Format of mediainfo is Section\nItem\t: data
            string section = null;
            foreach(string line in MediaInfoText.Split('\n'))
            {
            
 

            }
        }
    }
}
