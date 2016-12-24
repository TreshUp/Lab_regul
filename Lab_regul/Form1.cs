using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_regul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Data data = new Data();
        string max_string = "";
        System.Text.RegularExpressions.Match m;
        Dictionary<string, int> freq = new Dictionary<string,int>();
        private void Open_File(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                data.fileName = dlg.FileName;
                data.ReadFromFile();
                richTextBox1.Text = data.txt;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < data.result.Length; i++)
            {
                Find(data.result[i]);
                
                var sorted = freq.OrderByDescending(d => d.Value);

                var max = sorted.First();

                foreach (var p in sorted)
                {
                    //Console.Write(i);
                    //Console.Write(")");
                    Console.Write(p.Key);
                    Console.Write("----");
                    Console.WriteLine(p.Value);
                    if (p.Value < 0.8 * max.Value) break;
                }
                //string key = max.Key;
                Console.Write(max.Key);
                Console.Write(".....");
                Console.WriteLine(max.Value);
                Console.WriteLine("       ");
                max_string =max_string+i+")"+max.Key + "----" + max.Value + "\n";
                freq.Clear();
            }
            richTextBox2.Text = max_string;
        }
        private void Add(string r)
        {
            int n = 0;
            if (freq.ContainsKey(r))
            {
                n = freq[r];
                //freq.Remove(r);
                freq[r] = n + 1;
              //  freq.Add(r, n + 1);
            }
            else
            {
                freq.Add(m.ToString(), 1);
            }
        }
        private void Find(string result)
        {
            m = data.Find(result);
            Add(m.Value);
            
            while(true)
            {
                if (m != null && m.Success)
                {
                    m = m.NextMatch();
                    Add(m.Value);
                }
                else break;
                
            }
        }
    }
}
