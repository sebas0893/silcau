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
    public partial class ConsultaExterna : System.Web.UI.Page
    {

        MunicipioDelegador municipioDelegador = new MunicipioDelegador();
        DetalleReporteDelegador detalleReporteDelegador = new DetalleReporteDelegador();
        AutorizacionDelegador autorizacionDelegador = new AutorizacionDelegador();
        RestriccionesDelegador restriccionesDelegador = new RestriccionesDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) getMunicipios();
        }

        // Obtener municipios
        private void getMunicipios()
        {
            List<MunicipioDTO> listaMunicipio = municipioDelegador.consultar(null);
            var municipios = from m in listaMunicipio
                             select new
                             {
                                 codigo = m.Codigo,
                                 nombre = m.Nombre
                             };
            ddlMunicipio.DataSource = municipios.ToList();
            ddlMunicipio.DataBind();
            ListItem item = new ListItem("Seleccione", "");
            ddlMunicipio.Items.Insert(0, item);
        }
        

        // Consultar
        protected void btConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = DivResultados.Visible = false;
                Captcha1.ValidateCaptcha(tbCaptcha.Text.Trim());
                if (Captcha1.UserValidated) mostrarDetalle();
                else lblMessage.Visible = true;
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al consultar');", true);
            }
            finally
            {
                tbCaptcha.Text = "";
            }
        }

        // Mostrar Detalle
        private void mostrarDetalle()
        {
            DetalleReporteDTO detalleReporteDTO = new DetalleReporteDTO();
            if (ddlBuscar.SelectedValue.Equals("1"))
            {
                if (ddlMunicipio.SelectedValue != "") detalleReporteDTO.CodigoMunicipio = int.Parse(ddlMunicipio.SelectedValue);
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Debe seleccionar un Municipio');", true);
            }
            else if (ddlBuscar.SelectedValue.Equals("2"))
            {
                if (tbNumero.Text != "") detalleReporteDTO.Resolucion = tbNumero.Text;
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Debe ingresar el Número de Resolución');", true);
            }
            else
            {
                if (tbNumero.Text != "") detalleReporteDTO.CcNit = tbNumero.Text;
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Debe ingresar el Número de C.C. / Nit del Titular');", true);
            }
            List<DetalleReporteDTO> listaDetalle = detalleReporteDelegador.reporte(detalleReporteDTO);
            var detalle = from d in listaDetalle
                          select new
                          {
                              Autorizacion = setTipoAutorizacion(d.Autorizacion),
                              d.Resolucion,
                              d.Fecha,
                              d.Proyecto,
                              d.Titular,
                              d.CcNit,
                              d.NombreSuelo,
                              d.NombreMunicipio,
                              d.NombreVereda,
                              d.Sector,
                              d.Matricula,
                              d.Latitud,
                              d.Longitud,
                              d.Mapa,
                              d.Area,
                              d.NombreZonificacion,
                              Restricciones = setRestricciones(d.Restricciones),
                              d.Radicado,
                              d.Observaciones,
                              Anexo = d.Anexo != "" ? "Ver" : "",
                              Ruta = d.Anexo
                          };
            gvResultados.DataSource = detalle.ToList();
            gvResultados.DataBind();
            DivResultados.Visible = true;
        }

        // Mostrar Tipos de Autorización
        private string setTipoAutorizacion(string autorizacion)
        {
            List<string> res = new List<string>();
            List<AutorizacionDTO> listaAutorizacion = autorizacionDelegador.consultar(null);
            foreach (string a in autorizacion.Split(','))
            {
                res.Add(listaAutorizacion.Find(x => x.Codigo == int.Parse(a)).Nombre);
            }
            return string.Join(", ", res);
        }

        // Mostrar Restricciones
        private string setRestricciones(string restricciones)
        {
            List<string> res = new List<string>();
            List<RestriccionesDTO> listaRestricciones = restriccionesDelegador.consultar(null);
            foreach (string r in restricciones.Split(','))
            {
                res.Add(listaRestricciones.Find(x => x.Codigo == int.Parse(r)).Nombre);
            }
            return string.Join(", ", res);
        }

        // Paginación
        protected void gvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResultados.PageIndex = e.NewPageIndex;
            mostrarDetalle();
        }

    }
}