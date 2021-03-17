using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightShotExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    static class PrintScreenDecoderCode
    {


        //10ng581
        //https://prnt.sc/10ng581
    }
    class PrintScreenNumber:IprintscreenInetWindow
    {
        private long BASENUMBER = 0;
        private const int Base = 36;
        private const string Chars = "1234567890abcdefghijklmnopqrstuvwxyz";
        private const string BaseURL = "https://prnt.sc/";
        private string URL = string.Empty;
        public string PageURL
        {
            get 
            {
                return URL; 
            }
            set 
            {
                URLDecode(URL);
                URL = value;
            }
        } 
        public PrintScreenNumber(string URL)
        {
            URLDecode(URL);
            Recalculate();
        }
        public string Base36OutputString()
        {
            return Encode(BASENUMBER);
        }
        private void URLDecode(string url)
        {
            BASENUMBER = Decode(url.Replace(BaseURL, string.Empty));
        }
        static public string Encode(long number)
        {
            List<char> database = new List<char>(Chars);
            List<char> value = new List<char>();
            long tmp = number;

            while (tmp != 0)
            {
                value.Add(database[Convert.ToInt32(tmp % 36)]);
                tmp /= 36;
            }

            value.Reverse();
            return new string(value.ToArray());
        }
        static public long Decode(string value)
        {
            List<char> database = new List<char>(Chars);
            List<char> tmp = new List<char>(value.ToUpper().TrimStart(new char[] { '0' }).ToCharArray());
            tmp.Reverse();

            long number = 0;
            int index = 0;
            foreach (char character in tmp)
            {
                number += database.IndexOf(character) * (long)Math.Pow(36, index);
                index++;
            }
            return number;
        }
        /// <summary>
        /// recalulates URL numbers
        /// </summary>
        private void Recalculate()
        {
            URL = BaseURL + Base36OutputString();
        }
        public string NextPage()
        {
            BASENUMBER++;
            Recalculate();
            return URL;
        }

        public string LastPage()
        {
            BASENUMBER--;
            Recalculate();
            return URL;
        }
    }
    interface IprintscreenInetWindow
    {
        string LastPage();
        string NextPage();
        string PageURL { get; set; }

    }
}
