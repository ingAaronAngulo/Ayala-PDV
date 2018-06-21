using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ayala_PDV.Presentacion
{
    static class Program
    {
        public static string PATH = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            FrmMenuPrincipal form = new FrmMenuPrincipal();
            //FrmLogin form = new FrmLogin();

            PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/AyalaPDV/";

            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);

                BinaryWriter bw = new BinaryWriter(File.Open(PATH + "cuentas.apdv", FileMode.OpenOrCreate));
                bw.Write("Admin");
                bw.Close();
            }
            form.Show();
            Application.Run();
        }
    }
}
