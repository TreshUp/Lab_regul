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
        internal string pattern;
        internal void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                txt = sr.ReadToEnd().Replace("\r\n", "\n");
            }
            
            //foreach (Match match in Regex.Matches(txt, @"([LMXIV]+)\n[^<]+?([LMXIV]+)\n", RegexOptions.IgnoreCase))
            //    Console.WriteLine(match);
            pattern = "[LMXIV]+\n";
            string[] result = Regex.Split(txt, pattern,
                                    RegexOptions.IgnoreCase);
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
