using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class RestriccionesNegocio
    {

        public void crear(RestriccionesDTO restriccionesDTO, DAOFactory dao)
        {
            try
            {
                IRestriccionesDAO restriccionesDAO = dao.getRestriccionesDAO();
                restriccionesDAO.crear(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(RestriccionesDTO restriccionesDTO, DAOFactory dao)
        {
            try
            {
                IRestriccionesDAO restriccionesDAO = dao.getRestriccionesDAO();
                restriccionesDAO.actualizar(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(RestriccionesDTO restriccionesDTO, DAOFactory dao)
        {
            try
            {
                IRestriccionesDAO restriccionesDAO = dao.getRestriccionesDAO();
                restriccionesDAO.eliminar(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<RestriccionesDTO> consultar(RestriccionesDTO restriccionesDTO, DAOFactory dao)
        {
            List<RestriccionesDTO> listaRetorno = null;
            try
            {
                IRestriccionesDAO restriccionesDAO = dao.getRestriccionesDAO();
                listaRetorno = restriccionesDAO.consultar(restriccionesDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
