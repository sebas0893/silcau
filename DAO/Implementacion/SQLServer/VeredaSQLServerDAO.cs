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
    public class VeredaSQLServerDAO: IVeredaDAO
    {
        
        private SqlTransaction transaccion;

        public VeredaSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(VeredaDTO veredaDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_VEREDA(NV_NOMBRE) VALUES(@parametroNombre)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = veredaDTO.Nombre;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(VeredaDTO veredaDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_VEREDA SET NV_NOMBRE = @parametroNombre, NM_MUNICIPIO = @parametroMunicipio WHERE NV_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = veredaDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.Int).Value = veredaDTO.Municipio.Codigo;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.NVarChar).Value = veredaDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(VeredaDTO veredaDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_VEREDA WHERE NV_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.NVarChar).Value = veredaDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<VeredaDTO> consultar(VeredaDTO veredaDTO)
        {
            List<VeredaDTO> listaVereda = new List<VeredaDTO>();
            try
            {
                String sentenciaSQL = "SELECT NV_CODIGO, NV_NOMBRE " +
                                      "FROM LIC_VEREDA " + 
                                      "WHERE NV_CODIGO != ''";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    if (veredaDTO != null)
                    {
                        // Consultar por codigo
                        if (veredaDTO.Codigo != null && veredaDTO.Codigo != "")
                        {
                            sentenciaSQL += " AND NV_CODIGO = @parametroCodigo";
                            comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.NVarChar).Value = veredaDTO.Codigo;
                        }
                        // Consultar por el Municipio
                        if (veredaDTO.Municipio != null && veredaDTO.Municipio.Codigo != 0)
                        {
                            sentenciaSQL += " AND NM_MUNICIPIO = @parametroMunicipio";
                            comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.BigInt).Value = veredaDTO.Municipio.Codigo;
                        }
                    }
                    sentenciaSQL += " ORDER BY NV_NOMBRE";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        VeredaDTO veredaDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            veredaDTOTmp = new VeredaDTO();
                            veredaDTOTmp.Codigo = cursorDatos.GetString(0);
                            veredaDTOTmp.Nombre = cursorDatos.GetString(1);
                            listaVereda.Add(veredaDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaVereda;
        }

    }
}



