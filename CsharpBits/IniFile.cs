using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CsharpBits
{
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern short WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern short GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string INIPath)
        { path = INIPath; }

        public void IniWriteValue(string Section, string Key, string Value)
        { WritePrivateProfileString(Section, Key, Value, this.path); }

        public string IniReadValue(string Section, string Key, string Default)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 1024, this.path);
            return (temp.Length > 0) ? temp.ToString() : Default;
        }
    }
}
