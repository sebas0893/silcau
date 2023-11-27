using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.DAOFactory;
using System.Data.SqlClient;
using DAO.Interface;

namespace DAO.DAOFactory
{
    public abstract class DAOFactory
    {

        // Método encargado de instanciar una Factoria determinada
        public static DAOFactory getDAOFactory(int factoria)
        {
            DAOFactory factoriaDAO = null;
            try
            {
                switch (factoria)
                {
                    case 1:
                        // SQLServer (1)
                        factoriaDAO = new SQLServerDAOFactory();
                        break;
                    default:
                        factoriaDAO = new SQLServerDAOFactory();
                        break;
                }
                return factoriaDAO;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        // Método para iniciar una transacción al origen de datos
        public abstract void iniciarTransaccion();

        // Método para confirmar una transacción realizada en el origen de datos
        public abstract void confirmarTransaccion();

        // Método para cancelar una transacción en el origen de datos
        public abstract void cancelarTransaccion();

        // Método para la cerrar la conexión con el origen de datos
        public abstract void cerrarConexion();

        // Métodos para obtener interfaces

        public abstract IAutorizacionDAO getAutorizacionDAO();

        public abstract IDetalleReporteDAO getDetalleReporteDAO();

        public abstract IMunicipioDAO getMunicipioDAO();

        public abstract IReporteDAO getReporteDAO();

        public abstract IRestriccionesDAO getRestriccionesDAO();
        
        public abstract IRolDAO getRolDAO();

        public abstract ISueloDAO getSueloDAO();

        public abstract IUsuarioDAO getUsuarioDAO();

        public abstract IVeredaDAO getVeredaDAO();

        public abstract IZonificacionDAO getZonificacionDAO();

    }
}
