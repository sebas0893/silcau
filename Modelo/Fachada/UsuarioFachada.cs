using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO.DAOFactory;
using Modelo.Negocio;

namespace Modelo.Fachada
{
    public class UsuarioFachada
    {

        public void crear(UsuarioDTO usuarioDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.crear(usuarioDTO, dao);
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

        public void actualizar(UsuarioDTO usuarioDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.actualizar(usuarioDTO, dao);
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

        public void actualizarAcceso(UsuarioDTO usuarioDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.actualizarAcceso(usuarioDTO, dao);
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

        public void inactivar(UsuarioDTO usuarioDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.inactivar(usuarioDTO, dao);
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

        public void eliminar(UsuarioDTO usuarioDTO)
        {
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.eliminar(usuarioDTO, dao);
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

        public List<UsuarioDTO> consultar(UsuarioDTO usuarioDTO)
        {
            List<UsuarioDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                listaRetorno = usuarioNegocio.consultar(usuarioDTO, dao);
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

        public List<UsuarioDTO> consultarEntidades(UsuarioDTO usuarioDTO)
        {
            List<UsuarioDTO> listaRetorno = null;
            DAOFactory dao = null;
            try
            {
                dao = DAOFactory.getDAOFactory(1);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                listaRetorno = usuarioNegocio.consultarEntidades(usuarioDTO, dao);
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
