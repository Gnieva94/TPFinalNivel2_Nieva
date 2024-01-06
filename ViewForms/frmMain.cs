using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private List<Marca> _listMarcas;
        private List<Articulo> _listArticulosBuscar;
        private List<Articulo> _listaFiltrada;
        private string _cbxCampo;
        private string _cbxBuscar;
        private bool _action = false;

        public frmMain()
        {
            InitializeComponent();
            _cbxCampo = "";
            _cbxBuscar = "";
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var nMarca = new NMarca();
            _listMarcas = nMarca.GetAll();
            //_listMarcas.Insert(0, new Marca { Id = 0, Descripcion = "" });
            var nCategoria = new NCategoria();
            _listCategorias = nCategoria.GetAll();
            //_listCategorias.Insert(0, new Categoria { Id = 0, Descripcion = "" });

            tbxBuscar.Visible = false;
            gpFiltro.Visible = false;
            cbxBuscar.Visible = false;
            cbxCampo.Items.Add("");
            cbxCampo.Items.Add("Código");
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Marca");
            cbxCampo.Items.Add("Categoria");
            cbxCampo.Items.Add("Precio");
            LoadForm();
        }
        private void LoadForm()
        {
            var nArticulo = new NArticulo();
            
            try
            {
                _listArticulos = nArticulo.GetAll();
                if(_cbxCampo != "")
                {
                    switch(_cbxCampo)
                    {
                        case "Código":
                            if(tbxBuscar.Text != "")
                            {
                                _listaFiltrada = _listArticulos.FindAll(x => x.Codigo.ToUpper().Contains(tbxBuscar.Text.ToUpper()));
                                ResetDgv(_listaFiltrada);
                            }
                            else if(tbxFiltro.Text != "")
                            {
                                _listaFiltrada = nArticulo.Filter(cbxCampo.SelectedItem.ToString(), _cbxBuscar, cbxCriterio.SelectedItem.ToString(), tbxFiltro.Text);
                                ResetDgv(_listaFiltrada);
                            }
                            else
                            {
                                ResetDgv(_listArticulos);
                            }

                            break;
                        case "Nombre":
                            if(!string.IsNullOrEmpty(tbxBuscar.Text))
                            {
                                _listaFiltrada = _listArticulos.FindAll(x => x.Nombre.ToUpper().Contains(tbxBuscar.Text.ToUpper()));
                                ResetDgv(_listaFiltrada);
                            }
                            else if (tbxFiltro.Text != "")
                            {
                                _listaFiltrada = nArticulo.Filter(cbxCampo.SelectedItem.ToString(), _cbxBuscar, cbxCriterio.SelectedItem.ToString(), tbxFiltro.Text);
                                ResetDgv(_listaFiltrada);
                            }
                            else
                            {
                                ResetDgv(_listArticulos);
                            }
                            break;
                        case "Marca":
                            if(_cbxBuscar != "")
                            {
                                if (tbxFiltro.Text != "")
                                {
                                    _listaFiltrada = nArticulo.Filter(cbxCampo.SelectedItem.ToString(), _cbxBuscar, cbxCriterio.SelectedItem.ToString(), tbxFiltro.Text);
                                    ResetDgv(_listaFiltrada);
                                }
                                else
                                {
                                    _listaFiltrada = _listArticulos.FindAll(x => x.Marca.Descripcion == _cbxBuscar);
                                    ResetDgv(_listaFiltrada);
                                }
                            }
                            break;
                        case "Categoria":
                            if(_cbxBuscar != "")
                            {
                                if (tbxFiltro.Text != "")
                                {
                                    _listaFiltrada = nArticulo.Filter(cbxCampo.SelectedItem.ToString(), _cbxBuscar, cbxCriterio.SelectedItem.ToString(), tbxFiltro.Text);
                                    ResetDgv(_listaFiltrada);
                                }
                                else
                                {
                                    _listaFiltrada = _listArticulos.FindAll(x => x.Categoria.Descripcion == _cbxBuscar);
                                    ResetDgv(_listaFiltrada);
                                }
                            }
                            break;
                        case "Precio":
                            if (tbxFiltro.Text != "")
                            {
                                _listaFiltrada = nArticulo.Filter(cbxCampo.SelectedItem.ToString(), _cbxBuscar, cbxCriterio.SelectedItem.ToString(), tbxFiltro.Text);
                                ResetDgv(_listaFiltrada);
                            }
                            else
                            {
                                ResetDgv(_listArticulos);
                            }
                            break;
                    }
                }
                else
                {
                    ResetDgv(_listArticulos);
                }
                
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
            if (filtro != "" && filtro.Length >= 3)
            {
                btnAgregar.Enabled = false;
                _listaFiltrada = _cbxCampo == "Código" ? _listArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper())) : _listArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else 
            {
                btnAgregar.Enabled = true;
                _listaFiltrada = _listArticulos; 
            }
            ResetDgv(_listaFiltrada);
        }

        public void HideColumns()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "$#,###.00";
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
            if(_action) LoadForm();
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
                if (_action) LoadForm();
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
                    if (_action) LoadForm();
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

        private void cbxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxBuscar.SelectedIndex > -1)
            {
                _cbxBuscar = cbxBuscar.SelectedItem.ToString();
                tbxFiltro.Text = "";
                if (_cbxBuscar == "")
                {
                    gpFiltro.Visible = false;
                    _listArticulosBuscar = null;
                    ResetDgv(_listArticulos);
                }
                else
                {
                    gpFiltro.Visible = true;
                    cbxCampoLoad(_cbxCampo);
                    _listArticulosBuscar = _cbxCampo == "Categoria" ? _listArticulos.FindAll(x => x.Categoria.Descripcion == _cbxBuscar) : _listArticulos.FindAll(x => x.Marca.Descripcion == _cbxBuscar);
                    if (_listArticulosBuscar.Count > 0) gpFiltro.Enabled = true;
                    else gpFiltro.Enabled = false;
                    ResetDgv(_listArticulosBuscar);
                }
            }
            
        }

        private void cbxCampoLoad(string cbxCampo)
        {
            cbxCriterio.Items.Clear();
            if (cbxCampo == "Código" || cbxCampo == "Nombre")
            {
                cbxCriterio.Items.Add("Empieza con");
                cbxCriterio.Items.Add("Termina con");
                cbxCriterio.Items.Add("Contiene");
            }
            else
            {
                cbxCriterio.Items.Add(">");
                cbxCriterio.Items.Add(">=");
                cbxCriterio.Items.Add("<");
                cbxCriterio.Items.Add("<=");
                cbxCriterio.Items.Add("=");
            }
        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxFiltro.Text = "";
            tbxBuscar.Text = "";
            _cbxCampo = cbxCampo.SelectedItem.ToString();
            ResetDgv(_listArticulos);
            if(_cbxCampo != "")
            {
                gpFiltro.Visible = true;
                gpFiltro.Enabled = true;
                cbxCampoLoad(_cbxCampo);
            }
            else
            {
                gpFiltro.Visible = false;
            }
            switch (_cbxCampo)
            {
                case "":
                    cbxBuscar.Visible = false;
                    tbxBuscar.Visible = false;
                    break;
                case "Código":
                    tbxBuscar.Visible = true;
                    lblCampo.Text = "Código";
                    cbxBuscar.Visible = false;
                    break;
                case "Nombre":
                    tbxBuscar.Visible = true;
                    lblCampo.Text = "Nombre";
                    cbxBuscar.Visible = false;
                    break;
                case "Marca":
                    tbxBuscar.Visible = false;
                    gpFiltro.Visible = false;
                    lblCampo.Text = "Precio";
                    cbxBuscar.Visible = true;
                    cbxBuscar.SelectedIndexChanged -= cbxBuscar_SelectedIndexChanged;
                    cbxBuscar.DataSource = _listMarcas;
                    cbxBuscar.ValueMember = "Id";
                    cbxBuscar.DisplayMember = "Descripcion";
                    cbxBuscar.SelectedIndex = -1;
                    cbxBuscar.SelectedIndexChanged += cbxBuscar_SelectedIndexChanged;

                    break;
                case "Categoria":
                    tbxBuscar.Visible = false;
                    gpFiltro.Visible = false;
                    lblCampo.Text = "Precio";
                    cbxBuscar.Visible = true;
                    cbxBuscar.SelectedIndexChanged -= cbxBuscar_SelectedIndexChanged;
                    cbxBuscar.DataSource = _listCategorias;
                    cbxBuscar.ValueMember = "Id";
                    cbxBuscar.DisplayMember = "Descripcion";
                    cbxBuscar.SelectedIndex = -1;
                    cbxBuscar.SelectedIndexChanged += cbxBuscar_SelectedIndexChanged;
                    break;
                case "Precio":
                    tbxBuscar.Visible = false;
                    cbxBuscar.Visible = false;
                    lblCampo.Text = "Precio";
                    cbxCampoLoad(_cbxCampo);

                    break;
            }
        }

        private void btnFiltroBuscar_Click(object sender, EventArgs e)
        {
            var nArticulo = new NArticulo();
            try
            {
                btnAgregar.Enabled = false;
                string campo;
                if (cbxCampo.SelectedItem != null) campo = cbxCampo.SelectedItem.ToString();
                else 
                {
                    MessageBox.Show("Debes elegir un campo");
                    return;
                }
                string criterio;
                if(cbxCriterio.SelectedItem != null) criterio = cbxCriterio.SelectedItem.ToString();
                else
                {
                    MessageBox.Show("Debes elegir un criterio");
                    return;
                }

                var filtro = tbxFiltro.Text;


                if(campo != "" && criterio != "" && filtro != "")
                {
                    tbxBuscar.Text = "";
                    string campoSecundario = "";
                    if(_cbxBuscar != "") campoSecundario = _cbxBuscar;
                    _listaFiltrada = nArticulo.Filter(campo, campoSecundario, criterio, filtro );
                    ResetDgv(_listaFiltrada);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            tbxFiltro.Text = "";
            cbxCampoLoad(_cbxCampo);
            if(_cbxCampo == "Categoria" || _cbxCampo == "Marca")
            {
                ResetDgv(_listArticulosBuscar);
            }
            else
            {
                ResetDgv(_listArticulos);
            }
        }

        private void ResetDgv<T>(List<T> lista)
        {
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = lista;
            if (lista.Count == 0) ImageLoad("");
            HideColumns();
        }
    }
}
