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
    public partial class FrmOgrListe : Form
    {
        public FrmOgrListe()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();
        private void FrmOgrListe_Load(object sender, EventArgs e)
        {
            DataAdapter();

        }

        private void DataAdapter()
        {
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Ogrenci", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Ogrenci");
            dataGridView1.DataSource = dataSet.Tables["Ogrenci"];
            bgl.baglanti().Close();
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            FrmOgrDuzenle ogrDuzenle = new FrmOgrDuzenle();
            ogrDuzenle.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ogrDuzenle.ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            ogrDuzenle.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            ogrDuzenle.Tc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            ogrDuzenle.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            ogrDuzenle.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            ogrDuzenle.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            ogrDuzenle.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            ogrDuzenle.odano = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            ogrDuzenle.veliad = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            ogrDuzenle.velitel = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            ogrDuzenle.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            ogrDuzenle.Show();
        }
    }
}
