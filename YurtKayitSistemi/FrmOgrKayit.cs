using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    //Data Source=DESKTOP-NIJEM97\WINCC;Initial Catalog=YurtOtomasyonu;Integrated Security=True
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NIJEM97\WINCC;
        //Initial Catalog=YurtOtomasyonu;Integrated Security=True");//data verilerinin olduğu adres
        //sql ile baglanti connection ile bir baglanti oluşturduk.
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {
            //bölümleri listeleme komutları
            //baglanti.Open();//baglanti açma işlemi
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler order by BolumAd", bgl.baglanti());//ilgili table ile
            SqlDataReader oku = komut.ExecuteReader(); //komut oluşturma ve executereder ile verileri okuma yapıldı
            while (oku.Read())//veri okunup okumadığını döndüren bir bool komutu
            {
                CmbOgrBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();//baglanti kapatma işlemi

            //Boş odaları listeleme komutları //sql komutlarında büyük küçük ayrımı yok
            //baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite!=OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // baglanti.Open();
                SqlCommand komutKaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTC,OgrTelefon," +
                    "OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values" +
                    "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komutKaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);// truncate table ogrenci
                komutKaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);//veri sıfırlama komutu
                komutKaydet.Parameters.AddWithValue("@p3", MskOgrTC.Text);
                komutKaydet.Parameters.AddWithValue("@p4", MskOgrTel.Text);
                komutKaydet.Parameters.AddWithValue("@p5", MskOgrDogum.Text);
                komutKaydet.Parameters.AddWithValue("@p6", CmbOgrBolum.Text);
                komutKaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                komutKaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                komutKaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                komutKaydet.Parameters.AddWithValue("@p10", MskVeliTel.Text);
                komutKaydet.Parameters.AddWithValue("@p11", RchAdres.Text);

                komutKaydet.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Başarılı bir şekilde gerçekleştirildi");



                //Öğrenci id yi label12 ye çekme
                SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci", bgl.baglanti());

                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();



                //Öğrenci Borç Alanı Oluşturma
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad)" +
                    " values (@b1,@b2,@b3)", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);

                komutkaydet2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"HATA Lütfen Tekrar Deneyin {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Öğrenci Oda Kontejanı arttırma

            SqlCommand komutOda = new SqlCommand("update odalar set odaaktif+=1 where odano=@oda", bgl.baglanti());
            komutOda.Parameters.AddWithValue("@oda", CmbOdaNo.Text);
            komutOda.ExecuteNonQuery();
            bgl.baglanti().Close();
            

           


        }
    }
}
