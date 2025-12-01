using proyectoPOScafeteria.Capa_Datos;
using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Negocio
{
    public class VentaBLL
    {
        public static RespuestaOperacion ValidarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            // 1) Validar existencia del objeto Venta
            if (venta == null)
                return new RespuestaOperacion { Exito = false, Mensaje = "Venta no válida." };

            // 2) Validar cliente
            if (venta.Id_Cliente <= 0)
                return new RespuestaOperacion { Exito = false, Mensaje = "Debe seleccionar un cliente." };

            // 3) Validar tipo de pago
            if (venta.Id_MetodoPago <= 0)
                return new RespuestaOperacion { Exito = false, Mensaje = "Debe seleccionar un tipo de pago." };

            // 4) Validar detalles
            if (detalles == null || detalles.Count == 0)
            {
                return new RespuestaOperacion
                {
                    Exito = false,
                    Mensaje = "La venta debe contener al menos un producto."
                };
            }

            // 5) Validar montos
            if (venta.MontoTotal <= 0)
                return new RespuestaOperacion { Exito = false, Mensaje = "El total de la venta debe ser mayor a cero." };

            // 6) Validar cada detalle
            foreach (var d in detalles)
            {
                // Validar cantidad
                if (d.Cantidad <= 0)
                    return new RespuestaOperacion
                    {
                        Exito = false,
                        Mensaje = $"La cantidad del producto ID {d.Id_Producto} es inválida."
                    };

                // Validar precio
                if (d.PrecioUnitario <= 0)
                    return new RespuestaOperacion
                    {
                        Exito = false,
                        Mensaje = $"Precio unitario inválido para el producto ID {d.Id_Producto}"
                    };

                // Validar subtotal
                if (d.Subtotal != d.Cantidad * d.PrecioUnitario)
                    return new RespuestaOperacion
                    {
                        Exito = false,
                        Mensaje = $"Subtotal incorrecto para el producto ID {d.Id_Producto}."
                    };

                // Validar stock disponible (consulta al DAL)
                int stockActual = ProductoDAL.ObtenerStock(d.Id_Producto);

                if (stockActual < d.Cantidad)
                {
                    return new RespuestaOperacion
                    {
                        Exito = false,
                        Mensaje = $"Stock insuficiente del producto ID {d.Id_Producto} (Stock actual: {stockActual})."
                    };
                }
            }

            // Si todo está OK, la BLL autoriza enviar a DAL transaccional
            return new RespuestaOperacion
            {
                Exito = true,
                Mensaje = "Validación correcta."
            };
        }
    }

}

