using proyectoPOScafeteria.Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPOScafeteria.Capa_Presentacion
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }


        private void FrmVentas_Load(object sender, EventArgs e)
        {
            // --- CLIENTES ---
            cboCliente.DataSource = ClienteDAL.ListarActivos();
            cboCliente.DisplayMember = "Nombre";
            cboCliente.ValueMember = "Id";

            // --- TIPO PAGO ---
            cboMetodoPago.DataSource = MetodoPagoDAL.Listar(); //asiganmos datos al desplegable
            cboMetodoPago.DisplayMember = "Metodo"; //lo que muestra
            cboMetodoPago.ValueMember = "Id"; //el valor que nos importa ID

            // --- FECHA ---
            dtpFecha.Value = DateTime.Now;//obtiene la fecha de ahora

            // --- CONFIGURAR COLUMNAS DEL DETALLE ---
            ConfigurarTablaDetalles();

        }
        private void ConfigurarTablaDetalles()
        {
            dgvDetalles.Columns.Clear();

            // ID PRODUCTO
            DataGridViewTextBoxColumn colIdProd = new DataGridViewTextBoxColumn();
            colIdProd.Name = "Id_Producto";
            colIdProd.HeaderText = "ID";
            colIdProd.Visible = false;
            dgvDetalles.Columns.Add(colIdProd);

            // NOMBRE PRODUCTO
            dgvDetalles.Columns.Add("NombreProducto", "Producto");

            // CANTIDAD
            DataGridViewTextBoxColumn colCant = new DataGridViewTextBoxColumn();
            colCant.Name = "Cantidad";
            colCant.HeaderText = "Cant.";
            dgvDetalles.Columns.Add(colCant);

            // PRECIO UNITARIO
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "PrecioUnitario";
            colPrecio.HeaderText = "Precio Unitario";
            dgvDetalles.Columns.Add(colPrecio);

            // SUBTOTAL
            DataGridViewTextBoxColumn colSub = new DataGridViewTextBoxColumn();
            colSub.Name = "SubTotal";
            colSub.HeaderText = "Subtotal";
            colSub.ReadOnly = true;
            dgvDetalles.Columns.Add(colSub);
            // Asegurar permisos de edición
            dgvDetalles.ReadOnly = false;

            // Columnas NO editables
            dgvDetalles.Columns["SubTotal"].ReadOnly = true;
            dgvDetalles.Columns["PrecioUnitario"].ReadOnly = true;
            dgvDetalles.Columns["NombreProducto"].ReadOnly = true;
            dgvDetalles.Columns["Id_Producto"].ReadOnly = true;

            // ÚNICA columna editable:
            dgvDetalles.Columns["Cantidad"].ReadOnly = false;

        }

    }
}
