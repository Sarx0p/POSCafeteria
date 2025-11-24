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
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
        {
            string sql = "SELECT Id, NombreCompleto, CorreoC, Telefono, TipoCliente, Estado From Cliente";
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                new SqlDataAdapter(cmd).Fill(dt);
            }
        }
        return dt;
        }
    public int Insertar(Clientedos c)
    {

        using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
        {
            string sql = @"INSERT INTO cliente(NombreCompleto, CorreoC, Telefono, Id_TipoCliente, Estado) 
        VALUES(@Nombre, @CorreoC, @Telefono, @TipoCliente, @Estado); SELECT SCOPE IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@CorreoC", c.Correo);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@TipoCLiente", c.TipoCliente);
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
            string sql = @"UPDATE Cliente SET Nombre=@nombre, CorreoC=@Correo, Telefono=@Telefono,TipoCliente=@Id_TipoCliente, Estado=Estado WHERE Id=@Id;";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@NombreCompleto", c.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoC", c.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@TipoCliente", c.TipoCliente);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
            }
        }
     }
            public bool Eliminar (int Id)
        {
            using(SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM cliente WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(sql, cn))

            {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cn.Open() ;
                    return cmd.ExecuteNonQuery() > 0;
                }

            
}
}
            public DataTable Buscar(string filtro)
        {
            DataTable dt  = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT Id, NombreCompleto, CorreoC,Telefono, TipoCliente, Estado FROM cliente WHERE NombreCompleto LIKE @filtro
                OR Telefono Like @filtro";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    cn.Open() ;
                    new SqlDataAdapter(cmd).Fill(dt);
            }
         }
       }
    }
}

    
