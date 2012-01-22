using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpBits
{
    class DescriptionGenerator
    {

        XmlConfig xc;
        private List<string> links;

        Imdb imdb = null;
        Anidb anidb = null;
        Ffmpeg ffmpeg = null;
        MediaInfo mediainfo = null;
        String title = null;
        String shortTitle = null;
        String path = null;
        Section sec;

        public delegate void ErrorHandler(string error);
        ErrorHandler eh;
        public delegate void ProgressHandler(string progress);
        ProgressHandler ph;

        public enum Section
        {
            Anime, Movie, TV
        }

        public DescriptionGenerator(string userTitle, string filePath, Section s, XmlConfig config, ErrorHandler e, ProgressHandler p)
        {
            title = userTitle;
            shortTitle = userTitle;
            path = filePath;
            sec = s;
            xc = config;
            eh = e;
            ph = p;

            updateProgress("Preemptively collecting imdb info", 0, 1);

            imdb = new Imdb(title); //Preemptively do an imdb thingy because all the other things depend slightly on information from this
            if (imdb.foundPage())
            {
                title = imdb.Title.Length > 0 ? imdb.Title : title;
                shortTitle = imdb.ShortTitle.Length > 0 ? imdb.ShortTitle : title;
            }
            else
                eh("Could not find IMDb page");

            links = new List<string>();
        }

        public string GetTitleImage()
        {
            string img = imdb.GetImage();
            if(img.Length > 0)
                return Imgur.UploadImageUrl(img, xc.GetValue("imgurapikey"));
            return "";
        }

        public string ParseDescription(string desc)
        {
            int i = 0; string result = "";
            doParse(desc, ref i, ref result);
            return result;
        }

        public List<String> GetLinks()
        {
            return links;
        }

        public bool DescriptionIsValid(string desc)
        {

            return true;
        }

        private bool doParse(string desc, ref int i, ref string result)
        {
            bool changed = false;
            for (; i < desc.Length; )
            {
                updateProgress("Parsing description ...", i, desc.Length);
                if (desc[i] != '%')
                {
                    result += desc[i]; i++;
                }
                else if (desc[i + 1] == '%') // "%%" so % escaped added and skip over second %
                {
                    result += '%';
                    i += 2;
                }
                else
                {
                    string command = "";
                    for (i++; desc[i] != '%'; i++)
                        command += desc[i];
                    i++;
                    command = command.ToLower();
                    updateProgress("Parsing " + command, i, desc.Length);
                    if (command == "iff")
                    {
                        string tmpRes = "";
                        if (doParse(desc, ref i, ref tmpRes))
                        {
                            changed = true;
                            result += tmpRes;
                        }
                    }
                    else if (command == "ifanime")
                    {
                        string tmpRes = "";
                        if (sec == Section.Anime)
                        {
                            doParse(desc, ref i, ref tmpRes);
                            result += tmpRes;
                            changed = true;
                        }
                        else
                            doFakeParse(desc, ref i);
                    }
                    else if (command == "iftv")
                    {
                        string tmpRes = "";
                        if (sec == Section.TV)
                        {
                            doParse(desc, ref i, ref tmpRes);
                            result += tmpRes;
                            changed = true;
                        }
                        else
                            doFakeParse(desc, ref i);
                    }
                    else if (command == "ifmovie")
                    {
                        string tmpRes = "";
                        if (sec == Section.Movie)
                        {
                            doParse(desc, ref i, ref tmpRes);
                            result += tmpRes;
                            changed = true;
                        }
                        else
                            doFakeParse(desc, ref i);
                    }
                    else if (command == "else")
                    {
                        string tmpRes = "";
                        if (changed) //If added something, parse through the else and discard result.
                        {
                            doFakeParse(desc, ref i);
                        }
                        else
                        {
                            if(doParse(desc, ref i, ref tmpRes))
                                changed = true;
                            result += tmpRes; //Add it regardles... it's an %else% .. they can do their own %else%%iff%
                        }
                        return changed; //Uhh... maybe
                    }
                    else if (command == "endf")
                    {
                        return changed;
                    }
                    else
                    {
                        string tmpRes = "";
                        tmpRes = doSpecialParse(command);
                        if (tmpRes.Length > 0)
                        {
                            changed = true;
                            result += tmpRes;
                        }
                    }
                }
            }
            return changed;
        }

        private string doSpecialParse(string token)
        {
            string result = "";
            if (token.StartsWith("imdb"))
            {
                if (imdb.foundPage())
                {
                    result = imdb.GetAttribute(token.Substring(4));
                    if (result.Length == 0)
                        eh("Could not find IMDb attribute " + token.Substring(4));
                }
                if ((token == "imdburl" || token == "imdbtrailer") && result.Length > 0)
                    links.Add(result);
            }
            else if (token == "anidburl")
            {
                if (anidb == null)
                {
                    anidb = new Anidb(shortTitle);
                }
                if (anidb.foundPage())
                {
                    result = anidb.Url;
                }
                if (result.Length == 0)
                    eh("Could not find Anidb url");
                else
                    links.Add(anidb.Url);

            }
            else if (token == "wikiurl")
            {
                if (imdb != null && imdb.foundPage())
                {
                    if (Wiki.GetWiki(shortTitle + " " + ((sec == Section.Anime) ? "Anime" : (sec == Section.TV) ? "TV" : "Movie") + " " + imdb.GetAttribute("year"), eh))
                        result = Wiki.Url;
                }
                else if (Wiki.GetWiki(shortTitle + " " + ((sec == Section.Anime) ? "Anime" : (sec == Section.TV) ? "TV" : "Movie"), eh))
                    result = Wiki.Url;
                if (result.Length > 0)
                    links.Add(result);
                else
                    eh("Could not get wikipedia url");
            }
            else if (token == "youtubeurl" || token == "youtubetrailer")
            {
                if (Trailer.GetTrailer(shortTitle + " " + ((sec == Section.Anime) ? "Anime" : (sec == Section.TV) ? "TV" : "Movie")))
                    result = Trailer.Url;

                if (result.Length > 0)
                    links.Add(result);
                else
                    eh("Could not get youtube url");
            }
            else if (token == "mediainfo")
            {
                if (mediainfo == null)
                {
                    mediainfo = new MediaInfo(path, xc.GetValue("mediainfopath"));
                }
                if (mediainfo.MediaInfoFound())
                    result = mediainfo.GetMediaInfo();
                else
                    eh("Could not find MediaInfo (probably missing exe)");
            }
            else if (token.StartsWith("screenshot"))
            {
                if (ffmpeg == null)
                    ffmpeg = new Ffmpeg(path, xc.GetValue("ffmpegpath"), ref xc);
                if (ffmpeg.FfmpegFound())
                {
                    if (token == "screenshotall")
                    {
                        string[] screenshots;
                        int numShots;
                        if (int.TryParse(xc.GetValue("numscreenshots"), out numShots))
                        {
                            screenshots = ffmpeg.TakeScreenshots(ref xc);
                            for (int j = 0; j < screenshots.Length; j++)
                            {
                                if (xc.GetBoolValue("openscreens"))
                                    links.Add(screenshots[j]);
                                result += screenshots[j].Length == 0 ? "" : "\r\n[img=" + screenshots[j] + "]\r\n";
                            }
                        }
                        else
                            eh("Failed to parse number of screenshots");
                    }
                    else
                    {
                        int shotNum;
                        if (int.TryParse(token.Substring(11), out shotNum))
                        {
                            string screenshot = ffmpeg.TakeScreenshot(shotNum);
                            if(xc.GetBoolValue("openscreens"))
                                links.Add(screenshot);
                        }
                        else
                            eh("Screenshot token should take the form screenshotall or screenshot#");
                    }
                }
                else
                    eh("Could not find ffmpeg (probably missing exe");
            }
            return result;
        }

        /// <summary>
        /// This method is used for parsing through chunks which shouldn't produce real data. 
        /// Used for %else%s and %ifanime% (it's not an anime)
        /// </summary>
        /// <param name="desc">Description format string</param>
        /// <param name="i">Location in the description</param>
        private void doFakeParse(string desc, ref int i)
        {
            for (; i < desc.Length; )
            {
                updateProgress("Parsing description ...", i, desc.Length);
                if (desc[i] != '%')
                {
                    i++;
                }
                else if (desc[i + 1] == '%') // "%%" so % escaped added and skip over second %
                {
                    i += 2;
                }
                else
                {
                    string command = "";
                    for (i++; desc[i] != '%'; i++)
                        command += desc[i];
                    i++;
                    command = command.ToLower();
                    if (command == "iff")
                    {
                        doFakeParse(desc, ref i);
                    }
                    else if (command == "ifanime")
                    {
                        doFakeParse(desc, ref i);
                    }
                    else if (command == "iftv")
                    {
                        doFakeParse(desc, ref i);
                    }
                    else if (command == "ifmovie")
                    {
                        doFakeParse(desc, ref i);
                    }
                    else if (command == "else")
                    {
                        doFakeParse(desc, ref i);
                    }
                    else if (command == "endf")
                    {
                        return;
                    }
                }
            }
        }


        private void updateProgress(string s, int i, int total)
        {
            if (total == 0)
                total = 1; //Devision by zero? NOPE
            ph(s + Environment.NewLine + i * 100 / total + "%");
        }

    }
}
