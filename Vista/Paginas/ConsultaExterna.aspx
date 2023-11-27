<%@ Page Title="Consultas" MasterPageFile="~/Paginas/Default.Master" MaintainScrollPositionOnPostback="true" Language="C#" AutoEventWireup="true" CodeBehind="ConsultaExterna.aspx.cs" Inherits="Vista.Paginas.ConsultaExterna" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title text-center">Consultas</h4>
            </div>
            <div class="panel-body">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Buscar <font color="red"> *</font> </label>
                        <asp:DropDownList runat="server" ID="ddlBuscar" class="form-control" required>
                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                            <asp:ListItem Value="1">Municipio</asp:ListItem>
                            <asp:ListItem Value="2">Resolución</asp:ListItem>
                            <asp:ListItem Value="3">C.C. / Nit del Titular</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Municipio</label>
                        <asp:DropDownList ID="ddlMunicipio" runat="server" class="form-control js-example-placeholder-single" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Número</label>
                        <asp:TextBox ID="tbNumero" runat="server" class="form-control" MaxLength="50" placeholder="Número"></asp:TextBox>
                        <asp:filteredtextboxextender ID="fteNumero" runat="server" FilterType="Numbers" TargetControlID="tbNumero" />
                    </div>
                    <div class="form-group">
                        <label>Verificación de seguridad<font color="red">*</font></label>
                        <cc1:captchacontrol ID="Captcha1" runat="server" CaptchaBackgroundNoise="None" FontColor="Green" CaptchaLength="4" CaptchaHeight="35" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" Width="200px" /><br />
                        <asp:TextBox ID="tbCaptcha" runat="server" class="form-control" required autocomplete="off" placeholder="Carácteres de la imagen" MaxLength="4"></asp:TextBox>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">Incorrecto</asp:Label>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Button runat="server" ID="btConsultar" class="btn btn-lg btn-success btn-block" Text="Consultar" onclick="btConsultar_Click" />
                        </div>
                    </div>
                </div>

                <!-- Resultados -->
                <div class="col-md-12 text-center" runat="server" ID="DivResultados" visible="false">
                    <div class="alert alert-success">
                        <strong>Detalle de la Consulta</strong>
                    </div>
                    <div class="table-responsive" style="overflow: scroll;">
                        <asp:GridView ID="gvResultados" HeaderStyle-VerticalAlign="Bottom" Width="200%" 
                            runat="server" AutoGenerateColumns="False" 
                            class="table table-bordered table-striped" AllowPaging="True" 
                            onpageindexchanging="gvResultados_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Autorizacion" HeaderText="Tipo de Autorización" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Resolucion" HeaderText="Número de Resolución" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Proyecto" HeaderText="Nombre del Proyecto" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Titular" HeaderText="Titular o Propietario" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="CcNit" HeaderText="C.C. / Nit" />
                                <asp:BoundField DataField="NombreSuelo" HeaderText="Suelo" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="NombreMunicipio" HeaderText="Municipio" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="NombreVereda" HeaderText="Vereda" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Sector" HeaderText="Paraje o Sector" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Matricula" HeaderText="Matrícula Inmobiliaria" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Latitud" HeaderText="Latitud" />
                                <asp:BoundField DataField="Longitud" HeaderText="Longitud" />
                                <asp:HyperLinkField DataNavigateUrlFields="Mapa" HeaderText="Mapa" Target="_blank" Text="Ver" />
                                <asp:BoundField DataField="Area" HeaderText="Área (m2)" />
                                <asp:BoundField DataField="NombreZonificacion" HeaderText="Zonificación POT y Usos" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Restricciones" HeaderText="Restricciones ambientales" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Radicado" HeaderText="Radicado PAA" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" ItemStyle-Wrap="false" />
                                <asp:HyperLinkField DataNavigateUrlFields="Ruta" DataTextField="Anexo" HeaderText="Anexo" Target="_blank" />
                            </Columns>
                            <EmptyDataTemplate>
                                NO SE ENCONTRARON RESULTADOS
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="success headerClass" />
                        </asp:GridView>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>

</asp:Content>