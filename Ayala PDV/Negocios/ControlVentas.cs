using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ayala_PDV.Datos;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Ayala_PDV.Negocios
{
    class ControlVentas : IEVentas
    {
        private List<Producto> productos = new List<Producto>();
        

        public ControlVentas()
        {
            
        }

        public DataTable ObtenerReporteVentas(DateTime inicio, DateTime fin, bool calendarizado)
        {
            if(!calendarizado)
                return ConexionSQL.Instance.SelectQuery("SELECT idVenta as 'No.Venta', fecha as 'Fecha', monto as 'Monto', concretada as 'Concretada' FROM Ventas");
            else
            {
                string s1 = ConvertidorFechaReporte(inicio);
                string s2 = ConvertidorFechaReporte(fin);
                return ConexionSQL.Instance.SelectQuery("SELECT idVenta as 'No.Venta', fecha as 'Fecha', monto as 'Monto', concretada as 'Concretada' FROM Ventas WHERE fecha BETWEEN '" + s1 + "' AND '" + s2 + "'");
            }
        }

        public DataTable ObtenerDetalleVentas(int id)
        {
            return ConexionSQL.Instance.SelectQuery("SELECT dv.idDetalleVentas 'No.Detalle de venta', p.nombre 'Nombre', dv.cantidad as 'Cantidad', p.precio 'Precio' FROM DetalleVentas dv join Productos p  on dv.idProducto = p.idProducto where dv.idVenta = " + id);
        }

        public string ConvertidorFecha(DateTime datetime)
        {
            string formato = "{0}-{1}-{2} {3}:{4}";
            return string.Format(formato, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute);
        }

        public string ConvertidorFechaReporte(DateTime datetime)
        {
            string s = "" + datetime.Year + "-";

            if(datetime.Month.ToString().Length == 1)
                s += "0" + datetime.Month + "-";
            else
                s += datetime.Month + "-";

            if (datetime.Day.ToString().Length == 1)
                s += "0" + datetime.Day;
            else
                s += datetime.Day;
            return s;
        }

        public void RealizarVenta(Venta venta)
        {
            //Insertando en Ventas
            long idVenta = venta.getId();
            string fecha = ConvertidorFechaReporte(venta.getFecha());
            double monto = venta.getMonto();
            ConexionSQL.Instance.InsertQuery("INSERT INTO Ventas VALUES (" + idVenta + ", '" + fecha + "', " + monto + ", 1)");

            //Insertando en DetalleVentas
            Producto producto;
            long idDetalleVentas;
            int cantidad;
            long idProducto;
            double precio;

            for (int i = 0; i < productos.Count; i++)
            {
                producto = productos[i];
                idDetalleVentas = NoDetalleVentas();
                idProducto = producto.getId();
                precio = producto.getPrecio();
                cantidad = producto.getCantidad();

                ConexionSQL.Instance.InsertQuery("INSERT INTO DetalleVentas VALUES (" + idDetalleVentas + ", " + idVenta + ", " + idProducto + ", " + cantidad + ", " + precio + ")");
                producto.setExistencia(producto.getExistencia() - cantidad);
                FachadaNegocios.Instance.ModificarProducto(producto);
            }
        }

        public void DesactivarVenta(long id)
        {
            string query = "UPDATE Ventas SET concretada = 0 WHERE idVenta = " + id;
            Console.WriteLine(query);
            ConexionSQL.Instance.InsertQuery(query);

            query = "SELECT idProducto, cantidad FROM DetalleVentas where idVenta = " + id;
            Console.WriteLine(query);

            DataTable dt = ConexionSQL.Instance.SelectQuery(query);
            long[] ids = new long[dt.Rows.Count];
            long[] existenciasADevolver = new long[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = dt.Rows[i].Field<Int64>(0);
                existenciasADevolver[i] = dt.Rows[i].Field<Int64>(1);
            }

            query = "SELECT existencia FROM productos WHERE idProducto = " + ids[0];
            
            for (int i = 1; i < ids.Length; i++)
                query += " OR idProducto = " + ids[i];

            dt = ConexionSQL.Instance.SelectQuery(query);
            Console.WriteLine(query);

            for (int i = 0; i < ids.Length; i++)
            {
                Console.WriteLine("DT: " + dt.Rows[i].Field<int>(0) + " Array: " + existenciasADevolver[i]);
                query = "UPDATE Productos SET existencia = " + (dt.Rows[i].Field<int>(0) + existenciasADevolver[i]) + " WHERE idProducto = " + ids[i];
                Console.WriteLine(query);

                ConexionSQL.Instance.InsertQuery(query);
            }
        }

        public void CancelarVenta()
        {
            productos = new List<Producto>();
        }

        public void AgregarProductoVenta(Producto producto)
        {
            for (int i = 0; i < productos.Count; i++)
                if (productos[i].getId() == producto.getId())
                {
                    productos[i].ActualizarCantidad(1);
                    return;
                }

            productos.Add(producto);
        }

        public bool VerificarProductoRepetido(Producto producto)
        {
            if (productos.Count == 0)
            {
                productos.Add(producto);
                return false;
            }
            else
                for (int i = 0; i < productos.Count; i++)
                    if (productos[i].getId() == producto.getId())
                        return true;
                return false;
        }

        public void EliminarProductoVenta(Producto producto)
        {
            for (int i = 0; i < productos.Count; i++)
                if (producto.getId() == productos[i].getId())
                    if (productos[i].getCantidad() > 0)
                    {
                        productos[i].ActualizarCantidad(-1);
                        if (productos[i].getCantidad() == 0)
                            productos.RemoveAt(i);
                    }
                    else
                        break;
        }

        public long NoVentas()
        {
            if (ConexionSQL.Instance.SelectQuery("SELECT idVenta FROM Ventas ORDER BY idVenta DESC LIMIT 1").Rows.Count == 0)
                return 1;
            else
                return ConexionSQL.Instance.SelectQuery("SELECT idVenta FROM Ventas ORDER BY idVenta DESC LIMIT 1").Rows[0].Field<Int64>(0) + 1;
        }

        public long NoDetalleVentas()
        {
            if (ConexionSQL.Instance.SelectQuery("SELECT idDetalleVentas FROM DetalleVentas ORDER BY idDetalleVentas DESC LIMIT 1").Rows.Count == 0)
                return 1;
            else
                return ConexionSQL.Instance.SelectQuery("SELECT idDetalleVentas FROM DetalleVentas ORDER BY idDetalleVentas DESC LIMIT 1").Rows[0].Field<Int64>(0) + 1;
        }

    }
}
