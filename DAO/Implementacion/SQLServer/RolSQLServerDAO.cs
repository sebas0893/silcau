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
    public class RolSQLServerDAO : IRolDAO
    {

        private SqlTransaction transaccion;

        public RolSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(RolDTO rolDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_ROL(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = rolDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(RolDTO rolDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_ROL SET NV_NOMBRE = @parametroNombre WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = rolDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = rolDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(RolDTO rolDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_ROL WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = rolDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<RolDTO> consultar(RolDTO rolDTO)
        {
            List<RolDTO> listaRol = new List<RolDTO>();
            try
            {
                String sentenciaSQL = "SELECT NM_CODIGO, NV_NOMBRE FROM LIC_ROL";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        RolDTO rolDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            rolDTOTmp = new RolDTO();
                            rolDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            rolDTOTmp.Nombre = cursorDatos.GetString(1);
                            listaRol.Add(rolDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRol;
        }

    }
}
