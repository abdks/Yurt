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
    public partial class FrmAnaForm : Form
    {

        public FrmAnaForm()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "www.kaizen40.com",
            //    MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    e.Cancel = true;

            //    // iptal ederseniz ne yapacağınızı buraya yazın
            //}

            //// Evet' i tıklarsanız çıkarsınız
            Application.Exit();

        }
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            DataAdapter();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // this.Hide();
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet1.Ogrenci' table. You can move, or remove it, as needed.
            //this.ogrenciTableAdapter.Fill(this.yurtOtomasyonuDataSet1.Ogrenci);

            timer1.Start();
            axWindowsMediaPlayer1.Location = new Point(500, 230);


        }

        private void DataAdapter()
        {
            
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select Ogrid,OgrAd,OgrSoyad,OgrOdaNo from Ogrenci", bgl.baglanti());            
            dataAdapter.Fill(dataSet,"Ogrenci");
            dataGridView1.DataSource = dataSet.Tables["Ogrenci"];
            bgl.baglanti().Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MsPaint.exe");
        }

        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://37.247.98.8/stream/166/";
        }

        private void radyo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://160.75.86.29:8088/stream/1/";
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://radio-trtradyohaber.live.trt.com.tr/master.m3u8";
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrKayit ogrKayit = new FrmOgrKayit();
            ogrKayit.Show();
        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe ogrListe = new FrmOgrListe();
            ogrListe.Show();

        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmOgrDuzenle ogrDuzenle = new FrmOgrDuzenle();
            //ogrDuzenle.Show();
            FrmOgrListe ogrListe = new FrmOgrListe();
            ogrListe.Show();

        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler bolumler = new FrmBolumler();
            bolumler.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler bolumler = new FrmBolumler();
            bolumler.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler odemeler = new FrmOdemeler();
            odemeler.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderler giderler = new FrmGiderler();
            giderler.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListesi giderListesi = new FrmGiderListesi();
            giderListesi.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirIstatistik gelirIstatistik = new FrmGelirIstatistik();
            gelirIstatistik.Show();
        }

        private void giderİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYoneticiDuzenle yoneticiDuzenle = new FrmYoneticiDuzenle();
            yoneticiDuzenle.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel personel = new FrmPersonel();
            personel.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotEkle notEkle = new frmNotEkle();
            notEkle.Show();
        }

        private void öğrenciBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrenciRapor rapor = new frmOgrenciRapor();
            rapor.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu proje İlker Şenel tarafından yapılmıştır." +
                "Linkedin sayfamı görmek için evet'e basabilirsiniz.", "Hakkımızda", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                == DialogResult.Yes)

            {
                System.Diagnostics.Process.Start("https://www.linkedin.com/in/ilker-%C5%9Fenel-112363221/");
            }

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            DataAdapter();
        }


        //~FrmAnaForm()
        //{
        //    Application.Exit();
        //   // GC.Collect();
        //}
    }
}
