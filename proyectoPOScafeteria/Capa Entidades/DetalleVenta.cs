using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Entidades
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int Id_Venta { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
