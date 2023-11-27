using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IZonificacionDAO
    {

        void crear(ZonificacionDTO zonificacionDTO);

        void actualizar(ZonificacionDTO zonificacionDTO);

        void eliminar(ZonificacionDTO zonificacionDTO);

        List<ZonificacionDTO> consultar(ZonificacionDTO zonificacionDTO);

    }
}
