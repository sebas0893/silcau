using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO.DAOFactory;
using Modelo.Negocio;

namespace Modelo.Fachada
{
    public class SueloFachada
    {

        public void crear(SueloDTO sueloDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                SueloNegocio sueloNegocio = new SueloNegocio();
                sueloNegocio.crear(sueloDTO, dao);
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

        public void actualizar(SueloDTO sueloDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                SueloNegocio sueloNegocio = new SueloNegocio();
                sueloNegocio.actualizar(sueloDTO, dao);
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

        public void eliminar(SueloDTO sueloDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                SueloNegocio sueloNegocio = new SueloNegocio();
                sueloNegocio.eliminar(sueloDTO, dao);
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

        public List<SueloDTO> consultar(SueloDTO sueloDTO)
        {
            List<SueloDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                SueloNegocio sueloNegocio = new SueloNegocio();
                listaRetorno = sueloNegocio.consultar(sueloDTO, dao);
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
