using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class RolNegocio
    {

        public void crear(RolDTO rolDTO, DAOFactory dao)
        {
            try
            {
                IRolDAO rolDAO = dao.getRolDAO();
                rolDAO.crear(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(RolDTO rolDTO, DAOFactory dao)
        {
            try
            {
                IRolDAO rolDAO = dao.getRolDAO();
                rolDAO.actualizar(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(RolDTO rolDTO, DAOFactory dao)
        {
            try
            {
                IRolDAO rolDAO = dao.getRolDAO();
                rolDAO.eliminar(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<RolDTO> consultar(RolDTO rolDTO, DAOFactory dao)
        {
            List<RolDTO> listaRetorno = null;
            try
            {
                IRolDAO rolDAO = dao.getRolDAO();
                listaRetorno = rolDAO.consultar(rolDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
