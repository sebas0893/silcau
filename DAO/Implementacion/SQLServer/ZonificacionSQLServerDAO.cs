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
    public class ZonificacionSQLServerDAO : IZonificacionDAO
    {

        private SqlTransaction transaccion;

        public ZonificacionSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(ZonificacionDTO zonificacionDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_ZONIFICACION(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = zonificacionDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(ZonificacionDTO zonificacionDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_ZONIFICACION SET NV_NOMBRE = @parametroNombre WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = zonificacionDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = zonificacionDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(ZonificacionDTO zonificacionDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_ZONIFICACION WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = zonificacionDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ZonificacionDTO> consultar(ZonificacionDTO zonificacionDTO)
        {
            List<ZonificacionDTO> listaZonificacion = new List<ZonificacionDTO>();
            try
            {
                String sentenciaSQL = "SELECT NM_CODIGO, NV_NOMBRE FROM LIC_ZONIFICACION ORDER BY NM_CODIGO";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        ZonificacionDTO zonificacionDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            zonificacionDTOTmp = new ZonificacionDTO();
                            zonificacionDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            zonificacionDTOTmp.Nombre = cursorDatos.GetString(1);
                            listaZonificacion.Add(zonificacionDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaZonificacion;
        }

    }
}
