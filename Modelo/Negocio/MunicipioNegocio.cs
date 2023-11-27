using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class MunicipioNegocio
    {

        public void crear(MunicipioDTO municipioDTO, DAOFactory dao)
        {
            try
            {
                IMunicipioDAO municipioDAO = dao.getMunicipioDAO();
                municipioDAO.crear(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(MunicipioDTO municipioDTO, DAOFactory dao)
        {
            try
            {
                IMunicipioDAO municipioDAO = dao.getMunicipioDAO();
                municipioDAO.actualizar(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(MunicipioDTO municipioDTO, DAOFactory dao)
        {
            try
            {
                IMunicipioDAO municipioDAO = dao.getMunicipioDAO();
                municipioDAO.eliminar(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<MunicipioDTO> consultar(MunicipioDTO municipioDTO, DAOFactory dao)
        {
            List<MunicipioDTO> listaRetorno = null;
            try
            {
                IMunicipioDAO municipioDAO = dao.getMunicipioDAO();
                listaRetorno = municipioDAO.consultar(municipioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
