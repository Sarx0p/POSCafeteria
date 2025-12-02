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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = UsuarioBLL.Login(txtUsuario.Text.Trim(), txtClave.Text.Trim());

                if (u == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar sesión
                SesionActual.IdUsuario = u.IdUsuario;
                SesionActual.NombreUsuario = u.NombreUsuario;
                SesionActual.Rol = u.Rol;

                // Abrir principal
                FrmMenuPrincipal main = new FrmMenuPrincipal();
                main.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
