using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAO.Interface;
using Entidad;

namespace DAO.Implementacion.SQLServer
{
    public class AutorizacionSQLServerDAO : IAutorizacionDAO
    {

        private SqlTransaction transaccion;

        public AutorizacionSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(AutorizacionDTO autorizacionDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_AUTORIZACION(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = autorizacionDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(AutorizacionDTO autorizacionDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_AUTORIZACION SET NV_NOMBRE = @parametroNombre WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = autorizacionDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = autorizacionDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(AutorizacionDTO autorizacionDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_AUTORIZACION WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = autorizacionDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<AutorizacionDTO> consultar(AutorizacionDTO autorizacionDTO)
        {
            List<AutorizacionDTO> listaAutorizacion = new List<AutorizacionDTO>();
            try
            {
                String sentenciaSQL = "SELECT NM_CODIGO, NV_NOMBRE FROM LIC_AUTORIZACION ORDER BY NM_CODIGO";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        AutorizacionDTO autorizacionDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            autorizacionDTOTmp = new AutorizacionDTO();
                            autorizacionDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            autorizacionDTOTmp.Nombre = cursorDatos.GetString(1);
                            listaAutorizacion.Add(autorizacionDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaAutorizacion;
        }

    }
}
