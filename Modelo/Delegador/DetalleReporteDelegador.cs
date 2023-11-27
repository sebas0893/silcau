using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class DetalleReporteDelegador
    {

        private DetalleReporteFachada fachada = null;

        public DetalleReporteDelegador()
        {
            try
            {
                fachada = new DetalleReporteFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void crear(DetalleReporteDTO detalleReporteDTO)
        {
            try
            {
                fachada.crear(detalleReporteDTO);
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
                fachada.actualizar(detalleReporteDTO);
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
                fachada.eliminar(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<DetalleReporteDTO> consultar(DetalleReporteDTO detalleReporteDTO)
        {
            List<DetalleReporteDTO> listaDetalleReportes = null;
            try
            {
                listaDetalleReportes = fachada.consultar(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaDetalleReportes;
        }

        public List<DetalleReporteDTO> reporte(DetalleReporteDTO detalleReporteDTO)
        {
            List<DetalleReporteDTO> listaDetalleReportes = null;
            try
            {
                listaDetalleReportes = fachada.reporte(detalleReporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaDetalleReportes;
        }

    }
}