using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IRestriccionesDAO
    {

        void crear(RestriccionesDTO restriccionesDTO);

        void actualizar(RestriccionesDTO restriccionesDTO);

        void eliminar(RestriccionesDTO restriccionesDTO);

        List<RestriccionesDTO> consultar(RestriccionesDTO restriccionesDTO);

    }
}
