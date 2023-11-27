using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO.DAOFactory;
using Modelo.Negocio;

namespace Modelo.Fachada
{
    public class DetalleReporteFachada
    {

        public void crear(DetalleReporteDTO detalleReporteDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                DetalleReporteNegocio detalleReporteNegocio = new DetalleReporteNegocio();
                detalleReporteNegocio.crear(detalleReporteDTO, dao);
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

        public void actualizar(DetalleReporteDTO detalleReporteDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                DetalleReporteNegocio detalleReporteNegocio = new DetalleReporteNegocio();
                detalleReporteNegocio.actualizar(detalleReporteDTO, dao);
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

        public void eliminar(DetalleReporteDTO detalleReporteDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                DetalleReporteNegocio detalleReporteNegocio = new DetalleReporteNegocio();
                detalleReporteNegocio.eliminar(detalleReporteDTO, dao);
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

        public List<DetalleReporteDTO> consultar(DetalleReporteDTO detalleReporteDTO)
        {
            List<DetalleReporteDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                DetalleReporteNegocio detalleReporteNegocio = new DetalleReporteNegocio();
                listaRetorno = detalleReporteNegocio.consultar(detalleReporteDTO, dao);
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

        public List<DetalleReporteDTO> reporte(DetalleReporteDTO detalleReporteDTO)
        {
            List<DetalleReporteDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                DetalleReporteNegocio detalleReporteNegocio = new DetalleReporteNegocio();
                listaRetorno = detalleReporteNegocio.reporte(detalleReporteDTO, dao);
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
