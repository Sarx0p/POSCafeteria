using proyectoPOScafeteria.Capa_Negocio;
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
    public partial class FrmCategoria : Form
    {
        CategoriaBLL bll = new CategoriaBLL();

        int categoriaID = 0;  // Guarda el ID seleccionado
        string Modo = "Nuevo"; // Nuevo o Editar

        public FrmCategoria()
        {
            InitializeComponent();
        }
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarDatos();
            HabilitarBotones();
        }
        void HabilitarBotones()
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvCategoria.ClearSelection();
            dgvCategoria.SelectionChanged += (s, e) =>
            {
                bool filaSeleccionada = dgvCategoria.SelectedRows.Count > 0;
                btnModificar.Enabled = filaSeleccionada;
                btnEliminar.Enabled = filaSeleccionada;
            };
        }
        void CargarDatos()
        {
            dgvCategoria.DataSource = bll.Listar();
            dgvCategoria.ClearSelection();
            categoriaID = 0;   

        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvCategoria.DataSource = bll.Buscar(txtBuscar.Text);
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                // Si clickeamos una fila válida
                if (e.RowIndex >= 0)
                {
                    categoriaID = Convert.ToInt32(dgvCategoria.Rows[e.RowIndex].Cells["CategoriaID"].Value);
                }
            }

        }
    }
}
