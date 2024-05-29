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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet= new DataSet();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet8.Personel' table. You can move, or remove it, as needed.
            
            DataAdapter();

        }

        private void DataAdapter()
        {
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Personel", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Personel");
            dataGridView1.DataSource = dataSet.Tables["Personel"];
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman)" +
                " values(@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtPersonelAd.Text);
            komut.Parameters.AddWithValue("@p2", txtPersonelGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt eklendi");
            DataAdapter();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete from Personel where Personelid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtPersonelId.Text));
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt silindi");
                DataAdapter();
            }
            catch (Exception)
            {

                ;
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtPersonelId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtPersonelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPersonelGorev.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutgun = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2" +
               " where Personelid=@p0", bgl.baglanti());
                komutgun.Parameters.AddWithValue("@p0", byte.Parse(txtPersonelId.Text));
                komutgun.Parameters.AddWithValue("@p1", txtPersonelAd.Text);
                komutgun.Parameters.AddWithValue("@p2", txtPersonelGorev.Text);
                komutgun.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("kayıt güncellendi");
                DataAdapter();
            }
            catch (Exception)
            {

                ;
            }
           
        }
    }
}
