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
using System.IO;

namespace Vista.Paginas
{
    public partial class AdminNuevoInforme : System.Web.UI.Page
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
                getMeses();

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

        // Obtener últimos meses reportados
        private void getMeses()
        {
            ReporteDTO reporteDTO = new ReporteDTO();
            string codigoUsuario = (string)Session["usuario"];
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.Codigo = long.Parse(codigoUsuario);
            reporteDTO.Usuario = usuarioDTO;
            List<ReporteDTO> listaReporte = reporteDelegador.consultar(reporteDTO);
            var meses = from r in listaReporte
                        select new
                        {
                            codigo = r.Codigo,
                            municipio = r.Municipio.Nombre,
                            mes = Constantes.Meses[r.Mes] + " " + r.Anio,
                            enviado = Constantes.Boolean[r.Enviado]
                        };
            gvMeses.DataSource = meses.ToList();
            gvMeses.DataBind();
        }

        // Paginación
        protected void gvMeses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMeses.PageIndex = e.NewPageIndex;
            getMeses();
        }

        // Nuevo Reporte Mensual
        protected void btGuardarMes_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteDTO reporteDTO = new ReporteDTO();
                string codigoUsuario = (string)Session["usuario"];
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.Codigo = long.Parse(codigoUsuario);
                reporteDTO.Usuario = usuarioDTO;
                MunicipioDTO municipioDTO = new MunicipioDTO();
                municipioDTO.Codigo = int.Parse(ddlMunicipio.SelectedValue);
                reporteDTO.Municipio = municipioDTO;
                reporteDTO.Mes = int.Parse(ddlMes.SelectedValue);
                reporteDTO.Anio = int.Parse(tbAnio.Text);
                reporteDTO.Codigo = reporteDelegador.crear(reporteDTO);
                Session["codigoReporte"] = reporteDTO.Codigo.ToString();
                Server.Transfer("AdminInformeMensual.aspx");
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El mes seleccionado ya está reportado');", true);
            }
        }

        // Opciones
        protected void gvMeses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ReporteDTO reporteDTO = new ReporteDTO();
            reporteDTO.Codigo = long.Parse(gvMeses.DataKeys[index].Value.ToString());
            Session["codigoReporte"] = reporteDTO.Codigo.ToString();
            string enviado = gvMeses.Rows[index].Cells[2].Text;

            // Editar
            if (e.CommandName.Equals("Editar"))
            {
                if (enviado.Equals("No")) Server.Transfer("AdminInformeMensual.aspx");
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El informe ya fue enviado. No se puede modificar');", true);
            }

            // Descargar
            else if (e.CommandName.Equals("Descargar")) generarReporte(reporteDTO);

            // Eliminar
            else if (e.CommandName.Equals("Eliminar"))
            {
                if (enviado.Equals("No"))
                {
                    mpeEliminar.Enabled = true;
                    mpeEliminar.Show();
                }
                else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El informe ya fue enviado. No se puede eliminar');", true);
            }
        }

        // Confirmar eliminar
        protected void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoReporte = (string)Session["codigoReporte"];
                ReporteDTO reporteDTO = new ReporteDTO();
                reporteDTO.Codigo = long.Parse(codigoReporte);
                reporteDelegador.eliminar(reporteDTO);
                getMeses();
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Informe eliminado correctamente');", true);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al eliminar el Informe');", true);
            }
            finally
            {
                mpeEliminar.Enabled = false;
                mpeEliminar.Hide();
            }
        }

        // Cancelar eliminar
        protected void btCancelarEliminar_Click(object sender, EventArgs e)
        {
            mpeEliminar.Enabled = false;
            mpeEliminar.Hide();
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
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al generar Informe');", true);
            }
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

    }
}