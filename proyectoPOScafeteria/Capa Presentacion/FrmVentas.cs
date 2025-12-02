using proyectoPOScafeteria.Capa_Datos;
using proyectoPOScafeteria.Capa_Entidades;
using proyectoPOScafeteria.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
            dgvDetalles.AllowUserToAddRows = false;
        
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

        

        CargarProductos(string.Empty);
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

        private void CargarProductos(string filtro)
        {
            // Obtenemos la lista desde DAL
            var tabla = ProductoDAL.Listar(); // ya lo creamos en Paso 2

            // Filtrar si hay texto
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var dv = tabla.DefaultView;
                dv.RowFilter = $"Nombre LIKE '%{filtro}%'";
                dgvProductos.DataSource = dv;
            }
            else
            {
                dgvProductos.DataSource = tabla;
            }

            dgvProductos.Columns["Id"].Visible = false;
        }



        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarProducto.Text.Trim();
            CargarProductos(texto);

        }

      

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var row = dgvProductos.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("Seleccione un producto (haga clic en la fila).");
                return;
            }

            // Validaciones defensivas: columnas y valores
            if (dgvProductos.Columns["Id"] == null || dgvProductos.Columns["Nombre"] == null || dgvProductos.Columns["Precio"] == null)
            {
                MessageBox.Show("Error: columnas Id/Nombre/Precio no encontradas.");
                return;
            }

            if (row.Cells["Id"].Value == null || row.Cells["Nombre"].Value == null || row.Cells["Precio"].Value == null)
            {
                MessageBox.Show("El producto seleccionado no tiene datos completos.");
                return;
            }

            // Parseo seguro
            int idProducto = 0;
            int.TryParse(row.Cells["Id"].Value.ToString(), out idProducto);

            string nombre = row.Cells["Nombre"].Value.ToString();

            decimal precio = 0;
            decimal.TryParse(row.Cells["Precio"].Value.ToString(), out precio);

            int cantidad = 1;
            decimal subTotal = precio * cantidad;

            // Evitar fila extra de edición en detalles (hazlo también en Load)
            dgvDetalles.AllowUserToAddRows = false;

            // (Opcional) Si ya existe el producto en detalles, aumentar la cantidad en vez de duplicar
            for (int i = 0; i < dgvDetalles.Rows.Count; i++)
            {
                var cell = dgvDetalles.Rows[i].Cells["Id_Producto"];
                if (cell != null && cell.Value != null && Convert.ToInt32(cell.Value) == idProducto)
                {
                    int cantExist = 1;
                    int.TryParse(dgvDetalles.Rows[i].Cells["Cantidad"].Value?.ToString() ?? "1", out cantExist);
                    cantExist += 1;
                    dgvDetalles.Rows[i].Cells["Cantidad"].Value = cantExist;
                    decimal precioUnit = Convert.ToDecimal(dgvDetalles.Rows[i].Cells["PrecioUnitario"].Value);
                    dgvDetalles.Rows[i].Cells["SubTotal"].Value = cantExist * precioUnit;
                    RecalcularTotal();
                    return;
                }
            }
            dgvDetalles.Rows.Add(idProducto, nombre, cantidad, precio, subTotal);
            RecalcularTotal();
            // RecalcularTotal();//dará error, mas adelante se creará el método, comenta esta linea cuando ejecutes


        }

        

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvProductos.ClearSelection();
            dgvProductos.Rows[e.RowIndex].Selected = true;
            // Reutilizamos el mismo método del botón Agregar Producto
            // Así no duplicamos código.
            btnAgregarProducto_Click(sender, e);
        }

        private void btnBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProductos(txtBuscarProducto.Text.Trim());
            }

        }

        private void RecalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }

            lblTotal.Text = "Total: $" + total.ToString("0.00");
        }

        private void dgvDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Si editaron la columna Cantidad
            if (dgvDetalles.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                DataGridViewRow row = dgvDetalles.Rows[e.RowIndex];

                int cantidad;
                bool ok = int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out cantidad);

                if (!ok || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    row.Cells["Cantidad"].Value = 1;
                    cantidad = 1;
                }

                decimal precio = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                decimal subTotal = cantidad * precio;

                row.Cells["SubTotal"].Value = subTotal;

                // Recalcular total general
                RecalcularTotal();
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para quitar.");
                return;
            }

            dgvDetalles.Rows.RemoveAt(dgvDetalles.SelectedRows[0].Index);

            RecalcularTotal();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalles.Rows.Count == 0)
                {
                    MessageBox.Show("La venta no tiene productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ---------------------------------------------------
                // 1) CREAR OBJETO VENTA
                // ---------------------------------------------------
                Venta venta = new Venta()
                {
                    FechaVenta = dtpFecha.Value,
                    MontoTotal = ObtenerTotalVenta(), // lo creamos abajo
                    Id_Cliente = Convert.ToInt32(cboCliente.SelectedValue),
                    Id_MetodoPago = Convert.ToInt32(cboMetodoPago.SelectedValue)
                };

                // ---------------------------------------------------
                // 2) CREAR LISTA DE DETALLES
                // ---------------------------------------------------
                List<DetalleVenta> detalles = new List<DetalleVenta>();

                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    detalles.Add(new DetalleVenta()
                    {
                        Id_Producto = Convert.ToInt32(row.Cells["Id_Producto"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value)
                    });
                }

             var validacion = VentaBLL.ValidarVenta(venta, detalles);

            if (!validacion.Exito)
            {
                MessageBox.Show(validacion.Mensaje, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                var resultado = VentaDAL.RegistrarVentaTransaccional(venta, detalles);

                if (resultado.Exito)
                {
                    MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }

        }
        private decimal ObtenerTotalVenta()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalles.Rows)
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);

            return total;
        }

        private void LimpiarFormulario()
        {
            dgvDetalles.Rows.Clear();
            lblTotal.Text = "Total: $0.00";
            txtBuscarProducto.Clear();
            CargarProductos(string.Empty); // recarga lista completa
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres cancelar la venta?", "Informacion",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
            }
    }

        private void btnLimpiarDetalle_Click(object sender, EventArgs e)
        {
            dgvDetalles.Rows.Clear();
            RecalcularTotal();

        }
    }

    }







