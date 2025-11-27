using proyectoPOScafeteria.Capa_Entidades;
using proyectoPOScafeteria.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPOScafeteria.Capa_Presentacion
{
    public partial class FrmClientedos : Form
    {
        int clienteId = 0;
        ClienteBLL bll = new ClienteBLL();
        public FrmClientedos()
        {
            InitializeComponent();
        }
      
      

        private void CargarLista()
        {
            dgvClientesdos.DataSource = bll.Listar();
        }

        private void FrmClientedos_Load(object sender, EventArgs e)
        {
            {
                CargarLista();
                Limpiar();
            }
        }

        void Limpiar()
        {
            txtNombre.Clear();
            
            txtTelefono.Clear();
            txtCorreo.Clear();
            chkEstado.Checked = true;
            txtBuscar.Clear();
            txtNombre.Focus();

            clienteId = 0;
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientedos c = new Clientedos()
                {
                    Id = clienteId,//Si es 0 es nuevo registro, si tiene valor es MOdificación
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Estado = chkEstado.Checked
                };
                //Llamamos al metodo guardar de la BLL(EL DECIDE SI ES INSERT O UPDATE)
                int id = bll.Guardar(c);
                MessageBox.Show("Cliente guardado con exito.", "Notificación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientesdos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clienteId = Convert.ToInt32(dgvClientesdos.Rows[e.RowIndex].Cells["Id"].Value );
                txtNombre.Text = dgvClientesdos.Rows[e.RowIndex].Cells["NombreCompleto"].Value.ToString();
                txtTelefono.Text = dgvClientesdos.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvClientesdos.Rows[e.RowIndex].Cells["CorreoC"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(dgvClientesdos.Rows[e.RowIndex].Cells["Estado"].Value);
            }
            ;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteId == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar el cliente seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bll.Eliminar(clienteId);
                CargarLista();
                Limpiar();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvClientesdos.DataSource = bll.Buscar(txtBuscar.Text);
        }
    }
}
