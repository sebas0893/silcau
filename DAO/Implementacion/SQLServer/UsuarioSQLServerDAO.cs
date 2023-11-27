using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Security.Permissions;
using DAO.Interface;
using Entidad;
using Transversal;

namespace DAO.Implementacion.SQLServer
{
    public class UsuarioSQLServerDAO : IUsuarioDAO
    {

        private SqlTransaction transaccion;

        public UsuarioSQLServerDAO(SqlTransaction transaccion)
        {
            this.transaccion = transaccion;
        }

        public void crear(UsuarioDTO usuarioDTO)
        {
            try
            {
                String sentenciaSQL = "INSERT INTO LIC_USUARIO(NM_MUNICIPIO, NM_ROL, NV_ID, NV_NOMBRE, NV_EMAIL, NV_TEL, NM_ESTADO, NV_PASS, DT_REGISTRO, DT_ULTIMO_ACCESO, NM_INTENTOS) VALUES(@parametroMunicipio, @parametroRol, @parametroId, @parametroNombre, @parametroEmail, @parametroTel, @parametroEstado, @parametroPass, @parametroFecha, @parametroFecha, 0)";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroRol", SqlDbType.Int).Value = usuarioDTO.Rol.Codigo;
                    comandoSQL.Parameters.Add("@parametroId", SqlDbType.VarChar).Value = usuarioDTO.Id;
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.VarChar).Value = usuarioDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroEmail", SqlDbType.VarChar).Value = usuarioDTO.Email;
                    comandoSQL.Parameters.Add("@parametroTel", SqlDbType.VarChar).Value = usuarioDTO.Tel;
                    comandoSQL.Parameters.Add("@parametroMunicipio", SqlDbType.Int).Value = usuarioDTO.Municipio.Codigo;
                    comandoSQL.Parameters.Add("@parametroEstado", SqlDbType.Int).Value = usuarioDTO.Estado;
                    comandoSQL.Parameters.Add("@parametroPass", SqlDbType.VarChar).Value = usuarioDTO.Password;
                    comandoSQL.Parameters.Add("@parametroFecha", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(UsuarioDTO usuarioDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_USUARIO SET NV_ID = @parametroId, NV_NOMBRE = @parametroNombre, NV_EMAIL = @parametroEmail, NV_TEL = @parametroTel, NV_PASS = @parametroPass, NM_ESTADO = @parametroEstado WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroId", SqlDbType.VarChar).Value = usuarioDTO.Id;
                    comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.VarChar).Value = usuarioDTO.Nombre;
                    comandoSQL.Parameters.Add("@parametroEmail", SqlDbType.VarChar).Value = usuarioDTO.Email;
                    comandoSQL.Parameters.Add("@parametroTel", SqlDbType.VarChar).Value = usuarioDTO.Tel;
                    comandoSQL.Parameters.Add("@parametroPass", SqlDbType.VarChar).Value = usuarioDTO.Password;
                    comandoSQL.Parameters.Add("@parametroEstado", SqlDbType.Int).Value = usuarioDTO.Estado;
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = usuarioDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizarAcceso(UsuarioDTO usuarioDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_USUARIO SET DT_ULTIMO_ACCESO = @parametroFecha, NM_INTENTOS = 0 WHERE NM_CODIGO = @parametroCodigo";
                if (usuarioDTO.IntentosAcceso != 0)
                {
                    sentenciaSQL = "UPDATE LIC_USUARIO SET DT_ULTIMO_ACCESO = @parametroFecha, NM_INTENTOS = NM_INTENTOS + 1 WHERE NM_CODIGO = @parametroCodigo";
                }
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroFecha", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.BigInt).Value = usuarioDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void inactivar(UsuarioDTO usuarioDTO)
        {
            try
            {
                String sentenciaSQL = "UPDATE LIC_USUARIO SET NM_ESTADO = 2 WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = usuarioDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(UsuarioDTO usuarioDTO)
        {
            try
            {
                String sentenciaSQL = "DELETE FROM LIC_USUARIO WHERE NM_CODIGO = @parametroCodigo";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Parámetros de la sentencia SQL
                    comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = usuarioDTO.Codigo;
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<UsuarioDTO> consultar(UsuarioDTO usuarioDTO)
        {
            List<UsuarioDTO> listaUsuario = new List<UsuarioDTO>();
            try
            {
                String sentenciaSQL = "SELECT U.NM_CODIGO, U.NV_ID, U.NM_ROL, U.NV_NOMBRE, U.NV_EMAIL, U.NV_TEL, U.NM_ESTADO, U.NV_PASS, U.DT_REGISTRO, U.DT_ULTIMO_ACCESO, U.NM_INTENTOS, M.NM_CODIGO, M.NV_NOMBRE " +
                                      "FROM LIC_USUARIO U " +
                                      "INNER JOIN LIC_MUNICIPIO M ON M.NM_CODIGO = U.NM_MUNICIPIO " +
                                      "WHERE U.NM_CODIGO > 0";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Consultar por cc/nit
                    if (usuarioDTO.Id != null && usuarioDTO.Id !="")
                    {
                        sentenciaSQL += " AND U.NV_ID = @parametroId";
                        comandoSQL.Parameters.Add("@parametroId", SqlDbType.VarChar).Value = usuarioDTO.Id;
                    }
                    // Consultar por codigo
                    if (usuarioDTO.Codigo != 0)
                    {
                        sentenciaSQL += " AND U.NM_CODIGO = @parametroCodigo";
                        comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = usuarioDTO.Codigo;
                    }
                    // Consultar por rol
                    if (usuarioDTO.Rol != null && usuarioDTO.Rol.Codigo != 0)
                    {
                        sentenciaSQL += " AND U.NM_ROL = @parametroRol";
                        comandoSQL.Parameters.Add("@parametroRol", SqlDbType.Int).Value = usuarioDTO.Rol.Codigo;
                    }
                    sentenciaSQL += " ORDER BY U.NV_NOMBRE";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        UsuarioDTO usuarioDTOTmp = null;
                        RolDTO rolDTOTmp = null;
                        MunicipioDTO municipioDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            usuarioDTOTmp = new UsuarioDTO();
                            usuarioDTOTmp.Codigo = (long)cursorDatos.GetDecimal(0);
                            usuarioDTOTmp.Id = cursorDatos.GetString(1);
                            rolDTOTmp = new RolDTO();
                            rolDTOTmp.Codigo = (int)cursorDatos.GetDecimal(2);
                            usuarioDTOTmp.Rol = rolDTOTmp;
                            usuarioDTOTmp.Nombre = cursorDatos.GetString(3);
                            usuarioDTOTmp.Email = cursorDatos.GetString(4);
                            usuarioDTOTmp.Tel = cursorDatos.GetString(5);
                            usuarioDTOTmp.Estado = (int)cursorDatos.GetDecimal(6);
                            usuarioDTOTmp.Password = cursorDatos.GetString(7);
                            if (usuarioDTOTmp.Password != "") usuarioDTOTmp.Password = descifrar(usuarioDTOTmp);
                            usuarioDTOTmp.FechaRegistro = cursorDatos.GetDateTime(8).ToString("yyyy-MM-dd hh:mm tt");
                            usuarioDTOTmp.UltimoAcceso = cursorDatos.GetDateTime(9).ToString("yyyy-MM-dd hh:mm tt");
                            usuarioDTOTmp.IntentosAcceso = (int)cursorDatos.GetDecimal(10);
                            municipioDTOTmp = new MunicipioDTO();
                            municipioDTOTmp.Codigo = (int)cursorDatos.GetDecimal(11);
                            municipioDTOTmp.Nombre = cursorDatos.GetString(12);
                            usuarioDTOTmp.Municipio = municipioDTOTmp;
                            listaUsuario.Add(usuarioDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaUsuario;
        }

        public List<UsuarioDTO> consultarEntidades(UsuarioDTO usuarioDTO)
        {
            List<UsuarioDTO> listaUsuario = new List<UsuarioDTO>();
            try
            {
                String sentenciaSQL = "SELECT U.NM_CODIGO, U.NV_ID, U.NV_NOMBRE, U.NV_EMAIL, U.NV_TEL, U.NM_ESTADO, U.DT_REGISTRO, U.DT_ULTIMO_ACCESO, M.NM_CODIGO, M.NV_NOMBRE " +
                                      "FROM LIC_USUARIO U " +
                                      "INNER JOIN LIC_MUNICIPIO M ON M.NM_CODIGO = U.NM_MUNICIPIO " +
                                      "WHERE U.NM_ROL = 2";
                using (SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, transaccion.Connection, transaccion))
                {
                    // Consultar por codigo
                    if (usuarioDTO.Codigo != 0)
                    {
                        sentenciaSQL += " AND U.NM_CODIGO = @parametroCodigo";
                        comandoSQL.Parameters.Add("@parametroCodigo", SqlDbType.Int).Value = usuarioDTO.Codigo;
                    }
                    // Consultar por cc/nit
                    if (usuarioDTO.Id != null && usuarioDTO.Id != "")
                    {
                        sentenciaSQL += " AND U.NV_ID = @parametroId";
                        comandoSQL.Parameters.Add("@parametroId", SqlDbType.VarChar).Value = usuarioDTO.Id;
                    }
                    // Consultar por nombre
                    if (usuarioDTO.Nombre != null && usuarioDTO.Nombre != "")
                    {
                        sentenciaSQL += " AND (U.NV_NOMBRE LIKE @parametroNombre OR M.NV_NOMBRE LIKE @parametroNombre)";
                        comandoSQL.Parameters.Add("@parametroNombre", SqlDbType.NVarChar).Value = "%" + usuarioDTO.Nombre + "%";
                    }
                    // Consultar por estado
                    if (usuarioDTO.Estado != 0)
                    {
                        sentenciaSQL += " AND U.NM_ESTADO = @parametroEstado";
                        comandoSQL.Parameters.Add("@parametroEstado", SqlDbType.Int).Value = usuarioDTO.Estado;
                    }
                    sentenciaSQL += " ORDER BY U.NV_NOMBRE";
                    comandoSQL.CommandText = sentenciaSQL;
                    using (SqlDataReader cursorDatos = comandoSQL.ExecuteReader())
                    {
                        UsuarioDTO usuarioDTOTmp = null;
                        MunicipioDTO municipioDTOTmp = null;
                        while (cursorDatos.Read())
                        {
                            usuarioDTOTmp = new UsuarioDTO();
                            usuarioDTOTmp.Codigo = (int)cursorDatos.GetDecimal(0);
                            usuarioDTOTmp.Id = cursorDatos.GetString(1);
                            usuarioDTOTmp.Nombre = cursorDatos.GetString(2);
                            usuarioDTOTmp.Email = cursorDatos.GetString(3);
                            usuarioDTOTmp.Tel = cursorDatos.GetString(4);
                            usuarioDTOTmp.Estado = (int)cursorDatos.GetDecimal(5);
                            usuarioDTOTmp.FechaRegistro = cursorDatos.GetDateTime(6).ToString("yyyy-MM-dd hh:mm tt");
                            usuarioDTOTmp.UltimoAcceso = cursorDatos.GetDateTime(7).ToString("yyyy-MM-dd hh:mm tt");
                            municipioDTOTmp = new MunicipioDTO();
                            municipioDTOTmp.Codigo = (int)cursorDatos.GetDecimal(8);
                            municipioDTOTmp.Nombre = cursorDatos.GetString(9);
                            usuarioDTOTmp.Municipio = municipioDTOTmp;
                            listaUsuario.Add(usuarioDTOTmp);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaUsuario;
        }

        private string descifrar(UsuarioDTO usuarioDTO)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(usuarioDTO.Password);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(usuarioDTO.Id));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}