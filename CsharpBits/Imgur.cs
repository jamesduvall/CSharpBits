using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using HtmlAgilityPack;

namespace CsharpBits
{
    class Imgur
    {
        public static string UploadImage(string path, string key)
        {
            byte[] imageData;
            try
            {
                FileStream fs = File.OpenRead(path);
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
                fs.Close();
                fs.Dispose();
                string upload = HttpUtility.UrlEncode("image", Encoding.UTF8) +
                    "=" + HttpUtility.UrlEncode(Convert.ToBase64String(imageData)) +
                    "&" + HttpUtility.UrlEncode("key", Encoding.UTF8) +
                    "=" + HttpUtility.UrlEncode(key, Encoding.UTF8);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://api.imgur.com/2/upload");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ServicePoint.Expect100Continue = false;

                StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
                streamWriter.Write(upload);
                streamWriter.Flush();
                streamWriter.Close();

                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
                
                string responseString = responseReader.ReadToEnd();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(responseString);
                return doc.DocumentNode.SelectSingleNode("//links/original").InnerText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string UploadImageUrl(string url, string key)
        {
            try
            {
                string upload = HttpUtility.UrlEncode("image", Encoding.UTF8) +
                    "=" + HttpUtility.UrlEncode(url) +
                    "&" + HttpUtility.UrlEncode("key", Encoding.UTF8) +
                    "=" + HttpUtility.UrlEncode(key, Encoding.UTF8);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://api.imgur.com/2/upload");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ServicePoint.Expect100Continue = false;

                StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
                streamWriter.Write(upload);
                streamWriter.Flush();
                streamWriter.Close();

                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);

                string responseString = responseReader.ReadToEnd();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(responseString);
                return doc.DocumentNode.SelectSingleNode("//links/original").InnerText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
