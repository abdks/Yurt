using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YurtKayitSistemi
{
    public partial class frmNotEkle : Form
    {
        public frmNotEkle()
        {
            InitializeComponent();
        }

        private void btnNotEkle_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt yeri Seçin";
                saveFileDialog1.Filter = "Metin dosyası | *.txt";
                saveFileDialog1.InitialDirectory = "C:\\Users\\DellPc\\Desktop\\C-Sharp_Yurt_Kayit_Sistemi_Form_Uygulamasi-main\\YurtKayitSistemi";
                saveFileDialog1.ShowDialog();
                StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
                kaydet.WriteLine(richTextBox1.Text + "\n");
                kaydet.Close();
                MessageBox.Show("kayıt yapıldı");
            }
            catch 
            {
                ;
            }
        }
    }
}
