using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IVeredaDAO
    {
        void crear(VeredaDTO veredaDTO);

        List<VeredaDTO> consultar(VeredaDTO veredaDTO);

        void eliminar(VeredaDTO veredaDTO);

        void actualizar(VeredaDTO veredaDTO);
    }
}
