//Código creado por Aarón Angulo

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ayala_PDV.Datos;

namespace Ayala_PDV.Negocios
{
    class FachadaNegocios : IEControlProducto, IEVentas, IESincronizacion
    {
        private ControlProducto cp;
        private ControlVentas cv;
        private ControlSincronizacion cs;

        //////////////////////////////////////////////////////////Clase/////////////////////////////////////////////////////////////
        private static FachadaNegocios instance;
        private FachadaNegocios()
        {
            cp = new ControlProducto();
            cv = new ControlVentas();
            cs = new ControlSincronizacion();
            EstablecerConexion();
        }

        public static FachadaNegocios Instance
        {
            get
            {
                if (instance == null)
                    instance = new FachadaNegocios();
                return instance;
            }
        }

        public void EstablecerConexion()
        {
            ConexionSQL.Instance.ConectarBDD();
        }
        //////////////////////////////////////////////////////////ControlProducto/////////////////////////////////////////////////////////////
        public Producto ObtenerProducto(string codigo, bool activado)
        {
            return cp.ObtenerProducto(codigo, activado);
        }

        public DataTable ObtenerProductos(string campo, string valor)
        {
            return cp.ObtenerProductos(campo, valor);
        }

        public long NoProductos()
        {
            return cp.NoProductos();
        }

        public void AgregarProducto(Producto producto)
        {
            cp.AgregarProducto(producto);
        }

        public void ModificarProducto(Producto producto)
        {
            cp.ModificarProducto(producto);
        }

        public void EliminarProducto(long id)
        {
            cp.EliminarProducto(id);
        }
        //////////////////////////////////////////////////////////ControlVentas/////////////////////////////////////////////////////////////

        public string ConvertidorFecha(DateTime datetime)
        {
            return cv.ConvertidorFecha(datetime);
        }

        public string ConvertidorFechaReporte(DateTime datetime)
        {
            return cv.ConvertidorFechaReporte(datetime);
        }

        public void RealizarVenta(Venta venta)
        {
            cv.RealizarVenta(venta);
        }

        public void CancelarVenta()
        {
            cv.CancelarVenta();
        }

        public void AgregarProductoVenta(Producto producto)
        {
            cv.AgregarProductoVenta(producto);
        }

        public void DesactivarVenta(long id)
        {
            cv.DesactivarVenta(id);
        }

        public void EliminarProductoVenta(Producto producto)
        {
            cv.EliminarProductoVenta(producto);
        }

        public long NoVentas()
        {
            return cv.NoVentas();
        }

        public long NoDetalleVentas()
        {
            return cv.NoDetalleVentas();
        }

        public DataTable ObtenerReporteVentas(DateTime inicio, DateTime fin, bool calendarizado)
        {
            return cv.ObtenerReporteVentas(inicio, fin, calendarizado);
        }

        public bool VerificarProductoRepetido(Producto producto)
        {
            return cv.VerificarProductoRepetido(producto);
        }

        public DataTable ObtenerDetalleVentas(int id)
        {
            return cv.ObtenerDetalleVentas(id);
        }

        //////////////////////////////////////////////////////////ControlSincronizacion/////////////////////////////////////////////////////////////

        public void InicializarAPI()
        {
            cs.InicializarAPI();
        }

        public void SubirBDD()
        {
            cs.SubirBDD();
        }

    }
}
