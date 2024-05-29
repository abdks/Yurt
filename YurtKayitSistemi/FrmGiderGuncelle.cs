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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        public string elektrik, su, dogalgaz, internet, gida, personel, diger, id;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,Internet=@p4," +
               "Gida=@p5,Personel=@p6,Diger=@p7 where Odemeid=@p0", bgl.baglanti());
                komut.Parameters.AddWithValue("@p0", txtId.Text);
                komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", txtSu.Text);
                komut.Parameters.AddWithValue("@p3", txtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", txtInternet.Text);
                komut.Parameters.AddWithValue("@p5", txtGida.Text);
                komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", txtDiger.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("gider güncelleme işlemi yapıldı");
            }
            catch (Exception)
            {
                MessageBox.Show("bir hata oluştu tekrar deneyin");
            }




        }

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            txtId.Text = id;
            txtElektrik.Text = elektrik;
            txtDogalgaz.Text = dogalgaz;
            txtSu.Text = su;
            txtInternet.Text = internet;
            txtPersonel.Text = personel;
            txtDiger.Text = diger;
            txtGida.Text = gida;


        }
    }
}
