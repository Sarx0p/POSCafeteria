using proyectoPOScafeteria.Capa_Datos;
using proyectoPOScafeteria.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Si el Id es 0, es un nuevo cliente
            if (c.Id == 0)
            {
                return dal.Insertar(c);
            }
            else
            {
                dal.Actualizar(c);
                return c.Id;
            }
        }
        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
        public DataTable Buscar(string nombre)
        {
            return dal.Buscar(nombre);
        }

}
}
