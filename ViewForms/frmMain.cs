using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace ViewForms
{
    public partial class frmMain : Form
    {
        private List<Articulo> _listArticulos;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var negocio = new NArticulo();
            _listArticulos = negocio.GetAll();
            dgvArticulos.DataSource = _listArticulos;
            pbxArticulo.Load(_listArticulos[0].ImagenUrl);
        }
    }
}
