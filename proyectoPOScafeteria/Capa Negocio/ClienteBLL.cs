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

        public int Guardar (Clientedos c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
                throw new Exception("El nombre del cliente es obligatorio.");
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

}
}
