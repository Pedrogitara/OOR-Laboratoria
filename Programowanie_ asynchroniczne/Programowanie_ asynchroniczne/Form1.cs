using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie__asynchroniczne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_uruchom_Click(object sender, EventArgs e)
        {
            CallBigImportantMethod();
            lbl_napis.Text = "Czekaj, trochę to trwa...";
        }

        private async void CallBigImportantMethod()
        {
            var result = await BigLongImportantMethodAsync("Piotr ;)");
            lbl_napis.Text = result;
        }

        private Task<string> BigLongImportantMethodAsync(string name)
        {
            return Task.Factory.StartNew(() => BigLongImportantMethod(name));
        }

        private string BigLongImportantMethod(string name)
        {
            Thread.Sleep(10000);
            return "Witaj " + name;
        }
    }
}
