using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class UsuarioDelegador
    {

        private UsuarioFachada fachada = null;

        public UsuarioDelegador()
        {
            try
            {
                fachada = new UsuarioFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(UsuarioDTO UsuarioDTO)
        {
            try
            {
                fachada.crear(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(UsuarioDTO UsuarioDTO)
        {
            try
            {
                fachada.actualizar(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizarAcceso(UsuarioDTO UsuarioDTO)
        {
            try
            {
                fachada.actualizarAcceso(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void inactivar(UsuarioDTO UsuarioDTO)
        {
            try
            {
                fachada.inactivar(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(UsuarioDTO UsuarioDTO)
        {
            try
            {
                fachada.eliminar(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<UsuarioDTO> consultar(UsuarioDTO UsuarioDTO)
        {
            List<UsuarioDTO> listaUsuarios = null;
            try
            {
                listaUsuarios = fachada.consultar(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaUsuarios;
        }

        public List<UsuarioDTO> consultarEntidades(UsuarioDTO UsuarioDTO)
        {
            List<UsuarioDTO> listaUsuarios = null;
            try
            {
                listaUsuarios = fachada.consultarEntidades(UsuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaUsuarios;
        }

    }
}