using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Datos
{
    public class VentaDAL
    {
         
        public static (bool Exito, string Mensaje) RegistrarVentaTransaccional(Venta venta, List<DetalleVenta> detalles)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();

                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    // 1) INSERTAMOS VENTA Y RECUPERAMOS ID DE LA VENTA INGRESADA

                    string sqlVenta = @"
                        INSERT INTO Venta (FechaVenta, MontoTotal, Id_MetodoPago, Id_Cliente)
                        VALUES (@FechaVenta, @MontoTotal, @Id_MetodoPago, @Id_Cliente);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlVenta, con, tx))
                    {
                        cmd.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                        cmd.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
                        cmd.Parameters.AddWithValue("@Id_MetodoPago", venta.Id_MetodoPago);
                        cmd.Parameters.AddWithValue("@Id_Cliente", venta.Id_Cliente);

                        // Recuperamos ID generado
                        venta.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2) INSERTAMOS LOS DETALLES

                    string sqlDetalle = @"
                        INSERT INTO DetalleVenta (Cantidad, PrecioUnitario, SubTotal, Id_Venta, Id_Producto)
                        VALUES (@Cantidad, @PrecioUnitario, @SubTotal, @Id_Venta, @Id_Producto);";

                    // Acumular cantidades por producto (para descontar stock una sola vez)
                    var acumulador = new Dictionary<int, int>();

                    foreach (var d in detalles)
                    {
                        // A) Insertar detalle de venta
                        using (SqlCommand cmdDet = new SqlCommand(sqlDetalle, con, tx))
                        {
                            cmdDet.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                            cmdDet.Parameters.AddWithValue("@PrecioUnitario", d.PrecioUnitario);
                            cmdDet.Parameters.AddWithValue("@SubTotal", d.Subtotal);
                            cmdDet.Parameters.AddWithValue("@Id_Venta", venta.Id);
                            cmdDet.Parameters.AddWithValue("@Id_Producto", d.Id_Producto);

                            cmdDet.ExecuteNonQuery();
                        }

                        // B) Actualizar acumulador
                        if (!acumulador.ContainsKey(d.Id_Producto))
                            acumulador[d.Id_Producto] = 0;

                        acumulador[d.Id_Producto] += d.Cantidad;
                    }

                    // 3) DESCONTAREMOS EL STOCK (validación interna)

                    string sqlStock = @"
                        UPDATE Producto
                        SET Stock = Stock - @Cant
                        WHERE Id = @IdProducto AND Stock >= @Cant;";

                    foreach (var item in acumulador)
                    {
                        using (SqlCommand cmdStock = new SqlCommand(sqlStock, con, tx))
                        {
                            cmdStock.Parameters.AddWithValue("@Cant", item.Value);
                            cmdStock.Parameters.AddWithValue("@IdProducto", item.Key);

                            int filas = cmdStock.ExecuteNonQuery();

                            // Si no se afectó ninguna fila → NO había stock suficiente
                            if (filas == 0)
                                throw new Exception("Stock insuficiente para el producto ID: " + item.Key);
                        }
                    }

                    // 4) CONFIRMAMOS LA TRANSACCIÓN
                    tx.Commit();

                    return (true, "Venta registrada con éxito. ID generado: " + venta.Id);
                }
                catch (Exception ex)
                {
                    // Si algo falla → revertir todo
                    tx.Rollback();
                    return (false, "Error al registrar venta: " + ex.Message);
                }
            }
        }
    }

}

