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
    public partial class FrmGiderListesi : Form
    {
       
        public FrmGiderListesi()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet= new DataSet();
        private void FrmGiderlerListesi_Load(object sender, EventArgs e)
        {
            DataAdapter();
        }

        private void DataAdapter()
        {
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Giderler", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Giderler");
            dataGridView1.DataSource = dataSet.Tables["Giderler"];
            bgl.baglanti().Close();
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmGiderGuncelle giderGuncelle = new FrmGiderGuncelle();
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            giderGuncelle.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            giderGuncelle.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            giderGuncelle.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            giderGuncelle.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            giderGuncelle.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            giderGuncelle.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            giderGuncelle.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            giderGuncelle.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            giderGuncelle.Show();



        }

      
    }
}
