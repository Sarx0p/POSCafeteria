using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Datos
{
    public  class CategoriaDAL
    {
       public DataTable Listar()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT Id, NombreCategoria, Descripcion FROM CategoriaProducto";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();

                    new SqlDataAdapter(cmd).Fill(dt);
                    // SqlDataAdapter ejecuta el SELECT y guarda el resultado en dt
                }
            }
            return dt;
        }
        public int Insertar(Categoria c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                // SCOPE_IDENTITY devuelve el ID recién insertado
                string sql = @"INSERT INTO CategoriaProducto (NombreCategoria, Descripcion)
                    VALUES (@NombreCategoria, @Descripcion);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCategoria", c.NombreCategoria);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)c.Descripcion ?? DBNull.Value);

                    cn.Open();

                    // ExecuteScalar devuelve un solo valor (el ID)
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            // MÉTODO: Actualizar categoría existente
        }
        public bool Actualizar(Categoria c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"UPDATE CategoriaProducto SET
                   NombreCategoria=@NombreCategoria,
                   Descripcion=@descripcion
                   WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@NombreCategoria", c.NombreCategoria);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)c.Descripcion ?? DBNull.Value);
                    /*La línea de código agrega un parámetro llamado @descripcion al comando SQL. Si la propiedad 
                     * c.Descripcion en C# es null, se envía un valor NULL a la base de datos (usando DBNull.Value); 
                     * de lo contrario, se envía el valor real de la descripción.*/

                    cn.Open();

                    // ExecuteNonQuery devuelve número de filas afectadas
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM CategoriaProducto WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    cn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable Buscar(string filtro)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT Id, NombreCategoria, Descripcion
                               FROM CategoriaProducto
                               WHERE NombreCategoria LIKE @filtro 
                                  OR Descripcion LIKE @filtro";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    // %filtro% coincide con cualquier parte del texto
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    cn.Open();

                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }
        // MÉTODO NUEVO

        public bool ExisteNombre(string NombreCategoria)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT COUNT(*) FROM CategoriaProducto WHERE NombreCategoria = @NombreCategoria";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCategoria", NombreCategoria
                        );

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // MÉTODO NUEVO: ¿Existe el nombre en OTRA categoría?
        // (Validación para EDITAR sin permitir duplicados)

        public bool ExisteNombreEnOtraCategoria(string NombreCategoria, int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT COUNT(*) 
                               FROM CategoriaProducto
                               WHERE NombreCategoria = @NombreCategoria AND Id <> @Id";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCategoria", NombreCategoria);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // MÉTODO NUEVO: Validar relación FK
        // ¿Tiene productos asociados?

        public bool TieneProductosAsociados(int Id_CategoriaProducto)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT COUNT(*) 
                               FROM Producto 
                               WHERE Id_CategoriaProducto = @id_CategoriaProducto";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id_CategoriaProducto", Id_CategoriaProducto);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

    }

}
    

    



