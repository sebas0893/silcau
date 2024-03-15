<%@ Page Language="C#" Title="Informe de Licencias" MasterPageFile="~/Paginas/Admin.Master" AutoEventWireup="true" CodeBehind="AdminInforme.aspx.cs" Inherits="Vista.Paginas.AdminInforme" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <strong>Informe de Licencias</strong>
            </div>
            <div class="panel-body">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <label>Municipio</label>
                    <asp:DropDownList runat="server" ID="ddlMunicipioFiltro" class="form-control js-example-placeholder-single" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                    <label>Año</label>
                    <asp:TextBox ID="tbAnioFiltro" runat="server" class="form-control" placeholder="Año"></asp:TextBox>
                    <label>Mes</label>
                    <asp:DropDownList runat="server" ID="ddlMesFiltro" class="form-control">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Button runat="server" ID="btFiltrar" Text="Consultar" class="btn btn-primary" Width="165px" onclick="btFiltrar_Click" />
                    &nbsp;<asp:Button runat="server" ID="btCancelar" Text="Cancelar" class="btn btn-danger" Width="165px" onclick="btCancelar_Click" />
                </div>

                <div class="col-md-12" runat="server" id="divReportes" visible="false" style="text-align: center; margin-top: 20px">
                    <label>Total Informes Enviados: </label>&nbsp;<asp:Label ID="lbTotal" runat="server" Text="0"></asp:Label>
                    <br />
                    <div class="table-responsive text-center">
                        <asp:GridView ID="gvMeses" runat="server" class="table table-bordered table-striped" AllowPaging="True" PageSize="10" AutoGenerateColumns="False" DataKeyNames="codigo" onpageindexchanging="gvMeses_PageIndexChanging" onrowcommand="gvMeses_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="municipio" HeaderText="Municipio" />
                                <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="mes" HeaderText="Mes" />
                                <asp:BoundField DataField="enviado" HeaderText="Enviado" />
                                <asp:BoundField DataField="tieneResgistros" HeaderText="Lincencias/Autorizaciones otorgadas" />
                                <asp:ButtonField ButtonType="Image" CommandName="Devolver" HeaderText="Devolver" ImageUrl="~/img/icono_cambiar.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="Descargar" HeaderText="Descargar" ImageUrl="~/img/icon_excel.png" />
                            </Columns>
                            <EmptyDataTemplate>
                                NO HAY INFORMES PARA EL MES SELECCIONADO
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="success headerClass" />
                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                        </asp:GridView>
                        <asp:HiddenField ID="hfCodigo" runat="server" Value="" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal popup Devolver -->
<asp:ModalPopupExtender ID="mpeDevolver" runat="server" Enabled="false" TargetControlID="gvMeses" BackgroundCssClass="modalBackground" PopupControlID="pnlDevolver" DropShadow="true"></asp:ModalPopupExtender>

<!-- Panel Devolver -->
<asp:Panel ID="pnlDevolver" runat="server" style="display:none; left:0px; background:white;" Width="500px">
    <div class="modal-header"><h4>Devolver reporte</h4>
        <div class="container-fluid well">
             <div class="row-fluid">
                <div class="span4" style="width: 424px; text-align:justify">
                    Al devolver el informe se enviará para ajustes por parte del Municipio</div>
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <asp:Button ID="btCancelarDevolver" class="btn" runat="server" Text="Cancelar" onclick="btCancelarDevolver_Click" CausesValidation="false" />
        <asp:Button ID="btDevolver" class="btn btn-danger" runat="server" Text="Aceptar" onclick="btDevolver_Click" CausesValidation="false" />
    </div>
</asp:Panel>

</asp:Content>