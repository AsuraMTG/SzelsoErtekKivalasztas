using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace holera
{
    public partial class Form1 : Form
    {
        public void Csere(int[] hol, int p1, int p2)
        {
            int s = hol[p1];
            hol[p1] = hol[p2];
            hol[p2] = s;
        }
        public int MaxKiNo(int[] hol, int e, int v)
        {
            int poz = 0;
            int aktMax = 0;
            for (int i = e; i < v; i++)
            {
                if (hol[i] > aktMax)
                {
                    aktMax = t[i];
                    poz = i;
                }
            }
            return poz; 
        }
        public int MaxKiCs(int[] hol, int e, int v)
        {
            int poz = 0;
            int aktMax = hol[0];
            for (int i = e; i < v; i++)
            {
                if (hol[i] < aktMax)
                {
                    aktMax = t[i];
                    poz = i;
                }
            }
            return poz;
        }

        int[] t = new int[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            label1.Text = "";
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = rnd.Next(1, 101);
                label1.Text += " " + t[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = MaxKiNo(t, 0, t.Length - 1).ToString();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = MaxKiCs(t, 0, t.Length - 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            for (int i = 0; i < t.Length; i++)
            {
                Csere(t, i, MaxKiNo(t, i, t.Length));   
            }

            for (int i = 0; i < t.Length; i++)
            {
                label4.Text += " " + t[i].ToString();
            }

            // 2 tömb unioja
        }
    }
}
