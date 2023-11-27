using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using Entidad;

namespace Transversal
{
    public class UtilEmail
    {

        // Nueva entidad
        public static void nuevaEntidad(UsuarioDTO usuarioDTO)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Nueva Entidad - SILCAU";
                string mensaje = "<h2>Nueva Entidad,</h2></br>" +
                "<p>Se ha registrado una nueva Entidad en el aplicativo SILCAU, la cual se encuentra Pendiente de aprobación:</p></br>" +
                "<p>Municipio: " + usuarioDTO.Municipio.Nombre + "</p></br>" +
                "<p>Responsable del diligenciamiento: " + usuarioDTO.Nombre + "</p></br>" +
                "<p>CC/NIT: " + usuarioDTO.Id + "</p></br>" +
                "<p>Email: " + usuarioDTO.Email + "</p></br>" +
                "<p>Teléfono: " + usuarioDTO.Tel + "</p></br></br>" +
                "<p>Correo enviado por el aplicativo SILCAU</p>";
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                mail.To.Add("ordenamientoterritorial@cornare.gov.co");
                enviarEmail(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Reporte mensual
        public static void enviarReporte(string municipio, string mes)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Informe mensual - SILCAU";
                string mensaje = "<h2>Informe mensual,</h2></br>" +
                "<p>Se ha enviado un nuevo Informe mensual:</p></br>" +
                "<p>Municipio: " + municipio + "</p></br>" +
                "<p>Mes reportado: " + mes + "</p></br></br>" +
                "<p>Correo enviado por el aplicativo SILCAU</p>";
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                mail.To.Add("ordenamientoterritorial@cornare.gov.co");
                enviarEmail(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Devolver informe
        public static void devolverInforme(ReporteDTO reporteDTO, string mes)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Devolución de Informe mensual - SILCAU";
                mail.Body = "<h2>Devolución de Informe mensual,</h2></br>" +
                            "<p>El Informe del Municipio " + reporteDTO.Municipio.Nombre + " para el mes de " + mes + " fue habilitado para ajustes. Por favor actualizar y enviar nuevamente el Informe.</p></br></br>" +
                            "<p>Correo enviado por el aplicativo SILCAU</p>";
                mail.IsBodyHtml = true;
                
                // Enviar copia al Administrador
                mail.To.Add("ordenamientoterritorial@cornare.gov.co");
                if (reporteDTO.Usuario.Codigo != 1) mail.To.Add(reporteDTO.Usuario.Email); // Reporte enviado por Municpio
                enviarEmail(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Estado de usuario
        public static void estadoUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Registro - SILCAU";
                string mensaje = "<h2>Estimado Usuario,</h2></br>" +
                "<p>Su nuevo estado es: " + Constantes.EstadoUsuario[usuarioDTO.Estado] + "</p></br>" +
                "<p>Para resolver cualquier inquietud, comuníquese a la Oficina de Ordenamiento al teléfono 546 1616 ext 478 </p></br></br>" +
                "<p>Correo enviado por el aplicativo SILCAU</p>";
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                mail.To.Add(usuarioDTO.Email);
                enviarEmail(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Recuperar password
        public static void recuperarPassword(UsuarioDTO usuarioDTO)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Olvidé mis datos - SILCAU";
                mail.Body = "<h2>Estimado Usuario,</h2></br>" +
                            "<p>Su contraseña es: " + usuarioDTO.Password + "</p></br></br></br>" +
                            "<p>Por motivos de seguridad le recomendamos cambiar la contraseña y eliminar este correo electrónico. Agradecemos su colaboración.</p></br></br>" +
                            "<p>Correo enviado por el aplicativo SILCAU</p>";
                mail.IsBodyHtml = true;
                mail.To.Add(usuarioDTO.Email);
                enviarEmail(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Enviar email
        private static void enviarEmail(MailMessage mail)
        {
            try
            {
                // Configuracion del SMTP
                mail.From = new MailAddress("aplicativos@cornare.gov.co", "SILCAU - Cornare", Encoding.UTF8);
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;

                // Credenciales
                SmtpServer.Credentials = new System.Net.NetworkCredential("aplicativos@cornare.gov.co", "4pl1c4t1v0s");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

    }
}
