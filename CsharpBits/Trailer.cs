using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace CsharpBits
{
    class Trailer
    {

        public static string Url;
        public static bool GetTrailer(string titleWithStuff)
        {
            Url = "";
            string searchStr = "http://google.com/search?lr=lang_en&q=site:youtube.com+";
            searchStr += HttpUtility.UrlEncode(titleWithStuff) + "+trailer";

            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00";


            HtmlDocument googRes = new HtmlDocument();
            googRes.LoadHtml(wc.DownloadString(searchStr));
            wc.Dispose();

            foreach (HtmlNode n in googRes.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (n.Attributes["href"].Value.StartsWith("http://www.youtube.com/watch?v="))
                {
                    Url = n.Attributes["href"].Value.Trim();
                    break;
                }
            }

            if (Url.Length == 0)
                return false;
            return true;
        }
    }
}
