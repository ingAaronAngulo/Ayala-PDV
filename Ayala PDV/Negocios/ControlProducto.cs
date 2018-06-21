using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ayala_PDV.Datos;
using System.Windows.Forms;

namespace Ayala_PDV.Negocios
{
    class ControlProducto : IEControlProducto
    {
        public ControlProducto()
        {
            
        }

        public Producto ObtenerProducto(string codigo, bool activado)
        {
            Producto producto;
            try
            {
                string query;
                if (activado)
                    query = "SELECT * FROM Productos WHERE codigo= '" + codigo + "' AND activado = 1";
                else
                    query = "SELECT * FROM Productos WHERE codigo= '" + codigo + "'";

                DataTable dt = ConexionSQL.Instance.SelectQuery(query);
                Console.WriteLine(query);
                producto = new Producto(dt.Rows[0].Field<Int64>(0), dt.Rows[0].Field<string>(1), dt.Rows[0].Field<string>(2), dt.Rows[0].Field<int>(3), dt.Rows[0].Field<string>(4), dt.Rows[0].Field<double>(5), dt.Rows[0].Field<string>(6), dt.Rows[0].Field<int>(7), dt.Rows[0].Field<int>(8));
                Console.Write(producto.ToString());
                return producto;
            }
            catch(Exception e)
            {
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public DataTable ObtenerProductos(string campo, string valor)
        {
            if (campo == null)
                return ConexionSQL.Instance.SelectQuery("SELECT idProducto as 'ID producto', nombre as 'Nombre', distribuidor as 'Distribuidor', existencia as 'Existencia', codigo 'Código', precio as 'Precio', origen 'Origen', existenciaMinima as 'Existencia minima' FROM Productos WHERE activado = 1");
            else
                return ConexionSQL.Instance.SelectQuery("SELECT idProducto as 'ID producto', nombre as 'Nombre', distribuidor as 'Distribuidor', existencia as 'Existencia', codigo 'Código', precio as 'Precio', origen 'Origen', existenciaMinima as 'Existencia minima' FROM Productos WHERE activado = 1 AND " + campo + " LIKE '" + valor + "%'");
        }

        public void AgregarProducto(Producto producto)
        {
            long id = producto.getId();
            string nombre = producto.getNombre();
            string distribuidor = producto.getDistribuidor();
            int existencia = producto.getExistencia();
            string codigo = producto.getCodigo();
            double precio = producto.getPrecio();
            string origen = producto.getOrigen();
            int existenciaMinima = producto.getExistenciaMinima();
            
            ConexionSQL.Instance.InsertQuery("INSERT INTO Productos VALUES (" + id + ", '" + nombre + "', '" + distribuidor + "', " + existencia + ", '" + codigo + "', " + precio + ", '" + origen + "', " + existenciaMinima + ", 1)");
        }

        public void ModificarProducto(Producto producto)
        {
            long id = producto.getId();
            string nombre = producto.getNombre();
            string distribuidor = producto.getDistribuidor();
            int existencia = producto.getExistencia();
            string codigo = producto.getCodigo();
            double precio = producto.getPrecio();
            string origen = producto.getOrigen();
            int existenciaMinima = producto.getExistenciaMinima();
            int activado = producto.getActivado();

            ConexionSQL.Instance.InsertQuery("UPDATE Productos SET nombre= '" + nombre + "', distribuidor= '" + distribuidor + "', existencia= " + existencia + ", codigo= '" + codigo + "', precio= " + precio + ", origen= '" + origen + "', existenciaMinima= " + existenciaMinima + ", activado= " + activado + " WHERE idProducto= " + id);
        }

        public void EliminarProducto(long id)
        {
            ConexionSQL.Instance.InsertQuery("UPDATE Productos SET activado = 0 WHERE idProducto= " + id);
        }

        //Devuelve el proximo ID a registrar para productos
        public long NoProductos()
        {
            if (ConexionSQL.Instance.SelectQuery("SELECT idProducto FROM Productos ORDER BY idProducto DESC LIMIT 1").Rows.Count == 0)
                return 1;
            else
                return ConexionSQL.Instance.SelectQuery("SELECT idProducto FROM Productos ORDER BY idProducto DESC LIMIT 1").Rows[0].Field<Int64>(0) + 1;
        }
    }
}
