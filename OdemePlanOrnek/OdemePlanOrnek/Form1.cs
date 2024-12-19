using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdemePlanOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTaksit.Items.Add("Peşin");
            for (int i = 2; i <= 12; i++)
            {
                cmbTaksit.Items.Add(i + " Taksit");
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            double fiyat = 0;
            DateTime tarih= DateTime.Now;
            fiyat=Convert.ToDouble(txtFiyat.Text);
            int taksitSayisi=cmbTaksit.SelectedIndex+1;

            if (taksitSayisi >= 6 && taksitSayisi<=9)
            {
                fiyat = fiyat * 1.1;
            }
            else if (taksitSayisi > 9 && taksitSayisi<=12)
            {
                fiyat = fiyat * 1.2;
            }
            else
            {
                fiyat = fiyat;
            }

            double taksitTutar = fiyat / taksitSayisi;
            //MessageBox.Show(taksitTutar + "");

            for(int i = 1; i <= taksitSayisi; i++)
            {
                tarih=tarih.AddMonths(1);
                listBox1.Items.Add(i+".Taksit:"+tarih.ToShortDateString()+"   Ödenecek Tutar:"+Math.Round(taksitTutar,2) + " ₺");

            }

            lblToplamTutar.Text = "Toplam Ödenecek Tutar: " + fiyat + "₺";


        }
    }
}
