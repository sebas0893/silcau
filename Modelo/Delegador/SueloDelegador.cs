using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class SueloDelegador
    {

        private SueloFachada fachada = null;

        public SueloDelegador()
        {
            try
            {
                fachada = new SueloFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(SueloDTO sueloDTO)
        {
            try
            {
                fachada.crear(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(SueloDTO sueloDTO)
        {
            try
            {
                fachada.actualizar(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(SueloDTO sueloDTO)
        {
            try
            {
                fachada.eliminar(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<SueloDTO> consultar(SueloDTO sueloDTO)
        {
            List<SueloDTO> listaSuelos = null;
            try
            {
                listaSuelos = fachada.consultar(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaSuelos;
        }

    }
}