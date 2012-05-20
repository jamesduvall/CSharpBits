using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace CsharpBits
{
    class Minus
    {

        private static Dictionary<string, string> galleryInfo = null;

        public static string UploadImage(string file)
        {
            string retUrl;
            if (galleryInfo == null)
            {
                try
                {
                    HttpWebRequest galleryCreate = (HttpWebRequest)WebRequest.Create("http://minus.com/api/CreateGallery");
                    WebResponse galleryResponse = galleryCreate.GetResponse();

                    galleryInfo = parseResponse((new StreamReader(galleryResponse.GetResponseStream()).ReadToEnd()));
                }
                catch (Exception ex)
                { throw ex; }
            }
            try
            {
                WebClient wc = new WebClient();
                string upUrl = "http://minus.com/api/UploadItem?editor_id=" + galleryInfo["editor_id"] + "&filename=" + file.Substring(file.LastIndexOf('\\') + 1);
                byte[] response = wc.UploadFile(upUrl, "POST", file);

                retUrl = "http://minus.com/i" + parseResponse(Encoding.ASCII.GetString(response))["id"] + ".png";
            }
            catch (Exception ex)
            { throw ex; }

            return retUrl;
        }

        public static string[] Upload(string[] files)
        {
            string[] urls = new string[files.Length];

            //Create the gallery
            
            try
            {
                if (galleryInfo == null)
                {
                    HttpWebRequest galleryCreate = (HttpWebRequest)WebRequest.Create("http://minus.com/api/CreateGallery");
                    WebResponse galleryResponse = galleryCreate.GetResponse();
                    galleryInfo = parseResponse((new StreamReader(galleryResponse.GetResponseStream()).ReadToEnd()));
                }

                WebClient wc = new WebClient();

                for (int i = 0; i < files.Length; i++)
                {
                    string url = "http://minus.com/api/UploadItem?editor_id=" + galleryInfo["editor_id"] +/* "&key=" + galleryInfo["editor_id_ext"] +*/ "&filename=screenshot" + i + ".png";
                    byte[] response = wc.UploadFile(url, "POST", files[i]);
                    urls[i] = "http://minus.com/i" + parseResponse(Encoding.ASCII.GetString(response))["id"] + ".png";
                }
                wc.Dispose();
                return urls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Dictionary<string, string> parseResponse(string response)
        {
            //Minus returns data in the form {"Data":"value", "data2":"value2"} . This puts it in a dictionary for easy use.
            try //Because proper error handling is for wimps.
            {
                string[] items = response.Trim(new char[] { '{', ' ', '\n', '}' }).Split(',');

                Dictionary<string, string> result = new Dictionary<string, string>();
                for (int i = 0; i < items.Length; i++)
                {
                    result.Add(items[i].Split(':')[0].Trim(new char[] { ' ', '"' }), items[i].Split(':')[1].Trim(new char[] { ' ', '"' })); //Add "Data, value".
                }
                return result;
            }
            catch (Exception)
            {
                return new Dictionary<string, string>();
            }
        }
    }
}
