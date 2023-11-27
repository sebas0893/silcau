using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using Modelo.Delegador;
using Transversal;
using Microsoft.Reporting.WebForms;
//using System.IO;

namespace Vista.Paginas
{
    public partial class AdminInforme : System.Web.UI.Page
    {

        ReporteDelegador reporteDelegador = new ReporteDelegador();
        DetalleReporteDelegador detalleReporteDelegador = new DetalleReporteDelegador();
        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();
        AutorizacionDelegador autorizacionDelegador = new AutorizacionDelegador();
        RestriccionesDelegador restriccionesDelegador = new RestriccionesDelegador();
        MunicipioDelegador municipioDelegador = new MunicipioDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string codigoRol = (string)Session["rol"];
                if (codigoRol != "1") Server.Transfer("Bienvenido.aspx");
                getMunicipios();
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
            ddlMunicipioFiltro.DataSource = municipios.ToList();
            ddlMunicipioFiltro.DataBind();
            ListItem item = new ListItem("Seleccione", "");
            ddlMunicipioFiltro.Items.Insert(0, item);
        }

        // Filtrar
        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            getReportes();
        }

        // Obtener reportes
        private void getReportes()
        {
            ReporteDTO reporteDTO = new ReporteDTO();
            if (ddlMunicipioFiltro.SelectedValue != "")
            {
                MunicipioDTO municipioDTO = new MunicipioDTO();
                municipioDTO.Codigo = int.Parse(ddlMunicipioFiltro.SelectedValue);
                reporteDTO.Municipio = municipioDTO;
            }
            if (tbAnioFiltro.Text != "") reporteDTO.Anio = int.Parse(tbAnioFiltro.Text);
            if (ddlMesFiltro.SelectedValue != "") reporteDTO.Mes = int.Parse(ddlMesFiltro.SelectedValue);
            List<ReporteDTO> listaReporte = reporteDelegador.reportes(reporteDTO);
            var reportes = from r in listaReporte
                           select new
                           {
                               codigo = r.Codigo,
                               municipio = r.NombreMunicipio,
                               mes = Constantes.Meses[r.Mes] + " " + r.Anio,
                               enviado = Constantes.Boolean[r.Enviado]
                           };
            gvMeses.DataSource = reportes.ToList();
            gvMeses.DataBind();

            // Total Informes Enviados
            lbTotal.Text = listaReporte.Where(x => x.Enviado.Equals(1)).ToList().Count.ToString();
            divReportes.Visible = true;
        }

        // Paginación
        protected void gvMeses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMeses.PageIndex = e.NewPageIndex;
            getReportes();
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

        // Opciones
        protected void gvMeses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ReporteDTO reporteDTO = new ReporteDTO();
            reporteDTO.Codigo = long.Parse(gvMeses.DataKeys[index].Value.ToString());
            hfCodigo.Value = reporteDTO.Codigo.ToString();
            string enviado = gvMeses.Rows[index].Cells[2].Text;

            // Devolver
            if (e.CommandName.Equals("Devolver"))
            {
                if (enviado.Equals("Si"))
                {
                    mpeDevolver.Enabled = true;
                    mpeDevolver.Show();
                }
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Sólo es posible devolver reportes enviados');", true);
            }

            // Descargar
            else if (e.CommandName.Equals("Descargar")) generarReporte(reporteDTO);
        }

        // Confirmar Devolver
        protected void btDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteDTO reporteDTO = new ReporteDTO();
                reporteDTO.Codigo = long.Parse(hfCodigo.Value);
                reporteDTO = reporteDelegador.consultar(reporteDTO)[0];
                string mes = Constantes.Meses[reporteDTO.Mes] + " " + reporteDTO.Anio;
                reporteDelegador.devolver(reporteDTO);

                UtilEmail.devolverInforme(reporteDTO, mes); // Enviar Notificación
                getReportes();
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('El informe fue enviado para ajustes');", true);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al devolver el informe');", true);
            }
        }

        // Cancelar Devolver
        protected void btCancelarDevolver_Click(object sender, EventArgs e)
        {
            mpeDevolver.Enabled = false;
            mpeDevolver.Hide();
        }

        // Generar reporte
        private void generarReporte(ReporteDTO reporteDTO)
        {
            try
            {
                ReportViewer rvReporte = new ReportViewer();
                rvReporte.LocalReport.EnableHyperlinks = true;
                rvReporte.LocalReport.ReportPath = "Reportes\\InformeMensual.rdlc";
                reporteDTO = reporteDelegador.consultar(reporteDTO)[0];
                DetalleReporteDTO detalleReporteDTO = new DetalleReporteDTO();
                detalleReporteDTO.Reporte = reporteDTO;
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
                                  d.NombreVereda,
                                  d.Sector,
                                  d.Matricula,
                                  d.Direccion,
                                  d.Tel,
                                  d.Latitud,
                                  d.Longitud,
                                  d.Mapa,
                                  d.Area,
                                  d.NombreZonificacion,
                                  Restricciones = setRestricciones(d.Restricciones),
                                  d.Radicado,
                                  d.Observaciones,
                                  d.Anexo
                              };
                rvReporte.LocalReport.DataSources.Clear();
                rvReporte.LocalReport.DataSources.Add(new ReportDataSource("dsDetalle", detalle.ToList()));

                // Parametros
                string mes = Constantes.Meses[reporteDTO.Mes] + " " + reporteDTO.Anio;
                string municipio = reporteDTO.Municipio.Nombre;
                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("municipio", municipio);
                parametros[1] = new ReportParameter("mes", mes);
                rvReporte.LocalReport.SetParameters(parametros);

                // Descargar
                Byte[] mybytes = rvReporte.LocalReport.Render("Excel", "");
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/excel";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=Informe " + municipio + " " + mes + ".xls");
                HttpContext.Current.Response.BinaryWrite(mybytes);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al generar el Informe');", true);
            }
        }

        // Cancelar
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            ddlMunicipioFiltro.SelectedValue = tbAnioFiltro.Text = ddlMesFiltro.SelectedValue = "";
        }

    }
}