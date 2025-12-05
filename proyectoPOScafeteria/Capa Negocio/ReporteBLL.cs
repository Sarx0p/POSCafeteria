using proyectoPOScafeteria.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Negocio
{
    public class ReporteBLL
    {
        
    public ReporteDAL dal = new ReporteDAL();
        public DataTable ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            // Validaciones simples: fecha inicio no mayor a fecha fin
            if (fechaInicio > fechaFin)
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha fin.");

            // Llamada a la capa de datos
            return dal.ReporteVentas(fechaInicio, fechaFin);
        }
        public static DataTable ObtenerVentasPorPeriodo(DateTime inicio, DateTime fin)
        {
            return ReporteDAL.ObtenerVentaPorPeriodo(inicio, fin);
        }
    }
}


