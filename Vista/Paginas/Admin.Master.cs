using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using Modelo.Delegador;

namespace Vista.Paginas
{
    public partial class Admin : System.Web.UI.MasterPage
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener datos de la Sesión
                string usuario = (string)(Session["usuario"]);
                if (usuario == null || usuario == "0") Server.Transfer("Inicio.aspx");
                else
                {
                    string nombre = (string)(Session["nombre"]);
                    lbUsuario.Text = nombre;
                    string rol = (string)(Session["rol"]);
                    // Administrador
                    if (rol.Equals("1"))
                    {
                        MenuItem item = new MenuItem("Entidades", null, null, "~/Paginas/Entidades.aspx", null);
                        menuPrincipal.Items.Add(item);
                        item = new MenuItem("Consultar Informes", null, null, "~/Paginas/AdminInforme.aspx", null);
                        menuPrincipal.Items.Add(item);
                        item = new MenuItem("Nuevo Informe", null, null, "~/Paginas/AdminNuevoInforme.aspx", null);
                        menuPrincipal.Items.Add(item);
                        //item = new MenuItem("Reportes", null, null, "~/Paginas/Reportes.aspx", null);
                        //menuPrincipal.Items.Add(item);
                    }
                    // Entidad
                    else if (rol.Equals("2"))
                    {
                        MenuItem item = new MenuItem("Informe mensual", null, null, "~/Paginas/Informes.aspx", null);
                        menuPrincipal.Items.Add(item);
                    }
                }
            }
        }

    }
}