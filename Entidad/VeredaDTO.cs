using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class VeredaDTO
    {
        
        private string codigo;

        public string Codigo
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

        private string nombre;

        public string Nombre
        {

            get { return nombre; }
            set { nombre = value; }
        }

    }
}
