using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab_regul
{
    class Data 
    {
        internal string txt = ""; // текст для обработки
        internal string fileName; // имя открытого файла  
        static internal string pattern="[LMXIV]+\n";    
        internal string[] result;
        internal void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                txt = sr.ReadToEnd().Replace("\r\n", "\n");
            }
            pattern = "[LMXIV]+\n";
            result = Regex.Split(txt, pattern, RegexOptions.IgnoreCase);
            //for (int i = 1; i < result.Length; i++)
            //{
            //    Console.WriteLine(result[i]);
            //}
        }
        //internal void SplitText(string[] text_result)
        //{
        //    text_result = Regex.Split(txt, pattern, RegexOptions.IgnoreCase);
        //}
        internal Match Find(string result)
        {
            //Regex r = new Regex(@"(\b)(\w)(\w)(\w)(\w)\b");
            Regex r = new Regex(@"(\b)(\w){4}\b");
            //Regex r = new Regex(@"(\b[a-z]{4}\b)*(\b[A-Z]{3}\b)");
            return r.Match(result);
        }
    }
}
