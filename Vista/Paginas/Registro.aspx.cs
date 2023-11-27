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
    public partial class Registro : System.Web.UI.Page
    {

        UsuarioDelegador usuarioDelegador = new UsuarioDelegador();
        MunicipioDelegador municipioDelegador = new MunicipioDelegador();
        AutorizacionDelegador autorizacionDelegador = new AutorizacionDelegador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) getMunicipios();
        }

        // Obtener municipios sin registro
        private void getMunicipios()
        {
            MunicipioDTO municipioDTO = new MunicipioDTO();
            municipioDTO.Registro = false;
            List<MunicipioDTO> listaMunicipio = municipioDelegador.consultar(municipioDTO);
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

        // Registro
        protected void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Captcha1.ValidateCaptcha(tbCaptcha.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    UsuarioDTO usuarioDTO = new UsuarioDTO();
                    MunicipioDTO municipioDTO = new MunicipioDTO();
                    municipioDTO.Codigo = int.Parse(ddlMunicipio.SelectedValue);
                    municipioDTO.Nombre = ddlMunicipio.SelectedItem.Text;
                    usuarioDTO.Municipio = municipioDTO;
                    RolDTO rolDTO = new RolDTO();
                    rolDTO.Codigo = 2; // Entidad
                    usuarioDTO.Rol = rolDTO;
                    usuarioDTO.Nombre = tbNombre.Text;
                    usuarioDTO.Id = tbCcNit.Text;
                    usuarioDTO.Email = tbEmail.Text;
                    usuarioDTO.Tel = tbTel.Text;
                    usuarioDTO.Password = tbPass1.Text;
                    usuarioDTO.Estado = 2; // Pendiente por aprobar
                    usuarioDelegador.crear(usuarioDTO);

                    // Notificación
                    UtilEmail.nuevaEntidad(usuarioDTO);
                    btAceptar.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "mensaje('Registro completado exitosamente. Su solicitud ha sido enviada y se encuentra Pendiente de aprobación');", true);
                }
                else lblMessage.Text = "Incorrecto";
            }
            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "advertencia", "advertencia('Existe otro usuario registrado para la misma Entidad. Solicita el bloqueo de los otros usuarios');", true);
            }
        }

    }
}