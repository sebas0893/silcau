using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class ZonificacionNegocio
    {

        public void crear(ZonificacionDTO zonificacionDTO, DAOFactory dao)
        {
            try
            {
                IZonificacionDAO zonificacionDAO = dao.getZonificacionDAO();
                zonificacionDAO.crear(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(ZonificacionDTO zonificacionDTO, DAOFactory dao)
        {
            try
            {
                IZonificacionDAO zonificacionDAO = dao.getZonificacionDAO();
                zonificacionDAO.actualizar(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(ZonificacionDTO zonificacionDTO, DAOFactory dao)
        {
            try
            {
                IZonificacionDAO zonificacionDAO = dao.getZonificacionDAO();
                zonificacionDAO.eliminar(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ZonificacionDTO> consultar(ZonificacionDTO zonificacionDTO, DAOFactory dao)
        {
            List<ZonificacionDTO> listaRetorno = null;
            try
            {
                IZonificacionDAO zonificacionDAO = dao.getZonificacionDAO();
                listaRetorno = zonificacionDAO.consultar(zonificacionDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
