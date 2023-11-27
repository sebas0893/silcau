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
    public class SueloSQLServerDAO : ISueloDAO
    {

        private SqlTransaction transaccion;

        public SueloSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(SueloDTO sueloDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_SUELO(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = sueloDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(SueloDTO sueloDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_SUELO SET NV_NOMBRE = @parametroNombre WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = sueloDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = sueloDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(SueloDTO sueloDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_SUELO WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = sueloDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<SueloDTO> consultar(SueloDTO sueloDTO)
        {
            List<SueloDTO> listaSuelo = new List<SueloDTO>();
            try
            {
                String sentenciaSQL = "SELECT NM_CODIGO, NV_NOMBRE FROM LIC_SUELO ORDER BY NM_CODIGO";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        SueloDTO sueloDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            sueloDTOTmp = new SueloDTO();
                            sueloDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            sueloDTOTmp.Nombre = cursorDatos.GetString(1);
                            listaSuelo.Add(sueloDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaSuelo;
        }

    }
}
