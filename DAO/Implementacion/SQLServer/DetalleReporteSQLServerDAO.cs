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
    public class DetalleReporteSQLServerDAO : IDetalleReporteDAO
    {

        private SqlTransaction transaccion;

        public DetalleReporteSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(DetalleReporteDTO detalleReporteDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_DETALLE_REPORTE(NM_REPORTE, NV_AUTORIZACION, NV_RESOLUCION, DA_FECHA, NV_PROYECTO, NV_TITULAR, NV_CC_NIT, NM_SUELO, NV_VEREDA, NV_SECTOR, NV_MATRICULA, NV_DIRECCION, NV_TEL, NV_LATITUD, NV_LONGITUD, NM_AREA, NM_ZONIFICACION, NV_RESTRICCIONES, NV_RADICADO, NV_ANEXO, NV_OBSERVACIONES) VALUES(@parametroReporte, @parametroAutorizacion, @parametroResolucion, @parametroFecha, @parametroProyecto, @parametroTitular, @parametroCcNit, @parametroSuelo, @parametroVereda, @parametroSector, @parametroMatricula, @parametroDireccion, @parametroTel, @parametroLatitud, @parametroLongitud, @parametroArea, @parametroZonificacion, @parametroRestricciones, @parametroRadicado, @parametroAnexo, @parametroObservaciones)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroReporte", SqlDbType.BigInt).Value = detalleReporteDTO.Reporte.Codigo;
                    comandoSQL.Parameters.Add("@parametroAutorizacion", SqlDbType.NVarChar).Value = detalleReporteDTO.Autorizacion;
                    comandoSQL.Parameters.Add("@parametroResolucion", SqlDbType.NVarChar).Value = detalleReporteDTO.Resolucion;
                    comandoSQL.Parameters.Add("@parametroFecha", SqlDbType.Date).Value = DateTime.ParseExact(detalleReporteDTO.Fecha, "yyyy-MM-dd", null);
                    comandoSQL.Parameters.Add("@parametroProyecto", SqlDbType.NVarChar).Value = detalleReporteDTO.Proyecto;
                    comandoSQL.Parameters.Add("@parametroTitular", SqlDbType.NVarChar).Value = detalleReporteDTO.Titular;
                    comandoSQL.Parameters.Add("@parametroCcNit", SqlDbType.NVarChar).Value = detalleReporteDTO.CcNit;
                    comandoSQL.Parameters.Add("@parametroSuelo", SqlDbType.Int).Value = detalleReporteDTO.Suelo.Codigo;
                    comandoSQL.Parameters.Add("@parametroVereda", SqlDbType.NVarChar).Value = detalleReporteDTO.Vereda.Codigo;
                    comandoSQL.Parameters.Add("@parametroSector", SqlDbType.NVarChar).Value = detalleReporteDTO.Sector;
                    comandoSQL.Parameters.Add("@parametroMatricula", SqlDbType.NVarChar).Value = detalleReporteDTO.Matricula;
                    comandoSQL.Parameters.Add("@parametroDireccion", SqlDbType.NVarChar).Value = detalleReporteDTO.Direccion;
                    comandoSQL.Parameters.Add("@parametroTel", SqlDbType.NVarChar).Value = detalleReporteDTO.Tel;
                    comandoSQL.Parameters.Add("@parametroLatitud", SqlDbType.NVarChar).Value = detalleReporteDTO.Latitud;
                    comandoSQL.Parameters.Add("@parametroLongitud", SqlDbType.NVarChar).Value = detalleReporteDTO.Longitud;
                    comandoSQL.Parameters.Add("@parametroArea", SqlDbType.Decimal).Value = detalleReporteDTO.Area;
                    comandoSQL.Parameters.Add("@parametroZonificacion", SqlDbType.Int).Value = detalleReporteDTO.Zonificacion.Codigo;
                    comandoSQL.Parameters.Add("@parametroRestricciones", SqlDbType.NVarChar).Value = detalleReporteDTO.Restricciones;
                    comandoSQL.Parameters.Add("@parametroRadicado", SqlDbType.NVarChar).Value = detalleReporteDTO.Radicado;
                    comandoSQL.Parameters.Add("@parametroAnexo", SqlDbType.NVarChar).Value = detalleReporteDTO.Anexo;
                    comandoSQL.Parameters.Add("@parametroObservaciones", SqlDbType.NVarChar).Value = detalleReporteDTO.Observaciones;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(DetalleReporteDTO detalleReporteDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_DETALLE_REPORTE SET NV_AUTORIZACION = @parametroAutorizacion, NV_RESOLUCION = @parametroResolucion, DA_FECHA = @parametroFecha, NV_PROYECTO = @parametroProyecto, NV_TITULAR = @parametroTitular, NV_CC_NIT = @parametroCcNit, NM_SUELO = @parametroSuelo, NV_VEREDA = @parametroVereda, NV_SECTOR = @parametroSector, NV_MATRICULA = @parametroMatricula, NV_DIRECCION = @parametroDireccion, NV_TEL = @parametroTel, NV_LATITUD = @parametroLatitud, NV_LONGITUD = @parametroLongitud, NM_AREA = @parametroArea, NM_ZONIFICACION = @parametroZonificacion, NV_RESTRICCIONES = @parametroRestricciones, NV_RADICADO = @parametroRadicado, NV_OBSERVACIONES = @parametroObservaciones WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroAutorizacion", SqlDbType.NVarChar).Value = detalleReporteDTO.Autorizacion;
                    comandoSQL.Parameters.Add("@parametroResolucion", SqlDbType.NVarChar).Value = detalleReporteDTO.Resolucion;
                    comandoSQL.Parameters.Add("@parametroFecha", SqlDbType.Date).Value = DateTime.ParseExact(detalleReporteDTO.Fecha, "yyyy-MM-dd", null);
                    comandoSQL.Parameters.Add("@parametroProyecto", SqlDbType.NVarChar).Value = detalleReporteDTO.Proyecto;
                    comandoSQL.Parameters.Add("@parametroTitular", SqlDbType.NVarChar).Value = detalleReporteDTO.Titular;
                    comandoSQL.Parameters.Add("@parametroCcNit", SqlDbType.NVarChar).Value = detalleReporteDTO.CcNit;
                    comandoSQL.Parameters.Add("@parametroSuelo", SqlDbType.Int).Value = detalleReporteDTO.Suelo.Codigo;
                    comandoSQL.Parameters.Add("@parametroVereda", SqlDbType.NVarChar).Value = detalleReporteDTO.Vereda.Codigo;
                    comandoSQL.Parameters.Add("@parametroSector", SqlDbType.NVarChar).Value = detalleReporteDTO.Sector;
                    comandoSQL.Parameters.Add("@parametroMatricula", SqlDbType.NVarChar).Value = detalleReporteDTO.Matricula;
                    comandoSQL.Parameters.Add("@parametroDireccion", SqlDbType.NVarChar).Value = detalleReporteDTO.Direccion;
                    comandoSQL.Parameters.Add("@parametroTel", SqlDbType.NVarChar).Value = detalleReporteDTO.Tel;
                    comandoSQL.Parameters.Add("@parametroLatitud", SqlDbType.NVarChar).Value = detalleReporteDTO.Latitud;
                    comandoSQL.Parameters.Add("@parametroLongitud", SqlDbType.NVarChar).Value = detalleReporteDTO.Longitud;
                    comandoSQL.Parameters.Add("@parametroArea", SqlDbType.Decimal).Value = detalleReporteDTO.Area;
                    comandoSQL.Parameters.Add("@parametroZonificacion", SqlDbType.Int).Value = detalleReporteDTO.Zonificacion.Codigo;
                    comandoSQL.Parameters.Add("@parametroRestricciones", SqlDbType.NVarChar).Value = detalleReporteDTO.Restricciones;
                    comandoSQL.Parameters.Add("@parametroRadicado", SqlDbType.NVarChar).Value = detalleReporteDTO.Radicado;
                    comandoSQL.Parameters.Add("@parametroObservaciones", SqlDbType.NVarChar).Value = detalleReporteDTO.Observaciones;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = detalleReporteDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(DetalleReporteDTO detalleReporteDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_DETALLE_REPORTE WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = detalleReporteDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<DetalleReporteDTO> consultar(DetalleReporteDTO detalleReporteDTO)
        {
            List<DetalleReporteDTO> listaDetalleReporte = new List<DetalleReporteDTO>();
            try
            {
                String sentenciaSQL = "SELECT D.NM_CODIGO, D.NV_AUTORIZACION, D.NV_RESOLUCION, D.DA_FECHA, D.NV_PROYECTO, D.NV_TITULAR, D.NV_CC_NIT, D.NM_SUELO, D.NV_SECTOR, D.NV_MATRICULA, D.NV_DIRECCION, D.NV_TEL, D.NV_LATITUD, D.NV_LONGITUD, D.NM_AREA, D.NM_ZONIFICACION, D.NV_RESTRICCIONES, D.NV_RADICADO, D.NV_ANEXO, D.NV_OBSERVACIONES, V.NV_CODIGO, V.NV_NOMBRE " +
                                      "FROM LIC_DETALLE_REPORTE D " +
                                      "INNER JOIN LIC_VEREDA V ON V.NV_CODIGO = D.NV_VEREDA " + 
                                      "WHERE D.NM_CODIGO > 0";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Consultar por codigo
                    if (detalleReporteDTO.Codigo != 0)
                    {
                        sentenciaSQL += " AND D.NM_CODIGO = @parametroCodigo";
                        comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = detalleReporteDTO.Codigo;
                    }
                    // Consultar por Reporte
                    if (detalleReporteDTO.Reporte != null && detalleReporteDTO.Reporte.Codigo != 0)
                    {
                        sentenciaSQL += " AND D.NM_REPORTE = @parametroReporte";
                        comandoSQL.Parameters.Add("@parametroReporte", SqlDbType.BigInt).Value = detalleReporteDTO.Reporte.Codigo;
                    }
                    sentenciaSQL += " ORDER BY D.NM_CODIGO";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        DetalleReporteDTO detalleReporteDTOTmp = null;
                        SueloDTO sueloDTOTmp = null;
                        VeredaDTO veredaDTOTmp = null;
                        ZonificacionDTO zonificacionDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            detalleReporteDTOTmp = new DetalleReporteDTO();
                            detalleReporteDTOTmp.Codigo = (long)cursorDatos.GetDecimal(0);
                            detalleReporteDTOTmp.Autorizacion = cursorDatos.GetString(1);
                            detalleReporteDTOTmp.Resolucion = cursorDatos.GetString(2);
                            detalleReporteDTOTmp.Fecha = cursorDatos.GetDateTime(3).ToString("yyyy-MM-dd");
                            detalleReporteDTOTmp.Proyecto = cursorDatos.GetString(4);
                            detalleReporteDTOTmp.Titular = cursorDatos.GetString(5);
                            detalleReporteDTOTmp.CcNit = cursorDatos.GetString(6);
                            sueloDTOTmp = new SueloDTO();
                            sueloDTOTmp.Codigo = (int)cursorDatos.GetDecimal(7);
                            detalleReporteDTOTmp.Suelo = sueloDTOTmp;
                            detalleReporteDTOTmp.Sector = cursorDatos.GetString(8);
                            detalleReporteDTOTmp.Matricula = cursorDatos.GetString(9);
                            detalleReporteDTOTmp.Direccion = cursorDatos.GetString(10);
                            detalleReporteDTOTmp.Tel = cursorDatos.GetString(11);
                            detalleReporteDTOTmp.Latitud = cursorDatos.GetString(12);
                            detalleReporteDTOTmp.Longitud = cursorDatos.GetString(13);
                            detalleReporteDTOTmp.Area = (decimal)cursorDatos.GetDecimal(14);
                            zonificacionDTOTmp = new ZonificacionDTO();
                            zonificacionDTOTmp.Codigo = (int)cursorDatos.GetDecimal(15);
                            detalleReporteDTOTmp.Zonificacion = zonificacionDTOTmp;
                            detalleReporteDTOTmp.Restricciones = cursorDatos.GetString(16);
                            detalleReporteDTOTmp.Radicado = cursorDatos.GetString(17);
                            detalleReporteDTOTmp.Anexo = cursorDatos.GetString(18);
                            detalleReporteDTOTmp.Observaciones = cursorDatos.GetString(19);
                            veredaDTOTmp = new VeredaDTO();
                            veredaDTOTmp.Codigo = cursorDatos.GetString(20);
                            veredaDTOTmp.Nombre = detalleReporteDTOTmp.NombreVereda = cursorDatos.GetString(21);
                            detalleReporteDTOTmp.Vereda = veredaDTOTmp;
                            listaDetalleReporte.Add(detalleReporteDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaDetalleReporte;
        }

        public List<DetalleReporteDTO> reporte(DetalleReporteDTO detalleReporteDTO)
        {
            List<DetalleReporteDTO> listaDetalleReporte = new List<DetalleReporteDTO>();
            try
            {
                String sentenciaSQL = "SELECT D.NM_CODIGO, D.NV_AUTORIZACION, D.NV_RESOLUCION, D.DA_FECHA, D.NV_PROYECTO, D.NV_TITULAR, D.NV_CC_NIT, S.NV_NOMBRE, D.NV_SECTOR, D.NV_MATRICULA, D.NV_DIRECCION, D.NV_TEL, D.NV_LATITUD, D.NV_LONGITUD, D.NM_AREA, Z.NV_NOMBRE, D.NV_RESTRICCIONES, D.NV_RADICADO, D.NV_ANEXO, D.NV_OBSERVACIONES, V.NV_NOMBRE, M.NV_NOMBRE " +
                                      "FROM LIC_DETALLE_REPORTE D " +
                                      "INNER JOIN LIC_SUELO S ON S.NM_CODIGO = D.NM_SUELO " +
                                      "INNER JOIN LIC_ZONIFICACION Z ON Z.NM_CODIGO = D.NM_ZONIFICACION " +
                                      "INNER JOIN LIC_VEREDA V ON V.NV_CODIGO = D.NV_VEREDA " +
                                      "INNER JOIN LIC_MUNICIPIO M ON M.NM_CODIGO = V.NM_MUNICIPIO " +
                                      "WHERE D.NM_CODIGO > 0";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Consultar por Reporte
                    if (detalleReporteDTO.Reporte != null && detalleReporteDTO.Reporte.Codigo != 0)
                    {
                        sentenciaSQL += " AND D.NM_REPORTE = @parametroReporte";
                        comandoSQL.Parameters.Add("@parametroReporte", SqlDbType.BigInt).Value = detalleReporteDTO.Reporte.Codigo;
                    }
                    // Consultar por Municipio
                    if (detalleReporteDTO.CodigoMunicipio != 0)
                    {
                        sentenciaSQL += " AND V.NM_MUNICIPIO = @parametroMunicipio";
                        comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.Int).Value = detalleReporteDTO.CodigoMunicipio;
                    }
                    // Consultar por Resolución
                    if (detalleReporteDTO.Resolucion != null && detalleReporteDTO.Resolucion != "")
                    {
                        sentenciaSQL += " AND D.NV_RESOLUCION = @parametroResolucion";
                        comandoSQL.Parameters.Add("@parametroResolucion", SqlDbType.NVarChar).Value = detalleReporteDTO.Resolucion;
                    }
                    // Consultar por CC / Nit Titular
                    if (detalleReporteDTO.CcNit != null && detalleReporteDTO.CcNit != "")
                    {
                        sentenciaSQL += " AND D.NV_CC_NIT = @parametroCcNit";
                        comandoSQL.Parameters.Add("@parametroCcNit", SqlDbType.NVarChar).Value = detalleReporteDTO.CcNit;
                    }
                    sentenciaSQL += " ORDER BY D.NM_CODIGO";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        DetalleReporteDTO detalleReporteDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            detalleReporteDTOTmp = new DetalleReporteDTO();
                            detalleReporteDTOTmp.Codigo = (long)cursorDatos.GetDecimal(0);
                            detalleReporteDTOTmp.Autorizacion = cursorDatos.GetString(1);
                            detalleReporteDTOTmp.Resolucion = cursorDatos.GetString(2);
                            detalleReporteDTOTmp.Fecha = cursorDatos.GetDateTime(3).ToString("yyyy-MM-dd");
                            detalleReporteDTOTmp.Proyecto = cursorDatos.GetString(4);
                            detalleReporteDTOTmp.Titular = cursorDatos.GetString(5);
                            detalleReporteDTOTmp.CcNit = cursorDatos.GetString(6);
                            detalleReporteDTOTmp.NombreSuelo = cursorDatos.GetString(7);
                            detalleReporteDTOTmp.Sector = cursorDatos.GetString(8);
                            detalleReporteDTOTmp.Matricula = cursorDatos.GetString(9);
                            detalleReporteDTOTmp.Direccion = cursorDatos.GetString(10);
                            detalleReporteDTOTmp.Tel = cursorDatos.GetString(11);
                            detalleReporteDTOTmp.Latitud = cursorDatos.GetString(12);
                            detalleReporteDTOTmp.Longitud = cursorDatos.GetString(13);
                            if (detalleReporteDTOTmp.Latitud != "") detalleReporteDTOTmp.Mapa = "https://maps.google.com/?q=" + detalleReporteDTOTmp.Latitud + "," + detalleReporteDTOTmp.Longitud + "&z=14&t=k";
                            detalleReporteDTOTmp.Area = (decimal)cursorDatos.GetDecimal(14);
                            detalleReporteDTOTmp.NombreZonificacion = cursorDatos.GetString(15);
                            detalleReporteDTOTmp.Restricciones = cursorDatos.GetString(16);
                            detalleReporteDTOTmp.Radicado = cursorDatos.GetString(17);
                            detalleReporteDTOTmp.Anexo = cursorDatos.GetString(18);
                            if (detalleReporteDTOTmp.Anexo != "") detalleReporteDTOTmp.Anexo = "https://cornare.cornare.gov.co/licencias/Anexos/" + detalleReporteDTOTmp.Anexo;
                            detalleReporteDTOTmp.Observaciones = cursorDatos.GetString(19);
                            detalleReporteDTOTmp.NombreVereda = cursorDatos.GetString(20);
                            detalleReporteDTOTmp.NombreMunicipio = cursorDatos.GetString(21);
                            listaDetalleReporte.Add(detalleReporteDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaDetalleReporte;
        }

    }
}