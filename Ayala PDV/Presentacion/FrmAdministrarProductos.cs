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

namespace Ayala_PDV.Presentacion
{
    public partial class FrmAdministrarProductos : Form
    {
        int modo;
        //modo = 1 Agregar, 2 Modificar, 3 Eliminar, 4 Buscar
        public FrmAdministrarProductos(int modo)
        {
            InitializeComponent();
            this.modo = modo;
            ReiniciarControles();
            Show();
        }

        public void ReiniciarControles()
        {
            switch (modo)
            {
                case 1:
                    BtnAgregar.Visible = true;
                    TxtId.Text = "" + FachadaNegocios.Instance.NoProductos();
                    BtnBuscar.Enabled = false;
                    break;

                case 2:
                    BtnModificar.Visible = true;
                    BtnModificar.Enabled = false;
                    TxtDistribuidor.Enabled = false;
                    TxtExistencia.Enabled = false;
                    TxtPrecio.Enabled = false;
                    TxtOrigen.Enabled = false;
                    TxtExistenciaMinima.Enabled = false;
                    break;

                case 3:
                    BtnEliminar.Visible = true;
                    BtnEliminar.Enabled = false;
                    TxtDistribuidor.Enabled = false;
                    TxtExistencia.Enabled = false;
                    TxtPrecio.Enabled = false;
                    TxtOrigen.Enabled = false;
                    TxtExistenciaMinima.Enabled = false;
                    break;
            }
        }

        public void LimpiarTxt()
        {
            TxtId.Text = "";
            TxtNombre.Text = "";
            TxtDistribuidor.Text = "";
            TxtExistencia.Text = "";
            TxtCodigo.Text = "";
            TxtPrecio.Text = "";
            TxtOrigen.Text = "";
            TxtExistenciaMinima.Text = "";

            ReiniciarControles();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(!ErrorCampos())
            {
                try
                {
                    if (FachadaNegocios.Instance.ObtenerProducto(TxtCodigo.Text, true) != null)
                        MessageBox.Show("El código de barras de éste producto es igual al de otro producto registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Producto producto = new Producto(long.Parse(TxtId.Text), VerificarCampos(TxtNombre.Text), VerificarCampos(TxtDistribuidor.Text), int.Parse(TxtExistencia.Text), VerificarCampos(TxtCodigo.Text), double.Parse(TxtPrecio.Text), VerificarCampos(TxtOrigen.Text), int.Parse(TxtExistenciaMinima.Text), 1);
                        FachadaNegocios.Instance.AgregarProducto(producto);
                    }
                    LimpiarTxt();
                    TxtId.Text = "" + FachadaNegocios.Instance.NoProductos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Está proporcionando datos inválidos en algun(os) campo(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (!ErrorCampos())
            {
                Producto producto = new Producto(long.Parse(TxtId.Text), VerificarCampos(TxtNombre.Text), VerificarCampos(TxtDistribuidor.Text), int.Parse(TxtExistencia.Text), VerificarCampos(TxtCodigo.Text), double.Parse(TxtPrecio.Text), VerificarCampos(TxtOrigen.Text), int.Parse(TxtExistenciaMinima.Text), 1);
                FachadaNegocios.Instance.ModificarProducto(producto);
                LimpiarTxt();
            }
        }

        public bool BuscarProducto()
        {
            Producto producto = FachadaNegocios.Instance.ObtenerProducto(TxtCodigo.Text, true);
            if (producto != null)
            {
                TxtId.Text = "" + producto.getId();
                TxtNombre.Text = DevolverApostrofe(producto.getNombre());
                TxtDistribuidor.Text = DevolverApostrofe(producto.getDistribuidor());
                TxtExistencia.Text = "" + producto.getExistencia();
                TxtCodigo.Text = "" + DevolverApostrofe(producto.getCodigo());
                TxtPrecio.Text = "" + producto.getPrecio();
                TxtOrigen.Text = DevolverApostrofe(producto.getOrigen());
                TxtExistenciaMinima.Text = "" + producto.getExistenciaMinima();

                if (modo == 3)
                    BtnEliminar.Enabled = true;
                if (modo == 2)
                {
                    BtnModificar.Enabled = true;
                    TxtNombre.Enabled = true;
                    TxtDistribuidor.Enabled = true;
                    TxtExistencia.Enabled = true;
                    TxtCodigo.Enabled = true;
                    TxtPrecio.Enabled = true;
                    TxtOrigen.Enabled = true;
                    TxtExistenciaMinima.Enabled = true;
                }
                return true;
            }
            else
                return false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            FachadaNegocios.Instance.EliminarProducto(long.Parse(TxtId.Text));
            LimpiarTxt();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if((TxtNombre.Text == "") && (TxtCodigo.Text == ""))
                MessageBox.Show("Proporcione el nombre o código del producto", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (TxtCodigo.Text != "")
                {
                    //la busqueda con código no tuvo exito
                    if (!BuscarProducto())
                    {
                        if (TxtNombre.Text != "")
                        {
                            TablaEncontrados.Rows.Clear();
                            DataTable dt = FachadaNegocios.Instance.ObtenerProductos("nombre", TxtNombre.Text);
                            int filas = dt.Rows.Count;
                            if (filas > 0)
                            {
                                for (int i = 0; i < filas; i++)
                                    TablaEncontrados.Rows.Add(dt.Rows[i].Field<string>(1), dt.Rows[i].Field<string>(2), dt.Rows[i].Field<string>(4), dt.Rows[i].Field<string>(6));
                            }
                            else
                                MessageBox.Show("No hubo coincidencías con el nombre y código de producto proporcionados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("No se encontró el producto con el código proporcionado, teclee el nombre del producto para brindarle ayuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    TablaEncontrados.Rows.Clear();
                    DataTable dt = FachadaNegocios.Instance.ObtenerProductos("nombre", TxtNombre.Text);
                    int filas = dt.Rows.Count;
                    for (int i = 0; i < filas; i++)
                        TablaEncontrados.Rows.Add(dt.Rows[i].Field<string>(1), dt.Rows[i].Field<string>(2), dt.Rows[i].Field<string>(4), dt.Rows[i].Field<string>(6));
                }
            }
        }

        public string VerificarCampos(string s)
        {
            if (s.Contains("'"))
                return s.Replace("'", "''");
            return s;
        }
        public string DevolverApostrofe(string s)
        {
            if (s.Contains("''"))
                return s.Replace("''", "'");
            return s;
        }


        private bool ErrorCampos()
        {
            if ((TxtNombre.Text == "") || (TxtDistribuidor.Text == "") || (TxtExistencia.Text == "") || (TxtCodigo.Text == "") || (TxtPrecio.Text == "") || (TxtOrigen.Text == "") || (TxtExistencia.Text == ""))
            {
                MessageBox.Show("Proporcione la información pertinente en todos los campos", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                try
                {
                    if ((int.Parse(TxtExistencia.Text) < 0) || (double.Parse(TxtPrecio.Text) < 0) || (int.Parse(TxtExistenciaMinima.Text) < 0))
                    {
                        MessageBox.Show("Proporcione valores mayores a 0 en los campos de 'existencia' y/o 'precio'", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Está proporcionando datos inválidos en algun(os) campo(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        private void TablaEncontrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;

            if (fila >= 0)
            {
                TxtCodigo.Text = TablaEncontrados.Rows[fila].Cells[2].Value.ToString();
                BuscarProducto();
            }
        }
    }
}
