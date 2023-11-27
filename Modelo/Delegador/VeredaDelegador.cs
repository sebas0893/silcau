using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class VeredaDelegador
    {

        private VeredaFachada fachada = null;

        public VeredaDelegador()
        {
            try
            {
                fachada = new VeredaFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(VeredaDTO veredaDTO)
        {
            try
            {
                fachada.crear(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(VeredaDTO veredaDTO)
        {
            try
            {
                fachada.actualizar(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(VeredaDTO veredaDTO)
        {
            try
            {
                fachada.eliminar(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<VeredaDTO> consultar(VeredaDTO veredaDTO)
        {
            List<VeredaDTO> listaRetorno = null;
            try
            {
                listaRetorno = fachada.consultar(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
   
