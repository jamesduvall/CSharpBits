using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace CsharpBits
{
    class Updates
    {

        const double VERSION = .60;
        /// <summary>
        /// Checks for updates by downloading the VERSION file
        /// </summary>
        /// <param name="xc">Configuarion manager for settings</param>
        /// <returns>True if update found, false otherwise</returns>
        public static bool CheckForUpdates(XmlConfig xc)
        {
            WebClient wc = new WebClient();
            if(xc.GetBoolValue("NullProxy"))
                wc.Proxy = null;
            try
            {
                double cur = double.Parse(wc.DownloadString("http://csharpbits.googlecode.com/files/VERSION"));
                if (cur > VERSION)
                    return true;
            }
            catch (Exception)
            { }//throw e; }
            return false;
        }
    }
}
