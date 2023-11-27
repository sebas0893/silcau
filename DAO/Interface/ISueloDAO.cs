using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface ISueloDAO
    {

        void crear(SueloDTO sueloDTO);

        void actualizar(SueloDTO sueloDTO);

        void eliminar(SueloDTO sueloDTO);

        List<SueloDTO> consultar(SueloDTO sueloDTO);

    }
}
