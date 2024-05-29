using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmOgrKayit());
            //Application.Run(new FrmBolumler());
            //Application.Run(new FrmAnaForm());
            //Application.Run(new frmOgrenciRapor());
            // Application.Run(new FrmOdemeler());
            //Application.Run(new FrmOgrListe());
            //Application.Run(new FrmGiderler());
            //Application.Run(new FrmGiderListesi());
            //Application.Run(new FrmGelirIstatistik());
            Application.Run(new FrmAdminGiris());
            //Application.Run(new FrmYoneticiDuzenle());
            //Application.Run(new FrmPersonel());

        }
    }
}
