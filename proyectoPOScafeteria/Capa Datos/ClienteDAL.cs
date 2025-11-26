using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Datos
{
    public class ClienteDAL
    {
        public DataTable Listar()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cliente", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            
        }

        public int Insertar(Clientedos c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"INSERT INTO Cliente (NombreCompleto, CorreoC, Telefono, Estado)
                           VALUES (@NombreCompleto, @CorreoC, @Telefono, @Estado);
                           SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCompleto", c.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoC", c.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Actualizar(Clientedos c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"UPDATE Cliente 
                           SET NombreCompleto=@NombreCompleto,
                               CorreoC=@CorreoC,
                               Telefono=@Telefono,
                               Estado=@Estado
                           WHERE Id=@Id;";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@NombreCompleto", c.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoC", c.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM cliente WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                    //Elimina y devuelve true si se elimino al menos una fila
                }
            }
        }

        public DataTable Buscar(string filtro)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT Id, NombreCompleto, CorreoC, Telefono, Estado
                           FROM Cliente
                           WHERE NombreCompleto LIKE @filtro
                           OR Telefono LIKE @filtro";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    cn.Open();
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        public bool ExisteNombre(string nombre)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT COUNT(*) FROM Cliente WHERE NombreCompleto = @nombre";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
        public bool ExisteNombreEnOtroCliente(string nombre, int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT COUNT(*)
                       FROM Cliente
                       WHERE NombreCompleto = @nombre AND Id <> @id";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool TieneVentasAsociadas(int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT COUNT(*) 
                       FROM Venta 
                       WHERE Id_Cliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", id);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

    }
}
    
    

