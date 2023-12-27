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
            LoadForm();
        }
        private void LoadForm()
        {
            var nArticulo = new NArticulo();
            try
            {
                _listArticulos = nArticulo.GetAll();
                dgvArticulos.DataSource = _listArticulos;
                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                ImageLoad(_listArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            var articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            ImageLoad(articuloSeleccionado.ImagenUrl);
        }

        private void ImageLoad(string url)
        {
            try
            {
                pbxArticulo.Load(url);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frmAlta = new frmAlta();
            frmAlta.ShowDialog();
            LoadForm();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                var seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                var frmAlta = new frmAlta(seleccionado);
                frmAlta.ShowDialog();
                LoadForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var nArticulo = new NArticulo();
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad quieres eliminar el articulo?","Eliminando",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    var seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    nArticulo.Delete(seleccionado);
                    LoadForm();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
