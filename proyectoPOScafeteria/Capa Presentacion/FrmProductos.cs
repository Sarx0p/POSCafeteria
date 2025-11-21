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

        private void DeshabilitarBotones()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnNuevo.Enabled = true;
        }
        private void HabilitarBotones()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnLimpiar.Enabled = true;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)

        {
            DeshabilitarBotones(); //al iniciar, no esten activos
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
            //Validaciones basicas
            //valida que el nombre no este vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (!Validaciones.Sololetrayespacios(txtNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }


            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show("El precio del producto debe ser un valor numérico.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }//valida que el stock ingresado sea un entero
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("El stock del producto debe ser un valor entero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;
            }


            int nuevoId = listaProductos.Any() ? listaProductos.Max(x => x.Id) + 1 : 1;
            var p = new Producto
            {
                Id = nuevoId,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Estado = chkEstado.Checked
            };
            //Agregar a la lista
            listaProductos.Add(p);
            RefrescarGrid();//refrescar el datagridview
            //Limpiar los controles
            LimpiarCampos();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un producto válido para eliminar.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //busco el producto en la lista
            var prod = listaProductos.FirstOrDefault(x => x.Id == id);
            //si lo encuentro, actualizo sus propiedades
            if (prod == null)
            {
                MessageBox.Show("Producto no encontrado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }//valida que el precio ingresado sea un decimal
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show("El precio del producto debe ser un valor numérico.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }//valida que el stock ingresado sea un entero
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("el stock del producto debe ser un valor entero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;
            }
        
        //Actualizar los campos en memoria
        prod.Nombre = txtNombre.Text.Trim();
            prod.Descripcion = txtDescripcion.Text.Trim();
            prod.Precio = decimal.Parse(txtPrecio.Text);
        prod.Stock = int.Parse(txtStock.Text);
        prod.Estado = chkEstado.Checked;
            MessageBox.Show("Producto actualizado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarGrid();//refrescar el datagridview
        LimpiarCampos();//limpiar los controles
            DeshabilitarBotones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Evento para eliminar un producto
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un producto válido para eliminar.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prod = listaProductos.FirstOrDefault(x => x.Id == id);
            if (prod == null)
            {
                MessageBox.Show("Producto no encontrado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar el producto seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaProductos.Remove(prod);//con remove elimino el producto de la lista
                RefrescarGrid();//refrescar el datagridview
                LimpiarCampos();//limpiar los controles
                DeshabilitarBotones();
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            chkEstado.Checked = true;
            txtNombre.Focus();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            txtId.Text = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
            chkEstado.Checked = (bool)dgvProductos.CurrentRow.Cells["Estado"].Value;

            HabilitarBotones();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
