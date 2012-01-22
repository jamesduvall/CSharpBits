using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace CsharpBits
{
    class Wiki
    {
        public static string Url;
        public static bool GetWiki(string titleWithReleaseDateAndSource, CsharpBits.DescriptionGenerator.ErrorHandler e)
        {
            
            string wikiHost = "http://en.wikipedia.org/wiki/";
            Url = "";
            string searchStr = "http://google.com/search?lr=lang_en&q=site:en.wikipedia.org+"
                + HttpUtility.UrlEncode(titleWithReleaseDateAndSource).Replace(' ', '+'); //This gives iffy results. Try and think of a better way to get wiki results?
             e("Using string " + searchStr + " to try and find wiki page" + Environment.NewLine);
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Opera/9.80 (fX11; Linux i686; U; en) Presto/2.2.15 Version/10.00";

            HtmlDocument googRes = new HtmlDocument();
            e("Loading page HTML");
            googRes.LoadHtml(wc.DownloadString(searchStr));
            e("Saving html to wikiout.html");
            googRes.Save("wikiout.html");
            foreach (HtmlNode n in googRes.DocumentNode.SelectNodes("//a[@href]")) //Get all links
            {
                
                if (n.Attributes["href"].Value.StartsWith(wikiHost)) //If the link is a wiki link then that's our answer
                {
                    Url = n.Attributes["href"].Value;
                    e("Found url of " + Url);
                    break;
                }
            }
            wc.Dispose();

            Url = HttpUtility.HtmlDecode(Url);
            Url = wikiHost + Url.Remove(0, wikiHost.Length).Replace("(", "%28").Replace(")", "%29");//HttpUtility.UrlEncode(Url.Remove(0, wikiHost.Length)).Replace("(", "%28").Replace(")", "%29"); //BBCode doesn't like some chars in links. Need to take care of others too perhaps...

            if (Url.Length > 0)
                return true;
            return false;
        }

    }
}
