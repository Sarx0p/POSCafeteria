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
    public partial class FrmCategoriasGestion : Form
    
        {
            //Definimos estos atributos para recibir datos desde FrmCategoria y guardarlos acá
            public string Modo { get; set; }        // Define la acción
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }

            CategoriaBLL bll = new CategoriaBLL();

            public FrmCategoriasGestion()
        {
            InitializeComponent();
        }
    
      private void FrmCategoriaGestion_Load(object sender, EventArgs e)
        {
            if (Modo == "Nuevo")
            {
                lblTitulo.Text = "AGREGAR NUEVA CATEGORÍA";
            }
            else
            {
                lblTitulo.Text = "MODIFICAR CATEGORÍA";
                // Cargar datos en controles
                txtNombre.Text = Nombre;
                txtDescripcion.Text = Descripcion;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show(
                        "Debe ingresar un nombre para la categoría.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                // Creamos objeto categoría
                Categoria c = new Categoria
                {
                    Id = Id,
                    NombreCategoria = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };
                bll.Guardar(c);

                MessageBox.Show(
                   Modo == "Nuevo"
                       ? "La categoría ha sido registrada correctamente."
                       : "Los cambios han sido guardados correctamente.",
                   "Operación exitosa",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1
               );
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error al interactuar con la base de datos.\n\nDetalles técnicos:\n" + ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error inesperado:\n" + ex.Message,
                    "Error general",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); // Cierra sin hacer nada
        }
    }
}
