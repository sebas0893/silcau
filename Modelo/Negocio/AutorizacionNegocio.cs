using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class AutorizacionNegocio
    {

        public void crear(AutorizacionDTO autorizacionDTO, DAOFactory dao)
        {
            try
            {
                IAutorizacionDAO autorizacionDAO = dao.getAutorizacionDAO();
                autorizacionDAO.crear(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(AutorizacionDTO autorizacionDTO, DAOFactory dao)
        {
            try
            {
                IAutorizacionDAO autorizacionDAO = dao.getAutorizacionDAO();
                autorizacionDAO.actualizar(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(AutorizacionDTO autorizacionDTO, DAOFactory dao)
        {
            try
            {
                IAutorizacionDAO autorizacionDAO = dao.getAutorizacionDAO();
                autorizacionDAO.eliminar(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<AutorizacionDTO> consultar(AutorizacionDTO autorizacionDTO, DAOFactory dao)
        {
            List<AutorizacionDTO> listaRetorno = null;
            try
            {
                IAutorizacionDAO autorizacionDAO = dao.getAutorizacionDAO();
                listaRetorno = autorizacionDAO.consultar(autorizacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
