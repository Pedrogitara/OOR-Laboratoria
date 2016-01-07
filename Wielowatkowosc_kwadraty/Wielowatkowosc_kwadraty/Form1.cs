using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Wielowatkowosc_kwadraty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread watek1;
        Thread watek2;
        Random rdm;

        public void watek_czerwony()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(rdm.Next(0, this.Width), rdm.Next(0, this.Height), 20, 20));
                Thread.Sleep(100);
            }
            MessageBox.Show("Ukończono wątek z kwadratami czerwonymi.");
        }

        public void watek_niebieski()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Blue, 4), new Rectangle(rdm.Next(0, this.Width), rdm.Next(0, this.Height), 20, 20));
                Thread.Sleep(100);
            }
            MessageBox.Show("Ukończono wątek z kwadratami niebieskimi.");
        }

        private void btn_watek_1_Click(object sender, EventArgs e)
        {
            watek1 = new Thread(watek_czerwony);
            watek1.Start();
        }

        private void btn_watek_2_Click(object sender, EventArgs e)
        {
            watek2 = new Thread(watek_niebieski);
            watek2.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdm = new Random();
        }
    }
}
