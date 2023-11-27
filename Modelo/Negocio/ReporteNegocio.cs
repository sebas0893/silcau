using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class ReporteNegocio
    {

        public long crear(ReporteDTO reporteDTO, DAOFactory dao)
        {
            try
            {
                IReporteDAO reporteDAO = dao.getReporteDAO();
                return reporteDAO.crear(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void enviar(ReporteDTO reporteDTO, DAOFactory dao)
        {
            try
            {
                IReporteDAO reporteDAO = dao.getReporteDAO();
                reporteDAO.enviar(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void devolver(ReporteDTO reporteDTO, DAOFactory dao)
        {
            try
            {
                IReporteDAO reporteDAO = dao.getReporteDAO();
                reporteDAO.devolver(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(ReporteDTO reporteDTO, DAOFactory dao)
        {
            try
            {
                IReporteDAO reporteDAO = dao.getReporteDAO();
                reporteDAO.eliminar(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ReporteDTO> consultar(ReporteDTO reporteDTO, DAOFactory dao)
        {
            List<ReporteDTO> listaRetorno = null;
            try
            {
                IReporteDAO reporteDAO = dao.getReporteDAO();
                listaRetorno = reporteDAO.consultar(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

        public List<ReporteDTO> reportes(ReporteDTO reporteDTO, DAOFactory dao)
        {
            List<ReporteDTO> listaRetorno = null;
            try
            {
                IReporteDAO reporteDAO = dao.getReporteDAO();
                listaRetorno = reporteDAO.reportes(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}