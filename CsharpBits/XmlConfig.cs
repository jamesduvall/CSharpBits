using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace CsharpBits
{
    public class XmlConfig
    {
        XmlDocument doc;
        public string XmlPath;
        Dictionary<String, String> values;


        /// <summary>
        /// Initialize the Xml configuration. Will read in values and create the file if it doesn't exist
        /// </summary>
        /// <param name="path">Path to the xml configuration file</param>
        public XmlConfig(string path)
        {
            doc = new XmlDocument();
            setDefaults();
            XmlPath = path;
            if (!File.Exists(path))
                CreateDefaultConfig();
            else
            {
                doc.LoadXml(File.ReadAllText(path));
                initializeValues();
            }
        }

        /// <summary>
        /// Gets configuration value
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Value</returns>
        public string GetValue(string name)
        {
            name = name.ToLower();
            XmlNodeList res = doc.SelectNodes("/Config/" + name);
            if (res.Count != 0 && res[0].InnerText.Trim().Length > 0)
                return res[0].InnerText;
            else if (values.ContainsKey(name))
                return values[name];
            return "";
        }

        public Dictionary<string, string> GetValueDic()
        {
            return values;
        }

        public void SetValueDic(Dictionary<string, string> dic)
        {
            values = dic;
            foreach (string s in values.Keys)
                SetValue(s, values[s]);
        }

        /// <summary>
        /// Gets configuration value and attempts to parse to bool
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Value or false if couldn't parse</returns>
        public bool GetBoolValue(string name)
        {
            name = name.ToLower();
            bool ret = false;
            XmlNodeList res = doc.SelectNodes("/Config/" + name);
            if (res.Count != 0)
            {
                if (bool.TryParse(res[0].InnerText, out ret))
                    return ret;
            }
            if (values.ContainsKey(name))
            {
                if (bool.TryParse(values[name], out ret))
                    return ret;
            }
            return false;   
        }

        /// <summary>
        /// Gets configuration value and attempts to parse to int
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Value or 0 if couldn't parse</returns>
        public int GetIntValue(string name)
        {
            name = name.ToLower();
            int ret = 0;
            XmlNodeList res = doc.SelectNodes("/Config/" + name);
            if (res.Count != 0)
            {
                if (int.TryParse(res[0].InnerText, out ret))
                    return ret;
            }
            if (values.ContainsKey(name))
            {
                if (int.TryParse(values[name], out ret))
                    return ret;
            }
            return 0;   
        }

        /// <summary>
        /// Sets configuration value
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="val">Value</param>
        public void SetValue(string name, string val)
        {
            name = name.ToLower();
            XmlNodeList res = doc.SelectNodes("/Config/" + name);
            XmlNode conf = doc.SelectSingleNode("/Config");
            XmlNode tmp = doc.CreateElement(name);
            tmp.AppendChild(doc.CreateTextNode(val));
            if (res.Count != 0)
                conf.ReplaceChild(tmp, res[0]);
            else
                conf.AppendChild(tmp);
        }

        /// <summary>
        /// Saves the current configuration to file
        /// </summary>
        public void SaveConfig()
        {
            doc.Save(XmlPath);
        }

        /// <summary>
        /// Initializes the values to their defaults. Dunno why there's a whole method for this
        /// </summary>
        private void setDefaults()
        {
            values = new Dictionary<string, string>()
            {
                   { "ffmpegpath", getExePath("ffmpeg") },
                   { "imgurapikey", "7af00891be20ccdd604344479a9a1a54" },
                   { "imageshackapikey", "01DKMNOYc7e121aec80f7ed9cf91ee78f1782d24" },
                   { "imagehost" , "Imageshack" },
                   { "mediainfopath", getExePath("MediaInfo") },
                   { "numscreenshots", "2" },
                   { "guesstitle", "false" },
                   { "openscreens", "true" },
                   { "nullproxy", "true" },
                   { "showdebug", "false" },
                   { "imdbimage", "true" },
                   { "descriptionformat", "%iff%[color=#FF6633][b]Description:[/b][/color]\n" +
                                          "[quote]%imdbdescription%[/quote]\n%endf%" +
                                          "[color=#FF6633][b]Information:[/b][/color]\n" +
                                          "[quote]%iff%Title: %imdbtitle%\n%endf%" +
                                          "%iff%Rating: %imdbrating%\n%endf%" +
                                          "%iff%Director: %imdbdirector%\n%endf%" +
                                          "%iff%Release Date: %imdbreleasedate%\n%endf%" +
                                          "%iff%Genre: %imdbgenre%\n%endf%" +
                                          "%iff%Language: %imdblanguage%\n%endf%" +
                                          "%iff%Country: %imdbcountry%\n%endf%" +
                                          "[url=%imdburl%]IMDb[/url]\n" +                                         
                                          "%iff%[url=%wikiurl%]Wikipedia[/url]\n%endf%" +
                                          "%iff%[url=%iff%%imdbtrailer%%else%%youtubetrailer%%endf%]Trailer[/url]\n%endf%" +
                                          "%ifanime%%iff%[url=%anidburl%]AniDb[/url]\n%endf%%endf%" +
                                          "[/quote]\n" +
                                          "[color=#FF6633][b]Screenshots:[/b][/color]\n" +
                                          "[quote][align=center]%screenshotall%\n" +
                                          "[/align][/quote]\n" +
                                          "[mediainfo]%mediainfo%[/mediainfo]"}
            };

        }

        /// <summary>
        /// Create the xml configuration file with default values
        /// </summary>
        public void CreateDefaultConfig()
        {
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode conf = doc.CreateElement("Config");
            doc.AppendChild(conf);
            foreach (string s in values.Keys)
            {
                XmlNode tmp = doc.CreateElement(s);
                tmp.AppendChild(doc.CreateTextNode(values[s]));
                conf.AppendChild(tmp);
            }
            doc.Save(XmlPath);
        }

        /// <summary>
        /// Loads all values from the configuration file
        /// </summary>
        private void initializeValues()
        {
            XmlNode conf = doc.SelectSingleNode("/Config");
            if (!conf.HasChildNodes) return;
            foreach (XmlNode n in conf.ChildNodes)
            {
                if (n.InnerText.Trim().Length > 0) 
                values[n.Name] = n.InnerText;
            }
        }

        
        /// <summary>
        /// Searches for an executable in the program's directory and the system's path
        /// </summary>
        /// <param name="exe">The executable name (no extension. Ex: ffmpeg)</param>
        /// <returns>The full path to the executable if found. Empty string otherwise</returns>

        private string getExePath(string exe)
        {
            string exePath= "";
            string values = System.Windows.Forms.Application.StartupPath + ";" +
                Environment.GetEnvironmentVariable("PATH") +
                ";" + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles); //Check the path for those pythonbits people who have it in thier path
            values.Replace(";;", ";"); //Above mighta messed it up if the path was already oddly formed.
            foreach (string path in values.Split(';'))
            {
                string fullPath = Path.Combine(path, exe + ".exe");
                if (File.Exists(fullPath))
                {
                    exePath = fullPath;
                    break;
                }
            }
            if (exePath.Length > 0)
                return exePath;
            return "";
        }
    }
}
