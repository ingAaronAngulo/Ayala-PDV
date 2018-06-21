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

namespace Ayala_PDV.Presentacion
{
    public partial class FrmReporteVentas : Form
    {
        private DataTable ventas;
        
        private double monto;

        public FrmReporteVentas()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            MostrarVentas(false);
        }

        public void MostrarVentas(bool calendario)
        {
            ventas = FachadaNegocios.Instance.ObtenerReporteVentas(DtpInicio.Value.Date, DtpFin.Value.Date, calendario);
            int filas = ventas.Rows.Count;
            TablaReporteVentas.Rows.Clear();
            for (int i = 0; i < filas; i++)
                TablaReporteVentas.Rows.Add("", ventas.Rows[i].Field<Int64>(0), ventas.Rows[i].Field<string>(1), ventas.Rows[i].Field<double>(2), ventas.Rows[i].Field<int>(3));
            
            CalcularGanancias();
        }

        public void CalcularGanancias()
        {
            monto = 0;

            DataTable TotalVentas = FachadaNegocios.Instance.ObtenerReporteVentas(DtpInicio.Value.Date, DtpFin.Value.Date, false);
            int filas = TotalVentas.Rows.Count;
            
            for (int i = 0; i < filas; i++)
                if (TotalVentas.Rows[i].Field<int>(3) == 1)
                    monto += TotalVentas.Rows[i].Field<double>(2);

            LblGanancias.Text = "$" + monto;

            monto = 0;
            filas = TablaReporteVentas.Rows.Count;

            for (int i = 0; i < filas; i++)
                if (int.Parse(TablaReporteVentas.Rows[i].Cells[4].Value.ToString()) == 1)
                    monto += double.Parse(TablaReporteVentas.Rows[i].Cells[3].Value.ToString());

            LblGananciasPeriodo.Text = "$" + monto;
        }

        public void MostrarDetalle(int fila)
        {
            FrmDetalleVenta frmDv = new FrmDetalleVenta(int.Parse(TablaReporteVentas.Rows[fila].Cells[1].Value.ToString()));
            frmDv.Show();
        }

        private void TablaReporteVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            int columna = e.ColumnIndex;

            Console.WriteLine(fila);
            Console.WriteLine(columna);
            
            if (fila >= 0)
                if (columna == 0)
                    MostrarDetalle(fila);
                if (columna == 4)
                    if (int.Parse(TablaReporteVentas.Rows[fila].Cells[columna].Value.ToString()) == 1)
                        if (MessageBox.Show("¿Está seguro que desea marcar la venta como No concretada? ésta acción no se puede revertir", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            TablaReporteVentas.Rows[fila].Cells[columna].Value = 0;
                            Console.WriteLine("Eliminando venta con id: " + TablaReporteVentas.Rows[fila].Cells[1].Value.ToString());
                            FachadaNegocios.Instance.DesactivarVenta(long.Parse(TablaReporteVentas.Rows[fila].Cells[1].Value.ToString()));
                            CalcularGanancias();
                        }
        }

        private void DtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (CbCalendario.Enabled)
                CbCalendario_CheckedChanged(null, null);
        }

        private void CbCalendario_CheckedChanged(object sender, EventArgs e)
        {
            if (CbCalendario.Checked)
                MostrarVentas(true);
            else
                MostrarVentas(false);
        }

        private void DtpFin_ValueChanged(object sender, EventArgs e)
        {
            if(CbCalendario.Enabled)
                CbCalendario_CheckedChanged(null, null);
        }
        
    }
}
