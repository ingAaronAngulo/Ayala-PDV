using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayala_PDV.Presentacion
{
    public partial class FrmLogin : Form
    {
        bool autorizado;

        public FrmLogin()
        {
            InitializeComponent();
            autorizado = false;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            BinaryReader br = new BinaryReader(File.Open(Program.PATH + "cuentas.apdv", FileMode.OpenOrCreate));
            string contrasena = br.ReadString();
            br.Close();

            if (TxtContrasena.Text == contrasena)
            {
                autorizado = true;
                FrmMenuPrincipal form = new FrmMenuPrincipal();
                form.Show();
                Close();
            }
            else
                MessageBox.Show("Contraseña errónea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!autorizado)
                Application.Exit();
        }
    }
}
