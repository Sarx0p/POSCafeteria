using proyectoPOScafeteria.Capa_Entidades;
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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            
        }
        //Creacion de una lista estatica que simulara la DB
        public static List<Producto> listaProductos = new List<Producto>();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            //Cargar los datos iniciales
            if (!listaProductos.Any())
            {// cada vez que se cargue el formulario, si la lista esta vacia,
             // se agregan los productos iniciales
                listaProductos.Add(new Producto
                {
                    Id = 1,
                    Nombre = "Café Gourmet",
                    Descripcion = "Importado",
                    Precio = 10.5m,
                    Stock = 100,
                    Estado = true
                });
                listaProductos.Add(new Producto
                {
                    Id = 2,
                    Nombre = "Café Borbon",
                    Descripcion = "De altura",
                    Precio = 20.0m,
                    Stock = 50,
                    Estado = true
                });
                listaProductos.Add(new Producto
                {
                    Id = 3,
                    Nombre = "Cheescake",
                    Descripcion = "Dulce sabor",
                    Precio = 15.75m,
                    Stock = 75,
                    Estado = true
                });
            }
            RefrescarGrid();//mando a llamar el metodo para refrescar el datagridview
        }
        //asignar la lista como DataSOurce al datagridview
        private void RefrescarGrid()
        {
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.DataSource = null; // Limpiar el DataSource antes de reasignarlo
            dgvProductos.DataSource = listaProductos; // Asignar la lista como DataSource
        }

       

      
        
            private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Validación de nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            // Validación de precio
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show("El precio debe ser un número válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }

            // Validación de stock
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("El stock debe ser un número entero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;
            }

            // Crear un producto nuevo
            Producto nuevo = new Producto
            {
                Id = listaProductos.Count + 1,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Estado = chkEstado.Checked
            };

            // Agregarlo a la lista
            listaProductos.Add(nuevo);

            // Refrescar la tabla
            RefrescarGrid();

            MessageBox.Show("Producto agregado correctamente.");

        
        }
     

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto;

                txtId.Text = fila.Id.ToString();
                txtNombre.Text = fila.Nombre;
                txtDescripcion.Text = fila.Descripcion;
                txtPrecio.Text = fila.Precio.ToString();
                txtStock.Text = fila.Stock.ToString();
                chkEstado.Checked = fila.Estado;
            }
        }
       
        
            

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
        {
            this.Close();
        }

    }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Selecciona un producto primero.");
                return;
            }

            int id = int.Parse(txtId.Text);
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Precio = decimal.Parse(txtPrecio.Text);
                producto.Stock = int.Parse(txtStock.Text);
                producto.Estado = chkEstado.Checked;

                RefrescarGrid();
                MessageBox.Show("Producto modificado.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
                return;
            }

            int id = int.Parse(txtId.Text);

            Producto p = listaProductos.FirstOrDefault(x => x.Id == id);

            if (p != null)
            {
                listaProductos.Remove(p);
                RefrescarGrid();
                MessageBox.Show("Producto eliminado.");
                LimpiarCampos();
            }
        }

    }

        private void btnLimpiar_Click(object sender, EventArgs e)
        
         
        {
            LimpiarCampos();
            }
                private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            chkEstado.Checked = false;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}

    

    
