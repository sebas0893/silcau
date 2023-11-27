using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO.DAOFactory;
using Modelo.Negocio;

namespace Modelo.Fachada
{
    public class RestriccionesFachada
    {

        public void crear(RestriccionesDTO restriccionesDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                RestriccionesNegocio restriccionesNegocio = new RestriccionesNegocio();
                restriccionesNegocio.crear(restriccionesDTO, dao);
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

        public void actualizar(RestriccionesDTO restriccionesDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                RestriccionesNegocio restriccionesNegocio = new RestriccionesNegocio();
                restriccionesNegocio.actualizar(restriccionesDTO, dao);
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

        public void eliminar(RestriccionesDTO restriccionesDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                RestriccionesNegocio restriccionesNegocio = new RestriccionesNegocio();
                restriccionesNegocio.eliminar(restriccionesDTO, dao);
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

        public List<RestriccionesDTO> consultar(RestriccionesDTO restriccionesDTO)
        {
            List<RestriccionesDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                RestriccionesNegocio restriccionesNegocio = new RestriccionesNegocio();
                listaRetorno = restriccionesNegocio.consultar(restriccionesDTO, dao);
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
