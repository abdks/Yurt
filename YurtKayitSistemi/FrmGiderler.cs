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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Giderler (Elektrik,Su,Dogalgaz,Internet,Gida" +
              ",Personel,Diger,KayitTarihi) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", txtSu.Text);
                komut.Parameters.AddWithValue("@p3", txtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", txtInternet.Text);
                komut.Parameters.AddWithValue("@p5", txtGida.Text);
                komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", txtDiger.Text);
                komut.Parameters.AddWithValue("@p8", DateTime.Now.Date);               
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("update  Giderler set Toplam= " +
                    "(Elektrik+Su+Dogalgaz+Internet+Gida+Personel+Diger)", bgl.baglanti());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("giderler kaydedildi");

            }
            catch (Exception)
            {

                MessageBox.Show("Hata oluştu yeniden deneyin");
            }
          

        }
    }
}
