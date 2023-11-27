using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class MunicipioDTO
    {

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int regional;

        public int Regional
        {
            get { return regional; }
            set { regional = value; }
        }

        private bool registro;

        public bool Registro
        {
            get { return registro; }
            set { registro = value; }
        }

    }
}