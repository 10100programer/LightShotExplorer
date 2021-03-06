using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightShotExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static PrintScreenNumber PrintScreenNumber;
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        bool firstclick = true;
        private void Next()
        {
            if (firstclick)
            {
                PrintScreenNumber = new PrintScreenNumber(textBox1.Text);
                textBox1.ReadOnly = true;
                firstclick = false;
            }

            PrintScreenNumber.NextPage();
            textBox1.Text = PrintScreenNumber.PageURL;
            webBrowser1.Url = new Uri(textBox1.Text);
        }
        private void Last()
        {
            if (firstclick)
            {
                PrintScreenNumber = new PrintScreenNumber(textBox1.Text);
                textBox1.ReadOnly = true;
                firstclick = false;
            }

            PrintScreenNumber.LastPage();
            textBox1.Text = PrintScreenNumber.PageURL;
            webBrowser1.Url = new Uri(textBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (firstclick)
            {
                PrintScreenNumber = new PrintScreenNumber(textBox1.Text);
                textBox1.ReadOnly = true;
                firstclick = false;
            }
            
            PrintScreenNumber.NextPage();
            textBox1.Text = PrintScreenNumber.PageURL;
            webBrowser1.Url = new Uri(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abx = new AboutBox1();
            abx.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            firstclick = true;
            textBox1.ReadOnly = false;
            textBox1.Text = string.Empty;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Last();
        }
    }
}
