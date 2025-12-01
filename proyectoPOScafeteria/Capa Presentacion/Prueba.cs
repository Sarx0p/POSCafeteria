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
    public partial class FrmPrueba : Form
    {
        public FrmPrueba()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            int stock = ProductoDAL.ObtenerStock(1); // prueba con un id real
            MessageBox.Show("Stock del producto 1: " + stock);

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var clientes = ClienteDAL.ListarActivos();
            MessageBox.Show("Clientes activos: " + clientes.Count);


        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            var pagos = MetodoPagoDAL.Listar();
            MessageBox.Show("Tipos de pago: " + pagos.Count);

        }

        private void btnValidarVenta_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta()
            {
                FechaVenta = DateTime.Now,
                MontoTotal = 5.00m,
                Id_Cliente = 1,
                Id_MetodoPago = 1
            };

            var detalles = new List<DetalleVenta>()
    {
        new DetalleVenta()
        {
            Id_Producto = 1,
            Cantidad = 1,
            PrecioUnitario = 5.00m,
            Subtotal = 5.00m
        }
    };

            var r = VentaBLL.ValidarVenta(venta, detalles);

            MessageBox.Show(r.Mensaje);
        }

        private void btnPruebaVenta_Click(object sender, EventArgs e)
        {
            {
                Venta venta = new Venta()
                {
                    FechaVenta = DateTime.Now,
                    MontoTotal = 10.00m,
                    Id_Cliente = 1, // usa tu Cliente por defecto
                    Id_MetodoPago = 1 // efectivo (o el que tengas)
                };

                var detalles = new List<DetalleVenta>()
    {
        new DetalleVenta()
        {
            Id_Producto = 1,  // debe existir
            Cantidad = 1,
            PrecioUnitario = 10.00m,
            Subtotal = 10.00m
        }
    };

                var r = VentaDAL.RegistrarVentaTransaccional(venta, detalles);

                MessageBox.Show(r.Mensaje);

            }
        }
    }
}
