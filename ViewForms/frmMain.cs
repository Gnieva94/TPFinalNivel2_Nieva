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
        private List<Categoria> _listCategorias;
        private List<Articulo> _listArticulosCategorias;
        private List<Articulo> _listaFiltrada;
        private string _cbxFiltroCat;
        private bool _action = false;

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var nCategoria = new NCategoria();
            _listCategorias = nCategoria.GetAll();
            _listCategorias.Insert(0, new Categoria { Id = 0, Descripcion = "CATEGORIA" });
            cbxFiltroCategoria.DataSource = _listCategorias;
            cbxFiltroCategoria.ValueMember = "Id";
            cbxFiltroCategoria.DisplayMember = "Descripcion";
            LoadForm();
        }
        private void LoadForm()
        {
            var nArticulo = new NArticulo();
            
            try
            {
                _listArticulos = nArticulo.GetAll();
                if (_action)
                {
                    if (_cbxFiltroCat != "CATEGORIA")
                    {
                        _listArticulosCategorias = _listArticulos.FindAll(x => x.Categoria.Descripcion == _cbxFiltroCat);
                        if(tbxBuscar.Text != "")
                        {
                            _listaFiltrada = _listArticulosCategorias.FindAll(x => x.Nombre.ToUpper().Contains(tbxBuscar.Text.ToUpper()));
                            dgvArticulos.DataSource = null;
                            dgvArticulos.DataSource = _listaFiltrada;
                        }
                        else
                        {
                            dgvArticulos.DataSource = null;
                            dgvArticulos.DataSource = _listArticulosCategorias;
                        }
                    }
                    else
                    {
                        if (tbxBuscar.Text != "")
                        {
                            _listaFiltrada = _listArticulos.FindAll(x => x.Nombre.ToUpper().Contains( tbxBuscar.Text.ToUpper()));
                            dgvArticulos.DataSource = null;
                            dgvArticulos.DataSource = _listaFiltrada;
                        }
                        else
                        {
                            dgvArticulos.DataSource = null;
                            dgvArticulos.DataSource = _listArticulos;
                        }
                    }
                }
                else
                {
                    dgvArticulos.DataSource = _listArticulos;
                }
                HideColumns();
                ImageLoad(_listArticulos[0].ImagenUrl);
                _action = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                var articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                ImageLoad(articuloSeleccionado.ImagenUrl);
            }
            else
            {
                ImageLoad("");
            }
        }

        private void tbxBuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = tbxBuscar.Text;
            var opcion = cbxFiltroCategoria.SelectedItem.ToString();
            
            if (_listArticulosCategorias != null && opcion != "CATEGORIA")
            {
                if (filtro != "" && filtro.Length >= 3) _listaFiltrada = _listArticulosCategorias.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                else _listaFiltrada = _listArticulosCategorias;
            }
            else
            {
                if (filtro != "" && filtro.Length >= 3) _listaFiltrada = _listArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                else _listaFiltrada = _listArticulos;
            }
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = _listaFiltrada;
            HideColumns();
        }
        private void cbxFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbxFiltroCat = cbxFiltroCategoria.SelectedItem.ToString();
            if (_listArticulos != null)
            {
                if(_cbxFiltroCat == "CATEGORIA")
                {
                    tbxBuscar.Text = "";
                    _listArticulosCategorias = null;
                    dgvArticulos.DataSource = null;
                    dgvArticulos.DataSource = _listArticulos;
                    HideColumns();
                }
                else
                {
                    tbxBuscar.Text = "";
                    _listArticulosCategorias = _listArticulos.FindAll(x => x.Categoria.Descripcion == _cbxFiltroCat);
                    dgvArticulos.DataSource = null;
                    dgvArticulos.DataSource = _listArticulosCategorias;
                    HideColumns();
                }
                
            }
            
        }
        public void HideColumns()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }

        private void ImageLoad(string url)
        {
            try
            {
                pbxArticulo.Load(url);
            }
            catch (Exception)
            {
                try
                {
                    pbxArticulo.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frmAlta = new frmAlta();
            frmAlta.ShowDialog();
            _action = frmAlta.GetActionState();
            LoadForm();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un articulo de la grilla.");
                    return;
                }
                var seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                var frmAlta = new frmAlta(seleccionado);
                frmAlta.ShowDialog();
                _action = frmAlta.GetActionState();
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
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un articulo de la grilla.");
                    return;
                }
                DialogResult result = MessageBox.Show("¿De verdad quieres eliminar el articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    _action = nArticulo.Delete(seleccionado);
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un articulo de la grilla.");
                    return;
                }
                var seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                var frmAlta = new frmAlta(seleccionado,true);
                frmAlta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
