<%@ Page Title="Editar Entidad" MasterPageFile="~/Paginas/Admin.Master" Language="C#" AutoEventWireup="true" CodeBehind="EditarEntidad.aspx.cs" Inherits="Vista.Paginas.EditarEntidad" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title text-center">Actualizar datos de la Entidad</h4>
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
                        <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="Correo electrónico" TextMode="Email" required MaxLength="70"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Teléfono: <font color="red">*</font></label>
                        <br />
                        <asp:TextBox ID="tbTel" runat="server" class="form-control" placeholder="Teléfono" required MaxLength="30"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Estado: <font color="red">*</font></label>
                        <br />
                        <asp:DropDownList ID="ddlEstado" runat="server" class="form-control">
                            <asp:ListItem Value="1">Aprobado</asp:ListItem>
                            <asp:ListItem Value="2">Pendiente por aprobar</asp:ListItem>
                            <asp:ListItem Value="3">Bloqueado</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12 center-block">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btAceptar" runat="server" Text="Actualizar" class="btn btn-lg btn-success btn-block" onclick="btAceptar_Click" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:HyperLink runat="server" ID="hlAtras" NavigateUrl="~/Paginas/Entidades.aspx" class="btn btn-lg btn-info btn-block" role="button">Atrás</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>    
    
</asp:Content>