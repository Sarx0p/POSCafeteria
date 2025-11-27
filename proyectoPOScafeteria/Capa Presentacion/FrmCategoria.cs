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

        

        void HabilitarBotones()
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvCategoria.ClearSelection();
            dgvCategoria.SelectionChanged += (s, e) =>
            {
                bool filaSeleccionada = dgvCategoria.SelectedRows.Count > 0 || dgvCategoria.CurrentRow != null;
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
        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si clickeamos una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategoria.Rows.Count)
            {
                var row = dgvCategoria.Rows[e.RowIndex];
                // Intentar obtener Id de la fila de forma segura
                string idStr = GetCellValueOrDefault(row, new[] { "Id", "ID", "id" });
                if (int.TryParse(idStr, out int id))
                {
                    categoriaID = id;
                }
                else
                {
                    categoriaID = 0;
                }

                // Asegurar selección visual
                if (!row.Selected)
                {
                    row.Selected = true;
                    dgvCategoria.CurrentCell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCategoriasGestion frm = new FrmCategoriasGestion(); //Aca dará error hasta que construyamos el Formulario llamado  FrmCategoriaGestion

            // MODO CREAR NUEVA CATEGORIA
            frm.Modo = "Nuevo"; //definimos por defecto que sea “nuevo”
            frm.Id = 0; //Guardara el Id que traigamos  del FrmCategoriaGestion

            frm.ShowDialog();  // Abrir como modal
            CargarDatos();     // Refrescar al cerrar
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría",
                   "Información",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }

            if (dgvCategoria.CurrentRow == null)
            {
                MessageBox.Show("No hay fila seleccionada.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            FrmCategoriasGestion frm = new FrmCategoriasGestion();
            // MODO EDITAR
            frm.Modo = "Modificar";
            frm.Id = categoriaID;

            // Pasar información desde el DGV con nombres alternativos y comprobaciones
            frm.Nombre = GetCellValueOrDefault(dgvCategoria.CurrentRow, new[] { "Nombre", "NombreCategoria", "nombre" });
            frm.Descripcion = GetCellValueOrDefault(dgvCategoria.CurrentRow, new[] { "Descripcion", "DescripcionCategoria", "descripcion" });

            frm.ShowDialog();
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría",
                   "Información",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }

            if (dgvCategoria.CurrentRow == null)
            {
                MessageBox.Show("No hay fila seleccionada.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Abrir formulario de eliminación
            FrmCategoriaEliminar frm = new FrmCategoriaEliminar();

            frm.Id = categoriaID;
            frm.Nombre = GetCellValueOrDefault(dgvCategoria.CurrentRow, new[] { "Nombre", "NombreCategoria", "nombre" });
            frm.Descripcion = GetCellValueOrDefault(dgvCategoria.CurrentRow, new[] { "Descripcion", "DescripcionCategoria", "descripcion" });

            frm.ShowDialog();
            CargarDatos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Método auxiliar: intenta obtener el valor de la celda probando varios nombres de columna y un fallback
        private string GetCellValueOrDefault(DataGridViewRow row, string[] columnNames)
        {
            if (row == null || row.DataGridView == null) return string.Empty;

            foreach (var name in columnNames)
            {
                if (row.DataGridView.Columns.Contains(name))
                {
                    var val = row.Cells[name]?.Value;
                    if (val != null) return val.ToString();
                }
            }

            // Fallback: devolver el primer valor no nulo de la fila
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell?.Value != null) return cell.Value.ToString();
            }

            return string.Empty;
        }

        private void FrmCategoria_Load_1(object sender, EventArgs e)
        {
            CargarDatos();
            HabilitarBotones(); 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvCategoria.DataSource = bll.Buscar(txtBuscar.Text);
        }
    }
}

