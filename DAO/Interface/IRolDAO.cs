using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IRolDAO
    {

        void crear(RolDTO rolDTO);

        void actualizar(RolDTO rolDTO);

        void eliminar(RolDTO rolDTO);

        List<RolDTO> consultar(RolDTO rolDTO);

    }
}
