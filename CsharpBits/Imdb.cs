using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Security;
using HtmlAgilityPack;

namespace CsharpBits
{
    class Imdb
    {
        string searchStr = "http://google.com/search?lr=lang_en&q=site:imdb.com+";

        public string Url;
        public string Title;
        public string ShortTitle;
        public int Year;

        HtmlDocument page;

        public Imdb(string movieTitle)
        {
            searchStr += HttpUtility.UrlEncode(movieTitle).Replace(' ', '+').Replace("&", "%26"); //The encode doesn't really help that much...
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00";

            HtmlDocument googRes = new HtmlDocument();

            try
            {
                googRes.LoadHtml(wc.DownloadString(searchStr));

                HtmlNodeCollection links = googRes.DocumentNode.SelectNodes("//a[@href]");

                Url = "";
                for (int i = 0; i < links.Count; i++)
                {

                    if (links[i].Attributes["href"].Value.StartsWith("http://www.imdb.com/title/tt") && links[i].Attributes["href"].Value.EndsWith("/")) //Gimpy fix to avoid getting userComment pages and the like
                    {
                        Url = links[i].Attributes["href"].Value;
                        break;
                    }
                }
                if (Url.Length > 0)
                {
                    page = new HtmlDocument();
                    page.LoadHtml(wc.DownloadString(Url));
                }
                wc.Dispose();
            }
            catch (Exception)
            { Url = ""; } //Bluh, trouble with getting google or imdb page probably
            setTitle();
        }

        public Imdb(string ImDbUrl, bool fromUrl)
        {
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00";

            Url = ImDbUrl;

            if (Url.Length > 0)
            {
                page = new HtmlDocument();
                page.LoadHtml(wc.DownloadString(Url));
            }
            wc.Dispose();
            setTitle();
        }

        public bool foundPage()
        {
            return Url.Length > 0;   
        }

        private void setTitle()
        {
            ShortTitle = "";
            Title = "";
            Year = 0;
            string yearStr;
            try
            {
                HtmlNode n = page.DocumentNode.SelectSingleNode("//h1");
                try
                {
                    yearStr = n.SelectSingleNode("span").InnerText;
                }
                catch (Exception)
                {
                    yearStr = n.InnerText.Trim().Replace("\n", "");
                }
                yearStr = HttpUtility.HtmlDecode(yearStr);
                try
                {
                    n.RemoveChild(n.SelectSingleNode("span"));
                }
                catch (Exception) { }
                if (n.HasChildNodes)
                {
                    try
                    {
                        HtmlNode subTitle = n.RemoveChild(n.SelectSingleNode("span"));
                        ShortTitle = n.InnerText.Trim().Replace("\n", "");
                        Title = n.InnerText.Trim().Replace("\n", "") + " | " + subTitle.InnerText.Trim().Replace("\n", "");
                    }
                    catch (Exception)
                    {
                        Title = n.InnerText.Trim().Replace("\n", "");
                    }
                }
                else
                {
                    Title = n.InnerText.Trim().Replace("\n", "");
                    ShortTitle = Title;
                }
                Title = HttpUtility.HtmlDecode(Title);
                ShortTitle = HttpUtility.HtmlDecode(ShortTitle);

                yearStr = yearStr.Substring(yearStr.LastIndexOf('('));
                yearStr = yearStr.Substring(0, yearStr.LastIndexOf(')'));
                string tmpyear = "";
                for (int i = 0; i < yearStr.Length; i++) //Why? Because ongoing are ( xxxx-) ...
                {
                    if (char.IsDigit(yearStr[i]))
                        tmpyear += yearStr[i];
                    if (tmpyear.Length > 4) //Forgot for a second... Some are in the form xxxx-yyyy .. We'll just get the starting year.
                        break;
                }
                Year = int.Parse(tmpyear);
            }
            catch (Exception) { }
        }

