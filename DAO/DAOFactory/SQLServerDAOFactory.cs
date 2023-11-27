using System;
using DAO.Implementacion.SQLServer;
using DAO.Interface;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAO.DAOFactory
{
    public class SQLServerDAOFactory : DAOFactory
    {

        private SqlConnection conexion = null;
        private SqlTransaction transaccion = null;

        // Constructor de la clase, encargado de abrir la conexión a la base de datos
        public SQLServerDAOFactory()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["conexionSQLServer"].ConnectionString;
                conexion = new SqlConnection(conString);
                conexion.Open();
                iniciarTransaccion();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        // Método para iniciar una transacción de base de datos
        public override void iniciarTransaccion()
        {
            if (conexion != null)
            {
                transaccion = conexion.BeginTransaction(IsolationLevel.ReadUncommitted);
            }
        }

        // Método para confirmar una transacción de base de datos
        public override void confirmarTransaccion()
        {
            if (transaccion != null)
            {
                transaccion.Commit();
            }
        }

        // Método para cancelar una transacción de base de datos
        public override void cancelarTransaccion()
        {
            if (transaccion != null)
            {
                transaccion.Rollback();
            }
        }

        // Método cerrar la conexión a la base de datos
        public override void cerrarConexion()
        {
            if (transaccion != null)
            {
                transaccion.Dispose();
            }
            if (conexion != null)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        public override IAutorizacionDAO getAutorizacionDAO()
        {
            return new AutorizacionSQLServerDAO(transaccion);
        }

        public override IDetalleReporteDAO getDetalleReporteDAO()
        {
            return new DetalleReporteSQLServerDAO(transaccion);
        }

        public override IMunicipioDAO getMunicipioDAO()
        {
            return new MunicipioSQLServerDAO(transaccion);
        }

        public override IReporteDAO getReporteDAO()
        {
            return new ReporteSQLServerDAO(transaccion);
        }

        public override IRestriccionesDAO getRestriccionesDAO()
        {
            return new RestriccionesSQLServerDAO(transaccion);
        }

        public override IRolDAO getRolDAO()
        {
            return new RolSQLServerDAO(transaccion);
        }

        public override ISueloDAO getSueloDAO()
        {
            return new SueloSQLServerDAO(transaccion);
        }

        public override IUsuarioDAO getUsuarioDAO()
        {
            return new UsuarioSQLServerDAO(transaccion);
        }

        public override IVeredaDAO getVeredaDAO()
        {
            return new VeredaSQLServerDAO(transaccion);
        }

        public override IZonificacionDAO getZonificacionDAO()
        {
            return new ZonificacionSQLServerDAO(transaccion);
        }

    }
}