using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XAYABitcoinLib
{
    public class CookieReader
    {
        public string Username = string.Empty;
        public string Userpassword = string.Empty;

        public CookieReader()
        {
            string path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData) + "\\Xaya\\.cookie";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                char splitter = ':';
                Username = text.Split(splitter)[0];
                Userpassword = text.Split(splitter)[1];
            }
        }
    }
}
