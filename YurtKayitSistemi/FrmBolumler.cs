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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        // SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NIJEM97\WINCC;
        // Initial Catalog = YurtOtomasyonu; Integrated Security = True");
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NIJEM97\WINCC;
        // Initial Catalog=YurtOtomasyonu;Integrated Security=True");
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet.Bolumler' table.
            // You can move, or remove it, as needed.
            dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            DataAdapter();
        }

        private void DataAdapter()
        {
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Bolumler", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Bolumler");
            dataGridView1.DataSource = dataSet.Tables["Bolumler"];
            bgl.baglanti().Close();
        }

        private void pcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtBolumAd.Text.Trim());
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm eklendi");
                DataAdapter();
            }
            catch
            {
                MessageBox.Show("Hata oluştu tekrar dene");
            }


        }

        private void pcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtBolumid.Text.Trim());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm silindi");
                DataAdapter();
            }
            catch
            {
                MessageBox.Show("Hata işlem gerçekleşmedi");
            }

        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumAd;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumAd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            txtBolumid.Text = id;
            txtBolumAd.Text = bolumAd;
        }

        private void pcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut2 = new SqlCommand("update bolumler Set BolumAd=@p1 where Bolumid=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtBolumAd.Text.Trim());
                komut2.Parameters.AddWithValue("@p2", txtBolumid.Text.Trim());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("güncelleme işlemi başarılı");
                DataAdapter();
            }
            catch
            {
                MessageBox.Show("Hata");
            }
        }
    }
}
