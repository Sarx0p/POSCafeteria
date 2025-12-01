namespace proyectoPOScafeteria.Capa_Presentacion
{
    partial class FrmPrueba
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
            this.btnStock = new System.Windows.Forms.Button();
            this.btnValidarVenta = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnPruebaVenta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(59, 47);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(118, 75);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnValidarVenta
            // 
            this.btnValidarVenta.Location = new System.Drawing.Point(59, 162);
            this.btnValidarVenta.Name = "btnValidarVenta";
            this.btnValidarVenta.Size = new System.Drawing.Size(118, 75);
            this.btnValidarVenta.TabIndex = 1;
            this.btnValidarVenta.Text = "Venta";
            this.btnValidarVenta.UseVisualStyleBackColor = true;
            this.btnValidarVenta.Click += new System.EventHandler(this.btnValidarVenta_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(261, 47);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(118, 75);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes Activos";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(435, 171);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(118, 75);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.Location = new System.Drawing.Point(419, 47);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(118, 75);
            this.btnPagos.TabIndex = 4;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnPruebaVenta
            // 
            this.btnPruebaVenta.Location = new System.Drawing.Point(261, 162);
            this.btnPruebaVenta.Name = "btnPruebaVenta";
            this.btnPruebaVenta.Size = new System.Drawing.Size(118, 75);
            this.btnPruebaVenta.TabIndex = 5;
            this.btnPruebaVenta.Text = "Prueba Venta";
            this.btnPruebaVenta.UseVisualStyleBackColor = true;
            this.btnPruebaVenta.Click += new System.EventHandler(this.btnPruebaVenta_Click);
            // 
            // FrmPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 580);
            this.Controls.Add(this.btnPruebaVenta);
            this.Controls.Add(this.btnPagos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnValidarVenta);
            this.Controls.Add(this.btnStock);
            this.Name = "FrmPrueba";
            this.Text = "Prueba";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnValidarVenta;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnPruebaVenta;
    }
}