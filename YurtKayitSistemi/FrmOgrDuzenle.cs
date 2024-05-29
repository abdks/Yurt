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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        public string id, ad, soyad, Tc, telefon, dogum, bolum;

        private void btnSil_Click(object sender, EventArgs e)
        {
            //öğrenci silme
            SqlCommand komutsil = new SqlCommand("delete from ogrenci where ogrid=@ogrid", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@ogrid", int.Parse(txtOgrid.Text));
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("kayıt silindi");

            //odanın aktif öğrenci sayısını azaltma
            SqlCommand komutoda = new SqlCommand("update Odalar set odaaktif-=1 " +
                "where odano=@odano ", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@odano", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Ogrenci set " +
                    "OgrAd=@p2,OgrSoyad=@p3,OgrTc=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7," +
                    "OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelefon=@p11,OgrVeliAdres=@p12" +
                    " where Ogrid=@p1", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", txtOgrid.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MskOgrTC.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTel.Text);
                komut.Parameters.AddWithValue("@p6", MskOgrDogum.Text);
                komut.Parameters.AddWithValue("@p7", CmbOgrBolum.Text);
                komut.Parameters.AddWithValue("@p8", TxtMail.Text);
                komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", MskVeliTel.Text);
                komut.Parameters.AddWithValue("@p12", RchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("kayıt güncellendi");
                if (odano != CmbOdaNo.Text)
                {
                    SqlCommand komutoda = new SqlCommand("update Odalar set odaaktif-=1 " +
               "where odano=@odano ", bgl.baglanti());
                    komutoda.Parameters.AddWithValue("@odano", odano);
                    komutoda.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlCommand komutoda2 = new SqlCommand("update Odalar set odaaktif+=1 where odano=@odano",
                        bgl.baglanti());
                    komutoda2.Parameters.AddWithValue("@odano", int.Parse(CmbOdaNo.Text));
                    komutoda2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

            }
            catch
            {
                MessageBox.Show("Hata yeniden deneyin");
            }


        }

        public string mail, odano, veliad, velitel, adres;
        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            txtOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskOgrTC.Text = Tc;
            MskOgrTel.Text = telefon;
            MskOgrDogum.Text = dogum;
            CmbOgrBolum.Text = bolum;
            TxtMail.Text = mail;
            CmbOdaNo.Text = odano;
            TxtVeliAdSoyad.Text = veliad;
            MskVeliTel.Text = velitel;
            RchAdres.Text = adres;
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler order by BolumAd", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                CmbOgrBolum.Items.Add(read[0]);
            }

            bgl.baglanti().Close();
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite!=OdaAktif", bgl.baglanti());
            read = komut2.ExecuteReader();
            while (read.Read())
            {
                CmbOdaNo.Items.Add(read[0]);
            }
            bgl.baglanti().Close();


        }
    }
}
