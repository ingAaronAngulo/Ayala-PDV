//Código creado por Aarón Angulo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayala_PDV.Datos
{
    class Venta
    {
        private long id;
        private DateTime fecha;
        private double monto;

        public Venta()
        {
            
        }

        public Venta(long id, DateTime fecha, double monto)
        {
            this.id = id;
            this.fecha = fecha;
            this.monto = monto;
        }

        public long getId()
        {
            return id;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public double getMonto()
        {
            return monto;
        }
    }
}
