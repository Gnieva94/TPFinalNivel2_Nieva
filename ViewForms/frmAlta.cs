using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace ViewForms
{
    public partial class frmAlta : Form
    {
        private Articulo _articulo = null;
        private List<Categoria> _listCategoria;
        private List<Marca> _listMarca;
        private bool _detalle = false;
        private bool _action = false;
        public frmAlta()
        {
            InitializeComponent();
        }
        public frmAlta(Articulo articulo, bool detalle = false)
        {
            InitializeComponent();
            _articulo = articulo;
            if(detalle)
            {
                Text = "Detalle Articulo";
                _detalle = detalle;
            }
            else
            {
                Text = "Modificar Articulo";
            }
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            var nCategoria = new NCategoria();
            var nMarca = new NMarca();
            try
            {
                VisibleValidateLabel(false);
                _action = false;
                _listCategoria = nCategoria.GetAll();
                cbxCategoria.DataSource = _listCategoria;
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.SelectedIndex = -1;
                _listMarca = nMarca.GetAll();
                cbxMarca.DataSource = _listMarca;
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";
                cbxMarca.SelectedIndex = -1;

                if (_articulo != null)
                {
                    tbxCodigo.Text = _articulo.Codigo;
                    tbxNombre.Text = _articulo.Nombre;
                    tbxDescripcion.Text = _articulo.Descripcion;
                    cbxCategoria.SelectedValue = _articulo.Categoria.Id;
                    cbxMarca.SelectedValue = _articulo.Marca.Id;
                    tbxImagenUrl.Text = _articulo.ImagenUrl;
                    ImageLoad(_articulo.ImagenUrl);
                    tbxPrecio.Text = _articulo.Precio.ToString();
                }
                if (_detalle)
                {
                    btnAceptar.Visible = false;
                    tbxCodigo.ReadOnly = true;
                    tbxCodigo.TabStop = false;
                    tbxNombre.ReadOnly = true;
                    tbxNombre.TabStop = false;
                    tbxDescripcion.ReadOnly = true;
                    tbxDescripcion.TabStop = false;
                    cbxCategoria.Enabled = false;
                    cbxCategoria.TabStop = false;
                    cbxMarca.Enabled = false;
                    cbxMarca.TabStop = false;
                    tbxImagenUrl.ReadOnly = true;
                    tbxImagenUrl.TabStop = false;
                    tbxPrecio.ReadOnly = true;
                    tbxPrecio.TabStop = false;
                    tbxPrecio.Text = _articulo.Precio.ToString("$#,###.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private bool SoloDoceCifras(string numero)
        {
            var cadena = numero.Split(',');
            return cadena[0].Length <= 12;
        }

        private bool ValidateDecimal(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("El campo Precio no puede estar vacío");
                return false;
            }

            decimal result;
            if (!decimal.TryParse(input, out result))
            {
                MessageBox.Show("Decimal no válido");
                return false;
            }


            if (result != Math.Round(result, 2))
            {
                MessageBox.Show("El precio solo debe tener dos decimales");
                return false;
            }

            if (input.StartsWith("-") || input.EndsWith("-")) return false;

            if (!SoloDoceCifras(input)) return false;

            return true;
        }

        private bool ValidarAlta()
        {
            bool retornar = false;
            VisibleValidateLabel(true);
            if (tbxCodigo.Text.Length == 0)
            {
                lblValCod.Text = "❌";
                retornar = true;
            }
            else
            {
                lblValCod.Text = "✔";
            }
            if(tbxNombre.Text.Length == 0)
            {
                lblValNombre.Text = "❌";
                retornar = true;
            }
            else
            {
                lblValNombre.Text = "✔";
            }
            if(cbxMarca.SelectedIndex == -1)
            {
                lblValMarca.Text = "❌";
                retornar = true;
            }
            else
            {
                lblValMarca.Text = "✔";
            }
            if(cbxCategoria.SelectedIndex == -1)
            {
                lblValCat.Text = "❌";
                retornar = true;
            }
            else
            {
                lblValCat.Text = "✔";
            }
            if (!ValidateDecimal(tbxPrecio.Text))
            {
                
                lblValPrecio.Text = "❌";
                retornar = true;
            }
            else
            {
                lblValPrecio.Text = "✔";
            }
            return retornar;
        }

        private void VisibleValidateLabel(bool state)
        {
            lblValCod.Visible = state;
            lblValNombre.Visible = state;
            lblValMarca.Visible = state;
            lblValCat.Visible = state;
            lblValPrecio.Visible = state;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var nArticulo = new NArticulo();
            try
            {
                if (ValidarAlta()) return;
                
                if (_articulo == null) _articulo = new Articulo();
                _articulo.Codigo = tbxCodigo.Text;
                _articulo.Nombre = tbxNombre.Text;
                _articulo.Descripcion = tbxDescripcion.Text;
                _articulo.Marca = (Marca)cbxMarca.SelectedItem;
                _articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                _articulo.ImagenUrl = tbxImagenUrl.Text;
                _articulo.Precio = Decimal.Parse(tbxPrecio.Text);

                if(_articulo.Id != 0)
                {
                    if (nArticulo.Modify(_articulo))
                    {
                        MessageBox.Show("Modificado exitosamente.");
                        _action = true;
                    }
                    else MessageBox.Show("No pudo ser modificado el articulo.");
                }
                else
                {
                    if (nArticulo.Insert(_articulo))
                    {
                        MessageBox.Show("Insertado exitosamente.");
                        VisibleValidateLabel(false);
                        tbxCodigo.Text = "";
                        tbxNombre.Text = "";
                        tbxDescripcion.Text = "";
                        cbxCategoria.SelectedIndex = -1;
                        cbxMarca.SelectedIndex = -1;
                        tbxImagenUrl.Text = "";
                        tbxPrecio.Text = "";
                        _action = true;
                    }
                    else MessageBox.Show("No pudo ser insertado el articulo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void tbxImagenUrl_Leave(object sender, EventArgs e)
        {
            ImageLoad(tbxImagenUrl.Text);
        }

        public bool GetActionState() { return _action; }

        private void tbxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                // Reemplazar el punto por la coma
                e.KeyChar = ',';
            }
        }

    }
}
