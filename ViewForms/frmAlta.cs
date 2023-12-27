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

namespace ViewForms
{
    public partial class frmAlta : Form
    {
        private Articulo _articulo = null;
        public frmAlta()
        {
            InitializeComponent();
        }
        public frmAlta(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            var nCategoria = new NCategoria();
            var nMarca = new NMarca();
            try
            {
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
                if(_articulo.Id != 0)
                {
                    if(nArticulo.Modify(_articulo)) MessageBox.Show("Modificado exitosamente.");
                    else MessageBox.Show("No pudo ser modificado el articulo.");
                }
                else
                {
                    if (nArticulo.Insert(_articulo)) MessageBox.Show("Insertado exitosamente.");
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
    }
}