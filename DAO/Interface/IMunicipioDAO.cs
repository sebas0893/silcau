using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IMunicipioDAO
    {

        void crear(MunicipioDTO municipioDTO);

        void actualizar(MunicipioDTO municipioDTO);

        void eliminar(MunicipioDTO municipioDTO);

        List<MunicipioDTO> consultar(MunicipioDTO municipioDTO);

    }
}
