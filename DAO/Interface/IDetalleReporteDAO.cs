using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IDetalleReporteDAO
    {

        void crear(DetalleReporteDTO detalleReporteDTO);

        void actualizar(DetalleReporteDTO detalleReporteDTO);

        void eliminar(DetalleReporteDTO detalleReporteDTO);

        List<DetalleReporteDTO> consultar(DetalleReporteDTO detalleReporteDTO);
        List<DetalleReporteDTO> reporte(DetalleReporteDTO detalleReporteDTO);

    }
}