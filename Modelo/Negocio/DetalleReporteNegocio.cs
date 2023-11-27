using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class DetalleReporteNegocio
    {

        public void crear(DetalleReporteDTO detalleReporteDTO, DAOFactory dao)
        {
            try
            {
                IDetalleReporteDAO detalleReporteDAO = dao.getDetalleReporteDAO();
                detalleReporteDAO.crear(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(DetalleReporteDTO detalleReporteDTO, DAOFactory dao)
        {
            try
            {
                IDetalleReporteDAO detalleReporteDAO = dao.getDetalleReporteDAO();
                detalleReporteDAO.actualizar(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(DetalleReporteDTO detalleReporteDTO, DAOFactory dao)
        {
            try
            {
                IDetalleReporteDAO detalleReporteDAO = dao.getDetalleReporteDAO();
                detalleReporteDAO.eliminar(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<DetalleReporteDTO> consultar(DetalleReporteDTO detalleReporteDTO, DAOFactory dao)
        {
            List<DetalleReporteDTO> listaRetorno = null;
            try
            {
                IDetalleReporteDAO detalleReporteDAO = dao.getDetalleReporteDAO();
                listaRetorno = detalleReporteDAO.consultar(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

        public List<DetalleReporteDTO> reporte(DetalleReporteDTO detalleReporteDTO, DAOFactory dao)
        {
            List<DetalleReporteDTO> listaRetorno = null;
            try
            {
                IDetalleReporteDAO detalleReporteDAO = dao.getDetalleReporteDAO();
                listaRetorno = detalleReporteDAO.reporte(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
