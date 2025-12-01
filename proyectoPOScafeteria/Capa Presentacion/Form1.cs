using proyectoPOScafeteria.Capa_Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPOScafeteria
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void btnVentaRapida_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.Show(); // abre el formulario normal
        }

        private void menusuperior_Click(object sender, EventArgs e)
        {

        }

        private void panelizquierdo_Click(object sender, EventArgs e)
        {

        }

      
        
           
        
            private void btnProducto_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.Show(); // abre el formulario normal
        }

        

        
        

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientedos frm = new FrmClientedos();
            frm.ShowDialog(); // abre el formulario normal
        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            FrmPrueba frm = new FrmPrueba();
            frm.ShowDialog(); 
        }

        private void btnVentaRapida_Click_1(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.ShowDialog(); // abre el formulario normal
        }
    }
    }

                                                                                                                                             