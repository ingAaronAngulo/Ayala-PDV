//Código creado por Aarón Angulo

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
    public partial class FrmProductosRegistrados : Form
    {
        public FrmProductosRegistrados()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            TablaProducto.DataSource = FachadaNegocios.Instance.ObtenerProductos(null, null);
            TablaProducto.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }
    }
}
