using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace DAO.Interface
{
    public interface IReporteDAO
    {

        long crear(ReporteDTO reporteDTO);

        void enviar(ReporteDTO reporteDTO);
        void devolver(ReporteDTO reporteDTO);

        void eliminar(ReporteDTO reporteDTO);

        List<ReporteDTO> consultar(ReporteDTO reporteDTO);
        List<ReporteDTO> reportes(ReporteDTO reporteDTO);

    }
}
