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
            for (int i = 1; i < 2;/*i < data.result.Length;*/ i++)
            {
                Find(data.result[i]);
                //freq = freq.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                foreach (var p in freq)
                {
                    Console.Write(p.Key);
                    Console.Write("-");
                    Console.WriteLine(p.Value);
                }
                //var max = freq.Select(k => freq.Max());
                var first = freq.Select(k => freq.First());
                
            }
            
        }
        private void Add(string poisk)
        {
            int n = 0;
            //if (freq[m.ToString()] != 0 && !freq[m.ToString()])
            if (freq.ContainsKey(m.ToString()))
            {
                n = freq[m.ToString()];
                freq.Remove(m.ToString());
                freq.Add(m.ToString(), n + 1);
            }
            else
            {
                freq.Add(m.ToString(), 1);
            }
        }
        private void Find(string result)
        {
            m = data.Find(result);
            Add(m.ToString());
            //if (freq[m.ToString()] != 0)
            //{
            //    n = freq[m.ToString()];
            //    freq.Remove(m.ToString());
            //    freq.Add(m.ToString(), n + 1);
            //}
            //else
            //{
            //    freq.Add(m.ToString(), 1);
            //}
            //foreach (var p in freq)
            //{
            //    if (m.ToString() == p.Key) p.Value = p.Value + 1;
            //}
            //Console.Write(m);
            //Console.Write("-----");
            while(true)
            {
                if (m != null && m.Success)
                {
                    m = m.NextMatch();
                    Add(m.ToString());
                    //Console.Write(m);
                    //Console.Write("-----");
                    
                }
                else break;
                
            }
        }
    }
}
