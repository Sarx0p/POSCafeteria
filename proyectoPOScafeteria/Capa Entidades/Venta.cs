using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public int Id_MetodoPago { get; set; }
        public decimal MontoTotal { get; set; }
        public int Id_Cliente { get; set; }  


    }
}
