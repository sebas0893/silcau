using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class RolDelegador
    {

        private RolFachada fachada = null;

        public RolDelegador()
        {
            try
            {
                fachada = new RolFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(RolDTO rolDTO)
        {
            try
            {
                fachada.crear(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(RolDTO rolDTO)
        {
            try
            {
                fachada.actualizar(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(RolDTO rolDTO)
        {
            try
            {
                fachada.eliminar(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<RolDTO> consultar(RolDTO rolDTO)
        {
            List<RolDTO> listaRoles = null;
            try
            {
                listaRoles = fachada.consultar(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRoles;
        }

    }
}