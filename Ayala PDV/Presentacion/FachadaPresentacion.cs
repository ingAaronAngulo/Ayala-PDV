//Código creado por Aarón Angulousing System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayala_PDV.Presentacion
{
    class FachadaPresentacion
    {
        private static FachadaPresentacion instance;
        private FachadaPresentacion()
        {

        }

        public static FachadaPresentacion Instance
        {
            get
            {
                if (instance == null)
                    instance = new FachadaPresentacion();
                return instance;
            }
        }
    }
}
