using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace CsharpBits
{
    class Imagesbaconbits
    {
        public static string UploadImage(string fileName)
        {
            WebClient wc = new WebClient();
            byte[] result = wc.UploadFile("https://images.baconbits.org/upload.php?ImageUp=", fileName);
            return "";
        }
    }
}
