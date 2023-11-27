using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class UsuarioDTO
    {

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

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private RolDTO rol;

        public RolDTO Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }      

        private string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
       
        private string fechaRegistro;

        public string FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private string ultimoAcceso;

        public string UltimoAcceso
        {
            get { return ultimoAcceso; }
            set { ultimoAcceso = value; }
        }

        private int intentosAcceso;

        public int IntentosAcceso
        {
            get { return intentosAcceso; }
            set { intentosAcceso = value; }
        }

        // Reporte

        private string nombreRegional;

        public string NombreRegional
        {
            get { return nombreRegional; }
            set { nombreRegional = value; }
        }

    }
}