using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class ZonificacionDelegador
    {

        private ZonificacionFachada fachada = null;

        public ZonificacionDelegador()
        {
            try
            {
                fachada = new ZonificacionFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(ZonificacionDTO zonificacionDTO)
        {
            try
            {
                fachada.crear(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(ZonificacionDTO zonificacionDTO)
        {
            try
            {
                fachada.actualizar(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(ZonificacionDTO zonificacionDTO)
        {
            try
            {
                fachada.eliminar(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ZonificacionDTO> consultar(ZonificacionDTO zonificacionDTO)
        {
            List<ZonificacionDTO> listaZonificaciones = null;
            try
            {
                listaZonificaciones = fachada.consultar(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaZonificaciones;
        }

    }
}