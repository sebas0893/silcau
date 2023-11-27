using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Entidad;
using Modelo.Delegador;
using Transversal;

namespace Vista.Paginas
{
    public partial class Reportes : System.Web.UI.Page
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();
        MunicipioDelegador municipioDelegador = new MunicipioDelegador();
        AutorizacionDelegador autorizacionDelegador = new AutorizacionDelegador();
        ReporteDelegador reporteDelegador = new ReporteDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string codigoRol = (string)Session["rol"];
                if (codigoRol != "1") Server.Transfer("Bienvenido.aspx");
                else getMunicipios();
            }
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

        // Generar Reporte
        protected void btGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                rvReporte.Visible = false;
                rvReporte.LocalReport.DataSources.Clear();
                string reporte = ddlReporte.SelectedValue;
                switch (reporte)
                {

                    // Entidades registradas
                    case "1":
                        UsuarioDTO usuarioDTO = new UsuarioDTO();
                        usuarioDTO.FechaRegistro = tbFechaInicial.Text;
                        usuarioDTO.UltimoAcceso = tbFechaFinal.Text;
                        // Regional
                        if (ddlRegional.SelectedValue != "")
                        {
                            MunicipioDTO municipioDTO = new MunicipioDTO();
                            municipioDTO.Regional = int.Parse(ddlRegional.SelectedValue);
                            usuarioDTO.Municipio = municipioDTO;
                        }
                        // Municipio
                        if (ddlMunicipio.SelectedValue != "")
                        {
                            MunicipioDTO municipioDTO = new MunicipioDTO();
                            municipioDTO.Codigo = int.Parse(ddlMunicipio.SelectedValue);
                            usuarioDTO.Municipio = municipioDTO;
                        }
                        break;

                }
                
                // Parámetros
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("fechas", "DEL " + tbFechaInicial.Text + " AL " + tbFechaFinal.Text);
                rvReporte.LocalReport.SetParameters(parametros);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('No hay información para generar el reporte');", true);
            }
        }

    }
}