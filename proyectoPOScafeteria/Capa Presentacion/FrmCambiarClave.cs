using proyectoPOScafeteria.Capa_Datos;
using proyectoPOScafeteria.Capa_Entidades;
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
    public partial class FrmCambiarClave : Form
    {
        public FrmCambiarClave()
        {
            InitializeComponent();
        }

        private void FrmCambiarClave_Load(object sender, EventArgs e)
        {

        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = SesionActual.IdUsuario;
                if (id == 0) throw new Exception("No hay sesión activa.");

                // Verificar clave actual
                var user = UsuarioDAL.Login(SesionActual.NombreUsuario, PruebaHash(txtClaveActual.Text));
                if (user == null)
                {
                    MessageBox.Show("La contraseña actual es incorrecta.");
                    return;
                }

                if (txtNuevaClave.Text != txtConfirmar.Text)
                {
                    MessageBox.Show("La nueva contraseña y su confirmación no coinciden.");
                    return;
                }

                bool ok = UsuarioBLL.CambiarClave(id, txtNuevaClave.Text);
                MessageBox.Show(ok ? "Contraseña actualizada." : "No se pudo actualizar.");
                if (ok) this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Método privado para generar hash temporal y verificar (evita duplicar Seguridad en UI)
        private string PruebaHash(string pass)
        {
            return Seguridad.Hash_SHA256(pass);
        }

    }
}

