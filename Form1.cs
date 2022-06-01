using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classForRandomMass;
using System.Threading;

namespace Form_for_NETTO_and_BRETTO
{

    public partial class Form1 : Form
    {
        information IWantInf = new information();
        static int port = 8005;


        public Form1()
        {
            InitializeComponent();
            NETTO_button.Enabled = false;
            BRUTTO_button.Enabled = false;
            AutoNum_box.Clear();
            RdyAutoNum.Text = "";

        }

        private void Fixation_button_Click(object sender, EventArgs e)
        {
            if (AutoNum_box.Text != "")
            {
                IWantInf.Auto_num = AutoNum_box.Text;
                RdyAutoNum.Text = AutoNum_box.Text;
                AutoNum_box.Clear();
                NETTO_button.Enabled = true;
                BRUTTO_button.Enabled = true;
                IWantInf.Mass = Convert.ToString(RandomMass.randomNum());
            }
            else
            {
                MessageBox.Show("Номер машины введен некоректно! Повторите снова.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void NETTO_button_Click(object sender, EventArgs e)
        {
            IWantInf.netto_brutto = true;
            NETTO_button.Enabled = false;
            BRUTTO_button.Enabled = false;
            RdyAutoNum.Text = "";

            Client uLikeWhatUSee = new Client();

            ThreadStart threadDelegate = new ThreadStart(() => uLikeWhatUSee.seeMessages(IWantInf.serialize()));

            Thread iWantMessage = new Thread(threadDelegate);

            iWantMessage.Start();
            
            
        }

        private void BRUTTO_button_Click(object sender, EventArgs e)
        {
            IWantInf.netto_brutto = false;
            BRUTTO_button.Enabled = false;
            NETTO_button.Enabled = false;
            RdyAutoNum.Text = "";

            Client uLikeWhatUSee = new Client();
                    
            ThreadStart threadDelegate = new ThreadStart(() => uLikeWhatUSee.seeMessages(IWantInf.serialize()));

            Thread iWantMessage = new Thread(threadDelegate);

            iWantMessage.Start();

        }
    }
}
