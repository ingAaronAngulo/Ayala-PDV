//Código creado por Aarón Angulousing System;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ayala_PDV.Datos;
using Ayala_PDV.Negocios;
using System.IO;
using Ayala_PDV.Presentacion;
using System.Net.NetworkInformation;

namespace Ayala_PDV
{
    public partial class FrmMenuPrincipal : Form
    {
        private FrmAdministrarProductos formAp;
        private Form frmActual;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            FachadaNegocios.Instance.EstablecerConexion();
        }

        public void ActualizarSubSistema(Form frm)
        {
            if (frmActual != null)
                frmActual.Close();

            frmActual = frm;

            frmActual.TopLevel = false;
            PnlSubSistema.Controls.Add(frmActual);
            frmActual.FormBorderStyle = FormBorderStyle.None;
            frmActual.Dock = DockStyle.Fill;

            frmActual.Show();
        }

        private void BtnRealizarVenta_Click(object sender, EventArgs e)
        {
            ActualizarSubSistema(new FrmVenta());
        }

        //1 = Agregar, 2 = Modificar, 3 = Eliminar, 4 = Buscar
        private void BtnAgregarProductos_Click(object sender, EventArgs e)
        {
            if (formAp != null)
                formAp.Dispose();
            formAp = new FrmAdministrarProductos(1);
        }

        private void BtnModificarProductos_Click(object sender, EventArgs e)
        {
            if (formAp != null)
                formAp.Dispose();
            formAp = new FrmAdministrarProductos(2);
        }

        private void BtnEliminarProductos_Click(object sender, EventArgs e)
        {
            if (formAp != null)
                formAp.Dispose();
            formAp = new FrmAdministrarProductos(3);
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (formAp != null)
                formAp.Dispose();
            formAp = new FrmAdministrarProductos(4);
        }

        private void BtnProductosRegistrados_Click(object sender, EventArgs e)
        {
            ActualizarSubSistema(new FrmProductosRegistrados());
        }
        
        private void BtnReporteVentas_Click(object sender, EventArgs e)
        {
            ActualizarSubSistema(new FrmReporteVentas());
        }

        private void BtnActualizarBDD_Click(object sender, EventArgs e)
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

            }
            catch (Exception)
            {
                MessageBox.Show("Necesitas conexión a internet para utilizar éste servicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bool posible = true;

            if ((frmActual != null) || (formAp != null))
            {
                if (frmActual != null)
                    if (!frmActual.IsDisposed)
                        posible = false;
                if (formAp != null)
                    if (!formAp.IsDisposed)
                        posible = false;

                if (!posible)
                    if (MessageBox.Show("Si continúa con la operación se cerraran las actividades que esté realizando", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (frmActual != null)
                            frmActual.Close();
                        if (formAp != null)
                            formAp.Close();
                        FrmCarga frmCarga = new FrmCarga();
                        frmCarga.Show();
                        try
                        {
                            FachadaNegocios.Instance.InicializarAPI();
                            FachadaNegocios.Instance.SubirBDD();
                        }
                        catch (Exception ex)
                        {

                        }
                        frmCarga.Close();
                    }
            }

            if(posible)
            {
                FrmCarga frmCarga = new FrmCarga();
                frmCarga.Show();
                try
                {
                    FachadaNegocios.Instance.InicializarAPI();
                    FachadaNegocios.Instance.SubirBDD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error desconocido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmCarga.Close();
            }
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
