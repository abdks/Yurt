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
    public partial class frmOgrenciRapor : Form
    {


        public frmOgrenciRapor()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();

        private void frmOgrenciRapor_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Ogrenci", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Ogrenci");
            dataGridView1.DataSource = dataSet.Tables["Ogrenci"];
            bgl.baglanti().Close();


        }


    }
}
