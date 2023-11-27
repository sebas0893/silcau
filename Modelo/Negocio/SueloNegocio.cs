using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Interface;
using Entidad;
using DAO.DAOFactory;

namespace Modelo.Negocio
{
    public class SueloNegocio
    {

        public void crear(SueloDTO sueloDTO, DAOFactory dao)
        {
            try
            {
                ISueloDAO sueloDAO = dao.getSueloDAO();
                sueloDAO.crear(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void actualizar(SueloDTO sueloDTO, DAOFactory dao)
        {
            try
            {
                ISueloDAO sueloDAO = dao.getSueloDAO();
                sueloDAO.actualizar(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void eliminar(SueloDTO sueloDTO, DAOFactory dao)
        {
            try
            {
                ISueloDAO sueloDAO = dao.getSueloDAO();
                sueloDAO.eliminar(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<SueloDTO> consultar(SueloDTO sueloDTO, DAOFactory dao)
        {
            List<SueloDTO> listaRetorno = null;
            try
            {
                ISueloDAO sueloDAO = dao.getSueloDAO();
                listaRetorno = sueloDAO.consultar(sueloDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaRetorno;
        }

    }
}
