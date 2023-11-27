<%@ Page Language="C#" Title="Registro" MasterPageFile="~/Paginas/Default.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vista.Paginas.Registro" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
<br />
<div class="container">
    <div class="row">
        <div class="col-md-12 col-xs-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title text-center">Registro</h4>
                </div>
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Municipio <font color="red">*</font></label>
                            <asp:DropDownList ID="ddlMunicipio" runat="server" class="form-control js-example-placeholder-single" required DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Responsable del diligenciamiento de información <font color="red">*</font></label>
                            <asp:TextBox ID="tbNombre" runat="server" class="form-control" placeholder="Nombre completo" required MaxLength="70"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>C.C./NIT <font color="red">*</font></label>
                            <asp:TextBox ID="tbCcNit" runat="server" class="form-control" placeholder="C.C./NIT" required MaxLength="15"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="tbCcNit_fte" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="tbCcNit"></asp:FilteredTextBoxExtender>
                        </div>
                        <div class="form-group">
                            <label>Correo electrónico <font color="red">*</font></label>
                            <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="Correo electrónico" TextMode="Email" required MaxLength="70"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Teléfono <font color="red">*</font></label>
                            <asp:TextBox ID="tbTel" runat="server" class="form-control" placeholder="Teléfono" required MaxLength="30"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Contraseña <font color="red">*</font></label>
                            <asp:TextBox ID="tbPass1" runat="server" class="form-control" TextMode="Password" placeholder="Mínimo 8, minúsculas, mayúsculas y números" required MaxLength="20"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPass" runat="server" ControlToValidate="tbPass1" ErrorMessage="Contraseña insegura" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                        </div>
                        <!-- Captcha -->
                        <div class="form-group">
                            <label>Verificación de seguridad <font color="red">*</font></label>
                            <cc1:captchacontrol ID="Captcha1" runat="server" CaptchaBackgroundNoise="None" FontColor="Green" CaptchaLength="4" CaptchaHeight="35" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" Width="200px" /><br />
                            <asp:TextBox ID="tbCaptcha" runat="server" class="form-control" autocomplete="off" placeholder="Carácteres de la imagen" required MaxLength="4"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
                    </div>

                    <!-- Términos -->
                    <div class="col-md-12 center-block">
                        <div class="panel panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">Autorización para el tratamiento de datos personales</h3>
                            </div>
                            <div class="panel-body" style="font-size:13.5px;;line-height:15px;overflow:auto;border:1px solid rgba(0,0,0,.1);height:180px;text-align:justify">
                                <p>Mediante el registro de sus datos personales en el presente formulario usted autoriza a La Corporación Autónoma Regional de las Cuencas de los Ríos Negro y Nare “Cornare”, Entidad pública, identificada con Nit 890985138-3, conforme a las facultades otorgadas en Ley 1581 de 2012 y las demás normas complementarías será el responsable del tratamiento y, en tal virtud, podrá recolectar, almacenar, usar, circular los datos personales suministrados con las siguientes finalidades:</p>
                                <p>1) Para los fines administrativos propios de la Entidad. 2) Contactar al Titular a través de medios electrónicos – SMS o chat para el envío de noticias relacionadas con campañas de mejoramiento del servicio, publicidad, comunicaciones y notificaciones por parte de la entidad. 3) Contactar al Titular a través de medios telefónicos para realizar encuestas, estudios y/o confirmación de datos personales necesarios para la ejecución de los trámites propios de la entidad. 4) Conocer y consultar la información del titular del dato que reposen en bases de datos de entidades públicas o privadas.</p>
                                <p><b>Derechos del titular:</b></p>
                                <p>Los derechos como titular del dato son los previstos en la Constitución y en la Ley 1581 de 2012, especialmente los siguientes: 1) Acceder en forma gratuita a los datos proporcionados que hayan sido objeto de tratamiento. 2) Solicitar la actualización y rectificación de su información frente a datos parciales, inexactos, incompletos, fraccionados, que induzcan a error, o a aquellos cuyo tratamiento esté prohibido o no haya sido autorizado. 3) Solicitar prueba de la autorización otorgada. 4) Presentar ante la Superintendencia de Industria y Comercio (SIC) quejas por infracciones a lo dispuesto en la normatividad vigente. 5) Revocar la autorización y/o solicitar la supresión del dato, a menos que exista un deber legal o contractual que haga imperativo conservar la información. 6) Abstenerse de responder las preguntas sobre datos sensibles o sobre datos de las niñas y niños y adolescentes.</p>
                                <p>Estos derechos se podrán ejercer a través de los canales o medios dispuestos por “Cornare” para la atención al público: la línea de atención (57 4) 5201170, correo electrónico cliente@cornare.gov.co, oficinas y números telefónicos de atención al cliente a nivel regional (El Santuario, Rionegro, Guatapé, San Luis, Alejandría, Sonsón y CITES, Departamento de Antioquia) los cuales podrá consultar en la página web de la Corporación. Por todo lo anterior, otorgo mi consentimiento a La Corporación Autónoma Regional de las Cuencas de los Ríos Negro y Nare “Cornare” para que trate mi información personal de acuerdo con la Política de Protección de Datos Personales dispuesta por la Entidad en la página web www.cornare.gov.co sección Protección de Datos y de forma física en las sedes de la Corporación. Dicha política se me dio a conocer antes de recolectar mis datos personales.</p>
                                <p>Manifiesto que la presente autorización me fue solicitada y puesta de presente antes de entregar mis datos y que la suscribo de forma libre y voluntaria una vez leída en su totalidad.</p>
                            </div>
                        </div>
                        <label>
                            <asp:CheckBox ID="cbAcepto" runat="server" onchange="changeCheck()" />  &nbsp;Entiendo y acepto el registro y uso de mis datos personales, como se estipula anteriormente
                        </label>
                        <br /><br />
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btAceptar" runat="server" Text="Aceptar" class="btn btn-lg btn-success btn-block" onclick="btAceptar_Click" disabled />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:HyperLink runat="server" ID="hlAtras" NavigateUrl="~/Paginas/Inicio.aspx" class="btn btn-lg btn-info btn-block" role="button">Atrás</asp:HyperLink>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>        
    </div>
</div>

<script type="text/javascript">

    function changeCheck() {
        var $aceptar = $('input[id*=cbAcepto]').is(":checked");
        if ($aceptar) {
            $('#<%= btAceptar.ClientID %>').prop('disabled', false);
        }
        else {
            $('#<%= btAceptar.ClientID %>').prop('disabled', true);
        }
    }

</script>

</asp:Content>