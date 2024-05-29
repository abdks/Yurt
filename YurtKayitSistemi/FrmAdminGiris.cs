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
    public partial class FrmAdminGiris : Form
    {
        SqlBaglantim bgl = new SqlBaglantim();
        public FrmAdminGiris()
        {
            InitializeComponent();
            //this.FormClosed +=
          //new System.Windows.Forms.FormClosedEventHandler(this.FrmAdminGiris_FormClosed);
        }
        //bool pass = false;
        //private void FrmAdminGiris_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (pass)
        //        (new FrmAnaForm()).ShowDialog();
        //    pass = false;
        //}
        bool degisken = false;
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from admin where yoneticiad=@p1 and yoneticisifre=@p2",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                FrmAnaForm anaForm = new FrmAnaForm();
                anaForm.ShowDialog();
                this.Hide();
                //pass = true;
                //this.Close();


            }
            else
            {
                MessageBox.Show("hatalı kullanıcı adı veya şifre");
                txtKullaniciAd.Text = txtSifre.Text = string.Empty;
                txtKullaniciAd.Focus();
            }
            bgl.baglanti().Close();
        }

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;//şifre yazımını .... olarak döndürür
        }

        private void chcSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if(chcSifreGoster.Checked)
            {
                txtSifre.UseSystemPasswordChar=false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar=true;
            }
        }


        //~FrmAdminGiris()
        //{
        //    GC.Collect();
        //}
    }
}
