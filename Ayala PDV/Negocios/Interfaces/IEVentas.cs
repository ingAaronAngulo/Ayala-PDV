using Ayala_PDV.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Ayala_PDV.Negocios
{
    interface IEVentas
    {
        DataTable ObtenerReporteVentas(DateTime inicio, DateTime fin, bool calendarizado);

        DataTable ObtenerDetalleVentas(int id);

        string ConvertidorFecha(DateTime datetime);

        string ConvertidorFechaReporte(DateTime fecha);

        void RealizarVenta(Venta venta);

        void DesactivarVenta(long id);

        long NoVentas();

        long NoDetalleVentas();

        void CancelarVenta();
        
        void AgregarProductoVenta(Producto producto);

        void EliminarProductoVenta(Producto producto);

        bool VerificarProductoRepetido(Producto producto);
    }
}
