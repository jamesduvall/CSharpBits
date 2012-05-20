using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace CsharpBits
{
    class Anidb
    {
        string searchStr = "http://google.com/search?q=site:anidb.net+";
        public string Url;

        //HtmlDocument page;

        public Anidb(string movieTitle)
        {
            searchStr += HttpUtility.UrlEncode(movieTitle).Replace(' ', '+').Replace("&", "%26"); //The encode doesn't really help that much...
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00"; //Whee, taken from pythonbits which was used for ... inspiration

            HtmlDocument googRes = new HtmlDocument();

            try
            {
                googRes.LoadHtml(wc.DownloadString(searchStr));

                HtmlNodeCollection links = googRes.DocumentNode.SelectNodes("//a[@href]");

                Url = "";
                for (int i = 0; i < links.Count; i++)
                {

                    if (links[i].Attributes["href"].Value.StartsWith("http://anidb.net"))
                    {
                        Url = links[i].Attributes["href"].Value;
                        Url = HttpUtility.HtmlDecode(Url);
                        break;
                    }
                }
                if (Url.Length > 0)
                {
                //    page = new HtmlDocument();
                //    page.LoadHtml(wc.DownloadString(Url));
                }
                wc.Dispose();
            }
            catch (Exception)
            { Url = ""; } //Bluh, trouble with getting google or imdb page probably
        }

        public Anidb(string ImDbUrl, bool fromUrl)
        {
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00";

            Url = ImDbUrl;

            if (Url.Length > 0)
            {
                //page = new HtmlDocument();
                //page.LoadHtml(wc.DownloadString(Url));
            }
            wc.Dispose();
        }

        public bool foundPage()
        {
            return Url.Length > 0;   
        }

    }
}
