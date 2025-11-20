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
    public partial class FrmCliente : Form
    {
        public static List<Cliente> listaClientes = new List<Cliente>();

        public FrmCliente()
        {
            InitializeComponent();
        }
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            if (!listaClientes.Any())
            {
                listaClientes.Add(new Cliente 
                { 
                    Id = 1, Nombre = "Carlos Díaz", 
                    Telefono = "1234-5678", 
                    Correo = "carlos@gmail.com", 
                    TipoCliente = "Normal" 
                });

                listaClientes.Add(new Cliente 
                { 
                    Id = 2, Nombre = "María García", 
                    Telefono = "7777-8888",
                    Correo = "maria@gmail.com",
                    TipoCliente = "Frecuente" 
                });

                listaClientes.Add(new Cliente
                {
                    Id = 3,
                    Nombre = "Pedro López",
                    Telefono = "9999-1122",
                    Correo = "pedro@gmail.com",
                    TipoCliente = "Empresarial"
                });
                            }

            RefrescarGrid();
        }
        private void RefrescarGrid()
        {
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefonoCliente.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
            {
                MessageBox.Show("El correo es obligatorio.");
                return;
            }
            int nuevoId = listaClientes.Any() ? listaClientes.Max(c => c.Id) + 1 : 1;

            var cli = new Cliente
            {
                Id = nuevoId,
                Nombre = txtNombreCliente.Text.Trim(),
                Telefono = txtTelefonoCliente.Text.Trim(),
                Correo = txtCorreoElectronico.Text.Trim(),
                TipoCliente = cbxTipoCliente.SelectedItem.ToString()
            };

            listaClientes.Add(cli);
            RefrescarGrid();
            LimpiarCampos();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione primero un cliente de la tabla.");
                return;
            }

            var cli = listaClientes.FirstOrDefault(c => c.Id == id);
            if (cli == null)
            {
                MessageBox.Show("Cliente no encontrado.");
                return;
            }

            cli.Nombre = txtNombreCliente.Text.Trim();
            cli.Telefono = txtTelefonoCliente.Text.Trim();
            cli.Correo = txtCorreoElectronico.Text.Trim();
            cli.TipoCliente = cbxTipoCliente.SelectedItem.ToString();

            MessageBox.Show("Cliente actualizado.");
            RefrescarGrid();
            LimpiarCampos();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un cliente válido.");
                return;
            }

            var cli = listaClientes.FirstOrDefault(c => c.Id == id);
            if (cli == null)
            {
                MessageBox.Show("Cliente no encontrado.");
                return;
            }

            if (MessageBox.Show("¿Seguro que desea eliminarlo?", "Confirmar", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                listaClientes.Remove(cli);
                RefrescarGrid();
                LimpiarCampos();
            }
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            txtId.Text = dgvClientes.CurrentRow.Cells["Id"].Value.ToString();
            txtNombreCliente.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefonoCliente.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCorreoElectronico.Text = dgvClientes.CurrentRow.Cells["Correo"].Value.ToString();
            cbxTipoCliente.SelectedItem = dgvClientes.CurrentRow.Cells["TipoCliente"].Value.ToString();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)

        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoElectronico.Clear();
            cbxTipoCliente.SelectedIndex = 0;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


