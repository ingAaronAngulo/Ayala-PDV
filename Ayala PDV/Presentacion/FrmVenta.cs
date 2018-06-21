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
using Ayala_PDV.Negocios;
using Ayala_PDV.Datos;

namespace Ayala_PDV.Presentacion
{
    public partial class FrmVenta : Form
    {
        private double monto;
        private int index;
        public FrmVenta()
        {
            InitializeComponent();
            
            index = 1;

        }

        private void ActualizarMontos()
        {
            LblTotal.Text = "$" + monto;

            try
            {
                if (TxtPagara.Text != "")
                    LblCambio.Text = "$" + (double.Parse(TxtPagara.Text) - monto);
                else
                    LblCambio.Text = "$0";
            }
            catch(Exception ex)
            {
                TxtPagara.Text = "";
                MessageBox.Show("Ingrese valores numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SumarProducto(int fila)
        {
            Producto producto = FachadaNegocios.Instance.ObtenerProducto(tablaVentas.Rows[fila].Cells[3].Value.ToString(), true);
            int i = IndiceEliminacion(producto.getCodigo());
            int cantidad = int.Parse(tablaVentas.Rows[i].Cells[4].Value.ToString()) + 1;

            if (producto.getExistencia() - cantidad >= 0)
            {
                tablaVentas.Rows[i].Cells[4].Value = cantidad;
                tablaVentas.Rows[i].Cells[6].Value = cantidad * producto.getPrecio();
                FachadaNegocios.Instance.AgregarProductoVenta(producto);
                monto += producto.getPrecio();
                ActualizarMontos();
            }
            else
            {
                MessageBox.Show("Está intentando vender el mismo producto mas veces de los que tiene registrados, modifique el registro de este producto antes de realizar esta venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void RestarProducto(int fila)
        {
            Producto producto = FachadaNegocios.Instance.ObtenerProducto(tablaVentas.Rows[fila].Cells[3].Value.ToString(), true);
            FachadaNegocios.Instance.EliminarProductoVenta(producto);

            int i = IndiceEliminacion(producto.getCodigo());
            int cantidad = int.Parse(tablaVentas.Rows[i].Cells[4].Value.ToString()) - 1;

            if (cantidad == 0)
            {
                tablaVentas.Rows.RemoveAt(i);
                if(tablaVentas.Rows.Count == 0)
                {
                    BtnCancelar_Click(null, null);
                    return;
                }
            }
            else
            {
                tablaVentas.Rows[i].Cells[4].Value = cantidad;
                tablaVentas.Rows[i].Cells[6].Value = cantidad * producto.getPrecio();
            }
            
            monto -= producto.getPrecio();
            ActualizarMontos();
        }

        private int IndiceEliminacion(string codigo)
        {
            string tablaCodigo;

            for (int i = 0; i < tablaVentas.RowCount; i++)
            {
                tablaCodigo = tablaVentas.Rows[i].Cells[3].Value.ToString();
                if (tablaCodigo == codigo)
                    return i;
            }
            return 0;
        }

        private bool ErrorCampos()
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Proporcione el código del producto", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (FachadaNegocios.Instance.ObtenerProducto(TxtCodigo.Text, true) == null)
            {
                MessageBox.Show("No se encontró el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(!ErrorCampos())
            {
                Producto producto = FachadaNegocios.Instance.ObtenerProducto(TxtCodigo.Text, true);

                if (producto.getExistencia() > 0)
                {
                    if (FachadaNegocios.Instance.VerificarProductoRepetido(producto))
                    {
                        //Agregar el producto es lo ultimo que se debe de hacer
                        //producto repetido
                        int i = IndiceEliminacion(producto.getCodigo());
                        int cantidad = int.Parse(tablaVentas.Rows[i].Cells[4].Value.ToString()) + 1;
                        if (producto.getExistencia() - cantidad >= 0)
                        {
                            tablaVentas.Rows[i].Cells[4].Value = cantidad;
                            tablaVentas.Rows[i].Cells[6].Value = cantidad * producto.getPrecio();
                            FachadaNegocios.Instance.AgregarProductoVenta(producto);
                        }
                        else
                        {
                            MessageBox.Show("Está intentando vender el mismo producto mas veces de los que tiene registrados, modifique el registro de este producto antes de realizar esta venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                        tablaVentas.Rows.Add(index++, producto.getNombre(), producto.getDistribuidor(), producto.getCodigo(), 1, producto.getPrecio(), producto.getPrecio(), "+", "-");

                    monto += producto.getPrecio();
                    ActualizarMontos();
                    TxtCodigo.Text = "";
                    if (BtnCancelar.Enabled == false)
                    {
                        BtnCancelar.Enabled = true;
                        BtnRegistrarVenta.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("Está intentando vender el mismo producto mas veces de los que tiene registrados, modifique el registro de este producto antes de realizar esta venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnRegistrarVenta_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta(FachadaNegocios.Instance.NoVentas(), DateTime.Now, monto);
            FachadaNegocios.Instance.RealizarVenta(venta);
            BtnCancelar_Click(null, null);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnCancelar.Enabled = false;
            BtnRegistrarVenta.Enabled = false;
            tablaVentas.Rows.Clear();
            index = 1;
            monto = 0;
            ActualizarMontos();
            TxtPagara.Text = "";
            FachadaNegocios.Instance.CancelarVenta();
        }

        private void tablaVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex == 7)
                    SumarProducto(e.RowIndex);
                else if (e.ColumnIndex == 8)
                    RestarProducto(e.RowIndex);
        }

        private void TxtPagara_TextChanged(object sender, EventArgs e)
        {
            ActualizarMontos();
        }
    }
}
