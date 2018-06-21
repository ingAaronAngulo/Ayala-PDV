//Código creado por Aarón Angulousing System;

using Ayala_PDV.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayala_PDV.Presentacion
{
    public partial class FrmDetalleVenta : Form
    {
        DataTable detalle;
        int filas;

        public FrmDetalleVenta(int id)
        {
            InitializeComponent();
            LblTitulo.Text = "Detallado de venta para la venta: " + id;
            detalle = FachadaNegocios.Instance.ObtenerDetalleVentas(id);
            filas = detalle.Rows.Count;
            CargarDetalle();
        }

        public void CargarDetalle()
        {
            long cantidad;
            double precio;
            int index = 0;
            for (int i = 0; i < filas; i++)
            {
                cantidad = detalle.Rows[i].Field<Int64>(2);
                precio = detalle.Rows[i].Field<double>(3);
                TablaDetalleVenta.Rows.Add(++index, detalle.Rows[i].Field<string>(1), cantidad, precio, precio * cantidad);
            }
        }
    }
}
