using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IAutorizacionDAO
    {

        void crear(AutorizacionDTO autorizacionDTO);

        void actualizar(AutorizacionDTO autorizacionDTO);

        void eliminar(AutorizacionDTO autorizacionDTO);

        List<AutorizacionDTO> consultar(AutorizacionDTO autorizacionDTO);

    }
}
