using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ReporteDTO
    {
        public ReporteDTO()
        {
            usuario = new UsuarioDTO();
        }

        private long codigo;

        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private MunicipioDTO municipio;

        public MunicipioDTO Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        private int anio;

        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        private int mes;

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        private int enviado;

        public int Enviado
        {
            get { return enviado; }
            set { enviado = value; }
        }

        private UsuarioDTO usuario;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public bool? TieneRegistros { get; set; }

        // Reporte

        private string nombreMunicipio;

        public string NombreMunicipio
        {
            get { return nombreMunicipio; }
            set { nombreMunicipio = value; }
        }

    }
}
