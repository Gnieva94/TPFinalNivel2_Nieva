namespace ViewForms
{
    partial class frmAlta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.tbxImagenUrl = new System.Windows.Forms.TextBox();
            this.lblImagenUrl = new System.Windows.Forms.Label();
            this.tbxPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.lblValNombre = new System.Windows.Forms.Label();
            this.lblValMarca = new System.Windows.Forms.Label();
            this.lblValCat = new System.Windows.Forms.Label();
            this.lblValPrecio = new System.Windows.Forms.Label();
            this.lblValCod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(36, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Location = new System.Drawing.Point(105, 13);
            this.tbxCodigo.MaxLength = 50;
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(145, 20);
            this.tbxCodigo.TabIndex = 0;
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(105, 36);
            this.tbxNombre.MaxLength = 50;
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(145, 20);
            this.tbxNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(32, 39);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Location = new System.Drawing.Point(105, 59);
            this.tbxDescripcion.MaxLength = 150;
            this.tbxDescripcion.Multiline = true;
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDescripcion.Size = new System.Drawing.Size(145, 87);
            this.tbxDescripcion.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 62);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // tbxImagenUrl
            // 
            this.tbxImagenUrl.Location = new System.Drawing.Point(105, 206);
            this.tbxImagenUrl.MaxLength = 1000;
            this.tbxImagenUrl.Name = "tbxImagenUrl";
            this.tbxImagenUrl.Size = new System.Drawing.Size(145, 20);
            this.tbxImagenUrl.TabIndex = 5;
            this.tbxImagenUrl.Leave += new System.EventHandler(this.tbxImagenUrl_Leave);
            // 
            // lblImagenUrl
            // 
            this.lblImagenUrl.AutoSize = true;
            this.lblImagenUrl.Location = new System.Drawing.Point(34, 209);
            this.lblImagenUrl.Name = "lblImagenUrl";
            this.lblImagenUrl.Size = new System.Drawing.Size(45, 13);
            this.lblImagenUrl.TabIndex = 6;
            this.lblImagenUrl.Text = "Imagen:";
            // 
            // tbxPrecio
            // 
            this.tbxPrecio.Location = new System.Drawing.Point(105, 232);
            this.tbxPrecio.Name = "tbxPrecio";
            this.tbxPrecio.Size = new System.Drawing.Size(145, 20);
            this.tbxPrecio.TabIndex = 6;
            this.tbxPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPrecio_KeyPress);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(39, 235);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(39, 155);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 10;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(22, 182);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(57, 13);
            this.lblCategoria.TabIndex = 11;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cbxMarca
            // 
            this.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(105, 152);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(145, 21);
            this.cbxMarca.TabIndex = 3;
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(105, 179);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(145, 21);
            this.cbxCategoria.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(42, 286);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(175, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(319, 13);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(173, 170);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 16;
            this.pbxArticulo.TabStop = false;
            // 
            // lblValNombre
            // 
            this.lblValNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValNombre.Location = new System.Drawing.Point(250, 33);
            this.lblValNombre.Margin = new System.Windows.Forms.Padding(0);
            this.lblValNombre.Name = "lblValNombre";
            this.lblValNombre.Size = new System.Drawing.Size(25, 25);
            this.lblValNombre.TabIndex = 18;
            this.lblValNombre.Text = "❌";
            this.lblValNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValMarca
            // 
            this.lblValMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValMarca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValMarca.Location = new System.Drawing.Point(251, 150);
            this.lblValMarca.Margin = new System.Windows.Forms.Padding(0);
            this.lblValMarca.Name = "lblValMarca";
            this.lblValMarca.Size = new System.Drawing.Size(25, 23);
            this.lblValMarca.TabIndex = 20;
            this.lblValMarca.Text = "❌";
            this.lblValMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValCat
            // 
            this.lblValCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValCat.Location = new System.Drawing.Point(251, 176);
            this.lblValCat.Margin = new System.Windows.Forms.Padding(0);
            this.lblValCat.Name = "lblValCat";
            this.lblValCat.Size = new System.Drawing.Size(24, 22);
            this.lblValCat.TabIndex = 21;
            this.lblValCat.Text = "❌";
            this.lblValCat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValPrecio
            // 
            this.lblValPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValPrecio.Location = new System.Drawing.Point(251, 229);
            this.lblValPrecio.Margin = new System.Windows.Forms.Padding(0);
            this.lblValPrecio.Name = "lblValPrecio";
            this.lblValPrecio.Size = new System.Drawing.Size(24, 22);
            this.lblValPrecio.TabIndex = 23;
            this.lblValPrecio.Text = "❌";
            this.lblValPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValCod
            // 
            this.lblValCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValCod.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblValCod.Location = new System.Drawing.Point(250, 11);
            this.lblValCod.Margin = new System.Windows.Forms.Padding(0);
            this.lblValCod.Name = "lblValCod";
            this.lblValCod.Size = new System.Drawing.Size(24, 22);
            this.lblValCod.TabIndex = 17;
            this.lblValCod.Text = "❌";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Solo hasta 12 cifras.";
            // 
            // frmAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(504, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValPrecio);
            this.Controls.Add(this.lblValCat);
            this.Controls.Add(this.lblValMarca);
            this.Controls.Add(this.lblValNombre);
            this.Controls.Add(this.lblValCod);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.cbxMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.tbxPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.tbxImagenUrl);
            this.Controls.Add(this.lblImagenUrl);
            this.Controls.Add(this.tbxDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Articulo";
            this.Load += new System.EventHandler(this.frmAlta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox tbxImagenUrl;
        private System.Windows.Forms.Label lblImagenUrl;
        private System.Windows.Forms.TextBox tbxPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Label lblValNombre;
        private System.Windows.Forms.Label lblValMarca;
        private System.Windows.Forms.Label lblValCat;
        private System.Windows.Forms.Label lblValPrecio;
        private System.Windows.Forms.Label lblValCod;
        private System.Windows.Forms.Label label1;
    }
}