namespace TP4
{
    partial class formPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.dataGProductosDisponibles = new System.Windows.Forms.DataGridView();
            this.lblProductos = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.textCantidadEnCarrito = new System.Windows.Forms.TextBox();
            this.textTotalAPagar = new System.Windows.Forms.TextBox();
            this.gpbCliente = new System.Windows.Forms.GroupBox();
            this.grbTipoDeOperacion = new System.Windows.Forms.GroupBox();
            this.rdbCompra = new System.Windows.Forms.RadioButton();
            this.rdbAlquiler = new System.Windows.Forms.RadioButton();
            this.btnAceptarCliente = new System.Windows.Forms.Button();
            this.lblDniCliente = new System.Windows.Forms.Label();
            this.lblApellidoCliente = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblAgregarSeleccionado = new System.Windows.Forms.Label();
            this.btnAgregarACarrito = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidadProductos = new System.Windows.Forms.Label();
            this.lblTotalAPagar = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmarPedido = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGProductosDisponibles)).BeginInit();
            this.gpbCliente.SuspendLayout();
            this.grbTipoDeOperacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGProductosDisponibles
            // 
            this.dataGProductosDisponibles.AllowUserToAddRows = false;
            this.dataGProductosDisponibles.AllowUserToDeleteRows = false;
            this.dataGProductosDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGProductosDisponibles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGProductosDisponibles.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGProductosDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGProductosDisponibles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGProductosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGProductosDisponibles.Location = new System.Drawing.Point(2, 72);
            this.dataGProductosDisponibles.MultiSelect = false;
            this.dataGProductosDisponibles.Name = "dataGProductosDisponibles";
            this.dataGProductosDisponibles.ReadOnly = true;
            this.dataGProductosDisponibles.RowHeadersWidth = 20;
            this.dataGProductosDisponibles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGProductosDisponibles.RowTemplate.Height = 24;
            this.dataGProductosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGProductosDisponibles.ShowCellErrors = false;
            this.dataGProductosDisponibles.ShowCellToolTips = false;
            this.dataGProductosDisponibles.ShowEditingIcon = false;
            this.dataGProductosDisponibles.ShowRowErrors = false;
            this.dataGProductosDisponibles.Size = new System.Drawing.Size(397, 280);
            this.dataGProductosDisponibles.TabIndex = 0;
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(2, 22);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(295, 32);
            this.lblProductos.TabIndex = 1;
            this.lblProductos.Text = "Productos disponibles";
            // 
            // textNombre
            // 
            this.textNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(207, 77);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(267, 30);
            this.textNombre.TabIndex = 2;
            // 
            // textApellido
            // 
            this.textApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellido.Location = new System.Drawing.Point(207, 133);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(267, 30);
            this.textApellido.TabIndex = 3;
            // 
            // textDni
            // 
            this.textDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDni.Location = new System.Drawing.Point(207, 189);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(267, 30);
            this.textDni.TabIndex = 4;
            // 
            // textCantidad
            // 
            this.textCantidad.Location = new System.Drawing.Point(255, 393);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(144, 22);
            this.textCantidad.TabIndex = 5;
            // 
            // textCantidadEnCarrito
            // 
            this.textCantidadEnCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCantidadEnCarrito.Location = new System.Drawing.Point(255, 515);
            this.textCantidadEnCarrito.Name = "textCantidadEnCarrito";
            this.textCantidadEnCarrito.Size = new System.Drawing.Size(144, 30);
            this.textCantidadEnCarrito.TabIndex = 6;
            // 
            // textTotalAPagar
            // 
            this.textTotalAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalAPagar.Location = new System.Drawing.Point(255, 559);
            this.textTotalAPagar.Name = "textTotalAPagar";
            this.textTotalAPagar.Size = new System.Drawing.Size(144, 30);
            this.textTotalAPagar.TabIndex = 7;
            // 
            // gpbCliente
            // 
            this.gpbCliente.BackColor = System.Drawing.Color.Transparent;
            this.gpbCliente.Controls.Add(this.grbTipoDeOperacion);
            this.gpbCliente.Controls.Add(this.btnAceptarCliente);
            this.gpbCliente.Controls.Add(this.lblDniCliente);
            this.gpbCliente.Controls.Add(this.lblApellidoCliente);
            this.gpbCliente.Controls.Add(this.lblNombreCliente);
            this.gpbCliente.Controls.Add(this.textNombre);
            this.gpbCliente.Controls.Add(this.textApellido);
            this.gpbCliente.Controls.Add(this.textDni);
            this.gpbCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbCliente.Location = new System.Drawing.Point(420, 72);
            this.gpbCliente.Name = "gpbCliente";
            this.gpbCliente.Size = new System.Drawing.Size(480, 346);
            this.gpbCliente.TabIndex = 9;
            this.gpbCliente.TabStop = false;
            this.gpbCliente.Text = "Datos del cliente";
            // 
            // grbTipoDeOperacion
            // 
            this.grbTipoDeOperacion.Controls.Add(this.rdbCompra);
            this.grbTipoDeOperacion.Controls.Add(this.rdbAlquiler);
            this.grbTipoDeOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTipoDeOperacion.Location = new System.Drawing.Point(51, 232);
            this.grbTipoDeOperacion.Name = "grbTipoDeOperacion";
            this.grbTipoDeOperacion.Size = new System.Drawing.Size(223, 108);
            this.grbTipoDeOperacion.TabIndex = 13;
            this.grbTipoDeOperacion.TabStop = false;
            this.grbTipoDeOperacion.Text = "Tipo de operacion";
            // 
            // rdbCompra
            // 
            this.rdbCompra.AutoSize = true;
            this.rdbCompra.Location = new System.Drawing.Point(39, 64);
            this.rdbCompra.Name = "rdbCompra";
            this.rdbCompra.Size = new System.Drawing.Size(103, 29);
            this.rdbCompra.TabIndex = 1;
            this.rdbCompra.TabStop = true;
            this.rdbCompra.Text = "Compra";
            this.rdbCompra.UseVisualStyleBackColor = true;
            // 
            // rdbAlquiler
            // 
            this.rdbAlquiler.AutoSize = true;
            this.rdbAlquiler.Location = new System.Drawing.Point(39, 29);
            this.rdbAlquiler.Name = "rdbAlquiler";
            this.rdbAlquiler.Size = new System.Drawing.Size(98, 29);
            this.rdbAlquiler.TabIndex = 0;
            this.rdbAlquiler.TabStop = true;
            this.rdbAlquiler.Text = "Alquiler";
            this.rdbAlquiler.UseVisualStyleBackColor = true;
            // 
            // btnAceptarCliente
            // 
            this.btnAceptarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarCliente.Location = new System.Drawing.Point(312, 232);
            this.btnAceptarCliente.Name = "btnAceptarCliente";
            this.btnAceptarCliente.Size = new System.Drawing.Size(162, 42);
            this.btnAceptarCliente.TabIndex = 8;
            this.btnAceptarCliente.Text = "Aceptar";
            this.btnAceptarCliente.UseVisualStyleBackColor = true;
            this.btnAceptarCliente.Click += new System.EventHandler(this.btnAceptarCliente_Click);
            // 
            // lblDniCliente
            // 
            this.lblDniCliente.AutoSize = true;
            this.lblDniCliente.Location = new System.Drawing.Point(45, 186);
            this.lblDniCliente.Name = "lblDniCliente";
            this.lblDniCliente.Size = new System.Drawing.Size(58, 32);
            this.lblDniCliente.TabIndex = 7;
            this.lblDniCliente.Text = "Dni";
            // 
            // lblApellidoCliente
            // 
            this.lblApellidoCliente.AutoSize = true;
            this.lblApellidoCliente.Location = new System.Drawing.Point(45, 131);
            this.lblApellidoCliente.Name = "lblApellidoCliente";
            this.lblApellidoCliente.Size = new System.Drawing.Size(119, 32);
            this.lblApellidoCliente.TabIndex = 6;
            this.lblApellidoCliente.Text = "Apellido";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(45, 77);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(115, 32);
            this.lblNombreCliente.TabIndex = 5;
            this.lblNombreCliente.Text = "Nombre";
            // 
            // lblAgregarSeleccionado
            // 
            this.lblAgregarSeleccionado.AutoSize = true;
            this.lblAgregarSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.lblAgregarSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregarSeleccionado.Location = new System.Drawing.Point(13, 462);
            this.lblAgregarSeleccionado.Name = "lblAgregarSeleccionado";
            this.lblAgregarSeleccionado.Size = new System.Drawing.Size(283, 25);
            this.lblAgregarSeleccionado.TabIndex = 10;
            this.lblAgregarSeleccionado.Text = "Agregar producto seleccionado";
            // 
            // btnAgregarACarrito
            // 
            this.btnAgregarACarrito.Location = new System.Drawing.Point(313, 462);
            this.btnAgregarACarrito.Name = "btnAgregarACarrito";
            this.btnAgregarACarrito.Size = new System.Drawing.Size(86, 25);
            this.btnAgregarACarrito.TabIndex = 11;
            this.btnAgregarACarrito.Text = "Agregar";
            this.btnAgregarACarrito.UseVisualStyleBackColor = true;
            this.btnAgregarACarrito.Click += new System.EventHandler(this.btnAgregarACarrito_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ingrese cantidad";
            // 
            // lblCantidadProductos
            // 
            this.lblCantidadProductos.AutoSize = true;
            this.lblCantidadProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadProductos.Location = new System.Drawing.Point(12, 515);
            this.lblCantidadProductos.Name = "lblCantidadProductos";
            this.lblCantidadProductos.Size = new System.Drawing.Size(205, 25);
            this.lblCantidadProductos.TabIndex = 13;
            this.lblCantidadProductos.Text = "Productos en el carrito";
            // 
            // lblTotalAPagar
            // 
            this.lblTotalAPagar.AutoSize = true;
            this.lblTotalAPagar.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAPagar.Location = new System.Drawing.Point(13, 564);
            this.lblTotalAPagar.Name = "lblTotalAPagar";
            this.lblTotalAPagar.Size = new System.Drawing.Size(127, 25);
            this.lblTotalAPagar.TabIndex = 14;
            this.lblTotalAPagar.Text = "Total a pagar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(492, 462);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 40);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmarPedido
            // 
            this.btnConfirmarPedido.Location = new System.Drawing.Point(718, 462);
            this.btnConfirmarPedido.Name = "btnConfirmarPedido";
            this.btnConfirmarPedido.Size = new System.Drawing.Size(165, 40);
            this.btnConfirmarPedido.TabIndex = 16;
            this.btnConfirmarPedido.Text = "Confirmar Pedido";
            this.btnConfirmarPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarPedido.Click += new System.EventHandler(this.btnConfirmarPedido_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.Location = new System.Drawing.Point(689, 537);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(194, 52);
            this.btnAgregarProducto.TabIndex = 17;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 606);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnConfirmarPedido);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTotalAPagar);
            this.Controls.Add(this.lblCantidadProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarACarrito);
            this.Controls.Add(this.lblAgregarSeleccionado);
            this.Controls.Add(this.gpbCliente);
            this.Controls.Add(this.textTotalAPagar);
            this.Controls.Add(this.textCantidadEnCarrito);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.dataGProductosDisponibles);
            this.MaximizeBox = false;
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGProductosDisponibles)).EndInit();
            this.gpbCliente.ResumeLayout(false);
            this.gpbCliente.PerformLayout();
            this.grbTipoDeOperacion.ResumeLayout(false);
            this.grbTipoDeOperacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGProductosDisponibles;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.TextBox textCantidadEnCarrito;
        private System.Windows.Forms.TextBox textTotalAPagar;
        private System.Windows.Forms.GroupBox gpbCliente;
        private System.Windows.Forms.GroupBox grbTipoDeOperacion;
        private System.Windows.Forms.RadioButton rdbCompra;
        private System.Windows.Forms.RadioButton rdbAlquiler;
        private System.Windows.Forms.Button btnAceptarCliente;
        private System.Windows.Forms.Label lblDniCliente;
        private System.Windows.Forms.Label lblApellidoCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblAgregarSeleccionado;
        private System.Windows.Forms.Button btnAgregarACarrito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidadProductos;
        private System.Windows.Forms.Label lblTotalAPagar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmarPedido;
        private System.Windows.Forms.Button btnAgregarProducto;
    }
}

