using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using Modelo.Delegador;
using Transversal;
using System.Web.Security;

namespace Vista.Paginas
{
    public partial class Inicio : System.Web.UI.Page
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // Ingresar
        protected void btIngresar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.Id = tbUsuario.Text;
            List<UsuarioDTO> listaUsuario = usuarioDelegador.consultar(usuarioDTO);
            if (listaUsuario.Count > 0)
            {
                usuarioDTO = listaUsuario[0];
                if (usuarioDTO.Estado.Equals(1))
                {
                    if (tbPassword.Text.Equals(usuarioDTO.Password))
                    {
                        // Actualizar fecha de último acceso
                        usuarioDTO.IntentosAcceso = 0;
                        usuarioDelegador.actualizarAcceso(usuarioDTO);
                        Session["usuario"] = usuarioDTO.Codigo.ToString();
                        Session["nombre"] = usuarioDTO.Nombre;
                        Session["rol"] = usuarioDTO.Rol.Codigo.ToString();
                        Session["municipio"] = usuarioDTO.Municipio.Codigo.ToString();
                        Server.Transfer("Bienvenido.aspx");
                    }
                    else
                    {
                        // Intentos de Acceso Fallidos: Max 5
                        usuarioDTO.IntentosAcceso += 1;
                        usuarioDelegador.actualizarAcceso(usuarioDTO);
                        if (usuarioDTO.IntentosAcceso >= 5) usuarioDelegador.inactivar(usuarioDTO);
                        ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('La contraseña es incorrecta. Con 5 intentos fallidos el usuario quedará bloqueado, para recuperar su clave ingrese por la opción Olvidé mis datos');", true);
                    }
                }
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El usuario se encuentra bloqueado o pendiente por aprobación. Comuníquese con el Área de Sistemas');", true);
            }
            else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El usuario no se encuentra registrado');", true);
        }

        // Recordar clave
        protected void btGuardarClave_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.Id = tbUsuarioClave.Text;
            List<UsuarioDTO> listaUsuario = usuarioDelegador.consultar(usuarioDTO);
            if (listaUsuario.Count > 0)
            {
                usuarioDTO = listaUsuario[0];
                if (usuarioDTO.Password.Equals(""))
                {
                    string pass = "";
                    usuarioDTO.Password = pass = Membership.GeneratePassword(8, 3);
                    usuarioDelegador.actualizar(usuarioDTO);
                    usuarioDTO.Password = pass;
                }
                // Enviar correo
                UtilEmail.recuperarPassword(usuarioDTO);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Se ha enviado un correo electrónico con las instrucciones para recuperar la contraseña');", true);
            }
            else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El usuario no se encuentra registrado');", true);
        }

    }
}