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
    public partial class Entidades : System.Web.UI.Page
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            string codigoRol = (string)Session["rol"];
            if (codigoRol != "1") Server.Transfer("Bienvenido.aspx");
        }

        // Filtrar
        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            mostrarEntidades();
        }

        // Mostrar entidades
        private void mostrarEntidades()
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            // Filtros
            if (ddlEstado.SelectedValue != "") usuarioDTO.Estado = int.Parse(ddlEstado.SelectedValue);
            usuarioDTO.Nombre = tbNombre.Text;
            usuarioDTO.Id = tbNit.Text;
            List<UsuarioDTO> listaEntidades = usuarioDelegador.consultarEntidades(usuarioDTO);
            var entidades = from e in listaEntidades
                           select new
                           {
                               codigo = e.Codigo,
                               municipio = e.Municipio.Nombre,
                               nombre = e.Nombre,
                               id = e.Id,
                               email = e.Email,
                               estado = Constantes.EstadoUsuario[e.Estado]
                           };
            gvUsuarios.DataSource = entidades.ToList();
            gvUsuarios.DataBind();
        }

        // Editar entidad
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["codigoEntidad"] = gvUsuarios.SelectedValue.ToString();
            Server.Transfer("EditarEntidad.aspx");
        }

        // Paginación
        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            mostrarEntidades();
        }

    }
}