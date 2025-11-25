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
        public FrmClientedos()
        {
            InitializeComponent();
        }
        ClienteBLL  ClienteBLL = new ClienteBLL();
      

        private void CargarLista()
        {
            dgvClientesdos.DataSource = ClienteBLL.Listar();
        }
        private void dgvClientesdos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmClientedos_Load(object sender, EventArgs e)
        {
            {
                CargarLista();
            }
        }
    }
}
