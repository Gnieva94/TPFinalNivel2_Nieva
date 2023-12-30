﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViewForms
{
    public partial class frmAlta : Form
    {
        private Articulo _articulo = null;
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
                _action = false;
                cbxCategoria.DataSource = nCategoria.GetAll();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";
                cbxMarca.DataSource = nMarca.GetAll();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var nArticulo = new NArticulo();
            try
            {
                
                if (_articulo == null) _articulo = new Articulo();
                _articulo.Codigo = tbxCodigo.Text;
                _articulo.Nombre = tbxNombre.Text;
                _articulo.Descripcion = tbxDescripcion.Text;
                _articulo.Marca = (Marca)cbxMarca.SelectedItem;
                _articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                _articulo.ImagenUrl = tbxImagenUrl.Text;
                _articulo.Precio = Decimal.Parse(tbxPrecio.Text);
                Console.WriteLine(_articulo.Precio);
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
