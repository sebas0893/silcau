using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{    
    public interface IUsuarioDAO
    {

        void crear(UsuarioDTO usuarioDTO);

        void actualizar(UsuarioDTO usuarioDTO);
        void actualizarAcceso(UsuarioDTO usuarioDTO);

        void inactivar(UsuarioDTO usuarioDTO);
        void eliminar(UsuarioDTO usuarioDTO);

        List<UsuarioDTO> consultar(UsuarioDTO usuarioDTO);
        List<UsuarioDTO> consultarEntidades(UsuarioDTO usuarioDTO);

    }
}
