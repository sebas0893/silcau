using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class MunicipioDelegador
    {

        private MunicipioFachada fachada = null;

        public MunicipioDelegador()
        {
            try
            {
                fachada = new MunicipioFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(MunicipioDTO municipioDTO)
        {
            try
            {
                fachada.crear(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(MunicipioDTO municipioDTO)
        {
            try
            {
                fachada.actualizar(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(MunicipioDTO municipioDTO)
        {
            try
            {
                fachada.eliminar(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<MunicipioDTO> consultar(MunicipioDTO municipioDTO)
        {
            List<MunicipioDTO> listaMunicipios = null;
            try
            {
                listaMunicipios = fachada.consultar(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaMunicipios;
        }

    }
}