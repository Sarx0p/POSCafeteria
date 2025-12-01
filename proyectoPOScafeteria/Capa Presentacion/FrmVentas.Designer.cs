namespace proyectoPOScafeteria.Capa_Presentacion
{
    partial class FrmVentas
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiarDetalle = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(87, 594);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(278, 31);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Monto total:  Total: $0.00";
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarVenta.Location = new System.Drawing.Point(512, 582);
            this.btnRegistrarVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(199, 43);
            this.btnRegistrarVenta.TabIndex = 14;
            this.btnRegistrarVenta.Text = "REGISTRAR VENTA";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "FORMULARIO POS - REGISTRO DE VENTAS";
            // 
            // btnLimpiarDetalle
            // 
            this.btnLimpiarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLimpiarDetalle.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDetalle.Location = new System.Drawing.Point(443, 160);
            this.btnLimpiarDetalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarDetalle.Name = "btnLimpiarDetalle";
            this.btnLimpiarDetalle.Size = new System.Drawing.Size(102, 54);
            this.btnLimpiarDetalle.TabIndex = 10;
            this.btnLimpiarDetalle.Text = "LIMPIAR TODOS";
            this.btnLimpiarDetalle.UseVisualStyleBackColor = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuitar.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Location = new System.Drawing.Point(443, 80);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(102, 54);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "QUITAR PRODUCTO";
            this.btnQuitar.UseVisualStyleBackColor = false;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(27, 29);
            this.dgvDetalles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowHeadersWidth = 62;
            this.dgvDetalles.RowTemplate.Height = 28;
            this.dgvDetalles.Size = new System.Drawing.Size(396, 324);
            this.dgvDetalles.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLimpiarDetalle);
            this.groupBox3.Controls.Add(this.btnQuitar);
            this.groupBox3.Controls.Add(this.dgvDetalles);
            this.groupBox3.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(538, 180);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(573, 378);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DETALLES DE VENTA";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(290, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "NUEVO";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(530, 25);
            this.cboMetodoPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(175, 26);
            this.cboMetodoPago.TabIndex = 4;
            this.cboMetodoPago.Text = "Lista de tipos de pago";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(111, 26);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(169, 26);
            this.cboCliente.TabIndex = 0;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(757, 28);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 19);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(29, 29);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(76, 19);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "CLIENTE:";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.Location = new System.Drawing.Point(425, 29);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(74, 19);
            this.lblPago.TabIndex = 2;
            this.lblPago.Text = "Tipo Pago";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cboMetodoPago);
            this.groupBox2.Controls.Add(this.cboCliente);
            this.groupBox2.Controls.Add(this.lblFecha);
            this.groupBox2.Controls.Add(this.lblCliente);
            this.groupBox2.Controls.Add(this.lblPago);
            this.groupBox2.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(58, 88);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1053, 66);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATO GENERAL DE VENTA";
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(30, 61);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.Size = new System.Drawing.Size(390, 242);
            this.dgvProductos.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregarProducto.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.Location = new System.Drawing.Point(61, 325);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(325, 28);
            this.btnAgregarProducto.TabIndex = 7;
            this.btnAgregarProducto.Text = "AGREGAR PRODUCTO AL CARRITO";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscarProducto.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.Location = new System.Drawing.Point(317, 26);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(103, 31);
            this.btnBuscarProducto.TabIndex = 6;
            this.btnBuscarProducto.Text = "BUSCAR";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(9, 29);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(72, 19);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "FILTRAR:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(762, 582);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(199, 43);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuscarProducto);
            this.groupBox1.Controls.Add(this.dgvProductos);
            this.groupBox1.Controls.Add(this.btnAgregarProducto);
            this.groupBox1.Controls.Add(this.btnBuscarProducto);
            this.groupBox1.Controls.Add(this.lblBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(59, 180);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(443, 378);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PRODUCTOS";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(826, 26);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 25);
            this.dtpFecha.TabIndex = 5;
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(87, 31);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(219, 25);
            this.txtBuscarProducto.TabIndex = 8;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1161, 647);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVentas";
            this.Text = "Formulario de Ventas Rapidas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiarDetalle;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtBuscarProducto;
    }
}