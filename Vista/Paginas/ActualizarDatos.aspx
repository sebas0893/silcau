<%@ Page Language="C#" Title="Actualizar datos" MasterPageFile="~/Paginas/Admin.Master" AutoEventWireup="true" CodeBehind="ActualizarDatos.aspx.cs" Inherits="Vista.Paginas.ActualizarDatos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title text-center">Actualizar datos</h4>
            </div>
            <div class="panel-body">
                <div class="col-md-6">
                   <div class="form-group">
                        <label>Municipio: </label>
                        <br />
                        <asp:Label ID="lbMunicipio" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Responsable del diligenciamiento de información: <font color="red">*</font></label>
                        <br />
                        <asp:TextBox ID="tbNombre" runat="server" class="form-control" placeholder="Nombre o Razón social" required MaxLength="70"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>C.C./NIT: <font color="red">*</font></label>
                        <br />
                        <asp:TextBox ID="tbCcNit" runat="server" class="form-control" placeholder="C.C./NIT" required MaxLength="15"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="tbCcNit_fte" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="tbCcNit"></asp:FilteredTextBoxExtender>
                    </div>
                    <div class="form-group">
                        <label>Correo electrónico: <font color="red">*</font></label>
                        <br />
                        <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="Correo electrónico" TextMode="Email" required></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Teléfono: <font color="red">*</font></label>
                        <br />
                        <asp:TextBox ID="tbTel" runat="server" class="form-control" placeholder="Tel" required></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Nueva contraseña: </label>
                        <asp:TextBox ID="tbPass" runat="server" class="form-control" TextMode="Password" placeholder="Mínimo 8, minúsculas, mayúsculas y números" MaxLength="20"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="revPass" runat="server" ControlToValidate="tbPass" ErrorMessage="Contraseña insegura" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-12 center-block">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btAceptar" runat="server" Text="Aceptar" class="btn btn-lg btn-success btn-block" onclick="btAceptar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>    
    
</asp:Content>
