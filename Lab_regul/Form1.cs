﻿using System;
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
        private void Open_File(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                //Stopwatch sw = new Stopwatch(); sw.Start(); // using System.Diagnostics
                data.fileName = dlg.FileName;
                data.ReadFromFile();
                richTextBox1.Text = data.txt;
                data.ReadFromFile();
                //sw.Stop();
                //Console.WriteLine("{0}ms reading file", sw.ElapsedMilliseconds);

            }

        }
    }
}