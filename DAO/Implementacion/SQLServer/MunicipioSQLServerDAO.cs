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
    public class MunicipioSQLServerDAO : IMunicipioDAO
    {

        private SqlTransaction transaccion;

        public MunicipioSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }
        
        public void crear(MunicipioDTO municipioDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_MUNICIPIO(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = municipioDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(MunicipioDTO municipioDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_MUNICIPIO SET NV_NOMBRE = @parametroNombre WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = municipioDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = municipioDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(MunicipioDTO municipioDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_MUNICIPIO WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = municipioDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<MunicipioDTO> consultar(MunicipioDTO municipioDTO)
        {
            List<MunicipioDTO> listaMunicipio = new List<MunicipioDTO>();
            try
            {
                String sentenciaSQL = "SELECT M.NM_CODIGO, M.NV_NOMBRE, M.NM_REGIONAL " +
                                      "FROM LIC_MUNICIPIO M " +
                                      "WHERE M.NM_CODIGO > 0";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    if (municipioDTO != null)
                    {
                        // Consultar por codigo
                        if (municipioDTO.Codigo != 0)
                        {
                            sentenciaSQL += " AND M.NM_CODIGO = @parametroCodigo";
                            comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = municipioDTO.Codigo;
                        }
                        // Consultar por registro (No incluir usuarios bloqueados)
                        if (municipioDTO.Registro)
                        {
                            sentenciaSQL += " AND NOT EXISTS (SELECT U.NM_MUNICIPIO FROM LIC_USUARIO U WHERE M.NM_CODIGO = U.NM_MUNICIPIO AND U.NM_ESTADO != 3)";
                        }
                    }
                    sentenciaSQL += " ORDER BY M.NV_NOMBRE";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        MunicipioDTO municipioDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            municipioDTOTmp = new MunicipioDTO();
                            municipioDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            municipioDTOTmp.Nombre = cursorDatos.GetString(1);
                            municipioDTOTmp.Regional = (int)cursorDatos.GetDecimal(2);
                            listaMunicipio.Add(municipioDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaMunicipio;
        }

    }
}