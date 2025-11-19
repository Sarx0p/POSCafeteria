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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        
        
            public static List<Cliente> listaClientes = new List<Cliente>();
    
    private void FrmClientes_Load(object sender, EventArgs e)
        {
            if (!listaClientes.Any())
            {
                listaClientes.Add(new Cliente
                {
                    Id = 1,
                    Nombre = "Luis Pérez",
                    Telefono = "7012-4587",
                    Correo = "luis@gmail.com",
                    Tipo = "Normal",
                    Estado = true
                });

                listaClientes.Add(new Cliente
                {
                    Id = 2,
                    Nombre = "Ana Torres",
                    Telefono = "7158-2233",
                    Correo = "ana@gmail.com",
                    Tipo = "Frecuente",
                    Estado = true
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
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            int nuevoId = listaClientes.Any() ? listaClientes.Max(c => c.Id) + 1 : 1;

            Cliente nuevo = new Cliente
            {
                Id = nuevoId,
                Nombre = txtNombreCliente.Text,
                Telefono = txtTelefonoCliente.Text,
                Correo = txtCorreoElectronico.Text,
                Tipo = cbxTipoCliente.Text,
                Estado = rbtActivo.Checked
            };

            listaClientes.Add(nuevo);
            RefrescarGrid();
            LimpiarCampos();
        }

      
        
            private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;

            Cliente cli = listaClientes.First(x => x.Id == id);

            cli.Nombre = txtNombreCliente.Text;
            cli.Telefono = txtTelefonoCliente.Text;
            cli.Correo = txtCorreoElectronico.Text;
            cli.Tipo = cbxTipoCliente.Text;
            cli.Estado = rbtActivo.Checked;

            RefrescarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
       
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;

            var cli = listaClientes.First(c => c.Id == id);

            listaClientes.Remove(cli);
            RefrescarGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
           
        
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoElectronico.Clear();
            cbxTipoCliente.SelectedIndex = -1;
            rbtActivo.Checked = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

    

        

    