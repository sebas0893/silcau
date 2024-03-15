using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAO.Interface;
using Entidad;
using Transversal;

namespace DAO.Implementacion.SQLServer
{
    public class ReporteSQLServerDAO : IReporteDAO
    {

        private SqlTransaction transaccion;

        public ReporteSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public long crear(ReporteDTO reporteDTO)
        {
            long codigo = 0;
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_REPORTE(NM_MUNICIPIO, NM_ANIO, NM_MES, NM_ENVIADO, NM_USUARIO, BI_TIENE_REGISTROS) VALUES(@parametroMunicipio, @parametroAnio, @parametroMes, 0, @parametroUsuario, @parametroTieneRegistros)" +
                                      "SELECT SCOPE_IDENTITY();";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.Int).Value = reporteDTO.Municipio.Codigo;
                    comandoSQL.Parameters.Add("@parametroAnio", SqlDbType.Int).Value = reporteDTO.Anio;
                    comandoSQL.Parameters.Add("@parametroMes", SqlDbType.Int).Value = reporteDTO.Mes;
                    comandoSQL.Parameters.Add("@parametroUsuario", SqlDbType.BigInt).Value = reporteDTO.Usuario.Codigo;
                    comandoSQL.Parameters.Add("@parametroTieneRegistros", SqlDbType.Bit).Value = Utilidades.BoolNull(reporteDTO.TieneRegistros);
                    codigo = long.Parse(comandoSQL.ExecuteScalar().ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return codigo;
        }

