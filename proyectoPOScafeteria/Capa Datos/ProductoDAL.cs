using proyectoPOScafeteria.Capa_Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Datos
{
    public class ProductoDAL
    {
        public static int ObtenerStock(int idProducto)
        {
            int stock = 0;

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT Stock FROM Producto WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idProducto);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        stock = Convert.ToInt32(result);
                }
            }

            return stock;
        }

        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"
                    SELECT p.Id, p.Nombre, p.Precio, p.Stock, c.Nombre AS Categoria
                    FROM Producto p
                    INNER JOIN Categoria c ON p.Id_Categoria = c.Id
                    WHERE p.Estado = 1;";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
            }

            return tabla;
        }
    }
}


    




    

