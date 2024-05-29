using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class FrmGelirIstatistik : Form
    {
        public FrmGelirIstatistik()
        {
            InitializeComponent();
        }
        SqlBaglantim baglantim = new SqlBaglantim();
        private void FrmGelirIstatistik_Load(object sender, EventArgs e)
        {
            //Kasadaki toplam tutar
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) from Kasa", baglantim.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblPara.Text = oku[0].ToString() + " TL";
            }
            baglantim.baglanti().Close();

            //Tekrarsız olarak ayları Listeleme
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", baglantim.baglanti());
            //distinct aynı şeyin tekrar etmesini engeller
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbAy.Items.Add(oku2[0].ToString());
            }
            baglantim.baglanti().Close();

            //Aylık Kazanç manuel
            //this.chart1.Series["Aylık"].Points.AddY(15);
            //this.chart1.Series["Aylık"].Points.AddXY("Nisan",25);

            //grafiklere veri tabanından veri çekme

            SqlCommand komut3 = new SqlCommand("select k.OdemeAy,sum(k.OdemeMiktar)from Kasa k group by k.OdemeAy"
                , baglantim.baglanti());
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3["OdemeAy"],oku3[1].ToString());
            }
            baglantim.baglanti().Close();

        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) from Kasa where " +
                "OdemeAy=@p1", baglantim.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAy.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAyKazanc.Text = oku[0].ToString();
            }
            baglantim.baglanti().Close();
        }
    }
}
