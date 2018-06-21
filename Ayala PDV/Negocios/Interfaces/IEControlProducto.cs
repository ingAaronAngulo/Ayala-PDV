//Código creado por Aarón Angulo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ayala_PDV.Datos;
using System.Data;

namespace Ayala_PDV.Negocios
{
    interface IEControlProducto
    {
        Producto ObtenerProducto(string codigo, bool activado);
        DataTable ObtenerProductos(string campo, string valor);
        long NoProductos();
        void AgregarProducto(Producto producto);
        void ModificarProducto(Producto producto);
        void EliminarProducto(long id);
    }
}
