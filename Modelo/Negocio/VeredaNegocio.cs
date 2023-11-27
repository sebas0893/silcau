using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class VeredaNegocio
    {

        public void crear(VeredaDTO veredaDTO, DAOFactory dao)
        {
            try
            {
                IVeredaDAO veredaDAO = dao.getVeredaDAO();
                veredaDAO.crear(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(VeredaDTO veredaDTO, DAOFactory dao)
        {
            try
            {
                IVeredaDAO veredaDAO = dao.getVeredaDAO();
                veredaDAO.actualizar(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(VeredaDTO veredaDTO, DAOFactory dao)
        {
            try
            {
                IVeredaDAO veredaDAO = dao.getVeredaDAO();
                veredaDAO.eliminar(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<VeredaDTO> consultar(VeredaDTO veredaDTO, DAOFactory dao)
        {
            List<VeredaDTO> listaRetorno = null;
            try
            {
                IVeredaDAO veredaDAO = dao.getVeredaDAO();
                listaRetorno = veredaDAO.consultar(veredaDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}