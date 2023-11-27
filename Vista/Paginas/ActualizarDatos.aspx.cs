using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using Modelo.Delegador;
using Transversal;

namespace Vista.Paginas
{
    public partial class ActualizarDatos : System.Web.UI.Page
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string codigoEntidad = (string)Session["usuario"];
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.Codigo = int.Parse(codigoEntidad);
                usuarioDTO = usuarioDelegador.consultar(usuarioDTO)[0];
                lbMunicipio.Text = usuarioDTO.Municipio.Nombre;
                tbNombre.Text = usuarioDTO.Nombre;
                tbCcNit.Text = usuarioDTO.Id;
                tbEmail.Text = usuarioDTO.Email;
                tbTel.Text = usuarioDTO.Tel;
            }
        }

        // Obtener datos
        private UsuarioDTO getDatos()
        {
            string codigoEntidad = (string)Session["usuario"];
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.Codigo = int.Parse(codigoEntidad);
            usuarioDTO = usuarioDelegador.consultar(usuarioDTO)[0];
            usuarioDTO.Nombre = tbNombre.Text;
            usuarioDTO.Email = tbEmail.Text;
            usuarioDTO.Tel = tbTel.Text;
            // Cambio de contraseña
            if (tbPass.Text != "")
            {
                usuarioDTO.Password = tbPass.Text;
            }
            return usuarioDTO;
        }

        // Guardar
        protected void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO usuarioDTO = getDatos();
                // Cambio de CC implica cambio de clave
                if (tbCcNit.Text != usuarioDTO.Id)
                {
                    usuarioDTO.Id = tbCcNit.Text;
                    usuarioDTO.Password = "";
                }
                usuarioDelegador.actualizar(usuarioDTO);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Datos actualizados correctamente');", true);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al actualizar los datos');", true);
            }
        }

    }
}