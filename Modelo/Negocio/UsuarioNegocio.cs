using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class UsuarioNegocio
    {

        public void crear(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            try
            {
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                usuarioDTO.Password = cifrar(usuarioDTO);
                usuarioDAO.crear(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            try
            {
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                if (usuarioDTO.Password != "")
                {
                    usuarioDTO.Password = cifrar(usuarioDTO);
                }
                usuarioDAO.actualizar(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizarAcceso(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            try
            {                
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                usuarioDAO.actualizarAcceso(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void inactivar(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            try
            {
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                usuarioDAO.inactivar(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            try
            {
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                usuarioDAO.eliminar(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<UsuarioDTO> consultar(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            List<UsuarioDTO> listaRetorno = null;
            try
            {
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                listaRetorno = usuarioDAO.consultar(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

        public List<UsuarioDTO> consultarEntidades(UsuarioDTO usuarioDTO, DAOFactory dao)
        {
            List<UsuarioDTO> listaRetorno = null;
            try
            {
                IUsuarioDAO usuarioDAO = dao.getUsuarioDAO();
                listaRetorno = usuarioDAO.consultarEntidades(usuarioDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

        private string cifrar(UsuarioDTO usuarioDTO)
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(usuarioDTO.Password);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(usuarioDTO.Id));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

    }
}
