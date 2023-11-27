using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO.DAOFactory;
using Modelo.Negocio;

namespace Modelo.Fachada
{
    public class ReporteFachada
    {

        public long crear(ReporteDTO reporteDTO)
        {
            DAOFactory dao = null;
            long codigo = 0;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                codigo = reporteNegocio.crear(reporteDTO, dao);
                dao.confirmarTransaccion();
            }
            catch (Exception exc)
            {
                if (dao != null)
                {
                    dao.cancelarTransaccion();
                }
                throw exc;
            }
            finally
            {
                if (dao != null)
                {
                    dao.cerrarConexion();
                }
            }
            return codigo;
        }

        public void enviar(ReporteDTO reporteDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                reporteNegocio.enviar(reporteDTO, dao);
                dao.confirmarTransaccion();
            }
            catch (Exception exc)
            {
                if (dao != null)
                {
                    dao.cancelarTransaccion();
                }
                throw exc;
            }
            finally
            {
                if (dao != null)
                {
                    dao.cerrarConexion();
                }
            }
        }

        public void devolver(ReporteDTO reporteDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                reporteNegocio.devolver(reporteDTO, dao);
                dao.confirmarTransaccion();
            }
            catch (Exception exc)
            {
                if (dao != null)
                {
                    dao.cancelarTransaccion();
                }
                throw exc;
            }
            finally
            {
                if (dao != null)
                {
                    dao.cerrarConexion();
                }
            }
        }

        public void eliminar(ReporteDTO reporteDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                reporteNegocio.eliminar(reporteDTO, dao);
                dao.confirmarTransaccion();
            }
            catch (Exception exc)
            {
                if (dao != null)
                {
                    dao.cancelarTransaccion();
                }
                throw exc;
            }
            finally
            {
                if (dao != null)
                {
                    dao.cerrarConexion();
                }
            }
        }

        public List<ReporteDTO> consultar(ReporteDTO reporteDTO)
        {
            List<ReporteDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                listaRetorno = reporteNegocio.consultar(reporteDTO, dao);
                dao.confirmarTransaccion();
            }
            catch (Exception exc)
            {
                if (dao != null)
                {
                    dao.cancelarTransaccion();
                }
                throw exc;
            }
            finally
            {
                if (dao != null)
                {
                    dao.cerrarConexion();
                }
            }
            return listaRetorno;
        }

        public List<ReporteDTO> reportes(ReporteDTO reporteDTO)
        {
            List<ReporteDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                listaRetorno = reporteNegocio.reportes(reporteDTO, dao);
                dao.confirmarTransaccion();
            }
            catch (Exception exc)
            {
                if (dao != null)
                {
                    dao.cancelarTransaccion();
                }
                throw exc;
            }
            finally
            {
                if (dao != null)
                {
                    dao.cerrarConexion();
                }
            }
            return listaRetorno;
        }

    }
}