        public void enviar(ReporteDTO reporteDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_REPORTE SET NM_ENVIADO = @parametroEnviado WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroEnviado", SqlDbType.Int).Value = reporteDTO.Enviado;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = reporteDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void devolver(ReporteDTO reporteDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_REPORTE SET NM_ENVIADO = 0 WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = reporteDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(ReporteDTO reporteDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_REPORTE WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = reporteDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ReporteDTO> consultar(ReporteDTO reporteDTO)
        {
            List<ReporteDTO> listaReporte = new List<ReporteDTO>();
            try
            {
                String sentenciaSQL = @"SELECT R.NM_CODIGO, R.NM_ANIO, R.NM_MES, R.NM_ENVIADO, M.NM_CODIGO, M.NV_NOMBRE, R.NM_USUARIO, ISNULL(US.NV_EMAIL, ''), R.BI_TIENE_REGISTROS 
FROM LIC_REPORTE R 
INNER JOIN LIC_MUNICIPIO M ON M.NM_CODIGO = R.NM_MUNICIPIO 
LEFT JOIN LIC_USUARIO US ON R.NM_USUARIO = US.NM_CODIGO 
WHERE R.NM_CODIGO > 0";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    if (reporteDTO != null)
                    {
                        // Consultar por codigo
                        if (reporteDTO.Codigo != 0)
                        {
                            sentenciaSQL += " AND R.NM_CODIGO = @parametroCodigo";
                            comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = reporteDTO.Codigo;
                        }
                        // Consultar por Usuario
                        if (reporteDTO.Usuario != null && reporteDTO.Usuario.Codigo != 0)
                        {
                            sentenciaSQL += " AND R.NM_USUARIO = @parametroUsuario";
                            comandoSQL.Parameters.Add("@parametroUsuario", SqlDbType.BigInt).Value = reporteDTO.Usuario.Codigo;
                        }
                        // Consultar por Municipio
                        if (reporteDTO.Municipio != null && reporteDTO.Municipio.Codigo != 0)
                        {
                            sentenciaSQL += " AND R.NM_MUNICIPIO = @parametroMunicipio";
                            comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.Int).Value = reporteDTO.Municipio.Codigo;
                        }
                    }
                    sentenciaSQL += " ORDER BY R.NM_MUNICIPIO, R.NM_ANIO, R.NM_MES DESC";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        ReporteDTO reporteDTOTmp = null;
                        MunicipioDTO municipioDTOTmp = null;
                        UsuarioDTO usuarioDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            reporteDTOTmp = new ReporteDTO();
                            reporteDTOTmp.Codigo = (long)cursorDatos.GetDecimal(0);
                            reporteDTOTmp.Anio = (int)cursorDatos.GetDecimal(1);
                            reporteDTOTmp.Mes = (int)cursorDatos.GetDecimal(2);
                            reporteDTOTmp.Enviado = (int)cursorDatos.GetDecimal(3);
                            municipioDTOTmp = new MunicipioDTO();
                            municipioDTOTmp.Codigo = (int)cursorDatos.GetDecimal(4);
                            municipioDTOTmp.Nombre = cursorDatos.GetString(5);
                            reporteDTOTmp.Municipio = municipioDTOTmp;
                            usuarioDTOTmp = new UsuarioDTO();
                            usuarioDTOTmp.Codigo = Utilidades.GetLong(cursorDatos, "NM_USUARIO");
                            usuarioDTOTmp.Email = cursorDatos.GetString(7);
                            reporteDTOTmp.Usuario = usuarioDTOTmp;
                            reporteDTOTmp.TieneRegistros = Utilidades.GetBoolNull(cursorDatos, "BI_TIENE_REGISTROS");
                            listaReporte.Add(reporteDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaReporte;
        }

        // Reportes
        public List<ReporteDTO> reportes(ReporteDTO reporteDTO)
        {
            List<ReporteDTO> listaReporte = new List<ReporteDTO>();
            try
            {
                String sentenciaSQL = @"SELECT R.NM_CODIGO, R.NM_ANIO, R.NM_MES, R.NM_ENVIADO, M.NV_NOMBRE , U.NV_NOMBRE'U.NV_NOMBRE', R.BI_TIENE_REGISTROS
FROM LIC_REPORTE R 
INNER JOIN LIC_MUNICIPIO M ON M.NM_CODIGO = R.NM_MUNICIPIO 
LEFT JOIN LIC_USUARIO U ON R.NM_USUARIO = U.NM_CODIGO
WHERE R.NM_CODIGO > 0";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Consultar por Municipio
                    if (reporteDTO.Municipio != null && reporteDTO.Municipio.Codigo != 0)
                    {
                        sentenciaSQL += " AND R.NM_MUNICIPIO = @parametroMunicipio";
                        comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.BigInt).Value = reporteDTO.Municipio.Codigo;
                    }
                    // Consultar por Año
                    if (reporteDTO.Anio != 0)
                    {
                        sentenciaSQL += " AND R.NM_ANIO = @parametroAnio";
                        comandoSQL.Parameters.Add("@parametroAnio", SqlDbType.Int).Value = reporteDTO.Anio;
                    }
                    // Consultar por Mes
                    if (reporteDTO.Mes != 0)
                    {
                        sentenciaSQL += " AND R.NM_MES = @parametroMes";
                        comandoSQL.Parameters.Add("@parametroMes", SqlDbType.Int).Value = reporteDTO.Mes;
                    }
                    sentenciaSQL += " ORDER BY R.NM_MUNICIPIO, R.NM_ANIO, R.NM_MES";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        ReporteDTO reporteDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            reporteDTOTmp = new ReporteDTO();
                            reporteDTOTmp.Codigo = (long)cursorDatos.GetDecimal(0);
                            reporteDTOTmp.Anio = (int)cursorDatos.GetDecimal(1);
                            reporteDTOTmp.Mes = (int)cursorDatos.GetDecimal(2);
                            reporteDTOTmp.Enviado = (int)cursorDatos.GetDecimal(3);
                            reporteDTOTmp.NombreMunicipio = cursorDatos.GetString(4);
                            reporteDTOTmp.Usuario.Nombre = Utilidades.GetString(cursorDatos, "U.NV_NOMBRE");
                            reporteDTOTmp.TieneRegistros = Utilidades.GetBoolNull(cursorDatos, "BI_TIENE_REGISTROS");
                            listaReporte.Add(reporteDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaReporte;
        }

    }
}