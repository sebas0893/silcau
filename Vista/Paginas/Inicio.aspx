<%@ Page Title="SILCAU" MasterPageFile="~/Paginas/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vista.Paginas.Inicio" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent" >
    
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="login-panel panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title text-center">Inicio</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>C.C./NIT &nbsp;<asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="tbUsuario" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="login"></asp:RequiredFieldValidator></label>
                        <asp:TextBox ID="tbUsuario" runat="server" class="form-control" placeholder="C.C./NIT" />
                    </div>
                    <div class="form-group">
                        <label>Contraseña &nbsp;<asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="tbPassword" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="login"></asp:RequiredFieldValidator></label>
                        <asp:TextBox ID="tbPassword" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password" />
                    </div>
                    <asp:Button ID="btIngresar" runat="server" Text="Ingresar" 
                        class="btn btn-lg btn-success btn-block" onclick="btIngresar_Click" 
                        ValidationGroup="login" />
                    <br />
                    <center>
                        <asp:HyperLink ID="hlRegistro" runat="server" NavigateUrl="~/Paginas/Registro.aspx" role="button">Regístrese</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="hlRecuperarDatos" runat="server" role="button">Olvidé mis datos</asp:HyperLink>
                    </center>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Clave -->
    <asp:ModalPopupExtender ID="mpeClave" runat="server" PopupControlID="pnClave" TargetControlID="hlRecuperarDatos" CancelControlID="btCerrarClave" BackgroundCssClass="modalBackground" DropShadow="true"></asp:ModalPopupExtender>

    <!-- Panel Clave -->
    <asp:Panel ID="pnClave" runat="server" style="display:none; background:white; width:800px">
        <div class="modal-header"><h3>Olvidé mis datos</h3></div>
        <div class="modal-body">
            <div class="container-fluid well">
                <div class="row-fluid">
                    <div class="span4" style="width: 80%">
                        <div class="control-group">                                            
                            <label class="control-label">C.C./NIT &nbsp;<asp:RequiredFieldValidator ID="rfvCc" runat="server" ControlToValidate="tbUsuarioClave" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="clave"></asp:RequiredFieldValidator>
                            </label>
                            <div class="controls">
                                <asp:TextBox ID="tbUsuarioClave" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="tbUsuarioClave_fte" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="tbUsuarioClave"></asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button runat="server" ID="btCerrarClave" CausesValidation="false" class="btn btn-default"  Text="Cerrar" />
            <asp:Button runat="server" ID="btGuardarClave" class="btn btn-primary" Text="Aceptar" onclick="btGuardarClave_Click" ValidationGroup="clave" />
        </div>
    </asp:Panel>

</asp:Content>