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
    public class RestriccionesSQLServerDAO : IRestriccionesDAO
    {

        private SqlTransaction transaccion;

        public RestriccionesSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(RestriccionesDTO restriccionesDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_RESTRICCIONES(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = restriccionesDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(RestriccionesDTO restriccionesDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_RESTRICCIONES SET NV_NOMBRE = @parametroNombre WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = restriccionesDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = restriccionesDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(RestriccionesDTO restriccionesDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_RESTRICCIONES WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = restriccionesDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<RestriccionesDTO> consultar(RestriccionesDTO restriccionesDTO)
        {
            List<RestriccionesDTO> listaRestricciones = new List<RestriccionesDTO>();
            try
            {
                String sentenciaSQL = "SELECT NM_CODIGO, NV_NOMBRE FROM LIC_RESTRICCIONES ORDER BY NM_CODIGO";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        RestriccionesDTO restriccionesDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            restriccionesDTOTmp = new RestriccionesDTO();
                            restriccionesDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            restriccionesDTOTmp.Nombre = cursorDatos.GetString(1);
                            listaRestricciones.Add(restriccionesDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRestricciones;
        }

    }
}
