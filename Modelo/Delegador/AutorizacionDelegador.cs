using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class AutorizacionDelegador
    {

        private AutorizacionFachada fachada = null;

        public AutorizacionDelegador()
        {
            try
            {
                fachada = new AutorizacionFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(AutorizacionDTO autorizacionDTO)
        {
            try
            {
                fachada.crear(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(AutorizacionDTO autorizacionDTO)
        {
            try
            {
                fachada.actualizar(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(AutorizacionDTO autorizacionDTO)
        {
            try
            {
                fachada.eliminar(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<AutorizacionDTO> consultar(AutorizacionDTO autorizacionDTO)
        {
            List<AutorizacionDTO> listaAutorizacion = null;
            try
            {
                listaAutorizacion = fachada.consultar(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaAutorizacion;
        }

    }
}