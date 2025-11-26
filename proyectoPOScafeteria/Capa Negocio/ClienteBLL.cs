using proyectoPOScafeteria.Capa_Datos;
using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPOScafeteria.Capa_Negocio
{
    public class ClienteBLL
    {
        ClienteDAL dal = new ClienteDAL();

        public DataTable Listar()
            { return dal.Listar(); }

        public int Guardar(Clientedos c)
        {
            //VALIDACIONES(van solo aqui)
            if (string.IsNullOrWhiteSpace(c.Nombre))
                throw new Exception("El nombre del cliente es obligatorio.");
            //Si el id es 0, es un nuevo cliente
            if (c.Id == 0)
            {
                if (dal.ExisteNombre(c.Nombre))
                    throw new Exception("Ya existe un cliente con ese nombre.");

                return dal.Insertar(c);
            }
            else
            {
                if (dal.ExisteNombreEnOtroCliente(c.Nombre, c.Id))
                    throw new Exception("Ya existe otro cliente con ese nombre.");

                dal.Actualizar(c);
                return c.Id;
            }
        }
        
        public void Eliminar(int id)
        {
            if (dal.TieneVentasAsociadas(id))
                MessageBox.Show("Este cliente tiene ventas registradas. No se puede eliminar.",
                      "Aviso",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            return;
            {
                dal.Eliminar(id);
        }
        }

        
        public DataTable Buscar(string nombre)
        {
            return dal.Buscar(nombre);
        }

}
}
