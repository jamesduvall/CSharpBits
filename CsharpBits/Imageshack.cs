using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;

namespace CsharpBits
{

    //Shamelessly stolen from http://www.codeemporium.com/2009/06/14/dot-net-c-sharp-wrapper-for-the-imageshack-xml-api/ . Didn't see a license so no issue I'm sure.
    //Modified to make it work with the new imageshack api and to make it simpler .. I don't need any complex junk like being able to up jpegs.

    /// <summary>
    /// Lets a user upload an Image to ImageShack with the option of having the image resized.
    /// </summary>
    public class ImageShack
    {
        /// <summary>
        /// Uploads an image to ImageShack.
        /// </summary>
        /// <param name="fileName">The fully qualified path of the file to be uploaded.</param>
        /// <returns>The details of the uploaded image.</returns>
        public static string UploadImage(string fileName, string apiKey)
        {
            string webPostAddress = "http://www.imageshack.us/upload_api.php";

            HttpWebResponse imageShackResponse;
            // send our picture off to ImageShack.
            try
            {
                imageShackResponse = SendRequestToImageShack(fileName, webPostAddress, apiKey);
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }

            Stream responseStream = imageShackResponse.GetResponseStream();
            string details;
            // extract the details about the image from the Xml data returned from ImageShack.
            try
            {
                details = GetImageUrl(responseStream);
                imageShackResponse.Close();
                responseStream.Close();
            }
            catch (XmlException e)
            {
                throw e;
            }

            return details;
        }

        private static HttpWebResponse SendRequestToImageShack(string fileName, string webPostAddress, string apiKey)
        {

            HttpWebRequest imageShackWebRequest = WebRequest.Create(webPostAddress) as HttpWebRequest;
            imageShackWebRequest.Method = "POST";
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            imageShackWebRequest.ContentType = @"multipart/form-data; boundary=" + boundary;

            FileInfo fileToUploadInfo = new FileInfo(fileName);
            if (!fileToUploadInfo.Exists)
            {
                throw new FileNotFoundException("The specified file doesn't seem to exist.", fileName);
            }

            string contentType = "image/png"; //Assume it'll be png

            // build up the post message header.
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("key");
            sb.Append("\r\n\r\n");
            sb.Append(apiKey);
            sb.Append("\r\n");
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("fileupload");
            sb.Append("\"; filename=\"");
            sb.Append(fileToUploadInfo.Name);
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contentType);
            sb.Append("\r\n");
            sb.Append("\r\n");

            string imagePostHeader = sb.ToString();
            byte[] imagePostHeaderBytes = Encoding.UTF8.GetBytes(imagePostHeader);

            // trailing boundary string as a byte array
            byte[] trailingBoundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            // get the file as a stream and using this information and previous length information
            // set the content length
            FileStream imageFileStream = new FileStream(fileToUploadInfo.FullName, FileMode.Open, FileAccess.Read);
            imageShackWebRequest.ContentLength = imagePostHeaderBytes.Length + imageFileStream.Length + trailingBoundaryBytes.Length;

            Stream httpRequestStream = imageShackWebRequest.GetRequestStream();

            // write out the post header
            httpRequestStream.Write(imagePostHeaderBytes, 0, imagePostHeaderBytes.Length);

            // write out the file contents
            byte[] imageFileBuffer = new Byte[checked((uint)Math.Min(4096, (int)imageFileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = imageFileStream.Read(imageFileBuffer, 0, imageFileBuffer.Length)) != 0)
            {
                httpRequestStream.Write(imageFileBuffer, 0, bytesRead);
            }
            imageFileStream.Flush();
            imageFileStream.Close();
            // write out the trailing boundary
            httpRequestStream.Write(trailingBoundaryBytes, 0, trailingBoundaryBytes.Length);

            httpRequestStream.Flush();
            httpRequestStream.Close();

            // get ImageShack's response and return it
            HttpWebResponse imageShackWebResponse = imageShackWebRequest.GetResponse() as HttpWebResponse;
            
            return imageShackWebResponse;
        }

        private static string GetImageUrl(Stream stream)
        {
            try
            {
                XmlReader rdr = XmlReader.Create(stream);
                while (rdr.Read())
                {
                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "image_link")
                        return rdr.ReadString();
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
            return "";
        }
    }
}
