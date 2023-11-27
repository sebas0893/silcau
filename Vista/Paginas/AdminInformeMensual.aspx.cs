using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Entidad;
using Modelo.Delegador;
using Transversal;

namespace Vista.Paginas
{
    public partial class AdminInformeMensual : System.Web.UI.Page
    {

        ReporteDelegador reporteDelegador = new ReporteDelegador();
        DetalleReporteDelegador detalleReporteDelegador = new DetalleReporteDelegador();
        AutorizacionDelegador autorizacionDelegador = new AutorizacionDelegador();
        SueloDelegador sueloDelegador = new SueloDelegador();
        VeredaDelegador veredaDelegador = new VeredaDelegador();
        ZonificacionDelegador zonificacionDelegador = new ZonificacionDelegador();
        RestriccionesDelegador restriccionesDelegador = new RestriccionesDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string codigoReporte = (string)Session["codigoReporte"];
                ReporteDTO reporteDTO = new ReporteDTO();
                reporteDTO.Codigo = long.Parse(codigoReporte);
                reporteDTO = reporteDelegador.consultar(reporteDTO)[0];
                lbMunicipio.Text = reporteDTO.Municipio.Nombre;
                lbMes.Text = Constantes.Meses[reporteDTO.Mes] + " " + reporteDTO.Anio;
                getAutorizacion();
                getSuelo();
                getVeredas(reporteDTO.Municipio);
                getZonificacion();
                getRestricciones();
                mostrarDetalleReporte(reporteDTO);
            }
        }

        // Obtener Tipos de Autorización
        private void getAutorizacion()
        {
            List<AutorizacionDTO> listaAutorizacion = autorizacionDelegador.consultar(null);
            var autorizaciones = from a in listaAutorizacion
                                 select new
                                 {
                                     codigo = a.Codigo,
                                     nombre = a.Nombre
                                 };
            lbAutorizacion.DataSource = autorizaciones.ToList();
            lbAutorizacion.DataBind();
        }

        // Obtener Tipos de Suelo
        private void getSuelo()
        {
            List<SueloDTO> listaSuelo = sueloDelegador.consultar(null);
            var suelos = from s in listaSuelo
                         select new
                         {
                             codigo = s.Codigo,
                             nombre = s.Nombre
                         };
            ddlSuelo.DataSource = suelos.ToList();
            ddlSuelo.DataBind();
            ListItem item = new ListItem("Seleccione", "");
            ddlSuelo.Items.Insert(0, item);
        }

        // Obtener Veredas
        private void getVeredas(MunicipioDTO municipioDTO)
        {
            VeredaDTO veredaDTO = new VeredaDTO();
            veredaDTO.Municipio = municipioDTO;
            List<VeredaDTO> listaVereda = veredaDelegador.consultar(veredaDTO);
            var veredas = from v in listaVereda
                          select new
                          {
                              codigo = v.Codigo,
                              nombre = v.Nombre
                          };
            ddlVereda.DataSource = veredas.ToList();
            ddlVereda.DataBind();
            ListItem item = new ListItem("Seleccione", "");
            ddlVereda.Items.Insert(0, item);
        }

        // Obtener Tipos de Zonificación 
        private void getZonificacion()
        {
            List<ZonificacionDTO> listaZonificacion = zonificacionDelegador.consultar(null);
            var zonificaciones = from z in listaZonificacion
                                 select new
                                 {
                                     codigo = z.Codigo,
                                     nombre = z.Nombre
                                 };
            ddlZonificacion.DataSource = zonificaciones.ToList();
            ddlZonificacion.DataBind();
            ListItem item = new ListItem("Seleccione", "");
            ddlZonificacion.Items.Insert(0, item);
        }

        // Obtener Tipos de Restricciones 
        private void getRestricciones()
        {
            List<RestriccionesDTO> listaRestricciones = restriccionesDelegador.consultar(null);
            var restricciones = from r in listaRestricciones
                                select new
                                {
                                    codigo = r.Codigo,
                                    nombre = r.Nombre
                                };
            lbRestricciones.DataSource = restricciones.ToList();
            lbRestricciones.DataBind();
        }

        // Mostrar detalle reporte
        private void mostrarDetalleReporte(ReporteDTO reporteDTO)
        {
            DetalleReporteDTO detalleReporteDTO = new DetalleReporteDTO();
            detalleReporteDTO.Reporte = reporteDTO;
            List<DetalleReporteDTO> listaDetalleReporte = detalleReporteDelegador.consultar(detalleReporteDTO);
            var detalle = from d in listaDetalleReporte
                          select new
                          {
                              codigo = d.Codigo,
                              autorizacion = setTipoAutorizacion(d.Autorizacion),
                              resolucion = d.Resolucion,
                              fecha = d.Fecha,
                              proyecto = d.Proyecto,
                              titular = d.Titular,
                              ccNit = d.CcNit,
                              vereda = d.NombreVereda
                          };
            gvReporte.DataSource = detalle.ToList();
            gvReporte.DataBind();
        }

        // Enviar Reporte
        protected void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoReporte = (string)Session["codigoReporte"];
                ReporteDTO reporteDTO = new ReporteDTO();
                reporteDTO.Codigo = long.Parse(codigoReporte);
                reporteDTO.Enviado = 1;
                reporteDelegador.enviar(reporteDTO);

                // Email
                UtilEmail.enviarReporte(lbMunicipio.Text, lbMes.Text);
                Server.Transfer("AdminNuevoInforme.aspx");
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al enviar el Informe');", true);
            }
        }

        // Editar - Eliminar detalle
        protected void gvReporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DetalleReporteDTO detalleReporteDTO = new DetalleReporteDTO();
            detalleReporteDTO.Codigo = int.Parse(gvReporte.DataKeys[index].Value.ToString());
            hfCodigo.Value = detalleReporteDTO.Codigo.ToString();

            // Editar
            if (e.CommandName.Equals("Editar"))
            { 
                fuAnexo.Enabled = false;
                detalleReporteDTO = detalleReporteDelegador.consultar(detalleReporteDTO)[0];

                // Detalle
                foreach (string a in detalleReporteDTO.Autorizacion.Split(','))
                {
                    lbAutorizacion.Items.FindByValue(a).Selected = true;
                }
                tbResolucion.Text = detalleReporteDTO.Resolucion;
                tbFecha.Text = detalleReporteDTO.Fecha;
                tbProyecto.Text = detalleReporteDTO.Proyecto;
                tbTitular.Text = detalleReporteDTO.Titular;
                tbCcNit.Text = detalleReporteDTO.CcNit;
                ddlSuelo.SelectedValue = detalleReporteDTO.Suelo.Codigo.ToString();
                ddlVereda.SelectedValue = detalleReporteDTO.Vereda.Codigo.ToString();
                tbSector.Text = detalleReporteDTO.Sector;
                tbMatricula.Text = detalleReporteDTO.Matricula;
                tbDireccion.Text = detalleReporteDTO.Direccion;
                tbTel.Text = detalleReporteDTO.Tel;
                tbLatitud.Text = detalleReporteDTO.Latitud;
                tbLongitud.Text = detalleReporteDTO.Longitud;
                tbArea.Text = detalleReporteDTO.Area.ToString();
                ddlZonificacion.SelectedValue = detalleReporteDTO.Zonificacion.Codigo.ToString();
                foreach (string r in detalleReporteDTO.Restricciones.Split(','))
                {
                    lbRestricciones.Items.FindByValue(r).Selected = true;
                }
                tbRadicado.Text = detalleReporteDTO.Radicado;
                tbObservaciones.Text = detalleReporteDTO.Observaciones;

                // Modal
                mpeReporte.Enabled = true;
                mpeReporte.Show();
            }

            // Eliminar
            else if (e.CommandName.Equals("Eliminar"))
            {
                mpeEliminar.Enabled = true;
                mpeEliminar.Show();
            }
        }

        // Obtener detalle Reporte
        private DetalleReporteDTO getDetalleReporte()
        {
            DetalleReporteDTO detalleReporteDTO = new DetalleReporteDTO();
            string codigoReporte = (string)Session["codigoReporte"];
            ReporteDTO reporteDTO = new ReporteDTO();
            reporteDTO.Codigo = long.Parse(codigoReporte);
            detalleReporteDTO.Reporte = reporteDTO;
            List<string> autorizacion = new List<string>();
            foreach (int index in lbAutorizacion.GetSelectedIndices())
            {
                autorizacion.Add(lbAutorizacion.Items[index].Value);
            }
            detalleReporteDTO.Autorizacion = string.Join(",", autorizacion);
            detalleReporteDTO.Resolucion = tbResolucion.Text;
            detalleReporteDTO.Fecha = tbFecha.Text;
            detalleReporteDTO.Proyecto = tbProyecto.Text;
            detalleReporteDTO.Titular = tbTitular.Text;
            detalleReporteDTO.CcNit = tbCcNit.Text;
            SueloDTO sueloDTO = new SueloDTO();
            sueloDTO.Codigo = int.Parse(ddlSuelo.SelectedValue);
            detalleReporteDTO.Suelo = sueloDTO;
            VeredaDTO veredaDTO = new VeredaDTO();
            veredaDTO.Codigo = ddlVereda.SelectedValue;
            detalleReporteDTO.Vereda = veredaDTO;
            detalleReporteDTO.Sector = tbSector.Text;
            detalleReporteDTO.Matricula = tbMatricula.Text;
            detalleReporteDTO.Direccion = tbDireccion.Text;
            detalleReporteDTO.Tel = tbTel.Text;
            detalleReporteDTO.Latitud = tbLatitud.Text;
            detalleReporteDTO.Longitud = tbLongitud.Text;
            detalleReporteDTO.Area = decimal.Parse(tbArea.Text);
            ZonificacionDTO zonificacionDTO = new ZonificacionDTO();
            zonificacionDTO.Codigo = int.Parse(ddlZonificacion.SelectedValue);
            detalleReporteDTO.Zonificacion = zonificacionDTO;
            List<string> restricciones = new List<string>();
            foreach (int index in lbRestricciones.GetSelectedIndices())
            {
                restricciones.Add(lbRestricciones.Items[index].Value);
            }
            detalleReporteDTO.Restricciones = string.Join(",", restricciones);
            detalleReporteDTO.Radicado = tbRadicado.Text;
            detalleReporteDTO.Anexo = "";
            if (fuAnexo.FileName != "") detalleReporteDTO.Anexo = detalleReporteDTO.Resolucion + " " + detalleReporteDTO.Fecha + ".pdf";
            detalleReporteDTO.Observaciones = tbObservaciones.Text;
            return detalleReporteDTO;
        }

        // Guardar detalle Reporte
        protected void btGuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleReporteDTO detalleReporteDTO = getDetalleReporte();
                // Actualizar
                if (hfCodigo.Value != null && hfCodigo.Value != "")
                {
                    detalleReporteDTO.Codigo = long.Parse(hfCodigo.Value);
                    detalleReporteDelegador.actualizar(detalleReporteDTO);
                    limpiarDetalleReporte();
                }
                // Guardar
                else
                {
                    // Anexo máximo 2 MB - 2000000 Bytes
                    if (fuAnexo.PostedFile.ContentLength < 2000000)
                    {
                        detalleReporteDelegador.crear(detalleReporteDTO);
                        if (fuAnexo.FileName != "")
                        {
                            string ruta = Server.MapPath(Constantes.RutaAnexos);
                            fuAnexo.PostedFile.SaveAs(Path.Combine(ruta, detalleReporteDTO.Anexo));
                        }
                        limpiarDetalleReporte();
                    }
                    else ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('El anexo no puede superar el tamaño permitido: 2 MB');", true);
                }
                mostrarDetalleReporte(detalleReporteDTO.Reporte);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Registro guardado correctamente');", true);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al guardar: Verifique que los campos son correctos');", true);
            }
        }

        // Limpiar detalle reporte
        private void limpiarDetalleReporte()
        {
            lbAutorizacion.SelectedIndex = lbRestricciones.SelectedIndex = -1;
            ddlSuelo.SelectedValue = ddlVereda.SelectedValue = ddlZonificacion.SelectedValue = tbResolucion.Text = tbFecha.Text = tbProyecto.Text = tbTitular.Text = tbCcNit.Text = tbSector.Text = tbMatricula.Text = tbDireccion.Text = tbLatitud.Text = tbLongitud.Text = tbArea.Text = tbRadicado.Text = tbObservaciones.Text = hfCodigo.Value = "";
            fuAnexo.Enabled = true;
            mpeReporte.Enabled = false;
            mpeReporte.Hide();
        }

        // Cerrar reporte
        protected void btCerrarReporte_Click(object sender, EventArgs e)
        {
            limpiarDetalleReporte();
        }

        // Agregar registro
        protected void btAgregar_Click(object sender, EventArgs e)
        {
            mpeReporte.Enabled = true;
            mpeReporte.Show();
        }

        // Confirmar eliminar
        protected void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleReporteDTO detalleReporteDTO = new DetalleReporteDTO();
                detalleReporteDTO.Codigo = long.Parse(hfCodigo.Value);
                detalleReporteDelegador.eliminar(detalleReporteDTO);
                ReporteDTO reporteDTO = new ReporteDTO();
                string codigoReporte = (string)Session["codigoReporte"];
                reporteDTO.Codigo = long.Parse(codigoReporte);
                mostrarDetalleReporte(reporteDTO);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Registro eliminado correctamente');", true);
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Error al eliminar el registro');", true);
            }
            finally
            {
                limpiarCampos();
            }
        }

        // Cancelar eliminar
        protected void btCancelarEliminar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        // Limpiar Campos
        private void limpiarCampos()
        {
            hfCodigo.Value = "";
            mpeEliminar.Enabled = false;
            mpeEliminar.Hide();
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

    }
}