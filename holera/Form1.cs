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
        int[] elsoTomb = new int[5];
        int[] masodikTomb = new int[5];
        int[] harmadikTomb = new int[10];


        //SZIA
        struct pontok
        {
            public int x;
            public int y;
            public double tav;
            public pontok(int a, int b)
            {
                x = a;
                y = b;
                tav = Math.Sqrt(x * x + y * y);
            }
            public static bool operator >(pontok a, pontok b)
            {
                if (a.tav > b.tav)
                {
                    return true;
                }
                return false;
            }
            public static bool operator <(pontok a, pontok b)
            {
                if (a.tav < b.tav)
                {
                    return true;
                }
                return false;
            }
        }

        pontok vaza = new pontok(9, 10);
        pontok haza = new pontok(10, 15);
        public Form1()
        {
            InitializeComponent();
        }
        // constructor legoglalja a helyet castolja es erteket ad neki
        private void Form1_Load(object sender, EventArgs e)
        {
            int k = 5;
            int pos = 0;
            bool vane = false;
            for (int i = 1; i < elsoTomb.Length; i++)
            {
                Random rnd = new Random();
                elsoTomb[i] = elsoTomb[i - 1] + rnd.Next(1, 10);
                masodikTomb[i] = masodikTomb[i - 1] + rnd.Next(1, 10);
                harmadikTomb[i] = elsoTomb[i];
            }
            for (int i = 0; i < elsoTomb.Length; i++)
            {
                for (int j = 0; j < elsoTomb.Length; j++)
                {
                    if (elsoTomb[i] == masodikTomb[j])
                    {
                        vane = true;
                        pos = j;
                    }
                }
                if (vane == true)
                {
                    harmadikTomb[k] = masodikTomb[pos];
                    k++;
                }
                vane = false;
            }
            if (vaza > haza)
            {

            }
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

            // 2 tömb unioja 2 tömb metszete


        }
    }
}
