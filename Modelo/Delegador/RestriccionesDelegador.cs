using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class RestriccionesDelegador
    {

        private RestriccionesFachada fachada = null;

        public RestriccionesDelegador()
        {
            try
            {
                fachada = new RestriccionesFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(RestriccionesDTO restriccionesDTO)
        {
            try
            {
                fachada.crear(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(RestriccionesDTO restriccionesDTO)
        {
            try
            {
                fachada.actualizar(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(RestriccionesDTO restriccionesDTO)
        {
            try
            {
                fachada.eliminar(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<RestriccionesDTO> consultar(RestriccionesDTO restriccionesDTO)
        {
            List<RestriccionesDTO> listaRestricciones = null;
            try
            {
                listaRestricciones = fachada.consultar(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRestricciones;
        }

    }
}