        public string GetAttribute(string s)
        {
            s = s.ToLower();
            switch (s)
            {
                case "url":
                    return this.Url;
                case "description":
                    return this.GetStoryline();
                case "title":
                    return this.Title;
                case "year":
                    return this.Year + "";
                case "releasedate":
                    return this.GetReleaseDate();
                case "rating":
                    return this.GetRating();
                case "trailer":
                    return this.GetTrailer();
                case "image":
                    return this.GetImage();
            }

            string res = "";
            foreach (HtmlNode n in page.DocumentNode.SelectNodes("//div/h4"))
            {
                if (n.InnerText.Trim().ToLower().StartsWith(s))
                {
//                    n.ParentNode.RemoveChild(n.ParentNode.SelectSingleNode("span")); //More elegant way to get rid of see more?
                    res = n.ParentNode.InnerText.Trim();
                    break;
                }
            }

            res = res.Replace("&amp;", "").Replace("&raquo;", ""); //Dunno why, I just don't like those.
            res = HtmlEntity.DeEntitize(res).Trim();

            if (res.EndsWith("See more")) //SEE MORE nope.avi
                res = res.Substring(0, res.LastIndexOf("See more"));
            if (res.EndsWith("Full episode list"))
                res = res.Substring(0, res.LastIndexOf("Full episode list"));

            Match m = Regex.Match(res, "and \\d* more credits"); //Remove all "AND X MROE DERPS" links
            if (m.Success)
                res = res.Remove(m.Index);
            res = res.Replace("\n", "");
            res = res.Trim().Trim(new char[] { ',', '|' }); //Get rid of the trailing comma from removing the "AND x MORE DERPS" We don't like pipes either

            if(res.Contains(":") && !res.EndsWith(":")) //Make sure the next line is safe
                res = res.Substring(res.IndexOf(':') + 1).Trim(); // Make there be one space after the : dispite other stupid stuff

            return res;
        }



        public string GetStoryline()
        {

            try
            {
                HtmlNode story = page.DocumentNode.SelectSingleNode("//p[@itemprop='description']");
                string result = HtmlEntity.DeEntitize(story.InnerText).Replace("\n", "").Trim();
                if (result.Length > 0)
                    return result;
            }
            catch (Exception) { }
            return "";

            /*foreach (HtmlNode n in page.DocumentNode.SelectNodes("//div/h2"))
            {
                if (n.InnerText.Trim().StartsWith("Storyline"))
                {
                    try
                    {
                        HtmlNode story = n.ParentNode.SelectSingleNode("p");
                        story.RemoveChild(story.SelectSingleNode("em"));
                        return HtmlEntity.DeEntitize(story.InnerText.Replace("&nbsp;", " ")).Trim();
                    }
                    catch (Exception)
                    { }
                }
            }
            return "";*/
        }

        public string GetRating()
        {
            try
            {
                HtmlNode rating = page.DocumentNode.SelectSingleNode("//span[@itemprop='ratingValue']");
                string result = HtmlEntity.DeEntitize(rating.InnerText).Replace("\n", "").Trim();
                rating = page.DocumentNode.SelectSingleNode("//span[@itemprop='bestRating']");
                result += "/" + HtmlEntity.DeEntitize(rating.InnerText).Replace("\n", "").Trim();
                if (result.Length > 0 && !result.Contains("-")) //avoid -/10
                    return result;
            }
            catch (Exception) { }
            return "";
        }

        public string GetReleaseDate()
        {
            try
            {
                //Release date's usually have (COUNTRY) at the end. So treat that as a special case and get the crap rid of it.
                string rd = GetAttribute("Release Date").Trim();
                if (rd.EndsWith(")") && rd.Contains("(")) //Assume it has the country in this case.
                    rd = rd.Remove(rd.LastIndexOf('('));
                return rd;
            }
            catch (Exception) { }
            return "";
        }

        public string GetTrailer()
        {
            try
            {
                HtmlNode n = page.DocumentNode.SelectSingleNode("//a[@class='btn large primary title-trailer']");
                string s = n.Attributes["href"].Value; //href="/video/screenplay/vi3437035801/"
                if (s.Length > 0 && s.StartsWith("/video/")) //Meh, sorta iffy. Well, let's hope it keeps working
                    return "http://imdb.com" + s;
            }
            catch (Exception) { }
            return "";
        }

        public string GetImage()
        {
            try
            {
                HtmlNode n = page.DocumentNode.SelectSingleNode("//td[@id='img_primary']/a");
            //    n = n.Se("/a");
                String newPage = n.Attributes["href"].Value;
                WebClient wc = new WebClient();
                wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00";

                HtmlDocument newDoc = new HtmlDocument();
                newDoc.LoadHtml(wc.DownloadString("http://imdb.com" + newPage));

                HtmlNode imgNode = newDoc.DocumentNode.SelectSingleNode("//img[@id='primary-img']");
                return imgNode.Attributes["src"].Value;
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
