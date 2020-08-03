using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zarAtma
{
    public partial class Form1 : Form
    {
        Oyuncu o1 = new Oyuncu("o1");
        Oyuncu o2 = new Oyuncu("o2");

        public Form1()
        {
            InitializeComponent();
            this.Width = 500; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();     
        }

        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = i.ToString() + ".png";
            pictureBox3.ImageLocation = i.ToString() + ".png";

            i++;
            if (i > 6)
                i = 1;

            timer1.Interval += 10;

            if (timer1.Interval > 350)
            {
                timer1.Stop();
                ZarAtmak();
            }   
        }

        void ZarAtmak()
        {
            o1.zarAt();
            pictureBox2.ImageLocation = o1.Zar.ToString() + ".png";

            System.Threading.Thread.Sleep(14);
            
            o2.zarAt();
            pictureBox3.ImageLocation = o2.Zar.ToString() + ".png";

            if (o1.Zar > o2.Zar)
                o1.Skor++;
            else if (o2.Zar > o1.Zar)
                o2.Skor++;
            else
            {
                MessageBox.Show("Beraberlik");
                yanma = 0;
                return;
            }
                
            yanma = 0;
            timer2.Start();

            label6.Text = o1.Skor.ToString();
            label5.Text = o2.Skor.ToString();
        }

        int yanma = 0;
        bool renk = true;
        private void timer2_Tick(object sender, EventArgs e)
        {
            yanma++;
            if(renk)
            {
                this.BackColor = Color.White;
                renk = false;
            }
            else
            {
                this.BackColor = Color.Black;
                renk = true;
            }

            if (yanma > 2)
            {
                timer2.Stop();
                this.BackColor = Color.Black;
            }
        }

        public void gecikme()
        {
           int bekle = 0;

           for( ; ; )
           {
               bekle++;
              if (bekle == 10000000)
                    break;
           }

        }

        bool acik = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(!acik)
            {
                this.Width = 700;
                button1.Text = "<";
                acik = true;
            }
            else
            {
                this.Width = 500;
                button1.Text = ">";
                acik = false;
                label1.Text = textBox1.Text;
                label2.Text = textBox2.Text;
            }
            
        }
        
    }
}
