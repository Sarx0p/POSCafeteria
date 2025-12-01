using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Datos
{
    public class MetodoPagoDAL
    {
        
        public static List<MetodoPago> Listar()
        {
            List<MetodoPago> lista = new List<MetodoPago>();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT * FROM MetodoPago";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new MetodoPago
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Metodo = dr["Metodo"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }


}

