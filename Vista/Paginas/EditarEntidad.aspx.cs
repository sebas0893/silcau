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
    public partial class EditarEntidad : System.Web.UI.Page
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Datos de la entidad
                string codigoEntidad = (string)Session["codigoEntidad"];
                if (codigoEntidad != null && codigoEntidad != "0")
                {
                    UsuarioDTO usuarioDTO = new UsuarioDTO();
                    usuarioDTO.Codigo = int.Parse(codigoEntidad);
                    usuarioDTO = usuarioDelegador.consultarEntidades(usuarioDTO)[0];
                    lbMunicipio.Text = usuarioDTO.Municipio.Nombre;
                    tbNombre.Text = usuarioDTO.Nombre;
                    tbCcNit.Text = usuarioDTO.Id;
                    tbEmail.Text = usuarioDTO.Email;
                    tbTel.Text = usuarioDTO.Tel;
                    ddlEstado.SelectedValue = usuarioDTO.Estado.ToString();
                }
                else Server.Transfer("Bienvenido.aspx");
            }
        }

        // Actualizar
        protected void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoEntidad = (string)Session["codigoEntidad"];
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.Codigo = int.Parse(codigoEntidad);
                usuarioDTO = usuarioDelegador.consultar(usuarioDTO)[0];
                usuarioDTO.Nombre = tbNombre.Text;
                usuarioDTO.Email = tbEmail.Text;
                usuarioDTO.Tel = tbTel.Text;
                int estado = int.Parse(ddlEstado.SelectedValue);
                // Notificar cambio de estado
                if (estado != usuarioDTO.Estado)
                {
                    usuarioDTO.Estado = estado;
                    UtilEmail.estadoUsuario(usuarioDTO);
                }
                // Cambio de CC implica cambio de clave
                if (tbCcNit.Text != usuarioDTO.Id)
                {
                    usuarioDTO.Id = tbCcNit.Text;
                    usuarioDTO.Password = "";
                }
                usuarioDelegador.actualizar(usuarioDTO);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Entidad actualizada correctamente');", true);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al actualizar los datos');", true);
            }
        }

    }
}