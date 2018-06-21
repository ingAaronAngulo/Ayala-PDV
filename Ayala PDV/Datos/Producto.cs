using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ayala_PDV.Datos
{
    class Producto
    {
        private long id;
        private string nombre;
        private string distribuidor;
        private int existencia;
        private string codigo;
        private double precio;
        private string origen;
        private int existenciaMinima;
        private int activado;

        private int cantidad;
        public Producto()
        {

        }

        public Producto(long id, string nombre, string distribuidor, int existencia, string codigo, double precio, string origen, int existenciaMinima, int activado)
        {
            this.id = id;
            this.nombre = nombre;
            this.distribuidor = distribuidor;
            this.existencia = existencia;
            this.codigo = codigo;
            this.precio = precio;
            this.origen = origen;
            this.existenciaMinima = existenciaMinima;
            this.activado = activado;

            cantidad = 1;
        }

        public long getId()
        {
            return id;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getDistribuidor()
        {
            return distribuidor;
        }

        public void setExistencia(int existencia)
        {
            this.existencia = existencia;
        }
        public int getExistencia()
        {
            return existencia;
        }

        public string getCodigo()
        {
            return codigo;
        }

        public double getPrecio()
        {
            return precio;
        }
        
        public string getOrigen()
        {
            return origen;
        }

        public int getExistenciaMinima()
        {
            return existenciaMinima;
        }

        public int getActivado()
        {
            return activado;
        }

        public int getCantidad()
        {
            return cantidad;
        }

        public void ActualizarCantidad(int incremento)
        {
            cantidad += incremento;
        }

        public override string ToString()
        {
            return "ID:" + id + ", nombre:" + nombre + ", distribuidor:" + "existencia:" + existencia + ", codigo:" + codigo + ", precio:" + precio + ", origen:" + origen + ", existencia minima:" + existenciaMinima + ", activado:" + activado;
        }
    }
}
