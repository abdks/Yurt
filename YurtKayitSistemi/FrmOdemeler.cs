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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();
        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataAdapter();
            for (int i = 0; i < 7; i++)
            {
                cmbYil.Items.Add((DateTime.Now.Year - 3 + i).ToString());
            }
            btnOdemeAl.Enabled = false;
            panel1.Hide();


        }

        private void DataAdapter()
        {
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Borclar", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Borclar");
            dataGridView1.DataSource = dataSet.Tables["Borclar"];
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtOgrid.Text = id;
            txtKalanBorc.Text = kalan;


        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            try
            {
                //ödenen tutarı kalan tutardan düşme
                int odenen, kalan, yeniborc;
                odenen = short.Parse(txtOdenenBorc.Text);
                kalan = short.Parse(txtKalanBorc.Text);
                yeniborc = kalan - odenen;
                txtKalanBorc.Text = yeniborc.ToString();

                //yeni tutarı veri tabanına kaydetme
                SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where " +
                    "Ogrid=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", txtOgrid.Text);
                komut.Parameters.AddWithValue("@p1", txtKalanBorc.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("borç ödendi");
                DataAdapter();

                //Kasa Tablosuna Ekleme Yapma
                SqlCommand komut2 = new SqlCommand("insert into Kasa(OdemeAy,OdemeMiktar) values(@k1,@k2)"
                    , bgl.baglanti());
                komut2.Parameters.AddWithValue("@k1", cmbAy.Text + " " + cmbYil.Text);
                komut2.Parameters.AddWithValue("@k2", txtOdenenBorc.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Hata tekrar deneyin");
            }


        }

        private void cmbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYil.Text != "" && cmbAy.Text != "")
            {
                btnOdemeAl.Enabled = true;
            }
        }
        bool SilmeIzni = false;
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (SilmeIzni == false)
                panel1.Show();
            else
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                if (index > 0)
                {
                    SqlCommand komut1 = new SqlCommand("delete from borclar where ogrid=@p1", bgl.baglanti());
                    komut1.Parameters.AddWithValue("@p1", int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString()));
                    komut1.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Öğrenci borç kaydı silindi");
                    DataAdapter();
                }
                SilmeIzni = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select *from Admin where YoneticiAd=@p1 and YoneticiSifre=@p2"
                , bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader reader = komut1.ExecuteReader();
            if (reader.Read())
            {
                SilmeIzni = true;
                bgl.baglanti().Close();
                DialogResult result = MessageBox.Show("şimdi sil butonuna basarak seçili öğrencinin borç kaydını silebilirsiniz ");
                if (result == DialogResult.OK)
                    panel1.Hide();
            }
            else
            {
                bgl.baglanti().Close();
                MessageBox.Show("hatalı giriş", "Message", MessageBoxButtons.OK);

            }

        }
    }
}
