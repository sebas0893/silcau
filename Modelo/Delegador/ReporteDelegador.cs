using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using Modelo.Fachada;

namespace Modelo.Delegador
{
    public class ReporteDelegador
    {

        private ReporteFachada fachada = null;

        public ReporteDelegador()
        {
            try
            {
                fachada = new ReporteFachada();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public long crear(ReporteDTO reporteDTO)
        {
            try
            {
                return fachada.crear(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void enviar(ReporteDTO reporteDTO)
        {
            try
            {
                fachada.enviar(reporteDTO);
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
                fachada.devolver(reporteDTO);
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
                fachada.eliminar(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ReporteDTO> consultar(ReporteDTO reporteDTO)
        {
            List<ReporteDTO> listaReportes = null;
            try
            {
                listaReportes = fachada.consultar(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaReportes;
        }

        public List<ReporteDTO> reportes(ReporteDTO reporteDTO)
        {
            List<ReporteDTO> listaReportes = null;
            try
            {
                listaReportes = fachada.reportes(reporteDTO);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return listaReportes;
        }

    }
}